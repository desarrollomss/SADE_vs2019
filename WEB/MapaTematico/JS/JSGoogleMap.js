

function popupMapaGoogle(vLat, vLng) {

    var txtHTML = "";
    var tabla = "";
    archivoValidacion = "../WebServiceGEO.asmx/convierteXY?jsoncallback=?"

    Ext.MessageBox.show({
        title: '...Procesando',
        //msg: '... Procesando consulta, Espere...',
        progressText: 'Saving...',
        width: 300,
        wait: true,
        waitConfig: { interval: 150 }
    });

    $.getJSON(archivoValidacion, { pX: vLat, pY: vLng })
	    .done(function (rptaServer) {
	        console.log(rptaServer);


	        //if (!mapwin) {

	        var Tmapwin = new Ext.Window({
	            layout: 'fit',
	            title: 'Google Map / Map Window',
	            closeAction: 'close',
	            plain: false,
	            width: 900,
	            height: 600,
	            modal: true,
	            items: {
	                xtype: 'gmappanel',
	                zoomLevel: 16,
	                gmapType: 'map',
	                mapConfOpts: ['enableScrollWheelZoom', 'enableDoubleClickZoom', 'enableDragging'],
	                mapControls: ['GSmallMapControl', 'GMapTypeControl', 'NonExistantControl'],
	                setCenter: { lat: rptaServer[0]._ygeo,
	                    lng: rptaServer[0]._xgeo
	                }
	            }
	        });

	        //}

	        Tmapwin.show();



	    })
        .always(function () {
            console.log("complete");
            Ext.MessageBox.hide();

        })
        .fail(function (jqxhr, textStatus, error) {
            var err = textStatus + ", " + error;
            console.log("Request Failed: " + err);
        });               // FIN DE LLAMADA

}
