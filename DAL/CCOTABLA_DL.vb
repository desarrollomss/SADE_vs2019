Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class CCOTABLA_DL
		Private cnDB2 As DB2Connection

		#Region "Numerador"
		Public Enum Campos
			TABCODIGO = 0
			TABCODIGOALTERNO = 1
			TABDESCRIPCION = 2
			TABABREVIADO = 3
			TABESTADO = 4
			TTACODIGO = 5
			AUDPRGCREACION = 6
			AUDPRGMODIF = 7
			AUDEQPCREACION = 8
			AUDEQPMODIF = 9
			AUDFECCREACION = 10
			AUDFECMODIF = 11
			AUDUSUCREACION = 12
			AUDUSUMODIF = 13
			AUDROLCREACION = 14
			AUDROLMODIF = 15
		End Enum
		#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

		Public Sub Insertar(ByVal pCCOTABLA_BE As CCOTABLA_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(15) {}
				arrParam(0) = New DB2Parameter("P_INTTABCODIGO", DB2Type.INTEGER)
				arrParam(0).Value = pCCOTABLA_BE.PropTABCODIGO
				arrParam(1) = New DB2Parameter("P_VCHTABCODIGOALTERNO", DB2Type.VARCHAR, 10)
				arrParam(1).Value = pCCOTABLA_BE.PropTABCODIGOALTERNO
				arrParam(2) = New DB2Parameter("P_VCHTABDESCRIPCION", DB2Type.VARCHAR, 60)
				arrParam(2).Value = pCCOTABLA_BE.PropTABDESCRIPCION
				arrParam(3) = New DB2Parameter("P_VCHTABABREVIADO", DB2Type.VARCHAR, 20)
				arrParam(3).Value = pCCOTABLA_BE.PropTABABREVIADO
				arrParam(4) = New DB2Parameter("P_INTTABESTADO", DB2Type.INTEGER)
				arrParam(4).Value = pCCOTABLA_BE.PropTABESTADO
				arrParam(5) = New DB2Parameter("P_VCHTTACODIGO", DB2Type.VARCHAR, 20)
				arrParam(5).Value = pCCOTABLA_BE.PropTTACODIGO
				arrParam(6) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VARCHAR, 150)
				arrParam(6).Value = pCCOTABLA_BE.PropAUDPRGCREACION
				arrParam(7) = New DB2Parameter("P_VCHAUDPRGMODIF", DB2Type.VARCHAR, 150)
				arrParam(7).Value = pCCOTABLA_BE.PropAUDPRGMODIF
				arrParam(8) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VARCHAR, 60)
				arrParam(8).Value = pCCOTABLA_BE.PropAUDEQPCREACION
				arrParam(9) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VARCHAR, 60)
				arrParam(9).Value = pCCOTABLA_BE.PropAUDEQPMODIF
				arrParam(10) = New DB2Parameter("P_DTMAUDFECCREACION", DB2Type.TIMESTAMP)
				arrParam(10).Value = pCCOTABLA_BE.PropAUDFECCREACION
				arrParam(11) = New DB2Parameter("P_DTMAUDFECMODIF", DB2Type.TIMESTAMP)
				arrParam(11).Value = pCCOTABLA_BE.PropAUDFECMODIF
				arrParam(12) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VARCHAR, 10)
				arrParam(12).Value = pCCOTABLA_BE.PropAUDUSUCREACION
				arrParam(13) = New DB2Parameter("P_VCHAUDUSUMODIF", DB2Type.VARCHAR, 10)
				arrParam(13).Value = pCCOTABLA_BE.PropAUDUSUMODIF
				arrParam(14) = New DB2Parameter("P_INTAUDROLCREACION", DB2Type.INTEGER)
				arrParam(14).Value = pCCOTABLA_BE.PropAUDROLCREACION
				arrParam(15) = New DB2Parameter("P_INTAUDROLMODIF", DB2Type.INTEGER)
				arrParam(15).Value = pCCOTABLA_BE.PropAUDROLMODIF
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOTABLA_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pCCOTABLA_BE As CCOTABLA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(15) {}
                arrParam(0) = New DB2Parameter("P_INTTABCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOTABLA_BE.PropTABCODIGO
                arrParam(1) = New DB2Parameter("P_VCHTABCODIGOALTERNO", DB2Type.VARCHAR, 10)
                arrParam(1).Value = pCCOTABLA_BE.PropTABCODIGOALTERNO
                arrParam(2) = New DB2Parameter("P_VCHTABDESCRIPCION", DB2Type.VARCHAR, 60)
                arrParam(2).Value = pCCOTABLA_BE.PropTABDESCRIPCION
                arrParam(3) = New DB2Parameter("P_VCHTABABREVIADO", DB2Type.VARCHAR, 20)
                arrParam(3).Value = pCCOTABLA_BE.PropTABABREVIADO
                arrParam(4) = New DB2Parameter("P_INTTABESTADO", DB2Type.INTEGER)
                arrParam(4).Value = pCCOTABLA_BE.PropTABESTADO
                arrParam(5) = New DB2Parameter("P_VCHTTACODIGO", DB2Type.VARCHAR, 20)
                arrParam(5).Value = pCCOTABLA_BE.PropTTACODIGO
                arrParam(6) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VARCHAR, 150)
                arrParam(6).Value = pCCOTABLA_BE.PropAUDPRGCREACION
                arrParam(7) = New DB2Parameter("P_VCHAUDPRGMODIF", DB2Type.VARCHAR, 150)
                arrParam(7).Value = pCCOTABLA_BE.PropAUDPRGMODIF
                arrParam(8) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VARCHAR, 60)
                arrParam(8).Value = pCCOTABLA_BE.PropAUDEQPCREACION
                arrParam(9) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VARCHAR, 60)
                arrParam(9).Value = pCCOTABLA_BE.PropAUDEQPMODIF
                arrParam(10) = New DB2Parameter("P_DTMAUDFECCREACION", DB2Type.TIMESTAMP)
                arrParam(10).Value = pCCOTABLA_BE.PropAUDFECCREACION
                arrParam(11) = New DB2Parameter("P_DTMAUDFECMODIF", DB2Type.TIMESTAMP)
                arrParam(11).Value = pCCOTABLA_BE.PropAUDFECMODIF
                arrParam(12) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VARCHAR, 10)
                arrParam(12).Value = pCCOTABLA_BE.PropAUDUSUCREACION
                arrParam(13) = New DB2Parameter("P_VCHAUDUSUMODIF", DB2Type.VARCHAR, 10)
                arrParam(13).Value = pCCOTABLA_BE.PropAUDUSUMODIF
                arrParam(14) = New DB2Parameter("P_INTAUDROLCREACION", DB2Type.INTEGER)
                arrParam(14).Value = pCCOTABLA_BE.PropAUDROLCREACION
                arrParam(15) = New DB2Parameter("P_INTAUDROLMODIF", DB2Type.INTEGER)
                arrParam(15).Value = pCCOTABLA_BE.PropAUDROLMODIF
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOTABLA_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOTABLA_BE As CCOTABLA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTTABCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOTABLA_BE.PropTABCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOTABLA_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOTABLA_BE As CCOTABLA_BE) As CCOTABLA_BE
            Dim oCCOTABLA_BE As New CCOTABLA_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTTABCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOTABLA_BE.PropTABCODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOTABLA_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.TABCODIGO) Then oCCOTABLA_BE.PropTABCODIGO = Nothing Else oCCOTABLA_BE.PropTABCODIGO = CType(oDataReader(Campos.TABCODIGO), Int32)
                    oCCOTABLA_BE.PropTABCODIGOALTERNO = IIf(oDataReader.IsDBNull(Campos.TABCODIGOALTERNO), "", oDataReader(Campos.TABCODIGOALTERNO))
                    oCCOTABLA_BE.PropTABDESCRIPCION = IIf(oDataReader.IsDBNull(Campos.TABDESCRIPCION), "", oDataReader(Campos.TABDESCRIPCION))
                    oCCOTABLA_BE.PropTABABREVIADO = IIf(oDataReader.IsDBNull(Campos.TABABREVIADO), "", oDataReader(Campos.TABABREVIADO))
                    If oDataReader.IsDBNull(Campos.TABESTADO) Then oCCOTABLA_BE.PropTABESTADO = Nothing Else oCCOTABLA_BE.PropTABESTADO = CType(oDataReader(Campos.TABESTADO), Int32)
                    oCCOTABLA_BE.PropTTACODIGO = IIf(oDataReader.IsDBNull(Campos.TTACODIGO), "", oDataReader(Campos.TTACODIGO))
                    oCCOTABLA_BE.PropAUDPRGCREACION = IIf(oDataReader.IsDBNull(Campos.AUDPRGCREACION), "", oDataReader(Campos.AUDPRGCREACION))
                    oCCOTABLA_BE.PropAUDPRGMODIF = IIf(oDataReader.IsDBNull(Campos.AUDPRGMODIF), "", oDataReader(Campos.AUDPRGMODIF))
                    oCCOTABLA_BE.PropAUDEQPCREACION = IIf(oDataReader.IsDBNull(Campos.AUDEQPCREACION), "", oDataReader(Campos.AUDEQPCREACION))
                    oCCOTABLA_BE.PropAUDEQPMODIF = IIf(oDataReader.IsDBNull(Campos.AUDEQPMODIF), "", oDataReader(Campos.AUDEQPMODIF))
                    If oDataReader.IsDBNull(Campos.AUDFECCREACION) Then oCCOTABLA_BE.PropAUDFECCREACION = Nothing Else oCCOTABLA_BE.PropAUDFECCREACION = CType(oDataReader(Campos.AUDFECCREACION), DateTime)
                    If oDataReader.IsDBNull(Campos.AUDFECMODIF) Then oCCOTABLA_BE.PropAUDFECMODIF = Nothing Else oCCOTABLA_BE.PropAUDFECMODIF = CType(oDataReader(Campos.AUDFECMODIF), DateTime)
                    oCCOTABLA_BE.PropAUDUSUCREACION = IIf(oDataReader.IsDBNull(Campos.AUDUSUCREACION), "", oDataReader(Campos.AUDUSUCREACION))
                    oCCOTABLA_BE.PropAUDUSUMODIF = IIf(oDataReader.IsDBNull(Campos.AUDUSUMODIF), "", oDataReader(Campos.AUDUSUMODIF))
                    If oDataReader.IsDBNull(Campos.AUDROLCREACION) Then oCCOTABLA_BE.PropAUDROLCREACION = Nothing Else oCCOTABLA_BE.PropAUDROLCREACION = CType(oDataReader(Campos.AUDROLCREACION), Int32)
                    If oDataReader.IsDBNull(Campos.AUDROLMODIF) Then oCCOTABLA_BE.PropAUDROLMODIF = Nothing Else oCCOTABLA_BE.PropAUDROLMODIF = CType(oDataReader(Campos.AUDROLMODIF), Int32)
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oCCOTABLA_BE
        End Function
        Public Function Listar(ByVal pCCOTABLA_BE As CCOTABLA_BE) As DataTable
            Dim odt As New DataTable
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
                arrParam(0) = New DB2Parameter("P_VCHTTACODIGO", DB2Type.VarChar, 20)
                arrParam(0).Value = pCCOTABLA_BE.PropTTACODIGO

                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOTABLA_LISTAR", arrParam)
                    odt.Load(dataReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return odt
        End Function


	End Class
End Namespace
