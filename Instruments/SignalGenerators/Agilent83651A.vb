'
' Created by SharpDevelop.
' User: rspage
' Date: 6/17/2005
' Time: 2:30 PM
' 

Imports System
Imports FreeCal.Common
Imports FreeCal.Instruments
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Class Agilent83651A
        Inherits FreeCal.Instruments.SignalGenerators.SignalGenerator

    Public Sub New(ByVal boardAddress As Integer, ByVal primaryAddress As Byte, ByVal getSettingsFromInstrument As Boolean, Optional ByVal simulate As Boolean = False)
        MyBase.New(boardAddress, primaryAddress, getSettingsFromInstrument, simulate)
        Me._Manufacturer = "Agilent"
        Me._Model = "83651A"
    End Sub

    Protected Overrides Sub SetupCommandTerminators
            Me._CommandTerminators.dBm = " DM"
        End Sub

		Protected Overrides Sub SetupTestPoints
			Dim HighAmplitudeAccuracyTestFrequenciesList() As Double = {75, 225, 375, 525, 675, 825, 975, 1125, 1275, 1350}
			Me._TestPoints.HighAmplitudeAccuracyTestFrequencies = HighAmplitudeAccuracyTestFrequenciesList
			Dim AttenuatorAccuracyTestFrequenciesList() As Double = {10, 100, 500, 1000, 10000, 20000, 26500}
			Me._TestPoints.AttenuatorAccuracyTestFrequencies = AttenuatorAccuracyTestFrequenciesList
			Dim CarrierFrequencyAccuracyTestFrequenciesList() As Double = {10, 100, 500, 1000, 10000, 20000, 26500}
			Me._TestPoints.CarrierFrequencyAccuracyTestFrequencies = CarrierFrequencyAccuracyTestFrequenciesList
			Dim ResidualAMTestFrequenciesList() As Double = {750, 1030}
			Me._TestPoints.ResidualAMTestFrequencies = ResidualAMTestFrequenciesList
			Dim AMModulationTestFrequenciesList() As Double = {31, 43, 200, 400, 500, 850, 1000}
			Me._TestPoints.AMModulationTestFrequencies = AMModulationTestFrequenciesList
			Dim AMModulationTestAmplitudesList() As Double = {0, 7}
			Me._TestPoints.AMModulationTestAmplitudes = AMModulationTestAmplitudesList
			Dim AMModulationTestDepthsList() As Double = {30, 80}
			Me._TestPoints.AMModulationTestDepths = AMModulationTestDepthsList
			Dim SpectralPurityTestFrequenciesList() As Double = {100, 1000}
			Me._TestPoints.SpectralPurityTestFrequencies = SpectralPurityTestFrequenciesList
		End Sub

		Protected Overrides Sub SetupSpecifications
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

		Protected Overrides Sub SetupCapabilities
			Me._CanIdentify = True
			Me._Capabilities.HasInternalAMModulation = True
			Me._Capabilities.HasInternalFMModulation = True
			Me._Capabilities.HasInternalPhaseModulation = True
			Me._Capabilities.MinimumFrequency = 10
			Me._Capabilities.MinimumFrequencySuffix = FrequencyEnum.MHz
			Me._Capabilities.MaximumFrequency = 65
			Me._Capabilities.MaximumFrequencySuffix = FrequencyEnum.GHz
			Me._Capabilities.MinimumRFAmplitude = -110
			Me._Capabilities.MaximumRFAmplitude = 20
			Me._Capabilities.RFAmplitudeSuffix = AmplitudeEnum.dBm
			Me._Capabilities.ReferenceOscillatorFrequency = 10
			Me._Capabilities.ReferenceOscillatorFrequencySuffix = FrequencyEnum.MHz
		End Sub

		Protected Overrides Sub SetupCommands
			Me._GeneralCommands.Identify = "*IDN?"
	        Me._GeneralCommands.Preset = "*RST"
	        Me._Commands.SetCWFrequency = "FREQ:CW "
	        Me._Commands.SetRFAmplitude = "POWER:LEVEL "
	        Me._Commands.SetRFAmplitudeSuffix = "RFLV:UNITS "
	        Me._Commands.SetRFOutputStateOn = "RF1"
	        Me._Commands.SetRFOutputStateOff = "RF0"
	        Me._Commands.SetAMFrequency = "AMR "
	        Me._Commands.SetAMDepth = "ADP1 "
	        Me._Commands.SetAMStateOn = "AM7"
	        Me._Commands.SetAMStateOff = "AM0"
	        Me._Commands.SetFMFrequency = "LFGF:VALUE "
	        Me._Commands.SetFMDeviation = "FM:DEVN "
	        Me._Commands.SetFMStateOn = "FM7"
	        Me._Commands.SetFMStateOff = "FM0"
			Me._Commands.SetModulationStateOn = ""
			Me._Commands.SetModulationStateOff = ""
			Me._Commands.SetModulationMode = "MODE "
			Me._Commands.SetSweepTime = "FREQUENCY:SWEEP:TIME "
			Me._Commands.SetSweepMode = "FREQUENCY:SWEEP:MODE "
		End Sub

	End Class


