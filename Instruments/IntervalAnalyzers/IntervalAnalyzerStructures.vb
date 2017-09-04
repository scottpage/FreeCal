'
' Created by SharpDevelop.
' User: rspage
' Date: 7/25/2005
' Time: 3:04 PM
' 

Imports System
Imports FreeCal.Common
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
    Public Structure IntervalAnalyzerGPIBCommands
        Public SetMeasurementFunctionToFrequency As String
        Public SetInterfaceOutputToASCII As String
        Public SetInterfaceOutputToBinary As String
        Public SetInterfaceOutputToFloatingPoint As String
        Public SetSourceAManualTrigger As String
        Public SetSourceATriggerLevelTo0Volts As String
        Public SetIntervalArming As String
        Public SetSourceAStatisticsOn As String
        Public SetMeasurementReadySRQMask As String
        Public SetMeasurementSourceToA As String
        Public SetMeasurementArmingToISampling As String
    End Structure

	Public Structure IntervalAnalyzerCapabilities
		Public ReferenceOscillatorFrequency As Double
		Public ReferenceOscillatorFrequencySuffix As FrequencyEnum
	End Structure

	Public Structure IntervalAnalyzerTestPoints
		Public None() As Double
	End Structure

	Public Structure IntervalAnalyzerSpecifications
		Public ReferenceOscillatorFrequencyTolerance As Double
	End Structure



