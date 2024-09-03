<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false"
    CodeFile="frmGestionaOperador.aspx.vb" Inherits="frmGestionaOperador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
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
		    top: 25%;
		    left: 30%;
		    width: 40%;
    		
		    padding: 0px;
		    border: 0px solid #a6c25c;
		    background-color: white;
		    z-index:1002;
		    overflow: auto;
	    }	


	    
        .Flotante
        {
	        position: absolute;
	        top: 25px;
	        left: 37px;
        }        
        


        </style>  

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:Panel ID="pnlBusqueda" runat="server">
        <div id="pnlFiltros" class="busqueda">
            <table style="width: 100%" class="Tabla">
                <colgroup>
                    <col style="width: 10%" />
                    <col style="width: 5%" />
                    <col style="width: 10%" />
                    <col style="width: 5%" />
                    <col style="width: 15%" />
                    <col style="width: 5%" />
                    <col style="width: 15%" />
                    <col style="width: 10%" />
                    <col style="width: 10%" />
                    <col style="width: 10%" />
                </colgroup>
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
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        Usuario
                    </td>
                    <td>
                        <asp:TextBox ID="txtUsuOperadorBus" runat="server" Width="90%"></asp:TextBox>
                    </td>
                    <td>
                        Rol/Perfil
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlRolOperadorBus" runat="server" CssClass="CajaCombo" 
                            Width="90%">
                        </asp:DropDownList>
                    </td>
                    <td>
                        Estado
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlEstOperadorBus" runat="server" CssClass="CajaCombo" 
                            Width="95%">
                        </asp:DropDownList>
                    </td>
                    <td colspan="2">
                        <asp:Button ID="btnBuscar" runat="server" CssClass="boton_busca" 
                            OnClientClick="cambiarvalor()" Text=" Buscar " />
                        &nbsp;<asp:Button ID="btnAgregar" runat="server" CssClass="boton_activar" 
                            OnClientClick="cambiarvalor()" Text="Nuevo Usuario" Visible="False" />
                    </td>
                    <td>
                    </td>
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
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </div>
        <div style="width: 100%; text-align: center;">
            <div style="padding-left: 5%; padding-top: 5px; width: 90%; display: block; float: left;">
                <table width="100%">
                    <tr>
                        <td>
                            <asp:GridView ID="gvDatos" runat="server" CssClass="Grid" AlternatingRowStyle-CssClass="GridAlternateRow"
                                HeaderStyle-CssClass="GridHeader" PagerStyle-CssClass="GridFooter" RowStyle-CssClass="GridRow"
                                AutoGenerateColumns="False" Width="100%">
                                <AlternatingRowStyle CssClass="GridAlternateRow"></AlternatingRowStyle>
                                <Columns>
                                    <asp:BoundField DataField="USUARIO" HeaderText="USUARIO">
                                        <HeaderStyle Height="30px" VerticalAlign="Middle" />
                                        <ItemStyle Height="30px" Width="10%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ESTADO" HeaderText="ESTADO">
                                        <HeaderStyle Height="30px" VerticalAlign="Middle" />
                                        <ItemStyle Height="30px" Width="10%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SESIONES" HeaderText="SESIONES">
                                        <HeaderStyle Height="30px" VerticalAlign="Middle" />
                                        <ItemStyle Height="30px" Width="5%" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="ROL ASIGNADO">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hfRolUsuario" runat="server" Value='<%# Eval("INTROLCODIGO") %>' />
                                            <asp:DropDownList ID="ddlRolUsuario" runat="server" CssClass="CajaCombo" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlRolUsuario_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <HeaderStyle Height="30px" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle Height="30px" Width="15%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="btnActivarUsuario" runat="server" Text=" Activar sesión " CssClass="boton_activar"
                                                OnClientClick="cambiarvalor();" OnClick="btnActivarUsuario_Click" />
                                        </ItemTemplate>
                                        <HeaderStyle Height="30px" VerticalAlign="Middle" />
                                        <ItemStyle Height="30px" Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="btnLiberarSesion" runat="server" Text="Liberar sesiones" CssClass="boton_regresar"
                                                OnClientClick="{cambiarvalor();javascript:return confirm('Estas seguro(a) LIBERAR LAS SESIONES?','SADE');}"
                                                OnClick="btnLiberarSesion_Click" />
                                        </ItemTemplate>
                                        <HeaderStyle Height="30px" VerticalAlign="Middle" />
                                        <ItemStyle Height="30px" Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="btnEliminarUsuario" runat="server" Text="Eliminar usuario" CssClass="boton_regresar"
                                                OnClientClick="{cambiarvalor();javascript:return confirm('Estas seguro(a) ELIMINAR USUARIO?','SADE');}"
                                                OnClick="btnEliminarUsuario_Click" />
                                        </ItemTemplate>
                                        <HeaderStyle Height="30px" VerticalAlign="Middle" />
                                        <ItemStyle Height="30px" Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Aud.Creación" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUsuCrea" Text='<%# Eval("VCHAUDUSUCREACION") %>' runat="server"></asp:Label><br />
                                            <asp:Label ID="lblFecCrea" Text='<%# Eval("DTMAUDFECCREACION") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="20%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Aud.Modificación" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUsuMod" Text='<%# Eval("VCHAUDUSUMODIF") %>' runat="server"></asp:Label><br />
                                            <asp:Label ID="lblFecMod" Text='<%# Eval("DTMAUDFECMODIF") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="20%" />
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader"></HeaderStyle>
                                <PagerStyle CssClass="GridFooter"></PagerStyle>
                                <RowStyle CssClass="GridRow"></RowStyle>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
            <asp:Label ID="lblMensajeError" Style="color: #D34434; font-size: 12px;" runat="server"
                Text=""></asp:Label>
        </div>
    </asp:Panel>

<div id="agregarOperador" class="white_content">
          <table width="100%" class="Tabla">
            <colgroup valign="top">
                <col width="5%" />
                <col width="15%" />
                <col width="15%" />
                <col width="15%" />
                <col width="15%" />
                <col width="15%" />
                <col width="15%" />
                <col width="5%" />
            </colgroup>
            <tr>
                <td style="background-color: #f0f0f0">
                </td>
                <td style="background-color: #f0f0f0; vertical-align: middle;" colspan="6" 
                    align="center">
                    <asp:Label ID="Label2" runat="server" Font-Size="Medium" Font-Bold="True">Registrar Usuario</asp:Label>
                </td>
                <td style="background-color: #f0f0f0; vertical-align: middle;">
                    <a href="javascript:void(0)" onclick="document.getElementById('agregarOperador').style.display='none';document.getElementById('fade').style.display='none'">
                        <img src="img/Close.gif" style="border: 0px" align="right" /></a>
                </td>
            </tr>
            <tr>
                <td colspan="8">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="8">&nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>Usuario</td>
                <td><asp:TextBox ID="txtUsuarioAdd" runat="server" CssClass="CajaTextoUpper" 
                        placeholder="Ingrese usuario" Width="100%"></asp:TextBox></td>
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
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td align="right" colspan="2">
                    <asp:Button ID="btnAgregarAceptar" runat="server" CssClass="boton_busca" 
                        Text="Aceptar"  OnClientClick="cambiarvalor()" />
                    &nbsp;<asp:Button ID="btnAgregarCancelar" runat="server" CssClass="boton_busca" 
                        Text="Cancelar" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="8">&nbsp;</td>
            </tr>
            </table>
    </div>
    <div id="fade" class="black_overlay">
    </div>

</asp:Content>
