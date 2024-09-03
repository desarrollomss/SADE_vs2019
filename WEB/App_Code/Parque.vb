Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

''' <summary>
''' Summary description for Calle
''' </summary>

Public Class Parque

    Private m_idparque As String
    Private m_codparque As String
    Private m_nomparque As String
    Private m_xGeo As String
    Private m_yGeo As String
    Private m_Geom As String


    Public Property idparque() As String
        Get
            Return m_idparque
        End Get
        Set(ByVal value As String)
            m_idparque = value
        End Set
    End Property

    Public Property codparque() As String
        Get
            Return m_codparque
        End Get
        Set(ByVal value As String)
            m_codparque = value
        End Set
    End Property

    Public Property nomparque() As String
        Get
            Return m_nomparque
        End Get
        Set(ByVal value As String)
            m_nomparque = value
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



End Class



