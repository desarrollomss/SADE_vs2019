<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmPopBuscaPersonal.aspx.vb" Inherits="frmPopBuscaPersonal" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Búsqueda de Personal</title>
	<link rel="stylesheet" href="css/master.css">
    <link href="css/boton.css" rel="stylesheet" type="text/css" />
    <link href="css/calendario.css" rel="stylesheet" type="text/css" />
    <link href="css/grid2.css" rel="stylesheet" type="text/css" />
    <link href="css/controles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table width="100%" class="Tabla">
        <colgroup valign="top">
            <col width="2%" />
            <col width="11%" />
            <col width="21%" />
            <col width="11%" />
            <col width="21%"/>
            <col width="11%" />
            <col width="21%" />
            <col width="2%" />
        </colgroup>
<tr>
<td style=" background-color:#f0f0f0"></td>
<td style=" background-color:#f0f0f0; vertical-align:middle;" colspan="6">
<asp:Label ID="lblTituloMantenimiento" runat="server" Font-Size="Medium" 
        Font-Bold="True">Búsqueda de personal</asp:Label>
</td>
<td style=" background-color:#f0f0f0; vertical-align:middle;">&nbsp;</td>
</tr>        
<tr><td colspan="8" style="height:10px;"></td></tr>
<tr>
<td>&nbsp;</td>
<td>
    <asp:Label ID="Label31" runat="server" Text="Código"></asp:Label></td>
<td >
    <asp:TextBox ID="txtCodigoBusca" runat="server" CssClass="CajaTexto" Width="70px" 
        MaxLength="50"></asp:TextBox></td>
<td>
    <asp:Label ID="Label40" runat="server" Text="Cargo"></asp:Label></td>
<td>
    <asp:DropDownList ID="ddlCargoBusca" runat="server" CssClass="CajaCombo" 
        Width="95%">
    </asp:DropDownList>
    </td>
<td>
    <asp:Label ID="Label41" runat="server" Text="Sector"></asp:Label></td>
<td>
    <asp:DropDownList ID="ddlSectorBusca" runat="server" CssClass="CajaCombo" 
        Width="95%">
    </asp:DropDownList>
    </td>
<td>&nbsp;</td>
</tr>
<tr>
<td></td>
<td><asp:Label ID="Label1" runat="server" Text="Apellido Paterno"></asp:Label></td>
<td >
    <asp:TextBox ID="txtPaternoBusca" runat="server" CssClass="CajaTexto" Width="95%" 
        MaxLength="100"></asp:TextBox></td>
<td>
    <asp:Label ID="Label3" runat="server" Text="Apellido Materno"></asp:Label></td>
<td>
    <asp:TextBox ID="txtMaternoBusca" runat="server" CssClass="CajaTexto" Width="95%" 
        MaxLength="100"></asp:TextBox></td>
<td>
    <asp:Label ID="Label2" runat="server" Text="Nombres"></asp:Label></td>
<td>
    <asp:TextBox ID="txtNombreBusca" runat="server" CssClass="CajaTexto" Width="95%" 
        MaxLength="50"></asp:TextBox></td>
<td></td>
</tr>
<tr>
<td colspan="8" style = "height:10px;">&nbsp;</td>
</tr>
<tr>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td >
    &nbsp;</td>
<td>
    &nbsp;</td>
<td>
    &nbsp;</td>
<td>
    &nbsp;</td>
<td align="right">
    <asp:Button ID="btnRecursoBuscar" runat="server" CssClass="boton_busca" 
        Text="   Buscar   " />

            </td>
<td>&nbsp;</td>
</tr>
<tr><td colspan="8" style="height:10px;"></td></tr>
<tr>
<td></td>
            <td class="style1" colspan="6">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                <div style="height: 300px; overflow: auto">
                    <asp:GridView ID="gvPersonalBusca" runat="server" AllowPaging="False" AlternatingRowStyle-CssClass="GridAlternateRow"
                        AutoGenerateColumns="False" CssClass="Grid" HeaderStyle-CssClass="GridHeader"
                        PagerStyle-CssClass="GridFooter" RowStyle-CssClass="GridRow" Width="100%">

                        <Columns>
                            <asp:TemplateField InsertVisible="False" ShowHeader="False">
                                <HeaderStyle />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkSelRecursoBusca" runat="server" CssClass="boton_selecciona" CommandName="Select">Seleccionar</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="5%" />
                            </asp:TemplateField>
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
                    </Triggers>
                </asp:UpdatePanel>
            </td>
<td class="style1"></td>
</tr>
        <tr>
            <td>
            </td>
            <td colspan="6">
                &nbsp;</td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td colspan="6">
                </td>
            <td>
                &nbsp;</td>
        </tr>
</table>
    </form>
</body>
</html>
