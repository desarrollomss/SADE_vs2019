Imports System

Namespace BE

    <Serializable()> _
    Public Class CCOROLSERVICIO_BE

        Private datrsefecha As Nullable(Of DateTime)
        Private intpercodigo As Nullable(Of Integer)
        Private vchpertelefono As String
        Private smlrsedisponible As Nullable(Of Int16)
        Private smlrsemotausencia As Nullable(Of Int16)
        Private smlturcodigo As Nullable(Of Int16)
        Private smlcrgcodigo As Nullable(Of Int16)
        Private smlpermodalidad As Nullable(Of Int16)
        Private vchrsecomentario As String
        Private smlseccodigo As Nullable(Of Int16)
        Private smlpficodigo As Nullable(Of Int16)
        Private smlrseasistencia As Nullable(Of Int16)
        Private vchaudprgcreacion As String
        Private vchaudprgmodif As String
        Private vchaudeqpcreacion As String
        Private vchaudeqpmodif As String
        Private dtmaudfeccreacion As DateTime
        Private dtmaudfecmodif As DateTime
        Private vchaudusucreacion As String
        Private vchaudusumodif As String
        Private intaudrolcreacion As Nullable(Of Integer)
        Private intaudrolmodif As Nullable(Of Integer)
        Private smlgrscodigo As Nullable(Of Int16)

        Public Property PropRSEFECHA() As Nullable(Of DateTime)
            Get
                Return datrsefecha
            End Get
            Set(ByVal value As Nullable(Of DateTime))
                datrsefecha = value
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
        Public Property PropPERTELEFONO() As String
            Get
                Return vchpertelefono
            End Get
            Set(ByVal value As String)
                vchpertelefono = value
            End Set
        End Property
        Public Property PropRSEDISPONIBLE() As Nullable(Of Int16)
            Get
                Return smlrsedisponible
            End Get
            Set(ByVal value As Nullable(Of Int16))
                smlrsedisponible = value
            End Set
        End Property
        Public Property PropRSEMOTAUSENCIA() As Nullable(Of Int16)
            Get
                Return smlrsemotausencia
            End Get
            Set(ByVal value As Nullable(Of Int16))
                smlrsemotausencia = value
            End Set
        End Property
        Public Property PropTURCODIGO() As Nullable(Of Int16)
            Get
                Return smlturcodigo
            End Get
            Set(ByVal value As Nullable(Of Int16))
                smlturcodigo = value
            End Set
        End Property
        Public Property PropCRGCODIGO() As Nullable(Of Int16)
            Get
                Return smlcrgcodigo
            End Get
            Set(ByVal value As Nullable(Of Int16))
                smlcrgcodigo = value
            End Set
        End Property
        Public Property PropPERMODALIDAD() As Nullable(Of Int16)
            Get
                Return smlpermodalidad
            End Get
            Set(ByVal value As Nullable(Of Int16))
                smlpermodalidad = value
            End Set
        End Property
        Public Property PropRSECOMENTARIO() As String
            Get
                Return vchrsecomentario
            End Get
            Set(ByVal value As String)
                vchrsecomentario = value
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
        Public Property PropPFICODIGO() As Nullable(Of Int16)
            Get
                Return smlpficodigo
            End Get
            Set(ByVal value As Nullable(Of Int16))
                smlpficodigo = value
            End Set
        End Property
        Public Property PropRSEASISTENCIA() As Nullable(Of Int16)
            Get
                Return smlrseasistencia
            End Get
            Set(ByVal value As Nullable(Of Int16))
                smlrseasistencia = value
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
        Public Property PropGRSCODIGO() As Nullable(Of Int16)
            Get
                Return smlgrscodigo
            End Get
            Set(ByVal value As Nullable(Of Int16))
                smlgrscodigo = value
            End Set
        End Property

        Public Sub New()
            LimpiaPropiedades()
        End Sub

        Public Sub LimpiaPropiedades()
            PropRSEFECHA = Nothing
            PropPERCODIGO = Nothing
            PropPERTELEFONO = Nothing
            PropRSEDISPONIBLE = Nothing
            PropRSEMOTAUSENCIA = Nothing
            PropTURCODIGO = Nothing
            PropCRGCODIGO = Nothing
            PropPERMODALIDAD = Nothing
            PropRSECOMENTARIO = Nothing
            PropSECCODIGO = Nothing
            PropPFICODIGO = Nothing
            PropRSEASISTENCIA = Nothing
            PropAUDPRGCREACION = Nothing
            PropAUDPRGMODIF = Nothing
            PropAUDEQPCREACION = Nothing
            PropAUDEQPMODIF = Nothing
            PropAUDFECCREACION = Now.Date
            PropAUDFECMODIF = Now.Date
            PropAUDUSUCREACION = Nothing
            PropAUDUSUMODIF = Nothing
            PropAUDROLCREACION = Nothing
            PropAUDROLMODIF = Nothing
            PropGRSCODIGO = Nothing
        End Sub

    End Class
End Namespace
