Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class CCOSECTOR_DL
		Private cnDB2 As DB2Connection

		#Region "Numerador"
		Public Enum Campos
			SECCODIGO = 0
			SECDESCRIPCION = 1
            SECESTADO = 2
            CSECCODIGO = 3
		End Enum
		#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

		Public Sub Insertar(ByVal pCCOSECTOR_BE As CCOSECTOR_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(2) {}
				arrParam(0) = New DB2Parameter("P_INTSECCODIGO", DB2Type.INTEGER)
				arrParam(0).Value = pCCOSECTOR_BE.PropSECCODIGO
				arrParam(1) = New DB2Parameter("P_VCHSECDESCRIPCION", DB2Type.VARCHAR, 10)
				arrParam(1).Value = pCCOSECTOR_BE.PropSECDESCRIPCION
				arrParam(2) = New DB2Parameter("P_INTSECESTADO", DB2Type.INTEGER)
				arrParam(2).Value = pCCOSECTOR_BE.PropSECESTADO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOSECTOR_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pCCOSECTOR_BE As CCOSECTOR_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(2) {}
                arrParam(0) = New DB2Parameter("P_INTSECCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOSECTOR_BE.PropSECCODIGO
                arrParam(1) = New DB2Parameter("P_VCHSECDESCRIPCION", DB2Type.VARCHAR, 10)
                arrParam(1).Value = pCCOSECTOR_BE.PropSECDESCRIPCION
                arrParam(2) = New DB2Parameter("P_INTSECESTADO", DB2Type.INTEGER)
                arrParam(2).Value = pCCOSECTOR_BE.PropSECESTADO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOSECTOR_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOSECTOR_BE As CCOSECTOR_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTSECCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOSECTOR_BE.PropSECCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOSECTOR_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOSECTOR_BE As CCOSECTOR_BE) As CCOSECTOR_BE
            Dim oCCOSECTOR_BE As New CCOSECTOR_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTSECCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOSECTOR_BE.PropSECCODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOSECTOR_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.SECCODIGO) Then oCCOSECTOR_BE.PropSECCODIGO = Nothing Else oCCOSECTOR_BE.PropSECCODIGO = CType(oDataReader(Campos.SECCODIGO), Int32)
                    oCCOSECTOR_BE.PropSECDESCRIPCION = IIf(oDataReader.IsDBNull(Campos.SECDESCRIPCION), "", oDataReader(Campos.SECDESCRIPCION))
                    If oDataReader.IsDBNull(Campos.SECESTADO) Then oCCOSECTOR_BE.PropSECESTADO = Nothing Else oCCOSECTOR_BE.PropSECESTADO = CType(oDataReader(Campos.SECESTADO), Int32)
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oCCOSECTOR_BE
        End Function

        Public Function ListarCombo() As List(Of CCOSECTOR_BE)
            Dim oCCOSECTOR_BE As New CCOSECTOR_BE
            Dim lstGeneral As New List(Of CCOSECTOR_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOSECTOR_LISTARCOMBO", arrParam)
                Using oDataReader
                    Do While oDataReader.Read()
                        oCCOSECTOR_BE = New CCOSECTOR_BE
                        If oDataReader.IsDBNull(Campos.SECCODIGO) Then oCCOSECTOR_BE.PropSECCODIGO = Nothing Else oCCOSECTOR_BE.PropSECCODIGO = CType(oDataReader(Campos.SECCODIGO), Int32)
                        oCCOSECTOR_BE.PropSECDESCRIPCION = IIf(oDataReader.IsDBNull(Campos.SECDESCRIPCION), "", oDataReader(Campos.SECDESCRIPCION))
                        If oDataReader.IsDBNull(Campos.SECESTADO) Then oCCOSECTOR_BE.PropSECESTADO = Nothing Else oCCOSECTOR_BE.PropSECESTADO = CType(oDataReader(Campos.SECESTADO), Int32)
                        lstGeneral.Add(oCCOSECTOR_BE)
                    Loop
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return lstGeneral
        End Function

        Public Function ListarCombo2() As List(Of CCOSECTOR_BE)
            Dim oCCOSECTOR_BE As New CCOSECTOR_BE
            Dim lstGeneral As New List(Of CCOSECTOR_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOSECTOR_LISTARCOMBO2", arrParam)
                Using oDataReader
                    Do While oDataReader.Read()
                        oCCOSECTOR_BE = New CCOSECTOR_BE
                        If oDataReader.IsDBNull(Campos.SECCODIGO) Then oCCOSECTOR_BE.PropSECCODIGO = Nothing Else oCCOSECTOR_BE.PropSECCODIGO = CType(oDataReader(Campos.SECCODIGO), Int32)
                        oCCOSECTOR_BE.PropSECDESCRIPCION = IIf(oDataReader.IsDBNull(Campos.SECDESCRIPCION), "", oDataReader(Campos.SECDESCRIPCION))
                        If oDataReader.IsDBNull(Campos.SECESTADO) Then oCCOSECTOR_BE.PropSECESTADO = Nothing Else oCCOSECTOR_BE.PropSECESTADO = CType(oDataReader(Campos.SECESTADO), Int32)
                        oCCOSECTOR_BE.PropCSECCODIGO = IIf(oDataReader.IsDBNull(Campos.CSECCODIGO), "", oDataReader(Campos.CSECCODIGO))
                        lstGeneral.Add(oCCOSECTOR_BE)
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

