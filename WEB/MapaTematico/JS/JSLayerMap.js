function mostrarCapas()
{
    __pmdl_top = {
        id: "div_panel_mdl_top",
        region: "north",
        contentEl: "divTitulo",
        height: 75,
        collapsible: true,
        collapseMode: "mini",
        autoScroll: false
    };

    __pmdl_west = {
        id: "div_panel_mdl_west",
        region: "east",
        //region: "west",
        margins: '0 0 0 0',
        bodyStyle: { "padding": "10x 0px 0px 10px" },
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
                        contentEl: 'divCapas',
                        title: 'Configuración del Mapa',
                        border: true,
                        iconCls: 'layers' // see the HEAD section for style used
                    },
                    {
                        contentEl: 'divDatos',
                        id: 'lDatos',
                        title: 'Informacion Alertas, Camaras y GPS',
                        border: true,
                        iconCls: 'informacion' // see the HEAD section for style used
                    }

                                        
                    //,
                    //{
                    //    contentEl: 'divRecursos',
                    //    title: 'Información de Recursos',
                    //    autoScroll: true,
                    //    border: true,
                    //    layout: 'fit',
                    //    iconCls: 'recurso' // see the HEAD section for style used
                    //},
                    //{
                    //    contentEl: 'divAlertas',
                    //    title: 'Información de Alertas',
                    //    autoScroll: true,
                    //    border: true,
                    //    layout: 'fit',
                    //    iconCls: 'alertas' // see the HEAD section for style used
                    //},
                    //{
                    //    contentEl: 'divCalles',
                    //    title: 'Busqueda de Calles',
                    //    autoScroll: true,
                    //    border: true,
                    //    layout: 'fit',
                    //    iconCls: 'calles' // see the HEAD section for style used
                    //}
                ]
                    ,
        //xtype: "gx_mappanel",
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
        bbar: [
                    {
                        xtype: "label",
                        text: "©2023 - Municipalidad de Santiago de Surco - Lima - Peru"
                    }
              ],
        tbar: toolbarItems,
        layers: [
                        wms = new OpenLayers.Layer.WMS("MuniSurco", vSERVER,
                                    {
                                        srs: 'EPSG:32718',
                                        layers: 'CM150140v2:base_surcov2',
                                        tiled: true,
                                        transparent: false
                                    }),
                        lote = new OpenLayers.Layer.WMS("Limite Lote", vSERVER,
                                    {
                                        srs: 'EPSG:32718',
                                        layers: 'CM150140:map_lote,CM150140v2:map_lote_cod',
                                        //layers: 'CM150140v2:map_lote,CM150140v2:map_lote_cod',
                                        transparent: true
                                    }, { isBaseLayer: false }
                                    ),
                        hurb = new OpenLayers.Layer.WMS("Limite Habilitacion Urbana", vSERVER,
                                    {
                                        srs: 'EPSG:32718',
                                        layers: 'CM150140v2:map_hurbana,CM150140v2:map_hurbana_lb',
                                        transparent: true
                                    }, { isBaseLayer: false, visibility: false }
                                    ),
                        zona = new OpenLayers.Layer.WMS("Limite Sectores Catastrales", vSERVER,
                                    {
                                        srs: 'EPSG:32718',
                                        layers: 'CM150140v2:map_sector,CM150140v2:map_sector_cod',
                                        transparent: true
                                    }, { isBaseLayer: false, visibility: false }
                                    ),
                        sc = new OpenLayers.Layer.WMS("Limite Cuadrantes", vSERVER,
                                    {
                                        srs: 'EPSG:32718',
                                        layers: 'map_cuadrante',
                                        transparent: true
                                    }, { isBaseLayer: false, visibility: false }
                                    ),
                        semaforo = new OpenLayers.Layer.WMS("Limite Sector Vecinal", vSERVER,
                                    {
                                        srs: 'EPSG:32718',
                                        layers: 'CM150140v2:map_sectorvecinal,CM150140v2:map_sectorvecinal_lb',
                                        transparent: true
                                    }, { isBaseLayer: false, visibility: false }
                                    ),
            
                        modulo = new OpenLayers.Layer.WMS("Limite Subsector Vecinal", vSERVER,
                                    {
                                        srs: 'EPSG:32718',
                                        layers: 'CM150140v2:map_subsectorvecinal,CM150140v2:map_subsectorvecinal_lb',
                                        transparent: true
                                    }, { isBaseLayer: false, visibility: false }
                                    )

        ]
    });

    //*****

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
        //renderTo: "divCapas",
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


    tabMaps = new Ext.TabPanel({
        renderTo: 'divCapas',
        //fit: true,
        width: 500,
        height: 600,
        activeTab: 0,
        autoScroll: true,
        defaults: { autoHeight: true, autoWidth: true },
        items: [
                { contentEl: 'divTabLayers', title: 'Capas', items: layerTree },
                { contentEl: 'divTabLegend', title: 'Leyenda', items: legendPanel },
                { contentEl: 'divTabSearch', title: 'Busqueda' }
        ]
    });
    
   
    //*****

    
    tabs = new Ext.TabPanel({
        renderTo: 'divDatos',
        //region: 'south',
        width: 480,
        height: 700,
        activeTab: 0,
        frame: true,
        expanded: true,
        autoScroll: true,
        defaults: { autoHeight: true },
        items: [
                    { contentEl: 'divTabAlertas', title: 'Alertas' },
                    { contentEl: 'divTabCamaras', title: 'Camaras' },
                    { contentEl: 'divTabUnidades', title: 'Unidades' },
                    { contentEl: 'divTabCalles', title: 'Calles' },
                    { contentEl: 'divTabParques', title: 'Parques' },
                    { contentEl: 'divTabHabilita', title: 'Urbanizaciones' }

        ]
    });

    tabs.doLayout();
    tabs.activate(0);
    tabs.activate(1);
    tabs.activate(2);
    tabs.activate(3);
    tabs.activate(4);
    tabs.activate(5);
    tabs.activate(0);


}




