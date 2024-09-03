Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class CCOCLASEINCIDENCIA_DL
		Private cnDB2 As DB2Connection

		#Region "Numerador"
		Public Enum Campos
			CINCODIGO = 0
			CINDESCRIPCION = 1
			CINABREVIA = 2
			CINESTADO = 3
		End Enum
		#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

		Public Sub Insertar(ByVal pCCOCLASEINCIDENCIA_BE As CCOCLASEINCIDENCIA_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(3) {}
				arrParam(0) = New DB2Parameter("P_INTCINCODIGO", DB2Type.INTEGER)
				arrParam(0).Value = pCCOCLASEINCIDENCIA_BE.PropCINCODIGO
				arrParam(1) = New DB2Parameter("P_VCHCINDESCRIPCION", DB2Type.VARCHAR, 30)
				arrParam(1).Value = pCCOCLASEINCIDENCIA_BE.PropCINDESCRIPCION
				arrParam(2) = New DB2Parameter("P_VCHCINABREVIA", DB2Type.VARCHAR, 10)
				arrParam(2).Value = pCCOCLASEINCIDENCIA_BE.PropCINABREVIA
				arrParam(3) = New DB2Parameter("P_INTCINESTADO", DB2Type.INTEGER)
				arrParam(3).Value = pCCOCLASEINCIDENCIA_BE.PropCINESTADO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOCLASEINCIDENCIA_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pCCOCLASEINCIDENCIA_BE As CCOCLASEINCIDENCIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(3) {}
                arrParam(0) = New DB2Parameter("P_INTCINCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOCLASEINCIDENCIA_BE.PropCINCODIGO
                arrParam(1) = New DB2Parameter("P_VCHCINDESCRIPCION", DB2Type.VARCHAR, 30)
                arrParam(1).Value = pCCOCLASEINCIDENCIA_BE.PropCINDESCRIPCION
                arrParam(2) = New DB2Parameter("P_VCHCINABREVIA", DB2Type.VARCHAR, 10)
                arrParam(2).Value = pCCOCLASEINCIDENCIA_BE.PropCINABREVIA
                arrParam(3) = New DB2Parameter("P_INTCINESTADO", DB2Type.INTEGER)
                arrParam(3).Value = pCCOCLASEINCIDENCIA_BE.PropCINESTADO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOCLASEINCIDENCIA_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOCLASEINCIDENCIA_BE As CCOCLASEINCIDENCIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTCINCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOCLASEINCIDENCIA_BE.PropCINCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOCLASEINCIDENCIA_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOCLASEINCIDENCIA_BE As CCOCLASEINCIDENCIA_BE) As CCOCLASEINCIDENCIA_BE
            Dim oCCOCLASEINCIDENCIA_BE As New CCOCLASEINCIDENCIA_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTCINCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOCLASEINCIDENCIA_BE.PropCINCODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOCLASEINCIDENCIA_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.CINCODIGO) Then oCCOCLASEINCIDENCIA_BE.PropCINCODIGO = Nothing Else oCCOCLASEINCIDENCIA_BE.PropCINCODIGO = CType(oDataReader(Campos.CINCODIGO), Int32)
                    oCCOCLASEINCIDENCIA_BE.PropCINDESCRIPCION = IIf(oDataReader.IsDBNull(Campos.CINDESCRIPCION), "", oDataReader(Campos.CINDESCRIPCION))
                    oCCOCLASEINCIDENCIA_BE.PropCINABREVIA = IIf(oDataReader.IsDBNull(Campos.CINABREVIA), "", oDataReader(Campos.CINABREVIA))
                    If oDataReader.IsDBNull(Campos.CINESTADO) Then oCCOCLASEINCIDENCIA_BE.PropCINESTADO = Nothing Else oCCOCLASEINCIDENCIA_BE.PropCINESTADO = CType(oDataReader(Campos.CINESTADO), Int32)
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oCCOCLASEINCIDENCIA_BE
        End Function

        Public Function ListarCombo() As DataTable
            Dim odt As New DataTable
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOCLASEINCIDENCIA_LISTARCOMBO", arrParam)
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
