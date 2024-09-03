Imports System

Namespace BE

	<Serializable()> _
	Public Class CCOINCIDENCIAPAQUETE_BE

        Private dtminpinicioatencion As String
        Private dtminpfinatencion As String
		Private intinccodigo As Nullable(Of Integer)
		Private intpaqcodigo As Nullable(Of Integer)
		Private intpincodigo As Nullable(Of Integer)
		Private intinptipo As Nullable(Of Integer)
		Private vchaudprgcreacion As String
		Private vchaudeqpcreacion As String
		Private dtmaudfeccreacion As DateTime
		Private vchaudusucreacion As String
        Private intaudrolcreacion As Nullable(Of Integer)
        Private dtmaudfecmodif As DateTime
        Private intaudrolmodif As Nullable(Of Integer)
        Private vchaudeqpmodif As String
        Private vchaudprgmodif As String
        Private vchaudusumodif As String



        Public Property PropINPINICIOATENCION() As String
            Get
                Return dtminpinicioatencion
            End Get
            Set(ByVal value As String)
                dtminpinicioatencion = value
            End Set
        End Property
        Public Property PropINPFINATENCION() As String
            Get
                Return dtminpfinatencion
            End Get
            Set(ByVal value As String)
                dtminpfinatencion = value
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
		Public Property PropPAQCODIGO() As Nullable(Of Integer)
		  Get
			  Return intpaqcodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intpaqcodigo = value
		  End Set
		End Property
		Public Property PropPINCODIGO() As Nullable(Of Integer)
		  Get
			  Return intpincodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intpincodigo = value
		  End Set
		End Property
		Public Property PropINPTIPO() As Nullable(Of Integer)
		  Get
			  Return intinptipo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intinptipo = value
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


        Public Property PropAUDROLMODIF() As Nullable(Of Integer)
            Get
                Return intaudrolmodif
            End Get
            Set(ByVal value As Nullable(Of Integer))
                intaudrolmodif = value
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
        Public Property PropAUDEQPMODIF() As String
            Get
                Return vchaudeqpmodif
            End Get
            Set(ByVal value As String)
                vchaudeqpmodif = value
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
            PropINPINICIOATENCION = Nothing
            PropINPFINATENCION = Nothing
			PropINCCODIGO = Nothing
			PropPAQCODIGO = Nothing
			PropPINCODIGO = Nothing
			PropINPTIPO = Nothing
			PropAUDPRGCREACION = Nothing
			PropAUDEQPCREACION = Nothing
			PropAUDFECCREACION = Now.Date
			PropAUDUSUCREACION = Nothing
            PropAUDROLCREACION = Nothing
            PropAUDFECMODIF = Nothing
            PropAUDROLMODIF = Nothing
            PropAUDEQPMODIF = Nothing
            PropAUDPRGMODIF = Nothing
            PropAUDUSUMODIF = Nothing

		End Sub

	End Class
End Namespace
