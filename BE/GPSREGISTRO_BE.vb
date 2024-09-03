Imports System

Namespace BE

	<Serializable()> _
	Public Class GPSREGISTRO_BE

		Private intregcodigo As Nullable(Of Integer)
		Private vchregnumero As String
		Private vchregnombre As String
		Private vchregdcmnto As String
		Private vchregemail As String
		Private smlregactivo As Nullable(Of Int16)
		Private vchaudprgcreacion As String
		Private vchaudeqpcreacion As String
		Private tmsaudfeccreacion As DateTime
		Private vchaudprgmodif As String
		Private vchaudeqpmodif As String
        Private tmsaudfecmodif As DateTime
        Private vchvernumero As String
        Private sysprocodigo As String
        Private sysprodescri As String

        Private vchINCDEVSDK As String
        Private vchINCDEVMODEL As String
        Private vchINCDEVDEVICE As String
        Private vchINCDEVHOST As String
        Private vchINCDEVID As String
        Private vchINCDEVDISPLAY As String
        Private vchINCDEVMANUFAC As String
        Private vchINCDEVUSER As String



		Public Property PropREGCODIGO() As Nullable(Of Integer)
		  Get
			  Return intregcodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intregcodigo = value
		  End Set
		End Property
		Public Property PropREGNUMERO() As String
		  Get
			  Return vchregnumero
		  End Get
		  Set(ByVal value As String)
			  vchregnumero = value
		  End Set
		End Property
		Public Property PropREGNOMBRE() As String
		  Get
			  Return vchregnombre
		  End Get
		  Set(ByVal value As String)
			  vchregnombre = value
		  End Set
		End Property
		Public Property PropREGDCMNTO() As String
		  Get
			  Return vchregdcmnto
		  End Get
		  Set(ByVal value As String)
			  vchregdcmnto = value
		  End Set
		End Property
		Public Property PropREGEMAIL() As String
		  Get
			  Return vchregemail
		  End Get
		  Set(ByVal value As String)
			  vchregemail = value
		  End Set
		End Property
		Public Property PropREGACTIVO() As Nullable(Of Int16)
		  Get
			  Return smlregactivo
		  End Get
		  Set(ByVal value As Nullable(Of Int16))
			  smlregactivo = value
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
			  Return tmsaudfeccreacion
		  End Get
		  Set(ByVal value As DateTime)
			  tmsaudfeccreacion = value
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
			  Return tmsaudfecmodif
		  End Get
		  Set(ByVal value As DateTime)
			  tmsaudfecmodif = value
		  End Set
		End Property
        Public Property PropVERNUMERO() As String
            Get
                Return vchvernumero
            End Get
            Set(ByVal value As String)
                vchvernumero = value
            End Set
        End Property


        Public Property PropPROCODIGO() As String
            Get
                Return sysprocodigo
            End Get
            Set(ByVal value As String)
                sysprocodigo = value
            End Set
        End Property

        Public Property PropPRODESCRI() As String
            Get
                Return sysprodescri
            End Get
            Set(ByVal value As String)
                sysprodescri = value
            End Set
        End Property

        Public Property PropINCDEVSDK() As String
            Get
                Return vchINCDEVSDK
            End Get
            Set(ByVal value As String)
                vchINCDEVSDK = value
            End Set
        End Property

        Public Property PropINCDEVMODEL() As String
            Get
                Return vchINCDEVMODEL
            End Get
            Set(ByVal value As String)
                vchINCDEVMODEL = value
            End Set
        End Property

        Public Property PropINCDEVDEVICE() As String
            Get
                Return vchINCDEVDEVICE
            End Get
            Set(ByVal value As String)
                vchINCDEVDEVICE = value
            End Set
        End Property

        Public Property PropINCDEVHOST() As String
            Get
                Return vchINCDEVHOST
            End Get
            Set(ByVal value As String)
                vchINCDEVHOST = value
            End Set
        End Property

        Public Property PropINCDEVID() As String
            Get
                Return vchINCDEVID
            End Get
            Set(ByVal value As String)
                vchINCDEVID = value
            End Set
        End Property

        Public Property PropINCDEVDISPLAY() As String
            Get
                Return vchINCDEVDISPLAY
            End Get
            Set(ByVal value As String)
                vchINCDEVDISPLAY = value
            End Set
        End Property

        Public Property PropINCDEVMANUFAC() As String
            Get
                Return vchINCDEVMANUFAC
            End Get
            Set(ByVal value As String)
                vchINCDEVMANUFAC = value
            End Set
        End Property

        Public Property PropINCDEVUSER() As String
            Get
                Return vchINCDEVUSER
            End Get
            Set(ByVal value As String)
                vchINCDEVUSER = value
            End Set
        End Property

		Public Sub New()
			LimpiaPropiedades()
		End Sub

		Public Sub LimpiaPropiedades()
			PropREGCODIGO = Nothing
			PropREGNUMERO = Nothing
			PropREGNOMBRE = Nothing
			PropREGDCMNTO = Nothing
			PropREGEMAIL = Nothing
			PropREGACTIVO = Nothing
			PropAUDPRGCREACION = Nothing
			PropAUDEQPCREACION = Nothing
			PropAUDFECCREACION = Now.Date
			PropAUDPRGMODIF = Nothing
			PropAUDEQPMODIF = Nothing
            PropAUDFECMODIF = Now.Date
            PropVERNUMERO = Nothing
            PropPROCODIGO = Nothing
            PropPRODESCRI = Nothing

            PropINCDEVSDK = Nothing
            PropINCDEVMODEL = Nothing
            PropINCDEVDEVICE = Nothing
            PropINCDEVHOST = Nothing
            PropINCDEVID = Nothing
            PropINCDEVDISPLAY = Nothing
            PropINCDEVMANUFAC = Nothing
            PropINCDEVUSER = Nothing

		End Sub

	End Class
End Namespace
