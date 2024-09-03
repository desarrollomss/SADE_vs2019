Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class CCOENCUESTAINCIDENCIA_DL
		Private cnDB2 As DB2Connection

		#Region "Numerador"
		Public Enum Campos
			PRRCODIGO = 0
			ALTCODIGO = 1
			PRRRESPUESTA = 2
			INCCODIGO = 3
			PRGCODIGO = 4
			AUDPRGCREACION = 5
			AUDPRGMODIF = 6
			AUDEQPCREACION = 7
			AUDEQPMODIF = 8
			AUDFECCREACION = 9
			AUDFECMODIF = 10
			AUDUSUCREACION = 11
			AUDUSUMODIF = 12
			AUDROLCREACION = 13
			AUDROLMODIF = 14
		End Enum
		#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

		Public Sub Insertar(ByVal pCCOENCUESTAINCIDENCIA_BE As CCOENCUESTAINCIDENCIA_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(14) {}
				arrParam(0) = New DB2Parameter("P_INTPRRCODIGO", DB2Type.INTEGER)
				arrParam(0).Value = pCCOENCUESTAINCIDENCIA_BE.PropPRRCODIGO
				arrParam(1) = New DB2Parameter("P_SMLALTCODIGO", DB2Type.SMALLINT)
				arrParam(1).Value = pCCOENCUESTAINCIDENCIA_BE.PropALTCODIGO
				arrParam(2) = New DB2Parameter("P_VCHPRRRESPUESTA", DB2Type.VARCHAR, 100)
				arrParam(2).Value = pCCOENCUESTAINCIDENCIA_BE.PropPRRRESPUESTA
				arrParam(3) = New DB2Parameter("P_INTINCCODIGO", DB2Type.INTEGER)
				arrParam(3).Value = pCCOENCUESTAINCIDENCIA_BE.PropINCCODIGO
				arrParam(4) = New DB2Parameter("P_SMLPRGCODIGO", DB2Type.INTEGER)
				arrParam(4).Value = pCCOENCUESTAINCIDENCIA_BE.PropPRGCODIGO
				arrParam(5) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VARCHAR, 150)
				arrParam(5).Value = pCCOENCUESTAINCIDENCIA_BE.PropAUDPRGCREACION
				arrParam(6) = New DB2Parameter("P_VCHAUDPRGMODIF", DB2Type.VARCHAR, 150)
				arrParam(6).Value = pCCOENCUESTAINCIDENCIA_BE.PropAUDPRGMODIF
				arrParam(7) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VARCHAR, 60)
				arrParam(7).Value = pCCOENCUESTAINCIDENCIA_BE.PropAUDEQPCREACION
				arrParam(8) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VARCHAR, 60)
				arrParam(8).Value = pCCOENCUESTAINCIDENCIA_BE.PropAUDEQPMODIF
				arrParam(9) = New DB2Parameter("P_DTMAUDFECCREACION", DB2Type.TIMESTAMP)
				arrParam(9).Value = pCCOENCUESTAINCIDENCIA_BE.PropAUDFECCREACION
				arrParam(10) = New DB2Parameter("P_DTMAUDFECMODIF", DB2Type.TIMESTAMP)
				arrParam(10).Value = pCCOENCUESTAINCIDENCIA_BE.PropAUDFECMODIF
				arrParam(11) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VARCHAR, 10)
				arrParam(11).Value = pCCOENCUESTAINCIDENCIA_BE.PropAUDUSUCREACION
				arrParam(12) = New DB2Parameter("P_VCHAUDUSUMODIF", DB2Type.VARCHAR, 10)
				arrParam(12).Value = pCCOENCUESTAINCIDENCIA_BE.PropAUDUSUMODIF
				arrParam(13) = New DB2Parameter("P_INTAUDROLCREACION", DB2Type.INTEGER)
				arrParam(13).Value = pCCOENCUESTAINCIDENCIA_BE.PropAUDROLCREACION
				arrParam(14) = New DB2Parameter("P_INTAUDROLMODIF", DB2Type.INTEGER)
				arrParam(14).Value = pCCOENCUESTAINCIDENCIA_BE.PropAUDROLMODIF
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOENCUESTAINCIDENCIA_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pCCOENCUESTAINCIDENCIA_BE As CCOENCUESTAINCIDENCIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(14) {}
                arrParam(0) = New DB2Parameter("P_INTPRRCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOENCUESTAINCIDENCIA_BE.PropPRRCODIGO
                arrParam(1) = New DB2Parameter("P_SMLALTCODIGO", DB2Type.SMALLINT)
                arrParam(1).Value = pCCOENCUESTAINCIDENCIA_BE.PropALTCODIGO
                arrParam(2) = New DB2Parameter("P_VCHPRRRESPUESTA", DB2Type.VARCHAR, 100)
                arrParam(2).Value = pCCOENCUESTAINCIDENCIA_BE.PropPRRRESPUESTA
                arrParam(3) = New DB2Parameter("P_INTINCCODIGO", DB2Type.INTEGER)
                arrParam(3).Value = pCCOENCUESTAINCIDENCIA_BE.PropINCCODIGO
                arrParam(4) = New DB2Parameter("P_SMLPRGCODIGO", DB2Type.INTEGER)
                arrParam(4).Value = pCCOENCUESTAINCIDENCIA_BE.PropPRGCODIGO
                arrParam(5) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VARCHAR, 150)
                arrParam(5).Value = pCCOENCUESTAINCIDENCIA_BE.PropAUDPRGCREACION
                arrParam(6) = New DB2Parameter("P_VCHAUDPRGMODIF", DB2Type.VARCHAR, 150)
                arrParam(6).Value = pCCOENCUESTAINCIDENCIA_BE.PropAUDPRGMODIF
                arrParam(7) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VARCHAR, 60)
                arrParam(7).Value = pCCOENCUESTAINCIDENCIA_BE.PropAUDEQPCREACION
                arrParam(8) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VARCHAR, 60)
                arrParam(8).Value = pCCOENCUESTAINCIDENCIA_BE.PropAUDEQPMODIF
                arrParam(9) = New DB2Parameter("P_DTMAUDFECCREACION", DB2Type.TIMESTAMP)
                arrParam(9).Value = pCCOENCUESTAINCIDENCIA_BE.PropAUDFECCREACION
                arrParam(10) = New DB2Parameter("P_DTMAUDFECMODIF", DB2Type.TIMESTAMP)
                arrParam(10).Value = pCCOENCUESTAINCIDENCIA_BE.PropAUDFECMODIF
                arrParam(11) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VARCHAR, 10)
                arrParam(11).Value = pCCOENCUESTAINCIDENCIA_BE.PropAUDUSUCREACION
                arrParam(12) = New DB2Parameter("P_VCHAUDUSUMODIF", DB2Type.VARCHAR, 10)
                arrParam(12).Value = pCCOENCUESTAINCIDENCIA_BE.PropAUDUSUMODIF
                arrParam(13) = New DB2Parameter("P_INTAUDROLCREACION", DB2Type.INTEGER)
                arrParam(13).Value = pCCOENCUESTAINCIDENCIA_BE.PropAUDROLCREACION
                arrParam(14) = New DB2Parameter("P_INTAUDROLMODIF", DB2Type.INTEGER)
                arrParam(14).Value = pCCOENCUESTAINCIDENCIA_BE.PropAUDROLMODIF
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOENCUESTAINCIDENCIA_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOENCUESTAINCIDENCIA_BE As CCOENCUESTAINCIDENCIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTPRRCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOENCUESTAINCIDENCIA_BE.PropPRRCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOENCUESTAINCIDENCIA_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOENCUESTAINCIDENCIA_BE As CCOENCUESTAINCIDENCIA_BE) As CCOENCUESTAINCIDENCIA_BE
            Dim oCCOENCUESTAINCIDENCIA_BE As New CCOENCUESTAINCIDENCIA_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTPRRCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOENCUESTAINCIDENCIA_BE.PropPRRCODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOENCUESTAINCIDENCIA_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.PRRCODIGO) Then oCCOENCUESTAINCIDENCIA_BE.PropPRRCODIGO = Nothing Else oCCOENCUESTAINCIDENCIA_BE.PropPRRCODIGO = CType(oDataReader(Campos.PRRCODIGO), Int32)
                    If oDataReader.IsDBNull(Campos.ALTCODIGO) Then oCCOENCUESTAINCIDENCIA_BE.PropALTCODIGO = Nothing Else oCCOENCUESTAINCIDENCIA_BE.PropALTCODIGO = CType(oDataReader(Campos.ALTCODIGO), Int16)
                    oCCOENCUESTAINCIDENCIA_BE.PropPRRRESPUESTA = IIf(oDataReader.IsDBNull(Campos.PRRRESPUESTA), "", oDataReader(Campos.PRRRESPUESTA))
                    If oDataReader.IsDBNull(Campos.INCCODIGO) Then oCCOENCUESTAINCIDENCIA_BE.PropINCCODIGO = Nothing Else oCCOENCUESTAINCIDENCIA_BE.PropINCCODIGO = CType(oDataReader(Campos.INCCODIGO), Int32)
                    If oDataReader.IsDBNull(Campos.PRGCODIGO) Then oCCOENCUESTAINCIDENCIA_BE.PropPRGCODIGO = Nothing Else oCCOENCUESTAINCIDENCIA_BE.PropPRGCODIGO = CType(oDataReader(Campos.PRGCODIGO), Int32)
                    oCCOENCUESTAINCIDENCIA_BE.PropAUDPRGCREACION = IIf(oDataReader.IsDBNull(Campos.AUDPRGCREACION), "", oDataReader(Campos.AUDPRGCREACION))
                    oCCOENCUESTAINCIDENCIA_BE.PropAUDPRGMODIF = IIf(oDataReader.IsDBNull(Campos.AUDPRGMODIF), "", oDataReader(Campos.AUDPRGMODIF))
                    oCCOENCUESTAINCIDENCIA_BE.PropAUDEQPCREACION = IIf(oDataReader.IsDBNull(Campos.AUDEQPCREACION), "", oDataReader(Campos.AUDEQPCREACION))
                    oCCOENCUESTAINCIDENCIA_BE.PropAUDEQPMODIF = IIf(oDataReader.IsDBNull(Campos.AUDEQPMODIF), "", oDataReader(Campos.AUDEQPMODIF))
                    If oDataReader.IsDBNull(Campos.AUDFECCREACION) Then oCCOENCUESTAINCIDENCIA_BE.PropAUDFECCREACION = Nothing Else oCCOENCUESTAINCIDENCIA_BE.PropAUDFECCREACION = CType(oDataReader(Campos.AUDFECCREACION), DateTime)
                    If oDataReader.IsDBNull(Campos.AUDFECMODIF) Then oCCOENCUESTAINCIDENCIA_BE.PropAUDFECMODIF = Nothing Else oCCOENCUESTAINCIDENCIA_BE.PropAUDFECMODIF = CType(oDataReader(Campos.AUDFECMODIF), DateTime)
                    oCCOENCUESTAINCIDENCIA_BE.PropAUDUSUCREACION = IIf(oDataReader.IsDBNull(Campos.AUDUSUCREACION), "", oDataReader(Campos.AUDUSUCREACION))
                    oCCOENCUESTAINCIDENCIA_BE.PropAUDUSUMODIF = IIf(oDataReader.IsDBNull(Campos.AUDUSUMODIF), "", oDataReader(Campos.AUDUSUMODIF))
                    If oDataReader.IsDBNull(Campos.AUDROLCREACION) Then oCCOENCUESTAINCIDENCIA_BE.PropAUDROLCREACION = Nothing Else oCCOENCUESTAINCIDENCIA_BE.PropAUDROLCREACION = CType(oDataReader(Campos.AUDROLCREACION), Int32)
                    If oDataReader.IsDBNull(Campos.AUDROLMODIF) Then oCCOENCUESTAINCIDENCIA_BE.PropAUDROLMODIF = Nothing Else oCCOENCUESTAINCIDENCIA_BE.PropAUDROLMODIF = CType(oDataReader(Campos.AUDROLMODIF), Int32)
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oCCOENCUESTAINCIDENCIA_BE
        End Function


	End Class
End Namespace
