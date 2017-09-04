'
' Created by SharpDevelop.
' User: Administrator
' Date: 6/11/2005
' Time: 10:50 AM
' 

Imports System
Imports Microsoft.VisualBasic.ControlChars
Imports NationalInstruments.NI4882
Imports FreeCal.Instruments
Imports FreeCal.Common



    Public Class AudioAnalyzerMeasurementsSection

        Protected _MainAudioAnalyzer As AudioAnalyzer
        Protected _CurrentMeasurementMode As AudioAnalyzerMeasurementModeEnum

        Public Property CurrentMeasurementMode As AudioAnalyzerMeasurementModeEnum
            Get
                Return Me._CurrentMeasurementMode
            End Get
            Set
                Me._CurrentMeasurementMode = Value
                Select Value
                    Case AudioAnalyzerMeasurementModeEnum.ACLevel
                        Me._MainAudioAnalyzer.Write(Me._MainAudioAnalyzer.Commands.MeasureACLevel)
                    Case AudioAnalyzerMeasurementModeEnum.SINAD
                        Me._MainAudioAnalyzer.Write(Me._MainAudioAnalyzer.Commands.MeasureSINAD)
                    Case AudioAnalyzerMeasurementModeEnum.Distortion
                        Me._MainAudioAnalyzer.Write(Me._MainAudioAnalyzer.Commands.MeasureDistortion)
                    Case AudioAnalyzerMeasurementModeEnum.DCLevel
                        Me._MainAudioAnalyzer.Write(Me._MainAudioAnalyzer.Commands.MeasureDCLevel)
                    Case AudioAnalyzerMeasurementModeEnum.SignalToNoise
                        Me._MainAudioAnalyzer.Write(Me._MainAudioAnalyzer.Commands.MeasureSignalToNoise)
                    Case AudioAnalyzerMeasurementModeEnum.DistortionLevel
                        Me._MainAudioAnalyzer.Write(Me._MainAudioAnalyzer.Commands.MeasureDistortionLevel)
                End Select
            End Set
        End Property

        Public Sub ACLevel
            Me._MainAudioAnalyzer.Write(Me._MainAudioAnalyzer.Commands.MeasureACLevel)
            Me._CurrentMeasurementMode = AudioAnalyzerMeasurementModeEnum.ACLevel
        End Sub

        Public Sub SINAD
            Me._MainAudioAnalyzer.Write(Me._MainAudioAnalyzer.Commands.MeasureSINAD)
            Me._CurrentMeasurementMode = AudioAnalyzerMeasurementModeEnum.SINAD
        End Sub

        Public Sub Distortion
            Me._MainAudioAnalyzer.Write(Me._MainAudioAnalyzer.Commands.MeasureDistortion)
            Me._CurrentMeasurementMode = AudioAnalyzerMeasurementModeEnum.Distortion
        End Sub

        Public Sub DCLevel
            Me._MainAudioAnalyzer.Write(Me._MainAudioAnalyzer.Commands.MeasureDCLevel)
            Me._CurrentMeasurementMode = AudioAnalyzerMeasurementModeEnum.DCLevel
        End Sub

        Public Sub SignalToNoise
            Me._MainAudioAnalyzer.Write(Me._MainAudioAnalyzer.Commands.MeasureSignalToNoise)
            Me._CurrentMeasurementMode = AudioAnalyzerMeasurementModeEnum.SignalToNoise
        End Sub

        Public Sub DistortionLevel
            Me._MainAudioAnalyzer.Write(Me._MainAudioAnalyzer.Commands.MeasureDistortionLevel)
            Me._CurrentMeasurementMode = AudioAnalyzerMeasurementModeEnum.DistortionLevel
        End Sub

        Public Sub New(ByRef MainAudioAnalyzer As AudioAnalyzer)
            Me._MainAudioAnalyzer = MainAudioAnalyzer
        End Sub

    End Class




