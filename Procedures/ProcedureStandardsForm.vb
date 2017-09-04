'
' Created by SharpDevelop.
' User: Administrator
' Date: 6/12/2005
' Time: 7:03 AM
' 


Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Reflection
Imports FreeCal.Common
Imports FreeCal.Instruments.SignalGenerators


	
	Public Class ProcedureStandardsForm
		Inherits System.Windows.Forms.Form
		Private FCResources As String = "FreeCal.Instruments."
		Private label3 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label1 As System.Windows.Forms.Label
		Private lablel1 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private cboDUTSignalGenerator As System.Windows.Forms.ComboBox
		Private label4 As System.Windows.Forms.Label
		Private btnCancel As System.Windows.Forms.Button
		Private cboAudioAnalyzer As System.Windows.Forms.ComboBox
		Private cboSpectrumAnalyzer As System.Windows.Forms.ComboBox
		Private button1 As System.Windows.Forms.Button
		Private cboPowerMeter As System.Windows.Forms.ComboBox
		Private cboMeasuringReceiver As System.Windows.Forms.ComboBox
		Private cboHighFrequencySignalGenerator As System.Windows.Forms.ComboBox

		Public SelectedDUTSignalGenerator As String
		Public SelectedSignalGenerator As String
		Public SelectedMeasuringReceiver As String
		Public SelectedSpectrumAnalyzer As String
		Public SelectedAudioAnalyzer As String
		Public SelectedPowerMeter As String

		Public Sub New()
			MyBase.New
			'
			' The Me.InitializeComponent call is required for Windows Forms designer support.
			'
			Me.InitializeComponent
			Me.FillComboBoxes
		End Sub
		
		#Region " Windows Forms Designer generated code "
		' This method is required for Windows Forms designer support.
		' Do not change the method contents inside the source code editor. The Forms designer might
		' not be able to load this method if it was changed manually.
		Private Sub InitializeComponent()
			Me.cboHighFrequencySignalGenerator = New System.Windows.Forms.ComboBox
			Me.cboMeasuringReceiver = New System.Windows.Forms.ComboBox
			Me.cboPowerMeter = New System.Windows.Forms.ComboBox
			Me.button1 = New System.Windows.Forms.Button
			Me.cboSpectrumAnalyzer = New System.Windows.Forms.ComboBox
			Me.cboAudioAnalyzer = New System.Windows.Forms.ComboBox
			Me.btnCancel = New System.Windows.Forms.Button
			Me.label4 = New System.Windows.Forms.Label
			Me.cboDUTSignalGenerator = New System.Windows.Forms.ComboBox
			Me.label5 = New System.Windows.Forms.Label
			Me.lablel1 = New System.Windows.Forms.Label
			Me.label1 = New System.Windows.Forms.Label
			Me.label2 = New System.Windows.Forms.Label
			Me.label3 = New System.Windows.Forms.Label
			Me.SuspendLayout
			'
			'cboHighFrequencySignalGenerator
			'
			Me.cboHighFrequencySignalGenerator.Location = New System.Drawing.Point(8, 112)
			Me.cboHighFrequencySignalGenerator.Name = "cboHighFrequencySignalGenerator"
			Me.cboHighFrequencySignalGenerator.Size = New System.Drawing.Size(128, 21)
			Me.cboHighFrequencySignalGenerator.TabIndex = 0
			'
			'cboMeasuringReceiver
			'
			Me.cboMeasuringReceiver.Location = New System.Drawing.Point(176, 48)
			Me.cboMeasuringReceiver.Name = "cboMeasuringReceiver"
			Me.cboMeasuringReceiver.Size = New System.Drawing.Size(128, 21)
			Me.cboMeasuringReceiver.TabIndex = 6
			'
			'cboPowerMeter
			'
			Me.cboPowerMeter.Location = New System.Drawing.Point(8, 176)
			Me.cboPowerMeter.Name = "cboPowerMeter"
			Me.cboPowerMeter.Size = New System.Drawing.Size(128, 21)
			Me.cboPowerMeter.TabIndex = 4
			'
			'button1
			'
			Me.button1.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.button1.Location = New System.Drawing.Point(40, 240)
			Me.button1.Name = "button1"
			Me.button1.TabIndex = 12
			Me.button1.Text = "OK"
			AddHandler Me.button1.Click, AddressOf Me.Button1Click
			'
			'cboSpectrumAnalyzer
			'
			Me.cboSpectrumAnalyzer.Location = New System.Drawing.Point(176, 112)
			Me.cboSpectrumAnalyzer.Name = "cboSpectrumAnalyzer"
			Me.cboSpectrumAnalyzer.Size = New System.Drawing.Size(128, 21)
			Me.cboSpectrumAnalyzer.TabIndex = 8
			'
			'cboAudioAnalyzer
			'
			Me.cboAudioAnalyzer.Location = New System.Drawing.Point(176, 176)
			Me.cboAudioAnalyzer.Name = "cboAudioAnalyzer"
			Me.cboAudioAnalyzer.Size = New System.Drawing.Size(128, 21)
			Me.cboAudioAnalyzer.TabIndex = 10
			'
			'btnCancel
			'
			Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.btnCancel.Location = New System.Drawing.Point(192, 240)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.TabIndex = 13
			Me.btnCancel.Text = "Cancel"
			AddHandler Me.btnCancel.Click, AddressOf Me.BtnCancelClick
			'
			'label4
			'
			Me.label4.AutoSize = true
			Me.label4.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0,Byte))
			Me.label4.Location = New System.Drawing.Point(176, 88)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(112, 17)
			Me.label4.TabIndex = 9
			Me.label4.Text = "Spectrum Analyzer"
			'
			'cboDUTSignalGenerator
			'
			Me.cboDUTSignalGenerator.Location = New System.Drawing.Point(8, 48)
			Me.cboDUTSignalGenerator.Name = "cboDUTSignalGenerator"
			Me.cboDUTSignalGenerator.Size = New System.Drawing.Size(128, 21)
			Me.cboDUTSignalGenerator.TabIndex = 2
			'
			'label5
			'
			Me.label5.AutoSize = true
			Me.label5.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0,Byte))
			Me.label5.Location = New System.Drawing.Point(176, 152)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(89, 17)
			Me.label5.TabIndex = 11
			Me.label5.Text = "Audio Analyzer"
			'
			'lablel1
			'
			Me.lablel1.AutoSize = true
			Me.lablel1.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0,Byte))
			Me.lablel1.Location = New System.Drawing.Point(8, 88)
			Me.lablel1.Name = "lablel1"
			Me.lablel1.TabIndex = 1
			Me.lablel1.Text = "Signal Generator"
			'
			'label1
			'
			Me.label1.AutoSize = true
			Me.label1.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0,Byte))
			Me.label1.Location = New System.Drawing.Point(8, 24)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(127, 17)
			Me.label1.TabIndex = 3
			Me.label1.Text = "DUT Signal Generator"
			'
			'label2
			'
			Me.label2.AutoSize = true
			Me.label2.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0,Byte))
			Me.label2.Location = New System.Drawing.Point(8, 152)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(77, 17)
			Me.label2.TabIndex = 5
			Me.label2.Text = "Power Meter"
			'
			'label3
			'
			Me.label3.AutoSize = true
			Me.label3.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0,Byte))
			Me.label3.Location = New System.Drawing.Point(176, 24)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(116, 17)
			Me.label3.TabIndex = 7
			Me.label3.Text = "Measuring Receiver"
			'
			'ProcedureStandardsForm
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(320, 277)
			Me.Controls.Add(Me.btnCancel)
			Me.Controls.Add(Me.button1)
			Me.Controls.Add(Me.cboAudioAnalyzer)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.cboSpectrumAnalyzer)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.cboMeasuringReceiver)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.cboPowerMeter)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.cboDUTSignalGenerator)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.cboHighFrequencySignalGenerator)
			Me.Controls.Add(Me.lablel1)
			Me.Name = "ProcedureStandardsForm"
			Me.Text = "ProcedureStandardsForm"
			Me.ResumeLayout(false)
		End Sub
		#End Region

		Public Sub FillComboBoxes
			Dim SignalGeneratorAssembly As [Assembly] = [Assembly].LoadFrom(Me.FCResources & "Microwave.SignalGenerators.dll")
			For Each Res As [Type] In SignalGeneratorAssembly.GetTypes
				Try
					If Res.BaseType.Name = "SignalGenerator" Then
						Me.cboDUTSignalGenerator.Items.Add(Res.Name)
						Me.cboHighFrequencySignalGenerator.Items.Add(Res.Name)
					End If
				Catch Ex As Exception
					MessageBox.Show(Ex.ToString)
				End Try
			Next
			SignalGeneratorAssembly = Nothing
			Dim PowerMeterAssembly As [Assembly] = [Assembly].LoadFrom(Me.FCResources & "Microwave.PowerMeters.dll")
			For Each Res As [Type] In PowerMeterAssembly.GetTypes
				Try
					If Res.BaseType.Name = "PowerMeter" Then
						Me.cboPowerMeter.Items.Add(Res.Name)
					End If
				Catch Ex As Exception
					MessageBox.Show(Ex.ToString)
				End Try
			Next
			PowerMeterAssembly = Nothing
			Dim MeasuringReceiverAssembly As [Assembly] = [Assembly].LoadFrom(Me.FCResources & "Microwave.MeasuringReceivers.dll")
			For Each Res As [Type] In MeasuringReceiverAssembly.GetTypes
				Try
					If Res.BaseType.Name = "MeasuringReceiver" Then
						Me.cboMeasuringReceiver.Items.Add(Res.Name)
					End If
				Catch Ex As Exception
					MessageBox.Show(Ex.ToString)
				End Try
			Next
			MeasuringReceiverAssembly = Nothing
			Dim SpectrumAnalyzerAssembly As [Assembly] = [Assembly].LoadFrom(Me.FCResources & "Microwave.SpectrumAnalyzers.dll")
			For Each Res As [Type] In SpectrumAnalyzerAssembly.GetTypes
				Try
					If Res.BaseType.Name = "SpectrumAnalyzer" Then
						Me.cboSpectrumAnalyzer.Items.Add(Res.Name)
					End If
				Catch Ex As Exception
					MessageBox.Show(Ex.ToString)
				End Try
			Next
			SpectrumAnalyzerAssembly = Nothing
			Dim AudioAnalyzerAssembly As [Assembly] = [Assembly].LoadFrom(Me.FCResources & "GeneralPurpose.AudioAnalyzers.dll")
			For Each Res As [Type] In AudioAnalyzerAssembly.GetTypes
				Try
					If Res.BaseType.Name = "AudioAnalyzer" Then
						Me.cboAudioAnalyzer.Items.Add(Res.Name)
					End If
				Catch Ex As Exception
					MessageBox.Show(Ex.ToString)
				End Try
			Next
			AudioAnalyzerAssembly = Nothing
			Me.cboAudioAnalyzer.SelectedIndex = 0
			Me.cboDUTSignalGenerator.SelectedIndex = 0
			Me.cboHighFrequencySignalGenerator.SelectedIndex = 0
			Me.cboMeasuringReceiver.SelectedIndex = 0
			Me.cboPowerMeter.SelectedIndex = 0
			Me.cboSpectrumAnalyzer.SelectedIndex = 0
		End Sub
		
		Private Sub Button1Click(sender As System.Object, e As System.EventArgs)
			Me.SelectedDUTSignalGenerator = Me.cboDUTSignalGenerator.SelectedItem
			Me.SelectedSignalGenerator = Me.cboHighFrequencySignalGenerator.SelectedItem
			Me.SelectedMeasuringReceiver = Me.cboMeasuringReceiver.SelectedItem
			Me.SelectedSpectrumAnalyzer = Me.cboSpectrumAnalyzer.SelectedItem
			Me.SelectedAudioAnalyzer = Me.cboAudioAnalyzer.SelectedItem
			Me.SelectedPowerMeter = Me.cboPowerMeter.SelectedItem
			Me.Close
		End Sub
		
		Private Sub BtnCancelClick(sender As System.Object, e As System.EventArgs)
			Me.Close
		End Sub
		
	End Class

