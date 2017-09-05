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
Imports FreeCal.Instruments.PowerMeters



Public Class PowerSensorProcedureForm
    Inherits System.Windows.Forms.Form
    Private Standards As New PowerSensorProcedureStandardsForm
    Private TestFrequencyForm As New PowerSensorTestFrequencyForm
    Private OldR As New PowerSensorOldCalibrationResultsForm
    Private button3 As System.Windows.Forms.Button
    Private dataGrid1 As System.Windows.Forms.DataGrid
    Private label1 As System.Windows.Forms.Label
    Private btnGetOldResults As System.Windows.Forms.Button
    Private btnFrequencies As System.Windows.Forms.Button
    Private btnEditMeterTables As System.Windows.Forms.Button
    Private tbReferenceLevel As System.Windows.Forms.TextBox
    Private chkSimulate As System.Windows.Forms.CheckBox
    Private button1 As System.Windows.Forms.Button
    Private tbDUTAssetNumber As System.Windows.Forms.TextBox
    Private label2 As System.Windows.Forms.Label
    Private cbReferenceLevelSuffix As System.Windows.Forms.ComboBox

    Public Sub New()
        MyBase.New
        '
        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        '
        Me.InitializeComponent()
        SetControlConfigurationOptions(Me, Me.Controls)
        Me.FillComboBoxes()
    End Sub

#Region " Windows Forms Designer generated code "
    ' This method is required for Windows Forms designer support.
    ' Do not change the method contents inside the source code editor. The Forms designer might
    ' not be able to load this method if it was changed manually.
    Private Sub InitializeComponent()
        Me.cbReferenceLevelSuffix = New System.Windows.Forms.ComboBox
        Me.label2 = New System.Windows.Forms.Label
        Me.tbDUTAssetNumber = New System.Windows.Forms.TextBox
        Me.button1 = New System.Windows.Forms.Button
        Me.chkSimulate = New System.Windows.Forms.CheckBox
        Me.tbReferenceLevel = New System.Windows.Forms.TextBox
        Me.btnEditMeterTables = New System.Windows.Forms.Button
        Me.btnFrequencies = New System.Windows.Forms.Button
        Me.btnGetOldResults = New System.Windows.Forms.Button
        Me.label1 = New System.Windows.Forms.Label
        Me.dataGrid1 = New System.Windows.Forms.DataGrid
        Me.button3 = New System.Windows.Forms.Button
        CType(Me.dataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbReferenceLevelSuffix
        '
        Me.cbReferenceLevelSuffix.Location = New System.Drawing.Point(72, 216)
        Me.cbReferenceLevelSuffix.Name = "cbReferenceLevelSuffix"
        Me.cbReferenceLevelSuffix.Size = New System.Drawing.Size(64, 21)
        Me.cbReferenceLevelSuffix.TabIndex = 25
        Me.cbReferenceLevelSuffix.Text = "dBm"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.label2.Location = New System.Drawing.Point(24, 200)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(95, 17)
        Me.label2.TabIndex = 26
        Me.label2.Text = "Reference Level"
        '
        'tbDUTAssetNumber
        '
        Me.tbDUTAssetNumber.Location = New System.Drawing.Point(8, 32)
        Me.tbDUTAssetNumber.Name = "tbDUTAssetNumber"
        Me.tbDUTAssetNumber.Size = New System.Drawing.Size(136, 20)
        Me.tbDUTAssetNumber.TabIndex = 2
        Me.tbDUTAssetNumber.Text = ""
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(32, 304)
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
        Me.chkSimulate.Visible = False
        '
        'tbReferenceLevel
        '
        Me.tbReferenceLevel.Location = New System.Drawing.Point(8, 216)
        Me.tbReferenceLevel.Name = "tbReferenceLevel"
        Me.tbReferenceLevel.Size = New System.Drawing.Size(56, 20)
        Me.tbReferenceLevel.TabIndex = 24
        Me.tbReferenceLevel.Text = "0"
        '
        'btnEditMeterTables
        '
        Me.btnEditMeterTables.Location = New System.Drawing.Point(24, 128)
        Me.btnEditMeterTables.Name = "btnEditMeterTables"
        Me.btnEditMeterTables.Size = New System.Drawing.Size(104, 23)
        Me.btnEditMeterTables.TabIndex = 22
        Me.btnEditMeterTables.Text = "Edit Cal Tables"
        AddHandler Me.btnEditMeterTables.Click, AddressOf Me.BtnEditMeterTablesClick
        '
        'btnFrequencies
        '
        Me.btnFrequencies.Location = New System.Drawing.Point(16, 96)
        Me.btnFrequencies.Name = "btnFrequencies"
        Me.btnFrequencies.Size = New System.Drawing.Size(120, 23)
        Me.btnFrequencies.TabIndex = 21
        Me.btnFrequencies.Text = "Set Test Frequencies"
        AddHandler Me.btnFrequencies.Click, AddressOf Me.btnFrequenciesClick
        '
        'btnGetOldResults
        '
        Me.btnGetOldResults.Location = New System.Drawing.Point(32, 160)
        Me.btnGetOldResults.Name = "btnGetOldResults"
        Me.btnGetOldResults.Size = New System.Drawing.Size(96, 23)
        Me.btnGetOldResults.TabIndex = 23
        Me.btnGetOldResults.Text = "Get Old Results"
        AddHandler Me.btnGetOldResults.Click, AddressOf Me.BtnGetOldResultsClick
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
        Me.Controls.Add(Me.cbReferenceLevelSuffix)
        Me.Controls.Add(Me.tbReferenceLevel)
        Me.Controls.Add(Me.btnGetOldResults)
        Me.Controls.Add(Me.btnEditMeterTables)
        Me.Controls.Add(Me.btnFrequencies)
        Me.Controls.Add(Me.chkSimulate)
        Me.Controls.Add(Me.button3)
        Me.Controls.Add(Me.dataGrid1)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.tbDUTAssetNumber)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.label2)
        Me.Name = "PowerSensorProcedureForm"
        Me.Text = "Power Sensor Calibration"
        CType(Me.dataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub
#End Region

    Private Sub FillComboBoxes()
        For Each A As String In [Enum].GetNames(GetType(AmplitudeEnum))
            Me.cbReferenceLevelSuffix.Items.Add(A)
        Next
        If Me.cbReferenceLevelSuffix.Items.Count > 0 Then
            Me.cbReferenceLevelSuffix.SelectedIndex = 0
        End If
    End Sub

    Private Sub Button1Click(sender As System.Object, e As System.EventArgs)
        Dim NewPowerSensorProcedure As New PowerSensorProcedure(Me.tbDUTAssetNumber.Text, Me.dataGrid1, Me.OldR.OldResults)
        NewPowerSensorProcedure.FrequencyList = Me.TestFrequencyForm.FrequencyList
        NewPowerSensorProcedure.FrequencyListSuffix = Me.TestFrequencyForm.FrequencyListSuffix
        NewPowerSensorProcedure.ReferenceLevel = CDbl(Me.tbReferenceLevel.Text)
        NewPowerSensorProcedure.ReferenceLevelSuffix = CType([Enum].Parse(GetType(AmplitudeEnum), Me.cbReferenceLevelSuffix.SelectedItem.ToString), AmplitudeEnum)
        NewPowerSensorProcedure.SelectedAttenuatorSwitchDriver = Me.Standards.SelectedAttenuatorSwitchDriver
        NewPowerSensorProcedure.SelectedHighFrequencySource = Me.Standards.SelectedHighFrequencySource
        NewPowerSensorProcedure.SelectedLowFrequencySource = Me.Standards.SelectedLowFrequencySource
        NewPowerSensorProcedure.SelectedNetworkAnalyzer = Me.Standards.SelectedNetworkAnalyzer
        NewPowerSensorProcedure.SelectedPwrMtr = Me.Standards.SelectedStdDUTPowerMeter

        NewPowerSensorProcedure.AttenuatorSwitchDriverAddress = Me.Standards.SelectedAttenuatorSwitchDriverAddress
        NewPowerSensorProcedure.HighFrequencySourceAddress = Me.Standards.SelectedHighFrequencySourceAddress
        NewPowerSensorProcedure.LowFrequencySourceAddress = Me.Standards.SelectedLowFrequencySourceAddress
        NewPowerSensorProcedure.NetworkAnalyzerAddress = Me.Standards.SelectedNetworkAnalyzerAddress
        NewPowerSensorProcedure.PwrMtrAddress = Me.Standards.SelectedStdDUTPowerMeterAddress

        NewPowerSensorProcedure.Simulate = Me.chkSimulate.Checked
        NewPowerSensorProcedure.AllTests()
    End Sub

    Private Sub Button3Click(sender As System.Object, e As System.EventArgs)
        Me.Standards.StartPosition = FormStartPosition.CenterScreen
        Me.Standards.Show()
    End Sub

    Private Sub btnFrequenciesClick(sender As System.Object, e As System.EventArgs)
        Me.TestFrequencyForm.StartPosition = FormStartPosition.CenterScreen
        Me.TestFrequencyForm.Show()
    End Sub

    Private Sub BtnEditMeterTablesClick(sender As System.Object, e As System.EventArgs)
        Dim TableEditor As New AgilentE4417ATableEditorForm(Me.MdiParent)
        TableEditor.Show()
    End Sub

    Private Sub BtnGetOldResultsClick(sender As System.Object, e As System.EventArgs)
        OldR.Show()
    End Sub

End Class



