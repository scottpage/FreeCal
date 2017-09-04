'
' Created by SharpDevelop.
' User: rspage
' Date: 6/28/2005
' Time: 8:09 AM
' 

Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports FreeCal.Common
Imports FreeCal.Instruments
Imports NationalInstruments.NI4882
Imports Microsoft.VisualBasic.ControlChars
Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.Threading
Imports Microsoft.VisualBasic


	
	Public Class NetworkAnalyzerDataCollectionForm
		Inherits System.Windows.Forms.Form
		Private dtData As New DataTable("Data")
		Private lblTotalAverage As System.Windows.Forms.Label
		Private cbFormat As System.Windows.Forms.ComboBox
		Private btnGetList As System.Windows.Forms.Button
		Private tbRunAverages As System.Windows.Forms.TextBox
		Private tbTestFrequency As System.Windows.Forms.TextBox
		Private lblTimeRemaining As System.Windows.Forms.Label
		Private nudPointsPerRun As System.Windows.Forms.NumericUpDown
		Private dgData As System.Windows.Forms.DataGrid
		Private nudDelay As System.Windows.Forms.NumericUpDown
		Private label7 As System.Windows.Forms.Label
		Private nudRuns As System.Windows.Forms.NumericUpDown
		Private cbParameter As System.Windows.Forms.ComboBox
		Private label3 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label1 As System.Windows.Forms.Label
		Private cbTestFrequencySuffix As System.Windows.Forms.ComboBox
		Private label6 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private lblCurrentPoint As System.Windows.Forms.Label
		Private btnGetData As System.Windows.Forms.Button
		
		Protected _MainNetworkAnalyzer As NetworkAnalyzer

		Public Sub New(ByRef MainNetworkAnalyzer As NetworkAnalyzer)
			MyBase.New
			'
			' The Me.InitializeComponent call is required for Windows Forms designer support.
			'
			Me.InitializeComponent
			Me._MainNetworkAnalyzer = MainNetworkAnalyzer
			Me.FillComboBoxes
		End Sub
		
		#Region " Windows Forms Designer generated code "
		' This method is required for Windows Forms designer support.
		' Do not change the method contents inside the source code editor. The Forms designer might
		' not be able to load this method if it was changed manually.
		Private Sub InitializeComponent()
			Me.btnGetData = New System.Windows.Forms.Button
			Me.lblCurrentPoint = New System.Windows.Forms.Label
			Me.label4 = New System.Windows.Forms.Label
			Me.label5 = New System.Windows.Forms.Label
			Me.label6 = New System.Windows.Forms.Label
			Me.cbTestFrequencySuffix = New System.Windows.Forms.ComboBox
			Me.label1 = New System.Windows.Forms.Label
			Me.label2 = New System.Windows.Forms.Label
			Me.label3 = New System.Windows.Forms.Label
			Me.cbParameter = New System.Windows.Forms.ComboBox
			Me.nudRuns = New System.Windows.Forms.NumericUpDown
			Me.label7 = New System.Windows.Forms.Label
			Me.nudDelay = New System.Windows.Forms.NumericUpDown
			Me.dgData = New System.Windows.Forms.DataGrid
			Me.nudPointsPerRun = New System.Windows.Forms.NumericUpDown
			Me.lblTimeRemaining = New System.Windows.Forms.Label
			Me.tbTestFrequency = New System.Windows.Forms.TextBox
			Me.tbRunAverages = New System.Windows.Forms.TextBox
			Me.btnGetList = New System.Windows.Forms.Button
			Me.cbFormat = New System.Windows.Forms.ComboBox
			Me.lblTotalAverage = New System.Windows.Forms.Label
			CType(Me.nudRuns,System.ComponentModel.ISupportInitialize).BeginInit
			CType(Me.nudDelay,System.ComponentModel.ISupportInitialize).BeginInit
			CType(Me.dgData,System.ComponentModel.ISupportInitialize).BeginInit
			CType(Me.nudPointsPerRun,System.ComponentModel.ISupportInitialize).BeginInit
			Me.SuspendLayout
			'
			'btnGetData
			'
			Me.btnGetData.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
			Me.btnGetData.Location = New System.Drawing.Point(16, 440)
			Me.btnGetData.Name = "btnGetData"
			Me.btnGetData.TabIndex = 1
			Me.btnGetData.Text = "Get Point"
			AddHandler Me.btnGetData.Click, AddressOf Me.BtnGetDataClick
			'
			'lblCurrentPoint
			'
			Me.lblCurrentPoint.AutoSize = true
			Me.lblCurrentPoint.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
			Me.lblCurrentPoint.Location = New System.Drawing.Point(256, 8)
			Me.lblCurrentPoint.Name = "lblCurrentPoint"
			Me.lblCurrentPoint.Size = New System.Drawing.Size(183, 17)
			Me.lblCurrentPoint.TabIndex = 15
			Me.lblCurrentPoint.Text = "Current Run:   - Current Point:  "
			'
			'label4
			'
			Me.label4.AutoSize = true
			Me.label4.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
			Me.label4.Location = New System.Drawing.Point(16, 64)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(33, 17)
			Me.label4.TabIndex = 9
			Me.label4.Text = "Runs"
			'
			'label5
			'
			Me.label5.AutoSize = true
			Me.label5.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
			Me.label5.Location = New System.Drawing.Point(8, 128)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(91, 17)
			Me.label5.TabIndex = 11
			Me.label5.Text = "Test Frequency"
			'
			'label6
			'
			Me.label6.AutoSize = true
			Me.label6.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
			Me.label6.Location = New System.Drawing.Point(120, 128)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(127, 17)
			Me.label6.TabIndex = 13
			Me.label6.Text = "Test Frequency Suffix"
			'
			'cbTestFrequencySuffix
			'
			Me.cbTestFrequencySuffix.Location = New System.Drawing.Point(144, 144)
			Me.cbTestFrequencySuffix.Name = "cbTestFrequencySuffix"
			Me.cbTestFrequencySuffix.Size = New System.Drawing.Size(64, 21)
			Me.cbTestFrequencySuffix.TabIndex = 12
			'
			'label1
			'
			Me.label1.AutoSize = true
			Me.label1.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
			Me.label1.Location = New System.Drawing.Point(8, 8)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(64, 17)
			Me.label1.TabIndex = 3
			Me.label1.Text = "Parameter"
			'
			'label2
			'
			Me.label2.AutoSize = true
			Me.label2.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
			Me.label2.Location = New System.Drawing.Point(104, 8)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(45, 17)
			Me.label2.TabIndex = 5
			Me.label2.Text = "Format"
			'
			'label3
			'
			Me.label3.AutoSize = true
			Me.label3.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
			Me.label3.Location = New System.Drawing.Point(80, 64)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(88, 17)
			Me.label3.TabIndex = 7
			Me.label3.Text = "Points Per Run"
			'
			'cbParameter
			'
			Me.cbParameter.Location = New System.Drawing.Point(8, 24)
			Me.cbParameter.Name = "cbParameter"
			Me.cbParameter.Size = New System.Drawing.Size(64, 21)
			Me.cbParameter.TabIndex = 2
			'
			'nudRuns
			'
			Me.nudRuns.Location = New System.Drawing.Point(8, 80)
			Me.nudRuns.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
			Me.nudRuns.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
			Me.nudRuns.Name = "nudRuns"
			Me.nudRuns.Size = New System.Drawing.Size(56, 20)
			Me.nudRuns.TabIndex = 8
			Me.nudRuns.Value = New Decimal(New Integer() {10, 0, 0, 0})
			'
			'label7
			'
			Me.label7.AutoSize = true
			Me.label7.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
			Me.label7.Location = New System.Drawing.Point(200, 64)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(36, 17)
			Me.label7.TabIndex = 19
			Me.label7.Text = "Delay"
			'
			'nudDelay
			'
			Me.nudDelay.Location = New System.Drawing.Point(192, 80)
			Me.nudDelay.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
			Me.nudDelay.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
			Me.nudDelay.Name = "nudDelay"
			Me.nudDelay.Size = New System.Drawing.Size(56, 20)
			Me.nudDelay.TabIndex = 18
			Me.nudDelay.Value = New Decimal(New Integer() {100, 0, 0, 0})
			'
			'dgData
			'
			Me.dgData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
						Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
			Me.dgData.DataMember = ""
			Me.dgData.HeaderForeColor = System.Drawing.SystemColors.ControlText
			Me.dgData.Location = New System.Drawing.Point(256, 24)
			Me.dgData.Name = "dgData"
			Me.dgData.Size = New System.Drawing.Size(600, 448)
			Me.dgData.TabIndex = 0
			'
			'nudPointsPerRun
			'
			Me.nudPointsPerRun.Location = New System.Drawing.Point(96, 80)
			Me.nudPointsPerRun.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
			Me.nudPointsPerRun.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
			Me.nudPointsPerRun.Name = "nudPointsPerRun"
			Me.nudPointsPerRun.Size = New System.Drawing.Size(56, 20)
			Me.nudPointsPerRun.TabIndex = 6
			Me.nudPointsPerRun.Value = New Decimal(New Integer() {100, 0, 0, 0})
			'
			'lblTimeRemaining
			'
			Me.lblTimeRemaining.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
			Me.lblTimeRemaining.AutoSize = true
			Me.lblTimeRemaining.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
			Me.lblTimeRemaining.Location = New System.Drawing.Point(672, 8)
			Me.lblTimeRemaining.Name = "lblTimeRemaining"
			Me.lblTimeRemaining.Size = New System.Drawing.Size(107, 17)
			Me.lblTimeRemaining.TabIndex = 20
			Me.lblTimeRemaining.Text = "Time Remaining:  "
			'
			'tbTestFrequency
			'
			Me.tbTestFrequency.Location = New System.Drawing.Point(8, 144)
			Me.tbTestFrequency.Name = "tbTestFrequency"
			Me.tbTestFrequency.TabIndex = 10
			Me.tbTestFrequency.Text = "18"
			'
			'tbRunAverages
			'
			Me.tbRunAverages.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
						Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
			Me.tbRunAverages.Location = New System.Drawing.Point(8, 176)
			Me.tbRunAverages.Multiline = true
			Me.tbRunAverages.Name = "tbRunAverages"
			Me.tbRunAverages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
			Me.tbRunAverages.Size = New System.Drawing.Size(240, 232)
			Me.tbRunAverages.TabIndex = 16
			Me.tbRunAverages.Text = ""
			'
			'btnGetList
			'
			Me.btnGetList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
			Me.btnGetList.Location = New System.Drawing.Point(152, 440)
			Me.btnGetList.Name = "btnGetList"
			Me.btnGetList.TabIndex = 21
			Me.btnGetList.Text = "Get List"
			AddHandler Me.btnGetList.Click, AddressOf Me.BtnGetListClick
			'
			'cbFormat
			'
			Me.cbFormat.Location = New System.Drawing.Point(96, 24)
			Me.cbFormat.Name = "cbFormat"
			Me.cbFormat.Size = New System.Drawing.Size(64, 21)
			Me.cbFormat.TabIndex = 4
			'
			'lblTotalAverage
			'
			Me.lblTotalAverage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
			Me.lblTotalAverage.AutoSize = true
			Me.lblTotalAverage.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
			Me.lblTotalAverage.Location = New System.Drawing.Point(8, 408)
			Me.lblTotalAverage.Name = "lblTotalAverage"
			Me.lblTotalAverage.Size = New System.Drawing.Size(94, 17)
			Me.lblTotalAverage.TabIndex = 17
			Me.lblTotalAverage.Text = "Total Average:  "
			'
			'NetworkAnalyzerDataCollectionForm
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(864, 477)
			Me.Controls.Add(Me.btnGetList)
			Me.Controls.Add(Me.nudDelay)
			Me.Controls.Add(Me.tbRunAverages)
			Me.Controls.Add(Me.cbTestFrequencySuffix)
			Me.Controls.Add(Me.tbTestFrequency)
			Me.Controls.Add(Me.nudRuns)
			Me.Controls.Add(Me.nudPointsPerRun)
			Me.Controls.Add(Me.cbFormat)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.cbParameter)
			Me.Controls.Add(Me.btnGetData)
			Me.Controls.Add(Me.dgData)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.lblCurrentPoint)
			Me.Controls.Add(Me.label7)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.label6)
			Me.Controls.Add(Me.lblTotalAverage)
			Me.Controls.Add(Me.lblTimeRemaining)
			Me.MinimumSize = New System.Drawing.Size(672, 336)
			Me.Name = "NetworkAnalyzerDataCollectionForm"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "NetworkAnalyzerDataCollectionForm"
			CType(Me.nudRuns,System.ComponentModel.ISupportInitialize).EndInit
			CType(Me.nudDelay,System.ComponentModel.ISupportInitialize).EndInit
			CType(Me.dgData,System.ComponentModel.ISupportInitialize).EndInit
			CType(Me.nudPointsPerRun,System.ComponentModel.ISupportInitialize).EndInit
			Me.ResumeLayout(false)
		End Sub
		#End Region

		Private Sub FillComboBoxes
			Dim Parameters As NetworkAnalyzerParameterEnum
			Dim Formats As NetworkAnalyzerFormatEnum
			Dim FrequencySuffixes As FrequencyEnum
			For Each Parameter As String In [Enum].GetNames(Parameters.GetType)
				Me.cbParameter.Items.Add(Parameter)
			Next
			For Each [Format] As String In [Enum].GetNames(Formats.GetType)
				Me.cbFormat.Items.Add([Format])
			Next
			For Each FrequencySuffix As String In [Enum].GetNames(FrequencySuffixes.GetType)
				Me.cbTestFrequencySuffix.Items.Add(FrequencySuffix)
			Next
			Me.cbParameter.SelectedIndex = 0
			Me.cbFormat.SelectedIndex = 0
			Me.cbTestFrequencySuffix.Text = "MHz"
		End Sub

		Private Sub BtnGetDataClick(sender As System.Object, e As System.EventArgs)
			Me.ClearControls
			Dim Parameters As NetworkAnalyzerParameterEnum
			Dim Formats As NetworkAnalyzerFormatEnum
			Dim FrequencySuffixes As FrequencyEnum
        Me._MainNetworkAnalyzer.Sections.Parameter.Current = CType([Enum].Parse(Parameters.GetType, cbParameter.SelectedItem.ToString), NetworkAnalyzerParameterEnum)
        Me._MainNetworkAnalyzer.Sections.[Format].Current = CType([Enum].Parse(Formats.GetType, Me.cbFormat.SelectedItem.ToString), NetworkAnalyzerFormatEnum)
        Me._MainNetworkAnalyzer.Sections.Markers.Current = NetworkAnalyzerMarkerEnum.Marker1
        Me._MainNetworkAnalyzer.Sections.Markers.Suffix = CType([Enum].Parse(FrequencySuffixes.GetType, Me.cbTestFrequencySuffix.SelectedItem.ToString), FrequencyEnum)
        Me._MainNetworkAnalyzer.Sections.Markers.Frequency = CDbl(Me.tbTestFrequency.Text)
			Me._MainNetworkAnalyzer.Sections.Output.DataType = NetworkAnalyzerOutputDataTypeEnum.Marker
			Me._MainNetworkAnalyzer.Sections.Output.DataFormat = NetworkAnalyzerDataFormatEnum.Form4
			Me.dtData.Columns.Add(New DataColumn("Point"))
        For Point As Integer = 1 To Convert.ToInt32(nudPointsPerRun.Value)
            Dim NewDR As DataRow = Me.dtData.NewRow
            NewDR("Point") = Point
            Me.dtData.Rows.Add(NewDR)
        Next
        Me.dgData.DataMember = Me.dtData.TableName
			Me.dgData.DataSource = Me.dtData
			Dim RunTotal As Double = 0
			Dim Total As Double = 0
        Dim TotalSeconds As Integer = (Convert.ToInt32(Me.nudRuns.Value) * Convert.ToInt32(Me.nudPointsPerRun.Value) * Convert.ToInt32(Me.nudDelay.Value)) \ 1000
        Dim T1 As [DateTime] = DateTime.Now.AddSeconds(TotalSeconds)
        For Run As Integer = 1 To Convert.ToInt32(Me.nudRuns.Value)
            Me.dtData.Columns.Add(New DataColumn("Run " & Run))
            For Point As Integer = 0 To Convert.ToInt32(Me.nudPointsPerRun.Value) - 1
                Dim Reading As Double = Me._MainNetworkAnalyzer.Sections.Output.Marker
                Me.dtData.Rows(Point)(Run) = Reading
                RunTotal += Reading
                Me.lblCurrentPoint.Text = "Current Run:  " & Run & " - Current Point:  " & Point + 1
                Thread.Sleep(Convert.ToInt32(Me.nudDelay.Value))
                Me.lblTimeRemaining.Text = "Time Remaining:  " & DateDiff(DateInterval.Second, DateTime.Now, T1).ToString
                Me.Refresh()
            Next
            Me.tbRunAverages.AppendText("Run " & Run & " Average = " & RunTotal / Me.nudPointsPerRun.Value & NewLine)
            Total += RunTotal / Me.nudPointsPerRun.Value
            Me.lblTotalAverage.Text = "Total Average:  " & Total / Run
            Me.tbRunAverages.Refresh()
            RunTotal = 0
        Next
    End Sub

		Private Sub ClearControls
			Me.dgData.DataMember = ""
			Me.dgData.DataSource = Nothing
			Me.dtData.Clear
			Me.dtData.Columns.Clear
			Me.tbRunAverages.Clear
		End Sub

		Private Sub BtnGetListClick(sender As System.Object, e As System.EventArgs)
			Me.ClearControls
			Dim Parameters As NetworkAnalyzerParameterEnum
			Dim Formats As NetworkAnalyzerFormatEnum
			Dim FrequencySuffixes As FrequencyEnum
        Me._MainNetworkAnalyzer.Sections.Parameter.Current = CType([Enum].Parse(Parameters.GetType, Me.cbParameter.SelectedItem.ToString), NetworkAnalyzerParameterEnum)
        Me._MainNetworkAnalyzer.Sections.[Format].Current = CType([Enum].Parse(Formats.GetType, Me.cbFormat.SelectedItem.ToString), NetworkAnalyzerFormatEnum)
        Me._MainNetworkAnalyzer.Sections.Markers.Current = NetworkAnalyzerMarkerEnum.Marker1
        Me._MainNetworkAnalyzer.Sections.Markers.Suffix = CType([Enum].Parse(FrequencySuffixes.GetType, Me.cbTestFrequencySuffix.SelectedItem.ToString), FrequencyEnum)
        Me._MainNetworkAnalyzer.Sections.Output.DataType = NetworkAnalyzerOutputDataTypeEnum.Marker
			Me._MainNetworkAnalyzer.Sections.Output.DataFormat = NetworkAnalyzerDataFormatEnum.Form4
			Me.dtData.Columns.Add(New DataColumn("Frequency"))
			For TestFrequency As Integer = 50 To 6000 Step 50
				Dim NewDR As DataRow = Me.dtData.NewRow
				NewDR("Frequency") = TestFrequency
				Me.dtData.Rows.Add(NewDR)
			Next
			Me.dgData.DataMember = Me.dtData.TableName
			Me.dgData.DataSource = Me.dtData
			Dim RunTotal As Double = 0
			Dim Total As Double = 0
        For Run As Integer = 1 To Convert.ToInt32(Me.nudRuns.Value)
            Me._MainNetworkAnalyzer.Write("TITL" & Quote & "Run " & Run & Quote)
            Dim Point As Integer = 0
            Me.dtData.Columns.Add(New DataColumn("Run " & Run))
            For TestFrequency As Integer = 0 To 20000 Step 100
                Me._MainNetworkAnalyzer.Sections.Markers.Frequency = TestFrequency
                Dim Reading As Double = Me._MainNetworkAnalyzer.Sections.Output.Marker
                Me.dtData.Rows(Point)(Run) = Reading
                RunTotal += Reading
                Me.lblCurrentPoint.Text = "Current Run:  " & Run & " - Current Frequency:  " & TestFrequency
                Thread.Sleep(Convert.ToInt32(Me.nudDelay.Value))
                Point += 1
                Me.Refresh()
            Next
            Me.tbRunAverages.AppendText("Run " & Run & " Average = " & RunTotal / Me.nudPointsPerRun.Value & NewLine)
            Total += RunTotal / Me.nudPointsPerRun.Value
            Me.lblTotalAverage.Text = "Total Average:  " & Total / Run
            RunTotal = 0
            Me.tbRunAverages.Refresh()
        Next
    End Sub
		
	End Class

