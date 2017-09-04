'
' Created by SharpDevelop.
' User: Administrator
' Date: 6/14/2005
' Time: 5:12 PM
' 

Imports System
Imports Microsoft.VisualBasic.ControlChars
Imports NationalInstruments.NI4882
Imports FreeCal.Instruments
Imports FreeCal.Common



    Public Class MeasuringReceiverMeasurementsSection

        Protected _MainMeasuringReceiver As MeasuringReceiver
        Protected _CurrentMeasurement As MeasuringReceiverMeasurementsEnum
		Protected _FrequencyOffsetMode As MeasuringReceiverFrequencyOffsetModeSection

		Public ReadOnly Property FrequencyOffsetMode As MeasuringReceiverFrequencyOffsetModeSection
			Get
				Return Me._FrequencyOffsetMode
			End Get
		End Property

        Public Property CurrentMeasurement As MeasuringReceiverMeasurementsEnum
            Get
                Return Me._CurrentMeasurement
            End Get
            Set
                Me._CurrentMeasurement = Value
                Select Value
                    Case MeasuringReceiverMeasurementsEnum.AM
                        Me._MainMeasuringReceiver.Write(Me._MainMeasuringReceiver.Commands.MeasureAM)
                    Case MeasuringReceiverMeasurementsEnum.AudioDistortion
                        Me._MainMeasuringReceiver.Write(Me._MainMeasuringReceiver.Commands.MeasureAudioDistortion)
                    Case MeasuringReceiverMeasurementsEnum.AudioFrequency
                        Me._MainMeasuringReceiver.Write(Me._MainMeasuringReceiver.Commands.MeasureAudioFrequency)
                    Case MeasuringReceiverMeasurementsEnum.FM
                        Me._MainMeasuringReceiver.Write(Me._MainMeasuringReceiver.Commands.MeasureFM)
                    Case MeasuringReceiverMeasurementsEnum.Frequency
                        Me._MainMeasuringReceiver.Write(Me._MainMeasuringReceiver.Commands.MeasureFrequency)
                    Case MeasuringReceiverMeasurementsEnum.IFLevel
                        Me._MainMeasuringReceiver.Write(Me._MainMeasuringReceiver.Commands.MeasureIFLevel)
                    Case MeasuringReceiverMeasurementsEnum.PM
                        Me._MainMeasuringReceiver.Write(Me._MainMeasuringReceiver.Commands.MeasurePM)
                    Case MeasuringReceiverMeasurementsEnum.RFPower
                        Me._MainMeasuringReceiver.Write(Me._MainMeasuringReceiver.Commands.MeasureRFPower)
                    Case MeasuringReceiverMeasurementsEnum.TunedRFLevel
                        Me._MainMeasuringReceiver.Write(Me._MainMeasuringReceiver.Commands.MeasureTunedRFLevel)
                End Select
            End Set
        End Property

        Public Sub AM
            Me._MainMeasuringReceiver.Write(Me._MainMeasuringReceiver.Commands.MeasureAM)
            Me._CurrentMeasurement = MeasuringReceiverMeasurementsEnum.AM
        End Sub

        Public Sub AudioDistortion
            Me._MainMeasuringReceiver.Write(Me._MainMeasuringReceiver.Commands.MeasureAudioDistortion)
            Me._CurrentMeasurement = MeasuringReceiverMeasurementsEnum.AudioDistortion
        End Sub

        Public Sub AudioFrequency
            Me._MainMeasuringReceiver.Write(Me._MainMeasuringReceiver.Commands.MeasureAudioFrequency)
            Me._CurrentMeasurement = MeasuringReceiverMeasurementsEnum.AudioFrequency
        End Sub

        Public Sub FM
            Me._MainMeasuringReceiver.Write(Me._MainMeasuringReceiver.Commands.MeasureFM)
            Me._CurrentMeasurement = MeasuringReceiverMeasurementsEnum.FM
        End Sub

        Public Sub Frequency
            Me._MainMeasuringReceiver.Write(Me._MainMeasuringReceiver.Commands.MeasureFrequency)
            Me._CurrentMeasurement = MeasuringReceiverMeasurementsEnum.Frequency
        End Sub

        Public Sub IFLevel
            Me._MainMeasuringReceiver.Write(Me._MainMeasuringReceiver.Commands.MeasureIFLevel)
            Me._CurrentMeasurement = MeasuringReceiverMeasurementsEnum.IFLevel
        End Sub

        Public Sub PM
            Me._MainMeasuringReceiver.Write(Me._MainMeasuringReceiver.Commands.MeasurePM)
            Me._CurrentMeasurement = MeasuringReceiverMeasurementsEnum.PM
        End Sub

        Public Sub RFPower
            Me._MainMeasuringReceiver.Write(Me._MainMeasuringReceiver.Commands.MeasureRFPower)
            Me._CurrentMeasurement = MeasuringReceiverMeasurementsEnum.RFPower
        End Sub

        Public Sub TunedRFLevel
            Me._MainMeasuringReceiver.Write(Me._MainMeasuringReceiver.Commands.MeasureTunedRFLevel)
            Me._CurrentMeasurement = MeasuringReceiverMeasurementsEnum.TunedRFLevel
        End Sub

		Public Function GetRoundedTunedRFAmplitude(ByVal minimumAmplitude As Double) As Double
			If (MinimumAmplitude <= 0 And MinimumAmplitude >= -10) Then
				Return -10
			ElseIf (MinimumAmplitude <= -10 And MinimumAmplitude >= -20) Then
				Return -20
			ElseIf (MinimumAmplitude <= -20 And MinimumAmplitude >= -30) Then
				Return -30
			ElseIf (MinimumAmplitude <= -30 And MinimumAmplitude >= -40) Then
				Return -40
			ElseIf (MinimumAmplitude <= -40 And MinimumAmplitude >= -50) Then
				Return -50
			ElseIf (MinimumAmplitude <= -50 And MinimumAmplitude >= -60) Then
				Return -60
			ElseIf (MinimumAmplitude <= -60 And MinimumAmplitude >= -70) Then
				Return -70
			ElseIf (MinimumAmplitude <= -70 And MinimumAmplitude >= -80) Then
				Return -80
			ElseIf (MinimumAmplitude <= -80 And MinimumAmplitude >= -90) Then
				Return -90
			ElseIf (MinimumAmplitude <= -90 And MinimumAmplitude >= -100) Then
				Return -100
			ElseIf (MinimumAmplitude <= -100 And MinimumAmplitude >= -110) Then
				Return -110
			ElseIf (MinimumAmplitude <= -110 And MinimumAmplitude >= -120) Then
				Return -120
			ElseIf (MinimumAmplitude <= -120 And MinimumAmplitude >= -130) Then
				Return -130
			ElseIf (MinimumAmplitude <= -130 And MinimumAmplitude >= -140) Then
				Return -130
			ElseIf (MinimumAmplitude <= -140 And MinimumAmplitude >= -150) Then
				Return -130
			End If
		End Function

        Public Sub New(ByRef MainMeasuringReceiver As MeasuringReceiver)
            Me._MainMeasuringReceiver = MainMeasuringReceiver
            Me._FrequencyOffsetMode = New MeasuringReceiverFrequencyOffsetModeSection(Me._MainMeasuringReceiver)
        End Sub

    End Class





