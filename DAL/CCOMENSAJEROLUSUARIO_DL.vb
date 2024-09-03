Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class CCOMENSAJEROLUSUARIO_DL
		Private cnDB2 As DB2Connection

		#Region "Numerador"
		Public Enum Campos
			ROLCODIGO = 0
			MJRCODIGO = 1
			MSJCODIGO = 2
		End Enum
		#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

		Public Sub Insertar(ByVal pCCOMENSAJEROLUSUARIO_BE As CCOMENSAJEROLUSUARIO_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(2) {}
				arrParam(0) = New DB2Parameter("P_INTROLCODIGO", DB2Type.INTEGER)
				arrParam(0).Value = pCCOMENSAJEROLUSUARIO_BE.PropROLCODIGO
				arrParam(1) = New DB2Parameter("P_INTMJRCODIGO", DB2Type.INTEGER)
				arrParam(1).Value = pCCOMENSAJEROLUSUARIO_BE.PropMJRCODIGO
				arrParam(2) = New DB2Parameter("P_INTMSJCODIGO", DB2Type.INTEGER)
				arrParam(2).Value = pCCOMENSAJEROLUSUARIO_BE.PropMSJCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOMENSAJEROLUSUARIO_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pCCOMENSAJEROLUSUARIO_BE As CCOMENSAJEROLUSUARIO_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(2) {}
                arrParam(0) = New DB2Parameter("P_INTROLCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOMENSAJEROLUSUARIO_BE.PropROLCODIGO
                arrParam(1) = New DB2Parameter("P_INTMJRCODIGO", DB2Type.INTEGER)
                arrParam(1).Value = pCCOMENSAJEROLUSUARIO_BE.PropMJRCODIGO
                arrParam(2) = New DB2Parameter("P_INTMSJCODIGO", DB2Type.INTEGER)
                arrParam(2).Value = pCCOMENSAJEROLUSUARIO_BE.PropMSJCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOMENSAJEROLUSUARIO_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOMENSAJEROLUSUARIO_BE As CCOMENSAJEROLUSUARIO_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTMJRCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOMENSAJEROLUSUARIO_BE.PropMJRCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOMENSAJEROLUSUARIO_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOMENSAJEROLUSUARIO_BE As CCOMENSAJEROLUSUARIO_BE) As CCOMENSAJEROLUSUARIO_BE
            Dim oCCOMENSAJEROLUSUARIO_BE As New CCOMENSAJEROLUSUARIO_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTMJRCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOMENSAJEROLUSUARIO_BE.PropMJRCODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOMENSAJEROLUSUARIO_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.ROLCODIGO) Then oCCOMENSAJEROLUSUARIO_BE.PropROLCODIGO = Nothing Else oCCOMENSAJEROLUSUARIO_BE.PropROLCODIGO = CType(oDataReader(Campos.ROLCODIGO), Int32)
                    If oDataReader.IsDBNull(Campos.MJRCODIGO) Then oCCOMENSAJEROLUSUARIO_BE.PropMJRCODIGO = Nothing Else oCCOMENSAJEROLUSUARIO_BE.PropMJRCODIGO = CType(oDataReader(Campos.MJRCODIGO), Int32)
                    If oDataReader.IsDBNull(Campos.MSJCODIGO) Then oCCOMENSAJEROLUSUARIO_BE.PropMSJCODIGO = Nothing Else oCCOMENSAJEROLUSUARIO_BE.PropMSJCODIGO = CType(oDataReader(Campos.MSJCODIGO), Int32)
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oCCOMENSAJEROLUSUARIO_BE
        End Function


	End Class
End Namespace
