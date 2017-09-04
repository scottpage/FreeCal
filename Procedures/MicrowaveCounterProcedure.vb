'
' Created by SharpDevelop.
' User: rspage
' Date: 6/21/2005
' Time: 6:58 AM
' 

'
' Created by SharpDevelop.
' User: rspage
' Date: 6/15/2005
' Time: 12:49 PM
' 

Imports NationalInstruments.NI4882
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.ControlChars
Imports System
Imports System.Data
Imports System.IO
Imports System.Threading
Imports System.Windows.Forms
Imports FreeCal.Common
Imports FreeCal.Instruments
Imports FreeCal.Instruments.FunctionGenerators
Imports FreeCal.Instruments.PowerMeters
Imports FreeCal.Instruments.SignalGenerators
Imports FreeCal.Instruments.Counters
Imports FreeCal.DialogBoxes
Imports FreeCal.Data


	Public Class CounterProcedure
		Inherits FreeCal.Procedures.Procedure

	#Region "Declarations"

		Protected DUTCounter As Counter
		Protected HighFrequencySource As SignalGenerator
		Protected LowFrequencySource As FunctionGenerator
		Protected PwrMtr As PowerMeter
		Protected _ResultDataGrid As DataGrid

		Private FCResources As String = FreeCalResourceDirectory & "FreeCal.Instruments."
		Private Canceled As Boolean = False

		Public Results As CounterTestResultsTable

		Public SelectedDUTCounter As String
		Public DUTCounterAddress As Byte

		Public SelectedHighFrequencySource As String
		Public HighFrequencySourceAddress As Byte

		Public SelectedLowFrequencySource As String
		Public LowFrequencySourceAddress As Byte

		Public SelectedPwrMtr As String
		Public PwrMtrAddress As Byte

	#End Region

	#Region "Constructors"

		Public Sub New(ByVal dUTAssetNumber As String, ByRef ResultDataGrid As DataGrid)
			MyBase.New(DUTAssetNumber)
			Me.Results = New CounterTestResultsTable(DUTAssetNumber)
			Me._ResultDataGrid = ResultDataGrid
			Me._ResultDataGrid.DataSource = Me.Results
			Me._ResultDataGrid.Refresh
			Me._ResultDataGrid.Update
		End Sub

	#End Region

	#Region "Instruments"

		Private Sub InitializeInstruments
			If (Me.HighFrequencySource Is Nothing) Then
				Select Me.SelectedHighFrequencySource
					Case "AgilentE4433B"
						Me.HighFrequencySource = New AgilentE4433B(0, Me.HighFrequencySourceAddress, False, Me._Simulate)
					Case "IFR2050"
						Me.HighFrequencySource = New IFR2050(0, Me.HighFrequencySourceAddress, False, Me._Simulate)
					Case "Agilent8340A"
						Me.HighFrequencySource = New Agilent8340A(0, Me.HighFrequencySourceAddress, False, Me._Simulate)
					Case "Agilent8340B"
						Me.HighFrequencySource = New Agilent8340B(0, Me.HighFrequencySourceAddress, False, Me._Simulate)
					Case "Agilent8643A"
						Me.HighFrequencySource = New Agilent8643A(0, Me.HighFrequencySourceAddress, False, Me._Simulate)
					Case "Agilent8660D"
						Me.HighFrequencySource = New Agilent8660D(0, Me.HighFrequencySourceAddress, False, Me._Simulate)
					Case "AnritsuMG3696A"
						Me.HighFrequencySource = New AnritsuMG3696A(0, Me.HighFrequencySourceAddress, False, Me._Simulate)
					Case "Agilent8672A"
						Me.HighFrequencySource = New Agilent8672A(0, Me.HighFrequencySourceAddress, False, Me._Simulate)
				End Select
			End If
			If (Me.LowFrequencySource Is Nothing) Then
				Select Me.SelectedLowFrequencySource
					Case "Agilent3325B"
						Me.LowFrequencySource = New Agilent3325B(0, Me.LowFrequencySourceAddress, False, Me._Simulate)
				End Select
			End If
			If (Me.PwrMtr Is Nothing) Then
				Me.PwrMtr = New AgilentE4417A(0, Me.PwrMtrAddress, False, Me._Simulate)
			End If
			If (Me.DUTCounter Is Nothing) Then
				Select Me.SelectedDUTCounter
					Case "Agilent5342A"
						Me.DUTCounter = New Agilent5342A(0, Me.DUTCounterAddress, False, Me._Simulate)
					Case "Agilent5343A"
						Me.DUTCounter = New Agilent5343A(0, Me.DUTCounterAddress, False, Me._Simulate)
				End Select
			End If
			Try
				If (Me._GPIB0 Is Nothing) Then
					Me._GPIB0 = New Board(0)
				End If
				Me._GPIB0.IOTimeout = TimeoutValue.T3s
				Me._GPIB0.SendInterfaceClear
				Me._GPIB0.BecomeActiveController(True)
			Catch
			End Try
			Try
				Me.HighFrequencySource.Preset
			Catch
			End Try
			Try
				Me.LowFrequencySource.Preset
			Catch
			End Try
			Try
				Me.PwrMtr.Preset
			Catch
			End Try
			Try
				Me.DUTCounter.Preset
			Catch
			End Try
		End Sub

		Public Sub UnInitializeInstruments
			Try
				Me.HighFrequencySource.Dispose
			Catch
			End Try
			Try
				Me.LowFrequencySource.Dispose
			Catch
			End Try
			Try
				Me.PwrMtr.Dispose
			Catch
			End Try
			Try
				Me.DUTCounter.Dispose
			Catch
			End Try
			Try
				Me._GPIB0.Dispose
			Catch
			End Try
		End Sub

	#End Region

		Private Sub SetSourceAmplitude(ByVal desiredAmplitudeSetting As Double, ByVal desiredAmplitudeSuffix As AmplitudeEnum, ByVal source As String)
			Dim PwrMtrReading As Double
			Dim LoopCounter As Integer = 0
			If Source = "LowFrequency" Then
				Thread.Sleep(1000)
				Me.LowFrequencySource.Amplitude = DesiredAmplitudeSetting
				PwrMtrReading = Me.PwrMtr.Sections.Measurements.Measure("A")
				Do While (PwrMtrReading > DesiredAmplitudeSetting + 0.02 Or PwrMtrReading < DesiredAmplitudeSetting - 0.02)
					If (PwrMtrReading > DesiredAmplitudeSetting) Then
						Me.LowFrequencySource.Amplitude = Me.LowFrequencySource.Amplitude - PwrMtrReading
					ElseIf (PwrMtrReading < DesiredAmplitudeSetting)
						Me.LowFrequencySource.Amplitude = Me.LowFrequencySource.Amplitude - PwrMtrReading
					End If
					Thread.Sleep(500)
					PwrMtrReading = Me.PwrMtr.Sections.Measurements.Measure("A")
				Loop
			ElseIf Source = "HighFrequency" Then
				Me.HighFrequencySource.Sections.RF.Amplitude.Level = DesiredAmplitudeSetting
				Thread.Sleep(500)
				PwrMtrReading = Format(Me.PwrMtr.Sections.Measurements.Measure("A"), "#0.00")
				Do While (PwrMtrReading > DesiredAmplitudeSetting + 0.01 Or PwrMtrReading < DesiredAmplitudeSetting)
					If DesiredAmplitudeSetting < 0 Then
						Me.HighFrequencySource.Sections.RF.Amplitude.Level += DesiredAmplitudeSetting - PwrMtrReading
					End If
					Thread.Sleep(500)
					PwrMtrReading = Format(Me.PwrMtr.Sections.Measurements.Measure("A"), "#0.00")
				Loop
			End If
		End Sub

		Public Sub AllTests
			Me.InitializeInstruments
			Me.FrequencyAccuracyAndDisplayTest
			Me.FrequencyRangeAndInputSensitivityTest
		End Sub

		Public Sub FrequencyAccuracyAndDisplayTest
			If MessageBox.Show("Do you want to test the Frequency Accuracy and Display?", "User Input", MessageBoxButtons.YesNo) = DialogResult.Yes
				MessageBox.Show("Connect the DUT FREQ STD OUTPUT to the DUT Input 2 BNC Connector.")
				Me.DUTCounter.FrequencyRange = CounterFrequencyRangeEnum.Low
				Me.Results.StoreResult("Frequency and Display Accuracy", "", Me.DUTCounter.Capabilities.ReferenceOscillatorFrequency - Me.DUTCounter.Specifications.ReferenceOscillatorFrequencyTolerance, Me.DUTCounter.Capabilities.ReferenceOscillatorFrequency + Me.DUTCounter.Specifications.ReferenceOscillatorFrequencyTolerance, Me.DUTCounter.SampleThenHoldAndReadDouble, Me.DUTCounter.Capabilities.ReferenceOscillatorFrequency, Me.DUTCounter.Capabilities.ReferenceOscillatorFrequencySuffix, 0)
				'5345A Manual Test of Frequency Accuracy (Add)
			End If
		End Sub

		Public Sub FrequencyRangeAndInputSensitivityTest
			If MessageBox.Show("Do you want to test the Low Frequency Range and Display?", "User Input", MessageBoxButtons.YesNo) = DialogResult.Yes
				Me.DUTCounter.FrequencyRange = CounterFrequencyRangeEnum.Low
				Me.DUTCounter.Resolution = Agilent5343AResolutionModeEnum.OneHz
				Me.LowFrequencySource.FrequencySuffix = FrequencyEnum.MHz
				Me.LowFrequencySource.AmplitudeSuffix = AmplitudeEnum.dBm
				Me.LowFrequencySource.Amplitude = -19.03
				MessageBox.Show("Set the 50 Ohm/1M Ohm switch to 50 Ohm and connect the Low Frequency Source to the DUT Low Range Input Connector.")
				For Each TestFrequency As Double In Me.DUTCounter.TestPoints.LowRangeTestFrequencies
					Me.LowFrequencySource.Frequency = TestFrequency
					Thread.Sleep(1000)
					'Me.Results.StoreResult("Frequency and Display Accuracy", "", Me.DUTCounter.Capabilities.ReferenceOscillatorFrequency - Me.DUTCounter.Specifications.ReferenceOscillatorFrequencyTolerance, Me.DUTCounter.Capabilities.ReferenceOscillatorFrequency + Me.DUTCounter.Specifications.ReferenceOscillatorFrequencyTolerance, Me.DUTCounter.SampleThenHoldAndReadSingle, Me.DUTCounter.Capabilities.ReferenceOscillatorFrequency, Me.DUTCounter.Capabilities.ReferenceOscillatorFrequencySuffix, 0)
				Next
			End If
			If MessageBox.Show("Do you want to test the High Frequency Accuracy and Display?", "User Input", MessageBoxButtons.YesNo) = DialogResult.Yes
				Me.PwrMtr.Sections.Calibration.ZeroAndCalibrate
				MessageBox.Show("Connect the High Frequency Source Output to the Splitter Input." & NewLine & "Connect one Splitter Output directly to the DUT Input." & NewLine & "Connect the Power Sensor to the remaining Splitter Output.")
				Me.HighFrequencySource.Sections.RF.Amplitude.Level = -19.03
				For Each TestFrequency As Double In Me.DUTCounter.TestPoints.HighRangeTestFrequencies
					Me.HighFrequencySource.Sections.RF.Frequency.CW = TestFrequency
					Me.SetSourceAmplitude(-19.03, AmplitudeEnum.dBm, "HighFrequency")
					Thread.Sleep(1000)
					Me.DUTCounter.Preset
					Me.DUTCounter.FrequencyRange = CounterFrequencyRangeEnum.High
					Me.DUTCounter.FrequencyMode = AutomaticManualModeEnum.Auto
					Me.DUTCounter.SampleThenHoldAndReadDouble
					Me.DUTCounter.SampleThenHoldAndReadDouble
					'Me.Results.StoreResult(TestFrequency, Me.HighFrequencySource.Sections.RF.Frequency.Suffix, "High Range Input Sensitivity", Me.DUTCounter.SampleThenHoldAndReadSingle, CDbl(TestFrequency), CDbl(TestFrequency))
				Next
			End If
		End Sub

	End Class

