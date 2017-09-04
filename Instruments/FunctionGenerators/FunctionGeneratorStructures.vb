'
' Created by SharpDevelop.
' User: rspage
' Date: 6/16/2005
' Time: 9:28 AM
' 

Imports System
Imports FreeCal.Common


Public Structure FunctionGeneratorGPIBCommands
    Public SetFrequency As String
    Public SetAmplitude As String
    Public SetSineWaveform As String
    Public RearOnlyOutput As String
    Public FrontOnlyOutput As String
End Structure

Public Structure FunctionGeneratorCapabilities
    Public MinimumWarmUpTime As Integer

    Public MinimumFrequency As Double
    Public MinimumFrequencyMultiplier As FrequencyEnum
    Public MaximumFrequency As Double
    Public MaximumFrequencyMultiplier As FrequencyEnum
    Public NumberOfFrequencyBands As Integer

    Public MinimumAmplitude As Double
    Public MaximumAmplitude As Double
    Public AmplitudeMultiplier As AmplitudeEnum
End Structure

Public Structure FunctionGeneratorTestPoints
    Public None As String
End Structure

Public Structure FunctionGeneratorSpecifications
    Public None As String
End Structure


