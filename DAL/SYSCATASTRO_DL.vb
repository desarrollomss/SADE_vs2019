Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

    Public Class SYSCATASTRO_DL
        Private cnDB2 As DB2Connection

#Region "Numerador"
        Public Enum Campos
            p_CHRTIPO = 0
            p_VCHDESCRIPCION = 1
            p_strdesvaloropc1 = 2
            p_strdesvaloropc2 = 3
        End Enum
#End Region

        Public Sub New()
            cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2("cadSATTI"))
        End Sub

        Public Function consultAutoVias(ByVal P_DESVIAS As String) As List(Of SYSCATASTRO_BE)
            Dim oSYSCATASTRO_BE As New SYSCATASTRO_BE
            Dim lstGeneral As New List(Of SYSCATASTRO_BE)

            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_DESVIAS", DB2Type.VarChar)
                arrParam(0).Value = P_DESVIAS
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "SIRCAT.SYSCATASTRO_AUTOCALLES_LISTAR", arrParam)
                Using oDataReader
                    Do While oDataReader.Read()
                        oSYSCATASTRO_BE = New SYSCATASTRO_BE
                        oSYSCATASTRO_BE.p_CHRTIPO = oDataReader.GetString(oDataReader.GetOrdinal("vchviacodigo"))
                        oSYSCATASTRO_BE.p_VCHDESCRIPCION = oDataReader.GetString(oDataReader.GetOrdinal("vchviadescripcion"))
                        oSYSCATASTRO_BE.p_strdesvaloropc1 = ""
                        oSYSCATASTRO_BE.p_strdesvaloropc2 = ""
                        lstGeneral.Add(oSYSCATASTRO_BE)
                    Loop
                End Using
                Return lstGeneral
            Catch ex As Exception
                Dim strErrNumber As String
                Dim strErrDescripcion As String
                strErrNumber = Err.Number.ToString
                strErrDescripcion = " Error en la consulta " + Err.Description.Trim
                oSYSCATASTRO_BE = New SYSCATASTRO_BE
                oSYSCATASTRO_BE.p_strdesvaloropc1 = strErrNumber
                oSYSCATASTRO_BE.p_strdesvaloropc2 = strErrDescripcion
                lstGeneral.Add(oSYSCATASTRO_BE)
                oSYSCATASTRO_BE = Nothing
                Return lstGeneral
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return lstGeneral
        End Function

        Public Function consultAutoCodCat(ByVal P_CODVIA As String) As List(Of SYSCATASTRO_BE)
            Dim oSYSCATASTRO_BE As New SYSCATASTRO_BE
            Dim lstGeneral As New List(Of SYSCATASTRO_BE)

            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_CODVIA", DB2Type.VarChar)
                arrParam(0).Value = P_CODVIA
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "SIRCAT.SYSCATASTRO_AUTOCODCAT_LISTAR", arrParam)
                Using oDataReader
                    Do While oDataReader.Read()
                        oSYSCATASTRO_BE = New SYSCATASTRO_BE
                        oSYSCATASTRO_BE.p_CHRTIPO = oDataReader.GetString(oDataReader.GetOrdinal("vchcodcat"))
                        oSYSCATASTRO_BE.p_VCHDESCRIPCION = oDataReader.GetString(oDataReader.GetOrdinal("vchnumero"))
                        oSYSCATASTRO_BE.p_strdesvaloropc1 = ""
                        oSYSCATASTRO_BE.p_strdesvaloropc2 = ""
                        lstGeneral.Add(oSYSCATASTRO_BE)
                    Loop
                End Using
                Return lstGeneral
            Catch ex As Exception
                Dim strErrNumber As String
                Dim strErrDescripcion As String
                strErrNumber = Err.Number.ToString
                strErrDescripcion = " Error en la consulta " + Err.Description.Trim
                oSYSCATASTRO_BE = New SYSCATASTRO_BE
                oSYSCATASTRO_BE.p_strdesvaloropc1 = strErrNumber
                oSYSCATASTRO_BE.p_strdesvaloropc2 = strErrDescripcion
                lstGeneral.Add(oSYSCATASTRO_BE)
                oSYSCATASTRO_BE = Nothing
                Return lstGeneral
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return lstGeneral
        End Function


        Public Function consultComboVias() As List(Of SYSCATASTRO_BE)
            Dim oSYSCATASTRO_BE As New SYSCATASTRO_BE
            Dim lstGeneral As New List(Of SYSCATASTRO_BE)

            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "SIRCAT.SYSCATASTRO_COMBOCALLES_LISTAR", arrParam)
                Using oDataReader
                    Do While oDataReader.Read()
                        oSYSCATASTRO_BE = New SYSCATASTRO_BE
                        oSYSCATASTRO_BE.p_CHRTIPO = oDataReader.GetString(oDataReader.GetOrdinal("vchviacodigo"))
                        oSYSCATASTRO_BE.p_VCHDESCRIPCION = oDataReader.GetString(oDataReader.GetOrdinal("vchvianombre"))
                        oSYSCATASTRO_BE.p_strdesvaloropc1 = ""
                        oSYSCATASTRO_BE.p_strdesvaloropc2 = ""
                        lstGeneral.Add(oSYSCATASTRO_BE)
                    Loop
                End Using
                Return lstGeneral
            Catch ex As Exception
                Dim strErrNumber As String
                Dim strErrDescripcion As String
                strErrNumber = Err.Number.ToString
                strErrDescripcion = " Error en la consulta " + Err.Description.Trim
                oSYSCATASTRO_BE = New SYSCATASTRO_BE
                oSYSCATASTRO_BE.p_strdesvaloropc1 = strErrNumber
                oSYSCATASTRO_BE.p_strdesvaloropc2 = strErrDescripcion
                lstGeneral.Add(oSYSCATASTRO_BE)
                oSYSCATASTRO_BE = Nothing
                Return lstGeneral
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return lstGeneral
        End Function


        Public Function listarkeyCodCat(ByVal P_CODCAT As String, ByVal P_CODVIA As String) As List(Of SYSCATASTRO_BE)
            Dim oSYSCATASTRO_BE As New SYSCATASTRO_BE
            Dim lstGeneral As New List(Of SYSCATASTRO_BE)

            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
                arrParam(0) = New DB2Parameter("P_CODCAT", DB2Type.VarChar)
                arrParam(0).Value = P_CODCAT
                arrParam(1) = New DB2Parameter("P_CODVIA", DB2Type.VarChar)
                arrParam(1).Value = P_CODVIA
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "SIRCAT.SYSCATASTRO_AUTOCODCAT_LISTARKEY", arrParam)
                Using oDataReader
                    Do While oDataReader.Read()
                        oSYSCATASTRO_BE = New SYSCATASTRO_BE
                        oSYSCATASTRO_BE.p_CHRTIPO = oDataReader.GetString(oDataReader.GetOrdinal("vchcodcat"))
                        oSYSCATASTRO_BE.p_VCHDESCRIPCION = oDataReader.GetString(oDataReader.GetOrdinal("vchnumero"))
                        oSYSCATASTRO_BE.p_strdesvaloropc1 = oDataReader.GetString(oDataReader.GetOrdinal("VCHLOTLATIT"))
                        oSYSCATASTRO_BE.p_strdesvaloropc2 = oDataReader.GetString(oDataReader.GetOrdinal("VCHLOTLONGI"))
                        lstGeneral.Add(oSYSCATASTRO_BE)
                    Loop
                End Using
                Return lstGeneral
            Catch ex As Exception
                Dim strErrNumber As String
                Dim strErrDescripcion As String
                strErrNumber = Err.Number.ToString
                strErrDescripcion = " Error en la consulta " + Err.Description.Trim
                oSYSCATASTRO_BE = New SYSCATASTRO_BE
                oSYSCATASTRO_BE.p_strdesvaloropc1 = strErrNumber
                oSYSCATASTRO_BE.p_strdesvaloropc2 = strErrDescripcion
                lstGeneral.Add(oSYSCATASTRO_BE)
                oSYSCATASTRO_BE = Nothing
                Return lstGeneral
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return lstGeneral
        End Function

        Public Function BuscarDireccion(ByVal pDIRECCION As String) As DataTable
            Dim odt As New DataTable
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
                arrParam(0) = New DB2Parameter("P_DIRECCION", DB2Type.VarChar, 150)
                arrParam(0).Value = pDIRECCION
                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "SIRCAT.BUSQUEDA_LOTE_DETALLE", arrParam)
                    odt.Load(dataReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return odt
        End Function


        Public Function ListarLoteDetalle(ByVal pCODLOTE As String) As DataTable
            Dim odt As New DataTable
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
                arrParam(0) = New DB2Parameter("P_CODCAT", DB2Type.VarChar, 8)
                arrParam(0).Value = pCODLOTE
                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "SIRCAT.BUSQUEDA_LOTE_DETALLE", arrParam)
                    odt.Load(dataReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return odt
        End Function

        Public Function ListarLoteLicencia(ByVal pCODLOTE As String) As DataTable
            Dim odt As New DataTable
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
                arrParam(0) = New DB2Parameter("P_CODCAT", DB2Type.VarChar, 8)
                arrParam(0).Value = pCODLOTE
                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "SIRCAT.BUSQUEDA_LOTE_LICENCIA", arrParam)
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
