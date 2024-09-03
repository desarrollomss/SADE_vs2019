Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

''' <summary>
''' Summary description for Punto
''' </summary>
Public Class Punto

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
End Class

