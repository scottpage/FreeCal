'
' Created by SharpDevelop.
' User: rspage
' Date: 6/14/2005
' Time: 9:12 AM
' 

Imports System
Imports FreeCal.Common



	Public Structure MeasuringReceiverCapabilities
		Public MinimumWarmUpTime As Integer

		Public MinimumFrequency As Double
		Public MinimumFrequencyMultiplier As FrequencyEnum
		Public MaximumFrequency As Double
		Public MaximumFrequencyMultiplier As FrequencyEnum
		Public NumberOfFrequencyBands As Integer

		Public MinimumInputAmplitude As Double
		Public MaximumInputAmplitude As Double
		Public InputAmplitudeMultiplier As AmplitudeEnum

		Public ReferenceOscillatorFrequency As Double
		Public ReferenceOscillatorFrequencyMultiplier As FrequencyEnum
	End Structure

	Public Structure MeasuringReceiverTestFrequencies
		Public None As String
	End Structure

	Public Structure MeasuringReceiverSpecifications
		Public None As String
	End Structure


