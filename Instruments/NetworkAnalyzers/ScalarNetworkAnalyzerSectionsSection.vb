'
' Created by SharpDevelop.
' User: rspage
' Date: 7/5/2005
' Time: 12:56 PM
' 

Imports System



	Public Class ScalarNetworkAnalyzerSectionsSection

		Protected _MainScalarNetworkAnalyzer As ScalarNetworkAnalyzer
		Protected _Display As ScalarNetworkAnalyzerDisplaySection
		Protected _Cursor As ScalarNetworkAnalyzerCursorSection
		Protected _Measurement As ScalarNetworkAnalyzerMeasurementSection
		Protected _Average As ScalarNetworkAnalyzerAverageSection
		Protected _Scale As ScalarNetworkAnalyzerScaleSection
		Protected _Calibration As ScalarNetworkAnalyzerCalibrationSection
		Protected _Reference As ScalarNetworkAnalyzerReferenceSection
		Protected _Channel As ScalarNetworkAnalyzerChannelSection

		Public ReadOnly Property Display As ScalarNetworkAnalyzerDisplaySection
			Get
				Return Me._Display
			End Get
		End Property

		Public ReadOnly Property Cursor As ScalarNetworkAnalyzerCursorSection
			Get
				Return Me._Cursor
			End Get
		End Property

		Public ReadOnly Property Measurement As ScalarNetworkAnalyzerMeasurementSection
			Get
				Return Me._Measurement
			End Get
		End Property

		Public ReadOnly Property Average As ScalarNetworkAnalyzerAverageSection
			Get
				Return Me._Average
			End Get
		End Property

		Public ReadOnly Property Scale As ScalarNetworkAnalyzerScaleSection
			Get
				Return Me._Scale
			End Get
		End Property

		Public ReadOnly Property Calibration As ScalarNetworkAnalyzerCalibrationSection
			Get
				Return Me._Calibration
			End Get
		End Property

		Public ReadOnly Property Reference As ScalarNetworkAnalyzerReferenceSection
			Get
				Return Me._Reference
			End Get
		End Property

		Public ReadOnly Property Channel As ScalarNetworkAnalyzerChannelSection
			Get
				Return Me._Channel
			End Get
		End Property

		Public Sub New(ByRef MainScalarNetworkAnalyzer As ScalarNetworkAnalyzer)
			Me._MainScalarNetworkAnalyzer = MainScalarNetworkAnalyzer
			Me._Display = New ScalarNetworkAnalyzerDisplaySection(Me._MainScalarNetworkAnalyzer)
			Me._Cursor = New ScalarNetworkAnalyzerCursorSection(Me._MainScalarNetworkAnalyzer)
			Me._Measurement = New ScalarNetworkAnalyzerMeasurementSection(Me._MainScalarNetworkAnalyzer)
			Me._Average = New ScalarNetworkAnalyzerAverageSection(Me._MainScalarNetworkAnalyzer)
			Me._Scale = New ScalarNetworkAnalyzerScaleSection(Me._MainScalarNetworkAnalyzer)
			Me._Calibration = New ScalarNetworkAnalyzerCalibrationSection(Me._MainScalarNetworkAnalyzer)
			Me._Reference = New ScalarNetworkAnalyzerReferenceSection(Me._MainScalarNetworkAnalyzer)
			Me._Channel = New ScalarNetworkAnalyzerChannelSection(Me._MainScalarNetworkAnalyzer)
		End Sub

	End Class

