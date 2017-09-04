'
' Created by SharpDevelop.
' User: rspage
' Date: 6/28/2005
' Time: 10:36 AM
' 

Imports System
Imports Microsoft.VisualBasic.ControlChars
Imports NationalInstruments.NI4882
Imports FreeCal.Instruments
Imports FreeCal.Common
Imports System.Windows.Forms
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Class NetworkAnalyzerMarkerSection

		Protected _MainNetworkAnalyzer As NetworkAnalyzer
		Protected _Current As NetworkAnalyzerMarkerEnum = NetworkAnalyzerMarkerEnum.AllOff
		Protected _Frequency As Double = 4000
		Protected _Suffix As FrequencyEnum = FrequencyEnum.MHz

		Public Property Current As NetworkAnalyzerMarkerEnum
			Get
				Return Me._Current
			End Get
			Set
				Me._Current = Value
				Select Value
					Case NetworkAnalyzerMarkerEnum.AllOff
						Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.AllMarkersOff)
					Case NetworkAnalyzerMarkerEnum.Marker1
						Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.Marker1)
					Case NetworkAnalyzerMarkerEnum.Marker2
						Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.Marker2)
					Case NetworkAnalyzerMarkerEnum.Marker3
						Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.Marker3)
					Case NetworkAnalyzerMarkerEnum.Marker4
						Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.Marker4)
				End Select
			End Set
		End Property

		Public Property Frequency As Double
			Get
				Return Me._Frequency
			End Get
			Set
				Me._Frequency = Value
				Select Me._Current
					Case NetworkAnalyzerMarkerEnum.AllOff
					Case NetworkAnalyzerMarkerEnum.Marker1
						Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.Marker1 & Value & Me._MainNetworkAnalyzer.GetFrequencyTerminator(Me._Suffix))
					Case NetworkAnalyzerMarkerEnum.Marker2
						Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.Marker2 & Value & Me._MainNetworkAnalyzer.GetFrequencyTerminator(Me._Suffix))
					Case NetworkAnalyzerMarkerEnum.Marker3
						Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.Marker3 & Value & Me._MainNetworkAnalyzer.GetFrequencyTerminator(Me._Suffix))
					Case NetworkAnalyzerMarkerEnum.Marker4
						Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.Marker4 & Value & Me._MainNetworkAnalyzer.GetFrequencyTerminator(Me._Suffix))
				End Select
			End Set
		End Property

		Public Property Suffix As FrequencyEnum
			Get
				Return Me._Suffix
			End Get
			Set
				Me._Suffix = Value
			End Set
		End Property

		Public Sub New(ByRef MainNetworkAnalyzer As NetworkAnalyzer)
			Me._MainNetworkAnalyzer = MainNetworkAnalyzer
		End Sub

	End Class

