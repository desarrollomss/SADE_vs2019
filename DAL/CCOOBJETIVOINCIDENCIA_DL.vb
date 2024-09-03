Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class CCOOBJETIVOINCIDENCIA_DL
		Private cnDB2 As DB2Connection

		#Region "Numerador"
		Public Enum Campos
			OBJCODIGO = 0
			OBJDESCRIPCION = 1
		End Enum
		#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

		Public Sub Insertar(ByVal pCCOOBJETIVOINCIDENCIA_BE As CCOOBJETIVOINCIDENCIA_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
				arrParam(0) = New DB2Parameter("P_INTOBJCODIGO", DB2Type.INTEGER)
				arrParam(0).Value = pCCOOBJETIVOINCIDENCIA_BE.PropOBJCODIGO
				arrParam(1) = New DB2Parameter("P_VCHOBJDESCRIPCION", DB2Type.VARCHAR, 30)
				arrParam(1).Value = pCCOOBJETIVOINCIDENCIA_BE.PropOBJDESCRIPCION
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOOBJETIVOINCIDENCIA_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pCCOOBJETIVOINCIDENCIA_BE As CCOOBJETIVOINCIDENCIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
                arrParam(0) = New DB2Parameter("P_INTOBJCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOOBJETIVOINCIDENCIA_BE.PropOBJCODIGO
                arrParam(1) = New DB2Parameter("P_VCHOBJDESCRIPCION", DB2Type.VARCHAR, 30)
                arrParam(1).Value = pCCOOBJETIVOINCIDENCIA_BE.PropOBJDESCRIPCION
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOOBJETIVOINCIDENCIA_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOOBJETIVOINCIDENCIA_BE As CCOOBJETIVOINCIDENCIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTOBJCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOOBJETIVOINCIDENCIA_BE.PropOBJCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOOBJETIVOINCIDENCIA_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOOBJETIVOINCIDENCIA_BE As CCOOBJETIVOINCIDENCIA_BE) As CCOOBJETIVOINCIDENCIA_BE
            Dim oCCOOBJETIVOINCIDENCIA_BE As New CCOOBJETIVOINCIDENCIA_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTOBJCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOOBJETIVOINCIDENCIA_BE.PropOBJCODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOOBJETIVOINCIDENCIA_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.OBJCODIGO) Then oCCOOBJETIVOINCIDENCIA_BE.PropOBJCODIGO = Nothing Else oCCOOBJETIVOINCIDENCIA_BE.PropOBJCODIGO = CType(oDataReader(Campos.OBJCODIGO), Int32)
                    oCCOOBJETIVOINCIDENCIA_BE.PropOBJDESCRIPCION = IIf(oDataReader.IsDBNull(Campos.OBJDESCRIPCION), "", oDataReader(Campos.OBJDESCRIPCION))
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oCCOOBJETIVOINCIDENCIA_BE
        End Function

        Public Function ListarCombo() As DataTable
            Dim odt As New DataTable
            Try

                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOOBJETIVOINCIDENCIA_LISTARCOMBO", arrParam)
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
