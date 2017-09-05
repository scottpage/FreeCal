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
Imports Microsoft.VisualBasic

Public Class HTBasicConverter

    Private MyFileStream As FileStream
    Private MyStreamReader As StreamReader
    Private HTBasicFileToConvert As String
    Public FileToConvertLines As New ArrayList
    Public NewConvertedFile As New ArrayList

    Public Sub New(ByVal fileToConvert As String)
        Me.HTBasicFileToConvert = fileToConvert
        Me.MyFileStream = New FileStream(fileToConvert, FileMode.Open)
        Me.MyStreamReader = New StreamReader(Me.MyFileStream)
        Dim FileContents As String = Me.MyStreamReader.ReadToEnd()
        Me.FileToConvertLines.AddRange(FileContents.Replace(ControlChars.Cr, "").Split(ControlChars.Lf))
    End Sub

    Public Sub Convert()
        For Each Line As String In Me.FileToConvertLines
            If Line.StartsWith("ASSIGN") Then
                Me.NewConvertedFile.Add(Line)
            End If
        Next
    End Sub

End Class

