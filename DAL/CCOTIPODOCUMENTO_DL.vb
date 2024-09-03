Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class CCOTIPODOCUMENTO_DL
		Private cnDB2 As DB2Connection

		#Region "Numerador"
		Public Enum Campos
			TDOCODIGO = 0
			TDODESCRIPCION = 1
			TDOABREVIA = 2
			TDOESTADO = 3
		End Enum
		#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

		Public Sub Insertar(ByVal pCCOTIPODOCUMENTO_BE As CCOTIPODOCUMENTO_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(3) {}
				arrParam(0) = New DB2Parameter("P_INTTDOCODIGO", DB2Type.INTEGER)
				arrParam(0).Value = pCCOTIPODOCUMENTO_BE.PropTDOCODIGO
				arrParam(1) = New DB2Parameter("P_VCHTDODESCRIPCION", DB2Type.VARCHAR, 30)
				arrParam(1).Value = pCCOTIPODOCUMENTO_BE.PropTDODESCRIPCION
				arrParam(2) = New DB2Parameter("P_VCHTDOABREVIA", DB2Type.VARCHAR, 10)
				arrParam(2).Value = pCCOTIPODOCUMENTO_BE.PropTDOABREVIA
				arrParam(3) = New DB2Parameter("P_INTTDOESTADO", DB2Type.INTEGER)
				arrParam(3).Value = pCCOTIPODOCUMENTO_BE.PropTDOESTADO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOTIPODOCUMENTO_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pCCOTIPODOCUMENTO_BE As CCOTIPODOCUMENTO_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(3) {}
                arrParam(0) = New DB2Parameter("P_INTTDOCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOTIPODOCUMENTO_BE.PropTDOCODIGO
                arrParam(1) = New DB2Parameter("P_VCHTDODESCRIPCION", DB2Type.VARCHAR, 30)
                arrParam(1).Value = pCCOTIPODOCUMENTO_BE.PropTDODESCRIPCION
                arrParam(2) = New DB2Parameter("P_VCHTDOABREVIA", DB2Type.VARCHAR, 10)
                arrParam(2).Value = pCCOTIPODOCUMENTO_BE.PropTDOABREVIA
                arrParam(3) = New DB2Parameter("P_INTTDOESTADO", DB2Type.INTEGER)
                arrParam(3).Value = pCCOTIPODOCUMENTO_BE.PropTDOESTADO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOTIPODOCUMENTO_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOTIPODOCUMENTO_BE As CCOTIPODOCUMENTO_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTTDOCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOTIPODOCUMENTO_BE.PropTDOCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOTIPODOCUMENTO_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOTIPODOCUMENTO_BE As CCOTIPODOCUMENTO_BE) As CCOTIPODOCUMENTO_BE
            Dim oCCOTIPODOCUMENTO_BE As New CCOTIPODOCUMENTO_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTTDOCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOTIPODOCUMENTO_BE.PropTDOCODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOTIPODOCUMENTO_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.TDOCODIGO) Then oCCOTIPODOCUMENTO_BE.PropTDOCODIGO = Nothing Else oCCOTIPODOCUMENTO_BE.PropTDOCODIGO = CType(oDataReader(Campos.TDOCODIGO), Int32)
                    oCCOTIPODOCUMENTO_BE.PropTDODESCRIPCION = IIf(oDataReader.IsDBNull(Campos.TDODESCRIPCION), "", oDataReader(Campos.TDODESCRIPCION))
                    oCCOTIPODOCUMENTO_BE.PropTDOABREVIA = IIf(oDataReader.IsDBNull(Campos.TDOABREVIA), "", oDataReader(Campos.TDOABREVIA))
                    If oDataReader.IsDBNull(Campos.TDOESTADO) Then oCCOTIPODOCUMENTO_BE.PropTDOESTADO = Nothing Else oCCOTIPODOCUMENTO_BE.PropTDOESTADO = CType(oDataReader(Campos.TDOESTADO), Int32)
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oCCOTIPODOCUMENTO_BE
        End Function

        Public Function ListarCombo() As List(Of CCOTIPODOCUMENTO_BE)
            Dim oCCOTIPODOCUMENTO_BE As New CCOTIPODOCUMENTO_BE
            Dim lstGeneral As New List(Of CCOTIPODOCUMENTO_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOTIPODOCUMENTO_LISTARCOMBO", arrParam)
                Using oDataReader
                    Do While oDataReader.Read()
                        oCCOTIPODOCUMENTO_BE = New CCOTIPODOCUMENTO_BE
                        If oDataReader.IsDBNull(Campos.TDOCODIGO) Then oCCOTIPODOCUMENTO_BE.PropTDOCODIGO = Nothing Else oCCOTIPODOCUMENTO_BE.PropTDOCODIGO = CType(oDataReader(Campos.TDOCODIGO), Int32)
                        oCCOTIPODOCUMENTO_BE.PropTDODESCRIPCION = IIf(oDataReader.IsDBNull(Campos.TDODESCRIPCION), "", oDataReader(Campos.TDODESCRIPCION))
                        oCCOTIPODOCUMENTO_BE.PropTDOABREVIA = IIf(oDataReader.IsDBNull(Campos.TDOABREVIA), "", oDataReader(Campos.TDOABREVIA))
                        If oDataReader.IsDBNull(Campos.TDOESTADO) Then oCCOTIPODOCUMENTO_BE.PropTDOESTADO = Nothing Else oCCOTIPODOCUMENTO_BE.PropTDOESTADO = CType(oDataReader(Campos.TDOESTADO), Int32)
                        lstGeneral.Add(oCCOTIPODOCUMENTO_BE)
                    Loop
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return lstGeneral
        End Function

	End Class
End Namespace
