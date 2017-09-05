'
' Created by SharpDevelop.
' User: rspage
' Date: 7/25/2005
' Time: 3:25 PM
' 



Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Threading
Imports System.Data
Imports System.Reflection
Imports FreeCal.Common
Imports FreeCal.Instruments.IntervalAnalyzers
Imports NationalInstruments.NI4882
Imports ZedGraph
Imports Microsoft.VisualBasic.ControlChars



Public Class LongTermOscillatorStabilityProcedureForm
    Inherits System.Windows.Forms.Form
    Private gbMeasurements As System.Windows.Forms.GroupBox
    Private cbIntervalAnalyzerModel As System.Windows.Forms.ComboBox
    Private btnStart As System.Windows.Forms.Button
    Private nudNominalFrequency As System.Windows.Forms.NumericUpDown
    Private gbDUTInfo As System.Windows.Forms.GroupBox
    Private dudAveragingTime As System.Windows.Forms.DomainUpDown
    Private tbDUTSerialNumber As System.Windows.Forms.TextBox
    Private tbDUTModelNumber As System.Windows.Forms.TextBox
    Private nudTestPeriod As System.Windows.Forms.NumericUpDown
    Private tbDUTAssetNumber As System.Windows.Forms.TextBox
    Private tbIntervalAnalyzerAssetNumber As System.Windows.Forms.TextBox
    Private nudTimeIntervalAnalyzerAddress As System.Windows.Forms.NumericUpDown
    Private lblTimeRemaining As System.Windows.Forms.Label
    Private chkbSimulate As System.Windows.Forms.CheckBox
    Private gbTimeIntervalAnalyzer As System.Windows.Forms.GroupBox
    Private label10 As System.Windows.Forms.Label
    Private label3 As System.Windows.Forms.Label
    Private label2 As System.Windows.Forms.Label
    Private label1 As System.Windows.Forms.Label
    Private dgResults As System.Windows.Forms.DataGrid
    Private label7 As System.Windows.Forms.Label
    Private label6 As System.Windows.Forms.Label
    Private label5 As System.Windows.Forms.Label
    Private label4 As System.Windows.Forms.Label
    Private nudBusNumber As System.Windows.Forms.NumericUpDown
    Private lblTestStartDateTime As System.Windows.Forms.Label
    Private label9 As System.Windows.Forms.Label
    Private label8 As System.Windows.Forms.Label
    Private graphResults As ZedGraph.ZedGraphControl

#Region "Declarations"

    Private Analyzer As Agilent5372A
    Private TestThread As Thread
    Private dtResults As DataTable
    Private GPIBBus As Board
    Private WithEvents MeasurementIntervalTimer As System.Timers.Timer
    Private NumberOfMeasurementsTaken As Integer = 0
    Private TestPeriodTimeSpan As TimeSpan
    Private TestStartDateTime As DateTime
    Private Tau As Integer
    Private AverageTime As Integer
    Private DriftMultiplier As Integer
    Private NominalFrequency As Double
    Private MeasurementNumberMultiplier As Double
    Private WithEvents TestPeriodTimer As System.Timers.Timer
    Private WithEvents TestTimeRemainingTimer As System.Timers.Timer
    Private TestTimeRemainingTimeSpan As TimeSpan
    Private TestEndDateTime As DateTime

#End Region

    Public Sub New()
        MyBase.New
        '
        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        '
        Me.InitializeComponent()
        Me.FillComboBoxes()
        Me.dudAveragingTime.SelectedIndex = 0
    End Sub

#Region " Windows Forms Designer generated code "
    ' This method is required for Windows Forms designer support.
    ' Do not change the method contents inside the source code editor. The Forms designer might
    ' not be able to load this method if it was changed manually.
    Private Sub InitializeComponent()
        Me.graphResults = New ZedGraph.ZedGraphControl
        Me.label8 = New System.Windows.Forms.Label
        Me.label9 = New System.Windows.Forms.Label
        Me.lblTestStartDateTime = New System.Windows.Forms.Label
        Me.nudBusNumber = New System.Windows.Forms.NumericUpDown
        Me.label4 = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.label6 = New System.Windows.Forms.Label
        Me.label7 = New System.Windows.Forms.Label
        Me.dgResults = New System.Windows.Forms.DataGrid
        Me.label1 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.label10 = New System.Windows.Forms.Label
        Me.gbTimeIntervalAnalyzer = New System.Windows.Forms.GroupBox
        Me.chkbSimulate = New System.Windows.Forms.CheckBox
        Me.lblTimeRemaining = New System.Windows.Forms.Label
        Me.nudTimeIntervalAnalyzerAddress = New System.Windows.Forms.NumericUpDown
        Me.tbIntervalAnalyzerAssetNumber = New System.Windows.Forms.TextBox
        Me.tbDUTAssetNumber = New System.Windows.Forms.TextBox
        Me.nudTestPeriod = New System.Windows.Forms.NumericUpDown
        Me.tbDUTModelNumber = New System.Windows.Forms.TextBox
        Me.tbDUTSerialNumber = New System.Windows.Forms.TextBox
        Me.dudAveragingTime = New System.Windows.Forms.DomainUpDown
        Me.gbDUTInfo = New System.Windows.Forms.GroupBox
        Me.nudNominalFrequency = New System.Windows.Forms.NumericUpDown
        Me.btnStart = New System.Windows.Forms.Button
        Me.cbIntervalAnalyzerModel = New System.Windows.Forms.ComboBox
        Me.gbMeasurements = New System.Windows.Forms.GroupBox
        CType(Me.nudBusNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTimeIntervalAnalyzer.SuspendLayout()
        CType(Me.nudTimeIntervalAnalyzerAddress, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudTestPeriod, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDUTInfo.SuspendLayout()
        CType(Me.nudNominalFrequency, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbMeasurements.SuspendLayout()
        Me.SuspendLayout()
        '
        'graphResults
        '
        Me.graphResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.graphResults.IsEnableHPan = True
        Me.graphResults.IsEnableVPan = True
        Me.graphResults.IsEnableZoom = True
        Me.graphResults.IsShowContextMenu = True
        Me.graphResults.IsShowPointValues = False
        Me.graphResults.Location = New System.Drawing.Point(208, 16)
        Me.graphResults.Name = "graphResults"
        Me.graphResults.PointDateFormat = "g"
        Me.graphResults.PointValueFormat = "G"
        Me.graphResults.Size = New System.Drawing.Size(474, 450)
        Me.graphResults.TabIndex = 9
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.label8.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.label8.Location = New System.Drawing.Point(72, 16)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(39, 17)
        Me.label8.TabIndex = 24
        Me.label8.Text = "Model"
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.label9.Location = New System.Drawing.Point(48, 96)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(86, 17)
        Me.label9.TabIndex = 25
        Me.label9.Text = "Serial Number"
        '
        'lblTestStartDateTime
        '
        Me.lblTestStartDateTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTestStartDateTime.AutoSize = True
        Me.lblTestStartDateTime.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblTestStartDateTime.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.lblTestStartDateTime.Location = New System.Drawing.Point(376, 472)
        Me.lblTestStartDateTime.Name = "lblTestStartDateTime"
        Me.lblTestStartDateTime.Size = New System.Drawing.Size(125, 17)
        Me.lblTestStartDateTime.TabIndex = 16
        Me.lblTestStartDateTime.Text = "Test Start Date/Time"
        Me.lblTestStartDateTime.Visible = False
        '
        'nudBusNumber
        '
        Me.nudBusNumber.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.nudBusNumber.Location = New System.Drawing.Point(40, 120)
        Me.nudBusNumber.Maximum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.nudBusNumber.Name = "nudBusNumber"
        Me.nudBusNumber.Size = New System.Drawing.Size(48, 21)
        Me.nudBusNumber.TabIndex = 3
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.label4.Location = New System.Drawing.Point(48, 16)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(93, 17)
        Me.label4.TabIndex = 12
        Me.label4.Text = "Averaging Time"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.label5.Location = New System.Drawing.Point(48, 56)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(95, 17)
        Me.label5.TabIndex = 14
        Me.label5.Text = "Duration (Days)"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.label6.Location = New System.Drawing.Point(72, 24)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(39, 17)
        Me.label6.TabIndex = 20
        Me.label6.Text = "Model"
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.label7.Location = New System.Drawing.Point(48, 64)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(84, 17)
        Me.label7.TabIndex = 23
        Me.label7.Text = "Asset Number"
        '
        'dgResults
        '
        Me.dgResults.AllowNavigation = False
        Me.dgResults.AllowSorting = False
        Me.dgResults.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dgResults.DataMember = ""
        Me.dgResults.FlatMode = True
        Me.dgResults.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgResults.Location = New System.Drawing.Point(688, 16)
        Me.dgResults.Name = "dgResults"
        Me.dgResults.Size = New System.Drawing.Size(216, 448)
        Me.dgResults.TabIndex = 8
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.label1.Location = New System.Drawing.Point(96, 104)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(49, 17)
        Me.label1.TabIndex = 4
        Me.label1.Text = "Address"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.label2.Location = New System.Drawing.Point(48, 104)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(25, 17)
        Me.label2.TabIndex = 5
        Me.label2.Text = "Bus"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.label3.Location = New System.Drawing.Point(48, 56)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(84, 17)
        Me.label3.TabIndex = 6
        Me.label3.Text = "Asset Number"
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.label10.Location = New System.Drawing.Point(24, 136)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(152, 17)
        Me.label10.TabIndex = 28
        Me.label10.Text = "Nominal Frequency (MHz)"
        '
        'gbTimeIntervalAnalyzer
        '
        Me.gbTimeIntervalAnalyzer.Controls.Add(Me.tbIntervalAnalyzerAssetNumber)
        Me.gbTimeIntervalAnalyzer.Controls.Add(Me.label7)
        Me.gbTimeIntervalAnalyzer.Controls.Add(Me.cbIntervalAnalyzerModel)
        Me.gbTimeIntervalAnalyzer.Controls.Add(Me.label6)
        Me.gbTimeIntervalAnalyzer.Controls.Add(Me.label1)
        Me.gbTimeIntervalAnalyzer.Controls.Add(Me.nudTimeIntervalAnalyzerAddress)
        Me.gbTimeIntervalAnalyzer.Controls.Add(Me.nudBusNumber)
        Me.gbTimeIntervalAnalyzer.Controls.Add(Me.label2)
        Me.gbTimeIntervalAnalyzer.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.gbTimeIntervalAnalyzer.Location = New System.Drawing.Point(8, 8)
        Me.gbTimeIntervalAnalyzer.Name = "gbTimeIntervalAnalyzer"
        Me.gbTimeIntervalAnalyzer.Size = New System.Drawing.Size(192, 152)
        Me.gbTimeIntervalAnalyzer.TabIndex = 6
        Me.gbTimeIntervalAnalyzer.TabStop = False
        Me.gbTimeIntervalAnalyzer.Text = "Frequency and Time IntervalAnalyzer"
        '
        'chkbSimulate
        '
        Me.chkbSimulate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkbSimulate.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.chkbSimulate.Location = New System.Drawing.Point(208, 496)
        Me.chkbSimulate.Name = "chkbSimulate"
        Me.chkbSimulate.TabIndex = 10
        Me.chkbSimulate.Text = "Simulate Test"
        '
        'lblTimeRemaining
        '
        Me.lblTimeRemaining.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTimeRemaining.AutoSize = True
        Me.lblTimeRemaining.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.lblTimeRemaining.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.lblTimeRemaining.Location = New System.Drawing.Point(376, 488)
        Me.lblTimeRemaining.Name = "lblTimeRemaining"
        Me.lblTimeRemaining.Size = New System.Drawing.Size(124, 17)
        Me.lblTimeRemaining.TabIndex = 17
        Me.lblTimeRemaining.Text = "Test Time Remaining"
        Me.lblTimeRemaining.Visible = False
        '
        'nudTimeIntervalAnalyzerAddress
        '
        Me.nudTimeIntervalAnalyzerAddress.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.nudTimeIntervalAnalyzerAddress.Location = New System.Drawing.Point(96, 120)
        Me.nudTimeIntervalAnalyzerAddress.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.nudTimeIntervalAnalyzerAddress.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudTimeIntervalAnalyzerAddress.Name = "nudTimeIntervalAnalyzerAddress"
        Me.nudTimeIntervalAnalyzerAddress.Size = New System.Drawing.Size(48, 21)
        Me.nudTimeIntervalAnalyzerAddress.TabIndex = 2
        Me.nudTimeIntervalAnalyzerAddress.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'tbIntervalAnalyzerAssetNumber
        '
        Me.tbIntervalAnalyzerAssetNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbIntervalAnalyzerAssetNumber.Location = New System.Drawing.Point(8, 80)
        Me.tbIntervalAnalyzerAssetNumber.Name = "tbIntervalAnalyzerAssetNumber"
        Me.tbIntervalAnalyzerAssetNumber.Size = New System.Drawing.Size(176, 20)
        Me.tbIntervalAnalyzerAssetNumber.TabIndex = 21
        Me.tbIntervalAnalyzerAssetNumber.Text = ""
        '
        'tbDUTAssetNumber
        '
        Me.tbDUTAssetNumber.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.tbDUTAssetNumber.Location = New System.Drawing.Point(8, 72)
        Me.tbDUTAssetNumber.Name = "tbDUTAssetNumber"
        Me.tbDUTAssetNumber.Size = New System.Drawing.Size(176, 21)
        Me.tbDUTAssetNumber.TabIndex = 11
        Me.tbDUTAssetNumber.Text = ""
        '
        'nudTestPeriod
        '
        Me.nudTestPeriod.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.nudTestPeriod.Location = New System.Drawing.Point(40, 72)
        Me.nudTestPeriod.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.nudTestPeriod.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudTestPeriod.Name = "nudTestPeriod"
        Me.nudTestPeriod.Size = New System.Drawing.Size(104, 21)
        Me.nudTestPeriod.TabIndex = 13
        Me.nudTestPeriod.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'tbDUTModelNumber
        '
        Me.tbDUTModelNumber.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.tbDUTModelNumber.Location = New System.Drawing.Point(8, 32)
        Me.tbDUTModelNumber.Name = "tbDUTModelNumber"
        Me.tbDUTModelNumber.Size = New System.Drawing.Size(176, 21)
        Me.tbDUTModelNumber.TabIndex = 27
        Me.tbDUTModelNumber.Text = ""
        '
        'tbDUTSerialNumber
        '
        Me.tbDUTSerialNumber.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.tbDUTSerialNumber.Location = New System.Drawing.Point(8, 112)
        Me.tbDUTSerialNumber.Name = "tbDUTSerialNumber"
        Me.tbDUTSerialNumber.Size = New System.Drawing.Size(176, 21)
        Me.tbDUTSerialNumber.TabIndex = 26
        Me.tbDUTSerialNumber.Text = ""
        '
        'dudAveragingTime
        '
        Me.dudAveragingTime.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.dudAveragingTime.Items.Add("15 Minutes (2.0E-13)")
        Me.dudAveragingTime.Items.Add("30 Minutes (1.1E-13)")
        Me.dudAveragingTime.Items.Add("1 Hour (5.6E-14)")
        Me.dudAveragingTime.Items.Add("3 Hours (2.0E-14)")
        Me.dudAveragingTime.Location = New System.Drawing.Point(32, 32)
        Me.dudAveragingTime.Name = "dudAveragingTime"
        Me.dudAveragingTime.ReadOnly = True
        Me.dudAveragingTime.TabIndex = 11
        '
        'gbDUTInfo
        '
        Me.gbDUTInfo.Controls.Add(Me.tbDUTModelNumber)
        Me.gbDUTInfo.Controls.Add(Me.tbDUTSerialNumber)
        Me.gbDUTInfo.Controls.Add(Me.tbDUTAssetNumber)
        Me.gbDUTInfo.Controls.Add(Me.label3)
        Me.gbDUTInfo.Controls.Add(Me.label8)
        Me.gbDUTInfo.Controls.Add(Me.label9)
        Me.gbDUTInfo.Controls.Add(Me.nudNominalFrequency)
        Me.gbDUTInfo.Controls.Add(Me.label10)
        Me.gbDUTInfo.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.gbDUTInfo.Location = New System.Drawing.Point(8, 168)
        Me.gbDUTInfo.Name = "gbDUTInfo"
        Me.gbDUTInfo.Size = New System.Drawing.Size(192, 184)
        Me.gbDUTInfo.TabIndex = 8
        Me.gbDUTInfo.TabStop = False
        Me.gbDUTInfo.Text = "DUT"
        '
        'nudNominalFrequency
        '
        Me.nudNominalFrequency.Location = New System.Drawing.Point(8, 152)
        Me.nudNominalFrequency.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.nudNominalFrequency.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudNominalFrequency.Name = "nudNominalFrequency"
        Me.nudNominalFrequency.Size = New System.Drawing.Size(176, 21)
        Me.nudNominalFrequency.TabIndex = 18
        Me.nudNominalFrequency.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'btnStart
        '
        Me.btnStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnStart.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnStart.Location = New System.Drawing.Point(208, 472)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.TabIndex = 0
        Me.btnStart.Text = "Start Test"
        AddHandler Me.btnStart.Click, AddressOf Me.BtnStartClick
        '
        'cbIntervalAnalyzerModel
        '
        Me.cbIntervalAnalyzerModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbIntervalAnalyzerModel.Location = New System.Drawing.Point(32, 40)
        Me.cbIntervalAnalyzerModel.Name = "cbIntervalAnalyzerModel"
        Me.cbIntervalAnalyzerModel.Size = New System.Drawing.Size(121, 21)
        Me.cbIntervalAnalyzerModel.TabIndex = 22
        '
        'gbMeasurements
        '
        Me.gbMeasurements.Controls.Add(Me.nudTestPeriod)
        Me.gbMeasurements.Controls.Add(Me.label5)
        Me.gbMeasurements.Controls.Add(Me.dudAveragingTime)
        Me.gbMeasurements.Controls.Add(Me.label4)
        Me.gbMeasurements.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.gbMeasurements.Location = New System.Drawing.Point(8, 360)
        Me.gbMeasurements.Name = "gbMeasurements"
        Me.gbMeasurements.Size = New System.Drawing.Size(192, 152)
        Me.gbMeasurements.TabIndex = 7
        Me.gbMeasurements.TabStop = False
        Me.gbMeasurements.Text = "Measurements"
        '
        'LongTermOscillatorStabilityProcedureForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(912, 517)
        Me.Controls.Add(Me.lblTimeRemaining)
        Me.Controls.Add(Me.lblTestStartDateTime)
        Me.Controls.Add(Me.graphResults)
        Me.Controls.Add(Me.dgResults)
        Me.Controls.Add(Me.gbMeasurements)
        Me.Controls.Add(Me.gbTimeIntervalAnalyzer)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.chkbSimulate)
        Me.Controls.Add(Me.gbDUTInfo)
        Me.MinimumSize = New System.Drawing.Size(920, 544)
        Me.Name = "LongTermOscillatorStabilityProcedureForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Long Term Oscillator Stability Test"
        AddHandler Closing, AddressOf Me.LongTermOscillatorStabilityProcedureFormClosing
        CType(Me.nudBusNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbTimeIntervalAnalyzer.ResumeLayout(False)
        CType(Me.nudTimeIntervalAnalyzerAddress, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudTestPeriod, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDUTInfo.ResumeLayout(False)
        CType(Me.nudNominalFrequency, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbMeasurements.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub
#End Region

#Region "Form Load Methods"

    Private Sub FillComboBoxes()
        Dim IntervalAnalyzerAssembly As [Assembly] = [Assembly].LoadFrom(ResourceDirectory & "\FreeCal.Instruments.IntervalAnalyzers.dll")
        For Each Res As [Type] In IntervalAnalyzerAssembly.GetTypes
            Try
                If Res.BaseType.Name = "IntervalAnalyzer" Then
                    Me.cbIntervalAnalyzerModel.Items.Add(Res.Name)
                End If
            Catch Ex As Exception
                MessageBox.Show(Ex.ToString)
            End Try
        Next
        IntervalAnalyzerAssembly = Nothing
        Me.cbIntervalAnalyzerModel.SelectedIndex = 0
    End Sub

#End Region

#Region "Start Test Methods"

    Private Sub BtnStartClick(sender As System.Object, e As System.EventArgs)
        If Me.btnStart.Text = "Start Test" Then
            Me.btnStart.Text = "Stop Test"
            Me.lblTestStartDateTime.Text = "Test Start Date/Time:  " & DateTime.Now
            Me.lblTestStartDateTime.Visible = True

            Me.NominalFrequency = Me.nudNominalFrequency.Value

            Me.TestThread = New Thread(AddressOf Me.StartTest)

            Me.dtResults = New DataTable(Me.tbDUTAssetNumber.Text)
            Me.dtResults.Columns.Add(New DataColumn("Time (Hours)"))
            Me.dtResults.Columns.Add(New DataColumn("Measurement"))
            Me.dgResults.DataMember = ""
            Me.dgResults.DataSource = Nothing
            Me.dgResults.DataMember = Me.dtResults.TableName
            Me.dgResults.DataSource = Me.dtResults

            Me.graphResults.GraphPane.CurveList.Clear()
            Me.graphResults.GraphPane.Title.Text = Me.tbDUTAssetNumber.Text
            Me.graphResults.GraphPane.XAxis.Title.Text = "Time (Hours)"
            Me.graphResults.GraphPane.YAxis.Title.Text = "Drift"
            Me.graphResults.GraphPane.AddCurve(Me.tbDUTAssetNumber.Text, New PointPairList, Color.Red, SymbolType.Diamond)
            Me.graphResults.AxisChange()
            Me.graphResults.Refresh()

            Me.TestThread.Start()
        ElseIf Me.btnStart.Text = "Stop Test" Then
            Me.CloseOrAbort()
        End If
    End Sub

    Private Sub StartTest()
        Select Case Me.dudAveragingTime.SelectedIndex
            Case 0
                Me.Tau = 900
                Me.AverageTime = 900
                Me.DriftMultiplier = 96
                Me.MeasurementNumberMultiplier = 0.25
            Case 1
                Me.Tau = 1800
                Me.AverageTime = 1800
                Me.DriftMultiplier = 48
                Me.MeasurementNumberMultiplier = 0.5
            Case 2
                Me.Tau = 3600
                Me.AverageTime = 3600
                Me.DriftMultiplier = 24
                Me.MeasurementNumberMultiplier = 1
            Case 3
                Me.Tau = 10800
                Me.AverageTime = 10800
                Me.DriftMultiplier = 8
                Me.MeasurementNumberMultiplier = 3
        End Select

        Me.TestStartDateTime = DateTime.Now
        Me.TestPeriodTimeSpan = New TimeSpan(Convert.ToInt32(Me.nudTestPeriod.Value), 0, 0, 0)
        Me.TestEndDateTime = Me.TestStartDateTime.Add(Me.TestPeriodTimeSpan)
        Me.TestPeriodTimer = New System.Timers.Timer(Me.TestPeriodTimeSpan.TotalMilliseconds)
        Me.TestPeriodTimer.Start()
        Me.lblTimeRemaining.Visible = True

        Me.TestTimeRemainingTimer = New System.Timers.Timer(1000)
        Me.TestTimeRemainingTimer.Start()

        Me.Analyzer = New Agilent5372A(CInt(Me.nudBusNumber.Value), CByte(Me.nudTimeIntervalAnalyzerAddress.Value), False, Me.chkbSimulate.Checked)
        Me.Analyzer.Clear()
        Me.Analyzer.Write("PRESET")
        Me.Analyzer.Write("INT;OUTPUT ASCII")
        Me.Analyzer.Write("MEAS;FUNC FREQ;SOUR A")
        Me.Analyzer.Write("INP;SOUR,A;TRIG,MAN")
        Me.Analyzer.Write("INP;SOUR,A;LEV,0")
        Me.Analyzer.Write("MEAS;ARM ISAM")
        Me.Analyzer.Write("PROC;SOUR A;STAT ON")
        Me.Analyzer.Write("MEAS;SAMP;DEL 5")
        Me.Analyzer.Write("SSIZE " & Me.Tau / 5)
        Me.Analyzer.Write("*SRE 16")
        Me.Analyzer.Trigger()
        Me.Analyzer.Notify(GpibStatusFlags.DeviceServiceRequest, AddressOf Me.OnIntervalAnalyzerSRQ, "")
    End Sub

#End Region

#Region "Measurement and Timer Methods"

    Private Sub OnTestPeriodTimerElapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles TestPeriodTimer.Elapsed
        Me.TestTimeRemainingTimer.Stop()
        Me.TestPeriodTimer.Stop()

        Try
            If Not Me.Analyzer Is Nothing Then
                Me.Analyzer.Dispose()
            End If
            If Not Me.GPIBBus Is Nothing Then
                Me.GPIBBus.Dispose()
            End If
            Me.TestThread.Join()
            Me.btnStart.Text = "Start Test"
            Me.lblTestStartDateTime.Visible = False
            MessageBox.Show("Test completed!")
        Catch Ex As Exception
            MessageBox.Show(Ex.ToString)
        End Try
    End Sub

    Private Sub OnTestTimeRemainingTimerElapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles TestTimeRemainingTimer.Elapsed
        Dim Diff As TimeSpan = Me.TestEndDateTime.Subtract(DateTime.Now)
        Dim DayOrDays As String = " Days - "
        Dim HourOrHours As String = " Hours - "
        Dim MinuteOrMinutes As String = " Minutes - "
        Dim SecondOrSeconds As String = " Seconds"
        If Diff.Days = 1 Then
            DayOrDays = " Day - "
        End If
        If Diff.Hours = 1 Then
            HourOrHours = " Hour"
        End If
        If Diff.Minutes = 1 Then
            HourOrHours = " Minute"
        End If
        If Diff.Seconds = 1 Then
            SecondOrSeconds = " Second"
        End If
        Me.lblTimeRemaining.Text = "Time Remaining:  " & Diff.Days & DayOrDays & Diff.Hours & HourOrHours & Diff.Minutes & MinuteOrMinutes & Diff.Seconds & SecondOrSeconds
    End Sub

    Private Sub OnIntervalAnalyzerSRQ(ByVal sender As Object, ByVal data As NotifyData)
        Dim STB As SerialPollFlags = Me.Analyzer.SerialPoll
        Me.lblTestStartDateTime.Text = STB.ToString
        If STB = 82 Then
            Me.NumberOfMeasurementsTaken += 1
            Dim Freq_A As String
            Me.Analyzer.Write("PROC;SOUR,A;MEAN?")
            Freq_A = (Me.Analyzer.ConvertFrequency(Me.Analyzer.ReadDouble, FrequencyEnum.Hz, FrequencyEnum.MHz) - Me.NominalFrequency).ToString
            Dim DR As DataRow = Me.dtResults.NewRow
            DR(0) = Me.NumberOfMeasurementsTaken * Me.MeasurementNumberMultiplier
            DR(1) = Freq_A
            Me.dtResults.Rows.Add(DR)
            Dim PP As New PointPair
            PP.X = Me.NumberOfMeasurementsTaken * Me.MeasurementNumberMultiplier
            PP.Y = Convert.ToDouble(Freq_A)
            Me.graphResults.GraphPane.CurveList(0).AddPoint(PP)
            Me.graphResults.AxisChange()
            Me.Refresh()
        End If
        data.SetReenableMask(GpibStatusFlags.DeviceServiceRequest)
    End Sub

#End Region

#Region "Form Close Methods"

    Private Function CloseOrAbort() As Boolean
        If MessageBox.Show("There is a test currently in progress!  Are you sure you want to abort the test?", "Caution! Test In Progress...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            Try
                If Not Me.Analyzer Is Nothing Then
                    Me.Analyzer.Dispose()
                End If
                If Not Me.GPIBBus Is Nothing Then
                    Me.GPIBBus.Dispose()
                End If
                Me.TestThread.Join()
                Me.btnStart.Text = "Start Test"
                Me.lblTestStartDateTime.Visible = False
            Catch Ex As Exception
                MessageBox.Show(Ex.ToString)
            End Try
            Return True
        End If
        Return False
    End Function

    Private Sub LongTermOscillatorStabilityProcedureFormClosing(sender As System.Object, e As System.ComponentModel.CancelEventArgs)
        If Me.btnStart.Text = "Stop Test" Then
            If Not Me.CloseOrAbort Then
                e.Cancel = True
            End If
        End If
    End Sub

#End Region

End Class

