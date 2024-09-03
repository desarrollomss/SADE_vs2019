Imports System

Namespace BE

	<Serializable()> _
	Public Class CCOPARTEDIARIO_BE

		Private intinccodigo As Nullable(Of Integer)
		Private intincagresores As Nullable(Of Integer)
		Private vchincconsecuencia As String
		Private intobjcodigo As Nullable(Of Integer)
		Private intmodcodigo As Nullable(Of Integer)
		Private intintcodigo As Nullable(Of Integer)
		Private vchaudprgcreacion As String
		Private vchaudeqpcreacion As String
		Private dtmaudfeccreacion As DateTime
		Private vchaudusucreacion As String
        Private intaudrolcreacion As Nullable(Of Integer)
        Private intpercodoperador As Nullable(Of Integer)
        Private intpercodsereno As Nullable(Of Integer)
        Private smlfugacodigo As Nullable(Of Integer)
        Private smlturnocodigo As Nullable(Of Integer)
        Private dtmfinatencion As String
        Private smltipodelito As Nullable(Of Integer)


		Public Property PropINCCODIGO() As Nullable(Of Integer)
		  Get
			  Return intinccodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intinccodigo = value
		  End Set
		End Property
		Public Property PropINCAGRESORES() As Nullable(Of Integer)
		  Get
			  Return intincagresores
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intincagresores = value
		  End Set
		End Property
		Public Property PropINCCONSECUENCIA() As String
		  Get
			  Return vchincconsecuencia
		  End Get
		  Set(ByVal value As String)
			  vchincconsecuencia = value
		  End Set
		End Property
		Public Property PropOBJCODIGO() As Nullable(Of Integer)
		  Get
			  Return intobjcodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intobjcodigo = value
		  End Set
		End Property
		Public Property PropMODCODIGO() As Nullable(Of Integer)
		  Get
			  Return intmodcodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intmodcodigo = value
		  End Set
		End Property
		Public Property PropINTCODIGO() As Nullable(Of Integer)
		  Get
			  Return intintcodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intintcodigo = value
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


        Public Property PropPERCODOPERADOR() As Nullable(Of Integer)
            Get
                Return intpercodoperador
            End Get
            Set(ByVal value As Nullable(Of Integer))
                intpercodoperador = value
            End Set
        End Property
        Public Property PropPERCODSERENO() As Nullable(Of Integer)
            Get
                Return intpercodsereno
            End Get
            Set(ByVal value As Nullable(Of Integer))
                intpercodsereno = value
            End Set
        End Property
        Public Property PropFUGACODIGO() As Nullable(Of Integer)
            Get
                Return smlfugacodigo
            End Get
            Set(ByVal value As Nullable(Of Integer))
                smlfugacodigo = value
            End Set
        End Property

        Public Property PropTURNOCODIGO() As Nullable(Of Integer)
            Get
                Return smlturnocodigo
            End Get
            Set(ByVal value As Nullable(Of Integer))
                smlturnocodigo = value
            End Set
        End Property

        Public Property PropFINATENCION() As String
            Get
                Return dtmfinatencion
            End Get
            Set(ByVal value As String)
                dtmfinatencion = value
            End Set
        End Property

        Public Property PropTIPODELITO() As Nullable(Of Integer)
            Get
                Return SMLTIPODELITO
            End Get
            Set(ByVal value As Nullable(Of Integer))
                SMLTIPODELITO = value
            End Set
        End Property

        Public Sub New()
            LimpiaPropiedades()
        End Sub

		Public Sub LimpiaPropiedades()
			PropINCCODIGO = Nothing
			PropINCAGRESORES = Nothing
			PropINCCONSECUENCIA = Nothing
			PropOBJCODIGO = Nothing
			PropMODCODIGO = Nothing
			PropINTCODIGO = Nothing
			PropAUDPRGCREACION = Nothing
			PropAUDEQPCREACION = Nothing
			PropAUDFECCREACION = Now.Date
			PropAUDUSUCREACION = Nothing
            PropAUDROLCREACION = Nothing
            PropFINATENCION = Nothing
            PropFUGACODIGO = Nothing
            PropPERCODOPERADOR = Nothing
            PropPERCODSERENO = Nothing
            PropTURNOCODIGO = Nothing
            PropTIPODELITO = Nothing

        End Sub

	End Class
End Namespace
