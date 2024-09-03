Imports System

Namespace BE

	<Serializable()> _
	Public Class CCOSUBTIPOINCIDENCIA_BE

		Private smlsticodigo As Nullable(Of Int16)
		Private vchstidescripcion As String
		Private vchstiabrevia As String
		Private smltincodigo As Nullable(Of Int16)
		Private vchsticonsejo As String
		Private smlpricodigo As Nullable(Of Int16)
        Private smlstiestado As Nullable(Of Int16)
        Private vchaudprgcreacion As String
        Private vchaudprgmodif As String
        Private vchaudeqpcreacion As String
        Private vchaudeqpmodif As String
        Private dtmaudfeccreacion As DateTime
        Private dtmaudfecmodif As DateTime
        Private vchaudusucreacion As String
        Private vchaudusumodif As String


		Public Property PropSTICODIGO() As Nullable(Of Int16)
		  Get
			  Return smlsticodigo
		  End Get
		  Set(ByVal value As Nullable(Of Int16))
			  smlsticodigo = value
		  End Set
		End Property
		Public Property PropSTIDESCRIPCION() As String
		  Get
			  Return vchstidescripcion
		  End Get
		  Set(ByVal value As String)
			  vchstidescripcion = value
		  End Set
		End Property
		Public Property PropSTIABREVIA() As String
		  Get
			  Return vchstiabrevia
		  End Get
		  Set(ByVal value As String)
			  vchstiabrevia = value
		  End Set
		End Property
		Public Property PropTINCODIGO() As Nullable(Of Int16)
		  Get
			  Return smltincodigo
		  End Get
		  Set(ByVal value As Nullable(Of Int16))
			  smltincodigo = value
		  End Set
		End Property
		Public Property PropSTICONSEJO() As String
		  Get
			  Return vchsticonsejo
		  End Get
		  Set(ByVal value As String)
			  vchsticonsejo = value
		  End Set
		End Property
		Public Property PropPRICODIGO() As Nullable(Of Int16)
		  Get
			  Return smlpricodigo
		  End Get
		  Set(ByVal value As Nullable(Of Int16))
			  smlpricodigo = value
		  End Set
		End Property
		Public Property PropSTIESTADO() As Nullable(Of Int16)
		  Get
			  Return smlstiestado
		  End Get
		  Set(ByVal value As Nullable(Of Int16))
			  smlstiestado = value
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
			PropSTICODIGO = Nothing
			PropSTIDESCRIPCION = Nothing
			PropSTIABREVIA = Nothing
			PropTINCODIGO = Nothing
			PropSTICONSEJO = Nothing
			PropPRICODIGO = Nothing
            PropSTIESTADO = Nothing
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
