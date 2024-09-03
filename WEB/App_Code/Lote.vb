Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

''' <summary>
''' Summary description for Lote
''' </summary>
Public Class Lote
    Public Property codLote() As String
        Get
            Return m_codLote
        End Get
        Set(ByVal value As String)
            m_codLote = Value
        End Set
    End Property
    Private m_codLote As String
    Public Property codLHU() As String
        Get
            Return m_codLHU
        End Get
        Set(ByVal value As String)
            m_codLHU = Value
        End Set
    End Property
    Private m_codLHU As String
    Public Property codMZU() As String
        Get
            Return m_codMZU
        End Get
        Set(ByVal value As String)
            m_codMZU = Value
        End Set
    End Property
    Private m_codMZU As String
    Public Property codHU() As String
        Get
            Return m_codHU
        End Get
        Set(ByVal value As String)
            m_codHU = Value
        End Set
    End Property
    Private m_codHU As String
    Public Property denHU() As String
        Get
            Return m_denHU
        End Get
        Set(ByVal value As String)
            m_denHU = Value
        End Set
    End Property
    Private m_denHU As String
    Public Property codFoto() As String
        Get
            Return m_codFoto
        End Get
        Set(ByVal value As String)
            m_codFoto = Value
        End Set
    End Property
    Private m_codFoto As String
    Public Property xGeo() As String
        Get
            Return m_xGeo
        End Get
        Set(ByVal value As String)
            m_xGeo = Value
        End Set
    End Property
    Private m_xGeo As String
    Public Property yGeo() As String
        Get
            Return m_yGeo
        End Get
        Set(ByVal value As String)
            m_yGeo = Value
        End Set
    End Property
    Private m_yGeo As String
    Public Property Geom() As String
        Get
            Return m_Geom
        End Get
        Set(ByVal value As String)
            m_Geom = Value
        End Set
    End Property
    Private m_Geom As String
    Public Property xyCord() As String
        Get
            Return m_xyCord
        End Get
        Set(ByVal value As String)
            m_xyCord = Value
        End Set
    End Property
    Private m_xyCord As String
    Public Property Poly() As String
        Get
            Return m_Poly
        End Get
        Set(ByVal value As String)
            m_Poly = Value
        End Set
    End Property
    Private m_Poly As String

    Public Property Extend() As String
        Get
            Return m_Extend
        End Get
        Set(ByVal value As String)
            m_Extend = value
        End Set
    End Property
    Private m_Extend As String


End Class
