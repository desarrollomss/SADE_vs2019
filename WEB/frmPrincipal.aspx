<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="frmPrincipal.aspx.vb" Inherits="frmPrincipal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div style="padding-left: 25%; padding-top: 5%; width: 50%; display: block; float: left;">
        <table width="100%">
            <colgroup>
                <col width="20%" />
                <col width="60%" />
                <col width="20%" />
            </colgroup>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td align="center">
                    <asp:Image ID="imgAcceso" runat="server" ImageUrl="~/img/Media/acceso.png" Visible="false" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="center">
                    <asp:Label ID="lblMensaje" Visible="False" runat="server" Font-Bold="True" Font-Size="Large"
                        Font-Names="Arial" ForeColor="Red"></asp:Label>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td align="center">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>


</asp:Content>

