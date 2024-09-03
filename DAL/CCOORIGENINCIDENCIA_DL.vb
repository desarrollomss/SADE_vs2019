Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class CCOORIGENINCIDENCIA_DL
		Private cnDB2 As DB2Connection

		#Region "Numerador"
		Public Enum Campos
			ORICODIGO = 0
			ORIDESCRIPCION = 1
			ORIESTADO = 2
		End Enum
		#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

		Public Sub Insertar(ByVal pCCOORIGENINCIDENCIA_BE As CCOORIGENINCIDENCIA_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(2) {}
				arrParam(0) = New DB2Parameter("P_INTORICODIGO", DB2Type.INTEGER)
				arrParam(0).Value = pCCOORIGENINCIDENCIA_BE.PropORICODIGO
				arrParam(1) = New DB2Parameter("P_VCHORIDESCRIPCION", DB2Type.VARCHAR, 20)
				arrParam(1).Value = pCCOORIGENINCIDENCIA_BE.PropORIDESCRIPCION
				arrParam(2) = New DB2Parameter("P_INTORIESTADO", DB2Type.INTEGER)
				arrParam(2).Value = pCCOORIGENINCIDENCIA_BE.PropORIESTADO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOORIGENINCIDENCIA_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pCCOORIGENINCIDENCIA_BE As CCOORIGENINCIDENCIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(2) {}
                arrParam(0) = New DB2Parameter("P_INTORICODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOORIGENINCIDENCIA_BE.PropORICODIGO
                arrParam(1) = New DB2Parameter("P_VCHORIDESCRIPCION", DB2Type.VARCHAR, 20)
                arrParam(1).Value = pCCOORIGENINCIDENCIA_BE.PropORIDESCRIPCION
                arrParam(2) = New DB2Parameter("P_INTORIESTADO", DB2Type.INTEGER)
                arrParam(2).Value = pCCOORIGENINCIDENCIA_BE.PropORIESTADO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOORIGENINCIDENCIA_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOORIGENINCIDENCIA_BE As CCOORIGENINCIDENCIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTORICODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOORIGENINCIDENCIA_BE.PropORICODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOORIGENINCIDENCIA_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOORIGENINCIDENCIA_BE As CCOORIGENINCIDENCIA_BE) As CCOORIGENINCIDENCIA_BE
            Dim oCCOORIGENINCIDENCIA_BE As New CCOORIGENINCIDENCIA_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTORICODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOORIGENINCIDENCIA_BE.PropORICODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOORIGENINCIDENCIA_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.ORICODIGO) Then oCCOORIGENINCIDENCIA_BE.PropORICODIGO = Nothing Else oCCOORIGENINCIDENCIA_BE.PropORICODIGO = CType(oDataReader(Campos.ORICODIGO), Int32)
                    oCCOORIGENINCIDENCIA_BE.PropORIDESCRIPCION = IIf(oDataReader.IsDBNull(Campos.ORIDESCRIPCION), "", oDataReader(Campos.ORIDESCRIPCION))
                    If oDataReader.IsDBNull(Campos.ORIESTADO) Then oCCOORIGENINCIDENCIA_BE.PropORIESTADO = Nothing Else oCCOORIGENINCIDENCIA_BE.PropORIESTADO = CType(oDataReader(Campos.ORIESTADO), Int32)
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oCCOORIGENINCIDENCIA_BE
        End Function


        Public Function ListarCombo() As List(Of CCOORIGENINCIDENCIA_BE)
            Dim obj As New CCOORIGENINCIDENCIA_BE
            Dim lstGeneral As New List(Of CCOORIGENINCIDENCIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOORIGENINCIDENCIA_LISTARCOMBO", arrParam)
                Using oDataReader
                    While (oDataReader.Read())
                        obj = New CCOORIGENINCIDENCIA_BE

                        If oDataReader.IsDBNull(Campos.ORICODIGO) Then obj.PropORICODIGO = Nothing Else obj.PropORICODIGO = CType(oDataReader(Campos.ORICODIGO), Int32)
                        obj.PropORIDESCRIPCION = IIf(oDataReader.IsDBNull(Campos.ORIDESCRIPCION), "", oDataReader(Campos.ORIDESCRIPCION))
                        If oDataReader.IsDBNull(Campos.ORIESTADO) Then obj.PropORIESTADO = Nothing Else obj.PropORIESTADO = CType(oDataReader(Campos.ORIESTADO), Int32)
                        lstGeneral.Add(obj)
                    End While
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
