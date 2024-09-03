Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class CCOMENSAJE_DL
		Private cnDB2 As DB2Connection

		#Region "Numerador"
		Public Enum Campos
			MSJCODIGO = 0
			MSJFECCREACION = 1
			MSJTITULO = 2
			MSJCUERPO = 3
			MSJFECCADUCIDAD = 4
			MSJESTADO = 5
			AUDPRGCREACION = 6
			AUDEQPCREACION = 7
			AUDFECCREACION = 8
			AUDUSUCREACION = 9
			AUDROLCREACION = 10
		End Enum
		#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

		Public Sub Insertar(ByVal pCCOMENSAJE_BE As CCOMENSAJE_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(10) {}
				arrParam(0) = New DB2Parameter("P_INTMSJCODIGO", DB2Type.INTEGER)
				arrParam(0).Value = pCCOMENSAJE_BE.PropMSJCODIGO
				arrParam(1) = New DB2Parameter("P_DTMMSJFECCREACION", DB2Type.TIMESTAMP)
				arrParam(1).Value = pCCOMENSAJE_BE.PropMSJFECCREACION
				arrParam(2) = New DB2Parameter("P_VCHMSJTITULO", DB2Type.VARCHAR, 30)
				arrParam(2).Value = pCCOMENSAJE_BE.PropMSJTITULO
				arrParam(3) = New DB2Parameter("P_VCHMSJCUERPO", DB2Type.VARCHAR, 250)
				arrParam(3).Value = pCCOMENSAJE_BE.PropMSJCUERPO
				arrParam(4) = New DB2Parameter("P_DTMMSJFECCADUCIDAD", DB2Type.TIMESTAMP)
				arrParam(4).Value = pCCOMENSAJE_BE.PropMSJFECCADUCIDAD
				arrParam(5) = New DB2Parameter("P_INTMSJESTADO", DB2Type.INTEGER)
				arrParam(5).Value = pCCOMENSAJE_BE.PropMSJESTADO
				arrParam(6) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VARCHAR, 150)
				arrParam(6).Value = pCCOMENSAJE_BE.PropAUDPRGCREACION
				arrParam(7) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VARCHAR, 60)
				arrParam(7).Value = pCCOMENSAJE_BE.PropAUDEQPCREACION
				arrParam(8) = New DB2Parameter("P_DTMAUDFECCREACION", DB2Type.TIMESTAMP)
				arrParam(8).Value = pCCOMENSAJE_BE.PropAUDFECCREACION
				arrParam(9) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VARCHAR, 10)
				arrParam(9).Value = pCCOMENSAJE_BE.PropAUDUSUCREACION
				arrParam(10) = New DB2Parameter("P_INTAUDROLCREACION", DB2Type.INTEGER)
				arrParam(10).Value = pCCOMENSAJE_BE.PropAUDROLCREACION
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOMENSAJE_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pCCOMENSAJE_BE As CCOMENSAJE_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(10) {}
                arrParam(0) = New DB2Parameter("P_INTMSJCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOMENSAJE_BE.PropMSJCODIGO
                arrParam(1) = New DB2Parameter("P_DTMMSJFECCREACION", DB2Type.TIMESTAMP)
                arrParam(1).Value = pCCOMENSAJE_BE.PropMSJFECCREACION
                arrParam(2) = New DB2Parameter("P_VCHMSJTITULO", DB2Type.VARCHAR, 30)
                arrParam(2).Value = pCCOMENSAJE_BE.PropMSJTITULO
                arrParam(3) = New DB2Parameter("P_VCHMSJCUERPO", DB2Type.VARCHAR, 250)
                arrParam(3).Value = pCCOMENSAJE_BE.PropMSJCUERPO
                arrParam(4) = New DB2Parameter("P_DTMMSJFECCADUCIDAD", DB2Type.TIMESTAMP)
                arrParam(4).Value = pCCOMENSAJE_BE.PropMSJFECCADUCIDAD
                arrParam(5) = New DB2Parameter("P_INTMSJESTADO", DB2Type.INTEGER)
                arrParam(5).Value = pCCOMENSAJE_BE.PropMSJESTADO
                arrParam(6) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VARCHAR, 150)
                arrParam(6).Value = pCCOMENSAJE_BE.PropAUDPRGCREACION
                arrParam(7) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VARCHAR, 60)
                arrParam(7).Value = pCCOMENSAJE_BE.PropAUDEQPCREACION
                arrParam(8) = New DB2Parameter("P_DTMAUDFECCREACION", DB2Type.TIMESTAMP)
                arrParam(8).Value = pCCOMENSAJE_BE.PropAUDFECCREACION
                arrParam(9) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VARCHAR, 10)
                arrParam(9).Value = pCCOMENSAJE_BE.PropAUDUSUCREACION
                arrParam(10) = New DB2Parameter("P_INTAUDROLCREACION", DB2Type.INTEGER)
                arrParam(10).Value = pCCOMENSAJE_BE.PropAUDROLCREACION
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOMENSAJE_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOMENSAJE_BE As CCOMENSAJE_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTMSJCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOMENSAJE_BE.PropMSJCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOMENSAJE_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOMENSAJE_BE As CCOMENSAJE_BE) As CCOMENSAJE_BE
            Dim oCCOMENSAJE_BE As New CCOMENSAJE_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTMSJCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOMENSAJE_BE.PropMSJCODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOMENSAJE_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.MSJCODIGO) Then oCCOMENSAJE_BE.PropMSJCODIGO = Nothing Else oCCOMENSAJE_BE.PropMSJCODIGO = CType(oDataReader(Campos.MSJCODIGO), Int32)
                    If oDataReader.IsDBNull(Campos.MSJFECCREACION) Then oCCOMENSAJE_BE.PropMSJFECCREACION = Nothing Else oCCOMENSAJE_BE.PropMSJFECCREACION = CType(oDataReader(Campos.MSJFECCREACION), DateTime)
                    oCCOMENSAJE_BE.PropMSJTITULO = IIf(oDataReader.IsDBNull(Campos.MSJTITULO), "", oDataReader(Campos.MSJTITULO))
                    oCCOMENSAJE_BE.PropMSJCUERPO = IIf(oDataReader.IsDBNull(Campos.MSJCUERPO), "", oDataReader(Campos.MSJCUERPO))
                    If oDataReader.IsDBNull(Campos.MSJFECCADUCIDAD) Then oCCOMENSAJE_BE.PropMSJFECCADUCIDAD = Nothing Else oCCOMENSAJE_BE.PropMSJFECCADUCIDAD = CType(oDataReader(Campos.MSJFECCADUCIDAD), DateTime)
                    If oDataReader.IsDBNull(Campos.MSJESTADO) Then oCCOMENSAJE_BE.PropMSJESTADO = Nothing Else oCCOMENSAJE_BE.PropMSJESTADO = CType(oDataReader(Campos.MSJESTADO), Int32)
                    oCCOMENSAJE_BE.PropAUDPRGCREACION = IIf(oDataReader.IsDBNull(Campos.AUDPRGCREACION), "", oDataReader(Campos.AUDPRGCREACION))
                    oCCOMENSAJE_BE.PropAUDEQPCREACION = IIf(oDataReader.IsDBNull(Campos.AUDEQPCREACION), "", oDataReader(Campos.AUDEQPCREACION))
                    If oDataReader.IsDBNull(Campos.AUDFECCREACION) Then oCCOMENSAJE_BE.PropAUDFECCREACION = Nothing Else oCCOMENSAJE_BE.PropAUDFECCREACION = CType(oDataReader(Campos.AUDFECCREACION), DateTime)
                    oCCOMENSAJE_BE.PropAUDUSUCREACION = IIf(oDataReader.IsDBNull(Campos.AUDUSUCREACION), "", oDataReader(Campos.AUDUSUCREACION))
                    If oDataReader.IsDBNull(Campos.AUDROLCREACION) Then oCCOMENSAJE_BE.PropAUDROLCREACION = Nothing Else oCCOMENSAJE_BE.PropAUDROLCREACION = CType(oDataReader(Campos.AUDROLCREACION), Int32)
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oCCOMENSAJE_BE
        End Function


	End Class
End Namespace
