<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmTrucking.aspx.vb" Inherits="Mapa_frmTrucking" %>

<!DOCTYPE html>
<html>
  <head>
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no">
    <meta charset="utf-8">
    <title>Simple Polylines</title>
    <link href="/maps/documentation/javascript/examples/default.css" rel="stylesheet">
    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false"></script>
    <script>
        function initialize() {
            var myLatLng = new google.maps.LatLng(-12.09898,-76.97233);
            var mapOptions = {
                zoom: 20,
                center: myLatLng,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };

            var map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);

            var flightPlanCoordinates = [
new google.maps.LatLng(-12.09898,-76.97233),
new google.maps.LatLng(-12.10062,-76.97185),
new google.maps.LatLng(-12.10153,-76.97115),
new google.maps.LatLng(-12.09915,-76.97662),
new google.maps.LatLng(-12.09803,-76.97388),
new google.maps.LatLng(-12.09899,-76.97251),
new google.maps.LatLng(-12.10025,-76.97354),
new google.maps.LatLng(-12.09927,-76.97284),
new google.maps.LatLng(-12.09855,-76.97335),
new google.maps.LatLng(-12.09598,-76.97577),
new google.maps.LatLng(-12.09876,-76.97309),
new google.maps.LatLng(-12.09851,-76.97352),
new google.maps.LatLng(-12.09851,-76.97352),
new google.maps.LatLng(-12.09978,-76.97313),
new google.maps.LatLng(-12.10177,-76.97357),
new google.maps.LatLng(-12.10268,-76.97386),
new google.maps.LatLng(-12.10276,-76.97437),
new google.maps.LatLng(-12.10479,-76.97348),
new google.maps.LatLng(-12.10459,-76.97351),
new google.maps.LatLng(-12.10567,-76.97365)
                                 ];
            var flightPath = new google.maps.Polyline({
                path: flightPlanCoordinates,
                strokeColor: '#FF0000',
                strokeOpacity: 1.0,
                strokeWeight: 1
            });

            flightPath.setMap(map);
        }

        google.maps.event.addDomListener(window, 'load', initialize);

    </script>
  </head>
  <body>
      <form id="form2" runat="server">
    <div id="map-canvas" style="width:100%; height:800px;"></div>
    </form>
  </body>