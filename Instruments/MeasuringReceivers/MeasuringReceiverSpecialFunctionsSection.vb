'
' Created by SharpDevelop.
' User: Administrator
' Date: 6/14/2005
' Time: 5:34 PM
' 

Imports System
Imports Microsoft.VisualBasic.ControlChars
Imports NationalInstruments.NI4882
Imports FreeCal.Instruments
Imports FreeCal.Common



    Public Class MeasuringReceiverSpecialFunctionsSection

        Protected _MainMeasuringReceiver As MeasuringReceiver
        Protected _CurrentMeasurement As MeasuringReceiverMeasurementsEnum

        Public Sub New(ByRef MainMeasuringReceiver As MeasuringReceiver)
            Me._MainMeasuringReceiver = MainMeasuringReceiver
        End Sub

    End Class


