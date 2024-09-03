Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class CCOCOMISARIA_DL
		Private cnDB2 As DB2Connection

		#Region "Numerador"
		Public Enum Campos
			COMCODIGO = 0
			COMDESCRIPCION = 1
			COMESTADO = 2
		End Enum
		#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

		Public Sub Insertar(ByVal pCCOCOMISARIA_BE As CCOCOMISARIA_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(2) {}
				arrParam(0) = New DB2Parameter("P_INTCOMCODIGO", DB2Type.INTEGER)
				arrParam(0).Value = pCCOCOMISARIA_BE.PropCOMCODIGO
				arrParam(1) = New DB2Parameter("P_VCHCOMDESCRIPCION", DB2Type.VARCHAR, 30)
				arrParam(1).Value = pCCOCOMISARIA_BE.PropCOMDESCRIPCION
				arrParam(2) = New DB2Parameter("P_INTCOMESTADO", DB2Type.INTEGER)
				arrParam(2).Value = pCCOCOMISARIA_BE.PropCOMESTADO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOCOMISARIA_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pCCOCOMISARIA_BE As CCOCOMISARIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(2) {}
                arrParam(0) = New DB2Parameter("P_INTCOMCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOCOMISARIA_BE.PropCOMCODIGO
                arrParam(1) = New DB2Parameter("P_VCHCOMDESCRIPCION", DB2Type.VARCHAR, 30)
                arrParam(1).Value = pCCOCOMISARIA_BE.PropCOMDESCRIPCION
                arrParam(2) = New DB2Parameter("P_INTCOMESTADO", DB2Type.INTEGER)
                arrParam(2).Value = pCCOCOMISARIA_BE.PropCOMESTADO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOCOMISARIA_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOCOMISARIA_BE As CCOCOMISARIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTCOMCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOCOMISARIA_BE.PropCOMCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOCOMISARIA_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOCOMISARIA_BE As CCOCOMISARIA_BE) As CCOCOMISARIA_BE
            Dim oCCOCOMISARIA_BE As New CCOCOMISARIA_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTCOMCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOCOMISARIA_BE.PropCOMCODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOCOMISARIA_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.COMCODIGO) Then oCCOCOMISARIA_BE.PropCOMCODIGO = Nothing Else oCCOCOMISARIA_BE.PropCOMCODIGO = CType(oDataReader(Campos.COMCODIGO), Int32)
                    oCCOCOMISARIA_BE.PropCOMDESCRIPCION = IIf(oDataReader.IsDBNull(Campos.COMDESCRIPCION), "", oDataReader(Campos.COMDESCRIPCION))
                    If oDataReader.IsDBNull(Campos.COMESTADO) Then oCCOCOMISARIA_BE.PropCOMESTADO = Nothing Else oCCOCOMISARIA_BE.PropCOMESTADO = CType(oDataReader(Campos.COMESTADO), Int32)
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oCCOCOMISARIA_BE
        End Function


	End Class
End Namespace
