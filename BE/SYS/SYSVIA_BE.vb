Imports System

Namespace BE
    <Serializable()> _
    Public Class SYSVIA_BE

        Private _VCHCODVIA As String
        Private _VCHNOMVIA As String
        Private _VCHCODHU As String
        Private _VCHNOMHU As String
        Private _strdesvaloropc1 As String
        Private _strdesvaloropc2 As String

        Public Property pVCHCODVIA As String
            Get
                Return _VCHCODVIA
            End Get
            Set(ByVal value As String)
                _VCHCODVIA = value
            End Set
        End Property
        Public Property pVCHNOMVIA As String
            Get
                Return _VCHNOMVIA
            End Get
            Set(ByVal value As String)
                _VCHNOMVIA = value
            End Set
        End Property

        Public Property pVCHCODHU As String
            Get
                Return _VCHCODHU
            End Get
            Set(ByVal value As String)
                _VCHCODHU = value
            End Set
        End Property
        Public Property pVCHNOMHU As String
            Get
                Return _VCHNOMHU
            End Get
            Set(ByVal value As String)
                _VCHNOMHU = value
            End Set
        End Property

        Public Property pstrdesvaloropc1 As String
            Get
                Return _strdesvaloropc1
            End Get
            Set(ByVal value As String)
                _strdesvaloropc1 = value
            End Set
        End Property
        Public Property pstrdesvaloropc2 As String
            Get
                Return _strdesvaloropc2
            End Get
            Set(ByVal value As String)
                _strdesvaloropc2 = value
            End Set
        End Property

        Public Sub New()
            LimpiaPropiedades()
        End Sub

        Public Sub LimpiaPropiedades()
            pVCHCODVIA = Nothing
            pVCHNOMVIA = Nothing
            pVCHCODHU = Nothing
            pVCHNOMHU = Nothing
            pstrdesvaloropc1 = Nothing
            pstrdesvaloropc2 = Nothing
        End Sub

    End Class
End Namespace
