'
' Created by SharpDevelop.
' User: Administrator
' Date: 7/28/2005
' Time: 8:31 PM
'

Imports System
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Class MultifunctionCalibratorectionsSection

		Protected _MainMultifunctionCalibrator As MultifunctionCalibrator
		Protected _Output As MultifunctionCalibratorOutputSection

		Public ReadOnly Property Output As MultifunctionCalibratorOutputSection
			Get
				Return Me._Output
			End Get
		End Property

		Public Sub New(ByRef mainMultifunctionCalibrator As MultifunctionCalibrator)
			Me._MainMultifunctionCalibrator = mainMultifunctionCalibrator
			Me._Output = New MultifunctionCalibratorOutputSection(Me._MainMultifunctionCalibrator)
		End Sub

	End Class


