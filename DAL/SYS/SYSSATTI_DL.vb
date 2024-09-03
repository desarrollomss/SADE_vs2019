Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

    Public Class SATTI_DL
        Private cnDB2 As DB2Connection

        Public Sub New()
            cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2("cadSATTI"))
        End Sub

        Public Function ListaDetPredioCONS(ByVal pANOPRO As Integer, ByVal pNUMDDJJ As Integer, ByVal pCODPRE As Integer) As DataTable
            Dim odt As New DataTable
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(3) {}
                arrParam(0) = New DB2Parameter("PSMLANOANIOPRO", DB2Type.Integer)
                arrParam(0).Value = pANOPRO
                arrParam(1) = New DB2Parameter("PINTDJUNUMDDJJ", DB2Type.Integer)
                arrParam(1).Value = pNUMDDJJ
                arrParam(2) = New DB2Parameter("PINTPRECODIGO", DB2Type.Integer)
                arrParam(2).Value = pCODPRE
                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "SATT.DJURPTPRDETALLE", arrParam)
                    odt.Load(dataReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return odt
        End Function

        Public Function ListaDetPredioPU(ByVal pANOPRO As Integer, ByVal pNUMDDJJ As Integer, ByVal pCODPRE As Integer) As DataTable
            Dim odt As New DataTable
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(3) {}
                arrParam(0) = New DB2Parameter("PSMLANOANIOPRO", DB2Type.Integer)
                arrParam(0).Value = pANOPRO
                arrParam(1) = New DB2Parameter("PINTDJUNUMDDJJ", DB2Type.Integer)
                arrParam(1).Value = pNUMDDJJ
                arrParam(2) = New DB2Parameter("PINTPRECODIGO", DB2Type.Integer)
                arrParam(2).Value = pCODPRE
                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "SATT.RPTDJUPREDIOURBANO", arrParam)
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
