Imports System

Namespace BE

	<Serializable()> _
	Public Class CCORECURSO_BE

		Private intreccodigo As Nullable(Of Integer)
		Private vchrecdescripcion As String
		Private vchreccodigoalterno As String
		Private vchrecmarca As String
		Private vchrecmodelo As String
		Private vchrecplaca As String
		Private smlrecestado As Nullable(Of Int16)
		Private smltrecodigo As Nullable(Of Int16)
		Private smlseccodigo As Nullable(Of Int16)
		Private vchreccodigopatrimonial As String
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

		Public Property PropRECCODIGO() As Nullable(Of Integer)
		  Get
			  Return intreccodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intreccodigo = value
		  End Set
		End Property
		Public Property PropRECDESCRIPCION() As String
		  Get
			  Return vchrecdescripcion
		  End Get
		  Set(ByVal value As String)
			  vchrecdescripcion = value
		  End Set
		End Property
		Public Property PropRECCODIGOALTERNO() As String
		  Get
			  Return vchreccodigoalterno
		  End Get
		  Set(ByVal value As String)
			  vchreccodigoalterno = value
		  End Set
		End Property
		Public Property PropRECMARCA() As String
		  Get
			  Return vchrecmarca
		  End Get
		  Set(ByVal value As String)
			  vchrecmarca = value
		  End Set
		End Property
		Public Property PropRECMODELO() As String
		  Get
			  Return vchrecmodelo
		  End Get
		  Set(ByVal value As String)
			  vchrecmodelo = value
		  End Set
		End Property
		Public Property PropRECPLACA() As String
		  Get
			  Return vchrecplaca
		  End Get
		  Set(ByVal value As String)
			  vchrecplaca = value
		  End Set
		End Property
		Public Property PropRECESTADO() As Nullable(Of Int16)
		  Get
			  Return smlrecestado
		  End Get
		  Set(ByVal value As Nullable(Of Int16))
			  smlrecestado = value
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
		Public Property PropRECCODIGOPATRIMONIAL() As String
		  Get
			  Return vchreccodigopatrimonial
		  End Get
		  Set(ByVal value As String)
			  vchreccodigopatrimonial = value
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
			PropRECCODIGO = Nothing
			PropRECDESCRIPCION = Nothing
			PropRECCODIGOALTERNO = Nothing
			PropRECMARCA = Nothing
			PropRECMODELO = Nothing
			PropRECPLACA = Nothing
			PropRECESTADO = Nothing
			PropTRECODIGO = Nothing
			PropSECCODIGO = Nothing
			PropRECCODIGOPATRIMONIAL = Nothing
			PropAUDPRGCREACION = Nothing
			PropAUDPRGMODIF = Nothing
			PropAUDEQPCREACION = Nothing
			PropAUDEQPMODIF = Nothing
            PropAUDFECCREACION = Now.Date
            PropAUDFECMODIF = Nothing
			PropAUDUSUCREACION = Nothing
			PropAUDUSUMODIF = Nothing
			PropAUDROLCREACION = Nothing
			PropAUDROLMODIF = Nothing
		End Sub

	End Class
End Namespace
