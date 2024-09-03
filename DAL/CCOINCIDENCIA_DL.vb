Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class CCOINCIDENCIA_DL
		Private cnDB2 As DB2Connection

#Region "Numerador"
        Public Enum Campos
            INCCODIGO = 0
            INCNUMEROORIGEN = 1
            INCCOMENTARIO = 2
            INCLOCVIACODIGO1 = 3
            INCLOCVIANOMBRE1 = 4
            INCLOCVIACODIGO2 = 5
            INCLOCVIANOMBRE2 = 6
            INCLOCNUMERO = 7
            INCLOCCUADRA = 8
            INCLOCMANZANA = 9
            INCLOCLOTE = 10
            INCLOCDPTO = 11
            INCLOCBLOCK = 12
            INCLOCHABCODIGO = 13
            INCLOCHABNOMBRE = 14
            INCLOCSECTOR = 15
            INCLOCCUADRANTE = 16
            INCLOCCOMENTARIO = 17
            INCRELATO = 18
            INCANONIMO = 19
            INCNOMBRE = 20
            INCAPELLIDOS = 21
            INCNOMBRECOMP = 22
            INCDOCUMENTO = 23
            INCLLAVIACODIGO = 24
            INCLLAVIANOMBRE = 25
            INCLLANUMERO = 26
            INCLLACUADRA = 27
            INCLLAMANZANA = 28
            INCLLALOTE = 29
            INCLLADPTO = 30
            INCLLABLOCK = 31
            INCLLAHABCODIGO = 32
            INCLLAHABNOMBRE = 33
            INCLLASECTOR = 34
            INCLLACUADRANTE = 35
            INCLLACOMENTARIO = 36
            INCRESULTADO = 37
            INCESTADO = 38
            AUDFECCREACION = 39
            AUDFECMODIF = 40
            AUDUSUCREACION = 41
            AUDUSUMODIF = 42
            INCACODIGO = 43
            INCANUMERO = 44
            ADMCODIGO = 45
            PRECODIGO = 46
            INCIDLATITUDE = 47
            INCIDLONGITUDE = 48
            ORICODIGO = 49
            TINCODIGO = 50
            STICODIGO = 51
            PRICODIGO = 52
            TPECODIGO = 53
            TIDCODIGO = 54
            INCINTERVENIDOS = 55
            PAQCODIGO = 56
            PINCODIGO = 57
            AUDROLCREACION = 58
            AUDROLMODIF = 59
            INCUSUDERIVADO = 60
            INCROLDERIVADO = 61
            INCFECDERIVADO = 62
            RESCODIGO = 63
            AUDPRGCREACION = 64
            AUDPRGMODIF = 65
            AUDEQPCREACION = 66
            AUDEQPMODIF = 67
            CATCODIGO = 68
            INCFECHA = 69
            INCIDANEXO = 70
            INCIDLLAMADA = 71
            INCPARTEPOLICIAL = 72
            VCHMOTIVOALERTA = 73
            VCHCODQUEJA = 74
            VCHINCLOCXGEO = 75
            VCHINCLOCYGEO = 76
            VCHINCLOCCUADRANTE = 77
            VCHINCLOCSECTOR = 78
        End Enum
#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

		Public Sub Insertar(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE)
			Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(67) {}
				arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.INTEGER)
				arrParam(0).Value = pCCOINCIDENCIA_BE.PropINCCODIGO
				arrParam(1) = New DB2Parameter("P_VCHINCNUMEROORIGEN", DB2Type.VARCHAR, 15)
				arrParam(1).Value = pCCOINCIDENCIA_BE.PropINCNUMEROORIGEN
				arrParam(2) = New DB2Parameter("P_VCHINCCOMENTARIO", DB2Type.VARCHAR, 500)
				arrParam(2).Value = pCCOINCIDENCIA_BE.PropINCCOMENTARIO
				arrParam(3) = New DB2Parameter("P_VCHINCLOCVIACCODIGO1", DB2Type.VARCHAR, 6)
                arrParam(3).Value = pCCOINCIDENCIA_BE.PropINCLOCVIACODIGO1
				arrParam(4) = New DB2Parameter("P_VCHINCLOCVIANOMBRE1", DB2Type.VARCHAR, 150)
				arrParam(4).Value = pCCOINCIDENCIA_BE.PropINCLOCVIANOMBRE1
				arrParam(5) = New DB2Parameter("P_VCHINCLOCVIACCODIGO2", DB2Type.VARCHAR, 6)
                arrParam(5).Value = pCCOINCIDENCIA_BE.PropINCLOCVIACODIGO2
				arrParam(6) = New DB2Parameter("P_VCHINCLOCVIANOMBRE2", DB2Type.VARCHAR, 150)
				arrParam(6).Value = pCCOINCIDENCIA_BE.PropINCLOCVIANOMBRE2
				arrParam(7) = New DB2Parameter("P_VCHINCLOCNUMERO", DB2Type.VARCHAR, 10)
				arrParam(7).Value = pCCOINCIDENCIA_BE.PropINCLOCNUMERO
				arrParam(8) = New DB2Parameter("P_VCHINCLOCCUADRA", DB2Type.VARCHAR, 10)
				arrParam(8).Value = pCCOINCIDENCIA_BE.PropINCLOCCUADRA
                arrParam(9) = New DB2Parameter("P_VCHINCLOCMANZANA", DB2Type.VarChar, 10)
                arrParam(9).Value = pCCOINCIDENCIA_BE.PropINCLOCMANZANA
				arrParam(10) = New DB2Parameter("P_VCHINCLOCLOTE", DB2Type.VARCHAR, 10)
				arrParam(10).Value = pCCOINCIDENCIA_BE.PropINCLOCLOTE
				arrParam(11) = New DB2Parameter("P_VCHINCLOCDPTO", DB2Type.VARCHAR, 10)
				arrParam(11).Value = pCCOINCIDENCIA_BE.PropINCLOCDPTO
				arrParam(12) = New DB2Parameter("P_VCHINCLOCBLOCK", DB2Type.VARCHAR, 10)
				arrParam(12).Value = pCCOINCIDENCIA_BE.PropINCLOCBLOCK
				arrParam(13) = New DB2Parameter("P_CHRINCLOCHABCODIGO", DB2Type.CHAR, 4)
				arrParam(13).Value = pCCOINCIDENCIA_BE.PropINCLOCHABCODIGO
				arrParam(14) = New DB2Parameter("P_VCHINCLOCHABNOMBRE", DB2Type.VARCHAR, 100)
				arrParam(14).Value = pCCOINCIDENCIA_BE.PropINCLOCHABNOMBRE
				arrParam(15) = New DB2Parameter("P_VCHINCLOCSECTOR", DB2Type.VARCHAR, 10)
				arrParam(15).Value = pCCOINCIDENCIA_BE.PropINCLOCSECTOR
				arrParam(16) = New DB2Parameter("P_VCHINCLOCCUADRANTE", DB2Type.VARCHAR, 10)
				arrParam(16).Value = pCCOINCIDENCIA_BE.PropINCLOCCUADRANTE
				arrParam(17) = New DB2Parameter("P_VCHINCLOCCOMENTARIO", DB2Type.VARCHAR, 250)
				arrParam(17).Value = pCCOINCIDENCIA_BE.PropINCLOCCOMENTARIO
				arrParam(18) = New DB2Parameter("P_VCHINCRELATO", DB2Type.VARCHAR, 500)
				arrParam(18).Value = pCCOINCIDENCIA_BE.PropINCRELATO
				arrParam(19) = New DB2Parameter("P_SMLINCANONIMO", DB2Type.SMALLINT)
				arrParam(19).Value = pCCOINCIDENCIA_BE.PropINCANONIMO
				arrParam(20) = New DB2Parameter("P_VCHINCNOMBRE", DB2Type.VARCHAR, 30)
				arrParam(20).Value = pCCOINCIDENCIA_BE.PropINCNOMBRE
				arrParam(21) = New DB2Parameter("P_VCHINCAPELLIDOS", DB2Type.VARCHAR, 50)
				arrParam(21).Value = pCCOINCIDENCIA_BE.PropINCAPELLIDOS
				arrParam(22) = New DB2Parameter("P_VCHINCDOCUMENTO", DB2Type.VARCHAR, 20)
				arrParam(22).Value = pCCOINCIDENCIA_BE.PropINCDOCUMENTO
				arrParam(23) = New DB2Parameter("P_VCHINCLLAVIACODIGO", DB2Type.VARCHAR, 6)
				arrParam(23).Value = pCCOINCIDENCIA_BE.PropINCLLAVIACODIGO
				arrParam(24) = New DB2Parameter("P_VCHINCLLAVIANOMBRE", DB2Type.VARCHAR, 150)
				arrParam(24).Value = pCCOINCIDENCIA_BE.PropINCLLAVIANOMBRE
				arrParam(25) = New DB2Parameter("P_VCHINCLLANUMERO", DB2Type.VARCHAR, 10)
				arrParam(25).Value = pCCOINCIDENCIA_BE.PropINCLLANUMERO
                arrParam(26) = New DB2Parameter("P_VCHINCLLAMANZANA", DB2Type.VarChar, 10)
                arrParam(26).Value = pCCOINCIDENCIA_BE.PropINCLLAMANZANA
				arrParam(27) = New DB2Parameter("P_VCHINCLLALOTE", DB2Type.VARCHAR, 10)
				arrParam(27).Value = pCCOINCIDENCIA_BE.PropINCLLALOTE
				arrParam(28) = New DB2Parameter("P_VCHINCLLADPTO", DB2Type.VARCHAR, 10)
				arrParam(28).Value = pCCOINCIDENCIA_BE.PropINCLLADPTO
				arrParam(29) = New DB2Parameter("P_VCHINCLLABLOCK", DB2Type.VARCHAR, 10)
				arrParam(29).Value = pCCOINCIDENCIA_BE.PropINCLLABLOCK
				arrParam(30) = New DB2Parameter("P_CHRINCLLAHABCODIGO", DB2Type.CHAR, 4)
				arrParam(30).Value = pCCOINCIDENCIA_BE.PropINCLLAHABCODIGO
				arrParam(31) = New DB2Parameter("P_VCHINCLLAHABNOMBRE", DB2Type.VARCHAR, 100)
				arrParam(31).Value = pCCOINCIDENCIA_BE.PropINCLLAHABNOMBRE
				arrParam(32) = New DB2Parameter("P_VCHINCLLASECTOR", DB2Type.VARCHAR, 10)
				arrParam(32).Value = pCCOINCIDENCIA_BE.PropINCLLASECTOR
				arrParam(33) = New DB2Parameter("P_VCHINCLLACUADRANTE", DB2Type.VARCHAR, 10)
				arrParam(33).Value = pCCOINCIDENCIA_BE.PropINCLLACUADRANTE
				arrParam(34) = New DB2Parameter("P_VCHINCLLACOMENTARIO", DB2Type.VARCHAR, 250)
				arrParam(34).Value = pCCOINCIDENCIA_BE.PropINCLLACOMENTARIO
				arrParam(35) = New DB2Parameter("P_VCHINCRESULTADO", DB2Type.VARCHAR, 500)
				arrParam(35).Value = pCCOINCIDENCIA_BE.PropINCRESULTADO
				arrParam(36) = New DB2Parameter("P_SMLINCESTADO", DB2Type.SMALLINT)
				arrParam(36).Value = pCCOINCIDENCIA_BE.PropINCESTADO
				arrParam(37) = New DB2Parameter("P_DTMAUDFECCREACION", DB2Type.TIMESTAMP)
				arrParam(37).Value = pCCOINCIDENCIA_BE.PropAUDFECCREACION
				arrParam(38) = New DB2Parameter("P_DTMAUDFECMODIF", DB2Type.TIMESTAMP)
				arrParam(38).Value = pCCOINCIDENCIA_BE.PropAUDFECMODIF
				arrParam(39) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VARCHAR, 10)
				arrParam(39).Value = pCCOINCIDENCIA_BE.PropAUDUSUCREACION
				arrParam(40) = New DB2Parameter("P_VCHAUDUSUMODIF", DB2Type.VARCHAR, 10)
				arrParam(40).Value = pCCOINCIDENCIA_BE.PropAUDUSUMODIF
				arrParam(41) = New DB2Parameter("P_INTINCACODIGO", DB2Type.INTEGER)
				arrParam(41).Value = pCCOINCIDENCIA_BE.PropINCACODIGO
				arrParam(42) = New DB2Parameter("P_INTINCANUMERO", DB2Type.INTEGER)
				arrParam(42).Value = pCCOINCIDENCIA_BE.PropINCANUMERO
				arrParam(43) = New DB2Parameter("P_INTADMCODIGO", DB2Type.INTEGER)
				arrParam(43).Value = pCCOINCIDENCIA_BE.PropADMCODIGO
				arrParam(44) = New DB2Parameter("P_INTPRECODIGO", DB2Type.INTEGER)
				arrParam(44).Value = pCCOINCIDENCIA_BE.PropPRECODIGO
                arrParam(45) = New DB2Parameter("P_VCHINCIDLATITUDE", DB2Type.VarChar)
				arrParam(45).Value = pCCOINCIDENCIA_BE.PropINCIDLATITUDE
                arrParam(46) = New DB2Parameter("P_VCHINCIDLONGITUDE", DB2Type.VarChar)
				arrParam(46).Value = pCCOINCIDENCIA_BE.PropINCIDLONGITUDE
				arrParam(47) = New DB2Parameter("P_SMLORICODIGO", DB2Type.SMALLINT)
				arrParam(47).Value = pCCOINCIDENCIA_BE.PropORICODIGO
				arrParam(48) = New DB2Parameter("P_SMLTINCODIGO", DB2Type.SMALLINT)
				arrParam(48).Value = pCCOINCIDENCIA_BE.PropTINCODIGO
				arrParam(49) = New DB2Parameter("P_SMLSTICODIGO", DB2Type.SMALLINT)
				arrParam(49).Value = pCCOINCIDENCIA_BE.PropSTICODIGO
				arrParam(50) = New DB2Parameter("P_SMLPRICODIGO", DB2Type.SMALLINT)
				arrParam(50).Value = pCCOINCIDENCIA_BE.PropPRICODIGO
				arrParam(51) = New DB2Parameter("P_SMLTPECODIGO", DB2Type.SMALLINT)
				arrParam(51).Value = pCCOINCIDENCIA_BE.PropTPECODIGO
                arrParam(52) = New DB2Parameter("P_VCHTIDCODIGO", DB2Type.VarChar, 2)
                arrParam(52).Value = pCCOINCIDENCIA_BE.PropTIDCODIGO
                arrParam(53) = New DB2Parameter("P_SMLINCINTERVENIDOS", DB2Type.SmallInt)
				arrParam(53).Value = pCCOINCIDENCIA_BE.PropINCINTERVENIDOS
				arrParam(54) = New DB2Parameter("P_INTPAQCODIGO", DB2Type.INTEGER)
				arrParam(54).Value = pCCOINCIDENCIA_BE.PropPAQCODIGO
				arrParam(55) = New DB2Parameter("P_VCHPINCODIGO", DB2Type.VARCHAR, 15)
				arrParam(55).Value = pCCOINCIDENCIA_BE.PropPINCODIGO
				arrParam(56) = New DB2Parameter("P_INTAUDROLCREACION", DB2Type.INTEGER)
				arrParam(56).Value = pCCOINCIDENCIA_BE.PropAUDROLCREACION
				arrParam(57) = New DB2Parameter("P_INTAUDROLMODIF", DB2Type.INTEGER)
				arrParam(57).Value = pCCOINCIDENCIA_BE.PropAUDROLMODIF
				arrParam(58) = New DB2Parameter("P_VCHINCUSUDERIVADO", DB2Type.VARCHAR, 10)
				arrParam(58).Value = pCCOINCIDENCIA_BE.PropINCUSUDERIVADO
				arrParam(59) = New DB2Parameter("P_INTINCROLDERIVADO", DB2Type.INTEGER)
				arrParam(59).Value = pCCOINCIDENCIA_BE.PropINCROLDERIVADO
				arrParam(60) = New DB2Parameter("P_DTMINCFECDERIVADO", DB2Type.TIMESTAMP)
				arrParam(60).Value = pCCOINCIDENCIA_BE.PropINCFECDERIVADO
				arrParam(61) = New DB2Parameter("P_SMLRESCODIGO", DB2Type.SMALLINT)
				arrParam(61).Value = pCCOINCIDENCIA_BE.PropRESCODIGO
				arrParam(62) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VARCHAR, 150)
				arrParam(62).Value = pCCOINCIDENCIA_BE.PropAUDPRGCREACION
				arrParam(63) = New DB2Parameter("P_VCHAUDPRGMODIF", DB2Type.VARCHAR, 150)
				arrParam(63).Value = pCCOINCIDENCIA_BE.PropAUDPRGMODIF
				arrParam(64) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VARCHAR, 60)
				arrParam(64).Value = pCCOINCIDENCIA_BE.PropAUDEQPCREACION
				arrParam(65) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VARCHAR, 60)
				arrParam(65).Value = pCCOINCIDENCIA_BE.PropAUDEQPMODIF
				arrParam(66) = New DB2Parameter("P_VCHCATCODIGO", DB2Type.VARCHAR, 14)
                arrParam(66).Value = pCCOINCIDENCIA_BE.PropCATCODIGO
                arrParam(67) = New DB2Parameter("P_VCHINCLLACUADRA", DB2Type.VarChar, 10)
                arrParam(67).Value = pCCOINCIDENCIA_BE.PropINCLLACUADRA

                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIA_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(71) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOINCIDENCIA_BE.PropINCCODIGO
                arrParam(1) = New DB2Parameter("P_VCHINCNUMEROORIGEN", DB2Type.VARCHAR, 15)
                arrParam(1).Value = pCCOINCIDENCIA_BE.PropINCNUMEROORIGEN
                arrParam(2) = New DB2Parameter("P_VCHINCCOMENTARIO", DB2Type.VARCHAR, 500)
                arrParam(2).Value = pCCOINCIDENCIA_BE.PropINCCOMENTARIO
                arrParam(3) = New DB2Parameter("P_VCHINCLOCVIACODIGO1", DB2Type.VARCHAR, 6)
                arrParam(3).Value = pCCOINCIDENCIA_BE.PropINCLOCVIACODIGO1
                arrParam(4) = New DB2Parameter("P_VCHINCLOCVIANOMBRE1", DB2Type.VARCHAR, 150)
                arrParam(4).Value = pCCOINCIDENCIA_BE.PropINCLOCVIANOMBRE1
                arrParam(5) = New DB2Parameter("P_VCHINCLOCVIACODIGO2", DB2Type.VARCHAR, 6)
                arrParam(5).Value = pCCOINCIDENCIA_BE.PropINCLOCVIACODIGO2
                arrParam(6) = New DB2Parameter("P_VCHINCLOCVIANOMBRE2", DB2Type.VARCHAR, 150)
                arrParam(6).Value = pCCOINCIDENCIA_BE.PropINCLOCVIANOMBRE2
                arrParam(7) = New DB2Parameter("P_VCHINCLOCNUMERO", DB2Type.VARCHAR, 10)
                arrParam(7).Value = pCCOINCIDENCIA_BE.PropINCLOCNUMERO
                arrParam(8) = New DB2Parameter("P_VCHINCLOCCUADRA", DB2Type.VARCHAR, 10)
                arrParam(8).Value = pCCOINCIDENCIA_BE.PropINCLOCCUADRA
                arrParam(9) = New DB2Parameter("P_VCHINCLOCMANZANA", DB2Type.VarChar, 10)
                arrParam(9).Value = pCCOINCIDENCIA_BE.PropINCLOCMANZANA
                arrParam(10) = New DB2Parameter("P_VCHINCLOCLOTE", DB2Type.VARCHAR, 10)
                arrParam(10).Value = pCCOINCIDENCIA_BE.PropINCLOCLOTE
                arrParam(11) = New DB2Parameter("P_VCHINCLOCDPTO", DB2Type.VARCHAR, 10)
                arrParam(11).Value = pCCOINCIDENCIA_BE.PropINCLOCDPTO
                arrParam(12) = New DB2Parameter("P_VCHINCLOCBLOCK", DB2Type.VARCHAR, 10)
                arrParam(12).Value = pCCOINCIDENCIA_BE.PropINCLOCBLOCK
                arrParam(13) = New DB2Parameter("P_CHRINCLOCHABCODIGO", DB2Type.CHAR, 4)
                arrParam(13).Value = pCCOINCIDENCIA_BE.PropINCLOCHABCODIGO
                arrParam(14) = New DB2Parameter("P_VCHINCLOCHABNOMBRE", DB2Type.VARCHAR, 100)
                arrParam(14).Value = pCCOINCIDENCIA_BE.PropINCLOCHABNOMBRE
                arrParam(15) = New DB2Parameter("P_SMLINCLOCSECTOR", DB2Type.SMALLINT)
                arrParam(15).Value = pCCOINCIDENCIA_BE.PropINCLOCSECTOR
                arrParam(16) = New DB2Parameter("P_SMLINCLOCCUADRANTE", DB2Type.SMALLINT)
                arrParam(16).Value = pCCOINCIDENCIA_BE.PropINCLOCCUADRANTE
                arrParam(17) = New DB2Parameter("P_VCHINCLOCCOMENTARIO", DB2Type.VARCHAR, 250)
                arrParam(17).Value = pCCOINCIDENCIA_BE.PropINCLOCCOMENTARIO
                arrParam(18) = New DB2Parameter("P_VCHINCRELATO", DB2Type.VARCHAR, 500)
                arrParam(18).Value = pCCOINCIDENCIA_BE.PropINCRELATO
                arrParam(19) = New DB2Parameter("P_SMLINCANONIMO", DB2Type.SMALLINT)
                arrParam(19).Value = pCCOINCIDENCIA_BE.PropINCANONIMO
                arrParam(20) = New DB2Parameter("P_VCHINCNOMBRE", DB2Type.VARCHAR, 30)
                arrParam(20).Value = pCCOINCIDENCIA_BE.PropINCNOMBRE
                arrParam(21) = New DB2Parameter("P_VCHINCAPELLIDOS", DB2Type.VARCHAR, 50)
                arrParam(21).Value = pCCOINCIDENCIA_BE.PropINCAPELLIDOS
                arrParam(22) = New DB2Parameter("P_VCHINCNOMBRECOMP", DB2Type.VARCHAR, 100)
                arrParam(22).Value = pCCOINCIDENCIA_BE.PropINCNOMBRECOMP
                arrParam(23) = New DB2Parameter("P_VCHINCDOCUMENTO", DB2Type.VARCHAR, 20)
                arrParam(23).Value = pCCOINCIDENCIA_BE.PropINCDOCUMENTO
                arrParam(24) = New DB2Parameter("P_VCHINCLLAVIACODIGO", DB2Type.VARCHAR, 6)
                arrParam(24).Value = pCCOINCIDENCIA_BE.PropINCLLAVIACODIGO
                arrParam(25) = New DB2Parameter("P_VCHINCLLAVIANOMBRE", DB2Type.VARCHAR, 150)
                arrParam(25).Value = pCCOINCIDENCIA_BE.PropINCLLAVIANOMBRE
                arrParam(26) = New DB2Parameter("P_VCHINCLLANUMERO", DB2Type.VARCHAR, 10)
                arrParam(26).Value = pCCOINCIDENCIA_BE.PropINCLLANUMERO
                arrParam(27) = New DB2Parameter("P_VCHINCLLAMANZANA", DB2Type.VarChar, 10)
                arrParam(27).Value = pCCOINCIDENCIA_BE.PropINCLLAMANZANA
                arrParam(28) = New DB2Parameter("P_VCHINCLLALOTE", DB2Type.VARCHAR, 10)
                arrParam(28).Value = pCCOINCIDENCIA_BE.PropINCLLALOTE
                arrParam(29) = New DB2Parameter("P_VCHINCLLADPTO", DB2Type.VARCHAR, 10)
                arrParam(29).Value = pCCOINCIDENCIA_BE.PropINCLLADPTO
                arrParam(30) = New DB2Parameter("P_VCHINCLLABLOCK", DB2Type.VARCHAR, 10)
                arrParam(30).Value = pCCOINCIDENCIA_BE.PropINCLLABLOCK
                arrParam(31) = New DB2Parameter("P_CHRINCLLAHABCODIGO", DB2Type.CHAR, 4)
                arrParam(31).Value = pCCOINCIDENCIA_BE.PropINCLLAHABCODIGO
                arrParam(32) = New DB2Parameter("P_VCHINCLLAHABNOMBRE", DB2Type.VARCHAR, 100)
                arrParam(32).Value = pCCOINCIDENCIA_BE.PropINCLLAHABNOMBRE
                arrParam(33) = New DB2Parameter("P_SMLINCLLASECTOR", DB2Type.SMALLINT)
                arrParam(33).Value = pCCOINCIDENCIA_BE.PropINCLLASECTOR
                arrParam(34) = New DB2Parameter("P_SMLINCLLACUADRANTE", DB2Type.SMALLINT)
                arrParam(34).Value = pCCOINCIDENCIA_BE.PropINCLLACUADRANTE
                arrParam(35) = New DB2Parameter("P_VCHINCLLACOMENTARIO", DB2Type.VARCHAR, 250)
                arrParam(35).Value = pCCOINCIDENCIA_BE.PropINCLLACOMENTARIO
                arrParam(36) = New DB2Parameter("P_VCHINCRESULTADO", DB2Type.VARCHAR, 500)
                arrParam(36).Value = pCCOINCIDENCIA_BE.PropINCRESULTADO
                arrParam(37) = New DB2Parameter("P_SMLINCESTADO", DB2Type.SMALLINT)
                arrParam(37).Value = pCCOINCIDENCIA_BE.PropINCESTADO
                arrParam(38) = New DB2Parameter("P_DTMAUDFECCREACION", DB2Type.TIMESTAMP)
                arrParam(38).Value = pCCOINCIDENCIA_BE.PropAUDFECCREACION
                arrParam(39) = New DB2Parameter("P_DTMAUDFECMODIF", DB2Type.TIMESTAMP)
                arrParam(39).Value = pCCOINCIDENCIA_BE.PropAUDFECMODIF
                arrParam(40) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VARCHAR, 15)
                arrParam(40).Value = pCCOINCIDENCIA_BE.PropAUDUSUCREACION
                arrParam(41) = New DB2Parameter("P_VCHAUDUSUMODIF", DB2Type.VARCHAR, 15)
                arrParam(41).Value = pCCOINCIDENCIA_BE.PropAUDUSUMODIF
                arrParam(42) = New DB2Parameter("P_INTINCACODIGO", DB2Type.INTEGER)
                arrParam(42).Value = pCCOINCIDENCIA_BE.PropINCACODIGO
                arrParam(43) = New DB2Parameter("P_INTINCANUMERO", DB2Type.INTEGER)
                arrParam(43).Value = pCCOINCIDENCIA_BE.PropINCANUMERO
                arrParam(44) = New DB2Parameter("P_INTADMCODIGO", DB2Type.INTEGER)
                arrParam(44).Value = pCCOINCIDENCIA_BE.PropADMCODIGO
                arrParam(45) = New DB2Parameter("P_INTPRECODIGO", DB2Type.INTEGER)
                arrParam(45).Value = pCCOINCIDENCIA_BE.PropPRECODIGO
                arrParam(46) = New DB2Parameter("P_VCHINCIDLATITUDE", DB2Type.VARCHAR, 20)
                arrParam(46).Value = pCCOINCIDENCIA_BE.PropINCIDLATITUDE
                arrParam(47) = New DB2Parameter("P_VCHINCIDLONGITUDE", DB2Type.VARCHAR, 20)
                arrParam(47).Value = pCCOINCIDENCIA_BE.PropINCIDLONGITUDE
                arrParam(48) = New DB2Parameter("P_SMLORICODIGO", DB2Type.SMALLINT)
                arrParam(48).Value = pCCOINCIDENCIA_BE.PropORICODIGO
                arrParam(49) = New DB2Parameter("P_SMLTINCODIGO", DB2Type.SMALLINT)
                arrParam(49).Value = pCCOINCIDENCIA_BE.PropTINCODIGO
                arrParam(50) = New DB2Parameter("P_SMLSTICODIGO", DB2Type.SMALLINT)
                arrParam(50).Value = pCCOINCIDENCIA_BE.PropSTICODIGO
                arrParam(51) = New DB2Parameter("P_SMLPRICODIGO", DB2Type.SMALLINT)
                arrParam(51).Value = pCCOINCIDENCIA_BE.PropPRICODIGO
                arrParam(52) = New DB2Parameter("P_SMLTPECODIGO", DB2Type.SMALLINT)
                arrParam(52).Value = pCCOINCIDENCIA_BE.PropTPECODIGO
                arrParam(53) = New DB2Parameter("P_VCHTIDCODIGO", DB2Type.VARCHAR, 2)
                arrParam(53).Value = pCCOINCIDENCIA_BE.PropTIDCODIGO
                arrParam(54) = New DB2Parameter("P_SMLINCINTERVENIDOS", DB2Type.SMALLINT)
                arrParam(54).Value = pCCOINCIDENCIA_BE.PropINCINTERVENIDOS
                arrParam(55) = New DB2Parameter("P_INTPAQCODIGO", DB2Type.INTEGER)
                arrParam(55).Value = pCCOINCIDENCIA_BE.PropPAQCODIGO
                arrParam(56) = New DB2Parameter("P_INTPINCODIGO", DB2Type.INTEGER)
                arrParam(56).Value = pCCOINCIDENCIA_BE.PropPINCODIGO
                arrParam(57) = New DB2Parameter("P_INTAUDROLCREACION", DB2Type.INTEGER)
                arrParam(57).Value = pCCOINCIDENCIA_BE.PropAUDROLCREACION
                arrParam(58) = New DB2Parameter("P_INTAUDROLMODIF", DB2Type.INTEGER)
                arrParam(58).Value = pCCOINCIDENCIA_BE.PropAUDROLMODIF
                arrParam(59) = New DB2Parameter("P_VCHINCUSUDERIVADO", DB2Type.VARCHAR, 15)
                arrParam(59).Value = pCCOINCIDENCIA_BE.PropINCUSUDERIVADO
                arrParam(60) = New DB2Parameter("P_INTINCROLDERIVADO", DB2Type.INTEGER)
                arrParam(60).Value = pCCOINCIDENCIA_BE.PropINCROLDERIVADO
                arrParam(61) = New DB2Parameter("P_DTMINCFECDERIVADO", DB2Type.TIMESTAMP)
                arrParam(61).Value = pCCOINCIDENCIA_BE.PropINCFECDERIVADO
                arrParam(62) = New DB2Parameter("P_SMLRESCODIGO", DB2Type.SMALLINT)
                arrParam(62).Value = pCCOINCIDENCIA_BE.PropRESCODIGO
                arrParam(63) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VARCHAR, 150)
                arrParam(63).Value = pCCOINCIDENCIA_BE.PropAUDPRGCREACION
                arrParam(64) = New DB2Parameter("P_VCHAUDPRGMODIF", DB2Type.VARCHAR, 150)
                arrParam(64).Value = pCCOINCIDENCIA_BE.PropAUDPRGMODIF
                arrParam(65) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VARCHAR, 60)
                arrParam(65).Value = pCCOINCIDENCIA_BE.PropAUDEQPCREACION
                arrParam(66) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VARCHAR, 60)
                arrParam(66).Value = pCCOINCIDENCIA_BE.PropAUDEQPMODIF
                arrParam(67) = New DB2Parameter("P_VCHCATCODIGO", DB2Type.VARCHAR, 14)
                arrParam(67).Value = pCCOINCIDENCIA_BE.PropCATCODIGO
                arrParam(68) = New DB2Parameter("P_DTMINCFECHA", DB2Type.TIMESTAMP)
                arrParam(68).Value = pCCOINCIDENCIA_BE.PropINCFECHA
                arrParam(69) = New DB2Parameter("P_VCHINCIDANEXO", DB2Type.VARCHAR, 5)
                arrParam(69).Value = pCCOINCIDENCIA_BE.PropINCIDANEXO
                arrParam(70) = New DB2Parameter("P_VCHINCIDLLAMADA", DB2Type.VARCHAR, 15)
                arrParam(70).Value = pCCOINCIDENCIA_BE.PropINCIDLLAMADA
                arrParam(71) = New DB2Parameter("P_VCHINCLLACUADRA", DB2Type.VarChar, 10)
                arrParam(71).Value = pCCOINCIDENCIA_BE.PropINCLLACUADRA

                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIA_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOINCIDENCIA_BE.PropINCCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIA_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE) As CCOINCIDENCIA_BE
            Dim oCCOINCIDENCIA_BE As New CCOINCIDENCIA_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOINCIDENCIA_BE.PropINCCODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "SADE.CCOINCIDENCIA_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.INCCODIGO) Then oCCOINCIDENCIA_BE.PropINCCODIGO = Nothing Else oCCOINCIDENCIA_BE.PropINCCODIGO = CType(oDataReader(Campos.INCCODIGO), Int32)
                    oCCOINCIDENCIA_BE.PropINCNUMEROORIGEN = IIf(oDataReader.IsDBNull(Campos.INCNUMEROORIGEN), "", oDataReader(Campos.INCNUMEROORIGEN))
                    oCCOINCIDENCIA_BE.PropINCCOMENTARIO = IIf(oDataReader.IsDBNull(Campos.INCCOMENTARIO), "", oDataReader(Campos.INCCOMENTARIO))
                    oCCOINCIDENCIA_BE.PropINCLOCVIACODIGO1 = IIf(oDataReader.IsDBNull(Campos.INCLOCVIACODIGO1), "", oDataReader(Campos.INCLOCVIACODIGO1))
                    oCCOINCIDENCIA_BE.PropINCLOCVIANOMBRE1 = IIf(oDataReader.IsDBNull(Campos.INCLOCVIANOMBRE1), "", oDataReader(Campos.INCLOCVIANOMBRE1))
                    oCCOINCIDENCIA_BE.PropINCLOCVIACODIGO2 = IIf(oDataReader.IsDBNull(Campos.INCLOCVIACODIGO2), "", oDataReader(Campos.INCLOCVIACODIGO2))
                    oCCOINCIDENCIA_BE.PropINCLOCVIANOMBRE2 = IIf(oDataReader.IsDBNull(Campos.INCLOCVIANOMBRE2), "", oDataReader(Campos.INCLOCVIANOMBRE2))
                    oCCOINCIDENCIA_BE.PropINCLOCNUMERO = IIf(oDataReader.IsDBNull(Campos.INCLOCNUMERO), "", oDataReader(Campos.INCLOCNUMERO))
                    oCCOINCIDENCIA_BE.PropINCLOCCUADRA = IIf(oDataReader.IsDBNull(Campos.INCLOCCUADRA), "", oDataReader(Campos.INCLOCCUADRA))
                    oCCOINCIDENCIA_BE.PropINCLOCMANZANA = IIf(oDataReader.IsDBNull(Campos.INCLOCMANZANA), "", oDataReader(Campos.INCLOCMANZANA))
                    oCCOINCIDENCIA_BE.PropINCLOCLOTE = IIf(oDataReader.IsDBNull(Campos.INCLOCLOTE), "", oDataReader(Campos.INCLOCLOTE))
                    oCCOINCIDENCIA_BE.PropINCLOCDPTO = IIf(oDataReader.IsDBNull(Campos.INCLOCDPTO), "", oDataReader(Campos.INCLOCDPTO))
                    oCCOINCIDENCIA_BE.PropINCLOCBLOCK = IIf(oDataReader.IsDBNull(Campos.INCLOCBLOCK), "", oDataReader(Campos.INCLOCBLOCK))
                    oCCOINCIDENCIA_BE.PropINCLOCHABCODIGO = IIf(oDataReader.IsDBNull(Campos.INCLOCHABCODIGO), "", oDataReader(Campos.INCLOCHABCODIGO))
                    oCCOINCIDENCIA_BE.PropINCLOCHABNOMBRE = IIf(oDataReader.IsDBNull(Campos.INCLOCHABNOMBRE), "", oDataReader(Campos.INCLOCHABNOMBRE))
                    If oDataReader.IsDBNull(Campos.INCLOCSECTOR) Then oCCOINCIDENCIA_BE.PropINCLOCSECTOR = Nothing Else oCCOINCIDENCIA_BE.PropINCLOCSECTOR = CType(oDataReader(Campos.INCLOCSECTOR), Int16)
                    If oDataReader.IsDBNull(Campos.INCLOCCUADRANTE) Then oCCOINCIDENCIA_BE.PropINCLOCCUADRANTE = Nothing Else oCCOINCIDENCIA_BE.PropINCLOCCUADRANTE = CType(oDataReader(Campos.INCLOCCUADRANTE), Int16)
                    oCCOINCIDENCIA_BE.PropINCLOCCOMENTARIO = IIf(oDataReader.IsDBNull(Campos.INCLOCCOMENTARIO), "", oDataReader(Campos.INCLOCCOMENTARIO))
                    oCCOINCIDENCIA_BE.PropINCRELATO = IIf(oDataReader.IsDBNull(Campos.INCRELATO), "", oDataReader(Campos.INCRELATO))
                    If oDataReader.IsDBNull(Campos.INCANONIMO) Then oCCOINCIDENCIA_BE.PropINCANONIMO = Nothing Else oCCOINCIDENCIA_BE.PropINCANONIMO = CType(oDataReader(Campos.INCANONIMO), Int16)
                    oCCOINCIDENCIA_BE.PropINCNOMBRE = IIf(oDataReader.IsDBNull(Campos.INCNOMBRE), "", oDataReader(Campos.INCNOMBRE))
                    oCCOINCIDENCIA_BE.PropINCAPELLIDOS = IIf(oDataReader.IsDBNull(Campos.INCAPELLIDOS), "", oDataReader(Campos.INCAPELLIDOS))
                    oCCOINCIDENCIA_BE.PropINCNOMBRECOMP = IIf(oDataReader.IsDBNull(Campos.INCNOMBRECOMP), "", oDataReader(Campos.INCNOMBRECOMP))
                    oCCOINCIDENCIA_BE.PropINCDOCUMENTO = IIf(oDataReader.IsDBNull(Campos.INCDOCUMENTO), "", oDataReader(Campos.INCDOCUMENTO))
                    oCCOINCIDENCIA_BE.PropINCLLAVIACODIGO = IIf(oDataReader.IsDBNull(Campos.INCLLAVIACODIGO), "", oDataReader(Campos.INCLLAVIACODIGO))
                    oCCOINCIDENCIA_BE.PropINCLLAVIANOMBRE = IIf(oDataReader.IsDBNull(Campos.INCLLAVIANOMBRE), "", oDataReader(Campos.INCLLAVIANOMBRE))
                    oCCOINCIDENCIA_BE.PropINCLLANUMERO = IIf(oDataReader.IsDBNull(Campos.INCLLANUMERO), "", oDataReader(Campos.INCLLANUMERO))
                    oCCOINCIDENCIA_BE.PropINCLLACUADRA = IIf(oDataReader.IsDBNull(Campos.INCLLACUADRA), "", oDataReader(Campos.INCLLACUADRA))
                    oCCOINCIDENCIA_BE.PropINCLLAMANZANA = IIf(oDataReader.IsDBNull(Campos.INCLLAMANZANA), "", oDataReader(Campos.INCLLAMANZANA))
                    oCCOINCIDENCIA_BE.PropINCLLALOTE = IIf(oDataReader.IsDBNull(Campos.INCLLALOTE), "", oDataReader(Campos.INCLLALOTE))
                    oCCOINCIDENCIA_BE.PropINCLLADPTO = IIf(oDataReader.IsDBNull(Campos.INCLLADPTO), "", oDataReader(Campos.INCLLADPTO))
                    oCCOINCIDENCIA_BE.PropINCLLABLOCK = IIf(oDataReader.IsDBNull(Campos.INCLLABLOCK), "", oDataReader(Campos.INCLLABLOCK))
                    oCCOINCIDENCIA_BE.PropINCLLAHABCODIGO = IIf(oDataReader.IsDBNull(Campos.INCLLAHABCODIGO), "", oDataReader(Campos.INCLLAHABCODIGO))
                    oCCOINCIDENCIA_BE.PropINCLLAHABNOMBRE = IIf(oDataReader.IsDBNull(Campos.INCLLAHABNOMBRE), "", oDataReader(Campos.INCLLAHABNOMBRE))
                    If oDataReader.IsDBNull(Campos.INCLLASECTOR) Then oCCOINCIDENCIA_BE.PropINCLLASECTOR = Nothing Else oCCOINCIDENCIA_BE.PropINCLLASECTOR = CType(oDataReader(Campos.INCLLASECTOR), Int16)
                    If oDataReader.IsDBNull(Campos.INCLLACUADRANTE) Then oCCOINCIDENCIA_BE.PropINCLLACUADRANTE = Nothing Else oCCOINCIDENCIA_BE.PropINCLLACUADRANTE = CType(oDataReader(Campos.INCLLACUADRANTE), Int16)
                    oCCOINCIDENCIA_BE.PropINCLLACOMENTARIO = IIf(oDataReader.IsDBNull(Campos.INCLLACOMENTARIO), "", oDataReader(Campos.INCLLACOMENTARIO))
                    oCCOINCIDENCIA_BE.PropINCRESULTADO = IIf(oDataReader.IsDBNull(Campos.INCRESULTADO), "", oDataReader(Campos.INCRESULTADO))
                    If oDataReader.IsDBNull(Campos.INCESTADO) Then oCCOINCIDENCIA_BE.PropINCESTADO = Nothing Else oCCOINCIDENCIA_BE.PropINCESTADO = CType(oDataReader(Campos.INCESTADO), Int16)
                    If oDataReader.IsDBNull(Campos.AUDFECCREACION) Then oCCOINCIDENCIA_BE.PropAUDFECCREACION = Nothing Else oCCOINCIDENCIA_BE.PropAUDFECCREACION = CType(oDataReader(Campos.AUDFECCREACION), DateTime)
                    If oDataReader.IsDBNull(Campos.AUDFECMODIF) Then oCCOINCIDENCIA_BE.PropAUDFECMODIF = Nothing Else oCCOINCIDENCIA_BE.PropAUDFECMODIF = CType(oDataReader(Campos.AUDFECMODIF), DateTime)
                    oCCOINCIDENCIA_BE.PropAUDUSUCREACION = IIf(oDataReader.IsDBNull(Campos.AUDUSUCREACION), "", oDataReader(Campos.AUDUSUCREACION))
                    oCCOINCIDENCIA_BE.PropAUDUSUMODIF = IIf(oDataReader.IsDBNull(Campos.AUDUSUMODIF), "", oDataReader(Campos.AUDUSUMODIF))
                    If oDataReader.IsDBNull(Campos.INCACODIGO) Then oCCOINCIDENCIA_BE.PropINCACODIGO = Nothing Else oCCOINCIDENCIA_BE.PropINCACODIGO = CType(oDataReader(Campos.INCACODIGO), Int32)
                    If oDataReader.IsDBNull(Campos.INCANUMERO) Then oCCOINCIDENCIA_BE.PropINCANUMERO = Nothing Else oCCOINCIDENCIA_BE.PropINCANUMERO = CType(oDataReader(Campos.INCANUMERO), Int32)
                    If oDataReader.IsDBNull(Campos.ADMCODIGO) Then oCCOINCIDENCIA_BE.PropADMCODIGO = Nothing Else oCCOINCIDENCIA_BE.PropADMCODIGO = CType(oDataReader(Campos.ADMCODIGO), Int32)
                    If oDataReader.IsDBNull(Campos.PRECODIGO) Then oCCOINCIDENCIA_BE.PropPRECODIGO = Nothing Else oCCOINCIDENCIA_BE.PropPRECODIGO = CType(oDataReader(Campos.PRECODIGO), Int32)
                    oCCOINCIDENCIA_BE.PropINCIDLATITUDE = IIf(oDataReader.IsDBNull(Campos.INCIDLATITUDE), "", oDataReader(Campos.INCIDLATITUDE))
                    oCCOINCIDENCIA_BE.PropINCIDLONGITUDE = IIf(oDataReader.IsDBNull(Campos.INCIDLONGITUDE), "", oDataReader(Campos.INCIDLONGITUDE))
                    If oDataReader.IsDBNull(Campos.ORICODIGO) Then oCCOINCIDENCIA_BE.PropORICODIGO = Nothing Else oCCOINCIDENCIA_BE.PropORICODIGO = CType(oDataReader(Campos.ORICODIGO), Int16)
                    If oDataReader.IsDBNull(Campos.TINCODIGO) Then oCCOINCIDENCIA_BE.PropTINCODIGO = Nothing Else oCCOINCIDENCIA_BE.PropTINCODIGO = CType(oDataReader(Campos.TINCODIGO), Int16)
                    If oDataReader.IsDBNull(Campos.STICODIGO) Then oCCOINCIDENCIA_BE.PropSTICODIGO = Nothing Else oCCOINCIDENCIA_BE.PropSTICODIGO = CType(oDataReader(Campos.STICODIGO), Int16)
                    If oDataReader.IsDBNull(Campos.PRICODIGO) Then oCCOINCIDENCIA_BE.PropPRICODIGO = Nothing Else oCCOINCIDENCIA_BE.PropPRICODIGO = CType(oDataReader(Campos.PRICODIGO), Int16)
                    If oDataReader.IsDBNull(Campos.TPECODIGO) Then oCCOINCIDENCIA_BE.PropTPECODIGO = Nothing Else oCCOINCIDENCIA_BE.PropTPECODIGO = CType(oDataReader(Campos.TPECODIGO), Int16)
                    oCCOINCIDENCIA_BE.PropTIDCODIGO = IIf(oDataReader.IsDBNull(Campos.TIDCODIGO), "", oDataReader(Campos.TIDCODIGO))
                    If oDataReader.IsDBNull(Campos.INCINTERVENIDOS) Then oCCOINCIDENCIA_BE.PropINCINTERVENIDOS = Nothing Else oCCOINCIDENCIA_BE.PropINCINTERVENIDOS = CType(oDataReader(Campos.INCINTERVENIDOS), Int16)
                    If oDataReader.IsDBNull(Campos.PAQCODIGO) Then oCCOINCIDENCIA_BE.PropPAQCODIGO = Nothing Else oCCOINCIDENCIA_BE.PropPAQCODIGO = CType(oDataReader(Campos.PAQCODIGO), Int32)
                    If oDataReader.IsDBNull(Campos.PINCODIGO) Then oCCOINCIDENCIA_BE.PropPINCODIGO = Nothing Else oCCOINCIDENCIA_BE.PropPINCODIGO = CType(oDataReader(Campos.PINCODIGO), Int32)
                    If oDataReader.IsDBNull(Campos.AUDROLCREACION) Then oCCOINCIDENCIA_BE.PropAUDROLCREACION = Nothing Else oCCOINCIDENCIA_BE.PropAUDROLCREACION = CType(oDataReader(Campos.AUDROLCREACION), Int32)
                    If oDataReader.IsDBNull(Campos.AUDROLMODIF) Then oCCOINCIDENCIA_BE.PropAUDROLMODIF = Nothing Else oCCOINCIDENCIA_BE.PropAUDROLMODIF = CType(oDataReader(Campos.AUDROLMODIF), Int32)
                    oCCOINCIDENCIA_BE.PropINCUSUDERIVADO = IIf(oDataReader.IsDBNull(Campos.INCUSUDERIVADO), "", oDataReader(Campos.INCUSUDERIVADO))
                    If oDataReader.IsDBNull(Campos.INCROLDERIVADO) Then oCCOINCIDENCIA_BE.PropINCROLDERIVADO = Nothing Else oCCOINCIDENCIA_BE.PropINCROLDERIVADO = CType(oDataReader(Campos.INCROLDERIVADO), Int32)
                    If oDataReader.IsDBNull(Campos.INCFECDERIVADO) Then oCCOINCIDENCIA_BE.PropINCFECDERIVADO = Nothing Else oCCOINCIDENCIA_BE.PropINCFECDERIVADO = CType(oDataReader(Campos.INCFECDERIVADO), DateTime)
                    If oDataReader.IsDBNull(Campos.RESCODIGO) Then oCCOINCIDENCIA_BE.PropRESCODIGO = Nothing Else oCCOINCIDENCIA_BE.PropRESCODIGO = CType(oDataReader(Campos.RESCODIGO), Int16)
                    oCCOINCIDENCIA_BE.PropAUDPRGCREACION = IIf(oDataReader.IsDBNull(Campos.AUDPRGCREACION), "", oDataReader(Campos.AUDPRGCREACION))
                    oCCOINCIDENCIA_BE.PropAUDPRGMODIF = IIf(oDataReader.IsDBNull(Campos.AUDPRGMODIF), "", oDataReader(Campos.AUDPRGMODIF))
                    oCCOINCIDENCIA_BE.PropAUDEQPCREACION = IIf(oDataReader.IsDBNull(Campos.AUDEQPCREACION), "", oDataReader(Campos.AUDEQPCREACION))
                    oCCOINCIDENCIA_BE.PropAUDEQPMODIF = IIf(oDataReader.IsDBNull(Campos.AUDEQPMODIF), "", oDataReader(Campos.AUDEQPMODIF))
                    oCCOINCIDENCIA_BE.PropCATCODIGO = IIf(oDataReader.IsDBNull(Campos.CATCODIGO), "", oDataReader(Campos.CATCODIGO))
                    If oDataReader.IsDBNull(Campos.INCFECHA) Then oCCOINCIDENCIA_BE.PropINCFECHA = Nothing Else oCCOINCIDENCIA_BE.PropINCFECHA = CType(oDataReader(Campos.INCFECHA), DateTime)
                    oCCOINCIDENCIA_BE.PropINCIDANEXO = IIf(oDataReader.IsDBNull(Campos.INCIDANEXO), "", oDataReader(Campos.INCIDANEXO))
                    oCCOINCIDENCIA_BE.PropINCIDLLAMADA = IIf(oDataReader.IsDBNull(Campos.INCIDLLAMADA), "", oDataReader(Campos.INCIDLLAMADA))
                    If oDataReader.IsDBNull(Campos.INCPARTEPOLICIAL) Then oCCOINCIDENCIA_BE.PropINCPARTEPOLICIAL = Nothing Else oCCOINCIDENCIA_BE.PropINCPARTEPOLICIAL = CType(oDataReader(Campos.INCPARTEPOLICIAL), Int16)
                    oCCOINCIDENCIA_BE.PropVCHMOTIVOALERTA = IIf(oDataReader.IsDBNull(Campos.VCHMOTIVOALERTA), "", oDataReader(Campos.VCHMOTIVOALERTA))
                    oCCOINCIDENCIA_BE.PropVCHCODQUEJA = IIf(oDataReader.IsDBNull(Campos.VCHCODQUEJA), "", oDataReader(Campos.VCHCODQUEJA))
                    oCCOINCIDENCIA_BE.PropINCLOCXGEO = IIf(oDataReader.IsDBNull(Campos.VCHINCLOCXGEO), "", oDataReader(Campos.VCHINCLOCXGEO))
                    oCCOINCIDENCIA_BE.PropINCLOCYGEO = IIf(oDataReader.IsDBNull(Campos.VCHINCLOCYGEO), "", oDataReader(Campos.VCHINCLOCYGEO))
                    oCCOINCIDENCIA_BE.PropVCHINCLOCCUADRANTE = IIf(oDataReader.IsDBNull(Campos.VCHINCLOCCUADRANTE), "", oDataReader(Campos.VCHINCLOCCUADRANTE))
                    oCCOINCIDENCIA_BE.PropVCHINCLOCSECTOR = IIf(oDataReader.IsDBNull(Campos.VCHINCLOCSECTOR), "", oDataReader(Campos.VCHINCLOCSECTOR))

                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oCCOINCIDENCIA_BE

        End Function

        Public Function Listar(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE, ByVal pBuscaTodo As Integer) As DataTable
            Dim odt As New DataTable

            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(17) {}

                arrParam(0) = New DB2Parameter("P_SMLORICODIGO", DB2Type.SmallInt)
                arrParam(0).Value = pCCOINCIDENCIA_BE.PropORICODIGO
                arrParam(1) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(1).Value = pCCOINCIDENCIA_BE.PropINCCODIGO
                arrParam(2) = New DB2Parameter("P_SMLTINCODIGO", DB2Type.SmallInt)
                arrParam(2).Value = pCCOINCIDENCIA_BE.PropTINCODIGO
                arrParam(3) = New DB2Parameter("P_SMLSTICODIGO", DB2Type.SmallInt)
                arrParam(3).Value = pCCOINCIDENCIA_BE.PropSTICODIGO
                arrParam(4) = New DB2Parameter("P_SMLPRICODIGO", DB2Type.SmallInt)
                arrParam(4).Value = pCCOINCIDENCIA_BE.PropPRICODIGO
                arrParam(5) = New DB2Parameter("P_VCHINCNOMBRE", DB2Type.VarChar, 30)
                arrParam(5).Value = pCCOINCIDENCIA_BE.PropINCNOMBRECOMP
                arrParam(6) = New DB2Parameter("P_VCHINCLOCVIANOMBRE1", DB2Type.VarChar, 150)
                arrParam(6).Value = pCCOINCIDENCIA_BE.PropINCLOCVIANOMBRE1
                arrParam(7) = New DB2Parameter("P_VCHINCNUMEROORIGEN", DB2Type.VarChar, 15)
                arrParam(7).Value = pCCOINCIDENCIA_BE.PropINCNUMEROORIGEN
                arrParam(8) = New DB2Parameter("P_VCHINCRELATO", DB2Type.VarChar, 500)
                arrParam(8).Value = pCCOINCIDENCIA_BE.PropINCRELATO
                arrParam(9) = New DB2Parameter("P_SMLINCESTADO", DB2Type.SmallInt)
                arrParam(9).Value = pCCOINCIDENCIA_BE.PropINCESTADO

                arrParam(10) = New DB2Parameter("P_INTAUDROLMODIF", DB2Type.Integer)
                arrParam(10).Value = pCCOINCIDENCIA_BE.PropAUDROLMODIF

                arrParam(11) = New DB2Parameter("P_INTRECCODIGO", DB2Type.Integer)
                arrParam(11).Value = pCCOINCIDENCIA_BE.PropPAQCODIGO
                arrParam(12) = New DB2Parameter("P_VCHINCLOCSECTOR", DB2Type.VarChar, 5)
                arrParam(12).Value = pCCOINCIDENCIA_BE.PropVCHINCLOCSECTOR

                arrParam(13) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VarChar, 50)
                arrParam(13).Value = pCCOINCIDENCIA_BE.PropAUDUSUCREACION

                arrParam(14) = New DB2Parameter("P_VCHFECHAINI", DB2Type.Date, 10)
                arrParam(14).Value = pCCOINCIDENCIA_BE.PropAUDFECCREACION
                arrParam(15) = New DB2Parameter("P_VCHFECHAFIN", DB2Type.Date, 10)
                arrParam(15).Value = pCCOINCIDENCIA_BE.PropAUDFECMODIF

                arrParam(16) = New DB2Parameter("P_VCHRECCODIGO", DB2Type.VarChar, 15)
                arrParam(16).Value = pCCOINCIDENCIA_BE.PropINCNOMBRE

                arrParam(17) = New DB2Parameter("P_BUSCATODO", DB2Type.Integer)
                arrParam(17).Value = pBuscaTodo



                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIA_BUSQUEDA_SADE2", arrParam)
                    odt.Load(dataReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return odt
        End Function

        Public Sub InsertFromSIP(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(9) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOINCIDENCIA_BE.PropINCCODIGO
                arrParam(1) = New DB2Parameter("P_SMLORICODIGO", DB2Type.SmallInt)
                arrParam(1).Value = pCCOINCIDENCIA_BE.PropORICODIGO
                arrParam(2) = New DB2Parameter("P_VCHINCNUMEROORIGEN", DB2Type.VarChar, 15)
                arrParam(2).Value = pCCOINCIDENCIA_BE.PropINCNUMEROORIGEN
                '--- ID LLAMADA, ANEXO RECIBE, 
                arrParam(3) = New DB2Parameter("P_VCHINCIDLLAMADA", DB2Type.VarChar, 15)
                arrParam(3).Value = pCCOINCIDENCIA_BE.PropINCIDLLAMADA
                arrParam(4) = New DB2Parameter("P_VCHINCIDANEXON", DB2Type.VarChar, 5)
                arrParam(4).Value = pCCOINCIDENCIA_BE.PropINCIDANEXO
                arrParam(5) = New DB2Parameter("P_SMLINCESTADO", DB2Type.SmallInt)
                arrParam(5).Value = pCCOINCIDENCIA_BE.PropINCESTADO
                arrParam(6) = New DB2Parameter("P_DTMAUDFECCREACION", DB2Type.Timestamp)
                arrParam(6).Value = pCCOINCIDENCIA_BE.PropAUDFECCREACION
                arrParam(7) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VarChar, 10)
                arrParam(7).Value = pCCOINCIDENCIA_BE.PropAUDUSUCREACION
                arrParam(8) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VarChar, 150)
                arrParam(8).Value = pCCOINCIDENCIA_BE.PropAUDPRGCREACION
                arrParam(9) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VarChar, 60)
                arrParam(9).Value = pCCOINCIDENCIA_BE.PropAUDEQPCREACION
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIA_INSERTAR_SIP", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function InsertarMan(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE) As Integer
            Dim result As Integer = 0
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(67) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(0).Direction = ParameterDirection.Output
                arrParam(1) = New DB2Parameter("P_VCHINCNUMEROORIGEN", DB2Type.VarChar, 15)
                arrParam(1).Value = pCCOINCIDENCIA_BE.PropINCNUMEROORIGEN
                arrParam(2) = New DB2Parameter("P_VCHINCCOMENTARIO", DB2Type.VarChar, 500)
                arrParam(2).Value = pCCOINCIDENCIA_BE.PropINCCOMENTARIO
                arrParam(3) = New DB2Parameter("P_VCHINCLOCVIACCODIGO1", DB2Type.VarChar, 6)
                arrParam(3).Value = pCCOINCIDENCIA_BE.PropINCLOCVIACODIGO1
                arrParam(4) = New DB2Parameter("P_VCHINCLOCVIANOMBRE1", DB2Type.VarChar, 150)
                arrParam(4).Value = pCCOINCIDENCIA_BE.PropINCLOCVIANOMBRE1
                arrParam(5) = New DB2Parameter("P_VCHINCLOCVIACCODIGO2", DB2Type.VarChar, 6)
                arrParam(5).Value = pCCOINCIDENCIA_BE.PropINCLOCVIACODIGO2
                arrParam(6) = New DB2Parameter("P_VCHINCLOCVIANOMBRE2", DB2Type.VarChar, 150)
                arrParam(6).Value = pCCOINCIDENCIA_BE.PropINCLOCVIANOMBRE2
                arrParam(7) = New DB2Parameter("P_VCHINCLOCNUMERO", DB2Type.VarChar, 10)
                arrParam(7).Value = pCCOINCIDENCIA_BE.PropINCLOCNUMERO
                arrParam(8) = New DB2Parameter("P_VCHINCLOCCUADRA", DB2Type.VarChar, 10)
                arrParam(8).Value = pCCOINCIDENCIA_BE.PropINCLOCCUADRA
                arrParam(9) = New DB2Parameter("P_VCHINCLOCMANZANA", DB2Type.VarChar, 10)
                arrParam(9).Value = pCCOINCIDENCIA_BE.PropINCLOCMANZANA
                arrParam(10) = New DB2Parameter("P_VCHINCLOCLOTE", DB2Type.VarChar, 10)
                arrParam(10).Value = pCCOINCIDENCIA_BE.PropINCLOCLOTE
                arrParam(11) = New DB2Parameter("P_VCHINCLOCDPTO", DB2Type.VarChar, 10)
                arrParam(11).Value = pCCOINCIDENCIA_BE.PropINCLOCDPTO
                arrParam(12) = New DB2Parameter("P_VCHINCLOCBLOCK", DB2Type.VarChar, 10)
                arrParam(12).Value = pCCOINCIDENCIA_BE.PropINCLOCBLOCK
                arrParam(13) = New DB2Parameter("P_CHRINCLOCHABCODIGO", DB2Type.Char, 4)
                arrParam(13).Value = pCCOINCIDENCIA_BE.PropINCLOCHABCODIGO
                arrParam(14) = New DB2Parameter("P_VCHINCLOCHABNOMBRE", DB2Type.VarChar, 100)
                arrParam(14).Value = pCCOINCIDENCIA_BE.PropINCLOCHABNOMBRE
                arrParam(15) = New DB2Parameter("P_SMLINCLOCSECTOR", DB2Type.SmallInt)
                arrParam(15).Value = pCCOINCIDENCIA_BE.PropINCLOCSECTOR
                arrParam(16) = New DB2Parameter("P_SMLINCLOCCUADRANTE", DB2Type.SmallInt)
                arrParam(16).Value = pCCOINCIDENCIA_BE.PropINCLOCCUADRANTE
                arrParam(17) = New DB2Parameter("P_VCHINCLOCCOMENTARIO", DB2Type.VarChar, 250)
                arrParam(17).Value = pCCOINCIDENCIA_BE.PropINCLOCCOMENTARIO
                arrParam(18) = New DB2Parameter("P_VCHINCRELATO", DB2Type.VarChar, 500)
                arrParam(18).Value = pCCOINCIDENCIA_BE.PropINCRELATO
                arrParam(19) = New DB2Parameter("P_SMLINCANONIMO", DB2Type.SmallInt)
                arrParam(19).Value = pCCOINCIDENCIA_BE.PropINCANONIMO
                arrParam(20) = New DB2Parameter("P_VCHINCNOMBRE", DB2Type.VarChar, 30)
                arrParam(20).Value = pCCOINCIDENCIA_BE.PropINCNOMBRE
                arrParam(21) = New DB2Parameter("P_VCHINCAPELLIDOS", DB2Type.VarChar, 50)
                arrParam(21).Value = pCCOINCIDENCIA_BE.PropINCAPELLIDOS
                arrParam(22) = New DB2Parameter("P_VCHINCDOCUMENTO", DB2Type.VarChar, 20)
                arrParam(22).Value = pCCOINCIDENCIA_BE.PropINCDOCUMENTO
                arrParam(23) = New DB2Parameter("P_VCHINCLLAVIACODIGO", DB2Type.VarChar, 6)
                arrParam(23).Value = pCCOINCIDENCIA_BE.PropINCLLAVIACODIGO
                arrParam(24) = New DB2Parameter("P_VCHINCLLAVIANOMBRE", DB2Type.VarChar, 150)
                arrParam(24).Value = pCCOINCIDENCIA_BE.PropINCLLAVIANOMBRE
                arrParam(25) = New DB2Parameter("P_VCHINCLLANUMERO", DB2Type.VarChar, 10)
                arrParam(25).Value = pCCOINCIDENCIA_BE.PropINCLLANUMERO
                arrParam(26) = New DB2Parameter("P_VCHINCLLAMANZANA", DB2Type.VarChar, 10)
                arrParam(26).Value = pCCOINCIDENCIA_BE.PropINCLLAMANZANA
                arrParam(27) = New DB2Parameter("P_VCHINCLLALOTE", DB2Type.VarChar, 10)
                arrParam(27).Value = pCCOINCIDENCIA_BE.PropINCLLALOTE
                arrParam(28) = New DB2Parameter("P_VCHINCLLADPTO", DB2Type.VarChar, 10)
                arrParam(28).Value = pCCOINCIDENCIA_BE.PropINCLLADPTO
                arrParam(29) = New DB2Parameter("P_VCHINCLLABLOCK", DB2Type.VarChar, 10)
                arrParam(29).Value = pCCOINCIDENCIA_BE.PropINCLLABLOCK
                arrParam(30) = New DB2Parameter("P_CHRINCLLAHABCODIGO", DB2Type.Char, 4)
                arrParam(30).Value = pCCOINCIDENCIA_BE.PropINCLLAHABCODIGO
                arrParam(31) = New DB2Parameter("P_VCHINCLLAHABNOMBRE", DB2Type.VarChar, 100)
                arrParam(31).Value = pCCOINCIDENCIA_BE.PropINCLLAHABNOMBRE
                arrParam(32) = New DB2Parameter("P_SMLINCLLASECTOR", DB2Type.SmallInt)
                arrParam(32).Value = pCCOINCIDENCIA_BE.PropINCLLASECTOR
                arrParam(33) = New DB2Parameter("P_SMLINCLLACUADRANTE", DB2Type.SmallInt)
                arrParam(33).Value = pCCOINCIDENCIA_BE.PropINCLLACUADRANTE
                arrParam(34) = New DB2Parameter("P_VCHINCLLACOMENTARIO", DB2Type.VarChar, 250)
                arrParam(34).Value = pCCOINCIDENCIA_BE.PropINCLLACOMENTARIO
                arrParam(35) = New DB2Parameter("P_VCHINCRESULTADO", DB2Type.VarChar, 500)
                arrParam(35).Value = pCCOINCIDENCIA_BE.PropINCRESULTADO
                arrParam(36) = New DB2Parameter("P_SMLINCESTADO", DB2Type.SmallInt)
                arrParam(36).Value = pCCOINCIDENCIA_BE.PropINCESTADO
                arrParam(37) = New DB2Parameter("P_DTMAUDFECCREACION", DB2Type.Timestamp)
                arrParam(37).Value = pCCOINCIDENCIA_BE.PropAUDFECCREACION
                arrParam(38) = New DB2Parameter("P_DTMAUDFECMODIF", DB2Type.Timestamp)
                arrParam(38).Value = pCCOINCIDENCIA_BE.PropAUDFECMODIF
                arrParam(39) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VarChar, 10)
                arrParam(39).Value = pCCOINCIDENCIA_BE.PropAUDUSUCREACION
                arrParam(40) = New DB2Parameter("P_VCHAUDUSUMODIF", DB2Type.VarChar, 10)
                arrParam(40).Value = pCCOINCIDENCIA_BE.PropAUDUSUMODIF
                arrParam(41) = New DB2Parameter("P_INTINCACODIGO", DB2Type.Integer)
                arrParam(41).Value = pCCOINCIDENCIA_BE.PropINCACODIGO
                arrParam(42) = New DB2Parameter("P_INTINCANUMERO", DB2Type.Integer)
                arrParam(42).Value = pCCOINCIDENCIA_BE.PropINCANUMERO
                arrParam(43) = New DB2Parameter("P_INTADMCODIGO", DB2Type.Integer)
                arrParam(43).Value = pCCOINCIDENCIA_BE.PropADMCODIGO
                arrParam(44) = New DB2Parameter("P_INTPRECODIGO", DB2Type.Integer)
                arrParam(44).Value = pCCOINCIDENCIA_BE.PropPRECODIGO
                arrParam(45) = New DB2Parameter("P_VCHINCIDLATITUDE", DB2Type.VarChar)
                arrParam(45).Value = pCCOINCIDENCIA_BE.PropINCIDLATITUDE
                arrParam(46) = New DB2Parameter("P_VCHINCIDLONGITUDE", DB2Type.VarChar)
                arrParam(46).Value = pCCOINCIDENCIA_BE.PropINCIDLONGITUDE
                arrParam(47) = New DB2Parameter("P_SMLORICODIGO", DB2Type.SmallInt)
                arrParam(47).Value = pCCOINCIDENCIA_BE.PropORICODIGO
                arrParam(48) = New DB2Parameter("P_SMLTINCODIGO", DB2Type.SmallInt)
                arrParam(48).Value = pCCOINCIDENCIA_BE.PropTINCODIGO
                arrParam(49) = New DB2Parameter("P_SMLSTICODIGO", DB2Type.SmallInt)
                arrParam(49).Value = pCCOINCIDENCIA_BE.PropSTICODIGO
                arrParam(50) = New DB2Parameter("P_SMLPRICODIGO", DB2Type.SmallInt)
                arrParam(50).Value = pCCOINCIDENCIA_BE.PropPRICODIGO
                arrParam(51) = New DB2Parameter("P_SMLTPECODIGO", DB2Type.SmallInt)
                arrParam(51).Value = pCCOINCIDENCIA_BE.PropTPECODIGO
                arrParam(52) = New DB2Parameter("P_VCHTIDCODIGO", DB2Type.VarChar, 2)
                arrParam(52).Value = pCCOINCIDENCIA_BE.PropTIDCODIGO
                arrParam(53) = New DB2Parameter("P_SMLINCINTERVENIDOS", DB2Type.SmallInt)
                arrParam(53).Value = pCCOINCIDENCIA_BE.PropINCINTERVENIDOS
                arrParam(54) = New DB2Parameter("P_INTPAQCODIGO", DB2Type.Integer)
                arrParam(54).Value = pCCOINCIDENCIA_BE.PropPAQCODIGO
                arrParam(55) = New DB2Parameter("P_VCHPINCODIGO", DB2Type.VarChar, 15)
                arrParam(55).Value = pCCOINCIDENCIA_BE.PropPINCODIGO
                arrParam(56) = New DB2Parameter("P_INTAUDROLCREACION", DB2Type.Integer)
                arrParam(56).Value = pCCOINCIDENCIA_BE.PropAUDROLCREACION
                arrParam(57) = New DB2Parameter("P_INTAUDROLMODIF", DB2Type.Integer)
                arrParam(57).Value = pCCOINCIDENCIA_BE.PropAUDROLMODIF
                arrParam(58) = New DB2Parameter("P_VCHINCUSUDERIVADO", DB2Type.VarChar, 10)
                arrParam(58).Value = pCCOINCIDENCIA_BE.PropINCUSUDERIVADO
                arrParam(59) = New DB2Parameter("P_INTINCROLDERIVADO", DB2Type.Integer)
                arrParam(59).Value = pCCOINCIDENCIA_BE.PropINCROLDERIVADO
                arrParam(60) = New DB2Parameter("P_DTMINCFECDERIVADO", DB2Type.Timestamp)
                arrParam(60).Value = pCCOINCIDENCIA_BE.PropINCFECDERIVADO
                arrParam(61) = New DB2Parameter("P_SMLRESCODIGO", DB2Type.SmallInt)
                arrParam(61).Value = pCCOINCIDENCIA_BE.PropRESCODIGO
                arrParam(62) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VarChar, 150)
                arrParam(62).Value = pCCOINCIDENCIA_BE.PropAUDPRGCREACION

                arrParam(63) = New DB2Parameter("P_VCHAUDPRGMODIF", DB2Type.VarChar, 150)
                arrParam(63).Value = pCCOINCIDENCIA_BE.PropAUDPRGMODIF

                arrParam(64) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VarChar, 60)
                arrParam(64).Value = pCCOINCIDENCIA_BE.PropAUDEQPCREACION
                arrParam(65) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VarChar, 60)
                arrParam(65).Value = pCCOINCIDENCIA_BE.PropAUDEQPMODIF
                arrParam(66) = New DB2Parameter("P_VCHCATCODIGO", DB2Type.VarChar, 20)
                arrParam(66).Value = pCCOINCIDENCIA_BE.PropCATCODIGO

                arrParam(67) = New DB2Parameter("P_VCHINCLLACUADRA", DB2Type.VarChar, 10)
                arrParam(67).Value = pCCOINCIDENCIA_BE.PropINCLLACUADRA

                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIA_INSERTAR", arrParam)
                result = arrParam(0).Value
                Return result
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return result
        End Function

        Public Sub DerivarIncidencia(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(10) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOINCIDENCIA_BE.PropINCCODIGO
                arrParam(1) = New DB2Parameter("P_VCHINCCOMENTARIO", DB2Type.VarChar, 500)
                arrParam(1).Value = pCCOINCIDENCIA_BE.PropINCCOMENTARIO
                arrParam(2) = New DB2Parameter("P_SMLINCESTADO", DB2Type.SmallInt)
                arrParam(2).Value = pCCOINCIDENCIA_BE.PropINCESTADO
                arrParam(3) = New DB2Parameter("P_DTMAUDFECMODIF", DB2Type.Timestamp)
                arrParam(3).Value = pCCOINCIDENCIA_BE.PropAUDFECMODIF
                arrParam(4) = New DB2Parameter("P_VCHAUDUSUMODIF", DB2Type.VarChar, 10)
                arrParam(4).Value = pCCOINCIDENCIA_BE.PropAUDUSUMODIF
                arrParam(5) = New DB2Parameter("P_VCHINCUSUDERIVADO", DB2Type.VarChar, 10)
                arrParam(5).Value = pCCOINCIDENCIA_BE.PropINCUSUDERIVADO
                arrParam(6) = New DB2Parameter("P_INTINCROLDERIVADO", DB2Type.Integer)
                arrParam(6).Value = pCCOINCIDENCIA_BE.PropINCROLDERIVADO
                arrParam(8) = New DB2Parameter("P_DTMINCFECDERIVADO", DB2Type.Timestamp)
                arrParam(8).Value = pCCOINCIDENCIA_BE.PropINCFECDERIVADO
                arrParam(9) = New DB2Parameter("P_VCHAUDPRGMODIF", DB2Type.VarChar, 150)
                arrParam(9).Value = pCCOINCIDENCIA_BE.PropAUDPRGMODIF
                arrParam(10) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VarChar, 60)
                arrParam(10).Value = pCCOINCIDENCIA_BE.PropAUDEQPMODIF
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIA_DERIVACION", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub CancelarDerivarIncidencia(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(10) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOINCIDENCIA_BE.PropINCCODIGO
                arrParam(1) = New DB2Parameter("P_VCHINCCOMENTARIO", DB2Type.VarChar, 500)
                arrParam(1).Value = pCCOINCIDENCIA_BE.PropINCCOMENTARIO
                arrParam(2) = New DB2Parameter("P_SMLINCESTADO", DB2Type.SmallInt)
                arrParam(2).Value = pCCOINCIDENCIA_BE.PropINCESTADO
                arrParam(3) = New DB2Parameter("P_DTMAUDFECMODIF", DB2Type.Timestamp)
                arrParam(3).Value = pCCOINCIDENCIA_BE.PropAUDFECMODIF
                arrParam(4) = New DB2Parameter("P_VCHAUDUSUMODIF", DB2Type.VarChar, 10)
                arrParam(4).Value = pCCOINCIDENCIA_BE.PropAUDUSUMODIF
                arrParam(5) = New DB2Parameter("P_VCHINCUSUDERIVADO", DB2Type.VarChar, 10)
                arrParam(5).Value = pCCOINCIDENCIA_BE.PropINCUSUDERIVADO
                arrParam(6) = New DB2Parameter("P_INTINCROLDERIVADO", DB2Type.Integer)
                arrParam(6).Value = pCCOINCIDENCIA_BE.PropINCROLDERIVADO
                arrParam(8) = New DB2Parameter("P_DTMINCFECDERIVADO", DB2Type.Timestamp)
                arrParam(8).Value = pCCOINCIDENCIA_BE.PropINCFECDERIVADO
                arrParam(9) = New DB2Parameter("P_VCHAUDPRGMODIF", DB2Type.VarChar, 150)
                arrParam(9).Value = pCCOINCIDENCIA_BE.PropAUDPRGMODIF
                arrParam(10) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VarChar, 60)
                arrParam(10).Value = pCCOINCIDENCIA_BE.PropAUDEQPMODIF
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIA_CANCELADERIVACION", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function InsertFromALertaSurco(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE) As Integer
            Dim result As Integer
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(19) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(0).Direction = ParameterDirection.Output
                arrParam(1) = New DB2Parameter("P_VCHINCNUMEROORIGEN", DB2Type.VarChar, 15)
                arrParam(1).Value = pCCOINCIDENCIA_BE.PropINCNUMEROORIGEN
                arrParam(2) = New DB2Parameter("P_VCHINCRELATO", DB2Type.VarChar, 500)
                arrParam(2).Value = pCCOINCIDENCIA_BE.PropINCRELATO
                arrParam(3) = New DB2Parameter("P_VCHINCNOMBRE", DB2Type.VarChar, 100)
                arrParam(3).Value = pCCOINCIDENCIA_BE.PropINCNOMBRE
                arrParam(4) = New DB2Parameter("P_SMLINCESTADO", DB2Type.SmallInt)
                arrParam(4).Value = pCCOINCIDENCIA_BE.PropINCESTADO
                arrParam(5) = New DB2Parameter("P_DTMAUDFECCREACION", DB2Type.Timestamp)
                arrParam(5).Value = pCCOINCIDENCIA_BE.PropAUDFECCREACION
                arrParam(6) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VarChar, 15)
                arrParam(6).Value = pCCOINCIDENCIA_BE.PropAUDUSUCREACION
                arrParam(7) = New DB2Parameter("P_VCHINCIDLATITUDE", DB2Type.VarChar, 50)
                arrParam(7).Value = pCCOINCIDENCIA_BE.PropINCIDLATITUDE
                arrParam(8) = New DB2Parameter("P_VCHINCIDLONGITUDE", DB2Type.VarChar, 50)
                arrParam(8).Value = pCCOINCIDENCIA_BE.PropINCIDLONGITUDE
                arrParam(9) = New DB2Parameter("P_SMLORICODIGO", DB2Type.SmallInt)
                arrParam(9).Value = pCCOINCIDENCIA_BE.PropORICODIGO
                arrParam(10) = New DB2Parameter("P_INTAUDROLCREACION", DB2Type.Integer)
                arrParam(10).Value = pCCOINCIDENCIA_BE.PropAUDROLCREACION
                arrParam(11) = New DB2Parameter("P_INTAUDROLMODIF", DB2Type.Integer)
                arrParam(11).Value = pCCOINCIDENCIA_BE.PropAUDROLMODIF
                arrParam(12) = New DB2Parameter("P_VCHINCUSUDERIVADO", DB2Type.VarChar, 15)
                arrParam(12).Value = pCCOINCIDENCIA_BE.PropINCUSUDERIVADO
                arrParam(13) = New DB2Parameter("P_INTINCROLDERIVADO", DB2Type.Integer)
                arrParam(13).Value = pCCOINCIDENCIA_BE.PropINCROLDERIVADO
                arrParam(14) = New DB2Parameter("P_DTMINCFECDERIVADO", DB2Type.Timestamp)
                arrParam(14).Value = pCCOINCIDENCIA_BE.PropINCFECDERIVADO
                arrParam(15) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VarChar, 60)
                arrParam(15).Value = pCCOINCIDENCIA_BE.PropAUDPRGCREACION
                arrParam(16) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VarChar, 60)
                arrParam(16).Value = pCCOINCIDENCIA_BE.PropAUDEQPCREACION
                arrParam(17) = New DB2Parameter("P_VCHINCIDLLAMADA", DB2Type.VarChar, 15)
                arrParam(17).Value = pCCOINCIDENCIA_BE.PropINCIDLLAMADA
                arrParam(18) = New DB2Parameter("P_VCHINCIDANEXO", DB2Type.VarChar, 5)
                arrParam(18).Value = pCCOINCIDENCIA_BE.PropINCIDANEXO
                arrParam(19) = New DB2Parameter("P_VCHMOTIVOALERTA", DB2Type.VarChar, 2)
                arrParam(19).Value = pCCOINCIDENCIA_BE.PropVCHMOTIVOALERTA

                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIA_INSERTAR_ALERTASURCO", arrParam)
                result = arrParam(0).Value
                Return result
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return result
        End Function

        Public Sub CerrarIncidencia(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(10) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOINCIDENCIA_BE.PropINCCODIGO
                arrParam(1) = New DB2Parameter("P_VCHINCCOMENTARIO", DB2Type.VarChar, 500)
                arrParam(1).Value = pCCOINCIDENCIA_BE.PropINCCOMENTARIO
                arrParam(2) = New DB2Parameter("P_SMLINCESTADO", DB2Type.SmallInt)
                arrParam(2).Value = pCCOINCIDENCIA_BE.PropINCESTADO
                arrParam(3) = New DB2Parameter("P_DTMAUDFECMODIF", DB2Type.Timestamp)
                arrParam(3).Value = pCCOINCIDENCIA_BE.PropAUDFECMODIF
                arrParam(4) = New DB2Parameter("P_VCHAUDUSUMODIF", DB2Type.VarChar, 10)
                arrParam(4).Value = pCCOINCIDENCIA_BE.PropAUDUSUMODIF
                arrParam(5) = New DB2Parameter("P_VCHINCUSUDERIVADO", DB2Type.VarChar, 10)
                arrParam(5).Value = pCCOINCIDENCIA_BE.PropINCUSUDERIVADO
                arrParam(6) = New DB2Parameter("P_INTINCROLDERIVADO", DB2Type.Integer)
                arrParam(6).Value = pCCOINCIDENCIA_BE.PropINCROLDERIVADO
                arrParam(8) = New DB2Parameter("P_DTMINCFECDERIVADO", DB2Type.Timestamp)
                arrParam(8).Value = pCCOINCIDENCIA_BE.PropINCFECDERIVADO
                arrParam(9) = New DB2Parameter("P_VCHAUDPRGMODIF", DB2Type.VarChar, 150)
                arrParam(9).Value = pCCOINCIDENCIA_BE.PropAUDPRGMODIF
                arrParam(10) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VarChar, 60)
                arrParam(10).Value = pCCOINCIDENCIA_BE.PropAUDEQPMODIF
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIA_CERRAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub DevolerAbiertaIncidencia(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(10) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOINCIDENCIA_BE.PropINCCODIGO
                arrParam(1) = New DB2Parameter("P_VCHINCCOMENTARIO", DB2Type.VarChar, 500)
                arrParam(1).Value = pCCOINCIDENCIA_BE.PropINCCOMENTARIO
                arrParam(2) = New DB2Parameter("P_SMLINCESTADO", DB2Type.SmallInt)
                arrParam(2).Value = pCCOINCIDENCIA_BE.PropINCESTADO
                arrParam(3) = New DB2Parameter("P_DTMAUDFECMODIF", DB2Type.Timestamp)
                arrParam(3).Value = pCCOINCIDENCIA_BE.PropAUDFECMODIF
                arrParam(4) = New DB2Parameter("P_VCHAUDUSUMODIF", DB2Type.VarChar, 10)
                arrParam(4).Value = pCCOINCIDENCIA_BE.PropAUDUSUMODIF
                arrParam(5) = New DB2Parameter("P_VCHINCUSUDERIVADO", DB2Type.VarChar, 10)
                arrParam(5).Value = pCCOINCIDENCIA_BE.PropINCUSUDERIVADO
                arrParam(6) = New DB2Parameter("P_INTINCROLDERIVADO", DB2Type.Integer)
                arrParam(6).Value = pCCOINCIDENCIA_BE.PropINCROLDERIVADO
                arrParam(8) = New DB2Parameter("P_DTMINCFECDERIVADO", DB2Type.Timestamp)
                arrParam(8).Value = pCCOINCIDENCIA_BE.PropINCFECDERIVADO
                arrParam(9) = New DB2Parameter("P_VCHAUDPRGMODIF", DB2Type.VarChar, 150)
                arrParam(9).Value = pCCOINCIDENCIA_BE.PropAUDPRGMODIF
                arrParam(10) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VarChar, 60)
                arrParam(10).Value = pCCOINCIDENCIA_BE.PropAUDEQPMODIF
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIA_DEVOLVERABIERTA", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub AtenderIncidencia(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(15) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOINCIDENCIA_BE.PropINCCODIGO
                arrParam(1) = New DB2Parameter("P_VCHINCCOMENTARIO", DB2Type.VarChar, 500)
                arrParam(1).Value = pCCOINCIDENCIA_BE.PropINCCOMENTARIO
                arrParam(2) = New DB2Parameter("P_VCHINCRELATO", DB2Type.VarChar, 500)
                arrParam(2).Value = pCCOINCIDENCIA_BE.PropINCRELATO
                arrParam(3) = New DB2Parameter("P_VCHINCRESULTADO", DB2Type.VarChar, 500)
                arrParam(3).Value = pCCOINCIDENCIA_BE.PropINCRESULTADO
                arrParam(4) = New DB2Parameter("P_INTINCACODIGO", DB2Type.Integer)
                arrParam(4).Value = pCCOINCIDENCIA_BE.PropINCACODIGO
                arrParam(5) = New DB2Parameter("P_INTINCANUMERO", DB2Type.Integer)
                arrParam(5).Value = pCCOINCIDENCIA_BE.PropINCANUMERO
                arrParam(6) = New DB2Parameter("P_SMLINCINTERVENIDOS", DB2Type.SmallInt)
                arrParam(6).Value = pCCOINCIDENCIA_BE.PropINCINTERVENIDOS
                arrParam(7) = New DB2Parameter("P_INTPINCODIGO", DB2Type.Integer)
                arrParam(7).Value = pCCOINCIDENCIA_BE.PropPINCODIGO
                arrParam(8) = New DB2Parameter("P_SMLINCPARTEPOLICIAL", DB2Type.SmallInt)
                arrParam(8).Value = pCCOINCIDENCIA_BE.PropINCPARTEPOLICIAL
                arrParam(9) = New DB2Parameter("P_SMLRESCODIGO", DB2Type.SmallInt)
                arrParam(9).Value = pCCOINCIDENCIA_BE.PropRESCODIGO
                arrParam(10) = New DB2Parameter("P_SMLINCESTADO", DB2Type.SmallInt)
                arrParam(10).Value = pCCOINCIDENCIA_BE.PropINCESTADO
                arrParam(11) = New DB2Parameter("P_INTAUDROLMODIF", DB2Type.Integer)
                arrParam(11).Value = pCCOINCIDENCIA_BE.PropAUDROLMODIF
                arrParam(12) = New DB2Parameter("P_DTMAUDFECMODIF", DB2Type.Timestamp)
                arrParam(12).Value = pCCOINCIDENCIA_BE.PropAUDFECMODIF
                arrParam(13) = New DB2Parameter("P_VCHAUDUSUMODIF", DB2Type.VarChar, 15)
                arrParam(13).Value = pCCOINCIDENCIA_BE.PropAUDUSUMODIF
                arrParam(14) = New DB2Parameter("P_VCHAUDPRGMODIF", DB2Type.VarChar, 150)
                arrParam(14).Value = pCCOINCIDENCIA_BE.PropAUDPRGMODIF
                arrParam(15) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VarChar, 60)
                arrParam(15).Value = pCCOINCIDENCIA_BE.PropAUDEQPMODIF
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIA_ATENCION", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarUbicacion(ByVal pID As Integer) As List(Of CCOINCIDENCIA_BE)
            Dim Items As New List(Of CCOINCIDENCIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(0).Value = pID
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "SADE.CCOINCIDENCIA_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    Dim oCCOINCIDENCIA_BE As New CCOINCIDENCIA_BE
                    If oDataReader.IsDBNull(Campos.INCCODIGO) Then oCCOINCIDENCIA_BE.PropINCCODIGO = Nothing Else oCCOINCIDENCIA_BE.PropINCCODIGO = CType(oDataReader(Campos.INCCODIGO), Int32)
                    oCCOINCIDENCIA_BE.PropINCNUMEROORIGEN = IIf(oDataReader.IsDBNull(Campos.INCNUMEROORIGEN), "", oDataReader(Campos.INCNUMEROORIGEN))
                    oCCOINCIDENCIA_BE.PropINCCOMENTARIO = IIf(oDataReader.IsDBNull(Campos.INCCOMENTARIO), "", oDataReader(Campos.INCCOMENTARIO))
                    oCCOINCIDENCIA_BE.PropINCLOCVIACODIGO1 = IIf(oDataReader.IsDBNull(Campos.INCLOCVIACODIGO1), "", oDataReader(Campos.INCLOCVIACODIGO1))
                    oCCOINCIDENCIA_BE.PropINCLOCVIANOMBRE1 = IIf(oDataReader.IsDBNull(Campos.INCLOCVIANOMBRE1), "", oDataReader(Campos.INCLOCVIANOMBRE1))
                    oCCOINCIDENCIA_BE.PropINCLOCVIACODIGO2 = IIf(oDataReader.IsDBNull(Campos.INCLOCVIACODIGO2), "", oDataReader(Campos.INCLOCVIACODIGO2))
                    oCCOINCIDENCIA_BE.PropINCLOCVIANOMBRE2 = IIf(oDataReader.IsDBNull(Campos.INCLOCVIANOMBRE2), "", oDataReader(Campos.INCLOCVIANOMBRE2))
                    oCCOINCIDENCIA_BE.PropINCLOCNUMERO = IIf(oDataReader.IsDBNull(Campos.INCLOCNUMERO), "", oDataReader(Campos.INCLOCNUMERO))
                    oCCOINCIDENCIA_BE.PropINCLOCCUADRA = IIf(oDataReader.IsDBNull(Campos.INCLOCCUADRA), "", oDataReader(Campos.INCLOCCUADRA))
                    oCCOINCIDENCIA_BE.PropINCLOCMANZANA = IIf(oDataReader.IsDBNull(Campos.INCLOCMANZANA), "", oDataReader(Campos.INCLOCMANZANA))
                    oCCOINCIDENCIA_BE.PropINCLOCLOTE = IIf(oDataReader.IsDBNull(Campos.INCLOCLOTE), "", oDataReader(Campos.INCLOCLOTE))
                    oCCOINCIDENCIA_BE.PropINCLOCDPTO = IIf(oDataReader.IsDBNull(Campos.INCLOCDPTO), "", oDataReader(Campos.INCLOCDPTO))
                    oCCOINCIDENCIA_BE.PropINCLOCBLOCK = IIf(oDataReader.IsDBNull(Campos.INCLOCBLOCK), "", oDataReader(Campos.INCLOCBLOCK))
                    oCCOINCIDENCIA_BE.PropINCLOCHABCODIGO = IIf(oDataReader.IsDBNull(Campos.INCLOCHABCODIGO), "", oDataReader(Campos.INCLOCHABCODIGO))
                    oCCOINCIDENCIA_BE.PropINCLOCHABNOMBRE = IIf(oDataReader.IsDBNull(Campos.INCLOCHABNOMBRE), "", oDataReader(Campos.INCLOCHABNOMBRE))
                    If oDataReader.IsDBNull(Campos.INCLOCSECTOR) Then oCCOINCIDENCIA_BE.PropINCLOCSECTOR = Nothing Else oCCOINCIDENCIA_BE.PropINCLOCSECTOR = CType(oDataReader(Campos.INCLOCSECTOR), Int16)
                    If oDataReader.IsDBNull(Campos.INCLOCCUADRANTE) Then oCCOINCIDENCIA_BE.PropINCLOCCUADRANTE = Nothing Else oCCOINCIDENCIA_BE.PropINCLOCCUADRANTE = CType(oDataReader(Campos.INCLOCCUADRANTE), Int16)
                    oCCOINCIDENCIA_BE.PropINCLOCCOMENTARIO = IIf(oDataReader.IsDBNull(Campos.INCLOCCOMENTARIO), "", oDataReader(Campos.INCLOCCOMENTARIO))
                    oCCOINCIDENCIA_BE.PropINCRELATO = IIf(oDataReader.IsDBNull(Campos.INCRELATO), "", oDataReader(Campos.INCRELATO))
                    If oDataReader.IsDBNull(Campos.INCANONIMO) Then oCCOINCIDENCIA_BE.PropINCANONIMO = Nothing Else oCCOINCIDENCIA_BE.PropINCANONIMO = CType(oDataReader(Campos.INCANONIMO), Int16)
                    oCCOINCIDENCIA_BE.PropINCNOMBRE = IIf(oDataReader.IsDBNull(Campos.INCNOMBRE), "", oDataReader(Campos.INCNOMBRE))
                    oCCOINCIDENCIA_BE.PropINCAPELLIDOS = IIf(oDataReader.IsDBNull(Campos.INCAPELLIDOS), "", oDataReader(Campos.INCAPELLIDOS))
                    oCCOINCIDENCIA_BE.PropINCNOMBRECOMP = IIf(oDataReader.IsDBNull(Campos.INCNOMBRECOMP), "", oDataReader(Campos.INCNOMBRECOMP))
                    oCCOINCIDENCIA_BE.PropINCDOCUMENTO = IIf(oDataReader.IsDBNull(Campos.INCDOCUMENTO), "", oDataReader(Campos.INCDOCUMENTO))
                    oCCOINCIDENCIA_BE.PropINCLLAVIACODIGO = IIf(oDataReader.IsDBNull(Campos.INCLLAVIACODIGO), "", oDataReader(Campos.INCLLAVIACODIGO))
                    oCCOINCIDENCIA_BE.PropINCLLAVIANOMBRE = IIf(oDataReader.IsDBNull(Campos.INCLLAVIANOMBRE), "", oDataReader(Campos.INCLLAVIANOMBRE))
                    oCCOINCIDENCIA_BE.PropINCLLANUMERO = IIf(oDataReader.IsDBNull(Campos.INCLLANUMERO), "", oDataReader(Campos.INCLLANUMERO))
                    oCCOINCIDENCIA_BE.PropINCLLACUADRA = IIf(oDataReader.IsDBNull(Campos.INCLLACUADRA), "", oDataReader(Campos.INCLLACUADRA))
                    oCCOINCIDENCIA_BE.PropINCLLAMANZANA = IIf(oDataReader.IsDBNull(Campos.INCLLAMANZANA), "", oDataReader(Campos.INCLLAMANZANA))
                    oCCOINCIDENCIA_BE.PropINCLLALOTE = IIf(oDataReader.IsDBNull(Campos.INCLLALOTE), "", oDataReader(Campos.INCLLALOTE))
                    oCCOINCIDENCIA_BE.PropINCLLADPTO = IIf(oDataReader.IsDBNull(Campos.INCLLADPTO), "", oDataReader(Campos.INCLLADPTO))
                    oCCOINCIDENCIA_BE.PropINCLLABLOCK = IIf(oDataReader.IsDBNull(Campos.INCLLABLOCK), "", oDataReader(Campos.INCLLABLOCK))
                    oCCOINCIDENCIA_BE.PropINCLLAHABCODIGO = IIf(oDataReader.IsDBNull(Campos.INCLLAHABCODIGO), "", oDataReader(Campos.INCLLAHABCODIGO))
                    oCCOINCIDENCIA_BE.PropINCLLAHABNOMBRE = IIf(oDataReader.IsDBNull(Campos.INCLLAHABNOMBRE), "", oDataReader(Campos.INCLLAHABNOMBRE))
                    If oDataReader.IsDBNull(Campos.INCLLASECTOR) Then oCCOINCIDENCIA_BE.PropINCLLASECTOR = Nothing Else oCCOINCIDENCIA_BE.PropINCLLASECTOR = CType(oDataReader(Campos.INCLLASECTOR), Int16)
                    If oDataReader.IsDBNull(Campos.INCLLACUADRANTE) Then oCCOINCIDENCIA_BE.PropINCLLACUADRANTE = Nothing Else oCCOINCIDENCIA_BE.PropINCLLACUADRANTE = CType(oDataReader(Campos.INCLLACUADRANTE), Int16)
                    oCCOINCIDENCIA_BE.PropINCLLACOMENTARIO = IIf(oDataReader.IsDBNull(Campos.INCLLACOMENTARIO), "", oDataReader(Campos.INCLLACOMENTARIO))
                    oCCOINCIDENCIA_BE.PropINCRESULTADO = IIf(oDataReader.IsDBNull(Campos.INCRESULTADO), "", oDataReader(Campos.INCRESULTADO))
                    If oDataReader.IsDBNull(Campos.INCESTADO) Then oCCOINCIDENCIA_BE.PropINCESTADO = Nothing Else oCCOINCIDENCIA_BE.PropINCESTADO = CType(oDataReader(Campos.INCESTADO), Int16)
                    If oDataReader.IsDBNull(Campos.AUDFECCREACION) Then oCCOINCIDENCIA_BE.PropAUDFECCREACION = Nothing Else oCCOINCIDENCIA_BE.PropAUDFECCREACION = CType(oDataReader(Campos.AUDFECCREACION), DateTime)
                    If oDataReader.IsDBNull(Campos.AUDFECMODIF) Then oCCOINCIDENCIA_BE.PropAUDFECMODIF = Nothing Else oCCOINCIDENCIA_BE.PropAUDFECMODIF = CType(oDataReader(Campos.AUDFECMODIF), DateTime)
                    oCCOINCIDENCIA_BE.PropAUDUSUCREACION = IIf(oDataReader.IsDBNull(Campos.AUDUSUCREACION), "", oDataReader(Campos.AUDUSUCREACION))
                    oCCOINCIDENCIA_BE.PropAUDUSUMODIF = IIf(oDataReader.IsDBNull(Campos.AUDUSUMODIF), "", oDataReader(Campos.AUDUSUMODIF))
                    If oDataReader.IsDBNull(Campos.INCACODIGO) Then oCCOINCIDENCIA_BE.PropINCACODIGO = Nothing Else oCCOINCIDENCIA_BE.PropINCACODIGO = CType(oDataReader(Campos.INCACODIGO), Int32)
                    If oDataReader.IsDBNull(Campos.INCANUMERO) Then oCCOINCIDENCIA_BE.PropINCANUMERO = Nothing Else oCCOINCIDENCIA_BE.PropINCANUMERO = CType(oDataReader(Campos.INCANUMERO), Int32)
                    If oDataReader.IsDBNull(Campos.ADMCODIGO) Then oCCOINCIDENCIA_BE.PropADMCODIGO = Nothing Else oCCOINCIDENCIA_BE.PropADMCODIGO = CType(oDataReader(Campos.ADMCODIGO), Int32)
                    If oDataReader.IsDBNull(Campos.PRECODIGO) Then oCCOINCIDENCIA_BE.PropPRECODIGO = Nothing Else oCCOINCIDENCIA_BE.PropPRECODIGO = CType(oDataReader(Campos.PRECODIGO), Int32)
                    oCCOINCIDENCIA_BE.PropINCIDLATITUDE = IIf(oDataReader.IsDBNull(Campos.INCIDLATITUDE), "", oDataReader(Campos.INCIDLATITUDE))
                    oCCOINCIDENCIA_BE.PropINCIDLONGITUDE = IIf(oDataReader.IsDBNull(Campos.INCIDLONGITUDE), "", oDataReader(Campos.INCIDLONGITUDE))
                    If oDataReader.IsDBNull(Campos.ORICODIGO) Then oCCOINCIDENCIA_BE.PropORICODIGO = Nothing Else oCCOINCIDENCIA_BE.PropORICODIGO = CType(oDataReader(Campos.ORICODIGO), Int16)
                    If oDataReader.IsDBNull(Campos.TINCODIGO) Then oCCOINCIDENCIA_BE.PropTINCODIGO = Nothing Else oCCOINCIDENCIA_BE.PropTINCODIGO = CType(oDataReader(Campos.TINCODIGO), Int16)
                    If oDataReader.IsDBNull(Campos.STICODIGO) Then oCCOINCIDENCIA_BE.PropSTICODIGO = Nothing Else oCCOINCIDENCIA_BE.PropSTICODIGO = CType(oDataReader(Campos.STICODIGO), Int16)
                    If oDataReader.IsDBNull(Campos.PRICODIGO) Then oCCOINCIDENCIA_BE.PropPRICODIGO = Nothing Else oCCOINCIDENCIA_BE.PropPRICODIGO = CType(oDataReader(Campos.PRICODIGO), Int16)
                    If oDataReader.IsDBNull(Campos.TPECODIGO) Then oCCOINCIDENCIA_BE.PropTPECODIGO = Nothing Else oCCOINCIDENCIA_BE.PropTPECODIGO = CType(oDataReader(Campos.TPECODIGO), Int16)
                    oCCOINCIDENCIA_BE.PropTIDCODIGO = IIf(oDataReader.IsDBNull(Campos.TIDCODIGO), "", oDataReader(Campos.TIDCODIGO))
                    If oDataReader.IsDBNull(Campos.INCINTERVENIDOS) Then oCCOINCIDENCIA_BE.PropINCINTERVENIDOS = Nothing Else oCCOINCIDENCIA_BE.PropINCINTERVENIDOS = CType(oDataReader(Campos.INCINTERVENIDOS), Int16)
                    If oDataReader.IsDBNull(Campos.PAQCODIGO) Then oCCOINCIDENCIA_BE.PropPAQCODIGO = Nothing Else oCCOINCIDENCIA_BE.PropPAQCODIGO = CType(oDataReader(Campos.PAQCODIGO), Int32)
                    If oDataReader.IsDBNull(Campos.PINCODIGO) Then oCCOINCIDENCIA_BE.PropPINCODIGO = Nothing Else oCCOINCIDENCIA_BE.PropPINCODIGO = CType(oDataReader(Campos.PINCODIGO), Int32)
                    If oDataReader.IsDBNull(Campos.AUDROLCREACION) Then oCCOINCIDENCIA_BE.PropAUDROLCREACION = Nothing Else oCCOINCIDENCIA_BE.PropAUDROLCREACION = CType(oDataReader(Campos.AUDROLCREACION), Int32)
                    If oDataReader.IsDBNull(Campos.AUDROLMODIF) Then oCCOINCIDENCIA_BE.PropAUDROLMODIF = Nothing Else oCCOINCIDENCIA_BE.PropAUDROLMODIF = CType(oDataReader(Campos.AUDROLMODIF), Int32)
                    oCCOINCIDENCIA_BE.PropINCUSUDERIVADO = IIf(oDataReader.IsDBNull(Campos.INCUSUDERIVADO), "", oDataReader(Campos.INCUSUDERIVADO))
                    If oDataReader.IsDBNull(Campos.INCROLDERIVADO) Then oCCOINCIDENCIA_BE.PropINCROLDERIVADO = Nothing Else oCCOINCIDENCIA_BE.PropINCROLDERIVADO = CType(oDataReader(Campos.INCROLDERIVADO), Int32)
                    If oDataReader.IsDBNull(Campos.INCFECDERIVADO) Then oCCOINCIDENCIA_BE.PropINCFECDERIVADO = Nothing Else oCCOINCIDENCIA_BE.PropINCFECDERIVADO = CType(oDataReader(Campos.INCFECDERIVADO), DateTime)
                    If oDataReader.IsDBNull(Campos.RESCODIGO) Then oCCOINCIDENCIA_BE.PropRESCODIGO = Nothing Else oCCOINCIDENCIA_BE.PropRESCODIGO = CType(oDataReader(Campos.RESCODIGO), Int16)
                    oCCOINCIDENCIA_BE.PropAUDPRGCREACION = IIf(oDataReader.IsDBNull(Campos.AUDPRGCREACION), "", oDataReader(Campos.AUDPRGCREACION))
                    oCCOINCIDENCIA_BE.PropAUDPRGMODIF = IIf(oDataReader.IsDBNull(Campos.AUDPRGMODIF), "", oDataReader(Campos.AUDPRGMODIF))
                    oCCOINCIDENCIA_BE.PropAUDEQPCREACION = IIf(oDataReader.IsDBNull(Campos.AUDEQPCREACION), "", oDataReader(Campos.AUDEQPCREACION))
                    oCCOINCIDENCIA_BE.PropAUDEQPMODIF = IIf(oDataReader.IsDBNull(Campos.AUDEQPMODIF), "", oDataReader(Campos.AUDEQPMODIF))
                    oCCOINCIDENCIA_BE.PropCATCODIGO = IIf(oDataReader.IsDBNull(Campos.CATCODIGO), "", oDataReader(Campos.CATCODIGO))
                    If oDataReader.IsDBNull(Campos.INCFECHA) Then oCCOINCIDENCIA_BE.PropINCFECHA = Nothing Else oCCOINCIDENCIA_BE.PropINCFECHA = CType(oDataReader(Campos.INCFECHA), DateTime)
                    oCCOINCIDENCIA_BE.PropINCIDANEXO = IIf(oDataReader.IsDBNull(Campos.INCIDANEXO), "", oDataReader(Campos.INCIDANEXO))
                    oCCOINCIDENCIA_BE.PropINCIDLLAMADA = IIf(oDataReader.IsDBNull(Campos.INCIDLLAMADA), "", oDataReader(Campos.INCIDLLAMADA))
                    If oDataReader.IsDBNull(Campos.INCPARTEPOLICIAL) Then oCCOINCIDENCIA_BE.PropINCPARTEPOLICIAL = Nothing Else oCCOINCIDENCIA_BE.PropINCPARTEPOLICIAL = CType(oDataReader(Campos.INCPARTEPOLICIAL), Int16)
                    Items.Add(oCCOINCIDENCIA_BE)
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return Items


        End Function

        Public Function ListarDatos(ByVal pINCCODIGO As Integer) As DataTable
            Dim odt As New DataTable

            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}

                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(0).Value = pINCCODIGO
                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIA_LISTAR", arrParam)
                    odt.Load(dataReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return odt
        End Function

        Public Sub DerivarSIAVE(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(3) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOINCIDENCIA_BE.PropINCCODIGO
                arrParam(1) = New DB2Parameter("P_VCHINCCOMENTARIO", DB2Type.VarChar, 500)
                arrParam(1).Value = pCCOINCIDENCIA_BE.PropINCCOMENTARIO
                arrParam(2) = New DB2Parameter("P_VCHAUDUSUMODIF", DB2Type.VarChar, 10)
                arrParam(2).Value = pCCOINCIDENCIA_BE.PropAUDUSUMODIF
                arrParam(3) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VarChar, 60)
                arrParam(3).Value = pCCOINCIDENCIA_BE.PropAUDEQPMODIF
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIA_DERIVAR_SIAVE", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub CerrarSIAVE(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(3) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOINCIDENCIA_BE.PropINCCODIGO
                arrParam(1) = New DB2Parameter("P_VCHINCCOMENTARIO", DB2Type.VarChar, 500)
                arrParam(1).Value = pCCOINCIDENCIA_BE.PropINCCOMENTARIO
                arrParam(2) = New DB2Parameter("P_VCHAUDUSUMODIF", DB2Type.VarChar, 10)
                arrParam(2).Value = pCCOINCIDENCIA_BE.PropAUDUSUMODIF
                arrParam(3) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VarChar, 60)
                arrParam(3).Value = pCCOINCIDENCIA_BE.PropAUDEQPMODIF
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIA_CERRAR_SIAVE", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarBandejaAlerta(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE) As DataTable
            Dim odt As New DataTable

            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}

                arrParam(0) = New DB2Parameter("P_VCHINCNUMEROORIGEN", DB2Type.VarChar, 15)
                arrParam(0).Value = pCCOINCIDENCIA_BE.PropINCNUMEROORIGEN
                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIA_BANDEJA_ALERTA", arrParam)
                    odt.Load(dataReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return odt
        End Function

        Public Function ListarTematico(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE) As DataTable
            Dim odt As New DataTable

            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(2) {}


                arrParam(0) = New DB2Parameter("P_VCHMOTIVOALERTA", DB2Type.VarChar, 2)
                arrParam(0).Value = pCCOINCIDENCIA_BE.PropVCHMOTIVOALERTA

                arrParam(1) = New DB2Parameter("P_SMLINCESTADO", DB2Type.SmallInt)
                arrParam(1).Value = pCCOINCIDENCIA_BE.PropINCESTADO

                arrParam(2) = New DB2Parameter("P_SMLTPECODIGO", DB2Type.SmallInt)
                arrParam(2).Value = pCCOINCIDENCIA_BE.PropTPECODIGO

                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIA_LISTAR_TEMATICO", arrParam)
                    odt.Load(dataReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return odt
        End Function

        Public Function ListarMarcadores(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE) As DataTable
            Dim odt As New DataTable

            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}

                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIA_LISTAR_MARCADORES", arrParam)
                    odt.Load(dataReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return odt
        End Function

        Public Sub ActualizarAlertaSurcoV2(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(75) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOINCIDENCIA_BE.PropINCCODIGO
                arrParam(1) = New DB2Parameter("P_VCHINCNUMEROORIGEN", DB2Type.VarChar, 15)
                arrParam(1).Value = pCCOINCIDENCIA_BE.PropINCNUMEROORIGEN
                arrParam(2) = New DB2Parameter("P_VCHINCCOMENTARIO", DB2Type.VarChar, 500)
                arrParam(2).Value = pCCOINCIDENCIA_BE.PropINCCOMENTARIO
                arrParam(3) = New DB2Parameter("P_VCHINCLOCVIACODIGO1", DB2Type.VarChar, 6)
                arrParam(3).Value = pCCOINCIDENCIA_BE.PropINCLOCVIACODIGO1
                arrParam(4) = New DB2Parameter("P_VCHINCLOCVIANOMBRE1", DB2Type.VarChar, 150)
                arrParam(4).Value = pCCOINCIDENCIA_BE.PropINCLOCVIANOMBRE1
                arrParam(5) = New DB2Parameter("P_VCHINCLOCVIACODIGO2", DB2Type.VarChar, 6)
                arrParam(5).Value = pCCOINCIDENCIA_BE.PropINCLOCVIACODIGO2
                arrParam(6) = New DB2Parameter("P_VCHINCLOCVIANOMBRE2", DB2Type.VarChar, 150)
                arrParam(6).Value = pCCOINCIDENCIA_BE.PropINCLOCVIANOMBRE2
                arrParam(7) = New DB2Parameter("P_VCHINCLOCNUMERO", DB2Type.VarChar, 10)
                arrParam(7).Value = pCCOINCIDENCIA_BE.PropINCLOCNUMERO
                arrParam(8) = New DB2Parameter("P_VCHINCLOCCUADRA", DB2Type.VarChar, 10)
                arrParam(8).Value = pCCOINCIDENCIA_BE.PropINCLOCCUADRA
                arrParam(9) = New DB2Parameter("P_VCHINCLOCMANZANA", DB2Type.VarChar, 10)
                arrParam(9).Value = pCCOINCIDENCIA_BE.PropINCLOCMANZANA
                arrParam(10) = New DB2Parameter("P_VCHINCLOCLOTE", DB2Type.VarChar, 10)
                arrParam(10).Value = pCCOINCIDENCIA_BE.PropINCLOCLOTE
                arrParam(11) = New DB2Parameter("P_VCHINCLOCDPTO", DB2Type.VarChar, 10)
                arrParam(11).Value = pCCOINCIDENCIA_BE.PropINCLOCDPTO
                arrParam(12) = New DB2Parameter("P_VCHINCLOCBLOCK", DB2Type.VarChar, 10)
                arrParam(12).Value = pCCOINCIDENCIA_BE.PropINCLOCBLOCK
                arrParam(13) = New DB2Parameter("P_CHRINCLOCHABCODIGO", DB2Type.Char, 4)
                arrParam(13).Value = pCCOINCIDENCIA_BE.PropINCLOCHABCODIGO
                arrParam(14) = New DB2Parameter("P_VCHINCLOCHABNOMBRE", DB2Type.VarChar, 100)
                arrParam(14).Value = pCCOINCIDENCIA_BE.PropINCLOCHABNOMBRE
                arrParam(15) = New DB2Parameter("P_SMLINCLOCSECTOR", DB2Type.SmallInt)
                arrParam(15).Value = pCCOINCIDENCIA_BE.PropINCLOCSECTOR
                arrParam(16) = New DB2Parameter("P_SMLINCLOCCUADRANTE", DB2Type.SmallInt)
                arrParam(16).Value = pCCOINCIDENCIA_BE.PropINCLOCCUADRANTE
                arrParam(17) = New DB2Parameter("P_VCHINCLOCCOMENTARIO", DB2Type.VarChar, 250)
                arrParam(17).Value = pCCOINCIDENCIA_BE.PropINCLOCCOMENTARIO
                arrParam(18) = New DB2Parameter("P_VCHINCRELATO", DB2Type.VarChar, 500)
                arrParam(18).Value = pCCOINCIDENCIA_BE.PropINCRELATO
                arrParam(19) = New DB2Parameter("P_SMLINCANONIMO", DB2Type.SmallInt)
                arrParam(19).Value = pCCOINCIDENCIA_BE.PropINCANONIMO
                arrParam(20) = New DB2Parameter("P_VCHINCNOMBRE", DB2Type.VarChar, 30)
                arrParam(20).Value = pCCOINCIDENCIA_BE.PropINCNOMBRE
                arrParam(21) = New DB2Parameter("P_VCHINCAPELLIDOS", DB2Type.VarChar, 50)
                arrParam(21).Value = pCCOINCIDENCIA_BE.PropINCAPELLIDOS
                arrParam(22) = New DB2Parameter("P_VCHINCNOMBRECOMP", DB2Type.VarChar, 100)
                arrParam(22).Value = pCCOINCIDENCIA_BE.PropINCNOMBRECOMP
                arrParam(23) = New DB2Parameter("P_VCHINCDOCUMENTO", DB2Type.VarChar, 20)
                arrParam(23).Value = pCCOINCIDENCIA_BE.PropINCDOCUMENTO
                arrParam(24) = New DB2Parameter("P_VCHINCLLAVIACODIGO", DB2Type.VarChar, 6)
                arrParam(24).Value = pCCOINCIDENCIA_BE.PropINCLLAVIACODIGO
                arrParam(25) = New DB2Parameter("P_VCHINCLLAVIANOMBRE", DB2Type.VarChar, 150)
                arrParam(25).Value = pCCOINCIDENCIA_BE.PropINCLLAVIANOMBRE
                arrParam(26) = New DB2Parameter("P_VCHINCLLANUMERO", DB2Type.VarChar, 10)
                arrParam(26).Value = pCCOINCIDENCIA_BE.PropINCLLANUMERO
                arrParam(27) = New DB2Parameter("P_VCHINCLLAMANZANA", DB2Type.VarChar, 10)
                arrParam(27).Value = pCCOINCIDENCIA_BE.PropINCLLAMANZANA
                arrParam(28) = New DB2Parameter("P_VCHINCLLALOTE", DB2Type.VarChar, 10)
                arrParam(28).Value = pCCOINCIDENCIA_BE.PropINCLLALOTE
                arrParam(29) = New DB2Parameter("P_VCHINCLLADPTO", DB2Type.VarChar, 10)
                arrParam(29).Value = pCCOINCIDENCIA_BE.PropINCLLADPTO
                arrParam(30) = New DB2Parameter("P_VCHINCLLABLOCK", DB2Type.VarChar, 10)
                arrParam(30).Value = pCCOINCIDENCIA_BE.PropINCLLABLOCK
                arrParam(31) = New DB2Parameter("P_CHRINCLLAHABCODIGO", DB2Type.Char, 4)
                arrParam(31).Value = pCCOINCIDENCIA_BE.PropINCLLAHABCODIGO
                arrParam(32) = New DB2Parameter("P_VCHINCLLAHABNOMBRE", DB2Type.VarChar, 100)
                arrParam(32).Value = pCCOINCIDENCIA_BE.PropINCLLAHABNOMBRE
                arrParam(33) = New DB2Parameter("P_SMLINCLLASECTOR", DB2Type.SmallInt)
                arrParam(33).Value = pCCOINCIDENCIA_BE.PropINCLLASECTOR
                arrParam(34) = New DB2Parameter("P_SMLINCLLACUADRANTE", DB2Type.SmallInt)
                arrParam(34).Value = pCCOINCIDENCIA_BE.PropINCLLACUADRANTE
                arrParam(35) = New DB2Parameter("P_VCHINCLLACOMENTARIO", DB2Type.VarChar, 250)
                arrParam(35).Value = pCCOINCIDENCIA_BE.PropINCLLACOMENTARIO
                arrParam(36) = New DB2Parameter("P_VCHINCRESULTADO", DB2Type.VarChar, 500)
                arrParam(36).Value = pCCOINCIDENCIA_BE.PropINCRESULTADO
                arrParam(37) = New DB2Parameter("P_SMLINCESTADO", DB2Type.SmallInt)
                arrParam(37).Value = pCCOINCIDENCIA_BE.PropINCESTADO
                arrParam(38) = New DB2Parameter("P_DTMAUDFECCREACION", DB2Type.Timestamp)
                arrParam(38).Value = pCCOINCIDENCIA_BE.PropAUDFECCREACION
                arrParam(39) = New DB2Parameter("P_DTMAUDFECMODIF", DB2Type.Timestamp)
                arrParam(39).Value = pCCOINCIDENCIA_BE.PropAUDFECMODIF
                arrParam(40) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VarChar, 15)
                arrParam(40).Value = pCCOINCIDENCIA_BE.PropAUDUSUCREACION
                arrParam(41) = New DB2Parameter("P_VCHAUDUSUMODIF", DB2Type.VarChar, 15)
                arrParam(41).Value = pCCOINCIDENCIA_BE.PropAUDUSUMODIF
                arrParam(42) = New DB2Parameter("P_INTINCACODIGO", DB2Type.Integer)
                arrParam(42).Value = pCCOINCIDENCIA_BE.PropINCACODIGO
                arrParam(43) = New DB2Parameter("P_INTINCANUMERO", DB2Type.Integer)
                arrParam(43).Value = pCCOINCIDENCIA_BE.PropINCANUMERO
                arrParam(44) = New DB2Parameter("P_INTADMCODIGO", DB2Type.Integer)
                arrParam(44).Value = pCCOINCIDENCIA_BE.PropADMCODIGO
                arrParam(45) = New DB2Parameter("P_INTPRECODIGO", DB2Type.Integer)
                arrParam(45).Value = pCCOINCIDENCIA_BE.PropPRECODIGO
                arrParam(46) = New DB2Parameter("P_VCHINCIDLATITUDE", DB2Type.VarChar, 20)
                arrParam(46).Value = pCCOINCIDENCIA_BE.PropINCIDLATITUDE
                arrParam(47) = New DB2Parameter("P_VCHINCIDLONGITUDE", DB2Type.VarChar, 20)
                arrParam(47).Value = pCCOINCIDENCIA_BE.PropINCIDLONGITUDE
                arrParam(48) = New DB2Parameter("P_SMLORICODIGO", DB2Type.SmallInt)
                arrParam(48).Value = pCCOINCIDENCIA_BE.PropORICODIGO
                arrParam(49) = New DB2Parameter("P_SMLTINCODIGO", DB2Type.SmallInt)
                arrParam(49).Value = pCCOINCIDENCIA_BE.PropTINCODIGO
                arrParam(50) = New DB2Parameter("P_SMLSTICODIGO", DB2Type.SmallInt)
                arrParam(50).Value = pCCOINCIDENCIA_BE.PropSTICODIGO
                arrParam(51) = New DB2Parameter("P_SMLPRICODIGO", DB2Type.SmallInt)
                arrParam(51).Value = pCCOINCIDENCIA_BE.PropPRICODIGO
                arrParam(52) = New DB2Parameter("P_SMLTPECODIGO", DB2Type.SmallInt)
                arrParam(52).Value = pCCOINCIDENCIA_BE.PropTPECODIGO
                arrParam(53) = New DB2Parameter("P_VCHTIDCODIGO", DB2Type.VarChar, 2)
                arrParam(53).Value = pCCOINCIDENCIA_BE.PropTIDCODIGO
                arrParam(54) = New DB2Parameter("P_SMLINCINTERVENIDOS", DB2Type.SmallInt)
                arrParam(54).Value = pCCOINCIDENCIA_BE.PropINCINTERVENIDOS
                arrParam(55) = New DB2Parameter("P_INTPAQCODIGO", DB2Type.Integer)
                arrParam(55).Value = pCCOINCIDENCIA_BE.PropPAQCODIGO
                arrParam(56) = New DB2Parameter("P_INTPINCODIGO", DB2Type.Integer)
                arrParam(56).Value = pCCOINCIDENCIA_BE.PropPINCODIGO
                arrParam(57) = New DB2Parameter("P_INTAUDROLCREACION", DB2Type.Integer)
                arrParam(57).Value = pCCOINCIDENCIA_BE.PropAUDROLCREACION
                arrParam(58) = New DB2Parameter("P_INTAUDROLMODIF", DB2Type.Integer)
                arrParam(58).Value = pCCOINCIDENCIA_BE.PropAUDROLMODIF
                arrParam(59) = New DB2Parameter("P_VCHINCUSUDERIVADO", DB2Type.VarChar, 15)
                arrParam(59).Value = pCCOINCIDENCIA_BE.PropINCUSUDERIVADO
                arrParam(60) = New DB2Parameter("P_INTINCROLDERIVADO", DB2Type.Integer)
                arrParam(60).Value = pCCOINCIDENCIA_BE.PropINCROLDERIVADO
                arrParam(61) = New DB2Parameter("P_DTMINCFECDERIVADO", DB2Type.Timestamp)
                arrParam(61).Value = pCCOINCIDENCIA_BE.PropINCFECDERIVADO
                arrParam(62) = New DB2Parameter("P_SMLRESCODIGO", DB2Type.SmallInt)
                arrParam(62).Value = pCCOINCIDENCIA_BE.PropRESCODIGO
                arrParam(63) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VarChar, 150)
                arrParam(63).Value = pCCOINCIDENCIA_BE.PropAUDPRGCREACION
                arrParam(64) = New DB2Parameter("P_VCHAUDPRGMODIF", DB2Type.VarChar, 150)
                arrParam(64).Value = pCCOINCIDENCIA_BE.PropAUDPRGMODIF
                arrParam(65) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VarChar, 60)
                arrParam(65).Value = pCCOINCIDENCIA_BE.PropAUDEQPCREACION
                arrParam(66) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VarChar, 60)
                arrParam(66).Value = pCCOINCIDENCIA_BE.PropAUDEQPMODIF
                arrParam(67) = New DB2Parameter("P_VCHCATCODIGO", DB2Type.VarChar, 14)
                arrParam(67).Value = pCCOINCIDENCIA_BE.PropCATCODIGO
                arrParam(68) = New DB2Parameter("P_DTMINCFECHA", DB2Type.Timestamp)
                arrParam(68).Value = pCCOINCIDENCIA_BE.PropINCFECHA
                arrParam(69) = New DB2Parameter("P_VCHINCIDANEXO", DB2Type.VarChar, 5)
                arrParam(69).Value = pCCOINCIDENCIA_BE.PropINCIDANEXO
                arrParam(70) = New DB2Parameter("P_VCHINCIDLLAMADA", DB2Type.VarChar, 15)
                arrParam(70).Value = pCCOINCIDENCIA_BE.PropINCIDLLAMADA
                arrParam(71) = New DB2Parameter("P_VCHINCLLACUADRA", DB2Type.VarChar, 10)
                arrParam(71).Value = pCCOINCIDENCIA_BE.PropINCLLACUADRA

                arrParam(72) = New DB2Parameter("P_VCHINCLOCCUADRANTE", DB2Type.VarChar, 5)
                arrParam(72).Value = pCCOINCIDENCIA_BE.PropVCHINCLOCCUADRANTE
                arrParam(73) = New DB2Parameter("P_VCHINCLOCSECTOR", DB2Type.VarChar, 5)
                arrParam(73).Value = pCCOINCIDENCIA_BE.PropVCHINCLOCSECTOR
                arrParam(74) = New DB2Parameter("P_VCHINCLOCXGEO", DB2Type.VarChar, 20)
                arrParam(74).Value = pCCOINCIDENCIA_BE.PropINCLOCXGEO
                arrParam(75) = New DB2Parameter("P_VCHINCLOCYGEO", DB2Type.VarChar, 20)
                arrParam(75).Value = pCCOINCIDENCIA_BE.PropINCLOCYGEO

                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIA_ACTUALIZAR_ALERTASURCO_V2", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Insertar_SQL_DB2(ByVal plstCCOINCIDENCIA_BE As List(Of CCOINCIDENCIA_BE))
            Try

                For Each pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE In plstCCOINCIDENCIA_BE

                    Dim arrParam() As DB2Parameter = New DB2Parameter(78) {}
                    arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                    arrParam(0).Value = pCCOINCIDENCIA_BE.PropINCCODIGO
                    arrParam(1) = New DB2Parameter("P_VCHINCNUMEROORIGEN", DB2Type.VarChar, 15)
                    arrParam(1).Value = pCCOINCIDENCIA_BE.PropINCNUMEROORIGEN
                    arrParam(2) = New DB2Parameter("P_VCHINCCOMENTARIO", DB2Type.VarChar, 500)
                    arrParam(2).Value = pCCOINCIDENCIA_BE.PropINCCOMENTARIO
                    arrParam(3) = New DB2Parameter("P_VCHINCLOCVIACODIGO1", DB2Type.VarChar, 6)
                    arrParam(3).Value = pCCOINCIDENCIA_BE.PropINCLOCVIACODIGO1
                    arrParam(4) = New DB2Parameter("P_VCHINCLOCVIANOMBRE1", DB2Type.VarChar, 150)
                    arrParam(4).Value = pCCOINCIDENCIA_BE.PropINCLOCVIANOMBRE1
                    arrParam(5) = New DB2Parameter("P_VCHINCLOCVIACODIGO2", DB2Type.VarChar, 6)
                    arrParam(5).Value = pCCOINCIDENCIA_BE.PropINCLOCVIACODIGO2
                    arrParam(6) = New DB2Parameter("P_VCHINCLOCVIANOMBRE2", DB2Type.VarChar, 150)
                    arrParam(6).Value = pCCOINCIDENCIA_BE.PropINCLOCVIANOMBRE2
                    arrParam(7) = New DB2Parameter("P_VCHINCLOCNUMERO", DB2Type.VarChar, 10)
                    arrParam(7).Value = pCCOINCIDENCIA_BE.PropINCLOCNUMERO
                    arrParam(8) = New DB2Parameter("P_VCHINCLOCCUADRA", DB2Type.VarChar, 10)
                    arrParam(8).Value = pCCOINCIDENCIA_BE.PropINCLOCCUADRA
                    arrParam(9) = New DB2Parameter("P_VCHINCLOCMANZANA", DB2Type.VarChar, 10)
                    arrParam(9).Value = pCCOINCIDENCIA_BE.PropINCLOCMANZANA
                    arrParam(10) = New DB2Parameter("P_VCHINCLOCLOTE", DB2Type.VarChar, 10)
                    arrParam(10).Value = pCCOINCIDENCIA_BE.PropINCLOCLOTE
                    arrParam(11) = New DB2Parameter("P_VCHINCLOCDPTO", DB2Type.VarChar, 10)
                    arrParam(11).Value = pCCOINCIDENCIA_BE.PropINCLOCDPTO
                    arrParam(12) = New DB2Parameter("P_VCHINCLOCBLOCK", DB2Type.VarChar, 10)
                    arrParam(12).Value = pCCOINCIDENCIA_BE.PropINCLOCBLOCK
                    arrParam(13) = New DB2Parameter("P_CHRINCLOCHABCODIGO", DB2Type.Char, 4)
                    arrParam(13).Value = pCCOINCIDENCIA_BE.PropINCLOCHABCODIGO
                    arrParam(14) = New DB2Parameter("P_VCHINCLOCHABNOMBRE", DB2Type.VarChar, 100)
                    arrParam(14).Value = pCCOINCIDENCIA_BE.PropINCLOCHABNOMBRE
                    arrParam(15) = New DB2Parameter("P_SMLINCLOCSECTOR", DB2Type.SmallInt)
                    arrParam(15).Value = pCCOINCIDENCIA_BE.PropINCLOCSECTOR
                    arrParam(16) = New DB2Parameter("P_SMLINCLOCCUADRANTE", DB2Type.SmallInt)
                    arrParam(16).Value = pCCOINCIDENCIA_BE.PropINCLOCCUADRANTE
                    arrParam(17) = New DB2Parameter("P_VCHINCLOCCOMENTARIO", DB2Type.VarChar, 250)
                    arrParam(17).Value = pCCOINCIDENCIA_BE.PropINCLOCCOMENTARIO
                    arrParam(18) = New DB2Parameter("P_VCHINCRELATO", DB2Type.VarChar, 500)
                    arrParam(18).Value = pCCOINCIDENCIA_BE.PropINCRELATO
                    arrParam(19) = New DB2Parameter("P_SMLINCANONIMO", DB2Type.SmallInt)
                    arrParam(19).Value = pCCOINCIDENCIA_BE.PropINCANONIMO
                    arrParam(20) = New DB2Parameter("P_VCHINCNOMBRE", DB2Type.VarChar, 30)
                    arrParam(20).Value = pCCOINCIDENCIA_BE.PropINCNOMBRE
                    arrParam(21) = New DB2Parameter("P_VCHINCAPELLIDOS", DB2Type.VarChar, 50)
                    arrParam(21).Value = pCCOINCIDENCIA_BE.PropINCAPELLIDOS
                    arrParam(22) = New DB2Parameter("P_VCHINCNOMBRECOMP", DB2Type.VarChar, 100)
                    arrParam(22).Value = pCCOINCIDENCIA_BE.PropINCNOMBRECOMP
                    arrParam(23) = New DB2Parameter("P_VCHINCDOCUMENTO", DB2Type.VarChar, 20)
                    arrParam(23).Value = pCCOINCIDENCIA_BE.PropINCDOCUMENTO
                    arrParam(24) = New DB2Parameter("P_VCHINCLLAVIACODIGO", DB2Type.VarChar, 6)
                    arrParam(24).Value = pCCOINCIDENCIA_BE.PropINCLLAVIACODIGO
                    arrParam(25) = New DB2Parameter("P_VCHINCLLAVIANOMBRE", DB2Type.VarChar, 150)
                    arrParam(25).Value = pCCOINCIDENCIA_BE.PropINCLLAVIANOMBRE
                    arrParam(26) = New DB2Parameter("P_VCHINCLLANUMERO", DB2Type.VarChar, 10)
                    arrParam(26).Value = pCCOINCIDENCIA_BE.PropINCLLANUMERO
                    arrParam(27) = New DB2Parameter("P_VCHINCLLACUADRA", DB2Type.VarChar, 10)
                    arrParam(27).Value = pCCOINCIDENCIA_BE.PropINCLLACUADRA
                    arrParam(28) = New DB2Parameter("P_VCHINCLLAMANZANA", DB2Type.VarChar, 10)
                    arrParam(28).Value = pCCOINCIDENCIA_BE.PropINCLLAMANZANA
                    arrParam(29) = New DB2Parameter("P_VCHINCLLALOTE", DB2Type.VarChar, 10)
                    arrParam(29).Value = pCCOINCIDENCIA_BE.PropINCLLALOTE
                    arrParam(30) = New DB2Parameter("P_VCHINCLLADPTO", DB2Type.VarChar, 10)
                    arrParam(30).Value = pCCOINCIDENCIA_BE.PropINCLLADPTO
                    arrParam(31) = New DB2Parameter("P_VCHINCLLABLOCK", DB2Type.VarChar, 10)
                    arrParam(31).Value = pCCOINCIDENCIA_BE.PropINCLLABLOCK
                    arrParam(32) = New DB2Parameter("P_CHRINCLLAHABCODIGO", DB2Type.Char, 4)
                    arrParam(32).Value = pCCOINCIDENCIA_BE.PropINCLLAHABCODIGO
                    arrParam(33) = New DB2Parameter("P_VCHINCLLAHABNOMBRE", DB2Type.VarChar, 100)
                    arrParam(33).Value = pCCOINCIDENCIA_BE.PropINCLLAHABNOMBRE
                    arrParam(34) = New DB2Parameter("P_SMLINCLLASECTOR", DB2Type.SmallInt)
                    arrParam(34).Value = pCCOINCIDENCIA_BE.PropINCLLASECTOR
                    arrParam(35) = New DB2Parameter("P_SMLINCLLACUADRANTE", DB2Type.SmallInt)
                    arrParam(35).Value = pCCOINCIDENCIA_BE.PropINCLLACUADRANTE
                    arrParam(36) = New DB2Parameter("P_VCHINCLLACOMENTARIO", DB2Type.VarChar, 250)
                    arrParam(36).Value = pCCOINCIDENCIA_BE.PropINCLLACOMENTARIO
                    arrParam(37) = New DB2Parameter("P_VCHINCRESULTADO", DB2Type.VarChar, 500)
                    arrParam(37).Value = pCCOINCIDENCIA_BE.PropINCRESULTADO
                    arrParam(38) = New DB2Parameter("P_SMLINCESTADO", DB2Type.SmallInt)
                    arrParam(38).Value = pCCOINCIDENCIA_BE.PropINCESTADO
                    arrParam(39) = New DB2Parameter("P_DTMAUDFECCREACION", DB2Type.Timestamp)
                    arrParam(39).Value = pCCOINCIDENCIA_BE.PropAUDFECCREACION
                    arrParam(40) = New DB2Parameter("P_DTMAUDFECMODIF", DB2Type.Timestamp)
                    arrParam(40).Value = pCCOINCIDENCIA_BE.PropAUDFECMODIF
                    arrParam(41) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VarChar, 15)
                    arrParam(41).Value = pCCOINCIDENCIA_BE.PropAUDUSUCREACION
                    arrParam(42) = New DB2Parameter("P_VCHAUDUSUMODIF", DB2Type.VarChar, 15)
                    arrParam(42).Value = pCCOINCIDENCIA_BE.PropAUDUSUMODIF
                    arrParam(43) = New DB2Parameter("P_INTINCACODIGO", DB2Type.Integer)
                    arrParam(43).Value = pCCOINCIDENCIA_BE.PropINCACODIGO
                    arrParam(44) = New DB2Parameter("P_INTINCANUMERO", DB2Type.Integer)
                    arrParam(44).Value = pCCOINCIDENCIA_BE.PropINCANUMERO
                    arrParam(45) = New DB2Parameter("P_INTADMCODIGO", DB2Type.Integer)
                    arrParam(45).Value = pCCOINCIDENCIA_BE.PropADMCODIGO
                    arrParam(46) = New DB2Parameter("P_INTPRECODIGO", DB2Type.Integer)
                    arrParam(46).Value = pCCOINCIDENCIA_BE.PropPRECODIGO
                    arrParam(47) = New DB2Parameter("P_VCHINCIDLATITUDE", DB2Type.VarChar, 20)
                    arrParam(47).Value = pCCOINCIDENCIA_BE.PropINCIDLATITUDE
                    arrParam(48) = New DB2Parameter("P_VCHINCIDLONGITUDE", DB2Type.VarChar, 20)
                    arrParam(48).Value = pCCOINCIDENCIA_BE.PropINCIDLONGITUDE
                    arrParam(49) = New DB2Parameter("P_SMLORICODIGO", DB2Type.SmallInt)
                    arrParam(49).Value = pCCOINCIDENCIA_BE.PropORICODIGO
                    arrParam(50) = New DB2Parameter("P_SMLTINCODIGO", DB2Type.SmallInt)
                    arrParam(50).Value = pCCOINCIDENCIA_BE.PropTINCODIGO
                    arrParam(51) = New DB2Parameter("P_SMLSTICODIGO", DB2Type.SmallInt)
                    arrParam(51).Value = pCCOINCIDENCIA_BE.PropSTICODIGO
                    arrParam(52) = New DB2Parameter("P_SMLPRICODIGO", DB2Type.SmallInt)
                    arrParam(52).Value = pCCOINCIDENCIA_BE.PropPRICODIGO
                    arrParam(53) = New DB2Parameter("P_SMLTPECODIGO", DB2Type.SmallInt)
                    arrParam(53).Value = pCCOINCIDENCIA_BE.PropTPECODIGO
                    arrParam(54) = New DB2Parameter("P_VCHTIDCODIGO", DB2Type.VarChar, 2)
                    arrParam(54).Value = pCCOINCIDENCIA_BE.PropTIDCODIGO
                    arrParam(55) = New DB2Parameter("P_SMLINCINTERVENIDOS", DB2Type.SmallInt)
                    arrParam(55).Value = pCCOINCIDENCIA_BE.PropINCINTERVENIDOS
                    arrParam(56) = New DB2Parameter("P_INTPAQCODIGO", DB2Type.Integer)
                    arrParam(56).Value = pCCOINCIDENCIA_BE.PropPAQCODIGO
                    arrParam(57) = New DB2Parameter("P_INTPINCODIGO", DB2Type.Integer)
                    arrParam(57).Value = pCCOINCIDENCIA_BE.PropPINCODIGO
                    arrParam(58) = New DB2Parameter("P_INTAUDROLCREACION", DB2Type.Integer)
                    arrParam(58).Value = pCCOINCIDENCIA_BE.PropAUDROLCREACION
                    arrParam(59) = New DB2Parameter("P_INTAUDROLMODIF", DB2Type.Integer)
                    arrParam(59).Value = pCCOINCIDENCIA_BE.PropAUDROLMODIF
                    arrParam(60) = New DB2Parameter("P_VCHINCUSUDERIVADO", DB2Type.VarChar, 15)
                    arrParam(60).Value = pCCOINCIDENCIA_BE.PropINCUSUDERIVADO
                    arrParam(61) = New DB2Parameter("P_INTINCROLDERIVADO", DB2Type.Integer)
                    arrParam(61).Value = pCCOINCIDENCIA_BE.PropINCROLDERIVADO
                    arrParam(62) = New DB2Parameter("P_DTMINCFECDERIVADO", DB2Type.Timestamp)
                    arrParam(62).Value = pCCOINCIDENCIA_BE.PropINCFECDERIVADO
                    arrParam(63) = New DB2Parameter("P_SMLRESCODIGO", DB2Type.SmallInt)
                    arrParam(63).Value = pCCOINCIDENCIA_BE.PropRESCODIGO
                    arrParam(64) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VarChar, 150)
                    arrParam(64).Value = pCCOINCIDENCIA_BE.PropAUDPRGCREACION
                    arrParam(65) = New DB2Parameter("P_VCHAUDPRGMODIF", DB2Type.VarChar, 150)
                    arrParam(65).Value = pCCOINCIDENCIA_BE.PropAUDPRGMODIF
                    arrParam(66) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VarChar, 60)
                    arrParam(66).Value = pCCOINCIDENCIA_BE.PropAUDEQPCREACION
                    arrParam(67) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VarChar, 60)
                    arrParam(67).Value = pCCOINCIDENCIA_BE.PropAUDEQPMODIF
                    arrParam(68) = New DB2Parameter("P_VCHCATCODIGO", DB2Type.VarChar, 20)
                    arrParam(68).Value = pCCOINCIDENCIA_BE.PropCATCODIGO
                    arrParam(69) = New DB2Parameter("P_DTMINCFECHA", DB2Type.Timestamp)
                    arrParam(69).Value = pCCOINCIDENCIA_BE.PropINCFECHA
                    arrParam(70) = New DB2Parameter("P_VCHINCIDANEXO", DB2Type.VarChar, 5)
                    arrParam(70).Value = pCCOINCIDENCIA_BE.PropINCIDANEXO
                    arrParam(71) = New DB2Parameter("P_VCHINCIDLLAMADA", DB2Type.VarChar, 15)
                    arrParam(71).Value = pCCOINCIDENCIA_BE.PropINCIDLLAMADA
                    arrParam(72) = New DB2Parameter("P_SMLINCPARTEPOLICIAL", DB2Type.SmallInt)
                    arrParam(72).Value = pCCOINCIDENCIA_BE.PropINCPARTEPOLICIAL
                    arrParam(73) = New DB2Parameter("P_VCHMOTIVOALERTA", DB2Type.VarChar, 2)
                    arrParam(73).Value = pCCOINCIDENCIA_BE.PropVCHMOTIVOALERTA
                    arrParam(74) = New DB2Parameter("P_VCHCODQUEJA", DB2Type.VarChar, 12)
                    arrParam(74).Value = pCCOINCIDENCIA_BE.PropVCHCODQUEJA
                    arrParam(75) = New DB2Parameter("P_VCHINCLOCXGEO", DB2Type.VarChar, 20)
                    arrParam(75).Value = pCCOINCIDENCIA_BE.PropINCLOCXGEO
                    arrParam(76) = New DB2Parameter("P_VCHINCLOCYGEO", DB2Type.VarChar, 20)
                    arrParam(76).Value = pCCOINCIDENCIA_BE.PropINCLOCYGEO
                    arrParam(77) = New DB2Parameter("P_VCHINCLOCCUADRANTE", DB2Type.VarChar, 5)
                    arrParam(77).Value = pCCOINCIDENCIA_BE.PropINCLOCCUADRANTE
                    arrParam(78) = New DB2Parameter("P_VCHINCLOCSECTOR", DB2Type.VarChar, 5)
                    arrParam(78).Value = pCCOINCIDENCIA_BE.PropINCLOCSECTOR
                    DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIA_INSERTAR_SQL", arrParam)

                Next

            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try

        End Sub

        Public Function ListarF911(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE, ByVal pDesde As String, ByVal pHasta As String, ByVal pBuscaTodo As Integer) As DataTable
            Dim odt As New DataTable

            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(15) {}

                arrParam(0) = New DB2Parameter("P_SMLORICODIGO", DB2Type.SmallInt)
                arrParam(0).Value = pCCOINCIDENCIA_BE.PropORICODIGO
                arrParam(1) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(1).Value = pCCOINCIDENCIA_BE.PropINCCODIGO
                arrParam(2) = New DB2Parameter("P_SMLTINCODIGO", DB2Type.SmallInt)
                arrParam(2).Value = pCCOINCIDENCIA_BE.PropTINCODIGO
                arrParam(3) = New DB2Parameter("P_SMLSTICODIGO", DB2Type.SmallInt)
                arrParam(3).Value = pCCOINCIDENCIA_BE.PropSTICODIGO
                arrParam(4) = New DB2Parameter("P_SMLPRICODIGO", DB2Type.SmallInt)
                arrParam(4).Value = pCCOINCIDENCIA_BE.PropPRICODIGO
                arrParam(5) = New DB2Parameter("P_VCHINCNOMBRE", DB2Type.VarChar, 30)
                arrParam(5).Value = pCCOINCIDENCIA_BE.PropINCNOMBRE
                arrParam(6) = New DB2Parameter("P_VCHINCLOCVIANOMBRE1", DB2Type.VarChar, 150)
                arrParam(6).Value = pCCOINCIDENCIA_BE.PropINCLOCVIANOMBRE1
                arrParam(7) = New DB2Parameter("P_VCHINCNUMEROORIGEN", DB2Type.VarChar, 15)
                arrParam(7).Value = pCCOINCIDENCIA_BE.PropINCNUMEROORIGEN
                arrParam(8) = New DB2Parameter("P_VCHINCRELATO", DB2Type.VarChar, 500)
                arrParam(8).Value = pCCOINCIDENCIA_BE.PropINCRELATO
                arrParam(9) = New DB2Parameter("P_SMLINCESTADO", DB2Type.SmallInt)
                arrParam(9).Value = pCCOINCIDENCIA_BE.PropINCESTADO
                arrParam(10) = New DB2Parameter("P_INTINCACODIGO", DB2Type.Integer)
                arrParam(10).Value = pCCOINCIDENCIA_BE.PropINCACODIGO
                arrParam(11) = New DB2Parameter("P_SMLINCLOCSECTOR", DB2Type.Integer)
                arrParam(11).Value = pCCOINCIDENCIA_BE.PropINCLOCSECTOR
                arrParam(12) = New DB2Parameter("P_INTAUDROLMODIF", DB2Type.Integer)
                arrParam(12).Value = pCCOINCIDENCIA_BE.PropAUDROLMODIF
                '-- RANGO DE FECHAS
                arrParam(13) = New DB2Parameter("P_VCHFECHAINI", DB2Type.VarChar, 50)
                arrParam(13).Value = IIf(pDesde = "", DBNull.Value, pDesde)
                arrParam(14) = New DB2Parameter("P_VCHFECHAFIN", DB2Type.VarChar, 50)
                arrParam(14).Value = IIf(pHasta = "", DBNull.Value, pHasta)

                arrParam(15) = New DB2Parameter("P_BUSCATODO", DB2Type.Integer)
                arrParam(15).Value = pBuscaTodo



                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIA_BUSQUEDA_F911", arrParam)
                    odt.Load(dataReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return odt
        End Function

        Public Sub Actualizar_SQL_DB2(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(78) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOINCIDENCIA_BE.PropINCCODIGO
                arrParam(1) = New DB2Parameter("P_VCHINCCOMENTARIO", DB2Type.VarChar, 500)
                arrParam(1).Value = pCCOINCIDENCIA_BE.PropINCCOMENTARIO
                arrParam(2) = New DB2Parameter("P_VCHINCLOCVIACODIGO1", DB2Type.VarChar, 6)
                arrParam(2).Value = pCCOINCIDENCIA_BE.PropINCLOCVIACODIGO1
                arrParam(3) = New DB2Parameter("P_VCHINCLOCVIANOMBRE1", DB2Type.VarChar, 150)
                arrParam(3).Value = pCCOINCIDENCIA_BE.PropINCLOCVIANOMBRE1
                arrParam(4) = New DB2Parameter("P_VCHINCLOCVIACODIGO2", DB2Type.VarChar, 6)
                arrParam(4).Value = pCCOINCIDENCIA_BE.PropINCLOCVIACODIGO2
                arrParam(5) = New DB2Parameter("P_VCHINCLOCVIANOMBRE2", DB2Type.VarChar, 150)
                arrParam(5).Value = pCCOINCIDENCIA_BE.PropINCLOCVIANOMBRE2
                arrParam(6) = New DB2Parameter("P_VCHINCLOCNUMERO", DB2Type.VarChar, 10)
                arrParam(6).Value = pCCOINCIDENCIA_BE.PropINCLOCNUMERO
                arrParam(7) = New DB2Parameter("P_VCHINCLOCCUADRA", DB2Type.VarChar, 10)
                arrParam(7).Value = pCCOINCIDENCIA_BE.PropINCLOCCUADRA
                arrParam(8) = New DB2Parameter("P_VCHINCLOCMANZANA", DB2Type.VarChar, 10)
                arrParam(8).Value = pCCOINCIDENCIA_BE.PropINCLOCMANZANA
                arrParam(9) = New DB2Parameter("P_VCHINCLOCLOTE", DB2Type.VarChar, 10)
                arrParam(9).Value = pCCOINCIDENCIA_BE.PropINCLOCLOTE
                arrParam(10) = New DB2Parameter("P_VCHINCLOCDPTO", DB2Type.VarChar, 10)
                arrParam(10).Value = pCCOINCIDENCIA_BE.PropINCLOCDPTO
                arrParam(11) = New DB2Parameter("P_VCHINCLOCBLOCK", DB2Type.VarChar, 10)
                arrParam(11).Value = pCCOINCIDENCIA_BE.PropINCLOCBLOCK
                arrParam(12) = New DB2Parameter("P_CHRINCLOCHABCODIGO", DB2Type.Char, 4)
                arrParam(12).Value = pCCOINCIDENCIA_BE.PropINCLOCHABCODIGO
                arrParam(13) = New DB2Parameter("P_VCHINCLOCHABNOMBRE", DB2Type.VarChar, 100)
                arrParam(13).Value = pCCOINCIDENCIA_BE.PropINCLOCHABNOMBRE
                arrParam(14) = New DB2Parameter("P_VCHINCLOCCOMENTARIO", DB2Type.VarChar, 250)
                arrParam(14).Value = pCCOINCIDENCIA_BE.PropINCLOCCOMENTARIO
                arrParam(15) = New DB2Parameter("P_VCHINCRELATO", DB2Type.VarChar, 500)
                arrParam(15).Value = pCCOINCIDENCIA_BE.PropINCRELATO
                arrParam(16) = New DB2Parameter("P_SMLINCANONIMO", DB2Type.SmallInt)
                arrParam(16).Value = pCCOINCIDENCIA_BE.PropINCANONIMO
                arrParam(17) = New DB2Parameter("P_VCHINCNOMBRECOMP", DB2Type.VarChar, 100)
                arrParam(17).Value = pCCOINCIDENCIA_BE.PropINCNOMBRECOMP
                arrParam(18) = New DB2Parameter("P_VCHINCDOCUMENTO", DB2Type.VarChar, 20)
                arrParam(18).Value = pCCOINCIDENCIA_BE.PropINCDOCUMENTO
                arrParam(19) = New DB2Parameter("P_VCHINCRESULTADO", DB2Type.VarChar, 500)
                arrParam(19).Value = pCCOINCIDENCIA_BE.PropINCRESULTADO
                arrParam(20) = New DB2Parameter("P_SMLINCESTADO", DB2Type.SmallInt)
                arrParam(20).Value = pCCOINCIDENCIA_BE.PropINCESTADO
                arrParam(21) = New DB2Parameter("P_DTMAUDFECMODIF", DB2Type.Timestamp)
                arrParam(21).Value = pCCOINCIDENCIA_BE.PropAUDFECMODIF
                arrParam(22) = New DB2Parameter("P_VCHAUDUSUMODIF", DB2Type.VarChar, 15)
                arrParam(22).Value = pCCOINCIDENCIA_BE.PropAUDUSUMODIF
                arrParam(23) = New DB2Parameter("P_INTINCACODIGO", DB2Type.Integer)
                arrParam(23).Value = pCCOINCIDENCIA_BE.PropINCACODIGO
                arrParam(24) = New DB2Parameter("P_INTINCANUMERO", DB2Type.Integer)
                arrParam(24).Value = pCCOINCIDENCIA_BE.PropINCANUMERO
                arrParam(25) = New DB2Parameter("P_VCHINCIDLATITUDE", DB2Type.VarChar, 20)
                arrParam(25).Value = pCCOINCIDENCIA_BE.PropINCIDLATITUDE
                arrParam(26) = New DB2Parameter("P_VCHINCIDLONGITUDE", DB2Type.VarChar, 20)
                arrParam(26).Value = pCCOINCIDENCIA_BE.PropINCIDLONGITUDE
                arrParam(27) = New DB2Parameter("P_SMLORICODIGO", DB2Type.SmallInt)
                arrParam(27).Value = pCCOINCIDENCIA_BE.PropORICODIGO
                arrParam(28) = New DB2Parameter("P_SMLTINCODIGO", DB2Type.SmallInt)
                arrParam(28).Value = pCCOINCIDENCIA_BE.PropTINCODIGO
                arrParam(29) = New DB2Parameter("P_SMLSTICODIGO", DB2Type.SmallInt)
                arrParam(29).Value = pCCOINCIDENCIA_BE.PropSTICODIGO
                arrParam(30) = New DB2Parameter("P_SMLPRICODIGO", DB2Type.SmallInt)
                arrParam(30).Value = pCCOINCIDENCIA_BE.PropPRICODIGO
                arrParam(31) = New DB2Parameter("P_SMLTPECODIGO", DB2Type.SmallInt)
                arrParam(31).Value = pCCOINCIDENCIA_BE.PropTPECODIGO
                arrParam(32) = New DB2Parameter("P_VCHTIDCODIGO", DB2Type.VarChar, 2)
                arrParam(32).Value = pCCOINCIDENCIA_BE.PropTIDCODIGO
                arrParam(33) = New DB2Parameter("P_SMLINCINTERVENIDOS", DB2Type.SmallInt)
                arrParam(33).Value = pCCOINCIDENCIA_BE.PropINCINTERVENIDOS
                arrParam(34) = New DB2Parameter("P_INTPINCODIGO", DB2Type.Integer)
                arrParam(34).Value = pCCOINCIDENCIA_BE.PropPINCODIGO
                arrParam(35) = New DB2Parameter("P_SMLRESCODIGO", DB2Type.SmallInt)
                arrParam(35).Value = pCCOINCIDENCIA_BE.PropRESCODIGO
                arrParam(36) = New DB2Parameter("P_VCHAUDPRGMODIF", DB2Type.VarChar, 150)
                arrParam(36).Value = pCCOINCIDENCIA_BE.PropAUDPRGMODIF
                arrParam(37) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VarChar, 60)
                arrParam(37).Value = pCCOINCIDENCIA_BE.PropAUDEQPMODIF
                arrParam(38) = New DB2Parameter("P_SMLINCPARTEPOLICIAL", DB2Type.SmallInt)
                arrParam(38).Value = pCCOINCIDENCIA_BE.PropINCPARTEPOLICIAL
                arrParam(39) = New DB2Parameter("P_VCHINCLOCXGEO", DB2Type.VarChar, 20)
                arrParam(39).Value = pCCOINCIDENCIA_BE.PropINCLOCXGEO
                arrParam(40) = New DB2Parameter("P_VCHINCLOCYGEO", DB2Type.VarChar, 20)
                arrParam(40).Value = pCCOINCIDENCIA_BE.PropINCLOCYGEO
                arrParam(41) = New DB2Parameter("P_VCHINCLOCCUADRANTE", DB2Type.VarChar, 5)
                arrParam(41).Value = pCCOINCIDENCIA_BE.PropVCHINCLOCCUADRANTE
                arrParam(42) = New DB2Parameter("P_VCHINCLOCSECTOR", DB2Type.VarChar, 5)
                arrParam(42).Value = pCCOINCIDENCIA_BE.PropVCHINCLOCSECTOR
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIA_ACTUALIZAR_SQL", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try

        End Sub

        Public Sub DescartarSIAVE(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(3) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOINCIDENCIA_BE.PropINCCODIGO
                arrParam(1) = New DB2Parameter("P_VCHINCCOMENTARIO", DB2Type.VarChar, 500)
                arrParam(1).Value = pCCOINCIDENCIA_BE.PropINCCOMENTARIO
                arrParam(2) = New DB2Parameter("P_VCHAUDUSUMODIF", DB2Type.VarChar, 10)
                arrParam(2).Value = pCCOINCIDENCIA_BE.PropAUDUSUMODIF
                arrParam(3) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VarChar, 60)
                arrParam(3).Value = pCCOINCIDENCIA_BE.PropAUDEQPMODIF
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIA_DESCARTAR_SIAVE", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub
        Public Function ListarDetalle(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE) As DataTable
            Dim odt As New DataTable
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
                arrParam(0) = New DB2Parameter("P_DESDE", DB2Type.Date)
                arrParam(0).Value = Date.Parse(pCCOINCIDENCIA_BE.PropAUDUSUCREACION)
                arrParam(1) = New DB2Parameter("P_HASTA", DB2Type.Date)
                arrParam(1).Value = Date.Parse(pCCOINCIDENCIA_BE.PropAUDUSUMODIF)
                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIA_DETALLE_LISTAR", arrParam)
                    odt.Load(dataReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return odt
        End Function

        Public Sub Actualizar_GEO_SIAVE(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(20) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOINCIDENCIA_BE.PropINCCODIGO
                arrParam(1) = New DB2Parameter("P_VCHINCLOCVIACODIGO1", DB2Type.VarChar, 6)
                arrParam(1).Value = pCCOINCIDENCIA_BE.PropINCLOCVIACODIGO1
                arrParam(2) = New DB2Parameter("P_VCHINCLOCVIANOMBRE1", DB2Type.VarChar, 150)
                arrParam(2).Value = pCCOINCIDENCIA_BE.PropINCLOCVIANOMBRE1
                arrParam(3) = New DB2Parameter("P_VCHINCLOCNUMERO", DB2Type.VarChar, 10)
                arrParam(3).Value = pCCOINCIDENCIA_BE.PropINCLOCNUMERO
                arrParam(4) = New DB2Parameter("P_VCHINCLOCCUADRA", DB2Type.VarChar, 10)
                arrParam(4).Value = pCCOINCIDENCIA_BE.PropINCLOCCUADRA
                arrParam(5) = New DB2Parameter("P_VCHINCLOCMANZANA", DB2Type.VarChar, 10)
                arrParam(5).Value = pCCOINCIDENCIA_BE.PropINCLOCMANZANA
                arrParam(6) = New DB2Parameter("P_VCHINCLOCLOTE", DB2Type.VarChar, 10)
                arrParam(6).Value = pCCOINCIDENCIA_BE.PropINCLOCLOTE
                arrParam(7) = New DB2Parameter("P_VCHINCLOCDPTO", DB2Type.VarChar, 10)
                arrParam(7).Value = pCCOINCIDENCIA_BE.PropINCLOCDPTO
                arrParam(8) = New DB2Parameter("P_CHRINCLOCHABCODIGO", DB2Type.Char, 4)
                arrParam(8).Value = pCCOINCIDENCIA_BE.PropINCLOCHABCODIGO
                arrParam(9) = New DB2Parameter("P_VCHINCLOCHABNOMBRE", DB2Type.VarChar, 100)
                arrParam(9).Value = pCCOINCIDENCIA_BE.PropINCLOCHABNOMBRE

                arrParam(10) = New DB2Parameter("P_DTMAUDFECMODIF", DB2Type.Timestamp)
                arrParam(10).Value = pCCOINCIDENCIA_BE.PropAUDFECMODIF
                arrParam(11) = New DB2Parameter("P_VCHAUDUSUMODIF", DB2Type.VarChar, 15)
                arrParam(11).Value = pCCOINCIDENCIA_BE.PropAUDUSUMODIF
                arrParam(12) = New DB2Parameter("P_VCHINCIDLATITUDE", DB2Type.VarChar, 20)
                arrParam(12).Value = pCCOINCIDENCIA_BE.PropINCIDLATITUDE
                arrParam(13) = New DB2Parameter("P_VCHINCIDLONGITUDE", DB2Type.VarChar, 20)
                arrParam(13).Value = pCCOINCIDENCIA_BE.PropINCIDLONGITUDE

                arrParam(14) = New DB2Parameter("P_VCHAUDPRGMODIF", DB2Type.VarChar, 150)
                arrParam(14).Value = pCCOINCIDENCIA_BE.PropAUDPRGMODIF
                arrParam(15) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VarChar, 60)
                arrParam(15).Value = pCCOINCIDENCIA_BE.PropAUDEQPMODIF

                arrParam(16) = New DB2Parameter("P_VCHINCLOCXGEO", DB2Type.VarChar, 20)
                arrParam(16).Value = pCCOINCIDENCIA_BE.PropINCLOCXGEO
                arrParam(17) = New DB2Parameter("P_VCHINCLOCYGEO", DB2Type.VarChar, 20)
                arrParam(17).Value = pCCOINCIDENCIA_BE.PropINCLOCYGEO
                arrParam(18) = New DB2Parameter("P_VCHINCLOCCUADRANTE", DB2Type.VarChar, 5)
                arrParam(18).Value = pCCOINCIDENCIA_BE.PropVCHINCLOCCUADRANTE
                arrParam(19) = New DB2Parameter("P_VCHINCLOCSECTOR", DB2Type.VarChar, 5)
                arrParam(19).Value = pCCOINCIDENCIA_BE.PropVCHINCLOCSECTOR

                arrParam(20) = New DB2Parameter("P_VCHINCLOCCOMENTARIO", DB2Type.VarChar, 250)
                arrParam(20).Value = pCCOINCIDENCIA_BE.PropINCLOCCOMENTARIO

                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIA_ACTUALIZAR_GEO_SIAVE", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try

        End Sub



        Public Function InsertarAlertaSurcoV3(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE, ByVal pCCOINCIDENCIADEVICE_BE As CCOINCIDENCIADEVICE_BE) As Integer
            Dim result As Integer
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(25) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(0).Direction = ParameterDirection.Output
                arrParam(1) = New DB2Parameter("P_VCHINCNUMEROORIGEN", DB2Type.VarChar, 15)
                arrParam(1).Value = pCCOINCIDENCIA_BE.PropINCNUMEROORIGEN
                arrParam(2) = New DB2Parameter("P_VCHINCRELATO", DB2Type.VarChar, 500)
                arrParam(2).Value = pCCOINCIDENCIA_BE.PropINCRELATO
                arrParam(3) = New DB2Parameter("P_VCHINCNOMBRE", DB2Type.VarChar, 100)
                arrParam(3).Value = pCCOINCIDENCIA_BE.PropINCNOMBRE
                arrParam(4) = New DB2Parameter("P_SMLINCESTADO", DB2Type.SmallInt)
                arrParam(4).Value = pCCOINCIDENCIA_BE.PropINCESTADO
                arrParam(5) = New DB2Parameter("P_DTMAUDFECCREACION", DB2Type.Timestamp)
                arrParam(5).Value = pCCOINCIDENCIA_BE.PropAUDFECCREACION
                arrParam(6) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VarChar, 15)
                arrParam(6).Value = pCCOINCIDENCIA_BE.PropAUDUSUCREACION
                arrParam(7) = New DB2Parameter("P_VCHINCIDLATITUDE", DB2Type.VarChar, 50)
                arrParam(7).Value = pCCOINCIDENCIA_BE.PropINCIDLATITUDE
                arrParam(8) = New DB2Parameter("P_VCHINCIDLONGITUDE", DB2Type.VarChar, 50)
                arrParam(8).Value = pCCOINCIDENCIA_BE.PropINCIDLONGITUDE
                arrParam(9) = New DB2Parameter("P_SMLORICODIGO", DB2Type.SmallInt)
                arrParam(9).Value = pCCOINCIDENCIA_BE.PropORICODIGO
                arrParam(10) = New DB2Parameter("P_INTAUDROLCREACION", DB2Type.Integer)
                arrParam(10).Value = pCCOINCIDENCIA_BE.PropAUDROLCREACION
                arrParam(11) = New DB2Parameter("P_INTAUDROLMODIF", DB2Type.Integer)
                arrParam(11).Value = pCCOINCIDENCIA_BE.PropAUDROLMODIF
                arrParam(12) = New DB2Parameter("P_VCHINCUSUDERIVADO", DB2Type.VarChar, 15)
                arrParam(12).Value = pCCOINCIDENCIA_BE.PropINCUSUDERIVADO
                arrParam(13) = New DB2Parameter("P_INTINCROLDERIVADO", DB2Type.Integer)
                arrParam(13).Value = pCCOINCIDENCIA_BE.PropINCROLDERIVADO
                arrParam(14) = New DB2Parameter("P_DTMINCFECDERIVADO", DB2Type.Timestamp)
                arrParam(14).Value = pCCOINCIDENCIA_BE.PropINCFECDERIVADO
                arrParam(15) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VarChar, 60)
                arrParam(15).Value = pCCOINCIDENCIA_BE.PropAUDPRGCREACION
                arrParam(16) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VarChar, 60)
                arrParam(16).Value = pCCOINCIDENCIA_BE.PropAUDEQPCREACION
                arrParam(17) = New DB2Parameter("P_VCHINCIDLLAMADA", DB2Type.VarChar, 15)
                arrParam(17).Value = pCCOINCIDENCIA_BE.PropINCIDLLAMADA
                arrParam(18) = New DB2Parameter("P_VCHINCIDANEXO", DB2Type.VarChar, 5)
                arrParam(18).Value = pCCOINCIDENCIA_BE.PropINCIDANEXO
                arrParam(19) = New DB2Parameter("P_VCHMOTIVOALERTA", DB2Type.VarChar, 2)
                arrParam(19).Value = pCCOINCIDENCIA_BE.PropVCHMOTIVOALERTA

                arrParam(20) = New DB2Parameter("P_VCHINCLOCVIANOMBRE1", DB2Type.VarChar, 150)
                arrParam(20).Value = pCCOINCIDENCIA_BE.PropINCLOCVIANOMBRE1
                arrParam(21) = New DB2Parameter("P_VCHINCLOCHABNOMBRE", DB2Type.VarChar, 100)
                arrParam(21).Value = pCCOINCIDENCIA_BE.PropINCLOCHABNOMBRE
                arrParam(22) = New DB2Parameter("P_VCHINCLOCCUADRANTE", DB2Type.VarChar, 5)
                arrParam(22).Value = pCCOINCIDENCIA_BE.PropVCHINCLOCCUADRANTE
                arrParam(23) = New DB2Parameter("P_VCHINCLOCSECTOR", DB2Type.VarChar, 5)
                arrParam(23).Value = pCCOINCIDENCIA_BE.PropVCHINCLOCSECTOR
                arrParam(24) = New DB2Parameter("P_VCHINCLOCXGEO", DB2Type.VarChar, 20)
                arrParam(24).Value = pCCOINCIDENCIA_BE.PropINCLOCXGEO
                arrParam(25) = New DB2Parameter("P_VCHINCLOCYGEO", DB2Type.VarChar, 20)
                arrParam(25).Value = pCCOINCIDENCIA_BE.PropINCLOCYGEO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIA_INSERTAR_ALERTASURCO_V2", arrParam)
                result = arrParam(0).Value
                '-- Inserta datos complementarios
                Dim arrParamE() As DB2Parameter = New DB2Parameter(12) {}
                arrParamE(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParamE(0).Value = result
                arrParamE(1) = New DB2Parameter("P_VCHINCDEVSDK", DB2Type.VarChar, 50)
                arrParamE(1).Value = pCCOINCIDENCIADEVICE_BE.PropINCDEVSDK
                arrParamE(2) = New DB2Parameter("P_VCHINCDEVMODEL", DB2Type.VarChar, 50)
                arrParamE(2).Value = pCCOINCIDENCIADEVICE_BE.PropINCDEVMODEL
                arrParamE(3) = New DB2Parameter("P_VCHINCDEVDEVICE", DB2Type.VarChar, 50)
                arrParamE(3).Value = pCCOINCIDENCIADEVICE_BE.PropINCDEVDEVICE
                arrParamE(4) = New DB2Parameter("P_VCHINCDEVHOST", DB2Type.VarChar, 50)
                arrParamE(4).Value = pCCOINCIDENCIADEVICE_BE.PropINCDEVHOST
                arrParamE(5) = New DB2Parameter("P_VCHINCDEVID", DB2Type.VarChar, 50)
                arrParamE(5).Value = pCCOINCIDENCIADEVICE_BE.PropINCDEVID
                arrParamE(6) = New DB2Parameter("P_VCHINCDEVDISPLAY", DB2Type.VarChar, 50)
                arrParamE(6).Value = pCCOINCIDENCIADEVICE_BE.PropINCDEVDISPLAY
                arrParamE(7) = New DB2Parameter("P_VCHINCDEVMANUFAC", DB2Type.VarChar, 50)
                arrParamE(7).Value = pCCOINCIDENCIADEVICE_BE.PropINCDEVMANUFAC
                arrParamE(8) = New DB2Parameter("P_VCHINCDEVUSER", DB2Type.VarChar, 50)
                arrParamE(8).Value = pCCOINCIDENCIADEVICE_BE.PropINCDEVUSER
                arrParamE(9) = New DB2Parameter("P_DTMAUDFECCREACION", DB2Type.Timestamp)
                arrParamE(9).Value = pCCOINCIDENCIADEVICE_BE.PropAUDFECCREACION
                arrParamE(10) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VarChar, 15)
                arrParamE(10).Value = pCCOINCIDENCIADEVICE_BE.PropAUDUSUCREACION
                arrParamE(11) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VarChar, 60)
                arrParamE(11).Value = pCCOINCIDENCIADEVICE_BE.PropAUDPRGCREACION
                arrParamE(12) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VarChar, 60)
                arrParamE(12).Value = pCCOINCIDENCIADEVICE_BE.PropAUDEQPCREACION
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIADEVICE_INSERTAR", arrParamE)
                Return result
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return result
        End Function



        Public Function InsertarOperador(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE) As Integer
            Dim result As Integer = 0
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(43) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(0).Direction = ParameterDirection.Output
                arrParam(1) = New DB2Parameter("P_SMLORICODIGO", DB2Type.SmallInt)
                arrParam(1).Value = pCCOINCIDENCIA_BE.PropORICODIGO
                arrParam(2) = New DB2Parameter("P_VCHINCNUMEROORIGEN", DB2Type.VarChar, 15)
                arrParam(2).Value = pCCOINCIDENCIA_BE.PropINCNUMEROORIGEN
                arrParam(3) = New DB2Parameter("P_DTMINCFECHA", DB2Type.Timestamp)
                arrParam(3).Value = pCCOINCIDENCIA_BE.PropINCFECHA
                arrParam(4) = New DB2Parameter("P_VCHINCLOCVIACODIGO1", DB2Type.VarChar, 6)
                arrParam(4).Value = pCCOINCIDENCIA_BE.PropINCLOCVIACODIGO1
                arrParam(5) = New DB2Parameter("P_VCHINCLOCVIANOMBRE1", DB2Type.VarChar, 150)
                arrParam(5).Value = pCCOINCIDENCIA_BE.PropINCLOCVIANOMBRE1
                arrParam(6) = New DB2Parameter("P_VCHINCLOCVIACODIGO2", DB2Type.VarChar, 6)
                arrParam(6).Value = pCCOINCIDENCIA_BE.PropINCLOCVIACODIGO2
                arrParam(7) = New DB2Parameter("P_VCHINCLOCVIANOMBRE2", DB2Type.VarChar, 150)
                arrParam(7).Value = pCCOINCIDENCIA_BE.PropINCLOCVIANOMBRE2
                arrParam(8) = New DB2Parameter("P_VCHINCLOCNUMERO", DB2Type.VarChar, 10)
                arrParam(8).Value = pCCOINCIDENCIA_BE.PropINCLOCNUMERO
                arrParam(9) = New DB2Parameter("P_VCHINCLOCCUADRA", DB2Type.VarChar, 10)
                arrParam(9).Value = pCCOINCIDENCIA_BE.PropINCLOCCUADRA
                arrParam(10) = New DB2Parameter("P_VCHINCLOCMANZANA", DB2Type.VarChar, 10)
                arrParam(10).Value = pCCOINCIDENCIA_BE.PropINCLOCMANZANA
                arrParam(11) = New DB2Parameter("P_VCHINCLOCLOTE", DB2Type.VarChar, 10)
                arrParam(11).Value = pCCOINCIDENCIA_BE.PropINCLOCLOTE
                arrParam(12) = New DB2Parameter("P_VCHINCLOCDPTO", DB2Type.VarChar, 10)
                arrParam(12).Value = pCCOINCIDENCIA_BE.PropINCLOCDPTO
                arrParam(13) = New DB2Parameter("P_VCHINCLOCBLOCK", DB2Type.VarChar, 10)
                arrParam(13).Value = pCCOINCIDENCIA_BE.PropINCLOCBLOCK
                arrParam(14) = New DB2Parameter("P_CHRINCLOCHABCODIGO", DB2Type.Char, 4)
                arrParam(14).Value = pCCOINCIDENCIA_BE.PropINCLOCHABCODIGO
                arrParam(15) = New DB2Parameter("P_VCHINCLOCHABNOMBRE", DB2Type.VarChar, 100)
                arrParam(15).Value = pCCOINCIDENCIA_BE.PropINCLOCHABNOMBRE
                arrParam(16) = New DB2Parameter("P_VCHINCLOCSECTOR", DB2Type.VarChar, 5)
                arrParam(16).Value = pCCOINCIDENCIA_BE.PropVCHINCLOCSECTOR
                arrParam(17) = New DB2Parameter("P_VCHINCLOCCUADRANTE", DB2Type.VarChar, 5)
                arrParam(17).Value = pCCOINCIDENCIA_BE.PropVCHINCLOCCUADRANTE
                arrParam(18) = New DB2Parameter("P_VCHINCLOCCOMENTARIO", DB2Type.VarChar, 250)
                arrParam(18).Value = pCCOINCIDENCIA_BE.PropINCLOCCOMENTARIO
                arrParam(19) = New DB2Parameter("P_INTPRECODIGO", DB2Type.Integer)
                arrParam(19).Value = pCCOINCIDENCIA_BE.PropPRECODIGO
                arrParam(20) = New DB2Parameter("P_VCHINCIDLATITUDE", DB2Type.VarChar, 20)
                arrParam(20).Value = pCCOINCIDENCIA_BE.PropINCIDLATITUDE
                arrParam(21) = New DB2Parameter("P_VCHINCIDLONGITUDE", DB2Type.VarChar, 20)
                arrParam(21).Value = pCCOINCIDENCIA_BE.PropINCIDLONGITUDE
                arrParam(22) = New DB2Parameter("P_VCHCATCODIGO", DB2Type.VarChar, 20)
                arrParam(22).Value = pCCOINCIDENCIA_BE.PropCATCODIGO
                arrParam(23) = New DB2Parameter("P_VCHINCLOCXGEO", DB2Type.VarChar, 20)
                arrParam(23).Value = pCCOINCIDENCIA_BE.PropINCLOCXGEO
                arrParam(24) = New DB2Parameter("P_VCHINCLOCYGEO", DB2Type.VarChar, 20)
                arrParam(24).Value = pCCOINCIDENCIA_BE.PropINCLOCYGEO
                arrParam(25) = New DB2Parameter("P_SMLINCANONIMO", DB2Type.SmallInt)
                arrParam(25).Value = pCCOINCIDENCIA_BE.PropINCANONIMO
                arrParam(26) = New DB2Parameter("P_INTADMCODIGO", DB2Type.Integer)
                arrParam(26).Value = pCCOINCIDENCIA_BE.PropADMCODIGO
                arrParam(27) = New DB2Parameter("P_VCHINCNOMBRECOMP", DB2Type.VarChar, 100)
                arrParam(27).Value = pCCOINCIDENCIA_BE.PropINCNOMBRECOMP
                arrParam(28) = New DB2Parameter("P_VCHTIDCODIGO", DB2Type.VarChar, 2)
                arrParam(28).Value = pCCOINCIDENCIA_BE.PropTIDCODIGO
                arrParam(29) = New DB2Parameter("P_VCHINCDOCUMENTO", DB2Type.VarChar, 20)
                arrParam(29).Value = pCCOINCIDENCIA_BE.PropINCDOCUMENTO
                arrParam(30) = New DB2Parameter("P_VCHINCRELATO", DB2Type.VarChar, 500)
                arrParam(30).Value = pCCOINCIDENCIA_BE.PropINCRELATO
                arrParam(31) = New DB2Parameter("P_SMLINCESTADO", DB2Type.SmallInt)
                arrParam(31).Value = pCCOINCIDENCIA_BE.PropINCESTADO
                arrParam(32) = New DB2Parameter("P_INTINCACODIGO", DB2Type.Integer)
                arrParam(32).Value = pCCOINCIDENCIA_BE.PropINCACODIGO
                arrParam(33) = New DB2Parameter("P_INTINCANUMERO", DB2Type.Integer)
                arrParam(33).Value = pCCOINCIDENCIA_BE.PropINCANUMERO
                arrParam(34) = New DB2Parameter("P_SMLTINCODIGO", DB2Type.SmallInt)
                arrParam(34).Value = pCCOINCIDENCIA_BE.PropTINCODIGO
                arrParam(35) = New DB2Parameter("P_SMLSTICODIGO", DB2Type.SmallInt)
                arrParam(35).Value = pCCOINCIDENCIA_BE.PropSTICODIGO
                arrParam(36) = New DB2Parameter("P_SMLPRICODIGO", DB2Type.SmallInt)
                arrParam(36).Value = pCCOINCIDENCIA_BE.PropPRICODIGO
                arrParam(37) = New DB2Parameter("P_SMLTPECODIGO", DB2Type.SmallInt)
                arrParam(37).Value = pCCOINCIDENCIA_BE.PropTPECODIGO
                arrParam(38) = New DB2Parameter("P_INTAUDROLCREACION", DB2Type.Integer)
                arrParam(38).Value = pCCOINCIDENCIA_BE.PropAUDROLCREACION
                arrParam(39) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VarChar, 15)
                arrParam(39).Value = pCCOINCIDENCIA_BE.PropAUDUSUCREACION
                arrParam(40) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VarChar, 150)
                arrParam(40).Value = pCCOINCIDENCIA_BE.PropAUDPRGCREACION
                arrParam(41) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VarChar, 60)
                arrParam(41).Value = pCCOINCIDENCIA_BE.PropAUDEQPCREACION
                arrParam(42) = New DB2Parameter("P_DTMAUDFECCREACION", DB2Type.Timestamp)
                arrParam(42).Value = pCCOINCIDENCIA_BE.PropAUDFECCREACION
                arrParam(43) = New DB2Parameter("P_INTAUDROLMODIF", DB2Type.Integer)
                arrParam(43).Value = pCCOINCIDENCIA_BE.PropAUDROLMODIF


                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIA_INSERTAR_OPERADOR", arrParam)
                result = arrParam(0).Value
                Return result
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return result
        End Function


        Public Function ActualizarOperador(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE) As Integer
            Dim result As Integer = 0
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(43) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(0).Direction = ParameterDirection.InputOutput
                arrParam(0).Value = pCCOINCIDENCIA_BE.PropINCCODIGO
                arrParam(1) = New DB2Parameter("P_SMLORICODIGO", DB2Type.SmallInt)
                arrParam(1).Value = pCCOINCIDENCIA_BE.PropORICODIGO
                arrParam(2) = New DB2Parameter("P_VCHINCNUMEROORIGEN", DB2Type.VarChar, 15)
                arrParam(2).Value = pCCOINCIDENCIA_BE.PropINCNUMEROORIGEN
                arrParam(3) = New DB2Parameter("P_DTMINCFECHA", DB2Type.Timestamp)
                arrParam(3).Value = pCCOINCIDENCIA_BE.PropINCFECHA
                arrParam(4) = New DB2Parameter("P_VCHINCLOCVIACODIGO1", DB2Type.VarChar, 6)
                arrParam(4).Value = pCCOINCIDENCIA_BE.PropINCLOCVIACODIGO1
                arrParam(5) = New DB2Parameter("P_VCHINCLOCVIANOMBRE1", DB2Type.VarChar, 150)
                arrParam(5).Value = pCCOINCIDENCIA_BE.PropINCLOCVIANOMBRE1
                arrParam(6) = New DB2Parameter("P_VCHINCLOCVIACODIGO2", DB2Type.VarChar, 6)
                arrParam(6).Value = pCCOINCIDENCIA_BE.PropINCLOCVIACODIGO2
                arrParam(7) = New DB2Parameter("P_VCHINCLOCVIANOMBRE2", DB2Type.VarChar, 150)
                arrParam(7).Value = pCCOINCIDENCIA_BE.PropINCLOCVIANOMBRE2
                arrParam(8) = New DB2Parameter("P_VCHINCLOCNUMERO", DB2Type.VarChar, 10)
                arrParam(8).Value = pCCOINCIDENCIA_BE.PropINCLOCNUMERO
                arrParam(9) = New DB2Parameter("P_VCHINCLOCCUADRA", DB2Type.VarChar, 10)
                arrParam(9).Value = pCCOINCIDENCIA_BE.PropINCLOCCUADRA
                arrParam(10) = New DB2Parameter("P_VCHINCLOCMANZANA", DB2Type.VarChar, 10)
                arrParam(10).Value = pCCOINCIDENCIA_BE.PropINCLOCMANZANA
                arrParam(11) = New DB2Parameter("P_VCHINCLOCLOTE", DB2Type.VarChar, 10)
                arrParam(11).Value = pCCOINCIDENCIA_BE.PropINCLOCLOTE
                arrParam(12) = New DB2Parameter("P_VCHINCLOCDPTO", DB2Type.VarChar, 10)
                arrParam(12).Value = pCCOINCIDENCIA_BE.PropINCLOCDPTO
                arrParam(13) = New DB2Parameter("P_VCHINCLOCBLOCK", DB2Type.VarChar, 10)
                arrParam(13).Value = pCCOINCIDENCIA_BE.PropINCLOCBLOCK
                arrParam(14) = New DB2Parameter("P_CHRINCLOCHABCODIGO", DB2Type.Char, 4)
                arrParam(14).Value = pCCOINCIDENCIA_BE.PropINCLOCHABCODIGO
                arrParam(15) = New DB2Parameter("P_VCHINCLOCHABNOMBRE", DB2Type.VarChar, 100)
                arrParam(15).Value = pCCOINCIDENCIA_BE.PropINCLOCHABNOMBRE
                arrParam(16) = New DB2Parameter("P_VCHINCLOCSECTOR", DB2Type.VarChar, 5)
                arrParam(16).Value = pCCOINCIDENCIA_BE.PropVCHINCLOCSECTOR
                arrParam(17) = New DB2Parameter("P_VCHINCLOCCUADRANTE", DB2Type.VarChar, 5)
                arrParam(17).Value = pCCOINCIDENCIA_BE.PropVCHINCLOCCUADRANTE
                arrParam(18) = New DB2Parameter("P_VCHINCLOCCOMENTARIO", DB2Type.VarChar, 250)
                arrParam(18).Value = pCCOINCIDENCIA_BE.PropINCLOCCOMENTARIO
                arrParam(19) = New DB2Parameter("P_INTPRECODIGO", DB2Type.Integer)
                arrParam(19).Value = pCCOINCIDENCIA_BE.PropPRECODIGO
                arrParam(20) = New DB2Parameter("P_VCHINCIDLATITUDE", DB2Type.VarChar, 20)
                arrParam(20).Value = pCCOINCIDENCIA_BE.PropINCIDLATITUDE
                arrParam(21) = New DB2Parameter("P_VCHINCIDLONGITUDE", DB2Type.VarChar, 20)
                arrParam(21).Value = pCCOINCIDENCIA_BE.PropINCIDLONGITUDE
                arrParam(22) = New DB2Parameter("P_VCHCATCODIGO", DB2Type.VarChar, 20)
                arrParam(22).Value = pCCOINCIDENCIA_BE.PropCATCODIGO
                arrParam(23) = New DB2Parameter("P_VCHINCLOCXGEO", DB2Type.VarChar, 20)
                arrParam(23).Value = pCCOINCIDENCIA_BE.PropINCLOCXGEO
                arrParam(24) = New DB2Parameter("P_VCHINCLOCYGEO", DB2Type.VarChar, 20)
                arrParam(24).Value = pCCOINCIDENCIA_BE.PropINCLOCYGEO
                arrParam(25) = New DB2Parameter("P_SMLINCANONIMO", DB2Type.SmallInt)
                arrParam(25).Value = pCCOINCIDENCIA_BE.PropINCANONIMO
                arrParam(26) = New DB2Parameter("P_INTADMCODIGO", DB2Type.Integer)
                arrParam(26).Value = pCCOINCIDENCIA_BE.PropADMCODIGO
                arrParam(27) = New DB2Parameter("P_VCHINCNOMBRECOMP", DB2Type.VarChar, 100)
                arrParam(27).Value = pCCOINCIDENCIA_BE.PropINCNOMBRECOMP
                arrParam(28) = New DB2Parameter("P_VCHTIDCODIGO", DB2Type.VarChar, 2)
                arrParam(28).Value = pCCOINCIDENCIA_BE.PropTIDCODIGO
                arrParam(29) = New DB2Parameter("P_VCHINCDOCUMENTO", DB2Type.VarChar, 20)
                arrParam(29).Value = pCCOINCIDENCIA_BE.PropINCDOCUMENTO
                arrParam(30) = New DB2Parameter("P_VCHINCRELATO", DB2Type.VarChar, 500)
                arrParam(30).Value = pCCOINCIDENCIA_BE.PropINCRELATO
                arrParam(31) = New DB2Parameter("P_SMLINCESTADO", DB2Type.SmallInt)
                arrParam(31).Value = pCCOINCIDENCIA_BE.PropINCESTADO
                arrParam(32) = New DB2Parameter("P_INTINCACODIGO", DB2Type.Integer)
                arrParam(32).Value = pCCOINCIDENCIA_BE.PropINCACODIGO
                arrParam(33) = New DB2Parameter("P_INTINCANUMERO", DB2Type.Integer)
                arrParam(33).Value = pCCOINCIDENCIA_BE.PropINCANUMERO
                arrParam(34) = New DB2Parameter("P_SMLTINCODIGO", DB2Type.SmallInt)
                arrParam(34).Value = pCCOINCIDENCIA_BE.PropTINCODIGO
                arrParam(35) = New DB2Parameter("P_SMLSTICODIGO", DB2Type.SmallInt)
                arrParam(35).Value = pCCOINCIDENCIA_BE.PropSTICODIGO
                arrParam(36) = New DB2Parameter("P_SMLPRICODIGO", DB2Type.SmallInt)
                arrParam(36).Value = pCCOINCIDENCIA_BE.PropPRICODIGO
                arrParam(37) = New DB2Parameter("P_SMLTPECODIGO", DB2Type.SmallInt)
                arrParam(37).Value = pCCOINCIDENCIA_BE.PropTPECODIGO
                arrParam(38) = New DB2Parameter("P_INTAUDROLCREACION", DB2Type.Integer)
                arrParam(38).Value = pCCOINCIDENCIA_BE.PropAUDROLCREACION
                arrParam(39) = New DB2Parameter("P_VCHAUDUSUMODIF", DB2Type.VarChar, 15)
                arrParam(39).Value = pCCOINCIDENCIA_BE.PropAUDUSUMODIF
                arrParam(40) = New DB2Parameter("P_VCHAUDPRGMODIF", DB2Type.VarChar, 150)
                arrParam(40).Value = pCCOINCIDENCIA_BE.PropAUDPRGMODIF
                arrParam(41) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VarChar, 60)
                arrParam(41).Value = pCCOINCIDENCIA_BE.PropAUDEQPMODIF
                arrParam(42) = New DB2Parameter("P_DTMAUDFECMODIF", DB2Type.Timestamp)
                arrParam(42).Value = pCCOINCIDENCIA_BE.PropAUDFECMODIF
                arrParam(43) = New DB2Parameter("P_INTAUDAUDROLMODIF", DB2Type.Integer)
                arrParam(43).Value = pCCOINCIDENCIA_BE.PropAUDROLMODIF

                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIA_ACTUALIZAR_OPERADOR", arrParam)
                result = arrParam(0).Value
                Return result
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return result
        End Function

        Public Sub Finalizar_Atencion(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(11) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOINCIDENCIA_BE.PropINCCODIGO

                arrParam(1) = New DB2Parameter("P_VCHINCRESULTADO", DB2Type.VarChar, 500)
                arrParam(1).Value = pCCOINCIDENCIA_BE.PropINCRESULTADO

                arrParam(2) = New DB2Parameter("P_SMLINCINTERVENIDOS", DB2Type.SmallInt)
                arrParam(2).Value = pCCOINCIDENCIA_BE.PropINCINTERVENIDOS
                arrParam(3) = New DB2Parameter("P_INTPINCODIGO", DB2Type.Integer)
                arrParam(3).Value = pCCOINCIDENCIA_BE.PropPINCODIGO
                arrParam(4) = New DB2Parameter("P_SMLINCPARTEPOLICIAL", DB2Type.SmallInt)
                arrParam(4).Value = pCCOINCIDENCIA_BE.PropINCPARTEPOLICIAL
                arrParam(5) = New DB2Parameter("P_SMLRESCODIGO", DB2Type.SmallInt)
                arrParam(5).Value = pCCOINCIDENCIA_BE.PropRESCODIGO
                arrParam(6) = New DB2Parameter("P_SMLINCESTADO", DB2Type.SmallInt)
                arrParam(6).Value = pCCOINCIDENCIA_BE.PropINCESTADO

                arrParam(7) = New DB2Parameter("P_INTAUDROLMODIF", DB2Type.Integer)
                arrParam(7).Value = pCCOINCIDENCIA_BE.PropAUDROLMODIF
                arrParam(8) = New DB2Parameter("P_DTMAUDFECMODIF", DB2Type.Timestamp)
                arrParam(8).Value = pCCOINCIDENCIA_BE.PropAUDFECMODIF
                arrParam(9) = New DB2Parameter("P_VCHAUDUSUMODIF", DB2Type.VarChar, 15)
                arrParam(9).Value = pCCOINCIDENCIA_BE.PropAUDUSUMODIF
                arrParam(10) = New DB2Parameter("P_VCHAUDPRGMODIF", DB2Type.VarChar, 150)
                arrParam(10).Value = pCCOINCIDENCIA_BE.PropAUDPRGMODIF
                arrParam(11) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VarChar, 60)
                arrParam(11).Value = pCCOINCIDENCIA_BE.PropAUDEQPMODIF
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIA_FINALIZAR_ATENCION", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub


        Public Sub Finalizar_Atencion_Nuevo(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(15) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOINCIDENCIA_BE.PropINCCODIGO

                arrParam(1) = New DB2Parameter("P_VCHINCRESULTADO", DB2Type.VarChar, 1000)
                arrParam(1).Value = pCCOINCIDENCIA_BE.PropINCRESULTADO

                arrParam(2) = New DB2Parameter("P_SMLINCINTERVENIDOS", DB2Type.SmallInt)
                arrParam(2).Value = pCCOINCIDENCIA_BE.PropINCINTERVENIDOS
                arrParam(3) = New DB2Parameter("P_INTPINCODIGO", DB2Type.Integer)
                arrParam(3).Value = pCCOINCIDENCIA_BE.PropPINCODIGO
                arrParam(4) = New DB2Parameter("P_SMLINCPARTEPOLICIAL", DB2Type.SmallInt)
                arrParam(4).Value = pCCOINCIDENCIA_BE.PropINCPARTEPOLICIAL
                arrParam(5) = New DB2Parameter("P_SMLRESCODIGO", DB2Type.SmallInt)
                arrParam(5).Value = pCCOINCIDENCIA_BE.PropRESCODIGO
                arrParam(6) = New DB2Parameter("P_SMLINCESTADO", DB2Type.SmallInt)
                arrParam(6).Value = pCCOINCIDENCIA_BE.PropINCESTADO

                arrParam(7) = New DB2Parameter("P_INTAUDROLMODIF", DB2Type.Integer)
                arrParam(7).Value = pCCOINCIDENCIA_BE.PropAUDROLMODIF
                arrParam(8) = New DB2Parameter("P_DTMAUDFECMODIF", DB2Type.Timestamp)
                arrParam(8).Value = pCCOINCIDENCIA_BE.PropAUDFECMODIF
                arrParam(9) = New DB2Parameter("P_VCHAUDUSUMODIF", DB2Type.VarChar, 15)
                arrParam(9).Value = pCCOINCIDENCIA_BE.PropAUDUSUMODIF
                arrParam(10) = New DB2Parameter("P_VCHAUDPRGMODIF", DB2Type.VarChar, 150)
                arrParam(10).Value = pCCOINCIDENCIA_BE.PropAUDPRGMODIF
                arrParam(11) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VarChar, 60)
                arrParam(11).Value = pCCOINCIDENCIA_BE.PropAUDEQPMODIF

                arrParam(12) = New DB2Parameter("P_SMLTINCODIGO", DB2Type.SmallInt)
                arrParam(12).Value = pCCOINCIDENCIA_BE.PropTINCODIGO
                arrParam(13) = New DB2Parameter("P_SMLSTICODIGO", DB2Type.SmallInt)
                arrParam(13).Value = pCCOINCIDENCIA_BE.PropSTICODIGO
                arrParam(14) = New DB2Parameter("P_SMLPRICODIGO", DB2Type.SmallInt)
                arrParam(14).Value = pCCOINCIDENCIA_BE.PropPRICODIGO
                arrParam(15) = New DB2Parameter("P_SMLORICODIGO", DB2Type.SmallInt)
                arrParam(15).Value = pCCOINCIDENCIA_BE.PropORICODIGO

                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIA_FINALIZAR_ATENCION3", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function Busqueda(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE, ByVal pBuscaTodo As Integer) As DataTable
            Dim odt As New DataTable

            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(21) {}

                arrParam(0) = New DB2Parameter("P_SMLORICODIGO", DB2Type.SmallInt)
                arrParam(0).Value = pCCOINCIDENCIA_BE.PropORICODIGO
                arrParam(1) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(1).Value = pCCOINCIDENCIA_BE.PropINCCODIGO
                arrParam(2) = New DB2Parameter("P_SMLTINCODIGO", DB2Type.SmallInt)
                arrParam(2).Value = pCCOINCIDENCIA_BE.PropTINCODIGO
                arrParam(3) = New DB2Parameter("P_SMLSTICODIGO", DB2Type.SmallInt)
                arrParam(3).Value = pCCOINCIDENCIA_BE.PropSTICODIGO
                arrParam(4) = New DB2Parameter("P_SMLPRICODIGO", DB2Type.SmallInt)
                arrParam(4).Value = pCCOINCIDENCIA_BE.PropPRICODIGO
                arrParam(5) = New DB2Parameter("P_VCHINCNOMBRE", DB2Type.VarChar, 30)
                arrParam(5).Value = pCCOINCIDENCIA_BE.PropINCNOMBRECOMP
                arrParam(6) = New DB2Parameter("P_VCHINCLOCVIANOMBRE1", DB2Type.VarChar, 150)
                arrParam(6).Value = pCCOINCIDENCIA_BE.PropINCLOCVIANOMBRE1
                arrParam(7) = New DB2Parameter("P_VCHINCNUMEROORIGEN", DB2Type.VarChar, 15)
                arrParam(7).Value = pCCOINCIDENCIA_BE.PropINCNUMEROORIGEN
                arrParam(8) = New DB2Parameter("P_VCHINCRELATO", DB2Type.VarChar, 500)
                arrParam(8).Value = pCCOINCIDENCIA_BE.PropINCRELATO
                arrParam(9) = New DB2Parameter("P_SMLINCESTADO", DB2Type.SmallInt)
                arrParam(9).Value = pCCOINCIDENCIA_BE.PropINCESTADO

                arrParam(10) = New DB2Parameter("P_INTAUDROLMODIF", DB2Type.Integer)
                arrParam(10).Value = pCCOINCIDENCIA_BE.PropAUDROLMODIF

                arrParam(11) = New DB2Parameter("P_INTRECCODIGO", DB2Type.Integer)
                arrParam(11).Value = pCCOINCIDENCIA_BE.PropPAQCODIGO
                arrParam(12) = New DB2Parameter("P_VCHINCLOCSECTOR", DB2Type.VarChar, 5)
                arrParam(12).Value = pCCOINCIDENCIA_BE.PropVCHINCLOCSECTOR

                arrParam(13) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VarChar, 50)
                arrParam(13).Value = pCCOINCIDENCIA_BE.PropAUDUSUCREACION

                arrParam(14) = New DB2Parameter("P_VCHFECHAINI", DB2Type.Date, 10)
                arrParam(14).Value = pCCOINCIDENCIA_BE.PropAUDFECCREACION
                arrParam(15) = New DB2Parameter("P_VCHFECHAFIN", DB2Type.Date, 10)
                arrParam(15).Value = pCCOINCIDENCIA_BE.PropAUDFECMODIF

                arrParam(16) = New DB2Parameter("P_VCHHORAINI", DB2Type.VarChar, 10)
                arrParam(16).Value = pCCOINCIDENCIA_BE.PropAUDPRGCREACION
                arrParam(17) = New DB2Parameter("P_VCHHORAFIN", DB2Type.VarChar, 10)
                arrParam(17).Value = pCCOINCIDENCIA_BE.PropAUDPRGMODIF

                arrParam(18) = New DB2Parameter("P_VCHRECCODIGO", DB2Type.VarChar, 15)
                arrParam(18).Value = pCCOINCIDENCIA_BE.PropINCNOMBRE

                arrParam(19) = New DB2Parameter("P_VCHINCLOCCUADRANTE", DB2Type.VarChar, 5)
                arrParam(19).Value = pCCOINCIDENCIA_BE.PropVCHINCLOCCUADRANTE

                arrParam(20) = New DB2Parameter("P_VCHINCIDANEXO", DB2Type.VarChar, 5)
                arrParam(20).Value = pCCOINCIDENCIA_BE.PropINCIDANEXO

                arrParam(21) = New DB2Parameter("P_BUSCATODO", DB2Type.Integer)
                arrParam(21).Value = pBuscaTodo

                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIA_BUSQUEDA_SADE5", arrParam)
                    odt.Load(dataReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return odt
        End Function


        Public Function ReporteFormatoSADE(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE) As DataTable
            Dim odt As New DataTable

            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}

                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOINCIDENCIA_BE.PropINCCODIGO

                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIA_FORMATO", arrParam)
                    odt.Load(dataReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return odt
        End Function


        Public Function Exportar(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE) As DataTable
            Dim odt As New DataTable

            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}

                arrParam(0) = New DB2Parameter("P_VCHFECHAINI", DB2Type.Date, 10)
                arrParam(0).Value = pCCOINCIDENCIA_BE.PropAUDFECCREACION
                arrParam(1) = New DB2Parameter("P_VCHFECHAFIN", DB2Type.Date, 10)
                arrParam(1).Value = pCCOINCIDENCIA_BE.PropAUDFECMODIF

                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIA_EXPORTAR", arrParam)
                    odt.Load(dataReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return odt
        End Function

        Public Function getFechaHoraServer() As DateTime
            Dim resDateServer As DateTime
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_DTMSYSFECHORA", DB2Type.Timestamp)
                arrParam(0).Direction = ParameterDirection.Output

                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIA_FECHA_HORA", arrParam)
                resDateServer = arrParam(0).Value
                Return resDateServer
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return resDateServer
        End Function

        Public Sub DerivarSIAVE2(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(4) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOINCIDENCIA_BE.PropINCCODIGO
                arrParam(1) = New DB2Parameter("P_VCHINCCOMENTARIO", DB2Type.VarChar, 500)
                arrParam(1).Value = pCCOINCIDENCIA_BE.PropINCCOMENTARIO
                arrParam(2) = New DB2Parameter("P_VCHCODQUEJA", DB2Type.VarChar, 12)
                arrParam(2).Value = pCCOINCIDENCIA_BE.PropVCHCODQUEJA
                arrParam(3) = New DB2Parameter("P_VCHAUDUSUMODIF", DB2Type.VarChar, 10)
                arrParam(3).Value = pCCOINCIDENCIA_BE.PropAUDUSUMODIF
                arrParam(4) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VarChar, 60)
                arrParam(4).Value = pCCOINCIDENCIA_BE.PropAUDEQPMODIF
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIA_DERIVAR_SIAVE2", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub


        Public Sub ActualizarFile(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOINCIDENCIA_BE.PropINCCODIGO
                arrParam(1) = New DB2Parameter("P_VCHINCIDANEXO", DB2Type.VarChar, 5)
                arrParam(1).Value = pCCOINCIDENCIA_BE.PropINCIDANEXO

                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIA_ACTUALIZARFILE", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub


        Public Sub ActualizarFileNew(ByVal pNAMEFILE As String)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_VCHPOSTFILE", DB2Type.VarChar, 150)
                arrParam(0).Value = pNAMEFILE

                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIA_ACTUALIZARFILE_NEW", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function BusquedaGeneral(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE, ByVal pBuscaTodo As Integer) As DataTable
            Dim odt As New DataTable

            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(21) {}

                arrParam(0) = New DB2Parameter("P_SMLORICODIGO", DB2Type.SmallInt)
                arrParam(0).Value = pCCOINCIDENCIA_BE.PropORICODIGO
                arrParam(1) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(1).Value = pCCOINCIDENCIA_BE.PropINCCODIGO
                arrParam(2) = New DB2Parameter("P_SMLTINCODIGO", DB2Type.SmallInt)
                arrParam(2).Value = pCCOINCIDENCIA_BE.PropTINCODIGO
                arrParam(3) = New DB2Parameter("P_SMLSTICODIGO", DB2Type.SmallInt)
                arrParam(3).Value = pCCOINCIDENCIA_BE.PropSTICODIGO
                arrParam(4) = New DB2Parameter("P_SMLPRICODIGO", DB2Type.SmallInt)
                arrParam(4).Value = pCCOINCIDENCIA_BE.PropPRICODIGO
                arrParam(5) = New DB2Parameter("P_VCHINCNOMBRE", DB2Type.VarChar, 30)
                arrParam(5).Value = pCCOINCIDENCIA_BE.PropINCNOMBRECOMP
                arrParam(6) = New DB2Parameter("P_VCHINCLOCVIANOMBRE1", DB2Type.VarChar, 150)
                arrParam(6).Value = pCCOINCIDENCIA_BE.PropINCLOCVIANOMBRE1
                arrParam(7) = New DB2Parameter("P_VCHINCNUMEROORIGEN", DB2Type.VarChar, 15)
                arrParam(7).Value = pCCOINCIDENCIA_BE.PropINCNUMEROORIGEN
                arrParam(8) = New DB2Parameter("P_VCHINCRELATO", DB2Type.VarChar, 500)
                arrParam(8).Value = pCCOINCIDENCIA_BE.PropINCRELATO
                arrParam(9) = New DB2Parameter("P_SMLINCESTADO", DB2Type.SmallInt)
                arrParam(9).Value = pCCOINCIDENCIA_BE.PropINCESTADO

                arrParam(10) = New DB2Parameter("P_INTAUDROLMODIF", DB2Type.Integer)
                arrParam(10).Value = pCCOINCIDENCIA_BE.PropAUDROLMODIF

                arrParam(11) = New DB2Parameter("P_INTRECCODIGO", DB2Type.Integer)
                arrParam(11).Value = pCCOINCIDENCIA_BE.PropPAQCODIGO
                arrParam(12) = New DB2Parameter("P_VCHINCLOCSECTOR", DB2Type.VarChar, 5)
                arrParam(12).Value = pCCOINCIDENCIA_BE.PropVCHINCLOCSECTOR

                arrParam(13) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VarChar, 50)
                arrParam(13).Value = pCCOINCIDENCIA_BE.PropAUDUSUCREACION

                arrParam(14) = New DB2Parameter("P_VCHFECHAINI", DB2Type.Date, 10)
                arrParam(14).Value = pCCOINCIDENCIA_BE.PropAUDFECCREACION
                arrParam(15) = New DB2Parameter("P_VCHFECHAFIN", DB2Type.Date, 10)
                arrParam(15).Value = pCCOINCIDENCIA_BE.PropAUDFECMODIF

                arrParam(16) = New DB2Parameter("P_VCHHORAINI", DB2Type.VarChar, 10)
                arrParam(16).Value = pCCOINCIDENCIA_BE.PropAUDPRGCREACION
                arrParam(17) = New DB2Parameter("P_VCHHORAFIN", DB2Type.VarChar, 10)
                arrParam(17).Value = pCCOINCIDENCIA_BE.PropAUDPRGMODIF

                arrParam(18) = New DB2Parameter("P_VCHRECCODIGO", DB2Type.VarChar, 15)
                arrParam(18).Value = pCCOINCIDENCIA_BE.PropINCNOMBRE

                arrParam(19) = New DB2Parameter("P_VCHINCLOCCUADRANTE", DB2Type.VarChar, 5)
                arrParam(19).Value = pCCOINCIDENCIA_BE.PropVCHINCLOCCUADRANTE

                arrParam(20) = New DB2Parameter("P_VCHRECPERSONAL", DB2Type.VarChar, 100)
                arrParam(20).Value = pCCOINCIDENCIA_BE.PropINCLLAVIANOMBRE


                arrParam(21) = New DB2Parameter("P_BUSCATODO", DB2Type.Integer)
                arrParam(21).Value = pBuscaTodo

                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIA_BUSQUEDA_GENERAL", arrParam)
                    odt.Load(dataReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return odt
        End Function

        Public Function RegistrarAlertaSurcoV2(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE, ByVal pGPSREGISTRO_BE As GPSREGISTRO_BE) As Integer
            Dim result As Integer
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(26) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(0).Direction = ParameterDirection.Output
                arrParam(1) = New DB2Parameter("P_INTINCCODIGOAPP", DB2Type.Integer)
                arrParam(1).Value = pCCOINCIDENCIA_BE.PropINCCODIGOAPP

                arrParam(2) = New DB2Parameter("P_SMLORICODIGO", DB2Type.SmallInt)
                arrParam(2).Value = pCCOINCIDENCIA_BE.PropORICODIGO
                arrParam(3) = New DB2Parameter("P_VCHINCNUMEROORIGEN", DB2Type.VarChar, 15)
                arrParam(3).Value = pCCOINCIDENCIA_BE.PropINCNUMEROORIGEN
                arrParam(4) = New DB2Parameter("P_VCHINCIDLLAMADA", DB2Type.VarChar, 15)
                arrParam(4).Value = pCCOINCIDENCIA_BE.PropINCIDLLAMADA
                arrParam(5) = New DB2Parameter("P_VCHINCIDLATITUDE", DB2Type.VarChar, 50)
                arrParam(5).Value = pCCOINCIDENCIA_BE.PropINCIDLATITUDE
                arrParam(6) = New DB2Parameter("P_VCHINCIDLONGITUDE", DB2Type.VarChar, 50)
                arrParam(6).Value = pCCOINCIDENCIA_BE.PropINCIDLONGITUDE
                arrParam(7) = New DB2Parameter("P_VCHINCNOMBRE", DB2Type.VarChar, 100)
                arrParam(7).Value = pCCOINCIDENCIA_BE.PropINCNOMBRE

                arrParam(8) = New DB2Parameter("P_SMLTINCODIGO", DB2Type.SmallInt)
                arrParam(8).Value = pCCOINCIDENCIA_BE.PropTINCODIGO

                arrParam(9) = New DB2Parameter("P_SMLSTICODIGO", DB2Type.SmallInt)
                arrParam(9).Value = pCCOINCIDENCIA_BE.PropSTICODIGO

                arrParam(10) = New DB2Parameter("P_SMLINCESTADO", DB2Type.SmallInt)
                arrParam(10).Value = pCCOINCIDENCIA_BE.PropINCESTADO

                arrParam(11) = New DB2Parameter("P_VCHINCLOCCUADRANTE", DB2Type.VarChar, 5)
                arrParam(11).Value = pCCOINCIDENCIA_BE.PropVCHINCLOCCUADRANTE
                arrParam(12) = New DB2Parameter("P_VCHINCLOCSECTOR", DB2Type.VarChar, 5)
                arrParam(12).Value = pCCOINCIDENCIA_BE.PropVCHINCLOCSECTOR

                arrParam(13) = New DB2Parameter("P_VCHINCLOCVIANOMBRE1", DB2Type.VarChar, 150)
                arrParam(13).Value = pCCOINCIDENCIA_BE.PropINCLOCVIANOMBRE1
                arrParam(14) = New DB2Parameter("P_VCHINCLOCHABNOMBRE", DB2Type.VarChar, 100)
                arrParam(14).Value = pCCOINCIDENCIA_BE.PropINCLOCHABNOMBRE
                arrParam(15) = New DB2Parameter("P_VCHINCLOCXGEO", DB2Type.VarChar, 20)
                arrParam(15).Value = pCCOINCIDENCIA_BE.PropINCLOCXGEO
                arrParam(16) = New DB2Parameter("P_VCHINCLOCYGEO", DB2Type.VarChar, 20)
                arrParam(16).Value = pCCOINCIDENCIA_BE.PropINCLOCYGEO

                arrParam(17) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VarChar, 15)
                arrParam(17).Value = pCCOINCIDENCIA_BE.PropAUDUSUCREACION
                arrParam(18) = New DB2Parameter("P_DTMAUDFECCREACION", DB2Type.Timestamp)
                arrParam(18).Value = pCCOINCIDENCIA_BE.PropAUDFECCREACION
                arrParam(19) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VarChar, 60)
                arrParam(19).Value = pCCOINCIDENCIA_BE.PropAUDPRGCREACION
                arrParam(20) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VarChar, 60)
                arrParam(20).Value = pCCOINCIDENCIA_BE.PropAUDEQPCREACION

                arrParam(21) = New DB2Parameter("P_VCHREGNUMERO", DB2Type.VarChar, 12)
                arrParam(21).Value = pGPSREGISTRO_BE.PropREGNUMERO
                arrParam(22) = New DB2Parameter("P_VCHREGNOMBRE", DB2Type.VarChar, 100)
                arrParam(22).Value = pGPSREGISTRO_BE.PropREGNOMBRE
                arrParam(23) = New DB2Parameter("P_VCHREGDCMNTO", DB2Type.VarChar, 15)
                arrParam(23).Value = pGPSREGISTRO_BE.PropREGDCMNTO
                arrParam(24) = New DB2Parameter("P_VCHREGEMAIL", DB2Type.VarChar, 50)
                arrParam(24).Value = pGPSREGISTRO_BE.PropREGEMAIL
                arrParam(25) = New DB2Parameter("P_SMLREGACTIVO", DB2Type.SmallInt)
                arrParam(25).Value = pGPSREGISTRO_BE.PropREGACTIVO

                arrParam(26) = New DB2Parameter("P_VCHINCARCHIVOURL", DB2Type.VarChar, 150)
                arrParam(26).Value = pCCOINCIDENCIA_BE.PropINCARCHIVOURL


                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIA_INSERTAR_ALERTASURCO_V2", arrParam)
                result = arrParam(0).Value
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return result
        End Function


        Public Function RegistrarLlamada(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE) As Integer
            Dim result As Integer
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(9) {}

                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(0).Direction = ParameterDirection.Output
                arrParam(1) = New DB2Parameter("P_SMLORICODIGO", DB2Type.SmallInt)
                arrParam(1).Value = pCCOINCIDENCIA_BE.PropORICODIGO
                arrParam(2) = New DB2Parameter("P_VCHINCNUMEROORIGEN", DB2Type.VarChar, 15)
                arrParam(2).Value = pCCOINCIDENCIA_BE.PropINCNUMEROORIGEN
                '--- ID LLAMADA, ANEXO RECIBE, 
                arrParam(3) = New DB2Parameter("P_VCHINCIDLLAMADA", DB2Type.VarChar, 15)
                arrParam(3).Value = pCCOINCIDENCIA_BE.PropINCIDLLAMADA
                arrParam(4) = New DB2Parameter("P_VCHINCIDANEXON", DB2Type.VarChar, 5)
                arrParam(4).Value = pCCOINCIDENCIA_BE.PropINCIDANEXO
                arrParam(5) = New DB2Parameter("P_SMLINCESTADO", DB2Type.SmallInt)
                arrParam(5).Value = pCCOINCIDENCIA_BE.PropINCESTADO
                arrParam(6) = New DB2Parameter("P_DTMAUDFECCREACION", DB2Type.Timestamp)
                arrParam(6).Value = pCCOINCIDENCIA_BE.PropAUDFECCREACION
                arrParam(7) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VarChar, 10)
                arrParam(7).Value = pCCOINCIDENCIA_BE.PropAUDUSUCREACION
                arrParam(8) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VarChar, 150)
                arrParam(8).Value = pCCOINCIDENCIA_BE.PropAUDPRGCREACION
                arrParam(9) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VarChar, 60)
                arrParam(9).Value = pCCOINCIDENCIA_BE.PropAUDEQPCREACION

                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIA_INSERTAR_TELEFONIA", arrParam)
                result = arrParam(0).Value
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return result
        End Function


        Public Function RegistrarAlertaSurcoV3(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE, ByVal pGPSREGISTRO_BE As GPSREGISTRO_BE) As Integer
            Dim result As Integer
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(26) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(0).Direction = ParameterDirection.Output
                arrParam(1) = New DB2Parameter("P_VCHINCCODIGOAPP", DB2Type.VarChar, 25)
                arrParam(1).Value = pCCOINCIDENCIA_BE.PropINCCODIGOAPP

                arrParam(2) = New DB2Parameter("P_SMLORICODIGO", DB2Type.SmallInt)
                arrParam(2).Value = pCCOINCIDENCIA_BE.PropORICODIGO
                arrParam(3) = New DB2Parameter("P_VCHINCNUMEROORIGEN", DB2Type.VarChar, 15)
                arrParam(3).Value = pCCOINCIDENCIA_BE.PropINCNUMEROORIGEN
                arrParam(4) = New DB2Parameter("P_VCHINCIDLLAMADA", DB2Type.VarChar, 15)
                arrParam(4).Value = pCCOINCIDENCIA_BE.PropINCIDLLAMADA
                arrParam(5) = New DB2Parameter("P_VCHINCIDLATITUDE", DB2Type.VarChar, 50)
                arrParam(5).Value = pCCOINCIDENCIA_BE.PropINCIDLATITUDE
                arrParam(6) = New DB2Parameter("P_VCHINCIDLONGITUDE", DB2Type.VarChar, 50)
                arrParam(6).Value = pCCOINCIDENCIA_BE.PropINCIDLONGITUDE
                arrParam(7) = New DB2Parameter("P_VCHINCNOMBRE", DB2Type.VarChar, 100)
                arrParam(7).Value = pCCOINCIDENCIA_BE.PropINCNOMBRE

                arrParam(8) = New DB2Parameter("P_SMLTINCODIGO", DB2Type.SmallInt)
                arrParam(8).Value = pCCOINCIDENCIA_BE.PropTINCODIGO

                arrParam(9) = New DB2Parameter("P_SMLSTICODIGO", DB2Type.SmallInt)
                arrParam(9).Value = pCCOINCIDENCIA_BE.PropSTICODIGO

                arrParam(10) = New DB2Parameter("P_SMLINCESTADO", DB2Type.SmallInt)
                arrParam(10).Value = pCCOINCIDENCIA_BE.PropINCESTADO

                arrParam(11) = New DB2Parameter("P_VCHINCLOCCUADRANTE", DB2Type.VarChar, 5)
                arrParam(11).Value = pCCOINCIDENCIA_BE.PropVCHINCLOCCUADRANTE
                arrParam(12) = New DB2Parameter("P_VCHINCLOCSECTOR", DB2Type.VarChar, 5)
                arrParam(12).Value = pCCOINCIDENCIA_BE.PropVCHINCLOCSECTOR

                arrParam(13) = New DB2Parameter("P_VCHINCLOCVIANOMBRE1", DB2Type.VarChar, 150)
                arrParam(13).Value = pCCOINCIDENCIA_BE.PropINCLOCVIANOMBRE1
                arrParam(14) = New DB2Parameter("P_VCHINCLOCHABNOMBRE", DB2Type.VarChar, 100)
                arrParam(14).Value = pCCOINCIDENCIA_BE.PropINCLOCHABNOMBRE
                arrParam(15) = New DB2Parameter("P_VCHINCLOCXGEO", DB2Type.VarChar, 20)
                arrParam(15).Value = pCCOINCIDENCIA_BE.PropINCLOCXGEO
                arrParam(16) = New DB2Parameter("P_VCHINCLOCYGEO", DB2Type.VarChar, 20)
                arrParam(16).Value = pCCOINCIDENCIA_BE.PropINCLOCYGEO

                arrParam(17) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VarChar, 15)
                arrParam(17).Value = pCCOINCIDENCIA_BE.PropAUDUSUCREACION
                arrParam(18) = New DB2Parameter("P_DTMAUDFECCREACION", DB2Type.Timestamp)
                arrParam(18).Value = pCCOINCIDENCIA_BE.PropAUDFECCREACION
                arrParam(19) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VarChar, 60)
                arrParam(19).Value = pCCOINCIDENCIA_BE.PropAUDPRGCREACION
                arrParam(20) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VarChar, 60)
                arrParam(20).Value = pCCOINCIDENCIA_BE.PropAUDEQPCREACION

                arrParam(21) = New DB2Parameter("P_VCHREGNUMERO", DB2Type.VarChar, 12)
                arrParam(21).Value = pGPSREGISTRO_BE.PropREGNUMERO
                arrParam(22) = New DB2Parameter("P_VCHREGNOMBRE", DB2Type.VarChar, 100)
                arrParam(22).Value = pGPSREGISTRO_BE.PropREGNOMBRE
                arrParam(23) = New DB2Parameter("P_VCHREGDCMNTO", DB2Type.VarChar, 15)
                arrParam(23).Value = pGPSREGISTRO_BE.PropREGDCMNTO
                arrParam(24) = New DB2Parameter("P_VCHREGEMAIL", DB2Type.VarChar, 50)
                arrParam(24).Value = pGPSREGISTRO_BE.PropREGEMAIL
                arrParam(25) = New DB2Parameter("P_SMLREGACTIVO", DB2Type.SmallInt)
                arrParam(25).Value = pGPSREGISTRO_BE.PropREGACTIVO

                arrParam(26) = New DB2Parameter("P_VCHINCARCHIVOURL", DB2Type.VarChar, 150)
                arrParam(26).Value = pCCOINCIDENCIA_BE.PropINCARCHIVOURL


                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIA_INSERTAR_ALERTASURCO_V3", arrParam)
                result = arrParam(0).Value
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return result
        End Function

    End Class
End Namespace
