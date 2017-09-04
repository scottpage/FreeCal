'
' Created by SharpDevelop.
' User: rspage
' Date: 7/21/2005
' Time: 9:17 AM
' 


Imports System.IO


Public Class Logger

    Public Shared Event EventLogged(ByVal message As String)
    Public Shared Event InstrumentDataSent(ByVal message As String)
    Public Shared Event InstrumentDataRead(ByVal message As String)
    Public Shared LoggingEnabled As Boolean
    Public Shared FileLoggingEnabled As Boolean = False
    Public Shared RunTimeLoggingEnabled As Boolean = False
    Public Shared LogFileStream As FileStream = Nothing
    Public Shared LogFileName As String = LogDirectory & "FreeCal Log " & DateTime.Now.Year & DateTime.Now.Month & DateTime.Now.Day & DateTime.Now.Hour & DateTime.Now.Minute & DateTime.Now.Second & DateTime.Now.Millisecond & ".log"
    Public Shared LogFileWriter As StreamWriter

    Public Shared Function CreateLog() As Boolean
        Try
            If (LogFileName Is Nothing) Then
                LogFileName = LogDirectory & "FreeCal Log - " & DateTime.Now.Year & DateTime.Now.Month & DateTime.Now.Day & DateTime.Now.Hour & DateTime.Now.Minute & DateTime.Now.Second & DateTime.Now.Millisecond & ".log"
            End If
            LogFileStream = File.Open(LogFileName, FileMode.OpenOrCreate)
            LogFileWriter = New StreamWriter(LogFileStream)
            Return True
        Catch
            LoggingEnabled = False
            Return False
        End Try
    End Function

    Public Shared Sub CloseLog()
        Try
            LogFileWriter.Close()
        Catch
        End Try
    End Sub

    Public Shared Sub Write(ByVal message As String, ByVal messageType As LogMessageType, Optional ByVal createNewLine As Boolean = True)
        Select Case messageType
            Case LogMessageType.InstrumentWrite
                RaiseEvent InstrumentDataSent(message)
            Case LogMessageType.InstrumentRead
                RaiseEvent InstrumentDataRead(message)
            Case LogMessageType.ApplicationEvent
                RaiseEvent EventLogged(message)
        End Select
        If FileLoggingEnabled Then
            If createNewLine Then
                LogFileWriter.WriteLine(NewLine & DateTime.Now.TimeOfDay.ToString & " - " & message)
            Else
                LogFileWriter.Write(DateTime.Now.TimeOfDay.ToString & " - " & message)
            End If
        End If
    End Sub

End Class

Public Enum LogMessageType
    InstrumentWrite
    InstrumentRead
    ApplicationEvent
End Enum


