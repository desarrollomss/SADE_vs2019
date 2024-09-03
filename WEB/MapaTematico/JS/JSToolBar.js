
function f_createToolbar() {

    Ext.QuickTips.init();

    /********* Create Toolbar Buttons   *************/
    // Pan Map
    //toolbarItems.push("-");
    action = new GeoExt.Action({
        control: new OpenLayers.Control.Navigation(),
        map: map,
        toggleGroup: "toolGroup",
        allowDepress: false,
        cls: 'x-btn-icon',
        tooltip: '<b>Pan Map</b><br/>Mover el mapa',
        //tooltip: "pan map",
        scale: 'large',
        //cls: 'x-btn-text-icon x-ric-generic',
        iconCls: "panMap"
    });
    actions["nav"] = action;
    toolbarItems.push(action);

    // Vista inicial
    //toolbarItems.push("-");
    action = new GeoExt.Action({
        control: new OpenLayers.Control.ZoomToMaxExtent(),
        map: map,
        scale: 'large',
        cls: 'x-btn-icon',
        tooltip: '<b>Zoom Full</b><br/>Muestra el mapa en su vista inicial',
        iconCls: "zoomfull"
    });
    actions["max_extent"] = action;
    toolbarItems.push(action);

    // Zoom In
    //toolbarItems.push("-");
    action = new GeoExt.Action({
        control: new OpenLayers.Control.ZoomBox(),
        map: map,
        toggleGroup: "toolGroup",
        allowDepress: false,
        scale: 'large',
        cls: 'x-btn-icon',
        tooltip: '<b>Zoom In</b><br/>Acercar la vista del mapa',
        iconCls: "zoomIn"
    });
    actions["zoom_box"] = action;
    toolbarItems.push(action);

    // Zoom Out
    //toolbarItems.push(action);
    action = new GeoExt.Action({
        control: new OpenLayers.Control.ZoomBox({ out: true, displayClass: 'olControlZoomBoxOut' }),
        map: map,
        toggleGroup: "toolGroup",
        allowDepress: false,
        //tooltip: "larger box, less zoom out",
        scale: 'large',
        cls: 'x-btn-icon',
        tooltip: '<b>Zoom Out</b><br/>Alejar la vista del mapa',
        iconCls: "zoomOut"
    });
    actions["zoom_out"] = action;
    toolbarItems.push(action);

    // Measure Distance
    //toolbarItems.push("-");
    action = new GeoExt.Action({
        control: new OpenLayers.Control.Measure(OpenLayers.Handler.Path, {
            eventListeners: {
                measure: function (evt) {
                    Ext.Msg.alert('Información', '\n\nDistancia es :' + evt.measure + " sq " + evt.units + '\n\n');
                }
            }
        }),
        map: map,
        toggleGroup: "toolGroup",
        scale: 'large',
        cls: 'x-btn-icon',
        tooltip: '<b>Distancia</b><br/>Obtener la distancia entre los puntos seleccionados',
        iconCls: "measureDist"
    });
    actions["measure_distance"] = action;
    toolbarItems.push(action);

    // Measure Area
    //toolbarItems.push("-");
    action = new GeoExt.Action({
        control: new OpenLayers.Control.Measure(OpenLayers.Handler.Polygon,
                {
                    displayClass: 'olControlMeasureArea',
                    eventListeners: {
                        measure: function (evt) {
                            Ext.Msg.alert('Información', '\n\nArea es :' + evt.measure + " sq " + evt.units + '\n\n');
                        }
                    }
                }),
        map: map,
        toggleGroup: "toolGroup",
        //tooltip: "measure area",
        scale: 'large',
        cls: 'x-btn-icon',
        tooltip: '<b>Area</b><br/>Obtener el area de un polygono seleccionado',
        iconCls: "measureArea"
    });
    actions["measure_area"] = action;
    toolbarItems.push(action);

    //////google street view
    //////toolbarItems.push("-");
    ////action = new GeoExt.Action({
    ////    control: new OpenLayers.Control.Measure(OpenLayers.Handler.Point,
    ////            {
    ////                displayClass: 'olControlMeasureArea',
    ////                eventListeners: {
    ////                    measure: function (e) {
    ////                        //var lonlat = map.getLonLatFromPixel(e.xy);
    ////                        //var epsgTxt = map.getProjection();
    ////                        var lon = document.getElementById("txtX").value;
    ////                        var lat = document.getElementById("txtY").value;
    ////                        popupMapaGoogle(lon, lat);

    ////                    }
    ////                }
    ////            }),
    ////    map: map,
    ////    toggleGroup: "toolGroup",
    ////    scale: 'large',
    ////    cls: 'x-btn-icon',
    ////    tooltip: '<b>Google Map</b><br/>Muestra cartografia Google y StreetView',
    ////    iconCls: "gsview"
    ////});
    ////actions["gsview"] = action;
    ////toolbarItems.push(action);

    //informacion de Lote
    //toolbarItems.push("-");
    action = new GeoExt.Action({
        control: new OpenLayers.Control.Measure(OpenLayers.Handler.Point,
                {
                    displayClass: 'olControlMeasureArea',
                    eventListeners: {
                        measure: function (e) {
                            //var lonlat = map.getLonLatFromPixel(e.xy);
                            //var epsgTxt = map.getProjection();
                            var lon = document.getElementById("txtX").value;
                            var lat = document.getElementById("txtY").value;
                            muestraLote(lon, lat);

                        }
                    }
                }),
        map: map,
        toggleGroup: "toolGroup",
        cls: 'x-btn-icon',
        scale: 'large',
        cls: 'x-btn-icon',
        tooltip: '<b>Información</b><br/>Muestra información del Lote seleccionado',
        iconCls: "infolote"
    });
    actions["infolote"] = action;
    toolbarItems.push(action);

//    //Exit Action
//    //toolbarItems.push("-");
//    action = new GeoExt.Action({
//        handler: function () {
//            //window.open('frmLoginGIS.aspx');
//            window.location.href = 'LoginSIG.aspx';
//        },
//        map: map,
//        //toggleGroup: "toolGroup",
//        scale: 'large',
//        cls: 'x-btn-icon',
//        tooltip: '<b>Salir</b><br/>Salir del GIS',
//        iconCls: "salida"
//    });

//    actions["help"] = action;
//    toolbarItems.push(action);

}



