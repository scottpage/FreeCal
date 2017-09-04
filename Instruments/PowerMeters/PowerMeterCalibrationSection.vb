'
' Created by SharpDevelop.
' User: Administrator
' Date: 6/15/2005
' Time: 9:34 PM
' 

Imports System
Imports Microsoft.VisualBasic.ControlChars
Imports NationalInstruments.NI4882
Imports FreeCal.Instruments
Imports FreeCal.Common
Imports System.Windows.Forms
Imports System.Threading
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
    Public Class PowerMeterCalibrationSection

		Protected _MainPowerMeter As PowerMeter

        Public Sub New(ByRef MainPowerMeter As PowerMeter)
            Me._MainPowerMeter = MainPowerMeter
        End Sub

		Public Sub Zero
			Me._MainPowerMeter.Zero("A", True)
		End Sub

		Public Sub Zero(ByVal channel As String, ByVal showPrompts As Boolean)
			Me._MainPowerMeter.Zero(channel, showPrompts)
		End Sub

		Public Sub Calibrate(ByVal channel As String, ByVal showPrompts As Boolean)
			Me._MainPowerMeter.Calibrate(channel, showPrompts)
		End Sub

		Public Sub ZeroAndCalibrate
			Me._MainPowerMeter.ZeroAndCalibrate("A")
		End Sub

		Public Sub ZeroAndCalibrate(ByVal channel As String)
			Me._MainPowerMeter.ZeroAndCalibrate(channel)
		End Sub

    End Class







