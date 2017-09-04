'
' Created by SharpDevelop.
' User: Administrator
' Date: 4/3/2005
' Time: 10:25 PM
' 


Imports System
Imports System.Windows.Forms
Imports FreeCal.Common
Imports FreeCal.Instruments
Imports NationalInstruments.NI4882



	Public Class Agilent5343A
        Inherits FreeCal.Instruments.Counters.Counter

    Public Sub New(ByVal boardAddress As Integer, ByVal primaryAddress As Byte, ByVal getSettingsFromInstrument As Boolean, Optional ByVal simulate As Boolean = False)
        MyBase.New(boardAddress, primaryAddress, getSettingsFromInstrument, simulate)
        Me._Manufacturer = "Agilent Technologies"
        Me._Model = "5343A"
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

        Private Sub SetInstrumentSettings
            Me._CanIdentify = False
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


