Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL


    Public Class CCOPERSONAL_DL
        Private cnDB2 As DB2Connection

#Region "Numerador"
        Public Enum Campos
            PERCODIGO = 0
            PERAPELLIDOPATERNO = 1
            PERAPELLIDOMATERNO = 2
            PERNOMBRE = 3
            PERTELEFONO1 = 4
            PERTELEFONO2 = 5
            PERTELEFONO3 = 6
            PERESTADO = 7
            CRGCODIGO = 8
            SECCODIGO = 9
            AUDPRGCREACION = 10
            AUDPRGMODIF = 11
            AUDEQPCREACION = 12
            AUDEQPMODIF = 13
            AUDFECCREACION = 14
            AUDFECMODIF = 15
            AUDUSUCREACION = 16
            AUDUSUMODIF = 17
            AUDROLCREACION = 18
            AUDROLMODIF = 19
            SSECODIGO = 20
            PERDNI = 21
            PERRUC = 22
            PERFECNACIMIENTO = 23
            PERLUGNACIMIENTO = 24
            PERDIRECCION = 25
            PERHABURBANA = 26
            PERCORREO = 27
            PERCUENTABANCO = 28
            PERPROFESION = 29
            PERLICENCIADO = 30
            PERFUERZAARMADA = 31
            PERLIBRETAMILITAR = 32
            PERNUMEROAFP = 33
            PERNUMEROESSALUD = 34
            PERSUNAT4TA = 35
            PERGRUPOSANGUINEO = 36
            PERTALLA = 37
            PERPESO = 38
            PERCURSOS = 39
            PERFECINGMUNI = 40
            PERFECINGAREA = 41
            PERFECINGMODAL = 42
            PERFECINGSECTOR = 43
            PERFECINGCARGO = 44
            PERSUELDO = 45
            PERNUMEBREVAUTO = 46
            PERREVABREVAUTO = 47
            PERRESTBREVAUTO = 48
            PERNUMEBREVMOTO = 49
            PERREVABREVMOTO = 50
            PERRESTBREVMOTO = 51
            PERFOTO = 52
            ECICODIGO = 53
            GINCODIGO = 54
            AFPCODIGO = 55
            SBGCODIGO = 56
            MODCODIGO = 57
            RANCODIGO = 58
            CAUCODIGO = 59
            CMOCODIGO = 60
            UBICODIGO = 61
            PERFECESTADO = 62
        End Enum
#End Region

        Public Sub New()
            cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
        End Sub

        Public Function Insertar(ByVal pCCOPERSONAL_BE As CCOPERSONAL_BE)
            Dim respuesta As Integer = 0
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(62) {}
                arrParam(0) = New DB2Parameter("P_INTPERCODIGO", DB2Type.Integer)
                'arrParam(0).Value = pCCOPERSONAL_BE.PropPERCODIGO
                arrParam(0).Direction = ParameterDirection.Output
                arrParam(1) = New DB2Parameter("P_VCHPERAPELLIDOPATERNO", DB2Type.VarChar, 30)
                arrParam(1).Value = pCCOPERSONAL_BE.PropPERAPELLIDOPATERNO
                arrParam(2) = New DB2Parameter("P_VCHPERAPELLIDOMATERNO", DB2Type.VarChar, 30)
                arrParam(2).Value = pCCOPERSONAL_BE.PropPERAPELLIDOMATERNO
                arrParam(3) = New DB2Parameter("P_VCHPERNOMBRE", DB2Type.VarChar, 30)
                arrParam(3).Value = pCCOPERSONAL_BE.PropPERNOMBRE
                arrParam(4) = New DB2Parameter("P_VCHPERTELEFONO1", DB2Type.VarChar, 30)
                arrParam(4).Value = pCCOPERSONAL_BE.PropPERTELEFONO1
                arrParam(5) = New DB2Parameter("P_VCHPERTELEFONO2", DB2Type.VarChar, 30)
                arrParam(5).Value = pCCOPERSONAL_BE.PropPERTELEFONO2
                arrParam(6) = New DB2Parameter("P_VCHPERTELEFONO3", DB2Type.VarChar, 30)
                arrParam(6).Value = pCCOPERSONAL_BE.PropPERTELEFONO3
                arrParam(7) = New DB2Parameter("P_SMLPERESTADO", DB2Type.SmallInt)
                arrParam(7).Value = pCCOPERSONAL_BE.PropPERESTADO
                arrParam(8) = New DB2Parameter("P_SMLCRGCODIGO", DB2Type.SmallInt)
                arrParam(8).Value = pCCOPERSONAL_BE.PropCRGCODIGO
                arrParam(9) = New DB2Parameter("P_SMLSECCODIGO", DB2Type.SmallInt)
                arrParam(9).Value = pCCOPERSONAL_BE.PropSECCODIGO
                arrParam(10) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VarChar, 150)
                arrParam(10).Value = pCCOPERSONAL_BE.PropAUDPRGCREACION
                arrParam(11) = New DB2Parameter("P_VCHAUDPRGMODIF", DB2Type.VarChar, 150)
                arrParam(11).Value = pCCOPERSONAL_BE.PropAUDPRGMODIF
                arrParam(12) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VarChar, 60)
                arrParam(12).Value = pCCOPERSONAL_BE.PropAUDEQPCREACION
                arrParam(13) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VarChar, 60)
                arrParam(13).Value = pCCOPERSONAL_BE.PropAUDEQPMODIF
                arrParam(14) = New DB2Parameter("P_DTMAUDFECCREACION", DB2Type.Timestamp)
                arrParam(14).Value = pCCOPERSONAL_BE.PropAUDFECCREACION
                arrParam(15) = New DB2Parameter("P_DTMAUDFECMODIF", DB2Type.Timestamp)
                arrParam(15).Value = pCCOPERSONAL_BE.PropAUDFECMODIF
                arrParam(16) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VarChar, 10)
                arrParam(16).Value = pCCOPERSONAL_BE.PropAUDUSUCREACION
                arrParam(17) = New DB2Parameter("P_VCHAUDUSUMODIF", DB2Type.VarChar, 10)
                arrParam(17).Value = pCCOPERSONAL_BE.PropAUDUSUMODIF
                arrParam(18) = New DB2Parameter("P_INTAUDROLCREACION", DB2Type.Integer)
                arrParam(18).Value = pCCOPERSONAL_BE.PropAUDROLCREACION
                arrParam(19) = New DB2Parameter("P_INTAUDROLMODIF", DB2Type.Integer)
                arrParam(19).Value = pCCOPERSONAL_BE.PropAUDROLMODIF
                arrParam(20) = New DB2Parameter("P_SMLSSECODIGO", DB2Type.SmallInt)
                arrParam(20).Value = pCCOPERSONAL_BE.PropSSECODIGO
                arrParam(21) = New DB2Parameter("P_VCHPERDNI", DB2Type.VarChar, 8)
                arrParam(21).Value = pCCOPERSONAL_BE.PropPERDNI
                arrParam(22) = New DB2Parameter("P_VCHPERRUC", DB2Type.VarChar, 11)
                arrParam(22).Value = pCCOPERSONAL_BE.PropPERRUC
                arrParam(23) = New DB2Parameter("P_DATPERFECNACIMIENTO", DB2Type.Date)
                arrParam(23).Value = pCCOPERSONAL_BE.PropPERFECNACIMIENTO
                arrParam(24) = New DB2Parameter("P_VCHPERLUGNACIMIENTO", DB2Type.VarChar, 30)
                arrParam(24).Value = pCCOPERSONAL_BE.PropPERLUGNACIMIENTO
                arrParam(25) = New DB2Parameter("P_VCHPERDIRECCION", DB2Type.VarChar, 50)
                arrParam(25).Value = pCCOPERSONAL_BE.PropPERDIRECCION
                arrParam(26) = New DB2Parameter("P_VCHPERHABURBANA", DB2Type.VarChar, 50)
                arrParam(26).Value = pCCOPERSONAL_BE.PropPERHABURBANA
                arrParam(27) = New DB2Parameter("P_VCHPERCORREO", DB2Type.VarChar, 30)
                arrParam(27).Value = pCCOPERSONAL_BE.PropPERCORREO
                arrParam(28) = New DB2Parameter("P_VCHPERCUENTABANCO", DB2Type.VarChar, 30)
                arrParam(28).Value = pCCOPERSONAL_BE.PropPERCUENTABANCO
                arrParam(29) = New DB2Parameter("P_VCHPERPROFESION", DB2Type.VarChar, 30)
                arrParam(29).Value = pCCOPERSONAL_BE.PropPERPROFESION
                arrParam(30) = New DB2Parameter("P_SMLPERLICENCIADO", DB2Type.SmallInt)
                arrParam(30).Value = pCCOPERSONAL_BE.PropPERLICENCIADO
                arrParam(31) = New DB2Parameter("P_VCHPERFUERZAARMADA", DB2Type.VarChar, 30)
                arrParam(31).Value = pCCOPERSONAL_BE.PropPERFUERZAARMADA
                arrParam(32) = New DB2Parameter("P_VCHPERLIBRETAMILITAR", DB2Type.VarChar, 30)
                arrParam(32).Value = pCCOPERSONAL_BE.PropPERLIBRETAMILITAR
                arrParam(33) = New DB2Parameter("P_VCHPERNUMEROAFP", DB2Type.VarChar, 30)
                arrParam(33).Value = pCCOPERSONAL_BE.PropPERNUMEROAFP
                arrParam(34) = New DB2Parameter("P_VCHPERNUMEROESSALUD", DB2Type.VarChar, 30)
                arrParam(34).Value = pCCOPERSONAL_BE.PropPERNUMEROESSALUD
                arrParam(35) = New DB2Parameter("P_VCHPERSUNAT4TA", DB2Type.VarChar, 30)
                arrParam(35).Value = pCCOPERSONAL_BE.PropPERSUNAT4TA
                arrParam(36) = New DB2Parameter("P_VCHPERGRUPOSANGUINEO", DB2Type.VarChar, 10)
                arrParam(36).Value = pCCOPERSONAL_BE.PropPERGRUPOSANGUINEO
                arrParam(37) = New DB2Parameter("P_DECPERTALLA", DB2Type.Decimal)
                arrParam(37).Value = pCCOPERSONAL_BE.PropPERTALLA
                arrParam(38) = New DB2Parameter("P_DECPERPESO", DB2Type.Decimal)
                arrParam(38).Value = pCCOPERSONAL_BE.PropPERPESO
                arrParam(39) = New DB2Parameter("P_VCHPERCURSOS", DB2Type.VarChar, 250)
                arrParam(39).Value = pCCOPERSONAL_BE.PropPERCURSOS
                arrParam(40) = New DB2Parameter("P_DATPERFECINGMUNI", DB2Type.Date)
                arrParam(40).Value = pCCOPERSONAL_BE.PropPERFECINGMUNI
                arrParam(41) = New DB2Parameter("P_DATPERFECINGAREA", DB2Type.Date)
                arrParam(41).Value = pCCOPERSONAL_BE.PropPERFECINGAREA
                arrParam(42) = New DB2Parameter("P_DATPERFECINGMODAL", DB2Type.Date)
                arrParam(42).Value = pCCOPERSONAL_BE.PropPERFECINGMODAL
                arrParam(43) = New DB2Parameter("P_DATPERFECINGSECTOR", DB2Type.Date)
                arrParam(43).Value = pCCOPERSONAL_BE.PropPERFECINGSECTOR
                arrParam(44) = New DB2Parameter("P_DATPERFECINGCARGO", DB2Type.Date)
                arrParam(44).Value = pCCOPERSONAL_BE.PropPERFECINGCARGO
                arrParam(45) = New DB2Parameter("P_DECPERSUELDO", DB2Type.Decimal)
                arrParam(45).Value = pCCOPERSONAL_BE.PropPERSUELDO
                arrParam(46) = New DB2Parameter("P_VCHPERNUMEBREVAUTO", DB2Type.VarChar, 30)
                arrParam(46).Value = pCCOPERSONAL_BE.PropPERNUMEBREVAUTO
                arrParam(47) = New DB2Parameter("P_DATPERREVABREVAUTO", DB2Type.Date)
                arrParam(47).Value = pCCOPERSONAL_BE.PropPERREVABREVAUTO
                arrParam(48) = New DB2Parameter("P_VCHPERRESTBREVAUTO", DB2Type.VarChar, 100)
                arrParam(48).Value = pCCOPERSONAL_BE.PropPERRESTBREVAUTO
                arrParam(49) = New DB2Parameter("P_VCHPERNUMEBREVMOTO", DB2Type.VarChar, 30)
                arrParam(49).Value = pCCOPERSONAL_BE.PropPERNUMEBREVMOTO
                arrParam(50) = New DB2Parameter("P_DATPERREVABREVMOTO", DB2Type.Date)
                arrParam(50).Value = pCCOPERSONAL_BE.PropPERREVABREVMOTO
                arrParam(51) = New DB2Parameter("P_VCHPERRESTBREVMOTO", DB2Type.VarChar, 100)
                arrParam(51).Value = pCCOPERSONAL_BE.PropPERRESTBREVMOTO
                arrParam(52) = New DB2Parameter("P_BLBPERFOTO", DB2Type.Blob)
                arrParam(52).Value = pCCOPERSONAL_BE.PropPERFOTO
                arrParam(53) = New DB2Parameter("P_SMLECICODIGO", DB2Type.SmallInt)
                arrParam(53).Value = pCCOPERSONAL_BE.PropECICODIGO
                arrParam(54) = New DB2Parameter("P_SMLGINCODIGO", DB2Type.SmallInt)
                arrParam(54).Value = pCCOPERSONAL_BE.PropGINCODIGO
                arrParam(55) = New DB2Parameter("P_SMLAFPCODIGO", DB2Type.SmallInt)
                arrParam(55).Value = pCCOPERSONAL_BE.PropAFPCODIGO
                arrParam(56) = New DB2Parameter("P_SMLSBGCODIGO", DB2Type.SmallInt)
                arrParam(56).Value = pCCOPERSONAL_BE.PropSBGCODIGO
                arrParam(57) = New DB2Parameter("P_SMLMODCODIGO", DB2Type.SmallInt)
                arrParam(57).Value = pCCOPERSONAL_BE.PropMODCODIGO
                arrParam(58) = New DB2Parameter("P_SMLRANCODIGO", DB2Type.SmallInt)
                arrParam(58).Value = pCCOPERSONAL_BE.PropRANCODIGO
                arrParam(59) = New DB2Parameter("P_SMLCAUCODIGO", DB2Type.SmallInt)
                arrParam(59).Value = pCCOPERSONAL_BE.PropCAUCODIGO
                arrParam(60) = New DB2Parameter("P_SMLCMOCODIGO", DB2Type.SmallInt)
                arrParam(60).Value = pCCOPERSONAL_BE.PropCMOCODIGO
                arrParam(61) = New DB2Parameter("P_CHRUBICODIGO", DB2Type.Char, 6)
                arrParam(61).Value = pCCOPERSONAL_BE.PropUBICODIGO
                arrParam(62) = New DB2Parameter("P_DATPERFECESTADO", DB2Type.Date)
                arrParam(62).Value = pCCOPERSONAL_BE.PropPERFECESTADO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOPERSONAL_INSERTAR", arrParam)
                respuesta = arrParam(0).Value
                Return respuesta
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Function

        Public Sub Actualizar(ByVal pCCOPERSONAL_BE As CCOPERSONAL_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(62) {}
                arrParam(0) = New DB2Parameter("P_INTPERCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOPERSONAL_BE.PropPERCODIGO
                arrParam(1) = New DB2Parameter("P_VCHPERAPELLIDOPATERNO", DB2Type.VarChar, 30)
                arrParam(1).Value = pCCOPERSONAL_BE.PropPERAPELLIDOPATERNO
                arrParam(2) = New DB2Parameter("P_VCHPERAPELLIDOMATERNO", DB2Type.VarChar, 30)
                arrParam(2).Value = pCCOPERSONAL_BE.PropPERAPELLIDOMATERNO
                arrParam(3) = New DB2Parameter("P_VCHPERNOMBRE", DB2Type.VarChar, 30)
                arrParam(3).Value = pCCOPERSONAL_BE.PropPERNOMBRE
                arrParam(4) = New DB2Parameter("P_VCHPERTELEFONO1", DB2Type.VarChar, 30)
                arrParam(4).Value = pCCOPERSONAL_BE.PropPERTELEFONO1
                arrParam(5) = New DB2Parameter("P_VCHPERTELEFONO2", DB2Type.VarChar, 30)
                arrParam(5).Value = pCCOPERSONAL_BE.PropPERTELEFONO2
                arrParam(6) = New DB2Parameter("P_VCHPERTELEFONO3", DB2Type.VarChar, 30)
                arrParam(6).Value = pCCOPERSONAL_BE.PropPERTELEFONO3
                arrParam(7) = New DB2Parameter("P_SMLPERESTADO", DB2Type.SmallInt)
                arrParam(7).Value = pCCOPERSONAL_BE.PropPERESTADO
                arrParam(8) = New DB2Parameter("P_SMLCRGCODIGO", DB2Type.SmallInt)
                arrParam(8).Value = pCCOPERSONAL_BE.PropCRGCODIGO
                arrParam(9) = New DB2Parameter("P_SMLSECCODIGO", DB2Type.SmallInt)
                arrParam(9).Value = pCCOPERSONAL_BE.PropSECCODIGO
                arrParam(10) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VarChar, 150)
                arrParam(10).Value = pCCOPERSONAL_BE.PropAUDPRGCREACION
                arrParam(11) = New DB2Parameter("P_VCHAUDPRGMODIF", DB2Type.VarChar, 150)
                arrParam(11).Value = pCCOPERSONAL_BE.PropAUDPRGMODIF
                arrParam(12) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VarChar, 60)
                arrParam(12).Value = pCCOPERSONAL_BE.PropAUDEQPCREACION
                arrParam(13) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VarChar, 60)
                arrParam(13).Value = pCCOPERSONAL_BE.PropAUDEQPMODIF
                arrParam(14) = New DB2Parameter("P_DTMAUDFECCREACION", DB2Type.Timestamp)
                arrParam(14).Value = pCCOPERSONAL_BE.PropAUDFECCREACION
                arrParam(15) = New DB2Parameter("P_DTMAUDFECMODIF", DB2Type.Timestamp)
                arrParam(15).Value = pCCOPERSONAL_BE.PropAUDFECMODIF
                arrParam(16) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VarChar, 10)
                arrParam(16).Value = pCCOPERSONAL_BE.PropAUDUSUCREACION
                arrParam(17) = New DB2Parameter("P_VCHAUDUSUMODIF", DB2Type.VarChar, 10)
                arrParam(17).Value = pCCOPERSONAL_BE.PropAUDUSUMODIF
                arrParam(18) = New DB2Parameter("P_INTAUDROLCREACION", DB2Type.Integer)
                arrParam(18).Value = pCCOPERSONAL_BE.PropAUDROLCREACION
                arrParam(19) = New DB2Parameter("P_INTAUDROLMODIF", DB2Type.Integer)
                arrParam(19).Value = pCCOPERSONAL_BE.PropAUDROLMODIF
                arrParam(20) = New DB2Parameter("P_SMLSSECODIGO", DB2Type.SmallInt)
                arrParam(20).Value = pCCOPERSONAL_BE.PropSSECODIGO
                arrParam(21) = New DB2Parameter("P_VCHPERDNI", DB2Type.VarChar, 8)
                arrParam(21).Value = pCCOPERSONAL_BE.PropPERDNI
                arrParam(22) = New DB2Parameter("P_VCHPERRUC", DB2Type.VarChar, 11)
                arrParam(22).Value = pCCOPERSONAL_BE.PropPERRUC
                arrParam(23) = New DB2Parameter("P_DATPERFECNACIMIENTO", DB2Type.Date)
                arrParam(23).Value = pCCOPERSONAL_BE.PropPERFECNACIMIENTO
                arrParam(24) = New DB2Parameter("P_VCHPERLUGNACIMIENTO", DB2Type.VarChar, 30)
                arrParam(24).Value = pCCOPERSONAL_BE.PropPERLUGNACIMIENTO
                arrParam(25) = New DB2Parameter("P_VCHPERDIRECCION", DB2Type.VarChar, 50)
                arrParam(25).Value = pCCOPERSONAL_BE.PropPERDIRECCION
                arrParam(26) = New DB2Parameter("P_VCHPERHABURBANA", DB2Type.VarChar, 50)
                arrParam(26).Value = pCCOPERSONAL_BE.PropPERHABURBANA
                arrParam(27) = New DB2Parameter("P_VCHPERCORREO", DB2Type.VarChar, 30)
                arrParam(27).Value = pCCOPERSONAL_BE.PropPERCORREO
                arrParam(28) = New DB2Parameter("P_VCHPERCUENTABANCO", DB2Type.VarChar, 30)
                arrParam(28).Value = pCCOPERSONAL_BE.PropPERCUENTABANCO
                arrParam(29) = New DB2Parameter("P_VCHPERPROFESION", DB2Type.VarChar, 30)
                arrParam(29).Value = pCCOPERSONAL_BE.PropPERPROFESION
                arrParam(30) = New DB2Parameter("P_SMLPERLICENCIADO", DB2Type.SmallInt)
                arrParam(30).Value = pCCOPERSONAL_BE.PropPERLICENCIADO
                arrParam(31) = New DB2Parameter("P_VCHPERFUERZAARMADA", DB2Type.VarChar, 30)
                arrParam(31).Value = pCCOPERSONAL_BE.PropPERFUERZAARMADA
                arrParam(32) = New DB2Parameter("P_VCHPERLIBRETAMILITAR", DB2Type.VarChar, 30)
                arrParam(32).Value = pCCOPERSONAL_BE.PropPERLIBRETAMILITAR
                arrParam(33) = New DB2Parameter("P_VCHPERNUMEROAFP", DB2Type.VarChar, 30)
                arrParam(33).Value = pCCOPERSONAL_BE.PropPERNUMEROAFP
                arrParam(34) = New DB2Parameter("P_VCHPERNUMEROESSALUD", DB2Type.VarChar, 30)
                arrParam(34).Value = pCCOPERSONAL_BE.PropPERNUMEROESSALUD
                arrParam(35) = New DB2Parameter("P_VCHPERSUNAT4TA", DB2Type.VarChar, 30)
                arrParam(35).Value = pCCOPERSONAL_BE.PropPERSUNAT4TA
                arrParam(36) = New DB2Parameter("P_VCHPERGRUPOSANGUINEO", DB2Type.VarChar, 10)
                arrParam(36).Value = pCCOPERSONAL_BE.PropPERGRUPOSANGUINEO
                arrParam(37) = New DB2Parameter("P_DECPERTALLA", DB2Type.Decimal)
                arrParam(37).Value = pCCOPERSONAL_BE.PropPERTALLA
                arrParam(38) = New DB2Parameter("P_DECPERPESO", DB2Type.Decimal)
                arrParam(38).Value = pCCOPERSONAL_BE.PropPERPESO
                arrParam(39) = New DB2Parameter("P_VCHPERCURSOS", DB2Type.VarChar, 250)
                arrParam(39).Value = pCCOPERSONAL_BE.PropPERCURSOS
                arrParam(40) = New DB2Parameter("P_DATPERFECINGMUNI", DB2Type.Date)
                arrParam(40).Value = pCCOPERSONAL_BE.PropPERFECINGMUNI
                arrParam(41) = New DB2Parameter("P_DATPERFECINGAREA", DB2Type.Date)
                arrParam(41).Value = pCCOPERSONAL_BE.PropPERFECINGAREA
                arrParam(42) = New DB2Parameter("P_DATPERFECINGMODAL", DB2Type.Date)
                arrParam(42).Value = pCCOPERSONAL_BE.PropPERFECINGMODAL
                arrParam(43) = New DB2Parameter("P_DATPERFECINGSECTOR", DB2Type.Date)
                arrParam(43).Value = pCCOPERSONAL_BE.PropPERFECINGSECTOR
                arrParam(44) = New DB2Parameter("P_DATPERFECINGCARGO", DB2Type.Date)
                arrParam(44).Value = pCCOPERSONAL_BE.PropPERFECINGCARGO
                arrParam(45) = New DB2Parameter("P_DECPERSUELDO", DB2Type.Decimal)
                arrParam(45).Value = pCCOPERSONAL_BE.PropPERSUELDO
                arrParam(46) = New DB2Parameter("P_VCHPERNUMEBREVAUTO", DB2Type.VarChar, 30)
                arrParam(46).Value = pCCOPERSONAL_BE.PropPERNUMEBREVAUTO
                arrParam(47) = New DB2Parameter("P_DATPERREVABREVAUTO", DB2Type.Date)
                arrParam(47).Value = pCCOPERSONAL_BE.PropPERREVABREVAUTO
                arrParam(48) = New DB2Parameter("P_VCHPERRESTBREVAUTO", DB2Type.VarChar, 100)
                arrParam(48).Value = pCCOPERSONAL_BE.PropPERRESTBREVAUTO
                arrParam(49) = New DB2Parameter("P_VCHPERNUMEBREVMOTO", DB2Type.VarChar, 30)
                arrParam(49).Value = pCCOPERSONAL_BE.PropPERNUMEBREVMOTO
                arrParam(50) = New DB2Parameter("P_DATPERREVABREVMOTO", DB2Type.Date)
                arrParam(50).Value = pCCOPERSONAL_BE.PropPERREVABREVMOTO
                arrParam(51) = New DB2Parameter("P_VCHPERRESTBREVMOTO", DB2Type.VarChar, 100)
                arrParam(51).Value = pCCOPERSONAL_BE.PropPERRESTBREVMOTO
                arrParam(52) = New DB2Parameter("P_BLBPERFOTO", DB2Type.Blob)
                arrParam(52).Value = pCCOPERSONAL_BE.PropPERFOTO
                arrParam(53) = New DB2Parameter("P_SMLECICODIGO", DB2Type.SmallInt)
                arrParam(53).Value = pCCOPERSONAL_BE.PropECICODIGO
                arrParam(54) = New DB2Parameter("P_SMLGINCODIGO", DB2Type.SmallInt)
                arrParam(54).Value = pCCOPERSONAL_BE.PropGINCODIGO
                arrParam(55) = New DB2Parameter("P_SMLAFPCODIGO", DB2Type.SmallInt)
                arrParam(55).Value = pCCOPERSONAL_BE.PropAFPCODIGO
                arrParam(56) = New DB2Parameter("P_SMLSBGCODIGO", DB2Type.SmallInt)
                arrParam(56).Value = pCCOPERSONAL_BE.PropSBGCODIGO
                arrParam(57) = New DB2Parameter("P_SMLMODCODIGO", DB2Type.SmallInt)
                arrParam(57).Value = pCCOPERSONAL_BE.PropMODCODIGO
                arrParam(58) = New DB2Parameter("P_SMLRANCODIGO", DB2Type.SmallInt)
                arrParam(58).Value = pCCOPERSONAL_BE.PropRANCODIGO
                arrParam(59) = New DB2Parameter("P_SMLCAUCODIGO", DB2Type.SmallInt)
                arrParam(59).Value = pCCOPERSONAL_BE.PropCAUCODIGO
                arrParam(60) = New DB2Parameter("P_SMLCMOCODIGO", DB2Type.SmallInt)
                arrParam(60).Value = pCCOPERSONAL_BE.PropCMOCODIGO
                arrParam(61) = New DB2Parameter("P_CHRUBICODIGO", DB2Type.Char, 6)
                arrParam(61).Value = pCCOPERSONAL_BE.PropUBICODIGO
                arrParam(62) = New DB2Parameter("P_DATPERFECESTADO", DB2Type.Date)
                arrParam(62).Value = pCCOPERSONAL_BE.PropPERFECESTADO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOPERSONAL_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOPERSONAL_BE As CCOPERSONAL_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTPERCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOPERSONAL_BE.PropPERCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOPERSONAL_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOPERSONAL_BE As CCOPERSONAL_BE) As CCOPERSONAL_BE
            Dim oCCOPERSONAL_BE As New CCOPERSONAL_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTPERCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOPERSONAL_BE.PropPERCODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOPERSONAL_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.PERCODIGO) Then oCCOPERSONAL_BE.PropPERCODIGO = Nothing Else oCCOPERSONAL_BE.PropPERCODIGO = CType(oDataReader(Campos.PERCODIGO), Int32)
                    oCCOPERSONAL_BE.PropPERAPELLIDOPATERNO = IIf(oDataReader.IsDBNull(Campos.PERAPELLIDOPATERNO), "", oDataReader(Campos.PERAPELLIDOPATERNO))
                    oCCOPERSONAL_BE.PropPERAPELLIDOMATERNO = IIf(oDataReader.IsDBNull(Campos.PERAPELLIDOMATERNO), "", oDataReader(Campos.PERAPELLIDOMATERNO))
                    oCCOPERSONAL_BE.PropPERNOMBRE = IIf(oDataReader.IsDBNull(Campos.PERNOMBRE), "", oDataReader(Campos.PERNOMBRE))
                    oCCOPERSONAL_BE.PropPERTELEFONO1 = IIf(oDataReader.IsDBNull(Campos.PERTELEFONO1), "", oDataReader(Campos.PERTELEFONO1))
                    oCCOPERSONAL_BE.PropPERTELEFONO2 = IIf(oDataReader.IsDBNull(Campos.PERTELEFONO2), "", oDataReader(Campos.PERTELEFONO2))
                    oCCOPERSONAL_BE.PropPERTELEFONO3 = IIf(oDataReader.IsDBNull(Campos.PERTELEFONO3), "", oDataReader(Campos.PERTELEFONO3))
                    If oDataReader.IsDBNull(Campos.PERESTADO) Then oCCOPERSONAL_BE.PropPERESTADO = Nothing Else oCCOPERSONAL_BE.PropPERESTADO = CType(oDataReader(Campos.PERESTADO), Int16)
                    If oDataReader.IsDBNull(Campos.CRGCODIGO) Then oCCOPERSONAL_BE.PropCRGCODIGO = Nothing Else oCCOPERSONAL_BE.PropCRGCODIGO = CType(oDataReader(Campos.CRGCODIGO), Int16)
                    If oDataReader.IsDBNull(Campos.SECCODIGO) Then oCCOPERSONAL_BE.PropSECCODIGO = Nothing Else oCCOPERSONAL_BE.PropSECCODIGO = CType(oDataReader(Campos.SECCODIGO), Int16)
                    oCCOPERSONAL_BE.PropAUDPRGCREACION = IIf(oDataReader.IsDBNull(Campos.AUDPRGCREACION), "", oDataReader(Campos.AUDPRGCREACION))
                    oCCOPERSONAL_BE.PropAUDPRGMODIF = IIf(oDataReader.IsDBNull(Campos.AUDPRGMODIF), "", oDataReader(Campos.AUDPRGMODIF))
                    oCCOPERSONAL_BE.PropAUDEQPCREACION = IIf(oDataReader.IsDBNull(Campos.AUDEQPCREACION), "", oDataReader(Campos.AUDEQPCREACION))
                    oCCOPERSONAL_BE.PropAUDEQPMODIF = IIf(oDataReader.IsDBNull(Campos.AUDEQPMODIF), "", oDataReader(Campos.AUDEQPMODIF))
                    If oDataReader.IsDBNull(Campos.AUDFECCREACION) Then oCCOPERSONAL_BE.PropAUDFECCREACION = Nothing Else oCCOPERSONAL_BE.PropAUDFECCREACION = CType(oDataReader(Campos.AUDFECCREACION), DateTime)
                    If oDataReader.IsDBNull(Campos.AUDFECMODIF) Then oCCOPERSONAL_BE.PropAUDFECMODIF = Nothing Else oCCOPERSONAL_BE.PropAUDFECMODIF = CType(oDataReader(Campos.AUDFECMODIF), DateTime)
                    oCCOPERSONAL_BE.PropAUDUSUCREACION = IIf(oDataReader.IsDBNull(Campos.AUDUSUCREACION), "", oDataReader(Campos.AUDUSUCREACION))
                    oCCOPERSONAL_BE.PropAUDUSUMODIF = IIf(oDataReader.IsDBNull(Campos.AUDUSUMODIF), "", oDataReader(Campos.AUDUSUMODIF))
                    If oDataReader.IsDBNull(Campos.AUDROLCREACION) Then oCCOPERSONAL_BE.PropAUDROLCREACION = Nothing Else oCCOPERSONAL_BE.PropAUDROLCREACION = CType(oDataReader(Campos.AUDROLCREACION), Int32)
                    If oDataReader.IsDBNull(Campos.AUDROLMODIF) Then oCCOPERSONAL_BE.PropAUDROLMODIF = Nothing Else oCCOPERSONAL_BE.PropAUDROLMODIF = CType(oDataReader(Campos.AUDROLMODIF), Int32)
                    If oDataReader.IsDBNull(Campos.SSECODIGO) Then oCCOPERSONAL_BE.PropSSECODIGO = Nothing Else oCCOPERSONAL_BE.PropSSECODIGO = CType(oDataReader(Campos.SSECODIGO), Int16)
                    oCCOPERSONAL_BE.PropPERDNI = IIf(oDataReader.IsDBNull(Campos.PERDNI), "", oDataReader(Campos.PERDNI))
                    oCCOPERSONAL_BE.PropPERRUC = IIf(oDataReader.IsDBNull(Campos.PERRUC), "", oDataReader(Campos.PERRUC))
                    If oDataReader.IsDBNull(Campos.PERFECNACIMIENTO) Then oCCOPERSONAL_BE.PropPERFECNACIMIENTO = Nothing Else oCCOPERSONAL_BE.PropPERFECNACIMIENTO = CType(oDataReader(Campos.PERFECNACIMIENTO), DateTime)
                    oCCOPERSONAL_BE.PropPERLUGNACIMIENTO = IIf(oDataReader.IsDBNull(Campos.PERLUGNACIMIENTO), "", oDataReader(Campos.PERLUGNACIMIENTO))
                    oCCOPERSONAL_BE.PropPERDIRECCION = IIf(oDataReader.IsDBNull(Campos.PERDIRECCION), "", oDataReader(Campos.PERDIRECCION))
                    oCCOPERSONAL_BE.PropPERHABURBANA = IIf(oDataReader.IsDBNull(Campos.PERHABURBANA), "", oDataReader(Campos.PERHABURBANA))
                    oCCOPERSONAL_BE.PropPERCORREO = IIf(oDataReader.IsDBNull(Campos.PERCORREO), "", oDataReader(Campos.PERCORREO))
                    oCCOPERSONAL_BE.PropPERCUENTABANCO = IIf(oDataReader.IsDBNull(Campos.PERCUENTABANCO), "", oDataReader(Campos.PERCUENTABANCO))
                    oCCOPERSONAL_BE.PropPERPROFESION = IIf(oDataReader.IsDBNull(Campos.PERPROFESION), "", oDataReader(Campos.PERPROFESION))
                    If oDataReader.IsDBNull(Campos.PERLICENCIADO) Then oCCOPERSONAL_BE.PropPERLICENCIADO = Nothing Else oCCOPERSONAL_BE.PropPERLICENCIADO = CType(oDataReader(Campos.PERLICENCIADO), Int16)
                    oCCOPERSONAL_BE.PropPERFUERZAARMADA = IIf(oDataReader.IsDBNull(Campos.PERFUERZAARMADA), "", oDataReader(Campos.PERFUERZAARMADA))
                    oCCOPERSONAL_BE.PropPERLIBRETAMILITAR = IIf(oDataReader.IsDBNull(Campos.PERLIBRETAMILITAR), "", oDataReader(Campos.PERLIBRETAMILITAR))
                    oCCOPERSONAL_BE.PropPERNUMEROAFP = IIf(oDataReader.IsDBNull(Campos.PERNUMEROAFP), "", oDataReader(Campos.PERNUMEROAFP))
                    oCCOPERSONAL_BE.PropPERNUMEROESSALUD = IIf(oDataReader.IsDBNull(Campos.PERNUMEROESSALUD), "", oDataReader(Campos.PERNUMEROESSALUD))
                    oCCOPERSONAL_BE.PropPERSUNAT4TA = IIf(oDataReader.IsDBNull(Campos.PERSUNAT4TA), "", oDataReader(Campos.PERSUNAT4TA))
                    oCCOPERSONAL_BE.PropPERGRUPOSANGUINEO = IIf(oDataReader.IsDBNull(Campos.PERGRUPOSANGUINEO), "", oDataReader(Campos.PERGRUPOSANGUINEO))
                    If oDataReader.IsDBNull(Campos.PERTALLA) Then oCCOPERSONAL_BE.PropPERTALLA = Nothing Else oCCOPERSONAL_BE.PropPERTALLA = CType(oDataReader(Campos.PERTALLA), Decimal)
                    If oDataReader.IsDBNull(Campos.PERPESO) Then oCCOPERSONAL_BE.PropPERPESO = Nothing Else oCCOPERSONAL_BE.PropPERPESO = CType(oDataReader(Campos.PERPESO), Decimal)
                    oCCOPERSONAL_BE.PropPERCURSOS = IIf(oDataReader.IsDBNull(Campos.PERCURSOS), "", oDataReader(Campos.PERCURSOS))
                    If oDataReader.IsDBNull(Campos.PERFECINGMUNI) Then oCCOPERSONAL_BE.PropPERFECINGMUNI = Nothing Else oCCOPERSONAL_BE.PropPERFECINGMUNI = CType(oDataReader(Campos.PERFECINGMUNI), DateTime)
                    If oDataReader.IsDBNull(Campos.PERFECINGAREA) Then oCCOPERSONAL_BE.PropPERFECINGAREA = Nothing Else oCCOPERSONAL_BE.PropPERFECINGAREA = CType(oDataReader(Campos.PERFECINGAREA), DateTime)
                    If oDataReader.IsDBNull(Campos.PERFECINGMODAL) Then oCCOPERSONAL_BE.PropPERFECINGMODAL = Nothing Else oCCOPERSONAL_BE.PropPERFECINGMODAL = CType(oDataReader(Campos.PERFECINGMODAL), DateTime)
                    If oDataReader.IsDBNull(Campos.PERFECINGSECTOR) Then oCCOPERSONAL_BE.PropPERFECINGSECTOR = Nothing Else oCCOPERSONAL_BE.PropPERFECINGSECTOR = CType(oDataReader(Campos.PERFECINGSECTOR), DateTime)
                    If oDataReader.IsDBNull(Campos.PERFECINGCARGO) Then oCCOPERSONAL_BE.PropPERFECINGCARGO = Nothing Else oCCOPERSONAL_BE.PropPERFECINGCARGO = CType(oDataReader(Campos.PERFECINGCARGO), DateTime)
                    If oDataReader.IsDBNull(Campos.PERSUELDO) Then oCCOPERSONAL_BE.PropPERSUELDO = Nothing Else oCCOPERSONAL_BE.PropPERSUELDO = CType(oDataReader(Campos.PERSUELDO), Decimal)
                    oCCOPERSONAL_BE.PropPERNUMEBREVAUTO = IIf(oDataReader.IsDBNull(Campos.PERNUMEBREVAUTO), "", oDataReader(Campos.PERNUMEBREVAUTO))
                    If oDataReader.IsDBNull(Campos.PERREVABREVAUTO) Then oCCOPERSONAL_BE.PropPERREVABREVAUTO = Nothing Else oCCOPERSONAL_BE.PropPERREVABREVAUTO = CType(oDataReader(Campos.PERREVABREVAUTO), DateTime)
                    oCCOPERSONAL_BE.PropPERRESTBREVAUTO = IIf(oDataReader.IsDBNull(Campos.PERRESTBREVAUTO), "", oDataReader(Campos.PERRESTBREVAUTO))
                    oCCOPERSONAL_BE.PropPERNUMEBREVMOTO = IIf(oDataReader.IsDBNull(Campos.PERNUMEBREVMOTO), "", oDataReader(Campos.PERNUMEBREVMOTO))
                    If oDataReader.IsDBNull(Campos.PERREVABREVMOTO) Then oCCOPERSONAL_BE.PropPERREVABREVMOTO = Nothing Else oCCOPERSONAL_BE.PropPERREVABREVMOTO = CType(oDataReader(Campos.PERREVABREVMOTO), DateTime)
                    oCCOPERSONAL_BE.PropPERRESTBREVMOTO = IIf(oDataReader.IsDBNull(Campos.PERRESTBREVMOTO), "", oDataReader(Campos.PERRESTBREVMOTO))
                    If oDataReader.IsDBNull(Campos.PERFOTO) Then oCCOPERSONAL_BE.PropPERFOTO = Nothing Else oCCOPERSONAL_BE.PropPERFOTO = CType(oDataReader(Campos.PERFOTO), Object)
                    If oDataReader.IsDBNull(Campos.ECICODIGO) Then oCCOPERSONAL_BE.PropECICODIGO = Nothing Else oCCOPERSONAL_BE.PropECICODIGO = CType(oDataReader(Campos.ECICODIGO), Int16)
                    If oDataReader.IsDBNull(Campos.GINCODIGO) Then oCCOPERSONAL_BE.PropGINCODIGO = Nothing Else oCCOPERSONAL_BE.PropGINCODIGO = CType(oDataReader(Campos.GINCODIGO), Int16)
                    If oDataReader.IsDBNull(Campos.AFPCODIGO) Then oCCOPERSONAL_BE.PropAFPCODIGO = Nothing Else oCCOPERSONAL_BE.PropAFPCODIGO = CType(oDataReader(Campos.AFPCODIGO), Int16)
                    If oDataReader.IsDBNull(Campos.SBGCODIGO) Then oCCOPERSONAL_BE.PropSBGCODIGO = Nothing Else oCCOPERSONAL_BE.PropSBGCODIGO = CType(oDataReader(Campos.SBGCODIGO), Int16)
                    If oDataReader.IsDBNull(Campos.MODCODIGO) Then oCCOPERSONAL_BE.PropMODCODIGO = Nothing Else oCCOPERSONAL_BE.PropMODCODIGO = CType(oDataReader(Campos.MODCODIGO), Int16)
                    If oDataReader.IsDBNull(Campos.RANCODIGO) Then oCCOPERSONAL_BE.PropRANCODIGO = Nothing Else oCCOPERSONAL_BE.PropRANCODIGO = CType(oDataReader(Campos.RANCODIGO), Int16)
                    If oDataReader.IsDBNull(Campos.CAUCODIGO) Then oCCOPERSONAL_BE.PropCAUCODIGO = Nothing Else oCCOPERSONAL_BE.PropCAUCODIGO = CType(oDataReader(Campos.CAUCODIGO), Int16)
                    If oDataReader.IsDBNull(Campos.CMOCODIGO) Then oCCOPERSONAL_BE.PropCMOCODIGO = Nothing Else oCCOPERSONAL_BE.PropCMOCODIGO = CType(oDataReader(Campos.CMOCODIGO), Int16)
                    oCCOPERSONAL_BE.PropUBICODIGO = IIf(oDataReader.IsDBNull(Campos.UBICODIGO), "", oDataReader(Campos.UBICODIGO))
                    If oDataReader.IsDBNull(Campos.PERFECESTADO) Then oCCOPERSONAL_BE.PropPERFECESTADO = Nothing Else oCCOPERSONAL_BE.PropPERFECESTADO = CType(oDataReader(Campos.PERFECESTADO), DateTime)
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oCCOPERSONAL_BE
        End Function

        Public Function Listar(ByVal pCCOPERSONAL_BE As CCOPERSONAL_BE) As DataTable
            Dim odt As New DataTable
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(7) {}
                arrParam(0) = New DB2Parameter("P_INTPERCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOPERSONAL_BE.PropPERCODIGO
                arrParam(1) = New DB2Parameter("P_VCHPERAPELLIDOPATERNO", DB2Type.VarChar, 30)
                arrParam(1).Value = pCCOPERSONAL_BE.PropPERAPELLIDOPATERNO
                arrParam(2) = New DB2Parameter("P_VCHPERAPELLIDOMATERNO", DB2Type.VarChar, 30)
                arrParam(2).Value = pCCOPERSONAL_BE.PropPERAPELLIDOMATERNO
                arrParam(3) = New DB2Parameter("P_VCHPERNOMBRE", DB2Type.VarChar, 30)
                arrParam(3).Value = pCCOPERSONAL_BE.PropPERNOMBRE
                arrParam(4) = New DB2Parameter("P_INTPERESTADO", DB2Type.Integer)
                arrParam(4).Value = pCCOPERSONAL_BE.PropPERESTADO
                arrParam(5) = New DB2Parameter("P_INTCRGCODIGO", DB2Type.Integer)
                arrParam(5).Value = pCCOPERSONAL_BE.PropCRGCODIGO
                arrParam(6) = New DB2Parameter("P_INTTURCODIGO", DB2Type.Integer)
                arrParam(6).Value = pCCOPERSONAL_BE.PropTURCODIGO
                arrParam(7) = New DB2Parameter("P_INTSECCODIGO", DB2Type.Integer)
                arrParam(7).Value = pCCOPERSONAL_BE.PropSECCODIGO
                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOPERSONAL_LISTAR", arrParam)
                    odt.Load(dataReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return odt
        End Function

        Public Function RolListar(ByVal pCCOPERSONAL_BE As CCOPERSONAL_BE) As DataTable
            Dim odt As New DataTable
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(8) {}
                arrParam(0) = New DB2Parameter("P_INTPERCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOPERSONAL_BE.PropPERCODIGO
                arrParam(1) = New DB2Parameter("P_VCHPERAPELLIDOPATERNO", DB2Type.VarChar, 30)
                arrParam(1).Value = pCCOPERSONAL_BE.PropPERAPELLIDOPATERNO
                arrParam(2) = New DB2Parameter("P_VCHPERAPELLIDOMATERNO", DB2Type.VarChar, 30)
                arrParam(2).Value = pCCOPERSONAL_BE.PropPERAPELLIDOMATERNO
                arrParam(3) = New DB2Parameter("P_VCHPERNOMBRE", DB2Type.VarChar, 30)
                arrParam(3).Value = pCCOPERSONAL_BE.PropPERNOMBRE
                arrParam(4) = New DB2Parameter("P_INTPERESTADO", DB2Type.Integer)
                arrParam(4).Value = pCCOPERSONAL_BE.PropPERESTADO
                arrParam(5) = New DB2Parameter("P_INTCRGCODIGO", DB2Type.Integer)
                arrParam(5).Value = pCCOPERSONAL_BE.PropCRGCODIGO
                arrParam(6) = New DB2Parameter("P_INTTURCODIGO", DB2Type.Integer)
                arrParam(6).Value = pCCOPERSONAL_BE.Propturcodigo
                arrParam(7) = New DB2Parameter("P_VCHSECCODIGO", DB2Type.VarChar, 500)
                arrParam(7).Value = pCCOPERSONAL_BE.PropPERCURSOS
                arrParam(8) = New DB2Parameter("P_DATRSEFECHA", DB2Type.Date)
                arrParam(8).Value = pCCOPERSONAL_BE.PropPERFECESTADO

                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOPERSONALROL_LISTAR", arrParam)
                    odt.Load(dataReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return odt
        End Function

        Public Function ListarNombres(ByVal pCCOPERSONAL_BE As CCOPERSONAL_BE) As DataTable
            Dim odt As New DataTable
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                
                arrParam(0) = New DB2Parameter("P_VCHNOMBRES", DB2Type.VarChar, 100)
                arrParam(0).Value = pCCOPERSONAL_BE.PropPERNOMBRE
                
                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOPERSONAL_LISTARXNOMBRES", arrParam)
                    odt.Load(dataReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return odt
        End Function

        Public Function ListarBusqueda(ByVal pCCOPERSONAL_BE As CCOPERSONAL_BE) As DataTable
            Dim odt As New DataTable
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(12) {}


                arrParam(0) = New DB2Parameter("P_INTPERCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOPERSONAL_BE.PropPERCODIGO
                arrParam(1) = New DB2Parameter("P_VCHPERAPELLIDOPATERNO", DB2Type.VarChar, 30)
                arrParam(1).Value = pCCOPERSONAL_BE.PropPERAPELLIDOPATERNO
                arrParam(2) = New DB2Parameter("P_VCHPERAPELLIDOMATERNO", DB2Type.VarChar, 30)
                arrParam(2).Value = pCCOPERSONAL_BE.PropPERAPELLIDOMATERNO
                arrParam(3) = New DB2Parameter("P_VCHPERNOMBRE", DB2Type.VarChar, 30)
                arrParam(3).Value = pCCOPERSONAL_BE.PropPERNOMBRE
                arrParam(4) = New DB2Parameter("P_VCHPERDNI", DB2Type.VarChar, 8)
                arrParam(4).Value = pCCOPERSONAL_BE.PropPERDNI
                arrParam(5) = New DB2Parameter("P_CHRUBICODIGO", DB2Type.Char, 6)
                arrParam(5).Value = pCCOPERSONAL_BE.PropUBICODIGO
                arrParam(6) = New DB2Parameter("P_SMLECICODIGO", DB2Type.SmallInt)
                arrParam(6).Value = pCCOPERSONAL_BE.PropECICODIGO
                arrParam(7) = New DB2Parameter("P_SMLGINCODIGO", DB2Type.SmallInt)
                arrParam(7).Value = pCCOPERSONAL_BE.PropGINCODIGO
                arrParam(8) = New DB2Parameter("P_SMLAFPCODIGO", DB2Type.SmallInt)
                arrParam(8).Value = pCCOPERSONAL_BE.PropAFPCODIGO
                arrParam(9) = New DB2Parameter("P_SMLMODCODIGO", DB2Type.SmallInt)
                arrParam(9).Value = pCCOPERSONAL_BE.PropMODCODIGO
                arrParam(10) = New DB2Parameter("P_SMLSECCODIGO", DB2Type.SmallInt)
                arrParam(10).Value = pCCOPERSONAL_BE.PropSECCODIGO
                arrParam(11) = New DB2Parameter("P_SMLCRGCODIGO", DB2Type.SmallInt)
                arrParam(11).Value = pCCOPERSONAL_BE.PropCRGCODIGO
                arrParam(12) = New DB2Parameter("P_SMLPERESTADO", DB2Type.SmallInt)
                arrParam(12).Value = pCCOPERSONAL_BE.PropPERESTADO

                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOPERSONAL_LISTARBUSQUEDA", arrParam)
                    odt.Load(dataReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return odt
        End Function

        Public Function ListarCombo() As DataSet
            Dim ods As DataSet = New DataSet
            Try

                Using dataset As DataSet = DB2helper.ExecuteDataset(cnDB2, CommandType.StoredProcedure, "CCOPERSONAL_LISTARCOMBO")
                    ods = dataset
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return ods
        End Function
    End Class

End Namespace
