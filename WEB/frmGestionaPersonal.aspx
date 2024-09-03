<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="frmGestionaPersonal.aspx.vb" Inherits="frmGestionaPersonal"  EnableEventValidation="false" %>
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
        #pnlBusqueda
        {
         width : 100%;
         margin-top :0px;
        }        
        #pnlResultado 
        {
         width : 98%;
         float:left;
         margin-left :1%;
         margin-right :1%;
         height :400px; 
        }	
        #pnlBotonera
        {
         width : 100%;
         float:left;
        }        
        </style>   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
<div>
    <div id="busqueda" class="busqueda">
        <table style ="width:100%" class ="Tabla">
            <colgroup>
                <col style= "width:5%" />
                <col style= "width:10%" />
                <col style= "width:10%" />
                <col style= "width:10%" />
                <col style= "width:10%" />
                <col style= "width:10%" />
                <col style= "width:10%" />
                <col style= "width:10%" />
                <col style= "width:10%" />
                <col style= "width:15%" />
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
            <td><asp:Label ID="lblAnioBusca" runat="server" Text="Código"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtCodgoBusca" runat="server" CssClass="CajaTexto" 
                    Width="50px" MaxLength="8"></asp:TextBox>
         
            </td>
            <td>
            <asp:Label ID="Label1" runat="server" Text="Ape. Paterno"></asp:Label>

            </td>
            <td colspan = "2">
                <asp:TextBox ID="txtApePaternoBusca" runat="server" CssClass="CajaTexto" 
                    Width="95%" MaxLength="30"></asp:TextBox>
         
            </td>
            <td>
            <asp:Label ID="lblGrupoServicio" runat="server" Text="Ape. Materno"></asp:Label>
            </td>
            <td colspan = "2">
                <asp:TextBox ID="txtApeMaternoBusca" runat="server" CssClass="CajaTexto" 
                    Width="95%" MaxLength="30"></asp:TextBox>
         
            </td>
            <td>
            <asp:Label ID="lblSectorBusca" runat="server" Text="Nombres"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNombreBusca" runat="server" CssClass="CajaTexto" 
                    Width="95%" MaxLength="30"></asp:TextBox>
         
            </td>
            </tr>
            <tr>
            <td><asp:Label ID="lblAnioBusca0" runat="server" Text="Doc.Ident"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtDniBusca" runat="server" CssClass="CajaTexto" Width="95%" 
                    MaxLength="8"></asp:TextBox>
         
                </td>
            <td>
            <asp:Label ID="Label38" runat="server" Text="Distrito"></asp:Label>

                </td>
            <td colspan="2">
                <asp:DropDownList ID="ddlDistritoBusca" runat="server" CssClass="CajaCombo" 
                    Width="95%">
                </asp:DropDownList>
                </td>
            <td>
            <asp:Label ID="Label39" runat="server" Text="Estado civil"></asp:Label>

                </td>
            <td colspan="2">
                <asp:DropDownList ID="ddlEstadoCivilBusca" runat="server" CssClass="CajaCombo" 
                    Width="95%">
                </asp:DropDownList>
                </td>
            <td>
            <asp:Label ID="lblSectorBusca0" runat="server" Text="Afp"></asp:Label>
                </td>
            <td>
                            <asp:DropDownList ID="ddlAfpBusca" runat="server" CssClass="CajaCombo" 
                                Width="95%">
                            </asp:DropDownList>
                </td>                        
            </tr>
            <tr>
            <td colspan="2"><asp:Label ID="lblAnioBusca1" runat="server" 
                    Text="Grado de instrucción"></asp:Label></td>
            <td colspan="3">
                <asp:DropDownList ID="ddlGradoinstruccionBusca" runat="server" 
                    CssClass="CajaCombo" Width="95%">
                </asp:DropDownList>
                </td>
            <td>
            <asp:Label ID="Label40" runat="server" Text="Cargo"></asp:Label>

                </td>
            <td colspan="2">
                <asp:DropDownList ID="ddlCargoBusca" runat="server" CssClass="CajaCombo" 
                    Width="95%">
                </asp:DropDownList>
                </td>
            <td>
            <asp:Label ID="Label41" runat="server" Text="Sector"></asp:Label>

                </td>
            <td>
                <asp:DropDownList ID="ddlSectorBusca" runat="server" CssClass="CajaCombo" 
                    Width="95%">
                </asp:DropDownList>
                </td>                        
            </tr>
            <tr>
            <td colspan="2"><asp:Label ID="lblAnioBusca2" runat="server" 
                    Text="Modalidad de contrato"></asp:Label></td>
            <td colspan="3">
                <asp:DropDownList ID="ddlModalidadContratoBusca" runat="server" 
                    CssClass="CajaCombo" Width="95%">
                </asp:DropDownList>
                </td>
            <td>
                <asp:Label ID="lblAnioBusca3" runat="server" Text="Estado"></asp:Label></td>
            <td colspan="2">
                <asp:DropDownList ID="ddlEstadoBusca" runat="server" CssClass="CajaCombo" 
                    Width="95%">
                </asp:DropDownList>
                </td>
            <td>
                &nbsp;</td>
            <td>
                            <asp:Button ID="btnBuscar" runat="server" Text="  Buscar   "  OnClientClick ="cambiarvalor();"
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
                <asp:Button ID="btnNuevo" runat="server" Text="  Nuevo  "  OnClientClick ="cambiarvalor();"
                    CssClass="boton_dialogo" />
                &nbsp;<asp:Button ID="btnModificar" runat="server" Text="Modificar"  OnClientClick ="cambiarvalor();"
                    CssClass="boton_dialogo" />
                &nbsp;<asp:Button ID="btnEliminar" runat="server" Text="Eliminar"  
                    CssClass="boton_dialogo" 
                    
                    
                    onclientclick="{cambiarvalor();javascript:return confirm('Estas seguro(a) de eliminar?','SADE');}" />
                &nbsp;&nbsp;</td>
        </tr>
        <tr>
            <td colspan="10" style="height:10px; text-align :center;">
                <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="#CC0000"></asp:Label>
            </td>
        </tr>
    </table>
</div>
<div id= "pnlBusqueda">
<div id="pnlResultado" >
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <asp:GridView ID="gvDatos" runat="server" CssClass="Grid" AlternatingRowStyle-CssClass="GridAlternateRow"
        HeaderStyle-CssClass="GridHeader" PagerStyle-CssClass="GridFooter" RowStyle-CssClass="GridRow"
        AllowPaging="True"  Width="100%" AutoGenerateColumns="False" DataKeyNames="INTPERCODIGO">
                        <Columns>
                            <asp:BoundField DataField="INTPERCODIGO" HeaderText="Código">
                                <ItemStyle Width="5%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="VCHCOMPLETO" HeaderText="Apellidos y nombres">
                                <ItemStyle Width="35%" />
                            </asp:BoundField>
                           <asp:BoundField DataField="VCHPERDNI" HeaderText="Dni">
                                <ItemStyle Width="5%" />
                            </asp:BoundField>
                           <asp:BoundField DataField="VCHCRGDESCRIPCION" HeaderText="Cargo">
                                <ItemStyle Width="20%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CHRPERMODALIDADDES" HeaderText="Modalidad">
                                <ItemStyle Width="20%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="VCHSECDESCRIPCION" HeaderText="Sector">
                                <ItemStyle Width="5%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="VCHPERESTADODES" HeaderText="Estado">
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                        </Columns>
                 
<HeaderStyle CssClass="GridHeader"></HeaderStyle>

        <PagerStyle CssClass="GridFooter"></PagerStyle>
<AlternatingRowStyle CssClass="GridAlternateRow"></AlternatingRowStyle>
        <EmptyDataTemplate>
            <asp:Label ID="Label37" runat="server" Text="No existen registros para mostrar" CssClass="Tabla"></asp:Label>
        </EmptyDataTemplate>

<RowStyle CssClass="GridRow"></RowStyle>

         <SelectedRowStyle CssClass="GridSeletedRow" />
    </asp:GridView>
        </ContentTemplate>

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

