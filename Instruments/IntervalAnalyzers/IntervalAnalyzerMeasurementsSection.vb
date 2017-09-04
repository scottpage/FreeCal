'
' Created by SharpDevelop.
' User: rspage
' Date: 7/26/2005
' Time: 11:09 AM
' 

Imports System
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Class IntervalAnalyzerMeasurementsSection

		Protected _MainIntervalAnalyzer As IntervalAnalyzer
		Protected _Function As IntervalAnalyzerMeasurementFunctionEnum
		Protected _Source As IntervalAnalyzerMeasurementSourceEnum
		Protected _Arming As IntervalAnalyzerMeasurementArmingEnum

		Public Property Arming As IntervalAnalyzerMeasurementArmingEnum
			Get
				Return Me._Arming
			End Get
			Set
				Me._Arming = Value
				Select Value
					Case IntervalAnalyzerMeasurementArmingEnum.ISampling
						Me._MainIntervalAnalyzer.Write(Me._MainIntervalAnalyzer.Commands.SetMeasurementArmingToISampling)
				End Select
			End Set
		End Property

		Public Property [Function] As IntervalAnalyzerMeasurementFunctionEnum
			Get
				Return Me._Function
			End Get
			Set
				Me._Function = Value
				Select Value
					Case IntervalAnalyzerMeasurementFunctionEnum.Frequency
						Me._MainIntervalAnalyzer.Write(Me._MainIntervalAnalyzer.Commands.SetMeasurementFunctionToFrequency)
				End Select
			End Set
		End Property

		Public Property Source As IntervalAnalyzerMeasurementSourceEnum
			Get
				Return Me._Source
			End Get
			Set
				Me._Source = Value
				Select Value
					Case IntervalAnalyzerMeasurementSourceEnum.A
						Me._MainIntervalAnalyzer.Write(Me._MainIntervalAnalyzer.Commands.SetMeasurementSourceToA)
				End Select
			End Set
		End Property

		Public Sub New(ByRef mainIntervalAnalyzer As IntervalAnalyzer)
			Me._MainIntervalAnalyzer = mainIntervalAnalyzer
		End Sub

	End Class




