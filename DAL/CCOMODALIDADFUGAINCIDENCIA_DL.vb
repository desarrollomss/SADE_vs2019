Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class CCOMODALIDADFUGAINCIDENCIA_DL
		Private cnDB2 As DB2Connection

		#Region "Numerador"
		Public Enum Campos
			MODCODIGO = 0
			MODDESCRIPCION = 1
		End Enum
		#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

		Public Sub Insertar(ByVal pCCOMODALIDADFUGAINCIDENCIA_BE As CCOMODALIDADFUGAINCIDENCIA_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
				arrParam(0) = New DB2Parameter("P_INTMODCODIGO", DB2Type.INTEGER)
				arrParam(0).Value = pCCOMODALIDADFUGAINCIDENCIA_BE.PropMODCODIGO
				arrParam(1) = New DB2Parameter("P_VCHMODDESCRIPCION", DB2Type.VARCHAR, 30)
				arrParam(1).Value = pCCOMODALIDADFUGAINCIDENCIA_BE.PropMODDESCRIPCION
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOMODALIDADFUGAINCIDENCIA_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pCCOMODALIDADFUGAINCIDENCIA_BE As CCOMODALIDADFUGAINCIDENCIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
                arrParam(0) = New DB2Parameter("P_INTMODCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOMODALIDADFUGAINCIDENCIA_BE.PropMODCODIGO
                arrParam(1) = New DB2Parameter("P_VCHMODDESCRIPCION", DB2Type.VARCHAR, 30)
                arrParam(1).Value = pCCOMODALIDADFUGAINCIDENCIA_BE.PropMODDESCRIPCION
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOMODALIDADFUGAINCIDENCIA_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOMODALIDADFUGAINCIDENCIA_BE As CCOMODALIDADFUGAINCIDENCIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTMODCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOMODALIDADFUGAINCIDENCIA_BE.PropMODCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOMODALIDADFUGAINCIDENCIA_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOMODALIDADFUGAINCIDENCIA_BE As CCOMODALIDADFUGAINCIDENCIA_BE) As CCOMODALIDADFUGAINCIDENCIA_BE
            Dim oCCOMODALIDADFUGAINCIDENCIA_BE As New CCOMODALIDADFUGAINCIDENCIA_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTMODCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOMODALIDADFUGAINCIDENCIA_BE.PropMODCODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOMODALIDADFUGAINCIDENCIA_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.MODCODIGO) Then oCCOMODALIDADFUGAINCIDENCIA_BE.PropMODCODIGO = Nothing Else oCCOMODALIDADFUGAINCIDENCIA_BE.PropMODCODIGO = CType(oDataReader(Campos.MODCODIGO), Int32)
                    oCCOMODALIDADFUGAINCIDENCIA_BE.PropMODDESCRIPCION = IIf(oDataReader.IsDBNull(Campos.MODDESCRIPCION), "", oDataReader(Campos.MODDESCRIPCION))
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oCCOMODALIDADFUGAINCIDENCIA_BE
        End Function
        Public Function ListarCombo() As DataTable
            Dim odt As New DataTable
            Try

                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOMODALIDADFUGAINCIDENCIA_LISTARCOMBO", arrParam)
                    odt.Load(dataReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return odt
        End Function

	End Class
End Namespace
