Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class CCOTIPORESPUESTA_DL
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

		Public Sub Insertar(ByVal pCCOTIPORESPUESTA_BE As CCOTIPORESPUESTA_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(2) {}
				arrParam(0) = New DB2Parameter("P_SMLTRECODIGO", DB2Type.SMALLINT)
				arrParam(0).Value = pCCOTIPORESPUESTA_BE.PropTRECODIGO
				arrParam(1) = New DB2Parameter("P_VCHTREDESCRIPCION", DB2Type.VARCHAR, 30)
				arrParam(1).Value = pCCOTIPORESPUESTA_BE.PropTREDESCRIPCION
				arrParam(2) = New DB2Parameter("P_SMLTREESTADO", DB2Type.SMALLINT)
				arrParam(2).Value = pCCOTIPORESPUESTA_BE.PropTREESTADO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOTIPORESPUESTA_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pCCOTIPORESPUESTA_BE As CCOTIPORESPUESTA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(2) {}
                arrParam(0) = New DB2Parameter("P_SMLTRECODIGO", DB2Type.SMALLINT)
                arrParam(0).Value = pCCOTIPORESPUESTA_BE.PropTRECODIGO
                arrParam(1) = New DB2Parameter("P_VCHTREDESCRIPCION", DB2Type.VARCHAR, 30)
                arrParam(1).Value = pCCOTIPORESPUESTA_BE.PropTREDESCRIPCION
                arrParam(2) = New DB2Parameter("P_SMLTREESTADO", DB2Type.SMALLINT)
                arrParam(2).Value = pCCOTIPORESPUESTA_BE.PropTREESTADO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOTIPORESPUESTA_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOTIPORESPUESTA_BE As CCOTIPORESPUESTA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_SMLTRECODIGO", DB2Type.SMALLINT)
                arrParam(0).Value = pCCOTIPORESPUESTA_BE.PropTRECODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOTIPORESPUESTA_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOTIPORESPUESTA_BE As CCOTIPORESPUESTA_BE) As CCOTIPORESPUESTA_BE
            Dim oCCOTIPORESPUESTA_BE As New CCOTIPORESPUESTA_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_SMLTRECODIGO", DB2Type.SMALLINT)
                arrParam(0).Value = pCCOTIPORESPUESTA_BE.PropTRECODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOTIPORESPUESTA_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.TRECODIGO) Then oCCOTIPORESPUESTA_BE.PropTRECODIGO = Nothing Else oCCOTIPORESPUESTA_BE.PropTRECODIGO = CType(oDataReader(Campos.TRECODIGO), Int16)
                    oCCOTIPORESPUESTA_BE.PropTREDESCRIPCION = IIf(oDataReader.IsDBNull(Campos.TREDESCRIPCION), "", oDataReader(Campos.TREDESCRIPCION))
                    If oDataReader.IsDBNull(Campos.TREESTADO) Then oCCOTIPORESPUESTA_BE.PropTREESTADO = Nothing Else oCCOTIPORESPUESTA_BE.PropTREESTADO = CType(oDataReader(Campos.TREESTADO), Int16)
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oCCOTIPORESPUESTA_BE
        End Function


	End Class
End Namespace
