Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class CCOINCIDENCIAREPLICA_DL
		Private cnDB2 As DB2Connection

		#Region "Numerador"
		Public Enum Campos
			INRCODIGO = 0
		End Enum
		#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

		Public Sub Insertar(ByVal pCCOINCIDENCIAREPLICA_BE As CCOINCIDENCIAREPLICA_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
				arrParam(0) = New DB2Parameter("P_INTINRCODIGO", DB2Type.INTEGER)
				arrParam(0).Value = pCCOINCIDENCIAREPLICA_BE.PropINRCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIAREPLICA_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pCCOINCIDENCIAREPLICA_BE As CCOINCIDENCIAREPLICA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTINRCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOINCIDENCIAREPLICA_BE.PropINRCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIAREPLICA_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOINCIDENCIAREPLICA_BE As CCOINCIDENCIAREPLICA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTINRCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOINCIDENCIAREPLICA_BE.PropINRCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIAREPLICA_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOINCIDENCIAREPLICA_BE As CCOINCIDENCIAREPLICA_BE) As CCOINCIDENCIAREPLICA_BE
            Dim oCCOINCIDENCIAREPLICA_BE As New CCOINCIDENCIAREPLICA_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTINRCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOINCIDENCIAREPLICA_BE.PropINRCODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIAREPLICA_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.INRCODIGO) Then oCCOINCIDENCIAREPLICA_BE.PropINRCODIGO = Nothing Else oCCOINCIDENCIAREPLICA_BE.PropINRCODIGO = CType(oDataReader(Campos.INRCODIGO), Int32)
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oCCOINCIDENCIAREPLICA_BE
        End Function


	End Class
End Namespace
