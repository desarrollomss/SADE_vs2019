
function popupSIRCAT(vFICHA, vCODCAT, vTIPFIC) {
    var url = 'REPORTES/DetalleFC.aspx?pFICHA=' + vFICHA + '&pCODCAT=' + vCODCAT + '&pTIPFIC=' + vTIPFIC
    var setting = "directories=no,height=600,left=10,location=no,menubar=no,resizable=no,scrollbars=yes,status=no,toolbar=no,top=10,width=900";
    window.open(url, ".: Formato Ficha :.", setting)
}

function popupSATTI(vANOPRO, vNUMDDJJ, vCODPRE, vCODCAT) {
    var url = 'REPORTES/DetallePU.aspx?pANOPRO=' + vANOPRO + '&pNUMDDJJ=' + vNUMDDJJ + '&pCODPRE=' + vCODPRE + '&pCODCAT=' + vCODCAT
    var setting = "directories=no,height=600,left=10,location=no,menubar=no,resizable=no,scrollbars=yes,status=no,toolbar=no,top=10,width=900";
    window.open(url, ".: Formato PU :.", setting)
}


function popupSAC(vANOSOL, vNUMSOL) {
    var url = 'http://192.0.0.5:9080/SACWeb/rptCertificado.rep?numero=' + vNUMSOL + '&anio=' + vANOSOL;
    var setting = "directories=no,height=600,left=10,location=no,menubar=no,resizable=no,scrollbars=yes,status=no,toolbar=no,top=10,width=900";
    window.open(url, ".: Formato PU :.", setting)
}







function capas() {

    __pmdl_top = {
        id: "div_panel_mdl_top",
        region: "north",
        contentEl: "divTitulo",
        height: 75,
        collapsible: true,
        collapseMode: "mini",
        autoScroll: false
    };


    __pmdl_bottom = {
        id: "div_panel_mdl_bottom",
        region: "south",
        margins: '0 0 0 0',
        bodyStyle: { "padding": "0x 0px 0px 0px" },
        //html: '',
        height: 200,
        collapsible: true,
        layout: {
            type: 'accordion',
            animate: true
        },
        contentEl: "statusbar",
        collapsed: true

    };

    __pmdl_east = {
        id: "div_panel_mdl_east",
        title: "Leyenda",
        region: "east",
        contentEl: "mapLegend",
        width: 450,
        //height: 300,
        collapsible: true,
        //collapseMode: "large",
        autoScroll: true,
        collapsed: true
    };

    __pmdl_west = {
        id: "div_panel_mdl_west",
        region: "west",
        margins: '0 0 0 0',
        bodyStyle: { "padding": "20x 20px 20px 20px" },
        width: 500,
        minSize: 75,
        maxSize: 500,
        iconCls: 'titulo',
        layout: {
            type: 'accordion',
            animate: true
        },
        items: [
                    {
                        contentEl: 'divMaps',
                        title: 'Configuración del Mapa',
                        border: true,
                        iconCls: 'layers' // see the HEAD section for style used
                    },
                    {
                        contentEl: 'divBuscaMapa',
                        title: 'Busqueda en Mapa',
                        //autoScroll: true,
                        border: true,
                        layout: 'fit',
                        iconCls: 'buscar'  // see the HEAD section for style used
                    },
                    {
                        contentEl: 'divBuscaBase',
                        id: 'lBusca',
                        title: 'Busqueda en Base Literal',
                        border: true,
                        iconCls: 'persona' // see the HEAD section for style used
                    }
        ]
                    ,
        xtype: "gx_mappanel",
        html: '',
        //height: 200,
        //contentEl: "divLogo",
        title: '',
        //split: true,
        collapsible: true,
        animCollapse: true,
        collapseMode: 'header',
        titleCollapse: true,
        autoScroll: false
    };




    mapPanel = new GeoExt.MapPanel({
        border: true,
        region: "center",
        margins: '3 3 3 3',
        // we do not want all overlays, to try the OverlayLayerContainer
        map: map,
        center: [283430.991, 8657254.839],
        zoom: 14,
        //tbar: [measureLength, '-', measureArea, '-'],
        bbar: [
                    {
                        xtype: "label",
                        text: "©2023 - Municipalidad de Santiago de Surco - Lima - Peru"
                    }
        ],
        tbar: toolbarItems,

        layers: [
                        wms = new OpenLayers.Layer.WMS("00 - Santiago de Surco", vSERVER,
                                    {
                                        srs: 'EPSG:32718',
                                        layers: 'CM150140:CM150140_base',
                                        tiled: true,
                                        transparent: false
                                    }),
                        ves = new OpenLayers.Layer.WMS("12-Via Expresa", vSERVER,
                                    {
                                        srs: 'EPSG:32718',
                                        layers: 'tb_viaexpresa',
                                        transparent: true
                                    }, { isBaseLayer: false }
                                    ),
                        lote = new OpenLayers.Layer.WMS("11-Limite Lote", vSERVER,
                                    {
                                        srs: 'EPSG:32718',
                                        layers: 'CM150140:map_lote',
                                        transparent: true
                                    }, { isBaseLayer: false }
                                    ),
                        lotec = new OpenLayers.Layer.WMS("10-Código Lote", vSERVER,
                                    {
                                        srs: 'EPSG:32718',
                                        layers: 'CM150140:map_lote_cod',
                                        transparent: true
                                    }, { isBaseLayer: false }
                                    ),
                        lblhurb = new OpenLayers.Layer.WMS("09.1-Habilitación Urbana Etiqueta", vSERVER,
                                    {
                                        srs: 'EPSG:32718',
                                        //layers: 'CM150140:CM150140_hurbana',
                                        layers: 'map_hurbana_lb',
                                        transparent: true
                                    }, { isBaseLayer: false, visibility: false }
                                    ),
                        hurb = new OpenLayers.Layer.WMS("09-Habilitación Urbana", vSERVER,
                                    {
                                        srs: 'EPSG:32718',
                                        //layers: 'CM150140:CM150140_hurbana',
                                        layers: 'map_hurbana',
                                        transparent: true
                                    }, { isBaseLayer: false, visibility: false }
                                    ),
                        subsectorvecinal = new OpenLayers.Layer.WMS("08.2-Sub Sector Vecinal Etiqueta", vSERVER,
                                    {
                                        srs: 'EPSG:32718',
                                        layers: 'map_subsectorvecinal_lb',
                                        transparent: true
                                    }, { isBaseLayer: false, visibility: false }
                                    ),
                        lblsectorvecinal = new OpenLayers.Layer.WMS("08.1-Sector Vecinal Etiqueta", vSERVER,
                                    {
                                        srs: 'EPSG:32718',
                                        layers: 'map_area_lb ',
                                        transparent: true
                                    }, { isBaseLayer: false, visibility: false }
                                    ),
                        sectorvecinal = new OpenLayers.Layer.WMS("08-Sector Vecinal", vSERVER,
                                    {
                                        srs: 'EPSG:32718',
                                        layers: 'map_area',
                                        transparent: true
                                    }, { isBaseLayer: false, visibility: false }
                                    ),
                        zonificacion = new OpenLayers.Layer.WMS("07-Zonificación", vSERVER,
                                    {
                                        srs: 'EPSG:32718',
                                        layers: 'map_zonificacion',
                                        transparent: true
                                    }, { isBaseLayer: false, visibility: false }
                                    ),
                        zona = new OpenLayers.Layer.WMS("06-Secciones Catastrales", vSERVER,
                                    {
                                        srs: 'EPSG:32718',
                                        layers: 'map_sector',
                                        transparent: true
                                    }, { isBaseLayer: false, visibility: false }
                                    ),
                        sc = new OpenLayers.Layer.WMS("05-Cuadrantes Seguridad Ciudadana", vSERVER,
                                    {
                                        srs: 'EPSG:32718',
                                        layers: 'map_cuadrante',
                                        transparent: true
                                    }, { isBaseLayer: false, visibility: false }
                                    ),
                        comercio = new OpenLayers.Layer.WMS("04-Autorizaciones Comerciales", vSERVER,
                                    {
                                        srs: 'EPSG:32718',
                                        layers: 'map_lote_comercio',
                                        transparent: true
                                    }, { isBaseLayer: false, visibility: false }
                                    ),
                        construcciones = new OpenLayers.Layer.WMS("03-Construcciones Lote", vSERVER,
                                    {
                                        srs: 'EPSG:32718',
                                        layers: 'map_lote_construcciones',
                                        transparent: true
                                    }, { isBaseLayer: false, visibility: false }
                                    ),
                        licencia = new OpenLayers.Layer.WMS("02-Licencias de Obras", vSERVER,
                                    {
                                        srs: 'EPSG:32718',
                                        layers: 'map_lote_licencia',
                                        transparent: true
                                    }, { isBaseLayer: false, visibility: false }
                                    ),

                        lblareaT = new OpenLayers.Layer.WMS("01.1-Area Tratamiento Normativo Etiqueta", vSERVER,
                                    {
                                        srs: 'EPSG:32718',
                                        layers: 'map_atn_lb',
                                        transparent: true
                                    }, { isBaseLayer: false, visibility: false }
                                    ),

                        areaT = new OpenLayers.Layer.WMS("01-Area Tratamiento Normativo", vSERVER,
                                    {
                                        srs: 'EPSG:32718',
                                        layers: 'map_atn',
                                        transparent: true
                                    }, { isBaseLayer: false, visibility: false }
                                    )//,
        //                        areaL = new OpenLayers.Layer.WMS("ATN", vSERVER,
        //                                    {
        //                                        srs: 'EPSG:32718',
        //                                        layers: 'map_atn_lb',
        //                                        transparent: true
        //                                    }, { isBaseLayer: false, visibility: false, displayInLayerSwitcher: false }
        //                                    ),

        //                        subsector = new OpenLayers.Layer.WMS("Subsector vecinal", vSERVER,
        //                                    {
        //                                        srs: 'EPSG:32718',
        //                                        layers: 'map_subsectorvecinal',
        //                                        transparent: true
        //                                    }, { isBaseLayer: false, visibility: false }
        //                                    )
        //,
        //                        sector = new OpenLayers.Layer.WMS("Sectores", vSERVER,
        //                                    {
        //                                        srs: 'EPSG:32718',
        //                                        layers: 'map_sector',
        //                                        transparent: true
        //                                    }, { isBaseLayer: false, visibility: false }
        //                                    ),
        ////                        berma = new OpenLayers.Layer.WMS("Berma", vSERVER,
        //                                    {
        //                                        srs: 'EPSG:32718',
        //                                        layers: 'map_berma',
        //                                        transparent: true
        //                                    }, { isBaseLayer: false, visibility: false }
        //                                    )

        ],
        items: [
        //                {
        //                    xtype: "gx_zoomslider",
        //                    aggressive: true,
        //                    vertical: true,
        //                    height: 300,
        //                    x: 10,
        //                    y: 100,
        //                    plugins: new GeoExt.ZoomSliderTip({ template: "<div>Zoom Level: {zoom}</div>" })
        //                },
        ////                {
        ////                    region: "bottom",
        ////                    margins: '0 0 0 0',
        ////                    bodyStyle: { "padding": "0x 0px 0px 0px" },
        ////                    height: 400,
        ////                    html: 'Nested South',
        ////                    collapsible: true,
        ////                    layout: {
        ////                        type: 'accordion',
        ////                        animate: true
        ////                    },
        ////                    collapsed: true
        ////                }

        ]
    });


    layerRoot = new Ext.tree.TreeNode({
        text: "All Layers",
        border: false,
        expanded: true
    });

    layerRoot.appendChild(new GeoExt.tree.BaseLayerContainer({
        text: "Base Layers",
        map: map,
        expanded: true
    }));

    layerRoot.appendChild(new GeoExt.tree.OverlayLayerContainer({
        text: "Overlays",
        map: map,
        expanded: true
    }));


    layerTree = new Ext.tree.TreePanel({
        //title: "Layers de Mapa",
        //renderTo: "divTabLayers",
        renderTo: "divCapas",
        root: layerRoot,
        enableDD: true,
        collapsible: false,
        fit: true,
        //width: 480,
        //height: 380,
        expanded: true,
        rootVisible: false
    });



    legendPanel = new GeoExt.LegendPanel({
        layerStore: mapPanel.layers,
        enableDD: true,
        fit: true,
        expanded: true,
        autoScroll: true,
        defaults: { autoHeight: true },
        border: false
    });

    tabBuscaMaps = new Ext.TabPanel({
        renderTo: 'divTabsBM',
        enableTabScroll: true,
        width: 490,
        height: 450,
        defaults: { autoScroll: true },
        items: [
                    { contentEl: 'divCalles', title: 'Calles' },
                    { contentEl: 'divParques', title: 'Parques' },
                    { contentEl: 'divHabilitas', title: 'Habilitaciones' }
        ]
    });

    tabBuscaMaps.doLayout();
    tabBuscaMaps.activate(0);
    tabBuscaMaps.activate(1);
    tabBuscaMaps.activate(2);
    tabBuscaMaps.activate(0);



    tabMaps = new Ext.TabPanel({
        renderTo: 'divTabsL',
        //fit: true,
        width: 500,
        height: 600,
        activeTab: 0,
        autoScroll: true,
        defaults: { autoHeight: true, autoWidth: true },
        items: [
            { contentEl: 'divTabLayers', title: 'Capas', items: layerTree },
            { contentEl: 'divTabLegend', title: 'Leyenda', items: legendPanel }
        ]
    });

    var layerRoot = new Ext.tree.TreeNode({
        text: "All Layers",
        expanded: true
    });
    layerRoot.appendChild(new GeoExt.tree.BaseLayerContainer({
        text: "Base Layers",
        map: map,
        expanded: true
    }));
    layerRoot.appendChild(new GeoExt.tree.OverlayLayerContainer({
        text: "Overlays",
        map: map,
        expanded: true
    }));
    var layerTree = new Ext.tree.TreePanel({
        //title: "Layers de Mapa",
        root: layerRoot,
        enableDD: true,
        collapsible: false,
        height: 500,
        expanded: true,
        renderTo: "divCapas"
    });


}


function mostrar() {

    //var tabs = new Ext.TabPanel({
    //    renderTo: 'divTabs',
    //    //width: 450,
    //    height: 400,
    //    activeTab: 0,
    //    frame: true,
    //    //expanded: true,
    //    autoScroll: true,
    //    defaults: { autoHeight: true },
    //    items: [
    //        { contentEl: 'divTab1', title: 'Fotografia' },
    //        { contentEl: 'divTab2', title: 'Predios' },
    //        { contentEl: 'divTab3', title: 'Comercios' }
    //    ]
    //});




}
