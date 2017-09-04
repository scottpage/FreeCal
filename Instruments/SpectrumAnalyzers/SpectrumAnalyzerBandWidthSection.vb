'
' Created by SharpDevelop.
' User: rspage
' Date: 7/7/2005
' Time: 11:39 AM
' 



Imports System
Imports FreeCal.Common
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Class SpectrumAnalyzerBandWidthSection

		Protected _MainSpectrumAnalyzer As SpectrumAnalyzer
		Protected _ResolutionBandwidthFrequencySuffix As FrequencyEnum
		Protected _ResolutionBandWidth As SpectrumAnalyzerResolutionBandwidthEnum

		Public Property ResolutionBandwidth As SpectrumAnalyzerResolutionBandwidthEnum
			Get
				Return Me._ResolutionBandwidth
			End Get
			Set
				Me._ResolutionBandwidth = Value
				Me._MainSpectrumAnalyzer.Write(Me._MainSpectrumAnalyzer.Commands.SetResolutionBandwidth & Value & Me._MainSpectrumAnalyzer.CommandTerminators.MultipleCommandSeperator)
			End Set
		End Property

		Public Property ResolutionBandwidthFrequencySuffix As FrequencyEnum
			Get
				Return Me._ResolutionBandwidthFrequencySuffix
			End Get
			Set
				Me._ResolutionBandwidthFrequencySuffix = Value
			End Set
		End Property

		Public Sub New(ByRef mainSpectrumAnalyzer As SpectrumAnalyzer)
			Me._MainSpectrumAnalyzer = mainSpectrumAnalyzer
		End Sub

	End Class

