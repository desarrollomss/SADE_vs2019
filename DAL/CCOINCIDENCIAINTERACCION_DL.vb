Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

    Public Class CCOINCIDENCIAINTERACCION_DL
        Private cnDB2 As DB2Connection

#Region "Numerador"
        Public Enum Campos
            INPINICIOATENCION = 0
            INPFINATENCION = 1
            INCCODIGO = 2
            PAQCODIGO = 3
            PINCODIGO = 4
            INPTIPO = 5
            AUDPRGCREACION = 6
            AUDEQPCREACION = 7
            AUDFECCREACION = 8
            AUDUSUCREACION = 9
            AUDROLCREACION = 10
        End Enum
#End Region

        Public Sub New()
            cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
        End Sub


        Public Sub Insertar(ByVal pCCOINCIDENCIAINTERACCION_BE As CCOINCIDENCIAINTERACCION_BE)
            Try

                Dim arrParam() As DB2Parameter = New DB2Parameter(7) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOINCIDENCIAINTERACCION_BE.PropINCCODIGO
                arrParam(1) = New DB2Parameter("P_DTMINCIHORA", DB2Type.Timestamp)
                arrParam(1).Value = pCCOINCIDENCIAINTERACCION_BE.PropINCIHORA
                arrParam(2) = New DB2Parameter("P_VCHINCIRELATO", DB2Type.VarChar, 500)
                arrParam(2).Value = pCCOINCIDENCIAINTERACCION_BE.PropINCIRELATO
                arrParam(3) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VarChar, 150)
                arrParam(3).Value = pCCOINCIDENCIAINTERACCION_BE.PropAUDPRGCREACION
                arrParam(4) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VarChar, 60)
                arrParam(4).Value = pCCOINCIDENCIAINTERACCION_BE.PropAUDEQPCREACION
                arrParam(5) = New DB2Parameter("P_DTMAUDFECCREACION", DB2Type.Timestamp)
                arrParam(5).Value = pCCOINCIDENCIAINTERACCION_BE.PropAUDFECCREACION
                arrParam(6) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VarChar, 10)
                arrParam(6).Value = pCCOINCIDENCIAINTERACCION_BE.PropAUDUSUCREACION
                arrParam(7) = New DB2Parameter("P_INTAUDROLCREACION", DB2Type.Integer)
                arrParam(7).Value = pCCOINCIDENCIAINTERACCION_BE.PropAUDROLCREACION

                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIAINTERACCION_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function Listar(ByVal pINTINCCODIGO As Integer) As DataTable
            Dim odt As New DataTable
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(0).Value = pINTINCCODIGO
                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIAINTERACCION_LISTAR", arrParam)
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
