'
' Created by SharpDevelop.
' User: rspage
' Date: 6/16/2005
' Time: 10:12 AM
'

Imports System
Imports Microsoft.VisualBasic.ControlChars
Imports NationalInstruments.NI4882
Imports FreeCal.Instruments
Imports FreeCal.Common
Imports System.Windows.Forms
Imports System.Threading
Imports Microsoft.VisualBasic
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
    Public Class PowerMeterMeasurementsSection

		Protected _MainPowerMeter As PowerMeter

        Public Sub New(ByRef MainPowerMeter As PowerMeter)
            Me._MainPowerMeter = MainPowerMeter
        End Sub

		Public Function Measure(ByVal channel As String) As Double
			Select channel
				Case "A"
					Me._MainPowerMeter.Write(Me._MainPowerMeter.Commands.MeasureChannelA)
				Case "B"
					Me._MainPowerMeter.Write(Me._MainPowerMeter.Commands.MeasureChannelB)
			End Select
			Return Me._MainPowerMeter.ReadDouble
		End Function

		Public Function GetAveragedMeasurement(ByVal numberOfAverages As Integer, ByVal channel As string) As Double
			Dim Measurements(NumberOfAverages - 1) As Double
			For Measurement As Integer = 0 To NumberOfAverages - 1
				If Channel = "A" Then
					Measurements(Measurement) = Me.Measure("A")
				ElseIf Channel = "B" Then
					Measurements(Measurement) = Me.Measure("B")
				End If
			Next
			Dim Total As Double = 0
			For Each Measurement As Double In Measurements
				Total += Measurement
			Next
			Return (Total / NumberOfAverages)
		End Function

    End Class










