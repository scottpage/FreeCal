'
' Created by SharpDevelop.
' User: rspage
' Date: 7/5/2005
' Time: 1:03 PM
' 

Imports System
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Class ScalarNetworkAnalyzerAverageSection

		Protected _MainScalarNetworkAnalyzer As ScalarNetworkAnalyzer

		Public Sub New(ByRef MainScalarNetworkAnalyzer As ScalarNetworkAnalyzer)
			Me._MainScalarNetworkAnalyzer = MainScalarNetworkAnalyzer
		End Sub

	End Class

