'
' Created by SharpDevelop.
' User: Administrator
' Date: 6/14/2005
' Time: 5:32 PM
' 

Imports System
Imports Microsoft.VisualBasic.ControlChars
Imports NationalInstruments.NI4882
Imports FreeCal.Instruments
Imports FreeCal.Common



    Public Class MeasuringReceiverFilterSection

        Protected _MainMeasuringReceiver As MeasuringReceiver
        Protected _CurrentMeasurement As MeasuringReceiverMeasurementsEnum
		Protected _HighPass As MeasuringReceiverHighPassFilterEnum
		Protected _LowPass As MeasuringReceiverLowPassFilterEnum

		Public Property HighPass As MeasuringReceiverHighPassFilterEnum
			Get
				Return Me._HighPass
			End Get
			Set
				Select Value
					Case MeasuringReceiverHighPassFilterEnum.AllOff
						Me._MainMeasuringReceiver.Write(Me._MainMeasuringReceiver.Commands.AllHighPassFiltersOff)
					Case MeasuringReceiverHighPassFilterEnum.FiftyHz
						Me._MainMeasuringReceiver.Write(Me._MainMeasuringReceiver.Commands.HighPassFilter50Hz)
					Case MeasuringReceiverHighPassFilterEnum.ThreeHundredHz
						Me._MainMeasuringReceiver.Write(Me._MainMeasuringReceiver.Commands.HighPassFilter300Hz)
				End Select
			End Set
		End Property

		Public Property LowPass As MeasuringReceiverLowPassFilterEnum
			Get
				Return Me._LowPass
			End Get
			Set
				Me._LowPass = Value
				Select Value
					Case MeasuringReceiverLowPassFilterEnum.Above20kHz
						Me._MainMeasuringReceiver.Write(Me._MainMeasuringReceiver.Commands.LowPassFilterGreaterThan20kHz)
					Case MeasuringReceiverLowPassFilterEnum.AllOff
						Me._MainMeasuringReceiver.Write(Me._MainMeasuringReceiver.Commands.AllLowPassFiltersOff)
					Case MeasuringReceiverLowPassFilterEnum.FifteenkHz
						Me._MainMeasuringReceiver.Write(Me._MainMeasuringReceiver.Commands.LowPassFilter15kHz)
					Case MeasuringReceiverLowPassFilterEnum.ThreekHz
						Me._MainMeasuringReceiver.Write(Me._MainMeasuringReceiver.Commands.LowPassFilter3kHz)
				End Select
			End Set
		End Property

        Public Sub New(ByRef MainMeasuringReceiver As MeasuringReceiver)
            Me._MainMeasuringReceiver = MainMeasuringReceiver
        End Sub

    End Class



