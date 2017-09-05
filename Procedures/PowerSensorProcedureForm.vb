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

    Private WithEvents Standards As New PowerSensorProcedureStandardsForm
    Private WithEvents TestFrequencyForm As New PowerSensorTestFrequencyForm
    Private WithEvents OldR As New PowerSensorOldCalibrationResultsForm
    Private WithEvents button3 As System.Windows.Forms.Button
    Private WithEvents dataGrid1 As System.Windows.Forms.DataGrid
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents btnGetOldResults As System.Windows.Forms.Button
    Private WithEvents btnFrequencies As System.Windows.Forms.Button
    Private WithEvents btnEditMeterTables As System.Windows.Forms.Button
    Private WithEvents tbReferenceLevel As System.Windows.Forms.TextBox
    Private WithEvents chkSimulate As System.Windows.Forms.CheckBox
    Private WithEvents button1 As System.Windows.Forms.Button
    Private WithEvents tbDUTAssetNumber As System.Windows.Forms.TextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents cbReferenceLevelSuffix As System.Windows.Forms.ComboBox

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
        Me.cbReferenceLevelSuffix = New System.Windows.Forms.ComboBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.tbDUTAssetNumber = New System.Windows.Forms.TextBox()
        Me.button1 = New System.Windows.Forms.Button()
        Me.chkSimulate = New System.Windows.Forms.CheckBox()
        Me.tbReferenceLevel = New System.Windows.Forms.TextBox()
        Me.btnEditMeterTables = New System.Windows.Forms.Button()
        Me.btnFrequencies = New System.Windows.Forms.Button()
        Me.btnGetOldResults = New System.Windows.Forms.Button()
        Me.label1 = New System.Windows.Forms.Label()
        Me.dataGrid1 = New System.Windows.Forms.DataGrid()
        Me.button3 = New System.Windows.Forms.Button()
        CType(Me.dataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbReferenceLevelSuffix
        '
        Me.cbReferenceLevelSuffix.Location = New System.Drawing.Point(144, 399)
        Me.cbReferenceLevelSuffix.Name = "cbReferenceLevelSuffix"
        Me.cbReferenceLevelSuffix.Size = New System.Drawing.Size(128, 33)
        Me.cbReferenceLevelSuffix.TabIndex = 25
        Me.cbReferenceLevelSuffix.Text = "dBm"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(48, 369)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(169, 25)
        Me.label2.TabIndex = 26
        Me.label2.Text = "Reference Level"
        '
        'tbDUTAssetNumber
        '
        Me.tbDUTAssetNumber.Location = New System.Drawing.Point(16, 59)
        Me.tbDUTAssetNumber.Name = "tbDUTAssetNumber"
        Me.tbDUTAssetNumber.Size = New System.Drawing.Size(272, 31)
        Me.tbDUTAssetNumber.TabIndex = 2
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(64, 561)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(176, 43)
        Me.button1.TabIndex = 7
        Me.button1.Text = "Calibrate"
        '
        'chkSimulate
        '
        Me.chkSimulate.Location = New System.Drawing.Point(16, 827)
        Me.chkSimulate.Name = "chkSimulate"
        Me.chkSimulate.Size = New System.Drawing.Size(224, 74)
        Me.chkSimulate.TabIndex = 20
        Me.chkSimulate.Text = "Simulate Communication"
        Me.chkSimulate.Visible = False
        '
        'tbReferenceLevel
        '
        Me.tbReferenceLevel.Location = New System.Drawing.Point(16, 399)
        Me.tbReferenceLevel.Name = "tbReferenceLevel"
        Me.tbReferenceLevel.Size = New System.Drawing.Size(112, 31)
        Me.tbReferenceLevel.TabIndex = 24
        Me.tbReferenceLevel.Text = "0"
        '
        'btnEditMeterTables
        '
        Me.btnEditMeterTables.Location = New System.Drawing.Point(48, 236)
        Me.btnEditMeterTables.Name = "btnEditMeterTables"
        Me.btnEditMeterTables.Size = New System.Drawing.Size(208, 43)
        Me.btnEditMeterTables.TabIndex = 22
        Me.btnEditMeterTables.Text = "Edit Cal Tables"
        '
        'btnFrequencies
        '
        Me.btnFrequencies.Location = New System.Drawing.Point(32, 177)
        Me.btnFrequencies.Name = "btnFrequencies"
        Me.btnFrequencies.Size = New System.Drawing.Size(240, 43)
        Me.btnFrequencies.TabIndex = 21
        Me.btnFrequencies.Text = "Set Test Frequencies"
        '
        'btnGetOldResults
        '
        Me.btnGetOldResults.Location = New System.Drawing.Point(64, 295)
        Me.btnGetOldResults.Name = "btnGetOldResults"
        Me.btnGetOldResults.Size = New System.Drawing.Size(192, 43)
        Me.btnGetOldResults.TabIndex = 23
        Me.btnGetOldResults.Text = "Get Old Results"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(32, 30)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(196, 25)
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
        Me.dataGrid1.Location = New System.Drawing.Point(320, 15)
        Me.dataGrid1.Name = "dataGrid1"
        Me.dataGrid1.Size = New System.Drawing.Size(1415, 1076)
        Me.dataGrid1.TabIndex = 17
        '
        'button3
        '
        Me.button3.Location = New System.Drawing.Point(64, 118)
        Me.button3.Name = "button3"
        Me.button3.Size = New System.Drawing.Size(176, 43)
        Me.button3.TabIndex = 18
        Me.button3.Text = "Set Standards"
        '
        'PowerSensorProcedureForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(10, 24)
        Me.ClientSize = New System.Drawing.Size(1751, 1100)
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
        Me.PerformLayout()

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

    Private Sub Button1Click(sender As System.Object, e As System.EventArgs) Handles button1.Click
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

    Private Sub Button3Click(sender As System.Object, e As System.EventArgs) Handles button3.Click
        Me.Standards.StartPosition = FormStartPosition.CenterScreen
        Me.Standards.Show()
    End Sub

    Private Sub btnFrequenciesClick(sender As System.Object, e As System.EventArgs) Handles btnFrequencies.Click
        Me.TestFrequencyForm.StartPosition = FormStartPosition.CenterScreen
        Me.TestFrequencyForm.Show()
    End Sub

    Private Sub BtnEditMeterTablesClick(sender As System.Object, e As System.EventArgs) Handles btnEditMeterTables.Click
        Dim TableEditor As New AgilentE4417ATableEditorForm(Me.MdiParent)
        TableEditor.Show()
    End Sub

    Private Sub BtnGetOldResultsClick(sender As System.Object, e As System.EventArgs) Handles btnGetOldResults.Click
        OldR.Show()
    End Sub

End Class



