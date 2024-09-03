Imports System.Configuration
Imports System
Imports AccesoDatosGEO
Imports SISSADE.BE
Imports Npgsql

Namespace DAL

    Public Class TB_CAMARA_DL
        Private cnPsg As NpgsqlConnection

#Region "Numerador"
        Public Enum Campos
            IDCS = 0
            DIRECCION = 1
            GEOM = 2
            IDCST = 3
            IDCSE = 4
            OBSERV_EST = 5
            INFO_CS = 6
            IDCS_PADRE = 7
            COMUNICA_CS = 8
            IPRED_CS = 9
            AUDUSUARIO_CREA = 10
            AUDEQUIPO_CREA = 11
            AUDFECHA_CREA = 12
            _xgeo = 13
            _ygeo = 14
            FECINST_CS = 15
        End Enum
#End Region

        'Public Sub New()
        '    cnPsg = New NpgsqlConnection(Postgre_Conexion.Coneccion)
        'End Sub

        Public Function Insertar(ByVal pTB_CAMARA_BE As TB_CAMARA_BE) As Integer
            Try
                Dim MiCnx As ConnectionStringSettings = Nothing
                MiCnx = ConfigurationManager.ConnectionStrings("PgMSS")
                Dim cadena As String = MiCnx.ConnectionString

                Dim arrParam() As NpgsqlParameter = New NpgsqlParameter(13) {}
                arrParam(0) = New NpgsqlParameter("p_idcs", NpgsqlTypes.NpgsqlDbType.Integer)
                arrParam(0).Direction = ParameterDirection.Output
                'arrParam(1) = New NpgsqlParameter("p_direccion", NpgsqlTypes.NpgsqlDbType.Varchar)
                'arrParam(1).Value = pTB_COMPSEG_BE.PropDIRECCION
                'arrParam(2) = New NpgsqlParameter("p_geom", NpgsqlTypes.NpgsqlDbType.Varchar)
                'arrParam(2).Value = pTB_COMPSEG_BE.PropGEOM
                'arrParam(3) = New NpgsqlParameter("p_idcst", NpgsqlTypes.NpgsqlDbType.Integer)
                'arrParam(3).Value = pTB_COMPSEG_BE.PropIDCST
                'arrParam(4) = New NpgsqlParameter("p_idcse", NpgsqlTypes.NpgsqlDbType.Integer)
                'arrParam(4).Value = pTB_COMPSEG_BE.PropIDCSE
                'arrParam(5) = New NpgsqlParameter("p_observ_est", NpgsqlTypes.NpgsqlDbType.Varchar)
                'arrParam(5).Value = pTB_COMPSEG_BE.PropOBSERV_EST
                'arrParam(6) = New NpgsqlParameter("p_info_cs", NpgsqlTypes.NpgsqlDbType.Varchar)
                'arrParam(6).Value = pTB_COMPSEG_BE.PropINFO_CS
                'arrParam(7) = New NpgsqlParameter("p_idcs_padre", NpgsqlTypes.NpgsqlDbType.Integer)
                'arrParam(7).Value = pTB_COMPSEG_BE.PropIDCS_PADRE
                'arrParam(8) = New NpgsqlParameter("p_comunica_cs", NpgsqlTypes.NpgsqlDbType.Varchar)
                'arrParam(8).Value = pTB_COMPSEG_BE.PropCOMUNICA_CS
                'arrParam(9) = New NpgsqlParameter("p_ipred_cs", NpgsqlTypes.NpgsqlDbType.Varchar)
                'arrParam(9).Value = pTB_COMPSEG_BE.PropIPRED_CS
                'arrParam(10) = New NpgsqlParameter("p_audusuario_crea", NpgsqlTypes.NpgsqlDbType.Varchar)
                'arrParam(10).Value = pTB_COMPSEG_BE.PropAUDUSUARIO_CREA
                'arrParam(11) = New NpgsqlParameter("p_audequipo_crea", NpgsqlTypes.NpgsqlDbType.Varchar)
                'arrParam(11).Value = pTB_COMPSEG_BE.PropAUDEQUIPO_CREA
                'arrParam(12) = New NpgsqlParameter("p_audfecha_crea", NpgsqlTypes.NpgsqlDbType.Timestamp)
                'arrParam(12).Value = pTB_COMPSEG_BE.PropAUDFECHA_CREA
                'arrParam(13) = New NpgsqlParameter("p_fecinst_cs", NpgsqlTypes.NpgsqlDbType.Date)
                'arrParam(13).Value = pTB_COMPSEG_BE.PropFECINST_CS
                NpgsqlHelper.ExecuteDataset(cadena, CommandType.StoredProcedure, "sade.tb_compseg_insertar", arrParam)
                Return arrParam(0).Value
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

        Public Sub Actualizar(ByVal pTB_CAMARA_BE As TB_CAMARA_BE)
            Try
                Dim MiCnx As ConnectionStringSettings = Nothing
                MiCnx = ConfigurationManager.ConnectionStrings("PgMSS")
                Dim cadena As String = MiCnx.ConnectionString

                Dim arrParam() As NpgsqlParameter = New NpgsqlParameter(13) {}
                'arrParam(0) = New NpgsqlParameter("p_idcs", NpgsqlTypes.NpgsqlDbType.Integer)
                'arrParam(0).Value = pTB_COMPSEG_BE.PropIDCS
                'arrParam(1) = New NpgsqlParameter("p_direccion", NpgsqlTypes.NpgsqlDbType.Varchar)
                'arrParam(1).Value = pTB_COMPSEG_BE.PropDIRECCION
                'arrParam(2) = New NpgsqlParameter("p_geom", NpgsqlTypes.NpgsqlDbType.Varchar)
                'arrParam(2).Value = pTB_COMPSEG_BE.PropGEOM
                'arrParam(3) = New NpgsqlParameter("p_idcst", NpgsqlTypes.NpgsqlDbType.Integer)
                'arrParam(3).Value = pTB_COMPSEG_BE.PropIDCST
                'arrParam(4) = New NpgsqlParameter("p_idcse", NpgsqlTypes.NpgsqlDbType.Integer)
                'arrParam(4).Value = pTB_COMPSEG_BE.PropIDCSE
                'arrParam(5) = New NpgsqlParameter("p_observ_est", NpgsqlTypes.NpgsqlDbType.Varchar)
                'arrParam(5).Value = pTB_COMPSEG_BE.PropOBSERV_EST
                'arrParam(6) = New NpgsqlParameter("p_info_cs", NpgsqlTypes.NpgsqlDbType.Varchar)
                'arrParam(6).Value = pTB_COMPSEG_BE.PropINFO_CS
                'arrParam(7) = New NpgsqlParameter("p_idcs_padre", NpgsqlTypes.NpgsqlDbType.Integer)
                'arrParam(7).Value = pTB_COMPSEG_BE.PropIDCS_PADRE
                'arrParam(8) = New NpgsqlParameter("p_comunica_cs", NpgsqlTypes.NpgsqlDbType.Varchar)
                'arrParam(8).Value = pTB_COMPSEG_BE.PropCOMUNICA_CS
                'arrParam(9) = New NpgsqlParameter("p_ipred_cs", NpgsqlTypes.NpgsqlDbType.Varchar)
                'arrParam(9).Value = pTB_COMPSEG_BE.PropIPRED_CS
                'arrParam(10) = New NpgsqlParameter("p_audusurio_crea", NpgsqlTypes.NpgsqlDbType.Varchar)
                'arrParam(10).Value = pTB_COMPSEG_BE.PropAUDUSUARIO_CREA
                'arrParam(11) = New NpgsqlParameter("p_audequipo_crea", NpgsqlTypes.NpgsqlDbType.Varchar)
                'arrParam(11).Value = pTB_COMPSEG_BE.PropAUDEQUIPO_CREA
                'arrParam(12) = New NpgsqlParameter("p_audfecha_crea", NpgsqlTypes.NpgsqlDbType.Timestamp)
                'arrParam(12).Value = pTB_COMPSEG_BE.PropAUDFECHA_CREA
                'arrParam(13) = New NpgsqlParameter("p_fecinst_cs", NpgsqlTypes.NpgsqlDbType.Date)
                'arrParam(13).Value = pTB_COMPSEG_BE.PropFECINST_CS

                NpgsqlHelper.ExecuteDataset(cadena, CommandType.StoredProcedure, "sade.tb_compseg_actualizar", arrParam)

            Catch ex As Exception
                Throw ex
            Finally

            End Try
        End Sub

        Public Sub Eliminar(ByVal pTB_CAMARA_BE As TB_CAMARA_BE)
            Try
                Dim MiCnx As ConnectionStringSettings = Nothing
                MiCnx = ConfigurationManager.ConnectionStrings("PgMSS")
                Dim cadena As String = MiCnx.ConnectionString
                Dim arrParam() As NpgsqlParameter = New NpgsqlParameter(0) {}
                'arrParam(0) = New NpgsqlParameter("p_idcs", NpgsqlTypes.NpgsqlDbType.Integer)
                'arrParam(0).Value = pTB_COMPSEG_BE.PropIDCS
                NpgsqlHelper.ExecuteDataset(cadena, CommandType.StoredProcedure, "sade.tb_compseg_eliminar", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub


        Public Function Busqueda(ByVal pTB_CAMARA_BE As TB_CAMARA_BE) As DataTable
            Dim dt As New DataTable
            Dim MiCnx As ConnectionStringSettings = Nothing
            MiCnx = ConfigurationManager.ConnectionStrings("PgMSS")
            Dim cadena As String = MiCnx.ConnectionString


            Dim strSQL As String = "Select cam.intidcamara, cam.intcodmarca, m.vchdesmarca, cam.vchmodelo, cam.vchnroserie, cam.intcodcovv, covv.vchdescovv, cam.vchipcamara, cam.vchlat, cam.vchlon,  "
            strSQL += " cam.vchcodarea, cam.vchcodsector, cam.vchssecvecinal, cam.vchcodcuadrante, cam.vchcodaxxon, cam.vchubicacion, cam.vchurbanizacion, cam.txtestado, cam.vchobserva, "
            strSQL += " cam.intcodestado, e.vchdesestado, "
            strSQL += " cam.vchaudusuariocrea, cam.vchaudequipocrea, cam.tmsaudfechacrea, cam.vchaudusuariomodif, cam.vchaudequipomodif, cam.tmsaudfechamodif "
            strSQL += "     From sade.tb_camara cam inner Join sade.tb_camaramarca m ON (cam.intcodmarca = m.intcodmarca) "
            strSQL += " 	                        inner Join sade.tb_camaraestado e On (cam.intcodestado = e.intcodestado) "
            strSQL += " 							inner Join sade.tb_covv covv ON (cam.intcodcovv = covv.intcodcovv) "
            strSQL += " Where cam.intidcamara <> 0 "


            If pTB_CAMARA_BE.PropINTCODMARCA <> 0 Then
                strSQL = strSQL + " And cam.intcodmarca = " + pTB_CAMARA_BE.PropINTCODMARCA.ToString
            End If

            If pTB_CAMARA_BE.PropINTCODCOVV <> 0 Then
                strSQL = strSQL + " And cam.intcodcovv = " + pTB_CAMARA_BE.PropINTCODCOVV.ToString
            End If

            If pTB_CAMARA_BE.PropINTCODESTADO <> 0 Then
                strSQL = strSQL + " And cam.intcodestado = " + pTB_CAMARA_BE.PropINTCODESTADO.ToString
            End If

            If pTB_CAMARA_BE.PropVCHUBICACION <> "" Then
                strSQL = strSQL + " And upper(cam.vchubicacion) Like '%" + pTB_CAMARA_BE.PropVCHUBICACION.ToUpper + "%' "
            End If

            If pTB_CAMARA_BE.PropVCHOBSERVA <> "" Then
                strSQL = strSQL + " AND upper(cam.vchobserva) like '%" + pTB_CAMARA_BE.PropVCHOBSERVA.ToUpper + "%' "
            End If

            Try
                'Dim arrParam() As NpgsqlParameter = New NpgsqlParameter(0) {}
                'arrParam(0) = New NpgsqlParameter("p_idcs", NpgsqlTypes.NpgsqlDbType.Integer)
                'arrParam(0).Value = pTB_COMPSEG_BE.PropIDCS
                'dt = NpgsqlHelper.ExecuteDataset(cadena, CommandType.StoredProcedure, "sade.spu_tb_compseg_listar").Tables(0)
                dt = NpgsqlHelper.ExecuteDataset(cadena, CommandType.Text, strSQL).Tables(0)

            Catch ex As Exception
                Throw ex
            Finally
                'If cnPsg.State = ConnectionState.Open Then cnPsg.Close()
            End Try
            Return dt
        End Function

        Public Function ListarComboEstado() As DataTable
            Dim dt As New DataTable
            Dim MiCnx As ConnectionStringSettings = Nothing
            MiCnx = ConfigurationManager.ConnectionStrings("PgMSS")
            Dim cadena As String = MiCnx.ConnectionString
            Dim strSQL As String = "SELECT intcodestado as codigo, vchdesestado as descripcion FROM sade.tb_camaraestado order by intcodestado;"
            Try
                dt = NpgsqlHelper.ExecuteDataset(cadena, CommandType.Text, strSQL).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
            Return dt
        End Function

        Public Function ListarComboCOVV() As DataTable
            Dim dt As New DataTable
            Dim MiCnx As ConnectionStringSettings = Nothing
            MiCnx = ConfigurationManager.ConnectionStrings("PgMSS")
            Dim cadena As String = MiCnx.ConnectionString
            Dim strSQL As String = "SELECT intcodcovv as codigo, vchdescovv as descripcion FROM sade.tb_covv order by intcodcovv;"
            Try
                dt = NpgsqlHelper.ExecuteDataset(cadena, CommandType.Text, strSQL).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
            Return dt
        End Function

        Public Function ListarComboMarca() As DataTable
            Dim dt As New DataTable
            Dim MiCnx As ConnectionStringSettings = Nothing
            MiCnx = ConfigurationManager.ConnectionStrings("PgMSS")
            Dim cadena As String = MiCnx.ConnectionString
            Dim strSQL As String = "SELECT intcodmarca as codigo, vchdesmarca as descripcion FROM sade.tb_camaramarca order by intcodmarca;"
            Try
                dt = NpgsqlHelper.ExecuteDataset(cadena, CommandType.Text, strSQL).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
            Return dt
        End Function

    End Class
End Namespace
