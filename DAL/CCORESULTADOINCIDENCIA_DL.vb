Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class CCORESULTADOINCIDENCIA_DL
		Private cnDB2 As DB2Connection

		#Region "Numerador"
		Public Enum Campos
			RESCODIGO = 0
			RESDESCRIPCION = 1
		End Enum
		#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

		Public Sub Insertar(ByVal pCCORESULTADOINCIDENCIA_BE As CCORESULTADOINCIDENCIA_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
				arrParam(0) = New DB2Parameter("P_INTRESCODIGO", DB2Type.INTEGER)
				arrParam(0).Value = pCCORESULTADOINCIDENCIA_BE.PropRESCODIGO
				arrParam(1) = New DB2Parameter("P_VCHRESDESCRIPCION", DB2Type.VARCHAR, 20)
				arrParam(1).Value = pCCORESULTADOINCIDENCIA_BE.PropRESDESCRIPCION
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCORESULTADOINCIDENCIA_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pCCORESULTADOINCIDENCIA_BE As CCORESULTADOINCIDENCIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
                arrParam(0) = New DB2Parameter("P_INTRESCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCORESULTADOINCIDENCIA_BE.PropRESCODIGO
                arrParam(1) = New DB2Parameter("P_VCHRESDESCRIPCION", DB2Type.VARCHAR, 20)
                arrParam(1).Value = pCCORESULTADOINCIDENCIA_BE.PropRESDESCRIPCION
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCORESULTADOINCIDENCIA_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCORESULTADOINCIDENCIA_BE As CCORESULTADOINCIDENCIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTRESCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCORESULTADOINCIDENCIA_BE.PropRESCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCORESULTADOINCIDENCIA_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCORESULTADOINCIDENCIA_BE As CCORESULTADOINCIDENCIA_BE) As CCORESULTADOINCIDENCIA_BE
            Dim oCCORESULTADOINCIDENCIA_BE As New CCORESULTADOINCIDENCIA_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTRESCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCORESULTADOINCIDENCIA_BE.PropRESCODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCORESULTADOINCIDENCIA_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.RESCODIGO) Then oCCORESULTADOINCIDENCIA_BE.PropRESCODIGO = Nothing Else oCCORESULTADOINCIDENCIA_BE.PropRESCODIGO = CType(oDataReader(Campos.RESCODIGO), Int32)
                    oCCORESULTADOINCIDENCIA_BE.PropRESDESCRIPCION = IIf(oDataReader.IsDBNull(Campos.RESDESCRIPCION), "", oDataReader(Campos.RESDESCRIPCION))
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oCCORESULTADOINCIDENCIA_BE
        End Function


	End Class
End Namespace
