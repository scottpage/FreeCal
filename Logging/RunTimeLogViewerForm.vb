'
' Created by SharpDevelop.
' User: Administrator
' Date: 7/29/2005
' Time: 11:25 PM
'


Imports System.Windows.Forms

Public Class RunTimeLogViewerForm
    Inherits System.Windows.Forms.Form

    Private WithEvents MDIParentForm As Form
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents BtnClose As System.Windows.Forms.Button
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents TbEventLog As System.Windows.Forms.TextBox
    Private WithEvents ChkbLogInstrumentRead As System.Windows.Forms.CheckBox
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents BtnClearLog As System.Windows.Forms.Button
    Private WithEvents ChkbEventData As System.Windows.Forms.CheckBox
    Private WithEvents ChkbLogInstrumentWrite As System.Windows.Forms.CheckBox
    Private WithEvents ChkbMDIStatus As System.Windows.Forms.CheckBox
    Private WithEvents TbInstrumentDataRead As System.Windows.Forms.TextBox
    Private WithEvents TbInstrumentDataSent As System.Windows.Forms.TextBox

    Public Sub New()
        MyBase.New()
        '
        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        '
        Me.InitializeComponent()
        AddHandler Logger.EventLogged, AddressOf Me.OnEventLogged
        AddHandler Logger.InstrumentDataSent, AddressOf Me.OnInstrumentDataSent
        AddHandler Logger.InstrumentDataRead, AddressOf Me.OnInstrumentDataRead
    End Sub

#Region " Windows Forms Designer generated code "
    ' This method is required for Windows Forms designer support.
    ' Do not change the method contents inside the source code editor. The Forms designer might
    ' not be able to load this method if it was changed manually.
    Private Sub InitializeComponent()
        Me.tbInstrumentDataSent = New System.Windows.Forms.TextBox()
        Me.tbInstrumentDataRead = New System.Windows.Forms.TextBox()
        Me.chkbMDIStatus = New System.Windows.Forms.CheckBox()
        Me.chkbLogInstrumentWrite = New System.Windows.Forms.CheckBox()
        Me.chkbEventData = New System.Windows.Forms.CheckBox()
        Me.btnClearLog = New System.Windows.Forms.Button()
        Me.label2 = New System.Windows.Forms.Label()
        Me.chkbLogInstrumentRead = New System.Windows.Forms.CheckBox()
        Me.tbEventLog = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'tbInstrumentDataSent
        '
        Me.tbInstrumentDataSent.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbInstrumentDataSent.Location = New System.Drawing.Point(16, 44)
        Me.tbInstrumentDataSent.Multiline = True
        Me.tbInstrumentDataSent.Name = "tbInstrumentDataSent"
        Me.tbInstrumentDataSent.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.tbInstrumentDataSent.Size = New System.Drawing.Size(1416, 255)
        Me.tbInstrumentDataSent.TabIndex = 6
        '
        'tbInstrumentDataRead
        '
        Me.tbInstrumentDataRead.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbInstrumentDataRead.Location = New System.Drawing.Point(16, 251)
        Me.tbInstrumentDataRead.Multiline = True
        Me.tbInstrumentDataRead.Name = "tbInstrumentDataRead"
        Me.tbInstrumentDataRead.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.tbInstrumentDataRead.Size = New System.Drawing.Size(1416, 255)
        Me.tbInstrumentDataRead.TabIndex = 5
        '
        'chkbMDIStatus
        '
        Me.chkbMDIStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkbMDIStatus.Location = New System.Drawing.Point(1256, 757)
        Me.chkbMDIStatus.Name = "chkbMDIStatus"
        Me.chkbMDIStatus.Size = New System.Drawing.Size(152, 44)
        Me.chkbMDIStatus.TabIndex = 4
        Me.chkbMDIStatus.Text = "Floating"
        '
        'chkbLogInstrumentWrite
        '
        Me.chkbLogInstrumentWrite.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkbLogInstrumentWrite.Location = New System.Drawing.Point(16, 727)
        Me.chkbLogInstrumentWrite.Name = "chkbLogInstrumentWrite"
        Me.chkbLogInstrumentWrite.Size = New System.Drawing.Size(176, 44)
        Me.chkbLogInstrumentWrite.TabIndex = 7
        Me.chkbLogInstrumentWrite.Text = "Sent Data"
        '
        'chkbEventData
        '
        Me.chkbEventData.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkbEventData.Location = New System.Drawing.Point(16, 807)
        Me.chkbEventData.Name = "chkbEventData"
        Me.chkbEventData.Size = New System.Drawing.Size(176, 44)
        Me.chkbEventData.TabIndex = 2
        Me.chkbEventData.Text = "Events"
        '
        'btnClearLog
        '
        Me.btnClearLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClearLog.Location = New System.Drawing.Point(1112, 818)
        Me.btnClearLog.Name = "btnClearLog"
        Me.btnClearLog.Size = New System.Drawing.Size(150, 42)
        Me.btnClearLog.TabIndex = 3
        Me.btnClearLog.Text = "Clear Log"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.label2.Location = New System.Drawing.Point(16, 428)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(45, 13)
        Me.label2.TabIndex = 10
        Me.label2.Text = "Events"
        '
        'chkbLogInstrumentRead
        '
        Me.chkbLogInstrumentRead.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkbLogInstrumentRead.Location = New System.Drawing.Point(16, 768)
        Me.chkbLogInstrumentRead.Name = "chkbLogInstrumentRead"
        Me.chkbLogInstrumentRead.Size = New System.Drawing.Size(176, 44)
        Me.chkbLogInstrumentRead.TabIndex = 8
        Me.chkbLogInstrumentRead.Text = "Read Data"
        '
        'tbEventLog
        '
        Me.tbEventLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbEventLog.Location = New System.Drawing.Point(16, 458)
        Me.tbEventLog.Multiline = True
        Me.tbEventLog.Name = "tbEventLog"
        Me.tbEventLog.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.tbEventLog.Size = New System.Drawing.Size(1416, 254)
        Me.tbEventLog.TabIndex = 0
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(16, 15)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(107, 25)
        Me.label1.TabIndex = 9
        Me.label1.Text = "Sent Data"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(1288, 818)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(150, 42)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "Close"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.label3.Location = New System.Drawing.Point(16, 222)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(66, 13)
        Me.label3.TabIndex = 11
        Me.label3.Text = "Read Data"
        '
        'RunTimeLogViewerForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(10, 24)
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(1448, 871)
        Me.Controls.Add(Me.chkbEventData)
        Me.Controls.Add(Me.chkbLogInstrumentRead)
        Me.Controls.Add(Me.chkbLogInstrumentWrite)
        Me.Controls.Add(Me.tbInstrumentDataSent)
        Me.Controls.Add(Me.tbInstrumentDataRead)
        Me.Controls.Add(Me.chkbMDIStatus)
        Me.Controls.Add(Me.btnClearLog)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.tbEventLog)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1344, 842)
        Me.Name = "RunTimeLogViewerForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RunTimeLogViewer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    Private Sub OnInstrumentDataSent(ByVal message As String)
        If Me.chkbLogInstrumentWrite.Checked Then
            If Not (Me.tbInstrumentDataSent Is Nothing) Then
                Me.tbInstrumentDataSent.AppendText(NewLine & message)
            End If
        End If
    End Sub

    Private Sub OnInstrumentDataRead(ByVal message As String)
        If Me.chkbLogInstrumentRead.Checked Then
            If Not (Me.tbInstrumentDataRead Is Nothing) Then
                Me.tbInstrumentDataRead.AppendText(NewLine & message)
            End If
        End If
    End Sub

    Private Sub OnEventLogged(ByVal message As String)
        If Me.chkbEventData.Checked Then
            If Not (Me.tbEventLog Is Nothing) Then
                Me.tbEventLog.AppendText(NewLine & message)
            End If
        End If
    End Sub

    Private Sub OnLoggingEnabledChanged(ByVal setting As Boolean)
        Me.chkbEventData.Checked = FreeCal.Logging.Logger.LoggingEnabled
    End Sub

    Private Sub BtnCloseClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub ChkbMDIStatusCheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbMDIStatus.CheckedChanged
        Select Case Me.chkbMDIStatus.Checked
            Case True
                Me.MdiParent = Nothing
                Me.ShowInTaskbar = True
            Case False
                Me.MdiParent = Me.MDIParentForm
                Me.ShowInTaskbar = False
        End Select
    End Sub

    Private Sub RunTimeLogViewerFormClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        RemoveHandler Logger.EventLogged, AddressOf Me.OnEventLogged
        RemoveHandler Logger.InstrumentDataSent, AddressOf Me.OnInstrumentDataSent
        RemoveHandler Logger.InstrumentDataRead, AddressOf Me.OnInstrumentDataRead
    End Sub

End Class

