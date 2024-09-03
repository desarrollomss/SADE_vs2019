<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="frmProgMensualAuto.aspx.vb" Inherits="frmProgMensualAuto" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<script language="javascript" type="text/javascript">
   
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
                        <asp:Button ID="btnAgregar" runat="server" Text="  Agregar  personal" 
                            CssClass ="boton" />
                        </td>
                    <td></td>
                    <td colspan ="2" style = "text-align :right;">
                        <asp:Button ID="btnGrabaProgramacion2" runat="server" Text=" Grabar " 
                            CssClass ="boton_dialogo" />
                        <asp:Button ID="btnCancelaProgramacion2" runat="server" Text="Regresar" 
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
                                        <asp:GridView ID="gvProgramacion" runat="server" 
                                            AlternatingRowStyle-CssClass="GridAlternateRow" AutoGenerateColumns="False" 
                                            CssClass="Grid" HeaderStyle-CssClass="GridHeader" 
                                            PagerStyle-CssClass="GridFooter" RowStyle-CssClass="GridRow" 
                                    Width="100%">

                                            <Columns>
                                                <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                    <HeaderStyle />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkEliminaProgramacion" CssClass="boton_eliminar" 
                                                            OnClientClick="javascript:return confirm('Estas seguro(a) de eliminar?','SADE');" 
                                                            runat="server" CommandName="Select" >Eliminar</asp:LinkButton>
                                                    </ItemTemplate>
                                                <ItemStyle Width="10%" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="INTPERCODIGO" HeaderText="Código">
                                                <ItemStyle Width="5%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="VCHCOMPLETO" HeaderText="Apellidos y nombres">
                                                <ItemStyle Width="30%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="VCHCARGO" HeaderText="Cargo">
                                                <ItemStyle Width="15%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="VCHMODALIDAD" HeaderText="Modalidad">
                                                <ItemStyle Width="10%" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Secuencia">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSecuenciaUpd" runat="server" Text='<%# BIND("SMLSSECODIGO") %>' 
                                                            Visible="False"></asp:Label>
                                                        <asp:DropDownList ID="ddlSecuenciaUpd" runat="server" CssClass="CajaCombo" 
                                                            Width="95%" AutoPostBack="True">
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="15%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Inicio Sec.">
                                                    <ItemTemplate>
                                                        <asp:UpdatePanel ID="UDPSEC" runat="server">
                                                        <ContentTemplate>
                                                        <asp:Label ID="lblInicioSecuenciaUpd" runat="server" Visible="False" 
                                                            Text='<%# BIND("SMLDSSSECUENCIA") %>'></asp:Label>
                                                        <asp:DropDownList ID="ddlInicioSecuenciaUpd" runat="server" CssClass="CajaCombo" 
                                                            Width="95%">
                                                        </asp:DropDownList>
                                                        </ContentTemplate> 
                                                        </asp:UpdatePanel>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="15%" />
                                                </asp:TemplateField>

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
                     <td colspan ="2" style = "text-align :right;">
                        <asp:Button ID="btnGrabaProgramacion" runat="server" Text=" Grabar " 
                            CssClass ="boton_dialogo" />
                        <asp:Button ID="btnCancelaProgramacion" runat="server" Text="Regresar" 
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
<div id="personal" class="white_content">
    <table width="100%" class="Tabla">
        <colgroup valign="top">
            <col width="2%" />
            <col width="11%" />
            <col width="21%" />
            <col width="11%" />
            <col width="21%" />
            <col width="11%" />
            <col width="21%" />
            <col width="2%" />
        </colgroup>
        <tr>
            <td style="background-color: #f0f0f0">
            </td>
            <td style="background-color: #f0f0f0; vertical-align: middle;" colspan="6">
                <asp:Label ID="lblTituloMantenimiento" runat="server" Font-Size="Medium" Font-Bold="True">Búsqueda de personal</asp:Label>
            </td>
            <td style="background-color: #f0f0f0; vertical-align: middle;">
                <a href="javascript:void(0)" onclick="document.getElementById('personal').style.display='none';document.getElementById('fade').style.display='none'">
                    <img src="img/Close.gif" style="border: 0px" align="right" /></a>
            </td>
        </tr>
        <tr>
            <td colspan="8" style="height: 10px;">
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Label ID="Label31" runat="server" Text="Código"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCodigoBusca" runat="server" CssClass="CajaTexto" Width="70px"
                    MaxLength="50"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label40" runat="server" Text="Cargo"></asp:Label>
            </td>
            <td colspan="3">
                <asp:DropDownList ID="ddlCargoBusca" runat="server" CssClass="CajaCombo" Width="95%">
                </asp:DropDownList>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Apellido Paterno"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPaternoBusca" runat="server" CssClass="CajaTexto" Width="95%"
                    MaxLength="100"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Apellido Materno"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtMaternoBusca" runat="server" CssClass="CajaTexto" Width="95%"
                    MaxLength="100"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Labelnombrebusca" runat="server" Text="Nombres"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNombreBusca" runat="server" CssClass="CajaTexto" Width="95%"
                    MaxLength="50"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="8" style="height: 10px;">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="5">
                <asp:Button ID="btnRecursoBuscar" runat="server" CssClass="boton_busca" 
                    Text="  Buscar  " />
                &nbsp;<asp:Button ID="btnRecursoAgregar" runat="server" CssClass="boton_busca" Text="Agregar" />
            </td>
            <td style="text-align :right;">
                <asp:CheckBox ID="chkTodos" runat="server" Text="Selecciona Todos" 
                    TextAlign="Left" AutoPostBack="True" />
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="8" style="height: 10px;">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="6">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <div style="height: 300px; overflow: auto">
                            <asp:GridView ID="gvPersonalBusca" runat="server" AlternatingRowStyle-CssClass="GridAlternateRow"
                                AutoGenerateColumns="False" CssClass="Grid" HeaderStyle-CssClass="GridHeader"
                                PagerStyle-CssClass="GridFooter" RowStyle-CssClass="GridRow" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="INTPERCODIGO" HeaderText="Código">
                                        <ItemStyle Width="5%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="VCHCOMPLETO" HeaderText="Apellidos y nombres">
                                        <ItemStyle Width="40%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="VCHCRGDESCRIPCION" HeaderText="Cargo">
                                        <ItemStyle Width="20%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CHRPERMODALIDADDES" HeaderText="Modalidad">
                                        <ItemStyle Width="20%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="VCHSECDESCRIPCION" HeaderText="Sector">
                                        <ItemStyle Width="10%" />
                                    </asp:BoundField>
                                    <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelecciona" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle Width="5%" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle CssClass="GridRow" />
                                <PagerStyle CssClass="GridFooter" />
                                <EmptyDataTemplate>
                                    <asp:Label ID="Label38" runat="server" CssClass="Tabla" Text="No existen registros para mostrar"></asp:Label>
                                </EmptyDataTemplate>
                                <HeaderStyle CssClass="GridHeader" />
                                <AlternatingRowStyle CssClass="GridAlternateRow" />
                            </asp:GridView>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnRecursoBuscar" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="chkTodos" EventName="CheckedChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td>
            </td>
        </tr>
        <tr><td colspan = "8" style= "height:40px;"></td></tr>
    </table>
</div>


<div id="fade" class="black_overlay">
</div>

   </div>
</asp:Content>

