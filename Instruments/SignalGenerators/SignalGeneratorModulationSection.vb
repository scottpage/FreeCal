'
' Created by SharpDevelop.
' User: Administrator
' Date: 6/11/2005
' Time: 7:25 AM
' 

Imports System
Imports Microsoft.VisualBasic.ControlChars
Imports NationalInstruments.NI4882
Imports FreeCal.Instruments
Imports FreeCal.Common
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
    Public Class SignalGeneratorModulationSection

        Protected _MainSignalGenerator As SignalGenerator
        Protected _AM As SignalGeneratorAMSection
        Protected _FM As SignalGeneratorFMSection
        Protected _PM As SignalGeneratorPMSection
        Protected _OutputState As OnOffStateEnum
        Protected _Mode As ModulationModeEnum

		Public Property Mode As ModulationModeEnum
			Get
				Return Me._Mode
			End Get
			Set
				Me._Mode = Value
				Me._MainSignalGenerator.Write(Me._MainSignalGenerator.Commands.SetModulationMode & Value.ToString)
			End Set
		End Property

        Public ReadOnly Property AM As SignalGeneratorAMSection
            Get
                Return Me._AM
            End Get
        End Property

        Public ReadOnly Property FM As SignalGeneratorFMSection
            Get
                Return Me._FM
            End Get
        End Property

        Public ReadOnly Property PM As SignalGeneratorPMSection
            Get
                Return Me._PM
            End Get
        End Property

        Public Property OutputState As OnOffStateEnum
            Get
                Return Me._OutputState
            End Get
            Set
                Me._OutputState = Value
				If Value = OnOffStateEnum.[On] Then
                	Me._MainSignalGenerator.Write(Me._MainSignalGenerator.Commands.SetModulationStateOn)
                ElseIf Value = OnOffStateEnum.[Off] Then
                	Me._MainSignalGenerator.Write(Me._MainSignalGenerator.Commands.SetModulationStateOff)
                End If
            End Set
        End Property

        Public Sub New(ByRef MainSignalGenerator As SignalGenerator)
            Me._MainSignalGenerator = MainSignalGenerator
            Me._AM = New SignalGeneratorAMSection(Me._MainSignalGenerator)
            Me._FM = New SignalGeneratorFMSection(Me._MainSignalGenerator)
            Me._PM = New SignalGeneratorPMSection(Me._MainSignalGenerator)
        End Sub

    End Class



