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



    Public Class MeasuringReceiverDetectorSection

        Protected _MainMeasuringReceiver As MeasuringReceiver
		Protected _Mode As MeasuringReceiverDetectorEnum

		Public Property Mode As MeasuringReceiverDetectorEnum
			Get
				Return Me._Mode
			End Get
			Set
				Me._Mode = Value
				Select Value
					Case MeasuringReceiverDetectorEnum.FourHundredkHzDistortion
						Me._MainMeasuringReceiver.Write(Me._MainMeasuringReceiver.Commands.Distortion400Hz)
					Case MeasuringReceiverDetectorEnum.OnekHzDistortion
						Me._MainMeasuringReceiver.Write(Me._MainMeasuringReceiver.Commands.Distortion1KHz)
					Case MeasuringReceiverDetectorEnum.PeakHold
						Me._MainMeasuringReceiver.Write(Me._MainMeasuringReceiver.Commands.PeakHold)
					Case MeasuringReceiverDetectorEnum.PeakNegative
						Me._MainMeasuringReceiver.Write(Me._MainMeasuringReceiver.Commands.NegativePeak)
					Case MeasuringReceiverDetectorEnum.PeakPositive
						Me._MainMeasuringReceiver.Write(Me._MainMeasuringReceiver.Commands.PositivePeak)
					Case MeasuringReceiverDetectorEnum.PeakPositiveAndNegativeDividedBy2
						Me._MainMeasuringReceiver.Write(Me._MainMeasuringReceiver.Commands.PositiveAndNegativePeakDividedBy2)
					Case MeasuringReceiverDetectorEnum.RMS
						Me._MainMeasuringReceiver.Write(Me._MainMeasuringReceiver.Commands.RMS)
					Case MeasuringReceiverDetectorEnum.RMSCalibratedAverage
						Me._MainMeasuringReceiver.Write(Me._MainMeasuringReceiver.Commands.RMSCalibratedAverage)
				End Select
			End Set
		End Property

        Public Sub New(ByRef MainMeasuringReceiver As MeasuringReceiver)
            Me._MainMeasuringReceiver = MainMeasuringReceiver
        End Sub

    End Class


