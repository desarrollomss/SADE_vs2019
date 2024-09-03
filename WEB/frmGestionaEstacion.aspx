﻿<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false"
    CodeFile="frmGestionaEstacion.aspx.vb" Inherits="frmGestionaEstacion"  EnableEventValidation="false"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
		    top: 30%;
		    left: 30%;
		    width: 40%;  
		    height: 35%;
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
    <asp:ScriptManager ID="ScriptManager1" runat="server" 
    EnableScriptGlobalization="True" EnableScriptLocalization="False" />

    <asp:Panel ID="pnlBusqueda" runat="server">
        <div id="pnlFiltros" class="busqueda">
            <table style="width: 100%" class="Tabla">
                <colgroup>
                    <col style="width: 10%" />
                    <col style="width: 10%" />
                    <col style="width: 10%" />
                    <col style="width: 10%" />
                    <col style="width: 10%" />
                    <col style="width: 10%" />
                    <col style="width: 10%" />
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
                </tr>
                <tr>
                    <td></td>
                    <td align="right">
                        IP / Usuario
                    </td>
                    <td>
                        <asp:TextBox ID="txtUsuarioBus" runat="server" Width="90%" CssClass="CajaTextoUpper"></asp:TextBox>
                    </td>
                    <td align="right">Descripción
                    </td>
                    <td>
                        <asp:TextBox ID="txtDescripBus" runat="server" Width="90%" CssClass="CajaTextoUpper"></asp:TextBox>
                    </td>

                    <td align="right">
                        Estado
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlEstOperadorBus" runat="server" CssClass="CajaCombo" 
                            Width="95%">
                        </asp:DropDownList>
                    </td>
                    <td colspan="2">
                        <asp:Button ID="btnBuscar" runat="server" CssClass="boton_busca" Text=" Buscar " />
                        <asp:Button ID="btnAgregar" runat="server" CssClass="boton_activar" Text=" Nuevo " />
                    </td>
                    <td></td>
                    <td></td>
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
                                AutoGenerateColumns="False" Width="100%" ShowFooter="True">
                                <AlternatingRowStyle CssClass="GridAlternateRow"></AlternatingRowStyle>
                                <Columns>
                                    <asp:BoundField DataField="VCHESTCNUMIP" HeaderText="IP / USUARIO">
                                        <HeaderStyle Height="20px" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="VCHESTCDESCRI" HeaderText="DESCRIPCION">
                                        <HeaderStyle Height="20px" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="INTESTCESTADO" HeaderText="ESTADO">
                                        <HeaderStyle Height="20px" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="ESTADO">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hfEstadoEstacion" runat="server" Value='<%# Eval("INTESTCESTADO") %>' />
                                            <asp:DropDownList ID="ddlEstadoEstacion" runat="server" CssClass="CajaCombo" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlEstadoEstacion_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <HeaderStyle Height="30px" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle Height="30px" Width="15%" />
                                    </asp:TemplateField>


                                    <asp:BoundField DataField="VCHAUDUSUCREACION" HeaderText="Usu.Creación">
                                        <HeaderStyle Height="10px" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DTMAUDFECCREACION" HeaderText="Fec.Creación">
                                        <HeaderStyle Height="10px" VerticalAlign="Middle" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="VCHAUDUSUMODIF" HeaderText="Usu.Modificicación">
                                        <HeaderStyle Height="10px" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DTMAUDFECMODIF" HeaderText="Fec.Modificicación">
                                        <HeaderStyle Height="10px" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="btnEliminarEstacion" runat="server" Text="Eliminar" 
                                                OnClientClick="{cambiarvalor();javascript:return confirm('Estas seguro(a) ELIMINAR ESTACION?','SADE');}"
                                                OnClick="btnEliminarEstacion_Click" />
                                        </ItemTemplate>
                                        <HeaderStyle Height="30px" VerticalAlign="Middle" />
                                        <ItemStyle Height="30px" Width="10%" />
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
                    <asp:Label ID="Label2" runat="server" Font-Size="Medium" Font-Bold="True">Registrar Estación</asp:Label>
                </td>
                <td style="background-color: #f0f0f0; vertical-align: middle;">
                    <a href="javascript:void(0)" onclick="document.getElementById('agregarOperador').style.display='none';document.getElementById('fade').style.display='none'">
                        <img src="img/Close.gif" style="border: 0px" align="right" /></a>
                </td>
            </tr>
            <tr>
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
                <td></td>
                <td>Estación / IP</td>
                <td><asp:TextBox ID="txtEstacionAdd" runat="server" CssClass="CajaTextoUpper" MaxLength="15" 
                        placeholder="Estación" Width="100%"></asp:TextBox>
                </td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
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
                <td></td>
                <td>Descripción</td>
                <td colspan="2">
                <asp:TextBox ID="txtDescripcionAdd" runat="server" CssClass="CajaTextoUpper" MaxLength="30" 
                        placeholder="Descripción" Width="100%"></asp:TextBox>
                </td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
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
                <td>&nbsp;</td>
                <td>Estado</td>
                <td colspan="2">
                    <asp:DropDownList ID="ddlEstOperadorAdd" runat="server" CssClass="CajaCombo" Width="95%">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
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
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td align="right" colspan="2">
                    <asp:Button ID="btnAgregarAceptar" runat="server" CssClass="boton_busca" 
                        Text="Aceptar"  OnClientClick="cambiarvalor()" />
                    &nbsp;<asp:Button ID="btnAgregarCancelar" runat="server" CssClass="boton_busca" 
                        Text="Cancelar" />
                </td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>

            </table>
    </div>


    <div id="fade" class="black_overlay">
    </div>

</asp:Content>
