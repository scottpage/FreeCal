'
' Created by SharpDevelop.
' User: rspage
' Date: 7/11/2005
' Time: 3:25 PM
' 

Imports System.Data
Imports System.Threading
Imports System.Windows.Forms
Imports FreeCal.Instruments.PowerMeters
Imports FreeCal.Instruments.SignalGenerators
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.ControlChars

Public Class Agilent8487AProcedure
    Inherits System.Windows.Forms.Form
    Private label3 As System.Windows.Forms.Label
    Private label2 As System.Windows.Forms.Label
    Private label1 As System.Windows.Forms.Label
    Private cbStdSN As System.Windows.Forms.ComboBox
    Private tbReferenceLevel As System.Windows.Forms.TextBox
    Private label5 As System.Windows.Forms.Label
    Private dataGrid1 As System.Windows.Forms.DataGrid
    Private tbDUTAssetNumber As System.Windows.Forms.TextBox
    Private btnTestStandard As System.Windows.Forms.Button
    Private nudDwellTime As System.Windows.Forms.NumericUpDown
    Private btnTestDUT As System.Windows.Forms.Button
    Private label4 As System.Windows.Forms.Label
    Private button1 As System.Windows.Forms.Button
    Private tbDUTReferenceCF As System.Windows.Forms.TextBox

    Protected _PowerMeter As AgilentE4417A
    Protected _SignalGenerator As AnritsuMG3696A
    Protected _Amplitudes(24) As Double
    Protected _Data As New DataTable("Data")
    Protected _TestFreqencies() As Double
    Protected _TestFrequencySuffix As FrequencyEnum
    Protected _TestFreqencyForm As New PowerSensorTestFrequencyForm
    Protected _ChartForm As PowerSensorCalibrationChartForm

    Public Sub New()
        MyBase.New
        '
        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        '
        Me.InitializeComponent()
        Dim LF(17) As Double
        For I As Double = 1 To 18
            LF(Convert.ToInt32(I) - 1) = I
        Next
        Me._TestFreqencies = SortList(LF)
        SortList(Me._TestFreqencies)
        Me._Data.Columns.Add(New DataColumn("Frequency (GHz)"))
        Me._Data.Columns.Add(New DataColumn("Standard"))
        Me._Data.Columns.Add(New DataColumn("DUT"))
        For Each I As Double In Me._TestFreqencies
            Dim DR As DataRow = Me._Data.NewRow
            DR(0) = I
            Me._Data.Rows.Add(DR)
        Next
        Me.dataGrid1.DataMember = "Data"
        Me.dataGrid1.DataSource = Me._Data
        Try
            Me._PowerMeter = New AgilentE4417A(0, 13, False)
            Me._SignalGenerator = New AnritsuMG3696A(0, 19, False)
            Me.cbStdSN.DataSource = Me._PowerMeter.Sections.Memory.GetCalibrationFactorTableNames
            If Me.cbStdSN.Items.Count > 0 Then
                Me.cbStdSN.SelectedIndex = 0
            End If
        Catch
            Me.btnTestDUT.Enabled = False
            Me.btnTestStandard.Enabled = False
            'MessageBox.Show("Make sure all required devices are attached to the bus and powered on", "Device Error")
        End Try
        Me.Refresh()
    End Sub

#Region " Windows Forms Designer generated code "
    ' This method is required for Windows Forms designer support.
    ' Do not change the method contents inside the source code editor. The Forms designer might
    ' not be able to load this method if it was changed manually.
    Private Sub InitializeComponent()
        Me.tbDUTReferenceCF = New System.Windows.Forms.TextBox
        Me.button1 = New System.Windows.Forms.Button
        Me.label4 = New System.Windows.Forms.Label
        Me.btnTestDUT = New System.Windows.Forms.Button
        Me.nudDwellTime = New System.Windows.Forms.NumericUpDown
        Me.btnTestStandard = New System.Windows.Forms.Button
        Me.tbDUTAssetNumber = New System.Windows.Forms.TextBox
        Me.dataGrid1 = New System.Windows.Forms.DataGrid
        Me.label5 = New System.Windows.Forms.Label
        Me.tbReferenceLevel = New System.Windows.Forms.TextBox
        Me.cbStdSN = New System.Windows.Forms.ComboBox
        Me.label1 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        CType(Me.nudDwellTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbDUTReferenceCF
        '
        Me.tbDUTReferenceCF.Location = New System.Drawing.Point(0, 72)
        Me.tbDUTReferenceCF.Name = "tbDUTReferenceCF"
        Me.tbDUTReferenceCF.Size = New System.Drawing.Size(128, 20)
        Me.tbDUTReferenceCF.TabIndex = 5
        Me.tbDUTReferenceCF.Text = ""
        AddHandler Me.tbDUTReferenceCF.KeyPress, AddressOf Me.TbDUTReferenceCFKeyPress
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(16, 320)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(104, 23)
        Me.button1.TabIndex = 9
        Me.button1.Text = "Test Frequencies"
        AddHandler Me.button1.Click, AddressOf Me.Button1Click
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.label4.Location = New System.Drawing.Point(8, 152)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(99, 17)
        Me.label4.TabIndex = 11
        Me.label4.Text = "Dwell Time (mS)"
        '
        'btnTestDUT
        '
        Me.btnTestDUT.Location = New System.Drawing.Point(120, 360)
        Me.btnTestDUT.Name = "btnTestDUT"
        Me.btnTestDUT.Size = New System.Drawing.Size(96, 23)
        Me.btnTestDUT.TabIndex = 2
        Me.btnTestDUT.Text = "Test DUT"
        AddHandler Me.btnTestDUT.Click, AddressOf Me.BtnTestDUTClick
        '
        'nudDwellTime
        '
        Me.nudDwellTime.Location = New System.Drawing.Point(0, 168)
        Me.nudDwellTime.Maximum = New Decimal(New Integer() {120000, 0, 0, 0})
        Me.nudDwellTime.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudDwellTime.Name = "nudDwellTime"
        Me.nudDwellTime.Size = New System.Drawing.Size(128, 20)
        Me.nudDwellTime.TabIndex = 10
        Me.nudDwellTime.Value = New Decimal(New Integer() {30000, 0, 0, 0})
        '
        'btnTestStandard
        '
        Me.btnTestStandard.Location = New System.Drawing.Point(16, 360)
        Me.btnTestStandard.Name = "btnTestStandard"
        Me.btnTestStandard.Size = New System.Drawing.Size(96, 23)
        Me.btnTestStandard.TabIndex = 1
        Me.btnTestStandard.Text = "Test Standard"
        AddHandler Me.btnTestStandard.Click, AddressOf Me.BtnTestStandardClick
        '
        'tbDUTAssetNumber
        '
        Me.tbDUTAssetNumber.Location = New System.Drawing.Point(0, 24)
        Me.tbDUTAssetNumber.Name = "tbDUTAssetNumber"
        Me.tbDUTAssetNumber.Size = New System.Drawing.Size(128, 20)
        Me.tbDUTAssetNumber.TabIndex = 3
        Me.tbDUTAssetNumber.Text = ""
        '
        'dataGrid1
        '
        Me.dataGrid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dataGrid1.DataMember = ""
        Me.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dataGrid1.Location = New System.Drawing.Point(224, 8)
        Me.dataGrid1.Name = "dataGrid1"
        Me.dataGrid1.Size = New System.Drawing.Size(432, 384)
        Me.dataGrid1.TabIndex = 0
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.label5.Location = New System.Drawing.Point(8, 200)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(95, 17)
        Me.label5.TabIndex = 13
        Me.label5.Text = "Reference Level"
        '
        'tbReferenceLevel
        '
        Me.tbReferenceLevel.Location = New System.Drawing.Point(0, 216)
        Me.tbReferenceLevel.Name = "tbReferenceLevel"
        Me.tbReferenceLevel.Size = New System.Drawing.Size(128, 20)
        Me.tbReferenceLevel.TabIndex = 12
        Me.tbReferenceLevel.Text = ""
        AddHandler Me.tbReferenceLevel.KeyPress, AddressOf Me.TbDUTReferenceCFKeyPress
        '
        'cbStdSN
        '
        Me.cbStdSN.Location = New System.Drawing.Point(0, 120)
        Me.cbStdSN.Name = "cbStdSN"
        Me.cbStdSN.Size = New System.Drawing.Size(128, 21)
        Me.cbStdSN.TabIndex = 4
        AddHandler Me.cbStdSN.KeyPress, AddressOf Me.CbStdSNKeyPress
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.label1.Location = New System.Drawing.Point(8, 8)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(111, 17)
        Me.label1.TabIndex = 6
        Me.label1.Text = "DUT Asset Number"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.label2.Location = New System.Drawing.Point(8, 104)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(117, 17)
        Me.label2.TabIndex = 7
        Me.label2.Text = "Standard Sensor SN"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.label3.Location = New System.Drawing.Point(8, 56)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(134, 17)
        Me.label3.TabIndex = 8
        Me.label3.Text = "DUT Reference CF (%)"
        '
        'Agilent8487AProcedure
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(664, 397)
        Me.Controls.Add(Me.tbReferenceLevel)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.nudDwellTime)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.tbDUTReferenceCF)
        Me.Controls.Add(Me.cbStdSN)
        Me.Controls.Add(Me.tbDUTAssetNumber)
        Me.Controls.Add(Me.btnTestDUT)
        Me.Controls.Add(Me.btnTestStandard)
        Me.Controls.Add(Me.dataGrid1)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label4)
        Me.Name = "Agilent8487AProcedure"
        Me.Text = "Agilent8487AProcedure"
        CType(Me.nudDwellTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub
#End Region

    Private Sub FillDataRows()
        If Not (Me._TestFreqencies Is Nothing) Then
            Me._Data.Rows.Clear()

            For Each I As String In Me._TestFreqencies
                Dim DR As DataRow = Me._Data.NewRow
                DR(0) = I
                Me._Data.Rows.Add(DR)
            Next I
        End If
    End Sub

    Private Sub BtnTestDUTClick(sender As System.Object, e As System.EventArgs)
        Me._ChartForm = New PowerSensorCalibrationChartForm
        Me._ChartForm.Close()
        Me._ChartForm.StartPosition = FormStartPosition.CenterScreen
        Me._ChartForm.Chart.GraphPane.CurveList.Clear()
        Dim DUTPointPairList As New PointPairList
        Me._ChartForm.Chart.GraphPane.AddCurve(Me.tbDUTAssetNumber.Text, DUTPointPairList, System.Drawing.Color.Red, SymbolType.Diamond)
        Me._ChartForm.StartPosition = FormStartPosition.CenterScreen
        Me._ChartForm.Show()
        Me._PowerMeter.Write("SENS2:CORR:CSET1:STAT OFF")
        Me._PowerMeter.Write("SENS2:CORR:GAIN1 " & Me.tbDUTReferenceCF.Text)
        Me._PowerMeter.Write("UNIT2:POW W")
        Me._PowerMeter.Sections.Calibration.ZeroAndCalibrate("B")
        MessageBox.Show("Connect the DUT to the Signal Generator output.")
        Me._SignalGenerator.Sections.RF.OutputState = OnOffStateEnum.[Off]
        Me._PowerMeter.Sections.Calibration.Zero("B", True)
        Me._SignalGenerator.Sections.RF.OutputState = OnOffStateEnum.[On]
        For Each DR As DataRow In Me._Data.Rows
            Me._SignalGenerator.Sections.RF.Frequency.CW = CDbl(DR(0))
            Me._SignalGenerator.Sections.RF.Amplitude.Level = CDbl(DR(1))
            Thread.Sleep(Convert.ToInt32(nudDwellTime.Value))
            Dim Measurement As Double = Me._PowerMeter.Sections.Measurements.GetAveragedMeasurement(10, "B")
            Measurement = Me._PowerMeter.Sections.Measurements.Measure("B")
            DR(2) = Measurement
            Dim P As New PointPair With {
                .X = CDbl(ConvertFrequency.Convert(CDbl(DR(0)), Me._TestFrequencySuffix, FrequencyEnum.GHz)),
                .Y = CDbl(Measurement)
            }
            Me._ChartForm.Chart.GraphPane.CurveList(0).AddPoint(P)
            Me._ChartForm.Chart.AxisChange()
            Me.Refresh()
        Next DR
    End Sub

    Private Sub BtnTestStandardClick(sender As System.Object, e As System.EventArgs)
        Me._PowerMeter.Write("UNIT1:POW DBM")
        Me._PowerMeter.Write("UNIT2:POW DBM")
        Me._PowerMeter.Write("SENS1:CORR:CSET1 " & Quote & cbStdSN.SelectedItem.ToString & Quote)
        Me._PowerMeter.Write("SENS1:CORR:CSET1:STAT ON")
        Me._PowerMeter.Sections.Calibration.ZeroAndCalibrate("A")
        MessageBox.Show("Connect the Standard Sensor to the Signal Generator output.")
        Me._SignalGenerator.Sections.RF.OutputState = OnOffStateEnum.[Off]
        Me._PowerMeter.Sections.Calibration.Zero("A", True)
        Me._SignalGenerator.Sections.RF.OutputState = OnOffStateEnum.[On]
        Me._SignalGenerator.Sections.RF.Frequency.Suffix = FrequencyEnum.GHz
        For Each DR As DataRow In Me._Data.Rows
            Me._PowerMeter.SetCalibrationFactor(Me._PowerMeter.ConvertFrequency(CDbl(DR(0)), FrequencyEnum.GHz, FrequencyEnum.MHz))
            Me._SignalGenerator.Sections.RF.Frequency.CW = CDbl(DR(0))
            Me.SetSourceAmplitude(CDbl(Me.tbReferenceLevel.Text), AmplitudeEnum.dBm)
            DR(1) = Format(Me._SignalGenerator.Sections.RF.Amplitude.Level, "#0.000")
            Me.Refresh()
        Next DR
        MessageBox.Show("The Standard Sensor reference calibration is complete.  You may now calibrate the DUT's.")
    End Sub

    Private Sub SetSourceAmplitude(ByVal desiredAmplitudeSetting As Double, ByVal desiredAmplitudeSuffix As AmplitudeEnum)
        Dim PwrMtrReading As Double = Convert.ToDouble(Format(Me._PowerMeter.Sections.Measurements.GetAveragedMeasurement(2, "A"), "#0.000"))
        PwrMtrReading = Convert.ToDouble(Format(Me._PowerMeter.Sections.Measurements.Measure("A"), "#0.000"))
        Dim LoopCounter As Integer = 0
        Do While (PwrMtrReading > desiredAmplitudeSetting + 0.006 Or PwrMtrReading < desiredAmplitudeSetting - 0.006)
            If desiredAmplitudeSetting = 0 Then
                Me._SignalGenerator.Sections.RF.Amplitude.Level += desiredAmplitudeSetting - PwrMtrReading
            ElseIf (desiredAmplitudeSetting > 0) Then
                Me._SignalGenerator.Sections.RF.Amplitude.Level += desiredAmplitudeSetting - PwrMtrReading
            ElseIf (desiredAmplitudeSetting < 0) Then
                Me._SignalGenerator.Sections.RF.Amplitude.Level += desiredAmplitudeSetting - PwrMtrReading
            End If
            Thread.Sleep(Convert.ToInt32(nudDwellTime.Value))
            PwrMtrReading = Convert.ToDouble(Format(Me._PowerMeter.Sections.Measurements.Measure("A"), "#0.000"))
        Loop
    End Sub

    Private Sub TbDUTReferenceCFKeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
        If Not ([Char].IsDigit(e.KeyChar) Or [Char].IsControl(e.KeyChar) Or e.KeyChar = ".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub CbStdSNKeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub Button1Click(sender As System.Object, e As System.EventArgs)
        If Me._TestFreqencyForm.ShowDialog = DialogResult.OK Then
            Me._TestFreqencies = Me._TestFreqencyForm.FrequencyList
            Me._TestFrequencySuffix = Me._TestFreqencyForm.FrequencyListSuffix
            Me._Data.Columns(0).ColumnName = "Frequency (" & Me._TestFrequencySuffix.ToString & ")"
            Me.FillDataRows()
        End If
    End Sub

End Class

