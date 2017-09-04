'
' Created by SharpDevelop.
' User: Administrator
' Date: 7/9/2005
' Time: 6:21 PM
'


Imports System
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Class SpectrumAnalyzerSectionsSection

		Protected _MainSpectrumAnalyzer As SpectrumAnalyzer
		Protected _Frequency As SpectrumAnalyzerFrequencySection
		Protected _Span As SpectrumAnalyzerSpanSection
		Protected _Control As SpectrumAnalyzerControlSection
		Protected _Amplitude As SpectrumAnalyzerAmplitudeSection
		Protected _Markers As SpectrumAnalyzerMarkerSection
		Protected _InstrumentState As SpectrumAnalyzerInstrumentStateSection

		Public ReadOnly Property InstrumentState As SpectrumAnalyzerInstrumentStateSection
			Get
				Return Me._InstrumentState
			End Get
		End Property

		Public ReadOnly Property Markers As SpectrumAnalyzerMarkerSection
			Get
				Return Me._Markers
			End Get
		End Property

		Public ReadOnly Property Amplitude As SpectrumAnalyzerAmplitudeSection
			Get
				Return Me._Amplitude
			End Get
		End Property

		Public ReadOnly Property Control As SpectrumAnalyzerControlSection
			Get
				Return Me._Control
			End Get
		End Property

		Public ReadOnly Property Frequency As SpectrumAnalyzerFrequencySection
			Get
				Return Me._Frequency
			End Get
		End Property

		Public ReadOnly Property Span As SpectrumAnalyzerSpanSection
			Get
				Return Me._Span
			End Get
		End Property

		Public Sub New(ByRef mainSpectrumAnalyzer As SpectrumAnalyzer)
			Me._MainSpectrumAnalyzer = mainSpectrumAnalyzer
			Me._Frequency = New SpectrumAnalyzerFrequencySection(Me._MainSpectrumAnalyzer)
			Me._Span = New SpectrumAnalyzerSpanSection(Me._MainSpectrumAnalyzer)
			Me._Control = New SpectrumAnalyzerControlSection(Me._MainSpectrumAnalyzer)
			Me._Amplitude = New SpectrumAnalyzerAmplitudeSection(Me._MainSpectrumAnalyzer)
			Me._Markers = New SpectrumAnalyzerMarkerSection(Me._MainSpectrumAnalyzer)
			Me._InstrumentState = New SpectrumAnalyzerInstrumentStateSection(Me._MainSpectrumAnalyzer)
		End Sub

	End Class

