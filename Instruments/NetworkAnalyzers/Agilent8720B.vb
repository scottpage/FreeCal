'
' Created by SharpDevelop.
' User: rspage
' Date: 5/6/2005
' Time: 4:28 PM
' 
'
'

Imports System
Imports FreeCal.Common
Imports FreeCal.Instruments
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections
Imports System.Windows.Forms
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
    Public Class Agilent8720B
        Inherits FreeCal.Instruments.NetworkAnalyzers.NetworkAnalyzer

		Public Sub New(ByVal boardAddress As Integer, ByVal primaryAddress As Byte, ByVal getSettingsFromInstrument As Boolean, Optional ByVal simulate As Boolean = False)
		    MyBase.New(BoardAddress, PrimaryAddress, GetSettingsFromInstrument, Simulate)
		    Me._Model = "8720B"
		    Me._Manufacturer = "Agilent Technologies"
        End Sub

		Protected Overrides Sub SetupCommands
            Me._GeneralCommands.Identify = "OUTPIDEN"
            Me._GeneralCommands.Preset = "PRES"
	        Me._Commands.BEEPOFF = "BEEPOFF"
	        Me._Commands.BEEPON = "BEEPON"
	        Me._Commands.CALIS111 = "CALIS111"
	        Me._Commands.CALIS221 = "CALIS221"
	        Me._Commands.CALSALL = "CALSALL"
	        Me._Commands.CALSPORT1 = "CALSPORT1"
	        Me._Commands.CALSPORT2 = "CALSPORT2"
	        Me._Commands.CLASS11A = "CLASS11A"
	        Me._Commands.CLASS11B = "CLASS11B"
	        Me._Commands.CLASS11C = "CLASS11C"
	        Me._Commands.CLASS22A = "CLASS22A"
	        Me._Commands.CLASS22B = "CLASS22B"
	        Me._Commands.CLASS22C = "CLASS22C"
	        Me._Commands.FORM1 = "FORM1"
	        Me._Commands.FORM2 = "FORM2"
	        Me._Commands.FORM3 = "FORM3"
	        Me._Commands.FORM4 = "FORM4"
	        Me._Commands.FORM5 = "FORM5"
	        Me._Commands.LINM = "LINM"
	        Me._Commands.LINP = "LINP"
	        Me._Commands.MAGS = "MAGS"
	        Me._Commands.MARKCONT = "MARKCONT"
	        Me._Commands.MARKDISC = "MARKDISC"
	        Me._Commands.MARKMAXI = "MARKMAXI"
	        Me._Commands.MARKMINI = "MARKMINI"
	        Me._Commands.MARKTARG = "MARKTARG"
	        Me._Commands.MEMOALL = "MEMOALL"
	        Me._Commands.MENUCAL = "MENUCAL"
	        Me._Commands.MENUCOPY = "MENUCOPY"
	        Me._Commands.MENUDISC = "MENUDISC"
	        Me._Commands.MENUDISP = "MENUDISP"
	        Me._Commands.MENUDOMA = "MENUDOMA"
	        Me._Commands.MENUFORM = "MENUFORM"
	        Me._Commands.MENUMARK = "MENUMARK"
	        Me._Commands.MENUOFF = "MENUOFF"
	        Me._Commands.MENUON = "MENUON"
	        Me._Commands.MENUPARA = "MENUPARA"
	        Me._Commands.MENUPRIO = "MENUPRIO"
	        Me._Commands.MENURECA = "MENURECA"
	        Me._Commands.MENURESP = "MENURESP"
	        Me._Commands.MENUSAVE = "MENUSAVE"
	        Me._Commands.MENUSTIM = "MENUSTIM"
	        Me._Commands.MENUSYST = "MENUSYST"
	        Me._Commands.MENUTAPE = "MENUTAPE"
	        Me._Commands.MENUTEST = "MENUTEST"
	        Me._Commands.OUTPACTI = "OUTPACTI"
	        Me._Commands.OUTPCALC01 = "OUTPCALC01"
	        Me._Commands.OUTPCALC02 = "OUTPCALC02"
	        Me._Commands.OUTPCALC03 = "OUTPCALC03"
	        Me._Commands.OUTPCALC04 = "OUTPCALC04"
	        Me._Commands.OUTPCALC05 = "OUTPCALC05"
	        Me._Commands.OUTPCALC06 = "OUTPCALC06"
	        Me._Commands.OUTPCALC07 = "OUTPCALC07"
	        Me._Commands.OUTPCALC08 = "OUTPCALC08"
	        Me._Commands.OUTPCALC09 = "OUTPCALC09"
	        Me._Commands.OUTPCALC10 = "OUTPCALC10"
	        Me._Commands.OUTPCALC11 = "OUTPCALC11"
	        Me._Commands.OUTPCALC12 = "OUTPCALC12"
	        Me._Commands.OUTPDATA = "OUTPDATA"
	        Me._Commands.OUTPDELA = "OUTPDELA"
	        Me._Commands.OUTPERRO = "OUTPERRO"
	        Me._Commands.OUTPFORM = "OUTPFORM"
	        Me._Commands.OUTPFREL = "OUTPFREL"
	        Me._Commands.OUTPICAL01 = "OUTPICAL01"
	        Me._Commands.OUTPIDEN = "OUTPIDEN"
	        Me._Commands.OUTPKEY = "OUTPKEY"
	        Me._Commands.OUTPLEAS = "OUTPLEAS"
	        Me._Commands.OUTPMARK = "OUTPMARK"
	        Me._Commands.OUTPMEMO = "OUTPMEMO"
	        Me._Commands.OUTPPLOT = "OUTPPLOT"
	        Me._Commands.OUTPPRINALL = "OUTPPRINALL"
	        Me._Commands.OUTPRAW1 = "OUTPRAW1"
	        Me._Commands.OUTPRAW2 = "OUTPRAW2"
	        Me._Commands.OUTPRAW3 = "OUTPRAW3"
	        Me._Commands.OUTPRAW4 = "OUTPRAW4"
	        Me._Commands.OUTPSTAT = "OUTPSTAT"
	        Me._Commands.OUTPTITL = "OUTPTITL"
	        Me._Commands.POIN101 = "POIN101"
	        Me._Commands.POIN201 = "POIN201"
	        Me._Commands.POIN401 = "POIN401"
	        Me._Commands.POIN51 = "POIN51"
	        Me._Commands.POIN801 = "POIN801"
	        Me._Commands.Preset = "PRES"
	        Me._Commands.PHAS = "PHAS"
	        Me._Commands.S12 = "S12"
	        Me._Commands.S21 = "S21"
	        Me._Commands.SAV1 = "SAV1"
	        Me._Commands.SAV2 = "SAV2"
	        Me._Commands.SAVC = "SAVC"
	        Me._Commands.SAVE1 = "SAVE1"
	        Me._Commands.SAVE2 = "SAVE2"
	        Me._Commands.SAVE3 = "SAVE3"
	        Me._Commands.SAVE4 = "SAVE4"
	        Me._Commands.SAVE5 = "SAVE5"
	        Me._Commands.SAVE6 = "SAVE6"
	        Me._Commands.SAVE7 = "SAVE7"
	        Me._Commands.SAVE8 = "SAVE8"
	        Me._Commands.SWR = "SWR"
		End Sub

    End Class

