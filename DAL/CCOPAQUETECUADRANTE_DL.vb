Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class CCOPAQUETECUADRANTE_DL
		Private cnDB2 As DB2Connection

		#Region "Numerador"
		Public Enum Campos
			PQCCODIGO = 0
			PAQCODIGO = 1
			SECCODIGO = 2
			CUACODIGO = 3
			PFICODIGO = 4
		End Enum
		#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

		Public Sub Insertar(ByVal pCCOPAQUETECUADRANTE_BE As CCOPAQUETECUADRANTE_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(4) {}
				arrParam(0) = New DB2Parameter("P_INTPQCCODIGO", DB2Type.INTEGER)
				arrParam(0).Value = pCCOPAQUETECUADRANTE_BE.PropPQCCODIGO
				arrParam(1) = New DB2Parameter("P_INTPAQCODIGO", DB2Type.INTEGER)
				arrParam(1).Value = pCCOPAQUETECUADRANTE_BE.PropPAQCODIGO
				arrParam(2) = New DB2Parameter("P_SMLSECCODIGO", DB2Type.INTEGER)
				arrParam(2).Value = pCCOPAQUETECUADRANTE_BE.PropSECCODIGO
				arrParam(3) = New DB2Parameter("P_SMLCUACODIGO", DB2Type.INTEGER)
				arrParam(3).Value = pCCOPAQUETECUADRANTE_BE.PropCUACODIGO
				arrParam(4) = New DB2Parameter("P_SMLPFICODIGO", DB2Type.SMALLINT)
				arrParam(4).Value = pCCOPAQUETECUADRANTE_BE.PropPFICODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOPAQUETECUADRANTE_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pCCOPAQUETECUADRANTE_BE As CCOPAQUETECUADRANTE_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(4) {}
                arrParam(0) = New DB2Parameter("P_INTPQCCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOPAQUETECUADRANTE_BE.PropPQCCODIGO
                arrParam(1) = New DB2Parameter("P_INTPAQCODIGO", DB2Type.INTEGER)
                arrParam(1).Value = pCCOPAQUETECUADRANTE_BE.PropPAQCODIGO
                arrParam(2) = New DB2Parameter("P_SMLSECCODIGO", DB2Type.INTEGER)
                arrParam(2).Value = pCCOPAQUETECUADRANTE_BE.PropSECCODIGO
                arrParam(3) = New DB2Parameter("P_SMLCUACODIGO", DB2Type.INTEGER)
                arrParam(3).Value = pCCOPAQUETECUADRANTE_BE.PropCUACODIGO
                arrParam(4) = New DB2Parameter("P_SMLPFICODIGO", DB2Type.SMALLINT)
                arrParam(4).Value = pCCOPAQUETECUADRANTE_BE.PropPFICODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOPAQUETECUADRANTE_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOPAQUETECUADRANTE_BE As CCOPAQUETECUADRANTE_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTPQCCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOPAQUETECUADRANTE_BE.PropPQCCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOPAQUETECUADRANTE_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOPAQUETECUADRANTE_BE As CCOPAQUETECUADRANTE_BE) As CCOPAQUETECUADRANTE_BE
            Dim oCCOPAQUETECUADRANTE_BE As New CCOPAQUETECUADRANTE_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTPQCCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOPAQUETECUADRANTE_BE.PropPQCCODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOPAQUETECUADRANTE_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.PQCCODIGO) Then oCCOPAQUETECUADRANTE_BE.PropPQCCODIGO = Nothing Else oCCOPAQUETECUADRANTE_BE.PropPQCCODIGO = CType(oDataReader(Campos.PQCCODIGO), Int32)
                    If oDataReader.IsDBNull(Campos.PAQCODIGO) Then oCCOPAQUETECUADRANTE_BE.PropPAQCODIGO = Nothing Else oCCOPAQUETECUADRANTE_BE.PropPAQCODIGO = CType(oDataReader(Campos.PAQCODIGO), Int32)
                    If oDataReader.IsDBNull(Campos.SECCODIGO) Then oCCOPAQUETECUADRANTE_BE.PropSECCODIGO = Nothing Else oCCOPAQUETECUADRANTE_BE.PropSECCODIGO = CType(oDataReader(Campos.SECCODIGO), Int32)
                    If oDataReader.IsDBNull(Campos.CUACODIGO) Then oCCOPAQUETECUADRANTE_BE.PropCUACODIGO = Nothing Else oCCOPAQUETECUADRANTE_BE.PropCUACODIGO = CType(oDataReader(Campos.CUACODIGO), Int32)
                    If oDataReader.IsDBNull(Campos.PFICODIGO) Then oCCOPAQUETECUADRANTE_BE.PropPFICODIGO = Nothing Else oCCOPAQUETECUADRANTE_BE.PropPFICODIGO = CType(oDataReader(Campos.PFICODIGO), Int16)
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oCCOPAQUETECUADRANTE_BE
        End Function


	End Class
End Namespace
