'
' Created by SharpDevelop.
' User: Administrator
' Date: 7/28/2005
' Time: 8:43 PM
'

Imports System
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Class DigitalMultimeterCalculateSection

		Protected _MainDigitalMultimeter As DigitalMultimeter

		Public Sub New(ByRef mainDigitalMultimeter As DigitalMultimeter)
			Me._MainDigitalMultimeter = mainDigitalMultimeter
		End Sub

	End Class


