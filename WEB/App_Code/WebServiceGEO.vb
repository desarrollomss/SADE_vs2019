Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Diagnostics
Imports System.ComponentModel
Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Newtonsoft.Json
Imports System
Imports System.Web.Script.Services
Imports System.ServiceModel
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Configuration
Imports AccesoDatosGEO
Imports SISSADE.BL
Imports SISSADE.BE

' </summary>
' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class WebServiceGEO

    Inherits System.Web.Services.WebService

    Dim oGPSPOSICION_BL As New GPSPOSICION_BL

    Public jsoncallback As String


    'Uncomment the following line if using designed components 
    'InitializeComponent(); 
    Public Sub New()
    End Sub


    <WebMethod()> _
    Public Function buscaLote(ByVal pCODLOTE As String) As List(Of Lote)
        Dim MiCnx As ConnectionStringSettings = Nothing
        MiCnx = ConfigurationManager.ConnectionStrings("PgMSS")
        Dim cadena As String = MiCnx.ConnectionString
        Dim sql As String = " SELECT  l.cod, l.cod_lthu, l.cod_mzhu, hu.cod AS codhu, hu.denom, "
        sql += "  catastro.sp_fotolote(l.cod) as codfoto, "
        ' -- substring(l.cod, 1, 2)||'\40'||substring(l.cod,1,2)||substring(l.cod,4,2)||substring(l.cod,7,2) as codfoto, "
        sql += " ST_x(ST_centroid(ST_Transform(l.geom,32718))) as _xgeo, ST_y(ST_centroid(ST_Transform(l.geom,32718))) as _ygeo, l.geom as geom , ST_AsGeoJSON(ST_Transform(l.geom,32718),15,0) as geometria, (ST_x(ST_centroid(ST_Transform(l.geom,32718))) || ' ' || ST_y(ST_centroid(ST_Transform(l.geom,32718)))) as coord "
        sql += " FROM carto.tb_lote AS l"
        sql += " INNER JOIN carto.tb_ha_urbana AS hu on l.idhu=hu.idhu"
        sql += " WHERE l.cod ILIKE '%" + pCODLOTE + "%' ORDER BY l.cod"

        Dim dtP As New DataTable()
        dtP = NpgsqlHelper.ExecuteDataset(cadena, CommandType.Text, sql).Tables(0)
        Dim oLote As New List(Of Lote)()
        For Each row As DataRow In dtP.Rows
            Dim oL As New Lote()
            oL.codLote = row("cod").ToString()
            oL.codLHU = row("cod_lthu").ToString()
            oL.codMZU = row("cod_mzhu").ToString()
            oL.codHU = row("codhu").ToString()
            oL.denHU = row("denom").ToString()
            oL.xGeo = row("_xgeo").ToString()
            oL.yGeo = row("_ygeo").ToString()
            oL.Geom = row("geom").ToString()
            oL.xyCord = row("coord").ToString()
            oL.Poly = row("geometria").ToString()
            oL.codFoto = row("codfoto").ToString()
            oLote.Add(oL)
        Next
        Return oLote
    End Function

    <WebMethod()> _
    Public Function buscaLoteXY(ByVal pX As String, ByVal pY As String) As List(Of Lote)
        Dim MiCnx As ConnectionStringSettings = Nothing
        MiCnx = ConfigurationManager.ConnectionStrings("PgMSS")
        Dim cadena As String = MiCnx.ConnectionString
        Dim pgsql As String = " SELECT l.cod, l.cod_lthu, l.cod_mzhu, hu.cod AS codhu, hu.denom, "
        ' pgsql += "  substring(l.cod,1,2)||'\40'||substring(l.cod,1,2)||substring(l.cod,4,2)||substring(l.cod,7,2) as codfoto, "
        pgsql += "  catastro.sp_fotolote(l.cod) as codfoto, "
        pgsql += "  substring(l.cod,1,2)||'\40'||substring(l.cod,1,2)||substring(l.cod,4,2)||substring(l.cod,7,2) as codfoto, "
        pgsql += "  ST_area(l.geom) AS geom, ST_x(ST_centroid(l.geom)) as _xgeo, ST_y(ST_centroid(l.geom)) as _ygeo, "
        pgsql += "  ST_AsGeoJSON(ST_Transform(l.geom,32718),15,0) as geometria, "
        pgsql += "  (ST_x(ST_centroid(ST_Transform(l.geom,32718))) || ' ' || ST_y(ST_centroid(ST_Transform(l.geom,32718)))) as coord, "
        pgsql += "  box2d(l.geom) as extends "
        pgsql += " FROM carto.tb_lote AS l"
        pgsql += " INNER JOIN carto.tb_ha_urbana AS hu on l.idhu=hu.idhu"
        pgsql += " WHERE  ST_contains(l.geom, ST_Transform(ST_GeomFromText('POINT(" + pX + " " + pY + ")',32718),32718)) LIMIT 1 "


        Dim dtP As New DataTable()
        dtP = NpgsqlHelper.ExecuteDataset(cadena, CommandType.Text, pgsql).Tables(0)
        Dim oLote As New List(Of Lote)()
        For Each row As DataRow In dtP.Rows
            Dim oL As New Lote()

            oL.codLote = row("cod").ToString()
            oL.codLHU = row("cod_lthu").ToString()
            oL.codMZU = row("cod_mzhu").ToString()
            oL.codHU = row("codhu").ToString()
            oL.denHU = row("denom").ToString()
            oL.xGeo = row("_xgeo").ToString()
            oL.yGeo = row("_ygeo").ToString()
            oL.Geom = row("geom").ToString()
            oL.xyCord = row("coord").ToString()
            oL.Poly = row("geometria").ToString()
            oL.codFoto = row("codfoto").ToString()
            oL.Extend = row("extends").ToString().Replace(" ", ",").Replace("BOX(", "").Replace(")", "")
            oLote.Add(oL)
        Next
        Return oLote
    End Function

    '<WebMethod()> _
    'Public Function gpsPosicionListar() As List(Of GPSPOSICION_BE)
    '    Return oGPSPOSICION_BL.Listar
    'End Function

    <WebMethod(EnableSession:=True)> _
    Public Function buscarCalle() As List(Of Calle)

        Dim MiCnx As ConnectionStringSettings = Nothing
        MiCnx = ConfigurationManager.ConnectionStrings("PgMSS")
        Dim cadena As String = MiCnx.ConnectionString

        Dim pgsql As String
        pgsql = "SELECT v.idvia,v.cod, v.nom_act as nom_act,vh.apr_acon ,vh.cla_vial ,c.nro_cdra, "
        pgsql += "  ST_x(ST_centroid(ST_Transform(c.geom,32718))) as _xgeo,ST_y(ST_centroid(ST_Transform(c.geom,32718))) as _ygeo,"
        pgsql += "  ST_AsGeoJSON(ST_Transform(c.geom,32718),15,0) as geom "
        pgsql += " FROM carto.tb_via AS v"
        pgsql += " INNER JOIN carto.tb_via_hisn  AS vh ON v.idvia=vh.idvia and act=1"
        pgsql += " INNER JOIN carto.tb_via_cuadra AS c ON v.idvia=c.idvia"
        pgsql += " ORDER BY v.idvia, c.nro_cdra"

        Dim dtP As New DataTable()
        dtP = NpgsqlHelper.ExecuteDataset(cadena, CommandType.Text, pgsql).Tables(0)

        Dim oCalle As New List(Of Calle)
        For Each row As DataRow In dtP.Rows
            Dim oC As New Calle()
            oC.idvia = row("idvia").ToString()
            oC.codvia = row("cod").ToString()
            oC.nomvia = row("nom_act").ToString()
            oC.nrocdra = row("nro_cdra").ToString()
            oC.xGeo = row("_xgeo").ToString()
            oC.yGeo = row("_ygeo").ToString()
            oC.Geom = row("geom").ToString()
            oCalle.Add(oC)
        Next
        Return oCalle
    End Function

    '<WebMethod()> _
    'Public Function convierteXY(ByVal pX As String, ByVal pY As String) As List(Of Punto)
    '    Dim MiCnx As ConnectionStringSettings = Nothing
    '    MiCnx = ConfigurationManager.ConnectionStrings("PgMSS")
    '    Dim cadena As String = MiCnx.ConnectionString
    '    Dim pgsql As String = "select  "
    '    pgsql += " ST_x(ST_Transform(ST_GeomFromText('POINT('||" + pX + "||' '||" + pY + "||')',32718),4326)) as _xgeo,"
    '    pgsql += " ST_y(ST_Transform(ST_GeomFromText('POINT('||" + pX + "||' '||" + pY + "||')',32718),4326)) as _ygeo "


    '    Dim dtP As New DataTable()
    '    dtP = NpgsqlHelper.ExecuteDataset(cadena, CommandType.Text, pgsql).Tables(0)
    '    Dim oPunto As New List(Of Punto)()
    '    For Each row As DataRow In dtP.Rows
    '        Dim oP As New Punto()

    '        oP.xGeo = row("_xgeo").ToString()
    '        oP.yGeo = row("_ygeo").ToString()
    '        oPunto.Add(oP)
    '    Next
    '    Return oPunto
    'End Function

    <WebMethod()> _
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)> _
    Public Sub convierteXY(ByVal pX As String, ByVal pY As String)
        Dim MiCnx As ConnectionStringSettings = Nothing
        MiCnx = ConfigurationManager.ConnectionStrings("PgMSS")
        Dim cadena As String = MiCnx.ConnectionString
        Dim json As String = ""
        Dim pgsql As String = "select  "
        pgsql += " ST_x(ST_Transform(ST_GeomFromText('POINT('||" + pX + "||' '||" + pY + "||')',32718),4326)) as _xgeo,"
        pgsql += " ST_y(ST_Transform(ST_GeomFromText('POINT('||" + pX + "||' '||" + pY + "||')',32718),4326)) as _ygeo "

        Dim dtP As New DataTable()
        dtP = NpgsqlHelper.ExecuteDataset(cadena, CommandType.Text, pgsql).Tables(0)

        json = JsonConvert.SerializeObject(dtP, Formatting.Indented)
        jsoncallback = HttpContext.Current.Request.QueryString("jsoncallback")
        HttpContext.Current.Response.Write(jsoncallback & "(" & json & ");")

    End Sub


    <WebMethod()> _
    Public Function buscaComponenteXY(ByVal pX As String, ByVal pY As String) As List(Of TB_COMPSEG_BE)
        Dim MiCnx As ConnectionStringSettings = Nothing
        MiCnx = ConfigurationManager.ConnectionStrings("PgMSS")
        Dim cadena As String = MiCnx.ConnectionString
        Dim pgsql As String = "SELECT idcs, direccion,  C.idcst, C.idcse, observ_est, info_cs, idcs_padre,  "
        pgsql += "  comunica_cs, ipred_cs, audusuario_crea, audequipo_crea, audfecha_crea, "
        pgsql += " (SELECT direccion FROM sade.tb_compseg where idcs = c.idcs_padre) as Grupo, to_char(c.fecinst_cs, 'DD-MM-YYYY') AS fecinst_cs, "
        pgsql += "  ST_x(ST_centroid(ST_Transform(geom,32718))) as _xgeo, ST_y(ST_centroid(ST_Transform(geom,32718))) as _ygeo, "
        pgsql += "  CT.nom as _idcst, CE.nom as _idcse "
        pgsql += " FROM SADE.TB_COMPSEG C inner join sade.tb_compseg_tipo  CT on (C.idcst = CT.idcst) "
        pgsql += "                        inner join sade.tb_compseg_estado CE on (C.idcse = CE.idcse) "
        pgsql += "  WHERE ST_DWithin(geom,ST_Transform(ST_GeomFromText('POINT('||" + pX + "||' '||" + pY + "||')',32718),32718),25 ) "


        Dim dtP As New DataTable()
        dtP = NpgsqlHelper.ExecuteDataset(cadena, CommandType.Text, pgsql).Tables(0)
        Dim oLista As New List(Of TB_COMPSEG_BE)()
        For Each row As DataRow In dtP.Rows
            Dim oL As New TB_COMPSEG_BE

            oL.PropIDCS = row("idcs").ToString()
            oL.PropDIRECCION = row("direccion").ToString()
            'oL.PropGEOM = row("").ToString()
            oL.PropIDCST = row("idcst").ToString()
            oL.PropIDCSE = row("idcse").ToString()
            oL.PropINFO_CS = row("info_cs").ToString()
            'oL.PropIDCS_PADRE = row("idcs_padre").ToString()
            oL.PropCOMUNICA_CS = row("comunica_cs").ToString()
            oL.PropIPRED_CS = row("ipred_cs").ToString()
            oL.PropAUDUSUARIO_CREA = row("audusuario_crea").ToString()
            oL.PropAUDEQUIPO_CREA = row("audequipo_crea").ToString()
            oL.PropAUDFECHA_CREA = row("audfecha_crea").ToString()
            oL.PropGeoX = row("_xgeo").ToString()
            oL.PropGeoY = row("_ygeo").ToString()
            oL.PropDIDCST = row("_idcst").ToString()
            oL.PropDIDCSE = row("_idcse").ToString()
            oL.PropFECINST_CS = row("fecinst_cs").ToString()
            oL.PropOBSERV_EST = row("observ_est").ToString()
            oL.PropCOMUNICA_CS = row("Grupo").ToString()
            oL.PropFECINSTCS = row("fecinst_cs").ToString()  'cadena

            oLista.Add(oL)
        Next
        Return oLista
    End Function

    <WebMethod()> _
    Public Function buscaUbicacionXY(ByVal pX As String, ByVal pY As String) As Posicion
        Dim MiCnx As ConnectionStringSettings = Nothing
        MiCnx = ConfigurationManager.ConnectionStrings("PgMSS")
        Dim cadena As String = MiCnx.ConnectionString

        Dim pgsql As String = "SELECT"
        pgsql += "  (select l.nro from carto.tb_cuadrante l where ST_contains(l.geom, ST_Transform(ST_GeomFromText('POINT('||" + pX + "||' '||" + pY + "||')',32718),32718)) limit 1) AS cuadrante,"
        pgsql += "  (select l.nro from carto.tb_sector_vecinal l where ST_contains(l.geom, ST_Transform(ST_GeomFromText('POINT('||" + pX + "||' '||" + pY + "||')',32718),32718)) limit 1) AS sector,"
        pgsql += "  (select l.cod FROM carto.tb_ha_urbana l inner join carto.tb_ha_urbana_tipo lt on l.idhut = lt.idhut where ST_contains(l.geom, ST_Transform(ST_GeomFromText('POINT('||" + pX + "||' '||" + pY + "||')',32718),32718)) limit 1) AS codurb,"
        pgsql += "  (select lt.dsc||' '||l.denom FROM carto.tb_ha_urbana l inner join carto.tb_ha_urbana_tipo lt on l.idhut = lt.idhut where ST_contains(l.geom, ST_Transform(ST_GeomFromText('POINT('||" + pX + "||' '||" + pY + "||')',32718),32718))  limit 1) AS denurb,"
        pgsql += "  (select l.cod FROM carto.tb_lote l where ST_contains(l.geom, ST_Transform(ST_GeomFromText('POINT('||" + pX + "||' '||" + pY + "||')',32718),32718)) limit 1) AS codlote,"
        pgsql += "  (select catastro.sp_fotolote(l.cod) FROM carto.tb_lote l where ST_contains(l.geom, ST_Transform(ST_GeomFromText('POINT('||" + pX + "||' '||" + pY + "||')',32718),32718)) limit 1) AS CODFOTOLOTE, "

        pgsql += "  (select l.cod_lthu FROM carto.tb_lote l where ST_contains(l.geom, ST_Transform(ST_GeomFromText('POINT('||" + pX + "||' '||" + pY + "||')',32718),32718)) limit 1) AS LTU,"
        pgsql += "  (select l.cod_mzhu FROM carto.tb_lote l where ST_contains(l.geom, ST_Transform(ST_GeomFromText('POINT('||" + pX + "||' '||" + pY + "||')',32718),32718)) limit 1) AS MZU,"

        pgsql += "  ST_x(ST_Transform(ST_GeomFromText('POINT('||" + pX + "||' '||" + pY + "||')',32718),4326)) AS _LON, "
        pgsql += "  ST_y(ST_Transform(ST_GeomFromText('POINT('||" + pX + "||' '||" + pY + "||')',32718),4326)) AS _LAT, "

        pgsql += "  (SELECT C.NRO_CDRA FROM CARTO.TB_VIA AS V INNER JOIN CARTO.TB_VIA_HISN  AS VH ON V.IDVIA=VH.IDVIA AND ACT=1"
        pgsql += "                                       INNER JOIN CARTO.TB_VIA_CUADRA AS C ON V.IDVIA=C.IDVIA"
        pgsql += "               WHERE ST_DWITHIN(ST_Transform(ST_GeomFromText('POINT('||" + pX + "||' '||" + pY + "||')',32718),32718), ST_TRANSFORM(C.GEOM,32718) ,500)"
        pgsql += "        ORDER BY ST_Distance(ST_Transform(ST_GeomFromText('POINT('||" + pX + "||' '||" + pY + "||')',32718),32718), ST_TRANSFORM(C.GEOM,32718)) ASC LIMIT 1) AS NROCDA, "

        pgsql += "  (SELECT V.COD FROM CARTO.TB_VIA AS V INNER JOIN CARTO.TB_VIA_HISN  AS VH ON V.IDVIA=VH.IDVIA AND ACT=1"
        pgsql += "                                       INNER JOIN CARTO.TB_VIA_CUADRA AS C ON V.IDVIA=C.IDVIA"
        pgsql += "               WHERE ST_DWITHIN(ST_Transform(ST_GeomFromText('POINT('||" + pX + "||' '||" + pY + "||')',32718),32718), ST_TRANSFORM(C.GEOM,32718) ,500)"
        pgsql += "        ORDER BY ST_Distance(ST_Transform(ST_GeomFromText('POINT('||" + pX + "||' '||" + pY + "||')',32718),32718), ST_TRANSFORM(C.GEOM,32718)) ASC LIMIT 1) AS CODVIA,  "

        pgsql += "  (SELECT V.NOM_ACT FROM CARTO.TB_VIA AS V INNER JOIN CARTO.TB_VIA_HISN  AS VH ON V.IDVIA=VH.IDVIA AND ACT=1"
        pgsql += "                                           INNER JOIN CARTO.TB_VIA_CUADRA AS C ON V.IDVIA=C.IDVIA"
        pgsql += "                   WHERE ST_DWITHIN(ST_Transform(ST_GeomFromText('POINT('||" + pX + "||' '||" + pY + "||')',32718),32718), ST_TRANSFORM(C.GEOM,32718) ,500)"
        pgsql += "        ORDER BY ST_Distance(ST_Transform(ST_GeomFromText('POINT('||" + pX + "||' '||" + pY + "||')',32718),32718), ST_TRANSFORM(C.GEOM,32718)) ASC LIMIT 1) AS NOMVIA, "

        pgsql += "  (SELECT V.NOM_ACT FROM CARTO.TB_VIA AS V INNER JOIN CARTO.TB_VIA_HISN  AS VH ON V.IDVIA=VH.IDVIA AND ACT=1"
        pgsql += "                                           INNER JOIN CARTO.TB_VIA_CUADRA AS C ON V.IDVIA=C.IDVIA"
        pgsql += "                   WHERE ST_DWITHIN(ST_Transform(ST_GeomFromText('POINT('||" + pX + "||' '||" + pY + "||')',32718),32718), ST_TRANSFORM(C.GEOM,32718) ,500)"
        pgsql += "        ORDER BY ST_Distance(ST_Transform(ST_GeomFromText('POINT('||" + pX + "||' '||" + pY + "||')',32718),32718), ST_TRANSFORM(C.GEOM,32718)) ASC LIMIT 1 offset 1) AS NOMVIAINT, "

        pgsql += "  (SELECT V.COD FROM CARTO.TB_VIA AS V INNER JOIN CARTO.TB_VIA_HISN  AS VH ON V.IDVIA=VH.IDVIA AND ACT=1"
        pgsql += "                                           INNER JOIN CARTO.TB_VIA_CUADRA AS C ON V.IDVIA=C.IDVIA"
        pgsql += "                   WHERE ST_DWITHIN(ST_Transform(ST_GeomFromText('POINT('||" + pX + "||' '||" + pY + "||')',32718),32718), ST_TRANSFORM(C.GEOM,32718) ,500)"
        pgsql += "        ORDER BY ST_Distance(ST_Transform(ST_GeomFromText('POINT('||" + pX + "||' '||" + pY + "||')',32718),32718), ST_TRANSFORM(C.GEOM,32718)) ASC LIMIT 1 offset 1) AS CODVIAINT "


        Dim dtP As New DataTable()
        dtP = NpgsqlHelper.ExecuteDataset(cadena, CommandType.Text, pgsql).Tables(0)
        Dim oL As New Posicion
        For Each row As DataRow In dtP.Rows
            oL.xGeo = pX
            oL.yGeo = pY
            oL.nSector = row("sector").ToString()
            oL.nCdte = row("cuadrante").ToString()
            oL.cHU = row("codurb").ToString()
            oL.nHU = row("denurb").ToString()
            oL.cVia = row("CODVIA").ToString()
            oL.nVia = row("NOMVIA").ToString()
            oL.cCda = row("NROCDA").ToString()
            oL.cLTU = row("LTU").ToString()
            oL.cMZU = row("MZU").ToString()
            oL.cCODCAT = row("codlote").ToString()
            oL.nViaInt = row("NOMVIAINT").ToString()
            oL.cViaInt = row("CODVIAINT").ToString()
            oL.nLat = row("_LAT").ToString()
            oL.nLon = row("_LON").ToString()
            oL.cFotoLote = row("CODFOTOLOTE").ToString()
        Next
        Return oL
    End Function

    '<WebMethod()> _
    'Public Function projLonLat2XY(ByVal pLon As String, ByVal pLat As String) As List(Of Lugar_BE)
    '    Dim MiCnx As ConnectionStringSettings = Nothing
    '    MiCnx = ConfigurationManager.ConnectionStrings("PgMSS")
    '    Dim cadena As String = MiCnx.ConnectionString
    '    Dim pgsql As String = "	SELECT "
    '    pgsql += " 	ST_X(ST_TRANSFORM( ST_GEOMFROMTEXT('POINT(" + pLon + " " + pLat + ")',4326),32718)) AS _XGEO, "
    '    pgsql += " 	ST_Y(ST_TRANSFORM( ST_GEOMFROMTEXT('POINT(" + pLon + " " + pLat + ")',4326),32718)) AS _YGEO, "
    '    pgsql += " 	(SELECT L.NRO FROM CARTO.TB_CUADRANTE L "
    '    pgsql += " 	  WHERE ST_CONTAINS(L.GEOM, ST_TRANSFORM( ST_GEOMFROMTEXT('POINT(" + pLon + " " + pLat + ")',4326),32718) )"
    '    pgsql += " 	  LIMIT 1) AS CUADRANTE,"
    '    pgsql += " 	(SELECT L.NRO FROM CARTO.TB_SECTOR_VECINAL L"
    '    pgsql += " 	 WHERE ST_CONTAINS(L.GEOM, ST_TRANSFORM( ST_GEOMFROMTEXT('POINT(" + pLon + " " + pLat + ")',4326),32718) )  "
    '    pgsql += " 	   LIMIT 1) AS SECTOR,"
    '    pgsql += " 	( SELECT V.NOM_ACT || ' CDRA.' || C.NRO_CDRA AS NOM_ACT"
    '    pgsql += " 	    FROM CARTO.TB_VIA AS V INNER JOIN CARTO.TB_VIA_HISN  AS VH ON V.IDVIA=VH.IDVIA AND ACT=1"
    '    pgsql += " 				   INNER JOIN CARTO.TB_VIA_CUADRA AS C ON V.IDVIA=C.IDVIA"
    '    pgsql += " 	   WHERE ST_DWITHIN(ST_TRANSFORM( ST_GEOMFROMTEXT('POINT(" + pLon + " " + pLat + ")',4326),32718), ST_TRANSFORM(C.GEOM,32718) ,50)"
    '    pgsql += " 	ORDER BY V.IDVIA, C.NRO_CDRA "
    '    pgsql += " 	 LIMIT 1) AS VIA, "
    '    pgsql += " 	(SELECT LT.DSC||' '||L.DENOM FROM CARTO.TB_HA_URBANA L INNER JOIN CARTO.TB_HA_URBANA_TIPO LT ON L.IDHUT = LT.IDHUT "
    '    pgsql += " 	WHERE ST_CONTAINS(L.GEOM, ST_TRANSFORM( ST_GEOMFROMTEXT('POINT(" + pLon + " " + pLat + ")',4326),32718)) "
    '    pgsql += " 	LIMIT 1) AS HU "


    '    Dim dtP As New DataTable()
    '    dtP = NpgsqlHelper.ExecuteDataset(cadena, CommandType.Text, pgsql).Tables(0)
    '    Dim oLugar As New List(Of Lugar_BE)()
    '    For Each row As DataRow In dtP.Rows
    '        Dim oL As New Lugar_BE()
    '        oL.nLat = pLat
    '        oL.nLon = pLon
    '        oL.xGeo = row("_xgeo").ToString()
    '        oL.yGeo = row("_ygeo").ToString()
    '        oL.nCuadrante = row("CUADRANTE").ToString()
    '        oL.nSector = row("SECTOR").ToString()
    '        oL.nVia = row("VIA").ToString()
    '        oL.nHabilita = row("HU").ToString()


    '        'oP.Geom = row["geom"].ToString();
    '        'oP.xyCord = row["coord"].ToString();
    '        oLugar.Add(oL)
    '    Next
    '    Return oLugar
    'End Function


    ' FORMATO JSON 

    <WebMethod()> _
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)> _
    Public Sub buscaLoteJS(ByVal pCODLOTE As String)
        Dim MiCnx As ConnectionStringSettings = Nothing
        MiCnx = ConfigurationManager.ConnectionStrings("PgMSS")
        Dim cadena As String = MiCnx.ConnectionString
        Dim sql As String = " SELECT  l.cod, l.cod_lthu, l.cod_mzhu, hu.cod AS codhu, hu.denom, substring(l.cod,1,2)||'\40'||substring(l.cod,1,2)||substring(l.cod,4,2)||substring(l.cod,7,2) as codfoto, "
        sql += " ST_x(ST_centroid(ST_Transform(l.geom,32718))) as _xgeo, ST_y(ST_centroid(ST_Transform(l.geom,32718))) as _ygeo, l.geom as geom , ST_AsGeoJSON(ST_Transform(l.geom,32718),15,0) as geometria, (ST_x(ST_centroid(ST_Transform(l.geom,32718))) || ' ' || ST_y(ST_centroid(ST_Transform(l.geom,32718)))) as coord "
        sql += " FROM carto.tb_lote AS l"
        sql += " INNER JOIN carto.tb_ha_urbana AS hu on l.idhu=hu.idhu"
        sql += (Convert.ToString(" WHERE l.cod ILIKE '%") & pCODLOTE) + "%' ORDER BY l.cod"

        Dim dtP As New DataTable()
        dtP = NpgsqlHelper.ExecuteDataset(cadena, CommandType.Text, sql).Tables(0)

        Dim sb As New StringBuilder()
        Dim sw As New StringWriter(sb)
        Dim strOut As String = String.Empty
        Using jw As New JsonTextWriter(sw)
            For Each row As DataRow In dtP.Rows
                jw.WriteStartObject()
                jw.WritePropertyName("codLote")
                jw.WriteValue(row("cod").ToString())
                jw.WritePropertyName("codLHU")
                jw.WriteValue(row("cod_lthu").ToString())
                jw.WritePropertyName("codMZU")
                jw.WriteValue(row("cod_mzhu").ToString())
                jw.WritePropertyName("codHU")
                jw.WriteValue(row("codhu").ToString())
                jw.WritePropertyName("denHU")
                jw.WriteValue(row("denom").ToString())
                jw.WritePropertyName("xGeo")
                jw.WriteValue(row("_xgeo").ToString())
                jw.WritePropertyName("yGeo")
                jw.WriteValue(row("_ygeo").ToString())
                jw.WritePropertyName("Geom")
                jw.WriteValue(row("geom").ToString())
                jw.WritePropertyName("xyCord")
                jw.WriteValue(row("coord").ToString())
                jw.WritePropertyName("Poly")
                jw.WriteValue(row("geometria").ToString())
                jw.WritePropertyName("codFoto")
                jw.WriteValue(row("codfoto").ToString())
                jw.WriteEndObject()
            Next
            strOut = sw.ToString()
        End Using
        jsoncallback = HttpContext.Current.Request.QueryString("jsoncallback")
        HttpContext.Current.Response.Write((Convert.ToString(jsoncallback & Convert.ToString("(")) & strOut) + ");")
    End Sub

    <WebMethod()> _
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)> _
    Public Sub buscaLoteXYJS(ByVal pX As String, ByVal pY As String)
        Dim MiCnx As ConnectionStringSettings = Nothing
        MiCnx = ConfigurationManager.ConnectionStrings("PgMSS")
        Dim cadena As String = MiCnx.ConnectionString
        Dim pgsql As String = " SELECT l.cod, l.cod_lthu, l.cod_mzhu, hu.cod AS codhu, hu.denom, substring(l.cod,1,2)||'\40'||substring(l.cod,1,2)||substring(l.cod,4,2)||substring(l.cod,7,2) as codfoto, "
        pgsql += " ST_area(l.geom) AS geom, ST_x(ST_centroid(l.geom)) as _xgeo, ST_y(ST_centroid(l.geom)) as _ygeo, "
        '--pgsql += " ST_box2d(l.geom) as extends, "
        pgsql += " ST_AsGeoJSON(ST_Transform(l.geom,32718),15,0) as geometria, "
        pgsql += "  (ST_x(ST_centroid(ST_Transform(l.geom,32718))) || ' ' || ST_y(ST_centroid(ST_Transform(l.geom,32718)))) as coord "
        pgsql += " FROM carto.tb_lote AS l"
        pgsql += " INNER JOIN carto.tb_ha_urbana AS hu on l.idhu=hu.idhu"
        pgsql += " WHERE ST_contains(l.geom,ST_Transform(ST_GeomFromText('POINT('||" + pX + "||' '||" + pY + "||')',32718),32718)  limit 1 "


        Dim dtP As New DataTable()
        dtP = NpgsqlHelper.ExecuteDataset(cadena, CommandType.Text, pgsql).Tables(0)

        Dim sb As New StringBuilder()
        Dim sw As New StringWriter(sb)
        Dim strOut As String = String.Empty
        Using jw As New JsonTextWriter(sw)
            For Each row As DataRow In dtP.Rows
                jw.WriteStartObject()
                jw.WritePropertyName("codLote")
                jw.WriteValue(row("cod").ToString())
                jw.WritePropertyName("codLHU")
                jw.WriteValue(row("cod_lthu").ToString())
                jw.WritePropertyName("codMZU")
                jw.WriteValue(row("cod_mzhu").ToString())
                jw.WritePropertyName("codHU")
                jw.WriteValue(row("codhu").ToString())
                jw.WritePropertyName("denHU")
                jw.WriteValue(row("denom").ToString())
                jw.WritePropertyName("xGeo")
                jw.WriteValue(row("_xgeo").ToString())
                jw.WritePropertyName("yGeo")
                jw.WriteValue(row("_ygeo").ToString())
                jw.WritePropertyName("Geom")
                jw.WriteValue(row("geom").ToString())
                jw.WritePropertyName("xyCord")
                jw.WriteValue(row("coord").ToString())
                jw.WritePropertyName("Poly")
                jw.WriteValue(row("geometria").ToString())
                jw.WritePropertyName("codFoto")
                jw.WriteValue(row("codfoto").ToString())
                jw.WriteEndObject()
            Next
            strOut = sw.ToString()
        End Using
        jsoncallback = HttpContext.Current.Request.QueryString("jsoncallback")
        HttpContext.Current.Response.Write((Convert.ToString(jsoncallback & Convert.ToString("(")) & strOut) + ");")
    End Sub

    <WebMethod()> _
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)> _
    Public Sub gpsPosicionJS(ByVal pESTADO As String)
        Dim MiCnx As ConnectionStringSettings = Nothing
        MiCnx = ConfigurationManager.ConnectionStrings("PgDOLPHIN")
        Dim cadena As String = MiCnx.ConnectionString

        Dim pgsql As String = " SELECT intposid, intissi, decposlat, decposlon, datposfreg, intpospres, "
        pgsql += "  decposvel, vchcarcod, vchestcod, intsdsbuffid, "
        pgsql += "  st_x(st_astext(ST_Transform( ST_GeomFromText('POINT('|| decposlat ||' '|| decposlon ||')',4326),32718))) as _xgeo, "
        pgsql += "  st_y(st_astext(ST_Transform( ST_GeomFromText('POINT('|| decposlat ||' '|| decposlon ||')',4326),32718))) as _ygeo "
        pgsql += "  FROM gpsposicion "

        Dim dtP As New DataTable()
        dtP = NpgsqlHelper.ExecuteDataset(cadena, CommandType.Text, pgsql).Tables(0)

        Dim sb As New StringBuilder()
        Dim sw As New StringWriter(sb)
        Dim strOut As String = String.Empty
        Using jw As New JsonTextWriter(sw)
            For Each row As DataRow In dtP.Rows
                jw.WriteStartObject()
                jw.WritePropertyName("Id")
                jw.WriteValue(row("intposid").ToString())
                jw.WritePropertyName("Issi")
                jw.WriteValue(row("intissi").ToString())
                jw.WritePropertyName("Lat")
                jw.WriteValue(row("decposlat").ToString())
                jw.WritePropertyName("Lon")
                jw.WriteValue(row("decposlon").ToString())
                jw.WritePropertyName("xGeo")
                jw.WriteValue(row("_xgeo").ToString())
                jw.WritePropertyName("yGeo")
                jw.WriteValue(row("_ygeo").ToString())
                jw.WriteEndObject()
            Next
            strOut = sw.ToString()
        End Using
        jsoncallback = HttpContext.Current.Request.QueryString("jsoncallback")
        HttpContext.Current.Response.Write((Convert.ToString(jsoncallback & Convert.ToString("(")) & strOut) + ");")
    End Sub

    <WebMethod(EnableSession:=True)>
    Public Function listarCallejero() As List(Of Calle)

        Dim MiCnx As ConnectionStringSettings = Nothing
        MiCnx = ConfigurationManager.ConnectionStrings("PgMSS")
        Dim cadena As String = MiCnx.ConnectionString

        Dim pgsql As String
        pgsql = "SELECT v.idvia,v.cod as codvia, v.nom_act as nomvia, vh.apr_acon ,vh.cla_vial ,c.nro_cdra as nrocdra, "
        pgsql += "  ST_x(ST_centroid(ST_Transform(c.geom,32718))) as _xgeo, "
        pgsql += "  ST_y(ST_centroid(ST_Transform(c.geom,32718))) As _ygeo,"
        pgsql += "  ST_AsGeoJSON(ST_Transform(c.geom,32718),15,0) As geom "
        pgsql += " FROM carto.tb_via As v"
        pgsql += " INNER JOIN carto.tb_via_hisn  As vh On v.idvia=vh.idvia And act=1"
        pgsql += " INNER JOIN carto.tb_via_cuadra As c On v.idvia=c.idvia"
        pgsql += " ORDER BY v.nom_act, c.nro_cdra"


        Dim dtP As New DataTable()
        dtP = NpgsqlHelper.ExecuteDataset(cadena, CommandType.Text, pgsql).Tables(0)

        Dim oCalle As New List(Of Calle)
        For Each row As DataRow In dtP.Rows
            Dim oC As New Calle()
            oC.idvia = row("idvia").ToString()
            oC.codvia = row("codvia").ToString()
            oC.nomvia = row("nomvia").ToString()
            oC.nrocdra = row("nrocdra").ToString()
            oC.xGeo = row("_xgeo").ToString()
            oC.yGeo = row("_ygeo").ToString()
            oC.Geom = row("geom").ToString()
            oCalle.Add(oC)
        Next
        Return oCalle
    End Function


    <WebMethod()>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub listarCalleJS()
        Dim MiCnx As ConnectionStringSettings = Nothing
        MiCnx = ConfigurationManager.ConnectionStrings("PgMSS")
        Dim cadena As String = MiCnx.ConnectionString

        Dim pgsql As String
        pgsql = "Select v.idvia, v.cod, vh.nom As nom_act, vh.apr_acon, vh.cla_vial, c.nro_cdra,"
        pgsql += "  ST_x(ST_centroid(ST_Transform(c.geom,32718))) As _xgeo, "
        pgsql += "  ST_y(ST_centroid(ST_Transform(c.geom,32718))) As _ygeo,"
        pgsql += "  ST_AsGeoJSON(ST_Transform(c.geom,32718),15,0) As geom "
        pgsql += " FROM carto.tb_via As v"
        pgsql += " INNER JOIN carto.tb_via_hisn  As vh On v.idvia=vh.idvia And act=1"
        pgsql += " INNER JOIN carto.tb_via_cuadra As c On v.idvia=c.idvia"
        pgsql += " ORDER BY v.idvia, c.nro_cdra"

        Dim dtP As New DataTable()
        dtP = NpgsqlHelper.ExecuteDataset(cadena, CommandType.Text, pgsql).Tables(0)

        Dim sb As New StringBuilder()
        Dim sw As New StringWriter(sb)
        Dim strOut As String = String.Empty
        Using jw As New JsonTextWriter(sw)
            For Each row As DataRow In dtP.Rows
                jw.WriteStartObject()
                jw.WritePropertyName("Id")
                jw.WriteValue(row("idvia").ToString())
                jw.WritePropertyName("codvia")
                jw.WriteValue(row("cod").ToString())
                jw.WritePropertyName("nomvia")
                jw.WriteValue(row("nom_act").ToString())
                jw.WritePropertyName("nrocdra")
                jw.WriteValue(row("nro_cdra").ToString())
                jw.WritePropertyName("_xgeo")
                jw.WriteValue(row("_xgeo").ToString())
                jw.WritePropertyName("_ygeo")
                jw.WriteValue(row("_ygeo").ToString())
                jw.WritePropertyName("geom")
                jw.WriteValue(row("geom").ToString())

                jw.WriteEndObject()
            Next
            strOut = sw.ToString()
        End Using

        jsoncallback = HttpContext.Current.Request.QueryString("jsoncallback")
        HttpContext.Current.Response.Write((Convert.ToString(jsoncallback & Convert.ToString("(")) & strOut) + ");")
    End Sub

    <WebMethod()> _
 <ScriptMethod(ResponseFormat:=ResponseFormat.Json)> _
    Public Sub listarMarcadorGEO(ByVal pESTADO As String)

        Dim strMensaje As String
        Dim strEstado As String
        Dim dt As New DataTable
        Dim oCCOINCIDENCIA_BE As New CCOINCIDENCIA_BE
        Dim oCCOINCIDENCIA_BL As New CCOINCIDENCIA_BL
        Try
            'oCCOINCIDENCIA_BE.PropVCHMOTIVOALERTA = pMOTIVO
            oCCOINCIDENCIA_BE.PropINCESTADO = pESTADO
            'oCCOINCIDENCIA_BE.PropTPECODIGO = pPERIODO

            dt = oCCOINCIDENCIA_BL.ListarMarcadores(oCCOINCIDENCIA_BE)
            strMensaje = "Listado completo!!!"
            strEstado = "0"
        Catch ex As Exception
            strMensaje = ex.Message
            strEstado = "8"
        End Try

        Dim sb As New StringBuilder
        Dim sw As New IO.StringWriter(sb)
        Dim strOut As String = String.Empty
        Using jw As New JsonTextWriter(sw)
            jw.WriteStartObject()
            jw.WritePropertyName("Marcador")
            jw.WriteStartArray()
            For i As Integer = 0 To dt.Rows.Count - 1
                jw.WriteStartObject()


                jw.WritePropertyName("INTINCCODIGO")
                jw.WriteValue(dt.Rows(i).Item("INTINCCODIGO"))
                jw.WritePropertyName("VCHINCNUMEROORIGEN")
                jw.WriteValue(dt.Rows(i).Item("VCHINCNUMEROORIGEN"))
                jw.WritePropertyName("VCHINCRELATO")
                jw.WriteValue(dt.Rows(i).Item("VCHINCRELATO"))
                jw.WritePropertyName("VCHINCNOMBRECOMP")
                jw.WriteValue(dt.Rows(i).Item("VCHINCNOMBRECOMP"))
                jw.WritePropertyName("SMLINCESTADO")
                jw.WriteValue(dt.Rows(i).Item("SMLINCESTADO"))
                jw.WritePropertyName("VCHTABDESCRIPCION")
                jw.WriteValue(dt.Rows(i).Item("VCHTABDESCRIPCION"))
                jw.WritePropertyName("VCHINCIDLATITUDE")
                jw.WriteValue(dt.Rows(i).Item("VCHINCIDLATITUDE"))
                jw.WritePropertyName("VCHINCIDLONGITUDE")
                jw.WriteValue(dt.Rows(i).Item("VCHINCIDLONGITUDE"))
                jw.WritePropertyName("SMLORICODIGO")
                jw.WriteValue(dt.Rows(i).Item("SMLORICODIGO"))
                jw.WritePropertyName("VCHORIDESCRIPCION")
                jw.WriteValue(dt.Rows(i).Item("VCHORIDESCRIPCION"))
                jw.WritePropertyName("SMLTINCODIGO")
                jw.WriteValue(dt.Rows(i).Item("SMLTINCODIGO"))
                jw.WritePropertyName("VCHTINDESCRIPCION")
                jw.WriteValue(dt.Rows(i).Item("VCHTINDESCRIPCION"))
                jw.WritePropertyName("SMLSTICODIGO")
                jw.WriteValue(dt.Rows(i).Item("SMLSTICODIGO"))
                jw.WritePropertyName("VCHSTIDESCRIPCION")
                jw.WriteValue(dt.Rows(i).Item("VCHSTIDESCRIPCION"))
                jw.WritePropertyName("SMLPRICODIGO")
                jw.WriteValue(dt.Rows(i).Item("SMLPRICODIGO"))
                jw.WritePropertyName("VCHPRIDESCRIPCION")
                jw.WriteValue(dt.Rows(i).Item("VCHPRIDESCRIPCION"))
                jw.WritePropertyName("DTMINCFECHA")
                jw.WriteValue(dt.Rows(i).Item("DTMINCFECHA"))
                jw.WritePropertyName("VCHMOTIVOALERTA")
                jw.WriteValue(dt.Rows(i).Item("VCHMOTIVOALERTA"))
                jw.WritePropertyName("VCHDESMOTIVOALERTA")
                jw.WriteValue(dt.Rows(i).Item("VCHDESMOTIVOALERTA"))
                jw.WritePropertyName("VCHCODQUEJA")
                jw.WriteValue(dt.Rows(i).Item("VCHCODQUEJA"))

                jw.WritePropertyName("VCHINCLOCVIANOMBRE1")
                jw.WriteValue(dt.Rows(i).Item("VCHINCLOCVIANOMBRE1"))
                jw.WritePropertyName("VCHINCLOCHABNOMBRE")
                jw.WriteValue(dt.Rows(i).Item("VCHINCLOCHABNOMBRE"))
                jw.WritePropertyName("VCHINCLOCCUADRANTE")
                jw.WriteValue(dt.Rows(i).Item("VCHINCLOCCUADRANTE"))
                jw.WritePropertyName("VCHINCLOCSECTOR")
                jw.WriteValue(dt.Rows(i).Item("VCHINCLOCSECTOR"))
                jw.WritePropertyName("VCHINCLOCXGEO")
                jw.WriteValue(dt.Rows(i).Item("VCHINCLOCXGEO"))
                jw.WritePropertyName("VCHINCLOCYGEO")
                jw.WriteValue(dt.Rows(i).Item("VCHINCLOCYGEO"))

                jw.WriteEndObject()
            Next
            jw.WriteEndArray()
            jw.WriteEndObject()
            strOut = sw.ToString
        End Using
        jsoncallback = HttpContext.Current.Request.QueryString("jsoncallback")
        HttpContext.Current.Response.Write(jsoncallback & "(" & strOut & ");")
    End Sub

    <WebMethod()> _
 <ScriptMethod(ResponseFormat:=ResponseFormat.Json)> _
    Public Sub listarLoteDetalle(ByVal pCODLOTE As String)

        Dim strMensaje As String
        Dim strEstado As String
        Dim dt As New DataTable
        Dim oSYSCATASTRO_BL As New SYSCATASTRO_BL
        Try
            dt = oSYSCATASTRO_BL.ListarLoteDetalle(pCODLOTE)
            strMensaje = "Listado completo!!!"
            strEstado = "0"
        Catch ex As Exception
            strMensaje = ex.Message
            strEstado = "8"
        End Try

        Dim sb As New StringBuilder
        Dim sw As New IO.StringWriter(sb)
        Dim strOut As String = String.Empty
        Using jw As New JsonTextWriter(sw)
            jw.WriteStartObject()
            jw.WritePropertyName("LoteDetalle")
            jw.WriteStartArray()
            For i As Integer = 0 To dt.Rows.Count - 1
                jw.WriteStartObject()

                jw.WritePropertyName("INTPRECODIGO")
                jw.WriteValue(dt.Rows(i).Item("INTPRECODIGO"))
                jw.WritePropertyName("VCHPREDIRECCION")
                jw.WriteValue(dt.Rows(i).Item("VCHPREDIRECCION"))
                jw.WritePropertyName("INTADMCODIGO")
                jw.WriteValue(dt.Rows(i).Item("INTADMCODIGO"))
                jw.WritePropertyName("VCHADMCOMPLETO")
                jw.WriteValue(dt.Rows(i).Item("VCHADMCOMPLETO"))
                jw.WritePropertyName("VCHUSOCODIGO")
                jw.WriteValue(dt.Rows(i).Item("VCHUSOCODIGO"))
                jw.WritePropertyName("VCHCOPDESCRI")
                jw.WriteValue(dt.Rows(i).Item("VCHCOPDESCRI"))
                jw.WritePropertyName("DECPREPORCOPROP")
                jw.WriteValue(dt.Rows(i).Item("DECPREPORCOPROP"))
                jw.WritePropertyName("VCHCODCAT")
                jw.WriteValue(dt.Rows(i).Item("VCHCODCAT"))
                jw.WritePropertyName("VCHCODLOTEPRT")
                jw.WriteValue(dt.Rows(i).Item("VCHCODLOTEPRT"))
                jw.WritePropertyName("VCHESTRCODIGO")
                jw.WriteValue(dt.Rows(i).Item("VCHESTRCODIGO"))
                jw.WritePropertyName("VCHZONACOD")
                jw.WriteValue(dt.Rows(i).Item("VCHZONACOD"))
                jw.WritePropertyName("VCHUSODESCRI")
                jw.WriteValue(dt.Rows(i).Item("VCHUSODESCRI"))

                jw.WriteEndObject()
            Next
            jw.WriteEndArray()
            jw.WriteEndObject()
            strOut = sw.ToString
        End Using
        jsoncallback = HttpContext.Current.Request.QueryString("jsoncallback")
        HttpContext.Current.Response.Write(jsoncallback & "(" & strOut & ");")
    End Sub

    <WebMethod()> _
 <ScriptMethod(ResponseFormat:=ResponseFormat.Json)> _
    Public Sub listarLoteLicencia(ByVal pCODLOTE As String)

        Dim strMensaje As String
        Dim strEstado As String
        Dim dt As New DataTable
        Dim oSYSCATASTRO_BL As New SYSCATASTRO_BL
        Try
            dt = oSYSCATASTRO_BL.ListarLoteLicencia(pCODLOTE)
            strMensaje = "Listado completo!!!"
            strEstado = "0"
        Catch ex As Exception
            strMensaje = ex.Message
            strEstado = "8"
        End Try

        Dim sb As New StringBuilder
        Dim sw As New IO.StringWriter(sb)
        Dim strOut As String = String.Empty
        Using jw As New JsonTextWriter(sw)
            jw.WriteStartObject()
            jw.WritePropertyName("LoteDetalle")
            jw.WriteStartArray()
            For i As Integer = 0 To dt.Rows.Count - 1
                jw.WriteStartObject()
                jw.WritePropertyName("CHRSOLANIO")
                jw.WriteValue(dt.Rows(i).Item("CHRSOLANIO"))
                jw.WritePropertyName("VCHSOLNUMERO")
                jw.WriteValue(dt.Rows(i).Item("VCHSOLNUMERO"))
                jw.WritePropertyName("INTPRECODIGO")
                jw.WriteValue(dt.Rows(i).Item("INTPRECODIGO"))
                jw.WritePropertyName("VCHPREDIRECCION")
                jw.WriteValue(dt.Rows(i).Item("VCHPREDIRECCION"))
                jw.WritePropertyName("VCHSOLNOMBRECOMER")
                jw.WriteValue(dt.Rows(i).Item("VCHSOLNOMBRECOMER"))
                jw.WritePropertyName("VCHLICDEFCIVIL")
                jw.WriteValue(dt.Rows(i).Item("VCHLICDEFCIVIL"))
                jw.WritePropertyName("DATLICFECCERDF")
                jw.WriteValue(dt.Rows(i).Item("DATLICFECCERDF"))
                jw.WritePropertyName("VCHSOLNOMBRESOL")
                jw.WriteValue(dt.Rows(i).Item("VCHSOLNOMBRESOL"))
                jw.WritePropertyName("VCHTAUTDESCRIPCION")
                jw.WriteValue(dt.Rows(i).Item("VCHTAUTDESCRIPCION"))
                jw.WritePropertyName("VCHUSODESCRI")
                jw.WriteValue(dt.Rows(i).Item("VCHUSODESCRI"))
                jw.WritePropertyName("VCHZONACOD")
                jw.WriteValue(dt.Rows(i).Item("VCHZONACOD"))
                jw.WritePropertyName("VCHESTRCODIGO")
                jw.WriteValue(dt.Rows(i).Item("VCHESTRCODIGO"))
                jw.WritePropertyName("GIRO")
                jw.WriteValue(dt.Rows(i).Item("GIRO"))
                jw.WriteEndObject()
            Next
            jw.WriteEndArray()
            jw.WriteEndObject()
            strOut = sw.ToString
        End Using
        jsoncallback = HttpContext.Current.Request.QueryString("jsoncallback")
        HttpContext.Current.Response.Write(jsoncallback & "(" & strOut & ");")
    End Sub

    <WebMethod()> _
 <ScriptMethod(ResponseFormat:=ResponseFormat.Json)> _
    Public Sub LoteDetalleGIS(ByVal pCODLOTE As String)

        Dim strMensaje As String
        Dim strEstado As String
        Dim json As String = ""
        Dim ds As New DataSet

        Dim oSYSCATASTRO_BL As New SYSCATASTRO_BL
        Try
            ds = oSYSCATASTRO_BL.ListarLoteGIS(pCODLOTE)
            json = JsonConvert.SerializeObject(ds, Formatting.Indented)
            strMensaje = "Listado completo!!!"
            strEstado = "0"
        Catch ex As Exception
            strMensaje = ex.Message
            strEstado = "8"
        End Try
        jsoncallback = HttpContext.Current.Request.QueryString("jsoncallback")
        HttpContext.Current.Response.Write(jsoncallback & "(" & json & ");")
    End Sub

    <WebMethod()> _
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)> _
    Public Sub ActualizaRegistro(ByVal p_usuario As String, _
                                ByVal p_intregcodigo As String, _
                                ByVal p_smlfisestado As String, _
                                ByVal p_smlfisdeuda As String, _
                                ByVal p_decfisdeuda As String, _
                                ByVal p_smlfismulta As String, _
                                ByVal p_decfismulta As String, _
                                ByVal p_vchfisoserv As String)

        Dim obj As FISPREDIO_BE
        obj = New FISPREDIO_BE
        obj.p_INTREGCODIGO = p_intregcodigo
        obj.p_SMLFISESTADO = p_smlfisestado
        obj.p_SMLFISDEUDA = p_smlfisdeuda
        obj.p_DECFISDEUDA = p_decfisdeuda
        obj.p_SMLFISMULTA = p_smlfismulta
        obj.p_DECFISMULTA = p_decfismulta
        obj.p_VCHFISOSERV = p_vchfisoserv
        obj.p_VCHAUDUSUMODIF = p_usuario
        obj.p_VCHAUDPROGRAMA = HttpContext.Current.Request.UserHostAddress.ToString().Trim()
        obj.p_VCHAUDEQUIPO = HttpContext.Current.Request.UserHostAddress.ToString().Trim()

        Dim objPro As SYSCATASTRO_BL
        objPro = New SYSCATASTRO_BL
        objPro.ActualizaLoteFIS(obj)


        Dim sb As New StringBuilder
        Dim sw As New IO.StringWriter(sb)
        Dim strOut As String = String.Empty
        Using jw As New JsonTextWriter(sw)
            With jw
                .WriteStartObject()
                .WritePropertyName("CODIGO")
                .WriteValue(obj.p_INTREGCODIGO)
                .WritePropertyName("mensaje")
                .WriteValue("REGISTRO ACTUALIZADO")
                .WritePropertyName("estado")
                .WriteValue("0")
                .WriteEndObject()
            End With
            strOut = sw.ToString
        End Using
        jsoncallback = HttpContext.Current.Request.QueryString("jsoncallback")
        HttpContext.Current.Response.Write(jsoncallback & "(" & strOut & ");")
    End Sub


    '   <WebMethod()> _
    '<ScriptMethod(ResponseFormat:=ResponseFormat.Json)> _
    '   Public Sub ListaRegistro(ByVal p_usuario As String, ByVal p_vchubiclat As String, ByVal p_vchubiclon As String)
    '       '--ListaRegistro?p_usuario=xxxx&p_vchubiclat=xxxx&p_vchubiclon=xxxx
    '       Dim dt As New DataTable()
    '       Dim pToken As String
    '       pToken = p_usuario + Now.ToShortTimeString
    '       dt = procesaFISLOTE(pToken, p_vchubiclat, p_vchubiclon)

    '       Dim sb As New StringBuilder
    '       Dim sw As New IO.StringWriter(sb)
    '       Dim strOut As String = String.Empty
    '       Using jw As New JsonTextWriter(sw)
    '           jw.WriteStartObject()
    '           jw.WritePropertyName("bandeja")
    '           jw.WriteStartArray()
    '           For i As Integer = 0 To dt.Rows.Count - 1
    '               jw.WriteStartObject()

    '               For j As Integer = 0 To dt.Columns.Count - 1
    '                   Dim col As String = dt.Columns(j).ColumnName
    '                   jw.WritePropertyName(dt.Columns(j).ColumnName)
    '                   jw.WriteValue(dt.Rows(i).Item(col))

    '               Next
    '               jw.WriteEndObject()
    '           Next
    '           jw.WriteEndArray()
    '           jw.WriteEndObject()
    '           strOut = sw.ToString
    '       End Using
    '       jsoncallback = HttpContext.Current.Request.QueryString("jsoncallback")
    '       HttpContext.Current.Response.Write(jsoncallback & "(" & strOut & ");")
    '   End Sub

    Public Shared Function procesaFISLOTE(ByVal pTOKEN As String, ByVal pX As String, ByVal pY As String) As DataTable

        Dim MiCnx As ConnectionStringSettings = Nothing
        MiCnx = ConfigurationManager.ConnectionStrings("PgMSS")
        Dim cadena As String = MiCnx.ConnectionString

        Dim strMensaje As String = "Listado completo!!!"
        Dim strEstado As String = "0"

        Dim pCodLote, pPosLat, pPosLon As String
        Dim pDistance As Decimal
        Dim pgsql As String


        pgsql = " Select L.cod As codCat,"
        pgsql += "	ST_x(ST_centroid(ST_Transform(l.geom,4326))) As geoLat, "
        pgsql += "	ST_y(ST_centroid(ST_Transform(l.geom,4326))) As geoLon, "
        pgsql += "	ST_LENGTH((ST_ShortestLine(L.geom, ST_Transform( ST_GeomFromText('POINT(" + pX + " " + pY + ")',4326),32718)))) as Distancia "
        pgsql += "  FROM CARTO.TB_LOTE AS L "
        pgsql += " WHERE ST_DWITHIN(L.GEOM, ST_Transform( ST_GeomFromText('POINT(" + pX + " " + pY + ")',4326),32718) ,100)"
        Dim dtP As New DataTable()
        Dim dt As New DataTable()
        Try
            dtP = NpgsqlHelper.ExecuteDataset(cadena, CommandType.Text, pgsql).Tables(0)
            Dim oSYSCATASTRO_BL As New SYSCATASTRO_BL
            For Each r As DataRow In dtP.Rows
                pCodLote = r.Item("codcat").ToString.Trim
                pPosLat = r.Item("geoLat")
                pPosLon = r.Item("geoLon")
                pDistance = r.Item("Distancia")
                oSYSCATASTRO_BL.GuardaLoteFIS(pTOKEN, pCodLote, pPosLat, pPosLon, pDistance)
            Next
            dt = oSYSCATASTRO_BL.ListarLoteFIS(pTOKEN)
        Catch ex As Exception
            strMensaje = ex.Message
            strEstado = "8"
        End Try
        Return dt
    End Function


    '   <WebMethod()> _
    '<ScriptMethod(ResponseFormat:=ResponseFormat.Json)> _
    '   Public Sub ValidaUsuario(ByVal p_usuario As String, ByVal p_pass As String, ByVal p_app As String)
    '       Dim strMensaje As String
    '       Dim strEstado As String
    '       Try
    '           Dim oSEGUSUARIO As New ws_seguridad.SEGUSUARIOEntidad
    '           Dim msg = ""
    '           Dim msg1 = ""
    '           Dim exito As Boolean = False
    '           Dim address As EndpointAddress = New EndpointAddress("http://192.0.0.51/ws_siscas/service.asmx")
    '           Dim binding As New BasicHttpBinding()
    '           ServicePointManager.Expect100Continue = False
    '           Dim Seguridad As ws_seguridad.ServiceSoapClient = New ws_seguridad.ServiceSoapClient(binding, address)

    '           exito = Seguridad.LogeoUsuario(p_app, p_usuario, p_pass, oSEGUSUARIO, msg)
    '           If exito Then
    '               strMensaje = "Ingreso correcto!!!"
    '               strEstado = "0"
    '           Else
    '               strMensaje = msg
    '               strEstado = "1"
    '           End If
    '       Catch ex As Exception
    '           strMensaje = ex.Message.ToString
    '           strEstado = "100"
    '       End Try

    '       Dim sb As New StringBuilder
    '       Dim sw As New IO.StringWriter(sb)
    '       Dim strOut As String = String.Empty
    '       Using jw As New JsonTextWriter(sw)
    '           With jw
    '               .WriteStartObject()
    '               .WritePropertyName("mensaje")
    '               .WriteValue(strMensaje)
    '               .WritePropertyName("estado")
    '               .WriteValue(strEstado)
    '               .WriteEndObject()
    '           End With
    '           strOut = sw.ToString
    '       End Using
    '       jsoncallback = HttpContext.Current.Request.QueryString("jsoncallback")
    '       HttpContext.Current.Response.Write(jsoncallback & "(" & strOut & ");")
    '   End Sub

    <WebMethod()>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub listarComponenteGEO(ByVal pESTADO As String)

        Dim MiCnx As ConnectionStringSettings = Nothing
        MiCnx = ConfigurationManager.ConnectionStrings("PgMSS")
        Dim cadena As String = MiCnx.ConnectionString
        Dim pgsql As String = ""

        pgsql += "  Select C.idcs, C.direccion, C.geom, C.idcst, ct.nom, ct.icono, C.idcse, ce.nom, "
        pgsql += "  ST_x(ST_centroid(ST_Transform(geom,32718))) as _xgeo, ST_y(ST_centroid(ST_Transform(geom,32718))) as _ygeo, "
        pgsql += "  C.observ_est, C.info_cs, C.idcs_padre, C.comunica_cs, ipred_cs "
        pgsql += "      From sade.tb_compseg C inner Join sade.tb_compseg_tipo ct ON (C.idcst = ct.idcst) "
        pgsql += "  	                       inner Join sade.tb_compseg_estado ce On ( C.idcse = ce.idcse) "
        pgsql += "  WHERE C.idcst = 3"

        Dim dtP As New DataTable()
        dtP = NpgsqlHelper.ExecuteDataset(cadena, CommandType.Text, pgsql).Tables(0)

        Dim sb As New StringBuilder
        Dim sw As New IO.StringWriter(sb)
        Dim strOut As String = String.Empty
        Using jw As New JsonTextWriter(sw)
            jw.WriteStartObject()
            jw.WritePropertyName("Marcador")
            jw.WriteStartArray()
            For i As Integer = 0 To dtP.Rows.Count - 1
                jw.WriteStartObject()

                jw.WritePropertyName("idcs")
                jw.WriteValue(dtP.Rows(i).Item("idcs"))
                jw.WritePropertyName("direccion")
                jw.WriteValue(dtP.Rows(i).Item("direccion"))
                jw.WritePropertyName("idcst")
                jw.WriteValue(dtP.Rows(i).Item("idcst"))
                jw.WritePropertyName("idcse")
                jw.WriteValue(dtP.Rows(i).Item("idcse"))
                jw.WritePropertyName("info_cs")
                jw.WriteValue(dtP.Rows(i).Item("info_cs"))
                jw.WritePropertyName("comunica_cs")
                jw.WriteValue(dtP.Rows(i).Item("comunica_cs"))
                jw.WritePropertyName("ipred_cs")
                jw.WriteValue(dtP.Rows(i).Item("ipred_cs"))
                jw.WritePropertyName("_xgeo")
                jw.WriteValue(dtP.Rows(i).Item("_xgeo"))
                jw.WritePropertyName("_ygeo")
                jw.WriteValue(dtP.Rows(i).Item("_ygeo"))
                jw.WritePropertyName("observ_est")
                jw.WriteValue(dtP.Rows(i).Item("observ_est"))

                jw.WriteEndObject()
            Next
            jw.WriteEndArray()
            jw.WriteEndObject()
            strOut = sw.ToString
        End Using
        jsoncallback = HttpContext.Current.Request.QueryString("jsoncallback")
        HttpContext.Current.Response.Write(jsoncallback & "(" & strOut & ");")
    End Sub

    <WebMethod()>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub listarCamarasGEO(ByVal pCOVV As String, ByVal pESTADO As String)

        Dim MiCnx As ConnectionStringSettings = Nothing
        MiCnx = ConfigurationManager.ConnectionStrings("PgMSS")
        Dim cadena As String = MiCnx.ConnectionString
        Dim pgsql As String = ""

        pgsql += "  Select c.intidcamara, c.intcodmarca, cm.vchdesmarca, c.vchmodelo, c.vchnroserie, c.intcodcovv, co.vchdescovv,c.vchipcamara, "
        pgsql += "  c.vchlat, c.vchlon, c.geom, "
        pgsql += "  ST_x(ST_centroid(ST_Transform(C.geom, 32718))) As _xgeo, "
        pgsql += "  ST_y(ST_centroid(ST_Transform(C.geom, 32718))) As _ygeo, "
        pgsql += "  c.vchcodarea, c.vchcodsector, c.vchssecvecinal, c.vchcodcuadrante, c.vchcodaxxon, "
        pgsql += "  c.vchubicacion, c.vchurbanizacion, c.intcodestado, ce.vchdesestado, c.vchobserva  "
        pgsql += "      From sade.tb_camara c left outer Join sade.tb_camaramarca cm on (c.intcodmarca = cm.intcodmarca) "
        pgsql += "  	                      Left outer join sade.tb_covv co On (c.intcodcovv = co.intcodcovv) "
        pgsql += "  						  Left outer join sade.tb_camaraestado ce on (c.intcodestado = ce.intcodestado) "
        pgsql += "  WHERE (c.intidcamara is not null)  "

        If pCOVV <> 0 Then
            pgsql += "    AND (c.intcodcovv = " + pCOVV.ToString + ") "
        End If

        If pESTADO <> 0 Then
            pgsql += "    AND (c.intcodestado = " + pESTADO.ToString + ") "
        End If

        Dim dtP As New DataTable()
        dtP = NpgsqlHelper.ExecuteDataset(cadena, CommandType.Text, pgsql).Tables(0)

        Dim sb As New StringBuilder
        Dim sw As New IO.StringWriter(sb)
        Dim strOut As String = String.Empty
        Using jw As New JsonTextWriter(sw)
            jw.WriteStartObject()
            jw.WritePropertyName("Camaras")
            jw.WriteStartArray()
            For i As Integer = 0 To dtP.Rows.Count - 1
                jw.WriteStartObject()

                jw.WritePropertyName("intidcamara")
                jw.WriteValue(dtP.Rows(i).Item("intidcamara"))
                jw.WritePropertyName("intcodmarca")
                jw.WriteValue(dtP.Rows(i).Item("intcodmarca"))
                jw.WritePropertyName("vchdesmarca")
                jw.WriteValue(dtP.Rows(i).Item("vchdesmarca"))
                jw.WritePropertyName("vchmodelo")
                jw.WriteValue(dtP.Rows(i).Item("vchmodelo"))
                jw.WritePropertyName("vchnroserie")
                jw.WriteValue(dtP.Rows(i).Item("vchnroserie"))
                jw.WritePropertyName("intcodcovv")
                jw.WriteValue(dtP.Rows(i).Item("intcodcovv"))
                jw.WritePropertyName("vchdescovv")
                jw.WriteValue(dtP.Rows(i).Item("vchdescovv"))
                jw.WritePropertyName("vchipcamara")
                jw.WriteValue(dtP.Rows(i).Item("vchipcamara"))
                jw.WritePropertyName("vchlat")
                jw.WriteValue(dtP.Rows(i).Item("vchlat"))
                jw.WritePropertyName("vchlon")
                jw.WriteValue(dtP.Rows(i).Item("vchlon"))
                jw.WritePropertyName("geom")
                jw.WriteValue(dtP.Rows(i).Item("geom"))
                jw.WritePropertyName("_xgeo")
                jw.WriteValue(dtP.Rows(i).Item("_xgeo"))
                jw.WritePropertyName("_ygeo")
                jw.WriteValue(dtP.Rows(i).Item("_ygeo"))
                jw.WritePropertyName("vchcodarea")
                jw.WriteValue(dtP.Rows(i).Item("vchcodarea"))
                jw.WritePropertyName("vchcodsector")
                jw.WriteValue(dtP.Rows(i).Item("vchcodsector"))
                jw.WritePropertyName("vchssecvecinal")
                jw.WriteValue(dtP.Rows(i).Item("vchssecvecinal"))
                jw.WritePropertyName("vchcodcuadrante")
                jw.WriteValue(dtP.Rows(i).Item("vchcodcuadrante"))
                jw.WritePropertyName("vchcodaxxon")
                jw.WriteValue(dtP.Rows(i).Item("vchcodaxxon"))
                jw.WritePropertyName("vchubicacion")
                jw.WriteValue(dtP.Rows(i).Item("vchubicacion"))
                jw.WritePropertyName("vchurbanizacion")
                jw.WriteValue(dtP.Rows(i).Item("vchurbanizacion"))
                jw.WritePropertyName("intcodestado")
                jw.WriteValue(dtP.Rows(i).Item("intcodestado"))
                jw.WritePropertyName("vchdesestado")
                jw.WriteValue(dtP.Rows(i).Item("vchdesestado"))
                jw.WritePropertyName("vchobserva")
                jw.WriteValue(dtP.Rows(i).Item("vchobserva"))
                jw.WriteEndObject()

            Next
            jw.WriteEndArray()
            jw.WriteEndObject()
            strOut = sw.ToString
        End Using
        jsoncallback = HttpContext.Current.Request.QueryString("jsoncallback")
        HttpContext.Current.Response.Write(jsoncallback & "(" & strOut & ");")
    End Sub

    <WebMethod()>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub listarUnidadesGEO()

        Dim MiCnx As ConnectionStringSettings = Nothing
        MiCnx = ConfigurationManager.ConnectionStrings("PgMSS")
        Dim cadena As String = MiCnx.ConnectionString
        Dim pgsql As String = ""

        pgsql += "  Select intissi, intposid, decposlon, decposlat, to_char(datposfreg, 'YYYY/MM/DD HH:MM:SS') as datposfreg, vchcodunidad, intinccodigo, "
        pgsql += "  vchcodhu, vchdenhu, vchcodvia, vchnomvia, vchcdavia, vchcdte, vchsector, vchxgeo, vchygeo "
        pgsql += "  From sade.gps_issi "
        pgsql += "  WHERE extract('Year' from datposfreg) = extract('Year' from (current_timestamp)) "
        pgsql += "  And extract('Month' from datposfreg) = extract('Month' from (current_timestamp)) "
        pgsql += "  And extract('Day' from datposfreg) = extract('Day' from (current_timestamp)) "
        pgsql += "  And extract('Hour' from datposfreg) = extract('Hour' from (current_timestamp)) "
        pgsql += "  Order By vchcodunidad asc "

        Dim dtP As New DataTable()
        dtP = NpgsqlHelper.ExecuteDataset(cadena, CommandType.Text, pgsql).Tables(0)

        Dim sb As New StringBuilder
        Dim sw As New IO.StringWriter(sb)
        Dim strOut As String = String.Empty
        Using jw As New JsonTextWriter(sw)
            jw.WriteStartObject()
            jw.WritePropertyName("Unidades")
            jw.WriteStartArray()
            For i As Integer = 0 To dtP.Rows.Count - 1
                jw.WriteStartObject()

                jw.WritePropertyName("intissi")
                jw.WriteValue(dtP.Rows(i).Item("intissi"))
                jw.WritePropertyName("intposid")
                jw.WriteValue(dtP.Rows(i).Item("intposid"))
                jw.WritePropertyName("decposlon")
                jw.WriteValue(dtP.Rows(i).Item("decposlon"))
                jw.WritePropertyName("decposlat")
                jw.WriteValue(dtP.Rows(i).Item("decposlat"))
                jw.WritePropertyName("datposfreg")
                jw.WriteValue(dtP.Rows(i).Item("datposfreg"))
                jw.WritePropertyName("vchcodunidad")
                jw.WriteValue(dtP.Rows(i).Item("vchcodunidad"))
                jw.WritePropertyName("intinccodigo")
                jw.WriteValue(dtP.Rows(i).Item("intinccodigo"))
                jw.WritePropertyName("vchcodhu")
                jw.WriteValue(dtP.Rows(i).Item("vchcodhu"))
                jw.WritePropertyName("vchdenhu")
                jw.WriteValue(dtP.Rows(i).Item("vchdenhu"))
                jw.WritePropertyName("vchcodvia")
                jw.WriteValue(dtP.Rows(i).Item("vchcodvia"))
                jw.WritePropertyName("vchnomvia")
                jw.WriteValue(dtP.Rows(i).Item("vchnomvia"))
                jw.WritePropertyName("vchcdavia")
                jw.WriteValue(dtP.Rows(i).Item("vchcdavia"))
                jw.WritePropertyName("vchcdte")
                jw.WriteValue(dtP.Rows(i).Item("vchcdte"))
                jw.WritePropertyName("vchsector")
                jw.WriteValue(dtP.Rows(i).Item("vchsector"))
                jw.WritePropertyName("vchxgeo")
                jw.WriteValue(dtP.Rows(i).Item("vchxgeo"))
                jw.WritePropertyName("vchygeo")
                jw.WriteValue(dtP.Rows(i).Item("vchygeo"))

                jw.WriteEndObject()

            Next
            jw.WriteEndArray()
            jw.WriteEndObject()
            strOut = sw.ToString
        End Using
        jsoncallback = HttpContext.Current.Request.QueryString("jsoncallback")
        HttpContext.Current.Response.Write(jsoncallback & "(" & strOut & ");")
    End Sub

    <WebMethod()>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub listarHabilitaciones()

        Dim MiCnx As ConnectionStringSettings = Nothing
        MiCnx = ConfigurationManager.ConnectionStrings("PgMSS")
        Dim cadena As String = MiCnx.ConnectionString

        Dim pgsql As String


        pgsql = "SELECT hu.idhu, hu.cod, "
        pgsql += "  hu.denom||' - '||hut.dsc as nom, hu.idhut,"
        pgsql += "  ST_x(ST_centroid(ST_Transform(hu.geom,32718))) as _xgeo,ST_y(ST_centroid(ST_Transform(hu.geom,32718))) as _ygeo,"
        pgsql += "  ST_AsGeoJSON(ST_Transform(hu.geom,32718),15,0) as geom "
        pgsql += "    FROM carto.tb_ha_urbana hu join carto.tb_ha_urbana_tipo hut on hu.idhut = hut.idhut"
        pgsql += "    order by hu.denom, hu.idhut"

        Dim strMensaje As String
        Dim strEstado As String
        Dim json As String = ""

        Dim ds As New DataSet
        Try
            ds = NpgsqlHelper.ExecuteDataset(cadena, CommandType.Text, pgsql)
            json = JsonConvert.SerializeObject(ds, Formatting.Indented)
            strMensaje = "Listado completo!!!"
            strEstado = "0"
        Catch ex As Exception
            strMensaje = ex.Message
            strEstado = "8"
        End Try
        jsoncallback = HttpContext.Current.Request.QueryString("jsoncallback")
        HttpContext.Current.Response.Write(jsoncallback & "(" & json & ");")
    End Sub

    <WebMethod(EnableSession:=True)>
    Public Function listarHabilitaGeo() As List(Of Habilitacion)
        Dim MiCnx As ConnectionStringSettings = Nothing
        MiCnx = ConfigurationManager.ConnectionStrings("PgMSS")
        Dim cadena As String = MiCnx.ConnectionString

        Dim pgsql As String

        pgsql = "SELECT hu.idhu, hu.cod, "
        pgsql += "  hu.denom||' - '||hut.dsc as nom, hu.idhut,"
        pgsql += "  ST_x(ST_centroid(ST_Transform(hu.geom,32718))) as _xgeo,ST_y(ST_centroid(ST_Transform(hu.geom,32718))) as _ygeo,"
        pgsql += "  ST_AsGeoJSON(ST_Transform(hu.geom,32718),15,0) as geom "
        pgsql += "    FROM carto.tb_ha_urbana hu join carto.tb_ha_urbana_tipo hut on hu.idhut = hut.idhut"
        pgsql += "    order by hu.denom, hu.idhut"

        Dim dtP As New DataTable()
        dtP = NpgsqlHelper.ExecuteDataset(cadena, CommandType.Text, pgsql).Tables(0)

        Dim oHabilitacion As New List(Of Habilitacion)
        For Each row As DataRow In dtP.Rows
            Dim oH As New Habilitacion()
            oH.idhabilita = row("idhu").ToString()
            oH.codhabilita = row("cod").ToString()
            oH.nomhabilita = row("nom").ToString()
            oH.xGeo = row("_xgeo").ToString()
            oH.yGeo = row("_ygeo").ToString()
            oH.Geom = row("geom").ToString()
            oHabilitacion.Add(oH)
        Next
        Return oHabilitacion
    End Function



    <WebMethod()>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub listarParques()

        Dim MiCnx As ConnectionStringSettings = Nothing
        MiCnx = ConfigurationManager.ConnectionStrings("PgMSS")
        Dim cadena As String = MiCnx.ConnectionString

        Dim pgsql As String
        pgsql = "SELECT p.idparq, p.idlot, p.pref||' '||p.nom as nomparq, "
        pgsql += "  ST_x(ST_centroid(ST_Transform(p.geom,32718))) as _xgeo,"
        pgsql += "  ST_y(ST_centroid(ST_Transform(p.geom,32718))) as _ygeo,"
        pgsql += "  ST_AsGeoJSON(ST_Transform(p.geom,32718),15,0) as geom "
        pgsql += "    FROM carto.tb_lote_parque p"
        pgsql += "    ORDER BY p.nom"

        Dim strMensaje As String
        Dim strEstado As String
        Dim json As String = ""

        Dim ds As New DataSet
        Try
            ds = NpgsqlHelper.ExecuteDataset(cadena, CommandType.Text, pgsql)
            json = JsonConvert.SerializeObject(ds, Formatting.Indented)
            strMensaje = "Listado completo!!!"
            strEstado = "0"
        Catch ex As Exception
            strMensaje = ex.Message
            strEstado = "8"
        End Try
        jsoncallback = HttpContext.Current.Request.QueryString("jsoncallback")
        HttpContext.Current.Response.Write(jsoncallback & "(" & json & ");")
    End Sub

    <WebMethod(EnableSession:=True)>
    Public Function listarParquesGeo() As List(Of Parque)

        Dim MiCnx As ConnectionStringSettings = Nothing
        MiCnx = ConfigurationManager.ConnectionStrings("PgMSS")
        Dim cadena As String = MiCnx.ConnectionString

        Dim pgsql As String

        pgsql = "SELECT p.idparq, p.idlot, p.pref||' '||p.nom as nom, "
        pgsql += "  ST_x(ST_centroid(ST_Transform(p.geom,32718))) as _xgeo,ST_y(ST_centroid(ST_Transform(p.geom,32718))) as _ygeo,"
        pgsql += "  ST_AsGeoJSON(ST_Transform(p.geom,32718),15,0) as geom "
        pgsql += "    FROM carto.tb_lote_parque p"
        pgsql += "    ORDER BY p.nom"

        Dim dtP As New DataTable()
        dtP = NpgsqlHelper.ExecuteDataset(cadena, CommandType.Text, pgsql).Tables(0)

        Dim oParque As New List(Of Parque)
        For Each row As DataRow In dtP.Rows
            Dim oP As New Parque()
            oP.idparque = row("idparq").ToString()
            oP.codparque = row("idlot").ToString()
            oP.nomparque = row("nom").ToString()
            oP.xGeo = row("_xgeo").ToString()
            oP.yGeo = row("_ygeo").ToString()
            oP.Geom = row("geom").ToString()
            oParque.Add(oP)
        Next
        Return oParque
    End Function


End Class
