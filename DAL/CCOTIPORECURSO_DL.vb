Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class CCOTIPORECURSO_DL
		Private cnDB2 As DB2Connection

		#Region "Numerador"
		Public Enum Campos
			TRECODIGO = 0
			TREDESCRIPCION = 1
			TREESTADO = 2
		End Enum
		#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

		Public Sub Insertar(ByVal pCCOTIPORECURSO_BE As CCOTIPORECURSO_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(2) {}
				arrParam(0) = New DB2Parameter("P_INTTRECODIGO", DB2Type.INTEGER)
				arrParam(0).Value = pCCOTIPORECURSO_BE.PropTRECODIGO
				arrParam(1) = New DB2Parameter("P_VCHTREDESCRIPCION", DB2Type.VARCHAR, 30)
				arrParam(1).Value = pCCOTIPORECURSO_BE.PropTREDESCRIPCION
				arrParam(2) = New DB2Parameter("P_INTTREESTADO", DB2Type.INTEGER)
				arrParam(2).Value = pCCOTIPORECURSO_BE.PropTREESTADO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOTIPORECURSO_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pCCOTIPORECURSO_BE As CCOTIPORECURSO_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(2) {}
                arrParam(0) = New DB2Parameter("P_INTTRECODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOTIPORECURSO_BE.PropTRECODIGO
                arrParam(1) = New DB2Parameter("P_VCHTREDESCRIPCION", DB2Type.VARCHAR, 30)
                arrParam(1).Value = pCCOTIPORECURSO_BE.PropTREDESCRIPCION
                arrParam(2) = New DB2Parameter("P_INTTREESTADO", DB2Type.INTEGER)
                arrParam(2).Value = pCCOTIPORECURSO_BE.PropTREESTADO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOTIPORECURSO_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOTIPORECURSO_BE As CCOTIPORECURSO_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTTRECODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOTIPORECURSO_BE.PropTRECODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOTIPORECURSO_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOTIPORECURSO_BE As CCOTIPORECURSO_BE) As CCOTIPORECURSO_BE
            Dim oCCOTIPORECURSO_BE As New CCOTIPORECURSO_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTTRECODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOTIPORECURSO_BE.PropTRECODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOTIPORECURSO_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.TRECODIGO) Then oCCOTIPORECURSO_BE.PropTRECODIGO = Nothing Else oCCOTIPORECURSO_BE.PropTRECODIGO = CType(oDataReader(Campos.TRECODIGO), Int32)
                    oCCOTIPORECURSO_BE.PropTREDESCRIPCION = IIf(oDataReader.IsDBNull(Campos.TREDESCRIPCION), "", oDataReader(Campos.TREDESCRIPCION))
                    If oDataReader.IsDBNull(Campos.TREESTADO) Then oCCOTIPORECURSO_BE.PropTREESTADO = Nothing Else oCCOTIPORECURSO_BE.PropTREESTADO = CType(oDataReader(Campos.TREESTADO), Int32)
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oCCOTIPORECURSO_BE
        End Function

        Public Function ListarCombo() As List(Of CCOTIPORECURSO_BE)
            Dim oCCOTIPORECURSO_BE As New CCOTIPORECURSO_BE
            Dim lstGeneral As New List(Of CCOTIPORECURSO_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOTIPORECURSO_LISTARCOMBO", arrParam)
                Using oDataReader
                    Do While oDataReader.Read()
                        oCCOTIPORECURSO_BE = New CCOTIPORECURSO_BE
                        If oDataReader.IsDBNull(Campos.TRECODIGO) Then oCCOTIPORECURSO_BE.PropTRECODIGO = Nothing Else oCCOTIPORECURSO_BE.PropTRECODIGO = CType(oDataReader(Campos.TRECODIGO), Int32)
                        oCCOTIPORECURSO_BE.PropTREDESCRIPCION = IIf(oDataReader.IsDBNull(Campos.TREDESCRIPCION), "", oDataReader(Campos.TREDESCRIPCION))
                        If oDataReader.IsDBNull(Campos.TREESTADO) Then oCCOTIPORECURSO_BE.PropTREESTADO = Nothing Else oCCOTIPORECURSO_BE.PropTREESTADO = CType(oDataReader(Campos.TREESTADO), Int32)
                        lstGeneral.Add(oCCOTIPORECURSO_BE)
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
