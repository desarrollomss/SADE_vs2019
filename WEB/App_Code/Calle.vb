Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

''' <summary>
''' Summary description for Calle
''' </summary>
Public Class Calle

    Private m_idvia As String
    Private m_codvia As String
    Private m_nomvia As String
    Private m_nrocdra As String
    Private m_xGeo As String
    Private m_yGeo As String
    Private m_Geom As String
    Private m_Lon As String
    Private m_Lat As String


    Public Property idvia() As String
        Get
            Return m_idvia
        End Get
        Set(ByVal value As String)
            m_idvia = value
        End Set
    End Property

    Public Property codvia() As String
        Get
            Return m_codvia
        End Get
        Set(ByVal value As String)
            m_codvia = value
        End Set
    End Property

    Public Property nomvia() As String
        Get
            Return m_nomvia
        End Get
        Set(ByVal value As String)
            m_nomvia = value
        End Set
    End Property

    Public Property nrocdra() As String
        Get
            Return m_nrocdra
        End Get
        Set(ByVal value As String)
            m_nrocdra = value
        End Set
    End Property

    Public Property xGeo() As String
        Get
            Return m_xGeo
        End Get
        Set(ByVal value As String)
            m_xGeo = value
        End Set
    End Property

    Public Property yGeo() As String
        Get
            Return m_yGeo
        End Get
        Set(ByVal value As String)
            m_yGeo = value
        End Set
    End Property

    Public Property Geom() As String
        Get
            Return m_Geom
        End Get
        Set(ByVal value As String)
            m_Geom = value
        End Set
    End Property

    Public Property Lon() As String
        Get
            Return m_Lon
        End Get
        Set(ByVal value As String)
            m_Lon = value
        End Set
    End Property

    Public Property Lat() As String
        Get
            Return m_Lat
        End Get
        Set(ByVal value As String)
            m_Lat = value
        End Set
    End Property

End Class


