Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class CCOPRIORIDADINCIDENCIA_DL
		Private cnDB2 As DB2Connection

		#Region "Numerador"
		Public Enum Campos
			PRICODIGO = 0
			PRIDESCRIPCION = 1
			PRITIEMPODERI = 2
			PRITIEMPOASIG = 3
			PRITIEMPOATEN = 4
			PRIESTADO = 5
		End Enum
		#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

		Public Sub Insertar(ByVal pCCOPRIORIDADINCIDENCIA_BE As CCOPRIORIDADINCIDENCIA_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(5) {}
				arrParam(0) = New DB2Parameter("P_INTPRICODIGO", DB2Type.INTEGER)
				arrParam(0).Value = pCCOPRIORIDADINCIDENCIA_BE.PropPRICODIGO
				arrParam(1) = New DB2Parameter("P_VCHPRIDESCRIPCION", DB2Type.VARCHAR, 20)
				arrParam(1).Value = pCCOPRIORIDADINCIDENCIA_BE.PropPRIDESCRIPCION
				arrParam(2) = New DB2Parameter("P_INTPRITIEMPODERI", DB2Type.INTEGER)
				arrParam(2).Value = pCCOPRIORIDADINCIDENCIA_BE.PropPRITIEMPODERI
				arrParam(3) = New DB2Parameter("P_INTPRITIEMPOASIG", DB2Type.INTEGER)
				arrParam(3).Value = pCCOPRIORIDADINCIDENCIA_BE.PropPRITIEMPOASIG
				arrParam(4) = New DB2Parameter("P_INTPRITIEMPOATEN", DB2Type.INTEGER)
				arrParam(4).Value = pCCOPRIORIDADINCIDENCIA_BE.PropPRITIEMPOATEN
				arrParam(5) = New DB2Parameter("P_INTPRIESTADO", DB2Type.INTEGER)
				arrParam(5).Value = pCCOPRIORIDADINCIDENCIA_BE.PropPRIESTADO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOPRIORIDADINCIDENCIA_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pCCOPRIORIDADINCIDENCIA_BE As CCOPRIORIDADINCIDENCIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(5) {}
                arrParam(0) = New DB2Parameter("P_INTPRICODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOPRIORIDADINCIDENCIA_BE.PropPRICODIGO
                arrParam(1) = New DB2Parameter("P_VCHPRIDESCRIPCION", DB2Type.VARCHAR, 20)
                arrParam(1).Value = pCCOPRIORIDADINCIDENCIA_BE.PropPRIDESCRIPCION
                arrParam(2) = New DB2Parameter("P_INTPRITIEMPODERI", DB2Type.INTEGER)
                arrParam(2).Value = pCCOPRIORIDADINCIDENCIA_BE.PropPRITIEMPODERI
                arrParam(3) = New DB2Parameter("P_INTPRITIEMPOASIG", DB2Type.INTEGER)
                arrParam(3).Value = pCCOPRIORIDADINCIDENCIA_BE.PropPRITIEMPOASIG
                arrParam(4) = New DB2Parameter("P_INTPRITIEMPOATEN", DB2Type.INTEGER)
                arrParam(4).Value = pCCOPRIORIDADINCIDENCIA_BE.PropPRITIEMPOATEN
                arrParam(5) = New DB2Parameter("P_INTPRIESTADO", DB2Type.INTEGER)
                arrParam(5).Value = pCCOPRIORIDADINCIDENCIA_BE.PropPRIESTADO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOPRIORIDADINCIDENCIA_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOPRIORIDADINCIDENCIA_BE As CCOPRIORIDADINCIDENCIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTPRICODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOPRIORIDADINCIDENCIA_BE.PropPRICODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOPRIORIDADINCIDENCIA_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOPRIORIDADINCIDENCIA_BE As CCOPRIORIDADINCIDENCIA_BE) As CCOPRIORIDADINCIDENCIA_BE
            Dim oCCOPRIORIDADINCIDENCIA_BE As New CCOPRIORIDADINCIDENCIA_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTPRICODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOPRIORIDADINCIDENCIA_BE.PropPRICODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOPRIORIDADINCIDENCIA_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.PRICODIGO) Then oCCOPRIORIDADINCIDENCIA_BE.PropPRICODIGO = Nothing Else oCCOPRIORIDADINCIDENCIA_BE.PropPRICODIGO = CType(oDataReader(Campos.PRICODIGO), Int32)
                    oCCOPRIORIDADINCIDENCIA_BE.PropPRIDESCRIPCION = IIf(oDataReader.IsDBNull(Campos.PRIDESCRIPCION), "", oDataReader(Campos.PRIDESCRIPCION))
                    If oDataReader.IsDBNull(Campos.PRITIEMPODERI) Then oCCOPRIORIDADINCIDENCIA_BE.PropPRITIEMPODERI = Nothing Else oCCOPRIORIDADINCIDENCIA_BE.PropPRITIEMPODERI = CType(oDataReader(Campos.PRITIEMPODERI), Int32)
                    If oDataReader.IsDBNull(Campos.PRITIEMPOASIG) Then oCCOPRIORIDADINCIDENCIA_BE.PropPRITIEMPOASIG = Nothing Else oCCOPRIORIDADINCIDENCIA_BE.PropPRITIEMPOASIG = CType(oDataReader(Campos.PRITIEMPOASIG), Int32)
                    If oDataReader.IsDBNull(Campos.PRITIEMPOATEN) Then oCCOPRIORIDADINCIDENCIA_BE.PropPRITIEMPOATEN = Nothing Else oCCOPRIORIDADINCIDENCIA_BE.PropPRITIEMPOATEN = CType(oDataReader(Campos.PRITIEMPOATEN), Int32)
                    If oDataReader.IsDBNull(Campos.PRIESTADO) Then oCCOPRIORIDADINCIDENCIA_BE.PropPRIESTADO = Nothing Else oCCOPRIORIDADINCIDENCIA_BE.PropPRIESTADO = CType(oDataReader(Campos.PRIESTADO), Int32)
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oCCOPRIORIDADINCIDENCIA_BE
        End Function

        Public Function ListarCombo() As List(Of CCOPRIORIDADINCIDENCIA_BE)
            Dim oCCOPRIORIDADINCIDENCIA_BE As New CCOPRIORIDADINCIDENCIA_BE
            Dim lstGeneral As New List(Of CCOPRIORIDADINCIDENCIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOPRIORIDADINCIDENCIA_LISTARCOMBO", arrParam)
                Using oDataReader
                    Do While oDataReader.Read()
                        oCCOPRIORIDADINCIDENCIA_BE = New CCOPRIORIDADINCIDENCIA_BE
                        If oDataReader.IsDBNull(Campos.PRICODIGO) Then oCCOPRIORIDADINCIDENCIA_BE.PropPRICODIGO = Nothing Else oCCOPRIORIDADINCIDENCIA_BE.PropPRICODIGO = CType(oDataReader(Campos.PRICODIGO), Int32)
                        oCCOPRIORIDADINCIDENCIA_BE.PropPRIDESCRIPCION = IIf(oDataReader.IsDBNull(Campos.PRIDESCRIPCION), "", oDataReader(Campos.PRIDESCRIPCION))
                        If oDataReader.IsDBNull(Campos.PRITIEMPODERI) Then oCCOPRIORIDADINCIDENCIA_BE.PropPRITIEMPODERI = Nothing Else oCCOPRIORIDADINCIDENCIA_BE.PropPRITIEMPODERI = CType(oDataReader(Campos.PRITIEMPODERI), Int32)
                        If oDataReader.IsDBNull(Campos.PRITIEMPOASIG) Then oCCOPRIORIDADINCIDENCIA_BE.PropPRITIEMPOASIG = Nothing Else oCCOPRIORIDADINCIDENCIA_BE.PropPRITIEMPOASIG = CType(oDataReader(Campos.PRITIEMPOASIG), Int32)
                        If oDataReader.IsDBNull(Campos.PRITIEMPOATEN) Then oCCOPRIORIDADINCIDENCIA_BE.PropPRITIEMPOATEN = Nothing Else oCCOPRIORIDADINCIDENCIA_BE.PropPRITIEMPOATEN = CType(oDataReader(Campos.PRITIEMPOATEN), Int32)
                        If oDataReader.IsDBNull(Campos.PRIESTADO) Then oCCOPRIORIDADINCIDENCIA_BE.PropPRIESTADO = Nothing Else oCCOPRIORIDADINCIDENCIA_BE.PropPRIESTADO = CType(oDataReader(Campos.PRIESTADO), Int32)
                        lstGeneral.Add(oCCOPRIORIDADINCIDENCIA_BE)
                    Loop
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return lstGeneral
        End Function


	End Class
End Namespace
