'
' Created by SharpDevelop.
' User: Administrator
' Date: 7/26/2005
' Time: 4:52 AM
'


Imports System
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Class IntervalAnalyzerSubSystemSection

		Protected _MainIntervalAnalyzer As IntervalAnalyzer
		Protected _Interface As IntervalAnalyzerInterfaceSection
		Protected _Measurements As IntervalAnalyzerMeasurementsSection
		Protected _CurrentSubSystem As IntervalAnalyzerSubSystemEnum

		Public Property CurrentSubSystem As IntervalAnalyzerSubSystemEnum
			Get
				Return Me._CurrentSubSystem
			End Get
			Set
				If Not Me._CurrentSubSystem = Value
					Me._CurrentSubSystem = Value
					Select Value
						Case IntervalAnalyzerSubSystemEnum.Graphic
							Me._MainIntervalAnalyzer.Write("GRAP")
						Case IntervalAnalyzerSubSystemEnum.Input
							Me._MainIntervalAnalyzer.Write("INP")
						Case IntervalAnalyzerSubSystemEnum.InstrumentState
							Me._MainIntervalAnalyzer.Write("IST")
						Case IntervalAnalyzerSubSystemEnum.Measurement
							Me._MainIntervalAnalyzer.Write("MEAS")
						Case IntervalAnalyzerSubSystemEnum.Process
							Me._MainIntervalAnalyzer.Write("PROC")
					End Select
				End If
			End Set
		End Property

		Public ReadOnly Property [Interface] As IntervalAnalyzerInterfaceSection
			Get
				Me.CurrentSubSystem = IntervalAnalyzerSubSystemEnum.Interface
				Return Me._Interface
			End Get
		End Property

		Public ReadOnly Property Measurements As IntervalAnalyzerMeasurementsSection
			Get
				Return Me._Measurements
			End Get
		End Property

		Public Sub New(ByRef mainIntervalAnalyzer As IntervalAnalyzer)
			Me._MainIntervalAnalyzer = mainIntervalAnalyzer
			Me._Interface = New IntervalAnalyzerInterfaceSection(Me._MainIntervalAnalyzer)
			Me._Measurements = New IntervalAnalyzerMeasurementsSection(Me._MainIntervalAnalyzer)
		End Sub

	End Class

