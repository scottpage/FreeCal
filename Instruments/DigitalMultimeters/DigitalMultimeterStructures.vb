'
' Created by SharpDevelop.
' User: Administrator
' Date: 7/28/2005
' Time: 8:30 PM
'

Imports System
Imports FreeCal.Common
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
    Public Structure DigitalMultimeterGPIBCommands
        Public ACCurrentMode As String
        Public ACVoltMode As String
        Public DCCurrentMode As String
        Public DCVoltMode As String
        Public TwoWireResistanceMode As String
        Public FourWireResistanceMode As String
        Public ACVoltRange As String
        Public DCVoltRange As String
        Public ACAmpRange As String
        Public DCAmpRange As String
        Public TwoWireResistanceRange As String
        Public FourWireResistanceRange As String
        Public Read As String
    End Structure

	Public Structure DigitalMultimeterCapabilities
		Public TwoWireOhms As Boolean
		Public FourWireOhms As Boolean
		Public DCVolts As Boolean
		Public ACVolta As Boolean
		Public DCCurrent As Boolean
		Public ACCurrent As Boolean
	End Structure

		'All voltages as based on Volt
		'All currents is based on Amp
		'All frequency is based on Hz
		'All resistance is based on Ohm
	Public Structure DigitalMultimeterTestPoints
		Public ACVoltTestRanges() As Double
		Public ACVoltTestAppliedVoltages() As Double
		Public ACVoltTestAppliedFrequencies() As Double
		Public DCVoltTestRanges() As Double
		Public DCVoltTestAppliedVoltages() As Double
		Public ACCurrentTestRanges() As Double
		Public ACCurrentTestAppliedCurrents() As Double
		Public ACCurrentTestAppliedFrequencies() As Double
		Public DCCurrentTestRanges() As Double
		Public DCCurrentTestAppliedCurrents() As Double
		Public TwoWireResistanceTestRanges() As Double
		Public TwoWireResistanceTestAppliedOhms() As Double
		Public FourWireResistanceTestRanges() As Double
		Public FourWireResistanceTestAppliedOhms() As Double
		Public FrequencyTestRanges() As Double
		Public FrequencyTestAppliedVoltages() As Double
		Public FrequencyTestAppliedFrequencies() As Double
	End Structure

	Public Structure DigitalMultimeterSpecifications
		Public None As Double
	End Structure




