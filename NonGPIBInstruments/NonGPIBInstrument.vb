'
' Created by SharpDevelop.
' User: rspage
' Date: 5/5/2005
' Time: 9:42 PM
' 
'
'
Imports System

Public Class NonGPIBInstrument

    Protected MyModel As String
    Protected MyManufacturer As String
    Protected MyNomenclature As String
    Protected MySerialNumber As String
    Protected MyAssetNumber As String
    Protected MyCategory As String
    Protected MyIsEEPROM As Boolean

    Public ReadOnly Property Model() As String
        Get
            Return MyModel
        End Get
    End Property

    Public ReadOnly Property Manufacturer() As String
        Get
            Return MyManufacturer
        End Get
    End Property

    Public ReadOnly Property Nomenclature() As String
        Get
            Return MyNomenclature
        End Get
    End Property

    Public Property SerialNumber() As String
        Get
            Return MySerialNumber
        End Get
        Set(ByVal Value As String)
            Me.MySerialNumber = Value
        End Set
    End Property

    Public Property AssetNumber() As String
        Get
            Return MyAssetNumber
        End Get
        Set(ByVal Value As String)
            Me.MyAssetNumber = Value
        End Set
    End Property


    Public ReadOnly Property Category() As String
        Get
            Return MyCategory
        End Get
    End Property

    Public ReadOnly Property IsEEPROM() As Boolean
        Get
            Return MyIsEEPROM
        End Get
    End Property

    Public Sub New()
    End Sub

End Class


