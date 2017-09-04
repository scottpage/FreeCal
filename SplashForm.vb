'
' Created by SharpDevelop.
' User: rspage
' Date: 4/5/2005
' Time: 3:41 PM
' 


Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Xml
Imports System.IO
Imports FreeCal.Common
Imports FreeCal
Imports System.Threading
Imports Microsoft.VisualBasic.ControlChars


	
	Public Class SplashForm
		Inherits System.Windows.Forms.Form
		Private components As System.ComponentModel.IContainer
		Private cbDoNotShowAgain As System.Windows.Forms.CheckBox
		Private pbFreeCalImage As System.Windows.Forms.PictureBox
		Private MyTimer As System.Windows.Forms.Timer
		
		Public Sub New()
			MyBase.New
			'
			' The Me.InitializeComponent call is required for Windows Forms designer support.
			'
			Me.InitializeComponent    
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
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SplashForm))
            Me.MyTimer = New System.Windows.Forms.Timer(Me.components)
            Me.pbFreeCalImage = New System.Windows.Forms.PictureBox
            Me.cbDoNotShowAgain = New System.Windows.Forms.CheckBox
            Me.SuspendLayout
            '
            'MyTimer
            '
            AddHandler Me.MyTimer.Tick, AddressOf Me.MyTimerTick
            '
            'pbFreeCalImage
            '
            Me.pbFreeCalImage.BackColor = System.Drawing.SystemColors.Control
            Me.pbFreeCalImage.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pbFreeCalImage.Image = CType(resources.GetObject("pbFreeCalImage.Image"),System.Drawing.Image)
            Me.pbFreeCalImage.Location = New System.Drawing.Point(0, 0)
            Me.pbFreeCalImage.Name = "pbFreeCalImage"
            Me.pbFreeCalImage.Size = New System.Drawing.Size(600, 233)
            Me.pbFreeCalImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            Me.pbFreeCalImage.TabIndex = 0
            Me.pbFreeCalImage.TabStop = false
            '
            'cbDoNotShowAgain
            '
            Me.cbDoNotShowAgain.BackColor = System.Drawing.SystemColors.ControlDark
            Me.cbDoNotShowAgain.Checked = true
            Me.cbDoNotShowAgain.CheckState = System.Windows.Forms.CheckState.Checked
            Me.cbDoNotShowAgain.Location = New System.Drawing.Point(8, 208)
            Me.cbDoNotShowAgain.Name = "cbDoNotShowAgain"
            Me.cbDoNotShowAgain.Size = New System.Drawing.Size(16, 16)
            Me.cbDoNotShowAgain.TabIndex = 1
            AddHandler Me.cbDoNotShowAgain.CheckedChanged, AddressOf Me.CbDoNotShowAgainCheckedChanged
            '
            'SplashForm
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.SystemColors.Control
            Me.ClientSize = New System.Drawing.Size(600, 232)
            Me.ControlBox = false
            Me.Controls.Add(Me.cbDoNotShowAgain)
            Me.Controls.Add(Me.pbFreeCalImage)
            Me.Cursor = System.Windows.Forms.Cursors.Arrow
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Name = "SplashForm"
            Me.ShowInTaskbar = false
            Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "FreeCal"
            Me.TopMost = true
            Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(224,Byte), CType(224,Byte), CType(224,Byte))
            Me.ResumeLayout(false)
        End Sub
		#End Region

		Private Sub MyTimerTick(sender As System.Object, e As System.EventArgs)
		    Me.MyTimer.Enabled = False
            Me.Close
		End Sub

        Private Sub CbDoNotShowAgainCheckedChanged(sender As System.Object, e As System.EventArgs)
            Try
                Dim MyXmlTextWriter As New XmlTextWriter("c:\FreeCalSettings.xml", Nothing)
                MyXmlTextWriter.Formatting = Formatting.Indented
                MyXmlTextWriter.WriteStartElement("FreeCal")
                MyXmlTextWriter.WriteStartElement("Startup")
                MyXmlTextWriter.WriteStartElement("Display")
                MyXmlTextWriter.WriteAttributeString("ShowSlashScreen", "False")
                MyXmlTextWriter.WriteFullEndElement()
                MyXmlTextWriter.Close
                Me.Close
            Catch Ex As Exception
                MessageBox.Show(Ex.Message & NewLine & " - " & Ex.GetBaseException.ToString & " - " & Ex.StackTrace)
            End Try
        End Sub

	End Class

