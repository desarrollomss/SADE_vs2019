<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="frmBuscaPaqueteRecurso.aspx.vb" Inherits="frmBuscaPaqueteRecurso" EnableEventValidation="false" Culture="ES-pe" UICulture="Es-pe" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

    <script language="javascript" type="text/javascript">
        function ValidaActualizaBusca() {
            if (document.getElementById('<%= txtFechaBusca.ClientID %>').value == '') {
                alert('Ingrese la fecha a buscar.')
                return false
            }
        }

        function ValidaBuscar() {
            if (document.getElementById('<%= txtFechaBusca.ClientID %>').value == '') {
                alert('Ingrese la fecha para el paquete')
                return false
            }
        }
        function ValidaNuevo() {
            if (document.getElementById('<%= txtFechaBusca.ClientID %>').value == '') {
                alert('Ingrese la fecha a registrar.')
                return false
            }

            if (document.getElementById('<%= ddlTurnoBusca.ClientID %>').value == 0) {
                alert('Ingrese el turno para el paquete.')
                return false
            }
        }

   
        function sololetras(e) {

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
                return true;
            }

            return false;
        }

        function validarEmail(valor) {
            if (valor.indexOf('@', 0) == -1 ||
       valor.indexOf('@', 0) == 0 ||
       valor.indexOf('.', 0) == -1) {
                return (false)
            } else {
                return (true)
            };
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
        function solomontos(e) {

            var key;
            if (window.event) // IE
            {
                key = e.keyCode;
            }
            else if (e.which) // Netscape/Firefox/Opera
            {
                key = e.which;
            }

            if (key < 46 || key > 57) {
                return false;
            }
            else if (key == 47)
            { return false; }
            return true;
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
	    .white_content {
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
        </style>     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization = 'True'  EnableScriptLocalization = 'True'    >
                </asp:ScriptManager>
<div>
    <div id="busqueda" class="busqueda">
        <table style ="width:100%" class ="Tabla">
            <colgroup>
                <col style= "width:5%" />
                <col style= "width:10%" />
                <col style= "width:5%" />
                <col style= "width:15%" />
                <col style= "width:5%" />
                <col style= "width:15%" />
                <col style= "width:10%" />
                <col style= "width:20%" />
                <col style= "width:5%" />
                <col style= "width:10%" />
            </colgroup>
 
                <tr>
            <td style="height :10px;"></td>
            <td style="height :10px;"></td>
            <td style="height :10px;"></td>
            <td style="height :10px;"></td>
            <td style="height :10px;"></td>
            <td style="height :10px;"></td>
            <td style="height :10px;"></td>
            <td style="height :10px;"></td>
            <td style="height :10px;"></td>
            <td style="height :10px;"></td>
            </tr>
            <tr>
            <td><asp:Label ID="lblFecha" runat="server" Text="Fecha"></asp:Label></td>
            <td>
                    
                    <asp:TextBox ID="txtFechaBusca" runat="server" CssClass="CajaTexto"  
                        Width="70px"></asp:TextBox>
                    <asp:Image ID="imgFechaBusca" runat="server" ImageAlign="Middle" 
                        ImageUrl="~/img/calendario2.png" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtFechaBusca"
                        ErrorMessage="Fecha inválida" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"
                        Visible="False"></asp:RegularExpressionValidator>   
                    <cc1:maskededitextender ID="MaskedEditExtender6" runat="server" Mask="99/99/9999"
                        MaskType="Date" TargetControlID="txtFechaBusca" >
                    </cc1:maskededitextender>
                    <cc1:calendarextender ID="CalendarExtender5" runat="server" 
                        CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="imgFechaBusca"
                        TargetControlID="txtFechaBusca">
                    </cc1:calendarextender>                                 
            </td>
            <td>
            <asp:Label ID="Label1" runat="server" Text="Turno"></asp:Label>
            </td>
            <td>
             <asp:DropDownList ID="ddlTurnoBusca" runat="server" CssClass="CajaCombo" 
                                    Width="95%">
                                </asp:DropDownList>
            </td>
            <td>
            <asp:Label ID="lblSector" runat="server" Text="Sector"></asp:Label>
            </td>
            <td>
            <asp:DropDownList ID="ddlSectorBusca" runat="server" CssClass="CajaCombo" 
                                    Width="90%">
                                </asp:DropDownList>
            </td>
            <td>
            <asp:Label ID="lblTipoPaquete" runat="server" Text="Tipo Paquete"></asp:Label>
            </td>
            <td>
            <asp:DropDownList ID="ddlTipoPaqueteBusca" runat="server" CssClass="CajaCombo" 
                                    Width="95%">
                                </asp:DropDownList>
            </td>
            <td>
            </td>
            <td>
                            <asp:Button ID="btnBuscar" runat="server" Text="  Buscar   "   OnClientClick="cambiarvalor()"
                    CssClass="boton_busca" />
            </td>                        
            </tr>
            <tr>
            <td colspan= "10" style="height :10px;"></td>
            </tr>
        </table>
    </div>
<div id = "pnlBotonera">
    <table style ="width:100%;" class="Tabla">
        <tr>
            <td colspan="10" style="height: 3px;">
            </td>
        </tr>
        <tr>
            <td colspan="10">
                <asp:Button ID="btnNuevo" runat="server" Text="  Nuevo  " 
                    CssClass="boton_dialogo"  OnClientClick="cambiarvalor()" ToolTip="Crear nuevo paquete de recursos" />
                &nbsp;<asp:Button ID="btnModificar" runat="server" Text="Modificar" 
                    CssClass="boton_dialogo"  OnClientClick="cambiarvalor()"
                    ToolTip="Editar los datos del paquete de recursos" />
            &nbsp;<asp:Button ID="btnEliminar" runat="server" Text=" Eliminar " 
                    CssClass="boton_dialogo"  
                    onclientclick="{cambiarvalor();javascript:return confirm('“¿Está seguro de eliminar la el paquete de recurso?','SADE');}" 
                    ToolTip="Eliminar paquete de recursos" />
            &nbsp;<asp:Button ID="btnVer" runat="server" Text="Visualizar" 
                    CssClass="boton_dialogo"  OnClientClick="cambiarvalor()"
                    ToolTip="Ver paquete de recursos" />
            &nbsp;<asp:Button ID="btnReplicar" runat="server" Text="Replicar última programación"   OnClientClick="cambiarvalor()"
                    CssClass="boton_dialogo" Visible="False" />
            </td>
        </tr>
        <tr>
            <td colspan="10" align="center">
                <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="#CC0000"></asp:Label>
            </td>
        </tr>
    </table>
</div>
<div id= "pnlBusqueda">
<div id="pnlRecurso" class="busqueda" >
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
    <asp:GridView ID="gvRecursosDisponibles" runat="server" CssClass="Grid" AlternatingRowStyle-CssClass="GridAlternateRow"
        HeaderStyle-CssClass="GridHeader" PagerStyle-CssClass="GridFooter" RowStyle-CssClass="GridRow"
        AllowPaging="True" AutoGenerateColumns="False" Width="100%">
        <RowStyle CssClass="GridRow"></RowStyle>
        <Columns>
            <asp:BoundField HeaderText="Recurso" DataField="RECURSO">
                <HeaderStyle HorizontalAlign ="Center" />
                <ItemStyle Width="70%" HorizontalAlign ="Left" />
            </asp:BoundField>
            <asp:BoundField HeaderText="Cantidad" DataField="CANTIDAD">
                <HeaderStyle HorizontalAlign ="Center" />
                <ItemStyle Width="30%" HorizontalAlign ="Center" />
            </asp:BoundField>
        </Columns>
        <PagerStyle CssClass="GridFooter"></PagerStyle>
        <EmptyDataTemplate>
            <asp:Label ID="Label37" runat="server" Text="No existen registros para mostrar" CssClass="Tabla"></asp:Label>
        </EmptyDataTemplate>
        <HeaderStyle CssClass="GridHeader"></HeaderStyle>
        <AlternatingRowStyle CssClass="GridAlternateRow"></AlternatingRowStyle>
    </asp:GridView>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</div>      
<div id="pnlResultado">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <asp:GridView ID="gvDatos" runat="server" CssClass="Grid" AlternatingRowStyle-CssClass="GridAlternateRow"
        HeaderStyle-CssClass="GridHeader" PagerStyle-CssClass="GridFooter" RowStyle-CssClass="GridRow"
        AllowPaging="True" AutoGenerateColumns="False" Width="100%">
        <RowStyle CssClass="GridRow"></RowStyle>
                  <Columns>
                                        <asp:BoundField HeaderText="Cod" DataField="VCHPAQNUMERO">
                                            <ItemStyle Width="5%" />
                                        </asp:BoundField>       
                                        <asp:BoundField HeaderText="Tipo Paquete" DataField="VCHTPQDESCRIPCION">
                                            <ItemStyle Width="15%" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Responsable" DataField="VCHRESPONSABLE">
                                            <ItemStyle Width="15%" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Sector" DataField="SECTOR">
                                            <ItemStyle Width="5%" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Cuad" DataField="CUADRANTE">
                                            <ItemStyle Width="5%" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Puesto Fijo" DataField="PUESTOFIJO">
                                            <ItemStyle Width="20%" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Estado" DataField="CHRPAQESTADODES">
                                            <ItemStyle Width="15%" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Comentario" DataField="VCHPAQCOMENTARIO">
                                            <ItemStyle Width="20%" />
                                        </asp:BoundField>
                                    </Columns>
                  
        <PagerStyle CssClass="GridFooter"></PagerStyle>
        <EmptyDataTemplate>
            <asp:Label ID="Label37" runat="server" Text="No existen registros para mostrar" CssClass="Tabla"></asp:Label>
        </EmptyDataTemplate>
        <HeaderStyle CssClass="GridHeader"></HeaderStyle>
        <AlternatingRowStyle CssClass="GridAlternateRow"></AlternatingRowStyle>
         <SelectedRowStyle CssClass="GridSeletedRow" />
    </asp:GridView>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="gvDatos" 
                EventName="SelectedIndexChanging" />
            <asp:AsyncPostBackTrigger ControlID="gvDatos" EventName="PageIndexChanging" />
        </Triggers>
    </asp:UpdatePanel>

</div>
    </div>
<div id="mensaje" class="white_content">
    <table width="100%" class="Tabla">
        <colgroup valign="top">
            <col width="4%" />
            <col width="18%" />
            <col width="20%" />
            <col width="20%" />
            <col width="15%"/>
            <col width="21%" />
            <col width="2%" />
        </colgroup>
<tr>
<td style=" background-color:#f0f0f0"></td>
<td style=" background-color:#f0f0f0; vertical-align:middle; text-align:center;" colspan="5">
<asp:Label ID="Label12" runat="server" Font-Size="Small"
        Font-Bold="True">Replicar última programación</asp:Label>
</td>
<td style=" background-color:#f0f0f0; vertical-align:middle;"><a href = "javascript:void(0)" onclick = "document.getElementById('mensaje').style.display='none';document.getElementById('fade').style.display='none'"><img src="img/Close.gif" style="border :0px" align="right" /></a>
</td>
</tr>        
<tr><td colspan="7" style="height:20px;"></td></tr>
<tr>
<td></td>
<td></td>
<td><asp:Label ID="Label2" runat="server" Text="Fecha origen"></asp:Label></td>
<td>
    <asp:TextBox ID="txtFechaOrigen" runat="server" CssClass="CajaTexto"  
        Width="70px" AutoPostBack="True"></asp:TextBox>
    <asp:Image ID="Image1" runat="server" ImageAlign="Middle" ImageUrl="~/img/calendario.jpg" />
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtFechaOrigen"
        ErrorMessage="Fecha inválida" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"
        Visible="False"></asp:RegularExpressionValidator>   
    <cc1:maskededitextender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999"
        MaskType="Date" TargetControlID="txtFechaOrigen">
    </cc1:maskededitextender>
    <cc1:calendarextender ID="CalendarExtender1" runat="server" 
        CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="Image1"
        TargetControlID="txtFechaOrigen">
    </cc1:calendarextender>
</td>
<td></td>
<td></td>
<td></td>
</tr>
<tr><td colspan="7" style="height:20px;"></td></tr>
<tr>
<td></td>
<td></td>
<td><asp:Label ID="Label3" runat="server" Text="Fecha destino"></asp:Label></td>
<td>
    <asp:TextBox ID="txtFechaDestino" runat="server" CssClass="CajaTexto"  
        Width="70px" AutoPostBack="True"></asp:TextBox>
    <asp:Image ID="Image2" runat="server" ImageAlign="Middle" ImageUrl="~/img/calendario.jpg" />
    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtFechaDestino"
        ErrorMessage="Fecha inválida" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"
        Visible="False"></asp:RegularExpressionValidator>   
    <cc1:maskededitextender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999"
        MaskType="Date" TargetControlID="txtFechaDestino">
    </cc1:maskededitextender>
    <cc1:calendarextender ID="CalendarExtender2" runat="server" 
        CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="Image2"
        TargetControlID="txtFechaDestino">
    </cc1:calendarextender>
</td>
<td></td>
<td></td>
<td></td>
</tr>
<tr><td colspan="7" style="height:20px;"></td></tr>
<tr><td colspan="7" style="height:20px; vertical-align:middle; text-align :center;"><asp:Button ID="btnAceptarReplicar" runat="server" CssClass="boton_busca" 
        Text="    Replicar programación   " /></td></tr>
<tr><td colspan="7" style="height:50px;"></td></tr>
</table>
</div>
<div id="fade" class="black_overlay">
</div>

</div>
</asp:Content>

