Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class CCOTURNO_DL
		Private cnDB2 As DB2Connection

		#Region "Numerador"
		Public Enum Campos
			TURDESCRIPCION = 0
			TURHORARIO = 1
			TURCODIGO = 2
			TURABREVIA = 3
			TTUCODIGO = 4
		End Enum
		#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

		Public Sub Insertar(ByVal pCCOTURNO_BE As CCOTURNO_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(4) {}
				arrParam(0) = New DB2Parameter("P_VCHTURDESCRIPCION", DB2Type.VARCHAR, 10)
				arrParam(0).Value = pCCOTURNO_BE.PropTURDESCRIPCION
				arrParam(1) = New DB2Parameter("P_VCHTURHORARIO", DB2Type.VARCHAR, 20)
				arrParam(1).Value = pCCOTURNO_BE.PropTURHORARIO
				arrParam(2) = New DB2Parameter("P_INTTURCODIGO", DB2Type.INTEGER)
				arrParam(2).Value = pCCOTURNO_BE.PropTURCODIGO
				arrParam(3) = New DB2Parameter("P_VCHTURABREVIA", DB2Type.VARCHAR, 5)
				arrParam(3).Value = pCCOTURNO_BE.PropTURABREVIA
				arrParam(4) = New DB2Parameter("P_INTTTUCODIGO", DB2Type.INTEGER)
				arrParam(4).Value = pCCOTURNO_BE.PropTTUCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOTURNO_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pCCOTURNO_BE As CCOTURNO_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(4) {}
                arrParam(0) = New DB2Parameter("P_VCHTURDESCRIPCION", DB2Type.VARCHAR, 10)
                arrParam(0).Value = pCCOTURNO_BE.PropTURDESCRIPCION
                arrParam(1) = New DB2Parameter("P_VCHTURHORARIO", DB2Type.VARCHAR, 20)
                arrParam(1).Value = pCCOTURNO_BE.PropTURHORARIO
                arrParam(2) = New DB2Parameter("P_INTTURCODIGO", DB2Type.INTEGER)
                arrParam(2).Value = pCCOTURNO_BE.PropTURCODIGO
                arrParam(3) = New DB2Parameter("P_VCHTURABREVIA", DB2Type.VARCHAR, 5)
                arrParam(3).Value = pCCOTURNO_BE.PropTURABREVIA
                arrParam(4) = New DB2Parameter("P_INTTTUCODIGO", DB2Type.INTEGER)
                arrParam(4).Value = pCCOTURNO_BE.PropTTUCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOTURNO_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOTURNO_BE As CCOTURNO_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTTURCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOTURNO_BE.PropTURCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOTURNO_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOTURNO_BE As CCOTURNO_BE) As CCOTURNO_BE
            Dim oCCOTURNO_BE As New CCOTURNO_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTTURCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOTURNO_BE.PropTURCODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOTURNO_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    oCCOTURNO_BE.PropTURDESCRIPCION = IIf(oDataReader.IsDBNull(Campos.TURDESCRIPCION), "", oDataReader(Campos.TURDESCRIPCION))
                    oCCOTURNO_BE.PropTURHORARIO = IIf(oDataReader.IsDBNull(Campos.TURHORARIO), "", oDataReader(Campos.TURHORARIO))
                    If oDataReader.IsDBNull(Campos.TURCODIGO) Then oCCOTURNO_BE.PropTURCODIGO = Nothing Else oCCOTURNO_BE.PropTURCODIGO = CType(oDataReader(Campos.TURCODIGO), Int32)
                    oCCOTURNO_BE.PropTURABREVIA = IIf(oDataReader.IsDBNull(Campos.TURABREVIA), "", oDataReader(Campos.TURABREVIA))
                    If oDataReader.IsDBNull(Campos.TTUCODIGO) Then oCCOTURNO_BE.PropTTUCODIGO = Nothing Else oCCOTURNO_BE.PropTTUCODIGO = CType(oDataReader(Campos.TTUCODIGO), Int32)
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oCCOTURNO_BE
        End Function


	End Class
End Namespace
