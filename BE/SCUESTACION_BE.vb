Imports System

Namespace BE

    <Serializable()> _
    Public Class SCUESTACION_BE

        Private vchestcnumip As String
        Private vchestcdescri As String
        Private intestcestado As Nullable(Of Integer)
        Private vchaudprgcreacion As String
        Private vchaudeqpcreacion As String
        Private dtmaudfeccreacion As DateTime
        Private vchaudusucreacion As String
        Private vchaudprgmodif As String
        Private vchaudeqpmodif As String
        Private dtmaudfecmodif As DateTime
        Private vchaudusumodif As String

        Public Property PropESTCNUMIP() As String
            Get
                Return vchestcnumip
            End Get
            Set(ByVal value As String)
                vchestcnumip = value
            End Set
        End Property
        Public Property PropESTCDESCRI() As String
            Get
                Return vchestcdescri
            End Get
            Set(ByVal value As String)
                vchestcdescri = value
            End Set
        End Property
        Public Property PropESTCESTADO() As Nullable(Of Integer)
            Get
                Return intestcestado
            End Get
            Set(ByVal value As Nullable(Of Integer))
                intestcestado = value
            End Set
        End Property
        Public Property PropAUDPRGCREACION() As String
            Get
                Return vchaudprgcreacion
            End Get
            Set(ByVal value As String)
                vchaudprgcreacion = value
            End Set
        End Property
        Public Property PropAUDEQPCREACION() As String
            Get
                Return vchaudeqpcreacion
            End Get
            Set(ByVal value As String)
                vchaudeqpcreacion = value
            End Set
        End Property
        Public Property PropAUDFECCREACION() As DateTime
            Get
                Return dtmaudfeccreacion
            End Get
            Set(ByVal value As DateTime)
                dtmaudfeccreacion = value
            End Set
        End Property
        Public Property PropAUDUSUCREACION() As String
            Get
                Return vchaudusucreacion
            End Get
            Set(ByVal value As String)
                vchaudusucreacion = value
            End Set
        End Property
        Public Property PropAUDPRGMODIF() As String
            Get
                Return vchaudprgmodif
            End Get
            Set(ByVal value As String)
                vchaudprgmodif = value
            End Set
        End Property
        Public Property PropAUDEQPMODIF() As String
            Get
                Return vchaudeqpmodif
            End Get
            Set(ByVal value As String)
                vchaudeqpmodif = value
            End Set
        End Property
        Public Property PropAUDFECMODIF() As DateTime
            Get
                Return dtmaudfecmodif
            End Get
            Set(ByVal value As DateTime)
                dtmaudfecmodif = value
            End Set
        End Property
        Public Property PropAUDUSUMODIF() As String
            Get
                Return vchaudusumodif
            End Get
            Set(ByVal value As String)
                vchaudusumodif = value
            End Set
        End Property

        Public Sub New()
            LimpiaPropiedades()
        End Sub

        Public Sub LimpiaPropiedades()
            PropESTCNUMIP = Nothing
            PropESTCDESCRI = Nothing
            PropESTCESTADO = Nothing
            PropAUDPRGCREACION = Nothing
            PropAUDEQPCREACION = Nothing
            PropAUDFECCREACION = Now.Date
            PropAUDUSUCREACION = Nothing
            PropAUDPRGMODIF = Nothing
            PropAUDEQPMODIF = Nothing
            PropAUDFECMODIF = Now.Date
            PropAUDUSUMODIF = Nothing
        End Sub

    End Class
End Namespace
