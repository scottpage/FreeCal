'
' Created by SharpDevelop.
' User: rspage
' Date: 7/1/2005
' Time: 8:03 AM
' 

Imports System.Collections
Imports System.Data
Imports System.IO
Imports System.Threading
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.ControlChars

Public Class Gigatronics8542C
    Inherits FreeCal.Instruments.PowerMeters.PowerMeter

    Public dtBytes As DataTable
    Public dtCalibrationFactors As DataTable
    Public PowerSensorModelNumber As String
    Public PowerSensorSerialNumber As String
    Public EEPROMData As New List(Of Byte)
    Public EEPROMDataHasBeenDownloaded As Boolean = False

    Public Sub New(ByVal boardAddress As Integer, ByVal primaryAddress As Byte, ByVal getSettingsFromInstrument As Boolean, Optional ByVal simulate As Boolean = False)
        MyBase.New(boardAddress, primaryAddress, getSettingsFromInstrument, simulate)
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
        Me._Commands.ZeroAndCalibrateChannelA = "AE CL 100 EN;"
        Me._Commands.ZeroAndCalibrateChannelB = "BE CL 100 EN;"
        Me._Commands.ZeroChannelA = "AE ZE;"
        Me._Commands.ZeroChannelB = "BE ZE;"
        Me._Commands.GetChannelAZeroStatus = "CAL1:ZERO:AUTO?"
        Me._Commands.GetChannelBZeroStatus = "CAL2:ZERO:AUTO?"
        Me._Commands.SetFrequency = "SENS:FREQ:CW "
        Me._Commands.MeasureChannelA = "MEAS1?"
        Me._Commands.MeasureChannelB = "MEAS2?"
    End Sub

    Protected Friend Shadows Sub Zero(ByVal channel As String, Optional ByVal showPrompts As Boolean = True)
        Dim OriginalIOTimeout As TimeoutValue = Me.IOTimeout
        Me.IOTimeout = TimeoutValue.T100s
        If showPrompts Then
            If MessageBox.Show("Do you want to zero the Power Sensor connected to Channel " & channel.ToString & "?", "Sensor Calibration", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Select Case channel
                    Case "A"
                        Me.Write(Me.Commands.ZeroChannelA)
                            'Me.Write(Me.Commands.GetChannelAZeroStatus)
                    Case "B"
                        Me.Write(Me.Commands.ZeroChannelB)
                        'Me.Write(Me.Commands.GetChannelBZeroStatus)
                End Select
                'TempReading = Me.ReadString
                Thread.Sleep(20000)
            End If
        Else
            Select Case channel
                Case "A"
                    Me.Write(Me.Commands.ZeroChannelA)
                        'Me.Write(Me.Commands.GetChannelAZeroStatus)
                Case "B"
                    Me.Write(Me.Commands.ZeroChannelB)
                    'Me.Write(Me.Commands.GetChannelBZeroStatus)
            End Select
            'TempReading = Me.ReadString
            Thread.Sleep(20000)
        End If
        Me.IOTimeout = OriginalIOTimeout
    End Sub

    Protected Friend Overrides Sub ZeroAndCalibrate(ByVal channel As String)
        If MessageBox.Show("Do you want to Zero and Calibrate the Power Sensor connected to Channel " & channel.ToString & "?", "Sensor Calibration", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Dim OriginalIOTimeout As TimeoutValue = Me.IOTimeout
            Me.IOTimeout = TimeoutValue.T100s
            Select Case channel
                Case "A"
                    MessageBox.Show("Connect a Power Sensor to the Power Meter Channel A and to the POWER REF connector.")
                    Me.Write(Me.Commands.ZeroAndCalibrateChannelA)
                Case "B"
                    MessageBox.Show("Connect a Power Sensor to the Power Meter Channel B and to the POWER REF connector.")
                    Me.Write(Me.Commands.ZeroAndCalibrateChannelB)
            End Select
            Dim PowerMeterZeroCalResult As String = Me.ReadString
            Me.IOTimeout = OriginalIOTimeout
        End If
    End Sub

    Public Sub DownloadPowerSensorEEPROM()
        Me.dtCalibrationFactors = New DataTable("Calibration Factors")
        Me.dtBytes = New DataTable("Bytes")
        Me.dtBytes.Columns.Add(New DataColumn("Memory Location"))
        Me.dtBytes.Columns.Add(New DataColumn("Byte Value"))
        Dim GPIB0 As Board = Nothing
        Me.EEPROMData.Clear()

        Try
            GPIB0 = New Board(0)
            GPIB0.SendInterfaceClear()
            GPIB0.AcquireInterfaceLock(10000)
            Me.Write("SERV:SENS:TYPE?")
            Dim Model() As String = Me.ReadString.Split(","c)
            Me.Write("SERV:SENS:SNUM?")
            Me.PowerSensorSerialNumber = Me.ReadString.Replace(NewLine, "").Trim
            Me.Write("INIT:CONT OFF")
            Me.PowerSensorModelNumber = Model(0)
            If Model(0) = "E4413A" Then
                Me.dtBytes.Rows.Clear()
                Me.dtCalibrationFactors.Clear()
                Me.dtCalibrationFactors.Columns.Clear()
                Me.dtCalibrationFactors.Columns.Add(New DataColumn("Point Number"))
                Me.dtCalibrationFactors.Columns.Add(New DataColumn("Memory Location"))
                Me.dtCalibrationFactors.Columns.Add(New DataColumn("Frequency (MHz)"))
                Me.dtCalibrationFactors.Columns.Add(New DataColumn("Low CF"))
                Me.dtCalibrationFactors.Columns.Add(New DataColumn("High CF"))
                Me.Write("SERV:SENS:CALF?")
                Me.EEPROMData.AddRange(Me.ReadByteArray)
                For I As Integer = 0 To Me.EEPROMData.Count - 1
                    Dim NewDR As DataRow = Me.dtBytes.NewRow
                    NewDR(0) = I
                    NewDR(1) = EEPROMData(I)
                    Me.dtBytes.Rows.Add(NewDR)
                Next
                Dim NumberOfPointsArray(1) As Byte
                NumberOfPointsArray(1) = EEPROMData(4)
                NumberOfPointsArray(0) = EEPROMData(5)
                Dim MemoryLoc As Integer = 14
                For I As Integer = 1 To CInt((Me.EEPROMData.Count - 13) / 8)
                    Dim NewDR As DataRow = Me.dtCalibrationFactors.NewRow
                    NewDR(0) = I
                    NewDR(1) = MemoryLoc
                    Dim Bytes() As Byte = {EEPROMData(MemoryLoc + 3), EEPROMData(MemoryLoc + 2), EEPROMData(MemoryLoc + 1), EEPROMData(MemoryLoc)}
                    NewDR(2) = (BitConverter.ToInt32(Bytes, 0) / 1000)
                    Dim Bytes2() As Byte = {EEPROMData(MemoryLoc + 5), EEPROMData(MemoryLoc + 4)}
                    NewDR(3) = String.Format("{0:#.00}", 100 * (BitConverter.ToInt16(Bytes2, 0)) / 2 ^ 14)
                    Bytes2(0) = EEPROMData(MemoryLoc + 7)
                    Bytes2(1) = EEPROMData(MemoryLoc + 6)
                    NewDR(4) = String.Format("{0:#.00}", 100 * (BitConverter.ToInt16(Bytes2, 0)) / 2 ^ 14)
                    Me.dtCalibrationFactors.Rows.Add(NewDR)
                    MemoryLoc = MemoryLoc + 8
                Next
                Me.dtCalibrationFactors.Columns(0).ReadOnly = True
                Me.dtCalibrationFactors.Columns(1).ReadOnly = True
                Me.dtCalibrationFactors.Columns(2).ReadOnly = True
            ElseIf Model(0) = "E9300A" Then
                Me.dtBytes.Rows.Clear()
                Me.dtCalibrationFactors.Clear()
                Me.dtCalibrationFactors.Columns.Clear()
                Me.dtCalibrationFactors.Columns.Add(New DataColumn("Point Number"))
                Me.dtCalibrationFactors.Columns.Add(New DataColumn("CW Memory Location"))
                Me.dtCalibrationFactors.Columns.Add(New DataColumn("Frequency (MHz)"))
                Me.dtCalibrationFactors.Columns.Add(New DataColumn("CW - Low CF"))
                Me.dtCalibrationFactors.Columns.Add(New DataColumn("CW - High CF"))
                Me.dtCalibrationFactors.Columns.Add(New DataColumn("Peak Memory Location"))
                Me.dtCalibrationFactors.Columns.Add(New DataColumn("Peak - Low CF"))
                Me.dtCalibrationFactors.Columns.Add(New DataColumn("Peak - High CF"))
                Me.Write("SERV:SENS:CALF?")
                Me.EEPROMData.AddRange(Me.ReadByteArray)
                For I As Integer = 0 To Me.EEPROMData.Count - 1
                    Dim NewDR As DataRow = Me.dtBytes.NewRow
                    NewDR(0) = I
                    NewDR(1) = EEPROMData(I)
                    Me.dtBytes.Rows.Add(NewDR)
                Next
                Dim NumberOfPointsArray(1) As Byte
                NumberOfPointsArray(1) = EEPROMData(4)
                NumberOfPointsArray(0) = EEPROMData(5)
                Dim MemoryLoc As Integer = 15
                For I As Integer = 1 To 32
                    Dim NewDR As DataRow = Me.dtCalibrationFactors.NewRow
                    NewDR(0) = I
                    NewDR(1) = MemoryLoc
                    Dim Bytes() As Byte = {EEPROMData(MemoryLoc + 3), EEPROMData(MemoryLoc + 2), EEPROMData(MemoryLoc + 1), EEPROMData(MemoryLoc)}
                    NewDR(2) = (BitConverter.ToInt32(Bytes, 0) / 1000)
                    Dim Bytes2() As Byte = {EEPROMData(MemoryLoc + 5), EEPROMData(MemoryLoc + 4)}
                    NewDR(3) = String.Format("{0:#.00}", 100 * (BitConverter.ToInt16(Bytes2, 0)) / 2 ^ 14)
                    Bytes2(0) = EEPROMData(MemoryLoc + 7)
                    Bytes2(1) = EEPROMData(MemoryLoc + 6)
                    NewDR(4) = String.Format("{0:#.00}", 100 * (BitConverter.ToInt16(Bytes2, 0)) / 2 ^ 14)
                    Me.dtCalibrationFactors.Rows.Add(NewDR)
                    MemoryLoc = MemoryLoc + 8
                Next
                MemoryLoc = 275
                For I As Integer = 0 To 31
                    Me.dtCalibrationFactors.Rows(I)(5) = MemoryLoc
                    Dim Bytes2() As Byte = {EEPROMData(MemoryLoc + 5), EEPROMData(MemoryLoc + 4)}
                    Me.dtCalibrationFactors.Rows(I)(6) = String.Format("{0:#.00}", 100 * (BitConverter.ToInt16(Bytes2, 0)) / 2 ^ 14)
                    Bytes2(0) = EEPROMData(MemoryLoc + 7)
                    Bytes2(1) = EEPROMData(MemoryLoc + 6)
                    Me.dtCalibrationFactors.Rows(I)(7) = String.Format("{0:#.00}", 100 * (BitConverter.ToInt16(Bytes2, 0)) / 2 ^ 14)
                    MemoryLoc = MemoryLoc + 8
                Next
                Me.dtCalibrationFactors.Columns(5).ReadOnly = True
            End If
            Me.dtCalibrationFactors.Columns(0).ReadOnly = True
            Me.dtCalibrationFactors.Columns(1).ReadOnly = True
            Me.dtCalibrationFactors.Columns(2).ReadOnly = True
            Dim FS As FileStream = File.Open(Me.SerialNumber & ".txt", FileMode.OpenOrCreate)
            FS.SetLength(0)
            Dim SW As New StreamWriter(FS)
            For Each DR As DataRow In Me.dtBytes.Rows
                SW.WriteLine(DR(0).ToString & "," & DR(1).ToString)
            Next
            SW.Close()
            Me.EEPROMDataHasBeenDownloaded = True
        Catch Ex As Exception
            MessageBox.Show(Ex.ToString)
        Finally
            If Not (GPIB0 Is Nothing) Then
                GPIB0.Dispose()
            End If
        End Try
    End Sub

    Public Sub UploadPowerSensorEEPROM()
        If Me.EEPROMDataHasBeenDownloaded Then
            Dim GPIB0 As Board = Nothing
            Try
                GPIB0 = New Board(0)
                GPIB0.SendInterfaceClear()
                GPIB0.AcquireInterfaceLock(10000)
                If Me.PowerSensorModelNumber = "E4413A" Then
                    Me.Write("INIT:CONT OFF")
                    Dim Data As New List(Of Byte)
                    Dim T As String = String.Empty
                    For RowNumber As Integer = 0 To 38
                        Dim ConvertedFrequencyValue As Int32 = Convert.ToInt32(Me.dtCalibrationFactors.Rows(RowNumber)(2)) * 1000
                        Dim TempData() As Byte = BitConverter.GetBytes(ConvertedFrequencyValue)
                        For I As Integer = 3 To 0 Step -1
                            Data.Add(TempData(I))
                        Next
                        Dim ConvertedCalFactorValue As Integer = Convert.ToInt32(2 ^ 14 * Convert.ToInt32(Me.dtCalibrationFactors.Rows(RowNumber)(3)) / 100)
                        TempData = BitConverter.GetBytes(ConvertedCalFactorValue)
                        For I As Integer = 1 To 0 Step -1
                            Data.Add(TempData(I))
                        Next
                        ConvertedCalFactorValue = Convert.ToInt32(2 ^ 14 * Convert.ToInt32(Me.dtCalibrationFactors.Rows(RowNumber)(4)) / 100)
                        TempData = BitConverter.GetBytes(ConvertedCalFactorValue)
                        For I As Integer = 1 To 0 Step -1
                            Data.Add(TempData(I))
                        Next
                    Next
                    Dim MemLoc As Integer = 569
                    For Each V As String In Data
                        T = T & MemLoc & " " & V & NewLine
                        MemLoc += 1
                    Next
                    Dim FS As FileStream = File.Open(Path.Combine(Common.EEPROMDataDirectory, "Sensor Data2\Sensor Data\test.txt"), FileMode.OpenOrCreate)
                    Dim SW As New StreamWriter(FS)
                    SW.Write(T)
                    SW.Close()
                    Dim DataPoint As Integer = 0
                    For MemoryLocation As Integer = 569 To 880
                        Me.Write("DIAG:DET:EEPR " & MemoryLocation & "," & Data(DataPoint))
                        DataPoint += 1
                    Next
                ElseIf Me.PowerSensorModelNumber = "E9300A" Then
                    MessageBox.Show("I have not completed the code for the E9300A upload yet, Sorry.")
                End If
            Catch Ex As Exception
                MessageBox.Show(Ex.ToString)
            Finally
                If Not (GPIB0 Is Nothing) Then
                    GPIB0.Dispose()
                End If
            End Try
        End If
    End Sub

End Class


