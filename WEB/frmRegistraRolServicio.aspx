<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="frmRegistraRolServicio.aspx.vb" Inherits="frmRegistraRolServicio"  EnableEventValidation="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script language="javascript" type="text/javascript">
    function CargarDatosPopup(codigo, nombre, cargo, modalidad) {
        document.getElementById('<%= txtCodigo.ClientID %>').value = codigo;
        document.getElementById('<%= txtNombre.ClientID %>').value = nombre;
        document.getElementById('<%= txtCargo.ClientID %>').value = cargo;
        document.getElementById('<%= txtModalidad.ClientID %>').value = modalidad;
        document.getElementById('<%= txtCodigo.ClientID %>').readOnly = true;
        document.getElementById('<%= txtNombre.ClientID %>').readOnly = true;
        document.getElementById('<%= txtCargo.ClientID %>'). readOnly =  true ;
        document.getElementById('<%= txtModalidad.ClientID %>').readOnly =  true ;

    }
    function ValidaProgramacion() {
        if (document.getElementById('<%= txtCodigo.ClientID %>').value == '') {
            alert('DEBE SELECCIONAR EL PERSONAL')
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
        #pnlContenedor
        {
         width : 100%;
        }        
        #pnlRecurso
        {
         width : 100%;
         float:left;
        }
        #pnlPersonal 
        {
         width : 100%;
         float:left;
        }
        #pnlPuestoFijo
        {
         width : 100%;
         float:left;
        }        	
        #pnlBotones
        {
         width : 100%;
         float:left;
        }                
        </style>   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="pnlContenedor">
        <table  class="Tabla" style="width: 100%">
            <colgroup>
                <col style="width: 1%"/>
                <col style="width: 10%" />
                <col style="width: 19%"/>
                <col style="width: 10%" />
                <col style="width: 15%"/>
                <col style="width: 10%" />
                <col style="width: 10%"/>
                <col style="width: 10%" />
                <col style="width: 14%"/>
                <col style="width: 1%" />
            </colgroup>
            <tr>
            <td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td>
            </tr>
            <tr class="titulo">
                <td></td>
                <td><asp:Label ID="Label9" runat="server" Text="Periodo:"></asp:Label></td>
                <td><asp:Label ID="lblPeriodo" runat="server" Text=""></asp:Label></td>
                <td></td>
                <td><asp:Label ID="Label10" runat="server" Text="Grupo de servicio:"></asp:Label></td>
                <td><asp:Label ID="lbGrupoServicio" runat="server"></asp:Label></td>
                <td></td>
                <td><asp:Label ID="Label1" runat="server" Text="Sector:"></asp:Label></td>
                <td><asp:Label ID="lblSector" runat="server"></asp:Label></td>
                <td></td>
            </tr>
        </table>

           <div id="pnlPersonal" class="busquedaFondo" runat="server">
            <table  class="Tabla" style="width: 80%">
                <colgroup>
                    <col style="width: 1%"/>
                    <col style="width: 10%"/>
                    <col style="width: 15%"/>
                    <col style="width: 10%"/>
                    <col style="width: 10%"/>
                    <col style="width: 18%"/>
                    <col style="width: 10%"/>
                    <col style="width: 10%"/>
                    <col style="width: 15%"/>
                    <col style="width: 1%"/>
                </colgroup>
                <tr>
                <td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Código"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCodigo" runat="server" CssClass="CajaTexto" Width="100%"></asp:TextBox>
                    </td>
                    <td colspan = "5"><asp:TextBox ID="txtNombre" runat="server" CssClass="CajaTextoCOff" Width="100%"></asp:TextBox></td>
                    <td style = "text-align:center;">
                        <asp:Button ID="btnBuscarPersona" runat="server" Text="   Buscar   " 
                            CssClass ="boton_busca" /></td>                   
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="Label39" runat="server" Text="Cargo"></asp:Label>
                    </td>
                    <td colspan = "2"><asp:TextBox ID="txtCargo" runat="server" CssClass="CajaTextoCOff" Width="100%"></asp:TextBox></td>
                    <td style = "text-align:center;">
                        <asp:Label ID="Label40" runat="server" Text="Modalidad"></asp:Label>
                    </td>
                    <td colspan = "3"><asp:TextBox ID="txtModalidad" runat="server" 
                            CssClass="CajaTextoCOff" Width="100%"></asp:TextBox></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                <td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td>
                </tr>
            </table>
        </div>   
        <div id="pnlBotones2">
            <table class="Tabla" style="width: 100%">
                <colgroup>
                    <col style="width: 1%" />
                    <col style="width: 10%" />
                    <col style="width: 10%" />
                    <col style="width: 10%" />
                    <col style="width: 28%" />
                    <col style="width: 10%" />
                    <col style="width: 10%" />
                    <col style="width: 10%" />
                    <col style="width: 10%" />
                    <col style="width: 0%" />
                </colgroup>
                <tr>
                <td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="5">
                        <asp:Button ID="btnProgramacion" runat="server" Text="   Programación  " 
                            CssClass ="boton_dialogo" />
                        </td>
                    <td></td>
                    <td colspan ="2" align="center">
                        <asp:Button ID="btnGrabaRol2" runat="server" Text=" Grabar " 
                            CssClass ="boton_dialogo" />
                        <asp:Button ID="btnCancelaPaquete2" runat="server" Text="Regresar" 
                            CssClass ="boton_dialogo" />
                    </td>
                    <td></td>
                </tr>
                </table>
        </div>             
<div id="pnlPuestoFijo" class="busqueda" runat="server">
            <table  class="Tabla" style="width: 100%">
                <colgroup>
                    <col style="width: 1%"/>
                    <col style="width: 10%"/>
                    <col style="width: 15%"/>
                    <col style="width: 10%"/>
                    <col style="width: 28%"/>
                    <col style="width: 0%"/>
                    <col style="width: 10%"/>
                    <col style="width: 10%"/>
                    <col style="width: 15%"/>
                    <col style="width: 1%"/>
                </colgroup>
                <tr>
                <td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td>&nbsp;</td><td></td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan = "8">
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="gvProgramacion" runat="server" 
                                                    
    AlternatingRowStyle-CssClass="GridAlternateRow" AutoGenerateColumns="False" 
                                                    CssClass="Grid" HeaderStyle-CssClass="GridHeader" 
                                                    
    PagerStyle-CssClass="GridFooter" RowStyle-CssClass="GridRow" Width="100%">
                                                            <Columns>
                                                                <asp:BoundField DataField="VCHRSEFECHA" HeaderText="Dia" >
                                                                <ItemStyle Width="10%" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="Turno">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTurnoUpd" runat="server" Text='<%# BIND("SMLTURCODIGO") %>' 
                                                                    Visible="False"></asp:Label>
                                                                        <asp:DropDownList ID="ddlTurnoUpd" runat="server"  AutoPostBack = "True"
                                                                    CssClass="CajaCombo" Width="95%" 
                                                                    onselectedindexchanged="ddlTurnoUpd_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="10%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Mot.Ausencia" >
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblMotivoUpd" runat="server"  
                                                                    Text='<%# BIND("SMLRSEMOTAUSENCIA") %>' Visible="False"></asp:Label>
                                                                        <asp:DropDownList ID="ddlMotivoUpd" runat="server" AutoPostBack = "True"
                                                                    CssClass="CajaComboAlerta" onselectedindexchanged="ddlMotivoUpd_SelectedIndexChanged" 
                                                                    Width="95%">
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="15%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Puesto Fijo">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPuestoFijoUpd" runat="server" 
                                                                    Text='<%# BIND("SMLPFICODIGO") %>' Visible="False"></asp:Label>
                                                                        <asp:DropDownList ID="ddlPuestoFijoUpd" runat="server" CssClass="CajaCombo" 
                                                                    Width="95%">
                                                                        </asp:DropDownList>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="35%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Comentario">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtComentarioUpd" runat="server" CssClass="CajaTexto" 
                                                                    Text='<%# BIND("VCHRSECOMENTARIO") %>' width="95%"></asp:TextBox>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Width="25%" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="SMLRSEASISTENCIA" HeaderText="Asistencia">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                </asp:BoundField>
                                                            </Columns>
                                                            <RowStyle CssClass="GridRow" />
                                                            <PagerStyle CssClass="GridFooter" />
                                                            <EmptyDataTemplate>
                                                                <asp:Label ID="Label38" runat="server" CssClass="Tabla" 
                                                            Text="No existen registros para mostrar"></asp:Label>
                                                            </EmptyDataTemplate>
                                                            <HeaderStyle CssClass="GridHeader" />
                                                            <AlternatingRowStyle CssClass="GridAlternateRow" />
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="btnProgramacion" EventName="Click">
                                                        </asp:AsyncPostBackTrigger>
                                                    </Triggers>
                                                </asp:UpdatePanel>

                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan ="8">
                    </td>
                    <td></td>
                </tr>
            </table>
        </div>  
        <div id="pnlBotones">
            <table class="Tabla" style="width: 100%">
                <colgroup>
                    <col style="width: 1%" />
                    <col style="width: 10%" />
                    <col style="width: 10%" />
                    <col style="width: 10%" />
                    <col style="width: 28%" />
                    <col style="width: 10%" />
                    <col style="width: 10%" />
                    <col style="width: 10%" />
                    <col style="width: 10%" />
                    <col style="width: 0%" />
                </colgroup>
                <tr>
                <td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td>
                </tr>
                <tr>
                    <td colspan="10" style="height: 5px;">
                    </td>
                </tr>
                <tr>
                    <td colspan="7">
                    </td>
                     <td colspan ="2" align="center">
                        <asp:Button ID="btnGrabaRol" runat="server" Text=" Grabar " 
                            CssClass ="boton_dialogo" />
                        <asp:Button ID="btnCancelaPaquete" runat="server" Text="Regresar" 
                            CssClass ="boton_dialogo" />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td colspan="10" style="text-align: center">
                        <asp:Label ID="lblMensaje" runat="server" ForeColor="#CC0000" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="10" style="height: 5px;">
                        <asp:HiddenField ID="hdfSectores" runat="server" />
                    </td>
                </tr>
            </table>
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
        Font-Bold="True">Mensaje del sistema</asp:Label>
</td>
<td style=" background-color:#f0f0f0; vertical-align:middle;"><a href = "javascript:void(0)" onclick = "document.getElementById('mensaje').style.display='none';document.getElementById('fade').style.display='none'"><img src="img/Close.gif" style="border :0px" align="right" /></a>
</td>
</tr>        
<tr><td colspan="7" style="height:20px;"></td></tr>
        <tr class="titulo" >
            <td colspan="7" style="text-align :center">
                <asp:Label ID="lblMensajeSistema" runat="server" Text=""></asp:Label></td>
        </tr>
<tr><td colspan="7" style="height:20px;"></td></tr>
<tr><td colspan="7" style="height:20px; vertical-align:middle; text-align :center;"><asp:Button ID="btnRedirecciona" runat="server" CssClass="boton_busca" 
        Text="    Aceptar    " /></td></tr>
<tr><td colspan="7" style="height:10px;"></td></tr>
</table>
</div>
<div id="fade" class="black_overlay">
</div>

   </div>

</asp:Content>

