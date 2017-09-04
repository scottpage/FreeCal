'
' Created by SharpDevelop.
' User: Administrator
' Date: 6/14/2005
' Time: 5:51 PM
' 

Imports System
Imports Microsoft.VisualBasic.ControlChars
Imports NationalInstruments.NI4882
Imports FreeCal.Instruments
Imports FreeCal.Common
Imports FreeCal.Instruments.SignalGenerators



    Public Class MeasuringReceiverFrequencyOffsetModeSection

		Protected _MainMeasuringReceiver As MeasuringReceiver
		Protected _LocalOscillatorSignalGenerator As SignalGenerator
		Protected _LocalOscillatorSignalGeneratorAddress As Byte = CByte(29)
		Protected _FrequencyOffsetModeEnabled As Boolean = False
		Protected _FrequencyOffsetMode As MeasuringReceiverFrequencyOffsetControlEnum
		Protected _LocalOscillatorSignalGeneratorModel As SignalGeneratorEnum = SignalGeneratorEnum.Agilent8340A

		Public Property LocalOscillatorSignalGeneratorModel As SignalGeneratorEnum
			Get
				Return Me._LocalOscillatorSignalGeneratorModel
			End Get
			Set
				Me._LocalOscillatorSignalGeneratorModel = Value
			End Set
		End Property

		Public WriteOnly Property LocalOscillatorSignalGenerator As SignalGenerator
			Set
				Me._LocalOscillatorSignalGenerator = Value
				Me._LocalOscillatorSignalGeneratorAddress = _LocalOscillatorSignalGenerator.PrimaryAddress
			End Set
		End Property

		Public ReadOnly Property FrequencyOffsetModeEnabled As Boolean
			Get
				Return Me._FrequencyOffsetModeEnabled
			End Get
		End Property

		Public Property LocalOscillatorSignalGeneratorAddress As Byte
			Get
				Return Me._LocalOscillatorSignalGeneratorAddress
			End Get
			Set
				Me._LocalOscillatorSignalGeneratorAddress = Value
			End Set
		End Property

		Public Sub Preset
			Me._FrequencyOffsetModeEnabled = False
		End Sub

		Private Sub EnableFrequencyOffsetMode
			Me._LocalOscillatorSignalGenerator = GetNewSignalGenerator(Me._LocalOscillatorSignalGeneratorModel, Me._MainMeasuringReceiver.BoardAddress, Me._LocalOscillatorSignalGeneratorAddress, False)
			Me._LocalOscillatorSignalGenerator.Preset
			Me._LocalOscillatorSignalGenerator.Sections.RF.Frequency.Suffix = FrequencyEnum.MHz
			Me._LocalOscillatorSignalGenerator.Sections.RF.Amplitude.Level = 8
			Me._FrequencyOffsetModeEnabled = True
		End Sub

		Public Sub SetupTunedRFLevelFrequencyOffsetMode(ByVal frequencySetting As Double, ByVal frequencySettingSuffix As FrequencyEnum)
			Dim ConvertedFrequency As Double = Me._MainMeasuringReceiver.ConvertFrequency(FrequencySetting, FrequencySettingSuffix, FrequencyEnum.MHz)
			If Not Me._FrequencyOffsetModeEnabled Then Me.EnableFrequencyOffsetMode
			Me._LocalOscillatorSignalGenerator.Sections.RF.Frequency.CW = ConvertedFrequency + 120.5
			Me._MainMeasuringReceiver.Preset
			Me._MainMeasuringReceiver.Write("27.3SP")
			Me._MainMeasuringReceiver.Write(ConvertedFrequency + 120.5 & Me._MainMeasuringReceiver.Commands.InputFrequencyMHz)
        Dim TempReading As Double = Me._MainMeasuringReceiver.Sections.Triggers.TriggerWithSettlingAndReadSingle
        Me._MainMeasuringReceiver.Write(Me._MainMeasuringReceiver.Commands.InputFrequencyMHz)
			TempReading = Me._MainMeasuringReceiver.Sections.Triggers.TriggerWithSettlingAndReadSingle
			Me._MainMeasuringReceiver.Write(Me._MainMeasuringReceiver.Commands.MeasureTunedRFLevel)
			TempReading = Me._MainMeasuringReceiver.Sections.Triggers.TriggerWithSettlingAndReadSingle
		End Sub

        Public Sub New(ByRef MainMeasuringReceiver As MeasuringReceiver)
            Me._MainMeasuringReceiver = MainMeasuringReceiver
        End Sub

	End Class


