'
' Created by SharpDevelop.
' User: rspage
' Date: 3/31/2005
' Time: 10:49 AM
' 


Imports System
Imports System.Windows.Forms
Imports NationalInstruments.NI4882
Imports FreeCal.Instruments
Imports FreeCal.Common
Imports System.Collections
Imports FreeCal.Logging

    #Region "Structures"

    Public Structure InstrumentGPIBCommandTerminators
    	Public Amp As String
    	Public uAmp As String
    	Public mAmp As String
    	Public nAmp As String
        Public maHz As String
        Public Hz As String
        Public kHz As String
        Public MHz As String
        Public GHz As String
        Public dB As String
        Public dBm As String
        Public Watt As String
        Public uVolt As String
        Public mVolt As String
        Public Volt As String
        Public Percent As String
        Public Second As String
        Public MilliSecond As String
        Public MultipleCommandSeperator As String
        Public Ohm As String
    End Structure

	Public Structure GeneralGPIBCommands
		Public [Reset] As String
		Public Preset As String
		Public Identify As String
		Public GetModel As String
		Public GetManufacturer As String
		Public GetSerialNumber As String
		Public GetOptions As String
	End Structure

    #End Region

	Public Class Instrument
        Inherits NationalInstruments.NI4882.Device

        #Region "Declarations"

		Public Event DataSent(ByVal sender As Instrument, ByVal data As String)
		Public Event DataRead(ByVal sender As Instrument, ByVal data As String)

        Protected _AssetNumber As String = "Not Assigned"
		Protected Friend _Events As New InstrumentEventsSection(Me)
        Protected _SimulatedString As String = "No value yet"
        Protected _SimulatedByteArray() As Byte = {1, 2, 3, 4, 5, 6, 7, 8, 9, 0}
        Protected _FullIdentity As String = "Not Assigned"
        Protected _FullIdentityList As New ArrayList
        Protected _Model As String = "Not Assigned"
        Protected _Manufacturer As String = "Not Assigned"
        Protected _SerialNumber As String = "Not Assigned"
        Protected _OptionsList As New ArrayList
        Protected _CanIdentify As Boolean = True
        Protected _GeneralCommands As GeneralGPIBCommands
        Protected _CommandTerminators As InstrumentGPIBCommandTerminators
		Protected _MustReverseGPIBNumbers As Boolean = False
		Protected _MinimumWarmUpTime As Integer = 30
		Protected _MinimumWarmUpTimeSuffix As TimeEnum = TimeEnum.Minutes
		Protected _BoardAddress As Integer = 0
		Protected _Simulate As Boolean = False
		Protected _LastStringRead As String
		Protected _LastDoubleRead As Double
		Protected _LastIntegerRead As Integer
		Protected _LastByteRead As Byte
		Protected _LastBytesRead() As Byte
		Protected _LastCommand As String
		Protected _LastSingleRead As Single

        #End Region

        #Region "Propterties"

		Public ReadOnly Property LastCommand As String
			Get
				Return Me._LastCommand
			End Get
		End Property

		Public ReadOnly Property LastStringRead As String
			Get
				Return Me._LastStringRead
			End Get
		End Property

		Public ReadOnly Property LastSingleRead As Single
			Get
				Return Me._LastSingleRead
			End Get
		End Property

		Public ReadOnly Property LastDoubleRead As Double
			Get
				Return Me._LastDoubleRead
			End Get
		End Property

		Public ReadOnly Property Events As InstrumentEventsSection
			Get
				Return Me._Events
			End Get
		End Property

		Public Property AssetNumber As String
			Get
				Return Me._AssetNumber
			End Get
			Set
				Me._AssetNumber = Value
			End Set
		End Property

		Public Property Simulate As Boolean
			Get
				Return Me._Simulate
			End Get
			Set
				Me._Simulate = Value
			End Set
		End Property

		Public ReadOnly Property BoardAddress As Integer
			Get
				Return Me._BoardAddress
			End Get
		End Property

		Public ReadOnly Property MinimumWarmUpTime As Integer
			Get
				Return Me._MinimumWarmUpTime
			End Get
		End Property

		Public ReadOnly Property MinimumWarmUpTimeSuffix As TimeEnum
			Get
				Return Me._MinimumWarmUpTimeSuffix
			End Get
		End Property

        Public ReadOnly Property MustReverseGPIBNumbers As Boolean
            Get
                Return Me._MustReverseGPIBNumbers
            End Get
        End Property

		Public ReadOnly Property GeneralCommands As GeneralGPIBCommands
			Get
				Return Me._GeneralCommands
			End Get
		End Property

        Public ReadOnly Property CommandTerminators As InstrumentGPIBCommandTerminators
            Get
                Return Me._CommandTerminators
            End Get
        End Property

        Public ReadOnly Property CanIdentify As Boolean
            Get
                Return Me._CanIdentify
            End Get
        End Property

        Public ReadOnly Property Model As String
            Get
                Return Me._Model
            End Get
        End Property

        Public ReadOnly Property Manufacturer As String
            Get
                Return Me._Manufacturer
            End Get
        End Property

        Public Property SerialNumber As String
            Get
                Return Me._SerialNumber
            End Get
            Set
            	Me._SerialNumber = Value
            End Set
        End Property

        Public ReadOnly Property FullIdentity As String
            Get
                Return Me._FullIdentity
            End Get
        End Property

        Public ReadOnly Property FullIdentityList As ArrayList
            Get
                Return Me._FullIdentityList
            End Get
        End Property

        Public ReadOnly Property Options As ArrayList
            Get
                Return Me._OptionsList
            End Get
        End Property

		Public Shadows Property IOTimeout As TimeoutValue
			Get
				Dim IOT As TimeoutValue = MyBase.IOTimeout
            RaiseEvent DataRead(Me, IOT.ToString)
            Return IOT
			End Get
			Set
				RaiseEvent DataSent(Me, Value.ToString)
				MyBase.IOTimeout = Value
			End Set
		End Property

        #End Region

        #Region "Functions"

		Public Overrides Overloads Function ToString As String
			Return Me.Manufacturer & " " & Me.Model
		End Function

		Public Function ConvertFrequency(ByVal frequencySetting As Double, ByVal frequencySettingSuffix As FrequencyEnum, ByVal desiredFrequencySuffix As FrequencyEnum) As Double
        Return GlobalFunctions.ConvertFrequency(frequencySetting, frequencySettingSuffix, desiredFrequencySuffix)
    End Function

    Public Function ConvertAmplitude(ByVal amplitudeSetting As Double, ByVal amplitudeSettingSuffix As AmplitudeEnum, ByVal desiredAmplitudeSuffix As AmplitudeEnum) As Double
        Return GlobalFunctions.ConvertAmplitude(amplitudeSetting, amplitudeSettingSuffix, desiredAmplitudeSuffix)
    End Function

    Public Function GetReversedAmplitudeNumber(ByVal numberToProcess As Double) As String
			Dim NumberMinus13 As Integer = CInt(-(NumberToProcess - 13))
			If NumberMinus13 < 10 Then
				Return NumberMinus13.ToString & "00"
			End If
			Dim NumberAsString As String = NumberMinus13.ToString
        Dim NewString As String = String.Empty
        For CurrentPosition As Integer = NumberAsString.Length - 1 To 0 Step -1
				NewString = NewString & NumberAsString.Substring(CurrentPosition, 1)
			Next
			NumberMinus13 = CInt(NewString)
			If NumberMinus13 < 100 Then
				NewString = NumberMinus13.ToString & "0"
			End If
			Return NewString
		End Function

    Public Function GetReversedFrequencyNumber(ByVal valueToReverse As Double, ByVal frequencySuffixUsed As FrequencyEnum) As String
        Dim SingleToReverseAsString As String = valueToReverse.ToString
        SingleToReverseAsString = SingleToReverseAsString.Replace(".", "")
        Dim NewString As String = String.Empty
        For CurrentPosition As Integer = SingleToReverseAsString.Length - 1 To 0 Step -1
            NewString = NewString & SingleToReverseAsString.Substring(CurrentPosition, 1)
        Next
        Do Until Not NewString.EndsWith("0")
            NewString = NewString.Remove(NewString.Length - 1, 1)
        Loop
        Select Case frequencySuffixUsed
            Case FrequencyEnum.Hz
            Case FrequencyEnum.KHz
                If valueToReverse < 9 Then
                    Return NewString & "000000000"
                ElseIf (valueToReverse >= 10 And valueToReverse < 100) Then
                    Return NewString & "00000000"
                ElseIf (valueToReverse >= 100 And valueToReverse < 1000) Then
                    Return NewString & "0000000"
                ElseIf valueToReverse > 1000 Then
                    Return NewString
                End If
            Case FrequencyEnum.MHz
                If valueToReverse < 9 Then
                    Return NewString & "000"
                ElseIf (valueToReverse >= 10 And valueToReverse < 100) Then
                    Return NewString & "00"
                ElseIf (valueToReverse >= 100 And valueToReverse < 1000) Then
                    Return NewString & "0"
                ElseIf valueToReverse > 1000 Then
                    Return NewString
					End If
				Case FrequencyEnum.GHz
					Return NewString
			End Select
			Return NewString
		End Function

		Public Overridable Function Read() As String
			Return Me.ReadString
		End Function

		Public Overridable Function ReadSingle() As Single
			Me._LastSingleRead = CSng(Me.ReadString)
			Return Me._LastSingleRead
		End Function

		Public Overridable Function ReadDouble() As Double
			Me._LastDoubleRead = CDbl(Me.ReadString)
			Return Me._LastDoubleRead
		End Function

		Public Overridable Function ReadInteger() As Integer
			Return CInt(Me.ReadString.Replace(NewLine, "").Trim)
		End Function

		Public Overridable Function ReadInt16() As Int16
			Return System.Convert.ToInt16(Me.ReadString(2).Replace(NewLine, "").Trim)
		End Function

		Public Overridable Function ReadInt32() As Int32
			Return System.Convert.ToInt32(Me.ReadString(4).Replace(NewLine, "").Trim)
		End Function

		Public Overridable Function ReadInt64() As Int64
			Return System.Convert.ToInt64(Me.ReadString(8).Replace(NewLine, "").Trim)
		End Function

    Public Shadows Function ReadString() As String
        Dim Data As String = Nothing
        Try
            If Me._Simulate Then
                Data = Me._SimulatedString.Replace(NewLine, "").Trim
                RaiseEvent DataRead(Me, Data)
            Else
                Data = MyBase.ReadString.Replace(NewLine, "").Trim
                RaiseEvent DataRead(Me, Data)
            End If
            If Logger.LoggingEnabled Then
                Logger.Write("Read from: " & Me.Model & " - " & Data, LogMessageType.InstrumentRead)
            End If
            Me._LastStringRead = Data
        Catch Ex As Exception
            If Logger.LoggingEnabled Then
                Logger.Write(Me.Model & " - " & Ex.Message, LogMessageType.ApplicationEvent)
            End If
        End Try
        Return Data
    End Function

    Public Overridable Function ReadDouble(ByVal count As Integer) As Double
        Return Convert.ToDouble(Me.ReadString(count).Replace(NewLine, "").Trim)
    End Function

		Public Overridable Function ReadSingle(ByVal count As Integer) As Single
        Return Convert.ToSingle(Me.ReadString(count).Replace(NewLine, "").Trim)
    End Function

    Public Shadows Function ReadString(ByVal count As Integer) As String
        Dim Data As String = Nothing
        Try
            If Me._Simulate Then
                Data = Me._SimulatedString.Replace(NewLine, "").Trim
                RaiseEvent DataRead(Me, Data)
            Else
                Data = MyBase.ReadString(count)
                If Logger.LoggingEnabled Then
                    Logger.Write("Read from: " & Me.Model & " - " & Data, LogMessageType.InstrumentRead)
                End If
                RaiseEvent DataRead(Me, Data)
            End If
        Catch Ex As Exception
            If Logger.LoggingEnabled Then
                Logger.Write(Me.Model & " - " & Ex.Message, LogMessageType.ApplicationEvent)
            End If
        End Try
        Return Data
    End Function

    Public Shadows Function ReadByteArray As Byte()
        If Me._Simulate Then
            Return Me._SimulatedByteArray
        End If
        Return MyBase.ReadByteArray
    End Function

    Public Shadows Function ReadByteArray(ByVal count As Integer) As Byte()
        If Me._Simulate Then
            Dim NewByteArray() As Byte = Me._SimulatedByteArray
            ReDim Me._SimulatedByteArray(Count - 1)
            For CurrentByte As Integer = 0 To Count - 1
                Me._SimulatedByteArray(CurrentByte) = NewByteArray(CurrentByte)
            Next
            Return _SimulatedByteArray
        End If
        Return MyBase.ReadByteArray(count)
    End Function

    Public Overridable Function ProcessIdentity(ByVal identityToProcess As String, ByVal delimeters() As Char) As String
            Me._FullIdentity = IdentityToProcess
            Me._FullIdentityList.AddRange(Me._FullIdentity.Split(Delimeters))
            If Me._FullIdentityList.Count > 1 Then
            Me._Manufacturer = _FullIdentityList(1).ToString
        End If
            If Me._FullIdentityList.Count > 2 Then
            Me._Model = _FullIdentityList(2).ToString
        End If
        If Me._FullIdentityList.Count > 3 Then
            For Counter As Integer = 3 To Me._FullIdentityList.Count - 1
                Me._OptionsList.Add(Me._FullIdentityList(Counter))
            Next
        End If
        Return FullIdentity
    End Function

        Public Function HasOption(ByVal requestedOption As String) As Boolean
            For Each DeviceOption As String In Me._OptionsList
                If DeviceOption = RequestedOption Then
                    Return True
                Else
                    Return False
                End If
            Next DeviceOption
        End Function

        Public Overridable Function GetFrequencyTerminator(ByVal frequencySuffix As FrequencyEnum) As String
        Select Case FrequencySuffix
            Case FrequencyEnum.Hz
                Return Me._CommandTerminators.Hz
            Case FrequencyEnum.KHz
                Return Me._CommandTerminators.kHz
            Case FrequencyEnum.MHz
                Return Me._CommandTerminators.MHz
            Case FrequencyEnum.GHz
                Return Me._CommandTerminators.GHz
        End Select
        Return Nothing
    End Function

        Public Overridable Function GetAmplitudeTerminator(ByVal amplitudeSuffix As AmplitudeEnum) As String
        Select Case AmplitudeSuffix
            Case AmplitudeEnum.dBm
                Return Me._CommandTerminators.dBm
            Case AmplitudeEnum.I
                Return Me._CommandTerminators.Amp
            Case AmplitudeEnum.Ohm
                Return Me._CommandTerminators.Ohm
            Case AmplitudeEnum.V
                Return Me._CommandTerminators.Volt
        End Select
        Return Nothing
    End Function

        Public Overridable Function GetTimeTerminator(ByVal timeSuffix As TimeEnum) As String
        Select Case timeSuffix
            Case TimeEnum.Minutes
                Return Me._CommandTerminators.Second
            Case TimeEnum.Seconds
                Return Me._CommandTerminators.Second
            Case TimeEnum.MilliSeconds
                Return Me._CommandTerminators.MilliSecond
        End Select
        Return Nothing
    End Function

        #End Region

        #Region "Methods"

		Public Sub New(ByVal primaryAddress As Byte)
			MyBase.New(0, PrimaryAddress)
		    Me.InitializeSetups
		    Me._BoardAddress = 0
		End Sub

    Public Sub New(ByVal boardAddress As Integer, ByVal primaryAddress As Byte, ByVal secondaryAddress As Byte, Optional ByVal simulate As Boolean = False)
        MyBase.New(boardAddress, primaryAddress, secondaryAddress)
        Me._Simulate = simulate
        Me.InitializeSetups()
        Me._BoardAddress = boardAddress
    End Sub

    'TODO: Added 03-SEP-3017 - Other classes are passing getSettingsFromInstrument; need another constructor for secondaryAddress.
    Public Sub New(ByVal boardAddress As Integer, ByVal primaryAddress As Byte, ByVal getSettingsFromInstrument As Boolean, Optional ByVal simulate As Boolean = False)
        MyBase.New(boardAddress, primaryAddress)
        Me._Simulate = simulate
        Me.InitializeSetups()
        Me._BoardAddress = boardAddress
    End Sub

    Public Overridable Shadows Sub Write(ByVal data As String)
			Try
            _LastCommand = data
            If Logger.LoggingEnabled Then
					Logger.Write("Write to: " & Me.Model & " - " & data, LogMessageType.InstrumentWrite)
				End If
				RaiseEvent DataSent(me, data)
            If _Simulate Then
                Dim RndNumber As New Random
                _SimulatedString = RndNumber.Next(100).ToString
            Else
                MyBase.Write(data)
				End If
			Catch Ex As Exception
				If Logger.LoggingEnabled Then
					Logger.Write(Me.Model & " - " & Ex.Message, LogMessageType.ApplicationEvent)
				End If
			End Try
		End Sub

		Public Shadows Sub Write(ByVal data As Byte())
			If Me._Simulate Then
				Dim RndNumber As New Random
				ReDim Me._SimulatedByteArray(Data.GetUpperBound(0) - 1)
				For CurrentByte As Integer = 0 To Data.GetUpperBound(0) - 1
					Me._SimulatedByteArray(CurrentByte) = CByte(RndNumber.Next(Data(CurrentByte), 255))
				Next
			Else
				MyBase.Write(Data)
			End If
		End Sub

		Public Function NotifyOnMessageAvailable As InstrumentStatusFlags
			
		End Function

        Public Overridable Sub Preset
            Me.Write(Me.GeneralCommands.Preset)
            Me.SetupInstrument
        End Sub

        Protected Overridable Sub InitializeSetups
			Me._CommandTerminators.dBm = "DBM"
			Me._CommandTerminators.GHz = "GHZ"
			Me._CommandTerminators.Hz = "HZ"
			Me._CommandTerminators.kHz = "KHZ"
			Me._CommandTerminators.maHz = "MAHZ"
			Me._CommandTerminators.MHz = "MHZ"
			Me._CommandTerminators.MilliSecond = "MS"
			Me._CommandTerminators.MultipleCommandSeperator = ";"
			Me._CommandTerminators.mVolt = "MV"
			Me._CommandTerminators.Percent = "PCT"
			Me._CommandTerminators.Second = "S"
			Me._CommandTerminators.uVolt = "UV"
			Me._CommandTerminators.Volt = "V"
			Me._CommandTerminators.Watt = "W"
		    Me.SetupCommands
		    Me.SetupCommandTerminators
		    Me.SetupCapabilities
		    Me.SetupTestPoints
		    Me.SetupSpecifications
        End Sub

        Public Overridable Sub SetupInstrument
        End Sub

        Protected Overridable Sub SetupCommandTerminators
        End Sub

        Protected Overridable Sub GetSettings
        End Sub

		Protected Overridable Sub SetupTestPoints
		End Sub

		Protected Overridable Sub SetupSpecifications
		End Sub

		Protected Overridable Sub SetupCapabilities
			Me._CanIdentify = True
		End Sub

		Protected Overridable Sub SetupCommands
			Me._GeneralCommands.Identify = "*IDN?"
	        Me._GeneralCommands.Preset = "*RST"
		End Sub

        #End Region

	End Class

