
<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="frmGestionaIncF911.aspx.vb" Inherits="frmGestionaIncF911" EnableEventValidation="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <%--    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?v=3.exp&sensor=false&libraries=places"></script>--%>
    <script src="jBeep/jBeep.min.js" type="text/javascript"></script>

    <script type="text/javascript">
//    $(document).ready(function () {
//        $('#right_menu').sidr({
//            name: 'sidr',
//            speed: 200,
//            side: 'right',
//            source: null,
//            renaming: true,
//            body: 'body'
//        });
//    });

    function popupMostrarMapa(CodCat, Lat, Lon) {
        document.getElementById('vermapita').style.display = 'block'; 
        document.getElementById('fade').style.display = 'block';

        var img = new google.maps.MarkerImage("img/marker.gif");

        var latlng = new google.maps.LatLng(Lat, Lon);
        var myOptions = {
            zoom: 16,
            center: latlng,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);
        var marker = new google.maps.Marker({
            position: latlng,
            map: map,
            title: 'Ubicación',
            icon: img
        });

    }


    function popupDerivarAlerta(pURL) {
        var setting = "directories=no,height=640,left=10,location=no,menubar=no,resizable=no,scrollbars=yes,status=no,toolbar=no,top=10,width=900";
        window.open(pURL, "Derivar Alerta SIAVE", setting);
    }

    function popupMostrarAdjunto(pID) {
        var txtpth = '<%= System.Configuration.ConfigurationManager.AppSettings("RUTA_IMAGEN_WEB") %>';
        var txturl = txtpth + pID + ".jpg";
        console.log(txturl);               
        document.getElementById('verimagen').style.display = 'block';
        document.getElementById('fade').style.display = 'block';
        document.getElementById('imgFoto').src = txturl;
    }


    function popupEscucharAudio(pID) {

        if (pID) {
            var url = 'frmAudioIncidencia.aspx?pID=' + pID;
            var setting = "directories=no,height=100,left=10,location=no,menubar=no,resizable=no,scrollbars=yes,status=no,toolbar=no,top=10,width=400";
            window.open(url, "Audio Incidente", setting);
        }
        else {
            alert("Incidente no tiene Audio disponible!!!");
        }
    }

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

    function muestraCalle() {
        console.log("prueba de entra");
        document.getElementById('divCalles').style.display = 'block';
        document.getElementById('fade').style.display = 'block';
    }

    function muestraPerEnc() {
        console.log("prueba de Encargado");
        document.getElementById('divPerEnc').style.display = 'block';
        document.getElementById('fade').style.display = 'block';
    }

    function muestraPerSup() {
        console.log("prueba de Supervisor");
        document.getElementById('divPerSup').style.display = 'block';
        document.getElementById('fade').style.display = 'block';
    }


</script>

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

        .white_content_img
        {
            display: none;
            position: absolute;
            top: 10%;
            left: 25%;
            width: 50%;
            padding: 0px;
            border: 0px solid #a6c25c;
            background-color: white;
            z-index: 1002;
            overflow: auto;
        }

	    
        .white_content_map
        {
            display: none;
            position: absolute;
            top: 10%;
            left: 15%;
            width: 70%;
            padding: 0px;
            border: 0px solid #a6c25c;
            background-color: white;
            z-index: 1002;
            overflow: auto;
        }
	    
	    .white_content {
		    display:none;
		    position: absolute;
		    top: 25%;
		    left: 35%;
		    width: 30%;
    		
		    padding: 0px;
		    border: 0px solid #a6c25c;
		    background-color: white;
		    z-index:1002;
		    overflow: auto;
	    }	

	    .white_content_h {
		    display:none;
		    position: absolute;
		    top: 25%;
		    left: 20%;
		    width: 60%;
    		
		    padding: 0px;
		    border: 0px solid #a6c25c;
		    background-color: white;
		    z-index:1002;
		    overflow: auto;
	    }	

	    .white_content_r {
		    display:none;
		    position: absolute;
		    top: 15%;
		    left: 20%;
		    width: 60%;
    		
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
        #pnlRecurso
        {
         width : 20%;
         float:left;
         margin-top :0px;         
        }
        #pnlResultado 
        {
         width : 78%;
         float:left;
         margin-left :1%;
         margin-right :1%;
        }	
        #pnlBotonera
        {
         width : 100%;
         float:left;
        }        
        
        .LlamadaEntrante
        {
	        position: absolute;
	        height: 15px;
	        width: 150px;
	        top: 7px;
	        left: 75%;
        }
        .btnLlamadaEntrante
        {
	        height: 50px;
	        width: 150px;
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

        div#map_canvas {
          width:100%;
          height:100%;
        }

        div#foto {
         position: relative;
          width:100%;  
          height:500px;
          margin-top: 0px;
          margin-bottom:0px;
          border-top: 1px solid #333;
          border-bottom: 2px solid #333;
        }

        </style>  

    <link href="Styles/accordionmenu.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" 
    EnableScriptGlobalization="True" EnableScriptLocalization="False" />
<div>
    <script type="text/javascript" src="http://openlayers.org/api/OpenLayers.js"></script>
<asp:Panel ID="pnlBusqueda" runat="server">  
    <div id="busqueda" class="busqueda">
        
        <table style="width: 100%" class="Tabla">
            <colgroup>
                <col style="width: 2%" />
                <col style="width: 10%" />
                <col style="width: 14%" />
                <col style="width: 10%" />
                <col style="width: 14%" />
                <col style="width: 10%" />
                <col style="width: 14%" />
                <col style="width: 10%" />
                <col style="width: 14%" />
                <col style="width: 2%" />
            </colgroup>
            <tr>
                <td colspan="10" style="height: 10px;"></td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    Nº&nbsp; Incidente</td>
                <td>
                    <asp:TextBox ID="txtNumeroInc" runat="server" Width="90%" CssClass="CajaTexto"></asp:TextBox>
                </td>
                <td>
                    Telefóno</td>
                <td>
                    <asp:TextBox ID="txtTelefonoInc" runat="server" CssClass="CajaTexto" 
                        Width="90%"></asp:TextBox>
                </td>
                <td>
                    Tipo
                </td>
                <td>
                    <asp:DropDownList ID="ddlTipoInc" runat="server" Width="90%" 
                        AutoPostBack="True" CssClass="CajaCombo">
                    </asp:DropDownList>
                </td>
                <td>
                    Subtipo
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlSubtipoInc" runat="server" CssClass="CajaCombo" 
                                Width="90%">
                            </asp:DropDownList>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlTipoInc" 
                                EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    Origen</td>
                <td>
                    <asp:DropDownList ID="ddlOrigenInc" runat="server" Width="90%" 
                        CssClass="CajaCombo">
                    </asp:DropDownList>
                </td>
                <td>
                    Prioridad</td>
                <td>
                    <asp:DropDownList ID="ddlPrioridadInc" runat="server" Width="90%" 
                        CssClass="CajaCombo">
                    </asp:DropDownList>
                </td>
                <td>
                    Estado </td>
                <td>
                    <asp:DropDownList ID="ddlEstadoInc" runat="server" CssClass="CajaCombo" 
                        Width="90%">
                    </asp:DropDownList>
                </td>
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
                    Informante
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtInformanteInc" runat="server" CssClass="CajaTexto" 
                        Width="90%"></asp:TextBox>
                </td>
                <td>
                    Nombre de Via</td>
                <td colspan="3">
                    <asp:TextBox ID="txtViaInc" runat="server" CssClass="CajaTexto" Width="90%"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    Relato</td>
                <td colspan="3">
                    <asp:TextBox ID="txtRelatoInc" runat="server" CssClass="CajaTexto" Width="90%"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
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
                    <asp:RadioButton ID="rbtUtlimaSemana" runat="server" Checked="True" 
                        GroupName="Consulta" Text="Ultima Semana" AutoPostBack="True" />
                </td>
                <td>
                    <asp:RadioButton ID="rbtTodo" runat="server" GroupName="Consulta" 
                        Text="Rango de Fechas" AutoPostBack="True" />
                </td>
                <td>
                    <asp:Label ID="lblFecInicio" runat="server" Text="Desde" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFechaInicio" runat="server" CssClass="CajaTexto"
                        Width="70px" Visible="False"></asp:TextBox>
                    <cc1:MaskedEditExtender ID="meetxtFechaInicio" 
                        runat="server" Mask="99/99/9999"
                        MaskType="Date" TargetControlID="txtFechaInicio">
                    </cc1:MaskedEditExtender>
                    <cc1:CalendarExtender ID="cetxtFechaInicio" runat="server" CssClass="calendario"
                        Format="dd/MM/yyyy" PopupButtonID="Image1" 
                        TargetControlID="txtFechaInicio">
                    </cc1:CalendarExtender>
                    <asp:RegularExpressionValidator ID="revtxtFechaInicio" runat="server" ControlToValidate="txtFechaInicio"
                        ErrorMessage="* Fecha inicio inválida" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"
                        Visible="False" ForeColor="Red"></asp:RegularExpressionValidator>
                </td>
                <td>
                    <asp:Label ID="lblFecFinal" runat="server" Text="Hasta" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFechaFinal" runat="server" CssClass="CajaTexto"
                        Width="70px" Visible="False"></asp:TextBox>
                    <cc1:MaskedEditExtender ID="meetxtFechaFinal" 
                        runat="server" Mask="99/99/9999"
                        MaskType="Date" TargetControlID="txtFechaFinal">
                    </cc1:MaskedEditExtender>
                    <cc1:CalendarExtender ID="cetxtFechaFinal" runat="server" CssClass="calendario"
                        Format="dd/MM/yyyy" PopupButtonID="Image1" 
                        TargetControlID="txtFechaFinal">
                    </cc1:CalendarExtender>
                    <asp:RegularExpressionValidator ID="revtxtFechaFinal" 
                        runat="server" ControlToValidate="txtFechaFinal"
                        ErrorMessage="* Fecha final inválida" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"
                        Visible="False" ForeColor="Red"></asp:RegularExpressionValidator>
                </td>
                <td>
                    </td>
                <td>
                    <asp:Button ID="btnBuscar" runat="server" Text="  Buscar   " CssClass="boton_busca" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    </td>
                <td>
                    &nbsp;</td>
            </tr>
            </table>
    </div>
    <div id="pnlBotonera" class="redondear">
        <table style="width: 100%;" class="Tabla">
            <tr>
                <td colspan="10">
                    &nbsp;<asp:Button ID="btnReferencia" runat="server" Text="Modificar" 
                        CssClass="boton_dialogo"  OnClientClick="cambiarvalor()" Visible="False" />
                    &nbsp;<asp:Button ID="btnVisualizar" runat="server" Text="Visualizar"
                        CssClass="boton_dialogo"  OnClientClick="cambiarvalor()" Visible="False" />
                    &nbsp;&nbsp;<asp:Button ID="btnExportar" runat="server" Text="Exportar" 
                        CssClass="boton_dialogo" Visible="False"  OnClientClick="cambiarvalor()" />
                    </td>
            </tr>
            <tr>
                <td colspan="10" align="center">
                    <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="#CC0000"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>

        <asp:GridView ID="gvDatos" runat="server" CssClass="Grid" AlternatingRowStyle-CssClass="GridAlternateRow"
            HeaderStyle-CssClass="GridHeader" PagerStyle-CssClass="GridFooter" RowStyle-CssClass="GridRow"
            AllowPaging="True" AutoGenerateColumns="False" Width="100%" 
                
                DataKeyNames="INTINCCODIGO,INTINCROLDERIVADO,SMLINCESTADO,SMLORICODIGO,VCHMOTIVOALERTA,VCHINCDOCUMENTO,VCHINCIDLATITUDE,VCHINCIDLONGITUDE" 
                PageSize="7">
            <RowStyle CssClass="GridRow"></RowStyle>
            <Columns>
                <asp:TemplateField>
                    <itemtemplate>
                        <img id="imgTipo<%# Eval("INTINCCODIGO") %>" alt="<%#Eval("VCHINCRELATO")%>" src="img/origen/tipo<%#Eval("SMLORICODIGO")%>.png" />
                    </itemtemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Id" DataField="INTINCCODIGO"/>
                <asp:BoundField HeaderText="Fecha Hora" DataField="DTMINCFECHA"/>
                <asp:BoundField HeaderText="Origen" DataField="SMLORICODIGO" Visible="False"/>
                <asp:BoundField HeaderText="Origen" DataField="VCHORIDESCRIPCION"/>    
                <asp:BoundField HeaderText="Número" DataField="VCHINCNUMEROORIGEN"/>
                <asp:BoundField HeaderText="Paq" DataField="INTPAQCODIGO"/>    
                <asp:BoundField HeaderText="Id Tipo" DataField="SMLTINCODIGO" Visible="False"/>
                <asp:BoundField HeaderText="Tipo" DataField="VCHTINDESCRIPCION"/>
                <asp:BoundField HeaderText="id SubTipo" DataField="SMLSTICODIGO" Visible="False"/>
                <asp:BoundField HeaderText="Subtipo" DataField="VCHSTIDESCRIPCION"/>
                <asp:BoundField HeaderText="Est" DataField="SMLINCESTADO" Visible="False"/>
                <asp:BoundField HeaderText="Estado" DataField="VCHINCESTADO"/>
                <asp:TemplateField HeaderText="Informante / Localización">
                    <itemtemplate>
                    <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("VCHINCNOMBRECOMP") %>' ></asp:Label><br/>
                    <asp:Label ID="lblUbicat" runat="server" Text='<%# Eval("VCHINCLOCCOMENTARIO") %>' Font-Size="XX-Small"></asp:Label>
                    </itemtemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Asoc." DataField="INTINCACODIGO"/>
                <asp:BoundField HeaderText="Pri" DataField="SMLPRICODIGO" Visible="False"/>
                <asp:BoundField HeaderText="Prioridad" DataField="VCHPRIDESCRIPCION"/>
                <asp:BoundField HeaderText="Cdte" DataField="VCHINCLOCCUADRANTE" Visible="True"/>
                <asp:BoundField HeaderText="Sctr" DataField="VCHINCLOCSECTOR" Visible="True"/>

                <asp:BoundField HeaderText="Rol Derivado" DataField="INTINCROLDERIVADO" Visible="False"/>
                <asp:BoundField HeaderText="Fec Derivado" DataField="DTMINCFECDERIVADO" Visible="False"/>
                <asp:BoundField HeaderText="Asociado" DataField="INTINCACODIGO" Visible="False"/>
                <asp:BoundField HeaderText="Administrado" DataField="INTADMCODIGO" Visible="False"/>
                <asp:BoundField HeaderText="Predio" DataField="INTPRECODIGO" Visible="False"/>
                <asp:BoundField HeaderText="Lat" DataField="VCHINCIDLATITUDE" Visible="False"/>
                <asp:BoundField HeaderText="Lon" DataField="VCHINCIDLONGITUDE" Visible="False"/>
                <asp:BoundField HeaderText="Parte" DataField="VCHPINCODIGO" Visible="False"/>
                <asp:BoundField HeaderText="CodCat" DataField="VCHCATCODIGO" Visible="False"/>
            </Columns>
            <PagerStyle CssClass="GridFooter"></PagerStyle>
            <EmptyDataTemplate>
                <asp:Label ID="Label37" runat="server" Text="No existen registros para mostrar" CssClass="Tabla"></asp:Label>
            </EmptyDataTemplate>
            <HeaderStyle CssClass="GridHeader"></HeaderStyle>
            <AlternatingRowStyle CssClass="GridAlternateRow"></AlternatingRowStyle>
            <SelectedRowStyle  CssClass = "GridSeletedRow" />
        </asp:GridView>
        <asp:HiddenField ID="hfIncidente" runat="server" />
        <asp:HiddenField ID="hfregistro" runat="server" />
        </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="gvDatos" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="gvDatos" EventName="PageIndexChanging" />
                <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>

    </div>
</asp:Panel>
    <div id="mensaje" class="white_content">
        <table width="100%" class="Tabla">
            <colgroup valign="top">
                <col width="4%" />
                <col width="18%" />
                <col width="20%" />
                <col width="20%" />
                <col width="15%" />
                <col width="21%" />
                <col width="2%" />
            </colgroup>
            <tr>
                <td style="background-color: #f0f0f0">
                </td>
                <td style="background-color: #f0f0f0; vertical-align: middle; text-align: center;"
                    colspan="5">
                    <asp:Label ID="Label12" runat="server" Font-Size="Small" Font-Bold="True">Mensaje del sistema</asp:Label>
                </td>
                <td style="background-color: #f0f0f0; vertical-align: middle;">
                    <a href="javascript:void(0)" onclick="document.getElementById('detalle').style.display='none';document.getElementById('fade').style.display='none'">
                        <img src="img/Close.gif" style="border: 0px" align="right" /></a>
                </td>
            </tr>
            <tr>
                <td colspan="7" style="height: 20px;">
                </td>
            </tr>
            <tr class="titulo">
                <td colspan="7" style="text-align: center">
                    <asp:Label ID="lblMensajeSistema" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="7" style="height: 20px;">
                </td>
            </tr>
            <tr>
                <td colspan="7" style="height: 20px; vertical-align: middle; text-align: center;">
                    <asp:Button ID="btnRedirecciona" runat="server" CssClass="boton_busca" Text="    Aceptar    " />
                </td>
            </tr>
            <tr>
                <td colspan="7" style="height: 10px;">
                </td>
            </tr>
        </table>
    </div>

    


</div>


<asp:Panel ID="pnlEdicion" runat="server" Visible="False" Width ="100%">
    <table width="100%" cellpadding="0px" cellspacing="0px" >
        <colgroup>
            <col width="45%" />
            <col width="50%" />
            <col width="0%" />
        </colgroup>
        <tr>
            <td>
                <div id="divEdicion">
                    <table class="Tabla" style="width: 100%">
                        <colgroup>
                            <col style="width: 5%" />
                            <col style="width: 1%" />
                            <col style="width: 5%" />
                            <col style="width: 90%" />
                        </colgroup>
                        <tr>
                            <td align="center" valign="middle">
                                <asp:Button ID="btnGrabar" runat="server" Text=" Grabar " CssClass="boton_dialogo"
                                    OnClientClick="{ cambiarvalor();  javascript:return confirm('¿ESTA SEGURO DE REALIZAR LA OPERACION?','SADE');}" />
                            </td>
                            <td>
                            </td>
                            <td align="center" valign="middle">
                                <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="boton_dialogo" OnClientClick="cambiarvalor()" />
                                &nbsp;&nbsp;
                            </td>
                            <td align="center" valign="middle">
                                &nbsp;</td>
                        </tr>
                    </table>
                </div>
                <div id="pnlPuestoFijo" class="busqueda" runat="server">
                <table width="98%" class="Tabla">
                    <colgroup>
                        <col width="2%" />
                        <col width="10%" />
                        <col width="14%" />
                        <col width="10%" />
                        <col width="14%" />
                        <col width="10%" />
                        <col width="14%" />
                        <col width="10%" />
                        <col width="14%" />
                        <col width="2%" />
                    </colgroup>
                    <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    </tr>

                    <tr>
                        <td>
                        </td>
                        <td>
                            Id</td>
                        <td>                            
                            <asp:TextBox ID="txtNumeroIncEdi" runat="server" CssClass="CajaTexto" 
                                MaxLength="15" placeholder="Número de dispositivo" Width="90%"></asp:TextBox>
                            
                        </td>
                        <td>
                            <asp:TextBox ID="txtPreviasIncEdi" runat="server" CssClass="CajaTexto" 
                                Enabled="False" MaxLength="15" Width="85%"></asp:TextBox>
                        </td>
                        <td>
                            Fecha</td>
                        <td colspan="2">
                            <asp:TextBox ID="txtFechaIncEdi" runat="server" CssClass="CajaTexto" 
                                Width="90%"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUsuCreaIncEdi" runat="server" CssClass="CajaTexto" Enabled="false" 
                                    Width="90%"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUsuModIncEdi" runat="server" CssClass="CajaTexto" Enabled="false" 
                                    Width="90%"></asp:TextBox>
                        </td>

                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            Tipo</td>
                        <td colspan="3">
                            <asp:DropDownList ID="ddlTipoIncEdi" runat="server" AutoPostBack="True" 
                                CssClass="CajaTextoObligatorio" Width="95%">
                            </asp:DropDownList>
                        </td>
                        <td>
                            Subtipo</td>
                        <td colspan="3">
                            <asp:UpdatePanel ID="upSubTipoInc" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlSubtipoIncEdi" runat="server" AutoPostBack="True" 
                                        CssClass="CajaTextoObligatorio" Width="95%">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlTipoIncEdi" 
                                        EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            Prioridad</td>
                        <td colspan="2">
                            <asp:DropDownList ID="ddlPrioridadIncEdi" runat="server" CssClass="CajaTextoObligatorio" 
                                Width="95%">
                            </asp:DropDownList>
                        </td>
                        <td>
                            Origen</td>
                        <td colspan="2">
                            <asp:DropDownList ID="ddlOrigenIncEdi" runat="server" CssClass="CajaTextoObligatorio" 
                                Width="95%">
                            </asp:DropDownList>
                        </td>
                        <td>No.Telefono</td>
                        <td>
                            <asp:TextBox ID="txtNumTelIncEdi" runat="server" CssClass="CajaTexto" Enabled="False" 
                            Width="90%"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td colspan="2">
                            <asp:CheckBox ID="chkAnonimoIncEdi" runat="server" AutoPostBack="True" 
                                CssClass="CajaTexto" onchange="anonimo(this);" Text="No se identifica" />
                        </td>
                        <td>
                            Tp.Per</td>
                        <td>
                            <asp:DropDownList ID="ddlTipoPersonaIncEdi" runat="server" CssClass="CajaTextoObligatorio" 
                                Width="95%">
                            </asp:DropDownList>
                        </td>
                        <td>Tp.Doc.</td>
                        <td>
                            <asp:DropDownList ID="ddlTipoDocIncEdi" runat="server" CssClass="CajaCombo" 
                                Width="80%">
                            </asp:DropDownList>
                        </td>
                        <td>No.Doc.</td>
                        <td>
                            <asp:TextBox ID="txtNumDocIncEdi" runat="server" CssClass="CajaTextoObligatorio" 
                                MaxLength="20" Width="80%"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            Nombre</td>
                        <td colspan="5">
                            <asp:TextBox ID="txtNombreIncEdi" runat="server" CssClass="CajaTextoObligatorio" 
                                Width="95%"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            </td>
                        <td>
                            Calle/Via</td>
                        <td colspan="3">
                            <asp:TextBox ID="txtCalleIncEdi" runat="server" CssClass="CajaTextoObligatorio" 
                                MaxLength="150" Width="80%"></asp:TextBox>
                                <input id="busCalle" type="button" value="..." onclick="muestraCalle()" />
                        </td>
                        <td>Cdra.</td>
                        <td>
                            <asp:TextBox ID="txtCdraIncEdi" runat="server" CssClass="CajaTextoObligatorio" 
                                MaxLength="10" Width="80%"></asp:TextBox>
                        </td>
                        <td>Nº.</td>
                        <td>
                            <asp:TextBox ID="txtNroIncEdi" runat="server" CssClass="CajaTextoObligatorio" 
                                MaxLength="10" Width="80%"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            Mza. Lte.</td>
                        <td>
                            <asp:TextBox ID="txtMzaIncEdi" runat="server" CssClass="CajaTextoObligatorio" 
                                MaxLength="10" Width="35%"></asp:TextBox>  
                            <asp:TextBox ID="txtLteIncEdi" runat="server" CssClass="CajaTextoObligatorio" 
                                MaxLength="10" Width="35%"></asp:TextBox>
                        </td>
                        <td>

                            Dpto.</td>
                        <td>
                            <asp:TextBox ID="txtDptoIncEdi" runat="server" CssClass="CajaTextoObligatorio" 
                                MaxLength="10" Width="80%"></asp:TextBox>
                        </td>
                        <td>
                            Refer.</td>
                        <td colspan="3">
                            <asp:TextBox ID="txtComIncEdi" runat="server" CssClass="CajaTextoObligatorio" 
                                MaxLength="200" placeholder="Referencia" Width="90%"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            Hab.</td>
                        <td colspan="3">
                            <asp:TextBox ID="txtUrbIncEdi" runat="server" CssClass="CajaTextoObligatorio" 
                                MaxLength="100" placeholder="Urbanizacion" Width="90%"></asp:TextBox>
                        </td>
                        <td>
                            Sector</td>
                        <td>
                            <asp:TextBox ID="txtSectorIncEdi" runat="server" CssClass="CajaTextoObligatorio" 
                                Enabled="False" MaxLength="15" placeholder="Sector" Width="90%"></asp:TextBox>
                        </td>
                        <td>
                            Cuadrante.</td>
                        <td>
                            <asp:TextBox ID="txtCuadranteIncEdi" runat="server" CssClass="CajaTextoObligatorio" 
                                Enabled="False" MaxLength="15" placeholder="Cuadrante" Width="90%"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            Relato</td>
                        <td colspan="7">
                            <asp:TextBox ID="txtRelatoIncEdi" runat="server" CssClass="CajaTextoObligatorio" Height="60px" 
                                TextMode="MultiLine" Width="98%"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            Sereno</td>
                        <td colspan="3">
                            <asp:TextBox ID="txtNomPerEnc" runat="server" CssClass="CajaTextoObligatorio" 
                                MaxLength="150" Width="80%"></asp:TextBox>
                            <input id="busPerEnc" type="button" value="..." onclick="muestraPerEnc()" />
                        </td>
                        <td>
                            Supervisor</td>
                        <td colspan="3">
                            <asp:TextBox ID="txtNomPerSup" runat="server" CssClass="CajaTextoObligatorio" 
                                MaxLength="150" Width="80%"></asp:TextBox>
                            <input id="busPerSup" type="button" value="..." onclick="muestraPerSup()" />
                        </td>

                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>Turno</td>
                        <td colspan="2">
                            <asp:DropDownList ID="ddlTurnoIncEdi" runat="server" CssClass="CajaTextoObligatorio" 
                                Width="80%">
                            </asp:DropDownList>
                        </td>
                        <td>Objetivo</td>
                        <td colspan="2">
                            <asp:DropDownList ID="ddlObjetivoIncEdi" runat="server" CssClass="CajaTextoObligatorio" 
                                Width="80%">
                            </asp:DropDownList>
                        </td>
                        <td>Modalidad</td>
                        <td>
                            <asp:DropDownList ID="ddlModalidadIncEdi" runat="server" CssClass="CajaTextoObligatorio" 
                                Width="80%">
                            </asp:DropDownList>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            Intervenidos</td>
                        <td colspan="2">
                            <asp:DropDownList ID="ddlDetenidosIncEdi" runat="server" CssClass="CajaTextoObligatorio" 
                                Width="80%">
                            </asp:DropDownList>
                        </td>
                        <td>
                            Fuga</td>
                        <td colspan="2">
                            <asp:DropDownList ID="ddlFugaIncEdi" runat="server" CssClass="CajaTextoObligatorio" 
                                Width="80%">
                            </asp:DropDownList>
                        </td>
                        <td>
                            Denuncia</td>
                        <td>
                            <asp:DropDownList ID="ddlDenunciaIncEdi" runat="server" CssClass="CajaTextoObligatorio" 
                                Width="80%">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            Tipo Delito</td>
                        <td colspan="2">
                            <asp:DropDownList ID="ddlDelitoIncEdi" runat="server" 
                                CssClass="CajaTextoObligatorio" Width="80%">
                            </asp:DropDownList>
                        </td>
                        <td>
                            Consecuencias</td>
                        <td colspan="4">
                            <asp:TextBox ID="txtConsecuenciaIncEdi" runat="server" 
                                CssClass="CajaTextoObligatorio" Width="98%"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            Fec.Hora</td>
                        <td colspan="3">
                            <asp:TextBox ID="txtFechaAteIncEdi" runat="server" 
                                CssClass="CajaTextoObligatorio" Visible="true" Width="90%"></asp:TextBox>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" 
                                AcceptAMPM="True" Mask="99/99/9999 99:99:99" MaskType="DateTime" 
                                TargetControlID="txtFechaAteIncEdi">
                            </cc1:MaskedEditExtender>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="center" colspan="8">
                            <asp:Label ID="lblMensajeReg" runat="server" ForeColor="#CC0000" Text=""></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
               </div>

            </td>
            <td>&nbsp;
                <div id="divMap" style="width:800px; height:500px; border: 1px solid #ccc;" >
                </div>
            </td>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
        <td></td>
        <td></td>
        <td></td>
        </tr>
    </table>
    <asp:HiddenField ID="hdTipoAccion" runat="server" />
    <asp:HiddenField ID="hfGeoY" runat="server" />
    <asp:HiddenField ID="hfGeoX" runat="server" />
    <asp:HiddenField ID="hfCodPerEncEdi" runat="server" />
    <asp:HiddenField ID="hfCodPerSupEdi" runat="server" />
    <asp:HiddenField ID="hfCodViaIncEdi" runat="server" />
    <asp:HiddenField ID="hfCodHabUrbEdi" runat="server" />

    <div id="divCalles" style="height: 500px; border: 1px solid #ccc; z-index:9000;" class="white_content">
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
        <div id="divDataCalles" style="height: 450px; border: 1px solid #ccc; overflow: scroll;">
        </div>
    </div>

    <div id="divPerSup" style="height: 500px; border: 1px solid #ccc; z-index:9000;" class="white_content">
        <a href="javascript:void(0)" onclick="document.getElementById('divPerSup').style.display='none';document.getElementById('fade').style.display='none'">
            <img src="img/Close.gif" style="border: 0px" align="right" /></a>
        <div id="divFilterPerSup">
            <table id="Table1" style="width: 95%; padding-top: 10px; padding-bottom: 10px;
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
                        Supervisor
                    </td>
                    <td>
                        <input type="text" onkeyup="{ this.value=this.value.toUpperCase(); filterSupervisor(this); } "
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
        <div id="divDataPerSup" style="height: 450px; border: 1px solid #ccc; overflow: scroll;">
        </div>
    </div>

    <div id="divPerEnc" style="height: 500px; border: 1px solid #ccc; z-index:9000;" class="white_content">
        <a href="javascript:void(0)" onclick="document.getElementById('divPerEnc').style.display='none';document.getElementById('fade').style.display='none'">
            <img src="img/Close.gif" style="border: 0px" align="right" /></a>
        <div id="divFilterPerEnc">
            <table id="Table2" style="width: 95%; padding-top: 10px; padding-bottom: 10px;
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
                        Operador
                    </td>
                    <td>
                        <input type="text" onkeyup="{ this.value=this.value.toUpperCase(); filterSereno(this); } "
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
        <div id="divDataPerEnc" style="height: 450px; border: 1px solid #ccc; overflow: scroll;">
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
    var codPSup = '<%= hfCodPerSupEdi.ClientID %>';
    var nomPSup = '<%= txtNomPerSup.ClientID %>';
    var codPEnc = '<%= hfCodPerEncEdi.ClientID %>';
    var nomPEnc = '<%= txtNomPerEnc.ClientID %>';

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
            layers: [wms, lote, hurb, zona, sc, semaforo, modulo, locales, camara],
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
        mostrarPersonal();

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

    function mostrarPersonal() {
        var webMethod = "WebServiceGPS.asmx/listaPersonal";
        $.ajax({
            type: "POST",
            url: webMethod,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var lista = response.d;
                var txtHTMLSUP;
                var txtHTMLENC;
                var txtINFO;
                txtHTMLSUP = "";
                txtHTMLENC = "";
                i = 0;
                $.each(lista, function (index, pan) {
                    matrizPersona[i] = new Array(2);
                    matrizPersona[i][0] = pan.codPersona;
                    matrizPersona[i][1] = pan.nomPersona;
                    matrizPersona[i][2] = pan.crgPersona;

                    txtHTMLSUP += "<li><a href='javascript:MapPersonaSup(" + i + ");'>";
                    txtHTMLSUP += "" + pan.nomPersona + " (" + pan.crgPersona + ")</a></li>";

                    txtHTMLENC += "<li><a href='javascript:MapPersonaEnc(" + i + ");'>";
                    txtHTMLENC += "" + pan.nomPersona + " (" + pan.crgPersona + ")</a></li>";

                    i++;
                });

                if (txtHTMLSUP != null) {
                }
                document.getElementById("divDataPerSup").innerHTML = "<ul id='ListSuper' class='accordionS'>" + txtHTMLSUP + "</ul>";
                document.getElementById("divDataPerEnc").innerHTML = "<ul id='ListSereno' class='accordionS'>" + txtHTMLENC + "</ul>";

            },
            error: function (XMLHttpRequest, textStatus, error) { console.log(textStatus); alert('ERROR:' + error); }
        });        //fin llamada ajax
    }


    function MapPersonaEnc(i) {
        document.getElementById(codPEnc).value = matrizPersona[i][0];
        document.getElementById(nomPEnc).value = matrizPersona[i][1];

        document.getElementById('divPerEnc').style.display = 'none';
        document.getElementById('fade').style.display = 'none';
    }

    function MapPersonaSup(i) {
        document.getElementById(codPSup).value = matrizPersona[i][0];
        document.getElementById(nomPSup).value = matrizPersona[i][1];

        document.getElementById('divPerSup').style.display = 'none';
        document.getElementById('fade').style.display = 'none';
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

    function MapCalle(x, y,i ) {
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

    function filterSupervisor(element) {
        var value = $(element).val();
        $("#ListSuper > li").each(function () {
            if ($(this).text().search(value) > -1) {
                $(this).show();
            }
            else {
                $(this).hide();
            }
        });
    }

    function filterSereno(element) {
        var value = $(element).val();
        $("#ListSereno > li").each(function () {
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


                        
</asp:Content>

 