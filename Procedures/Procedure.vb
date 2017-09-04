Imports System
Imports System.Xml
Imports System.IO
Imports FreeCal.Common
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.ControlChars
Imports System.Collections
Imports System.Data
Imports FreeCal.Data
Imports FreeCal.DialogBoxes
Imports NationalInstruments.NI4882



    Public Class Procedure
		Protected _GPIB0 As Board
        Protected _GPIB1 As Board
        Protected _GPIB2 As Board
        Protected _GPIB3 As Board
        Protected _TestSetupImageDialog As New ImageDialog
        Protected _TestSetupTextDialog As New TextDialog
        Protected _CurrentTest As String = "No test currently in progress."
        Protected _CurrentInstrument As String = "No device currently in use."
        Public DUTBusNumber As Integer = 0
        Public StandardsBusNumber As Integer = 0
        Public DUTAssetNumber As String
        Public DUTAddress As Byte
        Public dgResults As DataGrid
        Protected _Simulate As Boolean

		Public Property Simulate As Boolean
			Get
				Return Me._Simulate
			End Get
			Set
				Me._Simulate = Value
			End Set
		End Property

        Public ReadOnly Property CurrentTest As String
            Get
                Return Me._CurrentTest
            End Get
        End Property

        Public ReadOnly Property CurrentInstrument As String
            Get
                Return Me._CurrentInstrument
            End Get
        End Property

        Public Sub New(ByVal dUTAssetNumber As String)
            Me.DUTAssetNumber = DUTAssetNumber
        End Sub

    End Class

