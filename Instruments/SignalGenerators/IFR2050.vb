'
' Created by SharpDevelop.
' User: Administrator
' Date: 6/1/2005
' Time: 6:29 PM
' 


Imports System.ComponentModel

<TypeConverter(GetType(ExpandableObjectConverter))>
Public Class IFR2050
        Inherits FreeCal.Instruments.SignalGenerators.SignalGenerator

    Public Sub New(ByVal boardAddress As Integer, ByVal primaryAddress As Byte, ByVal getSettingsFromInstrument As Boolean, Optional ByVal simulate As Boolean = False)
        MyBase.New(boardAddress, primaryAddress, getSettingsFromInstrument, simulate)
        Me._Manufacturer = "IFR"
        Me._Model = "2050"
        Me.Sections.RF.Frequency.Suffix = FrequencyEnum.GHz
        Me.Sections.RF.Frequency.CW = 1
        Me.Sections.RF.Amplitude.Suffix = AmplitudeEnum.dBm
        Me.Sections.RF.Amplitude.Level = 0
    End Sub

    Protected Overrides Sub SetupTestPoints
			Dim HighAmplitudeAccuracyTestFrequenciesList() As Double = {0.03, 0.1, 75, 225, 375, 525, 675, 825, 975, 1125, 1275, 1350}
			Me._TestPoints.HighAmplitudeAccuracyTestFrequencies = HighAmplitudeAccuracyTestFrequenciesList
			Dim AttenuatorAccuracyTestFrequenciesList() As Double = {1350, 250}'{2.5, 31, 325, 1125, 1275, 1350}
			Me._TestPoints.AttenuatorAccuracyTestFrequencies = AttenuatorAccuracyTestFrequenciesList
			Dim CarrierFrequencyAccuracyTestFrequenciesList() As Double = {0.01, 4.22675, 8.4435, 12.66025, 16.887, 21.03975, 21.0937499, 42.1874999, 84.3749999, 168.7499999, 337.4999999, 572.6623061, 674.9999999, 677.7995264, 798.5954816, 805.306368, 952.9458688, 959.6567552, 1134.1398016, 1140.850688, 1145.3246122, 1348.8881664}
			Me._TestPoints.CarrierFrequencyAccuracyTestFrequencies = CarrierFrequencyAccuracyTestFrequenciesList
			Dim AMModulationTestFrequenciesList() As Double = {1.5, 31, 43, 200, 400, 500, 850, 1000}
			Me._TestPoints.AMModulationTestFrequencies = AMModulationTestFrequenciesList
			Dim ResidualAMTestFrequenciesList() As Double = {750, 1030}
			Me._TestPoints.ResidualAMTestFrequencies = ResidualAMTestFrequenciesList
		End Sub

		Protected Overrides Sub SetupSpecifications
			Me._Specifications.HighAmplitudeAccuracyTolerance = 0.5
			Me._Specifications.AttenuatorAccuracyTolerance = 0.85
			Me._Specifications.CarrierFrequencyAccuracyTolerance = 0.000001
			Me._Specifications.ReferenceOscillatorFrequencyTolerance = 0.000001
			Me._Specifications.AMDepthTolerance = 1
			Me._Specifications.ResidualAMTolerance = 0.01
		End Sub

		Protected Overrides Sub SetupCapabilities
			Me._CanIdentify = True
			Me._Capabilities.HasInternalAMModulation = True
			Me._Capabilities.HasInternalFMModulation = True
			Me._Capabilities.HasInternalPhaseModulation = True
			Me._Capabilities.MinimumFrequency = 10
			Me._Capabilities.MinimumFrequencySuffix = FrequencyEnum.KHz
			Me._Capabilities.MaximumFrequency = 1.35
			Me._Capabilities.MaximumFrequencySuffix = FrequencyEnum.GHz
			Me._Capabilities.MinimumRFAmplitude = -144
			Me._Capabilities.MaximumRFAmplitude = 13
			Me._Capabilities.RFAmplitudeSuffix = AmplitudeEnum.dBm
			Me._Capabilities.ReferenceOscillatorFrequency = 10
			Me._Capabilities.ReferenceOscillatorFrequencySuffix = FrequencyEnum.MHz
		End Sub

		Protected Overrides Sub SetupCommands
			Me._GeneralCommands.Identify = "*IDN?"
	        Me._GeneralCommands.Preset = "*RST"
	        Me._Commands.SetCWFrequency = "CFRQ:VALUE "
	        Me._Commands.SetRFAmplitude = "RFLV:VALUE "
	        Me._Commands.SetRFAmplitudeSuffix = "RFLV:UNITS "
	        Me._Commands.SetRFOutputStateOn = "RFLV:ON"
	        Me._Commands.SetRFOutputStateOff = "RFLV:OFF"
	        Me._Commands.SetAMFrequency = "INTF4:FREQ "
	        Me._Commands.SetAMDepth = "AM:DEPTh "
	        Me._Commands.SetAMStateOn = "AM:ON"
	        Me._Commands.SetAMStateOff = "AM:OFF"
	        Me._Commands.SetFMFrequency = "LFGF:VALUE "
	        Me._Commands.SetFMDeviation = "FM:DEVN "
	        Me._Commands.SetFMStateOn = "FM:ON"
	        Me._Commands.SetFMStateOff = "FM:OFF"
			Me._Commands.SetModulationStateOn = "MOD:ON"
			Me._Commands.SetModulationStateOff = "MOD:OFF"
			Me._Commands.SetModulationMode = "MODE "
			Me._Commands.SetSweepTime = "SWEep:FREQuency:TIME "
			Me._Commands.SetSweepMode = "SWEep:FREQuency:MODE "
		End Sub

	End Class


