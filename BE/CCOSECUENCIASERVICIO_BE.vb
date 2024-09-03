Imports System

Namespace BE

	<Serializable()> _
	Public Class CCOSECUENCIASERVICIO_BE

		Private smlssecodigo As Nullable(Of Int16)
		Private vchssedescripcion As String
		Private smlttucodigo As Nullable(Of Int16)
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
		Private smlsseestado As Nullable(Of Int16)

		Public Property PropSSECODIGO() As Nullable(Of Int16)
		  Get
			  Return smlssecodigo
		  End Get
		  Set(ByVal value As Nullable(Of Int16))
			  smlssecodigo = value
		  End Set
		End Property
		Public Property PropSSEDESCRIPCION() As String
		  Get
			  Return vchssedescripcion
		  End Get
		  Set(ByVal value As String)
			  vchssedescripcion = value
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
		Public Property PropSSEESTADO() As Nullable(Of Int16)
		  Get
			  Return smlsseestado
		  End Get
		  Set(ByVal value As Nullable(Of Int16))
			  smlsseestado = value
		  End Set
		End Property

		Public Sub New()
			LimpiaPropiedades()
		End Sub

		Public Sub LimpiaPropiedades()
			PropSSECODIGO = Nothing
			PropSSEDESCRIPCION = Nothing
			PropTTUCODIGO = Nothing
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
			PropSSEESTADO = Nothing
		End Sub

	End Class
End Namespace
