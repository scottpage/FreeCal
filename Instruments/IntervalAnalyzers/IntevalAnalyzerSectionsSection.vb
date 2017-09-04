'
' Created by SharpDevelop.
' User: rspage
' Date: 7/25/2005
' Time: 3:01 PM
' 



Imports System
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Class IntervalAnalyzerSectionsSection

		Protected _MainIntervalAnalyzer As IntervalAnalyzer
		Protected _SubSystem As IntervalAnalyzerSubSystemSection

		Public ReadOnly Property SubSystem As IntervalAnalyzerSubSystemSection
			Get
				Return Me._SubSystem
			End Get
		End Property

		Public Sub New(ByRef mainIntervalAnalyzer As IntervalAnalyzer)
			Me._MainIntervalAnalyzer = mainIntervalAnalyzer
			Me._SubSystem = New IntervalAnalyzerSubSystemSection(Me._MainIntervalAnalyzer)
		End Sub

	End Class

