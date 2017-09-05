'
' Created by SharpDevelop.
' User: rspage
' Date: 7/19/2005
' Time: 2:38 PM
' 

Imports System
Imports FreeCal.Common
Imports System.Windows.Forms
Imports NationalInstruments.NI4882
Imports FreeCal.Instruments
Imports System.Data
Imports System.Collections
Imports System.IO
Imports Microsoft.VisualBasic.ControlChars
Imports System.Threading



Public Class Wavetek8531
    Inherits FreeCal.Instruments.PowerMeters.PowerMeter

    Public dtBytes As DataTable
    Public dtCalibrationFactors As DataTable
    Public PowerSensorModelNumber As String
    Public PowerSensorSerialNumber As String
    Public EEPROMData As New ArrayList
    Public EEPROMDataHasBeenDownloaded As Boolean = False

    Public Sub New(ByVal boardAddress As Integer, ByVal primaryAddress As Byte, ByVal getSettingsFromInstrument As Boolean, Optional ByVal simulate As Boolean = False)
        MyBase.New(boardAddress, primaryAddress, getSettingsFromInstrument, simulate)
        Me._Manufacturer = "Wavetek"
        Me._Model = "8531"
        Me._FrequencySuffix = FrequencyEnum.MHz
        Me._HasInternalSensorCalibrationTables = True
        Me._NumberOfChannels = 2
    End Sub

    Protected Overrides Sub SetupCommandTerminators()
        Me._CommandTerminators.dBm = "dBm"
        Me._CommandTerminators.Hz = "Hz"
        Me._CommandTerminators.kHz = "KHz"
        Me._CommandTerminators.MHz = "MHz"
        Me._CommandTerminators.GHz = "GHz"
    End Sub

    Protected Overrides Sub SetupCommands()
        Me._GeneralCommands.Identify = "*IDN?"
        Me._GeneralCommands.Preset = "*RST;"
        Me._Commands.Measure = "MEAS?"
        Me._Commands.ZeroChannelA = "AZ"
        Me._Commands.Calibrate = "AC"
        Me._Commands.MeasureChannelA = "MEAS1?"
    End Sub

    Public Overloads Overrides Function ReadDouble() As Double
        Dim Reading As String = MyBase.ReadString
        Return CDbl(Reading.Substring(3))
    End Function

    Protected Friend Overrides Sub Zero(ByVal channel As String, Optional ByVal showPrompts As Boolean = True)
        If channel.ToUpper <> "A" Then
            Throw New Exception("The Wavetek 8531 only has 1 channel (A).")
            Return
        End If
        Dim OriginalIOTimeout As TimeoutValue = Me.IOTimeout
        Me.IOTimeout = TimeoutValue.T100s
        If showPrompts Then
            If MessageBox.Show("Do you want to zero the Power Sensor connected to Channel " & channel.ToString & "?", "Sensor Calibration", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Me.Write(Me.Commands.ZeroChannelA)
                Me.Write("SQ4") 'Sets the "On end of GPIB operation SQR mask
                Dim B As New Board(0)
                B.IOTimeout = TimeoutValue.T30s
                B.WaitForSrq()
                B.Dispose()
            End If
        Else
            Me.Write(Me.Commands.ZeroChannelA)
            Me.Write("SQ4") 'Sets the "On end of GPIB operation SQR mask
            Dim B As New Board(0)
            B.IOTimeout = TimeoutValue.T30s
            B.WaitForSrq()
            B.Dispose()
        End If
        Me.Write("SRQ")
        Me.IOTimeout = OriginalIOTimeout
    End Sub

    Protected Friend Overrides Sub ZeroAndCalibrate(ByVal channel As String)
        If channel.ToUpper <> "A" Then
            Throw New Exception("The Wavetek 8531 only has 1 channel (A).")
            Return
        End If
        If MessageBox.Show("Do you want to Zero and Calibrate the Power Sensor connected to Channel " & channel.ToString & "?", "Sensor Calibration", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Dim OriginalIOTimeout As TimeoutValue = Me.IOTimeout
            Me.IOTimeout = TimeoutValue.T100s
            MessageBox.Show("Connect a Power Sensor to the Power Meter Channel A and to the POWER REF connector.")
            Me.Zero("A", False)
            Me.Write(Me.Commands.Calibrate)
            Me.Write("SQ4") 'Sets the "On end of GPIB operation SQR mask
            Dim B As New Board(0)
            B.IOTimeout = TimeoutValue.T30s
            B.WaitForSrq()
            B.Dispose()
            Me.Write("SRQ")
            Me.IOTimeout = OriginalIOTimeout
        End If
    End Sub

End Class




