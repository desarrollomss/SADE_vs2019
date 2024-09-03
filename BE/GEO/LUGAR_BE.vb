Imports System.Collections.Generic
'Imports System.Linq
Imports System.Web

Namespace BE

    <Serializable()> _
    Public Class LUGAR_BE
        Private m_nLat As String
        Private m_nLon As String
        Private m_xGeo As String
        Private m_yGeo As String
        Private m_nVia As String
        Private m_nCuadrante As String
        Private m_nSector As String
        Private m_nHabilita As String

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

        Public Property nCuadrante() As String
            Get
                Return m_nCuadrante
            End Get
            Set(ByVal value As String)
                m_nCuadrante = value
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


        Public Property nHabilita() As String
            Get
                Return m_nHabilita
            End Get
            Set(ByVal value As String)
                m_nHabilita = value
            End Set
        End Property


    End Class
End Namespace