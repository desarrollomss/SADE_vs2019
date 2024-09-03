Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

    Public Class CCORECURSO_DL
        Private cnDB2 As DB2Connection

#Region "Numerador"
        Public Enum Campos
            RECCODIGO = 0
            RECDESCRIPCION = 1
            RECCODIGOALTERNO = 2
            RECMARCA = 3
            RECMODELO = 4
            RECPLACA = 5
            RECESTADO = 6
            TRECODIGO = 7
            SECCODIGO = 8
            RECCODIGOPATRIMONIAL = 9
            AUDPRGCREACION = 10
            AUDPRGMODIF = 11
            AUDEQPCREACION = 12
            AUDEQPMODIF = 13
            AUDFECCREACION = 14
            AUDFECMODIF = 15
            AUDUSUCREACION = 16
            AUDUSUMODIF = 17
            AUDROLCREACION = 18
            AUDROLMODIF = 19
        End Enum
#End Region

        Public Sub New()
            cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
        End Sub

        Public Function Insertar(ByVal pCCORECURSO_BE As CCORECURSO_BE) As Integer
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(19) {}
                arrParam(0) = New DB2Parameter("P_INTRECCODIGO", DB2Type.Integer)
                arrParam(0).Direction = ParameterDirection.Output
                arrParam(1) = New DB2Parameter("P_VCHRECDESCRIPCION", DB2Type.VarChar, 50)
                arrParam(1).Value = pCCORECURSO_BE.PropRECDESCRIPCION
                arrParam(2) = New DB2Parameter("P_VCHRECCODIGOALTERNO", DB2Type.VarChar, 20)
                arrParam(2).Value = pCCORECURSO_BE.PropRECCODIGOALTERNO
                arrParam(3) = New DB2Parameter("P_VCHRECMARCA", DB2Type.VarChar, 30)
                arrParam(3).Value = pCCORECURSO_BE.PropRECMARCA
                arrParam(4) = New DB2Parameter("P_VCHRECMODELO", DB2Type.VarChar, 30)
                arrParam(4).Value = pCCORECURSO_BE.PropRECMODELO
                arrParam(5) = New DB2Parameter("P_VCHRECPLACA", DB2Type.VarChar, 10)
                arrParam(5).Value = pCCORECURSO_BE.PropRECPLACA
                arrParam(6) = New DB2Parameter("P_SMLRECESTADO", DB2Type.SmallInt)
                arrParam(6).Value = pCCORECURSO_BE.PropRECESTADO
                arrParam(7) = New DB2Parameter("P_SMLTRECODIGO", DB2Type.SmallInt)
                arrParam(7).Value = pCCORECURSO_BE.PropTRECODIGO
                arrParam(8) = New DB2Parameter("P_VCHRECCODIGOPATRIMONIAL", DB2Type.VarChar, 12)
                arrParam(8).Value = pCCORECURSO_BE.PropRECCODIGOPATRIMONIAL
                arrParam(9) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VarChar, 150)
                arrParam(9).Value = pCCORECURSO_BE.PropAUDPRGCREACION
                arrParam(10) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VarChar, 60)
                arrParam(10).Value = pCCORECURSO_BE.PropAUDEQPCREACION
                arrParam(11) = New DB2Parameter("P_DTMAUDFECCREACION", DB2Type.Timestamp)
                arrParam(11).Value = pCCORECURSO_BE.PropAUDFECCREACION
                arrParam(12) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VarChar, 10)
                arrParam(12).Value = pCCORECURSO_BE.PropAUDUSUCREACION

                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCORECURSO_INSERTAR", arrParam)
                Return arrParam(0).Value
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Function

        Public Sub Actualizar(ByVal pCCORECURSO_BE As CCORECURSO_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(12) {}
                arrParam(0) = New DB2Parameter("P_INTRECCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCORECURSO_BE.PropRECCODIGO
                arrParam(1) = New DB2Parameter("P_VCHRECDESCRIPCION", DB2Type.VARCHAR, 50)
                arrParam(1).Value = pCCORECURSO_BE.PropRECDESCRIPCION
                arrParam(2) = New DB2Parameter("P_VCHRECCODIGOALTERNO", DB2Type.VARCHAR, 20)
                arrParam(2).Value = pCCORECURSO_BE.PropRECCODIGOALTERNO
                arrParam(3) = New DB2Parameter("P_VCHRECMARCA", DB2Type.VARCHAR, 30)
                arrParam(3).Value = pCCORECURSO_BE.PropRECMARCA
                arrParam(4) = New DB2Parameter("P_VCHRECMODELO", DB2Type.VARCHAR, 30)
                arrParam(4).Value = pCCORECURSO_BE.PropRECMODELO
                arrParam(5) = New DB2Parameter("P_VCHRECPLACA", DB2Type.VARCHAR, 10)
                arrParam(5).Value = pCCORECURSO_BE.PropRECPLACA
                arrParam(6) = New DB2Parameter("P_SMLRECESTADO", DB2Type.SMALLINT)
                arrParam(6).Value = pCCORECURSO_BE.PropRECESTADO
                arrParam(7) = New DB2Parameter("P_SMLTRECODIGO", DB2Type.SMALLINT)
                arrParam(7).Value = pCCORECURSO_BE.PropTRECODIGO
                arrParam(8) = New DB2Parameter("P_VCHRECCODIGOPATRIMONIAL", DB2Type.VarChar, 12)
                arrParam(8).Value = pCCORECURSO_BE.PropRECCODIGOPATRIMONIAL
                arrParam(9) = New DB2Parameter("P_VCHAUDPRGMODIF", DB2Type.VarChar, 150)
                arrParam(9).Value = pCCORECURSO_BE.PropAUDPRGMODIF
                arrParam(10) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VarChar, 60)
                arrParam(10).Value = pCCORECURSO_BE.PropAUDEQPMODIF
                arrParam(11) = New DB2Parameter("P_DTMAUDFECMODIF", DB2Type.Timestamp)
                arrParam(11).Value = pCCORECURSO_BE.PropAUDFECMODIF
                arrParam(12) = New DB2Parameter("P_VCHAUDUSUMODIF", DB2Type.VarChar, 10)
                arrParam(12).Value = pCCORECURSO_BE.PropAUDUSUMODIF
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCORECURSO_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCORECURSO_BE As CCORECURSO_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTRECCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCORECURSO_BE.PropRECCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCORECURSO_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCORECURSO_BE As CCORECURSO_BE) As CCORECURSO_BE
            Dim oCCORECURSO_BE As New CCORECURSO_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTRECCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCORECURSO_BE.PropRECCODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCORECURSO_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.RECCODIGO) Then oCCORECURSO_BE.PropRECCODIGO = Nothing Else oCCORECURSO_BE.PropRECCODIGO = CType(oDataReader(Campos.RECCODIGO), Int32)
                    oCCORECURSO_BE.PropRECDESCRIPCION = IIf(oDataReader.IsDBNull(Campos.RECDESCRIPCION), "", oDataReader(Campos.RECDESCRIPCION))
                    oCCORECURSO_BE.PropRECCODIGOALTERNO = IIf(oDataReader.IsDBNull(Campos.RECCODIGOALTERNO), "", oDataReader(Campos.RECCODIGOALTERNO))
                    oCCORECURSO_BE.PropRECMARCA = IIf(oDataReader.IsDBNull(Campos.RECMARCA), "", oDataReader(Campos.RECMARCA))
                    oCCORECURSO_BE.PropRECMODELO = IIf(oDataReader.IsDBNull(Campos.RECMODELO), "", oDataReader(Campos.RECMODELO))
                    oCCORECURSO_BE.PropRECPLACA = IIf(oDataReader.IsDBNull(Campos.RECPLACA), "", oDataReader(Campos.RECPLACA))
                    If oDataReader.IsDBNull(Campos.RECESTADO) Then oCCORECURSO_BE.PropRECESTADO = Nothing Else oCCORECURSO_BE.PropRECESTADO = CType(oDataReader(Campos.RECESTADO), Int16)
                    If oDataReader.IsDBNull(Campos.TRECODIGO) Then oCCORECURSO_BE.PropTRECODIGO = Nothing Else oCCORECURSO_BE.PropTRECODIGO = CType(oDataReader(Campos.TRECODIGO), Int16)
                    If oDataReader.IsDBNull(Campos.SECCODIGO) Then oCCORECURSO_BE.PropSECCODIGO = Nothing Else oCCORECURSO_BE.PropSECCODIGO = CType(oDataReader(Campos.SECCODIGO), Int16)
                    oCCORECURSO_BE.PropRECCODIGOPATRIMONIAL = IIf(oDataReader.IsDBNull(Campos.RECCODIGOPATRIMONIAL), "", oDataReader(Campos.RECCODIGOPATRIMONIAL))
                    oCCORECURSO_BE.PropAUDPRGCREACION = IIf(oDataReader.IsDBNull(Campos.AUDPRGCREACION), "", oDataReader(Campos.AUDPRGCREACION))
                    oCCORECURSO_BE.PropAUDPRGMODIF = IIf(oDataReader.IsDBNull(Campos.AUDPRGMODIF), "", oDataReader(Campos.AUDPRGMODIF))
                    oCCORECURSO_BE.PropAUDEQPCREACION = IIf(oDataReader.IsDBNull(Campos.AUDEQPCREACION), "", oDataReader(Campos.AUDEQPCREACION))
                    oCCORECURSO_BE.PropAUDEQPMODIF = IIf(oDataReader.IsDBNull(Campos.AUDEQPMODIF), "", oDataReader(Campos.AUDEQPMODIF))
                    If oDataReader.IsDBNull(Campos.AUDFECCREACION) Then oCCORECURSO_BE.PropAUDFECCREACION = Nothing Else oCCORECURSO_BE.PropAUDFECCREACION = CType(oDataReader(Campos.AUDFECCREACION), DateTime)
                    If oDataReader.IsDBNull(Campos.AUDFECMODIF) Then oCCORECURSO_BE.PropAUDFECMODIF = Nothing Else oCCORECURSO_BE.PropAUDFECMODIF = CType(oDataReader(Campos.AUDFECMODIF), DateTime)
                    oCCORECURSO_BE.PropAUDUSUCREACION = IIf(oDataReader.IsDBNull(Campos.AUDUSUCREACION), "", oDataReader(Campos.AUDUSUCREACION))
                    oCCORECURSO_BE.PropAUDUSUMODIF = IIf(oDataReader.IsDBNull(Campos.AUDUSUMODIF), "", oDataReader(Campos.AUDUSUMODIF))
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oCCORECURSO_BE
        End Function
        Public Function Listar(ByVal pCCORECURSO_BE As CCORECURSO_BE) As DataTable
            Dim odt As New DataTable
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(4) {}
                arrParam(0) = New DB2Parameter("P_INTRECCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCORECURSO_BE.PropRECCODIGO
                arrParam(1) = New DB2Parameter("P_VCHRECDESCRIPCION", DB2Type.VarChar, 50)
                arrParam(1).Value = pCCORECURSO_BE.PropRECDESCRIPCION
                arrParam(2) = New DB2Parameter("P_INTTRECODIGO", DB2Type.Integer)
                arrParam(2).Value = pCCORECURSO_BE.PropTRECODIGO
                arrParam(3) = New DB2Parameter("P_VCHSECCODIGO", DB2Type.VarChar, 500)
                arrParam(3).Value = pCCORECURSO_BE.PropRECMODELO
                arrParam(4) = New DB2Parameter("P_VCHRECCODIGOALTERNO", DB2Type.VarChar, 50)
                arrParam(4).Value = pCCORECURSO_BE.PropRECCODIGOALTERNO
                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCORECURSO_LISTAR", arrParam)
                    odt.Load(dataReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return odt
        End Function
        Public Function ListarDisponibles(ByVal pCCORECURSO_BE As CCORECURSO_BE, ByVal pFecha As Date) As DataTable
            Dim odt As New DataTable
            Try

                Dim arrParam() As DB2Parameter = New DB2Parameter(5) {}
                arrParam(0) = New DB2Parameter("P_INTRECCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCORECURSO_BE.PropRECCODIGO
                arrParam(1) = New DB2Parameter("P_VCHRECDESCRIPCION", DB2Type.VarChar, 50)
                arrParam(1).Value = pCCORECURSO_BE.PropRECDESCRIPCION
                arrParam(2) = New DB2Parameter("P_INTTRECODIGO", DB2Type.Integer)
                arrParam(2).Value = pCCORECURSO_BE.PropTRECODIGO
                arrParam(3) = New DB2Parameter("P_VCHSECCODIGO", DB2Type.VarChar, 500)
                arrParam(3).Value = pCCORECURSO_BE.PropRECMODELO
                arrParam(4) = New DB2Parameter("P_VCHRECCODIGOALTERNO", DB2Type.VarChar, 50)
                arrParam(4).Value = pCCORECURSO_BE.PropRECCODIGOALTERNO
                arrParam(5) = New DB2Parameter("P_DATPAQFECHA", DB2Type.Date)
                arrParam(5).Value = pFecha

                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCORECURSO_LISTAR", arrParam)
                    odt.Load(dataReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return odt
        End Function

        Public Function ListarxTipo(ByVal pCCORECURSO_BE As CCORECURSO_BE) As DataTable
            Dim odt As New DataTable
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(5) {}
                arrParam(0) = New DB2Parameter("P_INTRECCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCORECURSO_BE.PropRECCODIGO
                arrParam(2) = New DB2Parameter("P_INTTRECODIGO", DB2Type.Integer)
                arrParam(2).Value = pCCORECURSO_BE.PropTRECODIGO
                arrParam(3) = New DB2Parameter("P_VCHSECCODIGO", DB2Type.VarChar, 5)
                arrParam(3).Value = pCCORECURSO_BE.PropRECMODELO
                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCORECURSO_LISTARXTIPO", arrParam)
                    odt.Load(dataReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return odt
        End Function

        Public Function Busqueda(ByVal pCCORECURSO_BE As CCORECURSO_BE) As DataTable
            Dim odt As New DataTable
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(4) {}
                arrParam(0) = New DB2Parameter("P_INTRECCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCORECURSO_BE.PropRECCODIGO
                arrParam(1) = New DB2Parameter("P_VCHRECDESCRIPCION", DB2Type.VarChar, 50)
                arrParam(1).Value = pCCORECURSO_BE.PropRECDESCRIPCION
                arrParam(2) = New DB2Parameter("P_INTTRECODIGO", DB2Type.Integer)
                arrParam(2).Value = pCCORECURSO_BE.PropTRECODIGO
                arrParam(3) = New DB2Parameter("P_VCHRECCODIGOALTERNO", DB2Type.VarChar, 50)
                arrParam(3).Value = pCCORECURSO_BE.PropRECCODIGOALTERNO
                arrParam(4) = New DB2Parameter("P_SMLRECESTADO", DB2Type.Integer)
                arrParam(4).Value = pCCORECURSO_BE.PropRECESTADO
                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCORECURSO_BUSQUEDA", arrParam)
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
