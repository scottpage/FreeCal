'
' Created by SharpDevelop.
' User: rspage
' Date: 6/14/2005
' Time: 12:58 PM
' 

Imports System
Imports FreeCal.Common
Imports FreeCal.Instruments
Imports NationalInstruments.NI4882
Imports System.Windows.Forms



    Public Class Counter
        Inherits FreeCal.Instruments.Instrument

#Region "Declarations"

    Protected _Commands As CounterGPIBCommands
    Protected _Specifications As CounterSpecifications
    Protected _Capabilities As CounterCapabilities
    Protected _TestPoints As CounterTestPoints

    Protected _CenterFrequency As Integer
    Protected _AmplitudeMode As OnOffStateEnum
    Protected _FrequencyMode As AutomaticManualModeEnum
    Protected _FrequencyRange As CounterFrequencyRangeEnum
    Protected _Resolution As Agilent5343AResolutionModeEnum
    Protected _TriggerMode As TriggerModeEnum
    Protected _OutputMode As Agilent5343AOutputModeEnum
    Protected _AcquisitionTime As Agilent5343AAcquisitionTimeEnum

#End Region

#Region "Properties"

    Public ReadOnly Property TestPoints() As CounterTestPoints
        Get
            Return Me._TestPoints
        End Get
    End Property

    Public ReadOnly Property Commands() As CounterGPIBCommands
        Get
            Return Me._Commands
        End Get
    End Property

    Public ReadOnly Property Specifications() As CounterSpecifications
        Get
            Return Me._Specifications
        End Get
    End Property

    Public ReadOnly Property Capabilities() As CounterCapabilities
        Get
            Return Me._Capabilities
        End Get
    End Property

#End Region

#Region "Methods"

    Public Sub New(ByVal boardAddress As Integer, ByVal primaryAddress As Byte, ByVal getSettingsFromInstrument As Boolean, Optional ByVal simulate As Boolean = False)
        MyBase.New(boardAddress, primaryAddress, getSettingsFromInstrument, simulate)
    End Sub

#End Region

#Region "Functions"

#End Region

    Public Property FrequencyMode() As AutomaticManualModeEnum
        Get
            Return Me._FrequencyMode
        End Get
        Set(ByVal Value As AutomaticManualModeEnum)
            Me._FrequencyMode = Value
            Select Case Value
                Case AutomaticManualModeEnum.[Auto]
                    Me.Write(Me.Commands.FrequencyModeAuto)
                Case AutomaticManualModeEnum.Manual
                    Me.Write(Me.Commands.FrequencyModeManual)
            End Select
        End Set
    End Property

    Public Property CenterFrequency() As Integer
        Get
            Return Me._CenterFrequency
        End Get
        Set(ByVal Value As Integer)
            Me._CenterFrequency = Value
            Me.Write(Me.Commands.ManualCenterFrequency & Value & "E")
        End Set
    End Property

    Public Property AmplitudeMode() As OnOffStateEnum
        Get
            Return Me._AmplitudeMode
        End Get
        Set(ByVal Value As OnOffStateEnum)
            Me._AmplitudeMode = Value
            Me.Write(Me.Commands.AmplitudeMode & Value.ToString)
        End Set
    End Property

    Public Property Resolution() As Agilent5343AResolutionModeEnum
        Get
            Return Me._Resolution
        End Get
        Set(ByVal Value As Agilent5343AResolutionModeEnum)
            Me._Resolution = Value
            Me.Write(Me.Commands.Resolution & Value)
        End Set
    End Property

    Public Property TriggerMode() As TriggerModeEnum
        Get
            Return Me._TriggerMode
        End Get
        Set(ByVal Value As TriggerModeEnum)
            Me._TriggerMode = Value
            Me.Write(Me.Commands.TriggerMode & Value)
        End Set
    End Property

    Public Property OutputMode() As Agilent5343AOutputModeEnum
        Get
            Return Me._OutputMode
        End Get
        Set(ByVal Value As Agilent5343AOutputModeEnum)
            Me._OutputMode = Value
            Me.Write(Me.Commands.OutputMode & Value)
        End Set
    End Property

    Public Property AcquisitionTime() As Agilent5343AAcquisitionTimeEnum
        Get
            Return Me._AcquisitionTime
        End Get
        Set(ByVal Value As Agilent5343AAcquisitionTimeEnum)
            Me._AcquisitionTime = Value
            Select Case Value
                Case Agilent5343AAcquisitionTimeEnum.Slow
                    Me.Write(Me.Commands.SlowAcquisitionTime)
                Case Agilent5343AAcquisitionTimeEnum.Medium
                    Me.Write(Me.Commands.MediumAcquisitionTime)
                Case Agilent5343AAcquisitionTimeEnum.Fast
                    Me.Write(Me.Commands.FastAcquisitionTime)
            End Select
        End Set
    End Property

    Public Shadows Function ReadSingle() As Double
        Return CDbl(ReadString(20).Replace(" F ", "").Trim) / 1000000
    End Function

    Public Function SampleThenHoldAndReadDouble() As Double
        Dim Reading As Double = 0
        Write(TriggerModeEnum.SampleThenHold)
        Try
            Reading = CDbl(ReadString(20).Replace(" F ", "")) / 1000000
        Catch
        End Try
        Return Reading
    End Function

    Public Function AccurateSampleThenHoldAndReadDouble() As Double
        Preset()
        FrequencyMode = AutomaticManualModeEnum.[Auto]
        FrequencyRange = CounterFrequencyRangeEnum.High
        AcquisitionTime = Agilent5343AAcquisitionTimeEnum.Slow
        Resolution = Agilent5343AResolutionModeEnum.OneHz
        OutputMode = Agilent5343AOutputModeEnum.WaitUntilAddressed
        Write(TriggerModeEnum.SampleThenHold)
        Return CDbl(Me.ReadString(20).Replace(" F ", "")) / 1000000
    End Function

    'TODO: Figure out what this is supposed to send.
    Public Overloads Sub Write(triggerMode As TriggerModeEnum)

    End Sub

    Public Sub SetFrequencyOffsetModeTo(ByVal onOff As OnOffStateEnum)
        Me.Write(Me.Commands.FrequencyOffsetMode & onOff)
    End Sub

    Public Sub SetFrequencyOffsetTo(ByVal posOrNegMHz As Double)
        Me.Write(Me.Commands.FrequencyOffset & posOrNegMHz & "E")
    End Sub

    Public Sub SetAmplitudeOffsetTo(ByVal posOrNegDB As Double)
        Me.Write(Me.Commands.AmplitudeOffset & posOrNegDB & "E")
    End Sub

    Public Property FrequencyRange() As CounterFrequencyRangeEnum
        Get
            Return Me._FrequencyRange
        End Get
        Set(ByVal Value As CounterFrequencyRangeEnum)
            Me._FrequencyRange = Value
            Select Case Value
                Case CounterFrequencyRangeEnum.High
                    Me.Write(Me.Commands.HighRange)
                Case CounterFrequencyRangeEnum.Low
                    Me.Write(Me.Commands.LowRange)
            End Select
        End Set
    End Property

    Public Sub SetModeTo(ByVal cWorFM As String)
        Select Case cWorFM
            Case "CW"
                Me.Write(Me.Commands.CWMode)
            Case "FM"
                Me.Write(Me.Commands.FMMode)
        End Select
    End Sub

    Public Sub SetOutPutModeTo(ByVal newOutputMode As Agilent5343AOutputModeEnum)
        Me.Write(Me.Commands.OutputMode & newOutputMode)
    End Sub

End Class

Public Enum Agilent5343AResolutionModeEnum
    OneHz = 3
    TenHz = 4
    OneHundredHz = 5
    OneKHz = 6
    TenKHz = 7
    OneHundredKHz = 8
    OneMHz = 9
End Enum

Public Enum Agilent5343AOutputModeEnum
    OutputOnlyWhenAddressed = 1
    WaitUntilAddressed = 2
End Enum

Public Enum CounterFrequencyRangeEnum
    High
    Low
End Enum

Public Enum Agilent5343AAcquisitionTimeEnum
    Fast = 1
    Medium = 2
    Slow = 3
End Enum




