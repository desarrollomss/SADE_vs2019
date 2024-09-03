Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class CCOTIPOTURNO_DL
		Private cnDB2 As DB2Connection

		#Region "Numerador"
		Public Enum Campos
			TTUCODIGO = 0
			TTUDESCRIPCIÓN = 1
		End Enum
		#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

		Public Sub Insertar(ByVal pCCOTIPOTURNO_BE As CCOTIPOTURNO_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
				arrParam(0) = New DB2Parameter("P_INTTTUCODIGO", DB2Type.INTEGER)
				arrParam(0).Value = pCCOTIPOTURNO_BE.PropTTUCODIGO
				arrParam(1) = New DB2Parameter("P_VCHTTUDESCRIPCIÓN", DB2Type.VARCHAR, 20)
				arrParam(1).Value = pCCOTIPOTURNO_BE.PropTTUDESCRIPCIÓN
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOTIPOTURNO_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pCCOTIPOTURNO_BE As CCOTIPOTURNO_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
                arrParam(0) = New DB2Parameter("P_INTTTUCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOTIPOTURNO_BE.PropTTUCODIGO
                arrParam(1) = New DB2Parameter("P_VCHTTUDESCRIPCIÓN", DB2Type.VARCHAR, 20)
                arrParam(1).Value = pCCOTIPOTURNO_BE.PropTTUDESCRIPCIÓN
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOTIPOTURNO_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOTIPOTURNO_BE As CCOTIPOTURNO_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTTTUCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOTIPOTURNO_BE.PropTTUCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOTIPOTURNO_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOTIPOTURNO_BE As CCOTIPOTURNO_BE) As CCOTIPOTURNO_BE
            Dim oCCOTIPOTURNO_BE As New CCOTIPOTURNO_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTTTUCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOTIPOTURNO_BE.PropTTUCODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOTIPOTURNO_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.TTUCODIGO) Then oCCOTIPOTURNO_BE.PropTTUCODIGO = Nothing Else oCCOTIPOTURNO_BE.PropTTUCODIGO = CType(oDataReader(Campos.TTUCODIGO), Int32)
                    oCCOTIPOTURNO_BE.PropTTUDESCRIPCIÓN = IIf(oDataReader.IsDBNull(Campos.TTUDESCRIPCIÓN), "", oDataReader(Campos.TTUDESCRIPCIÓN))
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oCCOTIPOTURNO_BE
        End Function


	End Class
End Namespace
