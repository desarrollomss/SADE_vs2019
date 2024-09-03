Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class CCOCUADRANTESECTOR_DL
		Private cnDB2 As DB2Connection

		#Region "Numerador"
		Public Enum Campos
			CUACODIGO = 0
			SECCODIGO = 1
			CUADESCRIPCION = 2
			COMCODIGO = 3
			CUAESTADO = 4
		End Enum
		#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

		Public Sub Insertar(ByVal pCCOCUADRANTESECTOR_BE As CCOCUADRANTESECTOR_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(4) {}
				arrParam(0) = New DB2Parameter("P_VCHCUACODIGO", DB2Type.INTEGER)
				arrParam(0).Value = pCCOCUADRANTESECTOR_BE.PropCUACODIGO
				arrParam(1) = New DB2Parameter("P_INTSECCODIGO", DB2Type.INTEGER)
				arrParam(1).Value = pCCOCUADRANTESECTOR_BE.PropSECCODIGO
				arrParam(2) = New DB2Parameter("P_VCHCUADESCRIPCION", DB2Type.VARCHAR, 10)
				arrParam(2).Value = pCCOCUADRANTESECTOR_BE.PropCUADESCRIPCION
				arrParam(3) = New DB2Parameter("P_INTCOMCODIGO", DB2Type.INTEGER)
				arrParam(3).Value = pCCOCUADRANTESECTOR_BE.PropCOMCODIGO
				arrParam(4) = New DB2Parameter("P_INTCUAESTADO", DB2Type.INTEGER)
				arrParam(4).Value = pCCOCUADRANTESECTOR_BE.PropCUAESTADO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOCUADRANTESECTOR_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pCCOCUADRANTESECTOR_BE As CCOCUADRANTESECTOR_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(4) {}
                arrParam(0) = New DB2Parameter("P_VCHCUACODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOCUADRANTESECTOR_BE.PropCUACODIGO
                arrParam(1) = New DB2Parameter("P_INTSECCODIGO", DB2Type.INTEGER)
                arrParam(1).Value = pCCOCUADRANTESECTOR_BE.PropSECCODIGO
                arrParam(2) = New DB2Parameter("P_VCHCUADESCRIPCION", DB2Type.VARCHAR, 10)
                arrParam(2).Value = pCCOCUADRANTESECTOR_BE.PropCUADESCRIPCION
                arrParam(3) = New DB2Parameter("P_INTCOMCODIGO", DB2Type.INTEGER)
                arrParam(3).Value = pCCOCUADRANTESECTOR_BE.PropCOMCODIGO
                arrParam(4) = New DB2Parameter("P_INTCUAESTADO", DB2Type.INTEGER)
                arrParam(4).Value = pCCOCUADRANTESECTOR_BE.PropCUAESTADO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOCUADRANTESECTOR_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOCUADRANTESECTOR_BE As CCOCUADRANTESECTOR_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_VCHCUACODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOCUADRANTESECTOR_BE.PropCUACODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOCUADRANTESECTOR_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOCUADRANTESECTOR_BE As CCOCUADRANTESECTOR_BE) As CCOCUADRANTESECTOR_BE
            Dim oCCOCUADRANTESECTOR_BE As New CCOCUADRANTESECTOR_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_VCHCUACODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOCUADRANTESECTOR_BE.PropCUACODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOCUADRANTESECTOR_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.CUACODIGO) Then oCCOCUADRANTESECTOR_BE.PropCUACODIGO = Nothing Else oCCOCUADRANTESECTOR_BE.PropCUACODIGO = CType(oDataReader(Campos.CUACODIGO), Int32)
                    If oDataReader.IsDBNull(Campos.SECCODIGO) Then oCCOCUADRANTESECTOR_BE.PropSECCODIGO = Nothing Else oCCOCUADRANTESECTOR_BE.PropSECCODIGO = CType(oDataReader(Campos.SECCODIGO), Int32)
                    oCCOCUADRANTESECTOR_BE.PropCUADESCRIPCION = IIf(oDataReader.IsDBNull(Campos.CUADESCRIPCION), "", oDataReader(Campos.CUADESCRIPCION))
                    If oDataReader.IsDBNull(Campos.COMCODIGO) Then oCCOCUADRANTESECTOR_BE.PropCOMCODIGO = Nothing Else oCCOCUADRANTESECTOR_BE.PropCOMCODIGO = CType(oDataReader(Campos.COMCODIGO), Int32)
                    If oDataReader.IsDBNull(Campos.CUAESTADO) Then oCCOCUADRANTESECTOR_BE.PropCUAESTADO = Nothing Else oCCOCUADRANTESECTOR_BE.PropCUAESTADO = CType(oDataReader(Campos.CUAESTADO), Int32)
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oCCOCUADRANTESECTOR_BE
        End Function


	End Class
End Namespace
