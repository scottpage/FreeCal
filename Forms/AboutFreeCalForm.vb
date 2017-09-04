'
' Created by SharpDevelop.
' User: Administrator
' Date: 4/12/2005
' Time: 9:39 PM
' 


Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports FreeCal.Common
Imports FreeCal.Procedures
Imports System.Threading
Imports FreeCal.Math
Imports FreeCal.Instruments.NetworkAnalyzers


	
	Public Class AboutFreeCalForm
		Inherits System.Windows.Forms.Form
		Private label1 As System.Windows.Forms.Label
		Private LnkScottPageLink As System.Windows.Forms.LinkLabel
		

		Public Sub New()
			MyBase.New
			'
			' The Me.InitializeComponent call is required for Windows Forms designer support.
			'
			Me.InitializeComponent
		End Sub

		#Region " Windows Forms Designer generated code "
		' This method is required for Windows Forms designer support.
		' Do not change the method contents inside the source code editor. The Forms designer might
		' not be able to load this method if it was changed manually.
		Private Sub InitializeComponent()
			Me.LnkScottPageLink = New System.Windows.Forms.LinkLabel
			Me.label1 = New System.Windows.Forms.Label
			Me.SuspendLayout
			'
			'LnkScottPageLink
			'
			Me.LnkScottPageLink.AutoSize = true
			Me.LnkScottPageLink.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
			Me.LnkScottPageLink.Location = New System.Drawing.Point(128, 184)
			Me.LnkScottPageLink.Name = "LnkScottPageLink"
			Me.LnkScottPageLink.Size = New System.Drawing.Size(65, 17)
			Me.LnkScottPageLink.TabIndex = 0
			Me.LnkScottPageLink.TabStop = true
			Me.LnkScottPageLink.Text = "Scott Page"
			AddHandler Me.LnkScottPageLink.Click, AddressOf Me.LnkScottPageLinkClicked
			'
			'label1
			'
			Me.label1.AutoSize = true
			Me.label1.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
			Me.label1.Location = New System.Drawing.Point(72, 184)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(47, 17)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Author:"
			'
			'AboutFreeCalForm
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(272, 272)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.LnkScottPageLink)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
			Me.MaximizeBox = false
			Me.MinimizeBox = false
			Me.Name = "AboutFreeCalForm"
			Me.ShowInTaskbar = false
			Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "About FreeCal"
			AddHandler Load, AddressOf Me.AboutFreeCalFormLoad
			Me.ResumeLayout(false)
		End Sub
		#End Region
		
		Private Sub BtnCloseClick(sender As System.Object, e As System.EventArgs)
            Me.Close
		End Sub
		
		Private Sub LnkScottPageLinkClicked(sender As System.Object, e As System.EventArgs)
            Dim IExplorer As New Diagnostics.Process
            IExplorer.Start("IExplore.exe", "http://hardway.us")
		End Sub

		Private Sub AboutFreeCalFormLoad(sender As System.Object, e As System.EventArgs)
'			Me.NWA.DisplayDataCollectionForm2
			Me.Close
		End Sub

'		Private Sub NWAClose Handles NWA.FormClose
'			Me.NWA.Dispose
'		End Sub

	End Class

