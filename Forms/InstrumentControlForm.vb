'
' Created by SharpDevelop.
' User: rspage
' Date: 4/13/2005
' Time: 9:19 AM
' 


Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports FreeCal.Common
Imports System.Threading
Imports NationalInstruments.NI4882
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.ControlChars
Imports System.Collections
Imports FreeCal.Instruments



	Public Enum InstrumentDataTypeEnum
		[String]
		[Single]
		[Double]
		[Integer]
		[Int32]
		[Int16]
		[Byte]
		[StringArray]
		Binary
	End Enum

	Public Class InstrumentControlForm
		Inherits System.Windows.Forms.Form
		Private chbReadNumberOfBytes As System.Windows.Forms.CheckBox
		Private lblTimeout As System.Windows.Forms.Label
		Private btnConnect As System.Windows.Forms.Button
		Private lblBus As System.Windows.Forms.Label
		Private LoopTimer As System.Timers.Timer
		Private btnConvertBinary As System.Windows.Forms.Button
		Private cbNotifyStatusFlag As System.Windows.Forms.ComboBox
		Private tbCommands As System.Windows.Forms.TextBox
		Private btnRead As System.Windows.Forms.Button
		Private tbSentData As System.Windows.Forms.TextBox
		Private lblPrimaryAddress As System.Windows.Forms.Label
		Private btnSend As System.Windows.Forms.Button
		Private chkLoop As System.Windows.Forms.CheckBox
		Private chkLoopNotify As System.Windows.Forms.CheckBox
		Private tbReceivedData As System.Windows.Forms.TextBox
		Private btnStopLoop As System.Windows.Forms.Button
		Private btnClearReceivedData As System.Windows.Forms.Button
		Private tbReadNumberOfBytes As System.Windows.Forms.TextBox
		Private cbInsertNewLineOnWrite As System.Windows.Forms.CheckBox
		Private btnDisconnect As System.Windows.Forms.Button
		Private cbReadDataType As System.Windows.Forms.ComboBox
		Private btnQuery As System.Windows.Forms.Button
		Private btnClearSentData As System.Windows.Forms.Button
		Private cbBusDevices As System.Windows.Forms.ComboBox
		Private btnNotify As System.Windows.Forms.Button
		Private cbBoards As System.Windows.Forms.ComboBox
		Private cbTimeout As System.Windows.Forms.ComboBox
		Private gbNotify As System.Windows.Forms.GroupBox
		Private lblCommands As System.Windows.Forms.Label
		Private btnTrigger As System.Windows.Forms.Button
		
        Private CurrentGPIBDevice As Instrument
        
		Public Sub New
			MyBase.New
			'
			' The Me.InitializeComponent call is required for Windows Forms designer support.
			'
			Me.InitializeComponent
			SetControlConfigurationOptions(Me, Me.Controls)
			Me.FillComboBoxes()
		End Sub
		
		#Region " Windows Forms Designer generated code "
		' This method is required for Windows Forms designer support.
		' Do not change the method contents inside the source code editor. The Forms designer might
		' not be able to load this method if it was changed manually.
		Private Sub InitializeComponent()
			Me.btnTrigger = New System.Windows.Forms.Button
			Me.lblCommands = New System.Windows.Forms.Label
			Me.gbNotify = New System.Windows.Forms.GroupBox
			Me.cbTimeout = New System.Windows.Forms.ComboBox
			Me.cbBoards = New System.Windows.Forms.ComboBox
			Me.btnNotify = New System.Windows.Forms.Button
			Me.cbBusDevices = New System.Windows.Forms.ComboBox
			Me.btnClearSentData = New System.Windows.Forms.Button
			Me.btnQuery = New System.Windows.Forms.Button
			Me.cbReadDataType = New System.Windows.Forms.ComboBox
			Me.btnDisconnect = New System.Windows.Forms.Button
			Me.cbInsertNewLineOnWrite = New System.Windows.Forms.CheckBox
			Me.tbReadNumberOfBytes = New System.Windows.Forms.TextBox
			Me.btnClearReceivedData = New System.Windows.Forms.Button
			Me.btnStopLoop = New System.Windows.Forms.Button
			Me.tbReceivedData = New System.Windows.Forms.TextBox
			Me.chkLoopNotify = New System.Windows.Forms.CheckBox
			Me.chkLoop = New System.Windows.Forms.CheckBox
			Me.btnSend = New System.Windows.Forms.Button
			Me.lblPrimaryAddress = New System.Windows.Forms.Label
			Me.tbSentData = New System.Windows.Forms.TextBox
			Me.btnRead = New System.Windows.Forms.Button
			Me.tbCommands = New System.Windows.Forms.TextBox
			Me.cbNotifyStatusFlag = New System.Windows.Forms.ComboBox
			Me.btnConvertBinary = New System.Windows.Forms.Button
			Me.LoopTimer = New System.Timers.Timer
			Me.lblBus = New System.Windows.Forms.Label
			Me.btnConnect = New System.Windows.Forms.Button
			Me.lblTimeout = New System.Windows.Forms.Label
			Me.chbReadNumberOfBytes = New System.Windows.Forms.CheckBox
			Me.gbNotify.SuspendLayout
			CType(Me.LoopTimer,System.ComponentModel.ISupportInitialize).BeginInit
			Me.SuspendLayout
			'
			'btnTrigger
			'
			Me.btnTrigger.Location = New System.Drawing.Point(272, 96)
			Me.btnTrigger.Name = "btnTrigger"
			Me.btnTrigger.TabIndex = 18
			Me.btnTrigger.Text = "Trigger"
			AddHandler Me.btnTrigger.Click, AddressOf Me.BtnTriggerClick
			'
			'lblCommands
			'
			Me.lblCommands.AutoSize = true
			Me.lblCommands.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
			Me.lblCommands.Location = New System.Drawing.Point(8, 56)
			Me.lblCommands.Name = "lblCommands"
			Me.lblCommands.Size = New System.Drawing.Size(145, 17)
			Me.lblCommands.TabIndex = 4
			Me.lblCommands.Text = "Enter commands to send"
			'
			'gbNotify
			'
			Me.gbNotify.Controls.Add(Me.cbNotifyStatusFlag)
			Me.gbNotify.Controls.Add(Me.chkLoopNotify)
			Me.gbNotify.Controls.Add(Me.btnNotify)
			Me.gbNotify.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
			Me.gbNotify.Location = New System.Drawing.Point(616, 32)
			Me.gbNotify.Name = "gbNotify"
			Me.gbNotify.Size = New System.Drawing.Size(160, 80)
			Me.gbNotify.TabIndex = 24
			Me.gbNotify.TabStop = false
			Me.gbNotify.Text = "Notify"
			'
			'cbTimeout
			'
			Me.cbTimeout.Location = New System.Drawing.Point(392, 24)
			Me.cbTimeout.Name = "cbTimeout"
			Me.cbTimeout.Size = New System.Drawing.Size(121, 21)
			Me.cbTimeout.TabIndex = 14
			Me.cbTimeout.Text = "T1s"
			'
			'cbBoards
			'
			Me.cbBoards.Location = New System.Drawing.Point(64, 24)
			Me.cbBoards.Name = "cbBoards"
			Me.cbBoards.Size = New System.Drawing.Size(121, 21)
			Me.cbBoards.TabIndex = 7
			AddHandler Me.cbBoards.SelectedIndexChanged, AddressOf Me.CbBoardsSelectedIndexChanged
			'
			'btnNotify
			'
			Me.btnNotify.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
			Me.btnNotify.Location = New System.Drawing.Point(8, 48)
			Me.btnNotify.Name = "btnNotify"
			Me.btnNotify.Size = New System.Drawing.Size(80, 23)
			Me.btnNotify.TabIndex = 22
			Me.btnNotify.Text = "Start Notify"
			AddHandler Me.btnNotify.Click, AddressOf Me.BtnNotifyClick
			'
			'cbBusDevices
			'
			Me.cbBusDevices.Location = New System.Drawing.Point(256, 24)
			Me.cbBusDevices.Name = "cbBusDevices"
			Me.cbBusDevices.Size = New System.Drawing.Size(80, 21)
			Me.cbBusDevices.TabIndex = 16
			'
			'btnClearSentData
			'
			Me.btnClearSentData.Location = New System.Drawing.Point(712, 168)
			Me.btnClearSentData.Name = "btnClearSentData"
			Me.btnClearSentData.Size = New System.Drawing.Size(96, 23)
			Me.btnClearSentData.TabIndex = 27
			Me.btnClearSentData.Text = "Clear Sent Data"
			AddHandler Me.btnClearSentData.Click, AddressOf Me.BtnClearSentDataClick
			'
			'btnQuery
			'
			Me.btnQuery.Enabled = false
			Me.btnQuery.Location = New System.Drawing.Point(184, 96)
			Me.btnQuery.Name = "btnQuery"
			Me.btnQuery.TabIndex = 2
			Me.btnQuery.Text = "Query"
			AddHandler Me.btnQuery.Click, AddressOf Me.BtnQueryClick
			'
			'cbReadDataType
			'
			Me.cbReadDataType.Location = New System.Drawing.Point(96, 120)
			Me.cbReadDataType.Name = "cbReadDataType"
			Me.cbReadDataType.Size = New System.Drawing.Size(80, 21)
			Me.cbReadDataType.TabIndex = 25
			'
			'btnDisconnect
			'
			Me.btnDisconnect.Enabled = false
			Me.btnDisconnect.Location = New System.Drawing.Point(536, 96)
			Me.btnDisconnect.Name = "btnDisconnect"
			Me.btnDisconnect.TabIndex = 13
			Me.btnDisconnect.Text = "Disconnect"
			AddHandler Me.btnDisconnect.Click, AddressOf Me.BtnDisconnectClick
			'
			'cbInsertNewLineOnWrite
			'
			Me.cbInsertNewLineOnWrite.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
			Me.cbInsertNewLineOnWrite.Location = New System.Drawing.Point(264, 120)
			Me.cbInsertNewLineOnWrite.Name = "cbInsertNewLineOnWrite"
			Me.cbInsertNewLineOnWrite.Size = New System.Drawing.Size(128, 24)
			Me.cbInsertNewLineOnWrite.TabIndex = 29
			Me.cbInsertNewLineOnWrite.Text = "Newline on Write"
			'
			'tbReadNumberOfBytes
			'
			Me.tbReadNumberOfBytes.Location = New System.Drawing.Point(608, 8)
			Me.tbReadNumberOfBytes.Name = "tbReadNumberOfBytes"
			Me.tbReadNumberOfBytes.Size = New System.Drawing.Size(79, 20)
			Me.tbReadNumberOfBytes.TabIndex = 21
			Me.tbReadNumberOfBytes.Text = ""
			'
			'btnClearReceivedData
			'
			Me.btnClearReceivedData.Location = New System.Drawing.Point(360, 96)
			Me.btnClearReceivedData.Name = "btnClearReceivedData"
			Me.btnClearReceivedData.TabIndex = 15
			Me.btnClearReceivedData.Text = "Clear Data"
			AddHandler Me.btnClearReceivedData.Click, AddressOf Me.BtnClearReceivedDataClick
			'
			'btnStopLoop
			'
			Me.btnStopLoop.Location = New System.Drawing.Point(520, 8)
			Me.btnStopLoop.Name = "btnStopLoop"
			Me.btnStopLoop.Size = New System.Drawing.Size(80, 23)
			Me.btnStopLoop.TabIndex = 19
			Me.btnStopLoop.Text = "Stop Looping"
			AddHandler Me.btnStopLoop.Click, AddressOf Me.BtnStopLoopClick
			'
			'tbReceivedData
			'
			Me.tbReceivedData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
						Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
			Me.tbReceivedData.BackColor = System.Drawing.Color.SteelBlue
			Me.tbReceivedData.Cursor = System.Windows.Forms.Cursors.IBeam
			Me.tbReceivedData.Font = New System.Drawing.Font("Tahoma", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
			Me.tbReceivedData.ForeColor = System.Drawing.Color.Yellow
			Me.tbReceivedData.Location = New System.Drawing.Point(8, 144)
			Me.tbReceivedData.Multiline = true
			Me.tbReceivedData.Name = "tbReceivedData"
			Me.tbReceivedData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
			Me.tbReceivedData.Size = New System.Drawing.Size(680, 320)
			Me.tbReceivedData.TabIndex = 5
			Me.tbReceivedData.Text = ""
			'
			'chkLoopNotify
			'
			Me.chkLoopNotify.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
			Me.chkLoopNotify.Location = New System.Drawing.Point(96, 48)
			Me.chkLoopNotify.Name = "chkLoopNotify"
			Me.chkLoopNotify.Size = New System.Drawing.Size(56, 24)
			Me.chkLoopNotify.TabIndex = 23
			Me.chkLoopNotify.Text = "Loop"
			'
			'chkLoop
			'
			Me.chkLoop.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
			Me.chkLoop.Location = New System.Drawing.Point(528, 40)
			Me.chkLoop.Name = "chkLoop"
			Me.chkLoop.Size = New System.Drawing.Size(56, 24)
			Me.chkLoop.TabIndex = 17
			Me.chkLoop.Text = "Loop"
			'
			'btnSend
			'
			Me.btnSend.Enabled = false
			Me.btnSend.Location = New System.Drawing.Point(8, 96)
			Me.btnSend.Name = "btnSend"
			Me.btnSend.TabIndex = 0
			Me.btnSend.Text = "Send"
			AddHandler Me.btnSend.Click, AddressOf Me.BtnSendClick
			'
			'lblPrimaryAddress
			'
			Me.lblPrimaryAddress.AutoSize = true
			Me.lblPrimaryAddress.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
			Me.lblPrimaryAddress.Location = New System.Drawing.Point(248, 8)
			Me.lblPrimaryAddress.Name = "lblPrimaryAddress"
			Me.lblPrimaryAddress.Size = New System.Drawing.Size(98, 17)
			Me.lblPrimaryAddress.TabIndex = 8
			Me.lblPrimaryAddress.Text = "Primary Address"
			'
			'tbSentData
			'
			Me.tbSentData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
						Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
			Me.tbSentData.BackColor = System.Drawing.Color.SlateGray
			Me.tbSentData.Cursor = System.Windows.Forms.Cursors.IBeam
			Me.tbSentData.Font = New System.Drawing.Font("Tahoma", 10!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
			Me.tbSentData.ForeColor = System.Drawing.Color.Yellow
			Me.tbSentData.Location = New System.Drawing.Point(696, 192)
			Me.tbSentData.Multiline = true
			Me.tbSentData.Name = "tbSentData"
			Me.tbSentData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
			Me.tbSentData.Size = New System.Drawing.Size(136, 272)
			Me.tbSentData.TabIndex = 26
			Me.tbSentData.Text = ""
			'
			'btnRead
			'
			Me.btnRead.Enabled = false
			Me.btnRead.Location = New System.Drawing.Point(96, 96)
			Me.btnRead.Name = "btnRead"
			Me.btnRead.Size = New System.Drawing.Size(80, 23)
			Me.btnRead.TabIndex = 1
			Me.btnRead.Text = "Read"
			AddHandler Me.btnRead.Click, AddressOf Me.BtnReadClick
			'
			'tbCommands
			'
			Me.tbCommands.Location = New System.Drawing.Point(8, 72)
			Me.tbCommands.Name = "tbCommands"
			Me.tbCommands.Size = New System.Drawing.Size(600, 20)
			Me.tbCommands.TabIndex = 3
			Me.tbCommands.Text = ""
			'
			'cbNotifyStatusFlag
			'
			Me.cbNotifyStatusFlag.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
			Me.cbNotifyStatusFlag.Location = New System.Drawing.Point(8, 24)
			Me.cbNotifyStatusFlag.Name = "cbNotifyStatusFlag"
			Me.cbNotifyStatusFlag.TabIndex = 24
			AddHandler Me.cbNotifyStatusFlag.KeyPress, AddressOf Me.CbNotifyStatusFlagKeyPress
			'
			'btnConvertBinary
			'
			Me.btnConvertBinary.Location = New System.Drawing.Point(184, 120)
			Me.btnConvertBinary.Name = "btnConvertBinary"
			Me.btnConvertBinary.TabIndex = 28
			Me.btnConvertBinary.Text = "Convert"
			AddHandler Me.btnConvertBinary.Click, AddressOf Me.BtnConvertBinaryClick
			'
			'LoopTimer
			'
			Me.LoopTimer.Interval = 500
			Me.LoopTimer.SynchronizingObject = Me
			AddHandler Me.LoopTimer.Elapsed, AddressOf Me.LoopTimerElapsed
			'
			'lblBus
			'
			Me.lblBus.AutoSize = true
			Me.lblBus.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
			Me.lblBus.Location = New System.Drawing.Point(112, 8)
			Me.lblBus.Name = "lblBus"
			Me.lblBus.Size = New System.Drawing.Size(25, 17)
			Me.lblBus.TabIndex = 6
			Me.lblBus.Text = "Bus"
			'
			'btnConnect
			'
			Me.btnConnect.Location = New System.Drawing.Point(448, 96)
			Me.btnConnect.Name = "btnConnect"
			Me.btnConnect.TabIndex = 12
			Me.btnConnect.Text = "Connect"
			AddHandler Me.btnConnect.Click, AddressOf Me.BtnConnectClick
			'
			'lblTimeout
			'
			Me.lblTimeout.AutoSize = true
			Me.lblTimeout.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
			Me.lblTimeout.Location = New System.Drawing.Point(424, 8)
			Me.lblTimeout.Name = "lblTimeout"
			Me.lblTimeout.Size = New System.Drawing.Size(51, 17)
			Me.lblTimeout.TabIndex = 10
			Me.lblTimeout.Text = "Timeout"
			'
			'chbReadNumberOfBytes
			'
			Me.chbReadNumberOfBytes.Location = New System.Drawing.Point(696, 0)
			Me.chbReadNumberOfBytes.Name = "chbReadNumberOfBytes"
			Me.chbReadNumberOfBytes.Size = New System.Drawing.Size(136, 40)
			Me.chbReadNumberOfBytes.TabIndex = 20
			Me.chbReadNumberOfBytes.Text = "Read Number of Bytes"
			'
			'InstrumentControlForm
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(842, 479)
			Me.Controls.Add(Me.btnConvertBinary)
			Me.Controls.Add(Me.btnClearSentData)
			Me.Controls.Add(Me.tbSentData)
			Me.Controls.Add(Me.cbReadDataType)
			Me.Controls.Add(Me.gbNotify)
			Me.Controls.Add(Me.tbReadNumberOfBytes)
			Me.Controls.Add(Me.chbReadNumberOfBytes)
			Me.Controls.Add(Me.btnStopLoop)
			Me.Controls.Add(Me.btnTrigger)
			Me.Controls.Add(Me.chkLoop)
			Me.Controls.Add(Me.cbBusDevices)
			Me.Controls.Add(Me.btnClearReceivedData)
			Me.Controls.Add(Me.cbTimeout)
			Me.Controls.Add(Me.btnDisconnect)
			Me.Controls.Add(Me.btnConnect)
			Me.Controls.Add(Me.cbBoards)
			Me.Controls.Add(Me.tbCommands)
			Me.Controls.Add(Me.tbReceivedData)
			Me.Controls.Add(Me.btnQuery)
			Me.Controls.Add(Me.btnRead)
			Me.Controls.Add(Me.btnSend)
			Me.Controls.Add(Me.lblCommands)
			Me.Controls.Add(Me.lblBus)
			Me.Controls.Add(Me.lblPrimaryAddress)
			Me.Controls.Add(Me.lblTimeout)
			Me.Controls.Add(Me.cbInsertNewLineOnWrite)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
			Me.Location = New System.Drawing.Point(13, 13)
			Me.Name = "InstrumentControlForm"
			Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "InstrumentControlForm"
			Me.gbNotify.ResumeLayout(false)
			CType(Me.LoopTimer,System.ComponentModel.ISupportInitialize).EndInit
			Me.ResumeLayout(false)
		End Sub
		#End Region

		Private Sub FillComboBoxes()
	        Me.cbTimeout.DataSource = [Enum].GetNames(GetType(TimeoutValue))
	        Me.cbTimeout.Text = "T1s"
			Me.cbBoards.DataSource = GetActiveGPIBBusses
			If Me.cbBoards.Items.Count > 0 Then
				Me.cbBoards.SelectedIndex = 0
	            Me.cbBusDevices.DataSource = GetGPIBBusDevices([Enum].Parse(GetType(Boards), Me.cbBoards.SelectedItem))
	            If Me.cbBusDevices.Items.Count > 0
					Me.cbBusDevices.SelectedIndex = 0
				End If
			End If
			Me.cbReadDataType.DataSource = [Enum].GetNames(GetType(InstrumentDataTypeEnum))
			Me.cbReadDataType.SelectedIndex = 0
			Me.cbNotifyStatusFlag.DataSource = [Enum].GetNames(GetType(GpibStatusFlags))
			Me.cbNotifyStatusFlag.SelectedIndex = 0
		End Sub

		Private Sub BtnConnectClick(sender As System.Object, e As System.EventArgs)
		    If Me.cbBoards.Items.Count > 0
                Dim NewGPIBDevice As New Instrument([Enum].Parse(GetType(Boards), Me.cbBoards.SelectedItem), Me.cbBusDevices.selectedItem, False)
                Me.CurrentGPIBDevice = NewGPIBDevice
                Me.CurrentGPIBDevice.IOTimeout = [Enum].Parse(GetType(TimeoutValue), Me.cbTimeout.SelectedItem)
                Me.btnDisconnect.Enabled = True
                Me.btnConnect.Enabled = False
                Me.btnQuery.Enabled = True
                Me.btnRead.Enabled = True
                Me.btnSend.Enabled = True
            End If
		End Sub
		
		Private Sub BtnDisconnectClick(sender As System.Object, e As System.EventArgs)
		    Me.CurrentGPIBDevice.Dispose
		    Me.LoopTimer.Enabled = False
            Me.btnDisconnect.Enabled = False
            Me.btnConnect.Enabled = True
            Me.btnQuery.Enabled = False
            Me.btnRead.Enabled = False
            Me.btnSend.Enabled = False
		End Sub

		Private Sub BtnSendClick(sender As System.Object, e As System.EventArgs)
            Me.WriteToCurrentGPIBDevice()
		End Sub
		
		Private Sub BtnReadClick(sender As System.Object, e As System.EventArgs)
            Me.ReadDataFromCurrentInstrument()
		End Sub

		Private Sub BtnQueryClick(sender As System.Object, e As System.EventArgs)
			If Me.chkLoop.Checked Then
				Me.LoopTimer.Enabled = True
            Else
            	Me.WriteToCurrentGPIBDevice()
           		Me.ReadDataFromCurrentInstrument()
           	End If
		End Sub

		Private Sub BtnClearReceivedDataClick(sender As System.Object, e As System.EventArgs)
            Me.tbReceivedData.Clear
		End Sub
		
		Private Sub CbBoardsSelectedIndexChanged(sender As System.Object, e As System.EventArgs)
            Me.cbBusDevices.DataSource = GetGPIBBusDevices([Enum].Parse(GetType(Boards), Me.cbBoards.SelectedItem))
		End Sub
		
		Private Sub BtnTriggerClick(sender As System.Object, e As System.EventArgs)
		    Me.CurrentGPIBDevice.Trigger
		End Sub
		
		Private Sub BtnStopLoopClick(sender As System.Object, e As System.EventArgs)
			Me.LoopTimer.Enabled = False
		End Sub
		
		Private Sub LoopTimerElapsed(sender As System.Object, e As System.Timers.ElapsedEventArgs)
            Me.WriteToCurrentGPIBDevice()
            Me.ReadDataFromCurrentInstrument()
		End Sub

		Private Sub WriteToCurrentGPIBDevice()
			Me.tbSentData.AppendText(Me.tbCommands.Text & NewLine)
			If Not RunFreeCalInNonGPIBMode Then
				If Me.cbInsertNewLineOnWrite.Checked Then
					Me.CurrentGPIBDevice.Write(Me.tbCommands.Text & NewLine)
				Else
					Me.CurrentGPIBDevice.Write(Me.tbCommands.Text)
				End If
			End If	
		End Sub

		Private Sub ReadDataFromCurrentInstrument()
			If Not RunFreeCalInNonGPIBMode Then
				Select CType([Enum].Parse(GetType(InstrumentDataTypeEnum), Me.cbReadDataType.SelectedItem), InstrumentDataTypeEnum)
					Case InstrumentDataTypeEnum.String
						If Me.chbReadNumberOfBytes.Checked Then
							Me.tbReceivedData.AppendText(Me.CurrentGPIBDevice.ReadString(CInt(Me.tbReadNumberOfBytes.Text) & NewLine))
						Else
							Me.tbReceivedData.AppendText(Me.CurrentGPIBDevice.ReadString & NewLine)
						End If
					Case InstrumentDataTypeEnum.Single
						Me.tbReceivedData.AppendText(Me.CurrentGPIBDevice.ReadDouble & NewLine)
					Case InstrumentDataTypeEnum.Double
						Me.tbReceivedData.AppendText(Me.CurrentGPIBDevice.ReadDouble & NewLine)
					Case InstrumentDataTypeEnum.Binary
						Dim Bytes() As Byte
						If Me.chbReadNumberOfBytes.Checked Then
							Bytes = Me.CurrentGPIBDevice.ReadByteArray(CInt(Me.tbReadNumberOfBytes.Text))
						Else
							Bytes = Me.CurrentGPIBDevice.ReadByteArray
						End If
						For Each B As Byte In Bytes
							Me.tbReceivedData.AppendText(B & Space(1))
						Next
						Me.tbReceivedData.AppendText(NewLine)
				End Select
			Else
				Me.tbReceivedData.AppendText(Me.tbCommands.Text & " - FreeCal is running in Non-GPIB mode, connect a GPIB board for proper operation." & NewLine)
			End If
		End Sub

		Private Sub BtnNotifyClick(sender As System.Object, e As System.EventArgs)
			Try
				If Me.btnNotify.Text = "Start Notify" Then
					Me.btnNotify.Text = "Stop Notify"
					Me.CurrentGPIBDevice.Notify(CType([Enum].Parse(GetType(GpibStatusFlags), Me.cbNotifyStatusFlag.SelectedItem), GpibStatusFlags), AddressOf Me.NotifyCallback, "Notify Status Returned")
				ElseIf Me.btnNotify.Text = "Stop Notify" Then
					Me.btnNotify.Text = "Start Notify"
				End If
			Catch
				Me.btnNotify.Text = "Start Notify"
			End Try
		End Sub

		Private Sub NotifyCallBack(ByVal sender As Object, ByVal userData As NotifyData)
			Me.tbReceivedData.AppendText(NewLine & "*** GPIB Notify Status Returned ***" & NewLine & userData.ToString)
			Me.tbReceivedData.AppendText(NewLine & Me.CurrentGPIBDevice.SerialPoll)
			If (Me.btnNotify.Text = "Stop Notify" And Me.chkLoopNotify.Checked) Then
				userData.SetReenableMask(CType([Enum].Parse(GetType(GpibStatusFlags), Me.cbNotifyStatusFlag.SelectedItem), GpibStatusFlags))
			Else
				Me.btnNotify.Text = "Start Notify"
			End If
		End Sub

		Private Sub CbNotifyStatusFlagKeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
			e.Handled = True
		End Sub

		Private Sub BtnClearSentDataClick(sender As System.Object, e As System.EventArgs)
			Me.tbSentData.Clear
		End Sub

		Private Sub BtnConvertBinaryClick(sender As System.Object, e As System.EventArgs)
			Dim StringData() As String = Me.tbReceivedData.SelectedText.Split(" ")
			Dim Bytes(StringData.GetUpperBound(0)) As Byte
			Try
				For I As Integer = 0 To StringData.GetUpperBound(0)
					Bytes(I) = StringData(I)
				Next
			Catch Ex As Exception
				MessageBox.Show(Ex.Message)
			End Try
			Try
				Me.tbReceivedData.AppendText(NewLine & NewLine & "*** Converted " & Me.tbReceivedData.SelectedText & " to " & Me.cbReadDataType.SelectedItem & " ***" & NewLine)
				Select CType([Enum].Parse(GetType(InstrumentDataTypeEnum), Me.cbReadDataType.SelectedItem), InstrumentDataTypeEnum)
					Case InstrumentDataTypeEnum.Int16
						Me.tbReceivedData.AppendText(BitConverter.ToInt16(Bytes, 0) & Space(1))
					Case InstrumentDataTypeEnum.Double
						Me.tbReceivedData.AppendText(BitConverter.ToDouble(Bytes, 0) & Space(1))
					Case InstrumentDataTypeEnum.Int32
						Me.tbReceivedData.AppendText(BitConverter.ToInt32(Bytes, 0) & Space(1))
					Case InstrumentDataTypeEnum.Integer
						Me.tbReceivedData.AppendText(BitConverter.ToInt32(Bytes, 0) & Space(1))
					Case InstrumentDataTypeEnum.Single
						Me.tbReceivedData.AppendText(BitConverter.ToSingle(Bytes, 0) & Space(1))
					Case InstrumentDataTypeEnum.String
						Me.tbReceivedData.AppendText(BitConverter.ToString(Bytes) & Space(1))
				End Select
			Catch Ex As Exception
				MessageBox.Show(Ex.Message)
			End Try
		End Sub

	End Class

