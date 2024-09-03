<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false"
    CodeFile="frmBuscaIncidencia.aspx.vb" Inherits="frmBuscaIncidencia" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="jBeep/jBeep.min.js" type="text/javascript"></script>
    <link rel="stylesheet" href="css/demos.css" type="text/css" />
    <link href="css/calendario.css" rel="stylesheet" type="text/css" />
    <link href="css/boton.css" rel="stylesheet" type="text/css" />
    <link href="css/grid2.css" rel="stylesheet" type="text/css" />
    <link href="css/controles.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        function Reporte() {
            var txtCODIGO = document.getElementById('<%= hfIncidente.ClientID %>');
            var setting = "directories=no,height=500,left=10,location=no,menubar=no,resizable=no,scrollbars=yes,status=no,toolbar=no,top=10,width=700";
            var txtURL = "Reportes/rpt/ReporteGenerico.aspx?pReporte=ReporteFormatoSADE&pINCCODIGO=" + txtCODIGO.value;
            window.open(pURL, "Reporte SADE", setting);
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


        //--  7	    A	NUEVO
        //--  8	    P	PARA DESPACHO
        //--  9	    D	DESPACHADO (CON RECURSO ASIGNADO)
        //--  10	X	DESCARTADO
        //--  11	F	ATENDIDO
        //--  12	C	CERRADO

        //    SUPERVISOR_CCO = 1
        //    TELEFONISTA = 2
        //    DESPACHADOR_SERENAZGO = 3
        //    OPERADOR_CAMARAS = 4
        //    OPERADOR_BOTON_ALERTA = 5
        //    DESPACHADOR_TRANSITO = 6
        //    DESPACHADOR_FISCALIZACION = 7
        //    DESPACHADOR_DEFENSA_CIVIL = 8

        function ValidarDespacho() {

            var intEST = document.getElementById('<%= hfINCESTADO.ClientID %>').value;
            var intROL = document.getElementById('<%= hfUSUROL.ClientID %>').value;

            //--  8	    P	PARA DESPACHO
            //--  9	    D	DESPACHADO (CON RECURSO ASIGNADO)
            if (intEST == 8 || intEST == 9) {  //VERIFICA ESTADO
            }
            else {
                alert('No es posible DESPACHAR Incidencia, Verifique ESTADO !!!')
                return false
            }

        }


        function ValidarCierre() {

            var intEST = document.getElementById('<%= hfINCESTADO.ClientID %>').value;
            var intROL = document.getElementById('<%= hfUSUROL.ClientID %>').value;

            if (!(intROL == 1)) {  // ROL SUPERVISOR
                alert('Usuario, No tiene asignado el ROL SUPERVISOR!!!')
                return false
            }

            // VERIFICA ESTADO : CERRADO
            if (intEST == 12) {  //ESTADO CERRADO
                alert('Verifique Incidencia ya esta CERRADA !!!')
                return false
            }

            // VERIFICA ESTADO : ATENDIDO o DESCARTADO
            if (intEST == 10 || intEST == 11) {  //ESTADO ATENDIDO o DESCARTADO
            }
            else {
                alert('No es posible CERRAR Incidencia, Verifique ESTADO !!!')
                return false
            }


        }

        function ValidarAtencion() {
            var intEST = document.getElementById('<%= hfINCESTADO.ClientID %>').value;
            var intROL = document.getElementById('<%= hfUSUROL.ClientID %>').value;

            //ESTADO NUEVO
            if (document.getElementById('<%= hfINCESTADO.ClientID %>').value != 7) {
                alert('No es posible Atender Incidencia, Verifique ESTADO !!!')
                return false
            }
            // ROL TELEFONISTA o BOTON ALERTA
            //        if (!(document.getElementById('<%= hfUSUROL.ClientID %>').value in [2,5])) { // ROL TELEFONISTA o OPERADOR BOTON ALERTA
            //            alert('No es posible Atender Incidencia, Verifique si tiene ROL TELEFONISTA u OPERADOR!!!')
            //            return false
            //        }
            //INCIDENTE ASIGNADO A ROL
            if (document.getElementById('<%= hfUSUROL.ClientID %>').value != document.getElementById('<%= hfINCROL.ClientID %>').value) {
                alert('No es posible Atender Incidencia, Verifique su ROL!!!')
                return false
            }
        }

        function popupMostrarMapa(pINC) {
            var posicion_x;
            var posicion_y;
            posicion_x = (screen.width / 2) - (950 / 2);
            posicion_y = (screen.height / 2) - (600 / 2);
            var url = 'frmIncidenciaMapa.aspx?pID=' + pINC;
            var setting = "directories=0,height=600,left=" + posicion_x + ",top=" + posicion_y + ",location=0,menubar=0,resizable=0,scrollbars=1,status=0,toolbar=0,width=950";
            window.open(url, "Titulo de la Ventana", setting);
        }


        function popupMostrarSAIVE(pDNI, pMOT, pINC, pUSU) {
            var url = "http://192.0.0.51/regweb/SIAVE_Interfaz.aspx?dni=" + pDNI + "&tipale=" + pMOT + "&codinc=" + pINC + "&codusu=" + pUSU;
            var setting = 'directories=no,height=640,left=20,location=no,menubar=no,resizable=yes,scrollbars=yes,status=no,toolbar=no,top=20,width=900';
            window.open(url, 'SIAVE', setting);
        }


        function GetUser() {
            var wsh = new ActiveXObject('WScript.Shell');
            var usuario = wsh.ExpandEnvironmentStrings('%USERNAME%');
            alert(usuario);
        } 


    </script>
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
        
        .white_content_his
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
        
        .white_content
        {
            display: none;
            position: absolute;
            top: 25%;
            left: 30%;
            width: 40%;
            padding: 0px;
            border: 0px solid #a6c25c;
            background-color: white;
            z-index: 1002;
            overflow: auto;
        }
        
        .white_content_h
        {
            display: none;
            position: absolute;
            top: 25%;
            left: 20%;
            width: 60%;
            padding: 0px;
            border: 0px solid #a6c25c;
            background-color: white;
            z-index: 1002;
            overflow: auto;
        }
        
        .white_content_r
        {
            display: none;
            position: absolute;
            top: 15%;
            left: 20%;
            width: 60%;
            padding: 0px;
            border: 0px solid #a6c25c;
            background-color: white;
            z-index: 1002;
            overflow: auto;
        }
        
        #pnlBusqueda
        {
            width: 100%;
            margin-top: 0px;
        }
        #pnlBotonera
        {
            width: 100%;
            float: left;
        }
        
        .LlamadaEntrante
        {
            position: absolute;
            height: 15px;
            width: 150px;
            top: 7px;
            left: 75%;
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
            height: 550px;
            margin-top: 0px;
            margin-bottom: 0px;
            border-top: 1px solid #333;
            border-bottom: 2px solid #333;
        }
        
        div#map_canvas
        {
            width: 100%;
            height: 100%;
        }
        
        div#foto
        {
            position: relative;
            width: 100%;
            height: 500px;
            margin-top: 0px;
            margin-bottom: 0px;
            border-top: 1px solid #333;
            border-bottom: 2px solid #333;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True"
        EnableScriptLocalization="False" />
    <div>
        <div id="busqueda" class="busqueda">
            <table style="width: 100%" class="Tabla">
                <colgroup>
                    <col style="width: 2%" />
                    <col style="width: 4%" />
                    <col style="width: 12%" />
                    <col style="width: 4%" />
                    <col style="width: 12%" />
                    <col style="width: 4%" />
                    <col style="width: 12%" />
                    <col style="width: 4%" />
                    <col style="width: 12%" />
                    <col style="width: 4%" />
                    <col style="width: 12%" />
                    <col style="width: 4%" />
                    <col style="width: 12%" />
                    <col style="width: 2%" />
                </colgroup>
                <tr>
                    <td colspan="14" style="height: 5px;">
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        Oriigen
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlOrigenInc" runat="server" Width="90%" CssClass="CajaCombo">
                        </asp:DropDownList>
                    </td>
                    <td>
                        Incidente
                    </td>
                    <td>
                        <asp:TextBox ID="txtNumeroInc" runat="server" Width="90%" CssClass="CajaTexto"></asp:TextBox>
                    </td>
                    <td>
                        Tipo
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTipoInc" runat="server" Width="90%" AutoPostBack="True"
                            CssClass="CajaCombo">
                        </asp:DropDownList>
                    </td>
                    <td>
                        Subtipo
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlSubtipoInc" runat="server" CssClass="CajaCombo" Width="90%">
                                </asp:DropDownList>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlTipoInc" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        Prioridad
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPrioridadInc" runat="server" Width="90%" CssClass="CajaCombo">
                        </asp:DropDownList>
                    </td>
                    <td>
                        Estado
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlEstadoInc" runat="server" Width="90%" CssClass="CajaCombo">
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        Ubicación
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlRol" runat="server" Width="90%" CssClass="CajaCombo">
                        </asp:DropDownList>
                    </td>
                    <td>
                        Usuario
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlUsuarioInc" runat="server" Width="90%" CssClass="CajaCombo">
                        </asp:DropDownList>
                    </td>
                    <td>
                        Telefóno
                    </td>
                    <td>
                        <asp:TextBox ID="txtTelefonoInc" runat="server" CssClass="CajaTexto" Width="90%"></asp:TextBox>
                    </td>
                    <td>
                        Sector
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSectorInc" runat="server" Width="60%" CssClass="CajaCombo">
                        </asp:DropDownList>
                        &nbsp;
                        <asp:TextBox ID="txtCuadrante" runat="server" CssClass="CajaTextoUpper" Width="25%"
                            MaxLength="5"></asp:TextBox>
                    </td>
                    <td>
                        Recurso
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlRecursoInc" runat="server" Width="50%" CssClass="CajaCombo">
                        </asp:DropDownList>
                        &nbsp;
                        <asp:TextBox ID="txtRecursoInc" runat="server" CssClass="CajaTextoUpper" Width="40%"
                            MaxLength="15"></asp:TextBox>
                    </td>
                    <td>
                        Personal
                    </td>
                    <td>
                        <asp:TextBox ID="txtResponsableRecurso" runat="server" CssClass="CajaTextoUpper"
                            Width="95%" MaxLength="100"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        Informante
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtInformanteInc" runat="server" CssClass="CajaTextoUpper" Width="90%"></asp:TextBox>
                    </td>
                    <td>
                        Calle/Via
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtViaInc" runat="server" CssClass="CajaTextoUpper" Width="90%"></asp:TextBox>
                    </td>
                    <td>
                        Relato
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtRelatoInc" runat="server" CssClass="CajaTextoUpper" Width="90%"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td colspan="2">
                        <asp:RadioButton ID="rbtUtlimaSemana" runat="server" Checked="True" GroupName="Consulta"
                            Text="Ultima Semana" AutoPostBack="True" />
                        <asp:RadioButton ID="rbtTodo" runat="server" GroupName="Consulta" Text="Rango de Fechas"
                            AutoPostBack="True" />
                    </td>
                    <td>
                        <asp:Label ID="lblFecInicio" runat="server" Text="Desde" Visible="False"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFechaInicio" runat="server" CssClass="CajaTexto" Width="70px"
                            Visible="False"></asp:TextBox>
                        <asp:Image ID="Image1" runat="server" ImageAlign="Middle" ImageUrl="~/img/calendario2.png"
                            Visible="False" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtFechaInicio"
                            ErrorMessage="Fecha inválida" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"
                            Visible="False"></asp:RegularExpressionValidator>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999"
                            MaskType="Date" TargetControlID="txtFechaInicio">
                        </cc1:MaskedEditExtender>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="calendario"
                            Format="dd/MM/yyyy" PopupButtonID="Image1" TargetControlID="txtFechaInicio">
                        </cc1:CalendarExtender>
                        <asp:TextBox ID="txtHoraInicio" runat="server" CssClass="CajaTexto" Width="45px"
                            Visible="False"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revHoraInicio" runat="server" ErrorMessage="* Introduzca el formato correcto."
                            Display="Dynamic" ControlToValidate="txtHoraInicio" ValidationExpression="^((([0]?[1-9]|1[0-2])(:|\.)[0-5][0-9]((:|\.)[0-5][0-9])?( )?(AM|am|aM|Am|PM|pm|pM|Pm))|(([0]?[0-9]|1[0-9]|2[0-3])(:|\.)[0-5][0-9]((:|\.)[0-5][0-9])?))$"></asp:RegularExpressionValidator>
                        <cc1:MaskedEditExtender ID="CalendarExtender4" runat="server" TargetControlID="txtHoraInicio"
                            AcceptAMPM="false" Mask="99:99" MaskType="Time" />
                    </td>
                    <td>
                        <asp:Label ID="lblFecFinal" runat="server" Text="Hasta" Visible="False"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFechaFinal" runat="server" CssClass="CajaTexto" Width="70px"
                            Visible="False"></asp:TextBox>
                        <asp:Image ID="Image2" runat="server" ImageAlign="Middle" ImageUrl="~/img/calendario2.png"
                            Visible="False" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtFechaFinal"
                            ErrorMessage="Fecha inválida" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"
                            Visible="False"></asp:RegularExpressionValidator>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999"
                            MaskType="Date" TargetControlID="txtFechaFinal">
                        </cc1:MaskedEditExtender>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="calendario"
                            Format="dd/MM/yyyy" PopupButtonID="Image2" TargetControlID="txtFechaFinal">
                        </cc1:CalendarExtender>
                        <asp:TextBox ID="txtHoraFinal" runat="server" CssClass="CajaTexto" Width="45px" Visible="False"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revHoraFinal" runat="server" ErrorMessage="* Introduzca el formato correcto."
                            Display="Dynamic" ControlToValidate="txtHoraFinal" ValidationExpression="^((([0]?[1-9]|1[0-2])(:|\.)[0-5][0-9]((:|\.)[0-5][0-9])?( )?(AM|am|aM|Am|PM|pm|pM|Pm))|(([0]?[0-9]|1[0-9]|2[0-3])(:|\.)[0-5][0-9]((:|\.)[0-5][0-9])?))$"></asp:RegularExpressionValidator>
                        <cc1:MaskedEditExtender ID="CalendarExtender3" runat="server" TargetControlID="txtHoraFinal"
                            AcceptAMPM="false" Mask="99:99" MaskType="Time" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Label ID="lblHorario" runat="server" Visible="False"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td colspan="3">
                        <asp:Button ID="btnDefault" runat="server" Text=":" CssClass="boton_activar" ToolTip="Restaurar filtros x defecto" />
                        &nbsp;
                        <asp:Button ID="btnBuscar" runat="server" Text=" Buscar " CssClass="boton_busca" />
                        <asp:Button ID="btnHistorial" runat="server" Text="Historial" CssClass="boton_dialogo"
                            Visible="False" />
                        <asp:Button ID="btnVisualizar" runat="server" Text="Visualizar" CssClass="boton_dialogo"
                            Visible="False" />
                        <asp:Button ID="btnReporte" runat="server" Text="Reporte" CssClass="boton_dialogo"
                            Visible="False" />
                        <asp:Button ID="btnExportar" runat="server" Text="Exportar Excel" CssClass="boton_dialogo"
                            Visible="False" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="14" style="height: 5px;">
                    </td>
                </tr>
            </table>
        </div>
        <div id="pnlBotonera" class="redondear">
            <table style="width: 100%;" class="Tabla">
                <tr>
                    <td colspan="10" align="center">
                        <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="#CC0000"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <asp:GridView ID="gvDatos" runat="server" CssClass="Grid" HeaderStyle-CssClass="GridHeader"
                PagerStyle-CssClass="GridFooter" AllowPaging="True" AutoGenerateColumns="False"
                Width="100%" DataKeyNames="INTINCCODIGO,INTINCROLDERIVADO,SMLINCESTADO,SMLORICODIGO,VCHMOTIVOALERTA,VCHCODQUEJA,VCHINCDOCUMENTO,VCHINCIDLATITUDE,VCHINCIDLONGITUDE,VCHINCESTADO,VCHORIDESCRIPCION,VCHTINDESCRIPCION,VCHSTIDESCRIPCION"
                PageSize="15">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <img id="imgTipo<%# Eval("INTINCCODIGO") %>" src="img/origen/tipo<%#Eval("SMLORICODIGO")%>.png"
                                alt="<%#Eval("VCHORIDESCRIPCION")%>" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Id" DataField="INTINCCODIGO" />
                    <asp:BoundField HeaderText="Fecha Hora" DataField="DTMINCFECHA" ItemStyle-Width="5%">
                        <ItemStyle Width="5%" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Origen" DataField="SMLORICODIGO" Visible="False" />
                    <asp:BoundField HeaderText="Origen" DataField="VCHORIDESCRIPCION" Visible="False" />
                    <asp:BoundField HeaderText="Número" DataField="VCHINCNUMEROORIGEN" />
                    <asp:TemplateField HeaderText="Tipo / Subtipo">
                        <ItemTemplate>
                            <asp:Label ID="lblTipo" runat="server" Text='<%# Eval("VCHTINDESCRIPCION") %>' Font-Size="XX-Small"></asp:Label><br />
                            <asp:Label ID="lblSubtipo" runat="server" Text='<%# Eval("VCHSTIDESCRIPCION") %>'
                                Font-Size="XX-Small"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Id Tipo" DataField="SMLTINCODIGO" Visible="False" />
                    <asp:BoundField HeaderText="Tipo" DataField="VCHTINDESCRIPCION" Visible="False" />
                    <asp:BoundField HeaderText="id SubTipo" DataField="SMLSTICODIGO" Visible="False" />
                    <asp:BoundField HeaderText="Subtipo" DataField="VCHSTIDESCRIPCION" Visible="False" />
                    <asp:BoundField HeaderText="Recurso" DataField="VCHRECDESCRIPCION" Visible="True" />
                    <asp:BoundField HeaderText="Resp.Recurso" DataField="VCHRECPERSONAL" Visible="True" />
                    <asp:TemplateField HeaderText="Informante / Localización" ItemStyle-Width="15%">
                        <ItemTemplate>
                            <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("VCHINCNOMBRECOMP") %>'></asp:Label><br />
                            <asp:Label ID="lblUbicat" runat="server" Text='<%# Eval("VCHINCLOCCOMENTARIO") %>'
                                Font-Size="XX-Small"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="15%" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Asoc." DataField="INTINCACODIGO" Visible="False" />
                    <asp:TemplateField HeaderText="Prioridad">
                        <ItemTemplate>
                            <asp:Label ID="lblPrioridad" runat="server" Text='<%# Eval("SMLPRICODIGO") %>' Visible="false"></asp:Label>
                            <a href="javascript:popupMostrarMapa('<%# Eval("INTINCCODIGO") %>');">
                                <asp:Image ID="imgPrioridad" runat="server" Alt='<%# Eval("VCHPRIDESCRIPCION") %>' />
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Prioridad" DataField="VCHPRIDESCRIPCION" Visible="True" />
                    <asp:BoundField HeaderText="Cdte" DataField="VCHINCLOCCUADRANTE" Visible="True" />
                    <asp:BoundField HeaderText="Sctr" DataField="VCHINCLOCSECTOR" Visible="True" />
                    <asp:BoundField HeaderText="Usuario" DataField="VCHAUDUSUCREACION" />
                    <asp:BoundField HeaderText="Derivado" DataField="VCHINCROLDERIVADO" />
                    <asp:BoundField HeaderText="Rol Derivado" DataField="INTINCROLDERIVADO" Visible="False" />
                    <asp:BoundField HeaderText="Fec Derivado" DataField="DTMINCFECDERIVADO" Visible="False" />
                    <asp:BoundField HeaderText="Asociado" DataField="INTINCACODIGO" Visible="False" />
                    <asp:BoundField HeaderText="Administrado" DataField="INTADMCODIGO" Visible="False" />
                    <asp:TemplateField HeaderText="Adjunto">
                        <ItemTemplate>
                            <a href="javascript:popupMostrarAdjunto('<%# Eval("INTINCCODIGO") %>');">
                                <img src="img/attach.png" />
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SIAVE">
                        <ItemTemplate>
                            <asp:Label ID="lblSIAVE" runat="server" Text='<%# Eval("VCHCODQUEJA") %>' Visible="false"></asp:Label>
                            <a href="javascript:popupMostrarSAIVE('<%# Eval("VCHINCDOCUMENTO") %>','<%# Eval("VCHMOTIVOALERTA") %>','<%# Eval("INTINCCODIGO") %>','SADE');">
                                <asp:Image ID="imgSIAVE" runat="server" Alt='<%# Eval("VCHCODQUEJA") %>' />
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Predio" DataField="INTPRECODIGO" Visible="False" />
                    <asp:BoundField HeaderText="Lat" DataField="VCHINCIDLATITUDE" Visible="False" />
                    <asp:BoundField HeaderText="Lon" DataField="VCHINCIDLONGITUDE" Visible="False" />
                    <asp:BoundField HeaderText="Parte" DataField="VCHPINCODIGO" Visible="False" />
                    <asp:BoundField HeaderText="CodCat" DataField="VCHCATCODIGO" Visible="False" />
                    <asp:BoundField HeaderText="Est" DataField="SMLINCESTADO" Visible="False" />
                    <asp:BoundField HeaderText="Estado" DataField="VCHINCESTADO" ItemStyle-Width="10%">
                        <ItemStyle Width="10%" />
                    </asp:BoundField>
                </Columns>
                <PagerStyle CssClass="GridFooter"></PagerStyle>
                <EmptyDataTemplate>
                    <asp:Label ID="Label37" runat="server" Text="No existen registros para mostrar" CssClass="Tabla"></asp:Label>
                </EmptyDataTemplate>
                <HeaderStyle CssClass="GridHeader"></HeaderStyle>
                <RowStyle CssClass="GridRow" />
                <AlternatingRowStyle CssClass="GridAlternateRow" />
                <SelectedRowStyle CssClass="GridSeletedRow" />
            </asp:GridView>
            <asp:HiddenField ID="hfIncidente" runat="server" />
            <asp:HiddenField ID="hfregistro" runat="server" />
            <asp:HiddenField ID="hfINCROL" runat="server" />
            <asp:HiddenField ID="hfINCESTADO" runat="server" />
            <asp:HiddenField ID="hfUSUROL" runat="server" />
            <asp:HiddenField ID="hfGeoX" runat="server" />
            <asp:HiddenField ID="hfGeoY" runat="server" />
        </div>
        <asp:GridView ID="gvEstadistica" runat="server" Visible = "false" >
        </asp:GridView>
        <div id="verimagen" class="white_content_img">
            <table width="100%" class="Tabla">
                <colgroup valign="top">
                    <col width="10%" />
                    <col width="80%" />
                    <col width="10%" />
                </colgroup>
                <tr>
                    <td style="background-color: #f0f0f0">
                    </td>
                    <td style="background-color: #f0f0f0; vertical-align: middle;" align="center">
                        <asp:Label ID="Label7" runat="server" Font-Size="Medium" Font-Bold="True">Adjuntos</asp:Label>
                    </td>
                    <td style="background-color: #f0f0f0; vertical-align: middle;">
                        <a href="javascript:void(0)" onclick="document.getElementById('verimagen').style.display='none';document.getElementById('fade').style.display='none'">
                            <img src="img/Close.gif" style="border: 0px" align="right" /></a>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <div id="foto">
                            <img id="imgFoto" alt="-" src="" height="450px" width="100%" onerror="this.src='img/nodisponible.gif';" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div id="fade" class="black_overlay">
        </div>
        <div id="historial" class="white_content_his">
            <table width="100%" class="Tabla">
                <colgroup valign="top">
                    <col width="4%" />
                    <col width="15%" />
                    <col width="64%" />
                    <col width="15%" />
                    <col width="2%" />
                </colgroup>
                <tr>
                    <td style="background-color: #f0f0f0">
                    </td>
                    <td style="background-color: #f0f0f0; vertical-align: middle; height: 30px;" colspan="3"
                        align="center">
                        <asp:Label ID="Label3" runat="server" Font-Size="Medium" Font-Bold="True">Historial de Incidencia</asp:Label>
                    </td>
                    <td style="background-color: #f0f0f0; vertical-align: middle;">
                        <a href="javascript:void(0)" onclick="document.getElementById('historial').style.display='none';document.getElementById('fade').style.display='none'">
                            <img src="img/Close.gif" style="border: 0px" align="right" /></a>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td colspan="3">
                        <table width="100%" class="Tabla">
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
                                <td colspan="10">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    Nº Incidente
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNumeroIncHis" runat="server" Width="60%" CssClass="CajaTextoOff"
                                        ReadOnly="True"></asp:TextBox>
                                </td>
                                <td>
                                    Tipo
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTipoIncHis" runat="server" Width="90%" CssClass="CajaTextoCOff"
                                        ReadOnly="True"></asp:TextBox>
                                </td>
                                <td>
                                    Subtipo
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSubtipoIncHis" runat="server" Width="90%" CssClass="CajaTextoCOff"
                                        ReadOnly="True"></asp:TextBox>
                                </td>
                                <td>
                                    Prioridad
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPrioridadIncHis" runat="server" Width="90%" CssClass="CajaTextoCOff"
                                        ReadOnly="True"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
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
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
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
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td colspan="3">
                        <div style="height: 300px; width: 100%; overflow: auto;">
                            <asp:GridView ID="gvHistorial" runat="server" CssClass="Grid" AlternatingRowStyle-CssClass="GridAlternateRow"
                                HeaderStyle-CssClass="GridHeader" PagerStyle-CssClass="GridFooter" RowStyle-CssClass="GridRow"
                                ShowHeader="True" AllowPaging="False" AutoGenerateColumns="False" Width="100%"
                                DataKeyNames="INTHISCODIGO">
                                <RowStyle CssClass="GridRow"></RowStyle>
                                <Columns>
                                    <asp:BoundField HeaderText="Fecha" DataField="DTMHISFECHAHORA" />
                                    <asp:BoundField HeaderText="Id.Ope." DataField="SMLHISOPERACION" />
                                    <asp:BoundField HeaderText="Operación" DataField="VCHTABDESCRIPCION" />
                                    <asp:BoundField HeaderText="Usuario" DataField="VCHHISUSUARIO" />
                                    <asp:BoundField HeaderText="Rol Usuario" DataField="VCHROLDESCRIP" />
                                    <asp:BoundField HeaderText="Comentario" DataField="VCHHISCOMENTARIO" />
                                </Columns>
                                <PagerStyle CssClass="GridFooter"></PagerStyle>
                                <EmptyDataTemplate>
                                    <asp:Label ID="Label37" runat="server" Text="No existen registros para mostrar" CssClass="Tabla"></asp:Label>
                                </EmptyDataTemplate>
                                <HeaderStyle CssClass="GridHeader"></HeaderStyle>
                                <AlternatingRowStyle CssClass="GridAlternateRow"></AlternatingRowStyle>
                                <SelectedRowStyle CssClass="GridSeletedRow" />
                            </asp:GridView>
                        </div>
                    </td>
                    <td>
                        &nbsp;
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
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td align="center">
                        <input id="btnCerrarHis" type="button" value="Cancelar" class="boton_dialogo" onclick="document.getElementById('historial').style.display='none';document.getElementById('fade').style.display='none'" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
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
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
