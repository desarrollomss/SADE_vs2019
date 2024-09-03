Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class GPSREGISTRO_DL
		Private cnDB2 As DB2Connection

		#Region "Numerador"
		Public Enum Campos
			REGCODIGO = 0
			REGNUMERO = 1
			REGNOMBRE = 2
			REGDCMNTO = 3
			REGEMAIL = 4
			REGACTIVO = 5
			AUDPRGCREACION = 6
			AUDEQPCREACION = 7
			AUDFECCREACION = 8
			AUDPRGMODIF = 9
			AUDEQPMODIF = 10
            AUDFECMODIF = 11
            VERNUMERO = 12
            PROCODIGO = 13
            PRODESCRI = 14
		End Enum
		#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

        'Public Sub Insertar(ByVal pGPSREGISTRO_BE As GPSREGISTRO_BE)
        '	Try
        '		Dim arrParam() As DB2Parameter = New DB2Parameter(11) {}
        '		arrParam(0) = New DB2Parameter("P_INTREGCODIGO", DB2Type.INTEGER)
        '		arrParam(0).Value = pGPSREGISTRO_BE.PropREGCODIGO
        '		arrParam(1) = New DB2Parameter("P_VCHREGNUMERO", DB2Type.VARCHAR, 12)
        '		arrParam(1).Value = pGPSREGISTRO_BE.PropREGNUMERO
        '		arrParam(2) = New DB2Parameter("P_VCHREGNOMBRE", DB2Type.VARCHAR, 100)
        '		arrParam(2).Value = pGPSREGISTRO_BE.PropREGNOMBRE
        '		arrParam(3) = New DB2Parameter("P_VCHREGDCMNTO", DB2Type.VARCHAR, 15)
        '		arrParam(3).Value = pGPSREGISTRO_BE.PropREGDCMNTO
        '		arrParam(4) = New DB2Parameter("P_VCHREGEMAIL", DB2Type.VARCHAR, 50)
        '		arrParam(4).Value = pGPSREGISTRO_BE.PropREGEMAIL
        '		arrParam(5) = New DB2Parameter("P_SMLREGACTIVO", DB2Type.SMALLINT)
        '		arrParam(5).Value = pGPSREGISTRO_BE.PropREGACTIVO
        '		arrParam(6) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VARCHAR, 50)
        '		arrParam(6).Value = pGPSREGISTRO_BE.PropAUDPRGCREACION
        '		arrParam(7) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VARCHAR, 50)
        '		arrParam(7).Value = pGPSREGISTRO_BE.PropAUDEQPCREACION
        '		arrParam(8) = New DB2Parameter("P_TMSAUDFECCREACION", DB2Type.TIMESTAMP)
        '		arrParam(8).Value = pGPSREGISTRO_BE.PropAUDFECCREACION
        '		arrParam(9) = New DB2Parameter("P_VCHAUDPRGMODIF", DB2Type.VARCHAR, 50)
        '		arrParam(9).Value = pGPSREGISTRO_BE.PropAUDPRGMODIF
        '		arrParam(10) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VARCHAR, 50)
        '		arrParam(10).Value = pGPSREGISTRO_BE.PropAUDEQPMODIF
        '		arrParam(11) = New DB2Parameter("P_TMSAUDFECMODIF", DB2Type.TIMESTAMP)
        '		arrParam(11).Value = pGPSREGISTRO_BE.PropAUDFECMODIF
        '              DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "GPSREGISTRO_INSERTAR", arrParam)
        '	Catch ex As Exception
        '		Throw ex
        '	Finally
        '		If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
        '	End Try
        '      End Sub

        Public Sub Actualizar(ByVal pGPSREGISTRO_BE As GPSREGISTRO_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(11) {}
                arrParam(0) = New DB2Parameter("P_INTREGCODIGO", DB2Type.Integer)
                arrParam(0).Value = pGPSREGISTRO_BE.PropREGCODIGO
                arrParam(1) = New DB2Parameter("P_VCHREGNUMERO", DB2Type.VarChar, 12)
                arrParam(1).Value = pGPSREGISTRO_BE.PropREGNUMERO
                arrParam(2) = New DB2Parameter("P_VCHREGNOMBRE", DB2Type.VarChar, 100)
                arrParam(2).Value = pGPSREGISTRO_BE.PropREGNOMBRE
                arrParam(3) = New DB2Parameter("P_VCHREGDCMNTO", DB2Type.VarChar, 15)
                arrParam(3).Value = pGPSREGISTRO_BE.PropREGDCMNTO
                arrParam(4) = New DB2Parameter("P_VCHREGEMAIL", DB2Type.VarChar, 50)
                arrParam(4).Value = pGPSREGISTRO_BE.PropREGEMAIL
                arrParam(5) = New DB2Parameter("P_SMLREGACTIVO", DB2Type.SmallInt)
                arrParam(5).Value = pGPSREGISTRO_BE.PropREGACTIVO
                arrParam(6) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VarChar, 50)
                arrParam(6).Value = pGPSREGISTRO_BE.PropAUDPRGCREACION
                arrParam(7) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VarChar, 50)
                arrParam(7).Value = pGPSREGISTRO_BE.PropAUDEQPCREACION
                arrParam(8) = New DB2Parameter("P_TMSAUDFECCREACION", DB2Type.Timestamp)
                arrParam(8).Value = pGPSREGISTRO_BE.PropAUDFECCREACION
                arrParam(9) = New DB2Parameter("P_VCHAUDPRGMODIF", DB2Type.VarChar, 50)
                arrParam(9).Value = pGPSREGISTRO_BE.PropAUDPRGMODIF
                arrParam(10) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VarChar, 50)
                arrParam(10).Value = pGPSREGISTRO_BE.PropAUDEQPMODIF
                arrParam(11) = New DB2Parameter("P_TMSAUDFECMODIF", DB2Type.Timestamp)
                arrParam(11).Value = pGPSREGISTRO_BE.PropAUDFECMODIF
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "GPSREGISTRO_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

		Public Sub Eliminar(ByVal pGPSREGISTRO_BE As GPSREGISTRO_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
				arrParam(0) = New DB2Parameter("P_INTREGCODIGO", DB2Type.INTEGER)
				arrParam(0).Value = pGPSREGISTRO_BE.PropREGCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "GPSREGISTRO_ELIMINAR", arrParam)
			Catch ex As Exception
				Throw ex
			Finally
				If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
			End Try
		End Sub

		Public Function ListarKey(ByVal pGPSREGISTRO_BE As GPSREGISTRO_BE) As GPSREGISTRO_BE
			Dim oGPSREGISTRO_BE As New GPSREGISTRO_BE
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
				arrParam(0) = New DB2Parameter("P_INTREGCODIGO", DB2Type.INTEGER)
				arrParam(0).Value = pGPSREGISTRO_BE.PropREGCODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "GPSREGISTRO_LISTARKEY", arrParam)
				Do While oDataReader.Read()
					If oDataReader.IsDBNull(Campos.REGCODIGO) Then oGPSREGISTRO_BE.PropREGCODIGO = Nothing Else oGPSREGISTRO_BE.PropREGCODIGO = CType(oDataReader(Campos.REGCODIGO), Int32)
					oGPSREGISTRO_BE.PropREGNUMERO = IIf(oDataReader.IsDBNull(Campos.REGNUMERO), "", oDataReader(Campos.REGNUMERO))
					oGPSREGISTRO_BE.PropREGNOMBRE = IIf(oDataReader.IsDBNull(Campos.REGNOMBRE), "", oDataReader(Campos.REGNOMBRE))
					oGPSREGISTRO_BE.PropREGDCMNTO = IIf(oDataReader.IsDBNull(Campos.REGDCMNTO), "", oDataReader(Campos.REGDCMNTO))
					oGPSREGISTRO_BE.PropREGEMAIL = IIf(oDataReader.IsDBNull(Campos.REGEMAIL), "", oDataReader(Campos.REGEMAIL))
					If oDataReader.IsDBNull(Campos.REGACTIVO) Then oGPSREGISTRO_BE.PropREGACTIVO = Nothing Else oGPSREGISTRO_BE.PropREGACTIVO = CType(oDataReader(Campos.REGACTIVO), Int16)
					oGPSREGISTRO_BE.PropAUDPRGCREACION = IIf(oDataReader.IsDBNull(Campos.AUDPRGCREACION), "", oDataReader(Campos.AUDPRGCREACION))
					oGPSREGISTRO_BE.PropAUDEQPCREACION = IIf(oDataReader.IsDBNull(Campos.AUDEQPCREACION), "", oDataReader(Campos.AUDEQPCREACION))
					If oDataReader.IsDBNull(Campos.AUDFECCREACION) Then oGPSREGISTRO_BE.PropAUDFECCREACION = Nothing Else oGPSREGISTRO_BE.PropAUDFECCREACION = CType(oDataReader(Campos.AUDFECCREACION), DateTime)
					oGPSREGISTRO_BE.PropAUDPRGMODIF = IIf(oDataReader.IsDBNull(Campos.AUDPRGMODIF), "", oDataReader(Campos.AUDPRGMODIF))
					oGPSREGISTRO_BE.PropAUDEQPMODIF = IIf(oDataReader.IsDBNull(Campos.AUDEQPMODIF), "", oDataReader(Campos.AUDEQPMODIF))
					If oDataReader.IsDBNull(Campos.AUDFECMODIF) Then oGPSREGISTRO_BE.PropAUDFECMODIF = Nothing Else oGPSREGISTRO_BE.PropAUDFECMODIF = CType(oDataReader(Campos.AUDFECMODIF), DateTime)
					Exit Do
				Loop
			Catch ex As Exception
				Throw ex
			Finally
				If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
			End Try
			Return oGPSREGISTRO_BE
		End Function

        Public Function Insertar(ByVal pGPSREGISTRO_BE As GPSREGISTRO_BE) As List(Of GPSREGISTRO_BE)
            Dim items As New List(Of GPSREGISTRO_BE)
            Dim obj As New GPSREGISTRO_BE

            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(11) {}
                arrParam(0) = New DB2Parameter("P_INTREGCODIGO", DB2Type.Integer)
                arrParam(0).Value = pGPSREGISTRO_BE.PropREGCODIGO
                arrParam(1) = New DB2Parameter("P_VCHREGNUMERO", DB2Type.VarChar, 12)
                arrParam(1).Value = pGPSREGISTRO_BE.PropREGNUMERO
                arrParam(2) = New DB2Parameter("P_VCHREGNOMBRE", DB2Type.VarChar, 100)
                arrParam(2).Value = pGPSREGISTRO_BE.PropREGNOMBRE
                arrParam(3) = New DB2Parameter("P_VCHREGDCMNTO", DB2Type.VarChar, 15)
                arrParam(3).Value = pGPSREGISTRO_BE.PropREGDCMNTO
                arrParam(4) = New DB2Parameter("P_VCHREGEMAIL", DB2Type.VarChar, 50)
                arrParam(4).Value = pGPSREGISTRO_BE.PropREGEMAIL
                arrParam(5) = New DB2Parameter("P_SMLREGACTIVO", DB2Type.SmallInt)
                arrParam(5).Value = pGPSREGISTRO_BE.PropREGACTIVO
                arrParam(6) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VarChar, 50)
                arrParam(6).Value = pGPSREGISTRO_BE.PropAUDPRGCREACION
                arrParam(7) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VarChar, 50)
                arrParam(7).Value = pGPSREGISTRO_BE.PropAUDEQPCREACION
                arrParam(8) = New DB2Parameter("P_TMSAUDFECCREACION", DB2Type.Timestamp)
                arrParam(8).Value = pGPSREGISTRO_BE.PropAUDFECCREACION
                arrParam(9) = New DB2Parameter("P_VCHAUDPRGMODIF", DB2Type.VarChar, 50)
                arrParam(9).Value = pGPSREGISTRO_BE.PropAUDPRGMODIF
                arrParam(10) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VarChar, 50)
                arrParam(10).Value = pGPSREGISTRO_BE.PropAUDEQPMODIF
                arrParam(11) = New DB2Parameter("P_TMSAUDFECMODIF", DB2Type.Timestamp)
                arrParam(11).Value = pGPSREGISTRO_BE.PropAUDFECMODIF
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "GPSREGISTRO_INSERTAR", arrParam)
                obj.PropPROCODIGO = "0"
                obj.PropPRODESCRI = "Verifique su correo, para activar y completar su registro."
                items.Add(obj)
            Catch ex As Exception
                obj.PropPROCODIGO = Err.Number.ToString
                obj.PropPRODESCRI = " Error al Registrar " + Err.Description.Trim
                items.Add(obj)
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return items
        End Function

        Public Function Listar(ByVal pNUMERO As String) As List(Of GPSREGISTRO_BE)
            Dim items As New List(Of GPSREGISTRO_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_VCHREGNUMERO", DB2Type.VarChar, 12)
                arrParam(0).Value = pNUMERO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "GPSREGISTRO_LISTAR", arrParam)
                Dim bolExiste As Boolean = False
                Do While oDataReader.Read()
                    Dim oGPSREGISTRO_BE As New GPSREGISTRO_BE
                    If oDataReader.IsDBNull(Campos.REGCODIGO) Then oGPSREGISTRO_BE.PropREGCODIGO = Nothing Else oGPSREGISTRO_BE.PropREGCODIGO = CType(oDataReader(Campos.REGCODIGO), Int32)
                    oGPSREGISTRO_BE.PropREGNUMERO = IIf(oDataReader.IsDBNull(Campos.REGNUMERO), "", oDataReader(Campos.REGNUMERO))
                    oGPSREGISTRO_BE.PropREGNOMBRE = IIf(oDataReader.IsDBNull(Campos.REGNOMBRE), "", oDataReader(Campos.REGNOMBRE))
                    oGPSREGISTRO_BE.PropREGDCMNTO = IIf(oDataReader.IsDBNull(Campos.REGDCMNTO), "", oDataReader(Campos.REGDCMNTO))
                    oGPSREGISTRO_BE.PropREGEMAIL = IIf(oDataReader.IsDBNull(Campos.REGEMAIL), "", oDataReader(Campos.REGEMAIL))
                    If oDataReader.IsDBNull(Campos.REGACTIVO) Then oGPSREGISTRO_BE.PropREGACTIVO = Nothing Else oGPSREGISTRO_BE.PropREGACTIVO = CType(oDataReader(Campos.REGACTIVO), Int16)
                    oGPSREGISTRO_BE.PropAUDPRGCREACION = IIf(oDataReader.IsDBNull(Campos.AUDPRGCREACION), "", oDataReader(Campos.AUDPRGCREACION))
                    oGPSREGISTRO_BE.PropAUDEQPCREACION = IIf(oDataReader.IsDBNull(Campos.AUDEQPCREACION), "", oDataReader(Campos.AUDEQPCREACION))
                    If oDataReader.IsDBNull(Campos.AUDFECCREACION) Then oGPSREGISTRO_BE.PropAUDFECCREACION = Nothing Else oGPSREGISTRO_BE.PropAUDFECCREACION = CType(oDataReader(Campos.AUDFECCREACION), DateTime)
                    oGPSREGISTRO_BE.PropAUDPRGMODIF = IIf(oDataReader.IsDBNull(Campos.AUDPRGMODIF), "", oDataReader(Campos.AUDPRGMODIF))
                    oGPSREGISTRO_BE.PropAUDEQPMODIF = IIf(oDataReader.IsDBNull(Campos.AUDEQPMODIF), "", oDataReader(Campos.AUDEQPMODIF))
                    If oDataReader.IsDBNull(Campos.AUDFECMODIF) Then oGPSREGISTRO_BE.PropAUDFECMODIF = Nothing Else oGPSREGISTRO_BE.PropAUDFECMODIF = CType(oDataReader(Campos.AUDFECMODIF), DateTime)
                    items.Add(oGPSREGISTRO_BE)
                    bolExiste = True
                Loop
                If Not bolExiste Then
                    Dim oGPSREGISTRO_BE As New GPSREGISTRO_BE
                    oGPSREGISTRO_BE.PropREGACTIVO = 8   '-- No existe registro
                    oGPSREGISTRO_BE.PropPROCODIGO = "8"
                    oGPSREGISTRO_BE.PropPRODESCRI = "No existe Registro."
                    items.Add(oGPSREGISTRO_BE)
                End If
            Catch ex As Exception
                Dim oGPSREGISTRO_BE As New GPSREGISTRO_BE
                oGPSREGISTRO_BE.PropREGACTIVO = 9   '-- Error de Servicio
                oGPSREGISTRO_BE.PropPROCODIGO = Err.Number.ToString
                oGPSREGISTRO_BE.PropPRODESCRI = " Error al Consultar " + Err.Description.Trim
                items.Add(oGPSREGISTRO_BE)
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return items
        End Function

        Public Function ListarUsuarioApp(ByVal pNUMERO As String, ByVal pVERSION As String) As List(Of GPSREGISTRO_BE)
            Dim items As New List(Of GPSREGISTRO_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
                arrParam(0) = New DB2Parameter("P_VCHREGNUMERO", DB2Type.VarChar, 12)
                arrParam(0).Value = pNUMERO
                arrParam(1) = New DB2Parameter("P_VCHVERNUMERO", DB2Type.VarChar, 12)
                arrParam(1).Value = pVERSION

                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "SADE.GPSREGISTRO_LISTARUSUARIOAPP", arrParam)
                Dim bolExiste As Boolean = False
                Do While oDataReader.Read()
                    Dim oGPSREGISTRO_BE As New GPSREGISTRO_BE
                    If oDataReader.IsDBNull(Campos.REGCODIGO) Then oGPSREGISTRO_BE.PropREGCODIGO = Nothing Else oGPSREGISTRO_BE.PropREGCODIGO = CType(oDataReader(Campos.REGCODIGO), Int32)
                    oGPSREGISTRO_BE.PropREGNUMERO = IIf(oDataReader.IsDBNull(Campos.REGNUMERO), "", oDataReader(Campos.REGNUMERO))
                    oGPSREGISTRO_BE.PropREGNOMBRE = IIf(oDataReader.IsDBNull(Campos.REGNOMBRE), "", oDataReader(Campos.REGNOMBRE))
                    oGPSREGISTRO_BE.PropREGDCMNTO = IIf(oDataReader.IsDBNull(Campos.REGDCMNTO), "", oDataReader(Campos.REGDCMNTO))
                    oGPSREGISTRO_BE.PropREGEMAIL = IIf(oDataReader.IsDBNull(Campos.REGEMAIL), "", oDataReader(Campos.REGEMAIL))
                    If oDataReader.IsDBNull(Campos.REGACTIVO) Then oGPSREGISTRO_BE.PropREGACTIVO = Nothing Else oGPSREGISTRO_BE.PropREGACTIVO = CType(oDataReader(Campos.REGACTIVO), Int16)
                    oGPSREGISTRO_BE.PropAUDPRGCREACION = IIf(oDataReader.IsDBNull(Campos.AUDPRGCREACION), "", oDataReader(Campos.AUDPRGCREACION))
                    oGPSREGISTRO_BE.PropAUDEQPCREACION = IIf(oDataReader.IsDBNull(Campos.AUDEQPCREACION), "", oDataReader(Campos.AUDEQPCREACION))
                    If oDataReader.IsDBNull(Campos.AUDFECCREACION) Then oGPSREGISTRO_BE.PropAUDFECCREACION = Nothing Else oGPSREGISTRO_BE.PropAUDFECCREACION = CType(oDataReader(Campos.AUDFECCREACION), DateTime)
                    oGPSREGISTRO_BE.PropAUDPRGMODIF = IIf(oDataReader.IsDBNull(Campos.AUDPRGMODIF), "", oDataReader(Campos.AUDPRGMODIF))
                    oGPSREGISTRO_BE.PropAUDEQPMODIF = IIf(oDataReader.IsDBNull(Campos.AUDEQPMODIF), "", oDataReader(Campos.AUDEQPMODIF))
                    If oDataReader.IsDBNull(Campos.AUDFECMODIF) Then oGPSREGISTRO_BE.PropAUDFECMODIF = Nothing Else oGPSREGISTRO_BE.PropAUDFECMODIF = CType(oDataReader(Campos.AUDFECMODIF), DateTime)
                    oGPSREGISTRO_BE.PropVERnumero = IIf(oDataReader.IsDBNull(Campos.VERNUMERO), "", oDataReader(Campos.VERNUMERO))
                    oGPSREGISTRO_BE.PropPROCODIGO = IIf(oDataReader.IsDBNull(Campos.PROCODIGO), "", oDataReader(Campos.PROCODIGO))
                    oGPSREGISTRO_BE.PropPRODESCRI = IIf(oDataReader.IsDBNull(Campos.PRODESCRI), "", oDataReader(Campos.PRODESCRI))
                    items.Add(oGPSREGISTRO_BE)
                    bolExiste = True
                Loop
                If Not bolExiste Then
                    Dim oGPSREGISTRO_BE As New GPSREGISTRO_BE
                    oGPSREGISTRO_BE.PropREGACTIVO = 8   '-- No existe registro
                    oGPSREGISTRO_BE.PropPROCODIGO = "8"
                    oGPSREGISTRO_BE.PropPRODESCRI = "No existe Registro."
                    items.Add(oGPSREGISTRO_BE)
                End If
            Catch ex As Exception
                Dim oGPSREGISTRO_BE As New GPSREGISTRO_BE
                oGPSREGISTRO_BE.PropREGACTIVO = 9   '-- Error de Servicio
                oGPSREGISTRO_BE.PropPROCODIGO = Err.Number.ToString
                oGPSREGISTRO_BE.PropPRODESCRI = " Error al Consultar " + Err.Description.Trim
                items.Add(oGPSREGISTRO_BE)
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return items
        End Function



        Public Function Validar(ByVal pNUMERO As String) As String
            Dim result As String = ""
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
                arrParam(0) = New DB2Parameter("P_VCHMENSAJE", DB2Type.VarChar, 100)
                arrParam(0).Direction = ParameterDirection.Output
                arrParam(1) = New DB2Parameter("P_VCHREGNUMERO", DB2Type.VarChar, 12)
                arrParam(1).Value = pNUMERO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "GPSREGISTRO_VALIDAR", arrParam)
                result = arrParam(0).Value
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return result
        End Function

        Public Function Listar(ByVal pGPSREGISTRO_BE As GPSREGISTRO_BE) As DataTable
            Dim odt As New DataTable
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(4) {}
                arrParam(0) = New DB2Parameter("P_VCHREGNUMERO", DB2Type.VarChar, 12)
                arrParam(0).Value = pGPSREGISTRO_BE.PropREGNUMERO
                arrParam(1) = New DB2Parameter("P_VCHREGNOMBRE", DB2Type.VarChar, 100)
                arrParam(1).Value = pGPSREGISTRO_BE.PropREGNOMBRE
                arrParam(2) = New DB2Parameter("P_VCHREGDCMNTO", DB2Type.VarChar, 15)
                arrParam(2).Value = pGPSREGISTRO_BE.PropREGDCMNTO
                arrParam(3) = New DB2Parameter("P_VCHREGEMAIL", DB2Type.VarChar, 50)
                arrParam(3).Value = pGPSREGISTRO_BE.PropREGEMAIL
                arrParam(4) = New DB2Parameter("P_SMLREGACTIVO", DB2Type.SmallInt)
                arrParam(4).Value = pGPSREGISTRO_BE.PropREGACTIVO
                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "GPSREGISTRO_LISTARBUSQUEDA", arrParam)
                    odt.Load(dataReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return odt
        End Function
        Public Function ListarDetalle(ByVal pGPSREGISTRO_BE As GPSREGISTRO_BE) As DataTable
            Dim odt As New DataTable
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
                arrParam(0) = New DB2Parameter("P_DESDE", DB2Type.Date)
                arrParam(0).Value = Date.Parse(pGPSREGISTRO_BE.PropREGNUMERO)
                arrParam(1) = New DB2Parameter("P_HASTA", DB2Type.Date)
                arrParam(1).Value = Date.Parse(pGPSREGISTRO_BE.PropREGNOMBRE)
                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "GPSREGISTRO_DETALLE_LISTAR", arrParam)
                    odt.Load(dataReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return odt
        End Function
        Public Function ListarResumen(ByVal pGPSREGISTRO_BE As GPSREGISTRO_BE) As DataTable
            Dim odt As New DataTable
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
                arrParam(0) = New DB2Parameter("P_DESDE", DB2Type.Date)
                arrParam(0).Value = Date.Parse(pGPSREGISTRO_BE.PropREGNUMERO)
                arrParam(1) = New DB2Parameter("P_HASTA", DB2Type.Date)
                arrParam(1).Value = Date.Parse(pGPSREGISTRO_BE.PropREGNOMBRE)
                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "GPSREGISTRO_RESUMEN_LISTAR", arrParam)
                    odt.Load(dataReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return odt
        End Function

        Public Function InsertarV3(ByVal pGPSREGISTRO_BE As GPSREGISTRO_BE) As List(Of GPSREGISTRO_BE)
            Dim items As New List(Of GPSREGISTRO_BE)
            Dim obj As New GPSREGISTRO_BE

            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(11) {}
                arrParam(0) = New DB2Parameter("P_INTREGCODIGO", DB2Type.Integer)
                arrParam(0).Value = pGPSREGISTRO_BE.PropREGCODIGO
                arrParam(1) = New DB2Parameter("P_VCHREGNUMERO", DB2Type.VarChar, 12)
                arrParam(1).Value = pGPSREGISTRO_BE.PropREGNUMERO
                arrParam(2) = New DB2Parameter("P_VCHREGNOMBRE", DB2Type.VarChar, 100)
                arrParam(2).Value = pGPSREGISTRO_BE.PropREGNOMBRE
                arrParam(3) = New DB2Parameter("P_VCHREGDCMNTO", DB2Type.VarChar, 15)
                arrParam(3).Value = pGPSREGISTRO_BE.PropREGDCMNTO
                arrParam(4) = New DB2Parameter("P_VCHREGEMAIL", DB2Type.VarChar, 50)
                arrParam(4).Value = pGPSREGISTRO_BE.PropREGEMAIL
                arrParam(5) = New DB2Parameter("P_SMLREGACTIVO", DB2Type.SmallInt)
                arrParam(5).Direction = ParameterDirection.Output
                arrParam(5).Value = pGPSREGISTRO_BE.PropREGACTIVO
                arrParam(6) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VarChar, 50)
                arrParam(6).Value = pGPSREGISTRO_BE.PropAUDPRGCREACION
                arrParam(7) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VarChar, 50)
                arrParam(7).Value = pGPSREGISTRO_BE.PropAUDEQPCREACION
                arrParam(8) = New DB2Parameter("P_TMSAUDFECCREACION", DB2Type.Timestamp)
                arrParam(8).Value = pGPSREGISTRO_BE.PropAUDFECCREACION
                arrParam(9) = New DB2Parameter("P_VCHAUDPRGMODIF", DB2Type.VarChar, 50)
                arrParam(9).Value = pGPSREGISTRO_BE.PropAUDPRGMODIF
                arrParam(10) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VarChar, 50)
                arrParam(10).Value = pGPSREGISTRO_BE.PropAUDEQPMODIF
                arrParam(11) = New DB2Parameter("P_TMSAUDFECMODIF", DB2Type.Timestamp)
                arrParam(11).Value = pGPSREGISTRO_BE.PropAUDFECMODIF
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "GPSREGISTRO_INSERTAR_V3", arrParam)
                obj.PropREGACTIVO = arrParam(5).Value
                obj.PropPROCODIGO = "0"
                obj.PropPRODESCRI = "Verifique su correo, para activar y completar su registro."
                items.Add(obj)
            Catch ex As Exception
                obj.PropREGACTIVO = 0
                obj.PropPROCODIGO = Err.Number.ToString
                obj.PropPRODESCRI = " Error al Registrar " + Err.Description.Trim
                items.Add(obj)
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return items
        End Function


        Public Function Registrar(ByVal pGPSREGISTRO_BE As GPSREGISTRO_BE) As List(Of GPSREGISTRO_BE)
            Dim items As New List(Of GPSREGISTRO_BE)
            Dim obj As New GPSREGISTRO_BE

            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(19) {}
                arrParam(0) = New DB2Parameter("P_INTREGCODIGO", DB2Type.Integer)
                arrParam(0).Value = pGPSREGISTRO_BE.PropREGCODIGO
                arrParam(1) = New DB2Parameter("P_VCHREGNUMERO", DB2Type.VarChar, 12)
                arrParam(1).Value = pGPSREGISTRO_BE.PropREGNUMERO
                arrParam(2) = New DB2Parameter("P_VCHREGNOMBRE", DB2Type.VarChar, 100)
                arrParam(2).Value = pGPSREGISTRO_BE.PropREGNOMBRE
                arrParam(3) = New DB2Parameter("P_VCHREGDCMNTO", DB2Type.VarChar, 15)
                arrParam(3).Value = pGPSREGISTRO_BE.PropREGDCMNTO
                arrParam(4) = New DB2Parameter("P_VCHREGEMAIL", DB2Type.VarChar, 50)
                arrParam(4).Value = pGPSREGISTRO_BE.PropREGEMAIL
                arrParam(5) = New DB2Parameter("P_SMLREGACTIVO", DB2Type.SmallInt)
                arrParam(5).Value = pGPSREGISTRO_BE.PropREGACTIVO

                arrParam(6) = New DB2Parameter("P_VCHINCDEVSDK", DB2Type.VarChar, 50)
                arrParam(6).Value = pGPSREGISTRO_BE.PropINCDEVSDK
                arrParam(7) = New DB2Parameter("P_VCHINCDEVMODEL", DB2Type.VarChar, 50)
                arrParam(7).Value = pGPSREGISTRO_BE.PropINCDEVMODEL
                arrParam(8) = New DB2Parameter("P_VCHINCDEVDEVICE", DB2Type.VarChar, 50)
                arrParam(8).Value = pGPSREGISTRO_BE.PropINCDEVDEVICE
                arrParam(9) = New DB2Parameter("P_VCHINCDEVHOST", DB2Type.VarChar, 50)
                arrParam(9).Value = pGPSREGISTRO_BE.PropINCDEVHOST
                arrParam(10) = New DB2Parameter("P_VCHINCDEVID", DB2Type.VarChar, 50)
                arrParam(10).Value = pGPSREGISTRO_BE.PropINCDEVID
                arrParam(11) = New DB2Parameter("P_VCHINCDEVDISPLAY", DB2Type.VarChar, 50)
                arrParam(11).Value = pGPSREGISTRO_BE.PropINCDEVDISPLAY
                arrParam(12) = New DB2Parameter("P_VCHINCDEVMANUFAC", DB2Type.VarChar, 50)
                arrParam(12).Value = pGPSREGISTRO_BE.PropINCDEVMANUFAC
                arrParam(13) = New DB2Parameter("P_VCHINCDEVUSER", DB2Type.VarChar, 50)
                arrParam(13).Value = pGPSREGISTRO_BE.PropINCDEVUSER

                arrParam(14) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VarChar, 50)
                arrParam(14).Value = pGPSREGISTRO_BE.PropAUDPRGCREACION
                arrParam(15) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VarChar, 50)
                arrParam(15).Value = pGPSREGISTRO_BE.PropAUDEQPCREACION
                arrParam(16) = New DB2Parameter("P_TMSAUDFECCREACION", DB2Type.Timestamp)
                arrParam(16).Value = pGPSREGISTRO_BE.PropAUDFECCREACION
                arrParam(17) = New DB2Parameter("P_VCHAUDPRGMODIF", DB2Type.VarChar, 50)
                arrParam(17).Value = pGPSREGISTRO_BE.PropAUDPRGMODIF
                arrParam(18) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VarChar, 50)
                arrParam(18).Value = pGPSREGISTRO_BE.PropAUDEQPMODIF
                arrParam(19) = New DB2Parameter("P_TMSAUDFECMODIF", DB2Type.Timestamp)
                arrParam(19).Value = pGPSREGISTRO_BE.PropAUDFECMODIF

                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "GPSREGISTRO_INSERTAR_V3", arrParam)
                obj.PropPROCODIGO = "0"
                obj.PropPRODESCRI = "Verifique su correo, para activar y completar su registro."
                items.Add(obj)
            Catch ex As Exception
                obj.PropPROCODIGO = Err.Number.ToString
                obj.PropPRODESCRI = " Error al Registrar " + Err.Description.Trim
                items.Add(obj)
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return items
        End Function


	End Class
End Namespace
