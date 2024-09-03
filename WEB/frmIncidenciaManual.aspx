<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmIncidenciaManual.aspx.vb" Inherits="frmIncidenciaManual" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!doctype html>
<html lang="en">
<head runat="server">
    <title></title>
    <script src="MapaTematico/OpenLayers-2.13.1/OpenLayers.js" type="text/javascript"></script>
    <link href="Styles/accordionmenu.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="css/themes/base/jquery.ui.all.css" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="js/ui/jquery.ui.core.js" type="text/javascript"></script>
    <script src="js/ui/jquery.ui.widget.js" type="text/javascript"></script>
    <script src="js/ui/jquery.ui.accordion.js" type="text/javascript"></script>
    <script src="sidr/js/jquery.sidr.min.js" type="text/javascript"></script>
    <link href="sidr/css/jquery.sidr.dark.css" rel="stylesheet" type="text/css" />
    <script src="js/funciones.js" type="text/javascript"></script>
    <link rel="stylesheet" href="css/demos.css" type="text/css" />
    <link href="css/calendario.css" rel="stylesheet" type="text/css" />
    <link href="css/boton.css" rel="stylesheet" type="text/css" />
    <link href="css/grid2.css" rel="stylesheet" type="text/css" />
    <link href="css/controles.css" rel="stylesheet" type="text/css" />
    <%--	
    <link rel="stylesheet" href="css/master.css" type="text/css" />    
    <script src="js/Popup.js" type="text/javascript"></script>--%>
    <style type="text/css">
        .black_overlay
        {
            display: none;
            position: absolute;
            top: 0%;
            left: 0%;
            width: 100%;
            height: 100%;
            background-color: black;
            z-index: 1001;
            -moz-opacity: 0.7;
            opacity: .70;
            filter: alpha(opacity=70);
        }
        .white_content
        {
            display: none;
            position: absolute;
            top: 10%;
            left: 10%;
            width: 80%;
            padding: 0px;
            border: 0px solid #a6c25c;
            background-color: white;
            z-index: 1002;
            overflow: auto;
        }
        #pnlContenedor
        {
            width: 98%;
            margin-top: 1%;
            margin-left: 1%;
            margin-right: 1%;
        }
        #pnlRecurso
        {
            width: 100%;
            float: left;
        }
        #pnlPersonal
        {
            width: 100%;
            float: left;
        }
        #pnlPuestoFijo
        {
            width: 100%;
            float: left;
        }
        #pnlBotones
        {
            width: 100%;
            float: left;
        }
        
        #pnlBusqueda
        {
            width: 100%;
            margin-top: 0px;
            margin-bottom: 0px;
        }
        
        #pnlAnonimo
        {
            width: 100%;
            margin-top: 0px;
            margin-bottom: 0px;
        }
        
        #pnlLlamada
        {
            width: 50%;
            float: left;
            margin-top: 0px;
        }
        #pnlIncidente
        {
            width: 49%;
            float: left;
            margin-top: 0px;
        }
        
        
        .PromptCSS
        {
            color: black;
            font-size: inherit;
            font-style: italic;
            font-weight: bold;
            background-color: snow;
            font-family: Courier New;
            border: solid 1px Pink;
            height: 28px;
        }
        
        /* CSS MAPAS*/
        
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
            width: 100%;
            height: 700px;
            margin-top: 0px;
            margin-bottom: 0px;
            border-top: 1px solid #333;
            border-bottom: 2px solid #333;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="pnlContenedor">
        <table>
            <col width="50%" />
            <col width="50%" />
            <tr>
                <td valign="top">


                    <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0"  Width="100%">
                        <cc1:TabPanel runat="server" HeaderText=".: Mapa :." ID="TabPanel1">
                            <ContentTemplate>

                                <asp:Panel ID="upUbicacion" runat="server" GroupingText="Ubicación Incidente" Font-Bold="true">
                                    <div id="vermapita">
                                        <asp:Panel ID="pnlEdicion" runat="server" Width="100%">
                                            <div id="divMap" style="width: 100%; height: 700px; border: 1px solid #ccc;">
                                            </div>
                                        </asp:Panel>
                                    </div>
                                </asp:Panel>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText=".: Fachada :.">
                            <ContentTemplate>
                                <div id="divFoto" />
                            </ContentTemplate>
                        </cc1:TabPanel>
                    </cc1:TabContainer>





                </td>
                <td valign="top">
                    <table>
                        <tr>
                            <td>
                                <asp:Panel ID="pnlDenunciante" runat="server" GroupingText="Identificacion" Font-Bold="true">
                                    <table width="98%" class="Tabla">
                                        <colgroup>
                                            <col width="10%" />
                                            <col width="10%" />
                                            <col width="10%" />
                                            <col width="10%" />
                                            <col width="10%" />
                                            <col width="10%" />
                                            <col width="10%" />
                                            <col width="10%" />
                                            <col width="10%" />
                                            <col width="10%" />
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
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                #Incidencia
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtNroIncidente" runat="server" CssClass="CajaTexto" Enabled="False"
                                                    MaxLength="10" placeholder="..." Width="80%"></asp:TextBox>
                                            </td>
                                            <td>
                                                Previas
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtPrevias" runat="server" CssClass="CajaTextoUpper" Enabled="False"
                                                    MaxLength="10" placeholder="0" Width="80%"></asp:TextBox>
                                            </td>
                                            <td bgcolor="#3399FF" align="center" colspan="2">
                                                <asp:Label ID="lblUsuario" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="White"></asp:Label>
                                            </td>
                                            <td bgcolor="#3399FF" align="center" colspan="2">
                                                <asp:Label ID="lblEquipo" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="White"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Origen
                                            </td>
                                            <td colspan="2">
                                                <asp:DropDownList ID="ddlOrigen" runat="server" CssClass="CajaCombo" Width="90%">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                Número
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txtNumero" runat="server" CssClass="CajaTextoUpper" MaxLength="15"
                                                    onKeyPress="return soloNumeros(event)" placeholder="Ingrese Teléfono" Width="80%"></asp:TextBox>
                                            </td>
                                            <td>
                                                Fecha
                                            </td>
                                            <td colspan="3">
                                                <asp:TextBox ID="txtFechaInc" runat="server" CssClass="CajaTextoOff" 
                                                    placeholder="dd/mm/aaaa" ReadOnly="True" Width="80%"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <asp:CheckBox ID="chkAnonimo" runat="server" AutoPostBack="True" CssClass="CajaTexto"
                                                    onchange="anonimo(this);" Text="No se identifica" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPersona" runat="server" Text="Persona"></asp:Label>
                                            </td>
                                            <td colspan="2">
                                                <asp:DropDownList ID="ddlTipoPersona" runat="server" CssClass="CajaCombo" Width="95%">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="10">
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        <table width="98%" class="Tabla">
                                                            <colgroup>
                                                                <col width="10%" />
                                                                <col width="10%" />
                                                                <col width="30%" />
                                                                <col width="10%" />
                                                                <col width="20%" />
                                                                <col width="10%" />
                                                                <col width="10%" />
                                                            </colgroup>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtNombre" runat="server" CssClass="CajaTextoUpper" Width="90%"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblTipoDoc" runat="server" Text="Tipo Doc."></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlTipoDocInf" runat="server" CssClass="CajaCombo" Width="95%">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblNroDoc" runat="server" Text="Nro.Doc."></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtNumDocInf" runat="server" CssClass="CajaTextoUpper" MaxLength="15"
                                                                        Width="90%"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="chkAnonimo" EventName="CheckedChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="pnlBusqueda" runat="server" GroupingText="Busqueda Mapa" Font-Bold="true">
                                    <table width="98%" class="Tabla">
                                        <colgroup>
                                            <col width="20%" />
                                            <col width="60%" />
                                            <col width="20%" />
                                        </colgroup>
                                        <tr>
                                            <td>
                                                Calle / Via
                                            </td>
                                            <td>
                                                <input type="text" onkeyup="{ this.value=this.value.toUpperCase(); filterCalle(this); } "
                                                    style="width: 95%" />
                                            </td>
                                            <td align="center">
                                                <input type="button" value="Ubicación CCO" onclick="javascript:posicionInicial();"
                                                    class="boton_dialogo" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <div id="divDataCalles" style="width: 80%; height: 120px; border: 1px solid #ccc;
                                                    overflow-y: auto;">
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="pnlDireccion" runat="server" GroupingText="Localización" Font-Bold="true">
                                    <table width="98%" class="Tabla">
                                        <colgroup>
                                            <col width="10%" />
                                            <col width="15%" />
                                            <col width="10%" />
                                            <col width="15%" />
                                            <col width="10%" />
                                            <col width="15%" />
                                            <col width="10%" />
                                            <col width="15%" />
                                        </colgroup>
                                        <tr>
                                            <td>
                                                Via
                                            </td>
                                            <td colspan="3" align="left">
                                                <asp:TextBox ID="txtViaInc" runat="server" CssClass="CajaTextoUpper" MaxLength="150"
                                                    Width="90%"></asp:TextBox>
                                            </td>
                                            <td>
                                                Cdra.
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtCdraInc" runat="server" CssClass="CajaTextoOff" MaxLength="10"
                                                    Width="80%" onkeydown="return false;" onkeypress="return false;" onkeyup="return false;"></asp:TextBox>
                                            </td>
                                            <td>
                                                Nro.
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtNroInc" runat="server" CssClass="CajaTextoUpper" MaxLength="10"
                                                    Width="80%"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Dpto/Int.
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtDptoInc" runat="server" CssClass="CajaTextoUpper" MaxLength="10"
                                                    Width="80%"></asp:TextBox>
                                            </td>
                                            <td>
                                                Hab.Urbana
                                            </td>
                                            <td align="left" colspan="3">
                                                <asp:TextBox ID="txtUrbInc" runat="server" CssClass="CajaTextoOff" MaxLength="100"
                                                    Width="90%" onkeydown="return false;" onkeypress="return false;" onkeyup="return false;"></asp:TextBox>
                                            </td>
                                            <td>
                                                Mza/Lte.
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtMzaInc" runat="server" CssClass="CajaTextoOff" MaxLength="10"
                                                    Width="40%" onkeydown="return false;" onkeypress="return false;" onkeyup="return false;"></asp:TextBox>
                                                <asp:TextBox ID="txtLteInc" runat="server" CssClass="CajaTextoOff" MaxLength="10"
                                                    Width="40%" onkeydown="return false;" onkeypress="return false;" onkeyup="return false;"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Intersección
                                            </td>
                                            <td align="left" colspan="3">
                                                <asp:TextBox ID="txtIntInc" runat="server" CssClass="CajaTextoUpper" MaxLength="150"
                                                    Width="90%"></asp:TextBox>
                                            </td>
                                            <td>
                                                Referencia
                                            </td>
                                            <td align="left" colspan="3">
                                                <asp:TextBox ID="txtComInc" runat="server" CssClass="CajaTextoUpper" MaxLength="200"
                                                    Width="90%"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Sector
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtSector" runat="server" CssClass="CajaTextoOff" placeholder="SC"
                                                    Width="50%" onkeydown="return false;" onkeypress="return false;" onkeyup="return false;"></asp:TextBox>
                                            </td>
                                            <td>
                                                Cuadrante
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtCuadrante" runat="server" CssClass="CajaTextoOff" placeholder="CD"
                                                    Width="50%" onkeydown="return false;" onkeypress="return false;" onkeyup="return false;"></asp:TextBox>
                                            </td>
                                            <td>
                                                Lote Cat.
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtCodCat" runat="server" CssClass="CajaTextoOff" MaxLength="15"
                                                    Visible="true" Width="80%" onkeydown="return false;" onkeypress="return false;"
                                                    onkeyup="return false;"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="pnlRelato" runat="server" GroupingText="Relato del Informante" Font-Bold="true">
                                    <asp:TextBox ID="txtRelato" runat="server" TextMode="MultiLine" Width="98%" Height="70px"
                                        CssClass="CajaTextoUpper"></asp:TextBox>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="pnlTipoInc" runat="server" GroupingText="Tipificación de Incidencia"
                                    Font-Bold="true">
                                    <table width="100%" class="Tabla">
                                        <colgroup>
                                            <col width="07%" />
                                            <col width="30%" />
                                            <col width="07%" />
                                            <col width="30%" />
                                            <col width="07%" />
                                            <col width="19%" />
                                        </colgroup>
                                        <tr>
                                            <td align="right" style="font-weight: bold;">
                                                Tipo
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlTipoInc" runat="server" Width="95%" AutoPostBack="True"
                                                    CssClass="CajaCombo">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right" style="font-weight: bold;">
                                                Subtipo
                                            </td>
                                            <td>
                                                <asp:UpdatePanel ID="upSubTipoInc" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlSubTipoInc" runat="server" Width="95%" CssClass="CajaCombo"
                                                            AutoPostBack="True">
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlTipoInc" EventName="SelectedIndexChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                            <td align="right" style="font-weight: bold;">
                                                Prioridad
                                            </td>
                                            <td>
                                                <asp:UpdatePanel ID="upPrioridad" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlPrioridad" runat="server" CssClass="CajaCombo" Width="95%">
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlSubTipoInc" EventName="SelectedIndexChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="pnlEstadoInc" runat="server" GroupingText="Estado de Incidencia" Font-Bold="true">
                                    <table width="100%" class="Tabla">
                                        <colgroup>
                                            <col width="10%" />
                                            <col width="40%" />
                                            <col width="10%" />
                                            <col width="40%" />
                                        </colgroup>
                                        <tr>
                                            <td align="right" style="font-weight: bold;">
                                                Situación
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlAccionOperador" runat="server" AutoPostBack="True" CssClass="CajaComboAlerta"
                                                    Width="90%">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right" style="font-weight: bold;">
                                                Derivar
                                            </td>
                                            <td>
                                                <asp:UpdatePanel ID="upDerivarGrupo" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlDerivarGrupo" runat="server" AutoPostBack="false" CssClass="CajaComboAlerta"
                                                            Width="90%">
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlAccionOperador" EventName="SelectedIndexChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="pnlBotones" runat="server" CssClass="busquedaFondo" GroupingText=""
                                    Font-Bold="true">
                                    <table width="100%" class="Tabla">
                                        <colgroup>
                                            <col width="50%" />
                                            <col width="50%" />
                                        </colgroup>
                                        <tr align="center">
                                            <td>
                                                <asp:Button ID="btnGrabar" runat="server" CssClass="boton_dialogo" Text="Grabar"
                                                    Width="80%" OnClientClick="javascript:return ValidarGrabar();" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btnCancelar2" runat="server" CssClass="boton_dialogo" Text="Cancelar"
                                                    Width="80%" OnClientClick="cerrarpagina()" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2" style="color: Red">
                    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>

        <asp:HiddenField ID="hfViaInc" runat="server" />
        <asp:HiddenField ID="hfUrbInc" runat="server" />
        <asp:HiddenField ID="hfIntInc" runat="server" />
        <asp:HiddenField ID="hfNombreLlam" runat="server" />
        <asp:HiddenField ID="hfTipoDocIde" runat="server" />
        <asp:HiddenField ID="hfUbica" runat="server" />
        <asp:HiddenField ID="hdTipoAccion" runat="server" />
        <asp:HiddenField ID="hfGeoX" runat="server" />
        <asp:HiddenField ID="hfGeoY" runat="server" />
        <asp:HiddenField ID="hfGeoLat" runat="server" />
        <asp:HiddenField ID="hfGeoLon" runat="server" />
        <asp:HiddenField ID="hfCodFoto" runat="server" />
        
    </div>
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
        var codCAT = '<%= txtCodCat.ClientID %>';

        var coorLon = '<%= hfGeoLon.ClientID %>';
        var coorLat = '<%= hfGeoLat.ClientID %>';
        var codFoto = '<%= hfCodFoto.ClientID %>';


        var coordefX = 283750.72514027;
        var coordefY = 8657312.3445717;

        var map;
        var markers;
        var vSelecc = null;
        var vecLayerCS;
        var matrizCalles = [];
        var matrizPersona = [];

        //var vSERVER = "http://serviciosgis.munisurco.gob.pe:70/geoserver/CM150140/wms";
        //var vFOTOS = "http://serviciosgis.munisurco.gob.pe:70/multimedia/fotos/catastro/2012/";

        var vSERVER = "http://192.0.0.92:8080//geoserver/CM150140/wms";
        //var vFOTOS = "http://192.0.0.92:8080//multimedia/fotos/catastro/2012/";

        var vFOTOS = "http://192.0.0.145/imagenes/foto/";

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
                    geoReferencia(lonlat.lon, lonlat.lat);

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

            var sc = new OpenLayers.Layer.WMS("Limite Cuadrantes", vSERVER,
                                    {
                                        srs: 'EPSG:32718',
                                        layers: 'map_cuadrante',
                                        transparent: true
                                    }, { isBaseLayer: false, visibility: false }
                                    );


            map = new OpenLayers.Map({
                div: "divMap",
                /*layers: [wms, lote, clote, sc],*/
                layers: [wms, sc],
                maxExtent: new OpenLayers.Bounds(275000.000, 8645389.716, 288750.000, 8664783.095),
                projection: new OpenLayers.Projection("EPSG:32718"),
                displayProj: new OpenLayers.Projection("EPSG:32718"),
                zoom: 1,
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
                geoReferencia(vPtoX, vPtoY)
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



        function posicionInicial() {
            //var coordefX = 283077.5083247;
            //var coordefY = 8659148.5249411;
            var center = new OpenLayers.LonLat(coordefX, coordefY);
            map.setCenter(center, 6);
            MapMarker(coordefX, coordefY);

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

            //console.log('X:' + x);
            //console.log('Y:' + y);

            vecLayerCS.removeAllFeatures();
            var iMarker = 'img/marker.GIF';
            var feature = new OpenLayers.Feature.Vector(
                new OpenLayers.Geometry.Point(x, y),
                { description: "<h1>Componente</h1>" },
                { externalGraphic: iMarker, graphicHeight: 24, graphicWidth: 24, graphicXOffset: -12, graphicYOffset: -24 }
            );
            //console.log(feature);
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

        function geoReferencia(xGeo, yGeo) {
            var webMethod = "WebServiceGEO.asmx/buscaUbicacionXY";
            console.log(xGeo);
            console.log(yGeo);
            $.ajax({
                type: "POST",
                async: true,
                url: "WebServiceGEO.asmx/buscaUbicacionXY",
                data: "{'pX':'" + xGeo + "','pY':'" + yGeo + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var punto = response.d;
                    console.log(punto);
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

                    document.getElementById(coorLon).value = punto.nLon;
                    document.getElementById(coorLat).value = punto.nLat;
                    document.getElementById(codFoto).value = punto.cFotoLote;

                    if (punto.cFotoLote != null) {

                        txtHTML = "<img id='imgprev' src='" + punto.cFotoLote + "' border='1' height='480' width='100%' onerror=this.src='img/nodisponible.gif'; />";
                        if (txtHTML != null) {
                            document.getElementById("divFoto").innerHTML = txtHTML;
                        }
                    }
                },
                error: function (XMLHttpRequest, textStatus, error) { alert('ERROR:' + error); },
            });          //fin llamada ajax

        }

    </script>
    <script language="javascript" type="text/javascript">
        function ValidarGrabar() {

            if (document.getElementById('<%= txtViaInc.ClientID %>').value == '') {
                alert('Ingrese el Nombre de la Via !!!!.')
                return false
            }


            if (document.getElementById('<%= ddlOrigen.ClientID %>').value == 0) {
                alert('Seleccione el origen.')
                return false
            }

            if (document.getElementById('<%= txtNumero.ClientID %>').value == '') {
                alert('Ingrese el Numero de origen.')
                return false
            }

            if (document.getElementById('<%= ddlTipoPersona.ClientID %>').value == 0) {
                alert('Seleccione el tipo de persona.')
                return false
            }

            if (!document.getElementById('<%= chkAnonimo.ClientID %>').checked) {
                if (document.getElementById('<%= txtNombre.ClientID %>').value == '') {
                    alert('Ingrese el Nombre del Informante.')
                    return false
                }

                //               if (document.getElementById('<%= ddlTipoDocInf.ClientID %>').value == 0) {
                //                   alert('Seleccione el tipo de documento de identidad.')
                //                   return false
                //               }

            }


            if (document.getElementById('<%= txtRelato.ClientID %>').value == '') {
                alert('Ingrese el Relato.')
                return false
            }


            if (document.getElementById('<%= ddlTipoInc.ClientID %>').value == 0) {
                alert('Seleccione el tipo de incidente.')
                return false
            }

            if (document.getElementById('<%= ddlSubTipoInc.ClientID %>').value == 0) {
                alert('Seleccione el subtipo de incidente.')
                return false
            }

            if (document.getElementById('<%= ddlPrioridad.ClientID %>').value == 0) {
                alert('Seleccione la prioridad.')
                return false
            }

            if (document.getElementById('<%= ddlAccionOperador.ClientID %>').value == 0) {
                alert('Indique el ESTADO de la INCIDENCIA(CARTA)  !!!')
                return false
            }

            if (document.getElementById('<%= ddlDerivarGrupo.ClientID %>').value == 0) {
                alert('Indique el ROL para Derivar la INCIDENCIA(CARTA)  !!!')
                return false
            }


            if (document.getElementById('<%= hfGeoX.ClientID %>').value == '') {
                alert('Debe referenciar Incidencia, Verifique en el Mapa!!!')
                return false
            }

            if (document.getElementById('<%= hfGeoY.ClientID %>').value == '') {
                alert('Debe referenciar Incidencia, Verifique en el Mapa!!!')
                return false
            }


            return confirm('Estas seguro(a) GUARDAR información?', 'SADE');
        }

        function cerrarpagina() {
            window.close();
            return false;
        }

        function PlaySound() {
            var sound = document.getElementById('sound1');
            sound.Play();
        }

    </script>

    </form>
</body>
</html>
