
function muestraLote(xGeo, yGeo) {

    if (map.zoom < 7) {
        Ext.Msg.alert('Información', '\n\nEscala del Mapa no permite visualizar\n\n');
    }
    else {
        //__pmdl_west.items.get(4).expand();
        //Ext.getCmp('lDatos').expand(true);
        console.log(xGeo);
        console.log(yGeo);
        var txtHTML;
        var txtPLANO;
        txtHTML = "<img id='imgprev' src='img/nodisponible.gif' border='1' height='240' width='360'/>";

        var lblLote;
        var lblPlano;
        var webMethod = "../WebServiceGEO.asmx/buscaLoteXY";
        $.ajax({
            type: "POST",
            url: webMethod,
            data: "{'pX':'" + xGeo + "','pY':'" + yGeo + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var lista = response.d;
                var polygon;
                $.each(lista, function (index, pan) {
                    lblLote = pan.codLote;
                    lblPlano = "http://192.0.0.130:70/map/maps/FLoteCatastralPlano.php?codcat=" + pan.codLote + "&corx=" + pan.xGeo + "&cory=" + pan.yGeo + "&ext=" + pan.Extend ;
                    txtHTML = "<img id='imgprev' src='" + pan.codFoto + "' border='1' height='280' width='360' onerror=this.src='../img/nodisponible.gif'; />";
                    txtPLANO = "<img id='imgplano' src='" + lblPlano + "' border='1' height='280' width='360' onerror=this.src='../img/nodisponible.gif'; href='" + lblPlano + "' />";
                    console.log(pan.Pol);
                    console.log(pan.codLote);
                    console.log(pan.codFoto);
                    //f_createVSelectPOLY(pan.Poly);
                });

                if (txtHTML != null) {
                    document.getElementById("divFoto").innerHTML = txtHTML;
                    document.getElementById("divPlano").innerHTML = txtPLANO;
                    
                    document.getElementById("divTab01").innerHTML = "";
                    document.getElementById("divTab02").innerHTML = "";
                    document.getElementById("divTab03").innerHTML = "";
                    document.getElementById("divTab04").innerHTML = "";
                    LoteJSON(lblLote);
                }
            },
            error: function (XMLHttpRequest, textStatus, error) { alert('ERROR:' + error); }
        });        //fin llamada ajax
    }   // fin de else
}

// prueba de Grid

function LoteJSON(pCodLote) {
    var txtHTML = "";
    var tabla = "";
    archivoValidacion = "../WebServiceGEO.asmx/LoteDetalleGIS?jsoncallback=?"

    Ext.MessageBox.show({
        title: '...Procesando',
        //msg: '... Procesando consulta, Espere...',
        progressText: 'Saving...',
        width: 300,
        
        wait: true,
        waitConfig: { interval: 50 }
    });

    //        archivoValidacion = "WebServiceSIG.asmx/listarLoteLicencia?jsoncallback=?"
    $.getJSON(archivoValidacion, { pCODLOTE: pCodLote })

	    .done(function (rptaServer) {

	        console.log(rptaServer);

	        var Grid1Store = new Ext.data.JsonStore({
	            root: 'Table',
	            fields: ['VCHCODCAT', 'INTADMCODIGO', 'VCHADMCOMPLETO', 'VCHUBICACION', 'CHRFICTIPO', 'TIPOFICHA', 'INTFICCODIGO', 'INTUCATID', 'CHRUSOCODIGO', 'VCHINDIVUSODESC'],
	            //autoLoad: true,
	            data: rptaServer
	        });

	        var Grid2Store = new Ext.data.JsonStore({
	            root: 'Table1',
	            fields: ['SMLANOANIOPRO', 'INTDJUNUMDDJJ', 'INTPRECODIGO', 'VCHPREDIRECCION', 'INTADMCODIGO', 'VCHADMCOMPLETO', 'VCHUSOCODIGO', 'VCHCOPDESCRI', 'DECPREPORCOPROP', 'VCHCODCAT', 'VCHCODLOTEPRT', 'VCHUSODESCRI'],
	            //autoLoad: true,
	            data: rptaServer
	        });

	        var Grid3Store = new Ext.data.JsonStore({
	            root: 'Table2',
	            fields: ['VCHLICNUMERO', 'VCHLICDEFCIVIL', 'DATLICFECCERDF', 'VCHSOLNUMERO', 'CHRSOLANIO', 'INTPRECODIGO', 'VCHSOLNOMBRECOMER', 'VCHSOLNOMBRESOL', 'VCHTAUTDESCRIPCION', 'VCHUURDIRECCION', 'CHRUBILOCCODCAT', 'VCHZONACOD', 'INTGIRCODIGO', 'VCHGIRDESCRIPCION', 'SMLSGIPRINCIPAL'],
	            //autoLoad: true,
	            data: rptaServer
	        });

	        var Grid4Store = new Ext.data.JsonStore({
	            root: 'Table4',
	            fields: ['TKEY', 'TVALUE'],
	            //autoLoad: true,
	            data: rptaServer
	        });

//	        console.log(Grid4Store);
                         
	        // create the grid
	        grid1 = new Ext.grid.GridPanel({
	            store: Grid1Store,
	            width: 780,
	            columns: [
                           {
                               xtype: 'actioncolumn',
                               width: 30,
                               items: [{
                                   icon: '../img/info.png',  // Use a URL in the icon config
                                   tooltip: 'Informacion',
                                   handler: function (grid, rowIndex, colIndex) {
                                       var rec = grid.getStore().getAt(rowIndex);
                                       popupSIRCAT(rec.get('INTFICCODIGO'), rec.get('VCHCODCAT'), rec.get('CHRFICTIPO'));
                                   }
                               }]
                           },
                            { header: 'C.Catastral  ', width: 120, dataIndex: 'VCHCODCAT', sortable: true },
                            { header: 'Codigo       ', width: 060, dataIndex: 'INTADMCODIGO', sortable: true },
                            { header: 'Administrado ', width: 250, dataIndex: 'VCHADMCOMPLETO', sortable: true },
                            { header: 'Interior     ', width: 100, dataIndex: 'VCHUBICACION', sortable: true },
                            { header: 'TF', width: 050, dataIndex: 'CHRFICTIPO', sortable: true },
                            { header: 'Ficha Codigo ', width: 100, dataIndex: 'INTFICCODIGO', sortable: true },
                            { header: 'U.Cat. Codigo', width: 100, dataIndex: 'INTUCATID', sortable: true },
                            { header: 'Uso          ', width: 200, dataIndex: 'VCHINDIVUSODESC', sortable: true }
                        ],
	            //renderTo: 'divTab2',
	            fit: true,
                viewConfig: {
                    deferEmptyText: false,
                    emptyText: '<div><img src="../img/nodatadisponible.png" /></div>',
                },
	            //width: 400,
	            height: 320
	        });

	        // create the grid
	        grid2 = new Ext.grid.GridPanel({
	            store: Grid2Store,
   	            width: 780,
	            columns: [
                           {
                               xtype: 'actioncolumn',
                               width: 30,
                               items: [{
                                   icon: '../img/info.png',  // Use a URL in the icon config
                                   tooltip: 'Informacion',
                                   handler: function (grid, rowIndex, colIndex) {
                                       var rec = grid.getStore().getAt(rowIndex);
                                       popupSATTI(rec.get('SMLANOANIOPRO'), rec.get('INTDJUNUMDDJJ'), rec.get('INTPRECODIGO'), rec.get('VCHCODCAT'));
                                   }
                               }]
                           },
                            { header: 'C.Predial    ', width: 100, dataIndex: 'INTPRECODIGO', sortable: true },
                            { header: 'Administrado ', width: 350, dataIndex: 'VCHADMCOMPLETO', sortable: true },
                            { header: 'Uso          ', width: 250, dataIndex: 'VCHUSODESCRI', sortable: true },
                            { header: 'Propiedad    ', width: 250, dataIndex: 'VCHCOPDESCRI', sortable: true },
                            { header: ' % ', width: 50, dataIndex: 'DECPREPORCOPROP', sortable: true },
                            { header: 'Ubicacion    ', width: 500, dataIndex: 'VCHPREDIRECCION', sortable: true },
                            { header: 'Codigo       ', width: 100, dataIndex: 'INTADMCODIGO', sortable: true },
	                        { header: 'C.Catastral  ', width: 120, dataIndex: 'VCHCODCAT', sortable: true }
                        ],
	            //renderTo: 'divTab2',
	            fit: true,
                viewConfig: {
                    deferEmptyText: false,
                    emptyText: '<div><img src="../img/nodatadisponible.png" /></div>',
                },
	            //width: 400,
	            height: 320
	        });


	        // create the grid
	        grid3 = new Ext.grid.GridPanel({
	            store: Grid3Store,
	            width: 780,
	            columns: [
                           {
                               xtype: 'actioncolumn',
                               width: 30,
                               items: [{
                                   icon: '../img/info.png',  // Use a URL in the icon config
                                   tooltip: 'Informacion',
                                   handler: function (grid, rowIndex, colIndex) {
                                       var rec = grid.getStore().getAt(rowIndex);
                                       popupSAC(rec.get('CHRSOLANIO'), rec.get('VCHSOLNUMERO'))
                                   }
                               }]
                           },
                            { header: 'Licencia     ', width: 80, dataIndex: 'VCHLICNUMERO', sortable: true },
                            { header: 'Solicitante  ', width: 350, dataIndex: 'VCHSOLNOMBRESOL', sortable: true },
                            { header: 'Nombre Comercial',  width: 350, dataIndex: 'VCHSOLNOMBRECOMER', sortable: true },                            
                            { header: 'Ubicación del Establecimiento', width: 400, dataIndex: 'VCHUURDIRECCION', sortable: true },
                            { header: 'Giro         ', width: 300, dataIndex: 'VCHGIRDESCRIPCION', sortable: true },
                            { header: 'Cert.DC      ', width: 120, dataIndex: 'VCHLICDEFCIVIL', sortable: true },
	                        { header: 'Fec.Cert.DC  ', width: 120, dataIndex: 'DATLICFECCERDF', sortable: true },
                            { header: 'C.Predial    ', width: 100, dataIndex: 'INTPRECODIGO', sortable: true }
                        ],
	            //renderTo: 'divTab2',
                fit: true,
                viewConfig: {
                    deferEmptyText: false,
                    emptyText: '<div><img src="../img/nodatadisponible.png" /></div>',
                },

	            //width: 400,
	            height: 320
	        });


	        grid4 = new Ext.grid.GridPanel({
	            store: Grid4Store,
	            width: 780,
	            //autoWidth: true,
	            columns: [
                            { header: '..', width: 200, dataIndex: 'TKEY', sortable: false, menuDisabled: true },
                            { header: '...', width: 500, dataIndex: 'TVALUE', sortable: false, menuDisabled: true }
                        ],
	            fit: true,
                viewConfig: {
                    deferEmptyText: false,
                    emptyText: '<div><img src="../img/nodatadisponiblesmall.png"  /></div>',
                },
	            height: 320,
                borderWidth: 1

	        });


	        tabs = new Ext.TabPanel({
	            renderTo: 'divTabsPop',
                //region: 'south',
	            width: 790,
	            height: 350,
	            activeTab: 0,
	            frame: true,
	            expanded: true,
	            autoScroll: true,
	            //defaults: { autoHeight: true },
	            items: [
                            { title: 'Información de Lote', items: grid4 },
                            //{ contentEl: 'divTab02', title: 'Fichas Catastrales', items: grid1},
                            { title: 'Administración Tributaria', items: grid2 },
                            { title: 'Autorizaciones Comerciales', items: grid3 }
                       ]
	        });
	        //var win;
	        if (win) {
	            // win.destroy();
	            // grid.destroy();
	        }

	        win = new Ext.Window({
	            //applyTo: 'divLote',
	            //layout: 'fit',
	            contentEl: 'divLote',
                title: '.: Detalle de Lote :.',
	            width: 820,
	            height: 680,
	            closeAction: 'hide',
                buttonAlign : 'center',     
	            plain: false,
                //items: tabs,
	            buttons: [
                            {  text: 'Cerrar', handler: function () {  win.hide(); } }
                         ],
                modal: true
	        });
	        win.show();

	    })
        .always(function () {
            console.log("complete");
            Ext.MessageBox.hide();
        })
        .fail(function (jqxhr, textStatus, error) {
            var err = textStatus + ", " + error;
            console.log("Request Failed: " + err);
        });             // FIN DE LLAMADA
}


function mostrarGeoParques() {
    
    var webMethod = "../WebServiceGEO.asmx/listarParquesGeo";
    //var matrizCalles = [];
    console.log("Iniciado");

    $.ajax({
        type: "POST",
        url: webMethod,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log("paso llamada");
            var lista = response.d;
            var txtHTML;
            var txtINFO;
            txtHTML = "";
            console.log("Recorriendo");
            i = 0;
            $.each(lista, function (index, pan) {

                //matrizParques[i] = new Array(5);
                //matrizParques[i][0] = pan.idparque;
                //matrizParques[i][1] = pan.codparque;
                //matrizParques[i][2] = pan.nomparque;
                //matrizParques[i][3] = pan.xGeo;
                //matrizParques[i][4] = pan.yGeo;
                //matrizParques[i][5] = pan.Geom;

                txtHTML += "<li><a href='javascript:MapParqueGeo(" + pan.xGeo + "," + pan.yGeo + "," + pan.Geo + ")' style='text-decoration:none'>";
                txtHTML += "" + pan.nomparque + "</a></li>";
                i++;

            });

            if (txtHTML != null) {
            }
            document.getElementById("divDataParques").innerHTML = "<ul id='ListParque' class='accordionC'>" + txtHTML + "</ul>";

        },
        error: function (XMLHttpRequest, textStatus, error) { console.log(textStatus); alert('ERROR:' + error); }
    });         //fin llamada ajax
}



function mostrarGeoCallejero() {
    var webMethod = "../WebServiceGEO.asmx/listarCallejero";
    console.log("Iniciado");

    $.ajax({
        type: "POST",
        url: webMethod,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log("paso llamada");
            var lista = response.d;
            var txtHTML;
            var txtINFO;
            txtHTML = "";
            console.log("Recorriendo");
            i = 0;
            $.each(lista, function (index, pan) {

                matrizCalles[i] = new Array(6);
                matrizCalles[i][0] = pan.idvia;
                matrizCalles[i][1] = pan.codvia;
                matrizCalles[i][2] = pan.nomvia;
                matrizCalles[i][3] = pan.nrocdra;
                matrizCalles[i][4] = pan.xGeo;
                matrizCalles[i][5] = pan.yGeo;
                matrizCalles[i][6] = pan.geom;
                txtHTML += "<li><a href='javascript:MapCalleGeo(" + pan.xGeo + "," + pan.yGeo + "," + pan.geom + ")' style='text-decoration:none'>";
                txtHTML += "" + pan.codvia + "-" + pan.nomvia + " " + pan.nrocdra + "</a></li>";
                i++;
            });
            if (txtHTML != null) {
            }
            document.getElementById("divDataCalles").innerHTML = "<ul id='ListCalle' class='accordionC'>" + txtHTML + "</ul>";
        },
        error: function (XMLHttpRequest, textStatus, error) { console.log(textStatus); alert('ERROR:' + error); }
    });      //fin llamada ajax
}

//function mostrarGeoParques() {
//    var webMethod = "../WebServiceGEO.asmx/listarParques?jsoncallback=?";
//    $.getJSON(webMethod)
//	    .done(function (rptaServer) {
//	        var GridStoreParques = new Ext.data.JsonStore({
//	            root: 'Table',
//	            fields: ['idparq', 'nomparq', 'idlot', '_xgeo', '_ygeo', 'geom'],
//	            //autoLoad: true,
//	            data: rptaServer
//	        });
//	        console.log("paso definicion grid");
//	        gridParques = new Ext.grid.GridPanel({
//	            store: GridStoreParques,
//	            width: 480,
//	            //features: [filtersCfg],
//	            //plugins: 'gridfilters',
//	            columns: [
//                             {
//                                 xtype: 'actioncolumn',
//                                 width: 30,
//                                 items: [{
//                                     icon: '../img/info.png',  // Use a URL in the icon config
//                                     tooltip: 'Informacion',
//                                     handler: function (grid, rowIndex, colIndex) {
//                                         var rec = grid.getStore().getAt(rowIndex);
//                                         MapParque(rec.get('_xgeo'), rec.get('_ygeo'), rec.get('geom'));
//                                     }
//                                 }]
//                             },
//                            //{ header: 'Id HU', width: 50, dataIndex: 'idhu', sortable: true, filter: { type: 'string' } },
//                            { header: 'Codigo Parque', width: 50, dataIndex: 'idlot', sortable: true, filter: { type: 'string' } },
//                            { header: 'Nombre Parque', width: 250, dataIndex: 'nomparq', sortable: true, filter: { type: 'string' } }
//	            ],
//	            renderTo: 'divTabParques',
//	            fit: true,
//	            //bbar: Ext.create('Ext.PagingToolbar', { store: Grid1Store }),
//	            viewConfig: {
//	                deferEmptyText: false,
//	                emptyText: '<div><img src="../img/nodatadisponible.png" /></div>',
//	            },
//	            //width: 400,
//	            height: 500
//	        });
//	        console.log("finaliza grid");
//	        console.log(gridParques);
//	    })
//        .always(function () {
//            console.log("complete");
//            Ext.MessageBox.hide();
//        })
//        .fail(function (jqxhr, textStatus, error) {
//            var err = textStatus + ", " + error;
//            console.log("Request Failed: " + err);
//        });             // FIN DE LLAMADA
//}

//function mostrarGeoHabilitaciones() {
//    var webMethod = "../WebServiceGEO.asmx/listarHabilitaciones?jsoncallback=?";
//    $.getJSON(webMethod)
//	    .done(function (rptaServer) {
//	        var GridStoreHabilita = new Ext.data.JsonStore({
//	            root: 'Table',
//	            fields: ['idhu', 'cod', 'nom', '_xgeo', '_ygeo', 'geom'],
//	            //autoLoad: true,
//	            data: rptaServer
//	        });
//	        console.log("paso definicion grid");
//	        console.log(GridStoreHabilita);
//	        gridHabilita = new Ext.grid.GridPanel({
//	            store: GridStoreHabilita,
//	            width: 480,
//	            //features: [filtersCfg],
//	            //plugins: 'gridfilters',
//	            columns: [
//                             {
//                                 xtype: 'actioncolumn',
//                                 width: 30,
//                                 items: [{
//                                     icon: '../img/info.png',  // Use a URL in the icon config
//                                     tooltip: 'Informacion',
//                                     handler: function (grid, rowIndex, colIndex) {
//                                         var rec = grid.getStore().getAt(rowIndex);
//                                         MapHabilita(rec.get('_xgeo'), rec.get('_ygeo'), rec.get('geom'));
//                                     }
//                                 }]
//                             },
//                            //{ header: 'Id HU', width: 50, dataIndex: 'idhu', sortable: true, filter: { type: 'string'} },
//                            { header: 'Codigo HU', width: 50, dataIndex: 'cod', sortable: true, filter: { type: 'string' } },
//                            { header: 'Nombre HU', width: 250, dataIndex: 'nom', sortable: true, filter: { type: 'string' } }
//	            ],
//	            renderTo: 'divTabHabilita',
//	            fit: true,
//	            //bbar: Ext.create('Ext.PagingToolbar', { store: Grid1Store }),
//	            viewConfig: {
//	                deferEmptyText: false,
//	                emptyText: '<div><img src="../img/nodatadisponible.png" /></div>',
//	            },
//	            //width: 400,
//	            height: 500
//	        });
//	        console.log("finaliza grid");
//	        console.log(gridHabilita);
//	    })
//        .always(function () {
//            console.log("complete");
//            Ext.MessageBox.hide();
//        })
//        .fail(function (jqxhr, textStatus, error) {
//            var err = textStatus + ", " + error;
//            console.log("Request Failed: " + err);
//        });             // FIN DE LLAMADA
//}

function mostrarGeoHabilitas() {
    var webMethod = "../WebServiceGEO.asmx/listarHabilitaGeo";
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
                //matrizHabilitas[i] = new Array(5);
                //matrizHabilitas[i][0] = pan.idhabilita;
                //matrizHabilitas[i][1] = pan.codhabilita;
                //matrizHabilitas[i][2] = pan.nomhabilita;
                //matrizHabilitas[i][3] = pan.xGeo;
                //matrizHabilitas[i][4] = pan.yGeo;
                //matrizHabilitas[i][5] = pan.Geom;

                txtHTML += "<li><a href='javascript:MapHabilitaGeo(" + pan.xGeo + "," + pan.yGeo + "," + pan.Geom + ")' style='text-decoration:none'>";
                txtHTML += "" + pan.codhabilita + " " + pan.nomhabilita + "</a></li>";
                i++;

            });



            if (txtHTML != null) {
            }
            document.getElementById("divDataHabilitas").innerHTML = "<ul id='ListHabilita' class='accordion'>" + txtHTML + "</ul>";
        },
        error: function (XMLHttpRequest, textStatus, error) { console.log(textStatus); alert('ERROR:' + error); }
    });      //fin llamada ajax
}


function MapHabilitaGeo(x, y, geo) {

    var center = new OpenLayers.LonLat(x, y);
    map.setCenter(center, 5);
    //var poly = matrizHabilitas[pos][5]
    var poly = geo;
    f_createVSelectPOLY(poly);
}

function MapParque(x, y, geo) {

    var center = new OpenLayers.LonLat(x, y);
    map.setCenter(center, 8);
    //var poly = geo;
    //f_createVSelectPOLY(poly);
}


function MapParqueGeo(x, y, geo) {
    var center = new OpenLayers.LonLat(x, y);
    map.setCenter(center, 8);
    var poly = geo;
    f_createVSelectPOLY(poly);
}

function MapCalleGeo(x, y, geo) {

    var center = new OpenLayers.LonLat(x, y);
    map.setCenter(center, 8);
    var poly = geo
    f_createVSelectLINE(poly);
}

function MapCalle(x, y, pos) {

    var center = new OpenLayers.LonLat(x, y);
    map.setCenter(center, 8);
    var poly = matrizCalles[pos][6]
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

function f_createVSelectPOLY(geom) {
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
                "geometries": [{ "type": "Polygon", "coordinates": eval(poly)}]
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

function mostrarGeoRecursos() {

    var sTREC = document.getElementById("SelTRecurso").value;
    var sNSEC = document.getElementById("SelSector").value;
    var intSize = 20;
    var intLeft = -10;
    var intZoom = 3;
    var webMethod = "../WebServiceGEO.asmx/gpsPosicionListar";
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

                if ((sTREC == pan.SMLTRECODIGO || sTREC == 0) && (sNSEC == pan.SMLSECCODIGO || sNSEC == 0)) {
                    i++;

                    txtHTML += "<li><a href='javascript:posicionGPS(" + pan.VCHPOSXGEO + "," + pan.VCHPOSYGEO + "," + pan.INTISSI + "," + pan.INTPOSID + ")' style='text-decoration:none'>";
                    txtHTML += "<p> [ I-" + pan.INTISSI + " ] - [ C-" + pan.VCHPOSCDTE + " ] - [" + pan.VCHTREDESCRIPCION + "]<BR>" + pan.VCHPOSNOMVIA + "<BR>" + pan.VCHPOSDENHU + "</p></a></li>";

                    var iMarker = '../img/Recursos/000.png';
                    var strUnit = pan.SMLTRECODIGO;

                    if (strUnit == 1) iMarker = "../img/Recursos/001.png";
                    if (strUnit == 2) iMarker = "../img/Recursos/002.png";
                    if (strUnit == 3) iMarker = "../img/Recursos/003.png";
                    if (strUnit == 4) iMarker = "../img/Recursos/004.png";
                    if (strUnit == 5) iMarker = "../img/Recursos/005.png";
                    if (strUnit == 6) iMarker = "../img/Recursos/006.png";
                    if (strUnit == 7) iMarker = "../img/Recursos/007.png";
                    if (strUnit == 8) iMarker = "../img/Recursos/008.png";
                    if (strUnit == 9) iMarker = "../img/Recursos/009.png";
                    if (strUnit == 10) iMarker = "../img/Recursos/010.png";
                    if (strUnit == 11) iMarker = "../img/Recursos/011.png";
                    if (strUnit == 12) iMarker = "../img/Recursos/012.png";
                    if (strUnit == 13) iMarker = "../img/Recursos/013.png";
                    if (strUnit == 14) iMarker = "../img/Recursos/014.png";
                    if (strUnit == 15) iMarker = "../img/Recursos/015.png";

                    if (strUnit == 16) iMarker = "../img/Recursos/016.png";
                    if (strUnit == 17) iMarker = "../img/Recursos/017.png";
                    if (strUnit == 18) iMarker = "../img/Recursos/018.png";
                    if (strUnit == 19) iMarker = "../img/Recursos/019.png";
                    if (strUnit == 20) iMarker = "../img/Recursos/020.png";

                    if (strUnit == 21) iMarker = "../img/Recursos/021.png";
                    if (strUnit == 22) iMarker = "../img/Recursos/022.png";
                    if (strUnit == 23) iMarker = "../img/Recursos/023.png";
                    if (strUnit == 24) iMarker = "../img/Recursos/024.png";
                    if (strUnit == 25) iMarker = "../img/Recursos/025.png";



                    //iMarker = '../img/Recursos/' + pan.VCHESTNIMG;
                    var featureR = new OpenLayers.Feature.Vector(
                            new OpenLayers.Geometry.Point(pan.VCHPOSXGEO, pan.VCHPOSYGEO),
                            { description: "<h1>marker number " + pan.INTISSI + "</h1>" },
                            { externalGraphic: iMarker, graphicHeight: intSize, graphicWidth: intSize, graphicXOffset: intLeft, graphicYOffset: intLeft }
                        );
//                    if (strUnit == 15) {
//                        var featureR = new OpenLayers.Feature.Vector(
//                            new OpenLayers.Geometry.Point(pan.VCHPOSXGEO, pan.VCHPOSYGEO),
//                            { description: "<h1>marker number " + pan.INTISSI + "</h1>" },
//                            { externalGraphic: iMarker, graphicHeight: 48, graphicWidth: 48, graphicXOffset: 24, graphicYOffset: 24 }
//                        );
//                    }

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
                }
            });



            if (txtHTML != null) {
                map.addLayer(vectorLayer);
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
            document.getElementById("divUnidades").innerHTML = "<ul id='ListGPS' class='accordion'>" + txtHTML + "</ul>";
        },
        error: function (XMLHttpRequest, textStatus, error) { alert('ERROR:' + error); }
    });           //fin llamada ajax
};





