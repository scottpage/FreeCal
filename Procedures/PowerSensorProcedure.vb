'
' Created by SharpDevelop.
' User: rspage
' Date: 6/15/2005
' Time: 12:49 PM
' 

Imports NationalInstruments.NI4882
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.ControlChars
Imports System
Imports System.Data
Imports System.IO
Imports System.Threading
Imports System.Windows.Forms
Imports FreeCal.Common
Imports FreeCal.Instruments
Imports FreeCal.Instruments.NetworkAnalyzers
Imports FreeCal.Instruments.FunctionGenerators
Imports FreeCal.Instruments.PowerMeters
Imports FreeCal.Instruments.SignalGenerators
Imports FreeCal.Instruments.AttenuatorSwitchDrivers
Imports FreeCal.DialogBoxes
Imports FreeCal.Data
Imports ZedGraph
Imports FreeCal.Conversion



Public Class PowerSensorProcedure
    Inherits FreeCal.Procedures.Procedure

#Region "Declarations"

    Protected HighFrequencySource As SignalGenerator
    Protected LowFrequencySource As FunctionGenerator
    Protected PwrMtr As PowerMeter
    Protected NetworkAn As NetworkAnalyzer
    Protected SwitchDriver As AttenuatorSwitchDriver
    Protected _ResultDataGrid As DataGrid
    Protected _ReferenceLevel As Double
    Protected _ReferenceLevelSuffix As AmplitudeEnum

    Private SensorSerialNumbers() As String
    Private ChartForm As PowerSensorCalibrationChartForm

    Private _FrequencyList() As Double
    Private _FrequencyListSuffix As FrequencyEnum
    Private SWRList() As Double
    Private StandardSensorSerialNumber As String
    Private ReferenceSensorSerialNumber As String

    Private FCResources As String = ResourceDirectory & "FreeCal.Instruments."
    Private Canceled As Boolean = False

    Public Results As PowerSensorTestResultsTable
    Private ReferencePowerLevels() As Double

    Public SelectedHighFrequencySource As String
    Public HighFrequencySourceAddress As Byte

    Public SelectedLowFrequencySource As String
    Public LowFrequencySourceAddress As Byte

    Public SelectedPwrMtr As String
    Public PwrMtrAddress As Byte

    Public SelectedNetworkAnalyzer As String
    Public NetworkAnalyzerAddress As Byte

    Public SelectedAttenuatorSwitchDriver As String
    Public AttenuatorSwitchDriverAddress As Byte

    Private ChartSymbol As SymbolType

#End Region

#Region "Properties"

    Public Property ReferenceLevel As Double
        Get
            Return Me._ReferenceLevel
        End Get
        Set
            Me._ReferenceLevel = Value
        End Set
    End Property

    Public Property ReferenceLevelSuffix As AmplitudeEnum
        Get
            Return Me._ReferenceLevelSuffix
        End Get
        Set
            Me._ReferenceLevelSuffix = Value
        End Set
    End Property

    Public Property FrequencyList As Double()
        Get
            Return Me._FrequencyList
        End Get
        Set
            Me._FrequencyList = Value
        End Set
    End Property

    Public Property FrequencyListSuffix As FrequencyEnum
        Get
            Return Me._FrequencyListSuffix
        End Get
        Set
            Me._FrequencyListSuffix = Value
        End Set
    End Property

#End Region

#Region "Constructors"

    Public Sub New(ByVal dUTAssetNumber As String, ByRef ResultDataGrid As DataGrid, Optional ByVal oldResults As PowerSensorTestResultsTable = Nothing)
        MyBase.New(dUTAssetNumber)
        Me.Results = New PowerSensorTestResultsTable(dUTAssetNumber)
        Me._ResultDataGrid = ResultDataGrid
        Me._ResultDataGrid.DataSource = Me.Results
        Me._ResultDataGrid.Refresh()
        Me._ResultDataGrid.Update()
        If Not oldResults Is Nothing Then Me.Results.OldDUTCalibrationFactors = oldResults
    End Sub

#End Region

#Region "Instruments"

    Private Sub InitializeInstruments()
        If (Me.HighFrequencySource Is Nothing) Then
            Select Case Me.SelectedHighFrequencySource
                Case "AgilentE4433B"
                    Me.HighFrequencySource = New AgilentE4433B(0, Me.HighFrequencySourceAddress, False, Me._Simulate)
                Case "IFR2050"
                    Me.HighFrequencySource = New IFR2050(0, Me.HighFrequencySourceAddress, False, Me._Simulate)
                Case "Agilent8340A"
                    Me.HighFrequencySource = New Agilent8340A(0, Me.HighFrequencySourceAddress, False, Me._Simulate)
                Case "Agilent8340B"
                    Me.HighFrequencySource = New Agilent8340B(0, Me.HighFrequencySourceAddress, False, Me._Simulate)
                Case "Agilent8643A"
                    Me.HighFrequencySource = New Agilent8643A(0, Me.HighFrequencySourceAddress, False, Me._Simulate)
                Case "Agilent8660D"
                    Me.HighFrequencySource = New Agilent8660D(0, Me.HighFrequencySourceAddress, False, Me._Simulate)
                Case "AnritsuMG3696A"
                    Me.HighFrequencySource = New AnritsuMG3696A(0, Me.HighFrequencySourceAddress, False, Me._Simulate)
                Case "Agilent8672A"
                    Me.HighFrequencySource = New Agilent8672A(0, Me.HighFrequencySourceAddress, False, Me._Simulate)
            End Select
        End If
        Try
            If (Me.LowFrequencySource Is Nothing) Then
                Select Case Me.SelectedLowFrequencySource
                    Case "Agilent3325B"
                        Me.LowFrequencySource = New Agilent3325B(0, Me.LowFrequencySourceAddress, False, Me._Simulate)
                End Select
            End If
        Catch
        End Try
        Try
            If (Me.NetworkAn Is Nothing) Then
                Select Case Me.SelectedNetworkAnalyzer
                    Case "Agilent8510C"
                        Me.NetworkAn = New Agilent8510C(0, Me.NetworkAnalyzerAddress, False, Me._Simulate)
                    Case "Agilent8720B"
                        Me.NetworkAn = New Agilent8720B(0, Me.NetworkAnalyzerAddress, False, Me._Simulate)
                End Select
            End If
        Catch
        End Try
        Try
            If (Me.PwrMtr Is Nothing) Then
                Me.PwrMtr = New AgilentE4417A(0, Me.PwrMtrAddress, False, Me._Simulate)
            End If
        Catch
        End Try
        Try
            If (Me._GPIB0 Is Nothing) Then
                Me._GPIB0 = New Board(0)
            End If
            Me._GPIB0.IOTimeout = TimeoutValue.T3s
            Me._GPIB0.SendInterfaceClear()
            Me._GPIB0.BecomeActiveController(True)
        Catch
        End Try
        Try
            Me.HighFrequencySource.Preset()
        Catch
        End Try
        Try
            Me.LowFrequencySource.Preset()
        Catch
        End Try
        Try
            Me.PwrMtr.Preset()
        Catch
        End Try
        Try
            Me.NetworkAn.Preset()
        Catch
        End Try
    End Sub

    Public Sub UnInitializeInstruments()
        Try
            Me.HighFrequencySource.Dispose()
        Catch
        End Try
        Try
            Me.LowFrequencySource.Dispose()
        Catch
        End Try
        Try
            Me.PwrMtr.Dispose()
        Catch
        End Try
        Try
            Me.NetworkAn.Dispose()
        Catch
        End Try
        Try
            Me._GPIB0.Dispose()
        Catch
        End Try
    End Sub

#End Region

    Private Sub SetSourceAmplitude(ByVal desiredAmplitudeSetting As Double, ByVal desiredAmplitudeSuffix As AmplitudeEnum, ByVal pwrMtrChannel As String, ByVal source As String)
        Dim PwrMtrReading As Double
        Dim LoopCounter As Integer = 0
        If source = "LowFrequency" Then
            Thread.Sleep(1000)
            Me.LowFrequencySource.Amplitude = desiredAmplitudeSetting
            PwrMtrReading = Me.PwrMtr.Sections.Measurements.GetAveragedMeasurement(30, "A")
            Do While (PwrMtrReading > desiredAmplitudeSetting + 0.02 Or PwrMtrReading < desiredAmplitudeSetting - 0.02)
                If (PwrMtrReading > desiredAmplitudeSetting) Then
                    Me.LowFrequencySource.Amplitude = Me.LowFrequencySource.Amplitude - PwrMtrReading
                ElseIf (PwrMtrReading < desiredAmplitudeSetting) Then
                    Me.LowFrequencySource.Amplitude = Me.LowFrequencySource.Amplitude - PwrMtrReading
                End If
                Thread.Sleep(500)
                PwrMtrReading = Me.PwrMtr.Sections.Measurements.GetAveragedMeasurement(30, "A")
            Loop
        ElseIf source = "HighFrequency" Then
            Me.HighFrequencySource.Sections.RF.Amplitude.Level = desiredAmplitudeSetting
            Thread.Sleep(500)
            If pwrMtrChannel = "A" Then
                PwrMtrReading = Convert.ToDouble(Format(Me.PwrMtr.Sections.Measurements.GetAveragedMeasurement(30, "A"), "#0.00"))
            ElseIf pwrMtrChannel = "B" Then
                PwrMtrReading = Convert.ToDouble(Format(Me.PwrMtr.Sections.Measurements.GetAveragedMeasurement(30, "B"), "#0.00"))
            End If
            Do While (PwrMtrReading > desiredAmplitudeSetting + 0.01 Or PwrMtrReading < desiredAmplitudeSetting)
                If desiredAmplitudeSetting = 0 Then
                    Me.HighFrequencySource.Sections.RF.Amplitude.Level += desiredAmplitudeSetting - PwrMtrReading
                ElseIf (desiredAmplitudeSetting > 0) Then
                    Me.HighFrequencySource.Sections.RF.Amplitude.Level += desiredAmplitudeSetting - PwrMtrReading
                ElseIf (desiredAmplitudeSetting < 0) Then
                    Me.HighFrequencySource.Sections.RF.Amplitude.Level += desiredAmplitudeSetting - PwrMtrReading
                End If
                Thread.Sleep(500)
                If pwrMtrChannel = "A" Then
                    PwrMtrReading = Convert.ToDouble(Format(Me.PwrMtr.Sections.Measurements.GetAveragedMeasurement(30, "A"), "#0.00"))
                ElseIf pwrMtrChannel = "B" Then
                    PwrMtrReading = Convert.ToDouble(Format(Me.PwrMtr.Sections.Measurements.GetAveragedMeasurement(30, "B"), "#0.00"))
                End If
            Loop
        End If
    End Sub

    Public Sub AllTests()
        Me.InitializeInstruments()
        Me.SParametersTest()

        If (Not Me.Canceled) Then
            Me.CalibrationFactors()
        End If
        If (Not Me.Canceled) Then
        End If
    End Sub

    Public Sub SParametersTest()
        Dim UserChoice As DialogResult = MessageBox.Show("Do you want to obtain Magnitude and Phase data from the Network Analyzer?", "User Intevention Required", MessageBoxButtons.YesNoCancel)
        Select Case UserChoice
            Case DialogResult.No
                Return
            Case DialogResult.Cancel
                Me.Canceled = True
        End Select
        Try
            If (Not Me.Canceled) Then

            End If
        Catch Ex As Exception
            MessageBox.Show(Ex.Message)
        Finally
            Me.UnInitializeInstruments()
        End Try
    End Sub

    Public Sub CalibrationFactors()
        Try
            Dim R As String = String.Empty
            For Each T As Double In Me.FrequencyList
                R = R & T.ToString & ", "
            Next
            MessageBox.Show(R)
            ReDim Me.ReferencePowerLevels(Me.FrequencyList.GetUpperBound(0) + 1)
            Me.SensorSerialNumbers = Me.PwrMtr.Sections.Memory.GetCalibrationFactorTableNames
            Dim StdRefSNForm As New PowerSensorProcedureStdRefSNForm(Me.SensorSerialNumbers)
            If StdRefSNForm.ShowDialog = DialogResult.OK Then
                Me.ReferenceSensorSerialNumber = StdRefSNForm.SelectedReferenceSensorSerialNumber
                Me.StandardSensorSerialNumber = StdRefSNForm.SelectedStandardSensorSerialNumber
                Me.PwrMtr.Write("SENS1:CORR:CSET1 " & Quote & Me.StandardSensorSerialNumber & Quote)
                Me.PwrMtr.Write("SENS1:CORR:CSET1:STAT ON")
            End If
            MessageBox.Show("Connect the Standard Power Sensor to the Power Meter A Channel" & NewLine & "and the Reference (Transfer) Power Sensor to Power Meter B Channel.")
            Me.PwrMtr.Sections.Calibration.ZeroAndCalibrate("A")
            Me.PwrMtr.Sections.Calibration.ZeroAndCalibrate("B")
            MessageBox.Show("Connect the Standard Power Sensor to Port 3 of the Power Splitter." & NewLine & "and the Reference (Transfer) Power Sensor to Port 2 of the Power Splitter.")
            Me.PwrMtr.Write("UNIT1:POW DBM")
            Me.PwrMtr.Write("UNIT2:POW DBM")
            If ConvertFrequency.Convert(Me.FrequencyList(0), Me.FrequencyListSuffix, FrequencyEnum.MHz) > 10 Then
                Me.HighFrequencySource.Sections.RF.OutputState = OnOffStateEnum.[Off]
                Me.PwrMtr.Sections.Calibration.Zero("A", True)
                Me.PwrMtr.Sections.Calibration.Zero("B", True)
                Me.HighFrequencySource.Sections.RF.OutputState = OnOffStateEnum.[On]
            Else
                Me.HighFrequencySource.Sections.RF.OutputState = OnOffStateEnum.[Off]
                Me.PwrMtr.Sections.Calibration.Zero("A", True)
                Me.PwrMtr.Sections.Calibration.Zero("B", True)
                Me.HighFrequencySource.Sections.RF.OutputState = OnOffStateEnum.[On]
            End If
            Dim MeasurementCounter As Integer = 0
            Dim TestFrequencyInMHz As Double
            For Each TestFrequency As Double In Me.FrequencyList
                TestFrequencyInMHz = ConvertFrequency.Convert(TestFrequency, Me.FrequencyListSuffix, FrequencyEnum.MHz)
                Me.PwrMtr.SetCalibrationFactor(TestFrequencyInMHz)
                If TestFrequencyInMHz < 10 Then
                    MessageBox.Show(TestFrequencyInMHz.ToString)
                    Me.LowFrequencySource.Amplitude = Me.LowFrequencySource.Capabilities.MinimumAmplitude
                    Me.LowFrequencySource.Output = FunctionGeneratorOutputEnum.Front
                    Me.LowFrequencySource.Output = FunctionGeneratorOutputEnum.Rear
                    Me.LowFrequencySource.Waveform = WaveformEnum.Sine
                    Me.LowFrequencySource.FrequencySuffix = FrequencyEnum.MHz
                    Me.LowFrequencySource.Frequency = TestFrequencyInMHz
                    Me.SetSourceAmplitude(Me.ReferenceLevel, Me.ReferenceLevelSuffix, "A", "LowFrequency")
                Else
                    Me.HighFrequencySource.Sections.RF.Frequency.Suffix = FrequencyEnum.MHz
                    Me.HighFrequencySource.Sections.RF.Frequency.CW = TestFrequencyInMHz
                    Me.SetSourceAmplitude(Me.ReferenceLevel, Me.ReferenceLevelSuffix, "A", "HighFrequency")
                End If
                Me.ReferencePowerLevels(MeasurementCounter) = Me.PwrMtr.Sections.Measurements.GetAveragedMeasurement(5, "B")
                MeasurementCounter += 1
            Next
        Catch Ex As Exception
            MessageBox.Show(Ex.ToString)
        Finally
        End Try
        Me.DUTCalibrationFactorsTest()
    End Sub

    Private Sub DUTCalibrationFactorsTest()
        Try
            Me.ChartForm = New PowerSensorCalibrationChartForm
            Me.ChartForm.Close()
            Me.ChartForm.StartPosition = FormStartPosition.CenterScreen
            Me.ChartForm.Chart.GraphPane.CurveList.Clear()
            Me.Results.Rows.Clear()
            Me.Results.AssetNumber = Me.DUTAssetNumber
            Dim MeasurementCounter As Integer = 0
            Dim DUTMeasurements(Me.ReferencePowerLevels.GetUpperBound(0)) As Double
            MessageBox.Show("Connect the DUT Sensor to Channel A of the Power Meter.")
            Me.PwrMtr.Write("SENS1:CORR:CSET1:STAT OFF")
            Me.PwrMtr.Write("SENS1:CORR:GAIN1 100")
            Me.PwrMtr.Write("UNIT1:POW W")
            Me.PwrMtr.Sections.Calibration.ZeroAndCalibrate("A")
            MessageBox.Show("Connect the DUT to the Power Splitter.")
            Me.HighFrequencySource.Sections.RF.OutputState = OnOffStateEnum.[Off]
            Me.PwrMtr.Sections.Calibration.Zero("A", True)
            Me.HighFrequencySource.Sections.RF.OutputState = OnOffStateEnum.[On]
            Dim M(Me.ReferencePowerLevels.GetUpperBound(0)) As Double
            Dim Measurement As Double
            Me.ChartForm.Show()
            Dim PPL As New PointPairList
            Dim R As New Random(DateTime.Now.Millisecond)
            Me.ChartSymbol = CType(R.Next(12), SymbolType)
            Me.ChartForm.Chart.GraphPane.AddCurve(Me.DUTAssetNumber, PPL, System.Drawing.Color.Red, Me.ChartSymbol)
            Me.ChartForm.Chart.AxisChange()

            If Me.Results.UseOldDUTCalibrationFactors Then
                Dim OldResultsPPL As New PointPairList
                For Each DR As DataRow In Me.Results.OldDUTCalibrationFactors.Rows
                    Dim OldResultsP As New PointPair
                    OldResultsP.X = ConvertFrequency.Convert(Convert.ToDouble(DR("FrequencyGHz")), Me.FrequencyListSuffix, FrequencyEnum.GHz)
                    OldResultsP.Y = Convert.ToDouble(DR("CalibrationFactor"))
                    OldResultsPPL.Add(OldResultsP)
                Next
                R = New Random(DateTime.Now.Millisecond)
                Me.ChartSymbol = CType(R.Next(12), SymbolType)
                Me.ChartForm.Chart.GraphPane.AddCurve("Old data", OldResultsPPL, System.Drawing.Color.Red, Me.ChartSymbol)
            End If
            Dim TestFrequencyInMHz As Double
            For Each TestFrequency As Double In Me.FrequencyList
                TestFrequencyInMHz = ConvertFrequency.Convert(TestFrequency, Me.FrequencyListSuffix, FrequencyEnum.MHz)
                If TestFrequencyInMHz < 10 Then
                    MessageBox.Show(TestFrequencyInMHz.ToString)
                    Me.LowFrequencySource.Output = FunctionGeneratorOutputEnum.Rear
                    Me.LowFrequencySource.Waveform = WaveformEnum.Sine
                    Me.LowFrequencySource.FrequencySuffix = FrequencyEnum.MHz
                    Me.LowFrequencySource.Frequency = TestFrequencyInMHz
                    Me.SetSourceAmplitude(Me.ReferenceLevel, Me.ReferenceLevelSuffix, "A", "LowFrequency")
                Else
                    Me.HighFrequencySource.Sections.RF.Frequency.Suffix = FrequencyEnum.MHz
                    Me.HighFrequencySource.Sections.RF.Frequency.CW = TestFrequencyInMHz
                    Me.SetSourceAmplitude(ReferencePowerLevels(MeasurementCounter), AmplitudeEnum.dBm, "B", "HighFrequency")
                End If
                Measurement = Me.PwrMtr.Sections.Measurements.GetAveragedMeasurement(10, "A")
                M(MeasurementCounter) = Measurement
                Me.Results.StoreResult("Calibration Factor", ConvertFrequency.Convert(TestFrequencyInMHz, FrequencyEnum.MHz, Me.FrequencyListSuffix), FrequencyEnum.GHz, Measurement)
                Me._ResultDataGrid.Refresh()
                Me._ResultDataGrid.Update()
                Dim P As New PointPair
                P.X = CDbl(ConvertFrequency.Convert(TestFrequencyInMHz, FrequencyEnum.MHz, Me.FrequencyListSuffix))
                P.Y = CDbl(Measurement)
                Me.ChartForm.Chart.GraphPane.CurveList(0).AddPoint(P)
                Me.ChartForm.Chart.AxisChange()
                Me.ChartForm.Refresh()
                Me.ChartForm.Update()
                Me.ChartForm.Chart.Refresh()
                Me.ChartForm.Chart.Update()
                MeasurementCounter += 1
            Next
        Catch Ex As Exception
            MessageBox.Show(Ex.ToString)
        Finally
            Me._ResultDataGrid.Update()
            Me._ResultDataGrid.Refresh()

            If MessageBox.Show("Do you want to save the chart?", "Calibration Complete", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            End If
            If MessageBox.Show("Do you want to calibrate another Sensor using the current Reference setup?", "End of Calibration", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Me.DUTAssetNumber = InputBox("What is the Asset Number of the DUT?")
                Me.DUTCalibrationFactorsTest()
            End If
            Me.UnInitializeInstruments()
        End Try
    End Sub

End Class



