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
		Private chkboxAllowUpload As System.Windows.Forms.CheckBox
		Private btnUpLoad As System.Windows.Forms.Button
		Private lblOptions As System.Windows.Forms.Label
		Private btnFindMeters As System.Windows.Forms.Button
		Private lblModel As System.Windows.Forms.Label
		Private lblNumberOfPoints As System.Windows.Forms.Label
		Private dgCalibrationFactors As System.Windows.Forms.DataGrid
		Private lblManufacturer As System.Windows.Forms.Label
		Private lblSerialNumber As System.Windows.Forms.Label
		Private dgBytes As System.Windows.Forms.DataGrid
		Private cboPowerMeters As System.Windows.Forms.ComboBox
		Private lblCurrentPowerMeter As System.Windows.Forms.Label
		Private btnDownload As System.Windows.Forms.Button
		
		Public Shared Sub Main
			Dim NewAgilentE4417AEEPROMForm As New AgilentE4417AEEPROMForm
			NewAgilentE4417AEEPROMForm.ShowDialog()
		End Sub

		Public Sub New()
			MyBase.New
			'
			' The Me.InitializeComponent call is required for Windows Forms designer support.
			'
			Me.InitializeComponent
			Me.SetupForm
		End Sub

		Public Sub New(ByVal parent As Form)
			MyBase.New
			'
			' The Me.InitializeComponent call is required for Windows Forms designer support.
			'
			Me.InitializeComponent
			Me.MdiParent = Parent
			Me.SetupForm
		End Sub

        Private Sub SetupForm()
            Me.DetectMeters
        End Sub		

		#Region " Windows Forms Designer generated code "
		' This method is required for Windows Forms designer support.
		' Do not change the method contents inside the source code editor. The Forms designer might
		' not be able to load this method if it was changed manually.
		Private Sub InitializeComponent()
            Me.btnDownload = New System.Windows.Forms.Button
            Me.lblCurrentPowerMeter = New System.Windows.Forms.Label
            Me.cboPowerMeters = New System.Windows.Forms.ComboBox
            Me.dgBytes = New System.Windows.Forms.DataGrid
            Me.lblSerialNumber = New System.Windows.Forms.Label
            Me.lblManufacturer = New System.Windows.Forms.Label
            Me.dgCalibrationFactors = New System.Windows.Forms.DataGrid
            Me.lblNumberOfPoints = New System.Windows.Forms.Label
            Me.lblModel = New System.Windows.Forms.Label
            Me.btnFindMeters = New System.Windows.Forms.Button
            Me.lblOptions = New System.Windows.Forms.Label
            Me.btnUpLoad = New System.Windows.Forms.Button
            Me.chkboxAllowUpload = New System.Windows.Forms.CheckBox
            CType(Me.dgBytes,System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.dgCalibrationFactors,System.ComponentModel.ISupportInitialize).BeginInit
            Me.SuspendLayout
            '
            'btnDownload
            '
            Me.btnDownload.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
            Me.btnDownload.Location = New System.Drawing.Point(640, 488)
            Me.btnDownload.Name = "btnDownload"
            Me.btnDownload.Size = New System.Drawing.Size(80, 23)
            Me.btnDownload.TabIndex = 1
            Me.btnDownload.Text = "Download"
            AddHandler Me.btnDownload.Click, AddressOf Me.btnDownloadClick
            '
            'lblCurrentPowerMeter
            '
            Me.lblCurrentPowerMeter.AutoSize = true
            Me.lblCurrentPowerMeter.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0,Byte))
            Me.lblCurrentPowerMeter.Location = New System.Drawing.Point(416, 472)
            Me.lblCurrentPowerMeter.Name = "lblCurrentPowerMeter"
            Me.lblCurrentPowerMeter.Size = New System.Drawing.Size(123, 17)
            Me.lblCurrentPowerMeter.TabIndex = 12
            Me.lblCurrentPowerMeter.Text = "Current Power Meter"
            '
            'cboPowerMeters
            '
            Me.cboPowerMeters.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
            Me.cboPowerMeters.Location = New System.Drawing.Point(352, 488)
            Me.cboPowerMeters.Name = "cboPowerMeters"
            Me.cboPowerMeters.Size = New System.Drawing.Size(240, 21)
            Me.cboPowerMeters.TabIndex = 11
            '
            'dgBytes
            '
            Me.dgBytes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
                        Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
            Me.dgBytes.DataMember = ""
            Me.dgBytes.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.dgBytes.Location = New System.Drawing.Point(600, 32)
            Me.dgBytes.Name = "dgBytes"
            Me.dgBytes.RowHeadersVisible = false
            Me.dgBytes.Size = New System.Drawing.Size(200, 416)
            Me.dgBytes.TabIndex = 10
            '
            'lblSerialNumber
            '
            Me.lblSerialNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
            Me.lblSerialNumber.AutoSize = true
            Me.lblSerialNumber.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0,Byte))
            Me.lblSerialNumber.Location = New System.Drawing.Point(8, 480)
            Me.lblSerialNumber.Name = "lblSerialNumber"
            Me.lblSerialNumber.Size = New System.Drawing.Size(96, 17)
            Me.lblSerialNumber.TabIndex = 6
            Me.lblSerialNumber.Text = "Serial Number:  "
            '
            'lblManufacturer
            '
            Me.lblManufacturer.AutoSize = true
            Me.lblManufacturer.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0,Byte))
            Me.lblManufacturer.Location = New System.Drawing.Point(8, 448)
            Me.lblManufacturer.Name = "lblManufacturer"
            Me.lblManufacturer.Size = New System.Drawing.Size(92, 17)
            Me.lblManufacturer.TabIndex = 13
            Me.lblManufacturer.Text = "Manufacturer:  "
            '
            'dgCalibrationFactors
            '
            Me.dgCalibrationFactors.AllowSorting = false
            Me.dgCalibrationFactors.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
                        Or System.Windows.Forms.AnchorStyles.Left)  _
                        Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
            Me.dgCalibrationFactors.DataMember = ""
            Me.dgCalibrationFactors.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.dgCalibrationFactors.Location = New System.Drawing.Point(8, 32)
            Me.dgCalibrationFactors.Name = "dgCalibrationFactors"
            Me.dgCalibrationFactors.PreferredColumnWidth = 100
            Me.dgCalibrationFactors.RowHeadersVisible = false
            Me.dgCalibrationFactors.Size = New System.Drawing.Size(584, 416)
            Me.dgCalibrationFactors.TabIndex = 2
            '
            'lblNumberOfPoints
            '
            Me.lblNumberOfPoints.AutoSize = true
            Me.lblNumberOfPoints.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0,Byte))
            Me.lblNumberOfPoints.Location = New System.Drawing.Point(8, 16)
            Me.lblNumberOfPoints.Name = "lblNumberOfPoints"
            Me.lblNumberOfPoints.Size = New System.Drawing.Size(114, 17)
            Me.lblNumberOfPoints.TabIndex = 3
            Me.lblNumberOfPoints.Text = "Number of Points:  "
            '
            'lblModel
            '
            Me.lblModel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
            Me.lblModel.AutoSize = true
            Me.lblModel.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0,Byte))
            Me.lblModel.Location = New System.Drawing.Point(8, 464)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(49, 17)
            Me.lblModel.TabIndex = 5
            Me.lblModel.Text = "Model:  "
            '
            'btnFindMeters
            '
            Me.btnFindMeters.Location = New System.Drawing.Point(688, 456)
            Me.btnFindMeters.Name = "btnFindMeters"
            Me.btnFindMeters.TabIndex = 14
            Me.btnFindMeters.Text = "Find Meters"
            AddHandler Me.btnFindMeters.Click, AddressOf Me.BtnFindMetersClick
            '
            'lblOptions
            '
            Me.lblOptions.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
            Me.lblOptions.AutoSize = true
            Me.lblOptions.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0,Byte))
            Me.lblOptions.Location = New System.Drawing.Point(8, 496)
            Me.lblOptions.Name = "lblOptions"
            Me.lblOptions.Size = New System.Drawing.Size(59, 17)
            Me.lblOptions.TabIndex = 8
            Me.lblOptions.Text = "Options:  "
            '
            'btnUpLoad
            '
            Me.btnUpLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
            Me.btnUpLoad.Enabled = false
            Me.btnUpLoad.Location = New System.Drawing.Point(728, 488)
            Me.btnUpLoad.Name = "btnUpLoad"
            Me.btnUpLoad.TabIndex = 4
            Me.btnUpLoad.Text = "Upload"
            AddHandler Me.btnUpLoad.Click, AddressOf Me.BtnUpLoadClick
            '
            'chkboxAllowUpload
            '
            Me.chkboxAllowUpload.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
            Me.chkboxAllowUpload.Location = New System.Drawing.Point(712, 8)
            Me.chkboxAllowUpload.Name = "chkboxAllowUpload"
            Me.chkboxAllowUpload.Size = New System.Drawing.Size(88, 24)
            Me.chkboxAllowUpload.TabIndex = 9
            Me.chkboxAllowUpload.Text = "Allow Upload"
            AddHandler Me.chkboxAllowUpload.CheckedChanged, AddressOf Me.ChkboxAllowUploadCheckedChanged
            '
            'EEPROMPowerSensorManipluatorForm
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(808, 517)
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
            AddHandler Closing, AddressOf Me.EEPROMPowerSensorManipluatorFormClosing
            CType(Me.dgBytes,System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.dgCalibrationFactors,System.ComponentModel.ISupportInitialize).EndInit
            Me.ResumeLayout(false)
        End Sub
		#End Region

		Private Sub DetectMeters()
            Dim GPIB0 As Board
            Try
            	GPIB0 = New Board(0)
    			GPIB0.SendInterfaceClear
    			GPIB0.IOTimeout = TimeoutValue.T10ms
    			Dim Listeners As AddressCollection = GPIB0.FindListeners
    			Dim Dev As Device
    			Dim DevIDN() As String
    			For Each Listener As Address In Listeners
    				Dev = New Device(GPIB0.PrimaryAddress, Listener.PrimaryAddress, Listener.SecondaryAddress)
    				Dev.IOTimeout = TimeoutValue.T1s
    				Try
    					Dev.Write("*IDN?")
    					DevIDN = Dev.ReadString.Split(",")
    				Catch
    				End Try
                    If DevIDN.GetUpperBound(0) > 0 Then
        				If (InStr(DevIDN(1).ToUpper, "E441")) Or (InStr(DevIDN(0).ToUpper, "GIGA-TRONICS") And InStr(DevIDN(1).ToUpper, "85")) Or (InStr(DevIDN(1).ToUpper, "ML248")) Then
        				    Me.Manufacturer = DevIDN(0).Replace(NewLine, "").Trim
        				    Me.lblManufacturer.Text = "Manufacturer:  " & Me.Manufacturer
        				    Me.ModelNumber = DevIDN(1).Replace(NewLine, "").Trim
        				    Me.SerialNumber = DevIDN(2).Replace(NewLine, "").Trim
        					Me.cboPowerMeters.Items.Add(Me.Manufacturer & ", " & Me.ModelNumber & ", " & Listener.PrimaryAddress)
        	            End If
        				If (Not Dev Is Nothing) Then
        					Dev.Dispose
        				End If
        			End If
    			Next
    			GPIB0.Dispose
    			If Me.cboPowerMeters.Items.Count > 0 Then Me.cboPowerMeters.SelectedIndex = 1
    		Catch BoardException As Exception
    		    MessageBox.Show("There was a problem connecting to the interface bus, make sure it is plugged in operational.")
             Finally
                If (Not GPIB0 Is Nothing) Then
        			GPIB0.Dispose
        		End If
            End Try
		End Sub

		Private Sub btnDownloadClick(sender As System.Object, e As System.EventArgs)
			Me.ESeriesPowerMeter = New AgilentE4417A(0, Me.cboPowerMeters.Text.Substring(Me.cboPowerMeters.Text.LastIndexOf(", ")).Replace(", ", "").Trim, False)
			Me.ESeriesPowerMeter.DownloadPowerSensorEEPROM
			Me.lblModel.Text = Me.ESeriesPowerMeter.PowerSensorModelNumber
			Me.lblSerialNumber.Text = Me.ESeriesPowerMeter.PowerSensorSerialNumber
			Me.dgBytes.DataSource = Me.ESeriesPowerMeter.dtBytes
			Me.dgCalibrationFactors.DataSource = Me.ESeriesPowerMeter.dtCalibrationFactors
		End Sub

        Private Sub BtnUpLoadClick(sender As System.Object, e As System.EventArgs)
			Me.ESeriesPowerMeter.UploadPowerSensorEEPROM
        End Sub

		Private Sub EEPROMPowerSensorManipluatorFormClosing(sender As System.Object, e As System.ComponentModel.CancelEventArgs)
			If (Not Me.ESeriesPowerMeter Is Nothing) Then
				Me.ESeriesPowerMeter.Dispose
			End If
		End Sub

		Private Sub ChkboxAllowUploadClick(sender As System.Object, e As System.EventArgs)
			If Me.chkboxAllowUpload.CheckState = CheckState.Checked Then
				Me.chkboxAllowUpload.Checked = True
				Me.btnUpLoad.Enabled = False
			ElseIf Me.chkboxAllowUpload.CheckState = CheckState.UnChecked Then
				Me.chkboxAllowUpload.Checked = False
				Me.btnUpLoad.Enabled = True
			End If
		End Sub

		Private Sub ChkboxAllowUploadCheckedChanged(sender As System.Object, e As System.EventArgs)
			If Me.ESeriesPowerMeter.dtCalibrationFactors.Rows.Count > 0 Then
				Me.btnUpLoad.Enabled = Me.chkboxAllowUpload.Checked
			Else
				Me.chkboxAllowUpload.Checked = False
				Me.btnUpLoad.Enabled = Me.chkboxAllowUpload.Checked
			End If
		End Sub

        Private Sub BtnFindMetersClick(sender As System.Object, e As System.EventArgs)
            Me.DetectMeters
        End Sub

	End Class



