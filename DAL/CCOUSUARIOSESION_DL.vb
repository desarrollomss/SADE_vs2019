Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class CCOUSUARIOSESION_DL
		Private cnDB2 As DB2Connection

		#Region "Numerador"
		Public Enum Campos
			USUIDENTIFICADOR = 0
			USUARIO = 1
			ESTADOSESION = 2
			ULTIMO = 3
			ROLCODIGO = 4
			AUDFECMODIF = 5
			AUDUSUMODIF = 6
			AUDPRGMODIF = 7
			AUDEQPMODIF = 8
			AUDFECCREACION = 9
			AUDUSUCREACION = 10
			AUDPRGCREACION = 11
			AUDEQPCREACION = 12
		End Enum
		#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

		Public Sub Insertar(ByVal pCCOUSUARIOSESION_BE As CCOUSUARIOSESION_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(12) {}
				arrParam(0) = New DB2Parameter("P_INTUSUIDENTIFICADOR", DB2Type.INTEGER)
				arrParam(0).Value = pCCOUSUARIOSESION_BE.PropUSUIDENTIFICADOR
				arrParam(1) = New DB2Parameter("P_VCHUSUARIO", DB2Type.VARCHAR, 50)
				arrParam(1).Value = pCCOUSUARIOSESION_BE.PropUSUARIO
				arrParam(2) = New DB2Parameter("P_SMLESTADOSESION", DB2Type.SMALLINT)
				arrParam(2).Value = pCCOUSUARIOSESION_BE.PropESTADOSESION
				arrParam(3) = New DB2Parameter("P_SMLULTIMO", DB2Type.SMALLINT)
				arrParam(3).Value = pCCOUSUARIOSESION_BE.PropULTIMO
				arrParam(4) = New DB2Parameter("P_INTROLCODIGO", DB2Type.INTEGER)
				arrParam(4).Value = pCCOUSUARIOSESION_BE.PropROLCODIGO
				arrParam(5) = New DB2Parameter("P_DTMAUDFECMODIF", DB2Type.TIMESTAMP)
				arrParam(5).Value = pCCOUSUARIOSESION_BE.PropAUDFECMODIF
				arrParam(6) = New DB2Parameter("P_VCHAUDUSUMODIF", DB2Type.VARCHAR, 15)
				arrParam(6).Value = pCCOUSUARIOSESION_BE.PropAUDUSUMODIF
				arrParam(7) = New DB2Parameter("P_VCHAUDPRGMODIF", DB2Type.VARCHAR, 150)
				arrParam(7).Value = pCCOUSUARIOSESION_BE.PropAUDPRGMODIF
				arrParam(8) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VARCHAR, 60)
				arrParam(8).Value = pCCOUSUARIOSESION_BE.PropAUDEQPMODIF
				arrParam(9) = New DB2Parameter("P_DTMAUDFECCREACION", DB2Type.TIMESTAMP)
				arrParam(9).Value = pCCOUSUARIOSESION_BE.PropAUDFECCREACION
				arrParam(10) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VARCHAR, 15)
				arrParam(10).Value = pCCOUSUARIOSESION_BE.PropAUDUSUCREACION
				arrParam(11) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VARCHAR, 150)
				arrParam(11).Value = pCCOUSUARIOSESION_BE.PropAUDPRGCREACION
				arrParam(12) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VARCHAR, 60)
				arrParam(12).Value = pCCOUSUARIOSESION_BE.PropAUDEQPCREACION
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOUSUARIOSESION_INSERTAR", arrParam)
			Catch ex As Exception
				Throw ex
			Finally
				If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCOUSUARIOSESION_BE As CCOUSUARIOSESION_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(12) {}
				arrParam(0) = New DB2Parameter("P_INTUSUIDENTIFICADOR", DB2Type.INTEGER)
				arrParam(0).Value = pCCOUSUARIOSESION_BE.PropUSUIDENTIFICADOR
				arrParam(1) = New DB2Parameter("P_VCHUSUARIO", DB2Type.VARCHAR, 50)
				arrParam(1).Value = pCCOUSUARIOSESION_BE.PropUSUARIO
				arrParam(2) = New DB2Parameter("P_SMLESTADOSESION", DB2Type.SMALLINT)
				arrParam(2).Value = pCCOUSUARIOSESION_BE.PropESTADOSESION
				arrParam(3) = New DB2Parameter("P_SMLULTIMO", DB2Type.SMALLINT)
				arrParam(3).Value = pCCOUSUARIOSESION_BE.PropULTIMO
				arrParam(4) = New DB2Parameter("P_INTROLCODIGO", DB2Type.INTEGER)
				arrParam(4).Value = pCCOUSUARIOSESION_BE.PropROLCODIGO
				arrParam(5) = New DB2Parameter("P_DTMAUDFECMODIF", DB2Type.TIMESTAMP)
				arrParam(5).Value = pCCOUSUARIOSESION_BE.PropAUDFECMODIF
				arrParam(6) = New DB2Parameter("P_VCHAUDUSUMODIF", DB2Type.VARCHAR, 15)
				arrParam(6).Value = pCCOUSUARIOSESION_BE.PropAUDUSUMODIF
				arrParam(7) = New DB2Parameter("P_VCHAUDPRGMODIF", DB2Type.VARCHAR, 150)
				arrParam(7).Value = pCCOUSUARIOSESION_BE.PropAUDPRGMODIF
				arrParam(8) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VARCHAR, 60)
				arrParam(8).Value = pCCOUSUARIOSESION_BE.PropAUDEQPMODIF
				arrParam(9) = New DB2Parameter("P_DTMAUDFECCREACION", DB2Type.TIMESTAMP)
				arrParam(9).Value = pCCOUSUARIOSESION_BE.PropAUDFECCREACION
				arrParam(10) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VARCHAR, 15)
				arrParam(10).Value = pCCOUSUARIOSESION_BE.PropAUDUSUCREACION
				arrParam(11) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VARCHAR, 150)
				arrParam(11).Value = pCCOUSUARIOSESION_BE.PropAUDPRGCREACION
				arrParam(12) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VARCHAR, 60)
				arrParam(12).Value = pCCOUSUARIOSESION_BE.PropAUDEQPCREACION
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOUSUARIOSESION_ACTUALIZAR", arrParam)
			Catch ex As Exception
				Throw ex
			Finally
				If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCOUSUARIOSESION_BE As CCOUSUARIOSESION_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
				arrParam(0) = New DB2Parameter("P_INTUSUIDENTIFICADOR", DB2Type.INTEGER)
				arrParam(0).Value = pCCOUSUARIOSESION_BE.PropUSUIDENTIFICADOR
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOUSUARIOSESION_ELIMINAR", arrParam)
			Catch ex As Exception
				Throw ex
			Finally
				If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
			End Try
		End Sub

		Public Function ListarKey(ByVal pCCOUSUARIOSESION_BE As CCOUSUARIOSESION_BE) As CCOUSUARIOSESION_BE
			Dim oCCOUSUARIOSESION_BE As New CCOUSUARIOSESION_BE
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_VCHINTUSUARIO", DB2Type.VarChar, 50)
                arrParam(0).Value = pCCOUSUARIOSESION_BE.PropUSUARIO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOUSUARIOSESION_LISTARKEY", arrParam)
				Do While oDataReader.Read()
					If oDataReader.IsDBNull(Campos.USUIDENTIFICADOR) Then oCCOUSUARIOSESION_BE.PropUSUIDENTIFICADOR = Nothing Else oCCOUSUARIOSESION_BE.PropUSUIDENTIFICADOR = CType(oDataReader(Campos.USUIDENTIFICADOR), Int32)
					oCCOUSUARIOSESION_BE.PropUSUARIO = IIf(oDataReader.IsDBNull(Campos.USUARIO), "", oDataReader(Campos.USUARIO))
					If oDataReader.IsDBNull(Campos.ESTADOSESION) Then oCCOUSUARIOSESION_BE.PropESTADOSESION = Nothing Else oCCOUSUARIOSESION_BE.PropESTADOSESION = CType(oDataReader(Campos.ESTADOSESION), Int16)
					If oDataReader.IsDBNull(Campos.ULTIMO) Then oCCOUSUARIOSESION_BE.PropULTIMO = Nothing Else oCCOUSUARIOSESION_BE.PropULTIMO = CType(oDataReader(Campos.ULTIMO), Int16)
					If oDataReader.IsDBNull(Campos.ROLCODIGO) Then oCCOUSUARIOSESION_BE.PropROLCODIGO = Nothing Else oCCOUSUARIOSESION_BE.PropROLCODIGO = CType(oDataReader(Campos.ROLCODIGO), Int32)
					If oDataReader.IsDBNull(Campos.AUDFECMODIF) Then oCCOUSUARIOSESION_BE.PropAUDFECMODIF = Nothing Else oCCOUSUARIOSESION_BE.PropAUDFECMODIF = CType(oDataReader(Campos.AUDFECMODIF), DateTime)
					oCCOUSUARIOSESION_BE.PropAUDUSUMODIF = IIf(oDataReader.IsDBNull(Campos.AUDUSUMODIF), "", oDataReader(Campos.AUDUSUMODIF))
					oCCOUSUARIOSESION_BE.PropAUDPRGMODIF = IIf(oDataReader.IsDBNull(Campos.AUDPRGMODIF), "", oDataReader(Campos.AUDPRGMODIF))
					oCCOUSUARIOSESION_BE.PropAUDEQPMODIF = IIf(oDataReader.IsDBNull(Campos.AUDEQPMODIF), "", oDataReader(Campos.AUDEQPMODIF))
					If oDataReader.IsDBNull(Campos.AUDFECCREACION) Then oCCOUSUARIOSESION_BE.PropAUDFECCREACION = Nothing Else oCCOUSUARIOSESION_BE.PropAUDFECCREACION = CType(oDataReader(Campos.AUDFECCREACION), DateTime)
					oCCOUSUARIOSESION_BE.PropAUDUSUCREACION = IIf(oDataReader.IsDBNull(Campos.AUDUSUCREACION), "", oDataReader(Campos.AUDUSUCREACION))
					oCCOUSUARIOSESION_BE.PropAUDPRGCREACION = IIf(oDataReader.IsDBNull(Campos.AUDPRGCREACION), "", oDataReader(Campos.AUDPRGCREACION))
					oCCOUSUARIOSESION_BE.PropAUDEQPCREACION = IIf(oDataReader.IsDBNull(Campos.AUDEQPCREACION), "", oDataReader(Campos.AUDEQPCREACION))
					Exit Do
				Loop
			Catch ex As Exception
				Throw ex
			Finally
				If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
			End Try
			Return oCCOUSUARIOSESION_BE
		End Function

        Public Sub EliminarUsuario(ByVal pVCHUSUARIO As String)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_VCHUSUARIO", DB2Type.VarChar, 50)
                arrParam(0).Value = pVCHUSUARIO

                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOUSUARIOSESION_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub
        Public Sub AgregarUsuario(ByVal pVCHUSUARIO As String)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_VCHUSUARIO", DB2Type.VarChar, 50)
                arrParam(0).Value = pVCHUSUARIO

                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOUSUARIOSESION_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub AsignaRol(ByVal pINTROLCODIGO As Int16, ByVal pVCHUSUARIO As String)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
                arrParam(0) = New DB2Parameter("P_VCHUSUARIO", DB2Type.VarChar, 50)
                arrParam(0).Value = pVCHUSUARIO
                arrParam(1) = New DB2Parameter("P_INTROLCODIGO", DB2Type.Integer)
                arrParam(1).Value = pINTROLCODIGO

                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOUSUARIOSESION_ASIGNAROL", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub


        Public Function Busqueda(ByVal pUsuario As String, ByVal pRolUsuario As Integer, ByVal pUsuarioEst As Integer) As DataTable
            Dim dt As DataTable = New DataTable
            Try

                Dim arrParam() As DB2Parameter = New DB2Parameter(2) {}
                arrParam(0) = New DB2Parameter("P_VCHUSUARIO", DB2Type.VarChar, 50)
                arrParam(0).Value = pUsuario
                arrParam(1) = New DB2Parameter("P_INTROLCODIGO", DB2Type.Integer)
                arrParam(1).Value = pRolUsuario
                arrParam(2) = New DB2Parameter("P_SMLESTADOSESION", DB2Type.Integer)
                arrParam(2).Value = pUsuarioEst
                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOUSUARIOSESION_BUSQUEDA", arrParam)
                    dt.Load(dataReader)
                End Using
            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function

        Public Sub InsertarUsuario(ByVal pCCOUSUARIOSESION_BE As CCOUSUARIOSESION_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(8) {}

                arrParam(0) = New DB2Parameter("P_INTUSUIDENTIFICADOR", DB2Type.Integer)
                arrParam(0).Value = pCCOUSUARIOSESION_BE.PropUSUIDENTIFICADOR
                arrParam(1) = New DB2Parameter("P_VCHUSUARIO", DB2Type.VarChar, 50)
                arrParam(1).Value = pCCOUSUARIOSESION_BE.PropUSUARIO
                arrParam(2) = New DB2Parameter("P_SMLESTADOSESION", DB2Type.SmallInt)
                arrParam(2).Value = pCCOUSUARIOSESION_BE.PropESTADOSESION
                arrParam(3) = New DB2Parameter("P_SMLULTIMO", DB2Type.SmallInt)
                arrParam(3).Value = pCCOUSUARIOSESION_BE.PropULTIMO
                arrParam(4) = New DB2Parameter("P_INTROLCODIGO", DB2Type.Integer)
                arrParam(4).Value = pCCOUSUARIOSESION_BE.PropROLCODIGO
                arrParam(5) = New DB2Parameter("P_DTMAUDFECCREACION", DB2Type.Timestamp)
                arrParam(5).Value = pCCOUSUARIOSESION_BE.PropAUDFECCREACION
                arrParam(6) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VarChar, 15)
                arrParam(6).Value = pCCOUSUARIOSESION_BE.PropAUDUSUCREACION
                arrParam(7) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VarChar, 150)
                arrParam(7).Value = pCCOUSUARIOSESION_BE.PropAUDPRGCREACION
                arrParam(8) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VarChar, 60)
                arrParam(8).Value = pCCOUSUARIOSESION_BE.PropAUDEQPCREACION
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOUSUARIOSESION_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub AsignaRol(ByVal pCCOUSUARIOSESION_BE As CCOUSUARIOSESION_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(8) {}
                arrParam(0) = New DB2Parameter("P_INTUSUIDENTIFICADOR", DB2Type.Integer)
                arrParam(0).Value = pCCOUSUARIOSESION_BE.PropUSUIDENTIFICADOR
                arrParam(1) = New DB2Parameter("P_VCHUSUARIO", DB2Type.VarChar, 50)
                arrParam(1).Value = pCCOUSUARIOSESION_BE.PropUSUARIO
                arrParam(2) = New DB2Parameter("P_SMLESTADOSESION", DB2Type.SmallInt)
                arrParam(2).Value = pCCOUSUARIOSESION_BE.PropESTADOSESION
                arrParam(3) = New DB2Parameter("P_SMLULTIMO", DB2Type.SmallInt)
                arrParam(3).Value = pCCOUSUARIOSESION_BE.PropULTIMO
                arrParam(4) = New DB2Parameter("P_INTROLCODIGO", DB2Type.Integer)
                arrParam(4).Value = pCCOUSUARIOSESION_BE.PropROLCODIGO
                arrParam(5) = New DB2Parameter("P_DTMAUDFECMODIF", DB2Type.Timestamp)
                arrParam(5).Value = pCCOUSUARIOSESION_BE.PropAUDFECMODIF
                arrParam(6) = New DB2Parameter("P_VCHAUDUSUMODIF", DB2Type.VarChar, 15)
                arrParam(6).Value = pCCOUSUARIOSESION_BE.PropAUDUSUMODIF
                arrParam(7) = New DB2Parameter("P_VCHAUDPRGCMODIF", DB2Type.VarChar, 150)
                arrParam(7).Value = pCCOUSUARIOSESION_BE.PropAUDPRGMODIF
                arrParam(8) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VarChar, 60)
                arrParam(8).Value = pCCOUSUARIOSESION_BE.PropAUDEQPMODIF
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOUSUARIOSESION_ASIGNAROL", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub



	End Class
End Namespace
