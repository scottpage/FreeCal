'
' Created by SharpDevelop.
' User: rspage
' Date: 6/23/2005
' Time: 3:36 PM
' 



Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports FreeCal.Common
Imports FreeCal.Instruments
Imports FreeCal.Instruments.PowerMeters


	
	Public Class PowerSensorProcedureStdRefSNForm
		Inherits System.Windows.Forms.Form
		Protected _SelectedStandardSensorSerialNumber As String
		Protected _SelectedReferenceSensorSerialNumber As String
		Private label2 As System.Windows.Forms.Label
		Private btnOk As System.Windows.Forms.Button
		Private btnCancel As System.Windows.Forms.Button
		Private cbReference As System.Windows.Forms.ComboBox
		Private label1 As System.Windows.Forms.Label
		Private cbStandard As System.Windows.Forms.ComboBox

		Public Property SelectedReferenceSensorSerialNumber As String
			Get
				Return Me._SelectedReferenceSensorSerialNumber
			End Get
			Set
				Me._SelectedReferenceSensorSerialNumber = Value
			End Set
		End Property

		Public Property SelectedStandardSensorSerialNumber As String
			Get
				Return Me._SelectedStandardSensorSerialNumber
			End Get
			Set
				Me._SelectedStandardSensorSerialNumber = Value
			End Set
		End Property

		Public Sub New(ByVal serialNumbers() As String)
			MyBase.New
			'
			' The Me.InitializeComponent call is required for Windows Forms designer support.
			'
			Me.InitializeComponent
			'Me.MdiParent = MDIParentForm
			For Each Table As String In SerialNumbers
				Me.cbStandard.Items.Add(Table)
				Me.cbReference.Items.Add(Table)
			Next
			If Me.cbStandard.Items.Count > 0 Then Me.cbStandard.SelectedIndex = 0
			If Me.cbReference.Items.Count > 0 Then Me.cbReference.SelectedIndex = 0
		End Sub
		
		#Region " Windows Forms Designer generated code "
		' This method is required for Windows Forms designer support.
		' Do not change the method contents inside the source code editor. The Forms designer might
		' not be able to load this method if it was changed manually.
		Private Sub InitializeComponent()
			Me.cbStandard = New System.Windows.Forms.ComboBox
			Me.label1 = New System.Windows.Forms.Label
			Me.cbReference = New System.Windows.Forms.ComboBox
			Me.btnCancel = New System.Windows.Forms.Button
			Me.btnOk = New System.Windows.Forms.Button
			Me.label2 = New System.Windows.Forms.Label
			Me.SuspendLayout
			'
			'cbStandard
			'
			Me.cbStandard.Location = New System.Drawing.Point(16, 24)
			Me.cbStandard.Name = "cbStandard"
			Me.cbStandard.Size = New System.Drawing.Size(121, 21)
			Me.cbStandard.TabIndex = 0
			'
			'label1
			'
			Me.label1.AutoSize = true
			Me.label1.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
			Me.label1.Location = New System.Drawing.Point(16, 8)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(117, 17)
			Me.label1.TabIndex = 4
			Me.label1.Text = "Standard Sensor SN"
			'
			'cbReference
			'
			Me.cbReference.Location = New System.Drawing.Point(160, 24)
			Me.cbReference.Name = "cbReference"
			Me.cbReference.Size = New System.Drawing.Size(121, 21)
			Me.cbReference.TabIndex = 3
			'
			'btnCancel
			'
			Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.btnCancel.Location = New System.Drawing.Point(168, 64)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.TabIndex = 2
			Me.btnCancel.Text = "Cancel"
			AddHandler Me.btnCancel.Click, AddressOf Me.BtnCancelClick
			'
			'btnOk
			'
			Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.btnOk.Location = New System.Drawing.Point(56, 64)
			Me.btnOk.Name = "btnOk"
			Me.btnOk.TabIndex = 1
			Me.btnOk.Text = "OK"
			AddHandler Me.btnOk.Click, AddressOf Me.BtnOkClick
			'
			'label2
			'
			Me.label2.AutoSize = true
			Me.label2.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
			Me.label2.Location = New System.Drawing.Point(160, 8)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(123, 17)
			Me.label2.TabIndex = 5
			Me.label2.Text = "Reference Sensor SN"
			'
			'PowerSensorProcedureStdRefSNForm
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(296, 109)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.cbReference)
			Me.Controls.Add(Me.btnCancel)
			Me.Controls.Add(Me.btnOk)
			Me.Controls.Add(Me.cbStandard)
			Me.Controls.Add(Me.label1)
			Me.Name = "PowerSensorProcedureStdRefSNForm"
			Me.Text = "PowerSensorProcedureStdRefSNForm"
			Me.ResumeLayout(false)
		End Sub
		#End Region

		Private Sub BtnOkClick(sender As System.Object, e As System.EventArgs)
			Me.SelectedReferenceSensorSerialNumber = Me.cbReference.SelectedItem
			Me.SelectedStandardSensorSerialNumber = Me.cbStandard.SelectedItem
		End Sub

		Private Sub BtnCancelClick(sender As System.Object, e As System.EventArgs)
			Me.Close
		End Sub

	End Class

