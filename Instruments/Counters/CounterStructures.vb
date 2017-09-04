'
' Created by SharpDevelop.
' User: rspage
' Date: 6/14/2005
' Time: 1:00 PM
' 


Public Structure CounterGPIBCommands
    Public FrequencyModeAuto As String
    Public FrequencyModeManual As String
    Public ManualCenterFrequency As String
    Public AmplitudeMode As String
    Public FrequencyOffsetMode As String
    Public FrequencyOffset As String
    Public AmplitudeOffset As String
    Public Resolution As String
    Public LowRange As String
    Public HighRange As String
    Public CWMode As String
    Public FMMode As String
    Public TriggerMode As String
    Public OutputMode As String
    Public [Reset] As String
    Public AutomaticFrequencyOffset As String
    Public AutomaticAmlitudeOffset As String
    Public CheckMode As String
    Public FastAcquisitionTime As String
    Public MediumAcquisitionTime As String
    Public SlowAcquisitionTime As String
End Structure

Public Structure CounterCapabilities
    Public MinimumFrequency As Double
    Public MinimumFrequencySuffix As FrequencyEnum
    Public MaximumFrequency As Double
    Public MaximumFrequencySuffix As FrequencyEnum
    Public NumberOfFrequencyBands As Integer

    Public MinimumRFAmplitude As Double
    Public MaximumRFAmplitude As Double
    Public RFAmplitudeSuffix As AmplitudeEnum

    Public ReferenceOscillatorFrequency As Double
    Public ReferenceOscillatorFrequencySuffix As FrequencyEnum
End Structure

Public Structure CounterTestPoints
    Public LowRangeTestFrequencies() As Double
    Public HighRangeTestFrequencies() As Double
End Structure

Public Structure CounterSpecifications
    Public ReferenceOscillatorFrequencyTolerance As Double
End Structure




