'
' Created by SharpDevelop.
' User: Administrator
' Date: 6/14/2005
' Time: 5:33 PM
' 

Imports System
Imports Microsoft.VisualBasic.ControlChars
Imports NationalInstruments.NI4882
Imports FreeCal.Instruments
Imports FreeCal.Common



    Public Class MeasuringReceiverTriggerSection

        Protected _MainMeasuringReceiver As MeasuringReceiver
        Protected _CurrentMeasurement As MeasuringReceiverMeasurementsEnum

    Public Function TriggerWithSettlingAndReadSingle() As Double
        Dim Reading As Double = 0
        _MainMeasuringReceiver.Write(Me._MainMeasuringReceiver.Commands.TriggerWithSettling)
        Try
            Reading = CDbl(Me._MainMeasuringReceiver.ReadString(15))
        Catch
        End Try
        Return Reading
    End Function

    Public Sub TriggerWithSettling
			Me._MainMeasuringReceiver.Write(Me._MainMeasuringReceiver.Commands.TriggerWithSettling)
		End Sub

		Public Sub Immediate
			Me._MainMeasuringReceiver.Write(Me._MainMeasuringReceiver.Commands.TriggerImmediate)
		End Sub

        Public Sub New(ByRef MainMeasuringReceiver As MeasuringReceiver)
            Me._MainMeasuringReceiver = MainMeasuringReceiver
        End Sub

    End Class


