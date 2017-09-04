'
' Created by SharpDevelop.
' User: rspage
' Date: 5/31/2005
' Time: 8:15 AM
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
Imports FreeCal.Instruments.Counters
Imports FreeCal.Instruments.MeasuringReceivers
Imports FreeCal.Instruments.PowerMeters
Imports FreeCal.Instruments.SignalGenerators
Imports FreeCal.Instruments.SpectrumAnalyzers
Imports FreeCal.DialogBoxes
Imports FreeCal.Data


	Public Class SpectrumAnalyzerProcedure
		Inherits FreeCal.Procedures.Procedure

		Private DUT As Agilent8566B
		Private HighFrequencySigGen As AnritsuMG3696A
		Private LowFrequencySigGen As IFR2050
		Private PwrMtr As AgilentE4417A

'        Public Results As TestResults

        Protected Sub StoreTestResultsToResultsDataSet
        End Sub

        Protected Overridable Sub CreateNewTestResultsDataTable(ByVal testTitle As String)
            'Me.dgResults.DataSource = Me.CurrentTestResults
            Me.dgResults.Update
            Me.dgResults.Refresh
        End Sub

		Public Sub New(DUTAssetNumber)
			MyBase.New(DUTAssetNumber)
		End Sub

        Private Sub Agilent8902AMeasuringReceiverAMFMZeroCal
			MessageBox.Show("Zero/Cal the 11722A Power Sensor using the AM/FM Calibration Routine")
        End Sub

		Private Sub InitializeInstruments
			If (Me._GPIB0 Is Nothing) Then Me._GPIB0 = New Board(0)
			If (Me.DUT Is Nothing) Then Me.DUT = New Agilent8566B(Me.DUTBusNumber, Me.DUTAddress, False)
			If (Me.HighFrequencySigGen Is Nothing) Then Me.HighFrequencySigGen = New AnritsuMG3696A(0, 11, False)
			If (Me.LowFrequencySigGen Is Nothing) Then Me.LowFrequencySigGen = New IFR2050(0, 5, False)
			If (Me.PwrMtr Is Nothing) Then Me.PwrMtr = New AgilentE4417A(0, 13, False)
			Try
				Me.DUT.Preset
			Catch
				MessageBox.Show("There was a problem connecting to the DUT, make sure all GPIB cables are attached and the device is on.")
			End Try
			Try
				Me.HighFrequencySigGen.Preset
			Catch
				MessageBox.Show("There was a problem connecting to the High Frequency Signal Generator, make sure all GPIB cables are attached and the device is on.")
			End Try
		End Sub

		Public Sub AllTests
		End Sub

		Public Function GetPowerSensorModelToUse(ByVal frequency As Double, ByVal amplitude As Double) As String
			Select Case Frequency
				Case < 10000000
					Return "8482A"
			End Select
		End Function

'=============================
'		    Tests
'=============================

		Public Sub CenterFrequencyReadoutAccuracyTest()
			Me.InitializeInstruments
			Me.DUT.Calibrate
			Me.HighFrequencySigGen.Sections.RF.Amplitude.Level = 0
			MessageBox.Show("Connect the High Frequency Signal Generator output to the DUT input.")
			For Each TestFrequency As Double In Me.DUT.TestPoints.CenterFrequencyReadoutAccuracyTestFrequencies
				Me.HighFrequencySigGen.Sections.RF.Frequency.CW = TestFrequency
				Me.DUT.Sections.Frequency.Center = TestFrequency
				For Each TestSpanWidth As Double In Me.DUT.TestPoints.CenterFrequencyReadoutAccuracyTestSpanWidths
					Me.DUT.Sections.Span.Width = TestSpanWidth
					Me.DUT.WaitForSweepThenExecuteNextCommand
					Me.DUT.Sections.Markers.PeakSearchHigh
					Me.DUT.WaitForSweepThenExecuteNextCommand
					Me.DUT.Sections.Markers.SetReferenceLevelToMarker
					Me.DUT.WaitForSweepThenExecuteNextCommand
					'Me.StoreMeasurement(TestFrequency & "MHz - " & TestSpanWidth & "MHz SW Frequency Readout Accuracy", TestFrequency, Me.HighFrequencySigGen.Sections.RF.Amplitude.Level, TestFrequency - ((TestSpanWidth * 1000000000) * Me.DUT.Specifications.CenterFrequencyReadoutAccuracyTolernace), Me.DUT.Sections.FrequencyReadOut, TestFrequency + ((TestSpanWidth * 1000000000) * Me.DUT.Specifications.CenterFrequencyReadoutAccuracyTolernace))
				Next TestSpanWidth
			Next TestFrequency
		End Sub

		Public Sub FrequencySpanAccuracyTest()
			Me.InitializeInstruments
			Me.DUT.Sections.Amplitude.ReferenceLevel = 0
			Me.DUT.Sections.Markers.MarkerReadout = MarkerReadoutEnum.Frequency
			Dim LowFrequencyMessageBoxShown As Boolean = False
			Dim HighFrequencyMessageBoxShown As Boolean = False
			For Each TestFrequency As Double In Me.DUT.TestPoints.FrequencySpanAccuracyTestCenterFrequencies
				Me.DUT.Sections.Frequency.Center = TestFrequency
				If TestFrequency = 40 Then
					Me.HighFrequencySigGen.Sections.RF.Amplitude.Level = 0
					If Not HighFrequencyMessageBoxShown Then
						MessageBox.Show("Connect the High Frequency Signal Generator output to the DUT input.")
						HighFrequencyMessageBoxShown = True
					End If
					For Each TestSpanWidth As Double In Me.DUT.TestPoints.LowFrequencySpanAccuracyTestSpanWidths
						Me.DUT.Sections.Span.Width = TestSpanWidth
						Dim LowSetting As Double = TestFrequency - (TestSpanWidth * 0.4)
						Dim HighSetting As Double = TestFrequency + (TestSpanWidth * 0.4)
						Dim Nominal As Double = HighSetting - LowSetting
						Me.HighFrequencySigGen.Sections.RF.Frequency.CW = LowSetting
						Me.DUT.WaitForSweepThenExecuteNextCommand
						Me.DUT.Sections.Markers.PeakSearchHigh
						Me.DUT.Sections.Markers.SetDeltaMarker
						Dim DeltaMarkerReading As Double = Me.DUT.FrequencyReadout
						Me.HighFrequencySigGen.Sections.RF.Frequency.CW = HighSetting
						Me.DUT.WaitForSweepThenExecuteNextCommand
						Me.DUT.Sections.Markers.PeakSearchHigh
						'Me.StoreMeasurement("CF = " & TestFrequency & "MHz, SW = " & TestSpanWidth & "MHz - Frequency Span Accuracy", TestFrequency, Me.HighFrequencySigGen.Sections.RF.Amplitude.Level, Nominal - (Nominal * Me.DUT.Specifications.LowFrequencySpanAccuracyTolerance) ,Me.DUT.Sections.FrequencyReadout, Nominal + (Nominal * Me.DUT.Specifications.LowFrequencySpanAccuracyTolerance))
					Next TestSpanWidth
				Else
					Me.HighFrequencySigGen.Sections.RF.Amplitude.Level = 0
					If Not HighFrequencyMessageBoxShown Then
						MessageBox.Show("Connect the High Frequency Signal Generator output to the DUT input.")
						HighFrequencyMessageBoxShown = True
					End If
					For Each TestSpanWidth As Double In Me.DUT.TestPoints.HighFrequencySpanAccuracyTestSpanWidths
						Me.DUT.Sections.Span.Width = TestSpanWidth
						Dim LowSetting As Double = TestFrequency - (TestSpanWidth * 0.4)
						Dim HighSetting As Double = TestFrequency + (TestSpanWidth * 0.4)
						Dim Nominal As Double = HighSetting - LowSetting
						Me.HighFrequencySigGen.Sections.RF.Frequency.CW = LowSetting
						Me.DUT.WaitForSweepThenExecuteNextCommand
						Me.DUT.Sections.Markers.PeakSearchHigh
						Me.DUT.Sections.Markers.SetDeltaMarker
						Dim DeltaMarkerReading As Double = Me.DUT.FrequencyReadout
						Me.HighFrequencySigGen.Sections.RF.Frequency.CW = HighSetting
						Me.DUT.WaitForSweepThenExecuteNextCommand
						Me.DUT.Sections.Markers.PeakSearchHigh
						'Me.StoreMeasurement("CF = " & TestFrequency & "MHz, SW = " & TestSpanWidth & "MHz - Frequency Span Accuracy", TestFrequency, Me.HighFrequencySigGen.Sections.RF.Amplitude.Level, Nominal - (Nominal * Me.DUT.Specifications.HighFrequencySpanAccuracyTolerance) ,Me.DUT.Sections.FrequencyReadout, Nominal + (Nominal * Me.DUT.Specifications.HighFrequencySpanAccuracyTolerance))
					Next
				End If
			Next TestFrequency
		End Sub

		Public Sub ResolutionBandWidthAccuracyTest 'Not Complete (Problem setting delta markers -3db from Peak)
			Me.InitializeInstruments
			MessageBox.Show("Connect the DUT Cal Output to the DUT Input connector.")
			Me.DUT.Sections.Frequency.Center = 100
			Me.DUT.Sections.Amplitude.ReferenceLevel = -10
			For TestPoint As Integer = 0 To Me.DUT.TestPoints.ResolutionBandWidthAccuracyTestResolutionBandWidths.GetUpperBound(0) - 1
				Me.DUT.Sections.Span.Width = Me.DUT.TestPoints.ResolutionBandWidthAccuracyTestSpanWidths(TestPoint)
				Me.DUT.Sections.Control.BW.ResolutionBandwidth = Me.DUT.TestPoints.ResolutionBandWidthAccuracyTestResolutionBandWidths(TestPoint)
				Me.DUT.Scale = SpectrumAnalyzerScaleEnum.Linear
				Me.DUT.Write("KSA;")
				Me.DUT.Write("MKTYPE AMP;")
				Me.DUT.WaitForSweepThenExecuteNextCommand
				Thread.Sleep(1000)
				Me.DUT.Sections.Markers.PeakSearchHigh
				Me.DUT.Sections.Markers.SetDeltaMarker
				Me.DUT.WaitForSweepThenExecuteNextCommand
				Thread.Sleep(1000)
				Me.DUT.Write("MKA-30")
				Me.DUT.WaitForSweepThenExecuteNextCommand
				Thread.Sleep(1000)
				Me.DUT.Sections.Markers.SetDeltaMarker
				Me.DUT.Sections.Markers.PeakSearchHigh
				Me.DUT.WaitForSweepThenExecuteNextCommand
				Thread.Sleep(1000)
				Me.DUT.Write("MKA30")
				Me.DUT.WaitForSweepThenExecuteNextCommand
				Thread.Sleep(1000)
				'Me.StoreMeasurement("Resolution Bandwidth (SW, " & Me.DUT.TestPoints.ResolutionBandWidthAccuracyTestResolutionBandWidths(TestPoint).ToString & ")", Me.DUT.TestPoints.ResolutionBandWidthAccuracyTestSpanWidths(TestPoint), 0, 0, Me.DUT.Sections.FrequencyReadout, 0)
			Next
		End Sub

		Public Sub FirstLOOutputAmplitudeTest
			Me.InitializeInstruments
			Me.PwrMtr.Sections.Calibration.ZeroAndCalibrate
			MessageBox.Show("Connect the power sensor to the DUT 1st LO output connector.")
			Me.DUT.Sections.Frequency.Stop = 5800
			Dim CurrentMinute As Integer
			Dim CurrentSecond As Integer
			Dim PowerLevel As Double
			Dim StartMinute As Integer = DateTime.Now.Minute
			Dim StartSecond As Integer = DateTime.Now.Second
			Me.DUT.Sections.Control.Sweep.Time = 100
			Do Until (CurrentMinute = StartMinute + 1 And CurrentSecond > StartSecond)
				'Me.tbResults.AppendText(Me.DUT.Sections.FrequencyReadout & ", " & Me.PwrMtr.MeasureAndReadSingle & NewLine)
				CurrentMinute = DateTime.Now.Minute
				CurrentSecond = DateTime.Now.Second
			Loop
		End Sub

	End Class

