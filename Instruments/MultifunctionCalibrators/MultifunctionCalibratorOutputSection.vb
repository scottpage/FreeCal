'
' Created by SharpDevelop.
' User: Administrator
' Date: 7/28/2005
' Time: 8:43 PM
'

Imports System
Imports FreeCal.Common
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Class MultifunctionCalibratorOutputSection

		Public Event OutputStateChanged(ByVal state As OnOffStateEnum)

		Protected _MainMultifunctionCalibrator As MultifunctionCalibrator
		Protected _Commands As MultifunctionCalibratorGPIBCommands
		Protected _State As OnOffStateEnum
		Protected _Volts As Double
		Protected _VoltSuffix As AmplitudeEnum
		Protected _Ohms As Double
		Protected _OhmSuffix As AmplitudeEnum
		Protected _Amps As Double
		Protected _AmpSuffix As AmplitudeEnum
		Protected _Frequency As Double
		Protected _FrequencySuffix As FrequencyEnum

		Public Property FrequencySuffix As FrequencyEnum
			Get
				Return Me._FrequencySuffix
			End Get
			Set
				Me._FrequencySuffix = Value
			End Set
		End Property

		Public Property AmpSuffix As AmplitudeEnum
			Get
				Return Me._AmpSuffix
			End Get
			Set
				Me._AmpSuffix = Value
			End Set
		End Property

		Public Property OhmSuffix As AmplitudeEnum
			Get
				Return Me._OhmSuffix
			End Get
			Set
				Me._OhmSuffix = Value
			End Set
		End Property

		Public Property VoltSuffix As AmplitudeEnum
			Get
				Return Me._VoltSuffix
			End Get
			Set
				Me._VoltSuffix = Value
			End Set
		End Property

		Public Property Volts As Double
			Get
				Return Me._Volts
			End Get
			Set
				Me.ZeroValues
				Me._Volts = Value
				Me.Write(Value & Me._MainMultifunctionCalibrator.GetAmplitudeTerminator(Me._VoltSuffix))
			End Set
		End Property

		Public Property Frequency As Double
			Get
				Return Me._Frequency
			End Get
			Set
				Me.ZeroValues
				Me._Frequency = Value
				Me.Write(Value & Me._MainMultifunctionCalibrator.GetFrequencyTerminator(Me._FrequencySuffix))
			End Set
		End Property

		Public Property Amps As Double
			Get
				Return Me._Amps
			End Get
			Set
				Me.ZeroValues
				Me._Frequency = 0
				Me._Amps = Value
				Me.Write(Value & Me._MainMultifunctionCalibrator.GetAmplitudeTerminator(Me._AmpSuffix))
			End Set
		End Property

		Public Property Ohms As Double
			Get
				Return Me._Ohms
			End Get
			Set
				Me.ZeroValues
				Me._Frequency = 0
				Me._Ohms = Value
				Me.Write(Value & Me._MainMultifunctionCalibrator.GetAmplitudeTerminator(Me._OhmSuffix))
			End Set
		End Property

		Public Property State As OnOffStateEnum
			Get
				Return Me._State
			End Get
			Set
				Select Value
					Case OnOffStateEnum.[On]
						Me.Write(Me._Commands.Operate)
					Case OnOffStateEnum.[Off]
						Me.Write(Me._Commands.StandBy)
				End Select
				RaiseEvent OutputStateChanged(Value)
			End Set
		End Property

		Public Sub ACOff
			Me._MainMultifunctionCalibrator.Write(Me._MainMultifunctionCalibrator.Commands.ACOff)
		End Sub

		Public Sub New(ByRef mainMultifunctionCalibrator As MultifunctionCalibrator)
			Me._MainMultifunctionCalibrator = mainMultifunctionCalibrator
			Me._Commands = Me._MainMultifunctionCalibrator.Commands
		End Sub

		Private Sub ZeroValues
			Me._Volts = 0
			Me._Amps = 0
			Me._Ohms = 0
		End Sub

		Private Sub Write(ByVal data As String)
			Me._MainMultifunctionCalibrator.Write(data)
		End Sub

	End Class


