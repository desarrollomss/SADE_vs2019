Imports System

Namespace BE

    <Serializable()> _
    Public Class CCOUSUARIOSESION_BE

        Private intusuidentificador As Nullable(Of Integer)
        Private vchusuario As String
        Private smlestadosesion As Nullable(Of Integer)
        Private smlultimo As Nullable(Of Integer)
        Private introlcodigo As Nullable(Of Integer)
        Private dtmaudfecmodif As DateTime
        Private vchaudusumodif As String
        Private vchaudprgmodif As String
        Private vchaudeqpmodif As String
        Private dtmaudfeccreacion As DateTime
        Private vchaudusucreacion As String
        Private vchaudprgcreacion As String
        Private vchaudeqpcreacion As String

        Public Property PropUSUIDENTIFICADOR As Nullable(Of Integer)
            Get
                Return intusuidentificador
            End Get
            Set(ByVal value As Nullable(Of Integer))
                intusuidentificador = value
            End Set
        End Property

        Public Property PropUSUARIO As String
            Get
                Return vchusuario
            End Get
            Set(ByVal value As String)
                vchusuario = value
            End Set
        End Property

        Public Property PropESTADOSESION As Nullable(Of Integer)
            Get
                Return smlestadosesion
            End Get
            Set(ByVal value As Nullable(Of Integer))
                smlestadosesion = value
            End Set
        End Property

        Public Property PropULTIMO As Nullable(Of Integer)
            Get
                Return smlultimo
            End Get
            Set(ByVal value As Nullable(Of Integer))
                smlultimo = value
            End Set
        End Property

        Public Property PropROLCODIGO As Nullable(Of Integer)
            Get
                Return introlcodigo
            End Get
            Set(ByVal value As Nullable(Of Integer))
                introlcodigo = value
            End Set
        End Property

        Public Property PropAUDFECMODIF As DateTime
            Get
                Return dtmaudfecmodif
            End Get
            Set(ByVal value As DateTime)
                dtmaudfecmodif = value
            End Set
        End Property

        Public Property PropAUDUSUMODIF As String
            Get
                Return vchaudusumodif
            End Get
            Set(ByVal value As String)
                vchaudusumodif = value
            End Set
        End Property

        Public Property PropAUDPRGMODIF As String
            Get
                Return vchaudprgmodif
            End Get
            Set(ByVal value As String)
                vchaudprgmodif = value
            End Set
        End Property

        Public Property PropAUDEQPMODIF As String
            Get
                Return vchaudeqpmodif
            End Get
            Set(ByVal value As String)
                vchaudeqpmodif = value
            End Set
        End Property

        Public Property PropAUDFECCREACION As DateTime
            Get
                Return dtmaudfeccreacion
            End Get
            Set(ByVal value As DateTime)
                dtmaudfeccreacion = value
            End Set
        End Property

        Public Property PropAUDUSUCREACION As String
            Get
                Return vchaudusucreacion
            End Get
            Set(ByVal value As String)
                vchaudusucreacion = value
            End Set
        End Property

        Public Property PropAUDPRGCREACION As String
            Get
                Return vchaudprgcreacion
            End Get
            Set(ByVal value As String)
                vchaudprgcreacion = value
            End Set
        End Property

        Public Property PropAUDEQPCREACION As String
            Get
                Return vchaudeqpcreacion
            End Get
            Set(ByVal value As String)
                vchaudeqpcreacion = value
            End Set
        End Property

        Public Sub New()
            LimpiaPropiedades()
        End Sub

        Public Sub LimpiaPropiedades()
            PropUSUIDENTIFICADOR = Nothing
            PropUSUARIO = Nothing
            PropESTADOSESION = Nothing
            PropULTIMO = Nothing
            PropROLCODIGO = Nothing
            PropAUDFECMODIF = Nothing
            PropAUDUSUMODIF = Nothing
            PropAUDPRGMODIF = Nothing
            PropAUDEQPMODIF = Nothing
            PropAUDFECCREACION = Nothing
            PropAUDUSUCREACION = Nothing
            PropAUDPRGCREACION = Nothing
            PropAUDEQPCREACION = Nothing
        End Sub

    End Class
End Namespace
