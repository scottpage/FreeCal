'
' Created by SharpDevelop.
' User: rspage
' Date: 6/21/2005
' Time: 7:03 AM
' 

'
' Created by SharpDevelop.
' User: rspage
' Date: 6/15/2005
' Time: 12:43 PM
' 

Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports NationalInstruments.NI4882
Imports FreeCal.Common



Public Class CounterProcedureForm
    Inherits System.Windows.Forms.Form
    Private Standards As New CounterProcedureStandardsForm
    Private TestFrequencyForm As New PowerSensorTestFrequencyForm
    Private button3 As System.Windows.Forms.Button
    Private dataGrid1 As System.Windows.Forms.DataGrid
    Private label1 As System.Windows.Forms.Label
    Private btnFrequencies As System.Windows.Forms.Button
    Private tbDUTAssetNumber As System.Windows.Forms.TextBox
    Private chkSimulate As System.Windows.Forms.CheckBox
    Private button1 As System.Windows.Forms.Button

    Public Sub New()
        MyBase.New
        '
        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        '
        Me.InitializeComponent()
        Me.Standards.MdiParent = Me.MdiParent
        Me.TestFrequencyForm.MdiParent = Me.MdiParent
    End Sub

    Public Sub New(ByVal parent As Form)
        MyBase.New
        '
        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        '
        Me.InitializeComponent()
        Me.MdiParent = parent
    End Sub

#Region " Windows Forms Designer generated code "
    ' This method is required for Windows Forms designer support.
    ' Do not change the method contents inside the source code editor. The Forms designer might
    ' not be able to load this method if it was changed manually.
    Private Sub InitializeComponent()
        Me.button1 = New System.Windows.Forms.Button
        Me.chkSimulate = New System.Windows.Forms.CheckBox
        Me.tbDUTAssetNumber = New System.Windows.Forms.TextBox
        Me.btnFrequencies = New System.Windows.Forms.Button
        Me.label1 = New System.Windows.Forms.Label
        Me.dataGrid1 = New System.Windows.Forms.DataGrid
        Me.button3 = New System.Windows.Forms.Button
        CType(Me.dataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(32, 256)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(88, 23)
        Me.button1.TabIndex = 7
        Me.button1.Text = "Calibrate"
        AddHandler Me.button1.Click, AddressOf Me.Button1Click
        '
        'chkSimulate
        '
        Me.chkSimulate.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.chkSimulate.Location = New System.Drawing.Point(8, 448)
        Me.chkSimulate.Name = "chkSimulate"
        Me.chkSimulate.Size = New System.Drawing.Size(112, 40)
        Me.chkSimulate.TabIndex = 20
        Me.chkSimulate.Text = "Simulate Communication"
        '
        'tbDUTAssetNumber
        '
        Me.tbDUTAssetNumber.Location = New System.Drawing.Point(8, 32)
        Me.tbDUTAssetNumber.Name = "tbDUTAssetNumber"
        Me.tbDUTAssetNumber.Size = New System.Drawing.Size(136, 20)
        Me.tbDUTAssetNumber.TabIndex = 2
        Me.tbDUTAssetNumber.Text = ""
        '
        'btnFrequencies
        '
        Me.btnFrequencies.Location = New System.Drawing.Point(16, 104)
        Me.btnFrequencies.Name = "btnFrequencies"
        Me.btnFrequencies.Size = New System.Drawing.Size(120, 23)
        Me.btnFrequencies.TabIndex = 21
        Me.btnFrequencies.Text = "Set Test Frequencies"
        AddHandler Me.btnFrequencies.Click, AddressOf Me.btnFrequenciesClick
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.label1.Location = New System.Drawing.Point(16, 16)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(111, 17)
        Me.label1.TabIndex = 12
        Me.label1.Text = "DUT Asset Number"
        '
        'dataGrid1
        '
        Me.dataGrid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dataGrid1.DataMember = ""
        Me.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dataGrid1.Location = New System.Drawing.Point(160, 8)
        Me.dataGrid1.Name = "dataGrid1"
        Me.dataGrid1.Size = New System.Drawing.Size(728, 480)
        Me.dataGrid1.TabIndex = 17
        '
        'button3
        '
        Me.button3.Location = New System.Drawing.Point(32, 64)
        Me.button3.Name = "button3"
        Me.button3.Size = New System.Drawing.Size(88, 23)
        Me.button3.TabIndex = 18
        Me.button3.Text = "Set Standards"
        AddHandler Me.button3.Click, AddressOf Me.Button3Click
        '
        'PowerSensorProcedureForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(896, 493)
        Me.Controls.Add(Me.btnFrequencies)
        Me.Controls.Add(Me.chkSimulate)
        Me.Controls.Add(Me.button3)
        Me.Controls.Add(Me.dataGrid1)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.tbDUTAssetNumber)
        Me.Controls.Add(Me.label1)
        Me.Name = "PowerSensorProcedureForm"
        Me.Text = "Power Sensor Calibration"
        CType(Me.dataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub
#End Region

    Private Sub Button1Click(sender As System.Object, e As System.EventArgs)
        Dim NewCounterProcedure As New CounterProcedure(Me.tbDUTAssetNumber.Text, Me.dataGrid1)

        NewCounterProcedure.SelectedHighFrequencySource = Me.Standards.SelectedHighFrequencySource
        NewCounterProcedure.SelectedLowFrequencySource = Me.Standards.SelectedLowFrequencySource
        NewCounterProcedure.SelectedDUTCounter = Me.Standards.SelectedDUTCounter
        NewCounterProcedure.SelectedPwrMtr = Me.Standards.SelectedPowerMeter

        NewCounterProcedure.HighFrequencySourceAddress = Me.Standards.SelectedHighFrequencySourceAddress
        NewCounterProcedure.LowFrequencySourceAddress = Me.Standards.SelectedLowFrequencySourceAddress
        NewCounterProcedure.DUTCounterAddress = Me.Standards.SelectedDUTCounterAddress
        NewCounterProcedure.PwrMtrAddress = Me.Standards.SelectedPowerMeterAddress

        NewCounterProcedure.Simulate = Me.chkSimulate.Checked
        NewCounterProcedure.AllTests()
    End Sub

    Private Sub Button3Click(sender As System.Object, e As System.EventArgs)
        Me.Standards.StartPosition = FormStartPosition.CenterScreen
        Me.Standards.ShowDialog()
    End Sub

    Private Sub btnFrequenciesClick(sender As System.Object, e As System.EventArgs)
        Me.TestFrequencyForm.StartPosition = FormStartPosition.CenterScreen
        Me.TestFrequencyForm.ShowDialog()
    End Sub

End Class





