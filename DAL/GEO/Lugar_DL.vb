Imports System.Configuration
Imports System
Imports AccesoDatosGEO
Imports SISSADE.BE


Namespace DAL

    Public Class LUGAR_DL

        Public Function proj_LonLat2XY(ByVal pLon As String, ByVal pLat As String) As LUGAR_BE
            Dim MiCnx As ConnectionStringSettings = Nothing
            MiCnx = ConfigurationManager.ConnectionStrings("PgMSS")
            Dim cadena As String = MiCnx.ConnectionString
            Dim pgsql As String = "	SELECT "
            pgsql += " 	ST_X(ST_TRANSFORM( ST_GEOMFROMTEXT('POINT(" + pLon + " " + pLat + ")',4326),32718)) AS _XGEO, "
            pgsql += " 	ST_Y(ST_TRANSFORM( ST_GEOMFROMTEXT('POINT(" + pLon + " " + pLat + ")',4326),32718)) AS _YGEO, "
            pgsql += " 	(SELECT L.NRO FROM CARTO.TB_CUADRANTE L "
            pgsql += " 	  WHERE ST_CONTAINS(L.GEOM, ST_TRANSFORM( ST_GEOMFROMTEXT('POINT(" + pLon + " " + pLat + ")',4326),32718) )"
            pgsql += " 	  LIMIT 1) AS CUADRANTE,"
            pgsql += " 	(SELECT L.NRO FROM CARTO.TB_SECTOR_VECINAL L"
            pgsql += " 	 WHERE ST_CONTAINS(L.GEOM, ST_TRANSFORM( ST_GEOMFROMTEXT('POINT(" + pLon + " " + pLat + ")',4326),32718) )  "
            pgsql += " 	   LIMIT 1) AS SECTOR,"
            pgsql += " 	( SELECT V.NOM_ACT || ' CDRA.' || C.NRO_CDRA AS NOM_ACT"
            pgsql += " 	    FROM CARTO.TB_VIA AS V INNER JOIN CARTO.TB_VIA_HISN  AS VH ON V.IDVIA=VH.IDVIA AND ACT=1"
            pgsql += " 				   INNER JOIN CARTO.TB_VIA_CUADRA AS C ON V.IDVIA=C.IDVIA"
            pgsql += " 	   WHERE ST_DWITHIN(ST_TRANSFORM( ST_GEOMFROMTEXT('POINT(" + pLon + " " + pLat + ")',4326),32718), ST_TRANSFORM(C.GEOM,32718) ,50)"
            pgsql += " 	ORDER BY V.IDVIA, C.NRO_CDRA "
            pgsql += " 	 LIMIT 1) AS VIA, "
            pgsql += " 	(SELECT LT.DSC||' '||L.DENOM FROM CARTO.TB_HA_URBANA L INNER JOIN CARTO.TB_HA_URBANA_TIPO LT ON L.IDHUT = LT.IDHUT "
            pgsql += " 	WHERE ST_CONTAINS(L.GEOM, ST_TRANSFORM( ST_GEOMFROMTEXT('POINT(" + pLon + " " + pLat + ")',4326),32718)) "
            pgsql += " 	LIMIT 1) AS HU "

            Dim dtP As New DataTable()
            dtP = NpgsqlHelper.ExecuteDataset(cadena, CommandType.Text, pgsql).Tables(0)

            Dim oLugar As New LUGAR_BE
            For Each row As DataRow In dtP.Rows
                oLugar.nLat = pLat
                oLugar.nLon = pLon
                oLugar.xGeo = row("_xgeo").ToString()
                oLugar.yGeo = row("_ygeo").ToString()
                oLugar.nCuadrante = row("CUADRANTE").ToString()
                oLugar.nSector = row("SECTOR").ToString()
                oLugar.nVia = row("VIA").ToString()
                oLugar.nHabilita = row("HU").ToString()
            Next
            Return oLugar

        End Function

        Public Function proj_XY2LonLat(ByVal pX As String, ByVal pY As String) As LUGAR_BE
            Dim MiCnx As ConnectionStringSettings = Nothing
            MiCnx = ConfigurationManager.ConnectionStrings("PgMSS")
            Dim cadena As String = MiCnx.ConnectionString
            Dim pgsql As String = "SELECT  "
            pgsql += " ST_x(ST_Transform(ST_GeomFromText('POINT('||" + pX + "||' '||" + pY + "||')',32718),4326)) as _lon,"
            pgsql += " ST_y(ST_Transform(ST_GeomFromText('POINT('||" + pX + "||' '||" + pY + "||')',32718),4326)) as _lat, "
            pgsql += " 	(SELECT L.NRO FROM CARTO.TB_CUADRANTE L "
            pgsql += " 	  WHERE ST_CONTAINS(L.GEOM, ST_GEOMFROMTEXT('POINT(" + pX + " " + pY + ")',32718) )"
            pgsql += " 	  LIMIT 1) AS CUADRANTE,"
            pgsql += " 	(SELECT L.NRO FROM CARTO.TB_SECTOR_VECINAL L"
            pgsql += " 	 WHERE ST_CONTAINS(L.GEOM,  ST_GEOMFROMTEXT('POINT(" + pX + " " + pY + ")',32718) )  "
            pgsql += " 	   LIMIT 1) AS SECTOR,"
            pgsql += " 	( SELECT V.NOM_ACT || ' CDRA.' || C.NRO_CDRA AS NOM_ACT"
            pgsql += " 	    FROM CARTO.TB_VIA AS V INNER JOIN CARTO.TB_VIA_HISN  AS VH ON V.IDVIA=VH.IDVIA AND ACT=1"
            pgsql += " 				   INNER JOIN CARTO.TB_VIA_CUADRA AS C ON V.IDVIA=C.IDVIA"
            pgsql += " 	   WHERE ST_DWITHIN( ST_GEOMFROMTEXT('POINT(" + pX + " " + pY + ")',32718), ST_TRANSFORM(C.GEOM,32718) ,50)"
            pgsql += " 	ORDER BY V.IDVIA, C.NRO_CDRA "
            pgsql += " 	 LIMIT 1) AS VIA, "
            pgsql += " 	(SELECT LT.DSC||' '||L.DENOM FROM CARTO.TB_HA_URBANA L INNER JOIN CARTO.TB_HA_URBANA_TIPO LT ON L.IDHUT = LT.IDHUT "
            pgsql += " 	WHERE ST_CONTAINS(L.GEOM, ST_GEOMFROMTEXT('POINT(" + pX + " " + pY + ")',32718)) "
            pgsql += " 	LIMIT 1) AS HU "

            Dim dtP As New DataTable()
            dtP = NpgsqlHelper.ExecuteDataset(cadena, CommandType.Text, pgsql).Tables(0)

            Dim oLugar As New LUGAR_BE
            For Each row As DataRow In dtP.Rows
                oLugar.nLat = row("_lon").ToString()
                oLugar.nLon = row("_lat").ToString()
                oLugar.xGeo = pX
                oLugar.yGeo = pY
                oLugar.nCuadrante = row("CUADRANTE").ToString()
                oLugar.nSector = row("SECTOR").ToString()
                oLugar.nVia = row("VIA").ToString()
                oLugar.nHabilita = row("HU").ToString()
            Next
            Return oLugar
        End Function

    End Class
End Namespace

