﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmIncidenciaCambiaUbicacion.aspx.vb" Inherits="frmIncidenciaCambiaUbicacion" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="MapaTematico/OpenLayers-2.13.1/OpenLayers.js" type="text/javascript"></script>

    <link href="Styles/accordionmenu.css" rel="stylesheet" type="text/css" />
	<link rel="stylesheet" href="css/themes/base/jquery.ui.all.css"/>
    <script src="js/jquery.js" type="text/javascript"></script>
	<script src="js/jquery-1.9.1.js" type="text/javascript"></script>
	<script src="js/ui/jquery.ui.core.js" type="text/javascript"></script>
	<script src="js/ui/jquery.ui.widget.js" type="text/javascript"></script>
	<script src="js/ui/jquery.ui.accordion.js" type="text/javascript"></script>
    <script src="sidr/js/jquery.sidr.min.js" type="text/javascript"></script>
    <link href="sidr/css/jquery.sidr.dark.css" rel="stylesheet" type="text/css" />


	<%--<link rel="stylesheet" href="css/master.css" type="text/css" />--%>

	<link rel="stylesheet" href="css/demos.css" type="text/css" />
    <link href="css/calendario.css" rel="stylesheet" type="text/css" />
    <link href="css/boton.css" rel="stylesheet" type="text/css" />
    <link href="css/grid2.css" rel="stylesheet" type="text/css" />
    <link href="css/controles.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .EncabezadoTab
        {
            height:20px; 
            font-size:10pt; 
            font-family:Tahoma, Sans-Serif; 
            background-color:#D34434; 
            color:White;            
        }
        .header-cont
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            width: 100%;
            height: auto;
            position: fixed;
            background-color: #666;
            color: #FFF;
        }
        
        #pnlBusqueda
        {
            width: 100%;
            margin-top: 0px;
        }
        
        .Flotante
        {
            position: absolute;
            top: 25px;
            left: 37px;
        }
        
        div#map
        {
            position: relative;
            width: 800px;
            height: 550px;
            margin-top: 0px;
            margin-bottom: 0px;
            border-top: 1px solid #333;
            border-bottom: 2px solid #333;
        }
        </style>
    <script language="javascript" type="text/javascript">
        function solonumeros(e) {
            var key;
            if (window.event) // IE
            {
                key = e.keyCode;
            }
            else if (e.which) // Netscape/Firefox/Opera
            {
                key = e.which;
            }
            if (key < 48 || key > 57) {
                return false;
            }
            return true;
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
   <asp:ScriptManager ID="ScriptManager1" runat="server" 
    EnableScriptGlobalization="True" EnableScriptLocalization="False" />

     <%--<asp:Timer ID="tmrTiempo" Interval="1000" runat="server">
    </asp:Timer>--%>

    <div id="pnlContenedor">
        <table class="Tabla" width="100%">
            <colgroup>
                <col width="50%" />
                <col width="50%" />
            </colgroup>
            <tr>
                <td valign="top">
                    <table class="Tabla" width="100%" style="border: 1px solid #ccc;">
                        <colgroup>
                            <col style="width: 7%" />
                            <col style="width: 28%" />
                            <col style="width: 7%" />
                            <col style="width: 28%" />
                            <col style="width: 7%" />
                            <col style="width: 23%" />
                        </colgroup>
                        <tr>
                            <td colspan="6" style="height:20px; font-size:10pt; font-family:Tahoma, Sans-Serif; background-color:#D34434; color:White;"><center>Información de Incidencia</center>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Nº
                            </td>
                            <td>
                                <asp:TextBox ID="txtNumeroInc" runat="server" CssClass="CajaTextoCOff" Width="50%"
                                    Enabled="False"></asp:TextBox>&nbsp;
                                <asp:TextBox ID="txtIncAsociados" runat="server" CssClass="CajaTextoCOff" Enabled="False"
                                    Width="20%"></asp:TextBox>
                            </td>
                            <td>
                                Origen
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlOrigenInc" runat="server" Width="90%" CssClass="CajaTextoCOff"
                                    Enabled="False">
                                </asp:DropDownList>
                            </td>
                            <td>
                                Fecha
                            </td>
                            <td>
                                <asp:TextBox ID="txtFechaInc" runat="server" CssClass="CajaTextoCOff" Width="90%"
                                    Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Inform.</td>
                            <td colspan="3">
                        <asp:DropDownList ID="ddlTipoPersona" runat="server" CssClass="CajaCombo" Width="25%" 
                                    Enabled="False">
                        </asp:DropDownList>
                            &nbsp;
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="CajaTextoCOff" Width="65%" 
                                    Enabled="False"></asp:TextBox>
                            </td>
                            <td>
                                Número</td>
                            <td>
                        <asp:TextBox ID="txtNumero" runat="server" CssClass="CajaTextoCOff" MaxLength="15"
                            placeholder="Ingrese Teléfono" Width="80%" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        </table>
                </td>
                <td valign="top">
                    <table class="Tabla" width="100%" style="border: 1px solid #ccc;">
                            <colgroup>
                                <col width="5%" />
                                <col width="5%" />
                                <col width="5%" />
                                <col width="5%" />
                                <col width="5%" />
                                <col width="5%" />
                                <col width="5%" />
                                <col width="5%" />
                                <col width="5%" />
                                <col width="5%" />
                                <col width="5%" />
                                <col width="5%" />
                                <col width="5%" />
                                <col width="5%" />
                                <col width="5%" />
                                <col width="5%" />
                            </colgroup>
                            <tr>
                                <td colspan="16" style="height:20px; font-size:10pt; font-family:Tahoma, Sans-Serif; background-color:#D34434; color:White;"><center>Ubicación de Incidencia</center>
                                </td>
                            </tr>


                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    Via
                                </td>
                                <td colspan="6" align="left">
                                    <asp:TextBox ID="txtViaInc" runat="server" CssClass="CajaTextoCOff" MaxLength="150"
                                        Width="95%"></asp:TextBox>
                                </td>
                                <td align="left">
                                    &nbsp;</td>
                                <td>
                                    Cdra.
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtCdraInc" runat="server" CssClass="CajaTextoCOff" MaxLength="10"
                                        Width="80%" ReadOnly="True" ></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;Nro.
                                </td>
                                <td align="left" colspan="2">
                                    <asp:TextBox ID="txtNroInc" runat="server" CssClass="CajaTextoCOff" MaxLength="10"
                                        Width="80%" ></asp:TextBox>
                                </td>
                                <td>Dpto/Int.</td>
                                <td>
                                    <asp:TextBox ID="txtDptoInc" runat="server" CssClass="CajaTextoCOff" MaxLength="10"
                                        Width="80%" ></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>Intersección</td>
                                <td colspan="6" align="left">
                                    <asp:TextBox ID="txtIntInc" runat="server" CssClass="CajaTextoCOff" MaxLength="150"
                                        Width="95%"></asp:TextBox>
                                </td>
                                <td align="left">
                                    &nbsp;</td>
                                <td>
                                    Mza/Lte.</td>
                                <td align="left">
                                    <asp:TextBox ID="txtMzaInc" runat="server" CssClass="CajaTextoCOff" MaxLength="10"
                                        Width="70%"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLteInc" runat="server" CssClass="CajaTextoOff" MaxLength="10"
                                        Width="70%" ReadOnly="True" Enabled="False"></asp:TextBox>
                                </td>
                                <td align="left">
                                    Sector
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSector" runat="server" CssClass="CajaTextoCOff" placeholder="SC"
                                        Width="80%" Enabled="False"></asp:TextBox>
                                </td>
                                <td>
                                    Cuadrante
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCuadrante" runat="server" CssClass="CajaTextoCOff" placeholder="CD"
                                        Width="80%" Enabled="False"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    Hab.Urbana</td>
                                <td colspan="6" align="left">
                                    <asp:TextBox ID="txtUrbInc" runat="server" CssClass="CajaTextoCOff" MaxLength="100"
                                        Width="95%" Enabled="False"></asp:TextBox>
                                </td>
                                <td align="left">
                                    &nbsp;</td>
                                <td>Referencia
                                </td>
                                <td colspan="6">
                                    <asp:TextBox ID="txtComInc" runat="server" CssClass="CajaTextoCOff" MaxLength="200"
                                        Width="95%" Enabled="False"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div id="divMap" style="width: 99%; height: 500px; border: 1px solid #ccc;">
                    </div>            
                </td>
            </tr>
            <tr>
                <td></td>
                <td align="right">
                    <asp:Label ID="lblCuentaCar" runat="server" Text="*"></asp:Label>
                    <asp:Button ID="btnGrabar" runat="server" Text=" Guardar Cambios " CssClass="boton_regresar" />
                    &nbsp;<asp:Button ID="btnRetorno" runat="server" Text="Regresar" CssClass="boton_dialogo" onclientclick="cerrarpagina()" />
                &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" align="center" style="color:Red"><asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="#CC0000"></asp:Label>
    </div>
    
    <asp:HiddenField ID="hfGeoX" runat="server" />
    <asp:HiddenField ID="hfGeoY" runat="server" />
    <asp:HiddenField ID="hfViaInc" runat="server" />
    <asp:HiddenField ID="hfUrbInc" runat="server" />
    <asp:HiddenField ID="hfIntInc" runat="server" />

    <script type="text/javascript">

        var nomViaInt = '<%= txtIntInc.ClientID %>';
        var codViaInt = '<%= hfIntInc.ClientID %>';
        var coorX = '<%= hfGeoX.ClientID %>';
        var coorY = '<%= hfGeoY.ClientID %>';
        var nomVia = '<%= txtViaInc.ClientID %>';
        var codVia = '<%= hfViaInc.ClientID %>';
        var numCdra = '<%= txtCdraInc.ClientID %>';
        var denHU = '<%= txtUrbInc.ClientID %>';
        var codHU = '<%= hfUrbInc.ClientID %>';
        var codSEC = '<%= txtSector.ClientID %>';
        var codCTE = '<%= txtCuadrante.ClientID %>';
        var numLTU = '<%= txtLteInc.ClientID %>';
        var numMZU = '<%= txtMzaInc.ClientID %>';

        var grid;
        var mapPanel;
        var panLote;
        var infoLote;
        var infoGPS;



        var map;
        var markers;
        var vSelecc = null;
        var vecLayerCS;
        var matrizCalles = [];
        var matrizPersona = [];
        var vectorLayer;

        var vSERVER = "http://serviciosgis.munisurco.gob.pe:70/geoserver/CM150140/wms";
        var vFOTOS = "http://serviciosgis.munisurco.gob.pe:70/multimedia/fotos/catastro/2012/";


        OpenLayers.IMAGE_RELOAD_ATTEMPTS = 5;
        OpenLayers.Util.onImageLoadErrorColor = "transparent";
        OpenLayers.Tile.Image.useBlankTile = true;
        OpenLayers.DOTS_PER_INCH = 90.71428571428572;

        initMAP();

        function initMAP() {

            var vPtoX = document.getElementById(coorX).value;
            var vPtoY = document.getElementById(coorY).value;
            console.log();

            OpenLayers.Control.Click = OpenLayers.Class(OpenLayers.Control, {
                defaultHandlerOptions: {
                    'single': true,
                    'double': false,
                    'pixelTolerance': 0,
                    'stopSingle': false,
                    'stopDouble': false
                },

                initialize: function (options) {
                    this.handlerOptions = OpenLayers.Util.extend(
                        {}, this.defaultHandlerOptions
                    );
                    OpenLayers.Control.prototype.initialize.apply(
                        this, arguments
                    );
                    this.handler = new OpenLayers.Handler.Click(
                        this, {
                            'click': this.trigger
                        }, this.handlerOptions
                    );
                },

                trigger: function (e) {
                    var lonlat = map.getLonLatFromPixel(e.xy);
                    MapMarker(lonlat.lon, lonlat.lat);
                    muestraUbicacion(lonlat.lon, lonlat.lat)

                }

            });

            vectorLayer = new OpenLayers.Layer.Vector("Recursos GPS")

            //mostrarGeoRecursos();

            var wms = new OpenLayers.Layer.WMS("MuniSurco", vSERVER,
                                    {
                                        srs: 'EPSG:32718',
                                        layers: 'CM150140:CM150140_base',
                                        tiled: true,
                                        transparent: false
                                    });

            var lote = new OpenLayers.Layer.WMS("Limite Lote", vSERVER,
                                    {
                                        srs: 'EPSG:32718',
                                        layers: 'CM150140:map_lote',
                                        transparent: true
                                    }, { isBaseLayer: false
                                    });
            var clote = new OpenLayers.Layer.WMS("Mza/Lote Urbano", vSERVER,
                                    {
                                        srs: 'EPSG:32718',
                                        layers: 'map_lote_mzurb',
                                        transparent: true
                                    }, { isBaseLayer: false
                                    });

            var sc = new OpenLayers.Layer.WMS("Limite Cuadrantes", vSERVER,
                                    {
                                        srs: 'EPSG:32718',
                                        layers: 'map_cuadrante',
                                        transparent: true
                                    }, { isBaseLayer: false, visibility: true }
                                    );


            map = new OpenLayers.Map({
                div: "divMap",
                layers: [wms, lote, clote, sc],
                maxExtent: new OpenLayers.Bounds(275000.000, 8645389.716, 288750.000, 8664783.095),
                projection: new OpenLayers.Projection("EPSG:32718"),
                displayProj: new OpenLayers.Projection("EPSG:32718"),
                zoom: 2,
                maxzoom: 1,
                minzoom: 10,
                controls: [
                        new OpenLayers.Control.Navigation(),
                        new OpenLayers.Control.PanZoomBar(),
                        new OpenLayers.Control.LayerSwitcher({ 'ascending': false }),
                        new OpenLayers.Control.MousePosition(),
                        //new OpenLayers.Control.OverviewMap(),
                        new OpenLayers.Control.KeyboardDefaults()
                      ],
                center: [283430.991, 8657254.839]
            });



            vSelecc = new OpenLayers.Layer.Vector("Objeto Seleccionado", { 'displayInLayerSwitcher': false, noLegend: true });
            vecLayerCS = new OpenLayers.Layer.Vector("Componentes Seguridad");



            map.addControl(new OpenLayers.Control.LayerSwitcher());
            if (!map.getCenter()) {
                map.zoomToMaxExtent();
            }

            //            var click = new OpenLayers.Control.Click();
            //            map.addControl(click);
            //            click.activate();
            //            console.log(map);

            if (vPtoX != "" || vPtoY != "") {
                console.log("prueba de ubicacion");
                var center = new OpenLayers.LonLat(vPtoX, vPtoY);
                MapMarker(vPtoX, vPtoY);
                //muestraUbicacion(vPtoX, vPtoY)
                map.setCenter(center, 8);
            }
        }

        function MapCalle(x, y, i) {
            var center = new OpenLayers.LonLat(x, y);

            map.setCenter(center, 8);
            var poly = matrizCalles[i][6]
            f_createVSelectLINE(poly);
        }

        function f_createVSelectLINE(geom) {
            console.log(geom);
            var posI = geom.indexOf("[");
            var posF = geom.indexOf("}");
            var poly = geom.substring(posI, posF);
            console.log(poly);
            vSelecc.removeAllFeatures();
            var fCollec = {
                "type": "FeatureCollection",
                "features": [{
                    "type": "Feature",
                    "properties": { "color": "green" },
                    "geometry": {
                        "type": "GeometryCollection",
                        "geometries": [{ "type": "LineString", "coordinates": eval(poly)}]
                    }
                }]
            };
            var gjsonf = new OpenLayers.Format.GeoJSON({
                'internalProjection': new OpenLayers.Projection("EPSG:32718"),
                'externalProjection': new OpenLayers.Projection("EPSG:32718")
            });
            map.addLayer(vSelecc);
            vSelecc.addFeatures(gjsonf.read(fCollec));
        };


        function MapMarker(x, y) {
            vecLayerCS.removeAllFeatures();
            var iMarker = 'img/marker.GIF';
            var feature = new OpenLayers.Feature.Vector(
                new OpenLayers.Geometry.Point(x, y),
                { description: "<h1>Componente</h1>" },
                { externalGraphic: iMarker, graphicHeight: 24, graphicWidth: 24, graphicXOffset: -12, graphicYOffset: -24 }
            );
            vecLayerCS.addFeatures(feature);
            map.addLayer(vecLayerCS);
            document.getElementById(coorX).value = x;
            document.getElementById(coorY).value = y;


        }


        function filterCalle(element) {
            var value = $(element).val();
            $("#ListCalle > li").each(function () {
                if ($(this).text().search(value) > -1) {
                    $(this).show();
                }
                else {
                    $(this).hide();
                }
            });
        }





        function muestraUbicacion(xGeo, yGeo) {
            var webMethod = "WebServiceGEO.asmx/buscaUbicacionXY";
            $.ajax({
                type: "POST",
                url: webMethod,
                data: "{'pX':'" + xGeo + "','pY':'" + yGeo + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var punto = response.d;
                    document.getElementById(coorX).value = punto.xGeo;
                    document.getElementById(coorY).value = punto.yGeo;
                    document.getElementById(codHU).value = punto.cHU;
                    document.getElementById(denHU).value = punto.nHU;
                    document.getElementById(codSEC).value = punto.nSector;
                    document.getElementById(codCTE).value = punto.nCdte;
                    document.getElementById(codVia).value = punto.cVia;
                    document.getElementById(nomVia).value = punto.nVia;
                    document.getElementById(numCdra).value = punto.cCda;
                    document.getElementById(numLTU).value = punto.cLTU;
                    document.getElementById(numMZU).value = punto.cMZU;
                    document.getElementById(codCAT).value = punto.cCODCAT;
                    document.getElementById(nomViaInt).value = punto.nViaInt;
                    document.getElementById(codViaInt).value = punto.cViaInt;
                },
                error: function (XMLHttpRequest, textStatus, error) { alert('ERROR:' + error); }
            });         //fin llamada ajax

        }


        function mostrarGeoRecursos() {

            var intSize = 20;
            var intLeft = -10;
            var intZoom = 3;
            var webMethod = "WebServiceGEO.asmx/gpsPosicionListar";
            var matrizGPS = [];

            vectorLayer.removeAllFeatures();
            $.ajax({
                type: "POST",
                url: webMethod,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var lista = response.d;
                    var txtHTML;
                    var txtINFO;
                    txtHTML = "";
                    i = 0;
                    $.each(lista, function (index, pan) {

                        i++;
                        txtHTML += "<li><a href='javascript:posicionGPS(" + pan.VCHPOSXGEO + "," + pan.VCHPOSYGEO + "," + pan.INTISSI + "," + pan.INTPOSID + ")'>";
                        txtHTML += "[ " + pan.INTISSI + " - " + pan.VCHTREDESCRIPCION + "]</a></li>";
                        var iMarker = 'img/Recursos/000.png';
                        var strUnit = pan.SMLTRECODIGO;

                        if (strUnit == 1) iMarker = "img/Recursos/001.png";
                        if (strUnit == 2) iMarker = "img/Recursos/002.png";
                        if (strUnit == 3) iMarker = "img/Recursos/003.png";
                        if (strUnit == 4) iMarker = "img/Recursos/004.png";
                        if (strUnit == 5) iMarker = "img/Recursos/005.png";
                        if (strUnit == 6) iMarker = "img/Recursos/006.png";
                        if (strUnit == 7) iMarker = "img/Recursos/007.png";
                        if (strUnit == 8) iMarker = "img/Recursos/008.png";
                        if (strUnit == 9) iMarker = "img/Recursos/009.png";
                        if (strUnit == 10) iMarker = "img/Recursos/010.png";
                        if (strUnit == 11) iMarker = "img/Recursos/011.png";
                        if (strUnit == 12) iMarker = "img/Recursos/012.png";
                        if (strUnit == 13) iMarker = "img/Recursos/013.png";
                        if (strUnit == 14) iMarker = "img/Recursos/014.png";
                        if (strUnit == 15) iMarker = "img/Recursos/015.png";

                        if (strUnit == 16) iMarker = "img/Recursos/016.png";
                        if (strUnit == 17) iMarker = "img/Recursos/017.png";
                        if (strUnit == 18) iMarker = "img/Recursos/018.png";
                        if (strUnit == 19) iMarker = "img/Recursos/019.png";
                        if (strUnit == 20) iMarker = "img/Recursos/020.png";

                        if (strUnit == 21) iMarker = "img/Recursos/021.png";
                        if (strUnit == 22) iMarker = "img/Recursos/022.png";
                        if (strUnit == 23) iMarker = "img/Recursos/023.png";
                        if (strUnit == 24) iMarker = "img/Recursos/024.png";
                        if (strUnit == 25) iMarker = "img/Recursos/025.png";



                        var featureR = new OpenLayers.Feature.Vector(
                            new OpenLayers.Geometry.Point(pan.VCHPOSXGEO, pan.VCHPOSYGEO),
                            { description: "<h1>marker number " + pan.INTISSI + "</h1>" },
                            { externalGraphic: iMarker, graphicHeight: intSize, graphicWidth: intSize, graphicXOffset: intLeft, graphicYOffset: intLeft }
                                                                        );

                        featureR.attributes = {
                            vID: pan.INTPOSID,
                            vISSI: pan.INTISSI,
                            vPOSLON: pan.DECPOSLON,
                            vPOSLAT: pan.DECPOSLAT,
                            vPOSFREG: pan.DATPOSFREG,
                            vPOSPRES: pan.INTPOSPRES,
                            vPOSVEL: pan.DECPOSVEL,
                            vCARCOD: pan.VCHCARCOD,
                            vESTCOD: pan.VCHESTCOD,
                            vSDSBUFFID: pan.INTSDSBUFFID,
                            vPOSCODHU: pan.VCHPOSCODHU,
                            vPOSDENHU: pan.VCHPOSDENHU,
                            vOSCODVIA: pan.VCHPOSCODVIA,
                            vPOSNOMVIA: pan.VCHPOSNOMVIA,
                            vPOSCDAVIA: pan.VCHPOSCDAVIA,
                            vPOSXGEO: pan.VCHPOSXGEO,
                            vPOSYGEO: pan.VCHPOSYGEO,
                            vPOSCDTE: pan.VCHPOSCDTE,
                            vPOSSECTOR: pan.VCHPOSSECTOR,
                            vESTDESC: pan.VCHESTDESC,
                            vESTRAD: pan.VCHESTRAD,
                            vESTNIMG: pan.VCHESTNIMG,
                            vESTCWEB: pan.VCHESTCWEB,
                            vCODREC: pan.INTRECCODIGO,
                            vDESREC: pan.VCHRECDESCRIPCION,
                            vTCODREC: pan.SMLTRECODIGO,
                            vTDESREC: pan.VCHTREDESCRIPCION,
                            vCODSEC: pan.SMLSECCODIGO,
                            vDESSEC: pan.VCHSECCODIGO
                        };
                        vectorLayer.addFeatures(featureR);
                        console.log(featureR);
                    });



                    if (txtHTML != null) {
                        map.addLayer(vectorLayer);
                        console.log("agregado...");
                        var selectControl = new OpenLayers.Control.SelectFeature(vectorLayer, {
                            hover: true,
                            toggle: true,
                            selectStyle: {
                                fillOpacity: 0.9,
                                fillColor: "#ffffff",
                                strokeColor: "#ffffff",
                                cursor: "pointer"
                            },
                            callbacks: {
                                click: function (event) {
                                    var color = event.attributes.vESTCWEB;
                                    var punto = new OpenLayers.LonLat(event.attributes.vPOSXGEO, event.attributes.vPOSYGEO);
                                    var xHTML;
                                    xHTML = "<div style='font-size:12px; font-family:Tahoma, Sans-Serif; color:#000000;' >"
                                    xHTML += "<table>";
                                    xHTML += "<tr><td style='font-size:16px;' colspan='2' align='center'>" + event.attributes.vISSI + " [" + event.attributes.vPOSFREG + "]</td></tr>";
                                    xHTML += "<tr><td>Cuadrante </td><td>" + event.attributes.vPOSCDTE + "</td></tr>";
                                    xHTML += "<tr><td>Urbanización </td><td>" + event.attributes.vPOSDENHU + "</td></tr>";
                                    xHTML += "<tr><td>Calle/Via </td><td>" + event.attributes.vPOSNOMVIA + "</td></tr>";
                                    xHTML += "<tr><td>Estado </td><td>" + event.attributes.vESTDESC + "</td></tr>";
                                    xHTML += "<tr><td>Tipo </td><td>" + event.attributes.vDESREC + "</td></tr>";
                                    xHTML += "<tr><td>Observación </td><td>" + event.attributes.vTDESREC + "</td></tr>";
                                    xHTML += "<tr><td>Sector </td><td>" + event.attributes.vDESSEC + "</td></tr>";

                                    xHTML += "</table></div>";

                                    if (infoGPS != null && infoGPS != undefined) {
                                        infoGPS.hide();
                                    }

                                    infoGPS = new OpenLayers.Popup("unidad",
                                                   punto,
                                                   new OpenLayers.Size(300, 160),
                                                   xHTML,
                                                   true);
                                    infoGPS.setBackgroundColor("#E1F5A9");
                                    infoGPS.setBackgroundColor(event.attributes.vESTCWEB);
                                    infoGPS.closeOnMove = true;
                                    map.addPopup(infoGPS);
                                },
                                over: function (event) {
                                }
                            }
                        })
                        map.addControl(selectControl);
                        selectControl.activate();
                    }
                    document.getElementById("divUnidades").innerHTML = "<ul id='ListGPS' class='accordionS'>" + txtHTML + "</ul>";
                },
                error: function (XMLHttpRequest, textStatus, error) { alert('ERROR:' + error); }
            });            //fin llamada ajax
        };

        function posicionGPS(x, y, tISSI, tID) {
            var center = new OpenLayers.LonLat(x, y);
            map.setCenter(center, 8);
        }



    </script>    
    
    <script language="javascript" type="text/javascript">

       function cerrarpagina() {
            window.close();
            return false;
        }


     </script>

    </form>
</body>
</html>
