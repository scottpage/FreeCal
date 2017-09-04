'
' Created by SharpDevelop.
' User: rspage
' Date: 5/6/2005
' Time: 9:37 PM
' 
'
'

Imports System
Imports System.IO
Imports System.Collections
Imports Microsoft.VisualBasic.ControlChars

	Public Class HTBasicConverter

		Private MyFileStream As FileStream
		Private MyStreamReader As StreamReader
		Private HTBasicFileToConvert As String
		Public FileToConvertLines As New ArrayList
		Public NewConvertedFile As New ArrayList

		Public Sub New(ByVal fileToConvert As String)
			Me.HTBasicFileToConvert = FileToConvert
			Me.MyFileStream = New FileStream(FileToConvert, FileMode.Open)
			Me.MyStreamReader = New StreamReader(Me.MyFileStream)
			Dim FileContents As String = Me.MyStreamReader.ReadToEnd()
			Me.FileToConvertLines.AddRange(FileContents.Split(NewLine))
		End Sub

		Public Sub Convert()
			For Each Line As String In Me.FileToConvertLines
				If Line.StartsWith("ASSIGN") Then
					Me.NewConvertedFile.Add(Line)
				End If
			Next
		End Sub

	End Class

