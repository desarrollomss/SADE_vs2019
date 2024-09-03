Imports System

Namespace BE

	<Serializable()> _
	Public Class CCOMENSAJE_BE

		Private intmsjcodigo As Nullable(Of Integer)
		Private dtmmsjfeccreacion As DateTime
		Private vchmsjtitulo As String
		Private vchmsjcuerpo As String
		Private dtmmsjfeccaducidad As DateTime
		Private intmsjestado As Nullable(Of Integer)
		Private vchaudprgcreacion As String
		Private vchaudeqpcreacion As String
		Private dtmaudfeccreacion As DateTime
		Private vchaudusucreacion As String
		Private intaudrolcreacion As Nullable(Of Integer)

		Public Property PropMSJCODIGO() As Nullable(Of Integer)
		  Get
			  Return intmsjcodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intmsjcodigo = value
		  End Set
		End Property
		Public Property PropMSJFECCREACION() As DateTime
		  Get
			  Return dtmmsjfeccreacion
		  End Get
		  Set(ByVal value As DateTime)
			  dtmmsjfeccreacion = value
		  End Set
		End Property
		Public Property PropMSJTITULO() As String
		  Get
			  Return vchmsjtitulo
		  End Get
		  Set(ByVal value As String)
			  vchmsjtitulo = value
		  End Set
		End Property
		Public Property PropMSJCUERPO() As String
		  Get
			  Return vchmsjcuerpo
		  End Get
		  Set(ByVal value As String)
			  vchmsjcuerpo = value
		  End Set
		End Property
		Public Property PropMSJFECCADUCIDAD() As DateTime
		  Get
			  Return dtmmsjfeccaducidad
		  End Get
		  Set(ByVal value As DateTime)
			  dtmmsjfeccaducidad = value
		  End Set
		End Property
		Public Property PropMSJESTADO() As Nullable(Of Integer)
		  Get
			  Return intmsjestado
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intmsjestado = value
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

		Public Sub New()
			LimpiaPropiedades()
		End Sub

		Public Sub LimpiaPropiedades()
			PropMSJCODIGO = Nothing
			PropMSJFECCREACION = Now.Date
			PropMSJTITULO = Nothing
			PropMSJCUERPO = Nothing
			PropMSJFECCADUCIDAD = Now.Date
			PropMSJESTADO = Nothing
			PropAUDPRGCREACION = Nothing
			PropAUDEQPCREACION = Nothing
			PropAUDFECCREACION = Now.Date
			PropAUDUSUCREACION = Nothing
			PropAUDROLCREACION = Nothing
		End Sub

	End Class
End Namespace
