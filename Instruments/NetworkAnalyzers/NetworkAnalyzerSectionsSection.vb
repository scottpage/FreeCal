'
' Created by SharpDevelop.
' User: Administrator
' Date: 7/12/2005
' Time: 5:28 PM
'


Imports System
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Class NetworkAnalyzerSectionsSection

		Protected _MainNetworkAnalyzer As NetworkAnalyzer
		Protected _Calibration As NetworkAnalyzerCalibrationSection
		Protected _Parameter As NetworkAnalyzerParameterSection
		Protected _Format As NetworkAnalyzerFormatSection
		Protected _Markers As NetworkAnalyzerMarkerSection
		Protected _Output As NetworkAnalyzerOutputSection
		Protected _Stimulus As NetworkAnalyzerStimulusSection

		Public ReadOnly Property Stimulus As NetworkAnalyzerStimulusSection
			Get
				Return Me._Stimulus
			End Get
		End Property

		Public ReadOnly Property Output As NetworkAnalyzerOutputSection
			Get
				Return Me._Output
			End Get
		End Property

		Public ReadOnly Property Markers As NetworkAnalyzerMarkerSection
			Get
				Return Me._Markers
			End Get
		End Property

		Public ReadOnly Property [Format] As NetworkAnalyzerFormatSection
			Get
				Return Me._Format
			End Get
		End Property

		Public ReadOnly Property Parameter As NetworkAnalyzerParameterSection
			Get
				Return Me._Parameter
			End Get
		End Property

		Public ReadOnly Property Calibration As NetworkAnalyzerCalibrationSection
			Get
				Return Me._Calibration
			End Get
		End Property

		Public Sub New(ByRef mainNetworkAnalyzer As NetworkAnalyzer)
			Me._MainNetworkAnalyzer = mainNetworkAnalyzer
			Me._Calibration = New NetworkAnalyzerCalibrationSection(Me._MainNetworkAnalyzer)
			Me._Parameter = New NetworkAnalyzerParameterSection(Me._MainNetworkAnalyzer)
			Me._Format = New NetworkAnalyzerFormatSection(Me._MainNetworkAnalyzer)
			Me._Markers = New NetworkAnalyzerMarkerSection(Me._MainNetworkAnalyzer)
			Me._Output = New NetworkAnalyzerOutputSection(Me._MainNetworkAnalyzer)
			Me._Stimulus = New NetworkAnalyzerStimulusSection(Me._MainNetworkAnalyzer)
		End Sub
	End Class

