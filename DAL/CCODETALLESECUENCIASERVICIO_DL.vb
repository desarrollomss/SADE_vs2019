Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class CCODETALLESECUENCIASERVICIO_DL
		Private cnDB2 As DB2Connection

		#Region "Numerador"
		Public Enum Campos
			DSSCODIGO = 0
			SSECODIGO = 1
			DSSSECUENCIA = 2
			DSSDISPONIBLE = 3
			MAUCODIGO = 4
			TURCODIGO = 5
		End Enum
		#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

		Public Sub Insertar(ByVal pCCODETALLESECUENCIASERVICIO_BE As CCODETALLESECUENCIASERVICIO_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(5) {}
				arrParam(0) = New DB2Parameter("P_SMLDSSCODIGO", DB2Type.SMALLINT)
				arrParam(0).Value = pCCODETALLESECUENCIASERVICIO_BE.PropDSSCODIGO
				arrParam(1) = New DB2Parameter("P_SMLSSECODIGO", DB2Type.SMALLINT)
				arrParam(1).Value = pCCODETALLESECUENCIASERVICIO_BE.PropSSECODIGO
				arrParam(2) = New DB2Parameter("P_SMLDSSSECUENCIA", DB2Type.SMALLINT)
				arrParam(2).Value = pCCODETALLESECUENCIASERVICIO_BE.PropDSSSECUENCIA
				arrParam(3) = New DB2Parameter("P_SMLDSSDISPONIBLE", DB2Type.SMALLINT)
				arrParam(3).Value = pCCODETALLESECUENCIASERVICIO_BE.PropDSSDISPONIBLE
				arrParam(4) = New DB2Parameter("P_SMLMAUCODIGO", DB2Type.SMALLINT)
				arrParam(4).Value = pCCODETALLESECUENCIASERVICIO_BE.PropMAUCODIGO
				arrParam(5) = New DB2Parameter("P_SMLTURCODIGO", DB2Type.SMALLINT)
				arrParam(5).Value = pCCODETALLESECUENCIASERVICIO_BE.PropTURCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCODETALLESECUENCIASERVICIO_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pCCODETALLESECUENCIASERVICIO_BE As CCODETALLESECUENCIASERVICIO_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(5) {}
                arrParam(0) = New DB2Parameter("P_SMLDSSCODIGO", DB2Type.SMALLINT)
                arrParam(0).Value = pCCODETALLESECUENCIASERVICIO_BE.PropDSSCODIGO
                arrParam(1) = New DB2Parameter("P_SMLSSECODIGO", DB2Type.SMALLINT)
                arrParam(1).Value = pCCODETALLESECUENCIASERVICIO_BE.PropSSECODIGO
                arrParam(2) = New DB2Parameter("P_SMLDSSSECUENCIA", DB2Type.SMALLINT)
                arrParam(2).Value = pCCODETALLESECUENCIASERVICIO_BE.PropDSSSECUENCIA
                arrParam(3) = New DB2Parameter("P_SMLDSSDISPONIBLE", DB2Type.SMALLINT)
                arrParam(3).Value = pCCODETALLESECUENCIASERVICIO_BE.PropDSSDISPONIBLE
                arrParam(4) = New DB2Parameter("P_SMLMAUCODIGO", DB2Type.SMALLINT)
                arrParam(4).Value = pCCODETALLESECUENCIASERVICIO_BE.PropMAUCODIGO
                arrParam(5) = New DB2Parameter("P_SMLTURCODIGO", DB2Type.SMALLINT)
                arrParam(5).Value = pCCODETALLESECUENCIASERVICIO_BE.PropTURCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCODETALLESECUENCIASERVICIO_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCODETALLESECUENCIASERVICIO_BE As CCODETALLESECUENCIASERVICIO_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_SMLDSSCODIGO", DB2Type.SMALLINT)
                arrParam(0).Value = pCCODETALLESECUENCIASERVICIO_BE.PropDSSCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCODETALLESECUENCIASERVICIO_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCODETALLESECUENCIASERVICIO_BE As CCODETALLESECUENCIASERVICIO_BE) As CCODETALLESECUENCIASERVICIO_BE
            Dim oCCODETALLESECUENCIASERVICIO_BE As New CCODETALLESECUENCIASERVICIO_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_SMLDSSCODIGO", DB2Type.SMALLINT)
                arrParam(0).Value = pCCODETALLESECUENCIASERVICIO_BE.PropDSSCODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCODETALLESECUENCIASERVICIO_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.DSSCODIGO) Then oCCODETALLESECUENCIASERVICIO_BE.PropDSSCODIGO = Nothing Else oCCODETALLESECUENCIASERVICIO_BE.PropDSSCODIGO = CType(oDataReader(Campos.DSSCODIGO), Int16)
                    If oDataReader.IsDBNull(Campos.SSECODIGO) Then oCCODETALLESECUENCIASERVICIO_BE.PropSSECODIGO = Nothing Else oCCODETALLESECUENCIASERVICIO_BE.PropSSECODIGO = CType(oDataReader(Campos.SSECODIGO), Int16)
                    If oDataReader.IsDBNull(Campos.DSSSECUENCIA) Then oCCODETALLESECUENCIASERVICIO_BE.PropDSSSECUENCIA = Nothing Else oCCODETALLESECUENCIASERVICIO_BE.PropDSSSECUENCIA = CType(oDataReader(Campos.DSSSECUENCIA), Int16)
                    If oDataReader.IsDBNull(Campos.DSSDISPONIBLE) Then oCCODETALLESECUENCIASERVICIO_BE.PropDSSDISPONIBLE = Nothing Else oCCODETALLESECUENCIASERVICIO_BE.PropDSSDISPONIBLE = CType(oDataReader(Campos.DSSDISPONIBLE), Int16)
                    If oDataReader.IsDBNull(Campos.MAUCODIGO) Then oCCODETALLESECUENCIASERVICIO_BE.PropMAUCODIGO = Nothing Else oCCODETALLESECUENCIASERVICIO_BE.PropMAUCODIGO = CType(oDataReader(Campos.MAUCODIGO), Int16)
                    If oDataReader.IsDBNull(Campos.TURCODIGO) Then oCCODETALLESECUENCIASERVICIO_BE.PropTURCODIGO = Nothing Else oCCODETALLESECUENCIASERVICIO_BE.PropTURCODIGO = CType(oDataReader(Campos.TURCODIGO), Int16)
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oCCODETALLESECUENCIASERVICIO_BE
        End Function
        Public Function Listar(ByVal pCCODETALLESECUENCIASERVICIO_BE As CCODETALLESECUENCIASERVICIO_BE) As DataTable
            Dim dt As DataTable = New DataTable
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
                arrParam(0) = New DB2Parameter("P_SMLDSSCODIGO", DB2Type.SmallInt)
                arrParam(0).Value = pCCODETALLESECUENCIASERVICIO_BE.PropDSSCODIGO
                arrParam(1) = New DB2Parameter("P_SMLSSECODIGO", DB2Type.SmallInt)
                arrParam(1).Value = pCCODETALLESECUENCIASERVICIO_BE.PropSSECODIGO
                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCODETALLESECUENCIASERVICIO_LISTAR", arrParam)
                    dt.Load(dataReader)
                End Using

            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return dt
        End Function


	End Class
End Namespace
