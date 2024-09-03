Imports System

Namespace BE

	<Serializable()> _
	Public Class CCOPAQUETE_BE
        Private smlseccodigo As Nullable(Of Int16)
		Private smlcuacodigo As Nullable(Of Int16)
		Private intpaqcodigo As Nullable(Of Integer)
		Private smltpqcodigo As Nullable(Of Int16)
        Private datpaqfecha As Nullable(Of DateTime)
		Private smlpaqestado As Nullable(Of Int16)
		Private intpercodigo As Nullable(Of Integer)
		Private vchpaqnumero As String
		Private vchpaqcomentario As String
		Private smlturcodigo As Nullable(Of Int16)
		Private smlpficodigo As Nullable(Of Int16)
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
		Private smlpaqconubicacion As Nullable(Of Int16)
		Private smlpaqavisarabandono As Nullable(Of Int16)

		Public Property PropSECCODIGO() As Nullable(Of Int16)
		  Get
			  Return smlseccodigo
		  End Get
		  Set(ByVal value As Nullable(Of Int16))
			  smlseccodigo = value
		  End Set
		End Property
		Public Property PropCUACODIGO() As Nullable(Of Int16)
		  Get
			  Return smlcuacodigo
		  End Get
		  Set(ByVal value As Nullable(Of Int16))
			  smlcuacodigo = value
		  End Set
		End Property
		Public Property PropPAQCODIGO() As Nullable(Of Integer)
		  Get
			  Return intpaqcodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intpaqcodigo = value
		  End Set
		End Property
		Public Property PropTPQCODIGO() As Nullable(Of Int16)
		  Get
			  Return smltpqcodigo
		  End Get
		  Set(ByVal value As Nullable(Of Int16))
			  smltpqcodigo = value
		  End Set
		End Property
        Public Property PropPAQFECHA() As Nullable(Of DateTime)
            Get
                Return datpaqfecha
            End Get
            Set(ByVal value As Nullable(Of DateTime))
                datpaqfecha = value
            End Set
        End Property
		Public Property PropPAQESTADO() As Nullable(Of Int16)
		  Get
			  Return smlpaqestado
		  End Get
		  Set(ByVal value As Nullable(Of Int16))
			  smlpaqestado = value
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
		Public Property PropPAQNUMERO() As String
		  Get
			  Return vchpaqnumero
		  End Get
		  Set(ByVal value As String)
			  vchpaqnumero = value
		  End Set
		End Property
		Public Property PropPAQCOMENTARIO() As String
		  Get
			  Return vchpaqcomentario
		  End Get
		  Set(ByVal value As String)
			  vchpaqcomentario = value
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
		Public Property PropPFICODIGO() As Nullable(Of Int16)
		  Get
			  Return smlpficodigo
		  End Get
		  Set(ByVal value As Nullable(Of Int16))
			  smlpficodigo = value
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
		Public Property PropPAQCONUBICACION() As Nullable(Of Int16)
		  Get
			  Return smlpaqconubicacion
		  End Get
		  Set(ByVal value As Nullable(Of Int16))
			  smlpaqconubicacion = value
		  End Set
		End Property
		Public Property PropPAQAVISARABANDONO() As Nullable(Of Int16)
		  Get
			  Return smlpaqavisarabandono
		  End Get
		  Set(ByVal value As Nullable(Of Int16))
			  smlpaqavisarabandono = value
		  End Set
		End Property

		Public Sub New()
			LimpiaPropiedades()
		End Sub

		Public Sub LimpiaPropiedades()
			PropSECCODIGO = Nothing
			PropCUACODIGO = Nothing
			PropPAQCODIGO = Nothing
			PropTPQCODIGO = Nothing
			PropPAQFECHA = Nothing
			PropPAQESTADO = Nothing
			PropPERCODIGO = Nothing
			PropPAQNUMERO = Nothing
			PropPAQCOMENTARIO = Nothing
			PropTURCODIGO = Nothing
			PropPFICODIGO = Nothing
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
			PropPAQCONUBICACION = Nothing
			PropPAQAVISARABANDONO = Nothing
		End Sub

	End Class
End Namespace
