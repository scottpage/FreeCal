'
' Created by SharpDevelop.
' User: Administrator
' Date: 7/28/2005
' Time: 8:31 PM
'

Imports System
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Class DigitalMultimeterSectionsSection

		Protected _MainDigitalMultimeter As DigitalMultimeter
		Protected _Calculate As DigitalMultimeterCalculateSection
		Protected _Configure As DigitalMultimeterConfigureSection
		Protected _Measure As DigitalMultimeterMeasureSection

		Public ReadOnly Property Calculate As DigitalMultimeterCalculateSection
			Get
				Return Me._Calculate
			End Get
		End Property

		Public ReadOnly Property Configure As DigitalMultimeterConfigureSection
			Get
				Return Me._Configure
			End Get
		End Property

		Public ReadOnly Property Measure As DigitalMultimeterMeasureSection
			Get
				Return Me._Measure
			End Get
		End Property

		Public Sub New(ByRef mainDigitalMultimeter As DigitalMultimeter)
			Me._MainDigitalMultimeter = mainDigitalMultimeter
			Me._Calculate = New DigitalMultimeterCalculateSection(Me._MainDigitalMultimeter)
			Me._Configure = New DigitalMultimeterConfigureSection(Me._MainDigitalMultimeter)
			Me._Measure = New DigitalMultimeterMeasureSection(Me._MainDigitalMultimeter)
		End Sub

	End Class


