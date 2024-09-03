Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class CCOTIPOPAQUETERECURSO_DL
		Private cnDB2 As DB2Connection

		#Region "Numerador"
		Public Enum Campos
			PAQCODIGO = 0
			TRECODIGO = 1
			TPROBLIGATORIO = 2
		End Enum
		#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

		Public Sub Insertar(ByVal pCCOTIPOPAQUETERECURSO_BE As CCOTIPOPAQUETERECURSO_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(2) {}
				arrParam(0) = New DB2Parameter("P_INTPAQCODIGO", DB2Type.INTEGER)
				arrParam(0).Value = pCCOTIPOPAQUETERECURSO_BE.PropPAQCODIGO
				arrParam(1) = New DB2Parameter("P_INTTRECODIGO", DB2Type.INTEGER)
				arrParam(1).Value = pCCOTIPOPAQUETERECURSO_BE.PropTRECODIGO
				arrParam(2) = New DB2Parameter("P_INTTPROBLIGATORIO", DB2Type.INTEGER)
				arrParam(2).Value = pCCOTIPOPAQUETERECURSO_BE.PropTPROBLIGATORIO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOTIPOPAQUETERECURSO_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pCCOTIPOPAQUETERECURSO_BE As CCOTIPOPAQUETERECURSO_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(2) {}
                arrParam(0) = New DB2Parameter("P_INTPAQCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOTIPOPAQUETERECURSO_BE.PropPAQCODIGO
                arrParam(1) = New DB2Parameter("P_INTTRECODIGO", DB2Type.INTEGER)
                arrParam(1).Value = pCCOTIPOPAQUETERECURSO_BE.PropTRECODIGO
                arrParam(2) = New DB2Parameter("P_INTTPROBLIGATORIO", DB2Type.INTEGER)
                arrParam(2).Value = pCCOTIPOPAQUETERECURSO_BE.PropTPROBLIGATORIO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOTIPOPAQUETERECURSO_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOTIPOPAQUETERECURSO_BE As CCOTIPOPAQUETERECURSO_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
                arrParam(0) = New DB2Parameter("P_INTPAQCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOTIPOPAQUETERECURSO_BE.PropPAQCODIGO
                arrParam(1) = New DB2Parameter("P_INTTRECODIGO", DB2Type.INTEGER)
                arrParam(1).Value = pCCOTIPOPAQUETERECURSO_BE.PropTRECODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOTIPOPAQUETERECURSO_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOTIPOPAQUETERECURSO_BE As CCOTIPOPAQUETERECURSO_BE) As CCOTIPOPAQUETERECURSO_BE
            Dim oCCOTIPOPAQUETERECURSO_BE As New CCOTIPOPAQUETERECURSO_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
                arrParam(0) = New DB2Parameter("P_INTPAQCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOTIPOPAQUETERECURSO_BE.PropPAQCODIGO
                arrParam(1) = New DB2Parameter("P_INTTRECODIGO", DB2Type.INTEGER)
                arrParam(1).Value = pCCOTIPOPAQUETERECURSO_BE.PropTRECODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOTIPOPAQUETERECURSO_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.PAQCODIGO) Then oCCOTIPOPAQUETERECURSO_BE.PropPAQCODIGO = Nothing Else oCCOTIPOPAQUETERECURSO_BE.PropPAQCODIGO = CType(oDataReader(Campos.PAQCODIGO), Int32)
                    If oDataReader.IsDBNull(Campos.TRECODIGO) Then oCCOTIPOPAQUETERECURSO_BE.PropTRECODIGO = Nothing Else oCCOTIPOPAQUETERECURSO_BE.PropTRECODIGO = CType(oDataReader(Campos.TRECODIGO), Int32)
                    If oDataReader.IsDBNull(Campos.TPROBLIGATORIO) Then oCCOTIPOPAQUETERECURSO_BE.PropTPROBLIGATORIO = Nothing Else oCCOTIPOPAQUETERECURSO_BE.PropTPROBLIGATORIO = CType(oDataReader(Campos.TPROBLIGATORIO), Int32)
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oCCOTIPOPAQUETERECURSO_BE
        End Function


	End Class
End Namespace
