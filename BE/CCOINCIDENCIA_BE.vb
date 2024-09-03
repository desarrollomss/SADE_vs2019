Imports System
'--prueba
Namespace BE

    <Serializable()> _
    Public Class CCOINCIDENCIA_BE

        Private intinccodigo As Nullable(Of Integer)
        Private vchincnumeroorigen As String
        Private vchinccomentario As String
        Private vchinclocviacodigo1 As String
        Private vchinclocvianombre1 As String
        Private vchinclocviacodigo2 As String
        Private vchinclocvianombre2 As String
        Private vchinclocnumero As String
        Private vchincloccuadra As String
        Private vchinclocmanzana As String
        Private vchincloclote As String
        Private vchinclocdpto As String
        Private vchinclocblock As String
        Private chrinclochabcodigo As String
        Private vchinclochabnombre As String
        Private smlinclocsector As Nullable(Of Int16)
        Private smlincloccuadrante As Nullable(Of Int16)
        Private vchincloccomentario As String
        Private vchincrelato As String
        Private smlincanonimo As Nullable(Of Int16)
        Private vchincnombre As String
        Private vchincapellidos As String
        Private vchincnombrecomp As String
        Private vchincdocumento As String
        Private vchincllaviacodigo As String
        Private vchincllavianombre As String
        Private vchincllanumero As String
        Private vchincllamanzana As String
        Private vchincllalote As String
        Private vchinclladpto As String
        Private vchincllablock As String
        Private chrincllahabcodigo As String
        Private vchincllahabnombre As String
        Private smlincllasector As Nullable(Of Int16)
        Private smlincllacuadrante As Nullable(Of Int16)
        Private vchincllacomentario As String
        Private vchincresultado As String
        Private smlincestado As Nullable(Of Int16)
        Private dtmaudfeccreacion As DateTime
        Private dtmaudfecmodif As DateTime
        Private vchaudusucreacion As String
        Private vchaudusumodif As String
        Private intincacodigo As Nullable(Of Integer)
        Private intincanumero As Nullable(Of Integer)
        Private intadmcodigo As Nullable(Of Integer)
        Private intprecodigo As Nullable(Of Integer)
        Private vchincidlatitude As String
        Private vchincidlongitude As String
        Private smloricodigo As Nullable(Of Int16)
        Private smltincodigo As Nullable(Of Int16)
        Private smlsticodigo As Nullable(Of Int16)
        Private smlpricodigo As Nullable(Of Int16)
        Private smltpecodigo As Nullable(Of Int16)
        Private vchtidcodigo As String
        Private smlincintervenidos As Nullable(Of Int16)
        Private intpaqcodigo As Nullable(Of Integer)
        Private intpincodigo As Nullable(Of Integer)
        Private intaudrolcreacion As Nullable(Of Integer)
        Private intaudrolmodif As Nullable(Of Integer)
        Private vchincusuderivado As String
        Private intincrolderivado As Nullable(Of Integer)
        Private dtmincfecderivado As DateTime
        Private smlrescodigo As Nullable(Of Int16)
        Private vchaudprgcreacion As String
        Private vchaudprgmodif As String
        Private vchaudeqpcreacion As String
        Private vchaudeqpmodif As String
        Private vchcatcodigo As String
        Private dtmincfecha As DateTime
        Private vchincidanexo As String
        Private vchincidllamada As String
        Private vchincllacuadra As String
        Private smlincpartepolicial As Nullable(Of Int16)
        Private vchmotivoalerta As String
        Private vchcodqueja As String
        Private vchinclocxgeo As String
        Private vchinclocygeo As String
        Private vchincloccuadrante As String
        Private vchinclocsector As String
        'Private intinccodigoapp As Nullable(Of Integer)
        Private vchinccodigoapp As String
        Private vchincarchivourl As String

        Public Property PropINCCODIGO() As Nullable(Of Integer)
            Get
                Return intinccodigo
            End Get
            Set(ByVal value As Nullable(Of Integer))
                intinccodigo = value
            End Set
        End Property
        Public Property PropINCNUMEROORIGEN() As String
            Get
                Return vchincnumeroorigen
            End Get
            Set(ByVal value As String)
                vchincnumeroorigen = value
            End Set
        End Property
        Public Property PropINCCOMENTARIO() As String
            Get
                Return vchinccomentario
            End Get
            Set(ByVal value As String)
                vchinccomentario = value
            End Set
        End Property
        Public Property PropINCLOCVIACODIGO1() As String
            Get
                Return vchinclocviacodigo1
            End Get
            Set(ByVal value As String)
                vchinclocviacodigo1 = value
            End Set
        End Property
        Public Property PropINCLOCVIANOMBRE1() As String
            Get
                Return vchinclocvianombre1
            End Get
            Set(ByVal value As String)
                vchinclocvianombre1 = value
            End Set
        End Property
        Public Property PropINCLOCVIACODIGO2() As String
            Get
                Return vchinclocviacodigo2
            End Get
            Set(ByVal value As String)
                vchinclocviacodigo2 = value
            End Set
        End Property
        Public Property PropINCLOCVIANOMBRE2() As String
            Get
                Return vchinclocvianombre2
            End Get
            Set(ByVal value As String)
                vchinclocvianombre2 = value
            End Set
        End Property
        Public Property PropINCLOCNUMERO() As String
            Get
                Return vchinclocnumero
            End Get
            Set(ByVal value As String)
                vchinclocnumero = value
            End Set
        End Property
        Public Property PropINCLOCCUADRA() As String
            Get
                Return vchincloccuadra
            End Get
            Set(ByVal value As String)
                vchincloccuadra = value
            End Set
        End Property
        Public Property PropINCLOCMANZANA() As String
            Get
                Return vchinclocmanzana
            End Get
            Set(ByVal value As String)
                vchinclocmanzana = value
            End Set
        End Property
        Public Property PropINCLOCLOTE() As String
            Get
                Return vchincloclote
            End Get
            Set(ByVal value As String)
                vchincloclote = value
            End Set
        End Property
        Public Property PropINCLOCDPTO() As String
            Get
                Return vchinclocdpto
            End Get
            Set(ByVal value As String)
                vchinclocdpto = value
            End Set
        End Property
        Public Property PropINCLOCBLOCK() As String
            Get
                Return vchinclocblock
            End Get
            Set(ByVal value As String)
                vchinclocblock = value
            End Set
        End Property
        Public Property PropINCLOCHABCODIGO() As String
            Get
                Return chrinclochabcodigo
            End Get
            Set(ByVal value As String)
                chrinclochabcodigo = value
            End Set
        End Property
        Public Property PropINCLOCHABNOMBRE() As String
            Get
                Return vchinclochabnombre
            End Get
            Set(ByVal value As String)
                vchinclochabnombre = value
            End Set
        End Property
        Public Property PropINCLOCSECTOR() As Nullable(Of Int16)
            Get
                Return smlinclocsector
            End Get
            Set(ByVal value As Nullable(Of Int16))
                smlinclocsector = value
            End Set
        End Property
        Public Property PropINCLOCCUADRANTE() As Nullable(Of Int16)
            Get
                Return smlincloccuadrante
            End Get
            Set(ByVal value As Nullable(Of Int16))
                smlincloccuadrante = value
            End Set
        End Property
        Public Property PropINCLOCCOMENTARIO() As String
            Get
                Return vchincloccomentario
            End Get
            Set(ByVal value As String)
                vchincloccomentario = value
            End Set
        End Property
        Public Property PropINCRELATO() As String
            Get
                Return vchincrelato
            End Get
            Set(ByVal value As String)
                vchincrelato = value
            End Set
        End Property
        Public Property PropINCANONIMO() As Nullable(Of Int16)
            Get
                Return smlincanonimo
            End Get
            Set(ByVal value As Nullable(Of Int16))
                smlincanonimo = value
            End Set
        End Property
        Public Property PropINCNOMBRE() As String
            Get
                Return vchincnombre
            End Get
            Set(ByVal value As String)
                vchincnombre = value
            End Set
        End Property
        Public Property PropINCAPELLIDOS() As String
            Get
                Return vchincapellidos
            End Get
            Set(ByVal value As String)
                vchincapellidos = value
            End Set
        End Property
        Public Property PropINCNOMBRECOMP() As String
            Get
                Return vchincnombrecomp
            End Get
            Set(ByVal value As String)
                vchincnombrecomp = value
            End Set
        End Property
        Public Property PropINCDOCUMENTO() As String
            Get
                Return vchincdocumento
            End Get
            Set(ByVal value As String)
                vchincdocumento = value
            End Set
        End Property
        Public Property PropINCLLAVIACODIGO() As String
            Get
                Return vchincllaviacodigo
            End Get
            Set(ByVal value As String)
                vchincllaviacodigo = value
            End Set
        End Property
        Public Property PropINCLLAVIANOMBRE() As String
            Get
                Return vchincllavianombre
            End Get
            Set(ByVal value As String)
                vchincllavianombre = value
            End Set
        End Property
        Public Property PropINCLLANUMERO() As String
            Get
                Return vchincllanumero
            End Get
            Set(ByVal value As String)
                vchincllanumero = value
            End Set
        End Property
        Public Property PropINCLLAMANZANA() As String
            Get
                Return vchincllamanzana
            End Get
            Set(ByVal value As String)
                vchincllamanzana = value
            End Set
        End Property
        Public Property PropINCLLALOTE() As String
            Get
                Return vchincllalote
            End Get
            Set(ByVal value As String)
                vchincllalote = value
            End Set
        End Property
        Public Property PropINCLLADPTO() As String
            Get
                Return vchinclladpto
            End Get
            Set(ByVal value As String)
                vchinclladpto = value
            End Set
        End Property
        Public Property PropINCLLABLOCK() As String
            Get
                Return vchincllablock
            End Get
            Set(ByVal value As String)
                vchincllablock = value
            End Set
        End Property
        Public Property PropINCLLAHABCODIGO() As String
            Get
                Return chrincllahabcodigo
            End Get
            Set(ByVal value As String)
                chrincllahabcodigo = value
            End Set
        End Property
        Public Property PropINCLLAHABNOMBRE() As String
            Get
                Return vchincllahabnombre
            End Get
            Set(ByVal value As String)
                vchincllahabnombre = value
            End Set
        End Property
        Public Property PropINCLLASECTOR() As Nullable(Of Int16)
            Get
                Return smlincllasector
            End Get
            Set(ByVal value As Nullable(Of Int16))
                smlincllasector = value
            End Set
        End Property
        Public Property PropINCLLACUADRANTE() As Nullable(Of Int16)
            Get
                Return smlincllacuadrante
            End Get
            Set(ByVal value As Nullable(Of Int16))
                smlincllacuadrante = value
            End Set
        End Property
        Public Property PropINCLLACOMENTARIO() As String
            Get
                Return vchincllacomentario
            End Get
            Set(ByVal value As String)
                vchincllacomentario = value
            End Set
        End Property
        Public Property PropINCRESULTADO() As String
            Get
                Return vchincresultado
            End Get
            Set(ByVal value As String)
                vchincresultado = value
            End Set
        End Property
        Public Property PropINCESTADO() As Nullable(Of Int16)
            Get
                Return smlincestado
            End Get
            Set(ByVal value As Nullable(Of Int16))
                smlincestado = value
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
        Public Property PropINCACODIGO() As Nullable(Of Integer)
            Get
                Return intincacodigo
            End Get
            Set(ByVal value As Nullable(Of Integer))
                intincacodigo = value
            End Set
        End Property
        Public Property PropINCANUMERO() As Nullable(Of Integer)
            Get
                Return intincanumero
            End Get
            Set(ByVal value As Nullable(Of Integer))
                intincanumero = value
            End Set
        End Property
        Public Property PropADMCODIGO() As Nullable(Of Integer)
            Get
                Return intadmcodigo
            End Get
            Set(ByVal value As Nullable(Of Integer))
                intadmcodigo = value
            End Set
        End Property
        Public Property PropPRECODIGO() As Nullable(Of Integer)
            Get
                Return intprecodigo
            End Get
            Set(ByVal value As Nullable(Of Integer))
                intprecodigo = value
            End Set
        End Property
        Public Property PropINCIDLATITUDE() As String
            Get
                Return vchincidlatitude
            End Get
            Set(ByVal value As String)
                vchincidlatitude = value
            End Set
        End Property
        Public Property PropINCIDLONGITUDE() As String
            Get
                Return vchincidlongitude
            End Get
            Set(ByVal value As String)
                vchincidlongitude = value
            End Set
        End Property
        Public Property PropORICODIGO() As Nullable(Of Int16)
            Get
                Return smloricodigo
            End Get
            Set(ByVal value As Nullable(Of Int16))
                smloricodigo = value
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
        Public Property PropSTICODIGO() As Nullable(Of Int16)
            Get
                Return smlsticodigo
            End Get
            Set(ByVal value As Nullable(Of Int16))
                smlsticodigo = value
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
        Public Property PropTPECODIGO() As Nullable(Of Int16)
            Get
                Return smltpecodigo
            End Get
            Set(ByVal value As Nullable(Of Int16))
                smltpecodigo = value
            End Set
        End Property
        Public Property PropTIDCODIGO() As String
            Get
                Return vchtidcodigo
            End Get
            Set(ByVal value As String)
                vchtidcodigo = value
            End Set
        End Property
        Public Property PropINCINTERVENIDOS() As Nullable(Of Int16)
            Get
                Return smlincintervenidos
            End Get
            Set(ByVal value As Nullable(Of Int16))
                smlincintervenidos = value
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
        Public Property PropINCUSUDERIVADO() As String
            Get
                Return vchincusuderivado
            End Get
            Set(ByVal value As String)
                vchincusuderivado = value
            End Set
        End Property
        Public Property PropINCROLDERIVADO() As Nullable(Of Integer)
            Get
                Return intincrolderivado
            End Get
            Set(ByVal value As Nullable(Of Integer))
                intincrolderivado = value
            End Set
        End Property
        Public Property PropINCFECDERIVADO() As DateTime
            Get
                Return dtmincfecderivado
            End Get
            Set(ByVal value As DateTime)
                dtmincfecderivado = value
            End Set
        End Property
        Public Property PropRESCODIGO() As Nullable(Of Int16)
            Get
                Return smlrescodigo
            End Get
            Set(ByVal value As Nullable(Of Int16))
                smlrescodigo = value
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
        Public Property PropCATCODIGO() As String
            Get
                Return vchcatcodigo
            End Get
            Set(ByVal value As String)
                vchcatcodigo = value
            End Set
        End Property
        Public Property PropINCFECHA() As DateTime
            Get
                Return dtmincfecha
            End Get
            Set(ByVal value As DateTime)
                dtmincfecha = value
            End Set
        End Property
        Public Property PropINCIDANEXO() As String
            Get
                Return vchincidanexo
            End Get
            Set(ByVal value As String)
                vchincidanexo = value
            End Set
        End Property
        Public Property PropINCIDLLAMADA() As String
            Get
                Return vchincidllamada
            End Get
            Set(ByVal value As String)
                vchincidllamada = value
            End Set
        End Property

        Public Property PropINCLLACUADRA() As String
            Get
                Return vchincllacuadra
            End Get
            Set(ByVal value As String)
                vchincllacuadra = value
            End Set
        End Property

        Public Property PropINCPARTEPOLICIAL() As Nullable(Of Int16)
            Get
                Return smlrescodigo
            End Get
            Set(ByVal value As Nullable(Of Int16))
                smlrescodigo = value
            End Set
        End Property


        Public Property PropVCHMOTIVOALERTA() As String
            Get
                Return vchmotivoalerta
            End Get
            Set(ByVal value As String)
                vchmotivoalerta = value
            End Set
        End Property

        Public Property PropVCHCODQUEJA() As String
            Get
                Return vchcodqueja
            End Get
            Set(ByVal value As String)
                vchcodqueja = value
            End Set
        End Property

        Public Property PropVCHINCLOCSECTOR() As String
            Get
                Return vchinclocsector
            End Get
            Set(ByVal value As String)
                vchinclocsector = value
            End Set
        End Property
        Public Property PropVCHINCLOCCUADRANTE() As String
            Get
                Return vchincloccuadrante
            End Get
            Set(ByVal value As String)
                vchincloccuadrante = value
            End Set
        End Property



        Public Property PropINCLOCXGEO() As String
            Get
                Return vchinclocxgeo
            End Get
            Set(ByVal value As String)
                vchinclocxgeo = value
            End Set
        End Property

        Public Property PropINCLOCYGEO() As String
            Get
                Return vchinclocygeo
            End Get
            Set(ByVal value As String)
                vchinclocygeo = value
            End Set
        End Property

        'Public Property PropINCCODIGOAPP() As Nullable(Of Integer)
        '    Get
        '        Return intinccodigoapp
        '    End Get
        '    Set(ByVal value As Nullable(Of Integer))
        '        intinccodigoapp = value
        '    End Set
        'End Property

        Public Property PropINCCODIGOAPP() As String
            Get
                Return vchinccodigoapp
            End Get
            Set(ByVal value As String)
                vchinccodigoapp = value
            End Set
        End Property

        Public Property PropINCARCHIVOURL() As String
            Get
                Return vchincarchivourl
            End Get
            Set(ByVal value As String)
                vchincarchivourl = value
            End Set
        End Property

        Public Sub New()
            LimpiaPropiedades()
        End Sub

        Public Sub LimpiaPropiedades()
            PropINCCODIGO = Nothing
            PropINCNUMEROORIGEN = Nothing
            PropINCCOMENTARIO = Nothing
            PropINCLOCVIACODIGO1 = Nothing
            PropINCLOCVIANOMBRE1 = Nothing
            PropINCLOCVIACODIGO2 = Nothing
            PropINCLOCVIANOMBRE2 = Nothing
            PropINCLOCNUMERO = Nothing
            PropINCLOCCUADRA = Nothing
            PropINCLOCMANZANA = Nothing
            PropINCLOCLOTE = Nothing
            PropINCLOCDPTO = Nothing
            PropINCLOCBLOCK = Nothing
            PropINCLOCHABCODIGO = Nothing
            PropINCLOCHABNOMBRE = Nothing
            PropINCLOCSECTOR = Nothing
            PropINCLOCCUADRANTE = Nothing
            PropINCLOCCOMENTARIO = Nothing
            PropINCRELATO = Nothing
            PropINCANONIMO = Nothing
            PropINCNOMBRE = Nothing
            PropINCAPELLIDOS = Nothing
            PropINCNOMBRECOMP = Nothing
            PropINCDOCUMENTO = Nothing
            PropINCLLAVIACODIGO = Nothing
            PropINCLLAVIANOMBRE = Nothing
            PropINCLLANUMERO = Nothing
            PropINCLLAMANZANA = Nothing
            PropINCLLALOTE = Nothing
            PropINCLLADPTO = Nothing
            PropINCLLABLOCK = Nothing
            PropINCLLAHABCODIGO = Nothing
            PropINCLLAHABNOMBRE = Nothing
            PropINCLLASECTOR = Nothing
            PropINCLLACUADRANTE = Nothing
            PropINCLLACOMENTARIO = Nothing
            PropINCRESULTADO = Nothing
            PropINCESTADO = Nothing
            PropAUDFECCREACION = Now.Date
            PropAUDFECMODIF = Now.Date
            PropAUDUSUCREACION = Nothing
            PropAUDUSUMODIF = Nothing
            PropINCACODIGO = Nothing
            PropINCANUMERO = Nothing
            PropADMCODIGO = Nothing
            PropPRECODIGO = Nothing
            PropINCIDLATITUDE = Nothing
            PropINCIDLONGITUDE = Nothing
            PropORICODIGO = Nothing
            PropTINCODIGO = Nothing
            PropSTICODIGO = Nothing
            PropPRICODIGO = Nothing
            PropTPECODIGO = Nothing
            PropTIDCODIGO = Nothing
            PropINCINTERVENIDOS = Nothing
            PropPAQCODIGO = Nothing
            PropPINCODIGO = Nothing
            PropAUDROLCREACION = Nothing
            PropAUDROLMODIF = Nothing
            PropINCUSUDERIVADO = Nothing
            PropINCROLDERIVADO = Nothing
            PropINCFECDERIVADO = Now.Date
            PropRESCODIGO = Nothing
            PropAUDPRGCREACION = Nothing
            PropAUDPRGMODIF = Nothing
            PropAUDEQPCREACION = Nothing
            PropAUDEQPMODIF = Nothing
            PropCATCODIGO = Nothing
            PropINCFECHA = Now.Date
            PropINCIDANEXO = Nothing
            PropINCIDLLAMADA = Nothing
            PropINCLLACUADRA = Nothing
            PropINCPARTEPOLICIAL = Nothing
            PropVCHMOTIVOALERTA = Nothing

            PropVCHCODQUEJA = Nothing
            PropINCLOCXGEO = Nothing
            PropINCLOCYGEO = Nothing
            PropVCHINCLOCCUADRANTE = Nothing
            PropVCHINCLOCSECTOR = Nothing

            PropINCCODIGOAPP = Nothing
            PropINCARCHIVOURL = Nothing

        End Sub

    End Class
End Namespace
