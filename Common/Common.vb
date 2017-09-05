'
' Created by SharpDevelop.
' User: rspage
' Date: 4/4/2005
' Time: 11:55 AM
' 

Imports System
Imports System.Environment
Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Collections
Imports MySql.Data.MySqlClient
Imports NationalInstruments.NI4882

Public Module [Global]
    Public DebugMode As Boolean = False
End Module

Public Module FreeCalDBConnection

    Public DBConnectionString As String = "Server=localhost;Database=freecal;Username=freecal;password="
    Public DBConnection As New MySqlConnection(DBConnectionString)

End Module

Public Module ConfigurationOptions
    'CONFIG : Form Colors
    Public FormBackColor As Color = Color.SlateGray
    Public FormForeColor As Color = Color.Beige
    Public ButtonBackColor As Color = Color.SlateGray
    Public ButtonForeColor As Color = Color.Red
    Public LabelBackColor As Color = Color.SlateGray
    Public LabelForeColor As Color = Color.Red
    Public TextBoxBackColor As Color = Color.LightGray
    Public TextBoxForeColor As Color = Color.Red
    Public GroupBoxBackColor As Color = Color.SlateGray
    Public GroupBoxForeColor As Color = Color.Beige

    'CONFIG : GPIB
    Public RunFreeCalInNonGPIBMode As Boolean = False
    Public DefaultTimeout As TimeoutValue = TimeoutValue.T10s

End Module

Public Module GlobalFunctions

    Public Function ConvertFrequency(ByVal frequencySetting As Double, ByVal frequencySettingSuffix As FrequencyEnum, ByVal desiredFrequencySuffix As FrequencyEnum) As Double
        Dim NewFrequencySetting As Double = frequencySetting
        Select Case frequencySettingSuffix
            Case FrequencyEnum.GHz
                Select Case desiredFrequencySuffix
                    Case FrequencyEnum.MHz
                        NewFrequencySetting = NewFrequencySetting * 1000
                    Case FrequencyEnum.KHz
                        NewFrequencySetting = NewFrequencySetting * 1000000
                    Case FrequencyEnum.Hz
                        NewFrequencySetting = NewFrequencySetting * 1000000000
                End Select
            Case FrequencyEnum.MHz
                Select Case desiredFrequencySuffix
                    Case FrequencyEnum.GHz
                        NewFrequencySetting = NewFrequencySetting / 1000
                    Case FrequencyEnum.KHz
                        NewFrequencySetting = NewFrequencySetting / 1000000
                    Case FrequencyEnum.Hz
                        NewFrequencySetting = NewFrequencySetting * 1000000
                End Select
            Case FrequencyEnum.KHz
                Select Case desiredFrequencySuffix
                    Case FrequencyEnum.GHz
                        NewFrequencySetting = NewFrequencySetting / 1000000
                    Case FrequencyEnum.MHz
                        NewFrequencySetting = NewFrequencySetting / 1000
                    Case FrequencyEnum.Hz
                        NewFrequencySetting = NewFrequencySetting * 1000
                End Select
            Case FrequencyEnum.Hz
                Select Case desiredFrequencySuffix
                    Case FrequencyEnum.GHz
                        NewFrequencySetting = NewFrequencySetting / 1000000000
                    Case FrequencyEnum.MHz
                        NewFrequencySetting = NewFrequencySetting / 1000000
                    Case FrequencyEnum.KHz
                        NewFrequencySetting = NewFrequencySetting / 1000
                End Select
        End Select
        Return NewFrequencySetting
    End Function

    Public Function ConvertAmplitude(ByVal amplitudeSetting As Double, ByVal amplitudeSettingSuffix As AmplitudeEnum, ByVal desiredAmplitudeSuffix As AmplitudeEnum) As Double
        Dim NewAmplitudeSetting As Double = amplitudeSetting
        Select Case amplitudeSettingSuffix
            Case AmplitudeEnum.dBm
                Select Case desiredAmplitudeSuffix
                    Case AmplitudeEnum.dBmW
                    Case AmplitudeEnum.mW
                        NewAmplitudeSetting = CDbl(10 * Math.Log10(NewAmplitudeSetting))
                    Case AmplitudeEnum.W
                        NewAmplitudeSetting = CDbl((10 ^ (NewAmplitudeSetting / 10)) / 1000)
                End Select
            Case AmplitudeEnum.dBmW
                Select Case desiredAmplitudeSuffix
                    Case AmplitudeEnum.dBm
                    Case AmplitudeEnum.mW
                    Case AmplitudeEnum.W
                End Select
            Case AmplitudeEnum.mW
                Select Case desiredAmplitudeSuffix
                    Case AmplitudeEnum.dBm
                        NewAmplitudeSetting = CDbl(10 ^ (NewAmplitudeSetting / 10))
                    Case AmplitudeEnum.dBmW
                    Case AmplitudeEnum.W
                        NewAmplitudeSetting = NewAmplitudeSetting * 1000
                End Select
            Case AmplitudeEnum.W
                Select Case desiredAmplitudeSuffix
                    Case AmplitudeEnum.dBm
                        NewAmplitudeSetting = CDbl(10 * Math.Log10(NewAmplitudeSetting / 0.001))
                    Case AmplitudeEnum.dBmW
                    Case AmplitudeEnum.mW
                        NewAmplitudeSetting = NewAmplitudeSetting / 1000
                End Select
        End Select
        Return NewAmplitudeSetting
    End Function

    Public Function FrequencySettingIsToLarge(ByVal attemptedFrequency As Double, ByVal maximumFrequency As Double, ByVal attemptedFrequencySuffix As FrequencyEnum, ByVal maximumFrequencySuffix As FrequencyEnum) As Boolean
        Select Case attemptedFrequencySuffix
            Case FrequencyEnum.GHz
                attemptedFrequency = attemptedFrequency * 1000
            Case FrequencyEnum.KHz
                attemptedFrequency = attemptedFrequency / 1000
            Case FrequencyEnum.Hz
                attemptedFrequency = (attemptedFrequency / 1000) / 1000
        End Select
        Select Case maximumFrequencySuffix
            Case FrequencyEnum.GHz
                maximumFrequency = maximumFrequency * 1000
            Case FrequencyEnum.KHz
                maximumFrequency = maximumFrequency / 1000
            Case FrequencyEnum.Hz
                maximumFrequency = (maximumFrequency / 1000) / 1000
        End Select
        If attemptedFrequency > maximumFrequency Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function AmplitudeSettingIsToLarge(ByVal attemptedAmplitude As Double, ByVal maximumAmplitude As Double, ByVal attemptedAmplitudeSuffix As AmplitudeEnum, ByVal maximumAmplitudeSuffix As AmplitudeEnum) As Boolean
        Select Case attemptedAmplitudeSuffix
            Case AmplitudeEnum.W
                attemptedAmplitude = ConvertAmplitude(attemptedAmplitude, attemptedAmplitudeSuffix, AmplitudeEnum.dBm)
        End Select
        Select Case maximumAmplitudeSuffix
            Case AmplitudeEnum.W
                maximumAmplitude = ConvertAmplitude(maximumAmplitude, maximumAmplitudeSuffix, AmplitudeEnum.dBm)
        End Select
        If attemptedAmplitude > maximumAmplitude Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function TimePeriodIsToLarge(ByVal attemptedTimePeriod As Integer, ByVal maximumTimePeriod As Integer, ByVal attemptedTimePeriodSuffix As TimeEnum, ByVal maximumTimePeriodSuffix As TimeEnum) As Boolean
        Select Case attemptedTimePeriodSuffix
            Case TimeEnum.Minutes
                attemptedTimePeriod \= 60
            Case TimeEnum.MilliSeconds
                attemptedTimePeriod *= 1000
            Case TimeEnum.MicroSeconds
                attemptedTimePeriod = (attemptedTimePeriod * 1000) * 1000
        End Select
        Select Case maximumTimePeriodSuffix
            Case TimeEnum.Minutes
                maximumTimePeriod \= 60
            Case TimeEnum.MilliSeconds
                maximumTimePeriod *= 1000
            Case TimeEnum.MicroSeconds
                maximumTimePeriod = (maximumTimePeriod * 1000) * 1000
        End Select
        If attemptedTimePeriod > maximumTimePeriod Then Return True
        Return False
    End Function

    Public Sub SetControlConfigurationOptions(ByVal formToProcess As Form, ByVal controls As Control.ControlCollection)
        formToProcess.BackColor = ButtonBackColor
        formToProcess.ForeColor = ButtonForeColor
        For Each FormControl As Control In controls
            Select Case FormControl.GetType.ToString
                Case "System.Windows.Forms.Button"
                    FormControl.BackColor = ButtonBackColor
                    FormControl.ForeColor = ButtonForeColor
                Case "System.Windows.Forms.Label"
                    FormControl.BackColor = LabelBackColor
                    FormControl.ForeColor = LabelForeColor
                Case "System.Windows.Forms.TextBox"
                    FormControl.BackColor = TextBoxBackColor
                    FormControl.ForeColor = TextBoxForeColor
                Case "System.Windows.Forms.GroupBox"
                    FormControl.BackColor = GroupBoxBackColor
                    FormControl.ForeColor = GroupBoxForeColor
                    For Each GroupBoxControl As Control In controls
                        Select Case GroupBoxControl.GetType.ToString
                            Case "System.Windows.Forms.Button"
                                GroupBoxControl.BackColor = ButtonBackColor
                                GroupBoxControl.ForeColor = ButtonForeColor
                            Case "System.Windows.Forms.Label"
                                GroupBoxControl.BackColor = LabelBackColor
                                GroupBoxControl.ForeColor = LabelForeColor
                            Case "System.Windows.Forms.TextBox"
                                GroupBoxControl.BackColor = TextBoxBackColor
                                GroupBoxControl.ForeColor = TextBoxForeColor
                        End Select
                    Next
            End Select
        Next
    End Sub

    Public Function GetActiveGPIBBusNames() As List(Of String)
        Dim ActiveBoards As New List(Of String)
        Dim Board0 As Board = Nothing
        Dim Board1 As Board = Nothing
        Dim Board2 As Board = Nothing
        Dim Board3 As Board = Nothing
        Try
            Board0 = New Board(Boards.GPIB0)
            ActiveBoards.Add(Boards.GPIB0.ToString)
        Catch
        Finally
            If Board0 IsNot Nothing Then
                Board0.Dispose()
            End If
        End Try
        Try
            Board1 = New Board(Boards.GPIB1)
            ActiveBoards.Add(Boards.GPIB1.ToString)
        Catch
        Finally
            If Board1 IsNot Nothing Then
                Board1.Dispose()
            End If
        End Try
        Try
            Board2 = New Board(Boards.GPIB2)
            ActiveBoards.Add(Boards.GPIB2.ToString)
        Catch
        Finally
            If Board2 IsNot Nothing Then
                Board2.Dispose()
            End If
        End Try
        Try
            Board3 = New Board(Boards.GPIB3)
            ActiveBoards.Add(Boards.GPIB3.ToString)
        Catch
        Finally
            If Board3 IsNot Nothing Then
                Board3.Dispose()
            End If
        End Try
        If ActiveBoards.Count = 0 Then
            RunFreeCalInNonGPIBMode = True
        End If
        Return ActiveBoards
    End Function

    Public Function GetGPIBBusAddresses(ByVal gPIBBoardToSearch As Boards) As List(Of Byte)
        Dim BusDevices As New List(Of Byte)
        Dim MyBoard As Board = Nothing
        Try
            MyBoard = New Board(gPIBBoardToSearch)
            MyBoard.SendInterfaceClear()
            Dim Devices As AddressCollection = MyBoard.FindListeners()
            For Each CurrentBoardDevice As Address In Devices
                BusDevices.Add(CurrentBoardDevice.PrimaryAddress)
            Next
        Catch
        Finally
            If Not MyBoard Is Nothing Then
                MyBoard.Dispose()
            End If
        End Try
        Return BusDevices
    End Function

    Public Function SortList(ByVal list() As Double) As Double()
        Dim AL As New ArrayList
        For Each V As Double In list
            AL.Add(CDbl(V))
        Next
        AL.Sort(New SingleComparer)
        AL.CopyTo(list)
        Return list
    End Function

End Module

Public Class SingleComparer
    Implements IComparer

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
        Dim sX As Double
        Dim sY As Double
        Try
            sX = CType(x, Single)
            sY = CType(y, Single)
        Catch Ex As Exception
            MessageBox.Show(Ex.ToString)
        End Try
        If sX < sY Then
            Return -1
        Else
            If sX > sY Then
                Return 1
            Else
                Return 0
            End If
        End If
    End Function

End Class

#Region "Enums"

<Flags()>
Public Enum InstrumentStatusFlags As Integer
    EventStatusRegister = 1
    MessageAvailable = 2
    RequestingService = 4
    Attention = 8
End Enum

Public Enum Boards As Integer
    GPIB0 = 0
    GPIB1 = 1
    GPIB2 = 2
    GPIB3 = 3
End Enum

Public Enum FrequencyEnum As Integer
    Hz = 1
    KHz = 1000
    MHz = 1000000
    GHz = 1000000000
End Enum

Public Enum AmplitudeEnum
    dBm
    dBmW
    W
    mW
    V
    mV
    uV
    nV
    pV
    fV
    nI
    uI
    mI
    I
    Ohm
End Enum

Public Enum ModulationModeEnum
    AM = 1
    FM = 2
    PM = 3
End Enum

Public Enum TimeEnum
    Minutes
    Seconds
    MilliSeconds
    MicroSeconds
    NanoSeconds
End Enum

Public Enum OnOffStateEnum
    [On] = 1
    [Off] = 0
End Enum

Public Enum AutomaticManualModeEnum
    [Auto] = 1
    Manual = 0
End Enum

Public Enum TriggerModeEnum
    FreeRun = 0
    Hold = 1
    FastSampleNoDelay = 2
    SampleThenHold = 3
End Enum

Public Enum GenderEnum
    Male
    Female
End Enum

Public Enum WaveformEnum
    Sine
    Square
    Triangle
    PositiveRise
    NegativeRise
End Enum

Public Enum ConnectorTypeEnum
    mm24
    mm25
    mm35
    mm7
    BNC
    N
End Enum

Public Enum CalibrationFactorScaleEnum
    Percent
    dBm
End Enum

#End Region

Public Module Directories
    Public MainDirectory As String = My.Application.Info.DirectoryPath
    Public ProgramDirectory As String = MainDirectory
    Public ResourceDirectory As String = MainDirectory
    Public EEPROMDataDirectory As String = MainDirectory
    Public LogDirectory As String = MainDirectory

    Public Sub CreateDirectories()
        Try
            If Not Directory.Exists(MainDirectory) Then
                Directory.CreateDirectory(MainDirectory)
            End If
            If Not Directory.Exists(Path.Combine(ProgramDirectory, "Resources")) Then
                Directory.CreateDirectory(Path.Combine(ProgramDirectory, "Resources"))
            End If
            If Not Directory.Exists(Path.Combine(ProgramDirectory, "Configuration")) Then
                Directory.CreateDirectory(Path.Combine(ProgramDirectory, "Configuration"))
            End If
            If Not Directory.Exists(Path.Combine(MainDirectory, "EEPROM Data")) Then
                Directory.CreateDirectory(Path.Combine(MainDirectory, "EEPROM Data"))
            End If
            If Not Directory.Exists(Path.Combine(MainDirectory, "Log Files")) Then
                Directory.CreateDirectory(Path.Combine(ProgramDirectory, "Log Files"))
            End If
        Catch Ex As Exception
            MessageBox.Show(String.Concat("There was a problem creating the program directories.", NewLine, NewLine, "The Error Message is:", NewLine, Ex.Message, NewLine, Ex.StackTrace))
        End Try
    End Sub

End Module
