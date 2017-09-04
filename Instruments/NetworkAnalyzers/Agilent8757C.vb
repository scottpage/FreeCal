'
' Created by SharpDevelop.
' User: rspage
' Date: 7/5/2005
' Time: 12:51 PM
' 



Imports System
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Class Agilent8757C
		Inherits FreeCal.Instruments.NetworkAnalyzers.ScalarNetworkAnalyzer

		Public Sub New(ByVal boardAddress As Integer, ByVal primaryAddress As Byte, ByVal getSettingsFromInstrument As Boolean, Optional ByVal simulate As Boolean = False)
		    MyBase.New(BoardAddress, PrimaryAddress, GetSettingsFromInstrument, Simulate)
		    Me._Model = "8757C"
		    Me._Manufacturer = "Agilent Technologies"
		End Sub

	End Class

