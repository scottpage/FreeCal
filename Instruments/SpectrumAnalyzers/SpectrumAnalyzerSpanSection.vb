'
' Created by SharpDevelop.
' User: Administrator
' Date: 7/6/2005
' Time: 12:09 PM
'

Imports System
Imports FreeCal.Common
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Class SpectrumAnalyzerSpanSection

		Protected Friend _MainSpectrumAnalyzer As SpectrumAnalyzer
		Protected Friend _Width As Double
		Protected Friend _Suffix As FrequencyEnum = FrequencyEnum.GHz

		Public Property Width As Double
			Get
				Return Me._Width
			End Get
			Set
				Me._MainSpectrumAnalyzer.Write(Me._MainSpectrumAnalyzer.Commands.SetSpanWidth & Value & Me._MainSpectrumAnalyzer.GetFrequencyTerminator(Me._Suffix))
				Me._Update
				Me._MainSpectrumAnalyzer.Sections.Frequency._Update
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

		Protected Friend Sub _Update
			Me._MainSpectrumAnalyzer.Write(Me._MainSpectrumAnalyzer.Commands.GetSpanWidth)
			Me._Width = Me._MainSpectrumAnalyzer.ConvertFrequency(Me._MainSpectrumAnalyzer.ReadDouble, Me._MainSpectrumAnalyzer.Capabilities.FundamentalFrequencySuffix, Me._Suffix)
		End Sub

		Public Sub New(ByRef mainSpectrumAnalyzer As SpectrumAnalyzer)
			Me._MainSpectrumAnalyzer = MainSpectrumAnalyzer
			Me._Update
		End Sub

	End Class

