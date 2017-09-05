'
' Created by SharpDevelop.
' User: rspage
' Date: 6/9/2005
' Time: 2:36 PM
' 

Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports NationalInstruments.NI4882


	
	Public Class SpectrumAnalyzerProcedureForm
		Inherits System.Windows.Forms.Form
		Private label3 As System.Windows.Forms.Label
		Private button2 As System.Windows.Forms.Button
		Private label1 As System.Windows.Forms.Label
		Private nudBusAddress As System.Windows.Forms.NumericUpDown
		Private cboTests As System.Windows.Forms.ComboBox
		Private label4 As System.Windows.Forms.Label
		Private tbDUTAssetNumber As System.Windows.Forms.TextBox
		Private cboDUTModel As System.Windows.Forms.ComboBox
		Private button1 As System.Windows.Forms.Button
		Private label2 As System.Windows.Forms.Label
		Private tbResults As System.Windows.Forms.TextBox
		Private nudDUTAddress As System.Windows.Forms.NumericUpDown
		Private checkBox1 As System.Windows.Forms.CheckBox
		
		Public Shared Sub Main
			Dim fMainForm As New SpectrumAnalyzerProcedureForm
			fMainForm.ShowDialog()
		End Sub
		
		Public Sub New()
			MyBase.New
			'
			' The Me.InitializeComponent call is required for Windows Forms designer support.
			'
			Me.InitializeComponent
		End Sub

		Public Sub New(ByVal parent As Form)
			MyBase.New
			'
			' The Me.InitializeComponent call is required for Windows Forms designer support.
			'
			Me.InitializeComponent
			Me.MdiParent = Parent
		End Sub

		#Region " Windows Forms Designer generated code "
		' This method is required for Windows Forms designer support.
		' Do not change the method contents inside the source code editor. The Forms designer might
		' not be able to load this method if it was changed manually.
		Private Sub InitializeComponent()
			Me.checkBox1 = New System.Windows.Forms.CheckBox
			Me.nudDUTAddress = New System.Windows.Forms.NumericUpDown
			Me.tbResults = New System.Windows.Forms.TextBox
			Me.label2 = New System.Windows.Forms.Label
			Me.button1 = New System.Windows.Forms.Button
			Me.cboDUTModel = New System.Windows.Forms.ComboBox
			Me.tbDUTAssetNumber = New System.Windows.Forms.TextBox
			Me.label4 = New System.Windows.Forms.Label
			Me.cboTests = New System.Windows.Forms.ComboBox
			Me.nudBusAddress = New System.Windows.Forms.NumericUpDown
			Me.label1 = New System.Windows.Forms.Label
			Me.button2 = New System.Windows.Forms.Button
			Me.label3 = New System.Windows.Forms.Label
			CType(Me.nudDUTAddress,System.ComponentModel.ISupportInitialize).BeginInit
			CType(Me.nudBusAddress,System.ComponentModel.ISupportInitialize).BeginInit
			Me.SuspendLayout
			'
			'checkBox1
			'
			Me.checkBox1.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
			Me.checkBox1.Location = New System.Drawing.Point(8, 160)
			Me.checkBox1.Name = "checkBox1"
			Me.checkBox1.Size = New System.Drawing.Size(144, 24)
			Me.checkBox1.TabIndex = 6
			Me.checkBox1.Text = "Calibrate Sensors?"
			'
			'nudDUTAddress
			'
			Me.nudDUTAddress.Location = New System.Drawing.Point(8, 128)
			Me.nudDUTAddress.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
			Me.nudDUTAddress.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
			Me.nudDUTAddress.Name = "nudDUTAddress"
			Me.nudDUTAddress.Size = New System.Drawing.Size(48, 20)
			Me.nudDUTAddress.TabIndex = 0
			Me.nudDUTAddress.Value = New Decimal(New Integer() {19, 0, 0, 0})
			'
			'tbResults
			'
			Me.tbResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
						Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
			Me.tbResults.Location = New System.Drawing.Point(288, 8)
			Me.tbResults.Multiline = true
			Me.tbResults.Name = "tbResults"
			Me.tbResults.ScrollBars = System.Windows.Forms.ScrollBars.Both
			Me.tbResults.Size = New System.Drawing.Size(448, 424)
			Me.tbResults.TabIndex = 11
			Me.tbResults.Text = ""
			Me.tbResults.WordWrap = false
			'
			'label2
			'
			Me.label2.AutoSize = true
			Me.label2.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
			Me.label2.Location = New System.Drawing.Point(8, 64)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(142, 17)
			Me.label2.TabIndex = 13
			Me.label2.Text = "Instrument Bus Number"
			'
			'button1
			'
			Me.button1.Location = New System.Drawing.Point(168, 240)
			Me.button1.Name = "button1"
			Me.button1.Size = New System.Drawing.Size(88, 23)
			Me.button1.TabIndex = 7
			Me.button1.Text = "Run All Tests"
			AddHandler Me.button1.Click, AddressOf Me.Button1Click
			'
			'cboDUTModel
			'
			Me.cboDUTModel.Items.AddRange(New Object() {"Agilent 8643A", "IFR 2050"})
			Me.cboDUTModel.Location = New System.Drawing.Point(8, 296)
			Me.cboDUTModel.Name = "cboDUTModel"
			Me.cboDUTModel.Size = New System.Drawing.Size(121, 21)
			Me.cboDUTModel.TabIndex = 16
			Me.cboDUTModel.Text = "IFR 2050"
			'
			'tbDUTAssetNumber
			'
			Me.tbDUTAssetNumber.Location = New System.Drawing.Point(8, 32)
			Me.tbDUTAssetNumber.Name = "tbDUTAssetNumber"
			Me.tbDUTAssetNumber.Size = New System.Drawing.Size(136, 20)
			Me.tbDUTAssetNumber.TabIndex = 2
			Me.tbDUTAssetNumber.Text = ""
			'
			'label4
			'
			Me.label4.AutoSize = true
			Me.label4.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
			Me.label4.Location = New System.Drawing.Point(8, 192)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(34, 17)
			Me.label4.TabIndex = 15
			Me.label4.Text = "Tests"
			'
			'cboTests
			'
			Me.cboTests.Items.AddRange(New Object() {"Center Frequency Readout Accuracy", "Frequency Span Accuracy", "Resolution Bandwidth Accuracy", "First LO Output Amplitude"})
			Me.cboTests.Location = New System.Drawing.Point(8, 208)
			Me.cboTests.Name = "cboTests"
			Me.cboTests.Size = New System.Drawing.Size(232, 21)
			Me.cboTests.TabIndex = 9
			Me.cboTests.Text = "Center Frequency Readout Accuracy"
			'
			'nudBusAddress
			'
			Me.nudBusAddress.Location = New System.Drawing.Point(8, 80)
			Me.nudBusAddress.Maximum = New Decimal(New Integer() {3, 0, 0, 0})
			Me.nudBusAddress.Name = "nudBusAddress"
			Me.nudBusAddress.Size = New System.Drawing.Size(48, 20)
			Me.nudBusAddress.TabIndex = 5
			'
			'label1
			'
			Me.label1.AutoSize = true
			Me.label1.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
			Me.label1.Location = New System.Drawing.Point(8, 16)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(111, 17)
			Me.label1.TabIndex = 12
			Me.label1.Text = "DUT Asset Number"
			'
			'button2
			'
			Me.button2.Location = New System.Drawing.Point(8, 240)
			Me.button2.Name = "button2"
			Me.button2.Size = New System.Drawing.Size(88, 23)
			Me.button2.TabIndex = 10
			Me.button2.Text = "Run One Test"
			AddHandler Me.button2.Click, AddressOf Me.Button2Click
			'
			'label3
			'
			Me.label3.AutoSize = true
			Me.label3.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
			Me.label3.Location = New System.Drawing.Point(8, 112)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(77, 17)
			Me.label3.TabIndex = 14
			Me.label3.Text = "DUT Address"
			'
			'SpectrumAnalyzerProcedureForm
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(744, 437)
			Me.Controls.Add(Me.cboDUTModel)
			Me.Controls.Add(Me.tbResults)
			Me.Controls.Add(Me.button2)
			Me.Controls.Add(Me.cboTests)
			Me.Controls.Add(Me.button1)
			Me.Controls.Add(Me.checkBox1)
			Me.Controls.Add(Me.nudBusAddress)
			Me.Controls.Add(Me.tbDUTAssetNumber)
			Me.Controls.Add(Me.nudDUTAddress)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.label4)
			Me.Name = "SpectrumAnalyzerProcedureForm"
			Me.Text = "Agilent 8643A Calibration"
			CType(Me.nudDUTAddress,System.ComponentModel.ISupportInitialize).EndInit
			CType(Me.nudBusAddress,System.ComponentModel.ISupportInitialize).EndInit
			Me.ResumeLayout(false)
		End Sub
		#End Region
		
		Private Sub Button1Click(sender As System.Object, e As System.EventArgs)
			Dim NewSpectrumAnalyzerProcedure As New SpectrumAnalyzerProcedure(Me.tbDUTAssetNumber.Text)
        NewSpectrumAnalyzerProcedure.DUTAddress = Convert.ToByte(Me.nudDUTAddress.Value)
        NewSpectrumAnalyzerProcedure.DUTBusNumber = Convert.ToInt32(Me.nudBusAddress.Value)
        NewSpectrumAnalyzerProcedure.DUTAssetNumber = Me.tbDUTAssetNumber.Text
            NewSpectrumAnalyzerProcedure.AllTests
			If Me.cboDUTModel.Text = "Agilent 8643A" Then
	        ElseIf Me.cboDUTModel.Text = "IFR 2050" Then
			End If
		End Sub
		
		Private Sub Button2Click(sender As System.Object, e As System.EventArgs)
			Dim NewSpectrumAnalyzerProcedure As New SpectrumAnalyzerProcedure(Me.tbDUTAssetNumber.Text)
        NewSpectrumAnalyzerProcedure.DUTAddress = Convert.ToByte(Me.nudDUTAddress.Value)
        NewSpectrumAnalyzerProcedure.DUTBusNumber = Convert.ToInt32(Me.nudBusAddress.Value)
        NewSpectrumAnalyzerProcedure.DUTAssetNumber = Me.tbDUTAssetNumber.Text
			If Me.cboDUTModel.Text = "Agilent 8643A" Then
			ElseIf Me.cboDUTModel.Text = "IFR 2050" Then
			End If
			Select Me.cboTests.Text
				Case "Center Frequency Readout Accuracy"
					NewSpectrumAnalyzerProcedure.CenterFrequencyReadoutAccuracyTest
				Case "Frequency Span Accuracy"
					NewSpectrumAnalyzerProcedure.FrequencySpanAccuracyTest
				Case "Resolution Bandwidth Accuracy"
					NewSpectrumAnalyzerProcedure.ResolutionBandWidthAccuracyTest
				Case "First LO Output Amplitude"
					NewSpectrumAnalyzerProcedure.FirstLOOutputAmplitudeTest
			End Select
		End Sub
		
	End Class



