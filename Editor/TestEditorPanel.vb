'
' Created by SharpDevelop.
' User: Administrator
' Date: 7/15/2005
' Time: 4:51 AM
'


Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports FreeCal.Instruments.SignalGenerators
Imports System.Reflection
Imports FreeCal.Instruments
Imports FreeCal.Common



	Public Class TestEditorPanel
		Inherits System.Windows.Forms.Panel

		Public Event DataSent(ByVal currentInstrumentControl As InstrumentControl, ByVal data As String)
		Public Event InstrumentClick(ByVal currentInstrumentControl As InstrumentControl)
		Public Event InstrumentDeleted(ByVal primaryAddress As Byte)
		Public Event InstrumentAdded(ByVal currentInstrumentControl As InstrumentControl)

		Protected _LastSelectedInstrumentControl As InstrumentControl = Nothing
		Protected _CurrentSelectedInstrumentControl As InstrumentControl = Nothing

		Public Sub New
			MyBase.New
			Me.AllowDrop = True
			Me.BackColor = Color.LightGray
		End Sub

		Private Sub InstrumentDragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragEnter
	        If (e.Data.GetDataPresent(DataFormats.Text)) Then
	            e.Effect = DragDropEffects.Copy
	        End If
		End Sub
		
		Private Sub InstrumentDragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragDrop
	        If (e.Data.GetDataPresent(DataFormats.Text)) Then
				Me.TransferInstruments("InstrumentDragDrop")
	            Dim InstrumentName As String = e.Data.GetData(DataFormats.Text).ToString.Trim.ToLower
	            Dim InstrumentType As String
	            Select InstrumentName
					Case "anritsumg3696a"
						InstrumentType = "SignalGenerator"
					Case "agilent8340a"
						InstrumentType = "SignalGenerator"
					Case "agilent8340b"
						InstrumentType = "SignalGenerator"
					Case "agilente4433b"
						InstrumentType = "SignalGenerator"
					Case "agilent83651a"
						InstrumentType = "SignalGenerator"
					Case "agilent8643a"
						InstrumentType = "SignalGenerator"
					Case "agilent8660d"
						InstrumentType = "SignalGenerator"
					Case "agilent8672a"
						InstrumentType = "SignalGenerator"
					Case "ifr2050"
						InstrumentType = "SignalGenerator"
					Case "agilent8510c"
						InstrumentType = "NetworkAnalyzer"
					Case "agilente4417a"
						InstrumentType = "PowerMeter"
					Case "agilent8564ec"
						InstrumentType = "SpectrumAnalyzer"
				End Select
				Select InstrumentType
					Case "SignalGenerator"
		                Dim _SignalGeneratorControl As New SignalGeneratorControl(InstrumentName, Me.Tag)
		                _SignalGeneratorControl.BackColor = Color.Red
		                _SignalGeneratorControl.AllowDrop = True
		                _SignalGeneratorControl.Location = Me.PointToClient(New Point(e.X - (_SignalGeneratorControl.Width / 2), e.Y - (_SignalGeneratorControl.Height / 2)))
		                AddHandler _SignalGeneratorControl.DataSent, AddressOf Me.OnDataSent
		                AddHandler _SignalGeneratorControl.DeleteInstrument, AddressOf Me.OnInstrumentDelete
		                AddHandler _SignalGeneratorControl.InstrumentClick, AddressOf Me.OnInstrumentClick
		                Me.Controls.Add(_SignalGeneratorControl)
		                _SignalGeneratorControl.BringToFront
		                Me._CurrentSelectedInstrumentControl = _SignalGeneratorControl
		                RaiseEvent InstrumentAdded(_SignalGeneratorControl)
					Case "NetworkAnalyzer"
		                Dim _NWAControl As New NetworkAnalyzerControl(InstrumentName, Me.Tag)
		                _NWAControl.BackColor = Color.Red
		                _NWAControl.AllowDrop = True
		                _NWAControl.Location = Me.PointToClient(New Point(e.X - (_NWAControl.Width / 2), e.Y - (_NWAControl.Height / 2)))
		                AddHandler _NWAControl.DataSent, AddressOf Me.OnDataSent
		                AddHandler _NWAControl.DeleteInstrument, AddressOf Me.OnInstrumentDelete
		                AddHandler _NWAControl.InstrumentClick, AddressOf Me.OnInstrumentClick
		                Me.Controls.Add(_NWAControl)
		                _NWAControl.BringToFront
		                Me._CurrentSelectedInstrumentControl = _NWAControl
		                RaiseEvent InstrumentAdded(_NWAControl)
					Case "PowerMeter"
		                Dim _PowerMeterControl As New PowerMeterControl(InstrumentName, Me.Tag)
		                _PowerMeterControl.BackColor = Color.Red
		                _PowerMeterControl.AllowDrop = True
		                _PowerMeterControl.Location = Me.PointToClient(New Point(e.X - (_PowerMeterControl.Width / 2), e.Y - (_PowerMeterControl.Height / 2)))
		                AddHandler _PowerMeterControl.DataSent, AddressOf Me.OnDataSent
		                AddHandler _PowerMeterControl.DeleteInstrument, AddressOf Me.OnInstrumentDelete
		                AddHandler _PowerMeterControl.InstrumentClick, AddressOf Me.OnInstrumentClick
		                Me.Controls.Add(_PowerMeterControl)
		                _PowerMeterControl.BringToFront
		                Me._CurrentSelectedInstrumentControl = _PowerMeterControl
		                RaiseEvent InstrumentAdded(_PowerMeterControl)
					Case "SpectrumAnalyzer"
		                Dim _SpectrumAnalyzerControl As New SpectrumAnalyzerControl(InstrumentName, Me.Tag)
		                _SpectrumAnalyzerControl.BackColor = Color.Red
		                _SpectrumAnalyzerControl.AllowDrop = True
		                _SpectrumAnalyzerControl.Location = Me.PointToClient(New Point(e.X - (_SpectrumAnalyzerControl.Width / 2), e.Y - (_SpectrumAnalyzerControl.Height / 2)))
		                AddHandler _SpectrumAnalyzerControl.DataSent, AddressOf Me.OnDataSent
		                AddHandler _SpectrumAnalyzerControl.DeleteInstrument, AddressOf Me.OnInstrumentDelete
		                AddHandler _SpectrumAnalyzerControl.InstrumentClick, AddressOf Me.OnInstrumentClick
		                Me.Controls.Add(_SpectrumAnalyzerControl)
		                _SpectrumAnalyzerControl.BringToFront
		                Me._CurrentSelectedInstrumentControl = _SpectrumAnalyzerControl
		                RaiseEvent InstrumentAdded(_SpectrumAnalyzerControl)
				End Select
	        End If
		End Sub

		Private Sub TransferInstruments(ByVal methodName As String)
			DebugMode = False
			If Not (Me._CurrentSelectedInstrumentControl Is Nothing) Then
	        	Me._CurrentSelectedInstrumentControl.IsSelected = False
	        	Me._CurrentSelectedInstrumentControl.Invalidate
		    Else
				If DebugMode Then
		        	MessageBox.Show(methodName & " - _CurrentSelectedInstrumentControl Is Nothing")
		        End If
		    End If			
		End Sub

		Private Sub OnInstrumentClick(ByVal currentInstrument As InstrumentControl)
			Me.TransferInstruments("OnInstrumentClick")
			Me._CurrentSelectedInstrumentControl = currentInstrument
			Me._CurrentSelectedInstrumentControl.IsSelected = True
			RaiseEvent InstrumentClick(Me._CurrentSelectedInstrumentControl)
			Me._CurrentSelectedInstrumentControl.Invalidate
		End Sub

		Private Sub OnInstrumentDelete(ByVal currentInstrument As InstrumentControl)
			RaiseEvent InstrumentDeleted(currentInstrument.Instrument.PrimaryAddress)
			Try
				currentInstrument.Instrument.Reset
				currentInstrument.Instrument.GoToLocal
				currentInstrument.Instrument.Dispose
				currentInstrument.Dispose
			Catch
			End Try
			Me.Controls.Remove(currentInstrument)
		End Sub

		Public Sub OnDataSent(ByVal currentinstrument As InstrumentControl, ByVal data As String)
			RaiseEvent DataSent(currentinstrument, data)
		End Sub

	End Class

