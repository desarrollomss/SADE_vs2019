Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class CCOTIPOFININTERVENCION_DL
		Private cnDB2 As DB2Connection

		#Region "Numerador"
		Public Enum Campos
			INTCODIGO = 0
			INTDESCRIPCION = 1
		End Enum
		#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

		Public Sub Insertar(ByVal pCCOTIPOFININTERVENCION_BE As CCOTIPOFININTERVENCION_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
				arrParam(0) = New DB2Parameter("P_INTINTCODIGO", DB2Type.INTEGER)
				arrParam(0).Value = pCCOTIPOFININTERVENCION_BE.PropINTCODIGO
				arrParam(1) = New DB2Parameter("P_VCHINTDESCRIPCION", DB2Type.VARCHAR, 30)
				arrParam(1).Value = pCCOTIPOFININTERVENCION_BE.PropINTDESCRIPCION
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOTIPOFININTERVENCION_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pCCOTIPOFININTERVENCION_BE As CCOTIPOFININTERVENCION_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
                arrParam(0) = New DB2Parameter("P_INTINTCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOTIPOFININTERVENCION_BE.PropINTCODIGO
                arrParam(1) = New DB2Parameter("P_VCHINTDESCRIPCION", DB2Type.VARCHAR, 30)
                arrParam(1).Value = pCCOTIPOFININTERVENCION_BE.PropINTDESCRIPCION
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOTIPOFININTERVENCION_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOTIPOFININTERVENCION_BE As CCOTIPOFININTERVENCION_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTINTCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOTIPOFININTERVENCION_BE.PropINTCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOTIPOFININTERVENCION_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOTIPOFININTERVENCION_BE As CCOTIPOFININTERVENCION_BE) As CCOTIPOFININTERVENCION_BE
            Dim oCCOTIPOFININTERVENCION_BE As New CCOTIPOFININTERVENCION_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTINTCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOTIPOFININTERVENCION_BE.PropINTCODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOTIPOFININTERVENCION_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.INTCODIGO) Then oCCOTIPOFININTERVENCION_BE.PropINTCODIGO = Nothing Else oCCOTIPOFININTERVENCION_BE.PropINTCODIGO = CType(oDataReader(Campos.INTCODIGO), Int32)
                    oCCOTIPOFININTERVENCION_BE.PropINTDESCRIPCION = IIf(oDataReader.IsDBNull(Campos.INTDESCRIPCION), "", oDataReader(Campos.INTDESCRIPCION))
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oCCOTIPOFININTERVENCION_BE
        End Function


	End Class
End Namespace
