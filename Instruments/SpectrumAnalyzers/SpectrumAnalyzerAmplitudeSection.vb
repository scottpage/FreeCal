'
' Created by SharpDevelop.
' User: rspage
' Date: 7/7/2005
' Time: 11:36 AM
' 



Imports System
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Class SpectrumAnalyzerAmplitudeSection

		Protected _MainSpectrumAnalyzer As SpectrumAnalyzer
		Protected _ReferenceLevel As Double

		Public Property ReferenceLevel As Double
			Get
				Return Me._ReferenceLevel
			End Get
			Set
				Me._ReferenceLevel = Value
				Me._MainSpectrumAnalyzer.Write(Me._MainSpectrumAnalyzer.Commands.SetReferenceLevel & Value & Me._MainSpectrumAnalyzer.CommandTerminators.dBm)
			End Set
		End Property

		Public Sub New(ByRef mainSpectrumAnalyzer As SpectrumAnalyzer)
			Me._MainSpectrumAnalyzer = mainSpectrumAnalyzer
		End Sub

	End Class

