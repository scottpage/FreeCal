'
' Created by SharpDevelop.
' User: rspage
' Date: 6/15/2005
' Time: 12:44 PM
' 

Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Reflection
Imports FreeCal.Common
Imports FreeCal.Instruments.SignalGenerators



Public Class PowerSensorProcedureStandardsForm
    Inherits System.Windows.Forms.Form
    Private FCResources As String = ResourceDirectory & "\FreeCal.Instruments."
    Private nudStdDUTPowerMeter As System.Windows.Forms.NumericUpDown
    Private cboReferencePowerMeter As System.Windows.Forms.ComboBox
    Private cboHighFrequencySource As System.Windows.Forms.ComboBox
    Private button1 As System.Windows.Forms.Button
    Private cboAttenuatorSwitchDriver As System.Windows.Forms.ComboBox
    Private nudAttenuatorSwitchDriver As System.Windows.Forms.NumericUpDown
    Private btnCancel As System.Windows.Forms.Button
    Private cboStdDUTPowerMeter As System.Windows.Forms.ComboBox
    Private nudHighFrequencySource As System.Windows.Forms.NumericUpDown
    Private cboNetworkAnalyzer As System.Windows.Forms.ComboBox
    Private nudNetworkAnalyzer As System.Windows.Forms.NumericUpDown
    Private label3 As System.Windows.Forms.Label
    Private label2 As System.Windows.Forms.Label
    Private label1 As System.Windows.Forms.Label
    Private nudLowFrequencySource As System.Windows.Forms.NumericUpDown
    Private label5 As System.Windows.Forms.Label
    Private label4 As System.Windows.Forms.Label
    Private cboLowFrequencySource As System.Windows.Forms.ComboBox
    Private nudReferencePowerMeter As System.Windows.Forms.NumericUpDown
    Private lablel1 As System.Windows.Forms.Label

    Public SelectedHighFrequencySource As String = "Agilent8340B"
    Public SelectedLowFrequencySource As String = "Agilent3325B"
    Public SelectedStdDUTPowerMeter As String = "AgilentE4417A"
    Public SelectedReferencePowerMeter As String = "Agilent437B"
    Public SelectedNetworkAnalyzer As String = "Agilent8510C"
    Public SelectedAttenuatorSwitchDriver As String = "Agilent11713A"

    Public SelectedHighFrequencySourceAddress As Byte = 19
    Public SelectedLowFrequencySourceAddress As Byte = 11
    Public SelectedStdDUTPowerMeterAddress As Byte = 13
    Public SelectedReferencePowerMeterAddress As Byte = 25
    Public SelectedNetworkAnalyzerAddress As Byte = 16
    Public SelectedAttenuatorSwitchDriverAddress As Byte = 28

    Public Sub New()
        MyBase.New
        '
        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        '
        Me.InitializeComponent()
        Me.FillComboBoxes()
    End Sub

#Region " Windows Forms Designer generated code "
    ' This method is required for Windows Forms designer support.
    ' Do not change the method contents inside the source code editor. The Forms designer might
    ' not be able to load this method if it was changed manually.
    Private Sub InitializeComponent()
        Me.lablel1 = New System.Windows.Forms.Label
        Me.nudReferencePowerMeter = New System.Windows.Forms.NumericUpDown
        Me.cboLowFrequencySource = New System.Windows.Forms.ComboBox
        Me.label4 = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.nudLowFrequencySource = New System.Windows.Forms.NumericUpDown
        Me.label1 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.nudNetworkAnalyzer = New System.Windows.Forms.NumericUpDown
        Me.cboNetworkAnalyzer = New System.Windows.Forms.ComboBox
        Me.nudHighFrequencySource = New System.Windows.Forms.NumericUpDown
        Me.cboStdDUTPowerMeter = New System.Windows.Forms.ComboBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.nudAttenuatorSwitchDriver = New System.Windows.Forms.NumericUpDown
        Me.cboAttenuatorSwitchDriver = New System.Windows.Forms.ComboBox
        Me.button1 = New System.Windows.Forms.Button
        Me.cboHighFrequencySource = New System.Windows.Forms.ComboBox
        Me.cboReferencePowerMeter = New System.Windows.Forms.ComboBox
        Me.nudStdDUTPowerMeter = New System.Windows.Forms.NumericUpDown
        CType(Me.nudReferencePowerMeter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudLowFrequencySource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudNetworkAnalyzer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudHighFrequencySource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudAttenuatorSwitchDriver, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudStdDUTPowerMeter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lablel1
        '
        Me.lablel1.AutoSize = True
        Me.lablel1.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.lablel1.Location = New System.Drawing.Point(8, 88)
        Me.lablel1.Name = "lablel1"
        Me.lablel1.Size = New System.Drawing.Size(195, 17)
        Me.lablel1.TabIndex = 1
        Me.lablel1.Text = "Low Frequency Source (<10MHz)"
        '
        'nudReferencePowerMeter
        '
        Me.nudReferencePowerMeter.Location = New System.Drawing.Point(384, 48)
        Me.nudReferencePowerMeter.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.nudReferencePowerMeter.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudReferencePowerMeter.Name = "nudReferencePowerMeter"
        Me.nudReferencePowerMeter.Size = New System.Drawing.Size(48, 20)
        Me.nudReferencePowerMeter.TabIndex = 16
        Me.nudReferencePowerMeter.Value = New Decimal(New Integer() {25, 0, 0, 0})
        '
        'cboLowFrequencySource
        '
        Me.cboLowFrequencySource.Location = New System.Drawing.Point(8, 112)
        Me.cboLowFrequencySource.Name = "cboLowFrequencySource"
        Me.cboLowFrequencySource.Size = New System.Drawing.Size(128, 21)
        Me.cboLowFrequencySource.TabIndex = 0
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.label4.Location = New System.Drawing.Point(248, 88)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(106, 17)
        Me.label4.TabIndex = 9
        Me.label4.Text = "Network Analyzer"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.label5.Location = New System.Drawing.Point(248, 152)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(150, 17)
        Me.label5.TabIndex = 11
        Me.label5.Text = "Attenuator/Switch Driver"
        '
        'nudLowFrequencySource
        '
        Me.nudLowFrequencySource.Location = New System.Drawing.Point(144, 112)
        Me.nudLowFrequencySource.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.nudLowFrequencySource.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudLowFrequencySource.Name = "nudLowFrequencySource"
        Me.nudLowFrequencySource.Size = New System.Drawing.Size(48, 20)
        Me.nudLowFrequencySource.TabIndex = 15
        Me.nudLowFrequencySource.Value = New Decimal(New Integer() {11, 0, 0, 0})
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.label1.Location = New System.Drawing.Point(8, 24)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(207, 17)
        Me.label1.TabIndex = 3
        Me.label1.Text = "High Frequency Source (>=10MHz)"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.label2.Location = New System.Drawing.Point(8, 152)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(130, 17)
        Me.label2.TabIndex = 5
        Me.label2.Text = "Std/DUT Power Meter"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.label3.Location = New System.Drawing.Point(248, 24)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(138, 17)
        Me.label3.TabIndex = 7
        Me.label3.Text = "Reference Power Meter"
        '
        'nudNetworkAnalyzer
        '
        Me.nudNetworkAnalyzer.Location = New System.Drawing.Point(384, 112)
        Me.nudNetworkAnalyzer.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.nudNetworkAnalyzer.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudNetworkAnalyzer.Name = "nudNetworkAnalyzer"
        Me.nudNetworkAnalyzer.Size = New System.Drawing.Size(48, 20)
        Me.nudNetworkAnalyzer.TabIndex = 17
        Me.nudNetworkAnalyzer.Value = New Decimal(New Integer() {16, 0, 0, 0})
        '
        'cboNetworkAnalyzer
        '
        Me.cboNetworkAnalyzer.Location = New System.Drawing.Point(248, 112)
        Me.cboNetworkAnalyzer.Name = "cboNetworkAnalyzer"
        Me.cboNetworkAnalyzer.Size = New System.Drawing.Size(128, 21)
        Me.cboNetworkAnalyzer.TabIndex = 8
        '
        'nudHighFrequencySource
        '
        Me.nudHighFrequencySource.Location = New System.Drawing.Point(144, 48)
        Me.nudHighFrequencySource.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.nudHighFrequencySource.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudHighFrequencySource.Name = "nudHighFrequencySource"
        Me.nudHighFrequencySource.Size = New System.Drawing.Size(48, 20)
        Me.nudHighFrequencySource.TabIndex = 14
        Me.nudHighFrequencySource.Value = New Decimal(New Integer() {19, 0, 0, 0})
        '
        'cboStdDUTPowerMeter
        '
        Me.cboStdDUTPowerMeter.Location = New System.Drawing.Point(8, 176)
        Me.cboStdDUTPowerMeter.Name = "cboStdDUTPowerMeter"
        Me.cboStdDUTPowerMeter.Size = New System.Drawing.Size(128, 21)
        Me.cboStdDUTPowerMeter.TabIndex = 4
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(248, 224)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.TabIndex = 13
        Me.btnCancel.Text = "Cancel"
        AddHandler Me.btnCancel.Click, AddressOf Me.BtnCancelClick
        '
        'nudAttenuatorSwitchDriver
        '
        Me.nudAttenuatorSwitchDriver.Location = New System.Drawing.Point(384, 176)
        Me.nudAttenuatorSwitchDriver.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.nudAttenuatorSwitchDriver.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudAttenuatorSwitchDriver.Name = "nudAttenuatorSwitchDriver"
        Me.nudAttenuatorSwitchDriver.Size = New System.Drawing.Size(48, 20)
        Me.nudAttenuatorSwitchDriver.TabIndex = 18
        Me.nudAttenuatorSwitchDriver.Value = New Decimal(New Integer() {28, 0, 0, 0})
        '
        'cboAttenuatorSwitchDriver
        '
        Me.cboAttenuatorSwitchDriver.Location = New System.Drawing.Point(248, 176)
        Me.cboAttenuatorSwitchDriver.Name = "cboAttenuatorSwitchDriver"
        Me.cboAttenuatorSwitchDriver.Size = New System.Drawing.Size(128, 21)
        Me.cboAttenuatorSwitchDriver.TabIndex = 10
        '
        'button1
        '
        Me.button1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.button1.Location = New System.Drawing.Point(64, 224)
        Me.button1.Name = "button1"
        Me.button1.TabIndex = 12
        Me.button1.Text = "OK"
        AddHandler Me.button1.Click, AddressOf Me.Button1Click
        '
        'cboHighFrequencySource
        '
        Me.cboHighFrequencySource.Location = New System.Drawing.Point(8, 48)
        Me.cboHighFrequencySource.Name = "cboHighFrequencySource"
        Me.cboHighFrequencySource.Size = New System.Drawing.Size(128, 21)
        Me.cboHighFrequencySource.TabIndex = 2
        '
        'cboReferencePowerMeter
        '
        Me.cboReferencePowerMeter.Location = New System.Drawing.Point(248, 48)
        Me.cboReferencePowerMeter.Name = "cboReferencePowerMeter"
        Me.cboReferencePowerMeter.Size = New System.Drawing.Size(128, 21)
        Me.cboReferencePowerMeter.TabIndex = 6
        '
        'nudStdDUTPowerMeter
        '
        Me.nudStdDUTPowerMeter.Location = New System.Drawing.Point(144, 176)
        Me.nudStdDUTPowerMeter.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.nudStdDUTPowerMeter.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudStdDUTPowerMeter.Name = "nudStdDUTPowerMeter"
        Me.nudStdDUTPowerMeter.Size = New System.Drawing.Size(48, 20)
        Me.nudStdDUTPowerMeter.TabIndex = 19
        Me.nudStdDUTPowerMeter.Value = New Decimal(New Integer() {13, 0, 0, 0})
        '
        'PowerSensorProcedureStandardsForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(448, 253)
        Me.Controls.Add(Me.nudStdDUTPowerMeter)
        Me.Controls.Add(Me.nudAttenuatorSwitchDriver)
        Me.Controls.Add(Me.nudNetworkAnalyzer)
        Me.Controls.Add(Me.nudReferencePowerMeter)
        Me.Controls.Add(Me.nudLowFrequencySource)
        Me.Controls.Add(Me.nudHighFrequencySource)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.cboAttenuatorSwitchDriver)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.cboNetworkAnalyzer)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.cboReferencePowerMeter)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.cboStdDUTPowerMeter)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.cboHighFrequencySource)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.cboLowFrequencySource)
        Me.Controls.Add(Me.lablel1)
        Me.Name = "PowerSensorProcedureStandardsForm"
        Me.Text = "Power Sensor Calibration Standards"
        CType(Me.nudReferencePowerMeter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudLowFrequencySource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudNetworkAnalyzer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudHighFrequencySource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudAttenuatorSwitchDriver, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudStdDUTPowerMeter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub
#End Region

    Public Sub FillComboBoxes()
        Dim SignalGeneratorAssembly As [Assembly] = [Assembly].LoadFrom(Me.FCResources & "SignalGenerators.dll")
        For Each Res As [Type] In SignalGeneratorAssembly.GetTypes
            Try
                If Res.BaseType.Name = "SignalGenerator" Then
                    Me.cboHighFrequencySource.Items.Add(Res.Name)
                End If
            Catch Ex As Exception
                MessageBox.Show(Ex.ToString)
            End Try
        Next
        SignalGeneratorAssembly = Nothing
        Dim PowerMeterAssembly As [Assembly] = [Assembly].LoadFrom(Me.FCResources & "PowerMeters.dll")
        For Each Res As [Type] In PowerMeterAssembly.GetTypes
            Try
                If Res.BaseType.Name = "PowerMeter" Then
                    Me.cboReferencePowerMeter.Items.Add(Res.Name)
                    Me.cboStdDUTPowerMeter.Items.Add(Res.Name)
                End If
            Catch Ex As Exception
                MessageBox.Show(Ex.ToString)
            End Try
        Next
        PowerMeterAssembly = Nothing
        Dim NetworkAnalyzerAssembly As [Assembly] = [Assembly].LoadFrom(Me.FCResources & "NetworkAnalyzers.dll")
        For Each Res As [Type] In NetworkAnalyzerAssembly.GetTypes
            Try
                If Res.BaseType.Name = "NetworkAnalyzer" Then
                    Me.cboNetworkAnalyzer.Items.Add(Res.Name)
                End If
            Catch Ex As Exception
                MessageBox.Show(Ex.ToString)
            End Try
        Next
        NetworkAnalyzerAssembly = Nothing
        Dim FunctionGeneratorAssembly As [Assembly] = [Assembly].LoadFrom(Me.FCResources & "FunctionGenerators.dll")
        For Each Res As [Type] In FunctionGeneratorAssembly.GetTypes
            Try
                If Res.BaseType.Name = "FunctionGenerator" Then
                    Me.cboLowFrequencySource.Items.Add(Res.Name)
                End If
            Catch Ex As Exception
                MessageBox.Show(Ex.ToString)
            End Try
        Next
        FunctionGeneratorAssembly = Nothing
        Dim AttenuatorSwitchDriverAssembly As [Assembly] = [Assembly].LoadFrom(Me.FCResources & "AttenuatorSwitchDrivers.dll")
        For Each Res As [Type] In AttenuatorSwitchDriverAssembly.GetTypes
            Try
                If Res.BaseType.Name = "AttenuatorSwitchDriver" Then
                    Me.cboAttenuatorSwitchDriver.Items.Add(Res.Name)
                End If
            Catch Ex As Exception
                MessageBox.Show(Ex.ToString)
            End Try
        Next
        AttenuatorSwitchDriverAssembly = Nothing
        Me.cboAttenuatorSwitchDriver.SelectedIndex = 0
        Me.cboHighFrequencySource.SelectedIndex = 0
        Me.cboLowFrequencySource.SelectedIndex = 0
        Me.cboNetworkAnalyzer.SelectedIndex = 0
        Me.cboReferencePowerMeter.SelectedIndex = 0
        Me.cboStdDUTPowerMeter.SelectedIndex = 0
    End Sub

    Private Sub Button1Click(sender As System.Object, e As System.EventArgs)
        Me.SelectedAttenuatorSwitchDriver = Me.cboAttenuatorSwitchDriver.Text
        Me.SelectedHighFrequencySource = Me.cboHighFrequencySource.Text
        Me.SelectedLowFrequencySource = Me.cboLowFrequencySource.Text
        Me.SelectedNetworkAnalyzer = Me.cboNetworkAnalyzer.Text
        Me.SelectedReferencePowerMeter = Me.cboReferencePowerMeter.Text
        Me.SelectedStdDUTPowerMeter = Me.cboStdDUTPowerMeter.Text

        Me.SelectedAttenuatorSwitchDriverAddress = Convert.ToByte(Me.nudAttenuatorSwitchDriver.Value)
        Me.SelectedHighFrequencySourceAddress = Convert.ToByte(Me.nudHighFrequencySource.Value)
        Me.SelectedLowFrequencySourceAddress = Convert.ToByte(Me.nudLowFrequencySource.Value)
        Me.SelectedNetworkAnalyzerAddress = Convert.ToByte(Me.nudNetworkAnalyzer.Value)
        Me.SelectedReferencePowerMeterAddress = Convert.ToByte(Me.nudReferencePowerMeter.Value)
        Me.SelectedStdDUTPowerMeterAddress = Convert.ToByte(Me.nudStdDUTPowerMeter.Value)
        Me.Close()
    End Sub

    Private Sub BtnCancelClick(sender As System.Object, e As System.EventArgs)
        Me.Close()
    End Sub

End Class



