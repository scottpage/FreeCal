'
' Created by SharpDevelop.
' User: Administrator
' Date: 7/26/2005
' Time: 4:55 AM
'


Imports System
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Class IntervalAnalyzerInterfaceSection

		Protected _MainIntervalAnalyzer As IntervalAnalyzer
		Protected _OutputFormat As IntervalAnalyzerOutputFormatEnum

		Public Property OutputFormat As IntervalAnalyzerOutputFormatEnum
			Get
				Return Me._OutputFormat
			End Get
			Set
				Me._OutputFormat = Value
				Select Value
					Case IntervalAnalyzerOutputFormatEnum.ASCII
						Me._MainIntervalAnalyzer.Write(Me._MainIntervalAnalyzer.Commands.SetInterfaceOutputToASCII)
					Case IntervalAnalyzerOutputFormatEnum.Binary
						Me._MainIntervalAnalyzer.Write(Me._MainIntervalAnalyzer.Commands.SetInterfaceOutputToBinary)
					Case IntervalAnalyzerOutputFormatEnum.FloatingPoint
						Me._MainIntervalAnalyzer.Write(Me._MainIntervalAnalyzer.Commands.SetInterfaceOutputToFloatingPoint)
				End Select
			End Set
		End Property

		Public Sub New(ByRef mainIntervalAnalyzer As IntervalAnalyzer)
			Me._MainIntervalAnalyzer = mainIntervalAnalyzer
		End Sub

	End Class


