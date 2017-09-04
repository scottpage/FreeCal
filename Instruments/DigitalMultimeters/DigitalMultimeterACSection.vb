'
' Created by SharpDevelop.
' User: rspage
' Date: 7/29/2005
' Time: 9:29 AM
' 


Imports System
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Class DigitalMultimeterACSection

		Protected _MainDigitalMultimeter As DigitalMultimeter
		Protected _VoltRange As Double
		Protected _AmpRange As Double
		Protected _Commands As DigitalMultimeterGPIBCommands

		Public Property VoltRange As Double
			Get
				Return Me._VoltRange
			End Get
			Set
				If Not Me._MainDigitalMultimeter.Sections.Configure.Mode = DigitalMultimeterModeEnum.ACVolts Then
					Me._MainDigitalMultimeter.Sections.Configure.Mode = DigitalMultimeterModeEnum.ACVolts
				End If
				Me._VoltRange = Value
				Me.Write(Me._Commands.ACVoltRange & Value)
			End Set
		End Property

		Public Property AmpRange As Double
			Get
				Return Me._AmpRange
			End Get
			Set
				If Not Me._MainDigitalMultimeter.Sections.Configure.Mode = DigitalMultimeterModeEnum.ACCurrent Then
					Me._MainDigitalMultimeter.Sections.Configure.Mode = DigitalMultimeterModeEnum.ACCurrent
				End If
				Me._AmpRange = Value
				Me.Write(Me._Commands.ACAmpRange & Value)
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

