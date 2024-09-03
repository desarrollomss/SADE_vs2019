Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class CCOCARGO_DL
		Private cnDB2 As DB2Connection

		#Region "Numerador"
		Public Enum Campos
			CRGCODIGO = 0
			CRGDESCRIPCION = 1
			CRGESTADO = 2
			TTUCODIGO = 3
		End Enum
		#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

		Public Sub Insertar(ByVal pCCOCARGO_BE As CCOCARGO_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(3) {}
				arrParam(0) = New DB2Parameter("P_INTCRGCODIGO", DB2Type.INTEGER)
				arrParam(0).Value = pCCOCARGO_BE.PropCRGCODIGO
				arrParam(1) = New DB2Parameter("P_VCHCRGDESCRIPCION", DB2Type.VARCHAR, 30)
				arrParam(1).Value = pCCOCARGO_BE.PropCRGDESCRIPCION
				arrParam(2) = New DB2Parameter("P_INTCRGESTADO", DB2Type.INTEGER)
				arrParam(2).Value = pCCOCARGO_BE.PropCRGESTADO
				arrParam(3) = New DB2Parameter("P_INTTTUCODIGO", DB2Type.INTEGER)
				arrParam(3).Value = pCCOCARGO_BE.PropTTUCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOCARGO_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pCCOCARGO_BE As CCOCARGO_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(3) {}
                arrParam(0) = New DB2Parameter("P_INTCRGCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOCARGO_BE.PropCRGCODIGO
                arrParam(1) = New DB2Parameter("P_VCHCRGDESCRIPCION", DB2Type.VARCHAR, 30)
                arrParam(1).Value = pCCOCARGO_BE.PropCRGDESCRIPCION
                arrParam(2) = New DB2Parameter("P_INTCRGESTADO", DB2Type.INTEGER)
                arrParam(2).Value = pCCOCARGO_BE.PropCRGESTADO
                arrParam(3) = New DB2Parameter("P_INTTTUCODIGO", DB2Type.INTEGER)
                arrParam(3).Value = pCCOCARGO_BE.PropTTUCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOCARGO_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOCARGO_BE As CCOCARGO_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTCRGCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOCARGO_BE.PropCRGCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOCARGO_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOCARGO_BE As CCOCARGO_BE) As CCOCARGO_BE
            Dim oCCOCARGO_BE As New CCOCARGO_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTCRGCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOCARGO_BE.PropCRGCODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOCARGO_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.CRGCODIGO) Then oCCOCARGO_BE.PropCRGCODIGO = Nothing Else oCCOCARGO_BE.PropCRGCODIGO = CType(oDataReader(Campos.CRGCODIGO), Int32)
                    oCCOCARGO_BE.PropCRGDESCRIPCION = IIf(oDataReader.IsDBNull(Campos.CRGDESCRIPCION), "", oDataReader(Campos.CRGDESCRIPCION))
                    If oDataReader.IsDBNull(Campos.CRGESTADO) Then oCCOCARGO_BE.PropCRGESTADO = Nothing Else oCCOCARGO_BE.PropCRGESTADO = CType(oDataReader(Campos.CRGESTADO), Int32)
                    If oDataReader.IsDBNull(Campos.TTUCODIGO) Then oCCOCARGO_BE.PropTTUCODIGO = Nothing Else oCCOCARGO_BE.PropTTUCODIGO = CType(oDataReader(Campos.TTUCODIGO), Int32)
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oCCOCARGO_BE
        End Function


	End Class
End Namespace
