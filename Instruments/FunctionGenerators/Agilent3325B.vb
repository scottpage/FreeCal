'
' Created by SharpDevelop.
' User: rspage
' Date: 6/9/2005
' Time: 1:00 PM
' 

Imports System
Imports FreeCal.Common
Imports FreeCal.Instruments
Imports System.Windows.Forms
Imports NationalInstruments.NI4882
Imports Microsoft.VisualBasic.ControlChars

	Public Class Agilent3325B
    Inherits FreeCal.Instruments.FunctionGenerators.FunctionGenerator

    Public Sub New(ByVal boardAddress As Integer, ByVal primaryAddress As Byte, ByVal getSettingsFromInstrument As Boolean, Optional ByVal simulate As Boolean = False)
        MyBase.New(boardAddress, primaryAddress, getSettingsFromInstrument, simulate)
        Me._Manufacturer = "Agilent Technologies"
        Me._Model = "3325B"
        Me.Write("HEAD0")
    End Sub

    Protected Overrides Sub SetupCommandTerminators()
        Me._CommandTerminators.dBm = " DB"
        Me._CommandTerminators.KHz = " KH"
        Me._CommandTerminators.MHz = " MH"
    End Sub

    Protected Overrides Sub SetupCommands()
        Me._Commands.SetAmplitude = "AM "
        Me._Commands.SetFrequency = "FR "
        Me._Commands.SetSineWaveform = "FU1"
        Me._Commands.RearOnlyOutput = "RF2"
        Me._Commands.FrontOnlyOutput = "RF1"
    End Sub

    Public Overrides Sub SetupInstrument()
        Me._FrequencySuffix = FrequencyEnum.MHz
        Me._AmplitudeSuffix = AmplitudeEnum.dBm
    End Sub

    Protected Overrides Sub SetupSpecifications()
        Me._Capabilities.MinimumAmplitude = -56
        Me._Capabilities.MaximumAmplitude = 20
        Me._Capabilities.MinimumFrequency = 1
        Me._Capabilities.MinimumFrequencyMultiplier = FrequencyEnum.Hz
        Me._Capabilities.MaximumFrequency = 50
        Me._Capabilities.MaximumFrequencyMultiplier = FrequencyEnum.MHz
    End Sub

End Class


