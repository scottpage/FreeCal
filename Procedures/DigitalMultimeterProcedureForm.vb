'
' Created by SharpDevelop.
' User: Administrator
' Date: 7/28/2005
' Time: 8:59 PM
'


Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Threading
Imports FreeCal.Instruments.DigitalMultimeters
Imports FreeCal.Instruments.MultifunctionCalibrators
Imports Microsoft.VisualBasic.ControlChars
Imports FreeCal.Instruments
Imports System.Data
Imports FreeCal.Common



Public Class DigitalMultimeterProcedureForm
    Inherits System.Windows.Forms.Form
    Private tbReadData As System.Windows.Forms.TextBox
    Private nudCalibratorBus As System.Windows.Forms.NumericUpDown
    Private btnTest As System.Windows.Forms.Button
    Private nudCalibratorSecondary As System.Windows.Forms.NumericUpDown
    Private groupBox2 As System.Windows.Forms.GroupBox
    Private groupBox1 As System.Windows.Forms.GroupBox
    Private cbTest As System.Windows.Forms.ComboBox
    Private label8 As System.Windows.Forms.Label
    Private nudThreadSleepPeriod As System.Windows.Forms.NumericUpDown
    Private nudDUTPrimary As System.Windows.Forms.NumericUpDown
    Private nudDUTSecondary As System.Windows.Forms.NumericUpDown
    Private nudDUTBus As System.Windows.Forms.NumericUpDown
    Private tbSentData As System.Windows.Forms.TextBox
    Private label3 As System.Windows.Forms.Label
    Private label2 As System.Windows.Forms.Label
    Private label1 As System.Windows.Forms.Label
    Private dgResults As System.Windows.Forms.DataGrid
    Private label7 As System.Windows.Forms.Label
    Private label6 As System.Windows.Forms.Label
    Private label5 As System.Windows.Forms.Label
    Private label4 As System.Windows.Forms.Label
    Private nudCalibratorPrimary As System.Windows.Forms.NumericUpDown

    Private WithEvents DUT As DigitalMultimeter
    Private WithEvents Calibrator As MultifunctionCalibrator

    Private dtResults As DataTable
    Private TestThread As Thread

    Public Sub New()
        MyBase.New
        '
        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        '
        Me.InitializeComponent()
        Me.dtResults = New DataTable("Results")
        Me.dtResults.Columns.Add(New DataColumn("Function"))
        Me.dtResults.Columns.Add(New DataColumn("Range"))
        Me.dtResults.Columns.Add(New DataColumn("Applied"))
        Me.dtResults.Columns.Add(New DataColumn("Measured"))
        Me.dgResults.DataMember = "Results"
        Me.dgResults.DataSource = Me.dtResults
        Me.FillComboBoxes()
    End Sub

#Region " Windows Forms Designer generated code "
    ' This method is required for Windows Forms designer support.
    ' Do not change the method contents inside the source code editor. The Forms designer might
    ' not be able to load this method if it was changed manually.
    Private Sub InitializeComponent()
        Me.nudCalibratorPrimary = New System.Windows.Forms.NumericUpDown
        Me.label4 = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.label6 = New System.Windows.Forms.Label
        Me.label7 = New System.Windows.Forms.Label
        Me.dgResults = New System.Windows.Forms.DataGrid
        Me.label1 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.tbSentData = New System.Windows.Forms.TextBox
        Me.nudDUTBus = New System.Windows.Forms.NumericUpDown
        Me.nudDUTSecondary = New System.Windows.Forms.NumericUpDown
        Me.nudDUTPrimary = New System.Windows.Forms.NumericUpDown
        Me.nudThreadSleepPeriod = New System.Windows.Forms.NumericUpDown
        Me.label8 = New System.Windows.Forms.Label
        Me.cbTest = New System.Windows.Forms.ComboBox
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.nudCalibratorSecondary = New System.Windows.Forms.NumericUpDown
        Me.btnTest = New System.Windows.Forms.Button
        Me.nudCalibratorBus = New System.Windows.Forms.NumericUpDown
        Me.tbReadData = New System.Windows.Forms.TextBox
        CType(Me.nudCalibratorPrimary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgResults, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudDUTBus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudDUTSecondary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudDUTPrimary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudThreadSleepPeriod, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox1.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        CType(Me.nudCalibratorSecondary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudCalibratorBus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'nudCalibratorPrimary
        '
        Me.nudCalibratorPrimary.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.nudCalibratorPrimary.Location = New System.Drawing.Point(72, 40)
        Me.nudCalibratorPrimary.Maximum = New Decimal(New Integer() {31, 0, 0, 0})
        Me.nudCalibratorPrimary.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudCalibratorPrimary.Name = "nudCalibratorPrimary"
        Me.nudCalibratorPrimary.Size = New System.Drawing.Size(48, 21)
        Me.nudCalibratorPrimary.TabIndex = 14
        Me.nudCalibratorPrimary.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(16, 24)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(25, 17)
        Me.label4.TabIndex = 11
        Me.label4.Text = "Bus"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(72, 24)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(49, 17)
        Me.label5.TabIndex = 12
        Me.label5.Text = "Primary"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(136, 24)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(64, 17)
        Me.label6.TabIndex = 13
        Me.label6.Text = "Secondary"
        '
        'label7
        '
        Me.label7.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.label7.Location = New System.Drawing.Point(224, 16)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(128, 32)
        Me.label7.TabIndex = 16
        Me.label7.Text = "Wait period before measurement (mS)"
        Me.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgResults
        '
        Me.dgResults.DataMember = ""
        Me.dgResults.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgResults.Location = New System.Drawing.Point(472, 8)
        Me.dgResults.Name = "dgResults"
        Me.dgResults.Size = New System.Drawing.Size(416, 472)
        Me.dgResults.TabIndex = 2
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(16, 16)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(25, 17)
        Me.label1.TabIndex = 5
        Me.label1.Text = "Bus"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(72, 16)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(49, 17)
        Me.label2.TabIndex = 6
        Me.label2.Text = "Primary"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(136, 16)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(64, 17)
        Me.label3.TabIndex = 7
        Me.label3.Text = "Secondary"
        '
        'tbSentData
        '
        Me.tbSentData.Location = New System.Drawing.Point(8, 160)
        Me.tbSentData.Multiline = True
        Me.tbSentData.Name = "tbSentData"
        Me.tbSentData.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.tbSentData.Size = New System.Drawing.Size(224, 320)
        Me.tbSentData.TabIndex = 0
        Me.tbSentData.Text = ""
        '
        'nudDUTBus
        '
        Me.nudDUTBus.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.nudDUTBus.Location = New System.Drawing.Point(8, 32)
        Me.nudDUTBus.Maximum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.nudDUTBus.Name = "nudDUTBus"
        Me.nudDUTBus.Size = New System.Drawing.Size(48, 21)
        Me.nudDUTBus.TabIndex = 5
        '
        'nudDUTSecondary
        '
        Me.nudDUTSecondary.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.nudDUTSecondary.Location = New System.Drawing.Point(144, 32)
        Me.nudDUTSecondary.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
        Me.nudDUTSecondary.Name = "nudDUTSecondary"
        Me.nudDUTSecondary.Size = New System.Drawing.Size(48, 21)
        Me.nudDUTSecondary.TabIndex = 9
        '
        'nudDUTPrimary
        '
        Me.nudDUTPrimary.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.nudDUTPrimary.Location = New System.Drawing.Point(72, 32)
        Me.nudDUTPrimary.Maximum = New Decimal(New Integer() {31, 0, 0, 0})
        Me.nudDUTPrimary.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudDUTPrimary.Name = "nudDUTPrimary"
        Me.nudDUTPrimary.Size = New System.Drawing.Size(48, 21)
        Me.nudDUTPrimary.TabIndex = 8
        Me.nudDUTPrimary.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'nudThreadSleepPeriod
        '
        Me.nudThreadSleepPeriod.Location = New System.Drawing.Point(232, 48)
        Me.nudThreadSleepPeriod.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.nudThreadSleepPeriod.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudThreadSleepPeriod.Name = "nudThreadSleepPeriod"
        Me.nudThreadSleepPeriod.Size = New System.Drawing.Size(112, 20)
        Me.nudThreadSleepPeriod.TabIndex = 6
        Me.nudThreadSleepPeriod.Value = New Decimal(New Integer() {2000, 0, 0, 0})
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.label8.Location = New System.Drawing.Point(248, 80)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(69, 17)
        Me.label8.TabIndex = 18
        Me.label8.Text = "Test to Run"
        Me.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbTest
        '
        Me.cbTest.Location = New System.Drawing.Point(224, 96)
        Me.cbTest.Name = "cbTest"
        Me.cbTest.Size = New System.Drawing.Size(121, 21)
        Me.cbTest.TabIndex = 17
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.nudDUTSecondary)
        Me.groupBox1.Controls.Add(Me.nudDUTPrimary)
        Me.groupBox1.Controls.Add(Me.nudDUTBus)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Controls.Add(Me.label3)
        Me.groupBox1.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.groupBox1.Location = New System.Drawing.Point(8, 8)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(208, 64)
        Me.groupBox1.TabIndex = 3
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "DUT Addressing"
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.nudCalibratorSecondary)
        Me.groupBox2.Controls.Add(Me.nudCalibratorPrimary)
        Me.groupBox2.Controls.Add(Me.nudCalibratorBus)
        Me.groupBox2.Controls.Add(Me.label4)
        Me.groupBox2.Controls.Add(Me.label5)
        Me.groupBox2.Controls.Add(Me.label6)
        Me.groupBox2.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.groupBox2.Location = New System.Drawing.Point(8, 80)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(208, 72)
        Me.groupBox2.TabIndex = 4
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Calibrator Addressing"
        '
        'nudCalibratorSecondary
        '
        Me.nudCalibratorSecondary.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.nudCalibratorSecondary.Location = New System.Drawing.Point(144, 40)
        Me.nudCalibratorSecondary.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
        Me.nudCalibratorSecondary.Name = "nudCalibratorSecondary"
        Me.nudCalibratorSecondary.Size = New System.Drawing.Size(48, 21)
        Me.nudCalibratorSecondary.TabIndex = 15
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(248, 120)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.TabIndex = 5
        Me.btnTest.Text = "Start Test"
        AddHandler Me.btnTest.Click, AddressOf Me.BtnTestClick
        '
        'nudCalibratorBus
        '
        Me.nudCalibratorBus.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.nudCalibratorBus.Location = New System.Drawing.Point(8, 40)
        Me.nudCalibratorBus.Maximum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.nudCalibratorBus.Name = "nudCalibratorBus"
        Me.nudCalibratorBus.Size = New System.Drawing.Size(48, 21)
        Me.nudCalibratorBus.TabIndex = 10
        '
        'tbReadData
        '
        Me.tbReadData.Location = New System.Drawing.Point(240, 160)
        Me.tbReadData.Multiline = True
        Me.tbReadData.Name = "tbReadData"
        Me.tbReadData.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.tbReadData.Size = New System.Drawing.Size(224, 320)
        Me.tbReadData.TabIndex = 1
        Me.tbReadData.Text = ""
        '
        'DigitalMultimeterProcedureForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(896, 486)
        Me.Controls.Add(Me.cbTest)
        Me.Controls.Add(Me.nudThreadSleepPeriod)
        Me.Controls.Add(Me.btnTest)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.dgResults)
        Me.Controls.Add(Me.tbReadData)
        Me.Controls.Add(Me.tbSentData)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.label8)
        Me.Name = "DigitalMultimeterProcedureForm"
        AddHandler Closing, AddressOf Me.DigitalMultimeterProcedureFormClosing
        CType(Me.nudCalibratorPrimary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgResults, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudDUTBus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudDUTSecondary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudDUTPrimary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudThreadSleepPeriod, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox2.ResumeLayout(False)
        CType(Me.nudCalibratorSecondary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudCalibratorBus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub
#End Region

    Private Sub FillComboBoxes()
        Me.cbTest.DataSource = [Enum].GetNames(GetType(DigitalMultimeterModeEnum))
        Me.cbTest.SelectedIndex = 0
    End Sub

    Private Sub BtnTestClick(sender As System.Object, e As System.EventArgs)
        If Me.btnTest.Text = "Start Test" Then
            Me.btnTest.Text = "Stop Test"
            Me.TestThread = New Thread(AddressOf Me.StartTest)
            Me.TestThread.Start()
        ElseIf Me.btnTest.Text = "Stop Test" Then
            Me.btnTest.Text = "Start Test"
            If Not (Me.TestThread Is Nothing) Then
                Me.TestThread.Abort()
                Me.TestThread = Nothing
            End If
        End If
    End Sub

    Private Sub StartTest()
        Me.DUT = New Agilent3478A(Convert.ToInt32(Me.nudDUTBus.Value), Convert.ToByte(Me.nudDUTPrimary.Value), Convert.ToByte(Me.nudDUTSecondary.Value), False)
        AddHandler Me.DUT.DataSent, AddressOf Me.OnInstrumentDataSent
        AddHandler Me.DUT.DataRead, AddressOf Me.OnInstrumentDataRead
        Me.Calibrator = New Fluke5700A(Convert.ToInt32(Me.nudCalibratorBus.Value), Convert.ToByte(Me.nudCalibratorPrimary.Value), Convert.ToByte(Me.nudCalibratorSecondary.Value), False)
        AddHandler Me.Calibrator.DataSent, AddressOf Me.OnInstrumentDataSent
        AddHandler Me.Calibrator.DataRead, AddressOf Me.OnInstrumentDataRead
        Select Case CType([Enum].Parse(GetType(DigitalMultimeterModeEnum), Me.cbTest.SelectedItem.ToString), DigitalMultimeterModeEnum)
            Case DigitalMultimeterModeEnum.DCVolts
                Me.DCVoltage()
            Case DigitalMultimeterModeEnum.ACVolts
                Me.ACVoltage()
            Case DigitalMultimeterModeEnum.DCCurrent
                Me.DCCurrent()
            Case DigitalMultimeterModeEnum.ACCurrent
                Me.ACCurrent()
        End Select
    End Sub

    Private Sub StoreResult(ByVal testName As String, ByVal appliedSetting As String, ByVal range As String)
        Thread.Sleep(Convert.ToInt32(Me.nudThreadSleepPeriod.Value))
        Dim DR As DataRow = Me.dtResults.NewRow
        DR(0) = testName
        DR(1) = range
        DR(2) = appliedSetting
        Try
            DR(3) = Me.DUT.Sections.Measure.Read
        Catch Ex As Exception
            DR(3) = "Device error"
        End Try
        Me.dtResults.Rows.Add(DR)
        Me.Refresh()
    End Sub

    Private Sub TestCompleted()
        Me.Calibrator.Sections.Output.State = OnOffStateEnum.[Off]
        Me.DisposeOfInstruments()
        Me.btnTest.Text = "Start Test"
        MessageBox.Show("Test complete.")
        Me.TestThread.Abort()
        Me.TestThread = Nothing
    End Sub

    Private Sub DCVoltage()
        MessageBox.Show("Connect a wire from the Calibrator HI terminal to the DMM HI terminal.")
        MessageBox.Show("Connect a wire from the Calibrator LO terminal to the DMM LO terminal.")
        MessageBox.Show("Disconnect all other wires, shorts and equipment.")
        Me.Calibrator.Preset()
        Me.DUT.Clear()
        Me.DUT.Preset()
        Me.Calibrator.Sections.Output.Frequency = 0
        For I As Integer = 0 To Me.DUT.TestPoints.DCVoltTestRanges.GetUpperBound(0)
            Me.DUT.Sections.Configure.DC.VoltRange = Me.DUT.TestPoints.DCVoltTestRanges(I)
            Me.Calibrator.Sections.Output.Volts = Me.DUT.TestPoints.DCVoltTestAppliedVoltages(I)
            Me.Calibrator.Sections.Output.State = OnOffStateEnum.[On]
            Me.StoreResult("DC Voltage", Me.DUT.TestPoints.DCVoltTestAppliedVoltages(I) & Me.Calibrator.Sections.Output.VoltSuffix.ToString, Me.DUT.TestPoints.DCVoltTestRanges(I) & "V")
        Next
        Me.TestCompleted()
    End Sub

    Private Sub ACVoltage()
        MessageBox.Show("Connect a wire from the Calibrator HI terminal to the DMM HI terminal.")
        MessageBox.Show("Connect a wire from the Calibrator LO terminal to the DMM LO terminal.")
        MessageBox.Show("Disconnect all other wires, shorts and equipment.")
        Me.Calibrator.Preset()
        Me.DUT.Clear()
        Me.DUT.Preset()

        For I As Integer = 0 To Me.DUT.TestPoints.ACVoltTestRanges.GetUpperBound(0)
            Me.DUT.Sections.Configure.AC.VoltRange = Me.DUT.TestPoints.ACVoltTestRanges(I)
            Me.Calibrator.Sections.Output.Volts = Me.DUT.TestPoints.ACVoltTestAppliedVoltages(I)
            Me.Calibrator.Sections.Output.Frequency = Me.DUT.TestPoints.ACVoltTestAppliedFrequencies(I)
            Me.Calibrator.Sections.Output.State = OnOffStateEnum.[On]
            Me.StoreResult("AC Voltage", Me.DUT.TestPoints.ACVoltTestAppliedVoltages(I) & Me.Calibrator.Sections.Output.VoltSuffix.ToString & " @ " & Me.DUT.TestPoints.ACVoltTestAppliedFrequencies(I) & Me.Calibrator.Sections.Output.FrequencySuffix.ToString, Me.DUT.TestPoints.ACVoltTestRanges(I) & "V")
        Next
        Me.TestCompleted()
    End Sub

    Private Sub DCCurrent()
        MessageBox.Show("Connect a wire from the Calibrator I (Current) terminal to the DMM I (Current) terminal.")
        MessageBox.Show("Connect a wire from the Calibrator LO terminal to the DMM LO terminal.")
        MessageBox.Show("Disconnect all other wires, shorts and equipment.")
        Me.Calibrator.Preset()
        Me.DUT.Clear()
        Me.DUT.Preset()
        Me.Calibrator.Sections.Output.Frequency = 0
        For I As Integer = 0 To Me.DUT.TestPoints.DCCurrentTestRanges.GetUpperBound(0)
            Me.DUT.Sections.Configure.DC.AmpRange = Me.DUT.TestPoints.DCCurrentTestRanges(I)
            Me.Calibrator.Sections.Output.Amps = Me.DUT.TestPoints.DCCurrentTestAppliedCurrents(I)
            Me.Calibrator.Sections.Output.State = OnOffStateEnum.[On]
            Me.StoreResult("DC Current", Me.DUT.TestPoints.DCCurrentTestAppliedCurrents(I) & "A", Me.DUT.TestPoints.DCCurrentTestRanges(I) & "A")
        Next
        Me.TestCompleted()
    End Sub

    Private Sub ACCurrent()
        MessageBox.Show("Connect a wire from the Calibrator I (Current) terminal to the DMM I (Current) terminal.")
        MessageBox.Show("Connect a wire from the Calibrator LO terminal to the DMM LO terminal.")
        MessageBox.Show("Disconnect all other wires, shorts and equipment.")
        Me.Calibrator.Preset()
        Me.DUT.Clear()
        Me.DUT.Preset()

        For I As Integer = 0 To Me.DUT.TestPoints.ACCurrentTestRanges.GetUpperBound(0)
            Me.DUT.Sections.Configure.AC.AmpRange = Me.DUT.TestPoints.ACCurrentTestRanges(I)
            Me.Calibrator.Sections.Output.Amps = Me.DUT.TestPoints.ACCurrentTestAppliedCurrents(I)
            Me.Calibrator.Sections.Output.Frequency = Me.DUT.TestPoints.ACCurrentTestAppliedFrequencies(I)
            Me.Calibrator.Sections.Output.State = OnOffStateEnum.[On]
            Me.StoreResult("AC Current", Me.DUT.TestPoints.ACCurrentTestAppliedCurrents(I) & "A @ " & Me.DUT.TestPoints.ACCurrentTestAppliedFrequencies(I) & Me.Calibrator.Sections.Output.FrequencySuffix.ToString, Me.DUT.TestPoints.ACCurrentTestRanges(I) & "A")
        Next
        Me.TestCompleted()
    End Sub

    Private Sub OnInstrumentDataSent(ByVal sender As Instrument, ByVal data As String)
        Me.tbSentData.AppendText(NewLine & "Pri " & sender.PrimaryAddress & " Sec " & sender.SecondaryAddress & " - " & sender.Model & " - " & data)
    End Sub

    Private Sub OnInstrumentDataRead(ByVal sender As Instrument, ByVal data As String)
        Me.tbReadData.AppendText(NewLine & "Pri " & sender.PrimaryAddress & " Sec " & sender.SecondaryAddress & " - " & sender.Model & " - " & data)
    End Sub

    Private Sub DisposeOfInstruments()
        If Not (Me.DUT Is Nothing) Then
            Me.DUT.Dispose()
        End If
        If Not (Me.Calibrator Is Nothing) Then
            Me.Calibrator.Dispose()
        End If
    End Sub

    Private Sub DigitalMultimeterProcedureFormClosing(sender As System.Object, e As System.ComponentModel.CancelEventArgs)
        Me.DisposeOfInstruments()
    End Sub

End Class

