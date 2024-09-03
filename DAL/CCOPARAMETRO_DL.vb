Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class CCOPARAMETRO_DL
		Private cnDB2 As DB2Connection

		#Region "Numerador"
		Public Enum Campos
			PARCODIGO = 0
			PARDESCRIPCION = 1
			PARRELACION = 2
            PARRELACIONC = 3
		End Enum
		#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

		Public Sub Insertar(ByVal pCCOPARAMETRO_BE As CCOPARAMETRO_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(3) {}
				arrParam(0) = New DB2Parameter("P_VCHPARCODIGO", DB2Type.VARCHAR, 20)
				arrParam(0).Value = pCCOPARAMETRO_BE.PropPARCODIGO
				arrParam(1) = New DB2Parameter("P_VCHPARDESCRIPCION", DB2Type.VARCHAR, 60)
				arrParam(1).Value = pCCOPARAMETRO_BE.PropPARDESCRIPCION
				arrParam(2) = New DB2Parameter("P_INTPARRELACION", DB2Type.INTEGER)
				arrParam(2).Value = pCCOPARAMETRO_BE.PropPARRELACION
				arrParam(3) = New DB2Parameter("P_VCHPARRELACION", DB2Type.VARCHAR, 10)
                arrParam(3).Value = pCCOPARAMETRO_BE.PropPARRELACIONC
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOPARAMETRO_INSERTAR", arrParam)
			Catch ex As Exception
				Throw ex
			Finally
				If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCOPARAMETRO_BE As CCOPARAMETRO_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(3) {}
				arrParam(0) = New DB2Parameter("P_VCHPARCODIGO", DB2Type.VARCHAR, 20)
				arrParam(0).Value = pCCOPARAMETRO_BE.PropPARCODIGO
				arrParam(1) = New DB2Parameter("P_VCHPARDESCRIPCION", DB2Type.VARCHAR, 60)
				arrParam(1).Value = pCCOPARAMETRO_BE.PropPARDESCRIPCION
				arrParam(2) = New DB2Parameter("P_INTPARRELACION", DB2Type.INTEGER)
				arrParam(2).Value = pCCOPARAMETRO_BE.PropPARRELACION
				arrParam(3) = New DB2Parameter("P_VCHPARRELACION", DB2Type.VARCHAR, 10)
                arrParam(3).Value = pCCOPARAMETRO_BE.PropPARRELACIONC
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOPARAMETRO_ACTUALIZAR", arrParam)
			Catch ex As Exception
				Throw ex
			Finally
				If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCOPARAMETRO_BE As CCOPARAMETRO_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
				arrParam(0) = New DB2Parameter("P_VCHPARCODIGO", DB2Type.VARCHAR, 20)
				arrParam(0).Value = pCCOPARAMETRO_BE.PropPARCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOPARAMETRO_ELIMINAR", arrParam)
			Catch ex As Exception
				Throw ex
			Finally
				If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
			End Try
		End Sub

		Public Function ListarKey(ByVal pCCOPARAMETRO_BE As CCOPARAMETRO_BE) As CCOPARAMETRO_BE
			Dim oCCOPARAMETRO_BE As New CCOPARAMETRO_BE
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
				arrParam(0) = New DB2Parameter("P_VCHPARCODIGO", DB2Type.VARCHAR, 20)
				arrParam(0).Value = pCCOPARAMETRO_BE.PropPARCODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOPARAMETRO_LISTARKEY", arrParam)
				Do While oDataReader.Read()
					oCCOPARAMETRO_BE.PropPARCODIGO = IIf(oDataReader.IsDBNull(Campos.PARCODIGO), "", oDataReader(Campos.PARCODIGO))
					oCCOPARAMETRO_BE.PropPARDESCRIPCION = IIf(oDataReader.IsDBNull(Campos.PARDESCRIPCION), "", oDataReader(Campos.PARDESCRIPCION))
					If oDataReader.IsDBNull(Campos.PARRELACION) Then oCCOPARAMETRO_BE.PropPARRELACION = Nothing Else oCCOPARAMETRO_BE.PropPARRELACION = CType(oDataReader(Campos.PARRELACION), Int32)
                    oCCOPARAMETRO_BE.PropPARRELACIONC = IIf(oDataReader.IsDBNull(Campos.PARRELACIONC), "", oDataReader(Campos.PARRELACIONC))
					Exit Do
				Loop
			Catch ex As Exception
				Throw ex
			Finally
				If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
			End Try
			Return oCCOPARAMETRO_BE
		End Function


	End Class
End Namespace
