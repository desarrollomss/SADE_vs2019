Imports System.Configuration
Imports System
Imports AccesoDatosGEO
Imports SISSADE.BE
Imports Npgsql

Namespace DAL

	Public Class TB_COMPSEG_DL
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

        Public Function Insertar(ByVal pTB_COMPSEG_BE As TB_COMPSEG_BE) As Integer
            Try
                Dim MiCnx As ConnectionStringSettings = Nothing
                MiCnx = ConfigurationManager.ConnectionStrings("PgMSS")
                Dim cadena As String = MiCnx.ConnectionString

                Dim arrParam() As NpgsqlParameter = New NpgsqlParameter(13) {}
                arrParam(0) = New NpgsqlParameter("p_idcs", NpgsqlTypes.NpgsqlDbType.Integer)
                arrParam(0).Direction = ParameterDirection.Output
                arrParam(1) = New NpgsqlParameter("p_direccion", NpgsqlTypes.NpgsqlDbType.Varchar)
                arrParam(1).Value = pTB_COMPSEG_BE.PropDIRECCION
                arrParam(2) = New NpgsqlParameter("p_geom", NpgsqlTypes.NpgsqlDbType.Varchar)
                arrParam(2).Value = pTB_COMPSEG_BE.PropGEOM
                arrParam(3) = New NpgsqlParameter("p_idcst", NpgsqlTypes.NpgsqlDbType.Integer)
                arrParam(3).Value = pTB_COMPSEG_BE.PropIDCST
                arrParam(4) = New NpgsqlParameter("p_idcse", NpgsqlTypes.NpgsqlDbType.Integer)
                arrParam(4).Value = pTB_COMPSEG_BE.PropIDCSE
                arrParam(5) = New NpgsqlParameter("p_observ_est", NpgsqlTypes.NpgsqlDbType.Varchar)
                arrParam(5).Value = pTB_COMPSEG_BE.PropOBSERV_EST
                arrParam(6) = New NpgsqlParameter("p_info_cs", NpgsqlTypes.NpgsqlDbType.Varchar)
                arrParam(6).Value = pTB_COMPSEG_BE.PropINFO_CS
                arrParam(7) = New NpgsqlParameter("p_idcs_padre", NpgsqlTypes.NpgsqlDbType.Integer)
                arrParam(7).Value = pTB_COMPSEG_BE.PropIDCS_PADRE
                arrParam(8) = New NpgsqlParameter("p_comunica_cs", NpgsqlTypes.NpgsqlDbType.Varchar)
                arrParam(8).Value = pTB_COMPSEG_BE.PropCOMUNICA_CS
                arrParam(9) = New NpgsqlParameter("p_ipred_cs", NpgsqlTypes.NpgsqlDbType.Varchar)
                arrParam(9).Value = pTB_COMPSEG_BE.PropIPRED_CS
                arrParam(10) = New NpgsqlParameter("p_audusuario_crea", NpgsqlTypes.NpgsqlDbType.Varchar)
                arrParam(10).Value = pTB_COMPSEG_BE.PropAUDUSUARIO_CREA
                arrParam(11) = New NpgsqlParameter("p_audequipo_crea", NpgsqlTypes.NpgsqlDbType.Varchar)
                arrParam(11).Value = pTB_COMPSEG_BE.PropAUDEQUIPO_CREA
                arrParam(12) = New NpgsqlParameter("p_audfecha_crea", NpgsqlTypes.NpgsqlDbType.Timestamp)
                arrParam(12).Value = pTB_COMPSEG_BE.PropAUDFECHA_CREA
                arrParam(13) = New NpgsqlParameter("p_fecinst_cs", NpgsqlTypes.NpgsqlDbType.Date)
                arrParam(13).Value = pTB_COMPSEG_BE.PropFECINST_CS
                NpgsqlHelper.ExecuteDataset(cadena, CommandType.StoredProcedure, "sade.tb_compseg_insertar", arrParam)
                Return arrParam(0).Value
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

        Public Sub Actualizar(ByVal pTB_COMPSEG_BE As TB_COMPSEG_BE)
            Try
                Dim MiCnx As ConnectionStringSettings = Nothing
                MiCnx = ConfigurationManager.ConnectionStrings("PgMSS")
                Dim cadena As String = MiCnx.ConnectionString

                Dim arrParam() As NpgsqlParameter = New NpgsqlParameter(13) {}
                arrParam(0) = New NpgsqlParameter("p_idcs", NpgsqlTypes.NpgsqlDbType.Integer)
                arrParam(0).Value = pTB_COMPSEG_BE.PropIDCS
                arrParam(1) = New NpgsqlParameter("p_direccion", NpgsqlTypes.NpgsqlDbType.Varchar)
                arrParam(1).Value = pTB_COMPSEG_BE.PropDIRECCION
                arrParam(2) = New NpgsqlParameter("p_geom", NpgsqlTypes.NpgsqlDbType.Varchar)
                arrParam(2).Value = pTB_COMPSEG_BE.PropGEOM
                arrParam(3) = New NpgsqlParameter("p_idcst", NpgsqlTypes.NpgsqlDbType.Integer)
                arrParam(3).Value = pTB_COMPSEG_BE.PropIDCST
                arrParam(4) = New NpgsqlParameter("p_idcse", NpgsqlTypes.NpgsqlDbType.Integer)
                arrParam(4).Value = pTB_COMPSEG_BE.PropIDCSE
                arrParam(5) = New NpgsqlParameter("p_observ_est", NpgsqlTypes.NpgsqlDbType.Varchar)
                arrParam(5).Value = pTB_COMPSEG_BE.PropOBSERV_EST
                arrParam(6) = New NpgsqlParameter("p_info_cs", NpgsqlTypes.NpgsqlDbType.Varchar)
                arrParam(6).Value = pTB_COMPSEG_BE.PropINFO_CS
                arrParam(7) = New NpgsqlParameter("p_idcs_padre", NpgsqlTypes.NpgsqlDbType.Integer)
                arrParam(7).Value = pTB_COMPSEG_BE.PropIDCS_PADRE
                arrParam(8) = New NpgsqlParameter("p_comunica_cs", NpgsqlTypes.NpgsqlDbType.Varchar)
                arrParam(8).Value = pTB_COMPSEG_BE.PropCOMUNICA_CS
                arrParam(9) = New NpgsqlParameter("p_ipred_cs", NpgsqlTypes.NpgsqlDbType.Varchar)
                arrParam(9).Value = pTB_COMPSEG_BE.PropIPRED_CS
                arrParam(10) = New NpgsqlParameter("p_audusurio_crea", NpgsqlTypes.NpgsqlDbType.Varchar)
                arrParam(10).Value = pTB_COMPSEG_BE.PropAUDUSUARIO_CREA
                arrParam(11) = New NpgsqlParameter("p_audequipo_crea", NpgsqlTypes.NpgsqlDbType.Varchar)
                arrParam(11).Value = pTB_COMPSEG_BE.PropAUDEQUIPO_CREA
                arrParam(12) = New NpgsqlParameter("p_audfecha_crea", NpgsqlTypes.NpgsqlDbType.Timestamp)
                arrParam(12).Value = pTB_COMPSEG_BE.PropAUDFECHA_CREA
                arrParam(13) = New NpgsqlParameter("p_fecinst_cs", NpgsqlTypes.NpgsqlDbType.Date)
                arrParam(13).Value = pTB_COMPSEG_BE.PropFECINST_CS

                NpgsqlHelper.ExecuteDataset(cadena, CommandType.StoredProcedure, "sade.tb_compseg_actualizar", arrParam)

            Catch ex As Exception
                Throw ex
            Finally

            End Try
        End Sub

        Public Sub Eliminar(ByVal pTB_COMPSEG_BE As TB_COMPSEG_BE)
            Try
                Dim MiCnx As ConnectionStringSettings = Nothing
                MiCnx = ConfigurationManager.ConnectionStrings("PgMSS")
                Dim cadena As String = MiCnx.ConnectionString
                Dim arrParam() As NpgsqlParameter = New NpgsqlParameter(0) {}
                arrParam(0) = New NpgsqlParameter("p_idcs", NpgsqlTypes.NpgsqlDbType.Integer)
                arrParam(0).Value = pTB_COMPSEG_BE.PropIDCS
                NpgsqlHelper.ExecuteDataset(cadena, CommandType.StoredProcedure, "sade.tb_compseg_eliminar", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

        Public Function ListarKey(ByVal pTB_COMPSEG_BE As TB_COMPSEG_BE) As TB_COMPSEG_BE
            Dim oTB_COMPSEG_BE As New TB_COMPSEG_BE


            Dim dt As New DataTable
            Dim MiCnx As ConnectionStringSettings = Nothing
            MiCnx = ConfigurationManager.ConnectionStrings("PgMSS")
            Dim cadena As String = MiCnx.ConnectionString
            Dim strSQL As String = "SELECT "
            strSQL = strSQL + "  idcs, direccion,  '', idcst, idcse, observ_est, info_cs, idcs_padre, "
            strSQL = strSQL + "  comunica_cs, ipred_cs, audusuario_crea, audequipo_crea, audfecha_crea,"
            strSQL = strSQL + "  ST_x(ST_centroid(ST_Transform(geom,32718))) as _xgeo, ST_y(ST_centroid(ST_Transform(geom,32718))) as _ygeo, fecinst_cs "
            strSQL = strSQL + "  FROM sade.tb_compseg "
            strSQL = strSQL + " WHERE idcs = " + pTB_COMPSEG_BE.PropIDCS.ToString
            Try
                Dim oDataReader As IDataReader = NpgsqlHelper.ExecuteReader(cadena, CommandType.Text, strSQL)

                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.IDCS) Then oTB_COMPSEG_BE.PropIDCS = Nothing Else oTB_COMPSEG_BE.PropIDCS = CType(oDataReader(Campos.IDCS), Integer)
                    oTB_COMPSEG_BE.PropDIRECCION = IIf(oDataReader.IsDBNull(Campos.DIRECCION), "", oDataReader(Campos.DIRECCION))
                    If oDataReader.IsDBNull(Campos.GEOM) Then oTB_COMPSEG_BE.PropGEOM = Nothing Else oTB_COMPSEG_BE.PropGEOM = CType(oDataReader(Campos.GEOM), String)
                    If oDataReader.IsDBNull(Campos.IDCST) Then oTB_COMPSEG_BE.PropIDCST = Nothing Else oTB_COMPSEG_BE.PropIDCST = CType(oDataReader(Campos.IDCST), Integer)
                    If oDataReader.IsDBNull(Campos.IDCSE) Then oTB_COMPSEG_BE.PropIDCSE = Nothing Else oTB_COMPSEG_BE.PropIDCSE = CType(oDataReader(Campos.IDCSE), Integer)
                    oTB_COMPSEG_BE.PropOBSERV_EST = IIf(oDataReader.IsDBNull(Campos.OBSERV_EST), "", oDataReader(Campos.OBSERV_EST))
                    oTB_COMPSEG_BE.PropINFO_CS = IIf(oDataReader.IsDBNull(Campos.INFO_CS), "", oDataReader(Campos.INFO_CS))
                    If oDataReader.IsDBNull(Campos.IDCS_PADRE) Then oTB_COMPSEG_BE.PropIDCS_PADRE = Nothing Else oTB_COMPSEG_BE.PropIDCS_PADRE = CType(oDataReader(Campos.IDCS_PADRE), Integer)
                    oTB_COMPSEG_BE.PropCOMUNICA_CS = IIf(oDataReader.IsDBNull(Campos.COMUNICA_CS), "", oDataReader(Campos.COMUNICA_CS))
                    oTB_COMPSEG_BE.PropIPRED_CS = IIf(oDataReader.IsDBNull(Campos.IPRED_CS), "", oDataReader(Campos.IPRED_CS))
                    oTB_COMPSEG_BE.PropAUDUSUARIO_CREA = IIf(oDataReader.IsDBNull(Campos.AUDUSUARIO_CREA), "", oDataReader(Campos.AUDUSUARIO_CREA))
                    oTB_COMPSEG_BE.PropAUDEQUIPO_CREA = IIf(oDataReader.IsDBNull(Campos.AUDEQUIPO_CREA), "", oDataReader(Campos.AUDEQUIPO_CREA))
                    If oDataReader.IsDBNull(Campos.AUDFECHA_CREA) Then oTB_COMPSEG_BE.PropAUDFECHA_CREA = Nothing Else oTB_COMPSEG_BE.PropAUDFECHA_CREA = CType(oDataReader(Campos.AUDFECHA_CREA), DateTime)
                    oTB_COMPSEG_BE.PropGeoX = IIf(oDataReader.IsDBNull(Campos._xgeo), "", oDataReader(Campos._xgeo))
                    oTB_COMPSEG_BE.PropGeoY = IIf(oDataReader.IsDBNull(Campos._ygeo), "", oDataReader(Campos._ygeo))
                    If oDataReader.IsDBNull(Campos.FECINST_CS) Then oTB_COMPSEG_BE.PropFECINST_CS = Nothing Else oTB_COMPSEG_BE.PropFECINST_CS = CType(oDataReader(Campos.FECINST_CS), Date)
                Loop
            Catch ex As Exception
                Throw ex
            Finally
            End Try
            Return oTB_COMPSEG_BE
        End Function

        Public Function Listar(ByVal pTB_COMPSEG_BE As TB_COMPSEG_BE) As DataTable
            Dim dt As New DataTable
            Dim MiCnx As ConnectionStringSettings = Nothing
            MiCnx = ConfigurationManager.ConnectionStrings("PgMSS")
            Dim cadena As String = MiCnx.ConnectionString
            Dim strSQL As String = "SELECT "
            strSQL = strSQL + "idcs, direccion, geom, C.idcst, TC.nom as nomt, C.idcse, EC.nom as nome, observ_est, info_cs, idcs_padre, "
            strSQL = strSQL + "(SELECT direccion FROM sade.tb_compseg where idcs = c.idcs_padre) as Grupo, "
            strSQL = strSQL + "comunica_cs, ipred_cs, audusuario_crea, audequipo_crea, audfecha_crea, fecinst_cs, "
            strSQL = strSQL + " ST_x(ST_centroid(ST_Transform(geom,32718))) as _xgeo, ST_y(ST_centroid(ST_Transform(geom,32718))) as _ygeo "
            strSQL = strSQL + "  FROM sade.tb_compseg C join sade.tb_compseg_tipo TC on C.idcst = TC.idcst "
            strSQL = strSQL + "                         join sade.tb_compseg_estado EC on C.idcse = EC.idcse "
            strSQL = strSQL + " WHERE C.idcs is not null "
            If pTB_COMPSEG_BE.PropIDCS <> 0 Then
                strSQL = strSQL + " AND C.idcs = " + pTB_COMPSEG_BE.PropIDCS.ToString
            End If

            If pTB_COMPSEG_BE.PropIDCSE <> 0 Then
                strSQL = strSQL + " AND C.idcse = " + pTB_COMPSEG_BE.PropIDCSE.ToString
            End If

            If pTB_COMPSEG_BE.PropIDCST <> 0 Then
                strSQL = strSQL + " AND C.idcst = " + pTB_COMPSEG_BE.PropIDCST.ToString
            End If

            If pTB_COMPSEG_BE.PropDIRECCION <> "" Then
                strSQL = strSQL + " AND upper(C.direccion) like '%" + pTB_COMPSEG_BE.PropDIRECCION.ToUpper + "%' "
            End If

            If pTB_COMPSEG_BE.PropIDCS_PADRE <> 0 Then
                strSQL = strSQL + " AND C.idcs_padre = " + pTB_COMPSEG_BE.PropIDCS_PADRE.ToString
            End If

            If pTB_COMPSEG_BE.PropINFO_CS <> "" Then
                strSQL = strSQL + " AND upper(C.info_cs) like '%" + pTB_COMPSEG_BE.PropINFO_CS.ToUpper + "%' "
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
                '''If cnPsg.State = ConnectionState.Open Then cnPsg.Close()
            End Try
            Return dt
        End Function


        Public Function ListarComboTipoCmpnt() As DataTable
            Dim dt As New DataTable
            Dim MiCnx As ConnectionStringSettings = Nothing
            MiCnx = ConfigurationManager.ConnectionStrings("PgMSS")
            Dim cadena As String = MiCnx.ConnectionString
            Dim strSQL As String = "SELECT idcst as codigo, cod, nom as descripcion, icono FROM sade.tb_compseg_tipo order by idcst;"
            Try
                dt = NpgsqlHelper.ExecuteDataset(cadena, CommandType.Text, strSQL).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
            Return dt
        End Function

        Public Function ListarComboEstadoCmpnt() As DataTable
            Dim dt As New DataTable
            Dim MiCnx As ConnectionStringSettings = Nothing
            MiCnx = ConfigurationManager.ConnectionStrings("PgMSS")
            Dim cadena As String = MiCnx.ConnectionString
            Dim strSQL As String = "SELECT idcse as codigo, nom as descripcion FROM sade.tb_compseg_estado order by idcse;"
            Try
                dt = NpgsqlHelper.ExecuteDataset(cadena, CommandType.Text, strSQL).Tables(0)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
            Return dt
        End Function

        Public Function ListarComboGrupoCmpnt() As DataTable
            Dim dt As New DataTable
            Dim MiCnx As ConnectionStringSettings = Nothing
            MiCnx = ConfigurationManager.ConnectionStrings("PgMSS")
            Dim cadena As String = MiCnx.ConnectionString
            Dim strSQL As String = "SELECT idcs AS CODIGO, direccion AS DESCRIPCION FROM sade.tb_compseg where idcst = 2 order by direccion;"
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
