Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class CCOPARTEDIARIO_DL
		Private cnDB2 As DB2Connection

		#Region "Numerador"
		Public Enum Campos
			INCCODIGO = 0
			INCAGRESORES = 1
			INCCONSECUENCIA = 2
			OBJCODIGO = 3
			MODCODIGO = 4
			INTCODIGO = 5
			AUDPRGCREACION = 6
			AUDEQPCREACION = 7
			AUDFECCREACION = 8
			AUDUSUCREACION = 9
            AUDROLCREACION = 10
            PERCODOPERADOR = 11
            PERCODSERENO = 12
            FUGACODIGO = 13
            TURNOCODIGO = 14
            FINATENCION = 15
            TIPODELITO = 16
		End Enum
		#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

		Public Sub Insertar(ByVal pCCOPARTEDIARIO_BE As CCOPARTEDIARIO_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(10) {}
				arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.INTEGER)
				arrParam(0).Value = pCCOPARTEDIARIO_BE.PropINCCODIGO
				arrParam(1) = New DB2Parameter("P_INTINCAGRESORES", DB2Type.INTEGER)
				arrParam(1).Value = pCCOPARTEDIARIO_BE.PropINCAGRESORES
				arrParam(2) = New DB2Parameter("P_VCHINCCONSECUENCIA", DB2Type.VARCHAR, 250)
				arrParam(2).Value = pCCOPARTEDIARIO_BE.PropINCCONSECUENCIA
				arrParam(3) = New DB2Parameter("P_INTOBJCODIGO", DB2Type.INTEGER)
				arrParam(3).Value = pCCOPARTEDIARIO_BE.PropOBJCODIGO
				arrParam(4) = New DB2Parameter("P_INTMODCODIGO", DB2Type.INTEGER)
				arrParam(4).Value = pCCOPARTEDIARIO_BE.PropMODCODIGO
				arrParam(5) = New DB2Parameter("P_INTINTCODIGO", DB2Type.INTEGER)
				arrParam(5).Value = pCCOPARTEDIARIO_BE.PropINTCODIGO
				arrParam(6) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VARCHAR, 150)
				arrParam(6).Value = pCCOPARTEDIARIO_BE.PropAUDPRGCREACION
				arrParam(7) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VARCHAR, 60)
				arrParam(7).Value = pCCOPARTEDIARIO_BE.PropAUDEQPCREACION
				arrParam(8) = New DB2Parameter("P_DTMAUDFECCREACION", DB2Type.TIMESTAMP)
				arrParam(8).Value = pCCOPARTEDIARIO_BE.PropAUDFECCREACION
				arrParam(9) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VARCHAR, 10)
				arrParam(9).Value = pCCOPARTEDIARIO_BE.PropAUDUSUCREACION
				arrParam(10) = New DB2Parameter("P_INTAUDROLCREACION", DB2Type.INTEGER)
				arrParam(10).Value = pCCOPARTEDIARIO_BE.PropAUDROLCREACION
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOPARTEDIARIO_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pCCOPARTEDIARIO_BE As CCOPARTEDIARIO_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(10) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOPARTEDIARIO_BE.PropINCCODIGO
                arrParam(1) = New DB2Parameter("P_INTINCAGRESORES", DB2Type.INTEGER)
                arrParam(1).Value = pCCOPARTEDIARIO_BE.PropINCAGRESORES
                arrParam(2) = New DB2Parameter("P_VCHINCCONSECUENCIA", DB2Type.VARCHAR, 250)
                arrParam(2).Value = pCCOPARTEDIARIO_BE.PropINCCONSECUENCIA
                arrParam(3) = New DB2Parameter("P_INTOBJCODIGO", DB2Type.INTEGER)
                arrParam(3).Value = pCCOPARTEDIARIO_BE.PropOBJCODIGO
                arrParam(4) = New DB2Parameter("P_INTMODCODIGO", DB2Type.INTEGER)
                arrParam(4).Value = pCCOPARTEDIARIO_BE.PropMODCODIGO
                arrParam(5) = New DB2Parameter("P_INTINTCODIGO", DB2Type.INTEGER)
                arrParam(5).Value = pCCOPARTEDIARIO_BE.PropINTCODIGO
                arrParam(6) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VARCHAR, 150)
                arrParam(6).Value = pCCOPARTEDIARIO_BE.PropAUDPRGCREACION
                arrParam(7) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VARCHAR, 60)
                arrParam(7).Value = pCCOPARTEDIARIO_BE.PropAUDEQPCREACION
                arrParam(8) = New DB2Parameter("P_DTMAUDFECCREACION", DB2Type.TIMESTAMP)
                arrParam(8).Value = pCCOPARTEDIARIO_BE.PropAUDFECCREACION
                arrParam(9) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VARCHAR, 10)
                arrParam(9).Value = pCCOPARTEDIARIO_BE.PropAUDUSUCREACION
                arrParam(10) = New DB2Parameter("P_INTAUDROLCREACION", DB2Type.INTEGER)
                arrParam(10).Value = pCCOPARTEDIARIO_BE.PropAUDROLCREACION
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOPARTEDIARIO_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOPARTEDIARIO_BE As CCOPARTEDIARIO_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOPARTEDIARIO_BE.PropINCCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOPARTEDIARIO_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOPARTEDIARIO_BE As CCOPARTEDIARIO_BE) As CCOPARTEDIARIO_BE
            Dim oCCOPARTEDIARIO_BE As New CCOPARTEDIARIO_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOPARTEDIARIO_BE.PropINCCODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOPARTEDIARIO_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.INCCODIGO) Then oCCOPARTEDIARIO_BE.PropINCCODIGO = Nothing Else oCCOPARTEDIARIO_BE.PropINCCODIGO = CType(oDataReader(Campos.INCCODIGO), Int32)
                    If oDataReader.IsDBNull(Campos.INCAGRESORES) Then oCCOPARTEDIARIO_BE.PropINCAGRESORES = Nothing Else oCCOPARTEDIARIO_BE.PropINCAGRESORES = CType(oDataReader(Campos.INCAGRESORES), Int32)
                    oCCOPARTEDIARIO_BE.PropINCCONSECUENCIA = IIf(oDataReader.IsDBNull(Campos.INCCONSECUENCIA), "", oDataReader(Campos.INCCONSECUENCIA))
                    If oDataReader.IsDBNull(Campos.OBJCODIGO) Then oCCOPARTEDIARIO_BE.PropOBJCODIGO = Nothing Else oCCOPARTEDIARIO_BE.PropOBJCODIGO = CType(oDataReader(Campos.OBJCODIGO), Int32)
                    If oDataReader.IsDBNull(Campos.MODCODIGO) Then oCCOPARTEDIARIO_BE.PropMODCODIGO = Nothing Else oCCOPARTEDIARIO_BE.PropMODCODIGO = CType(oDataReader(Campos.MODCODIGO), Int32)
                    If oDataReader.IsDBNull(Campos.INTCODIGO) Then oCCOPARTEDIARIO_BE.PropINTCODIGO = Nothing Else oCCOPARTEDIARIO_BE.PropINTCODIGO = CType(oDataReader(Campos.INTCODIGO), Int32)
                    oCCOPARTEDIARIO_BE.PropAUDPRGCREACION = IIf(oDataReader.IsDBNull(Campos.AUDPRGCREACION), "", oDataReader(Campos.AUDPRGCREACION))
                    oCCOPARTEDIARIO_BE.PropAUDEQPCREACION = IIf(oDataReader.IsDBNull(Campos.AUDEQPCREACION), "", oDataReader(Campos.AUDEQPCREACION))
                    If oDataReader.IsDBNull(Campos.AUDFECCREACION) Then oCCOPARTEDIARIO_BE.PropAUDFECCREACION = Nothing Else oCCOPARTEDIARIO_BE.PropAUDFECCREACION = CType(oDataReader(Campos.AUDFECCREACION), DateTime)
                    oCCOPARTEDIARIO_BE.PropAUDUSUCREACION = IIf(oDataReader.IsDBNull(Campos.AUDUSUCREACION), "", oDataReader(Campos.AUDUSUCREACION))
                    If oDataReader.IsDBNull(Campos.AUDROLCREACION) Then oCCOPARTEDIARIO_BE.PropAUDROLCREACION = Nothing Else oCCOPARTEDIARIO_BE.PropAUDROLCREACION = CType(oDataReader(Campos.AUDROLCREACION), Int32)

                    If oDataReader.IsDBNull(Campos.PERCODOPERADOR) Then oCCOPARTEDIARIO_BE.PropPERCODOPERADOR = Nothing Else oCCOPARTEDIARIO_BE.PropPERCODOPERADOR = CType(oDataReader(Campos.PERCODOPERADOR), Int32)
                    If oDataReader.IsDBNull(Campos.PERCODSERENO) Then oCCOPARTEDIARIO_BE.PropPERCODSERENO = Nothing Else oCCOPARTEDIARIO_BE.PropPERCODSERENO = CType(oDataReader(Campos.PERCODSERENO), Int32)
                    If oDataReader.IsDBNull(Campos.FUGACODIGO) Then oCCOPARTEDIARIO_BE.PropFUGACODIGO = Nothing Else oCCOPARTEDIARIO_BE.PropFUGACODIGO = CType(oDataReader(Campos.FUGACODIGO), Int32)
                    If oDataReader.IsDBNull(Campos.TURNOCODIGO) Then oCCOPARTEDIARIO_BE.PropTURNOCODIGO = Nothing Else oCCOPARTEDIARIO_BE.PropTURNOCODIGO = CType(oDataReader(Campos.TURNOCODIGO), Int32)
                    oCCOPARTEDIARIO_BE.PropFINATENCION = IIf(oDataReader.IsDBNull(Campos.FINATENCION), "", oDataReader(Campos.FINATENCION))
                    If oDataReader.IsDBNull(Campos.TIPODELITO) Then oCCOPARTEDIARIO_BE.PropTIPODELITO = Nothing Else oCCOPARTEDIARIO_BE.PropTIPODELITO = CType(oDataReader(Campos.TIPODELITO), Int32)
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oCCOPARTEDIARIO_BE
        End Function

        Public Sub Actualizar_SQL_DB2(ByVal pCCOPARTEDIARIO_BE As CCOPARTEDIARIO_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(16) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOPARTEDIARIO_BE.PropINCCODIGO
                arrParam(1) = New DB2Parameter("P_INTINCAGRESORES", DB2Type.Integer)
                arrParam(1).Value = pCCOPARTEDIARIO_BE.PropINCAGRESORES
                arrParam(2) = New DB2Parameter("P_VCHINCCONSECUENCIA", DB2Type.VarChar, 250)
                arrParam(2).Value = pCCOPARTEDIARIO_BE.PropINCCONSECUENCIA
                arrParam(3) = New DB2Parameter("P_SMLOBJCODIGO", DB2Type.Integer)
                arrParam(3).Value = pCCOPARTEDIARIO_BE.PropOBJCODIGO
                arrParam(4) = New DB2Parameter("P_SMLMODCODIGO", DB2Type.Integer)
                arrParam(4).Value = pCCOPARTEDIARIO_BE.PropMODCODIGO
                arrParam(5) = New DB2Parameter("P_SMLINTCODIGO", DB2Type.Integer)
                arrParam(5).Value = pCCOPARTEDIARIO_BE.PropINTCODIGO
                arrParam(6) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VarChar, 150)
                arrParam(6).Value = pCCOPARTEDIARIO_BE.PropAUDPRGCREACION
                arrParam(7) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VarChar, 60)
                arrParam(7).Value = pCCOPARTEDIARIO_BE.PropAUDEQPCREACION
                arrParam(8) = New DB2Parameter("P_DTMAUDFECCREACION", DB2Type.Timestamp)
                arrParam(8).Value = pCCOPARTEDIARIO_BE.PropAUDFECCREACION
                arrParam(9) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VarChar, 10)
                arrParam(9).Value = pCCOPARTEDIARIO_BE.PropAUDUSUCREACION
                arrParam(10) = New DB2Parameter("P_INTAUDROLCREACION", DB2Type.Integer)
                arrParam(10).Value = pCCOPARTEDIARIO_BE.PropAUDROLCREACION
                arrParam(11) = New DB2Parameter("P_INTPERCODOPERADOR", DB2Type.Integer)
                arrParam(11).Value = pCCOPARTEDIARIO_BE.PropPERCODOPERADOR
                arrParam(12) = New DB2Parameter("P_INTPERCODSERENO", DB2Type.Integer)
                arrParam(12).Value = pCCOPARTEDIARIO_BE.PropPERCODSERENO
                arrParam(13) = New DB2Parameter("P_SMLFUGACODIGO", DB2Type.Integer)
                arrParam(13).Value = pCCOPARTEDIARIO_BE.PropFUGACODIGO
                arrParam(14) = New DB2Parameter("P_SMLTURNOCODIGO", DB2Type.Integer)
                arrParam(14).Value = pCCOPARTEDIARIO_BE.PropTURNOCODIGO
                arrParam(15) = New DB2Parameter("P_DTMFINATENCION", DB2Type.VarChar, 25)
                arrParam(15).Value = pCCOPARTEDIARIO_BE.PropFINATENCION
                arrParam(16) = New DB2Parameter("P_SMLTIPODELITO", DB2Type.Integer)
                arrParam(16).Value = pCCOPARTEDIARIO_BE.PropTIPODELITO

                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOPARTEDIARIO_ACTUALIZAR_SQL", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub


	End Class
End Namespace
