Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

    Public Class GPSTETRA_DL

        Private cnDB2 As DB2Connection

#Region "Numerador"
        Public Enum Campos
            NISSI = 0
            TRECODIGO = 1
            SECCODIGO = 2
            PERCODIGO = 3
            OBSERVACION = 4
            ESTADO = 5
            AUDPRGCREACION = 6
            AUDPRGMODIF = 7
            AUDEQPCREACION = 8
            AUDEQPMODIF = 9
            AUDFECCREACION = 10
            AUDFECMODIF = 11
            AUDUSUCREACION = 12
            AUDUSUMODIF = 13
        End Enum
#End Region

        Public Sub New()
            cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
        End Sub

        Public Function ListarKey(ByVal pGPSTETRA_BE As GPSTETRA_BE) As GPSTETRA_BE
            Dim oGPSTETRA_BE As New GPSTETRA_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTNISSI", DB2Type.Integer)
                arrParam(0).Value = pGPSTETRA_BE.PropNISSI

                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "GPSTETRA_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.TRECODIGO) Then oGPSTETRA_BE.PropTRECODIGO = Nothing Else oGPSTETRA_BE.PropTRECODIGO = CType(oDataReader(Campos.TRECODIGO), Int16)
                    If oDataReader.IsDBNull(Campos.SECCODIGO) Then oGPSTETRA_BE.PropSECCODIGO = Nothing Else oGPSTETRA_BE.PropSECCODIGO = CType(oDataReader(Campos.SECCODIGO), Int16)
                    If oDataReader.IsDBNull(Campos.PERCODIGO) Then oGPSTETRA_BE.PropPERCODIGO = Nothing Else oGPSTETRA_BE.PropPERCODIGO = CType(oDataReader(Campos.PERCODIGO), Int32)
                    oGPSTETRA_BE.PropOBSERVACION = IIf(oDataReader.IsDBNull(Campos.OBSERVACION), "", oDataReader(Campos.OBSERVACION))
                    If oDataReader.IsDBNull(Campos.ESTADO) Then oGPSTETRA_BE.PropESTADO = Nothing Else oGPSTETRA_BE.PropESTADO = CType(oDataReader(Campos.ESTADO), Int16)
                    oGPSTETRA_BE.PropAUDPRGCREACION = IIf(oDataReader.IsDBNull(Campos.AUDPRGCREACION), "", oDataReader(Campos.AUDPRGCREACION))

                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oGPSTETRA_BE
        End Function

        Public Function Listar(ByVal pGPSTETRA_BE As GPSTETRA_BE) As DataTable
            Dim odt As New DataTable
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(4) {}
                arrParam(0) = New DB2Parameter("P_INTNISSI", DB2Type.Integer)
                arrParam(0).Value = pGPSTETRA_BE.PropNISSI
                arrParam(1) = New DB2Parameter("P_VCHNOMBRES", DB2Type.VarChar, 100)
                arrParam(1).Value = pGPSTETRA_BE.PropOBSERVACION
                arrParam(2) = New DB2Parameter("P_SMLTRECODIGO", DB2Type.SmallInt)
                arrParam(2).Value = pGPSTETRA_BE.PropTRECODIGO
                arrParam(3) = New DB2Parameter("P_SMLSECCODIGO", DB2Type.SmallInt)
                arrParam(3).Value = pGPSTETRA_BE.PropSECCODIGO
                arrParam(4) = New DB2Parameter("P_SMLESTADO", DB2Type.SmallInt)
                arrParam(4).Value = pGPSTETRA_BE.PropESTADO
                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "GPSTETRA_LISTAR", arrParam)
                    odt.Load(dataReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return odt
        End Function

        Public Sub Insertar(ByVal pGPSTETRA_BE As GPSTETRA_BE, ByRef MSG As String)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(9) {}
                arrParam(0) = New DB2Parameter("P_INTNISSI", DB2Type.Integer)
                arrParam(0).Value = pGPSTETRA_BE.PropNISSI
                arrParam(1) = New DB2Parameter("P_SMLTRECODIGO", DB2Type.SmallInt)
                arrParam(1).Value = pGPSTETRA_BE.PropTRECODIGO
                arrParam(2) = New DB2Parameter("P_SMLSECCODIGO", DB2Type.SmallInt)
                arrParam(2).Value = pGPSTETRA_BE.PropSECCODIGO
                arrParam(3) = New DB2Parameter("P_INTPERCODIGO", DB2Type.Integer)
                arrParam(3).Value = pGPSTETRA_BE.PropPERCODIGO
                arrParam(4) = New DB2Parameter("P_VCHOBSERVACION", DB2Type.VarChar, 100)
                arrParam(4).Value = pGPSTETRA_BE.PropOBSERVACION
                arrParam(5) = New DB2Parameter("P_SMLESTADO", DB2Type.SmallInt)
                arrParam(5).Value = pGPSTETRA_BE.PropESTADO
                arrParam(6) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VarChar, 150)
                arrParam(6).Value = pGPSTETRA_BE.PropAUDPRGCREACION
                arrParam(7) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VarChar, 60)
                arrParam(7).Value = pGPSTETRA_BE.PropAUDEQPCREACION
                arrParam(8) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VarChar, 10)
                arrParam(8).Value = pGPSTETRA_BE.PropAUDUSUCREACION
                arrParam(9) = New DB2Parameter("P_MSG", DB2Type.VarChar, 100)
                arrParam(9).Direction = ParameterDirection.Output

                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "GPSTETRA_INSERTAR", arrParam)
                MSG = arrParam(9).Value

            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pGPSTETRA_BE As GPSTETRA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(8) {}
                arrParam(0) = New DB2Parameter("P_INTNISSI", DB2Type.Integer)
                arrParam(0).Value = pGPSTETRA_BE.PropNISSI
                arrParam(1) = New DB2Parameter("P_SMLTRECODIGO", DB2Type.SmallInt)
                arrParam(1).Value = pGPSTETRA_BE.PropTRECODIGO
                arrParam(2) = New DB2Parameter("P_SMLSECCODIGO", DB2Type.SmallInt)
                arrParam(2).Value = pGPSTETRA_BE.PropSECCODIGO
                arrParam(3) = New DB2Parameter("P_INTPERCODIGO", DB2Type.Integer)
                arrParam(3).Value = pGPSTETRA_BE.PropPERCODIGO
                arrParam(4) = New DB2Parameter("P_VCHOBSERVACION", DB2Type.VarChar, 100)
                arrParam(4).Value = pGPSTETRA_BE.PropOBSERVACION
                arrParam(5) = New DB2Parameter("P_SMLESTADO", DB2Type.SmallInt)
                arrParam(5).Value = pGPSTETRA_BE.PropESTADO
                arrParam(6) = New DB2Parameter("P_VCHAUDPRGMODIF", DB2Type.VarChar, 150)
                arrParam(6).Value = pGPSTETRA_BE.PropAUDPRGCREACION
                arrParam(7) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VarChar, 60)
                arrParam(7).Value = pGPSTETRA_BE.PropAUDEQPCREACION
                arrParam(8) = New DB2Parameter("P_VCHAUDUSUMODIF", DB2Type.VarChar, 10)
                arrParam(8).Value = pGPSTETRA_BE.PropAUDUSUCREACION

                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "GPSTETRA_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pGPSTETRA_BE As GPSTETRA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTNISSI", DB2Type.Integer)
                arrParam(0).Value = pGPSTETRA_BE.PropNISSI

                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "GPSTETRA_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

    End Class

End Namespace