'
' Created by SharpDevelop.
' User: rspage
' Date: 7/7/2005
' Time: 11:11 AM
' 



Imports System
Imports FreeCal.Common
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Class SpectrumAnalyzerSweepSection

		Protected Friend _MainSpectrumAnalyzer As SpectrumAnalyzer
		Protected Friend _Time As Double
		Protected Friend _Suffix As TimeEnum = TimeEnum.Seconds

		Public Property Suffix As TimeEnum
			Get
				Return Me._Suffix
			End Get
			Set
				Me._Suffix = Value
			End Set
		End Property

		Public Property Time As Double
			Get
				Return Me._Time
			End Get
			Set
				Me._Time = Value
				Me._MainSpectrumAnalyzer.Write(Me._MainSpectrumAnalyzer.Commands.SetSweepTime & Value & Me._MainSpectrumAnalyzer.GetTimeTerminator(Me._Suffix))
			End Set
		End Property

		Public Sub New(ByRef mainSpectrumAnalyzer As SpectrumAnalyzer)
			Me._MainSpectrumAnalyzer = mainSpectrumAnalyzer
		End Sub

	End Class

