Imports System

Namespace BE

	<Serializable()> _
	Public Class CCOTABLA_BE

		Private inttabcodigo As Nullable(Of Integer)
		Private vchtabcodigoalterno As String
		Private vchtabdescripcion As String
		Private vchtababreviado As String
		Private inttabestado As Nullable(Of Integer)
		Private vchttacodigo As String
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

		Public Property PropTABCODIGO() As Nullable(Of Integer)
		  Get
			  Return inttabcodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  inttabcodigo = value
		  End Set
		End Property
		Public Property PropTABCODIGOALTERNO() As String
		  Get
			  Return vchtabcodigoalterno
		  End Get
		  Set(ByVal value As String)
			  vchtabcodigoalterno = value
		  End Set
		End Property
		Public Property PropTABDESCRIPCION() As String
		  Get
			  Return vchtabdescripcion
		  End Get
		  Set(ByVal value As String)
			  vchtabdescripcion = value
		  End Set
		End Property
		Public Property PropTABABREVIADO() As String
		  Get
			  Return vchtababreviado
		  End Get
		  Set(ByVal value As String)
			  vchtababreviado = value
		  End Set
		End Property
		Public Property PropTABESTADO() As Nullable(Of Integer)
		  Get
			  Return inttabestado
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  inttabestado = value
		  End Set
		End Property
		Public Property PropTTACODIGO() As String
		  Get
			  Return vchttacodigo
		  End Get
		  Set(ByVal value As String)
			  vchttacodigo = value
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

		Public Sub New()
			LimpiaPropiedades()
		End Sub

		Public Sub LimpiaPropiedades()
			PropTABCODIGO = Nothing
			PropTABCODIGOALTERNO = Nothing
			PropTABDESCRIPCION = Nothing
			PropTABABREVIADO = Nothing
			PropTABESTADO = Nothing
			PropTTACODIGO = Nothing
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
		End Sub

	End Class
End Namespace
