Imports System

Namespace BE

	<Serializable()> _
	Public Class SCUROL_BE

		Private introlcodigo As Nullable(Of Integer)
		Private vchroldescrip As String
		Private vchrolabrev As String
		Private vchrolobserv As String
		Private vchestado As String
		Private vchaudusucreacion As String
		Private tmsaudfeccreacion As DateTime
		Private vchaudusumodif As String
		Private tmsaudfecmodif As DateTime
		Private vchaudequipo As String

		Public Property PropROLCODIGO() As Nullable(Of Integer)
		  Get
			  Return introlcodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  introlcodigo = value
		  End Set
		End Property
		Public Property PropROLDESCRIP() As String
		  Get
			  Return vchroldescrip
		  End Get
		  Set(ByVal value As String)
			  vchroldescrip = value
		  End Set
		End Property
		Public Property PropROLABREV() As String
		  Get
			  Return vchrolabrev
		  End Get
		  Set(ByVal value As String)
			  vchrolabrev = value
		  End Set
		End Property
		Public Property PropROLOBSERV() As String
		  Get
			  Return vchrolobserv
		  End Get
		  Set(ByVal value As String)
			  vchrolobserv = value
		  End Set
		End Property
		Public Property PropESTADO() As String
		  Get
			  Return vchestado
		  End Get
		  Set(ByVal value As String)
			  vchestado = value
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
		Public Property PropAUDFECCREACION() As DateTime
		  Get
			  Return tmsaudfeccreacion
		  End Get
		  Set(ByVal value As DateTime)
			  tmsaudfeccreacion = value
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
		Public Property PropAUDFECMODIF() As DateTime
		  Get
			  Return tmsaudfecmodif
		  End Get
		  Set(ByVal value As DateTime)
			  tmsaudfecmodif = value
		  End Set
		End Property
		Public Property PropAUDEQUIPO() As String
		  Get
			  Return vchaudequipo
		  End Get
		  Set(ByVal value As String)
			  vchaudequipo = value
		  End Set
		End Property

		Public Sub New()
			LimpiaPropiedades()
		End Sub

		Public Sub LimpiaPropiedades()
			PropROLCODIGO = Nothing
			PropROLDESCRIP = Nothing
			PropROLABREV = Nothing
			PropROLOBSERV = Nothing
			PropESTADO = Nothing
			PropAUDUSUCREACION = Nothing
			PropAUDFECCREACION = Now.Date
			PropAUDUSUMODIF = Nothing
			PropAUDFECMODIF = Now.Date
			PropAUDEQUIPO = Nothing
		End Sub

	End Class
End Namespace
