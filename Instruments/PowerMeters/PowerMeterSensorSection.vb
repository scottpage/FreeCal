'
' Created by SharpDevelop.
' User: rspage
' Date: 6/24/2005
' Time: 3:16 PM
' 



Imports System
Imports System.ComponentModel
Imports FreeCal.Common


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Class PowerMeterSensorSection

		Protected _MainPowerMeter As PowerMeter

		Public Sub New(ByRef mainPowerMeter As PowerMeter)
			Me._MainPowerMeter = mainPowerMeter
		End Sub

	End Class

