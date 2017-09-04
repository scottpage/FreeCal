'
' Created by SharpDevelop.
' User: Administrator
' Date: 6/1/2005
' Time: 6:29 PM
' 


Imports System
Imports NationalInstruments.NI4882
Imports FreeCal.Common
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Class Agilent8643A
        Inherits FreeCal.Instruments.SignalGenerators.SignalGenerator

    Public Sub New(ByVal boardAddress As Integer, ByVal primaryAddress As Byte, ByVal getSettingsFromInstrument As Boolean, Optional ByVal simulate As Boolean = False)
        MyBase.New(boardAddress, primaryAddress, getSettingsFromInstrument, simulate)
        Me._Manufacturer = "Agilent Technologies"
        Me._Model = "8643A"
    End Sub

    Protected Overrides Sub SetupTestPoints
			Dim HighAmplitudeAccuracyTestFrequenciesList() As Double = {0.03, 0.1, 75, 225, 375, 525, 675, 825, 975, 1125, 1275, 1350}
			Me._TestPoints.HighAmplitudeAccuracyTestFrequencies = HighAmplitudeAccuracyTestFrequenciesList
			Dim AttenuatorAccuracyTestFrequenciesList() As Double = {10, 100, 500, 1000, 10000, 20000, 26500}
			Me._TestPoints.AttenuatorAccuracyTestFrequencies = AttenuatorAccuracyTestFrequenciesList
			Dim CarrierFrequencyAccuracyTestFrequenciesList() As Double = {10, 100, 500, 1000, 10000, 20000, 26500}
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
			Me._Capabilities.MaximumFrequency = 1050
			Me._Capabilities.MaximumFrequencySuffix = FrequencyEnum.MHz
			Me._Capabilities.MinimumRFAmplitude = -127
			Me._Capabilities.MaximumRFAmplitude = 13
			Me._Capabilities.RFAmplitudeSuffix = AmplitudeEnum.dBm
			Me._Capabilities.ReferenceOscillatorFrequency = 10
			Me._Capabilities.ReferenceOscillatorFrequencySuffix = FrequencyEnum.MHz
		End Sub

		Protected Overrides Sub SetupCommands
			Me._GeneralCommands.Identify = "*IDN?"
	        Me._GeneralCommands.Preset = "*RST"
	        Me._Commands.SetCWFrequency = "FREQuency:CW "
	        Me._Commands.SetRFAmplitude = "AMPLitude:OUT:LEVel "
	        Me._Commands.SetRFAmplitudeSuffix = "AMPLitude:UNIT "
	        Me._Commands.SetRFOutputStateOn = "AMPLitude:OUT:STATe ON"
	        Me._Commands.SetRFOutputStateOff = "AMPLitude:OUT:STATe OFF"
	        Me._Commands.SetAMFrequency = "AM:FREQuency "
	        Me._Commands.SetAMDepth = "AM:DEPTh "
	        Me._Commands.SetAMStateOn = "AM:STATe ON"
	        Me._Commands.SetAMStateOff = "AM:STATe OFF"
	        Me._Commands.SetFMFrequency = "FM:FREQuency "
	        Me._Commands.SetFMDeviation = "FM:DEViation "
	        Me._Commands.SetFMStateOn = "FM:STATe ON"
	        Me._Commands.SetFMStateOff = "FM:STATe OFF"
			Me._Commands.SetModulationStateOn = "MODulation:STATe ON"
			Me._Commands.SetModulationStateOff = "MODulation:STATe OFF"
			Me._Commands.SetModulationMode = " "
			Me._Commands.SetSweepTime = "SWEep:FREQuency:TIME "
			Me._Commands.SetSweepMode = "SWEep:FREQuency:MODE "
		End Sub

	End Class


