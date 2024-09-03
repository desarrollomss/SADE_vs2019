Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class CCOPUESTOFIJO_DL
		Private cnDB2 As DB2Connection

		#Region "Numerador"
		Public Enum Campos
			PFICODIGO = 0
			PFIUBICACION = 1
			SECCODIGO = 2
		End Enum
		#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

		Public Sub Insertar(ByVal pCCOPUESTOFIJO_BE As CCOPUESTOFIJO_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(2) {}
				arrParam(0) = New DB2Parameter("P_INTPFICODIGO", DB2Type.INTEGER)
				arrParam(0).Value = pCCOPUESTOFIJO_BE.PropPFICODIGO
				arrParam(1) = New DB2Parameter("P_VCHPFIUBICACION", DB2Type.VARCHAR, 250)
				arrParam(1).Value = pCCOPUESTOFIJO_BE.PropPFIUBICACION
				arrParam(2) = New DB2Parameter("P_INTSECCODIGO", DB2Type.INTEGER)
				arrParam(2).Value = pCCOPUESTOFIJO_BE.PropSECCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOPUESTOFIJO_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pCCOPUESTOFIJO_BE As CCOPUESTOFIJO_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(2) {}
                arrParam(0) = New DB2Parameter("P_INTPFICODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOPUESTOFIJO_BE.PropPFICODIGO
                arrParam(1) = New DB2Parameter("P_VCHPFIUBICACION", DB2Type.VARCHAR, 250)
                arrParam(1).Value = pCCOPUESTOFIJO_BE.PropPFIUBICACION
                arrParam(2) = New DB2Parameter("P_INTSECCODIGO", DB2Type.INTEGER)
                arrParam(2).Value = pCCOPUESTOFIJO_BE.PropSECCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOPUESTOFIJO_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOPUESTOFIJO_BE As CCOPUESTOFIJO_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTPFICODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOPUESTOFIJO_BE.PropPFICODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOPUESTOFIJO_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOPUESTOFIJO_BE As CCOPUESTOFIJO_BE) As CCOPUESTOFIJO_BE
            Dim oCCOPUESTOFIJO_BE As New CCOPUESTOFIJO_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTPFICODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOPUESTOFIJO_BE.PropPFICODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOPUESTOFIJO_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.PFICODIGO) Then oCCOPUESTOFIJO_BE.PropPFICODIGO = Nothing Else oCCOPUESTOFIJO_BE.PropPFICODIGO = CType(oDataReader(Campos.PFICODIGO), Int32)
                    oCCOPUESTOFIJO_BE.PropPFIUBICACION = IIf(oDataReader.IsDBNull(Campos.PFIUBICACION), "", oDataReader(Campos.PFIUBICACION))
                    If oDataReader.IsDBNull(Campos.SECCODIGO) Then oCCOPUESTOFIJO_BE.PropSECCODIGO = Nothing Else oCCOPUESTOFIJO_BE.PropSECCODIGO = CType(oDataReader(Campos.SECCODIGO), Int32)
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oCCOPUESTOFIJO_BE
        End Function


	End Class
End Namespace
