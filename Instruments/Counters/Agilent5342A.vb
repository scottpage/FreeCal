'
' Created by SharpDevelop.
' User: rspage
' Date: 6/21/2005
' Time: 6:52 AM
' 

Imports System
Imports System.Windows.Forms
Imports FreeCal.Common
Imports FreeCal.Instruments
Imports NationalInstruments.NI4882



	Public Class Agilent5342A
        Inherits FreeCal.Instruments.Counters.Counter

    Public Sub New(ByVal boardAddress As Integer, ByVal primaryAddress As Byte, ByVal getSettingsFromInstrument As Boolean, Optional ByVal simulate As Boolean = False)
        MyBase.New(boardAddress, primaryAddress, getSettingsFromInstrument, simulate)
        Me._Manufacturer = "Agilent Technologies"
        Me._Model = "5342A"
    End Sub

    Protected Overrides Sub SetupCommands
            Me._Commands.FrequencyModeAuto = "AU"
            Me._Commands.FrequencyModeManual = "M"
            Me._Commands.ManualCenterFrequency = "SM"
            Me._Commands.AmplitudeMode = "AM"
            Me._Commands.FrequencyOffsetMode = "OM"
            Me._Commands.FrequencyOffset = "SOM"
            Me._Commands.AmplitudeOffset = "SOB"
            Me._Commands.Resolution = "SR"
            Me._Commands.LowRange = "L"
            Me._Commands.HighRange = "H"
            Me._Commands.CWMode = "C"
            Me._Commands.FMMode = "F"
            Me._Commands.TriggerMode = "T"
            Me._Commands.OutputMode = "ST"
            Me._Commands.[Reset] = "R"
            Me._GeneralCommands.Preset = "P"
            Me._Commands.AutomaticFrequencyOffset = "SOMB"
            Me._Commands.AutomaticAmlitudeOffset = "SOBB"
            Me._Commands.CheckMode = "SR1"
            Me._Commands.FastAcquisitionTime = "QS"
            Me._Commands.MediumAcquisitionTime = "QM"
            Me._Commands.SlowAcquisitionTime = "QL"
        End Sub

        Public Overrides Sub SetupInstrument
            Me._CanIdentify = False
            Me._Manufacturer = "Agilent"
            Me._Model = "5342A"
        End Sub

		Protected Overrides Sub SetupCapabilities
			Me._Capabilities.MinimumFrequency = 10
			Me._Capabilities.MinimumFrequencySuffix = FrequencyEnum.Hz
			Me._Capabilities.MaximumFrequency = 18
			Me._Capabilities.MaximumFrequencySuffix = FrequencyEnum.GHz
			Me._Capabilities.NumberOfFrequencyBands = 2
			Me._Capabilities.MinimumRFAmplitude = 25
			Me._Capabilities.MaximumRFAmplitude = -31
			Me._Capabilities.RFAmplitudeSuffix = AmplitudeEnum.dBm
			Me._Capabilities.ReferenceOscillatorFrequency = 10
			Me._Capabilities.ReferenceOscillatorFrequencySuffix = FrequencyEnum.MHz
		End Sub

		Protected Overrides Sub SetupTestPoints
			Dim LowRangeTestFrequenciesList() As Double = {0.00001, 0.0001, 0.001, 0.01, 0.1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 100, 250, 350, 450, 520}
			Me._TestPoints.LowRangeTestFrequencies = LowRangeTestFrequenciesList
			Dim HighRangeTestFrequenciesList() As Double = {500, 1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000, 11000, 12000, 13000, 14000, 15000, 16000, 17000, 18000}
			Me._TestPoints.HighRangeTestFrequencies = HighRangeTestFrequenciesList
		End Sub

		Protected Overrides Sub SetupSpecifications
			Me._Specifications.ReferenceOscillatorFrequencyTolerance = 0.000001
		End Sub

		Public Function GetIdentity(ByVal storeResult As Boolean) As String
		    If StoreResult Then
    		    Me._FullIdentity = "The Agilent 5343 does not responsed to identify commands"
    		    Return Me.FullIdentity
    		Else
    		    Return "The Agilent 5343 does not responsed to identify commands"
    		End If
		End Function

	End Class




