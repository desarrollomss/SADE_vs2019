<%@ Page Language="VB" AutoEventWireup="false" CodeFile="geolocalRegistro.aspx.vb" Inherits="geolocalRegistro" %>

<!doctype html>
<html lang="en">
<head>
	<title></title>


    <meta name="viewport" content="width=device-width,user-scalable=no"/>
	<link rel="stylesheet" href="http://code.jquery.com/mobile/1.2.0/jquery.mobile-1.2.0.min.css" />
	<script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.min.js"></script>
	<script type="text/javascript" src="http://code.jquery.com/mobile/1.2.0/jquery.mobile-1.2.0.min.js"></script>

    <link href="Mapa/css/mapa.css" rel="stylesheet">
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false&libraries=places"></script>
    <script type="text/javascript" src="Mapa/markermanager.js"></script>
    <script type="text/javascript" src="Mapa/jquery-1.4.1.min.js" ></script>

    <style type="text/css">
        
      input {
        border: 1px solid  rgba(0, 0, 0, 0.5);
      }
      
      input.notfound {
        border: 2px solid  rgba(255, 0, 0, 0.4);
      }
              
      #directions-panel {
        height: 100%;
        float: right;
        width: 390px;
        overflow: auto;
      }


      #control {
        background: #fff;
        padding: 5px ;
        font-size: 14px;
        font-family: Arial;
        border: 1px solid #ccc;
        display: none;
      }

      #recurso {
        background: #fff;
        padding: 5px;
        font-size: 10px;
        font-family: Arial;
        border: 1px solid #ccc;
        width:400px;
        height:100px;
        overflow: auto;
      }

      @media print {
        #map-canvas {
          height: 600px;
          margin: 0;
        }

        #directions-panel {
          float: none;
          width: auto;
        }
      }


    </style>

    </head>
<body>
    <form id="form2" runat="server">


    <div data-role="page" id="inicio">
        <div data-role="header">
            <h1>Municipalidad de Santiago de Surco</h1>
        </div>
        <div data-role="content">
            <div id="map-canvas" style="width:100%; height:800px;">
            </div>
        </div>
        <div data-role="footer">
            <h3>Sistema de Atención de Denuncias y Emergencias</h3>
        </div>

    </div>

    <div id="control"  class="alpha">
        Layer:
        <select id="SelVista" onchange="changeVista(this.value);">
            <option value="">--Ninguno--</option>
            <option value="laySEC">Sectores</option>
            <option value="layCUA">Cuadrantes</option>
        </select>
        Sector:
        <select id="SelSector" onchange="buscaSector(this.value);">
            <option value="">--Ninguno--</option>
            <option value="01">01</option>
            <option value="02">02</option>
            <option value="03">03</option>
            <option value="04">04</option>
            <option value="05">05</option>
            <option value="06">06</option>
            <option value="07">07</option>
            <option value="08">08</option>
            <option value="09">09</option>
        </select>
        Buscar:
        <input id="searchTextField" type="text" size="50">
    </div>
    <br />
    <div id="status">
    </div>
    <br />
    <asp:HiddenField ID="hdfM" runat="server" />
    <asp:HiddenField ID="hdfLat" runat="server" />
    <asp:HiddenField ID="hdfLon" runat="server" />
    </form>
    <script type="text/javascript">
        // configuration
        var myZoom = 12;
        var myMarkerIsDraggable = true;
        var myCoordsLenght = 6;
        var defaultLat = document.getElementById('hdfLat').value;
        var defaultLng = document.getElementById('hdfLon').value;
        var myHOME = new google.maps.LatLng(defaultLat, defaultLng)
        var surcoHOME = new google.maps.LatLng(defaultLat, defaultLng)
        var input = /** @type {HTMLInputElement} */(document.getElementById('searchTextField'));
        var autocomplete = new google.maps.places.Autocomplete(input);

        var curr_infw; // We create a variable where we can store the most recently opened info window

        var layerSec;

        var layerS;
        var tableidS = '1ViElVltucTVD5EgQ1G2vy3372kXypQGvXMv-KtQ';

        var layerC;
        var tableidC = '1L7i2TYkcEnSwbdzxdYBpHt0K0IpJMjXHfVeilQc';

        var mgr;
        var markers = [];
        var imagesM = ["01.png", "02.png", "03.png", "04.png", "05.png", "06.png", "07.png", "08.png", "09.png", "10.png"];

        // creates the map
        // zooms
        // centers the map
        // sets the map's type 
        var map = new google.maps.Map(document.getElementById('map-canvas'), {
            zoom: myZoom,
            center: new google.maps.LatLng(defaultLat, defaultLng),
            mapTypeId: google.maps.MapTypeId.ROADMAP,
            mapTypeControl: true,
            mapTypeControlOptions: {
                style: google.maps.MapTypeControlStyle.HORIZONTAL_BAR,
                position: google.maps.ControlPosition.TOP_RIGHT
            },
            panControl: true,
            panControlOptions: {
                position: google.maps.ControlPosition.RIGHT_TOP
            },
            zoomControl: true,
            zoomControlOptions: {
                style: google.maps.ZoomControlStyle.DROPDOWN_MENU,
                position: google.maps.ControlPosition.RIGHT_TOP
            },
            scaleControl: false,
            scaleControlOptions: {
                position: google.maps.ControlPosition.TOP_LEFT
            },
            streetViewControl: false,
            streetViewControlOptions: {
                position: google.maps.ControlPosition.LEFT_TOP
            }

        });

//        var cityCircle;
//        var populationOptions = {
//            strokeColor: '#FF0000',
//            strokeOpacity: 0.20,
//            strokeWeight: 2,
//            fillColor: '#FF0000',
//            fillOpacity: 0.10,
//            map: map,
//            center: myHOME,
//            radius: 250
//        };
//        cityCircle = new google.maps.Circle(populationOptions);


        marker = new google.maps.Marker({
            map: map,
            draggable: true,
            animation: google.maps.Animation.BOUNCE,
            position: myHOME,
        });


        mgr = new MarkerManager(map);

        layerS = new google.maps.FusionTablesLayer({
            query: { select: 'geometry', from: '1ViElVltucTVD5EgQ1G2vy3372kXypQGvXMv-KtQ' },
            styles: [{ polygonOptions: { fillColor: '#5E5E5E', fillOpacity: 0.03}}]
        });

        layerC = new google.maps.FusionTablesLayer({
            query: { select: 'geometry', from: '1L7i2TYkcEnSwbdzxdYBpHt0K0IpJMjXHfVeilQc' },
            styles: [{ polygonOptions: { fillColor: '#5E5E5E', fillOpacity: 0.05}}]
        });

        autocomplete.bindTo('bounds', map);


        var infowindow = new google.maps.InfoWindow();
        var marker = new google.maps.Marker({
            map: map
        });

        google.maps.event.addListener(autocomplete, 'place_changed', function () {
            infowindow.close();
            marker.setVisible(false);
            input.className = '';
            var place = autocomplete.getPlace();
            if (!place.geometry) {
                // Inform the user that the place was not found and return.
                input.className = 'notfound';
                return;
            }

            // If the place has a geometry, then present it on a map.
            if (place.geometry.viewport) {
                map.fitBounds(place.geometry.viewport);
            } else {
                map.setCenter(place.geometry.location);
                map.setZoom(14);  // Why 17? Because it looks good.
            }
            marker.setIcon(/** @type {google.maps.Icon} */({
                url: place.icon,
                size: new google.maps.Size(71, 71),
                origin: new google.maps.Point(0, 0),
                anchor: new google.maps.Point(17, 34),
                scaledSize: new google.maps.Size(35, 35)
            }));
            marker.setPosition(place.geometry.location);
            marker.setVisible(true);

            var address = '';
            if (place.address_components) {
                address = [
        (place.address_components[0] && place.address_components[0].short_name || ''),
        (place.address_components[1] && place.address_components[1].short_name || ''),
        (place.address_components[2] && place.address_components[2].short_name || '')
      ].join(' ');
            }

            infowindow.setContent('<div><strong>' + place.name + '</strong><br>' + address);
            infowindow.open(map, marker);
        });





        //        var controlr = document.getElementById('recurso');
        //        controlr.style.display = 'block';
        //        map.controls[google.maps.ControlPosition.BOTTOM_LEFT].push(controlr);



        var control = document.getElementById('control');
        control.style.display = 'block';
        map.controls[google.maps.ControlPosition.TOP_CENTER].push(control);

        var modoControlDiv = document.createElement('DIV');
        var modoControl = new ModoControl(modoControlDiv, map, document.getElementById('hdfM').value);
        modoControlDiv.index = 1;
        map.controls[google.maps.ControlPosition.TOP_LEFT].push(modoControlDiv);

        google.maps.event.addDomListener(modoControlDiv, 'click', function () {
            map.setZoom(myZoom);
            map.setCenter(surcoHOME);
        });


        google.maps.event.addListener(map, 'zoom_changed', function () {
            //loadPosition(); 
        });


        //*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        // Codigo JS manejo de Google Maps para CCO Seguridad Ciudadana
        //*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        //*
        //*
        //*
        //-------------------------------------------------
        //  Carga posicion actual de AVL CCO via WebService
        //-------------------------------------------------
        function callRefresh() {
            loadPosition();
            setTimeout(callRefresh, 6000);
        }


        function changeZoom(zoomId) {
            if (zoomId) {
                map.setZoom(parseInt(zoomId));
            }
            else {
                map.setZoom(myZoom);
            }


        }

        //-------------------------------------------------
        //  Carga posicion actual de AVL CCO via WebService
        //-------------------------------------------------
        function loadPosition() {
            limpiar()
            markers = [];
            var izoom = map.getZoom();
            //var sel = document.getElementById("zoomAVL");
            //sel.options.length = 0;
            $('#zoomAVL option').remove()
            if (izoom >= 1 && izoom <= 10) {
                imagesM = ["cco.png", "cco.png", "cco.png", "cco.png", "cco.png", "cco.png", "cco.png", "cco.png", "cco.png", "cco.png"];
            }
            if (izoom >= 11 && izoom <= 14) {
                imagesM = ["01.png", "02.png", "03.png", "04.png", "05.png", "06.png", "07.png", "08.png", "09.png", "10.png"];
            }
            if (izoom >= 15 && izoom <= 16) {
                imagesM = ["001.png", "002.png", "003.png", "004.png", "005.png", "006.png", "007.png", "008.png", "009.png", "010.png"];
            }
            if (izoom >= 17 && izoom <= 20) {
                imagesM = ["0001.png", "0002.png", "0003.png", "0004.png", "0005.png", "0006.png", "0007.png", "0008.png", "0009.png", "0010.png"];
            }

            mgr = new MarkerManager(map);
            var webMethod = "WebServiceGPS.asmx/GetPosition";
            $.ajax({ type: "POST",
                url: webMethod,
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var lista = response.d;

                    $.each(lista, function (index, pan) {
                        var punto = new google.maps.LatLng(pan.PropLATITUDE, pan.PropLONGITUDE);
                        var htmlVentana = pan.PropDESCRIPTION;
                        var label = "" + pan.PropNISSI + "";
                        var img = "Mapa/tools/" + imagesM[parseInt(pan.PropUNITTYPE)];

                        marker = new google.maps.Marker({
                            map: map,
                            flat: true,
                            clickable: true,
                            position: punto,
                            icon: img,
                            title: label,
                            click: function (e) { alert("ALERTA DE MARKER"); }
                        });

                        markers.push(marker);

                        var infowindow = new google.maps.InfoWindow({
                            content: label
                        });
                        google.maps.event.addListener(marker, 'click', function () {
                            if (curr_infw) { curr_infw.close(); } // We check to see if there is an info window stored in curr_infw, if there is, we use .close() to hide the window
                            curr_infw = infowindow; // Now we put our new info window in to the curr_infw variable
                            infowindow.open(map, marker); // Now we open the window
                        });

                        //sel.options.add(new Option(label, label));
                        //$('#zoomAVL').append('<option value="' + label + '">' + label + '</option>');

//                        $('#zoomAVL').append($("<option></option>")
//                        .attr("value", label)
//                        .text(label));
                    });
                    mgr.addMarkers(markers, 10, 18);
                    mgr.refresh();
                    updateStatus(mgr.getMarkerCount(map.getZoom()));

                },
                error: function (XMLHttpRequest, textStatus, error) { alert('ERROR:' + error); }
            });      //fin llamada ajax

        }

        //-------------------------------------------------
        //  Activa un LAYER basado en FUSION TABLES
        //-------------------------------------------------
        function changeVista(tableId) {
            // Libera todos los LAYERS
            if (layerS) { layerS.setMap(null); }
            if (layerC) { layerC.setMap(null); }
            if (layerSec) { layerSec.setMap(null); }

            switch (tableId) {
                case 'laySEC':
                    layerS.setMap(map);
                    break;
                case 'layCUA':
                    layerC.setMap(map);
                    break;
                case 'layLOT':
                    layerL.setMap(map);
                    break;
                default:
                    {
                        if (layerS) { layerS.setMap(null); }
                        if (layerC) { layerC.setMap(null); }
                        if (layerSec) { layerSec.setMap(null); }
                    }
            }
        }

        //-------------------------------------------------
        //  Activa un LAYER basado en FUSION TABLES
        //-------------------------------------------------
        function buscaSector(sectorId) {
            // Libera todos los LAYERS
            if (layerS) { layerS.setMap(null); }
            if (layerC) { layerC.setMap(null); }
            if (layerSec) { layerSec.setMap(null); }
            var whr;
            if (sectorId == "") {
                whr = "name = 00";
            }
            else {
                whr = "name = " + sectorId;
            }


            layerSec = new google.maps.FusionTablesLayer({
                query: {
                    select: 'geometry',
                    from: '1ViElVltucTVD5EgQ1G2vy3372kXypQGvXMv-KtQ',
                    where: whr
                },
                styles: [{
                    polygonOptions: {
                        fillColor: '#FF0000',
                        fillOpacity: 0.3
                    }
                }]
            });
            layerSec.setMap(map);
        }

        //*********************************************************************//

        function showMarkers() {
            mgr.show();
            updateStatus(mgr.getMarkerCount(map.getZoom()));
        }

        function hideMarkers() {
            mgr.hide();
            updateStatus(mgr.getMarkerCount(map.getZoom()));
        }

        function clearMarkers() {
            mgr.clearMarkers();
            updateStatus(mgr.getMarkerCount(map.getZoom()));
        }

        function reloadMarkers() {
            setupOfficeMarkers();
        }

        function updateStatus(html) {
            document.getElementById("status").innerHTML = html;
        }

        //*********************************************************************//

        function limpiar() {
            if (markers) {
                for (var i = 0; i < markers.length; i++) {
                    markers[i].setPosition(null);
                }
                markers = 0;
            }
        }


        function ModoControl(controlDiv, map, modo) {
            controlDiv.style.padding = '5px';
            var controlUI = document.createElement('img');
            controlUI.id = 'btnModo';
            controlUI.className = 'noprint';
            controlUI.setAttribute('src', 'Mapa/tools/logocco.png');
            controlUI.style.borderColor = '#FFFFFF';
            controlUI.style.borderStyle = 'solid';
            controlUI.style.borderWidth = '1px';
            controlUI.title = 'CCO';
            controlDiv.appendChild(controlUI);
        }

        callRefresh();


    </script>
</body>
</html>