Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class CCOTIPOPERSONA_DL
		Private cnDB2 As DB2Connection

		#Region "Numerador"
		Public Enum Campos
			TPECODIGO = 0
			TPEDESCRIPCION = 1
			TPEABREVIA = 2
			TPEESTADO = 3
		End Enum
		#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

		Public Sub Insertar(ByVal pCCOTIPOPERSONA_BE As CCOTIPOPERSONA_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(3) {}
				arrParam(0) = New DB2Parameter("P_INTTPECODIGO", DB2Type.INTEGER)
				arrParam(0).Value = pCCOTIPOPERSONA_BE.PropTPECODIGO
				arrParam(1) = New DB2Parameter("P_VCHTPEDESCRIPCION", DB2Type.VARCHAR, 20)
				arrParam(1).Value = pCCOTIPOPERSONA_BE.PropTPEDESCRIPCION
				arrParam(2) = New DB2Parameter("P_VCHTPEABREVIA", DB2Type.VARCHAR, 5)
				arrParam(2).Value = pCCOTIPOPERSONA_BE.PropTPEABREVIA
				arrParam(3) = New DB2Parameter("P_INTTPEESTADO", DB2Type.INTEGER)
				arrParam(3).Value = pCCOTIPOPERSONA_BE.PropTPEESTADO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOTIPOPERSONA_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pCCOTIPOPERSONA_BE As CCOTIPOPERSONA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(3) {}
                arrParam(0) = New DB2Parameter("P_INTTPECODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOTIPOPERSONA_BE.PropTPECODIGO
                arrParam(1) = New DB2Parameter("P_VCHTPEDESCRIPCION", DB2Type.VARCHAR, 20)
                arrParam(1).Value = pCCOTIPOPERSONA_BE.PropTPEDESCRIPCION
                arrParam(2) = New DB2Parameter("P_VCHTPEABREVIA", DB2Type.VARCHAR, 5)
                arrParam(2).Value = pCCOTIPOPERSONA_BE.PropTPEABREVIA
                arrParam(3) = New DB2Parameter("P_INTTPEESTADO", DB2Type.INTEGER)
                arrParam(3).Value = pCCOTIPOPERSONA_BE.PropTPEESTADO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOTIPOPERSONA_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOTIPOPERSONA_BE As CCOTIPOPERSONA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTTPECODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOTIPOPERSONA_BE.PropTPECODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOTIPOPERSONA_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOTIPOPERSONA_BE As CCOTIPOPERSONA_BE) As CCOTIPOPERSONA_BE
            Dim oCCOTIPOPERSONA_BE As New CCOTIPOPERSONA_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTTPECODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOTIPOPERSONA_BE.PropTPECODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOTIPOPERSONA_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.TPECODIGO) Then oCCOTIPOPERSONA_BE.PropTPECODIGO = Nothing Else oCCOTIPOPERSONA_BE.PropTPECODIGO = CType(oDataReader(Campos.TPECODIGO), Int32)
                    oCCOTIPOPERSONA_BE.PropTPEDESCRIPCION = IIf(oDataReader.IsDBNull(Campos.TPEDESCRIPCION), "", oDataReader(Campos.TPEDESCRIPCION))
                    oCCOTIPOPERSONA_BE.PropTPEABREVIA = IIf(oDataReader.IsDBNull(Campos.TPEABREVIA), "", oDataReader(Campos.TPEABREVIA))
                    If oDataReader.IsDBNull(Campos.TPEESTADO) Then oCCOTIPOPERSONA_BE.PropTPEESTADO = Nothing Else oCCOTIPOPERSONA_BE.PropTPEESTADO = CType(oDataReader(Campos.TPEESTADO), Int32)
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oCCOTIPOPERSONA_BE
        End Function


        Public Function ListarCombo() As List(Of CCOTIPOPERSONA_BE)
            Dim oCCOTIPOPERSONA_BE As New CCOTIPOPERSONA_BE
            Dim lstGeneral As New List(Of CCOTIPOPERSONA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOTIPOPERSONA_LISTARCOMBO", arrParam)
                Using oDataReader
                    Do While oDataReader.Read()
                        oCCOTIPOPERSONA_BE = New CCOTIPOPERSONA_BE
                        If oDataReader.IsDBNull(Campos.TPECODIGO) Then oCCOTIPOPERSONA_BE.PropTPECODIGO = Nothing Else oCCOTIPOPERSONA_BE.PropTPECODIGO = CType(oDataReader(Campos.TPECODIGO), Int32)
                        oCCOTIPOPERSONA_BE.PropTPEDESCRIPCION = IIf(oDataReader.IsDBNull(Campos.TPEDESCRIPCION), "", oDataReader(Campos.TPEDESCRIPCION))
                        oCCOTIPOPERSONA_BE.PropTPEABREVIA = IIf(oDataReader.IsDBNull(Campos.TPEABREVIA), "", oDataReader(Campos.TPEABREVIA))
                        If oDataReader.IsDBNull(Campos.TPEESTADO) Then oCCOTIPOPERSONA_BE.PropTPEESTADO = Nothing Else oCCOTIPOPERSONA_BE.PropTPEESTADO = CType(oDataReader(Campos.TPEESTADO), Int32)
                        lstGeneral.Add(oCCOTIPOPERSONA_BE)
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
