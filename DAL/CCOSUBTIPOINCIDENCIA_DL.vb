Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class CCOSUBTIPOINCIDENCIA_DL
		Private cnDB2 As DB2Connection

#Region "Numerador"
        Public Enum Campos
            STICODIGO = 0
            STIDESCRIPCION = 1
            STIABREVIA = 2
            TINCODIGO = 3
            STICONSEJO = 4
            PRICODIGO = 5
            STIESTADO = 6
        End Enum
#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

		Public Sub Insertar(ByVal pCCOSUBTIPOINCIDENCIA_BE As CCOSUBTIPOINCIDENCIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(8) {}
                arrParam(0) = New DB2Parameter("P_SMLSTICODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOSUBTIPOINCIDENCIA_BE.PropSTICODIGO
                arrParam(1) = New DB2Parameter("P_VCHSTIDESCRIPCION", DB2Type.VarChar, 50)
                arrParam(1).Value = pCCOSUBTIPOINCIDENCIA_BE.PropSTIDESCRIPCION
                arrParam(2) = New DB2Parameter("P_SMLTINCODIGO", DB2Type.Integer)
                arrParam(2).Value = pCCOSUBTIPOINCIDENCIA_BE.PropTINCODIGO
                arrParam(3) = New DB2Parameter("P_SMLPRICODIGO", DB2Type.Integer)
                arrParam(3).Value = pCCOSUBTIPOINCIDENCIA_BE.PropPRICODIGO
                arrParam(4) = New DB2Parameter("P_SMLSTIESTADO", DB2Type.Integer)
                arrParam(4).Value = pCCOSUBTIPOINCIDENCIA_BE.PropSTIESTADO
                arrParam(5) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VarChar, 15)
                arrParam(5).Value = pCCOSUBTIPOINCIDENCIA_BE.PropAUDUSUCREACION
                arrParam(6) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VarChar, 150)
                arrParam(6).Value = pCCOSUBTIPOINCIDENCIA_BE.PropAUDPRGCREACION
                arrParam(7) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VarChar, 60)
                arrParam(7).Value = pCCOSUBTIPOINCIDENCIA_BE.PropAUDEQPCREACION
                arrParam(8) = New DB2Parameter("P_DTMAUDFECCREACION", DB2Type.Timestamp)
                arrParam(8).Value = pCCOSUBTIPOINCIDENCIA_BE.PropAUDFECCREACION
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOSUBTIPOINCIDENCIA_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pCCOSUBTIPOINCIDENCIA_BE As CCOSUBTIPOINCIDENCIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(8) {}
                arrParam(0) = New DB2Parameter("P_SMLSTICODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOSUBTIPOINCIDENCIA_BE.PropSTICODIGO
                arrParam(1) = New DB2Parameter("P_VCHSTIDESCRIPCION", DB2Type.VarChar, 50)
                arrParam(1).Value = pCCOSUBTIPOINCIDENCIA_BE.PropSTIDESCRIPCION
                arrParam(2) = New DB2Parameter("P_SMLTINCODIGO", DB2Type.Integer)
                arrParam(2).Value = pCCOSUBTIPOINCIDENCIA_BE.PropTINCODIGO
                arrParam(3) = New DB2Parameter("P_SMLPRICODIGO", DB2Type.Integer)
                arrParam(3).Value = pCCOSUBTIPOINCIDENCIA_BE.PropPRICODIGO
                arrParam(4) = New DB2Parameter("P_SMLSTIESTADO", DB2Type.Integer)
                arrParam(4).Value = pCCOSUBTIPOINCIDENCIA_BE.PropSTIESTADO
                arrParam(5) = New DB2Parameter("P_VCHAUDUSUMODIF", DB2Type.VarChar, 15)
                arrParam(5).Value = pCCOSUBTIPOINCIDENCIA_BE.PropAUDUSUMODIF
                arrParam(6) = New DB2Parameter("P_VCHAUDPRGMODIF", DB2Type.VarChar, 150)
                arrParam(6).Value = pCCOSUBTIPOINCIDENCIA_BE.PropAUDPRGMODIF
                arrParam(7) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VarChar, 60)
                arrParam(7).Value = pCCOSUBTIPOINCIDENCIA_BE.PropAUDEQPMODIF
                arrParam(8) = New DB2Parameter("P_DTMAUDFECMODIF", DB2Type.Timestamp)
                arrParam(8).Value = pCCOSUBTIPOINCIDENCIA_BE.PropAUDFECMODIF
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOSUBTIPOINCIDENCIA_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOSUBTIPOINCIDENCIA_BE As CCOSUBTIPOINCIDENCIA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
                arrParam(0) = New DB2Parameter("P_SMLSTICODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOSUBTIPOINCIDENCIA_BE.PropSTICODIGO
                arrParam(1) = New DB2Parameter("P_SMLTINCODIGO", DB2Type.Integer)
                arrParam(1).Value = pCCOSUBTIPOINCIDENCIA_BE.PropTINCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOSUBTIPOINCIDENCIA_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOSUBTIPOINCIDENCIA_BE As CCOSUBTIPOINCIDENCIA_BE) As CCOSUBTIPOINCIDENCIA_BE
            Dim oCCOSUBTIPOINCIDENCIA_BE As New CCOSUBTIPOINCIDENCIA_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_SMLSTICODIGO", DB2Type.SMALLINT)
                arrParam(0).Value = pCCOSUBTIPOINCIDENCIA_BE.PropSTICODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOSUBTIPOINCIDENCIA_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.STICODIGO) Then oCCOSUBTIPOINCIDENCIA_BE.PropSTICODIGO = Nothing Else oCCOSUBTIPOINCIDENCIA_BE.PropSTICODIGO = CType(oDataReader(Campos.STICODIGO), Int16)
                    oCCOSUBTIPOINCIDENCIA_BE.PropSTIDESCRIPCION = IIf(oDataReader.IsDBNull(Campos.STIDESCRIPCION), "", oDataReader(Campos.STIDESCRIPCION))
                    oCCOSUBTIPOINCIDENCIA_BE.PropSTIABREVIA = IIf(oDataReader.IsDBNull(Campos.STIABREVIA), "", oDataReader(Campos.STIABREVIA))
                    If oDataReader.IsDBNull(Campos.TINCODIGO) Then oCCOSUBTIPOINCIDENCIA_BE.PropTINCODIGO = Nothing Else oCCOSUBTIPOINCIDENCIA_BE.PropTINCODIGO = CType(oDataReader(Campos.TINCODIGO), Int16)
                    oCCOSUBTIPOINCIDENCIA_BE.PropSTICONSEJO = IIf(oDataReader.IsDBNull(Campos.STICONSEJO), "", oDataReader(Campos.STICONSEJO))
                    If oDataReader.IsDBNull(Campos.PRICODIGO) Then oCCOSUBTIPOINCIDENCIA_BE.PropPRICODIGO = Nothing Else oCCOSUBTIPOINCIDENCIA_BE.PropPRICODIGO = CType(oDataReader(Campos.PRICODIGO), Int16)
                    If oDataReader.IsDBNull(Campos.STIESTADO) Then oCCOSUBTIPOINCIDENCIA_BE.PropSTIESTADO = Nothing Else oCCOSUBTIPOINCIDENCIA_BE.PropSTIESTADO = CType(oDataReader(Campos.STIESTADO), Int16)
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oCCOSUBTIPOINCIDENCIA_BE
        End Function

        Public Function ListarCombo(ByVal pCCOSUBTIPOINCIDENCIA_BE As CCOSUBTIPOINCIDENCIA_BE) As List(Of CCOSUBTIPOINCIDENCIA_BE)
            Dim oCCOSUBTIPOINCIDENCIA_BE As New CCOSUBTIPOINCIDENCIA_BE
            Dim lstGeneral As New List(Of CCOSUBTIPOINCIDENCIA_BE)

            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
                arrParam(0) = New DB2Parameter("P_SMLSTICODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOSUBTIPOINCIDENCIA_BE.PropSTICODIGO
                arrParam(1) = New DB2Parameter("P_SMLTINCODIGO", DB2Type.Integer)
                arrParam(1).Value = pCCOSUBTIPOINCIDENCIA_BE.PropTINCODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOSUBTIPOINCIDENCIA_LISTARCOMBO", arrParam)
                Using oDataReader
                    Do While oDataReader.Read()
                        oCCOSUBTIPOINCIDENCIA_BE = New CCOSUBTIPOINCIDENCIA_BE
                        If oDataReader.IsDBNull(Campos.STICODIGO) Then oCCOSUBTIPOINCIDENCIA_BE.PropSTICODIGO = Nothing Else oCCOSUBTIPOINCIDENCIA_BE.PropSTICODIGO = CType(oDataReader(Campos.STICODIGO), Int32)
                        oCCOSUBTIPOINCIDENCIA_BE.PropSTIDESCRIPCION = IIf(oDataReader.IsDBNull(Campos.STIDESCRIPCION), "", oDataReader(Campos.STIDESCRIPCION))
                        oCCOSUBTIPOINCIDENCIA_BE.PropSTIABREVIA = IIf(oDataReader.IsDBNull(Campos.STIABREVIA), "", oDataReader(Campos.STIABREVIA))
                        If oDataReader.IsDBNull(Campos.TINCODIGO) Then oCCOSUBTIPOINCIDENCIA_BE.PropTINCODIGO = Nothing Else oCCOSUBTIPOINCIDENCIA_BE.PropTINCODIGO = CType(oDataReader(Campos.TINCODIGO), Int32)
                        If oDataReader.IsDBNull(Campos.STIESTADO) Then oCCOSUBTIPOINCIDENCIA_BE.PropSTIESTADO = Nothing Else oCCOSUBTIPOINCIDENCIA_BE.PropSTIESTADO = CType(oDataReader(Campos.STIESTADO), Int32)
                        lstGeneral.Add(oCCOSUBTIPOINCIDENCIA_BE)
                    Loop
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return lstGeneral
        End Function

        Public Function Listar(ByVal pCCOSUBTIPOINCIDENCIA_BE As CCOSUBTIPOINCIDENCIA_BE) As DataTable
            Dim odt As New DataTable

            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(2) {}

                arrParam(0) = New DB2Parameter("P_SMLTINCODIGO", DB2Type.SmallInt)
                arrParam(0).Value = pCCOSUBTIPOINCIDENCIA_BE.PropTINCODIGO
                arrParam(1) = New DB2Parameter("P_VCHSTIDESCRIPCION", DB2Type.VarChar, 30)
                arrParam(1).Value = pCCOSUBTIPOINCIDENCIA_BE.PropSTIDESCRIPCION
                arrParam(2) = New DB2Parameter("P_SMLSTIESTADO", DB2Type.SmallInt)
                arrParam(2).Value = pCCOSUBTIPOINCIDENCIA_BE.PropSTIESTADO


                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOSUBTIPOINCIDENCIA_LISTAR", arrParam)
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
