<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="frmRegistraPaqueteRecurso.aspx.vb" Inherits="frmRegistraPaqueteRecurso" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script language="javascript" type="text/javascript">
       function validasector() {
            if (document.getElementById('<%= ddlSector.ClientID %>').value == 0) {
                alert('DEBE INGRESAR UN SECTOR');
                return false;
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
                <col style="width: 10%"/>
                <col style="width: 10%" />
                <col style="width: 10%"/>
                <col style="width: 10%" />
                <col style="width: 19%"/>
                <col style="width: 1%" />
            </colgroup>
            <tr>
            <td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td>
            </tr>
            <tr class="titulo">
                <td></td>
                <td><asp:Label ID="Label9" runat="server" Text="Fecha:"></asp:Label></td>
                <td><asp:Label ID="lblFecha" runat="server" Text=""></asp:Label></td>
                <td></td>
                <td><asp:Label ID="Label10" runat="server" Text="Turno:"></asp:Label></td>
                <td><asp:Label ID="lblTurno" runat="server" Text=""></asp:Label></td>
                <td></td>
                <td></td>
                <td><asp:Label ID="Label1" runat="server" Text="Código de Paquete:"></asp:Label></td>
                <td><asp:Label ID="LblCodigoPaquete" runat="server" Text=""></asp:Label></td>
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
                    <col style="width: 1%" />
                </colgroup>
                <tr>
                <td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td>
                </tr>
                <tr>
                    <td colspan="10" style="height: 5px;">
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        &nbsp;</td>
                    <td colspan="2">
                        </td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td colspan ="3" align="center" valign="middle">
                        <asp:Button ID="btnGrabaPaquete2" runat="server" Text=" Grabar " 
                            CssClass ="boton_dialogo" 
                            onclientclick="javascript:return confirm('¿ESTA SEGURO DE REALIZAR LA OPERACION?','SADE');" />
                        <asp:Button ID="btnCancelaPaquete2" runat="server" Text="Regresar" 
                            CssClass ="boton_dialogo" />
                    </td>
                </tr>
                <tr>
                    <td colspan="7">
                        <asp:CheckBox ID="chkConUbicacion" runat="server" Checked="True" 
                            AutoPostBack="True" Text="Con ubicación" /> 
                    </td>
                    <td colspan="3">
                    </td>
                </tr>
            </table>
        </div>
        <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
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
                <td></td><td>&nbsp;</td><td></td><td></td><td></td><td></td><td></td><td></td><td>&nbsp;</td><td></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Label ID="Label8" runat="server" Text="Sector"></asp:Label></td>
                    <td><asp:DropDownList ID="ddlSector" runat="server" Width = "78%" 
                            CssClass ="CajaCombo" AutoPostBack="True">
                        </asp:DropDownList></td>
                    <td>
                    <asp:Label ID="Label5" runat="server" Text="Cuadrante:"></asp:Label>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                           <asp:DropDownList ID="ddlCuadrante" runat="server" AutoPostBack="True" 
                          CssClass="CajaCombo" Width="98%">
                        </asp:DropDownList>
                        </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlSector" 
                                    EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="ddlCuadrante" 
                                    EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                        </td>
                    <td colspan = "4"></td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Puesto Fijo:"></asp:Label>                        
                    </td>
                    <td colspan="5">
                        <asp:DropDownList ID="ddlPuestoFijo" runat="server" CssClass="CajaCombo" 
                            Width="98%" AutoPostBack="True">
                        </asp:DropDownList>
                        
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnAgregaUbicacion" runat="server" CssClass="boton_dialogo" 
                            onclientclick="javascript:return validasector();" Text="Agregar" />
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan = "8">
                                        <asp:GridView ID="gvUbicacion" runat="server" 
                                            AlternatingRowStyle-CssClass="GridAlternateRow" AutoGenerateColumns="False" 
                                            CssClass="Grid" HeaderStyle-CssClass="GridHeader" 
                                            PagerStyle-CssClass="GridFooter" RowStyle-CssClass="GridRow" 
                                    Width="100%">
                                            <Columns>
                                                <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                    <HeaderStyle />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkEliminaUbicacion" CssClass="boton_eliminar" OnClientClick="javascript:return confirm('Estas seguro(a) de eliminar?','SADE');" runat="server" CommandName="Select" >Eliminar</asp:LinkButton>
                                                    </ItemTemplate>
                                                <ItemStyle Width="9%" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="SMLCUACODIGO" HeaderText="ID">
                                                <ItemStyle Width="1%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="VCHSECDESCRIPCION" HeaderText="Sector">
                                                <ItemStyle Width="10%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="VCHCUACODIGOALTERNO" HeaderText="Cuadrante">
                                                <ItemStyle Width="10%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="VCHPFIUBICACION" HeaderText="Puesto fijo">
                                                <ItemStyle Width="70%" />
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
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        
                    </td>
                    <td colspan = "5">
                    
                    </td>
                    <td colspan="2">
                        <asp:CheckBox ID="chkAlertarAbandono" runat="server" 
                            Text="Alertar abandono de puesto" />
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
     
           </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="chkConUbicacion" 
                    EventName="CheckedChanged" />
                <asp:AsyncPostBackTrigger ControlID="ddlSector" 
                    EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="ddlCuadrante" 
                    EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
        </div>

        <div id="pnlRecurso" class="busqueda">
            &nbsp;<table class="Tabla" style="width: 100%">
                <colgroup>
                    <col style="width: 1%"/>
                    <col style="width: 98%"/>
                    <col style="width: 1%"/>
                </colgroup>
                <tr><td colspan= "3" style="height :5px;"></td></tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Tipo de Paquete:"></asp:Label>
                        <asp:DropDownList ID="ddlTipoPaquete" runat="server" CssClass="CajaCombo" 
                            Width="200px" AutoPostBack="True">
                        </asp:DropDownList>
                         <asp:Button ID="btnCargaPlantilla" runat="server" Text="Cargar plantilla" 
                            CssClass ="boton_dialogo" />
                    </td>
                    <td></td>
                </tr>
                
                <tr>
                    <td></td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                                        <asp:GridView ID="gvRecursos" runat="server" 
                                            AlternatingRowStyle-CssClass="GridAlternateRow" AutoGenerateColumns="False" 
                                            CssClass="Grid" HeaderStyle-CssClass="GridHeader" 
                                            PagerStyle-CssClass="GridFooter" RowStyle-CssClass="GridRow" 
                                    Width="100%">
                                            <Columns>
                                                <asp:BoundField DataField="SMLTRECODIGO" HeaderText="ID">
                                                <ItemStyle Width="1%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="VCHTREDESCRIPCION" HeaderText="Tipo">
                                                <ItemStyle Width="19%" />
                                                </asp:BoundField>
                                                <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                    <HeaderStyle />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" CssClass="boton_busca" runat="server" CommandName="Select" >Asignar</asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="2%" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="VCHRECCODIGOALTERNO" HeaderText="Código">
                                                <ItemStyle Width="10%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="VCHRECDESCRIPCION" HeaderText="Descripción">
                                                <ItemStyle Width="58%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="VCHTABDESCRIPCION" HeaderText="Estado">
                                                <ItemStyle Width="10%" />
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
                                        <br />
                        </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnCargaPlantilla" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="gvRecursos" 
                                    EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="gvRecursosBurca" 
                                    EventName="SelectedIndexChanged" />
                                <asp:AsyncPostBackTrigger ControlID="btnAgregaUbicacion" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="ddlTipoPaquete" 
                                    EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                    <td></td>
                </tr>
            </table>
        </div>
        <div id="pnlPersonal"  class="busqueda">
            <table class="Tabla" style="width: 100%">
                <colgroup>
                    <col style="width: 1%"/>
                    <col style="width: 5%"/>
                    <col style="width: 5%"/>
                    <col style="width: 38%"/>
                    <col style="width: 10%"/>
                    <col style="width: 10%"/>
                    <col style="width: 10%"/>
                    <col style="width: 10%"/>
                    <col style="width: 10%"/>
                    <col style="width: 1%"/>
                </colgroup>
                <tr>
                <td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td>
                </tr>
                <tr><td colspan= "10" style="height :5px;">
                                        &nbsp;</td></tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Persona:"></asp:Label>
                    </td>
                    <td colspan="3">

                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>
                        <asp:DropDownList ID="ddlPersonal" runat="server"  CssClass ="CajaCombo" 
                            Width="99%" AutoPostBack="True">
                        </asp:DropDownList>
                <cc1:ListSearchExtender id="ListSearchExtender1" runat="server" PromptText="_" TargetControlID="ddlPersonal">
                </cc1:ListSearchExtender> 
                        </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnAgregaUbicacion" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="gvUbicacion" 
                                    EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>

                    </td>
                    <td>
                        <asp:Button ID="btnAgregaPersona" runat="server" Text="Agregar" 
                            CssClass ="boton_dialogo" /></td>
                    <td></td>
                    <td></td>
                    <td>
                        &nbsp;</td>
                    <td></td>
                </tr>
                    <tr>
                    <td></td>
                    <td colspan ="8">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                                <asp:GridView ID="gvPersona" runat="server" 
                                    AlternatingRowStyle-CssClass="GridAlternateRow" AutoGenerateColumns="False" 
                                    CssClass="Grid" HeaderStyle-CssClass="GridHeader" 
                                    PagerStyle-CssClass="GridFooter" RowStyle-CssClass="GridRow" Width="100%">
                                        <Columns>
                                                <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                                    <HeaderStyle />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton1" CssClass="boton_eliminar" OnClientClick="javascript:return confirm('Estas seguro(a) de eliminar?','SADE');" runat="server" CommandName="Select" >Eliminar</asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="2%" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="INTPERCODIGO" HeaderText="Código">
                                                <ItemStyle Width="10%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="VCHCOMPLETO" HeaderText="Apellidos y nombres">
                                                <ItemStyle Width="48%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="VCHCRGDESCRIPCION" HeaderText="Cargo">
                                                <ItemStyle Width="30%" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Responsable">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkResponsable" runat="server" 
                                                            oncheckedchanged="chkResponsable_CheckedChanged" AutoPostBack="True" />
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                            </Columns>
                                    <RowStyle CssClass="GridRow" />
                                    <PagerStyle CssClass="GridFooter" />
                                    <EmptyDataTemplate>
                                        <asp:Label ID="Label37" runat="server" CssClass="Tabla" 
                                            Text="No existen registros para mostrar"></asp:Label>
                                    </EmptyDataTemplate>
                                    <HeaderStyle CssClass="GridHeader" />
                                    <AlternatingRowStyle CssClass="GridAlternateRow" />
                                    <SelectedRowStyle BackColor="#f4c237" />
                                </asp:GridView>
                        </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnAgregaPersona" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="gvPersona" 
                                    EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>

                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan ="8">
                        &nbsp;</td>
                    <td></td>
                </tr>
                <tr><td colspan= "10" style="height :5px;"></td></tr>
            </table>
        </div>
        <br />
        <div id="divEstado" class="busqueda">
            <table class="Tabla" style="width: 100%">
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
                <td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td>
                </tr>
                <tr><td colspan= "10" style="height :5px;"></td></tr>
                <tr>
                <td></td>
                <td>
                <asp:Label ID="Label7" runat="server" Text="Comentario:"></asp:Label>
                </td>
                <td colspan = "6">
                <asp:TextBox ID="txtComentario" runat="server" Width = "99%" 
                            CssClass="CajaTexto"></asp:TextBox>
                </td>
                <td></td><td></td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Estado:"></asp:Label>
                    </td>
                    <td colspan = "2">
                        <asp:DropDownList ID="ddlEstado" runat="server" Width = "98%" CssClass ="CajaCombo">
                        </asp:DropDownList>
                    </td>
                    <td colspan="4">
                    </td>
                    <td>
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
                    <col style="width: 1%" />
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
                    <td colspan ="3" align="center">
                        <asp:Button ID="btnGrabaPaquete" runat="server" Text=" Grabar " 
                            CssClass ="boton_dialogo" 
                            onclientclick="javascript:return confirm('¿ESTA SEGURO DE REALIZAR LA OPERACION?','SADE');" />
                        <asp:Button ID="btnCancelaPaquete" runat="server" Text="Regresar" 
                            CssClass ="boton_dialogo" />
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

<div id="detalle" class="white_content">
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
<td style=" background-color:#f0f0f0; vertical-align:middle;" colspan="5">
<asp:Label ID="lblTituloMantenimiento" runat="server" Font-Size="Medium" 
        Font-Bold="True">Búsqueda de Recursos</asp:Label>
</td>
<td style=" background-color:#f0f0f0; vertical-align:middle;"><a href = "javascript:void(0)" onclick = "document.getElementById('detalle').style.display='none';document.getElementById('fade').style.display='none'"><img src="img/Close.gif" style="border :0px" align="right" /></a>
</td>
</tr>        
<tr><td colspan="7" style="height:10px;"></td></tr>
<tr>
<td></td>
<td >
    <asp:Label ID="Label11" runat="server" Text="Descripción"></asp:Label></td>
<td colspan ="2">
    <asp:TextBox ID="txtDesRecBusca" runat="server" CssClass="CajaTexto" Width="90%" 
        MaxLength="100"></asp:TextBox></td>
<td>
    <asp:Label ID="Label31" runat="server" Text="Código"></asp:Label></td>
<td>
    <asp:TextBox ID="txtCodigoRecBusca" runat="server" CssClass="CajaTexto" Width="100px" 
        MaxLength="50"></asp:TextBox></td>
<td></td>
</tr>
<tr><td colspan="7" style="height:10px;"></td></tr>
<tr>
<td></td>
<td colspan="2" >
    <asp:Button ID="btnRecursoBuscar" runat="server" CssClass="boton_busca" 
        Text="Buscar" />
&nbsp;<asp:Button ID="btnRecursoSalir" runat="server" CssClass="boton_busca" 
        Text="Regresar" />
            </td>
<td></td>
<td colspan="3"></td>
</tr>
<tr>
<td></td>
            <td class="style1" colspan="5">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                <div style="height: 300px; overflow: auto">
                    <asp:GridView ID="gvRecursosBurca" runat="server" AllowPaging="False" AlternatingRowStyle-CssClass="GridAlternateRow"
                        AutoGenerateColumns="False" CssClass="Grid" HeaderStyle-CssClass="GridHeader"
                        PagerStyle-CssClass="GridFooter" RowStyle-CssClass="GridRow" Width="100%">
                        <Columns>
                            <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                <HeaderStyle />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkSelRecursoBusca" runat="server" CssClass="boton_busca" CommandName="Select">Agregar</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="10%" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="INTRECCODIGO" HeaderText="Id">
                                <ItemStyle Width="5%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="VCHRECCODIGOALTERNO" HeaderText="Código">
                                <ItemStyle Width="20%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="VCHRECDESCRIPCION" HeaderText="Descripción">
                                <ItemStyle Width="45%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SECTOR" HeaderText="Sector">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="VCHTABDESCRIPCION" HeaderText="Estado">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
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
                        <asp:AsyncPostBackTrigger ControlID="gvRecursos" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="gvRecursosBurca" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
<td class="style1"></td>
</tr>
        <tr>
            <td>
            </td>
            <td colspan="5">
                &nbsp;</td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td colspan="5">
                </td>
            <td>
                &nbsp;</td>
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
<td style=" background-color:#f0f0f0; vertical-align:middle;"><a href = "javascript:void(0)" onclick = "document.getElementById('detalle').style.display='none';document.getElementById('fade').style.display='none'"><img src="img/Close.gif" style="border :0px" align="right" /></a>
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

