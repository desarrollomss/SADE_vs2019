<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="frmGestionaRecurso.aspx.vb" Inherits="frmGestionaRecurso" EnableEventValidation="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization = 'True'  EnableScriptLocalization = 'True'    >

</asp:ScriptManager>
    <script src="MapaTematico/OpenLayers-2.13.1/OpenLayers.js" type="text/javascript"></script>
    <%--<script type="text/javascript" src="http://openlayers.org/api/OpenLayers.js"></script>--%>

<script type="text/javascript">    
    function popupMostrarAdjunto() {
        document.getElementById('verimagen').style.display = 'block';
        document.getElementById('fade').style.display = 'block';
    }
    function validarNum(e) {
        tecla = (document.all) ? e.keyCode : e.which;
        if (tecla == 8) return true;
        patron = /\d/;
        te = String.fromCharCode(tecla);
        return patron.test(te);
    }
</script>


<link href="Styles/accordionmenu.css" rel="stylesheet" type="text/css" />
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
            height: 70%;
            padding: 0px;
            border: 0px solid #a6c25c;
            background-color: white;
            z-index: 1002;
            overflow: auto;
        }
        .mayuscula
        {
            text-transform: uppercase;
        }    
       
        </style>  
<asp:Panel ID="pnlBusqueda" runat="server">    

    <div id="pnlFiltros" class="busqueda">
        <table style ="width:100%" class ="Tabla">
            <colgroup>
                <col style= "width:5%" />
                <col style= "width:5%" />
                <col style= "width:5%" />
                <col style= "width:10%" />

                <col style= "width:5%" />
                <col style= "width:20%" />
                <col style= "width:5%" />
                <col style= "width:20%" />

                <col style= "width:5%" />
                <col style= "width:10%" />
                <col style= "width:10%" />
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
                <td>&nbsp;</td>
            </tr>
            <tr>
            <td>Código</td>
            <td><asp:TextBox ID="txtCodRecursoBus" runat="server" 
                    Width="90%"></asp:TextBox></td>
            <td>Tipo</td>
            <td>                
                <asp:DropDownList ID="ddlTipoRecursoBus" runat="server" CssClass="CajaCombo" 
                    Width="90%">
                </asp:DropDownList>
            </td>
            <td>Nombre</td>
            <td>             
                <asp:TextBox ID="txtDesRecursoBus" runat="server" CssClass="mayuscula" 
                    Width="95%"></asp:TextBox>
                </td>
            <td>Descripción</td>
            <td>
                <asp:TextBox ID="txtDesAltRecursoBus" runat="server" CssClass="mayuscula" 
                    Width="95%"></asp:TextBox>
                </td>
            <td>
                Estado</td>
                <td>
                    <asp:DropDownList ID="ddlEstRecursoBus" runat="server" CssClass="CajaCombo" 
                        Width="95%">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="btnBuscar" runat="server" CssClass="boton_busca" 
                        OnClientClick="cambiarvalor()" Text="  Buscar   " />
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
                <td>
                    &nbsp;</td>
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
                    <asp:Button ID="btnNuevo" runat="server" Text="  Nuevo  " CssClass="boton_dialogo"  OnClientClick="cambiarvalor()" 
                        ToolTip="Registrar Recurso de seguridad" />
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="boton_dialogo"  OnClientClick="cambiarvalor()"
                        ToolTip="Editar datos Recurso de seguridad" />
                    <asp:Button ID="btnEliminar" runat="server" Text=" Eliminar " CssClass="boton_dialogo"  
                        onclientclick="{cambiarvalor();javascript:return confirm('“¿Está seguro de eliminar RECURSO ?','SADE');}" 
                        ToolTip="Eliminar Recurso de seguridad" />
                    <asp:Button ID="btnVer" runat="server" Text="Visualizar" CssClass="boton_dialogo"  OnClientClick="cambiarvalor(); "
                        ToolTip="Ver datos Recurso de seguridad" />
                    <asp:Button ID="btnExportar" runat="server" Text="Exportar" CssClass="boton_dialogo"  OnClientClick="cambiarvalor(); "
                        ToolTip="Exportar a Excel" />            
                </td>
            </tr>
            <tr>
                <td colspan="10" align="center">
                    <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="#CC0000"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div id="pnlGrid" class="busqueda" >
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
        <asp:GridView ID="gvTetras" runat="server" CssClass="Grid" AlternatingRowStyle-CssClass="GridAlternateRow"
            HeaderStyle-CssClass="GridHeader" PagerStyle-CssClass="GridFooter" RowStyle-CssClass="GridRow"
            AllowPaging="True" AutoGenerateColumns="False" Width="100%"
            DataKeyNames="INTRECCODIGO" PageSize="15">
            <RowStyle CssClass="GridRow"></RowStyle>
            <Columns>
                    <asp:BoundField DataField="INTRECCODIGO" HeaderText="Código"></asp:BoundField>
                    <asp:BoundField DataField="SMLTRECODIGO" HeaderText="TR" Visible="false"></asp:BoundField>
                    <asp:BoundField DataField="VCHTREDESCRIPCION" HeaderText="Tipo Recurso"></asp:BoundField>
                    <asp:BoundField DataField="VCHRECDESCRIPCION" HeaderText="Nombre"></asp:BoundField>
                    <asp:BoundField DataField="VCHRECCODIGOALTERNO" HeaderText="Descripción"></asp:BoundField>
                    <asp:BoundField DataField="VCHRECCODIGOPATRIMONIAL" HeaderText="Patrimonio"></asp:BoundField>
                    <asp:BoundField DataField="VCHRECMARCA" HeaderText="Marca"></asp:BoundField>
                    <asp:BoundField DataField="VCHRECMODELO" HeaderText="Modelo"></asp:BoundField>
                    <asp:BoundField DataField="VCHRECPLACA" HeaderText="Placa"></asp:BoundField>
                    <asp:BoundField DataField="INTNISSI" HeaderText="ISSI"></asp:BoundField>
                    <asp:BoundField DataField="SMLRECESTADO" HeaderText="E" Visible="False"></asp:BoundField>
                    <asp:BoundField DataField="VCHRECESTADO" HeaderText="Estado"></asp:BoundField>

            </Columns>
            <PagerStyle CssClass="GridFooter"></PagerStyle>
            <EmptyDataTemplate>
                <asp:Label ID="Label37" runat="server" Text="No existen registros para mostrar" CssClass="Tabla"></asp:Label>
            </EmptyDataTemplate>
            <HeaderStyle CssClass="GridHeader"></HeaderStyle>
            <AlternatingRowStyle CssClass="GridAlternateRow"></AlternatingRowStyle>
            <SelectedRowStyle  CssClass = "GridSeletedRow" />
        </asp:GridView>
        </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="gvTetras" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="gvTetras" EventName="PageIndexChanging" />
                <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>      

</asp:Panel>


<asp:Panel ID="pnlEdicion" runat="server" Visible="False" Width ="100%">
    <table width="100%" cellpadding="0px" cellspacing="0px" >
        <colgroup>
            <col width="100%" />
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
                            <td></td>
                            <td align="center" valign="middle">
                                <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="boton_dialogo" OnClientClick="cambiarvalor()" />
                            </td>
                            <td align="center" valign="middle">
                                <asp:HiddenField ID="hdTipoAccion" runat="server" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="pnlPuestoFijo" class="busqueda" runat="server">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <table class="Tabla" style="width: 100%">
                                <colgroup>
                                    <col style="width: 5%" />
                                    <col style="width: 5%" />
                                    <col style="width: 10%" />
                                    <col style="width: 5%" />
                                    <col style="width: 10%" />
                                    <col style="width: 5%" />
                                    <col style="width: 10%" />
                                    <col style="width: 50%" />
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
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        Código</td>
                                    <td>
                                        <asp:TextBox ID="txtCodRecursodEdit" runat="server" Width="95%"></asp:TextBox>
                                    </td>
                                    <td>
                                        Tipo</td>
                                    <td colspan="2">
                                        <asp:DropDownList ID="ddlTipoRecursoEdit" runat="server" AutoPostBack="True" 
                                            CssClass="CajaCombo" Width="95%">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
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
                                    <td colspan="3">
                                        <asp:TextBox ID="txtDesRecursoEdit" runat="server" CssClass="mayuscula" 
                                            Width="80%"></asp:TextBox>
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
                                        Alterno</td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtAltRecursoEdit" runat="server" CssClass="mayuscula" 
                                            Width="95%"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        Placa</td>
                                    <td>
                                        <asp:TextBox ID="txtPlacaRecursoEdit" runat="server" CssClass="mayuscula" 
                                            Width="95%"></asp:TextBox>
                                    </td>
                                    <td>
                                        Marca</td>
                                    <td>
                                        <asp:TextBox ID="txtMarcaRecursoEdit" runat="server" CssClass="mayuscula" 
                                            Width="95%"></asp:TextBox>
                                    </td>
                                    <td>
                                        Modelo</td>
                                    <td>
                                        <asp:TextBox ID="txtModeloRecursoEdit" runat="server" CssClass="mayuscula" 
                                            Width="95%"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        Patrim.</td>
                                    <td>
                                        <asp:TextBox ID="txtPatrimRecursoEdit" runat="server" CssClass="mayuscula" 
                                            Width="95%"></asp:TextBox>
                                    </td>
                                    <td>
                                        ISSI</td>
                                    <td>
                                        <asp:TextBox ID="txtISSIRecursoEdit" runat="server" CssClass="mayuscula" 
                                            Width="95%"></asp:TextBox>
                                    </td>
                                    <td>
                                        Estado</td>
                                    <td>
                                        <asp:DropDownList ID="ddlEstRecursoEdit" runat="server" AutoPostBack="True" 
                                            CssClass="CajaCombo" Width="90%">
                                        </asp:DropDownList>
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
                                </tr>

                                <tr style="height: 15px">
                                    <td>
                                    </td>
                                    <td align="center" colspan="5">
                                        <asp:Label ID="lblMensajeReg" runat="server" ForeColor="#CC0000" Text=""></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </td>
        </tr>
    </table>
<%--<div id="fade" class="black_overlay"></div>--%>
</asp:Panel>

</asp:Content>

