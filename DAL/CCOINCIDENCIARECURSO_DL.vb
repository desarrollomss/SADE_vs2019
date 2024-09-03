Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

    Public Class CCOINCIDENCIARECURSO_DL
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


        Public Sub Insertar(ByVal pCCOINCIDENCIARECURSO_BE As CCOINCIDENCIARECURSO_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(9) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOINCIDENCIARECURSO_BE.PropINCCODIGO
                arrParam(1) = New DB2Parameter("P_DTMINCRASIGNA", DB2Type.Timestamp)
                arrParam(1).Value = pCCOINCIDENCIARECURSO_BE.PropINCRASIGNA
                arrParam(2) = New DB2Parameter("P_SMLTRECODIGO", DB2Type.Integer)
                arrParam(2).Value = pCCOINCIDENCIARECURSO_BE.PropTRECODIGO
                arrParam(3) = New DB2Parameter("P_INTRECCODIGO", DB2Type.Integer)
                arrParam(3).Value = pCCOINCIDENCIARECURSO_BE.PropRECCODIGO
                arrParam(4) = New DB2Parameter("P_VCHRECPERSONAL", DB2Type.VarChar, 100)
                arrParam(4).Value = pCCOINCIDENCIARECURSO_BE.PropRECPERSONAL
                arrParam(5) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VarChar, 150)
                arrParam(5).Value = pCCOINCIDENCIARECURSO_BE.PropAUDPRGCREACION
                arrParam(6) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VarChar, 60)
                arrParam(6).Value = pCCOINCIDENCIARECURSO_BE.PropAUDEQPCREACION
                arrParam(7) = New DB2Parameter("P_DTMAUDFECCREACION", DB2Type.Timestamp)
                arrParam(7).Value = pCCOINCIDENCIARECURSO_BE.PropAUDFECCREACION
                arrParam(8) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VarChar, 10)
                arrParam(8).Value = pCCOINCIDENCIARECURSO_BE.PropAUDUSUCREACION
                arrParam(9) = New DB2Parameter("P_INTAUDROLCREACION", DB2Type.Integer)
                arrParam(9).Value = pCCOINCIDENCIARECURSO_BE.PropAUDROLCREACION
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIARECURSO_INSERTAR", arrParam)
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
                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIARECURSO_LISTAR", arrParam)
                    odt.Load(dataReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return odt
        End Function

        Public Function ActualizaLlegada(ByVal pCCOINCIDENCIARECURSO_BE As CCOINCIDENCIARECURSO_BE) As DataTable
            Dim odt As New DataTable
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(5) {}
                arrParam(0) = New DB2Parameter("P_INTINCRCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOINCIDENCIARECURSO_BE.PropINCRCODIGO

                arrParam(1) = New DB2Parameter("P_VCHAUDPRGMODIF", DB2Type.VarChar, 150)
                arrParam(1).Value = pCCOINCIDENCIARECURSO_BE.PropAUDPRGMODIF
                arrParam(2) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VarChar, 60)
                arrParam(2).Value = pCCOINCIDENCIARECURSO_BE.PropAUDEQPMODIF
                arrParam(3) = New DB2Parameter("P_DTMAUDFECMODIF", DB2Type.Timestamp)
                arrParam(3).Value = pCCOINCIDENCIARECURSO_BE.PropAUDFECMODIF
                arrParam(4) = New DB2Parameter("P_VCHAUDUSUMODIF", DB2Type.VarChar, 10)
                arrParam(4).Value = pCCOINCIDENCIARECURSO_BE.PropAUDUSUMODIF
                arrParam(5) = New DB2Parameter("P_INTAUDROLMODIF", DB2Type.Integer)
                arrParam(5).Value = pCCOINCIDENCIARECURSO_BE.PropAUDROLMODIF

                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIARECURSO_ACTLLEGADA", arrParam)
                    odt.Load(dataReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return odt
        End Function

        Public Sub Eliminar(ByVal pCCOINCIDENCIARECURSO_BE As CCOINCIDENCIARECURSO_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(5) {}
                arrParam(0) = New DB2Parameter("P_INTINCRCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOINCIDENCIARECURSO_BE.PropINCRCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIARECURSO_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try

        End Sub


        Public Function AsignarRecursoAPP(ByVal pCCOINCIDENCIARECURSO_BE As CCOINCIDENCIARECURSO_BE) As Integer
            Dim result As Integer
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(10) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOINCIDENCIARECURSO_BE.PropINCCODIGO
                arrParam(1) = New DB2Parameter("P_DTMINCRASIGNA", DB2Type.Timestamp)
                arrParam(1).Value = pCCOINCIDENCIARECURSO_BE.PropINCRASIGNA
                arrParam(2) = New DB2Parameter("P_SMLTRECODIGO", DB2Type.Integer)
                arrParam(2).Value = pCCOINCIDENCIARECURSO_BE.PropTRECODIGO
                arrParam(3) = New DB2Parameter("P_INTRECCODIGO", DB2Type.Integer)
                arrParam(3).Value = pCCOINCIDENCIARECURSO_BE.PropRECCODIGO
                arrParam(4) = New DB2Parameter("P_VCHRECPERSONAL", DB2Type.VarChar, 100)
                arrParam(4).Value = pCCOINCIDENCIARECURSO_BE.PropRECPERSONAL
                arrParam(5) = New DB2Parameter("P_VCHAUDPRGCREACION", DB2Type.VarChar, 150)
                arrParam(5).Value = pCCOINCIDENCIARECURSO_BE.PropAUDPRGCREACION
                arrParam(6) = New DB2Parameter("P_VCHAUDEQPCREACION", DB2Type.VarChar, 60)
                arrParam(6).Value = pCCOINCIDENCIARECURSO_BE.PropAUDEQPCREACION
                arrParam(7) = New DB2Parameter("P_DTMAUDFECCREACION", DB2Type.Timestamp)
                arrParam(7).Value = pCCOINCIDENCIARECURSO_BE.PropAUDFECCREACION
                arrParam(8) = New DB2Parameter("P_VCHAUDUSUCREACION", DB2Type.VarChar, 10)
                arrParam(8).Value = pCCOINCIDENCIARECURSO_BE.PropAUDUSUCREACION
                arrParam(9) = New DB2Parameter("P_INTAUDROLCREACION", DB2Type.Integer)
                arrParam(9).Value = pCCOINCIDENCIARECURSO_BE.PropAUDROLCREACION
                arrParam(10) = New DB2Parameter("P_INTINCRCODIGO", DB2Type.Integer)
                arrParam(10).Direction = ParameterDirection.Output
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIARECURSO_ASIGNAR_APP", arrParam)
                result = arrParam(10).Value
                Return result
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return result
        End Function

        Public Sub LiberarRecursoAPP(ByVal pCCOINCIDENCIARECURSO_BE As CCOINCIDENCIARECURSO_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(6) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOINCIDENCIARECURSO_BE.PropINCCODIGO
                arrParam(1) = New DB2Parameter("P_INTINCRCODIGO", DB2Type.Integer)
                arrParam(1).Value = pCCOINCIDENCIARECURSO_BE.PropINCRCODIGO
                arrParam(2) = New DB2Parameter("P_VCHAUDPRGMODIF", DB2Type.VarChar, 150)
                arrParam(2).Value = pCCOINCIDENCIARECURSO_BE.PropAUDPRGMODIF
                arrParam(3) = New DB2Parameter("P_VCHAUDEQPMODIF", DB2Type.VarChar, 60)
                arrParam(3).Value = pCCOINCIDENCIARECURSO_BE.PropAUDEQPMODIF
                arrParam(4) = New DB2Parameter("P_DTMAUDFECMODIF", DB2Type.Timestamp)
                arrParam(4).Value = pCCOINCIDENCIARECURSO_BE.PropAUDFECMODIF
                arrParam(5) = New DB2Parameter("P_VCHAUDUSUMODIF", DB2Type.VarChar, 10)
                arrParam(5).Value = pCCOINCIDENCIARECURSO_BE.PropAUDUSUMODIF
                arrParam(6) = New DB2Parameter("P_INTAUDROLMODIF", DB2Type.Integer)
                arrParam(6).Value = pCCOINCIDENCIARECURSO_BE.PropAUDROLMODIF
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIARECURSO_LIBERAR_APP", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try

        End Sub



    End Class
End Namespace
