Imports System

Namespace BE

	<Serializable()> _
	Public Class CCOENCUESTAINCIDENCIA_BE

		Private intprrcodigo As Nullable(Of Integer)
		Private smlaltcodigo As Nullable(Of Int16)
		Private vchprrrespuesta As String
		Private intinccodigo As Nullable(Of Integer)
		Private smlprgcodigo As Nullable(Of Integer)
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

		Public Property PropPRRCODIGO() As Nullable(Of Integer)
		  Get
			  Return intprrcodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intprrcodigo = value
		  End Set
		End Property
		Public Property PropALTCODIGO() As Nullable(Of Int16)
		  Get
			  Return smlaltcodigo
		  End Get
		  Set(ByVal value As Nullable(Of Int16))
			  smlaltcodigo = value
		  End Set
		End Property
		Public Property PropPRRRESPUESTA() As String
		  Get
			  Return vchprrrespuesta
		  End Get
		  Set(ByVal value As String)
			  vchprrrespuesta = value
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
		Public Property PropPRGCODIGO() As Nullable(Of Integer)
		  Get
			  Return smlprgcodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  smlprgcodigo = value
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
			PropPRRCODIGO = Nothing
			PropALTCODIGO = Nothing
			PropPRRRESPUESTA = Nothing
			PropINCCODIGO = Nothing
			PropPRGCODIGO = Nothing
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
