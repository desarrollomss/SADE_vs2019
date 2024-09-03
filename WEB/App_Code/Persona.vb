Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

''' <summary>
''' Summary description for Lote
''' </summary>
Public Class Persona

    Public Property codPersona() As String
        Get
            Return m_codPersona
        End Get
        Set(ByVal value As String)
            m_codPersona = value
        End Set
    End Property
    Private m_codPersona As String
    Public Property nomPersona() As String
        Get
            Return m_nomPersona
        End Get
        Set(ByVal value As String)
            m_nomPersona = value
        End Set
    End Property
    Private m_nomPersona As String
    Public Property crgPersona() As String
        Get
            Return m_crgPersona
        End Get
        Set(ByVal value As String)
            m_crgPersona = value
        End Set
    End Property
    Private m_crgPersona As String
End Class
