'
' Created by SharpDevelop.
' User: rspage
' Date: 6/27/2005
' Time: 12:06 PM
' 



Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports FreeCal.Data
Imports FreeCal.Common
Imports MySql.Data.MySqlClient
Imports System.Data


	
	Public Class PowerSensorOldCalibrationResultsForm
		Inherits System.Windows.Forms.Form
		Private dataGrid1 As System.Windows.Forms.DataGrid
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private mcLastCalibrationDate As System.Windows.Forms.MonthCalendar
		Private tbAssetNumber As System.Windows.Forms.TextBox
		Private button1 As System.Windows.Forms.Button
		Private btnOK As System.Windows.Forms.Button
		
		Public OldResults As PowerSensorTestResultsTable

		Public Sub New()
			MyBase.New
			'
			' The Me.InitializeComponent call is required for Windows Forms designer support.
			'
			Me.InitializeComponent
		End Sub
		
		#Region " Windows Forms Designer generated code "
		' This method is required for Windows Forms designer support.
		' Do not change the method contents inside the source code editor. The Forms designer might
		' not be able to load this method if it was changed manually.
		Private Sub InitializeComponent()
			Me.btnOK = New System.Windows.Forms.Button
			Me.button1 = New System.Windows.Forms.Button
			Me.tbAssetNumber = New System.Windows.Forms.TextBox
			Me.mcLastCalibrationDate = New System.Windows.Forms.MonthCalendar
			Me.label2 = New System.Windows.Forms.Label
			Me.label1 = New System.Windows.Forms.Label
			Me.dataGrid1 = New System.Windows.Forms.DataGrid
			CType(Me.dataGrid1,System.ComponentModel.ISupportInitialize).BeginInit
			Me.SuspendLayout
			'
			'btnOK
			'
			Me.btnOK.Location = New System.Drawing.Point(584, 304)
			Me.btnOK.Name = "btnOK"
			Me.btnOK.TabIndex = 6
			Me.btnOK.Text = "OK"
			AddHandler Me.btnOK.Click, AddressOf Me.BtnOKClick
			'
			'button1
			'
			Me.button1.Location = New System.Drawing.Point(624, 216)
			Me.button1.Name = "button1"
			Me.button1.TabIndex = 1
			Me.button1.Text = "Search"
			AddHandler Me.button1.Click, AddressOf Me.Button1Click
			'
			'tbAssetNumber
			'
			Me.tbAssetNumber.Location = New System.Drawing.Point(496, 216)
			Me.tbAssetNumber.Name = "tbAssetNumber"
			Me.tbAssetNumber.TabIndex = 2
			Me.tbAssetNumber.Text = ""
			'
			'mcLastCalibrationDate
			'
			Me.mcLastCalibrationDate.Location = New System.Drawing.Point(496, 32)
			Me.mcLastCalibrationDate.MaxDate = New Date(2010, 12, 31, 0, 0, 0, 0)
			Me.mcLastCalibrationDate.MaxSelectionCount = 1
			Me.mcLastCalibrationDate.MinDate = New Date(2005, 1, 1, 0, 0, 0, 0)
			Me.mcLastCalibrationDate.Name = "mcLastCalibrationDate"
			Me.mcLastCalibrationDate.TabIndex = 3
			'
			'label2
			'
			Me.label2.AutoSize = true
			Me.label2.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
			Me.label2.Location = New System.Drawing.Point(496, 16)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(124, 17)
			Me.label2.TabIndex = 5
			Me.label2.Text = "Last Calibration Date"
			'
			'label1
			'
			Me.label1.AutoSize = true
			Me.label1.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
			Me.label1.Location = New System.Drawing.Point(496, 200)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(84, 17)
			Me.label1.TabIndex = 4
			Me.label1.Text = "Asset Number"
			'
			'dataGrid1
			'
			Me.dataGrid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
						Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
			Me.dataGrid1.DataMember = ""
			Me.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
			Me.dataGrid1.Location = New System.Drawing.Point(8, 8)
			Me.dataGrid1.Name = "dataGrid1"
			Me.dataGrid1.Size = New System.Drawing.Size(480, 384)
			Me.dataGrid1.TabIndex = 0
			'
			'PowerSensorOldCalibrationResultsForm
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(728, 397)
			Me.Controls.Add(Me.btnOK)
			Me.Controls.Add(Me.mcLastCalibrationDate)
			Me.Controls.Add(Me.tbAssetNumber)
			Me.Controls.Add(Me.button1)
			Me.Controls.Add(Me.dataGrid1)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.label2)
			Me.Name = "PowerSensorOldCalibrationResultsForm"
			Me.Text = "PowerSensorOldCalibrationResultsForm"
			CType(Me.dataGrid1,System.ComponentModel.ISupportInitialize).EndInit
			Me.ResumeLayout(false)
		End Sub
		#End Region
		
		Private Sub Button1Click(sender As System.Object, e As System.EventArgs)
			If Not Me.tbAssetNumber.Text = "" Then
				Me.dataGrid1.DataSource = PowerSensorTestResultsTable.GetOldCalibrationResults(Me.tbAssetNumber.Text, Me.mcLastCalibrationDate.SelectionRange.Start)
			End If
		End Sub
		
		Private Sub BtnOKClick(sender As System.Object, e As System.EventArgs)
			Me.OldResults = CType(Me.dataGrid1.DataSource, PowerSensorTestResultsTable)
			Me.Close
		End Sub
		
	End Class

