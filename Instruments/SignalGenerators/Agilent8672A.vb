'
' Created by SharpDevelop.
' User: rspage
' Date: 6/13/2005
' Time: 1:08 PM
' 

Imports System
Imports FreeCal.Common
Imports System.Environment
Imports NationalInstruments.NI4882
Imports System.Windows.Forms
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Structure Agilent8672AExtendedGPIBCommands
		Public Set10GHzFrequency As String
		Public Set1GHzFrequency As String
		Public Set1MHzFrequency As String
		Public Set100KHzFrequency As String
		Public Set10KHzFrequency As String
		Public Set1KHzFrequency As String
		Public SetRFAmplitudeRange As String
		Public SetRFAmplitudeLevel As String
	End Structure

	Public Class Agilent8672A
        Inherits FreeCal.Instruments.SignalGenerators.SignalGenerator

		Protected _ExtendedCommands As Agilent8672AExtendedGPIBCommands

		Public ReadOnly Property ExtendedCommands As Agilent8672AExtendedGPIBCommands
			Get
				Return Me._ExtendedCommands
			End Get
		End Property

    Public Sub New(ByVal boardAddress As Integer, ByVal primaryAddress As Byte, ByVal getSettingsFromInstrument As Boolean, Optional ByVal simulate As Boolean = False)
        MyBase.New(boardAddress, primaryAddress, getSettingsFromInstrument, simulate)
        Me._Manufacturer = "Agilent Technologies"
        Me._Model = "8672A"
        Me.SetupExtendedGPIBCommands()
        Me.SetupInstrument()
    End Sub

    Protected Sub SetupExtendedGPIBCommands
			Me._ExtendedCommands.Set10GHzFrequency = "P"
			Me._ExtendedCommands.Set1GHzFrequency = "Q"
			Me._ExtendedCommands.Set1MHzFrequency = "T"
			Me._ExtendedCommands.Set100KHzFrequency = "U"
			Me._ExtendedCommands.Set10KHzFrequency = "V"
			Me._ExtendedCommands.Set1KHzFrequency = "W"
			Me._ExtendedCommands.SetRFAmplitudeRange = "K"
			Me._ExtendedCommands.SetRFAmplitudeLevel = "L"
		End Sub

		Public Overrides Sub SetupInstrument
			Me.Sections.RF.Frequency.Suffix = FrequencyEnum.MHz
			Me.Sections.RF.Amplitude.Suffix = AmplitudeEnum.dBm
		End Sub

        Protected Overrides Sub SetupCommandTerminators
            Me._CommandTerminators.dBm = ";"
            Me._CommandTerminators.Hz = "Z;"
            Me._CommandTerminators.KHz = "Z;"
            Me._CommandTerminators.MHz = "Z;"
            Me._CommandTerminators.GHz = "Z;"
        End Sub

		Protected Overrides Sub SetupTestPoints
			Dim HighAmplitudeAccuracyTestFrequenciesList() As Double = {2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000, 11000, 12000, 13000, 14000, 15000, 16000, 17000, 18000}
			Me._TestPoints.HighAmplitudeAccuracyTestFrequencies = HighAmplitudeAccuracyTestFrequenciesList
			Dim AttenuatorAccuracyTestFrequenciesList() As Double = {2000, 10000, 18000}
			Me._TestPoints.AttenuatorAccuracyTestFrequencies = AttenuatorAccuracyTestFrequenciesList
			Dim CarrierFrequencyAccuracyTestFrequenciesList() As Double = {2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000, 11000, 12000, 13000, 14000, 15000, 16000, 17000, 18000}
			Me._TestPoints.CarrierFrequencyAccuracyTestFrequencies = CarrierFrequencyAccuracyTestFrequenciesList
			Dim AMModulationTestFrequenciesList() As Double = {2000, 10000}
			Me._TestPoints.AMModulationTestFrequencies = AMModulationTestFrequenciesList
			Dim ResidualAMTestFrequenciesList() As Double = {2000, 10000}
			Me._TestPoints.ResidualAMTestFrequencies = ResidualAMTestFrequenciesList
			Dim SpectralPurityTestFrequenciesList() As Double = {2000, 10000, 18000}
			Me._TestPoints.SpectralPurityTestFrequencies = SpectralPurityTestFrequenciesList
		End Sub

		Protected Overrides Sub SetupSpecifications
			Me._Specifications.HighAmplitudeAccuracyTolerance = 0.5
			Me._Specifications.AttenuatorAccuracyTolerance = 0.85
			Me._Specifications.CarrierFrequencyAccuracyTolerance = 0.000001
			Me._Specifications.ReferenceOscillatorFrequencyTolerance = 0.000001
			Me._Specifications.AMDepthTolerance = 1
			Me._Specifications.ResidualAMTolerance = 0.01
			Me._Specifications.FirstHarmonicTolerance = -40
			Me._Specifications.SecondHarmonicTolerance = -60
			Me._Specifications.SubHarmonicTolerance = -70
		End Sub

		Protected Overrides Sub SetupCapabilities
			Me._CanIdentify = True
			Me._Capabilities.HasInternalAMModulation = True
			Me._Capabilities.HasInternalFMModulation = True
			Me._Capabilities.HasInternalPhaseModulation = False
			Me._Capabilities.MinimumFrequency = 2
			Me._Capabilities.MinimumFrequencySuffix = FrequencyEnum.GHz
			Me._Capabilities.MaximumFrequency = 18.599997
			Me._Capabilities.MaximumFrequencySuffix = FrequencyEnum.GHz
			Me._Capabilities.MinimumRFAmplitude = -110
			Me._Capabilities.MaximumRFAmplitude = 3
			Me._Capabilities.RFAmplitudeSuffix = AmplitudeEnum.dBm
			Me._Capabilities.ReferenceOscillatorFrequency = 10
			Me._Capabilities.ReferenceOscillatorFrequencySuffix = FrequencyEnum.MHz
		End Sub

		Protected Overrides Sub SetupCommands
			Me._GeneralCommands.Identify = "*IDN?"
	        Me._GeneralCommands.Preset = "IP"
	        Me._Commands.SetCWFrequency = "CW"
	        Me._Commands.SetRFAmplitude = "L"
	        Me._Commands.SetRFAmplitudeSuffix = ""
	        Me._Commands.SetRFOutputStateOn = "RF1"
	        Me._Commands.SetRFOutputStateOff = "RF0"
		End Sub

		Public Overrides Sub WriteFrequency(ByVal frequencySetting As Double)
        Dim PrefixCommand As String = String.Empty
        If (FrequencySetting >= 10 And Me.Sections.RF.Frequency.Suffix = FrequencyEnum.GHz) Then
				PrefixCommand = Me.ExtendedCommands.Set10GHzFrequency
			ElseIf (FrequencySetting < 10 And Me.Sections.RF.Frequency.Suffix = FrequencyEnum.GHz) Then
				PrefixCommand = Me.ExtendedCommands.Set1GHzFrequency
			ElseIf (FrequencySetting >= 10000 And Me.Sections.RF.Frequency.Suffix = FrequencyEnum.MHz) Then
				PrefixCommand = Me.ExtendedCommands.Set10GHzFrequency
			ElseIf (FrequencySetting >= 1000 And FrequencySetting < 10000 And Me.Sections.RF.Frequency.Suffix = FrequencyEnum.MHz) Then
				PrefixCommand = Me.ExtendedCommands.Set1GHzFrequency
			End If
			Me.Write(PrefixCommand & FrequencySetting.ToString.Replace(".", "") & Me.GetFrequencyTerminator(Me.Sections.RF.Frequency.Suffix))
		End Sub

	End Class






