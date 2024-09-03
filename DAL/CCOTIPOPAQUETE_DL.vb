Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class CCOTIPOPAQUETE_DL
		Private cnDB2 As DB2Connection

		#Region "Numerador"
		Public Enum Campos
			PAQCODIGO = 0
			PAQDESCRIPCION = 1
			PAQESTADO = 2
		End Enum
		#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

		Public Sub Insertar(ByVal pCCOTIPOPAQUETE_BE As CCOTIPOPAQUETE_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(2) {}
				arrParam(0) = New DB2Parameter("P_INTPAQCODIGO", DB2Type.INTEGER)
				arrParam(0).Value = pCCOTIPOPAQUETE_BE.PropPAQCODIGO
				arrParam(1) = New DB2Parameter("P_VCTPAQDESCRIPCION", DB2Type.VARCHAR, 30)
				arrParam(1).Value = pCCOTIPOPAQUETE_BE.PropPAQDESCRIPCION
				arrParam(2) = New DB2Parameter("P_INTPAQESTADO", DB2Type.CHAR, 18)
				arrParam(2).Value = pCCOTIPOPAQUETE_BE.PropPAQESTADO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOTIPOPAQUETE_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pCCOTIPOPAQUETE_BE As CCOTIPOPAQUETE_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(2) {}
                arrParam(0) = New DB2Parameter("P_INTPAQCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOTIPOPAQUETE_BE.PropPAQCODIGO
                arrParam(1) = New DB2Parameter("P_VCTPAQDESCRIPCION", DB2Type.VARCHAR, 30)
                arrParam(1).Value = pCCOTIPOPAQUETE_BE.PropPAQDESCRIPCION
                arrParam(2) = New DB2Parameter("P_INTPAQESTADO", DB2Type.CHAR, 18)
                arrParam(2).Value = pCCOTIPOPAQUETE_BE.PropPAQESTADO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOTIPOPAQUETE_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOTIPOPAQUETE_BE As CCOTIPOPAQUETE_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTPAQCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOTIPOPAQUETE_BE.PropPAQCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOTIPOPAQUETE_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOTIPOPAQUETE_BE As CCOTIPOPAQUETE_BE) As CCOTIPOPAQUETE_BE
            Dim oCCOTIPOPAQUETE_BE As New CCOTIPOPAQUETE_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTPAQCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOTIPOPAQUETE_BE.PropPAQCODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOTIPOPAQUETE_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.PAQCODIGO) Then oCCOTIPOPAQUETE_BE.PropPAQCODIGO = Nothing Else oCCOTIPOPAQUETE_BE.PropPAQCODIGO = CType(oDataReader(Campos.PAQCODIGO), Int32)
                    oCCOTIPOPAQUETE_BE.PropPAQDESCRIPCION = IIf(oDataReader.IsDBNull(Campos.PAQDESCRIPCION), "", oDataReader(Campos.PAQDESCRIPCION))
                    oCCOTIPOPAQUETE_BE.PropPAQESTADO = IIf(oDataReader.IsDBNull(Campos.PAQESTADO), "", oDataReader(Campos.PAQESTADO))
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oCCOTIPOPAQUETE_BE
        End Function


	End Class
End Namespace
