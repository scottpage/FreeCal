'
' Created by SharpDevelop.
' User: Scott Page
' Date: 6/1/2005
' Time: 6:21 PM
' 

Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports NationalInstruments.NI4882
Imports FreeCal.Common



Public Class SignalGeneratorProcedureForm
    Inherits System.Windows.Forms.Form
    Private Standards As New ProcedureStandardsForm
    Private label3 As System.Windows.Forms.Label
    Private button2 As System.Windows.Forms.Button
    Private label1 As System.Windows.Forms.Label
    Private nudBusAddress As System.Windows.Forms.NumericUpDown
    Private cboTests As System.Windows.Forms.ComboBox
    Private label4 As System.Windows.Forms.Label
    Private dataGrid1 As System.Windows.Forms.DataGrid
    Private tbDUTAssetNumber As System.Windows.Forms.TextBox
    Private button3 As System.Windows.Forms.Button
    Private chkSimulate As System.Windows.Forms.CheckBox
    Private button1 As System.Windows.Forms.Button
    Private label2 As System.Windows.Forms.Label
    Private comboBox1 As System.Windows.Forms.ComboBox

    Public Shared Sub Main()
        Dim fMainForm As New SignalGeneratorProcedureForm
        fMainForm.ShowDialog()
    End Sub

    Public Sub New()
        MyBase.New
        '
        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        '
        Me.InitializeComponent()
        Me.Standards.MdiParent = Me.MdiParent
    End Sub

    Public Sub New(ByVal parent As Form)
        MyBase.New
        '
        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        '
        Me.InitializeComponent()
        Me.MdiParent = parent
        Me.FillComboBoxes()
    End Sub

#Region " Windows Forms Designer generated code "
    ' This method is required for Windows Forms designer support.
    ' Do not change the method contents inside the source code editor. The Forms designer might
    ' not be able to load this method if it was changed manually.
    Private Sub InitializeComponent()
        Me.comboBox1 = New System.Windows.Forms.ComboBox
        Me.label2 = New System.Windows.Forms.Label
        Me.button1 = New System.Windows.Forms.Button
        Me.chkSimulate = New System.Windows.Forms.CheckBox
        Me.button3 = New System.Windows.Forms.Button
        Me.tbDUTAssetNumber = New System.Windows.Forms.TextBox
        Me.dataGrid1 = New System.Windows.Forms.DataGrid
        Me.label4 = New System.Windows.Forms.Label
        Me.cboTests = New System.Windows.Forms.ComboBox
        Me.nudBusAddress = New System.Windows.Forms.NumericUpDown
        Me.label1 = New System.Windows.Forms.Label
        Me.button2 = New System.Windows.Forms.Button
        Me.label3 = New System.Windows.Forms.Label
        CType(Me.dataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudBusAddress, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'comboBox1
        '
        Me.comboBox1.Location = New System.Drawing.Point(152, 32)
        Me.comboBox1.Name = "comboBox1"
        Me.comboBox1.Size = New System.Drawing.Size(121, 21)
        Me.comboBox1.TabIndex = 19
        Me.comboBox1.Text = "comboBox1"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.label2.Location = New System.Drawing.Point(128, 64)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(142, 17)
        Me.label2.TabIndex = 13
        Me.label2.Text = "Instrument Bus Number"
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(160, 240)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(88, 23)
        Me.button1.TabIndex = 7
        Me.button1.Text = "Run All Tests"
        AddHandler Me.button1.Click, AddressOf Me.Button1Click
        '
        'chkSimulate
        '
        Me.chkSimulate.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.chkSimulate.Location = New System.Drawing.Point(8, 64)
        Me.chkSimulate.Name = "chkSimulate"
        Me.chkSimulate.Size = New System.Drawing.Size(112, 40)
        Me.chkSimulate.TabIndex = 20
        Me.chkSimulate.Text = "Simulate Communication"
        '
        'button3
        '
        Me.button3.Location = New System.Drawing.Point(112, 136)
        Me.button3.Name = "button3"
        Me.button3.TabIndex = 18
        Me.button3.Text = "Standards"
        AddHandler Me.button3.Click, AddressOf Me.Button3Click
        '
        'tbDUTAssetNumber
        '
        Me.tbDUTAssetNumber.Location = New System.Drawing.Point(8, 32)
        Me.tbDUTAssetNumber.Name = "tbDUTAssetNumber"
        Me.tbDUTAssetNumber.Size = New System.Drawing.Size(136, 20)
        Me.tbDUTAssetNumber.TabIndex = 2
        Me.tbDUTAssetNumber.Text = ""
        '
        'dataGrid1
        '
        Me.dataGrid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dataGrid1.DataMember = ""
        Me.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dataGrid1.Location = New System.Drawing.Point(280, 8)
        Me.dataGrid1.Name = "dataGrid1"
        Me.dataGrid1.Size = New System.Drawing.Size(608, 480)
        Me.dataGrid1.TabIndex = 17
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.label4.Location = New System.Drawing.Point(128, 192)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(34, 17)
        Me.label4.TabIndex = 15
        Me.label4.Text = "Tests"
        '
        'cboTests
        '
        Me.cboTests.Items.AddRange(New Object() {"High Amplitude Accuracy", "Attenuator Accuracy", "Carrier Frequency Accuracy", "Residual AM", "AM Modulation", "3dB Bandwidth", "Residual FM", "FM Indicator Accuracy", "FM Distortion", "FM Carrier Frequency Accuracy", "Frequency Accuracy", "Harmonics", "Sub Harmonics"})
        Me.cboTests.Location = New System.Drawing.Point(40, 208)
        Me.cboTests.Name = "cboTests"
        Me.cboTests.Size = New System.Drawing.Size(224, 21)
        Me.cboTests.TabIndex = 9
        Me.cboTests.Text = "Attenuator Accuracy"
        '
        'nudBusAddress
        '
        Me.nudBusAddress.Location = New System.Drawing.Point(176, 80)
        Me.nudBusAddress.Maximum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.nudBusAddress.Name = "nudBusAddress"
        Me.nudBusAddress.Size = New System.Drawing.Size(48, 20)
        Me.nudBusAddress.TabIndex = 5
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.label1.Location = New System.Drawing.Point(24, 16)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(111, 17)
        Me.label1.TabIndex = 12
        Me.label1.Text = "DUT Asset Number"
        '
        'button2
        '
        Me.button2.Location = New System.Drawing.Point(56, 240)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(88, 23)
        Me.button2.TabIndex = 10
        Me.button2.Text = "Run One Test"
        AddHandler Me.button2.Click, AddressOf Me.Button2Click
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.label3.Location = New System.Drawing.Point(168, 16)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(77, 17)
        Me.label3.TabIndex = 14
        Me.label3.Text = "DUT Address"
        '
        'SignalGeneratorProcedureForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(896, 493)
        Me.Controls.Add(Me.chkSimulate)
        Me.Controls.Add(Me.comboBox1)
        Me.Controls.Add(Me.button3)
        Me.Controls.Add(Me.dataGrid1)
        Me.Controls.Add(Me.button2)
        Me.Controls.Add(Me.cboTests)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.nudBusAddress)
        Me.Controls.Add(Me.tbDUTAssetNumber)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label4)
        Me.Name = "SignalGeneratorProcedureForm"
        Me.Text = "Signal Generator Calibration"
        CType(Me.dataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudBusAddress, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub
#End Region

    Private Sub FillComboBoxes()
        Me.comboBox1.DataSource = GetGPIBBusAddresses(CType([Enum].Parse(GetType(Boards), 0.ToString), Boards))
        If Me.comboBox1.Items.Count > 0 Then
            Me.comboBox1.SelectedIndex = 0
        End If
    End Sub

    Private Sub Button1Click(sender As System.Object, e As System.EventArgs)
        Dim NewSignalGeneratorProcedure As New SignalGeneratorProcedure(Me.tbDUTAssetNumber.Text) With {
            .DUTAddress = Convert.ToByte(Me.comboBox1.SelectedItem),
            .DUTBusNumber = Convert.ToInt32(Me.nudBusAddress.Value),
            .DUTAssetNumber = Me.tbDUTAssetNumber.Text
        }
        NewSignalGeneratorProcedure.AllTests()
    End Sub

    Private Sub Button2Click(sender As System.Object, e As System.EventArgs)
        'Me.dataGrid1.DataSource = NewSignalGeneratorProcedure.CurrentTestResults
        Dim NewSignalGeneratorProcedure As New SignalGeneratorProcedure(Me.tbDUTAssetNumber.Text) With {
            .DUTAddress = Convert.ToByte(Me.comboBox1.SelectedItem),
            .DUTBusNumber = Convert.ToInt32(Me.nudBusAddress.Value),
            .dgResults = Me.dataGrid1,
            .SelectedAudioAnalyzer = Me.Standards.SelectedAudioAnalyzer,
            .SelectedDUTSignalGenerator = Me.Standards.SelectedDUTSignalGenerator,
            .SelectedMeasuringReceiver = Me.Standards.SelectedMeasuringReceiver,
            .SelectedPowerMeter = Me.Standards.SelectedPowerMeter,
            .SelectedSignalGenerator = Me.Standards.SelectedSignalGenerator,
            .SelectedSpectrumAnalyzer = Me.Standards.SelectedSpectrumAnalyzer,
            .Simulate = Me.chkSimulate.Checked
        }

        Select Case Me.cboTests.Text
            Case "High Amplitude Accuracy"
                NewSignalGeneratorProcedure.HighAmplitudeAccuracyTest()
            Case "Attenuator Accuracy"
                NewSignalGeneratorProcedure.AttenuatorAccuracyTest()
            Case "Carrier Frequency Accuracy"
                NewSignalGeneratorProcedure.CarrierFrequencyAccuracyTest()
            Case "Residual AM"
                NewSignalGeneratorProcedure.ResidualAMTest()
            Case "AM Modulation"
                NewSignalGeneratorProcedure.AMModulationTest()
            Case "Harmonics"
                NewSignalGeneratorProcedure.HarmonicsTest()
            Case "Sub Harmonics"
                NewSignalGeneratorProcedure.SubHarmonicsTest()
        End Select
    End Sub

    Private Sub Button3Click(sender As System.Object, e As System.EventArgs)
        Me.Standards.StartPosition = FormStartPosition.CenterScreen
        Me.Standards.ShowDialog()
    End Sub

End Class

