'
' Created by SharpDevelop.
' User: rspage
' Date: 6/29/2005
' Time: 12:41 PM
' 



Imports System
Imports FreeCal.Common
Imports System.Windows.Forms
Imports FreeCal.Instruments.SignalGenerators
Imports FreeCal.Instruments.MeasuringReceivers
Imports NationalInstruments.NI4882
Imports Microsoft.VisualBasic.ControlChars
Imports System.Data
Imports FreeCal.Data
Imports System.Threading
Imports FreeCal.Conversion

	Public Class StepAttenuatorProcedure
		Inherits FreeCal.Procedures.Procedure

		Protected _dtResults As DataTable

		Protected _SelectedSigGen As String = "AnritsuMG3696A"
		Protected _SelectedMeasRec As String = "Agilent8902A"
		Protected _SigGenAddress As Byte = 19
		Protected _MeasRecAddress As Byte = 14

		Protected _SigGen As AnritsuMG3696A
		Protected _MeasRec As Agilent8902A

		Protected _MaxAttenuation As Double = 110
		Protected _AttenuationStepSize As Double = 10

		Protected _ResultForm As Form

		Public Property ResultForm As Form
			Get
				Return Me._ResultForm
			End Get
			Set
				Me._ResultForm = Value
			End Set
		End Property

		Public Property MeasRecAddress As Byte
			Get
				Return Me._MeasRecAddress
			End Get
			Set
				Me._MeasRecAddress = Value
			End Set
		End Property

		Public Property SigGenAddress As Byte
			Get
				Return Me._SigGenAddress
			End Get
			Set
				Me._SigGenAddress = Value
			End Set
		End Property

		Public Property SelectedMeasRec As String
			Get
				Return Me._SelectedMeasRec
			End Get
			Set
				Me._SelectedMeasRec = Value
			End Set
		End Property

		Public Property SelectedSigGen As String
			Get
				Return Me._SelectedSigGen
			End Get
			Set
				Me._SelectedSigGen = Value
			End Set
		End Property

		Public Sub New(ByVal dUTAttenuatorAssetNumber As String, ByRef ResultsDataGrid As DataGrid)
			MyBase.New(DUTAttenuatorAssetNumber)
			Me.dgResults = ResultsDataGrid
			Me._dtResults = New DataTable(DUTAttenuatorAssetNumber)
			Me.InitializeInstruments
		End Sub

	#Region "Instruments"

		Private Sub InitializeInstruments
			'Try
				Me._SigGen = New AnritsuMG3696A(0, 19, False, False)
			'Catch
			'End Try
			'Try
					Me._MeasRec = New Agilent8902A(0, 14, False, False)
			'Catch
			'End Try
			'Try
				If (Me._GPIB0 Is Nothing) Then
					Me._GPIB0 = New Board(0)
				End If
				Me._GPIB0.IOTimeout = TimeoutValue.T3s
				Me._GPIB0.SendInterfaceClear
				Me._GPIB0.BecomeActiveController(True)
			'Catch
			'End Try
			'Try
				Me._SigGen.Preset
			'Catch
			'End Try
			'Try
				Me._MeasRec.Preset
			'Catch
			'End Try
		End Sub

		Public Sub UnInitializeInstruments
			Try
				Me._SigGen.Dispose
			Catch
			End Try
			Try
				Me._MeasRec.Dispose
			Catch
			End Try
			Try
				Me._GPIB0.Dispose
			Catch
			End Try
		End Sub

	#End Region

		Public Sub MeasureDUT(ByVal testFrequency As Double, ByVal testFrequencySuffix As FrequencyEnum, ByVal maxAttenuation As Double, ByVal waitBetweenMeasurements As Integer)
			Dim TempReading As Double
			Me._dtResults.Columns.Clear
			Me._dtResults.Columns.Add(New DataColumn("Frequency (" & TestFrequencySuffix.ToString & ")"))
			Me._dtResults.Columns.Add(New DataColumn("Setting"))
			Me._dtResults.Columns.Add(New DataColumn("Run 1"))
			Me._dtResults.Columns.Add(New DataColumn("Run 2"))
			Me._dtResults.Columns.Add(New DataColumn("Run 3"))
			For I As Integer = 10 To 110 Step 10
				Dim NewDR As DataRow = Me._dtResults.NewRow
				NewDR(0) = TestFrequency
				NewDR(1) = I
				Me._dtResults.Rows.Add(NewDR)
			Next
			Me.dgResults.DataMember = Me.DUTAssetNumber
			Me.dgResults.DataSource = Me._dtResults
			Me.ResultForm.Refresh
			For Run As Integer = 1 To 1
				Me._SigGen.Sections.RF.Amplitude.Level = 0
				Me._SigGen.Sections.RF.Frequency.Suffix = TestFrequencySuffix
				Me._SigGen.Sections.RF.Frequency.CW = TestFrequency
				Me._MeasRec.Write("39.9SP")
				Me._MeasRec.Preset
				If ConvertFrequency.Convert(TestFrequency, TestFrequencySuffix, FrequencyEnum.MHz) > 1300 Then
					MessageBox.Show("Connect an 11792A Sensor to the 8902A.")
					Me._MeasRec.Sections.Calibration.RFZeroCal
					MessageBox.Show("Connect the Sensor to one end of the RF cable, connect the other end of the cable to the Signal Generator RF output.")
					Me._MeasRec.Sections.Measurements.FrequencyOffsetMode.SetupTunedRFLevelFrequencyOffsetMode(TestFrequency, TestFrequencySuffix)
				Else
					MessageBox.Show("Connect an 11722A Sensor to the 8902A.")
					Me._MeasRec.Sections.Calibration.RFZeroCal
					TempReading = Me._MeasRec.Sections.Triggers.TriggerWithSettlingAndReadSingle
					MessageBox.Show("Connect the Sensor to one end of the RF cable, connect the other end of the cable to the Signal Generator RF output.")
					Me._MeasRec.Sections.Measurements.Frequency
					TempReading = Me._MeasRec.Sections.Triggers.TriggerWithSettlingAndReadSingle
					Me._MeasRec.Write(Me._MeasRec.Commands.InputFrequencyMHz)
					Me._MeasRec.Sections.Measurements.TunedRFLevel
				End If
				Me._MeasRec.Sections.Display.Scale = MeasuringReceiverDisplayScaleEnum.Logarithmic
				TempReading = Me._MeasRec.Sections.Triggers.TriggerWithSettlingAndReadSingle
				If MessageBox.Show("Is the ReCal light on?", "User Input", MessageBoxButtons.YesNo) = DialogResult.Yes Then
					Me._MeasRec.Sections.Calibration.Calibrate
					TempReading = Me._MeasRec.Sections.Triggers.TriggerWithSettlingAndReadSingle
				End If
				MessageBox.Show("Set the Attenuator to 0dBm and connect the Sensor to the Attenuator Output." & NewLine & "Connect the RF Cable to the Attenuator Input.")
				TempReading = Me._MeasRec.Sections.Triggers.TriggerWithSettlingAndReadSingle
				TempReading = Me._MeasRec.Sections.Triggers.TriggerWithSettlingAndReadSingle
				TempReading = Me._MeasRec.Sections.Triggers.TriggerWithSettlingAndReadSingle
				Me._MeasRec.Write("RF")
				TempReading = Me._MeasRec.Sections.Triggers.TriggerWithSettlingAndReadSingle
				Dim CurrentRow As Integer = 0
				Me._MeasRec.IOTimeout = TimeoutValue.T100s
				Me._GPIB0.IOTimeout = TimeoutValue.T100s
				For TestAmplitude As Double = 10 To MaxAttenuation Step Me._AttenuationStepSize
					MessageBox.Show("Set the attenuator to -" & TestAmplitude & ".")
					TempReading = Me._MeasRec.Sections.Triggers.TriggerWithSettlingAndReadSingle
					If MessageBox.Show("Is the ReCal light on?", "User Input", MessageBoxButtons.YesNo) = DialogResult.Yes Then
						Me._MeasRec.Sections.Calibration.Calibrate
						TempReading = Me._MeasRec.Sections.Triggers.TriggerWithSettlingAndReadSingle
					End If
					Thread.Sleep(WaitBetweenMeasurements)
					Me._dtResults.Rows(CurrentRow)(0) = TestFrequency
					Me._dtResults.Rows(CurrentRow)(1) = TestAmplitude
					TempReading = Me._MeasRec.Sections.Triggers.TriggerWithSettlingAndReadSingle
					Me._dtResults.Rows(CurrentRow)("Run " & Run) = TempReading
					Me.ResultForm.Refresh
					CurrentRow += 1
				Next TestAmplitude
				MessageBox.Show("Record the final Run result if a zero was measured.")
			Next Run
		End Sub

	End Class

