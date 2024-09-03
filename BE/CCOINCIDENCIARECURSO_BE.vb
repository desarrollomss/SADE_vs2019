Imports System

Namespace BE

    <Serializable()> _
    Public Class CCOINCIDENCIARECURSO_BE


        Private intincrcodigo As Nullable(Of Integer)
        Private intinccodigo As Nullable(Of Integer)
        Private dtmincrasigna As DateTime
        Private smltrecodigo As Nullable(Of Integer)
        Private intreccodigo As Nullable(Of Integer)
        Private vchrecpersonal As String
        Private vchaudprgcreacion As String
        Private vchaudeqpcreacion As String
        Private dtmaudfeccreacion As DateTime
        Private vchaudusucreacion As String
        Private intaudrolcreacion As Nullable(Of Integer)
        Private dtmaudfecmodif As DateTime
        Private intaudrolmodif As Nullable(Of Integer)
        Private vchaudeqpmodif As String
        Private vchaudprgmodif As String
        Private vchaudusumodif As String

        Public Property PropINCRCODIGO() As Nullable(Of Integer)
            Get
                Return intincrcodigo
            End Get
            Set(ByVal value As Nullable(Of Integer))
                intincrcodigo = value
            End Set
        End Property
        Public Property PropINCCODIGO() As Nullable(Of Integer)
            Get
                Return intinccodigo
            End Get
            Set(ByVal value As Nullable(Of Integer))
                intinccodigo = value
            End Set
        End Property
        Public Property PropINCRASIGNA() As DateTime
            Get
                Return dtmincrasigna
            End Get
            Set(ByVal value As DateTime)
                dtmincrasigna = value
            End Set
        End Property
        Public Property PropTRECODIGO() As Nullable(Of Integer)
            Get
                Return smltrecodigo
            End Get
            Set(ByVal value As Nullable(Of Integer))
                smltrecodigo = value
            End Set
        End Property
        Public Property PropRECCODIGO() As Nullable(Of Integer)
            Get
                Return intreccodigo
            End Get
            Set(ByVal value As Nullable(Of Integer))
                intreccodigo = value
            End Set
        End Property
        Public Property PropRECPERSONAL() As String
            Get
                Return vchrecpersonal
            End Get
            Set(ByVal value As String)
                vchrecpersonal = value
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
        Public Property PropAUDROLCREACION() As Nullable(Of Integer)
            Get
                Return intaudrolcreacion
            End Get
            Set(ByVal value As Nullable(Of Integer))
                intaudrolcreacion = value
            End Set
        End Property
        Public Property PropAUDROLMODIF() As Nullable(Of Integer)
            Get
                Return intaudrolmodif
            End Get
            Set(ByVal value As Nullable(Of Integer))
                intaudrolmodif = value
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
            PropINCRCODIGO = Nothing
            PropINCCODIGO = Nothing
            PropINCRASIGNA = Nothing
            PropTRECODIGO = Nothing
            PropRECCODIGO = Nothing
            PropRECPERSONAL = Nothing
            PropAUDPRGCREACION = Nothing
            PropAUDEQPCREACION = Nothing
            PropAUDFECCREACION = Now.Date
            PropAUDUSUCREACION = Nothing
            PropAUDROLCREACION = Nothing
            PropAUDFECMODIF = Nothing
            PropAUDROLMODIF = Nothing
            PropAUDEQPMODIF = Nothing
            PropAUDPRGMODIF = Nothing
            PropAUDUSUMODIF = Nothing

        End Sub

    End Class
End Namespace
