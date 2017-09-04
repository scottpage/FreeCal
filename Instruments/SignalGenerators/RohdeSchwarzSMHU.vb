'
' Created by SharpDevelop.
' User: rspage
' Date: 7/5/2005
' Time: 10:02 AM
' 

Imports System
Imports FreeCal.Common
Imports FreeCal.Instruments
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Class RohdeSchwarzSMHU
        Inherits FreeCal.Instruments.SignalGenerators.SignalGenerator

        Public Sub New(ByVal boardAddress As Integer, ByVal primaryAddress As Byte, ByVal getSettingsFromInstrument As Boolean, Optional ByVal simulate As Boolean = False)
		    MyBase.New(BoardAddress, PrimaryAddress, GetSettingsFromInstrument, Simulate)
		    Me._Manufacturer = "Rohde & Schwarz"
		    Me._Model = "SMHU"
		End Sub

		Protected Overrides Sub SetupTestPoints
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
			Me._Capabilities.MinimumFrequency = 100
			Me._Capabilities.MinimumFrequencySuffix = FrequencyEnum.KHz
			Me._Capabilities.MaximumFrequency = 4.32
			Me._Capabilities.MaximumFrequencySuffix = FrequencyEnum.GHz
			Me._Capabilities.MinimumRFAmplitude = -140
			Me._Capabilities.MaximumRFAmplitude = 19
			Me._Capabilities.RFAmplitudeSuffix = AmplitudeEnum.dBm
			Me._Capabilities.ReferenceOscillatorFrequency = 10
			Me._Capabilities.ReferenceOscillatorFrequencySuffix = FrequencyEnum.MHz
		End Sub

		Protected Overrides Sub SetupCommands
			Me._GeneralCommands.Identify = "*IDN?"
	        Me._GeneralCommands.Preset = "*RST"
	        Me._Commands.SetCWFrequency = "CF "
	        Me._Commands.SetRFAmplitude = "LEV RF "
	        Me._Commands.SetRFOutputStateOn = "LEV ON;"
	        Me._Commands.SetRFOutputStateOff = "LEV OFF;"
	        Me._Commands.SetAMFrequency = "AF "
	        Me._Commands.SetAMDepth = "AM "
	        Me._Commands.SetAMStateOn = " "
	        Me._Commands.SetAMStateOff = "AM:OFF;"
	        Me._Commands.SetFMFrequency = "AF "
	        Me._Commands.SetFMDeviation = "FM "
	        Me._Commands.SetFMStateOn = " "
	        Me._Commands.SetFMStateOff = "FM OFF;"
			Me._Commands.SetModulationStateOn = " "
			Me._Commands.SetModulationStateOff = " "
			Me._Commands.SetModulationMode = " "
			Me._Commands.SetSweepTime = "TIME: "
			Me._Commands.SetSweepMode = "SWP:MODE: "
		End Sub

	End Class


