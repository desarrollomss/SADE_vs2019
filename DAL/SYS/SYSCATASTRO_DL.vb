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

        Public Function ListarLoteGIS(ByVal pCODLOTE As String) As DataSet
            Dim ods As New DataSet
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
                arrParam(0) = New DB2Parameter("P_CODCAT", DB2Type.VarChar, 10)
                arrParam(0).Value = pCODLOTE


                'Using cnDB2 As New DB2Connection(cnDB2)
                '    cnDB2.Open()
                ods = DB2helper.ExecuteDataset(cnDB2, CommandType.StoredProcedure, "SIRCAT.BUSQUEDA_LOTE_GIS", arrParam)
                'End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return ods
        End Function

        Public Function consultarViasGIS(ByVal P_NOMVIA As String) As List(Of SYSVIA_BE)
            Dim oSYSVIA_BE As New SYSVIA_BE
            Dim lstGeneral As New List(Of SYSVIA_BE)

            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_NOMVIA", DB2Type.VarChar)
                arrParam(0).Value = P_NOMVIA
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "SIRCAT.BUSQUEDA_VIA_GIS", arrParam)
                Using oDataReader
                    Do While oDataReader.Read()
                        oSYSVIA_BE = New SYSVIA_BE
                        'oSYSVIA_BE.pVCHCODVIA = oDataReader.GetString(oDataReader.GetOrdinal("vchcodvia"))
                        'oSYSVIA_BE.pVCHNOMVIA = oDataReader.GetString(oDataReader.GetOrdinal("vchnomvia"))
                        'oSYSVIA_BE.pVCHCODHU = oDataReader.GetString(oDataReader.GetOrdinal("vchcodhu"))
                        'oSYSVIA_BE.pVCHNOMHU = oDataReader.GetString(oDataReader.GetOrdinal("vchnomhu"))

                        oSYSVIA_BE.pVCHCODVIA = oDataReader.GetString(0)
                        oSYSVIA_BE.pVCHNOMVIA = oDataReader.GetString(1)
                        oSYSVIA_BE.pVCHCODHU = oDataReader.GetString(2)
                        oSYSVIA_BE.pVCHNOMHU = oDataReader.GetString(3)

                        oSYSVIA_BE.pstrdesvaloropc1 = ""
                        oSYSVIA_BE.pstrdesvaloropc2 = ""
                        lstGeneral.Add(oSYSVIA_BE)
                    Loop
                End Using
                Return lstGeneral
            Catch ex As Exception
                Dim strErrNumber As String
                Dim strErrDescripcion As String
                strErrNumber = Err.Number.ToString
                strErrDescripcion = " Error en la consulta " + Err.Description.Trim
                oSYSVIA_BE = New SYSVIA_BE
                oSYSVIA_BE.pstrdesvaloropc1 = strErrNumber
                oSYSVIA_BE.pstrdesvaloropc2 = strErrDescripcion
                lstGeneral.Add(oSYSVIA_BE)
                oSYSVIA_BE = Nothing
                Return lstGeneral
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return lstGeneral
        End Function

        Public Function consultarNroGIS(ByVal P_CODVIA As String) As List(Of SYSNRO_BE)
            Dim oSYSNRO_BE As New SYSNRO_BE
            Dim lstGeneral As New List(Of SYSNRO_BE)

            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_CODVIA", DB2Type.VarChar)
                arrParam(0).Value = P_CODVIA
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "SIRCAT.BUSQUEDA_NRO_GIS", arrParam)
                Using oDataReader
                    Do While oDataReader.Read()
                        oSYSNRO_BE = New SYSNRO_BE

                        oSYSNRO_BE.pVCHCODLOTE = oDataReader.GetString(0)
                        oSYSNRO_BE.pVCHCODLOTEGIS = oDataReader.GetString(1)
                        oSYSNRO_BE.pVCHNROVIA = oDataReader.GetString(2)
                        oSYSNRO_BE.pVCHNROINT = oDataReader.GetString(3)
                        oSYSNRO_BE.pVCHLOTHU = oDataReader.GetString(4)
                        oSYSNRO_BE.pVCHNOMHU = oDataReader.GetString(5)
                        oSYSNRO_BE.pstrdesvaloropc1 = ""
                        oSYSNRO_BE.pstrdesvaloropc2 = ""

                        lstGeneral.Add(oSYSNRO_BE)
                    Loop
                End Using
                Return lstGeneral
            Catch ex As Exception
                Dim strErrNumber As String
                Dim strErrDescripcion As String
                strErrNumber = Err.Number.ToString
                strErrDescripcion = " Error en la consulta " + Err.Description.Trim
                oSYSNRO_BE = New SYSNRO_BE
                oSYSNRO_BE.pstrdesvaloropc1 = strErrNumber
                oSYSNRO_BE.pstrdesvaloropc2 = strErrDescripcion
                lstGeneral.Add(oSYSNRO_BE)
                oSYSNRO_BE = Nothing
                Return lstGeneral
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return lstGeneral
        End Function

        Public Function ListarCodLoteGIS(ByVal pCODLOTE As String) As DataTable
            Dim odt As New DataTable
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
                arrParam(0) = New DB2Parameter("P_CODCAT", DB2Type.VarChar, 10)
                arrParam(0).Value = pCODLOTE
                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "SIRCAT.BUSQUEDA_CODLOTE_GIS", arrParam)
                    odt.Load(dataReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return odt
        End Function

        Public Function ListarAdminGIS(ByVal pNOMBRE As String) As DataTable
            Dim odt As New DataTable
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
                arrParam(0) = New DB2Parameter("P_NOMBRE", DB2Type.VarChar, 100)
                arrParam(0).Value = pnombre
                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "SIRCAT.BUSQUEDA_ADMIN_GIS", arrParam)
                    odt.Load(dataReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return odt
        End Function


        Public Sub GuardaLotesFIS(ByVal pTOKEN As String, ByVal pCODLOTE As String, ByVal pPOSLAT As String, ByVal pPOSLON As String, ByVal pDISTANCE As Decimal)
            Dim odt As New DataTable
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(4) {}
                arrParam(0) = New DB2Parameter("P_VCHTOKEN", DB2Type.VarChar, 50)
                arrParam(0).Value = pTOKEN
                arrParam(1) = New DB2Parameter("P_VCHCODLOTE", DB2Type.VarChar, 10)
                arrParam(1).Value = pCODLOTE
                arrParam(2) = New DB2Parameter("P_VCHUBICLAT", DB2Type.VarChar, 20)
                arrParam(2).Value = pPOSLAT
                arrParam(3) = New DB2Parameter("P_VCHUBICLON", DB2Type.VarChar, 20)
                arrParam(3).Value = pPOSLON
                arrParam(4) = New DB2Parameter("P_DECDISTANCE", DB2Type.Decimal, 18, 2)
                arrParam(4).Value = pDISTANCE
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "SIRCAT.FISLOTEGEO_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarLoteFIS(ByVal pTOKEN As String) As DataTable
            Dim odt As New DataTable
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(1) {}
                arrParam(0) = New DB2Parameter("P_TOKEN", DB2Type.VarChar, 50)
                arrParam(0).Value = pTOKEN
                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "SIRCAT.FISLOTEGEO_LISTAR", arrParam)
                    odt.Load(dataReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return odt
        End Function

        Public Sub ActualizaLotesFIS(ByVal pBE As FISPREDIO_BE)
            Dim odt As New DataTable
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(7) {}
                arrParam(0) = New DB2Parameter("p_INTREGCODIGO", DB2Type.Integer)
                arrParam(0).Value = pBE.p_INTREGCODIGO
                arrParam(1) = New DB2Parameter("p_SMLFISESTADO", DB2Type.Integer)
                arrParam(1).Value = pBE.p_SMLFISESTADO
                arrParam(2) = New DB2Parameter("p_SMLFISDEUDA", DB2Type.Integer)
                arrParam(2).Value = pBE.p_SMLFISDEUDA
                arrParam(3) = New DB2Parameter("p_SMLFISMULTA", DB2Type.Integer)
                arrParam(3).Value = pBE.p_SMLFISMULTA
                arrParam(4) = New DB2Parameter("p_DECFISDEUDA", DB2Type.Decimal, 18, 2)
                arrParam(4).Value = pBE.p_DECFISDEUDA
                arrParam(5) = New DB2Parameter("p_DECFISMULTA", DB2Type.Decimal, 18, 2)
                arrParam(5).Value = pBE.p_DECFISMULTA
                arrParam(6) = New DB2Parameter("p_VCHFISOSERV", DB2Type.VarChar, 100)
                arrParam(6).Value = pBE.p_VCHFISOSERV
                arrParam(7) = New DB2Parameter("p_VCHAUDUSUMODIF", DB2Type.VarChar, 20)
                arrParam(7).Value = pBE.p_VCHAUDUSUMODIF
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "SIRCAT.FISLOTEGEO_ACTUALIZAR", arrParam)

            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function BuscarLoteFIS(ByVal pBE As FISPREDIO_BE) As DataTable
            Dim odt As New DataTable
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(3) {}
                arrParam(0) = New DB2Parameter("P_VCHCODLOTE", DB2Type.VarChar, 30)
                arrParam(0).Value = pBE.p_INTREGCODIGO
                arrParam(1) = New DB2Parameter("P_SMLFISESTADO", DB2Type.SmallInt)
                arrParam(1).Value = pBE.p_SMLFISESTADO
                arrParam(2) = New DB2Parameter("P_VCHCODSEC", DB2Type.VarChar, 5)
                arrParam(2).Value = pBE.p_SMLFISDEUDA
                arrParam(3) = New DB2Parameter("P_VCHCODURB", DB2Type.VarChar, 5)
                arrParam(3).Value = pBE.p_SMLFISMULTA

                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "SIRCAT.FISLOTEGEO_BUSCAR", arrParam)
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
