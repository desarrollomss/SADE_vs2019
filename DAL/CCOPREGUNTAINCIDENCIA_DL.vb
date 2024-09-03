Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class CCOPREGUNTAINCIDENCIA_DL
		Private cnDB2 As DB2Connection

		#Region "Numerador"
		Public Enum Campos
			PRGCODIGO = 0
			PRGDESCRIPCION = 1
			PRGESTADO = 2
			TRECODIGO = 3
			STICODIGO = 4
		End Enum
		#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

		Public Sub Insertar(ByVal pCCOPREGUNTAINCIDENCIA_BE As CCOPREGUNTAINCIDENCIA_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(4) {}
				arrParam(0) = New DB2Parameter("P_SMLPRGCODIGO", DB2Type.SMALLINT)
				arrParam(0).Value = pCCOPREGUNTAINCIDENCIA_BE.PropPRGCODIGO
				arrParam(1) = New DB2Parameter("P_VCHPRGDESCRIPCION", DB2Type.VARCHAR, 60)
				arrParam(1).Value = pCCOPREGUNTAINCIDENCIA_BE.PropPRGDESCRIPCION
				arrParam(2) = New DB2Parameter("P_SMLPRGESTADO", DB2Type.SMALLINT)
				arrParam(2).Value = pCCOPREGUNTAINCIDENCIA_BE.PropPRGESTADO
				arrParam(3) = New DB2Parameter("P_SMLTRECODIGO", DB2Type.SMALLINT)
				arrParam(3).Value = pCCOPREGUNTAINCIDENCIA_BE.PropTRECODIGO
				arrParam(4) = New DB2Parameter("P_SMLSTICODIGO", DB2Type.SMALLINT)
				arrParam(4).Value = pCCOPREGUNTAINCIDENCIA_BE.PropSTICODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOPREGUNTAINCIDENCIA_INSERTAR", arrParam)
			Catch ex As Exception
				Throw ex
			Finally
				If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCOPREGUNTAINCIDENCIA_BE As CCOPREGUNTAINCIDENCIA_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(4) {}
				arrParam(0) = New DB2Parameter("P_SMLPRGCODIGO", DB2Type.SMALLINT)
				arrParam(0).Value = pCCOPREGUNTAINCIDENCIA_BE.PropPRGCODIGO
				arrParam(1) = New DB2Parameter("P_VCHPRGDESCRIPCION", DB2Type.VARCHAR, 60)
				arrParam(1).Value = pCCOPREGUNTAINCIDENCIA_BE.PropPRGDESCRIPCION
				arrParam(2) = New DB2Parameter("P_SMLPRGESTADO", DB2Type.SMALLINT)
				arrParam(2).Value = pCCOPREGUNTAINCIDENCIA_BE.PropPRGESTADO
				arrParam(3) = New DB2Parameter("P_SMLTRECODIGO", DB2Type.SMALLINT)
				arrParam(3).Value = pCCOPREGUNTAINCIDENCIA_BE.PropTRECODIGO
				arrParam(4) = New DB2Parameter("P_SMLSTICODIGO", DB2Type.SMALLINT)
				arrParam(4).Value = pCCOPREGUNTAINCIDENCIA_BE.PropSTICODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOPREGUNTAINCIDENCIA_ACTUALIZAR", arrParam)
			Catch ex As Exception
				Throw ex
			Finally
				If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCOPREGUNTAINCIDENCIA_BE As CCOPREGUNTAINCIDENCIA_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
				arrParam(0) = New DB2Parameter("P_SMLPRGCODIGO", DB2Type.SMALLINT)
				arrParam(0).Value = pCCOPREGUNTAINCIDENCIA_BE.PropPRGCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOPREGUNTAINCIDENCIA_ELIMINAR", arrParam)
			Catch ex As Exception
				Throw ex
			Finally
				If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
			End Try
		End Sub

		Public Function ListarKey(ByVal pCCOPREGUNTAINCIDENCIA_BE As CCOPREGUNTAINCIDENCIA_BE) As CCOPREGUNTAINCIDENCIA_BE
			Dim oCCOPREGUNTAINCIDENCIA_BE As New CCOPREGUNTAINCIDENCIA_BE
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
				arrParam(0) = New DB2Parameter("P_SMLPRGCODIGO", DB2Type.SMALLINT)
				arrParam(0).Value = pCCOPREGUNTAINCIDENCIA_BE.PropPRGCODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOPREGUNTAINCIDENCIA_LISTARKEY", arrParam)
				Do While oDataReader.Read()
					If oDataReader.IsDBNull(Campos.PRGCODIGO) Then oCCOPREGUNTAINCIDENCIA_BE.PropPRGCODIGO = Nothing Else oCCOPREGUNTAINCIDENCIA_BE.PropPRGCODIGO = CType(oDataReader(Campos.PRGCODIGO), Int16)
					oCCOPREGUNTAINCIDENCIA_BE.PropPRGDESCRIPCION = IIf(oDataReader.IsDBNull(Campos.PRGDESCRIPCION), "", oDataReader(Campos.PRGDESCRIPCION))
					If oDataReader.IsDBNull(Campos.PRGESTADO) Then oCCOPREGUNTAINCIDENCIA_BE.PropPRGESTADO = Nothing Else oCCOPREGUNTAINCIDENCIA_BE.PropPRGESTADO = CType(oDataReader(Campos.PRGESTADO), Int16)
					If oDataReader.IsDBNull(Campos.TRECODIGO) Then oCCOPREGUNTAINCIDENCIA_BE.PropTRECODIGO = Nothing Else oCCOPREGUNTAINCIDENCIA_BE.PropTRECODIGO = CType(oDataReader(Campos.TRECODIGO), Int16)
					If oDataReader.IsDBNull(Campos.STICODIGO) Then oCCOPREGUNTAINCIDENCIA_BE.PropSTICODIGO = Nothing Else oCCOPREGUNTAINCIDENCIA_BE.PropSTICODIGO = CType(oDataReader(Campos.STICODIGO), Int16)
					Exit Do
				Loop
			Catch ex As Exception
				Throw ex
			Finally
				If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
			End Try
			Return oCCOPREGUNTAINCIDENCIA_BE
		End Function

        Public Function ListarGrilla(ByVal pCCOPREGUNTAINCIDENCIA_BE As CCOPREGUNTAINCIDENCIA_BE, ByVal pINTINCCODIGO As Integer) As DataTable
            Dim dt As New DataTable
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
                arrParam(0) = New DB2Parameter("P_SMLSTICODIGO", DB2Type.SmallInt)
                arrParam(0).Value = pCCOPREGUNTAINCIDENCIA_BE.PropSTICODIGO
                arrParam(1) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(1).Value = pINTINCCODIGO

                dt.Load(DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOPREGUNTAINCIDENCIA_LISTARGRILLA", arrParam))
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return dt
        End Function


	End Class
End Namespace
