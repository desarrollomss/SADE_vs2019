Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class SYSESTACION_DL
		Private cnDB2 As DB2Connection

		#Region "Numerador"
		Public Enum Campos
			EXTENSION = 0
			IDLLAMADA = 1
			NUMORIGEN = 2
			INCCODIGO = 3
			CONECTADO = 4
		End Enum
		#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

		Public Sub Insertar(ByVal pSYSESTACION_BE As SYSESTACION_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(4) {}
				arrParam(0) = New DB2Parameter("P_VCHEXTENSION", DB2Type.VARCHAR, 5)
				arrParam(0).Value = pSYSESTACION_BE.PropEXTENSION
				arrParam(1) = New DB2Parameter("P_VCHIDLLAMADA", DB2Type.VARCHAR, 64)
				arrParam(1).Value = pSYSESTACION_BE.PropIDLLAMADA
				arrParam(2) = New DB2Parameter("P_VCHNUMORIGEN", DB2Type.VARCHAR, 15)
				arrParam(2).Value = pSYSESTACION_BE.PropNUMORIGEN
				arrParam(3) = New DB2Parameter("P_INTINCCODIGO", DB2Type.INTEGER)
				arrParam(3).Value = pSYSESTACION_BE.PropINCCODIGO
				arrParam(4) = New DB2Parameter("P_SMLCONECTADO", DB2Type.SMALLINT)
				arrParam(4).Value = pSYSESTACION_BE.PropCONECTADO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "SYSESTACION_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pSYSESTACION_BE As SYSESTACION_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(4) {}
                arrParam(0) = New DB2Parameter("P_VCHEXTENSION", DB2Type.VARCHAR, 5)
                arrParam(0).Value = pSYSESTACION_BE.PropEXTENSION
                arrParam(1) = New DB2Parameter("P_VCHIDLLAMADA", DB2Type.VARCHAR, 64)
                arrParam(1).Value = pSYSESTACION_BE.PropIDLLAMADA
                arrParam(2) = New DB2Parameter("P_VCHNUMORIGEN", DB2Type.VARCHAR, 15)
                arrParam(2).Value = pSYSESTACION_BE.PropNUMORIGEN
                arrParam(3) = New DB2Parameter("P_INTINCCODIGO", DB2Type.INTEGER)
                arrParam(3).Value = pSYSESTACION_BE.PropINCCODIGO
                arrParam(4) = New DB2Parameter("P_SMLCONECTADO", DB2Type.SMALLINT)
                arrParam(4).Value = pSYSESTACION_BE.PropCONECTADO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "SYSESTACION_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pSYSESTACION_BE As SYSESTACION_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_VCHEXTENSION", DB2Type.VARCHAR, 5)
                arrParam(0).Value = pSYSESTACION_BE.PropEXTENSION
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "SYSESTACION_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pSYSESTACION_BE As SYSESTACION_BE) As SYSESTACION_BE
            Dim oSYSESTACION_BE As New SYSESTACION_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_VCHEXTENSION", DB2Type.VARCHAR, 5)
                arrParam(0).Value = pSYSESTACION_BE.PropEXTENSION
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "SYSESTACION_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    oSYSESTACION_BE.PropEXTENSION = IIf(oDataReader.IsDBNull(Campos.EXTENSION), "", oDataReader(Campos.EXTENSION))
                    oSYSESTACION_BE.PropIDLLAMADA = IIf(oDataReader.IsDBNull(Campos.IDLLAMADA), "", oDataReader(Campos.IDLLAMADA))
                    oSYSESTACION_BE.PropNUMORIGEN = IIf(oDataReader.IsDBNull(Campos.NUMORIGEN), "", oDataReader(Campos.NUMORIGEN))
                    If oDataReader.IsDBNull(Campos.INCCODIGO) Then oSYSESTACION_BE.PropINCCODIGO = Nothing Else oSYSESTACION_BE.PropINCCODIGO = CType(oDataReader(Campos.INCCODIGO), Int32)
                    If oDataReader.IsDBNull(Campos.CONECTADO) Then oSYSESTACION_BE.PropCONECTADO = Nothing Else oSYSESTACION_BE.PropCONECTADO = CType(oDataReader(Campos.CONECTADO), Int16)
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oSYSESTACION_BE
        End Function

        Public Sub Atencion_SIP(ByVal pSYSESTACION_BE As SYSESTACION_BE, ByVal pUsuario As String, ByVal pRolUsuario As String)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(6) {}
                arrParam(0) = New DB2Parameter("P_VCHEXTENSION", DB2Type.VarChar, 5)
                arrParam(0).Value = pSYSESTACION_BE.PropEXTENSION
                arrParam(1) = New DB2Parameter("P_VCHIDLLAMADA", DB2Type.VarChar, 64)
                arrParam(1).Value = pSYSESTACION_BE.PropIDLLAMADA
                arrParam(2) = New DB2Parameter("P_VCHNUMORIGEN", DB2Type.VarChar, 15)
                arrParam(2).Value = pSYSESTACION_BE.PropNUMORIGEN
                arrParam(3) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(3).Value = pSYSESTACION_BE.PropINCCODIGO
                arrParam(4) = New DB2Parameter("P_SMLCONECTADO", DB2Type.SmallInt)
                arrParam(4).Value = pSYSESTACION_BE.PropCONECTADO
                arrParam(5) = New DB2Parameter("P_INTAUDROLCREACION", DB2Type.Integer)
                arrParam(5).Value = pRolUsuario
                arrParam(6) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VarChar)
                arrParam(6).Value = pUsuario
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "SYSESTACION_ATENCION_SIP", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarAlerta(ByVal pVCHUSUARIO As String) As DataSet
            Dim ds As DataSet = New DataSet
            Try

                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_VCHUSUARIO", DB2Type.VarChar, 50)
                arrParam(0).Value = pVCHUSUARIO

                Using dataset As DataSet = DB2helper.ExecuteDataset(cnDB2, CommandType.StoredProcedure, "CCOUSUARIOATENCION_LISTAR", arrParam)
                    ds = dataset
                End Using

            Catch ex As Exception
                Throw ex
            End Try
            Return ds
        End Function

        Public Sub GestionarAlerta()
            Try
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOUSUARIOATENCION_GESTIONAR")
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub EliminarAlerta(ByVal pINTINCCODIGO As Int32)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(0).Value = pINTINCCODIGO

                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOUSUARIOATENCION_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub



        Public Sub EnAtencionAlerta(ByVal pINTINCCODIGO As Int32, ByVal pVCHUSUARIO As String, ByVal pSMLATENCION As Int16)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(2) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(0).Value = pINTINCCODIGO
                arrParam(1) = New DB2Parameter("P_VCHUSUARIO", DB2Type.VarChar, 50)
                arrParam(1).Value = pVCHUSUARIO
                arrParam(2) = New DB2Parameter("P_SMLATENCION", DB2Type.SmallInt)
                arrParam(2).Value = pSMLATENCION

                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOUSUARIOATENCION_ATENCION", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub LiberarAlerta(ByVal pINTINCCODIGO As Int32, ByVal pVCHUSUARIO As String)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(0).Value = pINTINCCODIGO
                arrParam(1) = New DB2Parameter("P_VCHUSUARIO", DB2Type.VarChar, 50)
                arrParam(1).Value = pVCHUSUARIO

                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOUSUARIOATENCION_LIBERAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub ActivaSesion(ByVal pSMLESTADOSESION As Int16, ByVal pVCHUSUARIO As String)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
                arrParam(0) = New DB2Parameter("P_VCHUSUARIO", DB2Type.VarChar, 50)
                arrParam(0).Value = pVCHUSUARIO
                arrParam(1) = New DB2Parameter("P_SMLESTADOSESION", DB2Type.SmallInt)
                arrParam(1).Value = pSMLESTADOSESION

                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOUSUARIOSESION_ACTIVAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub
        Public Function ListarUsuario(ByVal pVCHUSUARIO As String) As DataTable
            Dim dt As DataTable = New DataTable
            Try

                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_VCHUSUARIO", DB2Type.VarChar, 50)
                arrParam(0).Value = pVCHUSUARIO

                Using dataset As DataSet = DB2helper.ExecuteDataset(cnDB2, CommandType.StoredProcedure, "CCOUSUARIOSESION_LISTAR", arrParam)
                    dt = dataset.Tables(0)
                End Using

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function
        'Public Sub ElimnarUsuario(ByVal pVCHUSUARIO As String)
        '    Try
        '        Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
        '        arrParam(0) = New DB2Parameter("P_VCHUSUARIO", DB2Type.VarChar, 50)
        '        arrParam(0).Value = pVCHUSUARIO

        '        DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOUSUARIOSESION_ELIMINAR", arrParam)
        '    Catch ex As Exception
        '        Throw ex
        '    Finally
        '        If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
        '    End Try
        'End Sub
        'Public Sub AgregarUsuario(ByVal pVCHUSUARIO As String)
        '    Try
        '        Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
        '        arrParam(0) = New DB2Parameter("P_VCHUSUARIO", DB2Type.VarChar, 50)
        '        arrParam(0).Value = pVCHUSUARIO

        '        DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOUSUARIOSESION_INSERTAR", arrParam)
        '    Catch ex As Exception
        '        Throw ex
        '    Finally
        '        If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
        '    End Try
        'End Sub

        'Public Sub AsignaRol(ByVal pINTROLCODIGO As Int16, ByVal pVCHUSUARIO As String)
        '    Try
        '        Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
        '        arrParam(0) = New DB2Parameter("P_VCHUSUARIO", DB2Type.VarChar, 50)
        '        arrParam(0).Value = pVCHUSUARIO
        '        arrParam(1) = New DB2Parameter("P_INTROLCODIGO", DB2Type.Integer)
        '        arrParam(1).Value = pINTROLCODIGO

        '        DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOUSUARIOSESION_ASIGNAROL", arrParam)
        '    Catch ex As Exception
        '        Throw ex
        '    Finally
        '        If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
        '    End Try
        'End Sub


        'Public Function Busqueda(ByVal pUsuario As String, ByVal pRolUsuario As Integer, ByVal pUsuarioEst As Integer) As DataTable
        '    Dim dt As DataTable = New DataTable
        '    Try

        '        Dim arrParam() As DB2Parameter = New DB2Parameter(2) {}
        '        arrParam(0) = New DB2Parameter("P_VCHUSUARIO", DB2Type.VarChar, 50)
        '        arrParam(0).Value = pUsuario
        '        arrParam(1) = New DB2Parameter("P_INTROLCODIGO", DB2Type.Integer)
        '        arrParam(1).Value = pRolUsuario
        '        arrParam(2) = New DB2Parameter("P_SMLESTADOSESION", DB2Type.Integer)
        '        arrParam(2).Value = pUsuarioEst
        '        Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOUSUARIOSESION_BUSQUEDA", arrParam)
        '            dt.Load(dataReader)
        '        End Using
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        '    Return dt
        'End Function

        Public Function Listar() As DataTable
            Dim dt As DataTable = New DataTable
            Try

                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                Using dataset As DataSet = DB2helper.ExecuteDataset(cnDB2, CommandType.StoredProcedure, "SYSESTACION_LISTAR", arrParam)
                    dt = dataset.Tables(0)
                End Using

            Catch ex As Exception
                Throw ex
            End Try
            Return dt
        End Function


    End Class
End Namespace
