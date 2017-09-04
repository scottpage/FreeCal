'
' Created by SharpDevelop.
' User: Administrator
' Date: 7/6/2005
' Time: 12:19 PM
'


Imports System
Imports FreeCal.Common
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Class SpectrumAnalyzerFrequencySection

		Protected _MainSpectrumAnalyzer As SpectrumAnalyzer
		Protected Friend _Start As Double
		Protected Friend _StartSuffix As FrequencyEnum = FrequencyEnum.GHz
		Protected Friend _Stop As Double
		Protected Friend _StopSuffix As FrequencyEnum = FrequencyEnum.GHz
		Protected Friend _Center As Double
		Protected Friend _CenterSuffix As FrequencyEnum = FrequencyEnum.GHz

		Public WriteOnly Property AllSuffixes As FrequencyEnum
			Set
				Me._CenterSuffix = Value
				Me._StartSuffix = Value
				Me._StopSuffix = Value
			End Set
		End Property

		Public Property CenterSuffix As FrequencyEnum
			Get
				Return Me._CenterSuffix
			End Get
			Set
				Me._CenterSuffix = Value
			End Set
		End Property

		Public Property StartSuffix As FrequencyEnum
			Get
				Return Me._StartSuffix
			End Get
			Set
				Me._StartSuffix = Value
			End Set
		End Property

		Public Property StopSuffix As FrequencyEnum
			Get
				Return Me._StopSuffix
			End Get
			Set
				Me._StopSuffix = Value
			End Set
		End Property

		Public Property Start As Double
			Get
				Return Me._Start
			End Get
			Set
				Me._MainSpectrumAnalyzer.Write(Me._MainSpectrumAnalyzer.Commands.SetStartFrequency & Value & Me._MainSpectrumAnalyzer.GetFrequencyTerminator(Me._StartSuffix))
				Me._Update
				Me._MainSpectrumAnalyzer.Sections.Span._Update
			End Set
		End Property

		Public Property [Stop] As Double
			Get
				Return Me._Stop
			End Get
			Set
				Me._MainSpectrumAnalyzer.Write(Me._MainSpectrumAnalyzer.Commands.SetStopFrequency & Value & Me._MainSpectrumAnalyzer.GetFrequencyTerminator(Me._StopSuffix))
				Me._Update
				Me._MainSpectrumAnalyzer.Sections.Span._Update
			End Set
		End Property

		Public Property Center As Double
			Get
				Return Me._Center
			End Get
			Set
				Me._MainSpectrumAnalyzer.Write(Me._MainSpectrumAnalyzer.Commands.SetCenterFrequency & Value & Me._MainSpectrumAnalyzer.GetFrequencyTerminator(Me._CenterSuffix))
				Me._Update
				Me._MainSpectrumAnalyzer.Sections.Span._Update
			End Set
		End Property

		Protected Friend Sub _Update
			Me._MainSpectrumAnalyzer.Write(Me._MainSpectrumAnalyzer.Commands.GetCenterFrequency)
			Me._Center = Me._MainSpectrumAnalyzer.ConvertFrequency(Me._MainSpectrumAnalyzer.ReadDouble, Me._MainSpectrumAnalyzer.Capabilities.FundamentalFrequencySuffix, Me._CenterSuffix)
			Me._MainSpectrumAnalyzer.Write(Me._MainSpectrumAnalyzer.Commands.GetStartFrequency)
			Me._Start = Me._MainSpectrumAnalyzer.ConvertFrequency(Me._MainSpectrumAnalyzer.ReadDouble, Me._MainSpectrumAnalyzer.Capabilities.FundamentalFrequencySuffix, Me._StartSuffix)
			Me._MainSpectrumAnalyzer.Write(Me._MainSpectrumAnalyzer.Commands.GetStopFrequency)
			Me._Stop = Me._MainSpectrumAnalyzer.ConvertFrequency(Me._MainSpectrumAnalyzer.ReadDouble, Me._MainSpectrumAnalyzer.Capabilities.FundamentalFrequencySuffix, Me._StopSuffix)
		End Sub

		Public Sub New(ByRef mainSpectrumAnalyzer As SpectrumAnalyzer)
			Me._MainSpectrumAnalyzer = MainSpectrumAnalyzer
			Me._Update
		End Sub

	End Class

