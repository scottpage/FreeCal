'
' Created by SharpDevelop.
' User: Administrator
' Date: 6/13/2005
' Time: 7:16 PM
' 

Imports System
Imports FreeCal.Common



	Public Structure NetworkAnalyzerCapabilities
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

	Public Structure NetworkAnalyzerTestPoints
		Public HighAmplitudeAccuracyTestFrequencies() As Double
		Public AttenuatorAccuracyTestFrequencies() As Double
		Public CarrierFrequencyAccuracyTestFrequencies() As Double
		Public ResidualAMTestFrequencies() As Double
		Public AMModulationTestFrequencies() As Double
		Public AMModulationTestAmplitudes() As Double
		Public AMModulationTestDepths() As Double
		Public SpectralPurityTestFrequencies() As Double
	End Structure

	Public Structure NetworkAnalyzerSpecifications
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



