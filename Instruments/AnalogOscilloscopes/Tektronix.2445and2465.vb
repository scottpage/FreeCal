Imports System
Imports FreeCal.Common
Imports FreeCal.Instruments

Public Class Tektronix2445and2465GPIBCommands

    Public Const GetCH1COUPLING As String = "CH1? COUPLING"
    Public Const GetCH1POSITION As String = "CH1? POSITION"
    Public Const GetCH1PROBE As String = "CH1? PROBE"
    Public Const GetCH1VARIABLE As String = "CH1? VARIABLE"
    Public Const GetCH1VOLTS As String = "CH1? VOLTS"
    Public Const GetCH2COUPLING As String = "CH2? COUPLING"
    Public Const GetCH2INVERT As String = "CH2? INVERT"
    Public Const GetCH2POSITION As String = "CH2? POSITION"
    Public Const GetCH2PROBE As String = "CH2? PROBE"
    Public Const GetCH2VARIABLE As String = "CH2? VARIABLE"
    Public Const GetCH2VOLTS As String = "CH2? VOLTS"
    Public Const GetCH3POSITION As String = "CH3? POSITION"
    Public Const GetCH3PROBE As String = "CH3? PROBE"
    Public Const GetCH3VOLTS As String = "CH3? VOLTS"
    Public Const GetCH4POSITION As String = "CH4? POSITION"
    Public Const GetCH4PROBE As String = "CH4? PROBE"
    Public Const GetCH4VOLTS As String = "CH4? VOLTS"
    Public Const ATRIGGERBENDSAOFF As String = "ATRIGGER BENDSA:OFF"
    Public Const ATRIGGERBENDSAON As String = "ATRIGGER BENDSA:ON"
    Public Const ATRIGGERCOUPLINGAC As String = "ATRIGGER COUPLING:AC"
    Public Const ATRIGGERCOUPLINGDC As String = "ATRIGGER COUPLING:DC"
    Public Const ATRIGGERCOUPLINGHFREJ As String = "ATRIGGER COUPLING:HFREJ"
    Public Const ATRIGGERCOUPLINGLFREJ As String = "ATRIGGER COUPLING:LFREJ"
    Public Const ATRIGGERCOUPLINGNOISEREJ As String = "ATRIGGER COUPLING:NOISEREJ"
    Public Const ATRIGGERHOLDOFF As String = "ATRIGGER HOLDOFF:"
    Public Const ATRIGGERLEVEL As String = "ATRIGGER LEVEL:"
    Public Const ATRIGGERMODEAUTOBASELINE As String = "ATRIGGER MODE:AUTOBASELINE"
    Public Const ATRIGGERMODEAUTOLEVEL As String = "ATRIGGER MODE:AUTOLEVEL"
    Public Const ATRIGGERMODENORMAL As String = "ATRIGGER MODE:NORMAL"
    Public Const ATRIGGERMODESGLSEQ As String = "ATRIGGER MODE:SGLSEQ"
    Public Const ATRIGGERSLOPEMINUS As String = "ATRIGGER SLOPE:MINUS"
    Public Const ATRIGGERSLOPEPLUS As String = "ATRIGGER SLOPE:PLUS"
    Public Const ATRIGGERSOURCECH1 As String = "ATRIGGER SOURCE:CH1"
    Public Const ATRIGGERSOURCECH2 As String = "ATRIGGER SOURCE:CH2"
    Public Const ATRIGGERSOURCECH3 As String = "ATRIGGER SOURCE:CH3"
    Public Const ATRIGGERSOURCECH4 As String = "ATRIGGER SOURCE:CH4"
    Public Const ATRIGGERSOURCELINE As String = "ATRIGGER SOURCE:LINE"
    Public Const ATRIGGERSOURCEVERTICAL As String = "ATRIGGER SOURCE:VERTICAL"
    Public Const BTRIGGERCOUPLINGAC As String = "BTRIGGER COUPLING:AC"
    Public Const BTRIGGERCOUPLINGDC As String = "BTRIGGER COUPLING:DC"
    Public Const BTRIGGERCOUPLINGHFREJ As String = "BTRIGGER COUPLING:HFREJ"
    Public Const BTRIGGERCOUPLINGLFREJ As String = "BTRIGGER COUPLING:LFREJ"
    Public Const BTRIGGERCOUPLINGNOISEREJ As String = "BTRIGGER COUPLING:NOISEREJ"
    Public Const BTRIGGERLEVEL As String = "BTRIGGER LEVEL:"
    Public Const BTRIGGERMODERUN As String = "BTRIGGER MODE:RUN"
    Public Const BTRIGGERMODETRIGGERABLE As String = "BTRIGGER MODE:TRIGGERABLE"
    Public Const BTRIGGERSLOPEMINUS As String = "BTRIGGER SLOPE:MINUS"
    Public Const BTRIGGERSLOPEPLUS As String = "BTRIGGER SLOPE:PLUS"
    Public Const BTRIGGERSOURCECH1 As String = "BTRIGGER SOURCE:CH1"
    Public Const BTRIGGERSOURCECH2 As String = "BTRIGGER SOURCE:CH2"
    Public Const BTRIGGERSOURCECH3 As String = "BTRIGGER SOURCE:CH3"
    Public Const BTRIGGERSOURCECH4 As String = "BTRIGGER SOURCE:CH4"
    Public Const BTRIGGERSOURCEVERTICAL As String = "BTRIGGER SOURCE:VERTICAL"
    Public Const CH1COUPLINGAC As String = "CH1 COUPLING:AC"
    Public Const CH1POSITION As String = "CH1 POSITION:"
    Public Const CH1VARIABLE As String = "CH1 VARIABLE:"
    Public Const CH1VOLTS As String = "CH1 VOLTS:"
    Public Const CH2COUPLINGAC As String = "CH2 COUPLING:AC"
    Public Const CH2INVERTOFF As String = "CH2 INVERT:OFF"
    Public Const CH2INVERTON As String = "CH2 INVERT:ON"
    Public Const CH2POSITION As String = "CH2 POSITION:"
    Public Const CH2VARIABLE As String = "CH2 VARIABLE:"
    Public Const CH2VOLTS As String = "CH2 VOLTS:"
    Public Const CH3POSITION As String = "CH3 POSITION:"
    Public Const CH3VOLTS As String = "CH3 VOLTS:"
    Public Const CH4POSITION As String = "CH4 POSITION:"
    Public Const CH4VOLTS As String = "CH4 VOLTS:"
    Public Const DELAY As String = "DELAY"
    Public Const DELTAMODEPERTIME As String = "DELTA MODE:PERTIME"
    Public Const DELTATRACKINGOFF As String = "DELTA TRACKING:OFF"
    Public Const DELTATRACKINGON As String = "DELTA TRACKING:ON"
    Public Const DELTA As String = "DELTA:"
    Public Const DTIMEREFERENCE As String = "DTIME REFERENCE:"
    Public Const DVOLTSDELTA As String = "DVOLTS DELTA:"
    Public Const DVOLTSREFERENCE As String = "DVOLTS REFERENCE:"
    Public Const HMODEASWEEP As String = "HMODE ASWEEP:"
    Public Const HORIZONTALASECDIV As String = "HORIZONTAL ASECDIV:"
    Public Const HORIZONTALBSECDIV As String = "HORIZONTAL BSECDIV:"
    Public Const HORIZONTALMAGNIFYOFF As String = "HORIZONTAL MAGNIFY:OFF"
    Public Const HORIZONTALPOSITION As String = "HORIZONTAL POSITION:"
    Public Const HORIZONTALTRACESEP As String = "HORIZONTAL TRACESEP:"
    Public Const OPCOFF As String = "OPC OFF:"
    Public Const READOUTON As String = "READOUT ON:"
    Public Const RQSON As String = "RQS ON:"
    Public Const VMODEADDOFF As String = "VMODE ADD:OFF"
    Public Const VMODEBWLIMITOFF As String = "VMODE BWLIMIT:OFF"
    Public Const VMODECH1ON As String = "VMODE CH1:ON"
    Public Const VMODECH2OFF As String = "VMODE CH2:OFF"
    Public Const VMODECH3OFF As String = "VMODE CH3:OFF"
    Public Const VMODECH4OFF As String = "VMODE CH4:OFF"
    Public Const VMODECHOPOFF As String = "VMODE CHOP:OFF"
    Public Const VMODEINVERTOFF As String = "VMODE INVERT:OFF"
    Public Const WARNINGON As String = "WARNING ON:"
    Public Const Identity As String = "ID?"

End Class

Public Class Tektronix2445and2465
    Inherits Instrument

    Public Commands As Tektronix2445and2465GPIBCommands

    Public Sub New(ByVal boardID As Integer, ByVal primaryAddress As Byte, ByVal secondaryAddress As Byte)
        MyBase.New(boardID, primaryAddress, secondaryAddress)
        Me._Manufacturer = "Tektronix"
        Me._Model = "2445"
        Me.SetMyVariables()
    End Sub

    Private Sub SetMyVariables()
        Me._CanIdentify = True
    End Sub

    Public Function GetIdentity(ByVal storeResult As Boolean) As String
        Write(Tektronix2445and2465GPIBCommands.Identity)
        If storeResult Then
            Me._FullIdentity = Me.ReadString()
            Dim Delimeters As Char() = New Char() {" "c, ","c, "/"c}
            Me.ProcessIdentity(FullIdentity, Delimeters)
            Return Me.FullIdentity
        Else
            Return Me.ReadString()
        End If
    End Function

    Public Function GetGetCH1COUPLING() As String
        Me.Write(Tektronix2445and2465GPIBCommands.GetCH1COUPLING)
        Return Me.ReadString()
    End Function

    Public Function GetGetCH1POSITION() As String
        Me.Write(Tektronix2445and2465GPIBCommands.GetCH1POSITION)
        Return Me.ReadString()
    End Function

    Public Function GetGetCH1PROBE() As String
        Me.Write(Tektronix2445and2465GPIBCommands.GetCH1PROBE)
        Return Me.ReadString()
    End Function

    Public Function GetGetCH1VARIABLE() As String
        Me.Write(Tektronix2445and2465GPIBCommands.GetCH1VARIABLE)
        Return Me.ReadString()
    End Function

    Public Function GetGetCH1VOLTS() As String
        Me.Write(Tektronix2445and2465GPIBCommands.GetCH1VOLTS)
        Return Me.ReadString()
    End Function

    Public Function GetGetCH2COUPLING() As String
        Me.Write(Tektronix2445and2465GPIBCommands.GetCH2COUPLING)
        Return Me.ReadString()
    End Function

    Public Function GetGetCH2INVERT() As String
        Me.Write(Tektronix2445and2465GPIBCommands.GetCH2INVERT)
        Return Me.ReadString()
    End Function

    Public Function GetGetCH2POSITION() As String
        Me.Write(Tektronix2445and2465GPIBCommands.GetCH2POSITION)
        Return Me.ReadString()
    End Function

    Public Function GetGetCH2PROBE() As String
        Me.Write(Tektronix2445and2465GPIBCommands.GetCH2PROBE)
        Return Me.ReadString()
    End Function

    Public Function GetGetCH2VARIABLE() As String
        Me.Write(Tektronix2445and2465GPIBCommands.GetCH2VARIABLE)
        Return Me.ReadString()
    End Function

    Public Function GetGetCH2VOLTS() As String
        Me.Write(Tektronix2445and2465GPIBCommands.GetCH2VOLTS)
        Return Me.ReadString()
    End Function

    Public Function GetGetCH3POSITION() As String
        Me.Write(Tektronix2445and2465GPIBCommands.GetCH3POSITION)
        Return Me.ReadString()
    End Function

    Public Function GetGetCH3PROBE() As String
        Me.Write(Tektronix2445and2465GPIBCommands.GetCH3PROBE)
        Return Me.ReadString()
    End Function

    Public Function GetGetCH3VOLTS() As String
        Me.Write(Tektronix2445and2465GPIBCommands.GetCH3VOLTS)
        Return Me.ReadString()
    End Function

    Public Function GetGetCH4POSITION() As String
        Me.Write(Tektronix2445and2465GPIBCommands.GetCH4POSITION)
        Return Me.ReadString()
    End Function

    Public Function GetGetCH4PROBE() As String
        Me.Write(Tektronix2445and2465GPIBCommands.GetCH4PROBE)
        Return Me.ReadString()
    End Function

    Public Function GetGetCH4VOLTS() As String
        Me.Write(Tektronix2445and2465GPIBCommands.GetCH4VOLTS)
        Return Me.ReadString()
    End Function

    Public Sub SetATRIGGERBENDSAOFF(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.ATRIGGERBENDSAOFF & " " & value)
    End Sub

    Public Sub SetATRIGGERBENDSAON(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.ATRIGGERBENDSAON & " " & value)
    End Sub

    Public Sub SetATRIGGERCOUPLINGAC(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.ATRIGGERCOUPLINGAC & " " & value)
    End Sub

    Public Sub SetATRIGGERCOUPLINGDC(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.ATRIGGERCOUPLINGDC & " " & value)
    End Sub

    Public Sub SetATRIGGERCOUPLINGHFREJ(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.ATRIGGERCOUPLINGHFREJ & " " & value)
    End Sub

    Public Sub SetATRIGGERCOUPLINGLFREJ(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.ATRIGGERCOUPLINGLFREJ & " " & value)
    End Sub

    Public Sub SetATRIGGERCOUPLINGNOISEREJ(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.ATRIGGERCOUPLINGNOISEREJ & " " & value)
    End Sub

    Public Sub SetATRIGGERHOLDOFF(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.ATRIGGERHOLDOFF & " " & value)
    End Sub

    Public Sub SetATRIGGERLEVEL(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.ATRIGGERLEVEL & " " & value)
    End Sub

    Public Sub SetATRIGGERMODEAUTOBASELINE(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.ATRIGGERMODEAUTOBASELINE & " " & value)
    End Sub

    Public Sub SetATRIGGERMODEAUTOLEVEL(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.ATRIGGERMODEAUTOLEVEL & " " & value)
    End Sub

    Public Sub SetATRIGGERMODENORMAL(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.ATRIGGERMODENORMAL & " " & value)
    End Sub

    Public Sub SetATRIGGERMODESGLSEQ(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.ATRIGGERMODESGLSEQ & " " & value)
    End Sub

    Public Sub SetATRIGGERSLOPEMINUS(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.ATRIGGERSLOPEMINUS & " " & value)
    End Sub

    Public Sub SetATRIGGERSLOPEPLUS(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.ATRIGGERSLOPEPLUS & " " & value)
    End Sub

    Public Sub SetATRIGGERSOURCECH1(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.ATRIGGERSOURCECH1 & " " & value)
    End Sub

    Public Sub SetATRIGGERSOURCECH2(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.ATRIGGERSOURCECH2 & " " & value)
    End Sub

    Public Sub SetATRIGGERSOURCECH3(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.ATRIGGERSOURCECH3 & " " & value)
    End Sub

    Public Sub SetATRIGGERSOURCECH4(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.ATRIGGERSOURCECH4 & " " & value)
    End Sub

    Public Sub SetATRIGGERSOURCELINE(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.ATRIGGERSOURCELINE & " " & value)
    End Sub

    Public Sub SetATRIGGERSOURCEVERTICAL(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.ATRIGGERSOURCEVERTICAL & " " & value)
    End Sub

    Public Sub SetBTRIGGERCOUPLINGAC(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.BTRIGGERCOUPLINGAC & " " & value)
    End Sub

    Public Sub SetBTRIGGERCOUPLINGDC(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.BTRIGGERCOUPLINGDC & " " & value)
    End Sub

    Public Sub SetBTRIGGERCOUPLINGHFREJ(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.BTRIGGERCOUPLINGHFREJ & " " & value)
    End Sub

    Public Sub SetBTRIGGERCOUPLINGLFREJ(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.BTRIGGERCOUPLINGLFREJ & " " & value)
    End Sub

    Public Sub SetBTRIGGERCOUPLINGNOISEREJ(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.BTRIGGERCOUPLINGNOISEREJ & " " & value)
    End Sub

    Public Sub SetBTRIGGERLEVEL(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.BTRIGGERLEVEL & " " & value)
    End Sub

    Public Sub SetBTRIGGERMODERUN(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.BTRIGGERMODERUN & " " & value)
    End Sub

    Public Sub SetBTRIGGERMODETRIGGERABLE(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.BTRIGGERMODETRIGGERABLE & " " & value)
    End Sub

    Public Sub SetBTRIGGERSLOPEMINUS(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.BTRIGGERSLOPEMINUS & " " & value)
    End Sub

    Public Sub SetBTRIGGERSLOPEPLUS(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.BTRIGGERSLOPEPLUS & " " & value)
    End Sub

    Public Sub SetBTRIGGERSOURCECH1(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.BTRIGGERSOURCECH1 & " " & value)
    End Sub

    Public Sub SetBTRIGGERSOURCECH2(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.BTRIGGERSOURCECH2 & " " & value)
    End Sub

    Public Sub SetBTRIGGERSOURCECH3(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.BTRIGGERSOURCECH3 & " " & value)
    End Sub

    Public Sub SetBTRIGGERSOURCECH4(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.BTRIGGERSOURCECH4 & " " & value)
    End Sub

    Public Sub SetBTRIGGERSOURCEVERTICAL(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.BTRIGGERSOURCEVERTICAL & " " & value)
    End Sub

    Public Sub SetCH1COUPLINGAC(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.CH1COUPLINGAC & " " & value)
    End Sub

    Public Sub SetCH1POSITION(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.CH1POSITION & " " & value)
    End Sub

    Public Sub SetCH1VARIABLE(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.CH1VARIABLE & " " & value)
    End Sub

    Public Sub SetCH1VOLTS(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.CH1VOLTS & " " & value)
    End Sub

    Public Sub SetCH2COUPLINGAC(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.CH2COUPLINGAC & " " & value)
    End Sub

    Public Sub SetCH2INVERTOFF(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.CH2INVERTOFF & " " & value)
    End Sub

    Public Sub SetCH2INVERTON(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.CH2INVERTON & " " & value)
    End Sub

    Public Sub SetCH2POSITION(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.CH2POSITION & " " & value)
    End Sub

    Public Sub SetCH2VARIABLE(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.CH2VARIABLE & " " & value)
    End Sub

    Public Sub SetCH2VOLTS(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.CH2VOLTS & " " & value)
    End Sub

    Public Sub SetCH3POSITION(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.CH3POSITION & " " & value)
    End Sub

    Public Sub SetCH3VOLTS(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.CH3VOLTS & " " & value)
    End Sub

    Public Sub SetCH4POSITION(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.CH4POSITION & " " & value)
    End Sub

    Public Sub SetCH4VOLTS(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.CH4VOLTS & " " & value)
    End Sub

    Public Sub SetDELAY(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.DELAY & " " & value)
    End Sub

    Public Sub SetDELTAMODEPERTIME(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.DELTAMODEPERTIME & " " & value)
    End Sub

    Public Sub SetDELTATRACKINGOFF(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.DELTATRACKINGOFF & " " & value)
    End Sub

    Public Sub SetDELTATRACKINGON(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.DELTATRACKINGON & " " & value)
    End Sub

    Public Sub SetDELTA(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.DELTA & " " & value)
    End Sub

    Public Sub SetDTIMEREFERENCE(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.DTIMEREFERENCE & " " & value)
    End Sub

    Public Sub SetDVOLTSDELTA(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.DVOLTSDELTA & " " & value)
    End Sub

    Public Sub SetDVOLTSREFERENCE(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.DVOLTSREFERENCE & " " & value)
    End Sub

    Public Sub SetHMODEASWEEP(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.HMODEASWEEP & " " & value)
    End Sub

    Public Sub SetHORIZONTALASECDIV(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.HORIZONTALASECDIV & " " & value)
    End Sub

    Public Sub SetHORIZONTALBSECDIV(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.HORIZONTALBSECDIV & " " & value)
    End Sub

    Public Sub SetHORIZONTALMAGNIFYOFF(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.HORIZONTALMAGNIFYOFF & " " & value)
    End Sub

    Public Sub SetHORIZONTALPOSITION(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.HORIZONTALPOSITION & " " & value)
    End Sub

    Public Sub SetHORIZONTALTRACESEP(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.HORIZONTALTRACESEP & " " & value)
    End Sub

    Public Sub SetOPCOFF(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.OPCOFF & " " & value)
    End Sub

    Public Sub SetREADOUTON(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.READOUTON & " " & value)
    End Sub

    Public Sub SetRQSON(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.RQSON & " " & value)
    End Sub

    Public Sub SetVMODEADDOFF(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.VMODEADDOFF & " " & value)
    End Sub

    Public Sub SetVMODEBWLIMITOFF(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.VMODEBWLIMITOFF & " " & value)
    End Sub

    Public Sub SetVMODECH1ON(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.VMODECH1ON & " " & value)
    End Sub

    Public Sub SetVMODECH2OFF(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.VMODECH2OFF & " " & value)
    End Sub

    Public Sub SetVMODECH3OFF(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.VMODECH3OFF & " " & value)
    End Sub

    Public Sub SetVMODECH4OFF(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.VMODECH4OFF & " " & value)
    End Sub

    Public Sub SetVMODECHOPOFF(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.VMODECHOPOFF & " " & value)
    End Sub

    Public Sub SetVMODEINVERTOFF(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.VMODEINVERTOFF & " " & value)
    End Sub

    Public Sub SetWARNINGON(ByVal value As String)
        Me.Write(Tektronix2445and2465GPIBCommands.WARNINGON & " " & value)
    End Sub

End Class
