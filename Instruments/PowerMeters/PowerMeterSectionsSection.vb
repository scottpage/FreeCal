'
' Created by SharpDevelop.
' User: rspage
' Date: 7/11/2005
' Time: 8:41 AM
' 



Imports System
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Class PowerMeterSectionsSection

		Protected _MainPowerMeter As PowerMeter
		Protected _Calibration As PowerMeterCalibrationSection
		Protected _Memory As PowerMeterMemorySection
		Protected _Measurements As PowerMeterMeasurementsSection
		Protected _Sensor As PowerMeterSensorSection

		Public Shadows ReadOnly Property Measurements As PowerMeterMeasurementsSection
			Get
				Return Me._Measurements
			End Get
		End Property

		Public ReadOnly Property Calibration As PowerMeterCalibrationSection
			Get
				Return Me._Calibration
			End Get
		End Property

		Public ReadOnly Property Memory As PowerMeterMemorySection
			Get
				Return Me._Memory
			End Get
		End Property

		Public ReadOnly Property Sensor As PowerMeterSensorSection
			Get
				Return Me._Sensor
			End Get
		End Property

		Public Sub New(ByRef mainPowerMeter As PowerMeter)
			Me._MainPowerMeter = mainPowerMeter
			Me._Calibration = New PowerMeterCalibrationSection(Me._MainPowerMeter)
			Me._Memory = New PowerMeterMemorySection(Me._MainPowerMeter)
			Me._Measurements = New PowerMeterMeasurementsSection(Me._MainPowerMeter)
		End Sub

	End Class

