Imports System

Namespace BE

    <Serializable()> _
    Public Class SYSNRO_BE


        Private _VCHCODLOTE As String
        Private _VCHCODLOTEGIS As String
        Private _VCHNROVIA As String
        Private _VCHNROINT As String
        Private _VCHLOTHU As String
        Private _VCHNOMHU As String
        Private _strdesvaloropc1 As String
        Private _strdesvaloropc2 As String

        Public Property pVCHCODLOTE As String
            Get
                Return _VCHCODLOTE
            End Get
            Set(ByVal value As String)
                _VCHCODLOTE = value
            End Set
        End Property

        Public Property pVCHCODLOTEGIS As String
            Get
                Return _VCHCODLOTEGIS
            End Get
            Set(ByVal value As String)
                _VCHCODLOTEGIS = value
            End Set
        End Property

        Public Property pVCHNROVIA As String
            Get
                Return _VCHNROVIA
            End Get
            Set(ByVal value As String)
                _VCHNROVIA = value
            End Set
        End Property

        Public Property pVCHNROINT As String
            Get
                Return _VCHNROINT
            End Get
            Set(ByVal value As String)
                _VCHNROINT = value
            End Set
        End Property

        Public Property pVCHLOTHU As String
            Get
                Return _VCHLOTHU
            End Get
            Set(ByVal value As String)
                _VCHLOTHU = value
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
            pVCHCODLOTE = Nothing
            pVCHCODLOTEGIS = Nothing
            pVCHNROVIA = Nothing
            pVCHNROINT = Nothing
            pVCHLOTHU = Nothing
            pVCHNOMHU = Nothing
            pstrdesvaloropc1 = Nothing
            pstrdesvaloropc2 = Nothing
        End Sub

    End Class
End Namespace
