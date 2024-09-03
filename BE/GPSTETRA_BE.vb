Imports System

Namespace BE

    <Serializable()> _
    Public Class GPSTETRA_BE

        Private intnissi As Nullable(Of Integer)
        Private smltrecodigo As Nullable(Of Int16)
        Private smlseccodigo As Nullable(Of Int16)
        Private intpercodigo As Nullable(Of Integer)
        Private vchobservacion As String
        Private smlestado As Nullable(Of Int16)
        Private vchaudprgcreacion As String
        Private vchaudprgmodif As String
        Private vchaudeqpcreacion As String
        Private vchaudeqpmodif As String
        Private dtmaudfeccreacion As DateTime
        Private dtmaudfecmodif As DateTime
        Private vchaudusucreacion As String
        Private vchaudusumodif As String

        Public Property PropNISSI() As Nullable(Of Integer)
            Get
                Return intnissi
            End Get
            Set(ByVal value As Nullable(Of Integer))
                intnissi = value
            End Set
        End Property
        Public Property PropTRECODIGO() As Nullable(Of Int16)
            Get
                Return smltrecodigo
            End Get
            Set(ByVal value As Nullable(Of Int16))
                smltrecodigo = value
            End Set
        End Property
        Public Property PropSECCODIGO() As Nullable(Of Int16)
            Get
                Return smlseccodigo
            End Get
            Set(ByVal value As Nullable(Of Int16))
                smlseccodigo = value
            End Set
        End Property
        Public Property PropPERCODIGO() As Nullable(Of Integer)
            Get
                Return intpercodigo
            End Get
            Set(ByVal value As Nullable(Of Integer))
                intpercodigo = value
            End Set
        End Property
        Public Property PropOBSERVACION() As String
            Get
                Return vchobservacion
            End Get
            Set(ByVal value As String)
                vchobservacion = value
            End Set
        End Property
        Public Property PropESTADO() As Nullable(Of Int16)
            Get
                Return smlestado
            End Get
            Set(ByVal value As Nullable(Of Int16))
                smlestado = value
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
        Public Property PropAUDPRGMODIF() As String
            Get
                Return vchaudprgmodif
            End Get
            Set(ByVal value As String)
                vchaudprgmodif = value
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
        Public Property PropAUDEQPMODIF() As String
            Get
                Return vchaudeqpmodif
            End Get
            Set(ByVal value As String)
                vchaudeqpmodif = value
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
        Public Property PropAUDFECMODIF() As DateTime
            Get
                Return dtmaudfecmodif
            End Get
            Set(ByVal value As DateTime)
                dtmaudfecmodif = value
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
        Public Property PropAUDUSUMODIF() As String
            Get
                Return vchaudusumodif
            End Get
            Set(ByVal value As String)
                vchaudusumodif = value
            End Set
        End Property

    End Class

End Namespace