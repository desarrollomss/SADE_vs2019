Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

''' <summary>
''' Summary description for Posicion
''' </summary>
Public Class Posicion

    Private m_nId As String
    Private m_nISSI As String
    Private m_nLat As String
    Private m_nLon As String
    Private m_xGeo As String
    Private m_yGeo As String
    Private m_cVia As String
    Private m_nVia As String

    Private m_nCdte As String
    Private m_cHU As String
    Private m_nHU As String
    Private m_nSector As String

    Private m_LTU As String
    Private m_MZU As String
    Private m_CODCAT As String
    Private m_nCda As String
    Private m_nViaInt As String
    Private m_cViaInt As String
    Private m_cFotoLote As String



    Public Property nId() As String
        Get
            Return m_nId
        End Get
        Set(ByVal value As String)
            m_nId = value
        End Set
    End Property

    Public Property nISSI() As String
        Get
            Return m_nISSI
        End Get
        Set(ByVal value As String)
            m_nISSI = value
        End Set
    End Property

    Public Property nLat() As String
        Get
            Return m_nLat
        End Get
        Set(ByVal value As String)
            m_nLat = value
        End Set
    End Property

    Public Property nLon() As String
        Get
            Return m_nLon
        End Get
        Set(ByVal value As String)
            m_nLon = value
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

    Public Property nVia() As String
        Get
            Return m_nVia
        End Get
        Set(ByVal value As String)
            m_nVia = value
        End Set
    End Property

    Public Property nCdte() As String
        Get
            Return m_nCdte
        End Get
        Set(ByVal value As String)
            m_nCdte = value
        End Set
    End Property

    Public Property nHU() As String
        Get
            Return m_nHU
        End Get
        Set(ByVal value As String)
            m_nHU = value
        End Set
    End Property

    Public Property cHU() As String
        Get
            Return m_cHU
        End Get
        Set(ByVal value As String)
            m_cHU = value
        End Set
    End Property

    Public Property cVia() As String
        Get
            Return m_cVia
        End Get
        Set(ByVal value As String)
            m_cVia = value
        End Set
    End Property

    Public Property nSector() As String
        Get
            Return m_nSector
        End Get
        Set(ByVal value As String)
            m_nSector = value
        End Set
    End Property

    Public Property cLTU() As String
        Get
            Return m_LTU
        End Get
        Set(ByVal value As String)
            m_LTU = value
        End Set
    End Property

    Public Property cMZU() As String
        Get
            Return m_MZU
        End Get
        Set(ByVal value As String)
            m_MZU = value
        End Set
    End Property

    Public Property cCODCAT() As String
        Get
            Return m_CODCAT
        End Get
        Set(ByVal value As String)
            m_CODCAT = value
        End Set
    End Property

    Public Property cCda() As String
        Get
            Return m_nCda
        End Get
        Set(ByVal value As String)
            m_nCda = value
        End Set
    End Property

    Public Property nViaInt() As String
        Get
            Return m_nViaInt
        End Get
        Set(ByVal value As String)
            m_nViaInt = value
        End Set
    End Property

    Public Property cViaInt() As String
        Get
            Return m_cViaInt
        End Get
        Set(ByVal value As String)
            m_cViaInt = value
        End Set
    End Property

    Public Property cFotoLote() As String
        Get
            Return m_cFotoLote
        End Get
        Set(ByVal value As String)
            m_cFotoLote = value
        End Set
    End Property

End Class