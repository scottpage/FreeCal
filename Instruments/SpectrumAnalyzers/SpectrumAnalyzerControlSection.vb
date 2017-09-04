'
' Created by SharpDevelop.
' User: rspage
' Date: 7/7/2005
' Time: 11:25 AM
' 



Imports System
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Class SpectrumAnalyzerControlSection

		Protected _MainSpectrumAnalyzer As SpectrumAnalyzer
		Protected Friend _Sweep As SpectrumAnalyzerSweepSection
		Protected Friend _BW As SpectrumAnalyzerBandWidthSection

		Public ReadOnly Property BW As SpectrumAnalyzerBandWidthSection
			Get
				Return Me._BW
			End Get
		End Property

		Public ReadOnly Property Sweep As SpectrumAnalyzerSweepSection
			Get
				Return Me._Sweep
			End Get
		End Property

		Public Sub New(ByRef mainSpectrumAnalyzer As SpectrumAnalyzer)
			Me._MainSpectrumAnalyzer = mainSpectrumAnalyzer
			Me._Sweep = New SpectrumAnalyzerSweepSection(Me._MainSpectrumAnalyzer)
			Me._BW = New SpectrumAnalyzerBandWidthSection(Me._MainSpectrumAnalyzer)
		End Sub

	End Class

