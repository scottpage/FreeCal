'
' Created by SharpDevelop.
' User: rspage
' Date: 6/13/2005
' Time: 10:20 AM
' 

Imports System
Imports FreeCal.Common
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
    Public Structure SignalGeneratorGPIBCommands
        Public SetCWFrequency As String
        Public SetRFAmplitude As String
        Public SetRFAmplitudeSuffix As String
        Public SetRFOutputStateOn As String
        Public SetRFOutputStateOff As String
        Public SetAMFrequency As String
        Public SetAMDepth As String
        Public SetAMStateOn As String
        Public SetAMStateOff As String
        Public SetFMFrequency As String
        Public SetFMDeviation As String
        Public SetFMStateOn As String
        Public SetFMStateOff As String
		Public SetModulationStateOn As String
		Public SetModulationStateOff As String
		Public SetModulationMode As String
		Public SetSweepTime As String
		Public SetSweepMode As String
		Public GetRFAmplitude As String
    End Structure

	Public Structure SignalGeneratorCapabilities
		Public HasInternalFMModulation As Boolean
		Public HasInternalAMModulation As Boolean
		Public HasInternalPhaseModulation As Boolean

		Public MinimumFrequency As Double
		Public MinimumFrequencySuffix As FrequencyEnum
		Public MaximumFrequency As Double
		Public MaximumFrequencySuffix As FrequencyEnum
		Public NumberOfFrequencyBands As Integer

		Public MinimumRFAmplitude As Double
		Public MaximumRFAmplitude As Double
		Public RFAmplitudeSuffix As AmplitudeEnum

        Public MaximumSweepTime As Integer
        Public MaximumSweepTimeSuffix As TimeEnum

		Public ReferenceOscillatorFrequency As Double
		Public ReferenceOscillatorFrequencySuffix As FrequencyEnum
	End Structure

	Public Structure SignalGeneratorTestPoints
		Public HighAmplitudeAccuracyTestFrequencies() As Double
		Public HighAmplitudeAccuracyTestAmplitudes() As Double
		Public AttenuatorAccuracyTestFrequencies() As Double
		Public CarrierFrequencyAccuracyTestFrequencies() As Double
		Public ResidualAMTestFrequencies() As Double
		Public AMModulationTestFrequencies() As Double
		Public AMModulationTestAmplitudes() As Double
		Public AMModulationTestDepths() As Double
		Public SpectralPurityTestFrequencies() As Double
	End Structure

	Public Structure SignalGeneratorSpecifications
		Public HighAmplitudeAccuracyTolerance As Double
		Public AttenuatorAccuracyTolerance As Double
		Public CarrierFrequencyAccuracyTolerance As Double
		Public AMDepthTolerance As Double
		Public ResidualAMTolerance As Double
		Public AMIndicatorAccuracyTolerance As Double
		Public AMDistortionTolerance As Double
		Public IncidentalPhaseModulationTolerance As Double
		Public FirstHarmonicTolerance As Double
		Public SecondHarmonicTolerance As Double
		Public SubHarmonicTolerance As Double
		Public ReferenceOscillatorFrequencyTolerance As Double
	End Structure


