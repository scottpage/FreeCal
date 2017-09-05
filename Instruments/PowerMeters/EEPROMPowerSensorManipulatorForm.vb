'
' Created by SharpDevelop.
' User: Scott Page
' Date: 5/18/2005
' Time: 5:19 PM
' 

Imports System.Collections
Imports System.Data
Imports System.IO
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.ControlChars

Public Class EEPROMPowerSensorManipluatorForm
    Inherits System.Windows.Forms.Form

    Private dtCalibrationFactors As System.Data.DataTable
    Private CurrentPowerMeter As Device
    Private ModelNumber As String
    Private SerialNumber As String
    Private dtBytes As System.Data.DataTable
    Private Manufacturer As String
    Private WithEvents chkboxAllowUpload As System.Windows.Forms.CheckBox
    Private WithEvents btnUpLoad As System.Windows.Forms.Button
    Private WithEvents lblOptions As System.Windows.Forms.Label
    Private WithEvents btnFindMeters As System.Windows.Forms.Button
    Private WithEvents lblModel As System.Windows.Forms.Label
    Private WithEvents lblNumberOfPoints As System.Windows.Forms.Label
    Private WithEvents dgCalibrationFactors As System.Windows.Forms.DataGrid
    Private WithEvents lblManufacturer As System.Windows.Forms.Label
    Private WithEvents lblSerialNumber As System.Windows.Forms.Label
    Private WithEvents dgBytes As System.Windows.Forms.DataGrid
    Private WithEvents cboPowerMeters As System.Windows.Forms.ComboBox
    Private WithEvents lblCurrentPowerMeter As System.Windows.Forms.Label
    Private WithEvents btnDownload As System.Windows.Forms.Button
    Private EEPROMData As New ArrayList

    Public Shared Sub Main()
        Dim fEEPROMPowerSensorManipluatorForm As New EEPROMPowerSensorManipluatorForm
        fEEPROMPowerSensorManipluatorForm.ShowDialog()
    End Sub

    Public Sub New()
        MyBase.New
        '
        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        '
        Me.InitializeComponent()
        Me.SetupForm()
    End Sub

    Public Sub New(ByVal parent As Form)
        MyBase.New
        '
        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        '
        Me.InitializeComponent()
        Me.MdiParent = parent
        Me.SetupForm()
    End Sub

    Private Sub SetupForm()
        Me.dtCalibrationFactors = New DataTable("Calibration Factors")
        Me.dtBytes = New DataTable("Bytes")
        Me.dtBytes.Columns.Add(New DataColumn("Memory Location"))
        Me.dtBytes.Columns.Add(New DataColumn("Byte Value"))
        Me.dgCalibrationFactors.DataSource = Me.dtCalibrationFactors
        Me.DetectMeters()
    End Sub

#Region " Windows Forms Designer generated code "
    ' This method is required for Windows Forms designer support.
    ' Do not change the method contents inside the source code editor. The Forms designer might
    ' not be able to load this method if it was changed manually.
    Private Sub InitializeComponent()
        Me.btnDownload = New System.Windows.Forms.Button()
        Me.lblCurrentPowerMeter = New System.Windows.Forms.Label()
        Me.cboPowerMeters = New System.Windows.Forms.ComboBox()
        Me.dgBytes = New System.Windows.Forms.DataGrid()
        Me.lblSerialNumber = New System.Windows.Forms.Label()
        Me.lblManufacturer = New System.Windows.Forms.Label()
        Me.dgCalibrationFactors = New System.Windows.Forms.DataGrid()
        Me.lblNumberOfPoints = New System.Windows.Forms.Label()
        Me.lblModel = New System.Windows.Forms.Label()
        Me.btnFindMeters = New System.Windows.Forms.Button()
        Me.lblOptions = New System.Windows.Forms.Label()
        Me.btnUpLoad = New System.Windows.Forms.Button()
        Me.chkboxAllowUpload = New System.Windows.Forms.CheckBox()
        CType(Me.dgBytes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgCalibrationFactors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnDownload
        '
        Me.btnDownload.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDownload.Location = New System.Drawing.Point(1280, 895)
        Me.btnDownload.Name = "btnDownload"
        Me.btnDownload.Size = New System.Drawing.Size(160, 42)
        Me.btnDownload.TabIndex = 1
        Me.btnDownload.Text = "Download"
        '
        'lblCurrentPowerMeter
        '
        Me.lblCurrentPowerMeter.AutoSize = True
        Me.lblCurrentPowerMeter.Location = New System.Drawing.Point(827, 851)
        Me.lblCurrentPowerMeter.Name = "lblCurrentPowerMeter"
        Me.lblCurrentPowerMeter.Size = New System.Drawing.Size(210, 25)
        Me.lblCurrentPowerMeter.TabIndex = 12
        Me.lblCurrentPowerMeter.Text = "Current Power Meter"
        '
        'cboPowerMeters
        '
        Me.cboPowerMeters.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cboPowerMeters.Location = New System.Drawing.Point(704, 895)
        Me.cboPowerMeters.Name = "cboPowerMeters"
        Me.cboPowerMeters.Size = New System.Drawing.Size(480, 33)
        Me.cboPowerMeters.TabIndex = 11
        '
        'dgBytes
        '
        Me.dgBytes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgBytes.DataMember = ""
        Me.dgBytes.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgBytes.Location = New System.Drawing.Point(1206, 59)
        Me.dgBytes.Name = "dgBytes"
        Me.dgBytes.RowHeadersVisible = False
        Me.dgBytes.Size = New System.Drawing.Size(400, 762)
        Me.dgBytes.TabIndex = 10
        '
        'lblSerialNumber
        '
        Me.lblSerialNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSerialNumber.AutoSize = True
        Me.lblSerialNumber.Location = New System.Drawing.Point(16, 880)
        Me.lblSerialNumber.Name = "lblSerialNumber"
        Me.lblSerialNumber.Size = New System.Drawing.Size(166, 25)
        Me.lblSerialNumber.TabIndex = 6
        Me.lblSerialNumber.Text = "Serial Number:  "
        '
        'lblManufacturer
        '
        Me.lblManufacturer.AutoSize = True
        Me.lblManufacturer.Location = New System.Drawing.Point(16, 827)
        Me.lblManufacturer.Name = "lblManufacturer"
        Me.lblManufacturer.Size = New System.Drawing.Size(157, 25)
        Me.lblManufacturer.TabIndex = 13
        Me.lblManufacturer.Text = "Manufacturer:  "
        '
        'dgCalibrationFactors
        '
        Me.dgCalibrationFactors.AllowSorting = False
        Me.dgCalibrationFactors.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgCalibrationFactors.DataMember = ""
        Me.dgCalibrationFactors.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgCalibrationFactors.Location = New System.Drawing.Point(16, 59)
        Me.dgCalibrationFactors.Name = "dgCalibrationFactors"
        Me.dgCalibrationFactors.PreferredColumnWidth = 100
        Me.dgCalibrationFactors.RowHeadersVisible = False
        Me.dgCalibrationFactors.Size = New System.Drawing.Size(1174, 762)
        Me.dgCalibrationFactors.TabIndex = 2
        '
        'lblNumberOfPoints
        '
        Me.lblNumberOfPoints.AutoSize = True
        Me.lblNumberOfPoints.Location = New System.Drawing.Point(16, 30)
        Me.lblNumberOfPoints.Name = "lblNumberOfPoints"
        Me.lblNumberOfPoints.Size = New System.Drawing.Size(195, 25)
        Me.lblNumberOfPoints.TabIndex = 3
        Me.lblNumberOfPoints.Text = "Number of Points:  "
        '
        'lblModel
        '
        Me.lblModel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblModel.AutoSize = True
        Me.lblModel.Location = New System.Drawing.Point(16, 851)
        Me.lblModel.Name = "lblModel"
        Me.lblModel.Size = New System.Drawing.Size(89, 25)
        Me.lblModel.TabIndex = 5
        Me.lblModel.Text = "Model:  "
        '
        'btnFindMeters
        '
        Me.btnFindMeters.Location = New System.Drawing.Point(1376, 842)
        Me.btnFindMeters.Name = "btnFindMeters"
        Me.btnFindMeters.Size = New System.Drawing.Size(150, 42)
        Me.btnFindMeters.TabIndex = 14
        Me.btnFindMeters.Text = "Find Meters"
        '
        'lblOptions
        '
        Me.lblOptions.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblOptions.AutoSize = True
        Me.lblOptions.Location = New System.Drawing.Point(16, 910)
        Me.lblOptions.Name = "lblOptions"
        Me.lblOptions.Size = New System.Drawing.Size(104, 25)
        Me.lblOptions.TabIndex = 8
        Me.lblOptions.Text = "Options:  "
        '
        'btnUpLoad
        '
        Me.btnUpLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnUpLoad.Enabled = False
        Me.btnUpLoad.Location = New System.Drawing.Point(1456, 895)
        Me.btnUpLoad.Name = "btnUpLoad"
        Me.btnUpLoad.Size = New System.Drawing.Size(150, 42)
        Me.btnUpLoad.TabIndex = 4
        Me.btnUpLoad.Text = "Upload"
        '
        'chkboxAllowUpload
        '
        Me.chkboxAllowUpload.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkboxAllowUpload.Location = New System.Drawing.Point(1424, 9)
        Me.chkboxAllowUpload.Name = "chkboxAllowUpload"
        Me.chkboxAllowUpload.Size = New System.Drawing.Size(176, 44)
        Me.chkboxAllowUpload.TabIndex = 9
        Me.chkboxAllowUpload.Text = "Allow Upload"
        '
        'EEPROMPowerSensorManipluatorForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(10, 24)
        Me.ClientSize = New System.Drawing.Size(1622, 948)
        Me.Controls.Add(Me.btnFindMeters)
        Me.Controls.Add(Me.lblManufacturer)
        Me.Controls.Add(Me.cboPowerMeters)
        Me.Controls.Add(Me.dgBytes)
        Me.Controls.Add(Me.lblOptions)
        Me.Controls.Add(Me.lblSerialNumber)
        Me.Controls.Add(Me.lblModel)
        Me.Controls.Add(Me.btnUpLoad)
        Me.Controls.Add(Me.dgCalibrationFactors)
        Me.Controls.Add(Me.btnDownload)
        Me.Controls.Add(Me.chkboxAllowUpload)
        Me.Controls.Add(Me.lblCurrentPowerMeter)
        Me.Controls.Add(Me.lblNumberOfPoints)
        Me.Name = "EEPROMPowerSensorManipluatorForm"
        Me.Text = "EEPROM Power Sensor Manupulator"
        CType(Me.dgBytes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgCalibrationFactors, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    Private Sub DetectMeters()
        Dim GPIB0 As Board = Nothing
        Try
            GPIB0 = New Board(0)
            GPIB0.SendInterfaceClear()
            GPIB0.IOTimeout = TimeoutValue.T10ms
            Dim Listeners As AddressCollection = GPIB0.FindListeners
            Dim Dev As Device
            Dim DevIDN() As String = Nothing
            For Each Listener As Address In Listeners
                Dev = New Device(GPIB0.PrimaryAddress, Listener.PrimaryAddress, Listener.SecondaryAddress)
                Dev.IOTimeout = TimeoutValue.T1s
                Try
                    Dev.Write("*IDN?")
                    DevIDN = Dev.ReadString.Split(","c)
                Catch
                End Try
                If DevIDN.Length > 0 Then
                    If DevIDN(1).ToUpper.Contains("E441") Or (DevIDN(0).ToUpper.Contains("GIGA-TRONICS") And DevIDN(1).ToUpper.Contains("85")) Or DevIDN(1).ToUpper.Contains("ML248") Then
                        Me.Manufacturer = DevIDN(0).Replace(NewLine, "").Trim
                        Me.lblManufacturer.Text = "Manufacturer:  " & Me.Manufacturer
                        Me.ModelNumber = DevIDN(1).Replace(NewLine, "").Trim
                        Me.SerialNumber = DevIDN(2).Replace(NewLine, "").Trim
                        Me.cboPowerMeters.Items.Add(Me.Manufacturer & ", " & Me.ModelNumber & ", " & Listener.PrimaryAddress)
                    End If
                    If (Not Dev Is Nothing) Then
                        Dev.Dispose()
                    End If
                End If
            Next
            GPIB0.Dispose()
            If Me.cboPowerMeters.Items.Count > 0 Then Me.cboPowerMeters.SelectedIndex = 1
        Catch BoardException As Exception
            MessageBox.Show("There was a problem connecting to the interface bus, make sure it is plugged in operational.")
        Finally
            If (Not GPIB0 Is Nothing) Then
                GPIB0.Dispose()
            End If
        End Try
    End Sub

    Private Sub btnDownloadClick(sender As System.Object, e As System.EventArgs) Handles btnDownload.Click
        Me.EEPROMData.Clear()
        Dim B As Board = Nothing
        Try
            B = New Board(0)
            Me.CurrentPowerMeter = New Device(0, Convert.ToByte(cboPowerMeters.Text.Substring(cboPowerMeters.Text.LastIndexOf(", ")).Replace(", ", "").Trim))
            B.SendInterfaceClear()
            B.AcquireInterfaceLock(10000)
            If Me.cboPowerMeters.Text.Contains("E441") Then
                Me.CurrentPowerMeter.Write("SERV:SENS:TYPE?")
                Dim Model() As String = Me.CurrentPowerMeter.ReadString.Split(","c)
                Me.lblModel.Text = "Model:  " & Model(0)
                Me.CurrentPowerMeter.Write("SERV:SENS:SNUM?")
                Me.SerialNumber = Me.CurrentPowerMeter.ReadString.Replace(NewLine, "").Trim
                Me.lblSerialNumber.Text = "Serial Number:  " & Me.SerialNumber
                Me.CurrentPowerMeter.Write("INIT:CONT OFF")
                Me.ModelNumber = Model(0)
                Me.lblOptions.Text = "Options:  " & Model(1).Replace(NewLine, "").Trim
                If Model(0) = "E4413A" Then
                    Me.dtBytes.Rows.Clear()
                    Me.dtCalibrationFactors.Clear()
                    Me.dtCalibrationFactors.Columns.Clear()
                    Me.dtCalibrationFactors.Columns.Add(New DataColumn("Point Number"))
                    Me.dtCalibrationFactors.Columns.Add(New DataColumn("Memory Location"))
                    Me.dtCalibrationFactors.Columns.Add(New DataColumn("Frequency (MHz)"))
                    Me.dtCalibrationFactors.Columns.Add(New DataColumn("Low CF"))
                    Me.dtCalibrationFactors.Columns.Add(New DataColumn("High CF"))
                    Me.CurrentPowerMeter.Write("SERV:SENS:CALF?")
                    Me.EEPROMData.AddRange(Me.CurrentPowerMeter.ReadByteArray)
                    For I As Integer = 0 To Me.EEPROMData.Count - 1
                        Dim NewDR As DataRow = Me.dtBytes.NewRow
                        NewDR(0) = I
                        NewDR(1) = EEPROMData(I)
                        Me.dtBytes.Rows.Add(NewDR)
                    Next
                    Me.dgBytes.DataSource = Me.dtBytes
                    Me.dgBytes.ReadOnly = True
                    Dim NumberOfPointsArray(1) As Byte
                    NumberOfPointsArray(1) = Convert.ToByte(EEPROMData(4))
                    NumberOfPointsArray(0) = Convert.ToByte(EEPROMData(5))
                    Dim MemoryLoc As Integer = 14
                    For I As Integer = 1 To CInt((Me.EEPROMData.Count - 13) / 8)
                        Dim NewDR As DataRow = Me.dtCalibrationFactors.NewRow
                        NewDR(0) = I
                        NewDR(1) = MemoryLoc
                        Dim Bytes() As Byte = {Convert.ToByte(EEPROMData(MemoryLoc + 3)), Convert.ToByte(EEPROMData(MemoryLoc + 2)), Convert.ToByte(EEPROMData(MemoryLoc + 1)), Convert.ToByte(EEPROMData(MemoryLoc))}
                        NewDR(2) = (BitConverter.ToInt32(Bytes, 0) / 1000)
                        Dim Bytes2() As Byte = {Convert.ToByte(EEPROMData(MemoryLoc + 5)), Convert.ToByte(EEPROMData(MemoryLoc + 4))}
                        NewDR(3) = String.Format("{0:#.00}", 100 * (BitConverter.ToInt16(Bytes2, 0)) / 2 ^ 14)
                        Bytes2(0) = Convert.ToByte(EEPROMData(MemoryLoc + 7))
                        Bytes2(1) = Convert.ToByte(EEPROMData(MemoryLoc + 6))
                        NewDR(4) = String.Format("{0:#.00}", 100 * (BitConverter.ToInt16(Bytes2, 0)) / 2 ^ 14)
                        Me.dtCalibrationFactors.Rows.Add(NewDR)
                        MemoryLoc = MemoryLoc + 8
                    Next
                    Me.dtCalibrationFactors.Columns(0).ReadOnly = True
                    Me.dtCalibrationFactors.Columns(1).ReadOnly = True
                    Me.dtCalibrationFactors.Columns(2).ReadOnly = True
                    Me.lblNumberOfPoints.Text = "Number of Points:  " & Me.dtCalibrationFactors.Rows.Count
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
                    Me.CurrentPowerMeter.Write("SERV:SENS:CALF?")
                    Me.EEPROMData.AddRange(Me.CurrentPowerMeter.ReadByteArray)
                    For I As Integer = 0 To Me.EEPROMData.Count - 1
                        Dim NewDR As DataRow = Me.dtBytes.NewRow
                        NewDR(0) = I
                        NewDR(1) = EEPROMData(I)
                        Me.dtBytes.Rows.Add(NewDR)
                    Next
                    Me.dgBytes.DataSource = Me.dtBytes
                    Me.dgBytes.ReadOnly = True
                    Dim NumberOfPointsArray(1) As Byte
                    NumberOfPointsArray(1) = Convert.ToByte(EEPROMData(4))
                    NumberOfPointsArray(0) = Convert.ToByte(EEPROMData(5))
                    Dim MemoryLoc As Integer = 15
                    For I As Integer = 1 To 32
                        Dim NewDR As DataRow = Me.dtCalibrationFactors.NewRow
                        NewDR(0) = I
                        NewDR(1) = MemoryLoc
                        Dim Bytes() As Byte = {Convert.ToByte(EEPROMData(MemoryLoc + 3)), Convert.ToByte(EEPROMData(MemoryLoc + 2)), Convert.ToByte(EEPROMData(MemoryLoc + 1)), Convert.ToByte(EEPROMData(MemoryLoc))}
                        NewDR(2) = (BitConverter.ToInt32(Bytes, 0) / 1000)
                        Dim Bytes2() As Byte = {Convert.ToByte(EEPROMData(MemoryLoc + 5)), Convert.ToByte(EEPROMData(MemoryLoc + 4))}
                        NewDR(3) = String.Format("{0:#.00}", 100 * (BitConverter.ToInt16(Bytes2, 0)) / 2 ^ 14)
                        Bytes2(0) = Convert.ToByte(EEPROMData(MemoryLoc + 7))
                        Bytes2(1) = Convert.ToByte(EEPROMData(MemoryLoc + 6))
                        NewDR(4) = String.Format("{0:#.00}", 100 * (BitConverter.ToInt16(Bytes2, 0)) / 2 ^ 14)
                        Me.dtCalibrationFactors.Rows.Add(NewDR)
                        MemoryLoc = MemoryLoc + 8
                    Next
                    MemoryLoc = 275
                    For I As Integer = 0 To 31
                        Me.dtCalibrationFactors.Rows(I)(5) = MemoryLoc
                        Dim Bytes2() As Byte = {Convert.ToByte(EEPROMData(MemoryLoc + 5)), Convert.ToByte(EEPROMData(MemoryLoc + 4))}
                        Me.dtCalibrationFactors.Rows(I)(6) = String.Format("{0:#.00}", 100 * (BitConverter.ToInt16(Bytes2, 0)) / 2 ^ 14)
                        Bytes2(0) = Convert.ToByte(EEPROMData(MemoryLoc + 7))
                        Bytes2(1) = Convert.ToByte(EEPROMData(MemoryLoc + 6))
                        Me.dtCalibrationFactors.Rows(I)(7) = String.Format("{0:#.00}", 100 * (BitConverter.ToInt16(Bytes2, 0)) / 2 ^ 14)
                        MemoryLoc = MemoryLoc + 8
                    Next
                    Me.dtCalibrationFactors.Columns(5).ReadOnly = True
                End If
                Me.dtCalibrationFactors.Columns(0).ReadOnly = True
                Me.dtCalibrationFactors.Columns(1).ReadOnly = True
                Me.dtCalibrationFactors.Columns(2).ReadOnly = True
                Me.lblNumberOfPoints.Text = "Number of Points:  " & Me.dtCalibrationFactors.Rows.Count
                Dim FS As FileStream = File.Open(Me.SerialNumber & ".txt", FileMode.OpenOrCreate)
                FS.SetLength(0)
                Dim SW As New StreamWriter(FS)
                For Each DR As DataRow In Me.dtBytes.Rows
                    SW.WriteLine(DR(0).ToString & "," & DR(1).ToString)
                Next
                SW.Close()
            ElseIf cboPowerMeters.Text.Contains("85") Then
                Me.dtBytes.Rows.Clear()
                Me.dtCalibrationFactors.Clear()
                Me.dtCalibrationFactors.Columns.Clear()
                Me.dtCalibrationFactors.Columns.Add(New DataColumn("Point Number"))
                Me.dtCalibrationFactors.Columns.Add(New DataColumn("Frequency (GHz)"))
                Me.dtCalibrationFactors.Columns.Add(New DataColumn("Cal Factor (dBm)"))
                Me.CurrentPowerMeter.Write("TEST EEPROM A READ")
                Me.CurrentPowerMeter.Write("EEPROM A FREQ?")
                Me.EEPROMData.AddRange(Me.CurrentPowerMeter.ReadString.Split(","c))
                Dim I As Integer = 1
                For Each DataPoint As Double In EEPROMData
                    Dim NewDR As DataRow = Me.dtCalibrationFactors.NewRow
                    NewDR(0) = I
                    NewDR(1) = (DataPoint / 1000000000)
                    Me.dtCalibrationFactors.Rows.Add(NewDR)
                    I += 1
                Next
                Me.CurrentPowerMeter.Write("TEST EEPROM A CALFST?")
                Me.EEPROMData.Clear()
                Me.EEPROMData.AddRange(Me.CurrentPowerMeter.ReadString.Split(","c))
                Me.dtCalibrationFactors.Rows(0)(2) = 0
                I = 1
                For Each DataPoint As String In EEPROMData
                    Me.dtCalibrationFactors.Rows(I)(2) = DataPoint
                    I += 1
                Next
                Me.dtCalibrationFactors.Columns(0).ReadOnly = True
                Me.dtCalibrationFactors.Columns(1).ReadOnly = True
                Me.dgCalibrationFactors.DataSource = Me.dtCalibrationFactors
            ElseIf Me.cboPowerMeters.Text.Contains("ML248") Then
                Me.dtBytes.Rows.Clear()
                Me.dtCalibrationFactors.Clear()
                Me.dtCalibrationFactors.Columns.Clear()
                Me.dtCalibrationFactors.Columns.Add(New DataColumn("Point Number"))
                Me.dtCalibrationFactors.Columns.Add(New DataColumn("Frequency (GHz)"))
                Me.dtCalibrationFactors.Columns.Add(New DataColumn("Cal Factor (dBm)"))
                Me.CurrentPowerMeter.Write("SNCTNQ A")
                Dim NumberOfSensorTables As Integer = CInt(Me.CurrentPowerMeter.ReadString.Replace(NewLine, "").Trim)
                For CurrentTableNumber As Integer = 1 To NumberOfSensorTables
                    Me.CurrentPowerMeter.Write("SNCTAO A," & CurrentTableNumber)
                    Me.EEPROMData.AddRange(Me.CurrentPowerMeter.ReadString.Split(","c))
                    Dim PointNumber As Integer = 1
                    For FrequencyPoint As Integer = 4 To Me.EEPROMData.Count - 1 Step 2
                        Dim NewDR As DataRow = Me.dtCalibrationFactors.NewRow
                        NewDR(0) = PointNumber
                        NewDR(1) = EEPROMData(FrequencyPoint).ToString.Replace(NewLine, "").Trim
                        NewDR(2) = EEPROMData(FrequencyPoint + 1).ToString.Replace(NewLine, "").Trim
                        PointNumber += 1
                    Next
                Next
            End If
        Catch Ex As Exception
            MessageBox.Show("There was a problem downloading the sensor data, please check your setup and try again.")
        Finally
            If (Not B Is Nothing) Then
                B.Dispose()
            End If
        End Try
    End Sub

    Private Sub BtnUpLoadClick(sender As System.Object, e As System.EventArgs) Handles btnUpLoad.Click
        Dim B As Board = Nothing
        Try
            B = New Board(0)
            B.SendInterfaceClear()
            B.AcquireInterfaceLock(10000)
            If Me.cboPowerMeters.Text.Contains("E441") Then
                If Me.ModelNumber = "E4413A" Then
                    Me.CurrentPowerMeter.Write("INIT:CONT OFF")
                    Dim Data As New ArrayList
                    Dim T As String = String.Empty
                    For RowNumber As Integer = 0 To 38
                        Dim ConvertedFrequencyValue As Integer = Convert.ToInt32(Me.dtCalibrationFactors.Rows(RowNumber)(2)) * 1000
                        Dim TempData() As Byte = BitConverter.GetBytes(ConvertedFrequencyValue)
                        For I As Integer = 3 To 0 Step -1
                            Data.Add(TempData(I))
                        Next
                        Dim ConvertedCalFactorValue As Integer = Convert.ToInt32(2 ^ 14 * Convert.ToInt32(dtCalibrationFactors.Rows(RowNumber)(3)) / 100)
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
                    Dim FS As FileStream = File.Open(EEPROMDataDirectory & "\test.txt", FileMode.OpenOrCreate)
                    Dim SW As New StreamWriter(FS)
                    SW.Write(T)
                    SW.Close()
                    Dim DataPoint As Integer = 0
                    For MemoryLocation As Integer = 569 To 880
                        Me.CurrentPowerMeter.Write("DIAG:DET:EEPR " & MemoryLocation & "," & Data(DataPoint).ToString)
                        DataPoint += 1
                    Next
                ElseIf Me.ModelNumber = "E9300A" Then
                    MessageBox.Show("I have not completed the code for the E9300A upload yet, Sorry.")
                End If
            ElseIf Me.cboPowerMeters.Text.Contains("85") Then
                Dim DataArrayToWrite As New ArrayList
                For I As Integer = 1 To Me.dtCalibrationFactors.Rows.Count - 1
                    DataArrayToWrite.Add(Me.dtCalibrationFactors.Rows(I)(2))
                Next
                Dim DataStringToWrite As String = Nothing
                For Each DataPoint As String In DataArrayToWrite
                    DataStringToWrite = DataStringToWrite & DataPoint & ","
                Next
                DataStringToWrite = DataStringToWrite.Remove(DataStringToWrite.Length - 1, 1)
                Me.CurrentPowerMeter.Write("TEST EEPROM A WRITE 0")
            ElseIf Me.cboPowerMeters.Text.Contains("ML248") Then
            End If
        Catch Ex As Exception
            MessageBox.Show("There was a problem uploading the sensor data, please check your setup and try again.")
        Finally
            If (Not B Is Nothing) Then
                B.Dispose()
            End If
        End Try
    End Sub

    Private Sub EEPROMPowerSensorManipluatorFormClosing(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If (Not Me.CurrentPowerMeter Is Nothing) Then
            Me.CurrentPowerMeter.Dispose()
        End If
    End Sub

    Private Sub ChkboxAllowUploadClick(sender As System.Object, e As System.EventArgs)
        If Me.chkboxAllowUpload.CheckState = CheckState.Checked Then
            Me.chkboxAllowUpload.Checked = True
            Me.btnUpLoad.Enabled = False
        ElseIf Me.chkboxAllowUpload.CheckState = CheckState.Unchecked Then
            Me.chkboxAllowUpload.Checked = False
            Me.btnUpLoad.Enabled = True
        End If
    End Sub

    Private Sub ChkboxAllowUploadCheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkboxAllowUpload.CheckedChanged
        If Me.dtCalibrationFactors.Rows.Count > 0 Then
            Me.btnUpLoad.Enabled = Me.chkboxAllowUpload.Checked
        Else
            Me.chkboxAllowUpload.Checked = False
            Me.btnUpLoad.Enabled = Me.chkboxAllowUpload.Checked
        End If
    End Sub

    Private Sub BtnFindMetersClick(sender As System.Object, e As System.EventArgs) Handles btnFindMeters.Click
        Me.DetectMeters()
    End Sub

End Class

