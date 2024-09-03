<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="frmEstadistica.aspx.vb" Inherits="frmEstadistica" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization = 'True'  EnableScriptLocalization = 'True'    >
                </asp:ScriptManager>
    <div id="estadistica">
        <table width="100%" class="Tabla">
            <colgroup valign="top">
                <col width="4%" />
                <col width="18%" />
                <col width="20%" />
                <col width="20%" />
                <col width="15%" />
                <col width="21%" />
                <col width="2%" />
            </colgroup>

            <tr>
                <td colspan="7" style="height: 50px;">
                </td>
            </tr>
            <tr class="titulo">
                <td colspan="7" style="text-align: center">
                    <asp:Label ID="Label1" runat="server" Text="Seleccione el tipo de información"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="7" align="center">
                    <asp:RadioButtonList ID="rblTipoInformacion" runat="server"  OnClick="cambiarvalor()"
                        RepeatDirection="Horizontal" Font-Size="11pt" AutoPostBack="True" 
                        CellSpacing="10">
                        <asp:ListItem Value="AS" Selected="True">Incidencias SADE</asp:ListItem>
                        <asp:ListItem Value="UR">Usuarios registrados al Alerta Surco</asp:ListItem>
                    </asp:RadioButtonList>
                </td>

            </tr>

            <tr class="titulo">
                <td colspan="7" 
                    style="text-align: center; padding-top: 20px; padding-bottom: 10px;">
                    <asp:Label ID="Label4" runat="server" Text="Seleccione el tipo de reporte"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="7" align="center">

                            <asp:RadioButtonList ID="rblTipoReporte" runat="server"  OnClick="cambiarvalor()"
                        RepeatDirection="Horizontal" Font-Size="11pt" CellSpacing="10" Enabled="False">
                                <asp:ListItem Value="D" Selected="True">Detallado</asp:ListItem>
                                <asp:ListItem Value="R">Resumido</asp:ListItem>
                            </asp:RadioButtonList>
                </td>

            </tr>
            <tr>
                <td colspan="7" style="height: 30px;">
                </td>
            </tr>
            <tr class="titulo">
                <td colspan="7" style="text-align: center">
                    <asp:Label ID="Label3" runat="server" Text="Seleccione el rango de fecha"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="7" align="center">
                    <asp:TextBox ID="txtDesde" runat="server" CssClass="CajaTexto"  
                        Width="70px"></asp:TextBox>
                    <asp:Image ID="imgDesde" runat="server" ImageAlign="Middle" 
                        ImageUrl="~/img/calendario2.png" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtDesde"
                        ErrorMessage="Fecha inválida" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"
                        Visible="False"></asp:RegularExpressionValidator>   
                    <cc1:maskededitextender ID="MaskedEditExtender6" runat="server" Mask="99/99/9999"
                        MaskType="Date" TargetControlID="txtDesde" >
                    </cc1:maskededitextender>
                    <cc1:calendarextender ID="CalendarExtender5" runat="server" 
                        CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="imgDesde"
                        TargetControlID="txtDesde">
                    </cc1:calendarextender>  
                     &nbsp;&nbsp;&nbsp;AL&nbsp;&nbsp;&nbsp;  
                    <asp:TextBox ID="txtHasta" runat="server" CssClass="CajaTexto"  
                        Width="70px"></asp:TextBox>
                    <asp:Image ID="imgHasta" runat="server" ImageAlign="Middle" 
                        ImageUrl="~/img/calendario2.png" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtHasta"
                        ErrorMessage="Fecha inválida" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"
                        Visible="False"></asp:RegularExpressionValidator>   
                    <cc1:maskededitextender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999"
                        MaskType="Date" TargetControlID="txtHasta" >
                    </cc1:maskededitextender>
                    <cc1:calendarextender ID="CalendarExtender1" runat="server" 
                        CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="imgHasta"
                        TargetControlID="txtHasta">
                    </cc1:calendarextender> 
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
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="7" style="height: 30px;">
                </td>
            </tr>
            <tr>
                <td colspan="7" style="height: 30px; vertical-align: middle; text-align: center;">
                    <asp:Button ID="btnExportar" runat="server"  OnClientClick="cambiarvalor()" CssClass="boton_busca" Text="    Generar    " />
                </td>
            </tr>
            <tr>
                <td colspan="7" style="height: 100px;">
                    <asp:GridView ID="gvEstadistica" runat="server" Visible = "false" >
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="7" style="height: 30px; vertical-align: middle; text-align: center;">
                    <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="#CC0000"></asp:Label>
                </td>
            </tr>

        </table>
    </div>

</asp:Content>

