'
' Created by SharpDevelop.
' User: rspage
' Date: 7/7/2005
' Time: 11:31 AM
' 



Imports System
Imports FreeCal.Common
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Class SpectrumAnalyzerMarkerSection

		Protected _MainSpectrumAnalyzer As SpectrumAnalyzer
		Protected _MarkerPosition As Double
		Protected _MarkerFrequencySuffix As FrequencyEnum = FrequencyEnum.MHz
		Protected _MarkerReadout As MarkerReadoutEnum

		Public Property MarkerPosition As Double
			Get
				Return Me._MarkerPosition
			End Get
			Set
				Me._MarkerPosition = Value
				Me._MainSpectrumAnalyzer.Write(Me._MainSpectrumAnalyzer.Commands.SetMarkerPosition & Value & Me._MainSpectrumAnalyzer.GetFrequencyTerminator(Me._MarkerFrequencySuffix))
			End Set
		End Property

		Public Property MarkerFrequencySuffix As FrequencyEnum
			Get
				Return Me._MarkerFrequencySuffix
			End Get
			Set
				Me._MarkerFrequencySuffix = Value
			End Set
		End Property

		Public ReadOnly Property MarkerAmplitude As Double
			Get
				Me._MainSpectrumAnalyzer.Write(Me._MainSpectrumAnalyzer.Commands.GetMarkerAmplitude)
				Return Me._MainSpectrumAnalyzer.ReadDouble
			End Get
		End Property

		Public Property MarkerReadout As MarkerReadoutEnum
			Get
				Return Me._MarkerReadout
			End Get
			Set
				Me._MarkerReadout = Value
				Select Value
					Case MarkerReadoutEnum.Frequency
						Me._MainSpectrumAnalyzer.Write(Me._MainSpectrumAnalyzer.Commands.SetReadoutToFrequency)
				End Select
			End Set
		End Property

		Public Sub PeakSearchHigh
			Me._MainSpectrumAnalyzer.Write(Me._MainSpectrumAnalyzer.Commands.SetPeakSearchHigh)
		End Sub

		Public Sub SetReferenceLevelToMarker
			Me._MainSpectrumAnalyzer.Write(Me._MainSpectrumAnalyzer.Commands.SetReferenceLevelToMarker)
		End Sub

		Public Sub SetDeltaMarker
			Me._MainSpectrumAnalyzer.Write(Me._MainSpectrumAnalyzer.Commands.SetDeltaMarker)
		End Sub

		Public Function ReadMarkerA As Double
			Me._MainSpectrumAnalyzer.Write(Me._MainSpectrumAnalyzer.Commands.GetMarkerA)
			Return Me._MainSpectrumAnalyzer.ReadDouble
		End Function

		Public Sub New(ByRef mainSpectrumAnalyzer As SpectrumAnalyzer)
			Me._MainSpectrumAnalyzer = mainSpectrumAnalyzer
		End Sub

	End Class

