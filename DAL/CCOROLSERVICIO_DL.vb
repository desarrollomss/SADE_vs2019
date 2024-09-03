Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

    Public Class CCOROLSERVICIO_DL
        Private cnDB2 As DB2Connection

#Region "Numerador"
        Public Enum Campos
            RSEFECHA = 0
            PERCODIGO = 1
            PERTELEFONO = 2
            RSEDISPONIBLE = 3
            RSEMOTAUSENCIA = 4
            TURCODIGO = 5
            CRGCODIGO = 6
            PERMODALIDAD = 7
            RSECOMENTARIO = 8
            SECCODIGO = 9
            PFICODIGO = 10
            RSEASISTENCIA = 11
            AUDPRGCREACION = 12
            AUDPRGMODIF = 13
            AUDEQPCREACION = 14
            AUDEQPMODIF = 15
            AUDFECCREACION = 16
            AUDFECMODIF = 17
            AUDUSUCREACION = 18
            AUDUSUMODIF = 19
            AUDROLCREACION = 20
            AUDROLMODIF = 21
            GRSCODIGO = 22
        End Enum
#End Region

        Public Sub New()
            cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
        End Sub

        Public Sub Insertar(ByVal pCCOROLSERVICIO_BE As CCOROLSERVICIO_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(22) {}
                arrParam(0) = New DB2Parameter("P_DATRSEFECHA", DB2Type.DATE)
                arrParam(0).Value = pCCOROLSERVICIO_BE.PropRSEFECHA
                arrParam(1) = New DB2Parameter("P_INTPERCODIGO", DB2Type.INTEGER)
                arrParam(1).Value = pCCOROLSERVICIO_BE.PropPERCODIGO
                arrParam(2) = New DB2Parameter("P_VCHPERTELEFONO", DB2Type.VARCHAR, 30)
                arrParam(2).Value = pCCOROLSERVICIO_BE.PropPERTELEFONO
                arrParam(3) = New DB2Parameter("P_SMLRSEDISPONIBLE", DB2Type.SMALLINT)
                arrParam(3).Value = pCCOROLSERVICIO_BE.PropRSEDISPONIBLE
                arrParam(4) = New DB2Parameter("P_SMLRSEMOTAUSENCIA", DB2Type.SMALLINT)
                arrParam(4).Value = pCCOROLSERVICIO_BE.PropRSEMOTAUSENCIA
                arrParam(5) = New DB2Parameter("P_SMLTURCODIGO", DB2Type.SMALLINT)
                arrParam(5).Value = pCCOROLSERVICIO_BE.PropTURCODIGO
                arrParam(6) = New DB2Parameter("P_SMLCRGCODIGO", DB2Type.SMALLINT)
                arrParam(6).Value = pCCOROLSERVICIO_BE.PropCRGCODIGO
                arrParam(7) = New DB2Parameter("P_SMLPERMODALIDAD", DB2Type.SMALLINT)
                arrParam(7).Value = pCCOROLSERVICIO_BE.PropPERMODALIDAD
                arrParam(8) = New DB2Parameter("P_VCHRSECOMENTARIO", DB2Type.VARCHAR, 60)
                arrParam(8).Value = pCCOROLSERVICIO_BE.PropRSECOMENTARIO
                arrParam(9) = New DB2Parameter("P_SMLSECCODIGO", DB2Type.SMALLINT)
                arrParam(9).Value = pCCOROLSERVICIO_BE.PropSECCODIGO
                arrParam(10) = New DB2Parameter("P_SMLPFICODIGO", DB2Type.SMALLINT)
                arrParam(10).Value = pCCOROLSERVICIO_BE.PropPFICODIGO
                arrParam(11) = New DB2Parameter("P_SMLRSEASISTENCIA", DB2Type.SMALLINT)
                arrParam(11).Value = pCCOROLSERVICIO_BE.PropRSEASISTENCIA
                arrParam(12) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VARCHAR, 150)
                arrParam(12).Value = pCCOROLSERVICIO_BE.PropAUDPRGCREACION
                arrParam(13) = New DB2Parameter("P_VCHAUDPRGMODIF", DB2Type.VARCHAR, 150)
                arrParam(13).Value = pCCOROLSERVICIO_BE.PropAUDPRGMODIF
                arrParam(14) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VARCHAR, 60)
                arrParam(14).Value = pCCOROLSERVICIO_BE.PropAUDEQPCREACION
                arrParam(15) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VARCHAR, 60)
                arrParam(15).Value = pCCOROLSERVICIO_BE.PropAUDEQPMODIF
                arrParam(16) = New DB2Parameter("P_DTMAUDFECCREACION", DB2Type.TIMESTAMP)
                arrParam(16).Value = pCCOROLSERVICIO_BE.PropAUDFECCREACION
                arrParam(17) = New DB2Parameter("P_DTMAUDFECMODIF", DB2Type.TIMESTAMP)
                arrParam(17).Value = pCCOROLSERVICIO_BE.PropAUDFECMODIF
                arrParam(18) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VARCHAR, 10)
                arrParam(18).Value = pCCOROLSERVICIO_BE.PropAUDUSUCREACION
                arrParam(19) = New DB2Parameter("P_VCHAUDUSUMODIF", DB2Type.VARCHAR, 10)
                arrParam(19).Value = pCCOROLSERVICIO_BE.PropAUDUSUMODIF
                arrParam(20) = New DB2Parameter("P_INTAUDROLCREACION", DB2Type.INTEGER)
                arrParam(20).Value = pCCOROLSERVICIO_BE.PropAUDROLCREACION
                arrParam(21) = New DB2Parameter("P_INTAUDROLMODIF", DB2Type.INTEGER)
                arrParam(21).Value = pCCOROLSERVICIO_BE.PropAUDROLMODIF
                arrParam(22) = New DB2Parameter("P_SMLGRSCODIGO", DB2Type.SMALLINT)
                arrParam(22).Value = pCCOROLSERVICIO_BE.PropGRSCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOROLSERVICIO_INSERTARACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pCCOROLSERVICIO_BE As CCOROLSERVICIO_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(22) {}
                arrParam(0) = New DB2Parameter("P_DATRSEFECHA", DB2Type.DATE)
                arrParam(0).Value = pCCOROLSERVICIO_BE.PropRSEFECHA
                arrParam(1) = New DB2Parameter("P_INTPERCODIGO", DB2Type.INTEGER)
                arrParam(1).Value = pCCOROLSERVICIO_BE.PropPERCODIGO
                arrParam(2) = New DB2Parameter("P_VCHPERTELEFONO", DB2Type.VARCHAR, 30)
                arrParam(2).Value = pCCOROLSERVICIO_BE.PropPERTELEFONO
                arrParam(3) = New DB2Parameter("P_SMLRSEDISPONIBLE", DB2Type.SMALLINT)
                arrParam(3).Value = pCCOROLSERVICIO_BE.PropRSEDISPONIBLE
                arrParam(4) = New DB2Parameter("P_SMLRSEMOTAUSENCIA", DB2Type.SMALLINT)
                arrParam(4).Value = pCCOROLSERVICIO_BE.PropRSEMOTAUSENCIA
                arrParam(5) = New DB2Parameter("P_SMLTURCODIGO", DB2Type.SMALLINT)
                arrParam(5).Value = pCCOROLSERVICIO_BE.PropTURCODIGO
                arrParam(6) = New DB2Parameter("P_SMLCRGCODIGO", DB2Type.SMALLINT)
                arrParam(6).Value = pCCOROLSERVICIO_BE.PropCRGCODIGO
                arrParam(7) = New DB2Parameter("P_SMLPERMODALIDAD", DB2Type.SMALLINT)
                arrParam(7).Value = pCCOROLSERVICIO_BE.PropPERMODALIDAD
                arrParam(8) = New DB2Parameter("P_VCHRSECOMENTARIO", DB2Type.VARCHAR, 60)
                arrParam(8).Value = pCCOROLSERVICIO_BE.PropRSECOMENTARIO
                arrParam(9) = New DB2Parameter("P_SMLSECCODIGO", DB2Type.SMALLINT)
                arrParam(9).Value = pCCOROLSERVICIO_BE.PropSECCODIGO
                arrParam(10) = New DB2Parameter("P_SMLPFICODIGO", DB2Type.SMALLINT)
                arrParam(10).Value = pCCOROLSERVICIO_BE.PropPFICODIGO
                arrParam(11) = New DB2Parameter("P_SMLRSEASISTENCIA", DB2Type.SMALLINT)
                arrParam(11).Value = pCCOROLSERVICIO_BE.PropRSEASISTENCIA
                arrParam(12) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VARCHAR, 150)
                arrParam(12).Value = pCCOROLSERVICIO_BE.PropAUDPRGCREACION
                arrParam(13) = New DB2Parameter("P_VCHAUDPRGMODIF", DB2Type.VARCHAR, 150)
                arrParam(13).Value = pCCOROLSERVICIO_BE.PropAUDPRGMODIF
                arrParam(14) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VARCHAR, 60)
                arrParam(14).Value = pCCOROLSERVICIO_BE.PropAUDEQPCREACION
                arrParam(15) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VARCHAR, 60)
                arrParam(15).Value = pCCOROLSERVICIO_BE.PropAUDEQPMODIF
                arrParam(16) = New DB2Parameter("P_DTMAUDFECCREACION", DB2Type.TIMESTAMP)
                arrParam(16).Value = pCCOROLSERVICIO_BE.PropAUDFECCREACION
                arrParam(17) = New DB2Parameter("P_DTMAUDFECMODIF", DB2Type.TIMESTAMP)
                arrParam(17).Value = pCCOROLSERVICIO_BE.PropAUDFECMODIF
                arrParam(18) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VARCHAR, 10)
                arrParam(18).Value = pCCOROLSERVICIO_BE.PropAUDUSUCREACION
                arrParam(19) = New DB2Parameter("P_VCHAUDUSUMODIF", DB2Type.VARCHAR, 10)
                arrParam(19).Value = pCCOROLSERVICIO_BE.PropAUDUSUMODIF
                arrParam(20) = New DB2Parameter("P_INTAUDROLCREACION", DB2Type.INTEGER)
                arrParam(20).Value = pCCOROLSERVICIO_BE.PropAUDROLCREACION
                arrParam(21) = New DB2Parameter("P_INTAUDROLMODIF", DB2Type.INTEGER)
                arrParam(21).Value = pCCOROLSERVICIO_BE.PropAUDROLMODIF
                arrParam(22) = New DB2Parameter("P_SMLGRSCODIGO", DB2Type.SMALLINT)
                arrParam(22).Value = pCCOROLSERVICIO_BE.PropGRSCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOROLSERVICIO_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOROLSERVICIO_BE As CCOROLSERVICIO_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(4) {}
                arrParam(0) = New DB2Parameter("P_INTPERCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOROLSERVICIO_BE.PropPERCODIGO
                arrParam(1) = New DB2Parameter("P_SMLANIO", DB2Type.SmallInt)
                arrParam(1).Value = pCCOROLSERVICIO_BE.PropTURCODIGO
                arrParam(2) = New DB2Parameter("P_SMLMES", DB2Type.SmallInt)
                arrParam(2).Value = pCCOROLSERVICIO_BE.PropPFICODIGO
                arrParam(3) = New DB2Parameter("P_SMLGRSCODIGO", DB2Type.SmallInt)
                arrParam(3).Value = pCCOROLSERVICIO_BE.PropGRSCODIGO
                arrParam(4) = New DB2Parameter("P_SMLSECCODIGO", DB2Type.SmallInt)
                arrParam(4).Value = pCCOROLSERVICIO_BE.PropSECCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOROLSERVICIO_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOROLSERVICIO_BE As CCOROLSERVICIO_BE) As CCOROLSERVICIO_BE
            Dim oCCOROLSERVICIO_BE As New CCOROLSERVICIO_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
                arrParam(0) = New DB2Parameter("P_DATRSEFECHA", DB2Type.DATE)
                arrParam(0).Value = pCCOROLSERVICIO_BE.PropRSEFECHA
                arrParam(1) = New DB2Parameter("P_INTPERCODIGO", DB2Type.INTEGER)
                arrParam(1).Value = pCCOROLSERVICIO_BE.PropPERCODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOROLSERVICIO_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.RSEFECHA) Then oCCOROLSERVICIO_BE.PropRSEFECHA = Nothing Else oCCOROLSERVICIO_BE.PropRSEFECHA = CType(oDataReader(Campos.RSEFECHA), DateTime)
                    If oDataReader.IsDBNull(Campos.PERCODIGO) Then oCCOROLSERVICIO_BE.PropPERCODIGO = Nothing Else oCCOROLSERVICIO_BE.PropPERCODIGO = CType(oDataReader(Campos.PERCODIGO), Int32)
                    oCCOROLSERVICIO_BE.PropPERTELEFONO = IIf(oDataReader.IsDBNull(Campos.PERTELEFONO), "", oDataReader(Campos.PERTELEFONO))
                    If oDataReader.IsDBNull(Campos.RSEDISPONIBLE) Then oCCOROLSERVICIO_BE.PropRSEDISPONIBLE = Nothing Else oCCOROLSERVICIO_BE.PropRSEDISPONIBLE = CType(oDataReader(Campos.RSEDISPONIBLE), Int16)
                    If oDataReader.IsDBNull(Campos.RSEMOTAUSENCIA) Then oCCOROLSERVICIO_BE.PropRSEMOTAUSENCIA = Nothing Else oCCOROLSERVICIO_BE.PropRSEMOTAUSENCIA = CType(oDataReader(Campos.RSEMOTAUSENCIA), Int16)
                    If oDataReader.IsDBNull(Campos.TURCODIGO) Then oCCOROLSERVICIO_BE.PropTURCODIGO = Nothing Else oCCOROLSERVICIO_BE.PropTURCODIGO = CType(oDataReader(Campos.TURCODIGO), Int16)
                    If oDataReader.IsDBNull(Campos.CRGCODIGO) Then oCCOROLSERVICIO_BE.PropCRGCODIGO = Nothing Else oCCOROLSERVICIO_BE.PropCRGCODIGO = CType(oDataReader(Campos.CRGCODIGO), Int16)
                    If oDataReader.IsDBNull(Campos.PERMODALIDAD) Then oCCOROLSERVICIO_BE.PropPERMODALIDAD = Nothing Else oCCOROLSERVICIO_BE.PropPERMODALIDAD = CType(oDataReader(Campos.PERMODALIDAD), Int16)
                    oCCOROLSERVICIO_BE.PropRSECOMENTARIO = IIf(oDataReader.IsDBNull(Campos.RSECOMENTARIO), "", oDataReader(Campos.RSECOMENTARIO))
                    If oDataReader.IsDBNull(Campos.SECCODIGO) Then oCCOROLSERVICIO_BE.PropSECCODIGO = Nothing Else oCCOROLSERVICIO_BE.PropSECCODIGO = CType(oDataReader(Campos.SECCODIGO), Int16)
                    If oDataReader.IsDBNull(Campos.PFICODIGO) Then oCCOROLSERVICIO_BE.PropPFICODIGO = Nothing Else oCCOROLSERVICIO_BE.PropPFICODIGO = CType(oDataReader(Campos.PFICODIGO), Int16)
                    If oDataReader.IsDBNull(Campos.RSEASISTENCIA) Then oCCOROLSERVICIO_BE.PropRSEASISTENCIA = Nothing Else oCCOROLSERVICIO_BE.PropRSEASISTENCIA = CType(oDataReader(Campos.RSEASISTENCIA), Int16)
                    oCCOROLSERVICIO_BE.PropAUDPRGCREACION = IIf(oDataReader.IsDBNull(Campos.AUDPRGCREACION), "", oDataReader(Campos.AUDPRGCREACION))
                    oCCOROLSERVICIO_BE.PropAUDPRGMODIF = IIf(oDataReader.IsDBNull(Campos.AUDPRGMODIF), "", oDataReader(Campos.AUDPRGMODIF))
                    oCCOROLSERVICIO_BE.PropAUDEQPCREACION = IIf(oDataReader.IsDBNull(Campos.AUDEQPCREACION), "", oDataReader(Campos.AUDEQPCREACION))
                    oCCOROLSERVICIO_BE.PropAUDEQPMODIF = IIf(oDataReader.IsDBNull(Campos.AUDEQPMODIF), "", oDataReader(Campos.AUDEQPMODIF))
                    If oDataReader.IsDBNull(Campos.AUDFECCREACION) Then oCCOROLSERVICIO_BE.PropAUDFECCREACION = Nothing Else oCCOROLSERVICIO_BE.PropAUDFECCREACION = CType(oDataReader(Campos.AUDFECCREACION), DateTime)
                    If oDataReader.IsDBNull(Campos.AUDFECMODIF) Then oCCOROLSERVICIO_BE.PropAUDFECMODIF = Nothing Else oCCOROLSERVICIO_BE.PropAUDFECMODIF = CType(oDataReader(Campos.AUDFECMODIF), DateTime)
                    oCCOROLSERVICIO_BE.PropAUDUSUCREACION = IIf(oDataReader.IsDBNull(Campos.AUDUSUCREACION), "", oDataReader(Campos.AUDUSUCREACION))
                    oCCOROLSERVICIO_BE.PropAUDUSUMODIF = IIf(oDataReader.IsDBNull(Campos.AUDUSUMODIF), "", oDataReader(Campos.AUDUSUMODIF))
                    If oDataReader.IsDBNull(Campos.AUDROLCREACION) Then oCCOROLSERVICIO_BE.PropAUDROLCREACION = Nothing Else oCCOROLSERVICIO_BE.PropAUDROLCREACION = CType(oDataReader(Campos.AUDROLCREACION), Int32)
                    If oDataReader.IsDBNull(Campos.AUDROLMODIF) Then oCCOROLSERVICIO_BE.PropAUDROLMODIF = Nothing Else oCCOROLSERVICIO_BE.PropAUDROLMODIF = CType(oDataReader(Campos.AUDROLMODIF), Int32)
                    If oDataReader.IsDBNull(Campos.GRSCODIGO) Then oCCOROLSERVICIO_BE.PropGRSCODIGO = Nothing Else oCCOROLSERVICIO_BE.PropGRSCODIGO = CType(oDataReader(Campos.GRSCODIGO), Int16)
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oCCOROLSERVICIO_BE
        End Function
        Public Function Listar(ByVal pCCOROLSERVICIO_BE As CCOROLSERVICIO_BE) As DataTable
            Dim odt As New DataTable
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(4) {}
                arrParam(0) = New DB2Parameter("P_INTPERCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOROLSERVICIO_BE.PropPERCODIGO
                arrParam(1) = New DB2Parameter("P_SMLANIO", DB2Type.SmallInt)
                arrParam(1).Value = pCCOROLSERVICIO_BE.PropTURCODIGO
                arrParam(2) = New DB2Parameter("P_SMLMES", DB2Type.SmallInt)
                arrParam(2).Value = pCCOROLSERVICIO_BE.PropPFICODIGO
                arrParam(3) = New DB2Parameter("P_SMLGRSCODIGO", DB2Type.SmallInt)
                arrParam(3).Value = pCCOROLSERVICIO_BE.PropGRSCODIGO
                arrParam(4) = New DB2Parameter("P_SMLSECCODIGO", DB2Type.SmallInt)
                arrParam(4).Value = pCCOROLSERVICIO_BE.PropSECCODIGO
                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOROLSERVICIO_BUSCA_LISTAR", arrParam)
                    odt.Load(dataReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return odt
        End Function
        Public Function ListarProgramacion(ByVal pCCOROLSERVICIO_BE As CCOROLSERVICIO_BE) As DataTable
            Dim odt As New DataTable
            Try

                Dim arrParam() As DB2Parameter = New DB2Parameter(4) {}
                arrParam(0) = New DB2Parameter("P_INTPERCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOROLSERVICIO_BE.PropPERCODIGO
                arrParam(1) = New DB2Parameter("P_SMLANIO", DB2Type.SmallInt)
                arrParam(1).Value = pCCOROLSERVICIO_BE.PropTURCODIGO
                arrParam(2) = New DB2Parameter("P_SMLMES", DB2Type.SmallInt)
                arrParam(2).Value = pCCOROLSERVICIO_BE.PropPFICODIGO
                arrParam(3) = New DB2Parameter("P_SMLGRSCODIGO", DB2Type.SmallInt)
                arrParam(3).Value = pCCOROLSERVICIO_BE.PropGRSCODIGO
                arrParam(4) = New DB2Parameter("P_SMLSECCODIGO", DB2Type.SmallInt)
                arrParam(4).Value = pCCOROLSERVICIO_BE.PropSECCODIGO
                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOROLSERVICIO_PROGRAMACION_LISTAR", arrParam)
                    odt.Load(dataReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return odt
        End Function
        Public Sub InsertarProgramacion(ByVal pCCOROLSERVICIO_BE As CCOROLSERVICIO_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(5) {}
                arrParam(0) = New DB2Parameter("P_INTPERCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOROLSERVICIO_BE.PropPERCODIGO
                arrParam(1) = New DB2Parameter("P_SMLANIO", DB2Type.SmallInt)
                arrParam(1).Value = pCCOROLSERVICIO_BE.PropTURCODIGO
                arrParam(2) = New DB2Parameter("P_SMLMES", DB2Type.SmallInt)
                arrParam(2).Value = pCCOROLSERVICIO_BE.PropPFICODIGO
                arrParam(3) = New DB2Parameter("P_SMLGRSCODIGO", DB2Type.SmallInt)
                arrParam(3).Value = pCCOROLSERVICIO_BE.PropGRSCODIGO
                arrParam(4) = New DB2Parameter("P_SMLSECCODIGO", DB2Type.SmallInt)
                arrParam(4).Value = pCCOROLSERVICIO_BE.PropSECCODIGO
                arrParam(5) = New DB2Parameter("P_SMLDSSCODIGO", DB2Type.SmallInt)
                arrParam(5).Value = pCCOROLSERVICIO_BE.PropCRGCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOROLSERVICIO_PROGRAMACION_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub
    End Class
End Namespace
