'
' Created by SharpDevelop.
' User: rspage
' Date: 6/14/2005
' Time: 11:00 AM
' 

Imports System.ComponentModel


<TypeConverter(GetType(ExpandableObjectConverter))>
Public Class AgilentE4433B
    Inherits FreeCal.Instruments.SignalGenerators.SignalGenerator

    Public Sub New(ByVal boardAddress As Integer, ByVal primaryAddress As Byte, ByVal getSettingsFromInstrument As Boolean, Optional ByVal simulate As Boolean = False)
        MyBase.New(boardAddress, primaryAddress, getSettingsFromInstrument, simulate)
        Me._Manufacturer = "Agilent Technologies"
        Me._Model = "E4433B"
        Me.Sections.RF.Frequency.Suffix = FrequencyEnum.GHz
        Me.Sections.RF.Frequency.CW = 1
        Me.Sections.RF.Amplitude.Suffix = AmplitudeEnum.dBm
        Me.Sections.RF.Amplitude.Level = 0
    End Sub

    Protected Overrides Sub SetupTestPoints()
        Dim HighAmplitudeAccuracyTestFrequenciesList() As Double = {50, 100, 1000, 1500, 2000, 2500, 3000, 3500, 4000}
        Me._TestPoints.HighAmplitudeAccuracyTestFrequencies = HighAmplitudeAccuracyTestFrequenciesList
        Dim AttenuatorAccuracyTestFrequenciesList() As Double = {10, 100, 1000, 1500, 2000, 2500, 3000, 3500, 4000}
        Me._TestPoints.AttenuatorAccuracyTestFrequencies = AttenuatorAccuracyTestFrequenciesList
        Dim CarrierFrequencyAccuracyTestFrequenciesList() As Double = {10, 100, 1000, 1500, 2000, 2500, 3000, 3500, 4000}
        Me._TestPoints.CarrierFrequencyAccuracyTestFrequencies = CarrierFrequencyAccuracyTestFrequenciesList
        Dim ResidualAMTestFrequenciesList() As Double = {10, 100, 1000, 1500, 2000, 2500, 3000, 3500, 4000}
        Me._TestPoints.ResidualAMTestFrequencies = ResidualAMTestFrequenciesList
        Dim AMModulationTestFrequenciesList() As Double = {10, 100, 1000, 1500, 2000, 2500, 3000, 3500, 4000}
        Me._TestPoints.AMModulationTestFrequencies = AMModulationTestFrequenciesList
        Dim AMModulationTestAmplitudesList() As Double = {0, 7}
        Me._TestPoints.AMModulationTestAmplitudes = AMModulationTestAmplitudesList
        Dim AMModulationTestDepthsList() As Double = {30, 80}
        Me._TestPoints.AMModulationTestDepths = AMModulationTestDepthsList
        Dim SpectralPurityTestFrequenciesList() As Double = {0.25, 0.5, 1, 10, 100, 1000, 1500, 2000, 2500, 3000, 3500, 4000}
        Me._TestPoints.SpectralPurityTestFrequencies = SpectralPurityTestFrequenciesList
    End Sub

    Protected Overrides Sub SetupSpecifications()
        Me._Specifications.HighAmplitudeAccuracyTolerance = 0.5
        Me._Specifications.AttenuatorAccuracyTolerance = 0.85
        Me._Specifications.CarrierFrequencyAccuracyTolerance = 0.000001
        Me._Specifications.ReferenceOscillatorFrequencyTolerance = 0.000001
        Me._Specifications.ResidualAMTolerance = 0.01
        Me._Specifications.AMDepthTolerance = 4
        Me._Specifications.AMDistortionTolerance = 1
        Me._Specifications.IncidentalPhaseModulationTolerance = 0.2
        Me._Specifications.FirstHarmonicTolerance = -50
        Me._Specifications.SecondHarmonicTolerance = -70
        Me._Specifications.SubHarmonicTolerance = -70
    End Sub

    Protected Overrides Sub SetupCapabilities()
        Me._CanIdentify = True
        Me._Capabilities.HasInternalAMModulation = True
        Me._Capabilities.HasInternalFMModulation = True
        Me._Capabilities.HasInternalPhaseModulation = True
        Me._Capabilities.MinimumFrequency = 250
        Me._Capabilities.MinimumFrequencySuffix = FrequencyEnum.KHz
        Me._Capabilities.MaximumFrequency = 4
        Me._Capabilities.MaximumFrequencySuffix = FrequencyEnum.GHz
        Me._Capabilities.MinimumRFAmplitude = -135
        Me._Capabilities.MaximumRFAmplitude = 20
        Me._Capabilities.RFAmplitudeSuffix = AmplitudeEnum.dBm
        Me._Capabilities.ReferenceOscillatorFrequency = 10
        Me._Capabilities.ReferenceOscillatorFrequencySuffix = FrequencyEnum.MHz
    End Sub

    Protected Overrides Sub SetupCommands()
        Me._GeneralCommands.Identify = "*IDN?"
        Me._GeneralCommands.Preset = ":SYSTem:PRESet"
        Me._Commands.SetCWFrequency = ":FREQ "
        Me._Commands.SetRFAmplitude = ":POWer "
        Me._Commands.SetRFAmplitudeSuffix = ":UNIT:POWer "
        Me._Commands.SetRFOutputStateOn = ":OUTP:STAT ON"
        Me._Commands.SetRFOutputStateOff = ":OUTP:STAT OFF"
        Me._Commands.SetAMFrequency = "AMR "
        Me._Commands.SetAMDepth = ":AM:INTernal:FREQuency "
        Me._Commands.SetAMStateOn = ":AM:STATE ON"
        Me._Commands.SetAMStateOff = ":AM:STATE OFF"
        Me._Commands.SetFMFrequency = ":FM:INTernal:FREQuency "
        Me._Commands.SetFMDeviation = ":FM:DEV "
        Me._Commands.SetFMStateOn = ":FM:STATE ON"
        Me._Commands.SetFMStateOff = ":FM:STATE OFF"
        Me._Commands.SetModulationStateOn = ":OUTPut:MODulation ON"
        Me._Commands.SetModulationStateOff = ":OUTPut:MODulation OFF"
        Me._Commands.SetModulationMode = " "
        Me._Commands.SetSweepTime = "FREQUENCY:SWEEP:TIME "
        Me._Commands.SetSweepMode = "FREQUENCY:SWEEP:MODE "
    End Sub

End Class




