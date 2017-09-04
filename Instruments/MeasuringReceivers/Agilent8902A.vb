'
' Created by SharpDevelop.
' User: rspage
' Date: 6/6/2005
' Time: 1:46 PM
' 

Public Class Agilent8902A
    Inherits FreeCal.Instruments.MeasuringReceivers.MeasuringReceiver

    Public Sub New(ByVal boardAddress As Integer, ByVal primaryAddress As Byte, ByVal getSettingsFromInstrument As Boolean, Optional ByVal simulate As Boolean = False)
        MyBase.New(boardAddress, primaryAddress, getSettingsFromInstrument, simulate)
        Me._Manufacturer = "Agilent Technologies"
        Me._Model = "8902A"
        Me.IOTimeout = TimeoutValue.T30s
    End Sub

    Protected Overrides Sub SetupCapabilities()
        Me._CanIdentify = True
        Me._Capabilities.ReferenceOscillatorFrequency = 10
        Me._Capabilities.ReferenceOscillatorFrequencyMultiplier = FrequencyEnum.MHz
    End Sub

    Protected Overrides Sub SetupCommands()
        Me._GeneralCommands.Identify = "ID"
        Me._GeneralCommands.Preset = "IP"
        Me._Commands.MeasureAM = "M1"
        Me._Commands.MeasureFM = "M2"
        Me._Commands.MeasurePM = "M3"
        Me._Commands.MeasureRFPower = "M4"
        Me._Commands.MeasureFrequency = "M5"
        Me._Commands.MeasureAudioFrequency = "S1"
        Me._Commands.MeasureAudioDistortion = "S2"
        Me._Commands.MeasureIFLevel = "S3"
        Me._Commands.MeasureTunedRFLevel = "S4"
        Me._Commands.MeasureFrequencyError = "S5"
        Me._Commands.CalibrateOn = "C1"
        Me._Commands.CalibrateOff = "C0"
        Me._Commands.InputFrequencyMHz = "MZ"
        Me._Commands.DisplayLOGResult = "LG"
        Me._Commands.TriggerImmediate = "T1"
        Me._Commands.TriggerWithSettling = "T3"
        Me._Commands.RatioOn = "R1"
        Me._Commands.RatioOff = "R0"
    End Sub

    Public Overloads Overrides Function ReadDouble() As Double
        Return Me.ReadDouble(15)
    End Function

End Class




