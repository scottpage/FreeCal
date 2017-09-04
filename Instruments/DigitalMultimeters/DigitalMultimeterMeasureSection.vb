'
' Created by SharpDevelop.
' User: Administrator
' Date: 7/28/2005
' Time: 8:46 PM
'

Imports System
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Class DigitalMultimeterMeasureSection

		Protected _MainDigitalMultimeter As DigitalMultimeter

		Public Function Read As Double
			Me._MainDigitalMultimeter.Write(Me._MainDigitalMultimeter.Commands.Read)
			Return Me._MainDigitalMultimeter.ReadDouble
		End Function

		Public Sub New(ByRef mainDigitalMultimeter As DigitalMultimeter)
			Me._MainDigitalMultimeter = mainDigitalMultimeter
		End Sub

	End Class


