<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="frmBuscaTetra.aspx.vb" Inherits="frmBuscaTetra" EnableEventValidation="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization = 'True'  EnableScriptLocalization = 'True'    >
</asp:ScriptManager>

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
                <col style= "width:4%" />
                <col style= "width:6%" />
                <col style= "width:5%" />
                <col style= "width:10%" />
                <col style= "width:8%" />
                <col style= "width:10%" />
                <col style= "width:3%" />
                <col style= "width:26%" />
                <col style= "width:5%" />
                <col style= "width:10%" />
                <col style= "width:3%" />
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
            <td style="height :10px;"></td>
            <td style="height :10px;"></td>
            </tr>
            <tr>
            <td>ISSI</td>
            <td><asp:TextBox ID="txtISSI" runat="server" Width="90%"></asp:TextBox></td>
            <td>Sector</td>
            <td>                
            <asp:DropDownList ID="ddlSectorBusca" runat="server" CssClass="CajaCombo" Width="90%"></asp:DropDownList>
            </td>
            <td>Tipo Recurso</td>
            <td>             
            <asp:DropDownList ID="ddlTipoRecurso" runat="server" CssClass="CajaCombo" Width="95%"></asp:DropDownList>
            </td>
            <td>Personal</td>
            <td>
                <asp:TextBox ID="txtPersonal" runat="server" CssClass="mayuscula" Width="95%"></asp:TextBox>
            </td>
            <td>Estado</td>
            <td>
            <asp:DropDownList ID="ddlEstado" runat="server" CssClass="CajaCombo" Width="95%"></asp:DropDownList>
            </td>
            <td>
            </td>
            <td>
            <asp:Button ID="btnBuscar" runat="server" Text="  Buscar   " OnClientClick="cambiarvalor()" CssClass="boton_busca" />
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
                        CssClass="boton_dialogo"  OnClientClick="cambiarvalor()" ToolTip="Registrar asignación de Equipo" />
                    &nbsp;<asp:Button ID="btnModificar" runat="server" Text="Modificar" 
                        CssClass="boton_dialogo"  OnClientClick="cambiarvalor()"
                        ToolTip="Editar asiganción de Equipo" />
                &nbsp;<asp:Button ID="btnEliminar" runat="server" Text=" Eliminar " 
                        CssClass="boton_dialogo"  
                        onclientclick="{cambiarvalor();javascript:return confirm('“¿Está seguro de eliminar la asignación del Equipo?','SADE');}" 
                        ToolTip="Eliminar asignación de Equipo" />
                &nbsp;<asp:Button ID="btnVer" runat="server" Text="Visualizar" 
                        CssClass="boton_dialogo"  OnClientClick="cambiarvalor()"
                        ToolTip="Ver asignación de Equipo" />            
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
            DataKeyNames="INTNISSI,SMLTRECODIGO,SMLSECCODIGO,INTPERCODIGO,SMLESTADO" PageSize="10">
            <RowStyle CssClass="GridRow"></RowStyle>
            <Columns>
                <asp:BoundField HeaderText="ISSI" DataField="INTNISSI">
                    <HeaderStyle HorizontalAlign ="Center" />
                    <ItemStyle Width="10%" HorizontalAlign ="Left" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Sector" DataField="VCHSECDESCRIPCION">
                    <HeaderStyle HorizontalAlign ="Center" />
                    <ItemStyle Width="10%" HorizontalAlign ="Left" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Tipo Recurso" DataField="VCHTREDESCRIPCION">
                    <HeaderStyle HorizontalAlign ="Center" />
                    <ItemStyle Width="15%" HorizontalAlign ="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="VCHNOMBRES" HeaderText="Nombres" >
                    <HeaderStyle HorizontalAlign ="Center" />
                    <ItemStyle Width="30%" HorizontalAlign ="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="VCHOBSERVACION" HeaderText="Observación" >
                    <HeaderStyle HorizontalAlign ="Center" />
                    <ItemStyle Width="30%" HorizontalAlign ="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="VCHESTADO" HeaderText="Estado" >
                    <HeaderStyle HorizontalAlign ="Center" />
                    <ItemStyle Width="5%" HorizontalAlign ="Center" />
                </asp:BoundField>
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

<asp:Panel ID="pnlEdicion" runat="server" Visible="False">

   <div id="pnlBotonesEdicion1">
        <table class="Tabla" style="width: 100%">
            <colgroup>
                <col style="width: 5%" />
                <col style="width: 1%" />
                <col style="width: 5%" />
                <col style="width: 90%" />
            </colgroup>
            <tr>
                <td align="center" valign="middle">
                    <asp:Button ID="btnGrabar" runat="server" Text=" Grabar " CssClass ="boton_dialogo" 
                        onclientclick="javascript:return confirm('¿ESTA SEGURO DE REALIZAR LA OPERACION?','SADE');" />
                </td>
                <td></td>
                <td align="center" valign="middle">
                    <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass ="boton_dialogo" />
                </td>
                <td></td>
            </tr>
        </table>
    </div>

   <div id="pnlPuestoFijo" class="busqueda" runat="server">
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
        <table  class="Tabla" style="width: 100%">
            <colgroup>
                <col style="width: 1%"/>
                <col style="width: 9%"/>
                <col style="width: 20%"/>
                <col style="width: 10%"/>
                <col style="width: 25%"/>
                <col style="width: 9%"/>
                <col style="width: 25%"/>
                <col style="width: 1%"/>
            </colgroup>
            <tr style="height: 15px"><td colspan="8"></td>
            </tr>
            <tr>
                <td></td>
                <td>ISSI</td>
                <td><asp:TextBox ID="txtISSIEdit" Width = "95%" runat="server"></asp:TextBox></td>
                <td>Sector</td>
                <td><asp:DropDownList ID="ddlSectorEdit" runat="server" Width = "78%" CssClass ="CajaCombo" AutoPostBack="True">
                    </asp:DropDownList></td>                
                <td>Tipo de Recurso<asp:HiddenField ID="hdNissi" runat="server" />
                </td>
                <td><asp:DropDownList ID="ddlTipoRecursoEdit" runat="server" Width = "78%" CssClass ="CajaCombo" AutoPostBack="True">
                    </asp:DropDownList></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td>Personal</td>
                <td colspan="3"><asp:TextBox ID="txtPersonalEdit" Width = "95%" runat="server" 
                        Enabled="False"></asp:TextBox></td>                    
                <td>
                    <asp:HiddenField ID="hdIdPersonalEdit" runat="server" />
                    <asp:HiddenField ID="hdTipoAccion" runat="server" />
                </td>
                <td>
                    <input id="btnBuscarPer" type="button" value="Buscar" onclick="popupMostrarAdjunto();" class="boton_dialogo"  runat="server" />                    
                </td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td valign="middle">Observación</td>
                <td colspan = "3">
                    <asp:TextBox ID="txtObservacion" CssClass="mayuscula" runat="server" Width = "95%" Height="60px" 
                        TextMode="MultiLine"></asp:TextBox></td>                
                <td>Estado</td>
                <td><asp:DropDownList ID="ddlEstadoEdit" runat="server" Width = "78%" CssClass ="CajaCombo" AutoPostBack="True">
                    </asp:DropDownList></td>
                <td></td>
            </tr>
            <tr style="height: 15px"><td></td><td></td><td colspan="3" align="center"><asp:Label ID="lblMensajeReg" runat="server" Text="" ForeColor="#CC0000"></asp:Label></td><td></td><td></td>
            </tr>
        </table>
        </ContentTemplate>
        </asp:UpdatePanel>
   </div>        
   
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
            <td style="background-color: #f0f0f0; vertical-align: middle;"
                align="center">
                <asp:Label ID="Label7" runat="server" Font-Size="Medium" Font-Bold="True">Buscar Personal</asp:Label>
            </td>
            <td style="background-color: #f0f0f0; vertical-align: middle;">
                <a href="javascript:void(0)" onclick="document.getElementById('verimagen').style.display='none';document.getElementById('fade').style.display='none'">
                    <img src="img/Close.gif" style="border: 0px" align="right" /></a>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <div id="gridpersonal">
                    <table style="width: 100%;" class="Tabla">
                        <colgroup valign="top">
                            <col width="10%" />
                            <col width="80%" />
                            <col width="10%" />
                        </colgroup>
                        <tr>
                           <td align="center">&nbsp;</td>
                           <td align="center">&nbsp;</td>
                           <td align="center">&nbsp;</td>
                       </tr>
                       <tr>
                           <td align="center">Nombres</td>
                           <td align="center">
                               <asp:TextBox ID="txtNomPersonal" CssClass="mayuscula" Width="80%" runat="server"></asp:TextBox></td>
                           <td align="center">
                               <asp:Button ID="btnBuscarPersonal" runat="server" Text="Buscar" /></td>
                       </tr>
                       <tr>
                           <td colspan = "3">
                               <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                               <ContentTemplate>
                                   <asp:GridView ID="gvPersonal" runat="server"
                                   CssClass="Grid" AlternatingRowStyle-CssClass="GridAlternateRow" HeaderStyle-CssClass="GridHeader" PagerStyle-CssClass="GridFooter" 
                                   RowStyle-CssClass="GridRow" AllowPaging="True" AutoGenerateColumns="False" Width="100%" PageSize="10"
                                   DataKeyNames="INTPERCODIGO" onrowcommand="gvPersonal_RowCommand">
                                   <RowStyle CssClass="GridRow"></RowStyle>
                                   <PagerStyle CssClass="GridFooter"></PagerStyle>
                                       <Columns>
                                           <asp:ButtonField ButtonType="Image" CommandName="Seleccionar" HeaderText="" ImageUrl="img/arrow.gif" />
                                           <asp:BoundField DataField="VCHNOMBRES" HeaderText="Personal">
                                               <HeaderStyle HorizontalAlign ="Center" />
                                               <ItemStyle Width="65%" HorizontalAlign ="Left" />
                                           </asp:BoundField>
                                           <asp:BoundField DataField="VCHCRGDESCRIPCION" HeaderText="Cargo" >
                                               <HeaderStyle HorizontalAlign ="Center" />
                                               <ItemStyle Width="20%" HorizontalAlign ="Left" />
                                           </asp:BoundField>
                                           <asp:BoundField DataField="VCHSECDESCRIPCION" HeaderText="Sector" >
                                               <HeaderStyle HorizontalAlign ="Center" />
                                               <ItemStyle Width="15%" HorizontalAlign ="Left" />
                                           </asp:BoundField>
                                       </Columns>
                                   <EmptyDataTemplate>
                                        <asp:Label ID="Label37" runat="server" Text="No existen registros para mostrar" CssClass="Tabla"></asp:Label>
                                   </EmptyDataTemplate>
                                   <HeaderStyle CssClass="GridHeader"></HeaderStyle>
                                   <AlternatingRowStyle CssClass="GridAlternateRow"></AlternatingRowStyle>
                                   <SelectedRowStyle  CssClass = "GridSeletedRow" />
                                   </asp:GridView>
                               </ContentTemplate>
                               <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="gvPersonal" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="gvPersonal" EventName="PageIndexChanging" />
                                    <asp:AsyncPostBackTrigger ControlID="txtNomPersonal" EventName="TextChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="btnBuscarPersonal" EventName="Click" />
                               </Triggers>
                            </asp:UpdatePanel>
                           </td>
                       </tr>                       
                   </table>
                </div>
            </td>
        </tr>
        </table>
    </div>

    <div id="fade" class="black_overlay">
    </div>
</asp:Panel>

</asp:Content>

