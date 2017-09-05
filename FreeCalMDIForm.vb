'
' Created by SharpDevelop.
' User: Administrator
' Date: 4/5/2005
' Time: 10:24 PM
' 

Imports System.Windows.Forms

Public Class FreeCalMDIForm
    Inherits System.Windows.Forms.Form

    Private WithEvents ClockTimer As System.Timers.Timer
    Private components As System.ComponentModel.IContainer
    Private WithEvents menuItem14 As System.Windows.Forms.MenuItem
    Private WithEvents menuItem21 As System.Windows.Forms.MenuItem
    Private WithEvents menuItem20 As System.Windows.Forms.MenuItem
    Private WithEvents miArrange As System.Windows.Forms.MenuItem
    Private WithEvents miExit As System.Windows.Forms.MenuItem
    Private WithEvents menuItem12 As System.Windows.Forms.MenuItem
    Private WithEvents menuItem13 As System.Windows.Forms.MenuItem
    Private WithEvents menuItem10 As System.Windows.Forms.MenuItem
    Private WithEvents menuItem11 As System.Windows.Forms.MenuItem
    Private WithEvents menuItem16 As System.Windows.Forms.MenuItem
    Private WithEvents menuItem1 As System.Windows.Forms.MenuItem
    Private WithEvents menuItem15 As System.Windows.Forms.MenuItem
    Private WithEvents menuItem18 As System.Windows.Forms.MenuItem
    Private WithEvents miLongTermOscillatorStability As System.Windows.Forms.MenuItem
    Private WithEvents mmFreeCal As System.Windows.Forms.MainMenu
    Private WithEvents menuItem23 As System.Windows.Forms.MenuItem
    Private WithEvents statusBar1 As System.Windows.Forms.StatusBar
    Private WithEvents menuItem25 As System.Windows.Forms.MenuItem
    Private WithEvents menuItem24 As System.Windows.Forms.MenuItem
    Private WithEvents menuItem27 As System.Windows.Forms.MenuItem
    Private WithEvents menuItem26 As System.Windows.Forms.MenuItem
    Private WithEvents menuItem29 As System.Windows.Forms.MenuItem
    Private WithEvents menuItem28 As System.Windows.Forms.MenuItem
    Private WithEvents miCascade As System.Windows.Forms.MenuItem
    Private WithEvents miPowerSensor As System.Windows.Forms.MenuItem
    Private WithEvents menuItem30 As System.Windows.Forms.MenuItem
    Private WithEvents menuItem31 As System.Windows.Forms.MenuItem
    Private WithEvents miTileVertically As System.Windows.Forms.MenuItem
    Private WithEvents SelectedMenuComment As System.Windows.Forms.StatusBarPanel
    Private WithEvents miInstrumentControl As System.Windows.Forms.MenuItem
    Private WithEvents CurrentDateTime As System.Windows.Forms.StatusBarPanel
    Private WithEvents miLogViewer As System.Windows.Forms.MenuItem
    Private WithEvents miTileHorizontally As System.Windows.Forms.MenuItem
    Private WithEvents miConversion As System.Windows.Forms.MenuItem
    Private WithEvents menuItem3 As System.Windows.Forms.MenuItem
    Private WithEvents menuItem2 As System.Windows.Forms.MenuItem
    Private WithEvents miInstruments As System.Windows.Forms.MenuItem
    Private WithEvents menuItem7 As System.Windows.Forms.MenuItem
    Private WithEvents menuItem6 As System.Windows.Forms.MenuItem
    Private WithEvents menuItem5 As System.Windows.Forms.MenuItem
    Private WithEvents menuItem4 As System.Windows.Forms.MenuItem
    Private WithEvents menuItem9 As System.Windows.Forms.MenuItem
    Private WithEvents menuItem8 As System.Windows.Forms.MenuItem
    Private WithEvents menuItem22 As System.Windows.Forms.MenuItem
    Private WithEvents menuItem19 As System.Windows.Forms.MenuItem

    Public Sub New()
        MyBase.New()
        '
        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        '
        Me.InitializeComponent()
        Me.ClockTimer = New System.Timers.Timer
        Me.ClockTimer.Interval = 1000
        Me.ClockTimer.Start()
        AddHandler Me.ClockTimer.Elapsed, AddressOf Me.ClockTimerElapsed

        'TODO: Implement CreateFreeCalDirectories()

        FreeCal.Logging.Logger.CreateLog()
        FreeCal.Logging.Logger.LoggingEnabled = True

        Me.statusBar1.Panels(1).Text = DateTime.Now.ToString
        Me.statusBar1.Panels(1).Width = Me.Width - Me.statusBar1.Panels(0).Width
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region " Windows Forms Designer generated code "
    ' This method is required for Windows Forms designer support.
    ' Do not change the method contents inside the source code editor. The Forms designer might
    ' not be able to load this method if it was changed manually.
    Friend WithEvents MenuItem17 As System.Windows.Forms.MenuItem
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FreeCalMDIForm))
        Me.menuItem19 = New System.Windows.Forms.MenuItem()
        Me.menuItem22 = New System.Windows.Forms.MenuItem()
        Me.menuItem8 = New System.Windows.Forms.MenuItem()
        Me.menuItem9 = New System.Windows.Forms.MenuItem()
        Me.menuItem4 = New System.Windows.Forms.MenuItem()
        Me.menuItem5 = New System.Windows.Forms.MenuItem()
        Me.menuItem6 = New System.Windows.Forms.MenuItem()
        Me.menuItem7 = New System.Windows.Forms.MenuItem()
        Me.miInstruments = New System.Windows.Forms.MenuItem()
        Me.miInstrumentControl = New System.Windows.Forms.MenuItem()
        Me.menuItem2 = New System.Windows.Forms.MenuItem()
        Me.menuItem3 = New System.Windows.Forms.MenuItem()
        Me.miConversion = New System.Windows.Forms.MenuItem()
        Me.miTileHorizontally = New System.Windows.Forms.MenuItem()
        Me.miLogViewer = New System.Windows.Forms.MenuItem()
        Me.CurrentDateTime = New System.Windows.Forms.StatusBarPanel()
        Me.SelectedMenuComment = New System.Windows.Forms.StatusBarPanel()
        Me.miTileVertically = New System.Windows.Forms.MenuItem()
        Me.menuItem31 = New System.Windows.Forms.MenuItem()
        Me.menuItem30 = New System.Windows.Forms.MenuItem()
        Me.miPowerSensor = New System.Windows.Forms.MenuItem()
        Me.miCascade = New System.Windows.Forms.MenuItem()
        Me.menuItem28 = New System.Windows.Forms.MenuItem()
        Me.menuItem29 = New System.Windows.Forms.MenuItem()
        Me.miLongTermOscillatorStability = New System.Windows.Forms.MenuItem()
        Me.menuItem26 = New System.Windows.Forms.MenuItem()
        Me.menuItem27 = New System.Windows.Forms.MenuItem()
        Me.menuItem24 = New System.Windows.Forms.MenuItem()
        Me.menuItem25 = New System.Windows.Forms.MenuItem()
        Me.statusBar1 = New System.Windows.Forms.StatusBar()
        Me.menuItem23 = New System.Windows.Forms.MenuItem()
        Me.mmFreeCal = New System.Windows.Forms.MainMenu(Me.components)
        Me.menuItem1 = New System.Windows.Forms.MenuItem()
        Me.MenuItem17 = New System.Windows.Forms.MenuItem()
        Me.miExit = New System.Windows.Forms.MenuItem()
        Me.menuItem10 = New System.Windows.Forms.MenuItem()
        Me.menuItem11 = New System.Windows.Forms.MenuItem()
        Me.menuItem13 = New System.Windows.Forms.MenuItem()
        Me.menuItem12 = New System.Windows.Forms.MenuItem()
        Me.menuItem15 = New System.Windows.Forms.MenuItem()
        Me.menuItem20 = New System.Windows.Forms.MenuItem()
        Me.menuItem21 = New System.Windows.Forms.MenuItem()
        Me.menuItem14 = New System.Windows.Forms.MenuItem()
        Me.menuItem16 = New System.Windows.Forms.MenuItem()
        Me.menuItem18 = New System.Windows.Forms.MenuItem()
        Me.miArrange = New System.Windows.Forms.MenuItem()
        CType(Me.CurrentDateTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SelectedMenuComment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'menuItem19
        '
        Me.menuItem19.Index = 5
        Me.menuItem19.Text = "Help"
        '
        'menuItem22
        '
        Me.menuItem22.Index = 7
        Me.menuItem22.Text = "Counter"
        '
        'menuItem8
        '
        Me.menuItem8.Index = 2
        Me.menuItem8.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItem9})
        Me.menuItem8.Text = "Power Meters"
        '
        'menuItem9
        '
        Me.menuItem9.Index = 0
        Me.menuItem9.Text = "Modify Power Sensor EPROM"
        '
        'menuItem4
        '
        Me.menuItem4.Index = 5
        Me.menuItem4.Text = "Measuring Receivers"
        '
        'menuItem5
        '
        Me.menuItem5.Index = 1
        Me.menuItem5.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItem6, Me.menuItem7})
        Me.menuItem5.Text = "Network Analyzers"
        '
        'menuItem6
        '
        Me.menuItem6.Index = 0
        Me.menuItem6.Text = "Calibrate"
        '
        'menuItem7
        '
        Me.menuItem7.Index = 1
        Me.menuItem7.Text = "DataCollection"
        '
        'miInstruments
        '
        Me.miInstruments.Index = 1
        Me.miInstruments.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miInstrumentControl, Me.menuItem5, Me.menuItem8, Me.menuItem2, Me.menuItem3, Me.menuItem4})
        Me.miInstruments.Text = "Instrument"
        '
        'miInstrumentControl
        '
        Me.miInstrumentControl.Index = 0
        Me.miInstrumentControl.Text = "Instrument Control"
        '
        'menuItem2
        '
        Me.menuItem2.Index = 3
        Me.menuItem2.Text = "Signal Generators"
        '
        'menuItem3
        '
        Me.menuItem3.Index = 4
        Me.menuItem3.Text = "Spectrum Analyzers"
        '
        'miConversion
        '
        Me.miConversion.Index = 2
        Me.miConversion.Text = "Conversion"
        '
        'miTileHorizontally
        '
        Me.miTileHorizontally.Index = 0
        Me.miTileHorizontally.Text = "Tile Horizontally"
        '
        'miLogViewer
        '
        Me.miLogViewer.Index = 0
        Me.miLogViewer.Text = "Log Viewer"
        '
        'CurrentDateTime
        '
        Me.CurrentDateTime.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.CurrentDateTime.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None
        Me.CurrentDateTime.MinWidth = 100
        Me.CurrentDateTime.Name = "CurrentDateTime"
        '
        'SelectedMenuComment
        '
        Me.SelectedMenuComment.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents
        Me.SelectedMenuComment.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None
        Me.SelectedMenuComment.Name = "SelectedMenuComment"
        Me.SelectedMenuComment.Width = 10
        '
        'miTileVertically
        '
        Me.miTileVertically.Index = 1
        Me.miTileVertically.Text = "Tile Vertically"
        '
        'menuItem31
        '
        Me.menuItem31.Index = 1
        Me.menuItem31.Text = "Short Term Stability"
        '
        'menuItem30
        '
        Me.menuItem30.Index = 3
        Me.menuItem30.Text = "Options"
        '
        'miPowerSensor
        '
        Me.miPowerSensor.Index = 1
        Me.miPowerSensor.Text = "Power Sensor"
        '
        'miCascade
        '
        Me.miCascade.Index = 2
        Me.miCascade.Text = "Cascade"
        '
        'menuItem28
        '
        Me.menuItem28.Index = 1
        Me.menuItem28.Text = "Verification Kit"
        '
        'menuItem29
        '
        Me.menuItem29.Index = 10
        Me.menuItem29.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miLongTermOscillatorStability, Me.menuItem31})
        Me.menuItem29.Text = "Oscillators"
        '
        'miLongTermOscillatorStability
        '
        Me.miLongTermOscillatorStability.Index = 0
        Me.miLongTermOscillatorStability.Text = "Long Term Stability"
        '
        'menuItem26
        '
        Me.menuItem26.Index = 1
        Me.menuItem26.Text = "Variable"
        '
        'menuItem27
        '
        Me.menuItem27.Index = 0
        Me.menuItem27.Text = "Calibration Kit"
        '
        'menuItem24
        '
        Me.menuItem24.Index = 9
        Me.menuItem24.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItem25, Me.menuItem26})
        Me.menuItem24.Text = "Attenuators"
        '
        'menuItem25
        '
        Me.menuItem25.Index = 0
        Me.menuItem25.Text = "Fixed"
        '
        'statusBar1
        '
        Me.statusBar1.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.statusBar1.Location = New System.Drawing.Point(0, 928)
        Me.statusBar1.Name = "statusBar1"
        Me.statusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.SelectedMenuComment, Me.CurrentDateTime})
        Me.statusBar1.ShowPanels = True
        Me.statusBar1.Size = New System.Drawing.Size(1897, 40)
        Me.statusBar1.SizingGrip = False
        Me.statusBar1.TabIndex = 0
        '
        'menuItem23
        '
        Me.menuItem23.Index = 8
        Me.menuItem23.Text = "Power Splitter"
        '
        'mmFreeCal
        '
        Me.mmFreeCal.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItem1, Me.miInstruments, Me.menuItem10, Me.menuItem14, Me.menuItem18, Me.menuItem19})
        '
        'menuItem1
        '
        Me.menuItem1.Index = 0
        Me.menuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem17, Me.miExit})
        Me.menuItem1.Text = "File"
        '
        'MenuItem17
        '
        Me.MenuItem17.Index = 0
        Me.MenuItem17.Text = "TestUIControls"
        '
        'miExit
        '
        Me.miExit.Index = 1
        Me.miExit.Text = "Exit"
        '
        'menuItem10
        '
        Me.menuItem10.Index = 2
        Me.menuItem10.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItem11, Me.miPowerSensor, Me.menuItem13, Me.menuItem12, Me.menuItem15, Me.menuItem20, Me.menuItem21, Me.menuItem22, Me.menuItem23, Me.menuItem24, Me.menuItem29})
        Me.menuItem10.Text = "Procedures"
        '
        'menuItem11
        '
        Me.menuItem11.Index = 0
        Me.menuItem11.Text = "Signal Generator"
        '
        'menuItem13
        '
        Me.menuItem13.Index = 2
        Me.menuItem13.Text = "Digital Multimeter"
        '
        'menuItem12
        '
        Me.menuItem12.Index = 3
        Me.menuItem12.Text = "Power Meter"
        '
        'menuItem15
        '
        Me.menuItem15.Index = 4
        Me.menuItem15.Text = "Spectrum Analyzer"
        '
        'menuItem20
        '
        Me.menuItem20.Index = 5
        Me.menuItem20.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItem27, Me.menuItem28})
        Me.menuItem20.Text = "Network Analyzers"
        '
        'menuItem21
        '
        Me.menuItem21.Index = 6
        Me.menuItem21.Text = "Measuring Receiver"
        '
        'menuItem14
        '
        Me.menuItem14.Index = 3
        Me.menuItem14.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miLogViewer, Me.menuItem16, Me.miConversion, Me.menuItem30})
        Me.menuItem14.Text = "Tools"
        '
        'menuItem16
        '
        Me.menuItem16.Index = 1
        Me.menuItem16.Text = "Visual Editor"
        '
        'menuItem18
        '
        Me.menuItem18.Index = 4
        Me.menuItem18.MdiList = True
        Me.menuItem18.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miTileHorizontally, Me.miTileVertically, Me.miCascade, Me.miArrange})
        Me.menuItem18.Text = "Windows"
        '
        'miArrange
        '
        Me.miArrange.Index = 3
        Me.miArrange.Text = "Arrange"
        '
        'FreeCalMDIForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(10, 24)
        Me.ClientSize = New System.Drawing.Size(1897, 968)
        Me.Controls.Add(Me.statusBar1)
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Menu = Me.mmFreeCal
        Me.Name = "FreeCalMDIForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FreeCal"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.CurrentDateTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SelectedMenuComment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region

    Private Sub ClockTimerElapsed(ByVal sender As Object, ByVal E As System.Timers.ElapsedEventArgs)
        If InvokeRequired Then
            Dim Invoker As New Timers.ElapsedEventHandler(AddressOf ClockTimerElapsed)
            Invoke(Invoker, sender, E)
        Else
            statusBar1.Panels(1).Text = DateTime.Now.ToString
        End If
    End Sub

    Protected Overloads Overrides Sub OnResize(ByVal e As EventArgs)
        Me.statusBar1.Panels(1).Width = Me.Width - Me.statusBar1.Panels(0).Width
        MyBase.OnResize(e)
    End Sub

    Private Sub FreeCalMDIFormLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FreeCalMDIFormClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        FreeCal.Logging.Logger.CloseLog()
        Application.Exit()
    End Sub

    Private Sub MiLogViewerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miLogViewer.Click
        Dim LogViewer As New RunTimeLogViewerForm
        LogViewer.MdiParent = Me
        LogViewer.Show()
    End Sub

    Private Sub MiPowerSensorClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miPowerSensor.Click
        Dim PSProc As New PowerSensorProcedureForm
        PSProc.MdiParent = Me
        PSProc.Show()
    End Sub

    Private Sub MiExitClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miExit.Click
        Application.Exit()
    End Sub

    Private Sub MiInstrumentControlClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miInstrumentControl.Click
        Dim ICForm As New InstrumentControlForm
        ICForm.MdiParent = Me
        ICForm.Show()
    End Sub

    Private Sub MiInstrumentControlSelect(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miInstrumentControl.Select
        Me.statusBar1.Panels(0).Text = "Allows direct communcation with instruments on the bus."
    End Sub

    Private Sub miInstrumentsSelect(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miInstruments.Select
        Me.statusBar1.Panels(0).Text = ""
    End Sub

    Private Sub MiArrangeSelect(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miArrange.Select
    End Sub

    Private Sub MiCascadeClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miCascade.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub MiTileVerticallyClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miTileVertically.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub MiTileHorizontallyClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miTileHorizontally.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub MiArrangeClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miArrange.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub MiLongTermOscillatorStabilityClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miLongTermOscillatorStability.Click
        Dim LTOS As New LongTermOscillatorStabilityProcedureForm
        LTOS.MdiParent = Me
        LTOS.Show()
    End Sub

    Private Sub MiConversionClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miConversion.Click
        Dim ConversionF As New ConversionForm
        ConversionF.MdiParent = Me
        ConversionF.Show()
    End Sub

    Private Sub MenuItem17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem17.Click
        'Dim TNIControls As New TestNIControls
        'TNIControls.MdiParent = Me
        'TNIControls.Show()
    End Sub

End Class


