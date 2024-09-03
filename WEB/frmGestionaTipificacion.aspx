<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false"
    CodeFile="frmGestionaTipificacion.aspx.vb" Inherits="frmGestionaTipificacion"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
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
            top: 30%;
            left: 30%;
            width: 40%;
            height: 35%;
            padding-top:5px;
            padding-bottom:5px;
            padding-left:5px;
            padding-right:5px;
            border: 0px solid #a6c25c;
            background-color: white;
            z-index: 1002;
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
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True"
        EnableScriptLocalization="False" />
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
                <tr>
                    <td align="right">
                        ID
                    </td>
                    <td>
                        <asp:TextBox ID="txtCodigoBus" runat="server" CssClass="CajaTextoUpper" Width="90%"></asp:TextBox>
                    </td>
                    <td align="right">
                        Descripción
                    </td>
                    <td>
                        <asp:TextBox ID="txtDescripBus" runat="server" CssClass="CajaTextoUpper" Width="90%"></asp:TextBox>
                    </td>
                    <td>
                        Clasificacion
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlClasificaBus" runat="server" CssClass="CajaCombo" Width="95%">
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        Estado
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlEstadoBus" runat="server" CssClass="CajaCombo" Width="95%">
                        </asp:DropDownList>
                    </td>
                    <td colspan="2">
                        <asp:Button ID="btnBuscar" runat="server" CssClass="boton_busca" Text=" Buscar " />
                        
                    </td>
                    <td>
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
        </div>
        <div style="width: 100%;">
            <div style="padding-left: 5%; padding-top: 5px; width: 90%; display: block; float: left;">
                <table width="100%">
                    <tr>
                        <td>
                            <asp:GridView ID="gvDatos" runat="server" CssClass="Grid" AlternatingRowStyle-CssClass="GridAlternateRow"
                                HeaderStyle-CssClass="GridHeader" PagerStyle-CssClass="GridFooter" RowStyle-CssClass="GridRow"
                                AutoGenerateColumns="False" Width="100%" ShowFooter="True">
                                <AlternatingRowStyle CssClass="GridAlternateRow"></AlternatingRowStyle>
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                        <asp:Button ID="btnAgregar" runat="server" CssClass="boton_registrar" Text=" + " Width="50px" OnClick="btnAgregar_Click"/>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Button ID="btnEditar" runat="server" Text='<%# Eval("SMLTINCODIGO") %>' Width="50px"
                                                CssClass="boton_consultar" OnClick="btnEditar_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="VCHTINDESCRIPCION" HeaderText="DESCRIPCION">
                                        <HeaderStyle Height="20px" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SMLCINCODIGO" HeaderText="">
                                        <HeaderStyle Height="20px" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="VCHCINDESCRIPCION" HeaderText="CLASIFICACION">
                                        <HeaderStyle Height="20px" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SMLTINESTADO" HeaderText="ESTADO">
                                        <HeaderStyle Height="20px" VerticalAlign="Middle" />
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="Aud.Creación" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUsuCrea" Text='<%# Eval("VCHAUDUSUCREACION") %>' runat="server"></asp:Label><br />
                                            <asp:Label ID="lblFecCrea" Text='<%# Eval("DTMAUDFECCREACION") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="20%" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Aud.Creación" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUsuModif" Text='<%# Eval("VCHAUDUSUMODIF") %>' runat="server"></asp:Label><br />
                                            <asp:Label ID="lblFecModif" Text='<%# Eval("DTMAUDFECMODIF") %>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="20%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                        <asp:Button ID="btnTipoDelete" runat="server" CommandName="Delete" 
                                                     Text="Eliminar" OnClientClick="return confirm('Seguro de Eliminar Tipo ?');" />
                                        </ItemTemplate>
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
    <asp:Panel ID="pnlDetalle" runat="server" Visible="false">
        <table width="100%" cellspacing="5px" cellpadding="5px">
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
                <td>&nbsp;</td>
                <td align="center">Tipo</td>
                <td><asp:TextBox ID="txtCodTipoEdit" runat="server" CssClass="CajaTextoCOff" 
                        Width="50%"></asp:TextBox></td>
                <td align="center">Descripción</td>
                <td><asp:TextBox ID="txtDesTipoEdit" runat="server" CssClass="CajaTextoCOff" 
                        Width="80%"></asp:TextBox></td>
                <td align="center">Clasificación</td>
                <td><asp:TextBox ID="txtClaseEdit" runat="server" CssClass="CajaTextoCOff" 
                        Width="80%"></asp:TextBox></td>
                <td align="center">Estado</td>
                <td><asp:TextBox ID="txtEstadoEdit" runat="server" CssClass="CajaTextoCOff" 
                        Width="50%"></asp:TextBox></td>
                <td><asp:Button ID="btnAddSubtipoCab" runat="server" Text="+" Width="50px" CssClass="boton_registrar" OnClick="btnAddSubtipo_Click" />
                <asp:Button ID="btnRegresar" runat="server" CssClass="boton_busca" Text=" Regresar " /></td>
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
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                </td>
                <td colspan="8">
                    
                    <asp:GridView ID="gvDetalle" runat="server" 
                        AlternatingRowStyle-CssClass="GridAlternateRow" AutoGenerateColumns="False" 
                        CssClass="Grid" HeaderStyle-CssClass="GridHeader" 
                        PagerStyle-CssClass="GridFooter" RowStyle-CssClass="GridRow" ShowFooter="True" 
                        Width="100%">
                        <AlternatingRowStyle CssClass="GridAlternateRow" />
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Button ID="btnAddSubtipo" runat="server" Text="+" Width="50px" CssClass="boton_registrar"
                                        OnClick="btnAddSubtipo_Click" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Button ID="btnEditSubtipo" runat="server" Text='<%# Eval("SMLSTICODIGO") %>'
                                        Width="50px" CssClass="boton_consultar" OnClick="btnAddSubtipo_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="lblEditTipo" runat="server" Text='<%# Eval("SMLTINCODIGO") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="VCHSTIDESCRIPCION" HeaderText="DESCRIPCION">
                                <HeaderStyle Height="20px" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMLPRICODIGO" HeaderText="P">
                                <HeaderStyle Height="20px" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="VCHPRIDESCRIPCION" HeaderText="PRIORIDAD">
                                <HeaderStyle Height="20px" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SMLSTIESTADO" HeaderText="ESTADO">
                                <HeaderStyle Height="20px" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Aud.Creación" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblUsuCreaST" Text='<%# Eval("VCHAUDUSUCREACION") %>' runat="server"></asp:Label><br />
                                    <asp:Label ID="lblFecCreaST" Text='<%# Eval("DTMAUDFECCREACION") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="20%" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Aud.Creación" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblUsuModifST" Text='<%# Eval("VCHAUDUSUMODIF") %>' runat="server"></asp:Label><br />
                                    <asp:Label ID="lblFecModifST" Text='<%# Eval("DTMAUDFECMODIF") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="20%" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                <asp:Button ID="btnSubtipoDelete" runat="server" CommandName="Delete" 
                                             Text="Eliminar" OnClientClick="return confirm('Seguro de Eliminar Subtipo ?');" />
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                        <HeaderStyle CssClass="GridHeader" />
                        <PagerStyle CssClass="GridFooter" />
                        <RowStyle CssClass="GridRow" />
                    </asp:GridView>
                </td>
                <td>
                </td>
            </tr>
        </table>
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
                <td style="background-color: #f0f0f0; vertical-align: middle;" colspan="6" align="center">
                    <asp:Label ID="Label2" runat="server" Font-Size="Medium" Font-Bold="True">Registrar Tipo Incidencia</asp:Label>
                </td>
                <td style="background-color: #f0f0f0; vertical-align: middle;">
                    <a href="javascript:void(0)" onclick="document.getElementById('agregarOperador').style.display='none';document.getElementById('fade').style.display='none'">
                        <img src="img/Close.gif" style="border: 0px" align="right" /></a>
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
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    Id Tipo
                </td>
                <td>
                    <asp:TextBox ID="txtTipoAdd" runat="server" CssClass="CajaTextoUpper" MaxLength="5"
                        placeholder="0" Width="50%" Enabled="False"></asp:TextBox>
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
            <tr>
                <td>
                </td>
                <td>
                    Descripción
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtDescripcionAdd" runat="server" CssClass="CajaTextoUpper" MaxLength="30"
                        placeholder="Descripción Tipo" Width="100%"></asp:TextBox>
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
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    Clasificación
                </td>
                <td colspan="2">
                    <asp:DropDownList ID="ddlClasificaAdd" runat="server" CssClass="CajaCombo" Width="95%">
                    </asp:DropDownList>
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
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    Estado
                </td>
                <td colspan="2">
                    <asp:DropDownList ID="ddlEstadoAdd" runat="server" CssClass="CajaCombo" Width="95%">
                    </asp:DropDownList>
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
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td align="right" colspan="2">
                    <asp:Button ID="btnAgregarAceptar" runat="server" CssClass="boton_busca" Text="Aceptar"
                        OnClientClick="cambiarvalor()" />
                    &nbsp;<asp:Button ID="btnAgregarCancelar" runat="server" CssClass="boton_busca" Text="Cancelar" />
                </td>
                <td>
                </td>
                <td>
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
            </tr>
        </table>
    </div>

    <div id="editarSubtipo" class="white_content">


        <table width="100%" class="Tabla" style="cellpadding:30px; cellspacing:30px; border:0;">
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
                <td style="background-color: #f0f0f0; vertical-align: middle;" colspan="6" align="center">
                    <asp:Label ID="Label1" runat="server" Font-Size="Medium" Font-Bold="True">Registrar SubTipo Incidencia</asp:Label>
                </td>
                <td style="background-color: #f0f0f0; vertical-align: middle;">
                    <a href="javascript:void(0)" onclick="document.getElementById('editarSubtipo').style.display='none';document.getElementById('fade').style.display='none'">
                        <img src="img/Close.gif" style="border: 0px" align="right" /></a>
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
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    Id SubTipo
                </td>
                <td>
                    <asp:TextBox ID="txtSubtipoEdit" runat="server" CssClass="CajaTextoUpper" MaxLength="5"
                        placeholder="0" Width="50%" Enabled="False"></asp:TextBox>
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
                </td>
                <td>
                    Descripción
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtDescSubtipoEdit" runat="server" CssClass="CajaTextoUpper" MaxLength="30"
                        placeholder="Descripción SubTipo" Width="100%"></asp:TextBox>
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
                    &nbsp;
                </td>
                <td>
                    Prioridad</td>
                <td colspan="2">
                    <asp:DropDownList ID="ddlPrioridadSubtipoEdit" runat="server" 
                        CssClass="CajaCombo" Width="95%">
                    </asp:DropDownList>
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
                    Estado
                </td>
                <td colspan="2">
                    <asp:DropDownList ID="ddlEstadoSubtipoEdit" runat="server" CssClass="CajaCombo" 
                        Width="95%">
                    </asp:DropDownList>
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
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td align="right" colspan="2">
                    <asp:Button ID="btnAceptarEditSubtipo" runat="server" CssClass="boton_busca" Text=" Aceptar "
                        OnClientClick="cambiarvalor()" />
                    &nbsp;<asp:Button ID="btnCancelarEditSubtipo" runat="server" CssClass="boton_busca" Text="Cancelar" />
                </td>
                <td>
                </td>
                <td>
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
            </tr>
        </table>
    </div>
    <div id="fade" class="black_overlay">
    </div>
    <asp:HiddenField ID="hfCodTipo" runat="server" />
</asp:Content>
