Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class CCOSECUENCIASERVICIO_DL
		Private cnDB2 As DB2Connection

		#Region "Numerador"
		Public Enum Campos
			SSECODIGO = 0
			SSEDESCRIPCION = 1
			TTUCODIGO = 2
			AUDPRGCREACION = 3
			AUDPRGMODIF = 4
			AUDEQPCREACION = 5
			AUDEQPMODIF = 6
			AUDFECCREACION = 7
			AUDFECMODIF = 8
			AUDUSUCREACION = 9
			AUDUSUMODIF = 10
			AUDROLCREACION = 11
			AUDROLMODIF = 12
			SSEESTADO = 13
		End Enum
		#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

		Public Sub Insertar(ByVal pCCOSECUENCIASERVICIO_BE As CCOSECUENCIASERVICIO_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(13) {}
				arrParam(0) = New DB2Parameter("P_SMLSSECODIGO", DB2Type.SMALLINT)
				arrParam(0).Value = pCCOSECUENCIASERVICIO_BE.PropSSECODIGO
				arrParam(1) = New DB2Parameter("P_VCHSSEDESCRIPCION", DB2Type.VARCHAR, 30)
				arrParam(1).Value = pCCOSECUENCIASERVICIO_BE.PropSSEDESCRIPCION
				arrParam(2) = New DB2Parameter("P_SMLTTUCODIGO", DB2Type.SMALLINT)
				arrParam(2).Value = pCCOSECUENCIASERVICIO_BE.PropTTUCODIGO
				arrParam(3) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VARCHAR, 150)
				arrParam(3).Value = pCCOSECUENCIASERVICIO_BE.PropAUDPRGCREACION
				arrParam(4) = New DB2Parameter("P_VCHAUDPRGMODIF", DB2Type.VARCHAR, 150)
				arrParam(4).Value = pCCOSECUENCIASERVICIO_BE.PropAUDPRGMODIF
				arrParam(5) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VARCHAR, 60)
				arrParam(5).Value = pCCOSECUENCIASERVICIO_BE.PropAUDEQPCREACION
				arrParam(6) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VARCHAR, 60)
				arrParam(6).Value = pCCOSECUENCIASERVICIO_BE.PropAUDEQPMODIF
				arrParam(7) = New DB2Parameter("P_DTMAUDFECCREACION", DB2Type.TIMESTAMP)
				arrParam(7).Value = pCCOSECUENCIASERVICIO_BE.PropAUDFECCREACION
				arrParam(8) = New DB2Parameter("P_DTMAUDFECMODIF", DB2Type.TIMESTAMP)
				arrParam(8).Value = pCCOSECUENCIASERVICIO_BE.PropAUDFECMODIF
				arrParam(9) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VARCHAR, 10)
				arrParam(9).Value = pCCOSECUENCIASERVICIO_BE.PropAUDUSUCREACION
				arrParam(10) = New DB2Parameter("P_VCHAUDUSUMODIF", DB2Type.VARCHAR, 10)
				arrParam(10).Value = pCCOSECUENCIASERVICIO_BE.PropAUDUSUMODIF
				arrParam(11) = New DB2Parameter("P_INTAUDROLCREACION", DB2Type.INTEGER)
				arrParam(11).Value = pCCOSECUENCIASERVICIO_BE.PropAUDROLCREACION
				arrParam(12) = New DB2Parameter("P_INTAUDROLMODIF", DB2Type.INTEGER)
				arrParam(12).Value = pCCOSECUENCIASERVICIO_BE.PropAUDROLMODIF
				arrParam(13) = New DB2Parameter("P_SMLSSEESTADO", DB2Type.SMALLINT)
				arrParam(13).Value = pCCOSECUENCIASERVICIO_BE.PropSSEESTADO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOSECUENCIASERVICIO_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pCCOSECUENCIASERVICIO_BE As CCOSECUENCIASERVICIO_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(13) {}
                arrParam(0) = New DB2Parameter("P_SMLSSECODIGO", DB2Type.SMALLINT)
                arrParam(0).Value = pCCOSECUENCIASERVICIO_BE.PropSSECODIGO
                arrParam(1) = New DB2Parameter("P_VCHSSEDESCRIPCION", DB2Type.VARCHAR, 30)
                arrParam(1).Value = pCCOSECUENCIASERVICIO_BE.PropSSEDESCRIPCION
                arrParam(2) = New DB2Parameter("P_SMLTTUCODIGO", DB2Type.SMALLINT)
                arrParam(2).Value = pCCOSECUENCIASERVICIO_BE.PropTTUCODIGO
                arrParam(3) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VARCHAR, 150)
                arrParam(3).Value = pCCOSECUENCIASERVICIO_BE.PropAUDPRGCREACION
                arrParam(4) = New DB2Parameter("P_VCHAUDPRGMODIF", DB2Type.VARCHAR, 150)
                arrParam(4).Value = pCCOSECUENCIASERVICIO_BE.PropAUDPRGMODIF
                arrParam(5) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VARCHAR, 60)
                arrParam(5).Value = pCCOSECUENCIASERVICIO_BE.PropAUDEQPCREACION
                arrParam(6) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VARCHAR, 60)
                arrParam(6).Value = pCCOSECUENCIASERVICIO_BE.PropAUDEQPMODIF
                arrParam(7) = New DB2Parameter("P_DTMAUDFECCREACION", DB2Type.TIMESTAMP)
                arrParam(7).Value = pCCOSECUENCIASERVICIO_BE.PropAUDFECCREACION
                arrParam(8) = New DB2Parameter("P_DTMAUDFECMODIF", DB2Type.TIMESTAMP)
                arrParam(8).Value = pCCOSECUENCIASERVICIO_BE.PropAUDFECMODIF
                arrParam(9) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VARCHAR, 10)
                arrParam(9).Value = pCCOSECUENCIASERVICIO_BE.PropAUDUSUCREACION
                arrParam(10) = New DB2Parameter("P_VCHAUDUSUMODIF", DB2Type.VARCHAR, 10)
                arrParam(10).Value = pCCOSECUENCIASERVICIO_BE.PropAUDUSUMODIF
                arrParam(11) = New DB2Parameter("P_INTAUDROLCREACION", DB2Type.INTEGER)
                arrParam(11).Value = pCCOSECUENCIASERVICIO_BE.PropAUDROLCREACION
                arrParam(12) = New DB2Parameter("P_INTAUDROLMODIF", DB2Type.INTEGER)
                arrParam(12).Value = pCCOSECUENCIASERVICIO_BE.PropAUDROLMODIF
                arrParam(13) = New DB2Parameter("P_SMLSSEESTADO", DB2Type.SMALLINT)
                arrParam(13).Value = pCCOSECUENCIASERVICIO_BE.PropSSEESTADO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOSECUENCIASERVICIO_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOSECUENCIASERVICIO_BE As CCOSECUENCIASERVICIO_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_SMLSSECODIGO", DB2Type.SMALLINT)
                arrParam(0).Value = pCCOSECUENCIASERVICIO_BE.PropSSECODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOSECUENCIASERVICIO_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOSECUENCIASERVICIO_BE As CCOSECUENCIASERVICIO_BE) As CCOSECUENCIASERVICIO_BE
            Dim oCCOSECUENCIASERVICIO_BE As New CCOSECUENCIASERVICIO_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_SMLSSECODIGO", DB2Type.SMALLINT)
                arrParam(0).Value = pCCOSECUENCIASERVICIO_BE.PropSSECODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOSECUENCIASERVICIO_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.SSECODIGO) Then oCCOSECUENCIASERVICIO_BE.PropSSECODIGO = Nothing Else oCCOSECUENCIASERVICIO_BE.PropSSECODIGO = CType(oDataReader(Campos.SSECODIGO), Int16)
                    oCCOSECUENCIASERVICIO_BE.PropSSEDESCRIPCION = IIf(oDataReader.IsDBNull(Campos.SSEDESCRIPCION), "", oDataReader(Campos.SSEDESCRIPCION))
                    If oDataReader.IsDBNull(Campos.TTUCODIGO) Then oCCOSECUENCIASERVICIO_BE.PropTTUCODIGO = Nothing Else oCCOSECUENCIASERVICIO_BE.PropTTUCODIGO = CType(oDataReader(Campos.TTUCODIGO), Int16)
                    oCCOSECUENCIASERVICIO_BE.PropAUDPRGCREACION = IIf(oDataReader.IsDBNull(Campos.AUDPRGCREACION), "", oDataReader(Campos.AUDPRGCREACION))
                    oCCOSECUENCIASERVICIO_BE.PropAUDPRGMODIF = IIf(oDataReader.IsDBNull(Campos.AUDPRGMODIF), "", oDataReader(Campos.AUDPRGMODIF))
                    oCCOSECUENCIASERVICIO_BE.PropAUDEQPCREACION = IIf(oDataReader.IsDBNull(Campos.AUDEQPCREACION), "", oDataReader(Campos.AUDEQPCREACION))
                    oCCOSECUENCIASERVICIO_BE.PropAUDEQPMODIF = IIf(oDataReader.IsDBNull(Campos.AUDEQPMODIF), "", oDataReader(Campos.AUDEQPMODIF))
                    If oDataReader.IsDBNull(Campos.AUDFECCREACION) Then oCCOSECUENCIASERVICIO_BE.PropAUDFECCREACION = Nothing Else oCCOSECUENCIASERVICIO_BE.PropAUDFECCREACION = CType(oDataReader(Campos.AUDFECCREACION), DateTime)
                    If oDataReader.IsDBNull(Campos.AUDFECMODIF) Then oCCOSECUENCIASERVICIO_BE.PropAUDFECMODIF = Nothing Else oCCOSECUENCIASERVICIO_BE.PropAUDFECMODIF = CType(oDataReader(Campos.AUDFECMODIF), DateTime)
                    oCCOSECUENCIASERVICIO_BE.PropAUDUSUCREACION = IIf(oDataReader.IsDBNull(Campos.AUDUSUCREACION), "", oDataReader(Campos.AUDUSUCREACION))
                    oCCOSECUENCIASERVICIO_BE.PropAUDUSUMODIF = IIf(oDataReader.IsDBNull(Campos.AUDUSUMODIF), "", oDataReader(Campos.AUDUSUMODIF))
                    If oDataReader.IsDBNull(Campos.AUDROLCREACION) Then oCCOSECUENCIASERVICIO_BE.PropAUDROLCREACION = Nothing Else oCCOSECUENCIASERVICIO_BE.PropAUDROLCREACION = CType(oDataReader(Campos.AUDROLCREACION), Int32)
                    If oDataReader.IsDBNull(Campos.AUDROLMODIF) Then oCCOSECUENCIASERVICIO_BE.PropAUDROLMODIF = Nothing Else oCCOSECUENCIASERVICIO_BE.PropAUDROLMODIF = CType(oDataReader(Campos.AUDROLMODIF), Int32)
                    If oDataReader.IsDBNull(Campos.SSEESTADO) Then oCCOSECUENCIASERVICIO_BE.PropSSEESTADO = Nothing Else oCCOSECUENCIASERVICIO_BE.PropSSEESTADO = CType(oDataReader(Campos.SSEESTADO), Int16)
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oCCOSECUENCIASERVICIO_BE
        End Function
        Public Function Listar(ByVal pCCOSECUENCIASERVICIO_BE As CCOSECUENCIASERVICIO_BE) As DataTable
            Dim dt As DataTable = New DataTable
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_SMLSSECODIGO", DB2Type.SmallInt)
                arrParam(0).Value = pCCOSECUENCIASERVICIO_BE.PropSSECODIGO
                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOSECUENCIASERVICIO_LISTAR", arrParam)
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
