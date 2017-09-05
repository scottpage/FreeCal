'
' Created by SharpDevelop.
' User: rspage
' Date: 4/5/2005
' Time: 3:41 PM
' 

Imports System.Windows.Forms
Imports System.Xml
Imports Microsoft.VisualBasic.ControlChars

Public Class SplashForm
    Inherits System.Windows.Forms.Form

    Private WithEvents components As System.ComponentModel.IContainer
    Private WithEvents cbDoNotShowAgain As System.Windows.Forms.CheckBox
    Private WithEvents pbFreeCalImage As System.Windows.Forms.PictureBox
    Private WithEvents MyTimer As System.Windows.Forms.Timer

    Public Sub New()
        MyBase.New
        '
        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        '
        Me.InitializeComponent()
        Me.MyTimer.Interval = 10000
        Me.MyTimer.Enabled = True
        Me.Width = Me.pbFreeCalImage.Image.Width
        Me.Height = Me.pbFreeCalImage.Image.Height
    End Sub

#Region " Windows Forms Designer generated code "
    ' This method is required for Windows Forms designer support.
    ' Do not change the method contents inside the source code editor. The Forms designer might
    ' not be able to load this method if it was changed manually.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.MyTimer = New System.Windows.Forms.Timer(Me.components)
        Me.pbFreeCalImage = New System.Windows.Forms.PictureBox()
        Me.cbDoNotShowAgain = New System.Windows.Forms.CheckBox()
        CType(Me.pbFreeCalImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MyTimer
        '
        '
        'pbFreeCalImage
        '
        Me.pbFreeCalImage.BackColor = System.Drawing.SystemColors.Control
        Me.pbFreeCalImage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbFreeCalImage.Location = New System.Drawing.Point(0, 0)
        Me.pbFreeCalImage.Name = "pbFreeCalImage"
        Me.pbFreeCalImage.Size = New System.Drawing.Size(1711, 1107)
        Me.pbFreeCalImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbFreeCalImage.TabIndex = 0
        Me.pbFreeCalImage.TabStop = False
        '
        'cbDoNotShowAgain
        '
        Me.cbDoNotShowAgain.BackColor = System.Drawing.SystemColors.ControlDark
        Me.cbDoNotShowAgain.Checked = True
        Me.cbDoNotShowAgain.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbDoNotShowAgain.Location = New System.Drawing.Point(16, 384)
        Me.cbDoNotShowAgain.Name = "cbDoNotShowAgain"
        Me.cbDoNotShowAgain.Size = New System.Drawing.Size(32, 30)
        Me.cbDoNotShowAgain.TabIndex = 1
        Me.cbDoNotShowAgain.UseVisualStyleBackColor = False
        '
        'SplashForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(10, 24)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1711, 1107)
        Me.ControlBox = False
        Me.Controls.Add(Me.cbDoNotShowAgain)
        Me.Controls.Add(Me.pbFreeCalImage)
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "SplashForm"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FreeCal"
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        CType(Me.pbFreeCalImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    Private Sub MyTimerTick(sender As System.Object, e As System.EventArgs) Handles MyTimer.Tick
        Me.MyTimer.Enabled = False
        Me.Close()
    End Sub

    Private Sub CbDoNotShowAgainCheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbDoNotShowAgain.CheckedChanged
        Try
            Dim MyXmlTextWriter As New XmlTextWriter("c:\FreeCalSettings.xml", Nothing)
            MyXmlTextWriter.Formatting = Formatting.Indented
            MyXmlTextWriter.WriteStartElement("FreeCal")
            MyXmlTextWriter.WriteStartElement("Startup")
            MyXmlTextWriter.WriteStartElement("Display")
            MyXmlTextWriter.WriteAttributeString("ShowSlashScreen", "False")
            MyXmlTextWriter.WriteFullEndElement()
            MyXmlTextWriter.Close()
            Me.Close()
        Catch Ex As Exception
            MessageBox.Show(Ex.Message & NewLine & " - " & Ex.GetBaseException.ToString & " - " & Ex.StackTrace)
        End Try
    End Sub

End Class

