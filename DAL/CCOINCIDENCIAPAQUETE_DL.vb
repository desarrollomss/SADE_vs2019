Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class CCOINCIDENCIAPAQUETE_DL
		Private cnDB2 As DB2Connection

		#Region "Numerador"
		Public Enum Campos
			INPINICIOATENCION = 0
			INPFINATENCION = 1
			INCCODIGO = 2
			PAQCODIGO = 3
			PINCODIGO = 4
			INPTIPO = 5
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

		Public Sub Insertar(ByVal pCCOINCIDENCIAPAQUETE_BE As CCOINCIDENCIAPAQUETE_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(10) {}
				arrParam(0) = New DB2Parameter("P_DTMINPINICIOATENCION", DB2Type.TIMESTAMP)
				arrParam(0).Value = pCCOINCIDENCIAPAQUETE_BE.PropINPINICIOATENCION
				arrParam(1) = New DB2Parameter("P_DTMINPFINATENCION", DB2Type.TIMESTAMP)
				arrParam(1).Value = pCCOINCIDENCIAPAQUETE_BE.PropINPFINATENCION
				arrParam(2) = New DB2Parameter("P_INTINCCODIGO", DB2Type.INTEGER)
				arrParam(2).Value = pCCOINCIDENCIAPAQUETE_BE.PropINCCODIGO
				arrParam(3) = New DB2Parameter("P_INTPAQCODIGO", DB2Type.INTEGER)
				arrParam(3).Value = pCCOINCIDENCIAPAQUETE_BE.PropPAQCODIGO
				arrParam(4) = New DB2Parameter("P_INTPINCODIGO", DB2Type.INTEGER)
				arrParam(4).Value = pCCOINCIDENCIAPAQUETE_BE.PropPINCODIGO
				arrParam(5) = New DB2Parameter("P_INTINPTIPO", DB2Type.INTEGER)
				arrParam(5).Value = pCCOINCIDENCIAPAQUETE_BE.PropINPTIPO
				arrParam(6) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VARCHAR, 150)
				arrParam(6).Value = pCCOINCIDENCIAPAQUETE_BE.PropAUDPRGCREACION
				arrParam(7) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VARCHAR, 60)
				arrParam(7).Value = pCCOINCIDENCIAPAQUETE_BE.PropAUDEQPCREACION
				arrParam(8) = New DB2Parameter("P_DTMAUDFECCREACION", DB2Type.TIMESTAMP)
				arrParam(8).Value = pCCOINCIDENCIAPAQUETE_BE.PropAUDFECCREACION
				arrParam(9) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VARCHAR, 10)
				arrParam(9).Value = pCCOINCIDENCIAPAQUETE_BE.PropAUDUSUCREACION
				arrParam(10) = New DB2Parameter("P_INTAUDROLCREACION", DB2Type.INTEGER)
				arrParam(10).Value = pCCOINCIDENCIAPAQUETE_BE.PropAUDROLCREACION
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIAPAQUETE_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pCCOINCIDENCIAPAQUETE_BE As CCOINCIDENCIAPAQUETE_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(10) {}
                arrParam(0) = New DB2Parameter("P_DTMINPINICIOATENCION", DB2Type.TIMESTAMP)
                arrParam(0).Value = pCCOINCIDENCIAPAQUETE_BE.PropINPINICIOATENCION
                arrParam(1) = New DB2Parameter("P_DTMINPFINATENCION", DB2Type.TIMESTAMP)
                arrParam(1).Value = pCCOINCIDENCIAPAQUETE_BE.PropINPFINATENCION
                arrParam(2) = New DB2Parameter("P_INTINCCODIGO", DB2Type.INTEGER)
                arrParam(2).Value = pCCOINCIDENCIAPAQUETE_BE.PropINCCODIGO
                arrParam(3) = New DB2Parameter("P_INTPAQCODIGO", DB2Type.INTEGER)
                arrParam(3).Value = pCCOINCIDENCIAPAQUETE_BE.PropPAQCODIGO
                arrParam(4) = New DB2Parameter("P_INTPINCODIGO", DB2Type.INTEGER)
                arrParam(4).Value = pCCOINCIDENCIAPAQUETE_BE.PropPINCODIGO
                arrParam(5) = New DB2Parameter("P_INTINPTIPO", DB2Type.INTEGER)
                arrParam(5).Value = pCCOINCIDENCIAPAQUETE_BE.PropINPTIPO
                arrParam(6) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VARCHAR, 150)
                arrParam(6).Value = pCCOINCIDENCIAPAQUETE_BE.PropAUDPRGCREACION
                arrParam(7) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VARCHAR, 60)
                arrParam(7).Value = pCCOINCIDENCIAPAQUETE_BE.PropAUDEQPCREACION
                arrParam(8) = New DB2Parameter("P_DTMAUDFECCREACION", DB2Type.TIMESTAMP)
                arrParam(8).Value = pCCOINCIDENCIAPAQUETE_BE.PropAUDFECCREACION
                arrParam(9) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VARCHAR, 10)
                arrParam(9).Value = pCCOINCIDENCIAPAQUETE_BE.PropAUDUSUCREACION
                arrParam(10) = New DB2Parameter("P_INTAUDROLCREACION", DB2Type.INTEGER)
                arrParam(10).Value = pCCOINCIDENCIAPAQUETE_BE.PropAUDROLCREACION
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIAPAQUETE_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOINCIDENCIAPAQUETE_BE As CCOINCIDENCIAPAQUETE_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOINCIDENCIAPAQUETE_BE.PropINCCODIGO
                arrParam(1) = New DB2Parameter("P_INTPAQCODIGO", DB2Type.INTEGER)
                arrParam(1).Value = pCCOINCIDENCIAPAQUETE_BE.PropPAQCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIAPAQUETE_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOINCIDENCIAPAQUETE_BE As CCOINCIDENCIAPAQUETE_BE) As CCOINCIDENCIAPAQUETE_BE
            Dim oCCOINCIDENCIAPAQUETE_BE As New CCOINCIDENCIAPAQUETE_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOINCIDENCIAPAQUETE_BE.PropINCCODIGO
                arrParam(1) = New DB2Parameter("P_INTPAQCODIGO", DB2Type.INTEGER)
                arrParam(1).Value = pCCOINCIDENCIAPAQUETE_BE.PropPAQCODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIAPAQUETE_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.INPINICIOATENCION) Then oCCOINCIDENCIAPAQUETE_BE.PropINPINICIOATENCION = Nothing Else oCCOINCIDENCIAPAQUETE_BE.PropINPINICIOATENCION = CType(oDataReader(Campos.INPINICIOATENCION), DateTime)
                    If oDataReader.IsDBNull(Campos.INPFINATENCION) Then oCCOINCIDENCIAPAQUETE_BE.PropINPFINATENCION = Nothing Else oCCOINCIDENCIAPAQUETE_BE.PropINPFINATENCION = CType(oDataReader(Campos.INPFINATENCION), DateTime)
                    If oDataReader.IsDBNull(Campos.INCCODIGO) Then oCCOINCIDENCIAPAQUETE_BE.PropINCCODIGO = Nothing Else oCCOINCIDENCIAPAQUETE_BE.PropINCCODIGO = CType(oDataReader(Campos.INCCODIGO), Int32)
                    If oDataReader.IsDBNull(Campos.PAQCODIGO) Then oCCOINCIDENCIAPAQUETE_BE.PropPAQCODIGO = Nothing Else oCCOINCIDENCIAPAQUETE_BE.PropPAQCODIGO = CType(oDataReader(Campos.PAQCODIGO), Int32)
                    If oDataReader.IsDBNull(Campos.PINCODIGO) Then oCCOINCIDENCIAPAQUETE_BE.PropPINCODIGO = Nothing Else oCCOINCIDENCIAPAQUETE_BE.PropPINCODIGO = CType(oDataReader(Campos.PINCODIGO), Int32)
                    If oDataReader.IsDBNull(Campos.INPTIPO) Then oCCOINCIDENCIAPAQUETE_BE.PropINPTIPO = Nothing Else oCCOINCIDENCIAPAQUETE_BE.PropINPTIPO = CType(oDataReader(Campos.INPTIPO), Int32)
                    oCCOINCIDENCIAPAQUETE_BE.PropAUDPRGCREACION = IIf(oDataReader.IsDBNull(Campos.AUDPRGCREACION), "", oDataReader(Campos.AUDPRGCREACION))
                    oCCOINCIDENCIAPAQUETE_BE.PropAUDEQPCREACION = IIf(oDataReader.IsDBNull(Campos.AUDEQPCREACION), "", oDataReader(Campos.AUDEQPCREACION))
                    If oDataReader.IsDBNull(Campos.AUDFECCREACION) Then oCCOINCIDENCIAPAQUETE_BE.PropAUDFECCREACION = Nothing Else oCCOINCIDENCIAPAQUETE_BE.PropAUDFECCREACION = CType(oDataReader(Campos.AUDFECCREACION), DateTime)
                    oCCOINCIDENCIAPAQUETE_BE.PropAUDUSUCREACION = IIf(oDataReader.IsDBNull(Campos.AUDUSUCREACION), "", oDataReader(Campos.AUDUSUCREACION))
                    If oDataReader.IsDBNull(Campos.AUDROLCREACION) Then oCCOINCIDENCIAPAQUETE_BE.PropAUDROLCREACION = Nothing Else oCCOINCIDENCIAPAQUETE_BE.PropAUDROLCREACION = CType(oDataReader(Campos.AUDROLCREACION), Int32)
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oCCOINCIDENCIAPAQUETE_BE
        End Function


        Public Sub ActualizarAtencion(ByVal pCCOINCIDENCIAPAQUETE_BE As CCOINCIDENCIAPAQUETE_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(10) {}
                arrParam(0) = New DB2Parameter("P_DTMINPINICIOATENCION", DB2Type.Timestamp)
                arrParam(0).Value = pCCOINCIDENCIAPAQUETE_BE.PropINPINICIOATENCION
                arrParam(1) = New DB2Parameter("P_DTMINPFINATENCION", DB2Type.Timestamp)
                arrParam(1).Value = pCCOINCIDENCIAPAQUETE_BE.PropINPFINATENCION
                arrParam(2) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(2).Value = pCCOINCIDENCIAPAQUETE_BE.PropINCCODIGO
                arrParam(3) = New DB2Parameter("P_INTPAQCODIGO", DB2Type.Integer)
                arrParam(3).Value = pCCOINCIDENCIAPAQUETE_BE.PropPAQCODIGO
                arrParam(4) = New DB2Parameter("P_INTPINCODIGO", DB2Type.Integer)
                arrParam(4).Value = pCCOINCIDENCIAPAQUETE_BE.PropPINCODIGO
                arrParam(5) = New DB2Parameter("P_INTINPTIPO", DB2Type.Integer)
                arrParam(5).Value = pCCOINCIDENCIAPAQUETE_BE.PropINPTIPO
                arrParam(6) = New DB2Parameter("P_VCHAUDPRGMODIF", DB2Type.VarChar, 150)
                arrParam(6).Value = pCCOINCIDENCIAPAQUETE_BE.PropAUDPRGMODIF
                arrParam(7) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VarChar, 60)
                arrParam(7).Value = pCCOINCIDENCIAPAQUETE_BE.PropAUDEQPMODIF
                arrParam(8) = New DB2Parameter("P_DTMAUDFECMODIF", DB2Type.Timestamp)
                arrParam(8).Value = pCCOINCIDENCIAPAQUETE_BE.PropAUDFECMODIF
                arrParam(9) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VarChar, 10)
                arrParam(9).Value = pCCOINCIDENCIAPAQUETE_BE.PropAUDUSUMODIF
                arrParam(10) = New DB2Parameter("P_INTAUDROLMODIF", DB2Type.Integer)
                arrParam(10).Value = pCCOINCIDENCIAPAQUETE_BE.PropAUDROLMODIF

                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIAPAQUETE_ACTUALIZARATENCION", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub


        Public Function Listar(ByVal pINTINCCODIGO As Integer) As DataTable
            Dim odt As New DataTable
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(0).Value = pINTINCCODIGO
                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIAPAQUETE_LISTAR", arrParam)
                    odt.Load(dataReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return odt
        End Function


	End Class
End Namespace
