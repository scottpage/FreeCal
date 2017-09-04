'
' Created by SharpDevelop.
' User: Administrator
' Date: 7/9/2005
' Time: 5:50 PM
'

Imports System
Imports FreeCal.Common
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.ControlChars
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Class SpectrumAnalyzerInstrumentStateSection

		Protected Friend _MainSpectrumAnalyzer As SpectrumAnalyzer

		Public Sub New(ByRef mainSpectrumAnalyzer As SpectrumAnalyzer)
			Me._MainSpectrumAnalyzer = mainSpectrumAnalyzer
		End Sub

	End Class

