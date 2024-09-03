Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class SCUROL_DL
		Private cnDB2 As DB2Connection

		#Region "Numerador"
		Public Enum Campos
			ROLCODIGO = 0
			ROLDESCRIP = 1
			ROLABREV = 2
			ROLOBSERV = 3
			ESTADO = 4
			AUDUSUCREACION = 5
			AUDFECCREACION = 6
			AUDUSUMODIF = 7
			AUDFECMODIF = 8
			AUDEQUIPO = 9
		End Enum
		#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

		Public Sub Insertar(ByVal pSCUROL_BE As SCUROL_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(9) {}
				arrParam(0) = New DB2Parameter("P_INTROLCODIGO", DB2Type.INTEGER)
				arrParam(0).Value = pSCUROL_BE.PropROLCODIGO
				arrParam(1) = New DB2Parameter("P_VCHROLDESCRIP", DB2Type.VARCHAR, 80)
				arrParam(1).Value = pSCUROL_BE.PropROLDESCRIP
				arrParam(2) = New DB2Parameter("P_VCHROLABREV", DB2Type.VARCHAR, 20)
				arrParam(2).Value = pSCUROL_BE.PropROLABREV
				arrParam(3) = New DB2Parameter("P_VCHROLOBSERV", DB2Type.VARCHAR, 100)
				arrParam(3).Value = pSCUROL_BE.PropROLOBSERV
				arrParam(4) = New DB2Parameter("P_VCHESTADO", DB2Type.VARCHAR, 2)
				arrParam(4).Value = pSCUROL_BE.PropESTADO
				arrParam(5) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VARCHAR, 10)
				arrParam(5).Value = pSCUROL_BE.PropAUDUSUCREACION
				arrParam(6) = New DB2Parameter("P_TMSAUDFECCREACION", DB2Type.TIMESTAMP)
				arrParam(6).Value = pSCUROL_BE.PropAUDFECCREACION
				arrParam(7) = New DB2Parameter("P_VCHAUDUSUMODIF", DB2Type.VARCHAR, 10)
				arrParam(7).Value = pSCUROL_BE.PropAUDUSUMODIF
				arrParam(8) = New DB2Parameter("P_TMSAUDFECMODIF", DB2Type.TIMESTAMP)
				arrParam(8).Value = pSCUROL_BE.PropAUDFECMODIF
				arrParam(9) = New DB2Parameter("P_VCHAUDEQUIPO", DB2Type.VARCHAR, 20)
				arrParam(9).Value = pSCUROL_BE.PropAUDEQUIPO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "SCUROL_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pSCUROL_BE As SCUROL_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(9) {}
                arrParam(0) = New DB2Parameter("P_INTROLCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pSCUROL_BE.PropROLCODIGO
                arrParam(1) = New DB2Parameter("P_VCHROLDESCRIP", DB2Type.VARCHAR, 80)
                arrParam(1).Value = pSCUROL_BE.PropROLDESCRIP
                arrParam(2) = New DB2Parameter("P_VCHROLABREV", DB2Type.VARCHAR, 20)
                arrParam(2).Value = pSCUROL_BE.PropROLABREV
                arrParam(3) = New DB2Parameter("P_VCHROLOBSERV", DB2Type.VARCHAR, 100)
                arrParam(3).Value = pSCUROL_BE.PropROLOBSERV
                arrParam(4) = New DB2Parameter("P_VCHESTADO", DB2Type.VARCHAR, 2)
                arrParam(4).Value = pSCUROL_BE.PropESTADO
                arrParam(5) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VARCHAR, 10)
                arrParam(5).Value = pSCUROL_BE.PropAUDUSUCREACION
                arrParam(6) = New DB2Parameter("P_TMSAUDFECCREACION", DB2Type.TIMESTAMP)
                arrParam(6).Value = pSCUROL_BE.PropAUDFECCREACION
                arrParam(7) = New DB2Parameter("P_VCHAUDUSUMODIF", DB2Type.VARCHAR, 10)
                arrParam(7).Value = pSCUROL_BE.PropAUDUSUMODIF
                arrParam(8) = New DB2Parameter("P_TMSAUDFECMODIF", DB2Type.TIMESTAMP)
                arrParam(8).Value = pSCUROL_BE.PropAUDFECMODIF
                arrParam(9) = New DB2Parameter("P_VCHAUDEQUIPO", DB2Type.VARCHAR, 20)
                arrParam(9).Value = pSCUROL_BE.PropAUDEQUIPO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "SCUROL_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pSCUROL_BE As SCUROL_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTROLCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pSCUROL_BE.PropROLCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "SCUROL_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pSCUROL_BE As SCUROL_BE) As SCUROL_BE
            Dim oSCUROL_BE As New SCUROL_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTROLCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pSCUROL_BE.PropROLCODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "SCUROL_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.ROLCODIGO) Then oSCUROL_BE.PropROLCODIGO = Nothing Else oSCUROL_BE.PropROLCODIGO = CType(oDataReader(Campos.ROLCODIGO), Int32)
                    oSCUROL_BE.PropROLDESCRIP = IIf(oDataReader.IsDBNull(Campos.ROLDESCRIP), "", oDataReader(Campos.ROLDESCRIP))
                    oSCUROL_BE.PropROLABREV = IIf(oDataReader.IsDBNull(Campos.ROLABREV), "", oDataReader(Campos.ROLABREV))
                    oSCUROL_BE.PropROLOBSERV = IIf(oDataReader.IsDBNull(Campos.ROLOBSERV), "", oDataReader(Campos.ROLOBSERV))
                    oSCUROL_BE.PropESTADO = IIf(oDataReader.IsDBNull(Campos.ESTADO), "", oDataReader(Campos.ESTADO))
                    oSCUROL_BE.PropAUDUSUCREACION = IIf(oDataReader.IsDBNull(Campos.AUDUSUCREACION), "", oDataReader(Campos.AUDUSUCREACION))
                    If oDataReader.IsDBNull(Campos.AUDFECCREACION) Then oSCUROL_BE.PropAUDFECCREACION = Nothing Else oSCUROL_BE.PropAUDFECCREACION = CType(oDataReader(Campos.AUDFECCREACION), DateTime)
                    oSCUROL_BE.PropAUDUSUMODIF = IIf(oDataReader.IsDBNull(Campos.AUDUSUMODIF), "", oDataReader(Campos.AUDUSUMODIF))
                    If oDataReader.IsDBNull(Campos.AUDFECMODIF) Then oSCUROL_BE.PropAUDFECMODIF = Nothing Else oSCUROL_BE.PropAUDFECMODIF = CType(oDataReader(Campos.AUDFECMODIF), DateTime)
                    oSCUROL_BE.PropAUDEQUIPO = IIf(oDataReader.IsDBNull(Campos.AUDEQUIPO), "", oDataReader(Campos.AUDEQUIPO))
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oSCUROL_BE
        End Function

        Public Function ListarCombo() As DataTable
            Dim dt As New DataTable
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                dt.Load(DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "SCUROL_LISTARCOMBO", arrParam))
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return dt
        End Function


        Public Function ListarComboDeriva(ByVal pTIPO As Integer) As DataTable
            Dim dt As New DataTable
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("pINTTIPO", DB2Type.Integer)
                arrParam(0).Value = pTIPO

                dt.Load(DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "SCUROL_LISTARCOMBO_DER", arrParam))
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return dt
        End Function


	End Class
End Namespace
