'
' Created by SharpDevelop.
' User: rspage
' Date: 6/7/2005
' Time: 1:11 PM
' 

Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.ControlChars
Imports System.Collections
Imports System.Data
Imports NationalInstruments.NI4882
Imports FreeCal.Instruments.PowerMeters



Public Class AgilentE4417AEEPROMForm
    Inherits System.Windows.Forms.Form

    Private ESeriesPowerMeter As AgilentE4417A
    Private ModelNumber As String
    Private SerialNumber As String
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

    Public Shared Sub Main()
        Dim NewAgilentE4417AEEPROMForm As New AgilentE4417AEEPROMForm
        NewAgilentE4417AEEPROMForm.ShowDialog()
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
        Me.btnDownload.Location = New System.Drawing.Point(1280, 901)
        Me.btnDownload.Name = "btnDownload"
        Me.btnDownload.Size = New System.Drawing.Size(160, 42)
        Me.btnDownload.TabIndex = 1
        Me.btnDownload.Text = "Download"
        '
        'lblCurrentPowerMeter
        '
        Me.lblCurrentPowerMeter.AutoSize = True
        Me.lblCurrentPowerMeter.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.lblCurrentPowerMeter.Location = New System.Drawing.Point(832, 871)
        Me.lblCurrentPowerMeter.Name = "lblCurrentPowerMeter"
        Me.lblCurrentPowerMeter.Size = New System.Drawing.Size(125, 13)
        Me.lblCurrentPowerMeter.TabIndex = 12
        Me.lblCurrentPowerMeter.Text = "Current Power Meter"
        '
        'cboPowerMeters
        '
        Me.cboPowerMeters.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cboPowerMeters.Location = New System.Drawing.Point(704, 901)
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
        Me.dgBytes.Location = New System.Drawing.Point(1268, 59)
        Me.dgBytes.Name = "dgBytes"
        Me.dgBytes.RowHeadersVisible = False
        Me.dgBytes.Size = New System.Drawing.Size(400, 768)
        Me.dgBytes.TabIndex = 10
        '
        'lblSerialNumber
        '
        Me.lblSerialNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSerialNumber.AutoSize = True
        Me.lblSerialNumber.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.lblSerialNumber.Location = New System.Drawing.Point(16, 886)
        Me.lblSerialNumber.Name = "lblSerialNumber"
        Me.lblSerialNumber.Size = New System.Drawing.Size(95, 13)
        Me.lblSerialNumber.TabIndex = 6
        Me.lblSerialNumber.Text = "Serial Number:  "
        '
        'lblManufacturer
        '
        Me.lblManufacturer.AutoSize = True
        Me.lblManufacturer.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.lblManufacturer.Location = New System.Drawing.Point(16, 827)
        Me.lblManufacturer.Name = "lblManufacturer"
        Me.lblManufacturer.Size = New System.Drawing.Size(93, 13)
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
        Me.dgCalibrationFactors.Size = New System.Drawing.Size(1236, 768)
        Me.dgCalibrationFactors.TabIndex = 2
        '
        'lblNumberOfPoints
        '
        Me.lblNumberOfPoints.AutoSize = True
        Me.lblNumberOfPoints.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.lblNumberOfPoints.Location = New System.Drawing.Point(16, 30)
        Me.lblNumberOfPoints.Name = "lblNumberOfPoints"
        Me.lblNumberOfPoints.Size = New System.Drawing.Size(112, 13)
        Me.lblNumberOfPoints.TabIndex = 3
        Me.lblNumberOfPoints.Text = "Number of Points:  "
        '
        'lblModel
        '
        Me.lblModel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblModel.AutoSize = True
        Me.lblModel.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.lblModel.Location = New System.Drawing.Point(16, 857)
        Me.lblModel.Name = "lblModel"
        Me.lblModel.Size = New System.Drawing.Size(50, 13)
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
        Me.lblOptions.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.lblOptions.Location = New System.Drawing.Point(16, 916)
        Me.lblOptions.Name = "lblOptions"
        Me.lblOptions.Size = New System.Drawing.Size(59, 13)
        Me.lblOptions.TabIndex = 8
        Me.lblOptions.Text = "Options:  "
        '
        'btnUpLoad
        '
        Me.btnUpLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnUpLoad.Enabled = False
        Me.btnUpLoad.Location = New System.Drawing.Point(1456, 901)
        Me.btnUpLoad.Name = "btnUpLoad"
        Me.btnUpLoad.Size = New System.Drawing.Size(150, 42)
        Me.btnUpLoad.TabIndex = 4
        Me.btnUpLoad.Text = "Upload"
        '
        'chkboxAllowUpload
        '
        Me.chkboxAllowUpload.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkboxAllowUpload.Location = New System.Drawing.Point(1424, 15)
        Me.chkboxAllowUpload.Name = "chkboxAllowUpload"
        Me.chkboxAllowUpload.Size = New System.Drawing.Size(176, 44)
        Me.chkboxAllowUpload.TabIndex = 9
        Me.chkboxAllowUpload.Text = "Allow Upload"
        '
        'AgilentE4417AEEPROMForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(10, 24)
        Me.ClientSize = New System.Drawing.Size(1684, 954)
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
        Me.Name = "AgilentE4417AEEPROMForm"
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
            Dim Dev As Device = Nothing
            Dim DevIDN() As String = Nothing
            For Each Listener As Address In Listeners
                Dev = New Device(GPIB0.PrimaryAddress, Listener.PrimaryAddress, Listener.SecondaryAddress)
                Dev.IOTimeout = TimeoutValue.T1s
                Try
                    Dev.Write("*IDN?")
                    DevIDN = Dev.ReadString.Split(","c)
                Catch
                End Try
                If DevIDN.GetUpperBound(0) > 0 Then
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
        Me.ESeriesPowerMeter = New AgilentE4417A(0, Convert.ToByte(Me.cboPowerMeters.Text.Substring(Me.cboPowerMeters.Text.LastIndexOf(", ")).Replace(", ", "").Trim), False)
        Me.ESeriesPowerMeter.DownloadPowerSensorEEPROM()
        Me.lblModel.Text = Me.ESeriesPowerMeter.PowerSensorModelNumber
        Me.lblSerialNumber.Text = Me.ESeriesPowerMeter.PowerSensorSerialNumber
        Me.dgBytes.DataSource = Me.ESeriesPowerMeter.dtBytes
        Me.dgCalibrationFactors.DataSource = Me.ESeriesPowerMeter.dtCalibrationFactors
    End Sub

    Private Sub BtnUpLoadClick(sender As System.Object, e As System.EventArgs) Handles btnUpLoad.Click
        Me.ESeriesPowerMeter.UploadPowerSensorEEPROM()
    End Sub

    Private Sub EEPROMPowerSensorManipluatorFormClosing(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If (Not Me.ESeriesPowerMeter Is Nothing) Then
            Me.ESeriesPowerMeter.Dispose()
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
        If Me.ESeriesPowerMeter.dtCalibrationFactors.Rows.Count > 0 Then
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



