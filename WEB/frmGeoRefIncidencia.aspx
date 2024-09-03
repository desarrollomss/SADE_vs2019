<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmGeoRefIncidencia.aspx.vb" Inherits="frmGeoRefIncidencia" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">


<head runat="server">
    <script type="text/javascript">

        function muestraCalle() {
            console.log("prueba de entra");
            document.getElementById('divCalles').style.display = 'block';
            document.getElementById('fade').style.display = 'block';
        }
</script>

    <link href="Styles/accordionmenu.css" rel="stylesheet" type="text/css" />
	<link rel="stylesheet" href="css/themes/base/jquery.ui.all.css"/>
    <script src="js/jquery.js" type="text/javascript"></script>
	<script src="js/jquery-1.9.1.js" type="text/javascript"></script>
	<script src="js/ui/jquery.ui.core.js" type="text/javascript"></script>
	<script src="js/ui/jquery.ui.widget.js" type="text/javascript"></script>
	<script src="js/ui/jquery.ui.accordion.js" type="text/javascript"></script>
	<link rel="stylesheet" href="css/demos.css"/>
	<link rel="stylesheet" href="css/master.css"/>
    <link href="css/boton.css" rel="stylesheet" type="text/css" />
    <link href="css/calendario.css" rel="stylesheet" type="text/css" />
    <link href="css/grid2.css" rel="stylesheet" type="text/css" />
    <link href="css/controles.css" rel="stylesheet" type="text/css" />
    <script src="js/Popup.js" type="text/javascript"></script>
    <script src="sidr/js/jquery.sidr.min.js" type="text/javascript"></script>
    <link href="sidr/css/jquery.sidr.dark.css" rel="stylesheet" type="text/css" />
   <style type="text/css">    
	    .black_overlay{
		    display:none;
		    position: absolute;
		    top: 0%;
		    left: 0%;
		    width: 100%;
		    height: 100%;
		    background-color:black;
		    z-index:1001;
		    -moz-opacity: 0.7;
		    opacity:.70;
		    filter: alpha(opacity=70);
	    }
        	    
	    .white_content {
		    display:none;
		    position: absolute;
		    top: 15%;
		    left: 25%;
		    width: 50%;
    		
		    padding: 0px;
		    border: 0px solid #a6c25c;
		    background-color: white;
		    z-index:1002;
		    overflow: auto;
	    }	
    
        #pnlBusqueda
        {
         width : 100%;
         margin-top :0px;
        }        
        
        .Flotante
        {
	        position: absolute;
	        top: 25px;
	        left: 37px;
        }        
        
        div#map {
         position: relative;
          width:100%;  
          height:550px;
          margin-top: 0px;
          margin-bottom:0px;
          border-top: 1px solid #333;
          border-bottom: 2px solid #333;
        }


        </style>  

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <%--<script type="text/javascript" src="http://openlayers.org/api/OpenLayers.js"></script>--%>
    <script src="MapaTematico/OpenLayers-2.13.1/OpenLayers.js" type="text/javascript"></script>

    <asp:Panel ID="pnlEdicion" runat="server" Width="100%">
        <table width="100%" cellpadding="0px" cellspacing="0px">
            <colgroup>
                <col width="1%" />
                <col width="90%" />
                <col width="1%" />
            </colgroup>
            <tr>
                <td>&nbsp;</td>
                <td align="center">
                    <asp:TextBox ID="txtNumeroIncEdi" runat="server" 
                        CssClass="CajaTextoOff" MaxLength="15" Enabled="False"></asp:TextBox> / 
                    <asp:TextBox ID="txtFechaIncEdi" runat="server" CssClass="CajaTextoOff" 
                        Enabled="False"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                </td>
                <td>                    
                    <div id="divMap" style="width: 800px; height: 400px; border: 1px solid #ccc;">
                    </div>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <div id="div1" style="width: 800px; border: 1px solid #ccc;">
                        <table class="Tabla" style="width: 100%">
                            <colgroup>
                                <col style="width: 5%" />
                                <col style="width: 9%" />
                                <col style="width: 9%" />
                                <col style="width: 9%" />
                                <col style="width: 9%" />
                                <col style="width: 9%" />
                                <col style="width: 9%" />
                                <col style="width: 9%" />
                                <col style="width: 9%" />
                                <col style="width: 9%" />
                                <col style="width: 13%" />
                                <col style="width: 1%" />
                            </colgroup>
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    Calle/Via
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtCalleIncEdi" runat="server" CssClass="CajaTextoObligatorio" MaxLength="150"
                                        Width="75%"></asp:TextBox>
                                    <input id="busCalle" type="button" value="..." onclick="muestraCalle()" />
                                </td>
                                <td>
                                    Cdra.<asp:TextBox ID="txtCdraIncEdi" runat="server" placeholder="Cda."
                                        CssClass="CajaTextoObligatorio" MaxLength="10" Width="30%"></asp:TextBox>
                                </td>
                                <td>No.<asp:TextBox ID="txtNroIncEdi" runat="server"  placeholder="Nro."
                                        CssClass="CajaTextoObligatorio" MaxLength="10" Width="50%"></asp:TextBox>
                                </td>
                                <td>Dpto</td>
                                <td>
                                    <asp:TextBox ID="txtDptoIncEdi" runat="server" CssClass="CajaTextoObligatorio" placeholder="Departamento"
                                        MaxLength="10" Width="75%"></asp:TextBox>
                                </td>
                                <td>
                                    Mza./Lote</td>
                                <td>
                                    <asp:TextBox ID="txtMzaIncEdi" runat="server" CssClass="CajaTextoObligatorio" placeholder="Mza."
                                        MaxLength="10" Width="40%"></asp:TextBox>
                                    <asp:TextBox ID="txtLteIncEdi" runat="server" CssClass="CajaTextoObligatorio" placeholder="Lote"
                                        MaxLength="10" Width="40%"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    Habilitacion </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtUrbIncEdi" runat="server" CssClass="CajaTextoObligatorio" 
                                        MaxLength="100" placeholder="Urbanizacion" Width="90%"></asp:TextBox>
                                </td>
                                <td>
                                    Referencia </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtComIncEdi" runat="server" CssClass="CajaTextoObligatorio" 
                                        MaxLength="200" placeholder="Referencia" Width="90%"></asp:TextBox>
                                </td>
                                <td>
                                    Sec./Cdte.</td>
                                <td>
                                    <asp:TextBox ID="txtSectorIncEdi" runat="server" 
                                        CssClass="CajaTextoObligatorio" Enabled="False" MaxLength="15" 
                                        placeholder="Sector" Width="40%"></asp:TextBox>
                                    <asp:TextBox ID="txtCuadranteIncEdi" runat="server" 
                                        CssClass="CajaTextoObligatorio" Enabled="False" MaxLength="15" 
                                        placeholder="Cuadrante" Width="40%"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td colspan="3">
                                    &nbsp;</td>
                                <td>&nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>&nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td colspan="8" align="center">
                                    <asp:Button ID="btnGrabar" runat="server" CssClass="boton_agregar" 
                                        OnClientClick="{ cambiarvalor();  javascript:return confirm('¿ESTA SEGURO DE REALIZAR LA OPERACION?','SADE');}" 
                                        Text=" Grabar " />
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td colspan="10" align="center">
                                    <asp:Label ID="lblMensajeReg" runat="server" ForeColor="#CC0000" Text=""></asp:Label>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="hdTipoAccion" runat="server" />
    <asp:HiddenField ID="hfGeoY" runat="server" />
    <asp:HiddenField ID="hfGeoX" runat="server" />
    <asp:HiddenField ID="hfCodViaIncEdi" runat="server" />
    <asp:HiddenField ID="hfCodHabUrbEdi" runat="server" />

    <div id="divCalles" style="height: 350px; border: 1px solid #ccc; z-index:9000;" class="white_content">
        <a href="javascript:void(0)" onclick="document.getElementById('divCalles').style.display='none';document.getElementById('fade').style.display='none'">
            <img src="img/Close.gif" style="border: 0px" align="right" /></a>
        <div id="divFilterCalles">
            <table id="tbFiltrarCalle" style="width: 95%; padding-top: 10px; padding-bottom: 10px;
                font-size: 12px; font-family: Tahoma" width="100%" cellpadding="10" cellspacing="10"
                border="0">
                <colgroup>
                    <col width="20%" />
                    <col width="80%" />
                </colgroup>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        Calle / Via
                    </td>
                    <td>
                        <input type="text" onkeyup="{ this.value=this.value.toUpperCase(); filterCalle(this); } "
                            style="width: 90%" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
        <div id="divDataCalles" style="height: 300px; border: 1px solid #ccc; overflow: scroll;">
        </div>
    </div>

    <div id="fade" class="black_overlay">
    </div>

</asp:Panel>

<script type="text/javascript">
    var coorX = '<%= hfGeoX.ClientID %>';
    var coorY = '<%= hfGeoY.ClientID %>';
    var nomVia = '<%= txtCalleIncEdi.ClientID %>';
    var codVia = '<%= hfCodViaIncEdi.ClientID %>';
    var numCdra = '<%= txtCdraIncEdi.ClientID %>';
    var denHU = '<%= txtUrbIncEdi.ClientID %>';
    var codHU = '<%= hfCodHabUrbEdi.ClientID %>';
    var codSEC = '<%= txtSectorIncEdi.ClientID %>';
    var codCTE = '<%= txtCuadranteIncEdi.ClientID %>';

    var map;
    var markers;
    var vSelecc = null;
    var vecLayerCS;
    var matrizCalles = [];
    var matrizPersona = [];

    OpenLayers.IMAGE_RELOAD_ATTEMPTS = 5;
    OpenLayers.Util.onImageLoadErrorColor = "transparent";
    OpenLayers.Tile.Image.useBlankTile = true;
    OpenLayers.DOTS_PER_INCH = 90.71428571428572;

    initMAP();

    function initMAP() {

        var vSERVER = "http://192.0.0.130:70/geoserver/CM150140/wms";
        var vFOTOS = "http://192.0.0.130:70/multimedia/fotos/catastro/2012/";

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

        var hurb = new OpenLayers.Layer.WMS("Limite Habilitacion Urbana", vSERVER,
                                    {
                                        srs: 'EPSG:32718',
                                        layers: 'CM150140:CM150140_hurbana',
                                        transparent: true
                                    }, { isBaseLayer: false, visibility: false }
                                    );
        var zona = new OpenLayers.Layer.WMS("Limite Sectores Catastrales", vSERVER,
                                    {
                                        srs: 'EPSG:32718',
                                        layers: 'map_sector',
                                        transparent: true
                                    }, { isBaseLayer: false, visibility: false }
                                    );
        var sc = new OpenLayers.Layer.WMS("Limite Cuadrantes", vSERVER,
                                    {
                                        srs: 'EPSG:32718',
                                        layers: 'map_cuadrante',
                                        transparent: true
                                    }, { isBaseLayer: false, visibility: false }
                                    );
        var semaforo = new OpenLayers.Layer.WMS("Semaforos", vSERVER,
                                    {
                                        srs: 'EPSG:32718',
                                        layers: 'map_compseg_semaforos',
                                        transparent: true
                                    }, { isBaseLayer: false, visibility: false }
                                    );
        var modulo = new OpenLayers.Layer.WMS("Modulos", vSERVER,
                                    {
                                        srs: 'EPSG:32718',
                                        layers: 'map_compseg_modulos_v2',
                                        transparent: true
                                    }, { isBaseLayer: false, visibility: false }
                                    );
        var locales = new OpenLayers.Layer.WMS("Locales", vSERVER,
                                    {
                                        srs: 'EPSG:32718',
                                        layers: 'map_compseg_locales_v2',
                                        transparent: true
                                    }, { isBaseLayer: false, visibility: false }
                                    );
        var camara = new OpenLayers.Layer.WMS("Camaras", vSERVER,
                                    {
                                        srs: 'EPSG:32718',
                                        layers: 'map_compseg_camaras_v2',
                                        transparent: true
                                    }, { isBaseLayer: false, visibility: false }
                                    );



        map = new OpenLayers.Map({
            div: "divMap",
            layers: [wms, lote, clote, hurb, zona, sc, semaforo, modulo, locales, camara],
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
                        new OpenLayers.Control.OverviewMap(),
                        new OpenLayers.Control.KeyboardDefaults()
                      ],
            center: [283430.991, 8657254.839]
        });

        mostrarGeoCallejero();

        vSelecc = new OpenLayers.Layer.Vector("Objeto Seleccionado", { 'displayInLayerSwitcher': false, noLegend: true });
        vecLayerCS = new OpenLayers.Layer.Vector("Componentes Seguridad");

        map.addControl(new OpenLayers.Control.LayerSwitcher());
        if (!map.getCenter()) {
            map.zoomToMaxExtent();
        }

        var click = new OpenLayers.Control.Click();
        map.addControl(click);
        click.activate();
        console.log(map);

        if (vPtoX != "" || vPtoY != "") {
            console.log("prueba de ubicacion");
            var center = new OpenLayers.LonLat(vPtoX, vPtoY);
            //MapCalle(vPtoX, vPtoY);
            MapMarker(vPtoX, vPtoY);
            muestraUbicacion(vPtoX, vPtoY)
            map.setCenter(center, 8);
        }

    }







    function mostrarGeoCallejero() {
        var webMethod = "WebServiceGEO.asmx/buscarCalle";
        //var matrizCalles = [];
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
                    matrizCalles[i] = new Array(6);
                    matrizCalles[i][0] = pan.idvia;
                    matrizCalles[i][1] = pan.codvia;
                    matrizCalles[i][2] = pan.nomvia;
                    matrizCalles[i][3] = pan.nrocdra;
                    matrizCalles[i][4] = pan.xGeo;
                    matrizCalles[i][5] = pan.yGeo;
                    matrizCalles[i][6] = pan.Geom;
                    txtHTML += "<li><a href='javascript:MapCalle(" + pan.xGeo + "," + pan.yGeo + "," + i + ");'>";
                    txtHTML += "" + pan.codvia + " " + pan.nomvia + " " + pan.nrocdra + "</a></li>";
                    i++;
                });

                if (txtHTML != null) {
                }
                document.getElementById("divDataCalles").innerHTML = "<ul id='ListCalle' class='accordionS'>" + txtHTML + "</ul>";
            },
            error: function (XMLHttpRequest, textStatus, error) { console.log(textStatus); alert('ERROR:' + error); }
        });        //fin llamada ajax
    }

    function MapCalle(x, y, i) {
        var center = new OpenLayers.LonLat(x, y);

        document.getElementById(codVia).value = matrizCalles[i][1];
        document.getElementById(nomVia).value = matrizCalles[i][2];
        document.getElementById(numCdra).value = matrizCalles[i][3];

        document.getElementById('divCalles').style.display = 'none';
        document.getElementById('fade').style.display = 'none';
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

            },
            error: function (XMLHttpRequest, textStatus, error) { alert('ERROR:' + error); }
        });         //fin llamada ajax

    }


</script>


    </form>
</body>
</html>
