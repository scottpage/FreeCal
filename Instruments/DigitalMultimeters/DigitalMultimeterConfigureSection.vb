'
' Created by SharpDevelop.
' User: Administrator
' Date: 7/28/2005
' Time: 8:45 PM
'

Imports System
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Class DigitalMultimeterConfigureSection

		Protected _MainDigitalMultimeter As DigitalMultimeter
		Protected _Mode As DigitalMultimeterModeEnum
		Protected _Commands As DigitalMultimeterGPIBCommands
		Protected _DC As DigitalMultimeterDCSection
		Protected _AC As DigitalMultimeterACSection
		Protected _Measure As DigitalMultimeterMeasureSection

		Public ReadOnly Property Measure As DigitalMultimeterMeasureSection
			Get
				Return Me._Measure
			End Get
		End Property

		Public ReadOnly Property DC As DigitalMultimeterDCSection
			Get
				Return Me._DC
			End Get
		End Property

		Public ReadOnly Property AC As DigitalMultimeterACSection
			Get
				Return Me._AC
			End Get
		End Property

		Public Property Mode As DigitalMultimeterModeEnum
			Get
				Return Me._Mode
			End Get
			Set
				If Not Me._Mode = Value Then
					Me._Mode = Value
					Select Value
						Case DigitalMultimeterModeEnum.ACCurrent
							Me.Write(Me._Commands.ACCurrentMode)
						Case DigitalMultimeterModeEnum.ACVolts
							Me.Write(Me._Commands.ACVoltMode)
						Case DigitalMultimeterModeEnum.DCCurrent
							Me.Write(Me._Commands.DCCurrentMode)
						Case DigitalMultimeterModeEnum.DCVolts
							Me.Write(Me._Commands.DCVoltMode)
						Case DigitalMultimeterModeEnum.FourWireResistance
							Me.Write(Me._Commands.FourWireResistanceMode)
						Case DigitalMultimeterModeEnum.TwoWireResistance
							Me.Write(Me._Commands.TwoWireResistanceMode)
					End Select
				End If
			End Set
		End Property

		Public Sub New(ByRef mainDigitalMultimeter As DigitalMultimeter)
			Me._MainDigitalMultimeter = mainDigitalMultimeter
			Me._Commands = Me._MainDigitalMultimeter.Commands
			Me._AC = New DigitalMultimeterACSection(Me._MainDigitalMultimeter)
			Me._DC = New DigitalMultimeterDCSection(Me._MainDigitalMultimeter)
			Me._Measure = New DigitalMultimeterMeasureSection(Me._MainDigitalMultimeter)
		End Sub

		Private Sub Write(ByVal data As String)
			Me._MainDigitalMultimeter.Write(data)
		End Sub

	End Class

