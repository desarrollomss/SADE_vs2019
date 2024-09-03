Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class CCOTIPOINCIDENCIA_DL
		Private cnDB2 As DB2Connection

		#Region "Numerador"
		Public Enum Campos
			TINCODIGO = 0
			TINDESCRIPCION = 1
			TINABREVIA = 2
			CINCODIGO = 3
			TINESTADO = 4
        End Enum
		#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

		Public Sub Insertar(ByVal pCCOTIPOINCIDENCIA_BE As CCOTIPOINCIDENCIA_BE)
			Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(7) {}
				arrParam(0) = New DB2Parameter("P_INTTINCODIGO", DB2Type.INTEGER)
				arrParam(0).Value = pCCOTIPOINCIDENCIA_BE.PropTINCODIGO
				arrParam(1) = New DB2Parameter("P_VCHTINDESCRIPCION", DB2Type.VARCHAR, 50)
				arrParam(1).Value = pCCOTIPOINCIDENCIA_BE.PropTINDESCRIPCION
                arrParam(2) = New DB2Parameter("P_INTCINCODIGO", DB2Type.Integer)
                arrParam(2).Value = pCCOTIPOINCIDENCIA_BE.PropCINCODIGO
                arrParam(3) = New DB2Parameter("P_INTTINESTADO", DB2Type.Integer)
                arrParam(3).Value = pCCOTIPOINCIDENCIA_BE.PropTINESTADO
                arrParam(4) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VarChar, 15)
                arrParam(4).Value = pCCOTIPOINCIDENCIA_BE.PropAUDUSUCREACION
                arrParam(5) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VarChar, 150)
                arrParam(5).Value = pCCOTIPOINCIDENCIA_BE.PropAUDPRGCREACION
                arrParam(6) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VarChar, 60)
                arrParam(6).Value = pCCOTIPOINCIDENCIA_BE.PropAUDEQPCREACION
                arrParam(7) = New DB2Parameter("P_DTMAUDFECCREACION", DB2Type.Timestamp)
                arrParam(7).Value = pCCOTIPOINCIDENCIA_BE.PropAUDFECCREACION
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOTIPOINCIDENCIA_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pCCOTIPOINCIDENCIA_BE As CCOTIPOINCIDENCIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(4) {}
                arrParam(0) = New DB2Parameter("P_INTTINCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOTIPOINCIDENCIA_BE.PropTINCODIGO
                arrParam(1) = New DB2Parameter("P_VCHTINDESCRIPCION", DB2Type.VARCHAR, 50)
                arrParam(1).Value = pCCOTIPOINCIDENCIA_BE.PropTINDESCRIPCION
                arrParam(2) = New DB2Parameter("P_VCHTINABREVIA", DB2Type.VARCHAR, 10)
                arrParam(2).Value = pCCOTIPOINCIDENCIA_BE.PropTINABREVIA
                arrParam(3) = New DB2Parameter("P_INTCINCODIGO", DB2Type.INTEGER)
                arrParam(3).Value = pCCOTIPOINCIDENCIA_BE.PropCINCODIGO
                arrParam(4) = New DB2Parameter("P_INTTINESTADO", DB2Type.INTEGER)
                arrParam(4).Value = pCCOTIPOINCIDENCIA_BE.PropTINESTADO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOTIPOINCIDENCIA_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOTIPOINCIDENCIA_BE As CCOTIPOINCIDENCIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTTINCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOTIPOINCIDENCIA_BE.PropTINCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOTIPOINCIDENCIA_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOTIPOINCIDENCIA_BE As CCOTIPOINCIDENCIA_BE) As CCOTIPOINCIDENCIA_BE
            Dim oCCOTIPOINCIDENCIA_BE As New CCOTIPOINCIDENCIA_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_SMLTINCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOTIPOINCIDENCIA_BE.PropTINCODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOTIPOINCIDENCIA_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.TINCODIGO) Then oCCOTIPOINCIDENCIA_BE.PropTINCODIGO = Nothing Else oCCOTIPOINCIDENCIA_BE.PropTINCODIGO = CType(oDataReader(Campos.TINCODIGO), Int32)
                    oCCOTIPOINCIDENCIA_BE.PropTINDESCRIPCION = IIf(oDataReader.IsDBNull(Campos.TINDESCRIPCION), "", oDataReader(Campos.TINDESCRIPCION))
                    oCCOTIPOINCIDENCIA_BE.PropTINABREVIA = IIf(oDataReader.IsDBNull(Campos.TINABREVIA), "", oDataReader(Campos.TINABREVIA))
                    If oDataReader.IsDBNull(Campos.CINCODIGO) Then oCCOTIPOINCIDENCIA_BE.PropCINCODIGO = Nothing Else oCCOTIPOINCIDENCIA_BE.PropCINCODIGO = CType(oDataReader(Campos.CINCODIGO), Int32)
                    If oDataReader.IsDBNull(Campos.TINESTADO) Then oCCOTIPOINCIDENCIA_BE.PropTINESTADO = Nothing Else oCCOTIPOINCIDENCIA_BE.PropTINESTADO = CType(oDataReader(Campos.TINESTADO), Int32)
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oCCOTIPOINCIDENCIA_BE
        End Function


        Public Function ListarCombo() As List(Of CCOTIPOINCIDENCIA_BE)
            Dim oCCOTIPOINCIDENCIA_BE As New CCOTIPOINCIDENCIA_BE
            Dim lstGeneral As New List(Of CCOTIPOINCIDENCIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOTIPOINCIDENCIA_LISTARCOMBO", arrParam)
                Using oDataReader
                    Do While oDataReader.Read()
                        oCCOTIPOINCIDENCIA_BE = New CCOTIPOINCIDENCIA_BE
                        If oDataReader.IsDBNull(Campos.TINCODIGO) Then oCCOTIPOINCIDENCIA_BE.PropTINCODIGO = Nothing Else oCCOTIPOINCIDENCIA_BE.PropTINCODIGO = CType(oDataReader(Campos.TINCODIGO), Int32)
                        oCCOTIPOINCIDENCIA_BE.PropTINDESCRIPCION = IIf(oDataReader.IsDBNull(Campos.TINDESCRIPCION), "", oDataReader(Campos.TINDESCRIPCION))
                        oCCOTIPOINCIDENCIA_BE.PropTINABREVIA = IIf(oDataReader.IsDBNull(Campos.TINABREVIA), "", oDataReader(Campos.TINABREVIA))
                        If oDataReader.IsDBNull(Campos.CINCODIGO) Then oCCOTIPOINCIDENCIA_BE.PropCINCODIGO = Nothing Else oCCOTIPOINCIDENCIA_BE.PropCINCODIGO = CType(oDataReader(Campos.CINCODIGO), Int32)
                        If oDataReader.IsDBNull(Campos.TINESTADO) Then oCCOTIPOINCIDENCIA_BE.PropTINESTADO = Nothing Else oCCOTIPOINCIDENCIA_BE.PropTINESTADO = CType(oDataReader(Campos.TINESTADO), Int32)
                        lstGeneral.Add(oCCOTIPOINCIDENCIA_BE)
                    Loop
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return lstGeneral
        End Function


        Public Function Busqueda(ByVal pCCOTIPOINCIDENCIA_BE As CCOTIPOINCIDENCIA_BE) As DataTable
            Dim odt As New DataTable

            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(3) {}

                arrParam(0) = New DB2Parameter("P_SMLTINCODIGO", DB2Type.SmallInt)
                arrParam(0).Value = pCCOTIPOINCIDENCIA_BE.PropTINCODIGO
                arrParam(1) = New DB2Parameter("P_VCHTINDESCRIPCION", DB2Type.VarChar, 30)
                arrParam(1).Value = pCCOTIPOINCIDENCIA_BE.PropTINDESCRIPCION
                arrParam(2) = New DB2Parameter("P_SMLCINCODIGO", DB2Type.SmallInt)
                arrParam(2).Value = pCCOTIPOINCIDENCIA_BE.PropCINCODIGO
                arrParam(3) = New DB2Parameter("P_SMLTINESTADO", DB2Type.SmallInt)
                arrParam(3).Value = pCCOTIPOINCIDENCIA_BE.PropTINESTADO


                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOTIPOINCIDENCIA_BUSQUEDA", arrParam)
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
