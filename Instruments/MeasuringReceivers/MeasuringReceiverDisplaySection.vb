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



    Public Class MeasuringReceiverDisplaySection

        Protected _MainMeasuringReceiver As MeasuringReceiver
		Protected _Scale As MeasuringReceiverDisplayScaleEnum
		Protected _Ratio As Boolean

		Public Property Ratio As Boolean
			Get
				Return Me._Ratio
			End Get
			Set
				Me._Ratio = Value
				If Value Then
					Me._MainMeasuringReceiver.Write(Me._MainMeasuringReceiver.Commands.RatioOn)
				ElseIf (Not Value) Then
					Me._MainMeasuringReceiver.Write(Me._MainMeasuringReceiver.Commands.RatioOff)
				End If
			End Set
		End Property

		Public Property Scale As MeasuringReceiverDisplayScaleEnum
			Get
				Return Me._Scale
			End Get
			Set
				Me._Scale = Value
				If Value = MeasuringReceiverDisplayScaleEnum.Logarithmic Then
					Me._MainMeasuringReceiver.Write(Me._MainMeasuringReceiver.Commands.DisplayLOGResult)
				ElseIf Value = MeasuringReceiverDisplayScaleEnum.Linear Then
					Me._MainMeasuringReceiver.Write(Me._MainMeasuringReceiver.Commands.DisplayLINResult)
				End If
			End Set
		End Property

		Public Sub RatioOn
			Me.Ratio = True
		End Sub

		Public Sub RatioOff
			Me.Ratio = False
		End Sub

		Public Sub Logarithmic
			Me.Scale = MeasuringReceiverDisplayScaleEnum.Logarithmic
		End Sub

		Public Sub Linear
			Me.Scale = MeasuringReceiverDisplayScaleEnum.Linear			
		End Sub

        Public Sub New(ByRef MainMeasuringReceiver As MeasuringReceiver)
            Me._MainMeasuringReceiver = MainMeasuringReceiver
        End Sub

    End Class



