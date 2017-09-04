'
' Created by SharpDevelop.
' User: rspage
' Date: 7/11/2005
' Time: 8:25 AM
' 



Imports System



	Public Class MeasuringReceiverSectionsSection

		Protected _MainMeasuringReceiver As MeasuringReceiver
 		Protected _Measurements As MeasuringReceiverMeasurementsSection
 		Protected _Calibration As MeasuringReceiverCalibrationSection
 		Protected _Filters As MeasuringReceiverFilterSection
 		Protected _Display As MeasuringReceiverDisplaySection
 		Protected _Triggers As MeasuringReceiverTriggerSection
 		Protected _Detector As MeasuringReceiverDetectorSection
 		Protected _SpecialFunctions As MeasuringReceiverSpecialFunctionsSection

		Public ReadOnly Property Detector As MeasuringReceiverDetectorSection
			Get
				Return Me._Detector
			End Get
		End Property

		Public ReadOnly Property Triggers As MeasuringReceiverTriggerSection
			Get
				Return Me._Triggers
			End Get
		End Property

		Public ReadOnly Property Measurements As MeasuringReceiverMeasurementsSection
			Get
				Return Me._Measurements
			End Get
		End Property

		Public ReadOnly Property Filters As MeasuringReceiverFilterSection
			Get
				Return Me._Filters
			End Get
		End Property

		Public ReadOnly Property Calibration As MeasuringReceiverCalibrationSection
			Get
				Return Me._Calibration
			End Get
		End Property

		Public ReadOnly Property Display As MeasuringReceiverDisplaySection
			Get
				Return Me._Display
			End Get
		End Property

		Public Sub New(ByRef mainMeasuringReceiver As MeasuringReceiver)
			Me._MainMeasuringReceiver = mainMeasuringReceiver
 			Me._Measurements = New MeasuringReceiverMeasurementsSection(Me._MainMeasuringReceiver)
 			Me._Calibration = New MeasuringReceiverCalibrationSection(Me._MainMeasuringReceiver)
 			Me._Filters = New MeasuringReceiverFilterSection(Me._MainMeasuringReceiver)
 			Me._Display = New MeasuringReceiverDisplaySection(Me._MainMeasuringReceiver)
 			Me._Triggers = New MeasuringReceiverTriggerSection(Me._MainMeasuringReceiver)
 			Me._Detector = New MeasuringReceiverDetectorSection(Me._MainMeasuringReceiver)
 			Me._SpecialFunctions = New MeasuringReceiverSpecialFunctionsSection(Me._MainMeasuringReceiver)
		End Sub

	End Class

