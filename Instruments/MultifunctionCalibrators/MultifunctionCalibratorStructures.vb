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
    Public Structure MultifunctionCalibratorGPIBCommands
        Public OutputParameters As String
        Public Operate As String
        Public StandBy As String
        Public ExternalSenseOn As String
        Public ExternalSenseOff As String
        Public ACOff As String
    End Structure

	Public Structure MultifunctionCalibratorCapabilities
		Public None As Double
	End Structure

	Public Structure MultifunctionCalibratorTestPoints
		Public None() As Double
	End Structure

	Public Structure MultifunctionCalibratorpecifications
		Public None As Double
	End Structure




