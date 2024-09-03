Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE


Namespace DAL

    Public Class SCUESTACION_DL
        Private cnDB2 As DB2Connection

#Region "Numerador"
        Public Enum Campos
            ESTCNUMIP = 0
            ESTCDESCRI = 1
            ESTCESTADO = 2
            AUDPRGCREACION = 3
            AUDEQPCREACION = 4
            AUDFECCREACION = 5
            AUDUSUCREACION = 6
            AUDPRGMODIF = 7
            AUDEQPMODIF = 8
            AUDFECMODIF = 9
            AUDUSUMODIF = 10
        End Enum
#End Region

        Public Sub New()
            cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
        End Sub

        Public Sub Insertar(ByVal pSCUESTACION_BE As SCUESTACION_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(6) {}
                arrParam(0) = New DB2Parameter("P_VCHESTCNUMIP", DB2Type.VarChar, 15)
                arrParam(0).Value = pSCUESTACION_BE.PropESTCNUMIP
                arrParam(1) = New DB2Parameter("P_VCHESTCDESCRI", DB2Type.VarChar, 50)
                arrParam(1).Value = pSCUESTACION_BE.PropESTCDESCRI
                arrParam(2) = New DB2Parameter("P_INTESTCESTADO", DB2Type.Integer)
                arrParam(2).Value = pSCUESTACION_BE.PropESTCESTADO
                arrParam(3) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VarChar, 150)
                arrParam(3).Value = pSCUESTACION_BE.PropAUDPRGCREACION
                arrParam(4) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VarChar, 60)
                arrParam(4).Value = pSCUESTACION_BE.PropAUDEQPCREACION
                arrParam(5) = New DB2Parameter("P_DTMAUDFECCREACION", DB2Type.Timestamp)
                arrParam(5).Value = pSCUESTACION_BE.PropAUDFECCREACION
                arrParam(6) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VarChar, 15)
                arrParam(6).Value = pSCUESTACION_BE.PropAUDUSUCREACION
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "SCUESTACION_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pSCUESTACION_BE As SCUESTACION_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(5) {}
                arrParam(0) = New DB2Parameter("P_VCHESTCNUMIP", DB2Type.VarChar, 15)
                arrParam(0).Value = pSCUESTACION_BE.PropESTCNUMIP
                arrParam(1) = New DB2Parameter("P_INTESTCESTADO", DB2Type.Integer)
                arrParam(1).Value = pSCUESTACION_BE.PropESTCESTADO
                arrParam(2) = New DB2Parameter("P_VCHAUDPRGMODIF", DB2Type.VarChar, 150)
                arrParam(2).Value = pSCUESTACION_BE.PropAUDPRGMODIF
                arrParam(3) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VarChar, 60)
                arrParam(3).Value = pSCUESTACION_BE.PropAUDEQPMODIF
                arrParam(4) = New DB2Parameter("P_DTMAUDFECMODIF", DB2Type.Timestamp)
                arrParam(4).Value = pSCUESTACION_BE.PropAUDFECMODIF
                arrParam(5) = New DB2Parameter("P_VCHAUDUSUMODIF", DB2Type.VarChar, 10)
                arrParam(5).Value = pSCUESTACION_BE.PropAUDUSUMODIF
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "SCUESTACION_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pSCUESTACION_BE As SCUESTACION_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_VCHESTCNUMIP", DB2Type.VarChar, 15)
                arrParam(0).Value = pSCUESTACION_BE.PropESTCNUMIP
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "SCUESTACION_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pSCUESTACION_BE As SCUESTACION_BE) As SCUESTACION_BE
            Dim oSCUESTACION_BE As New SCUESTACION_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_VCHESTCNUMIP", DB2Type.VarChar, 15)
                arrParam(0).Value = pSCUESTACION_BE.PropESTCNUMIP
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOESTACION_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    oSCUESTACION_BE.PropESTCNUMIP = IIf(oDataReader.IsDBNull(Campos.ESTCNUMIP), "", oDataReader(Campos.ESTCNUMIP))
                    oSCUESTACION_BE.PropESTCDESCRI = IIf(oDataReader.IsDBNull(Campos.ESTCDESCRI), "", oDataReader(Campos.ESTCDESCRI))
                    If oDataReader.IsDBNull(Campos.ESTCESTADO) Then oSCUESTACION_BE.PropESTCESTADO = Nothing Else oSCUESTACION_BE.PropESTCESTADO = CType(oDataReader(Campos.ESTCESTADO), Int32)
                    oSCUESTACION_BE.PropAUDPRGCREACION = IIf(oDataReader.IsDBNull(Campos.AUDPRGCREACION), "", oDataReader(Campos.AUDPRGCREACION))
                    oSCUESTACION_BE.PropAUDEQPCREACION = IIf(oDataReader.IsDBNull(Campos.AUDEQPCREACION), "", oDataReader(Campos.AUDEQPCREACION))
                    If oDataReader.IsDBNull(Campos.AUDFECCREACION) Then oSCUESTACION_BE.PropAUDFECCREACION = Nothing Else oSCUESTACION_BE.PropAUDFECCREACION = CType(oDataReader(Campos.AUDFECCREACION), DateTime)
                    oSCUESTACION_BE.PropAUDUSUCREACION = IIf(oDataReader.IsDBNull(Campos.AUDUSUCREACION), "", oDataReader(Campos.AUDUSUCREACION))
                    oSCUESTACION_BE.PropAUDPRGMODIF = IIf(oDataReader.IsDBNull(Campos.AUDPRGMODIF), "", oDataReader(Campos.AUDPRGMODIF))
                    oSCUESTACION_BE.PropAUDEQPMODIF = IIf(oDataReader.IsDBNull(Campos.AUDEQPMODIF), "", oDataReader(Campos.AUDEQPMODIF))
                    If oDataReader.IsDBNull(Campos.AUDFECMODIF) Then oSCUESTACION_BE.PropAUDFECMODIF = Nothing Else oSCUESTACION_BE.PropAUDFECMODIF = CType(oDataReader(Campos.AUDFECMODIF), DateTime)
                    oSCUESTACION_BE.PropAUDUSUMODIF = IIf(oDataReader.IsDBNull(Campos.AUDUSUMODIF), "", oDataReader(Campos.AUDUSUMODIF))
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oSCUESTACION_BE
        End Function

        Public Function ValidarLogon(ByVal pSCUESTACION_BE As SCUESTACION_BE) As SCUESTACION_BE
            Dim oSCUESTACION_BE As New SCUESTACION_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
                arrParam(0) = New DB2Parameter("P_VCHESTCNUMIP", DB2Type.VarChar, 15)
                arrParam(0).Value = pSCUESTACION_BE.PropESTCNUMIP
                arrParam(1) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VarChar, 60)
                arrParam(1).Value = pSCUESTACION_BE.PropAUDEQPCREACION
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "SCUESTACION_VALIDA_LOGON", arrParam)
                Do While oDataReader.Read()
                    oSCUESTACION_BE.PropESTCNUMIP = IIf(oDataReader.IsDBNull(Campos.ESTCNUMIP), "", oDataReader(Campos.ESTCNUMIP))
                    oSCUESTACION_BE.PropESTCDESCRI = IIf(oDataReader.IsDBNull(Campos.ESTCDESCRI), "", oDataReader(Campos.ESTCDESCRI))
                    If oDataReader.IsDBNull(Campos.ESTCESTADO) Then oSCUESTACION_BE.PropESTCESTADO = Nothing Else oSCUESTACION_BE.PropESTCESTADO = CType(oDataReader(Campos.ESTCESTADO), Int32)
                    oSCUESTACION_BE.PropAUDPRGCREACION = IIf(oDataReader.IsDBNull(Campos.AUDPRGCREACION), "", oDataReader(Campos.AUDPRGCREACION))
                    oSCUESTACION_BE.PropAUDEQPCREACION = IIf(oDataReader.IsDBNull(Campos.AUDEQPCREACION), "", oDataReader(Campos.AUDEQPCREACION))
                    If oDataReader.IsDBNull(Campos.AUDFECCREACION) Then oSCUESTACION_BE.PropAUDFECCREACION = Nothing Else oSCUESTACION_BE.PropAUDFECCREACION = CType(oDataReader(Campos.AUDFECCREACION), DateTime)
                    oSCUESTACION_BE.PropAUDUSUCREACION = IIf(oDataReader.IsDBNull(Campos.AUDUSUCREACION), "", oDataReader(Campos.AUDUSUCREACION))
                    oSCUESTACION_BE.PropAUDPRGMODIF = IIf(oDataReader.IsDBNull(Campos.AUDPRGMODIF), "", oDataReader(Campos.AUDPRGMODIF))
                    oSCUESTACION_BE.PropAUDEQPMODIF = IIf(oDataReader.IsDBNull(Campos.AUDEQPMODIF), "", oDataReader(Campos.AUDEQPMODIF))
                    If oDataReader.IsDBNull(Campos.AUDFECMODIF) Then oSCUESTACION_BE.PropAUDFECMODIF = Nothing Else oSCUESTACION_BE.PropAUDFECMODIF = CType(oDataReader(Campos.AUDFECMODIF), DateTime)
                    oSCUESTACION_BE.PropAUDUSUMODIF = IIf(oDataReader.IsDBNull(Campos.AUDUSUMODIF), "", oDataReader(Campos.AUDUSUMODIF))
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oSCUESTACION_BE
        End Function

        Public Function Busqueda(ByVal pSCUESTACION_BE As SCUESTACION_BE) As DataTable
            Dim dt As DataTable = New DataTable
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(2) {}
                arrParam(0) = New DB2Parameter("P_VCHESTCNUMIP", DB2Type.VarChar, 15)
                arrParam(0).Value = pSCUESTACION_BE.PropESTCNUMIP
                arrParam(1) = New DB2Parameter("P_VCHESTCDESCRI", DB2Type.VarChar, 50)
                arrParam(1).Value = pSCUESTACION_BE.PropESTCDESCRI
                arrParam(2) = New DB2Parameter("P_INTESTCESTADO", DB2Type.Integer)
                arrParam(2).Value = pSCUESTACION_BE.PropESTCESTADO

                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "SCUESTACION_BUSQUEDA", arrParam)
                    dt.Load(dataReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return dt
        End Function


    End Class
End Namespace
