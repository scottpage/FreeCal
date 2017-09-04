'
' Created by SharpDevelop.
' User: rspage
' Date: 6/7/2005
' Time: 10:12 AM
' 

Imports System.ComponentModel

<TypeConverter(GetType(ExpandableObjectConverter))>
Public Class Agilent8340A
    Inherits FreeCal.Instruments.SignalGenerators.SignalGenerator

    Public Sub New(ByVal boardAddress As Integer, ByVal primaryAddress As Byte, ByVal getSettingsFromInstrument As Boolean, Optional ByVal simulate As Boolean = False)
        MyBase.New(boardAddress, primaryAddress, getSettingsFromInstrument, simulate)
        Me._Manufacturer = "Agilent Technologies"
        Me._Model = "8340A"
        Me.Sections.RF.Frequency.Suffix = FrequencyEnum.GHz
        Me.Sections.RF.Frequency.CW = 1
        Me.Sections.RF.Amplitude.Suffix = AmplitudeEnum.dBm
        Me.Sections.RF.Amplitude.Level = 0
    End Sub

    Protected Overrides Sub SetupCommandTerminators()
        Me._CommandTerminators.dBm = "DB"
        Me._CommandTerminators.Hz = "HZ"
        Me._CommandTerminators.kHz = "KZ"
        Me._CommandTerminators.MHz = "MZ"
        Me._CommandTerminators.GHz = "GZ"
    End Sub

    Protected Overrides Sub SetupTestPoints()
        Dim HighAmplitudeAccuracyTestFrequenciesList() As Double = {0.03, 0.1, 75, 225, 375, 525, 675, 825, 975, 1125, 1275, 1350}
        Me._TestPoints.HighAmplitudeAccuracyTestFrequencies = HighAmplitudeAccuracyTestFrequenciesList
        Dim AttenuatorAccuracyTestFrequenciesList() As Double = {2.5, 31, 325, 1125, 1275}
        Me._TestPoints.AttenuatorAccuracyTestFrequencies = AttenuatorAccuracyTestFrequenciesList
        Dim CarrierFrequencyAccuracyTestFrequenciesList() As Double = {0.01, 4.22675, 8.4435, 12.66025, 16.887, 21.03975, 21.0937499, 42.1874999, 84.3749999, 168.7499999, 337.4999999, 572.6623061, 674.9999999, 677.7995264, 798.5954816, 805.306368, 952.9458688, 959.6567552, 1134.1398016, 1140.850688, 1145.3246122, 1348.8881664}
        Me._TestPoints.CarrierFrequencyAccuracyTestFrequencies = CarrierFrequencyAccuracyTestFrequenciesList
        Dim AMModulationTestFrequenciesList() As Double = {1.5, 31, 43, 200, 400, 500, 850, 1000}
        Me._TestPoints.AMModulationTestFrequencies = AMModulationTestFrequenciesList
        Dim ResidualAMTestFrequenciesList() As Double = {750, 1030}
        Me._TestPoints.ResidualAMTestFrequencies = ResidualAMTestFrequenciesList
    End Sub

    Protected Overrides Sub SetupSpecifications()
        Me._Specifications.HighAmplitudeAccuracyTolerance = 0.5
        Me._Specifications.AttenuatorAccuracyTolerance = 0.85
        Me._Specifications.CarrierFrequencyAccuracyTolerance = 0.000001
        Me._Specifications.ReferenceOscillatorFrequencyTolerance = 0.000001
        Me._Specifications.AMDepthTolerance = 1
        Me._Specifications.ResidualAMTolerance = 0.01
    End Sub

    Protected Overrides Sub SetupCapabilities()
        Me._CanIdentify = True
        Me._Capabilities.MinimumFrequency = 10
        Me._Capabilities.MinimumFrequencySuffix = FrequencyEnum.MHz
        Me._Capabilities.MaximumFrequency = 26.5
        Me._Capabilities.MaximumFrequencySuffix = FrequencyEnum.GHz
    End Sub

    Protected Overrides Sub SetupCommands()
        Me._GeneralCommands.Identify = "*IDN?"
        Me._GeneralCommands.Preset = "IP"
        Me._Commands.SetCWFrequency = "CW"
        Me._Commands.SetRFAmplitude = "PL"
        Me._Commands.SetRFOutputStateOn = "RF1"
        Me._Commands.SetRFOutputStateOff = "RF0"
    End Sub

End Class




