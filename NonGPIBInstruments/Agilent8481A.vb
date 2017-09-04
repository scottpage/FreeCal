'
' Created by SharpDevelop.
' User: rspage
' Date: 5/5/2005
' Time: 10:10 PM
' 
'
'

Imports System

Public Class Agilent8481A
    Inherits FreeCal.NonGPIBInstruments.NonGPIBInstrument

    Public Specifications As Agilent8481ASpecifications

    Public Sub New()
        MyBase.New()
        Me.MyModel = "8481A"
        Me.MyManufacturer = "Agilent"
        Me.MyNomenclature = "Power Sensor"
        Me.MyIsEEPROM = False
    End Sub

End Class

Public Structure Agilent8481ASpecifications
    Private SpecificationsForAgilent8481A As String
    Public Const MaxdBPower As Double = 20
    Public Const MindBPower As Double = -70
    Public Const MaxFrequency As Double = 0.000000018
    Public Const MinFrequency As Double = 0.00001
    Public Const ConnectorType As String = "N"
    Public Const ImpedanceOhms As Integer = 50
End Structure


