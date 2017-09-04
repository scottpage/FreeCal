'
' Created by SharpDevelop.
' User: rspage
' Date: 7/29/2005
' Time: 9:28 AM
' 

Imports System
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Class DigitalMultimeterDCSection

		Protected _MainDigitalMultimeter As DigitalMultimeter
		Protected Friend _VoltRange As Double
		Protected Friend _AmpRange As Double
		Protected _Commands As DigitalMultimeterGPIBCommands

		Public Overridable Property VoltRange As Double
			Get
				Return Me._VoltRange
			End Get
			Set
				Me._MainDigitalMultimeter.SetDCVoltageRange(value)
			End Set
		End Property

		Public Property AmpRange As Double
			Get
				Return Me._AmpRange
			End Get
			Set
				If Not Me._MainDigitalMultimeter.Sections.Configure.Mode = DigitalMultimeterModeEnum.DCCurrent Then
					Me._MainDigitalMultimeter.Sections.Configure.Mode = DigitalMultimeterModeEnum.DCCurrent
				End If
				Me._AmpRange = Value
				Me.Write(Me._Commands.DCAmpRange & Value)
			End Set
		End Property

		Public Sub New(ByRef mainDigitalMultimeter As DigitalMultimeter)
			Me._MainDigitalMultimeter = mainDigitalMultimeter
			Me._Commands = Me._MainDigitalMultimeter.Commands
		End Sub

		Private Sub Write(ByVal data As String)
			Me._MainDigitalMultimeter.Write(data)
		End Sub

	End Class



