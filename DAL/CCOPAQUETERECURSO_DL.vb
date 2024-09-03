Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class CCOPAQUETERECURSO_DL
		Private cnDB2 As DB2Connection

		#Region "Numerador"
		Public Enum Campos
			PQRCODIGO = 0
			PAQCODIGO = 1
			RECCODIGO = 2
		End Enum
		#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

		Public Sub Insertar(ByVal pCCOPAQUETERECURSO_BE As CCOPAQUETERECURSO_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(2) {}
				arrParam(0) = New DB2Parameter("P_INTPQRCODIGO", DB2Type.INTEGER)
				arrParam(0).Value = pCCOPAQUETERECURSO_BE.PropPQRCODIGO
				arrParam(1) = New DB2Parameter("P_INTPAQCODIGO", DB2Type.INTEGER)
				arrParam(1).Value = pCCOPAQUETERECURSO_BE.PropPAQCODIGO
				arrParam(2) = New DB2Parameter("P_INTRECCODIGO", DB2Type.INTEGER)
				arrParam(2).Value = pCCOPAQUETERECURSO_BE.PropRECCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOPAQUETERECURSO_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pCCOPAQUETERECURSO_BE As CCOPAQUETERECURSO_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(2) {}
                arrParam(0) = New DB2Parameter("P_INTPQRCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOPAQUETERECURSO_BE.PropPQRCODIGO
                arrParam(1) = New DB2Parameter("P_INTPAQCODIGO", DB2Type.INTEGER)
                arrParam(1).Value = pCCOPAQUETERECURSO_BE.PropPAQCODIGO
                arrParam(2) = New DB2Parameter("P_INTRECCODIGO", DB2Type.INTEGER)
                arrParam(2).Value = pCCOPAQUETERECURSO_BE.PropRECCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOPAQUETERECURSO_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOPAQUETERECURSO_BE As CCOPAQUETERECURSO_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTPQRCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOPAQUETERECURSO_BE.PropPQRCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOPAQUETERECURSO_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOPAQUETERECURSO_BE As CCOPAQUETERECURSO_BE) As CCOPAQUETERECURSO_BE
            Dim oCCOPAQUETERECURSO_BE As New CCOPAQUETERECURSO_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTPQRCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOPAQUETERECURSO_BE.PropPQRCODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOPAQUETERECURSO_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.PQRCODIGO) Then oCCOPAQUETERECURSO_BE.PropPQRCODIGO = Nothing Else oCCOPAQUETERECURSO_BE.PropPQRCODIGO = CType(oDataReader(Campos.PQRCODIGO), Int32)
                    If oDataReader.IsDBNull(Campos.PAQCODIGO) Then oCCOPAQUETERECURSO_BE.PropPAQCODIGO = Nothing Else oCCOPAQUETERECURSO_BE.PropPAQCODIGO = CType(oDataReader(Campos.PAQCODIGO), Int32)
                    If oDataReader.IsDBNull(Campos.RECCODIGO) Then oCCOPAQUETERECURSO_BE.PropRECCODIGO = Nothing Else oCCOPAQUETERECURSO_BE.PropRECCODIGO = CType(oDataReader(Campos.RECCODIGO), Int32)
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oCCOPAQUETERECURSO_BE
        End Function


	End Class
End Namespace
