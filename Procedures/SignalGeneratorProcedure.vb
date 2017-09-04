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
Imports FreeCal.Instruments
Imports FreeCal.Instruments.Counters
Imports FreeCal.Instruments.MeasuringReceivers
Imports FreeCal.Instruments.PowerMeters
Imports FreeCal.Instruments.SignalGenerators
Imports FreeCal.Instruments.SpectrumAnalyzers
Imports FreeCal.Instruments.AudioAnalyzers
Imports FreeCal.DialogBoxes
Imports FreeCal.Data
Imports System.Reflection
Imports System.Globalization
Imports System.Runtime.Remoting

	Public Class SignalGeneratorProcedure
		Inherits FreeCal.Procedures.Procedure

		Protected DUT As SignalGenerator
		Protected MeasuringRec As MeasuringReceiver
		Protected LowFrequencySigGen As SignalGenerator
		Protected AudioAn As AudioAnalyzer
		Protected SpecAn As SpectrumAnalyzer
		Protected HighFrequencyCounter As Counter
		Protected PwrMtr As PowerMeter
		Private FCResources As String = FreeCalResourceDirectory & "FreeCal.Instruments."
		Private dtResults As DataTable

'        Public Results As SignalGeneratorTestResultsTable

		Public SelectedDUTSignalGenerator As String
		Public SelectedSignalGenerator As String
		Public SelectedMeasuringReceiver As String
		Public SelectedSpectrumAnalyzer As String
		Public SelectedAudioAnalyzer As String
		Public SelectedPowerMeter As String

        Protected Sub StoreTestResultsToResultsDataSet
        End Sub

		Public Sub New(DUTAssetNumber)
			MyBase.New(DUTAssetNumber)
		End Sub

        Protected Sub CreateNewTestResultsDataTable(ByVal testTitle As String)
        	Me.dtResults = New DataTable(testTitle)
			Me.dtResults.Columns.Add(New DataColumn("Frequency"))
			Me.dtResults.Columns.Add(New DataColumn("Amplitude"))
			Me.dtResults.Columns.Add(New DataColumn("LowerTolerance"))
			Me.dtResults.Columns.Add(New DataColumn("Measurement"))
			Me.dtResults.Columns.Add(New DataColumn("UpperTolerance"))
            Me.dgResults.DataSource = Me.dtResults
            Me.dgResults.Update
            Me.dgResults.Refresh
        End Sub

        Private Sub MeasuringRecAMFMZeroCal
			MessageBox.Show("Zero/Cal the 11722A Power Sensor using the AM/FM Calibration Routine")
        End Sub

		Private Sub InitializeInstruments
			If (Me.DUT Is Nothing) Then
				Select Me.SelectedDUTSignalGenerator
					Case "AgilentE4433B"
						Me.DUT = New AgilentE4433B(0, Me.DUTAddress, False, Me._Simulate)
					Case "IFR2050"
						Me.DUT = New IFR2050(Me.DUTBusNumber, Me.DUTAddress, False, Me._Simulate)
					Case "Agilent8340A"
						Me.DUT = New Agilent8340A(Me.DUTBusNumber, Me.DUTAddress, False, Me._Simulate)
					Case "Agilent8643A"
						Me.DUT = New Agilent8643A(Me.DUTBusNumber, Me.DUTAddress, False, Me._Simulate)
					Case "Agilent8660D"
						Me.DUT = New Agilent8660D(Me.DUTBusNumber, Me.DUTAddress, False, Me._Simulate)
					Case "AnritsuMG3696A"
						Me.DUT = New AnritsuMG3696A(Me.DUTBusNumber, Me.DUTAddress, False, Me._Simulate)
					Case "Agilent8672A"
						Me.DUT = New Agilent8672A(Me.DUTBusNumber, Me.DUTAddress, False, Me._Simulate)
				End Select
			End If
			If (Me.LowFrequencySigGen Is Nothing) Then
				Select Me.SelectedSignalGenerator
					Case "AgilentE4433B"
						Me.LowFrequencySigGen = New AgilentE4433B(0, 1, False, Me._Simulate)
					Case "IFR2050"
						Me.LowFrequencySigGen = New IFR2050(0, 1, False, Me._Simulate)
					Case "Agilent8340A"
						Me.LowFrequencySigGen = New Agilent8340A(0, 1, False, Me._Simulate)
					Case "Agilent8643A"
						Me.LowFrequencySigGen = New Agilent8643A(0, 1, False, Me._Simulate)
					Case "Agilent8660D"
						Me.LowFrequencySigGen = New Agilent8660D(0, 1, False, Me._Simulate)
					Case "AnritsuMG3696A"
						Me.LowFrequencySigGen = New AnritsuMG3696A(0, 1, False, Me._Simulate)
					Case "Agilent8672A"
						Me.LowFrequencySigGen = New Agilent8672A(0, 1, False, Me._Simulate)
				End Select
			End If
			If (Me.SpecAn Is Nothing) Then
				Select Me.SelectedSpectrumAnalyzer
					Case "Agilent8564EC"
						Me.SpecAn = New Agilent8564EC(0, 2, False, Me._Simulate)
					Case "Agilent8566B"
						Me.SpecAn = New Agilent8566B(0, 2, False, Me._Simulate)
				End Select
			End If
			If (Me.AudioAn Is Nothing) Then
				Select Me.SelectedAudioAnalyzer
					Case "Agilent8903B"
						Me.AudioAn = New Agilent8903B(0, 3, False, Me._Simulate)
				End Select
			End If
			If (Me.MeasuringRec Is Nothing) Then
				Select Me.SelectedMeasuringReceiver
					Case "Agilent8902A"
						Me.MeasuringRec = New Agilent8902A(0, 14, False, Me._Simulate)
				End Select
			End If
			If (Me.PwrMtr Is Nothing) Then
				Select Me.SelectedPowerMeter
					Case "AgilentE4417A"
						Me.PwrMtr = New AgilentE4417A(0, 13, False, Me._Simulate)
					Case "Agilent437B"
						Me.PwrMtr = New Agilent437B(0, 13, False, Me._Simulate)
				End Select
			End If
			If (Me.HighFrequencyCounter Is Nothing) Then
				Select Me.SelectedMeasuringReceiver
					Case "Agilent5343A"
						Me.HighFrequencyCounter = New Agilent5343A(0, 5, False, Me._Simulate)
				End Select
			End If
			Try
				If (Me._GPIB0 Is Nothing) Then
					Me._GPIB0 = New Board(0)
				End If
				Me._GPIB0.IOTimeout = TimeoutValue.T30s
			Catch
			End Try
			Try
				Me.DUT.Preset
			Catch
			End Try
			Try
				Me.LowFrequencySigGen.Preset
			Catch
			End Try
			Try
				Me.PwrMtr.Preset
			Catch
			End Try
			Try
				Me.AudioAn.Preset
			Catch
			End Try
			Try
				Me.MeasuringRec.Preset
			Catch
			End Try
			Try
				Me.SpecAn.Preset
			Catch
			End Try
		End Sub

		Public Sub AllTests
			Me.HighAmplitudeAccuracyTest
			Me.AttenuatorAccuracyTest
			Me.CarrierFrequencyAccuracyTest
			Me.ResidualAMTest
			Me.AMModulationTest
            Me.ThreedBBandwidthTest(516, 7, 3, 100, 80)
            Me.ThreedBBandwidthTest(1029, 7, 3, 100, 80)
			Me.ResidualFMTest(1028.0006, 0, 0.002)
			Me.FMIndicatorAccuracyTest(750, 0, 50, 360, 324, 396)
			Me.FMIndicatorAccuracyTest(750, 0, 70, 360, 324, 396)
			Me.FMIndicatorAccuracyTest(750, 0, 100, 360, 324, 396)
			Me.FMIndicatorAccuracyTest(260, 0, 20, 250, 238, 262)
			Me.FMIndicatorAccuracyTest(260, 0, 100, 250, 225, 275)
			Me.FMIndicatorAccuracyTest(514, 0, 20, 250, 238, 262)
			Me.FMIndicatorAccuracyTest(514, 0, 100, 250, 225, 275)
			Me.HarmonicsTest
			Me.SubHarmonicsTest
		End Sub

		Public Function GetPowerSensorModelToUse(ByVal frequency As Double, ByVal amplitude As Double) As String
			Select Case Frequency
				Case < 10000000
					Return "8482A"
			End Select
		End Function

		Private Sub AddResult(ByVal frequencySetting As Double, ByVal amplitudeSetting As Double, ByVal lowerTolerance As Double, ByVal measurement As Double, ByVal upperTolerance As Double)
			Dim DR As DataRow = Me.dtResults.NewRow
			DR("Frequency") = frequencySetting
			DR("Amplitude") = amplitudeSetting
			DR("LowerTolerance") = lowerTolerance
			DR("Measurement") = measurement
			DR("UpperTolerance") = UpperTolerance
			Me.dtResults.Rows.Add(DR)
			Me.dgResults.Refresh
		End Sub

		Public Sub HighAmplitudeAccuracyTest()
			Try
				Me.InitializeInstruments
				Me.CreateNewTestResultsDataTable("High Amplitude Accuracy")
				Me.PwrMtr.Sections.Calibration.ZeroAndCalibrate
				MessageBox.Show("Connect the Power Sensor to the DUT Output.")
				Me.DUT.Sections.RF.OutputState = OnOffStateEnum.[On]
				Me.DUT.Sections.RF.Frequency.Suffix = FrequencyEnum.MHz
				For Each TestFrequency As Double In Me.DUT.TestPoints.HighAmplitudeAccuracyTestFrequencies
					For Each TestAmplitude As Double In Me.DUT.TestPoints.HighAmplitudeAccuracyTestAmplitudes
						Me.DUT.Sections.RF.Frequency.CW = TestFrequency
						Me.PwrMtr.SetCalibrationFactor(TestFrequency)
						Me.DUT.Sections.RF.Amplitude.Level = TestAmplitude
						Thread.Sleep(2000)
						Me.AddResult(TestFrequency, DUT.Sections.RF.Amplitude.Level, Me.DUT.Sections.RF.Amplitude.Level - Me.DUT.Specifications.HighAmplitudeAccuracyTolerance, Me.PwrMtr.Sections.Measurements.Measure("A"), Me.DUT.Sections.RF.Amplitude.Level + Me.DUT.Specifications.HighAmplitudeAccuracyTolerance)
					Next
				Next
			Catch InvOpEx As InvalidOperationException
				If CType(InvOpEx.InnerException, GPIBException).ErrorCode = GpibError.NoListenersDetected Then
					MessageBox.Show("An instrument did not respond." & NewLine & "Make sure the devices used for this test are connected to the bus and powered on.")
				End If
			Finally
				Me.StoreTestResultsToResultsDataSet
			End Try
		End Sub

		Public Sub ALCLinearityTest()
			'To Be Completed
		End Sub

		Private Sub MeasuringRecCalibrate(ByVal sender As Object, ByVal data As NotifyData)
			Dim SPResult As SerialPollFlags = Me.MeasuringRec.SerialPoll
			Me.MeasuringRec.Sections.Calibration.Calibrate
			Dim Reading As Double = Me.MeasuringRec.Sections.Triggers.TriggerWithSettlingAndReadSingle
			Me.MeasuringRec.Write("22.32SP")
			data.SetReenableMask(GpibStatusFlags.DeviceServiceRequest)
		End Sub

		Public Sub AttenuatorAccuracyTest
			Me.InitializeInstruments
			Try
				Me.CreateNewTestResultsDataTable("Attenuator Accuracy")
				Dim HighFrequencyCalibrationComplete As Boolean = False
				Dim LowFrequencyCalibrationComplete As Boolean = False
				Dim HighFrequencyMessageBoxShown As Boolean = False
				Dim LowFrequencyMessageBoxShown As Boolean = False
				Me.DUT.Sections.RF.OutputState = OnOffStateEnum.[On]
				Me.DUT.Sections.RF.Frequency.Suffix = FrequencyEnum.MHz
				Me.DUT.Sections.RF.Amplitude.Level = 0
				Me._GPIB0.UseAutomaticSerialPolling = False
				Me._GPIB0.IOTimeout = TimeoutValue.T100s
				Me.MeasuringRec.SerialPollResponseTimeout = TimeoutValue.T3s
				Me.MeasuringRec.IOTimeout = TimeoutValue.T100s
				For Each TestFrequency As Double In Me.DUT.TestPoints.AttenuatorAccuracyTestFrequencies
					Me.MeasuringRec.Preset
					Me.DUT.Sections.RF.Frequency.CW = TestFrequency
					If TestFrequency > 1300 Then
						If MessageBox.Show("Do you want to perform High Frequency Calibration @ " & TestFrequency & Me.DUT.Sections.RF.Frequency.Suffix.ToString & "?", "High Frequency Calibration", MessageBoxButtons.YesNo) = DialogResult.Yes Then
							If Not HighFrequencyMessageBoxShown Then
								MessageBox.Show("Configure the 8902A for Frequency Offset Mode using the Microwave Converter and an 11792A sensor module.")
								If Not HighFrequencyCalibrationComplete Then
									Me.MeasuringRec.Sections.Calibration.RFZeroCal
									MessageBox.Show("Connect the 11792A Sensor to the DUT output.")
									HighFrequencyCalibrationComplete = True
								End If
								HighFrequencyMessageBoxShown = True
							End If
							Me.DUT.Sections.RF.Amplitude.Level = 5
							Me.MeasuringRec.Sections.Measurements.FrequencyOffsetMode.SetupTunedRFLevelFrequencyOffsetMode(TestFrequency, FrequencyEnum.MHz)
						End If
					Else
						If Not LowFrequencyMessageBoxShown Then
							MessageBox.Show("Configure the 8902A for Normal Mode using an 11722A sensor module.")
							LowFrequencyMessageBoxShown = True
							If Not LowFrequencyCalibrationComplete Then
								Me.MeasuringRec.Sections.Calibration.RFZeroCal
								MessageBox.Show("Connect the 11722A Sensor to the DUT output.")
								LowFrequencyCalibrationComplete = True
							End If
						End If
						Me.DUT.Sections.RF.Amplitude.Level = 0
						Me.MeasuringRec.Sections.Measurements.Frequency
						Dim TempReading As Double = Me.MeasuringRec.Sections.Triggers.TriggerWithSettlingAndReadSingle
						Me.MeasuringRec.Write("MZ")
						Me.MeasuringRec.Sections.Measurements.TunedRFLevel
					End If
					Me.MeasuringRec.Sections.Display.Logarithmic
					Me.MeasuringRec.Write("22.32SP")
					For CurrentAmplitude As Integer = 0 To Me.MeasuringRec.Sections.Measurements.GetRoundedTunedRFAmplitude(Me.DUT.Capabilities.MinimumRFAmplitude) Step - 10
						Me.MeasuringRec.Sections.Triggers.Immediate
						Dim SPR As SerialPollFlags
						Try
							SPR = Me.MeasuringRec.SerialPoll
						Catch Ex As Exception
						End Try
						If SPR Then
							Me.MeasuringRec.Write("22.64SPT3")
							If Me.MeasuringRec.ReadDouble = 34 Then
								Me.MeasuringRec.Sections.Calibration.Calibrate
								Dim TempReading As Double = Me.MeasuringRec.Sections.Triggers.TriggerWithSettlingAndReadSingle
								Me.MeasuringRec.Clear
								Me.DUT.Sections.RF.Amplitude.Level = 0
								Me.MeasuringRec.Sections.Measurements.Frequency
								TempReading = Me.MeasuringRec.Sections.Triggers.TriggerWithSettlingAndReadSingle
								Me.MeasuringRec.Write("MZ")
								Me.MeasuringRec.Sections.Measurements.TunedRFLevel
								Me.MeasuringRec.Sections.Display.Logarithmic
								TempReading = Me.MeasuringRec.Sections.Triggers.TriggerWithSettlingAndReadSingle
			                	Me.MeasuringRec.Sections.Display.RatioOn
								Me.MeasuringRec.Write("22.32SP")
								For I As Integer = -10 To CurrentAmplitude
									Me.DUT.Sections.RF.Amplitude.Level = I
									Dim TR As Double = Me.MeasuringRec.Sections.Triggers.TriggerWithSettlingAndReadSingle
								Next
							End If
						End If
						Me.DUT.Sections.RF.Amplitude.Level = CurrentAmplitude
		                If CurrentAmplitude = 0 Then
							Me.MeasuringRec.Sections.Calibration.Calibrate
							Dim TempReading As Double = Me.MeasuringRec.Sections.Triggers.TriggerWithSettlingAndReadSingle
		                	Me.MeasuringRec.Sections.Display.RatioOn
		                End If
						Me.AddResult(TestFrequency, DUT.Sections.RF.Amplitude.Level, Me.DUT.Sections.RF.Amplitude.Level - Me.DUT.Specifications.AttenuatorAccuracyTolerance, Me.MeasuringRec.Sections.Triggers.TriggerWithSettlingAndReadSingle, Me.DUT.Sections.RF.Amplitude.Level + Me.DUT.Specifications.AttenuatorAccuracyTolerance)
					Next CurrentAmplitude
				Next TestFrequency
			Catch Ex As FrequencyOverRangeException
				MessageBox.Show(Ex.Message)
			Finally
				Me.StoreTestResultsToResultsDataSet
				'Me._ResultsDataSet.StoreResultsToDB
			End Try
		End Sub

		Public Sub CarrierFrequencyAccuracyTest()
			Try
				Me.InitializeInstruments
				Me.CreateNewTestResultsDataTable("Carrier Frequency Accuracy")
				Me.DUT.Sections.RF.Amplitude.Level = 0
				Dim LowFrequencyMessageBoxShown As Boolean = False
				Dim HighFrequencyMessageBoxShown As Boolean = False
				Me.HighFrequencyCounter.Preset
				For Each TestFrequency As Double In Me.DUT.TestPoints.CarrierFrequencyAccuracyTestFrequencies
					If TestFrequency < 500 Then
						If Not LowFrequencyMessageBoxShown Then
							MessageBox.Show("Connect the DUT Output to the 5343A 10Hz-500MHz Input.")
							LowFrequencyMessageBoxShown = True
						End If
						Me.DUT.Sections.RF.Frequency.CW = TestFrequency
						Thread.Sleep(4000)
						Me.HighFrequencyCounter.Preset
						Me.HighFrequencyCounter.FrequencyMode = AutomaticManualModeEnum.[Auto]
						Me.HighFrequencyCounter.FrequencyRange = CounterFrequencyRangeEnum.Low
						Me.HighFrequencyCounter.AcquisitionTime = Agilent5343AAcquisitionTimeEnum.Fast
						Me.HighFrequencyCounter.Resolution = Agilent5343AResolutionModeEnum.OneHz
						Me.HighFrequencyCounter.OutputMode = Agilent5343AOutputModeEnum.WaitUntilAddressed
						'Me.CurrentTestResults.AddResult(Me.MeasuringRec.Sections.AssetNumber, TestFrequency & Me.DUT.Sections.RF.Frequency.Suffix.ToString & " @ " & Me.DUT.Sections.RF.Amplitude.Level & Me.DUT.Sections.RF.Amplitude.Suffix.ToString, Me.DUT.Sections.RF.Amplitude.Level - Me.DUT.Specifications.AttenuatorAccuracyTolerance, Me.DUT.Sections.RF.Amplitude.Level + Me.DUT.Specifications.AttenuatorAccuracyTolerance, Me.MeasuringRec.Sections.Triggers.TriggerWithSettlingAndReadSingle)
					ElseIf TestFrequency > 500 Then
						If Not HighFrequencyMessageBoxShown Then
							MessageBox.Show("Connect the DUT Output to the 5343A 500MHz-26.5GHz Input.")
							HighFrequencyMessageBoxShown = True
						End If
						Me.DUT.Sections.RF.Frequency.CW = TestFrequency
						Me.HighFrequencyCounter.Preset
						Me.HighFrequencyCounter.FrequencyMode = AutomaticManualModeEnum.[Auto]
						Me.HighFrequencyCounter.FrequencyRange = CounterFrequencyRangeEnum.High
						Me.HighFrequencyCounter.AcquisitionTime = Agilent5343AAcquisitionTimeEnum.Fast
						Me.HighFrequencyCounter.Resolution = Agilent5343AResolutionModeEnum.OneHz
						Me.HighFrequencyCounter.OutputMode = Agilent5343AOutputModeEnum.WaitUntilAddressed
						Thread.Sleep(4000)
						'Me.CurrentTestResults.AddResult(Me.MeasuringRec.Sections.AssetNumber, TestFrequency & Me.DUT.Sections.RF.Frequency.Suffix.ToString & " @ " & Me.DUT.Sections.RF.Amplitude.Level & Me.DUT.Sections.RF.Amplitude.Suffix.ToString, Me.DUT.Sections.RF.Amplitude.Level - Me.DUT.Specifications.AttenuatorAccuracyTolerance, Me.DUT.Sections.RF.Amplitude.Level + Me.DUT.Specifications.AttenuatorAccuracyTolerance, Me.MeasuringRec.Sections.Triggers.TriggerWithSettlingAndReadSingle)
					End If
				Next
			Catch Ex As FrequencyOverRangeException
				MessageBox.Show(Ex.Message & NewLine & Ex.AttemptedFrequency & NewLine & Ex.MaximumFrequency)
			Finally
				Me.StoreTestResultsToResultsDataSet
				'Me._ResultsDataSet.StoreResultsToDB
			End Try
		End Sub

		Public Sub ResidualAMTest
			Me.InitializeInstruments
			If Me.DUT.Capabilities.HasInternalAMModulation Then
				MessageBox.Show("Connect an RF cable from the DUT output to the 8902A input.")
				Me.DUT.Sections.RF.OutputState = OnOffStateEnum.[On]
	            Me.DUT.Sections.RF.Amplitude.Level = Me.DUT.Capabilities.MaximumRFAmplitude
	            Me.MeasuringRec.Sections.Measurements.AM
	            Me.MeasuringRec.Sections.Filters.HighPass = MeasuringReceiverHighPassFilterEnum.ThreeHundredHz
	            Me.MeasuringRec.Sections.Filters.LowPass = MeasuringReceiverLowPassFilterEnum.ThreekHz
	            Me.MeasuringRec.Sections.Detector.Mode = MeasuringReceiverDetectorEnum.RMS
	            Me.MeasuringRec.Sections.Display.Logarithmic
				For Each TestFrequency As Double In Me.DUT.TestPoints.ResidualAMTestFrequencies
					Me.DUT.Sections.RF.Frequency.CW = TestFrequency
					'Me.StoreMeasurement(TestFrequency & "MHz - Residual AM", TestFrequency, Me.DUT.Sections.RF.Amplitude.Level, 0, Me.MeasuringRec.Sections.Triggers.TriggerWithSettlingAndReadSingle, Me.DUT.Specifications.ResidualAMTolerance)
				Next TestFrequency
			End If
		End Sub

		Public Sub AMModulationTest
			Me.InitializeInstruments
			If Me.DUT.Capabilities.HasInternalAMModulation Then
	            Me.MeasuringRec.Sections.Calibration.RFZeroCal
				MessageBox.Show("Connect an RF cable from the DUT output to the 8902A input.")
				Me.DUT.Sections.RF.OutputState = OnOffStateEnum.[On]
				Me.DUT.Sections.Modulation.AM.OutputState = OnOffStateEnum.[On]
				Me.DUT.Sections.Modulation.OutputState = OnOffStateEnum.[On]
				Me.DUT.Sections.Modulation.AM.FrequencySuffix = FrequencyEnum.KHz
				Me.DUT.Sections.Modulation.AM.Frequency = 1
				For Each TestFrequency As Double In Me.DUT.TestPoints.AMModulationTestFrequencies
					Me.DUT.Sections.RF.Frequency.CW = TestFrequency
					For Each TestAmplitude As Double In Me.DUT.TestPoints.AMModulationTestAmplitudes
						Me.DUT.Sections.RF.Amplitude.Level = TestAmplitude
						For Each AMTestDepth As Double In Me.DUT.TestPoints.AMModulationTestDepths
							Me.DUT.Sections.Modulation.AM.Depth = AMTestDepth
							Me.MeasuringRec.Preset
							Me.MeasuringRec.InputFrequency = TestFrequency
							Me.MeasuringRec.Sections.Measurements.AM
							Me.MeasuringRec.Sections.Detector.Mode = MeasuringReceiverDetectorEnum.PeakPositiveAndNegativeDividedBy2
							'Me.StoreMeasurement(TestFrequency & "MHz - " & TestAmplitude & "dBm @ " & AMTestDepth & "% AM Depth", TestFrequency, TestAmplitude, AMTestDepth - Me.DUT.Specifications.AMDepthTolerance, Me.MeasuringRec.Sections.Triggers.TriggerWithSettlingAndReadSingle, AMTestDepth + Me.DUT.Specifications.AMDepthTolerance)
							Me.MeasuringRec.Sections.Measurements.AudioDistortion
							'Me.StoreMeasurement(TestFrequency & "MHz - " & TestAmplitude & "dBm @ " & AMTestDepth & "% AM Distortion", TestFrequency, TestAmplitude, 100 - Me.DUT.Specifications.AMDistortionTolerance, Me.MeasuringRec.Sections.Triggers.TriggerWithSettlingAndReadSingle, 100 + Me.DUT.Specifications.AMDistortionTolerance)
							Me.MeasuringRec.Sections.Measurements.PM
							Me.MeasuringRec.Sections.Detector.Mode = MeasuringReceiverDetectorEnum.PeakPositive
							'Me.StoreMeasurement(TestFrequency & "MHz - " & TestAmplitude & "dBm @ " & AMTestDepth & "% Incidental Phase Modulation", TestFrequency, TestAmplitude, 0 - Me.DUT.Specifications.IncidentalPhaseModulationTolerance, Me.MeasuringRec.Sections.Triggers.TriggerWithSettlingAndReadSingle, 0 + Me.DUT.Specifications.IncidentalPhaseModulationTolerance)
						Next AMTestDepth
					Next TestAmplitude
				Next TestFrequency
			End If
		End Sub

		Public Sub ThreedBBandwidthTest(ByVal frequency As Double, ByVal amplitude As Double, ByVal tolerance As Double, ByVal aMFrequency As Double, ByVal aMDepth As Double)
			Me.InitializeInstruments
			MessageBox.Show("Connect an RF cable from the DUT output to the 8902A input.")
			Me.DUT.Sections.RF.OutputState = OnOffStateEnum.[On]
			Me.DUT.Sections.RF.Frequency.CW = Frequency
            Me.DUT.Sections.RF.Amplitude.Level = Amplitude
            Me.DUT.Sections.Modulation.AM.OutputState = OnOffStateEnum.[On]
			Me.DUT.Sections.Modulation.AM.Frequency = AMFrequency
            Me.DUT.Sections.Modulation.AM.Depth = AMDepth
			Me.MeasuringRec.Write("M1LGT3R1")
			Me.DUT.Sections.Modulation.AM.Frequency = 100
			Me.MeasuringRec.Write("T3")
    		Dim Reading As Double = Me.MeasuringRec.ReadDouble
			'Me.StoreMeasurement("3dB Bandwidth", Frequency, Amplitude, Reading - Tolerance, Reading, Reading + Tolerance)
		End Sub

		Public Sub ResidualFMTest(ByVal frequency As Double, ByVal amplitude As Double, ByVal tolerance As Double)
			Me.InitializeInstruments
			MessageBox.Show("Connect an RF cable from the DUT output to the 8902A input")
			Me.DUT.Sections.RF.OutputState = OnOffStateEnum.[On]
			Me.DUT.Sections.RF.Frequency.CW = Frequency
            Me.DUT.Sections.RF.Amplitude.Level = Amplitude
			Me.MeasuringRec.Write("M2H2L1D8T3P5")
			'Me.StoreMeasurement("Residual FM", Frequency, Amplitude, 0, CDbl(Me.MeasuringRec.Sections.ReadString(15)) / 1000, 0.002)
			Me.MeasuringRec.Write("H1L2T3")
			'Me.StoreMeasurement("Residual FM", Frequency, Amplitude, 0, CDbl(Me.MeasuringRec.Sections.ReadString(15)) / 1000, 0.004)
  		End Sub

		Public Sub FMIndicatorAccuracyTest(ByVal frequency As Double, ByVal amplitude As Double, ByVal fMFrequency As Double, ByVal fMDeviation As Double, ByVal lowerTolerance As Double, ByVal upperTolerance As Double)
			Me.InitializeInstruments
			MessageBox.Show("Connect an RF cable from the DUT output to the 8902A input")
			Me.DUT.Sections.RF.OutputState = OnOffStateEnum.[On]
			Me.DUT.Sections.RF.Frequency.CW = Frequency
            Me.DUT.Sections.RF.Amplitude.Level = Amplitude
			Me.DUT.Sections.Modulation.FM.OutputState = OnOffStateEnum.[On]
			Me.DUT.Sections.Modulation.FM.Deviation = FMDeviation
            Me.DUT.Sections.Modulation.FM.Frequency = FMFrequency
			Me.MeasuringRec.Write("M2T3")
			'Me.StoreMeasurement("FM Indicator Accuracy", Frequency, Amplitude, LowerTolerance, CDbl(Me.MeasuringRec.Sections.ReadString(15)) / 1000, UpperTolerance)
  		End Sub

        Public Sub FMDistortionTest
			Me.InitializeInstruments
			MessageBox.Show("Connect an RF cable from the DUT output to the 8902A input")
			Me.DUT.Sections.RF.OutputState = OnOffStateEnum.[On]
			Me.DUT.Sections.RF.Frequency.CW = 260
			Me.DUT.Sections.RF.Amplitude.Level = 0
			Me.DUT.Sections.Modulation.FM.OutputState = OnOffStateEnum.[On]
			Me.DUT.Sections.Modulation.FM.Frequency = 100
			Me.DUT.Sections.Modulation.FM.Deviation = 250
			Me.MeasuringRec.Write("M2")
			Me.AudioAn.Sections.Measurements.Distortion
			Me.AudioAn.Sections.Filters.AllLowPassFiltersOff
			'Me.StoreMeasurement("FM Distortion", 260, 0, 0, Me.AudioAn.TriggerWithSettlingAndReadSingle, 5)
			'FMIncidentalAMTest
			Me.DUT.Sections.Modulation.FM.Deviation = 20
			Me.MeasuringRec.Sections.Measurements.AM
			'Me.StoreMeasurement("FM Incidental AM", 514, 0, 0, Me.MeasuringRec.Sections.Triggers.TriggerWithSettlingAndReadSingle, 0.5)
        End Sub

        Public Sub FMCarrierFrequencyAccuracyTest
			Me.InitializeInstruments
			MessageBox.Show("Connect an RF cable from the DUT output to the 8902A input")
			Me.MeasuringRec.Write("IP")
			Me.DUT.Preset
			Thread.Sleep(2000)
			Me.DUT.Sections.RF.OutputState = OnOffStateEnum.[On]
			Me.DUT.Sections.RF.Frequency.CW = 516
			Me.DUT.Sections.RF.Amplitude.Level = 0
			Me.DUT.Sections.Modulation.FM.OutputState = OnOffStateEnum.[On]
			Me.DUT.Sections.Modulation.FM.Frequency = 100
			Me.DUT.Sections.Modulation.FM.Deviation = 10
			Me.DUT.Sections.Modulation.OutputState = OnOffStateEnum.[Off]
			Me.DUT.Sections.Modulation.FM.OutputState = OnOffStateEnum.[On]
			Me.MeasuringRec.Write("7.1SP")
			Thread.Sleep(2000)
			Dim FMReading As String = Me.MeasuringRec.ReadString
			Dim FMReadingArray() As String = FMReading.Split(NewLine)
			Dim FMOnReading As Double = CDbl(FMReadingArray(0))
			Me.DUT.Sections.Modulation.FM.OutputState = OnOffStateEnum.[Off]
			FMReading = Me.MeasuringRec.ReadString
			FMReadingArray = FMReading.Split(NewLine)
			Dim FMOffReading As Double = CDbl(FMReadingArray(0))
			Dim FMResult As Double = FMOnReading - FMOffReading
			'Me.StoreMeasurement("FM Carrier Frequency Accuracy", 516, 0, -50, FMResult, 50)
        End Sub

		Public Sub FrequencyAccuracyTest
			Me.InitializeInstruments
	        Me.MeasuringRec.Sections.Calibration.RFZeroCal
			MessageBox.Show("Connect an RF cable from the DUT output to the 8902A input")
			Me.MeasuringRec.Write("IP")
			Me.DUT.Preset
			Thread.Sleep(5000)
			Me.DUT.Sections.RF.OutputState = OnOffStateEnum.[On]
            Me.DUT.Sections.RF.Frequency.CW = 1000
            Me.DUT.Sections.RF.Amplitude.Level = 0
            Me.MeasuringRec.Write("7.1SP")
            Thread.Sleep(3000)
			Dim TempData As String = Me.MeasuringRec.ReadString
			Dim TempDataArray() As String = TempData.Split(NewLine)
			'Me.StoreMeasurement("Frequency Accuracy", 1029, 0, 625, CDbl(TempDataArray(0)) / 1000000, 1375)
		End Sub

		Public Sub HarmonicsTest
			'Try
				Me.InitializeInstruments
				Me.CreateNewTestResultsDataTable("Harmonics")
	            Me.MeasuringRec.Sections.Calibration.RFZeroCal
				MessageBox.Show("Connect an RF Cable from the DUT output to the Spectrum Analyzer input")
				Me.SpecAn.Sections.Amplitude.ReferenceLevel = 8
				Me.DUT.Sections.RF.OutputState = OnOffStateEnum.[On]
	            Me.DUT.Sections.RF.Amplitude.Level = 8
				For Each TestFrequency As Double In Me.DUT.TestPoints.SpectralPurityTestFrequencies
		            Me.DUT.Sections.RF.Frequency.CW = TestFrequency
		            Me.SpecAn.Sections.Frequency.Center = TestFrequency
		            Me.SpecAn.Sections.Span.Suffix = FrequencyEnum.KHz
		            Me.SpecAn.Sections.Span.Width = 300
		            Thread.Sleep(1000)
		            Me.SpecAn.WaitForSweepThenExecuteNextCommand
		            Me.SpecAn.Sections.Markers.PeakSearchHigh
		            Me.SpecAn.Sections.Markers.SetReferenceLevelToMarker
		            Me.SpecAn.Sections.Markers.SetDeltaMarker
		            Me.SpecAn.Sections.Frequency.Center = TestFrequency + TestFrequency
		            Me.SpecAn.WaitForSweepThenExecuteNextCommand
		            Thread.Sleep(1000)
		            Me.SpecAn.Sections.Markers.PeakSearchHigh
					'Me.CurrentTestResults.AddResult(Me.SpecAn.AssetNumber, TestFrequency & Me.DUT.Sections.RF.Frequency.Suffix.ToString, -150, Me.DUT.Specifications.FirstHarmonicTolerance, Me.SpecAn.MarkerAmplitude)
		            Me.dgResults.Update
		            Me.dgResults.Refresh
	            Next
			'Catch Ex As FrequencyOverRangeException
				'MessageBox.Show(Ex.Message)
			'Finally
				'Me.StoreTestResultsToResultsDataSet
				''Me._ResultsDataSet.StoreResultsToDB
			'End Try
		End Sub

		Public Sub SubHarmonicsTest
			Try
				Me.InitializeInstruments
				Me.CreateNewTestResultsDataTable("Sub-Harmonics")
                Me.MeasuringRec.Sections.Calibration.RFZeroCal
				MessageBox.Show("Connect an RF Cable from the DUT output to the Spectrum Analyzer input")
				Me.SpecAn.Sections.Amplitude.ReferenceLevel = 8
				Me.DUT.Sections.RF.OutputState = OnOffStateEnum.[On]
	            Me.DUT.Sections.RF.Amplitude.Level = 8
				For Each TestFrequency As Double In Me.DUT.TestPoints.SpectralPurityTestFrequencies
		            Me.DUT.Sections.RF.Frequency.CW = TestFrequency
		            Me.SpecAn.Sections.Frequency.Center = TestFrequency
		            Me.SpecAn.Sections.Span.Suffix = FrequencyEnum.KHz
		            Me.SpecAn.Sections.Span.Width = 300
		            Me.SpecAn.WaitForSweepThenExecuteNextCommand
		            Me.SpecAn.Sections.Markers.PeakSearchHigh
		            Me.SpecAn.Sections.Markers.SetReferenceLevelToMarker
		            Me.SpecAn.Sections.Markers.SetDeltaMarker
		            Me.SpecAn.Sections.Markers.MarkerPosition = TestFrequency + 0.05
		            Me.SpecAn.WaitForSweepThenExecuteNextCommand
					'Me.CurrentTestResults.AddResult(Me.SpecAn.AssetNumber, TestFrequency & Me.DUT.Sections.RF.Frequency.Suffix.ToString, -150, Me.DUT.Specifications.SubHarmonicTolerance, Me.SpecAn.MarkerAmplitude)
		            Me.dgResults.Update
		            Me.dgResults.Refresh
	            Next
			Catch Ex As FrequencyOverRangeException
				MessageBox.Show(Ex.Message)
			Finally
				Me.StoreTestResultsToResultsDataSet
				'Me._ResultsDataSet.StoreResultsToDB
			End Try
		End Sub

	End Class

