Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

    Public Class CCOCARGOPERSONAL_DL
        Private cnDB2 As DB2Connection

#Region "Numerador"
        Public Enum Campos
            CRGCODIGO = 0
            CRGDESCRIPCION = 1
            CRGESTADO = 2
            TTUCODIGO = 3
            CRGTIPO = 4
        End Enum
#End Region

        Public Sub New()
            cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
        End Sub

        Public Sub Insertar(ByVal pCCOCARGOPERSONAL_BE As CCOCARGOPERSONAL_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(4) {}
                arrParam(0) = New DB2Parameter("P_SMLCRGCODIGO", DB2Type.SMALLINT)
                arrParam(0).Value = pCCOCARGOPERSONAL_BE.PropCRGCODIGO
                arrParam(1) = New DB2Parameter("P_VCHCRGDESCRIPCION", DB2Type.VARCHAR, 30)
                arrParam(1).Value = pCCOCARGOPERSONAL_BE.PropCRGDESCRIPCION
                arrParam(2) = New DB2Parameter("P_SMLCRGESTADO", DB2Type.SMALLINT)
                arrParam(2).Value = pCCOCARGOPERSONAL_BE.PropCRGESTADO
                arrParam(3) = New DB2Parameter("P_SMLTTUCODIGO", DB2Type.SMALLINT)
                arrParam(3).Value = pCCOCARGOPERSONAL_BE.PropTTUCODIGO
                arrParam(4) = New DB2Parameter("P_CHRCRGTIPO", DB2Type.CHAR, 1)
                arrParam(4).Value = pCCOCARGOPERSONAL_BE.PropCRGTIPO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOCARGOPERSONAL_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pCCOCARGOPERSONAL_BE As CCOCARGOPERSONAL_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(4) {}
                arrParam(0) = New DB2Parameter("P_SMLCRGCODIGO", DB2Type.SMALLINT)
                arrParam(0).Value = pCCOCARGOPERSONAL_BE.PropCRGCODIGO
                arrParam(1) = New DB2Parameter("P_VCHCRGDESCRIPCION", DB2Type.VARCHAR, 30)
                arrParam(1).Value = pCCOCARGOPERSONAL_BE.PropCRGDESCRIPCION
                arrParam(2) = New DB2Parameter("P_SMLCRGESTADO", DB2Type.SMALLINT)
                arrParam(2).Value = pCCOCARGOPERSONAL_BE.PropCRGESTADO
                arrParam(3) = New DB2Parameter("P_SMLTTUCODIGO", DB2Type.SMALLINT)
                arrParam(3).Value = pCCOCARGOPERSONAL_BE.PropTTUCODIGO
                arrParam(4) = New DB2Parameter("P_CHRCRGTIPO", DB2Type.CHAR, 1)
                arrParam(4).Value = pCCOCARGOPERSONAL_BE.PropCRGTIPO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOCARGOPERSONAL_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOCARGOPERSONAL_BE As CCOCARGOPERSONAL_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_SMLCRGCODIGO", DB2Type.SMALLINT)
                arrParam(0).Value = pCCOCARGOPERSONAL_BE.PropCRGCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOCARGOPERSONAL_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOCARGOPERSONAL_BE As CCOCARGOPERSONAL_BE) As CCOCARGOPERSONAL_BE
            Dim oCCOCARGOPERSONAL_BE As New CCOCARGOPERSONAL_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_SMLCRGCODIGO", DB2Type.SMALLINT)
                arrParam(0).Value = pCCOCARGOPERSONAL_BE.PropCRGCODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOCARGOPERSONAL_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.CRGCODIGO) Then oCCOCARGOPERSONAL_BE.PropCRGCODIGO = Nothing Else oCCOCARGOPERSONAL_BE.PropCRGCODIGO = CType(oDataReader(Campos.CRGCODIGO), Int16)
                    oCCOCARGOPERSONAL_BE.PropCRGDESCRIPCION = IIf(oDataReader.IsDBNull(Campos.CRGDESCRIPCION), "", oDataReader(Campos.CRGDESCRIPCION))
                    If oDataReader.IsDBNull(Campos.CRGESTADO) Then oCCOCARGOPERSONAL_BE.PropCRGESTADO = Nothing Else oCCOCARGOPERSONAL_BE.PropCRGESTADO = CType(oDataReader(Campos.CRGESTADO), Int16)
                    If oDataReader.IsDBNull(Campos.TTUCODIGO) Then oCCOCARGOPERSONAL_BE.PropTTUCODIGO = Nothing Else oCCOCARGOPERSONAL_BE.PropTTUCODIGO = CType(oDataReader(Campos.TTUCODIGO), Int16)
                    oCCOCARGOPERSONAL_BE.PropCRGTIPO = IIf(oDataReader.IsDBNull(Campos.CRGTIPO), "", oDataReader(Campos.CRGTIPO))
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oCCOCARGOPERSONAL_BE
        End Function
        Public Function Listar(ByVal pCCOCARGOPERSONAL_BE As CCOCARGOPERSONAL_BE) As DataTable
            Dim dt As DataTable = New DataTable
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(4) {}
                arrParam(0) = New DB2Parameter("P_SMLCRGCODIGO", DB2Type.SmallInt)
                arrParam(0).Value = pCCOCARGOPERSONAL_BE.PropCRGCODIGO
                arrParam(1) = New DB2Parameter("P_VCHCRGDESCRIPCION", DB2Type.VarChar, 30)
                arrParam(1).Value = pCCOCARGOPERSONAL_BE.PropCRGDESCRIPCION
                arrParam(2) = New DB2Parameter("P_SMLCRGESTADO", DB2Type.SmallInt)
                arrParam(2).Value = pCCOCARGOPERSONAL_BE.PropCRGESTADO
                arrParam(3) = New DB2Parameter("P_SMLTTUCODIGO", DB2Type.SmallInt)
                arrParam(3).Value = pCCOCARGOPERSONAL_BE.PropTTUCODIGO
                arrParam(4) = New DB2Parameter("P_CHRCRGTIPO", DB2Type.Char, 1)
                arrParam(4).Value = pCCOCARGOPERSONAL_BE.PropCRGTIPO

                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOCARGOPERSONAL_LISTAR", arrParam)
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
