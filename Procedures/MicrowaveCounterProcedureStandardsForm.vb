'
' Created by SharpDevelop.
' User: rspage
' Date: 6/21/2005
' Time: 7:07 AM
' 

Imports System.Reflection
Imports System.Windows.Forms

Public Class CounterProcedureStandardsForm
    Inherits System.Windows.Forms.Form

    Private FCResources As String = ResourceDirectory & "\FreeCal.Instruments."
    Private nudDUTCounter As System.Windows.Forms.NumericUpDown
    Private cboHighFrequencySource As System.Windows.Forms.ComboBox
    Private btnCancel As System.Windows.Forms.Button
    Private button1 As System.Windows.Forms.Button
    Private nudHighFrequencySource As System.Windows.Forms.NumericUpDown
    Private cboDUTCounter As System.Windows.Forms.ComboBox
    Private nudPowerMeter As System.Windows.Forms.NumericUpDown
    Private label3 As System.Windows.Forms.Label
    Private label2 As System.Windows.Forms.Label
    Private label1 As System.Windows.Forms.Label
    Private nudLowFrequencySource As System.Windows.Forms.NumericUpDown
    Private cboPowerMeter As System.Windows.Forms.ComboBox
    Private cboLowFrequencySource As System.Windows.Forms.ComboBox
    Private lablel1 As System.Windows.Forms.Label

    Public SelectedHighFrequencySource As String = "Agilent8340B"
    Public SelectedLowFrequencySource As String = "Agilent3325B"
    Public SelectedPowerMeter As String = "AgilentE4417A"
    Public SelectedDUTCounter As String = "Agilent5342A"

    Public SelectedHighFrequencySourceAddress As Byte = 19
    Public SelectedLowFrequencySourceAddress As Byte = 11
    Public SelectedPowerMeterAddress As Byte = 13
    Public SelectedDUTCounterAddress As Byte = 16

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
        Me.cboLowFrequencySource = New System.Windows.Forms.ComboBox
        Me.cboPowerMeter = New System.Windows.Forms.ComboBox
        Me.nudLowFrequencySource = New System.Windows.Forms.NumericUpDown
        Me.label1 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.nudPowerMeter = New System.Windows.Forms.NumericUpDown
        Me.cboDUTCounter = New System.Windows.Forms.ComboBox
        Me.nudHighFrequencySource = New System.Windows.Forms.NumericUpDown
        Me.button1 = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.cboHighFrequencySource = New System.Windows.Forms.ComboBox
        Me.nudDUTCounter = New System.Windows.Forms.NumericUpDown
        CType(Me.nudLowFrequencySource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPowerMeter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudHighFrequencySource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudDUTCounter, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'cboLowFrequencySource
        '
        Me.cboLowFrequencySource.Location = New System.Drawing.Point(8, 112)
        Me.cboLowFrequencySource.Name = "cboLowFrequencySource"
        Me.cboLowFrequencySource.Size = New System.Drawing.Size(128, 21)
        Me.cboLowFrequencySource.TabIndex = 0
        '
        'cboPowerMeter
        '
        Me.cboPowerMeter.Location = New System.Drawing.Point(8, 176)
        Me.cboPowerMeter.Name = "cboPowerMeter"
        Me.cboPowerMeter.Size = New System.Drawing.Size(128, 21)
        Me.cboPowerMeter.TabIndex = 4
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
        Me.label2.Size = New System.Drawing.Size(77, 17)
        Me.label2.TabIndex = 5
        Me.label2.Text = "Power Meter"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.label3.Location = New System.Drawing.Point(248, 24)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(77, 17)
        Me.label3.TabIndex = 7
        Me.label3.Text = "DUT Counter"
        '
        'nudPowerMeter
        '
        Me.nudPowerMeter.Location = New System.Drawing.Point(144, 176)
        Me.nudPowerMeter.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.nudPowerMeter.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudPowerMeter.Name = "nudPowerMeter"
        Me.nudPowerMeter.Size = New System.Drawing.Size(48, 20)
        Me.nudPowerMeter.TabIndex = 19
        Me.nudPowerMeter.Value = New Decimal(New Integer() {13, 0, 0, 0})
        '
        'cboDUTCounter
        '
        Me.cboDUTCounter.Location = New System.Drawing.Point(248, 48)
        Me.cboDUTCounter.Name = "cboDUTCounter"
        Me.cboDUTCounter.Size = New System.Drawing.Size(128, 21)
        Me.cboDUTCounter.TabIndex = 6
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
        'button1
        '
        Me.button1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.button1.Location = New System.Drawing.Point(64, 224)
        Me.button1.Name = "button1"
        Me.button1.TabIndex = 12
        Me.button1.Text = "OK"
        AddHandler Me.button1.Click, AddressOf Me.Button1Click
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
        'cboHighFrequencySource
        '
        Me.cboHighFrequencySource.Location = New System.Drawing.Point(8, 48)
        Me.cboHighFrequencySource.Name = "cboHighFrequencySource"
        Me.cboHighFrequencySource.Size = New System.Drawing.Size(128, 21)
        Me.cboHighFrequencySource.TabIndex = 2
        '
        'nudDUTCounter
        '
        Me.nudDUTCounter.Location = New System.Drawing.Point(384, 48)
        Me.nudDUTCounter.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.nudDUTCounter.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudDUTCounter.Name = "nudDUTCounter"
        Me.nudDUTCounter.Size = New System.Drawing.Size(48, 20)
        Me.nudDUTCounter.TabIndex = 16
        Me.nudDUTCounter.Value = New Decimal(New Integer() {25, 0, 0, 0})
        '
        'PowerSensorProcedureStandardsForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(448, 253)
        Me.Controls.Add(Me.nudPowerMeter)
        Me.Controls.Add(Me.nudDUTCounter)
        Me.Controls.Add(Me.nudLowFrequencySource)
        Me.Controls.Add(Me.nudHighFrequencySource)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.cboDUTCounter)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.cboPowerMeter)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.cboHighFrequencySource)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.cboLowFrequencySource)
        Me.Controls.Add(Me.lablel1)
        Me.Name = "PowerSensorProcedureStandardsForm"
        Me.Text = "Power Sensor Calibration Standards"
        CType(Me.nudLowFrequencySource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPowerMeter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudHighFrequencySource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudDUTCounter, System.ComponentModel.ISupportInitialize).EndInit()
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
                If Res.BaseType.Name = "TwoChannelPowerMeter" Then
                    Me.cboPowerMeter.Items.Add(Res.Name)
                End If
            Catch Ex As Exception
                MessageBox.Show(Ex.ToString)
            End Try
        Next
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
        Dim CounterAssembly As [Assembly] = [Assembly].LoadFrom(Me.FCResources & "Counters.dll")
        For Each Res As [Type] In CounterAssembly.GetTypes
            Try
                If Res.BaseType.Name = "Counter" Then
                    Me.cboDUTCounter.Items.Add(Res.Name)
                End If
            Catch Ex As Exception
                MessageBox.Show(Ex.ToString)
            End Try
        Next
        CounterAssembly = Nothing
        Me.cboHighFrequencySource.SelectedIndex = 0
        Me.cboLowFrequencySource.SelectedIndex = 0
        Me.cboDUTCounter.SelectedIndex = 0
        Me.cboPowerMeter.SelectedIndex = 0
    End Sub

    Private Sub Button1Click(sender As System.Object, e As System.EventArgs)
        Me.SelectedHighFrequencySource = Me.cboHighFrequencySource.Text
        Me.SelectedLowFrequencySource = Me.cboLowFrequencySource.Text
        Me.SelectedDUTCounter = Me.cboDUTCounter.Text
        Me.SelectedPowerMeter = Me.cboPowerMeter.Text

        Me.SelectedHighFrequencySourceAddress = Convert.ToByte(Me.nudHighFrequencySource.Value)
        Me.SelectedLowFrequencySourceAddress = Convert.ToByte(Me.nudLowFrequencySource.Value)
        Me.SelectedDUTCounterAddress = Convert.ToByte(Me.nudDUTCounter.Value)
        Me.SelectedPowerMeterAddress = Convert.ToByte(Me.nudPowerMeter.Value)
        Me.Close()
    End Sub

    Private Sub BtnCancelClick(sender As System.Object, e As System.EventArgs)
        Me.Close()
    End Sub

End Class



