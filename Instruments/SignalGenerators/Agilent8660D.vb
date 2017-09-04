'
' Created by SharpDevelop.
' User: rspage
' Date: 6/8/2005
' Time: 2:08 PM
' 

Imports System
Imports FreeCal.Common
Imports FreeCal.Instruments
Imports System.ComponentModel
Imports Microsoft.VisualBasic


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Class Agilent8660D
        Inherits FreeCal.Instruments.SignalGenerators.SignalGenerator

    Public Sub New(ByVal boardAddress As Integer, ByVal primaryAddress As Byte, ByVal getSettingsFromInstrument As Boolean, Optional ByVal simulate As Boolean = False)
        MyBase.New(boardAddress, primaryAddress, getSettingsFromInstrument, simulate)
        Me._Manufacturer = "Agilent Technologies"
        Me._Model = "8660D"
        Me.Write("NEW") 'Command required for Agilent8660D, turns on the "NEW" command capability (no reversal of numbers).
        Me.Sections.RF.Frequency.Suffix = FrequencyEnum.GHz
        Me.Sections.RF.Frequency.CW = 1
        Me.Sections.RF.Amplitude.Suffix = AmplitudeEnum.dBm
        Me.Sections.RF.Amplitude.Level = 0
    End Sub

    Public Overrides Sub SetupInstrument
        End Sub

        Protected Overrides Sub SetupCommandTerminators
            Me._CommandTerminators.dBm = "DM"
            Me._CommandTerminators.Hz = "HZ"
            Me._CommandTerminators.KHz = "KZ"
            Me._CommandTerminators.MHz = "MZ"
            Me._CommandTerminators.GHz = "GZ"
        End Sub

		Protected Overrides Sub SetupTestPoints
			Me._TestPoints.HighAmplitudeAccuracyTestFrequencies = New Double(){10, 100, 500, 1000, 2000, 2500}
			Me._TestPoints.HighAmplitudeAccuracyTestAmplitudes = New Double(){4, 8}
			Me._TestPoints.AttenuatorAccuracyTestFrequencies = New Double(){10, 100, 500, 1000, 2000, 2500}
			Me._TestPoints.CarrierFrequencyAccuracyTestFrequencies = New Double(){10, 100, 500, 1000, 2000, 2500}
			Me._TestPoints.SpectralPurityTestFrequencies = New Double(){10, 100, 500, 1000, 2000, 2500}
		End Sub

		Protected Overrides Sub SetupSpecifications
			Me._Specifications.HighAmplitudeAccuracyTolerance = 1
			Me._Specifications.AttenuatorAccuracyTolerance = 2
			Me._Specifications.CarrierFrequencyAccuracyTolerance = 0.000001
			Me._Specifications.ReferenceOscillatorFrequencyTolerance = 0.000001
			Me._Specifications.ResidualAMTolerance = 0.01
			Me._Specifications.AMDepthTolerance = 4
			Me._Specifications.AMDistortionTolerance = 1
			Me._Specifications.IncidentalPhaseModulationTolerance = 0.2
			Me._Specifications.FirstHarmonicTolerance = -40
			Me._Specifications.SecondHarmonicTolerance = -70
			Me._Specifications.SubHarmonicTolerance = -70
		End Sub

		Protected Overrides Sub SetupCapabilities
			Me._CanIdentify = False
			Me._Capabilities.HasInternalAMModulation = False
			Me._Capabilities.HasInternalFMModulation = False
			Me._Capabilities.HasInternalPhaseModulation = True
			Me._Capabilities.MinimumFrequency = 1
			Me._Capabilities.MinimumFrequencySuffix = FrequencyEnum.KHz
			Me._Capabilities.MaximumFrequency = 2600
			Me._Capabilities.MaximumFrequencySuffix = FrequencyEnum.MHz
			Me._Capabilities.MinimumRFAmplitude = -130
			Me._Capabilities.MaximumRFAmplitude = 13
			Me._Capabilities.RFAmplitudeSuffix = AmplitudeEnum.dBm
			Me._Capabilities.ReferenceOscillatorFrequency = 10
			Me._Capabilities.ReferenceOscillatorFrequencySuffix = FrequencyEnum.MHz
		End Sub

		Protected Overrides Sub SetupCommands
	        Me._GeneralCommands.Preset = ";"
	        Me._Commands.SetCWFrequency = "FR "
	        Me._Commands.SetRFAmplitude = "AP "
	        Me._Commands.SetRFOutputStateOn = ";"
	        Me._Commands.SetRFOutputStateOff = ";"
		End Sub

	End Class




