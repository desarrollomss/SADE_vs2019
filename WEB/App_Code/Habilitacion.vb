Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

''' <summary>
''' Summary description for Calle
''' </summary>

Public Class Habilitacion

    Private m_idhabilita As String
    Private m_codhabilita As String
    Private m_nomhabilita As String
    Private m_xGeo As String
    Private m_yGeo As String
    Private m_Geom As String


    Public Property idhabilita() As String
        Get
            Return m_idhabilita
        End Get
        Set(ByVal value As String)
            m_idhabilita = value
        End Set
    End Property

    Public Property codhabilita() As String
        Get
            Return m_codhabilita
        End Get
        Set(ByVal value As String)
            m_codhabilita = value
        End Set
    End Property

    Public Property nomhabilita() As String
        Get
            Return m_nomhabilita
        End Get
        Set(ByVal value As String)
            m_nomhabilita = value
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



