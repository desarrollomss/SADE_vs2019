Imports System

Namespace BE

    <Serializable()> _
    Public Class CCOCARGOPERSONAL_BE

        Private smlcrgcodigo As Nullable(Of Int16)
        Private vchcrgdescripcion As String
        Private smlcrgestado As Nullable(Of Int16)
        Private smlttucodigo As Nullable(Of Int16)
        Private chrcrgtipo As String

        Public Property PropCRGCODIGO() As Nullable(Of Int16)
            Get
                Return smlcrgcodigo
            End Get
            Set(ByVal value As Nullable(Of Int16))
                smlcrgcodigo = value
            End Set
        End Property
        Public Property PropCRGDESCRIPCION() As String
            Get
                Return vchcrgdescripcion
            End Get
            Set(ByVal value As String)
                vchcrgdescripcion = value
            End Set
        End Property
        Public Property PropCRGESTADO() As Nullable(Of Int16)
            Get
                Return smlcrgestado
            End Get
            Set(ByVal value As Nullable(Of Int16))
                smlcrgestado = value
            End Set
        End Property
        Public Property PropTTUCODIGO() As Nullable(Of Int16)
            Get
                Return smlttucodigo
            End Get
            Set(ByVal value As Nullable(Of Int16))
                smlttucodigo = value
            End Set
        End Property
        Public Property PropCRGTIPO() As String
            Get
                Return chrcrgtipo
            End Get
            Set(ByVal value As String)
                chrcrgtipo = value
            End Set
        End Property

        Public Sub New()
            LimpiaPropiedades()
        End Sub

        Public Sub LimpiaPropiedades()
            PropCRGCODIGO = Nothing
            PropCRGDESCRIPCION = Nothing
            PropCRGESTADO = Nothing
            PropTTUCODIGO = Nothing
            PropCRGTIPO = Nothing
        End Sub

    End Class
End Namespace
