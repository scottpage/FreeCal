'
' Created by SharpDevelop.
' User: rspage
' Date: 6/29/2005
' Time: 12:55 PM
' 



Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Data
Imports FreeCal.Common

	
	Public Class StepAttenuatorTestResultsForm
		Inherits System.Windows.Forms.Form
		Private tbMaxAttenuation As System.Windows.Forms.TextBox
		Private btnTest As System.Windows.Forms.Button
		Private tbWaitTime As System.Windows.Forms.TextBox
		Private dgResults As System.Windows.Forms.DataGrid
		Private cbTestFrequencySuffix As System.Windows.Forms.ComboBox
		Private tbAssetNumber As System.Windows.Forms.TextBox
		Private tbTestFrequency As System.Windows.Forms.TextBox
		
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
			Me.tbTestFrequency = New System.Windows.Forms.TextBox
			Me.tbAssetNumber = New System.Windows.Forms.TextBox
			Me.cbTestFrequencySuffix = New System.Windows.Forms.ComboBox
			Me.dgResults = New System.Windows.Forms.DataGrid
			Me.tbWaitTime = New System.Windows.Forms.TextBox
			Me.btnTest = New System.Windows.Forms.Button
			Me.tbMaxAttenuation = New System.Windows.Forms.TextBox
			CType(Me.dgResults,System.ComponentModel.ISupportInitialize).BeginInit
			Me.SuspendLayout
			'
			'tbTestFrequency
			'
			Me.tbTestFrequency.Location = New System.Drawing.Point(8, 64)
			Me.tbTestFrequency.Name = "tbTestFrequency"
			Me.tbTestFrequency.TabIndex = 2
			Me.tbTestFrequency.Text = ""
			'
			'tbAssetNumber
			'
			Me.tbAssetNumber.Location = New System.Drawing.Point(8, 16)
			Me.tbAssetNumber.Name = "tbAssetNumber"
			Me.tbAssetNumber.Size = New System.Drawing.Size(168, 20)
			Me.tbAssetNumber.TabIndex = 6
			Me.tbAssetNumber.Text = ""
			'
			'cbTestFrequencySuffix
			'
			Me.cbTestFrequencySuffix.Items.AddRange(New Object() {"MHz", "GHz"})
			Me.cbTestFrequencySuffix.Location = New System.Drawing.Point(112, 64)
			Me.cbTestFrequencySuffix.Name = "cbTestFrequencySuffix"
			Me.cbTestFrequencySuffix.Size = New System.Drawing.Size(64, 21)
			Me.cbTestFrequencySuffix.TabIndex = 3
			Me.cbTestFrequencySuffix.Text = "MHz"
			'
			'dgResults
			'
			Me.dgResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
						Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
			Me.dgResults.DataMember = ""
			Me.dgResults.HeaderForeColor = System.Drawing.SystemColors.ControlText
			Me.dgResults.Location = New System.Drawing.Point(248, 8)
			Me.dgResults.Name = "dgResults"
			Me.dgResults.Size = New System.Drawing.Size(480, 480)
			Me.dgResults.TabIndex = 0
			'
			'tbWaitTime
			'
			Me.tbWaitTime.Location = New System.Drawing.Point(176, 128)
			Me.tbWaitTime.Name = "tbWaitTime"
			Me.tbWaitTime.Size = New System.Drawing.Size(32, 20)
			Me.tbWaitTime.TabIndex = 5
			Me.tbWaitTime.Text = "5"
			'
			'btnTest
			'
			Me.btnTest.Location = New System.Drawing.Point(72, 184)
			Me.btnTest.Name = "btnTest"
			Me.btnTest.TabIndex = 1
			Me.btnTest.Text = "Test"
			AddHandler Me.btnTest.Click, AddressOf Me.BtnTestClick
			'
			'tbMaxAttenuation
			'
			Me.tbMaxAttenuation.Location = New System.Drawing.Point(16, 128)
			Me.tbMaxAttenuation.Name = "tbMaxAttenuation"
			Me.tbMaxAttenuation.Size = New System.Drawing.Size(48, 20)
			Me.tbMaxAttenuation.TabIndex = 4
			Me.tbMaxAttenuation.Text = "110"
			'
			'StepAttenuatorTestResultsForm
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(736, 493)
			Me.Controls.Add(Me.tbAssetNumber)
			Me.Controls.Add(Me.tbWaitTime)
			Me.Controls.Add(Me.tbMaxAttenuation)
			Me.Controls.Add(Me.cbTestFrequencySuffix)
			Me.Controls.Add(Me.tbTestFrequency)
			Me.Controls.Add(Me.btnTest)
			Me.Controls.Add(Me.dgResults)
			Me.Name = "StepAttenuatorTestResultsForm"
			Me.Text = "StepAttenuatorTestResultsForm"
			CType(Me.dgResults,System.ComponentModel.ISupportInitialize).EndInit
			Me.ResumeLayout(false)
		End Sub
		#End Region
		
		Private Sub BtnTestClick(sender As System.Object, e As System.EventArgs)
			Dim Proc As New StepAttenuatorProcedure(Me.tbAssetNumber.Text, Me.dgResults)
			Proc.ResultForm = Me
			Dim FrequencySuffixes As FrequencyEnum
        Proc.MeasureDUT(CDbl(Me.tbTestFrequency.Text), CType([Enum].Parse(FrequencySuffixes.GetType, Me.cbTestFrequencySuffix.SelectedItem.ToString), FrequencyEnum), CDbl(Me.tbMaxAttenuation.Text), CInt(Me.tbWaitTime.Text))
    End Sub
		
	End Class

