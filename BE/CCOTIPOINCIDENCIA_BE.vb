Imports System

Namespace BE

	<Serializable()> _
	Public Class CCOTIPOINCIDENCIA_BE

		Private inttincodigo As Nullable(Of Integer)
		Private vchtindescripcion As String
		Private vchtinabrevia As String
		Private intcincodigo As Nullable(Of Integer)
		Private inttinestado As Nullable(Of Integer)
        Private vchtinconsejo As String
        Private vchaudprgcreacion As String
        Private vchaudprgmodif As String
        Private vchaudeqpcreacion As String
        Private vchaudeqpmodif As String
        Private dtmaudfeccreacion As DateTime
        Private dtmaudfecmodif As DateTime
        Private vchaudusucreacion As String
        Private vchaudusumodif As String


		Public Property PropTINCODIGO() As Nullable(Of Integer)
		  Get
			  Return inttincodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  inttincodigo = value
		  End Set
		End Property
		Public Property PropTINDESCRIPCION() As String
		  Get
			  Return vchtindescripcion
		  End Get
		  Set(ByVal value As String)
			  vchtindescripcion = value
		  End Set
		End Property
		Public Property PropTINABREVIA() As String
		  Get
			  Return vchtinabrevia
		  End Get
		  Set(ByVal value As String)
			  vchtinabrevia = value
		  End Set
		End Property
		Public Property PropCINCODIGO() As Nullable(Of Integer)
		  Get
			  Return intcincodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intcincodigo = value
		  End Set
		End Property
		Public Property PropTINESTADO() As Nullable(Of Integer)
		  Get
			  Return inttinestado
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  inttinestado = value
		  End Set
		End Property
		Public Property PropTINCONSEJO() As String
		  Get
			  Return vchtinconsejo
		  End Get
		  Set(ByVal value As String)
			  vchtinconsejo = value
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


		Public Sub New()
			LimpiaPropiedades()
		End Sub

		Public Sub LimpiaPropiedades()
			PropTINCODIGO = Nothing
			PropTINDESCRIPCION = Nothing
			PropTINABREVIA = Nothing
			PropCINCODIGO = Nothing
			PropTINESTADO = Nothing
            PropTINCONSEJO = Nothing
            PropAUDPRGCREACION = Nothing
            PropAUDPRGMODIF = Nothing
            PropAUDEQPCREACION = Nothing
            PropAUDEQPMODIF = Nothing
            PropAUDFECCREACION = Now.Date
            PropAUDFECMODIF = Nothing
            PropAUDUSUCREACION = Nothing
            PropAUDUSUMODIF = Nothing
        End Sub

	End Class
End Namespace
