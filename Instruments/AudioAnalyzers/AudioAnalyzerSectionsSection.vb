'
' Created by SharpDevelop.
' User: rspage
' Date: 7/11/2005
' Time: 8:19 AM
' 



Imports System



	Public Class AudioAnalyzerSectionsSection

		Protected _MainAudioAnalyzer As AudioAnalyzer
        Protected _Measurements As AudioAnalyzerMeasurementsSection
        Protected _Source As AudioAnalyzerSourceSection
        Protected _Filters As AudioAnalyzerFilterSection

        Public ReadOnly Property Measurements As AudioAnalyzerMeasurementsSection
            Get
                Return Me._Measurements
            End Get
        End Property

        Public ReadOnly Property Source As AudioAnalyzerSourceSection
            Get
                Return Me._Source
            End Get
        End Property

        Public ReadOnly Property Filters As AudioAnalyzerFilterSection
            Get
                Return Me._Filters
            End Get
        End Property

		Public Sub New(ByRef mainAudioAnalyzer As AudioAnalyzer)
			Me._MainAudioAnalyzer = mainAudioAnalyzer
        	Me._Measurements = New AudioAnalyzerMeasurementsSection(Me._MainAudioAnalyzer)
        	Me._Source = New AudioAnalyzerSourceSection(Me._MainAudioAnalyzer)
        	Me._Filters = New AudioAnalyzerFilterSection(Me._MainAudioAnalyzer)
		End Sub

	End Class

