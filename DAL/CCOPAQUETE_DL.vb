Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

    Public Class CCOPAQUETE_DL
        Private cnDB2 As DB2Connection

		#Region "Numerador"
        Public Enum Campos
            PAQCODIGO = 0
            TPQCODIGO = 1
            PAQFECHA = 2
            PAQESTADO = 3
            PERCODIGO = 4
            PAQNUMERO = 5
            PAQCOMENTARIO = 6
            TURCODIGO = 7
            AUDPRGCREACION = 8
            AUDPRGMODIF = 9
            AUDEQPCREACION = 10
            AUDEQPMODIF = 11
            AUDFECCREACION = 12
            AUDFECMODIF = 13
            AUDUSUCREACION = 14
            AUDUSUMODIF = 15
            AUDROLCREACION = 16
            AUDROLMODIF = 17
            PAQCONUBICACION = 18
            PAQAVISARABANDONO = 19
        End Enum
#End Region

        Public Sub New()
            cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
        End Sub

        Public Function Insertar(ByVal pCCOPAQUETE_BE As CCOPAQUETE_BE) As Integer
            Dim cod As Integer = 0
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(22) {}
                arrParam(0) = New DB2Parameter("P_SMLSECCODIGO", DB2Type.SmallInt)
                arrParam(0).Value = pCCOPAQUETE_BE.PropSECCODIGO
                arrParam(1) = New DB2Parameter("P_SMLCUACODIGO", DB2Type.SmallInt)
                arrParam(1).Value = pCCOPAQUETE_BE.PropCUACODIGO
                arrParam(2) = New DB2Parameter("P_INTPAQCODIGO", DB2Type.Integer)
                arrParam(2).Direction = ParameterDirection.Output
                arrParam(3) = New DB2Parameter("P_SMLTPQCODIGO", DB2Type.SmallInt)
                arrParam(3).Value = pCCOPAQUETE_BE.PropTPQCODIGO
                arrParam(4) = New DB2Parameter("P_DATPAQFECHA", DB2Type.Date)
                arrParam(4).Value = pCCOPAQUETE_BE.PropPAQFECHA
                arrParam(5) = New DB2Parameter("P_SMLPAQESTADO", DB2Type.SmallInt)
                arrParam(5).Value = pCCOPAQUETE_BE.PropPAQESTADO
                arrParam(6) = New DB2Parameter("P_INTPERCODIGO", DB2Type.Integer)
                arrParam(6).Value = pCCOPAQUETE_BE.PropPERCODIGO
                arrParam(7) = New DB2Parameter("P_VCHPAQNUMERO", DB2Type.VarChar, 20)
                arrParam(7).Value = pCCOPAQUETE_BE.PropPAQNUMERO
                arrParam(8) = New DB2Parameter("P_VCHPAQCOMENTARIO", DB2Type.VarChar, 250)
                arrParam(8).Value = pCCOPAQUETE_BE.PropPAQCOMENTARIO
                arrParam(9) = New DB2Parameter("P_SMLTURCODIGO", DB2Type.SmallInt)
                arrParam(9).Value = pCCOPAQUETE_BE.PropTURCODIGO
                arrParam(10) = New DB2Parameter("P_SMLPFICODIGO", DB2Type.SmallInt)
                arrParam(10).Value = pCCOPAQUETE_BE.PropPFICODIGO
                arrParam(11) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VarChar, 150)
                arrParam(11).Value = pCCOPAQUETE_BE.PropAUDPRGCREACION
                arrParam(12) = New DB2Parameter("P_VCHAUDPRGMODIF", DB2Type.VarChar, 150)
                arrParam(12).Value = pCCOPAQUETE_BE.PropAUDPRGMODIF
                arrParam(13) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VarChar, 60)
                arrParam(13).Value = pCCOPAQUETE_BE.PropAUDEQPCREACION
                arrParam(14) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VarChar, 60)
                arrParam(14).Value = pCCOPAQUETE_BE.PropAUDEQPMODIF
                arrParam(15) = New DB2Parameter("P_DTMAUDFECCREACION", DB2Type.Timestamp)
                arrParam(15).Value = pCCOPAQUETE_BE.PropAUDFECCREACION
                arrParam(16) = New DB2Parameter("P_DTMAUDFECMODIF", DB2Type.Timestamp)
                arrParam(16).Value = pCCOPAQUETE_BE.PropAUDFECMODIF
                arrParam(17) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VarChar, 10)
                arrParam(17).Value = pCCOPAQUETE_BE.PropAUDUSUCREACION
                arrParam(18) = New DB2Parameter("P_VCHAUDUSUMODIF", DB2Type.VarChar, 10)
                arrParam(18).Value = pCCOPAQUETE_BE.PropAUDUSUMODIF
                arrParam(19) = New DB2Parameter("P_INTAUDROLCREACION", DB2Type.Integer)
                arrParam(19).Value = pCCOPAQUETE_BE.PropAUDROLCREACION
                arrParam(20) = New DB2Parameter("P_INTAUDROLMODIF", DB2Type.Integer)
                arrParam(20).Value = pCCOPAQUETE_BE.PropAUDROLMODIF
                arrParam(21) = New DB2Parameter("P_SMLPAQCONUBICACION", DB2Type.SmallInt)
                arrParam(21).Value = pCCOPAQUETE_BE.PropPAQCONUBICACION
                arrParam(22) = New DB2Parameter("P_SMLPAQAVISARABANDONO", DB2Type.SmallInt)
                arrParam(22).Value = pCCOPAQUETE_BE.PropPAQAVISARABANDONO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOPAQUETE_INSERTAR", arrParam)
                cod = arrParam(2).Value
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return (cod)
        End Function

        Public Sub Actualizar(ByVal pCCOPAQUETE_BE As CCOPAQUETE_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(19) {}
                arrParam(0) = New DB2Parameter("P_INTPAQCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOPAQUETE_BE.PropPAQCODIGO
                arrParam(1) = New DB2Parameter("P_SMLTPQCODIGO", DB2Type.SMALLINT)
                arrParam(1).Value = pCCOPAQUETE_BE.PropTPQCODIGO
                arrParam(2) = New DB2Parameter("P_DATPAQFECHA", DB2Type.DATE)
                arrParam(2).Value = pCCOPAQUETE_BE.PropPAQFECHA
                arrParam(3) = New DB2Parameter("P_SMLPAQESTADO", DB2Type.SMALLINT)
                arrParam(3).Value = pCCOPAQUETE_BE.PropPAQESTADO
                arrParam(4) = New DB2Parameter("P_INTPERCODIGO", DB2Type.INTEGER)
                arrParam(4).Value = pCCOPAQUETE_BE.PropPERCODIGO
                arrParam(5) = New DB2Parameter("P_VCHPAQNUMERO", DB2Type.VARCHAR, 20)
                arrParam(5).Value = pCCOPAQUETE_BE.PropPAQNUMERO
                arrParam(6) = New DB2Parameter("P_VCHPAQCOMENTARIO", DB2Type.VARCHAR, 250)
                arrParam(6).Value = pCCOPAQUETE_BE.PropPAQCOMENTARIO
                arrParam(7) = New DB2Parameter("P_SMLTURCODIGO", DB2Type.SMALLINT)
                arrParam(7).Value = pCCOPAQUETE_BE.PropTURCODIGO
                arrParam(8) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VARCHAR, 150)
                arrParam(8).Value = pCCOPAQUETE_BE.PropAUDPRGCREACION
                arrParam(9) = New DB2Parameter("P_VCHAUDPRGMODIF", DB2Type.VARCHAR, 150)
                arrParam(9).Value = pCCOPAQUETE_BE.PropAUDPRGMODIF
                arrParam(10) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VARCHAR, 60)
                arrParam(10).Value = pCCOPAQUETE_BE.PropAUDEQPCREACION
                arrParam(11) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VARCHAR, 60)
                arrParam(11).Value = pCCOPAQUETE_BE.PropAUDEQPMODIF
                arrParam(12) = New DB2Parameter("P_DTMAUDFECCREACION", DB2Type.TIMESTAMP)
                arrParam(12).Value = pCCOPAQUETE_BE.PropAUDFECCREACION
                arrParam(13) = New DB2Parameter("P_DTMAUDFECMODIF", DB2Type.TIMESTAMP)
                arrParam(13).Value = pCCOPAQUETE_BE.PropAUDFECMODIF
                arrParam(14) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VARCHAR, 10)
                arrParam(14).Value = pCCOPAQUETE_BE.PropAUDUSUCREACION
                arrParam(15) = New DB2Parameter("P_VCHAUDUSUMODIF", DB2Type.VARCHAR, 10)
                arrParam(15).Value = pCCOPAQUETE_BE.PropAUDUSUMODIF
                arrParam(16) = New DB2Parameter("P_INTAUDROLCREACION", DB2Type.INTEGER)
                arrParam(16).Value = pCCOPAQUETE_BE.PropAUDROLCREACION
                arrParam(17) = New DB2Parameter("P_INTAUDROLMODIF", DB2Type.INTEGER)
                arrParam(17).Value = pCCOPAQUETE_BE.PropAUDROLMODIF
                arrParam(18) = New DB2Parameter("P_SMLPAQCONUBICACION", DB2Type.SMALLINT)
                arrParam(18).Value = pCCOPAQUETE_BE.PropPAQCONUBICACION
                arrParam(19) = New DB2Parameter("P_SMLPAQAVISARABANDONO", DB2Type.SMALLINT)
                arrParam(19).Value = pCCOPAQUETE_BE.PropPAQAVISARABANDONO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOPAQUETE_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOPAQUETE_BE As CCOPAQUETE_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
                arrParam(0) = New DB2Parameter("P_INTPAQCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOPAQUETE_BE.PropPAQCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOPAQUETE_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub
        Public Sub EliminarTodo(ByVal pCCOPAQUETE_BE As CCOPAQUETE_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
                arrParam(0) = New DB2Parameter("P_INTPAQCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOPAQUETE_BE.PropPAQCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOPAQUETE_ELIMINAR_COMPLETO", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOPAQUETE_BE As CCOPAQUETE_BE) As CCOPAQUETE_BE
            Dim oCCOPAQUETE_BE As New CCOPAQUETE_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTPAQCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOPAQUETE_BE.PropPAQCODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOPAQUETE_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.PAQCODIGO) Then oCCOPAQUETE_BE.PropPAQCODIGO = Nothing Else oCCOPAQUETE_BE.PropPAQCODIGO = CType(oDataReader(Campos.PAQCODIGO), Int32)
                    If oDataReader.IsDBNull(Campos.TPQCODIGO) Then oCCOPAQUETE_BE.PropTPQCODIGO = Nothing Else oCCOPAQUETE_BE.PropTPQCODIGO = CType(oDataReader(Campos.TPQCODIGO), Int16)
                    If oDataReader.IsDBNull(Campos.PAQFECHA) Then oCCOPAQUETE_BE.PropPAQFECHA = Nothing Else oCCOPAQUETE_BE.PropPAQFECHA = CType(oDataReader(Campos.PAQFECHA), DateTime)
                    If oDataReader.IsDBNull(Campos.PAQESTADO) Then oCCOPAQUETE_BE.PropPAQESTADO = Nothing Else oCCOPAQUETE_BE.PropPAQESTADO = CType(oDataReader(Campos.PAQESTADO), Int16)
                    If oDataReader.IsDBNull(Campos.PERCODIGO) Then oCCOPAQUETE_BE.PropPERCODIGO = Nothing Else oCCOPAQUETE_BE.PropPERCODIGO = CType(oDataReader(Campos.PERCODIGO), Int32)
                    oCCOPAQUETE_BE.PropPAQNUMERO = IIf(oDataReader.IsDBNull(Campos.PAQNUMERO), "", oDataReader(Campos.PAQNUMERO))
                    oCCOPAQUETE_BE.PropPAQCOMENTARIO = IIf(oDataReader.IsDBNull(Campos.PAQCOMENTARIO), "", oDataReader(Campos.PAQCOMENTARIO))
                    If oDataReader.IsDBNull(Campos.TURCODIGO) Then oCCOPAQUETE_BE.PropTURCODIGO = Nothing Else oCCOPAQUETE_BE.PropTURCODIGO = CType(oDataReader(Campos.TURCODIGO), Int16)
                    oCCOPAQUETE_BE.PropAUDPRGCREACION = IIf(oDataReader.IsDBNull(Campos.AUDPRGCREACION), "", oDataReader(Campos.AUDPRGCREACION))
                    oCCOPAQUETE_BE.PropAUDPRGMODIF = IIf(oDataReader.IsDBNull(Campos.AUDPRGMODIF), "", oDataReader(Campos.AUDPRGMODIF))
                    oCCOPAQUETE_BE.PropAUDEQPCREACION = IIf(oDataReader.IsDBNull(Campos.AUDEQPCREACION), "", oDataReader(Campos.AUDEQPCREACION))
                    oCCOPAQUETE_BE.PropAUDEQPMODIF = IIf(oDataReader.IsDBNull(Campos.AUDEQPMODIF), "", oDataReader(Campos.AUDEQPMODIF))
                    If oDataReader.IsDBNull(Campos.AUDFECCREACION) Then oCCOPAQUETE_BE.PropAUDFECCREACION = Nothing Else oCCOPAQUETE_BE.PropAUDFECCREACION = CType(oDataReader(Campos.AUDFECCREACION), DateTime)
                    If oDataReader.IsDBNull(Campos.AUDFECMODIF) Then oCCOPAQUETE_BE.PropAUDFECMODIF = Nothing Else oCCOPAQUETE_BE.PropAUDFECMODIF = CType(oDataReader(Campos.AUDFECMODIF), DateTime)
                    oCCOPAQUETE_BE.PropAUDUSUCREACION = IIf(oDataReader.IsDBNull(Campos.AUDUSUCREACION), "", oDataReader(Campos.AUDUSUCREACION))
                    oCCOPAQUETE_BE.PropAUDUSUMODIF = IIf(oDataReader.IsDBNull(Campos.AUDUSUMODIF), "", oDataReader(Campos.AUDUSUMODIF))
                    If oDataReader.IsDBNull(Campos.AUDROLCREACION) Then oCCOPAQUETE_BE.PropAUDROLCREACION = Nothing Else oCCOPAQUETE_BE.PropAUDROLCREACION = CType(oDataReader(Campos.AUDROLCREACION), Int32)
                    If oDataReader.IsDBNull(Campos.AUDROLMODIF) Then oCCOPAQUETE_BE.PropAUDROLMODIF = Nothing Else oCCOPAQUETE_BE.PropAUDROLMODIF = CType(oDataReader(Campos.AUDROLMODIF), Int32)
                    If oDataReader.IsDBNull(Campos.PAQCONUBICACION) Then oCCOPAQUETE_BE.PropPAQCONUBICACION = Nothing Else oCCOPAQUETE_BE.PropPAQCONUBICACION = CType(oDataReader(Campos.PAQCONUBICACION), Int16)
                    If oDataReader.IsDBNull(Campos.PAQAVISARABANDONO) Then oCCOPAQUETE_BE.PropPAQAVISARABANDONO = Nothing Else oCCOPAQUETE_BE.PropPAQAVISARABANDONO = CType(oDataReader(Campos.PAQAVISARABANDONO), Int16)
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oCCOPAQUETE_BE
        End Function

        Public Function Listar(ByVal pCCOPAQUETE_BE As CCOPAQUETE_BE) As DataTable
            Dim odt As New DataTable
            Try

                Dim arrParam() As DB2Parameter = New DB2Parameter(5) {}
                arrParam(0) = New DB2Parameter("P_INTPAQCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOPAQUETE_BE.PropPAQCODIGO
                arrParam(1) = New DB2Parameter("P_DATPAQFECHA", DB2Type.Date)
                arrParam(1).Value = pCCOPAQUETE_BE.PropPAQFECHA
                arrParam(2) = New DB2Parameter("P_INTPERCODIGO", DB2Type.Integer)
                arrParam(2).Value = pCCOPAQUETE_BE.PropPERCODIGO
                arrParam(3) = New DB2Parameter("P_INTTURCODIGO", DB2Type.Integer)
                arrParam(3).Value = pCCOPAQUETE_BE.PropTURCODIGO
                arrParam(4) = New DB2Parameter("P_INTSECCODIGO", DB2Type.Integer)
                arrParam(4).Value = pCCOPAQUETE_BE.PropSECCODIGO
                arrParam(5) = New DB2Parameter("P_SMLTPQCODIGO", DB2Type.SmallInt)
                arrParam(5).Value = pCCOPAQUETE_BE.PropTPQCODIGO
                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOPAQUETE_LISTAR", arrParam)
                    odt.Load(dataReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return odt
        End Function
        Public Function ListarTurnoSector() As DataSet
            Dim ods As New DataSet
            Try
                Using dataset As DataSet = DB2helper.ExecuteDataset(cnDB2, CommandType.StoredProcedure, "CCOTURNOSECTORBUSQUEDA_LISTAR")
                    ods = dataset
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return ods
        End Function

        Public Function ListarRecursosDisponibles(ByVal pCCOPAQUETE_BE As CCOPAQUETE_BE) As DataTable
            Dim odt As New DataTable
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(2) {}
                arrParam(0) = New DB2Parameter("P_SMLSECCODIGO", DB2Type.SmallInt)
                arrParam(0).Value = pCCOPAQUETE_BE.PropSECCODIGO
                arrParam(1) = New DB2Parameter("P_DATPAQFECHA", DB2Type.Date)
                arrParam(1).Value = pCCOPAQUETE_BE.PropPAQFECHA
                arrParam(2) = New DB2Parameter("P_SMLTURCODIGO", DB2Type.SmallInt)
                arrParam(2).Value = pCCOPAQUETE_BE.PropTURCODIGO
                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOPAQUETE_RECURSOSDISPONIBLE_LISTAR", arrParam)
                    odt.Load(dataReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return odt
        End Function

        Public Function ListaCombo(ByVal pCCOPAQUETE_BE As CCOPAQUETE_BE) As DataSet
            Dim ods As New DataSet
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(2) {}
                arrParam(0) = New DB2Parameter("P_SMLSECCODIGO", DB2Type.SmallInt)
                arrParam(0).Value = pCCOPAQUETE_BE.PropSECCODIGO
                arrParam(1) = New DB2Parameter("P_SMLCUACODIGO", DB2Type.SmallInt)
                arrParam(1).Value = pCCOPAQUETE_BE.PropCUACODIGO
                Using dataset As DataSet = DB2helper.ExecuteDataset(cnDB2, CommandType.StoredProcedure, "CCOPAQUETEREGISTRO_LISTARCOMBO", arrParam)
                    ods = dataset
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return ods
        End Function
        Public Function ListarPlantilla(ByVal pCCOPAQUETE_BE As CCOPAQUETE_BE) As DataTable
            Dim odt As New DataTable
            Try

                Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
                arrParam(0) = New DB2Parameter("P_INTTPQCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOPAQUETE_BE.PropPAQCODIGO
                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOPAQUETEPLANTILLA_LISTAR", arrParam)
                    odt.Load(dataReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return odt
        End Function
        Public Function ListaTablaTemporal(ByVal pCCOPAQUETE_BE As CCOPAQUETE_BE) As DataSet
            Dim ods As New DataSet
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
                arrParam(0) = New DB2Parameter("P_INTPAQCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOPAQUETE_BE.PropPAQCODIGO
                Using dataset As DataSet = DB2helper.ExecuteDataset(cnDB2, CommandType.StoredProcedure, "CCOPAQUETEREGISTRO_TABLASLISTAR", arrParam)
                    ods = dataset
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return ods
        End Function
        Public Function VerificaIncidencia(ByVal pPAQCODIGO As Integer) As Int16
            Dim ret As Int16 = 0
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
                arrParam(0) = New DB2Parameter("P_INTPAQCODIGO", DB2Type.Integer)
                arrParam(0).Value = pPAQCODIGO
                arrParam(1) = New DB2Parameter("P_SMLCUENTA", DB2Type.SmallInt)
                arrParam(1).Direction = ParameterDirection.Output

                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIAPAQUETE_VERIFICA", arrParam)
                ret = arrParam(1).Value
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return (ret)
        End Function

    End Class
End Namespace
