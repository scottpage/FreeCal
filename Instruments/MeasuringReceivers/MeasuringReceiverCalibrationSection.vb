'
' Created by SharpDevelop.
' User: Administrator
' Date: 6/14/2005
' Time: 5:30 PM
' 

Imports System.Threading
Imports System.Windows.Forms

Public Class MeasuringReceiverCalibrationSection

    Protected _MainMeasuringReceiver As MeasuringReceiver
    Protected _CurrentMeasurement As MeasuringReceiverMeasurementsEnum

    Public Sub Calibrate()
        _MainMeasuringReceiver.Write(_MainMeasuringReceiver.Commands.CalibrateOn)
        Dim TempReading As Double = _MainMeasuringReceiver.Sections.Triggers.TriggerWithSettlingAndReadSingle
    End Sub

    Public Sub RFZeroCal()
        If MessageBox.Show("Do you want to calibrate the Sensor?", "Sensor Calibration", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Dim OriginalIOTimeout As TimeoutValue = Me._MainMeasuringReceiver.IOTimeout
            Me._MainMeasuringReceiver.IOTimeout = TimeoutValue.T100s
            MessageBox.Show("Connect the 11722A Sensor to the 8902A RF POWER Connector.")
            Me._MainMeasuringReceiver.Write("M4ZRT3")
            Dim TempReading As Double = Me._MainMeasuringReceiver.ReadDouble
            Thread.Sleep(3000)
            Me._MainMeasuringReceiver.Write("C1T3SCT3")
            TempReading = Me._MainMeasuringReceiver.ReadDouble
            Me._MainMeasuringReceiver.Write("C0")
            Me._MainMeasuringReceiver.IOTimeout = OriginalIOTimeout
        End If
    End Sub

    Public Sub New(ByRef MainMeasuringReceiver As MeasuringReceiver)
        Me._MainMeasuringReceiver = MainMeasuringReceiver
    End Sub

End Class


