'
' Created by SharpDevelop.
' User: rspage
' Date: 4/13/2005
' Time: 9:19 AM
' 

Imports System
Imports System.Windows.Forms
Imports FreeCal.Common
Imports FreeCal.Instruments
Imports Microsoft.VisualBasic
Imports NationalInstruments.NI4882

Public Enum InstrumentDataTypeEnum As Integer
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

    Private WithEvents chbReadNumberOfBytes As System.Windows.Forms.CheckBox
    Private WithEvents lblTimeout As System.Windows.Forms.Label
    Private WithEvents btnConnect As System.Windows.Forms.Button
    Private WithEvents lblBus As System.Windows.Forms.Label
    Private WithEvents LoopTimer As System.Timers.Timer
    Private WithEvents btnConvertBinary As System.Windows.Forms.Button
    Private WithEvents cbNotifyStatusFlag As System.Windows.Forms.ComboBox
    Private WithEvents tbCommands As System.Windows.Forms.TextBox
    Private WithEvents btnRead As System.Windows.Forms.Button
    Private WithEvents tbSentData As System.Windows.Forms.TextBox
    Private WithEvents lblPrimaryAddress As System.Windows.Forms.Label
    Private WithEvents btnSend As System.Windows.Forms.Button
    Private WithEvents chkLoop As System.Windows.Forms.CheckBox
    Private WithEvents chkLoopNotify As System.Windows.Forms.CheckBox
    Private WithEvents tbReceivedData As System.Windows.Forms.TextBox
    Private WithEvents btnStopLoop As System.Windows.Forms.Button
    Private WithEvents btnClearReceivedData As System.Windows.Forms.Button
    Private WithEvents tbReadNumberOfBytes As System.Windows.Forms.TextBox
    Private WithEvents cbInsertNewLineOnWrite As System.Windows.Forms.CheckBox
    Private WithEvents btnDisconnect As System.Windows.Forms.Button
    Private WithEvents cbReadDataType As System.Windows.Forms.ComboBox
    Private WithEvents btnQuery As System.Windows.Forms.Button
    Private WithEvents btnClearSentData As System.Windows.Forms.Button
    Private WithEvents cbBusDevices As System.Windows.Forms.ComboBox
    Private WithEvents btnNotify As System.Windows.Forms.Button
    Private WithEvents cbBoards As System.Windows.Forms.ComboBox
    Private WithEvents cbTimeout As System.Windows.Forms.ComboBox
    Private WithEvents gbNotify As System.Windows.Forms.GroupBox
    Private WithEvents lblCommands As System.Windows.Forms.Label
    Private WithEvents btnTrigger As System.Windows.Forms.Button

    Private CurrentGPIBDevice As Instrument

    Public Sub New()
        MyBase.New
        '
        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        '
        Me.InitializeComponent()
        SetControlConfigurationOptions(Me, Me.Controls)
        Me.FillComboBoxes()
    End Sub

#Region " Windows Forms Designer generated code "
    ' This method is required for Windows Forms designer support.
    ' Do not change the method contents inside the source code editor. The Forms designer might
    ' not be able to load this method if it was changed manually.
    Private Sub InitializeComponent()
        Me.btnTrigger = New System.Windows.Forms.Button()
        Me.lblCommands = New System.Windows.Forms.Label()
        Me.gbNotify = New System.Windows.Forms.GroupBox()
        Me.cbNotifyStatusFlag = New System.Windows.Forms.ComboBox()
        Me.chkLoopNotify = New System.Windows.Forms.CheckBox()
        Me.btnNotify = New System.Windows.Forms.Button()
        Me.cbTimeout = New System.Windows.Forms.ComboBox()
        Me.cbBoards = New System.Windows.Forms.ComboBox()
        Me.cbBusDevices = New System.Windows.Forms.ComboBox()
        Me.btnClearSentData = New System.Windows.Forms.Button()
        Me.btnQuery = New System.Windows.Forms.Button()
        Me.cbReadDataType = New System.Windows.Forms.ComboBox()
        Me.btnDisconnect = New System.Windows.Forms.Button()
        Me.cbInsertNewLineOnWrite = New System.Windows.Forms.CheckBox()
        Me.tbReadNumberOfBytes = New System.Windows.Forms.TextBox()
        Me.btnClearReceivedData = New System.Windows.Forms.Button()
        Me.btnStopLoop = New System.Windows.Forms.Button()
        Me.tbReceivedData = New System.Windows.Forms.TextBox()
        Me.chkLoop = New System.Windows.Forms.CheckBox()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.lblPrimaryAddress = New System.Windows.Forms.Label()
        Me.tbSentData = New System.Windows.Forms.TextBox()
        Me.btnRead = New System.Windows.Forms.Button()
        Me.tbCommands = New System.Windows.Forms.TextBox()
        Me.btnConvertBinary = New System.Windows.Forms.Button()
        Me.LoopTimer = New System.Timers.Timer()
        Me.lblBus = New System.Windows.Forms.Label()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.lblTimeout = New System.Windows.Forms.Label()
        Me.chbReadNumberOfBytes = New System.Windows.Forms.CheckBox()
        Me.gbNotify.SuspendLayout()
        CType(Me.LoopTimer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnTrigger
        '
        Me.btnTrigger.Location = New System.Drawing.Point(544, 177)
        Me.btnTrigger.Name = "btnTrigger"
        Me.btnTrigger.Size = New System.Drawing.Size(150, 43)
        Me.btnTrigger.TabIndex = 18
        Me.btnTrigger.Text = "Trigger"
        '
        'lblCommands
        '
        Me.lblCommands.AutoSize = True
        Me.lblCommands.Location = New System.Drawing.Point(16, 103)
        Me.lblCommands.Name = "lblCommands"
        Me.lblCommands.Size = New System.Drawing.Size(264, 25)
        Me.lblCommands.TabIndex = 4
        Me.lblCommands.Text = "Enter command(s) to send"
        '
        'gbNotify
        '
        Me.gbNotify.Controls.Add(Me.cbNotifyStatusFlag)
        Me.gbNotify.Controls.Add(Me.chkLoopNotify)
        Me.gbNotify.Controls.Add(Me.btnNotify)
        Me.gbNotify.Location = New System.Drawing.Point(1232, 59)
        Me.gbNotify.Name = "gbNotify"
        Me.gbNotify.Size = New System.Drawing.Size(320, 148)
        Me.gbNotify.TabIndex = 24
        Me.gbNotify.TabStop = False
        Me.gbNotify.Text = "Notify"
        '
        'cbNotifyStatusFlag
        '
        Me.cbNotifyStatusFlag.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.cbNotifyStatusFlag.Location = New System.Drawing.Point(16, 44)
        Me.cbNotifyStatusFlag.Name = "cbNotifyStatusFlag"
        Me.cbNotifyStatusFlag.Size = New System.Drawing.Size(242, 21)
        Me.cbNotifyStatusFlag.TabIndex = 24
        '
        'chkLoopNotify
        '
        Me.chkLoopNotify.Location = New System.Drawing.Point(192, 89)
        Me.chkLoopNotify.Name = "chkLoopNotify"
        Me.chkLoopNotify.Size = New System.Drawing.Size(112, 44)
        Me.chkLoopNotify.TabIndex = 23
        Me.chkLoopNotify.Text = "Loop"
        '
        'btnNotify
        '
        Me.btnNotify.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.btnNotify.Location = New System.Drawing.Point(16, 89)
        Me.btnNotify.Name = "btnNotify"
        Me.btnNotify.Size = New System.Drawing.Size(160, 42)
        Me.btnNotify.TabIndex = 22
        Me.btnNotify.Text = "Start Notify"
        '
        'cbTimeout
        '
        Me.cbTimeout.Location = New System.Drawing.Point(784, 44)
        Me.cbTimeout.Name = "cbTimeout"
        Me.cbTimeout.Size = New System.Drawing.Size(242, 33)
        Me.cbTimeout.TabIndex = 14
        Me.cbTimeout.Text = "T1s"
        '
        'cbBoards
        '
        Me.cbBoards.Location = New System.Drawing.Point(128, 44)
        Me.cbBoards.Name = "cbBoards"
        Me.cbBoards.Size = New System.Drawing.Size(242, 33)
        Me.cbBoards.TabIndex = 7
        '
        'cbBusDevices
        '
        Me.cbBusDevices.Location = New System.Drawing.Point(512, 44)
        Me.cbBusDevices.Name = "cbBusDevices"
        Me.cbBusDevices.Size = New System.Drawing.Size(160, 33)
        Me.cbBusDevices.TabIndex = 16
        '
        'btnClearSentData
        '
        Me.btnClearSentData.Location = New System.Drawing.Point(1472, 213)
        Me.btnClearSentData.Name = "btnClearSentData"
        Me.btnClearSentData.Size = New System.Drawing.Size(192, 43)
        Me.btnClearSentData.TabIndex = 27
        Me.btnClearSentData.Text = "Clear Sent Data"
        '
        'btnQuery
        '
        Me.btnQuery.Enabled = False
        Me.btnQuery.Location = New System.Drawing.Point(368, 177)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(150, 43)
        Me.btnQuery.TabIndex = 2
        Me.btnQuery.Text = "Query"
        '
        'cbReadDataType
        '
        Me.cbReadDataType.Location = New System.Drawing.Point(192, 222)
        Me.cbReadDataType.Name = "cbReadDataType"
        Me.cbReadDataType.Size = New System.Drawing.Size(160, 33)
        Me.cbReadDataType.TabIndex = 25
        '
        'btnDisconnect
        '
        Me.btnDisconnect.Enabled = False
        Me.btnDisconnect.Location = New System.Drawing.Point(1072, 177)
        Me.btnDisconnect.Name = "btnDisconnect"
        Me.btnDisconnect.Size = New System.Drawing.Size(150, 43)
        Me.btnDisconnect.TabIndex = 13
        Me.btnDisconnect.Text = "Disconnect"
        '
        'cbInsertNewLineOnWrite
        '
        Me.cbInsertNewLineOnWrite.Location = New System.Drawing.Point(528, 222)
        Me.cbInsertNewLineOnWrite.Name = "cbInsertNewLineOnWrite"
        Me.cbInsertNewLineOnWrite.Size = New System.Drawing.Size(256, 44)
        Me.cbInsertNewLineOnWrite.TabIndex = 29
        Me.cbInsertNewLineOnWrite.Text = "Newline on Write"
        '
        'tbReadNumberOfBytes
        '
        Me.tbReadNumberOfBytes.Location = New System.Drawing.Point(1216, 15)
        Me.tbReadNumberOfBytes.Name = "tbReadNumberOfBytes"
        Me.tbReadNumberOfBytes.Size = New System.Drawing.Size(158, 31)
        Me.tbReadNumberOfBytes.TabIndex = 21
        '
        'btnClearReceivedData
        '
        Me.btnClearReceivedData.Location = New System.Drawing.Point(720, 177)
        Me.btnClearReceivedData.Name = "btnClearReceivedData"
        Me.btnClearReceivedData.Size = New System.Drawing.Size(150, 43)
        Me.btnClearReceivedData.TabIndex = 15
        Me.btnClearReceivedData.Text = "Clear Data"
        '
        'btnStopLoop
        '
        Me.btnStopLoop.Location = New System.Drawing.Point(1040, 15)
        Me.btnStopLoop.Name = "btnStopLoop"
        Me.btnStopLoop.Size = New System.Drawing.Size(160, 42)
        Me.btnStopLoop.TabIndex = 19
        Me.btnStopLoop.Text = "Stop Looping"
        '
        'tbReceivedData
        '
        Me.tbReceivedData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbReceivedData.BackColor = System.Drawing.Color.SteelBlue
        Me.tbReceivedData.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbReceivedData.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.tbReceivedData.ForeColor = System.Drawing.Color.Yellow
        Me.tbReceivedData.Location = New System.Drawing.Point(16, 266)
        Me.tbReceivedData.Multiline = True
        Me.tbReceivedData.Name = "tbReceivedData"
        Me.tbReceivedData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbReceivedData.Size = New System.Drawing.Size(1360, 800)
        Me.tbReceivedData.TabIndex = 5
        '
        'chkLoop
        '
        Me.chkLoop.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.chkLoop.Location = New System.Drawing.Point(1056, 74)
        Me.chkLoop.Name = "chkLoop"
        Me.chkLoop.Size = New System.Drawing.Size(112, 44)
        Me.chkLoop.TabIndex = 17
        Me.chkLoop.Text = "Loop"
        '
        'btnSend
        '
        Me.btnSend.Enabled = False
        Me.btnSend.Location = New System.Drawing.Point(16, 177)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(150, 43)
        Me.btnSend.TabIndex = 0
        Me.btnSend.Text = "Send"
        '
        'lblPrimaryAddress
        '
        Me.lblPrimaryAddress.AutoSize = True
        Me.lblPrimaryAddress.Location = New System.Drawing.Point(496, 15)
        Me.lblPrimaryAddress.Name = "lblPrimaryAddress"
        Me.lblPrimaryAddress.Size = New System.Drawing.Size(170, 25)
        Me.lblPrimaryAddress.TabIndex = 8
        Me.lblPrimaryAddress.Text = "Primary Address"
        '
        'tbSentData
        '
        Me.tbSentData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbSentData.BackColor = System.Drawing.Color.SlateGray
        Me.tbSentData.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tbSentData.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.tbSentData.ForeColor = System.Drawing.Color.Yellow
        Me.tbSentData.Location = New System.Drawing.Point(1392, 266)
        Me.tbSentData.Multiline = True
        Me.tbSentData.Name = "tbSentData"
        Me.tbSentData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbSentData.Size = New System.Drawing.Size(351, 800)
        Me.tbSentData.TabIndex = 26
        '
        'btnRead
        '
        Me.btnRead.Enabled = False
        Me.btnRead.Location = New System.Drawing.Point(192, 177)
        Me.btnRead.Name = "btnRead"
        Me.btnRead.Size = New System.Drawing.Size(160, 43)
        Me.btnRead.TabIndex = 1
        Me.btnRead.Text = "Read"
        '
        'tbCommands
        '
        Me.tbCommands.Location = New System.Drawing.Point(16, 133)
        Me.tbCommands.Name = "tbCommands"
        Me.tbCommands.Size = New System.Drawing.Size(1200, 31)
        Me.tbCommands.TabIndex = 3
        '
        'btnConvertBinary
        '
        Me.btnConvertBinary.Location = New System.Drawing.Point(368, 222)
        Me.btnConvertBinary.Name = "btnConvertBinary"
        Me.btnConvertBinary.Size = New System.Drawing.Size(150, 42)
        Me.btnConvertBinary.TabIndex = 28
        Me.btnConvertBinary.Text = "Convert"
        '
        'LoopTimer
        '
        Me.LoopTimer.Interval = 500.0R
        Me.LoopTimer.SynchronizingObject = Me
        '
        'lblBus
        '
        Me.lblBus.AutoSize = True
        Me.lblBus.Location = New System.Drawing.Point(224, 15)
        Me.lblBus.Name = "lblBus"
        Me.lblBus.Size = New System.Drawing.Size(49, 25)
        Me.lblBus.TabIndex = 6
        Me.lblBus.Text = "Bus"
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(896, 177)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(150, 43)
        Me.btnConnect.TabIndex = 12
        Me.btnConnect.Text = "Connect"
        '
        'lblTimeout
        '
        Me.lblTimeout.AutoSize = True
        Me.lblTimeout.Location = New System.Drawing.Point(848, 15)
        Me.lblTimeout.Name = "lblTimeout"
        Me.lblTimeout.Size = New System.Drawing.Size(89, 25)
        Me.lblTimeout.TabIndex = 10
        Me.lblTimeout.Text = "Timeout"
        '
        'chbReadNumberOfBytes
        '
        Me.chbReadNumberOfBytes.Location = New System.Drawing.Point(1392, 0)
        Me.chbReadNumberOfBytes.Name = "chbReadNumberOfBytes"
        Me.chbReadNumberOfBytes.Size = New System.Drawing.Size(272, 74)
        Me.chbReadNumberOfBytes.TabIndex = 20
        Me.chbReadNumberOfBytes.Text = "Read Number of Bytes"
        '
        'InstrumentControlForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(10, 24)
        Me.ClientSize = New System.Drawing.Size(1763, 1093)
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
        Me.gbNotify.ResumeLayout(False)
        CType(Me.LoopTimer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    Private Sub FillComboBoxes()
        Me.cbTimeout.DataSource = [Enum].GetNames(GetType(TimeoutValue))
        Me.cbTimeout.Text = "T1s"
        Me.cbBoards.DataSource = GetActiveGPIBBusNames()

        If Me.cbBoards.Items.Count > 0 Then
            Me.cbBoards.SelectedIndex = 0
            Me.cbBusDevices.DataSource = GetGPIBBusAddresses(CType([Enum].Parse(GetType(Boards), Me.cbBoards.SelectedItem.ToString), Boards))
            If Me.cbBusDevices.Items.Count > 0 Then
                Me.cbBusDevices.SelectedIndex = 0
            End If
        End If
        Me.cbReadDataType.DataSource = [Enum].GetNames(GetType(InstrumentDataTypeEnum))
        Me.cbReadDataType.SelectedIndex = 0
        Me.cbNotifyStatusFlag.DataSource = [Enum].GetNames(GetType(GpibStatusFlags))
        Me.cbNotifyStatusFlag.SelectedIndex = 0
    End Sub

    Private Sub BtnConnectClick(sender As System.Object, e As System.EventArgs) Handles btnConnect.Click
        If Me.cbBoards.Items.Count > 0 Then
            Dim SelectedBoard As Boards = CType([Enum].Parse(GetType(Boards), Me.cbBoards.SelectedItem.ToString), Boards)
            Dim NewGPIBDevice As New Instrument(SelectedBoard, Convert.ToByte(Me.cbBusDevices.SelectedItem), False)
            Me.CurrentGPIBDevice = NewGPIBDevice
            Me.CurrentGPIBDevice.IOTimeout = CType([Enum].Parse(GetType(TimeoutValue), Me.cbTimeout.SelectedItem.ToString), TimeoutValue)
            Me.btnDisconnect.Enabled = True
            Me.btnConnect.Enabled = False
            Me.btnQuery.Enabled = True
            Me.btnRead.Enabled = True
            Me.btnSend.Enabled = True
        End If
    End Sub

    Private Sub BtnDisconnectClick(sender As System.Object, e As System.EventArgs) Handles btnDisconnect.Click
        Me.CurrentGPIBDevice.Dispose()
        Me.LoopTimer.Enabled = False
        Me.btnDisconnect.Enabled = False
        Me.btnConnect.Enabled = True
        Me.btnQuery.Enabled = False
        Me.btnRead.Enabled = False
        Me.btnSend.Enabled = False
    End Sub

    Private Sub BtnSendClick(sender As System.Object, e As System.EventArgs) Handles btnSend.Click
        Me.WriteToCurrentGPIBDevice()
    End Sub

    Private Sub BtnReadClick(sender As System.Object, e As System.EventArgs) Handles btnRead.Click
        Me.ReadDataFromCurrentInstrument()
    End Sub

    Private Sub BtnQueryClick(sender As System.Object, e As System.EventArgs) Handles btnQuery.Click
        If Me.chkLoop.Checked Then
            Me.LoopTimer.Enabled = True
        Else
            Me.WriteToCurrentGPIBDevice()
            Me.ReadDataFromCurrentInstrument()
        End If
    End Sub

    Private Sub BtnClearReceivedDataClick(sender As System.Object, e As System.EventArgs) Handles btnClearReceivedData.Click
        Me.tbReceivedData.Clear()
    End Sub

    Private Sub CbBoardsSelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbBoards.SelectedIndexChanged
        Me.cbBusDevices.DataSource = GetGPIBBusAddresses(CType([Enum].Parse(GetType(Boards), Me.cbBoards.SelectedItem.ToString), Boards))
    End Sub

    Private Sub BtnTriggerClick(sender As System.Object, e As System.EventArgs) Handles btnTrigger.Click
        Me.CurrentGPIBDevice.Trigger()
    End Sub

    Private Sub BtnStopLoopClick(sender As System.Object, e As System.EventArgs) Handles btnStopLoop.Click
        Me.LoopTimer.Enabled = False
    End Sub

    Private Sub LoopTimerElapsed(sender As System.Object, e As System.Timers.ElapsedEventArgs) Handles LoopTimer.Elapsed
        Me.WriteToCurrentGPIBDevice()
        Me.ReadDataFromCurrentInstrument()
    End Sub

    Private Sub WriteToCurrentGPIBDevice()
        Me.tbSentData.AppendText(Me.tbCommands.Text & ControlChars.NewLine)
        If Not RunFreeCalInNonGPIBMode Then
            If Me.cbInsertNewLineOnWrite.Checked Then
                Me.CurrentGPIBDevice.Write(Me.tbCommands.Text & ControlChars.NewLine)
            Else
                Me.CurrentGPIBDevice.Write(Me.tbCommands.Text)
            End If
        End If
    End Sub

    Private Sub ReadDataFromCurrentInstrument()
        If Not RunFreeCalInNonGPIBMode Then
            Select Case CType([Enum].Parse(GetType(InstrumentDataTypeEnum), Me.cbReadDataType.SelectedItem.ToString), InstrumentDataTypeEnum)
                Case InstrumentDataTypeEnum.String
                    If Me.chbReadNumberOfBytes.Checked Then
                        Me.tbReceivedData.AppendText(Me.CurrentGPIBDevice.ReadString(Convert.ToInt32(Me.tbReadNumberOfBytes.Text)) & ControlChars.NewLine)
                    Else
                        Me.tbReceivedData.AppendText(Me.CurrentGPIBDevice.ReadString & ControlChars.NewLine)
                    End If
                Case InstrumentDataTypeEnum.Single
                    Me.tbReceivedData.AppendText(Me.CurrentGPIBDevice.ReadDouble & ControlChars.NewLine)
                Case InstrumentDataTypeEnum.Double
                    Me.tbReceivedData.AppendText(Me.CurrentGPIBDevice.ReadDouble & ControlChars.NewLine)
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
                    Me.tbReceivedData.AppendText(ControlChars.NewLine)
            End Select
        Else
            Me.tbReceivedData.AppendText(Me.tbCommands.Text & " - FreeCal is running in Non-GPIB mode, connect a GPIB board for proper operation." & ControlChars.NewLine)
        End If
    End Sub

    Private Sub BtnNotifyClick(sender As System.Object, e As System.EventArgs) Handles btnNotify.Click
        Try
            If Me.btnNotify.Text = "Start Notify" Then
                Me.btnNotify.Text = "Stop Notify"
                Me.CurrentGPIBDevice.Notify(CType([Enum].Parse(GetType(GpibStatusFlags), Me.cbNotifyStatusFlag.SelectedItem.ToString), GpibStatusFlags), AddressOf Me.NotifyCallBack, "Notify Status Returned")
            ElseIf Me.btnNotify.Text = "Stop Notify" Then
                Me.btnNotify.Text = "Start Notify"
            End If
        Catch
            Me.btnNotify.Text = "Start Notify"
        End Try
    End Sub

    Private Sub NotifyCallBack(ByVal sender As Object, ByVal userData As NotifyData)
        Me.tbReceivedData.AppendText(ControlChars.NewLine & "*** GPIB Notify Status Returned ***" & ControlChars.NewLine & userData.ToString)
        Me.tbReceivedData.AppendText(ControlChars.NewLine & Me.CurrentGPIBDevice.SerialPoll)
        If (Me.btnNotify.Text = "Stop Notify" And Me.chkLoopNotify.Checked) Then
            userData.SetReenableMask(CType([Enum].Parse(GetType(GpibStatusFlags), Me.cbNotifyStatusFlag.SelectedItem.ToString), GpibStatusFlags))
        Else
            Me.btnNotify.Text = "Start Notify"
        End If
    End Sub

    Private Sub CbNotifyStatusFlagKeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbNotifyStatusFlag.KeyPress
        e.Handled = True
    End Sub

    Private Sub BtnClearSentDataClick(sender As System.Object, e As System.EventArgs) Handles btnClearSentData.Click
        Me.tbSentData.Clear()
    End Sub

    Private Sub BtnConvertBinaryClick(sender As System.Object, e As System.EventArgs) Handles btnConvertBinary.Click
        Dim StringData() As String = Me.tbReceivedData.SelectedText.Split(" "c)
        Dim Bytes(StringData.GetUpperBound(0)) As Byte
        Try
            For I As Integer = 0 To StringData.GetUpperBound(0)
                Bytes(I) = Convert.ToByte(StringData(I))
            Next
        Catch Ex As Exception
            MessageBox.Show(Ex.Message)
        End Try
        Try
            Me.tbReceivedData.AppendText(ControlChars.NewLine & ControlChars.NewLine & "*** Converted " & Me.tbReceivedData.SelectedText & " to " & Me.cbReadDataType.SelectedItem.ToString & " ***" & ControlChars.NewLine)
            Select Case CType([Enum].Parse(GetType(InstrumentDataTypeEnum), Me.cbReadDataType.SelectedItem.ToString), InstrumentDataTypeEnum)
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

