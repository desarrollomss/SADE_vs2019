Imports System

Namespace BE

    <Serializable()> _
    Public Class CCOPERSONAL_BE

        Private intpercodigo As Nullable(Of Integer)
        Private vchperapellidopaterno As String
        Private vchperapellidomaterno As String
        Private vchpernombre As String
        Private vchpertelefono1 As String
        Private vchpertelefono2 As String
        Private vchpertelefono3 As String
        Private smlperestado As Nullable(Of Int16)
        Private smlcrgcodigo As Nullable(Of Int16)
        Private smlseccodigo As Nullable(Of Int16)
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
        Private smlssecodigo As Nullable(Of Int16)
        Private vchperdni As String
        Private vchperruc As String
        Private datperfecnacimiento As Nullable(Of DateTime)
        Private vchperlugnacimiento As String
        Private vchperdireccion As String
        Private vchperhaburbana As String
        Private vchpercorreo As String
        Private vchpercuentabanco As String
        Private vchperprofesion As String
        Private smlperlicenciado As Nullable(Of Int16)
        Private vchperfuerzaarmada As String
        Private vchperlibretamilitar As String
        Private vchpernumeroafp As String
        Private vchpernumeroessalud As String
        Private vchpersunat4ta As String
        Private vchpergruposanguineo As String
        Private decpertalla As Nullable(Of Decimal)
        Private decperpeso As Nullable(Of Decimal)
        Private vchpercursos As String
        Private datperfecingmuni As Nullable(Of DateTime)
        Private datperfecingarea As Nullable(Of DateTime)
        Private datperfecingmodal As Nullable(Of DateTime)
        Private datperfecingsector As Nullable(Of DateTime)
        Private datperfecingcargo As Nullable(Of DateTime)
        Private decpersueldo As Nullable(Of Decimal)
        Private vchpernumebrevauto As String
        Private datperrevabrevauto As Nullable(Of DateTime)
        Private vchperrestbrevauto As String
        Private vchpernumebrevmoto As String
        Private datperrevabrevmoto As Nullable(Of DateTime)
        Private vchperrestbrevmoto As String
        Private blbperfoto As Object
        Private smlecicodigo As Nullable(Of Int16)
        Private smlgincodigo As Nullable(Of Int16)
        Private smlafpcodigo As Nullable(Of Int16)
        Private smlsbgcodigo As Nullable(Of Int16)
        Private smlmodcodigo As Nullable(Of Int16)
        Private smlrancodigo As Nullable(Of Int16)
        Private smlcaucodigo As Nullable(Of Int16)
        Private smlcmocodigo As Nullable(Of Int16)
        Private chrubicodigo As String
        Private datperfecestado As Nullable(Of DateTime)
        Private intturcodigo As Nullable(Of Integer)

        Public Property PropPERCODIGO() As Nullable(Of Integer)
            Get
                Return intpercodigo
            End Get
            Set(ByVal value As Nullable(Of Integer))
                intpercodigo = value
            End Set
        End Property
        Public Property PropPERAPELLIDOPATERNO() As String
            Get
                Return vchperapellidopaterno
            End Get
            Set(ByVal value As String)
                vchperapellidopaterno = value
            End Set
        End Property
        Public Property PropPERAPELLIDOMATERNO() As String
            Get
                Return vchperapellidomaterno
            End Get
            Set(ByVal value As String)
                vchperapellidomaterno = value
            End Set
        End Property
        Public Property PropPERNOMBRE() As String
            Get
                Return vchpernombre
            End Get
            Set(ByVal value As String)
                vchpernombre = value
            End Set
        End Property
        Public Property PropPERTELEFONO1() As String
            Get
                Return vchpertelefono1
            End Get
            Set(ByVal value As String)
                vchpertelefono1 = value
            End Set
        End Property
        Public Property PropPERTELEFONO2() As String
            Get
                Return vchpertelefono2
            End Get
            Set(ByVal value As String)
                vchpertelefono2 = value
            End Set
        End Property
        Public Property PropPERTELEFONO3() As String
            Get
                Return vchpertelefono3
            End Get
            Set(ByVal value As String)
                vchpertelefono3 = value
            End Set
        End Property
        Public Property PropPERESTADO() As Nullable(Of Int16)
            Get
                Return smlperestado
            End Get
            Set(ByVal value As Nullable(Of Int16))
                smlperestado = value
            End Set
        End Property
        Public Property PropCRGCODIGO() As Nullable(Of Int16)
            Get
                Return smlcrgcodigo
            End Get
            Set(ByVal value As Nullable(Of Int16))
                smlcrgcodigo = value
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
        Public Property PropSSECODIGO() As Nullable(Of Int16)
            Get
                Return smlssecodigo
            End Get
            Set(ByVal value As Nullable(Of Int16))
                smlssecodigo = value
            End Set
        End Property
        Public Property PropPERDNI() As String
            Get
                Return vchperdni
            End Get
            Set(ByVal value As String)
                vchperdni = value
            End Set
        End Property
        Public Property PropPERRUC() As String
            Get
                Return vchperruc
            End Get
            Set(ByVal value As String)
                vchperruc = value
            End Set
        End Property
        Public Property PropPERFECNACIMIENTO() As Nullable(Of DateTime)
            Get
                Return datperfecnacimiento
            End Get
            Set(ByVal value As Nullable(Of DateTime))
                datperfecnacimiento = value
            End Set
        End Property
        Public Property PropPERLUGNACIMIENTO() As String
            Get
                Return vchperlugnacimiento
            End Get
            Set(ByVal value As String)
                vchperlugnacimiento = value
            End Set
        End Property
        Public Property PropPERDIRECCION() As String
            Get
                Return vchperdireccion
            End Get
            Set(ByVal value As String)
                vchperdireccion = value
            End Set
        End Property
        Public Property PropPERHABURBANA() As String
            Get
                Return vchperhaburbana
            End Get
            Set(ByVal value As String)
                vchperhaburbana = value
            End Set
        End Property
        Public Property PropPERCORREO() As String
            Get
                Return vchpercorreo
            End Get
            Set(ByVal value As String)
                vchpercorreo = value
            End Set
        End Property
        Public Property PropPERCUENTABANCO() As String
            Get
                Return vchpercuentabanco
            End Get
            Set(ByVal value As String)
                vchpercuentabanco = value
            End Set
        End Property
        Public Property PropPERPROFESION() As String
            Get
                Return vchperprofesion
            End Get
            Set(ByVal value As String)
                vchperprofesion = value
            End Set
        End Property
        Public Property PropPERLICENCIADO() As Nullable(Of Int16)
            Get
                Return smlperlicenciado
            End Get
            Set(ByVal value As Nullable(Of Int16))
                smlperlicenciado = value
            End Set
        End Property
        Public Property PropPERFUERZAARMADA() As String
            Get
                Return vchperfuerzaarmada
            End Get
            Set(ByVal value As String)
                vchperfuerzaarmada = value
            End Set
        End Property
        Public Property PropPERLIBRETAMILITAR() As String
            Get
                Return vchperlibretamilitar
            End Get
            Set(ByVal value As String)
                vchperlibretamilitar = value
            End Set
        End Property
        Public Property PropPERNUMEROAFP() As String
            Get
                Return vchpernumeroafp
            End Get
            Set(ByVal value As String)
                vchpernumeroafp = value
            End Set
        End Property
        Public Property PropPERNUMEROESSALUD() As String
            Get
                Return vchpernumeroessalud
            End Get
            Set(ByVal value As String)
                vchpernumeroessalud = value
            End Set
        End Property
        Public Property PropPERSUNAT4TA() As String
            Get
                Return vchpersunat4ta
            End Get
            Set(ByVal value As String)
                vchpersunat4ta = value
            End Set
        End Property
        Public Property PropPERGRUPOSANGUINEO() As String
            Get
                Return vchpergruposanguineo
            End Get
            Set(ByVal value As String)
                vchpergruposanguineo = value
            End Set
        End Property
        Public Property PropPERTALLA() As Nullable(Of Decimal)
            Get
                Return decpertalla
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                decpertalla = value
            End Set
        End Property
        Public Property PropPERPESO() As Nullable(Of Decimal)
            Get
                Return decperpeso
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                decperpeso = value
            End Set
        End Property
        Public Property PropPERCURSOS() As String
            Get
                Return vchpercursos
            End Get
            Set(ByVal value As String)
                vchpercursos = value
            End Set
        End Property
        Public Property PropPERFECINGMUNI() As Nullable(Of DateTime)
            Get
                Return datperfecingmuni
            End Get
            Set(ByVal value As Nullable(Of DateTime))
                datperfecingmuni = value
            End Set
        End Property
        Public Property PropPERFECINGAREA() As Nullable(Of DateTime)
            Get
                Return datperfecingarea
            End Get
            Set(ByVal value As Nullable(Of DateTime))
                datperfecingarea = value
            End Set
        End Property
        Public Property PropPERFECINGMODAL() As Nullable(Of DateTime)
            Get
                Return datperfecingmodal
            End Get
            Set(ByVal value As Nullable(Of DateTime))
                datperfecingmodal = value
            End Set
        End Property
        Public Property PropPERFECINGSECTOR() As Nullable(Of DateTime)
            Get
                Return datperfecingsector
            End Get
            Set(ByVal value As Nullable(Of DateTime))
                datperfecingsector = value
            End Set
        End Property
        Public Property PropPERFECINGCARGO() As Nullable(Of DateTime)
            Get
                Return datperfecingcargo
            End Get
            Set(ByVal value As Nullable(Of DateTime))
                datperfecingcargo = value
            End Set
        End Property
        Public Property PropPERSUELDO() As Nullable(Of Decimal)
            Get
                Return decpersueldo
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                decpersueldo = value
            End Set
        End Property
        Public Property PropPERNUMEBREVAUTO() As String
            Get
                Return vchpernumebrevauto
            End Get
            Set(ByVal value As String)
                vchpernumebrevauto = value
            End Set
        End Property
        Public Property PropPERREVABREVAUTO() As Nullable(Of DateTime)
            Get
                Return datperrevabrevauto
            End Get
            Set(ByVal value As Nullable(Of DateTime))
                datperrevabrevauto = value
            End Set
        End Property
        Public Property PropPERRESTBREVAUTO() As String
            Get
                Return vchperrestbrevauto
            End Get
            Set(ByVal value As String)
                vchperrestbrevauto = value
            End Set
        End Property
        Public Property PropPERNUMEBREVMOTO() As String
            Get
                Return vchpernumebrevmoto
            End Get
            Set(ByVal value As String)
                vchpernumebrevmoto = value
            End Set
        End Property
        Public Property PropPERREVABREVMOTO() As Nullable(Of DateTime)
            Get
                Return datperrevabrevmoto
            End Get
            Set(ByVal value As Nullable(Of DateTime))
                datperrevabrevmoto = value
            End Set
        End Property
        Public Property PropPERRESTBREVMOTO() As String
            Get
                Return vchperrestbrevmoto
            End Get
            Set(ByVal value As String)
                vchperrestbrevmoto = value
            End Set
        End Property
        Public Property PropPERFOTO() As Object
            Get
                Return blbperfoto
            End Get
            Set(ByVal value As Object)
                blbperfoto = value
            End Set
        End Property
        Public Property PropECICODIGO() As Nullable(Of Int16)
            Get
                Return smlecicodigo
            End Get
            Set(ByVal value As Nullable(Of Int16))
                smlecicodigo = value
            End Set
        End Property
        Public Property PropGINCODIGO() As Nullable(Of Int16)
            Get
                Return smlgincodigo
            End Get
            Set(ByVal value As Nullable(Of Int16))
                smlgincodigo = value
            End Set
        End Property
        Public Property PropAFPCODIGO() As Nullable(Of Int16)
            Get
                Return smlafpcodigo
            End Get
            Set(ByVal value As Nullable(Of Int16))
                smlafpcodigo = value
            End Set
        End Property
        Public Property PropSBGCODIGO() As Nullable(Of Int16)
            Get
                Return smlsbgcodigo
            End Get
            Set(ByVal value As Nullable(Of Int16))
                smlsbgcodigo = value
            End Set
        End Property
        Public Property PropMODCODIGO() As Nullable(Of Int16)
            Get
                Return smlmodcodigo
            End Get
            Set(ByVal value As Nullable(Of Int16))
                smlmodcodigo = value
            End Set
        End Property
        Public Property PropRANCODIGO() As Nullable(Of Int16)
            Get
                Return smlrancodigo
            End Get
            Set(ByVal value As Nullable(Of Int16))
                smlrancodigo = value
            End Set
        End Property
        Public Property PropCAUCODIGO() As Nullable(Of Int16)
            Get
                Return smlcaucodigo
            End Get
            Set(ByVal value As Nullable(Of Int16))
                smlcaucodigo = value
            End Set
        End Property
        Public Property PropCMOCODIGO() As Nullable(Of Int16)
            Get
                Return smlcmocodigo
            End Get
            Set(ByVal value As Nullable(Of Int16))
                smlcmocodigo = value
            End Set
        End Property
        Public Property PropUBICODIGO() As String
            Get
                Return chrubicodigo
            End Get
            Set(ByVal value As String)
                chrubicodigo = value
            End Set
        End Property
        Public Property PropPERFECESTADO() As Nullable(Of DateTime)
            Get
                Return datperfecestado
            End Get
            Set(ByVal value As Nullable(Of DateTime))
                datperfecestado = value
            End Set
        End Property
        Public Property Propturcodigo() As Nullable(Of Integer)
            Get
                Return intturcodigo
            End Get
            Set(value As Nullable(Of Integer))
                intturcodigo = value
            End Set

        End Property


        Public Sub New()
            LimpiaPropiedades()
        End Sub

        Public Sub LimpiaPropiedades()
            PropPERCODIGO = Nothing
            PropPERAPELLIDOPATERNO = Nothing
            PropPERAPELLIDOMATERNO = Nothing
            PropPERNOMBRE = Nothing
            PropPERTELEFONO1 = Nothing
            PropPERTELEFONO2 = Nothing
            PropPERTELEFONO3 = Nothing
            PropPERESTADO = Nothing
            PropCRGCODIGO = Nothing
            PropSECCODIGO = Nothing
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
            PropSSECODIGO = Nothing
            PropPERDNI = Nothing
            PropPERRUC = Nothing
            PropPERFECNACIMIENTO = Nothing
            PropPERLUGNACIMIENTO = Nothing
            PropPERDIRECCION = Nothing
            PropPERHABURBANA = Nothing
            PropPERCORREO = Nothing
            PropPERCUENTABANCO = Nothing
            PropPERPROFESION = Nothing
            PropPERLICENCIADO = Nothing
            PropPERFUERZAARMADA = Nothing
            PropPERLIBRETAMILITAR = Nothing
            PropPERNUMEROAFP = Nothing
            PropPERNUMEROESSALUD = Nothing
            PropPERSUNAT4TA = Nothing
            PropPERGRUPOSANGUINEO = Nothing
            PropPERTALLA = Nothing
            PropPERPESO = Nothing
            PropPERCURSOS = Nothing
            PropPERFECINGMUNI = Nothing
            PropPERFECINGAREA = Nothing
            PropPERFECINGMODAL = Nothing
            PropPERFECINGSECTOR = Nothing
            PropPERFECINGCARGO = Nothing
            PropPERSUELDO = Nothing
            PropPERNUMEBREVAUTO = Nothing
            PropPERREVABREVAUTO = Nothing
            PropPERRESTBREVAUTO = Nothing
            PropPERNUMEBREVMOTO = Nothing
            PropPERREVABREVMOTO = Nothing
            PropPERRESTBREVMOTO = Nothing
            PropPERFOTO = Nothing
            PropECICODIGO = Nothing
            PropGINCODIGO = Nothing
            PropAFPCODIGO = Nothing
            PropSBGCODIGO = Nothing
            PropMODCODIGO = Nothing
            PropRANCODIGO = Nothing
            PropCAUCODIGO = Nothing
            PropCMOCODIGO = Nothing
            PropUBICODIGO = Nothing
            PropPERFECESTADO = Nothing
            Propturcodigo = Nothing
        End Sub

    End Class
End Namespace
