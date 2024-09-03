<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="frmConfigura.aspx.vb" Inherits="frmConfigura" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

<link href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.2/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-Smlep5jCw/wG7hdkwQ/Z5nLIefveQRIY9nfy6xoR1uRYBtpZgI6339F5dgvm/e9B" crossorigin="anonymous">
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.2/js/bootstrap.min.js" integrity="sha384-o+RDsa0aLu++PJvFqy8fFScvbHFLtbvScb8AjopnFD+iEQ7wo/CG0xlczd+2O/em" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.2/js/bootstrap.bundle.min.js" integrity="sha384-CS0nxkpPy+xUkNGhObAISrkg/xjb3USVCwy+0/NMzd5VxgY4CMCyTkItmy5n0voC" crossorigin="anonymous"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <div class="panel panel-success">
        <div class="panel-heading">
            <i class="icono fa fa-gear"></i>
            <label class="titulo">
                Configuración
            </label>
        </div>
        <div class="panel-body">
            <div class="panel panel-default">
                <div class="panel-heading panel-body">
                    <label class="titulo">
                        Capacidades del Browser
                    </label>
                </div>
                <div class="panel-body">
                    <table id="tbContenedorCapacidadBrowser" class="table">
                    <tbody>
                        <tr>
                            <td style="width: 25%" >
                                <asp:Label ID="lblTitBrowser" runat="server" Text="Browser Cliente" ></asp:Label>
                            </td>
                            <td style="width: 75%">
                                <asp:Label ID="lblBrowser" runat="server" SkinID="LblResaltadoRojo" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%" >
                                <asp:Label ID="lblTitPlataforma" runat="server" Text="Plataforma" ></asp:Label>
                            </td>
                            <td style="width: 75%">
                                <asp:Label ID="lblPlataforma" runat="server" SkinID="LblResaltadoRojo" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%" >
                                <asp:Label ID="lblTitSoportaTablas" runat="server" Text="Soporta Tablas" ></asp:Label>
                            </td>
                            <td style="width: 75%">
                                <asp:Label ID="lblSoportaTablas" runat="server" SkinID="LblResaltadoRojo" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%" >
                                <asp:Label ID="lblTitSoportaCookies" runat="server" Text="Soporta Cookies" ></asp:Label>
                            </td>
                            <td style="width: 75%">
                                <asp:Label ID="lblSoportaCookies" runat="server" SkinID="LblResaltadoRojo" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%" >
                                <asp:Label ID="lblTitSoportaVisualBasicScript" runat="server" Text="Soporta Visual Basic Script"
                                    ></asp:Label>
                            </td>
                            <td style="width: 75%">
                                <asp:Label ID="lblSoportaVisualBasicScript" SkinID="LblResaltadoRojo" runat="server"
                                    Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%" >
                                <asp:Label ID="lblTitSoportaJavaScript" runat="server" Text="Soporta Java Script"
                                    ></asp:Label>
                            </td>
                            <td style="width: 75%">
                                <asp:Label ID="lblSoportaJavaScript" runat="server" SkinID="LblResaltadoRojo" Text=""></asp:Label>
                            </td>
                        </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="panel panel-default">
                <div class="panel-heading panel-body">
                    <label class="titulo">
                        Variables del Servidor
                    </label>
                </div>
                <div class="panel-body">
                    <table id="tbContenedorVariablesServidor" class="table">
                        <tbody>
                        <tr>
                            <td style="width: 25%" >
                                <asp:Label ID="lblTitBrowserAgente" runat="server" Text="Detalle del Browser" ></asp:Label>
                            </td>
                            <td style="width: 75%">
                                <asp:Label ID="lblBrowserAgente" runat="server" SkinID="LblResaltadoRojo"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%" >
                                <asp:Label ID="lblTitDireccionIPx" runat="server" Text="Dirección IPx" ></asp:Label>
                            </td>
                            <td style="width: 75%">
                                <asp:Label ID="lblDireccionIPx" runat="server" SkinID="LblResaltadoRojo" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%" >
                                <asp:Label ID="lblTitDireccionIP" runat="server" Text="Dirección IP" ></asp:Label>
                            </td>
                            <td style="width: 75%">
                                <asp:Label ID="lblDireccionIP" runat="server" SkinID="LblResaltadoRojo" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%" >
                                <asp:Label ID="lblTitDireccionIPDNS" runat="server" Text="Dirección IP según DNS"
                                    ></asp:Label>
                            </td>
                            <td style="width: 75%">
                                <asp:Label ID="lblDireccionIPDNS" runat="server" SkinID="LblResaltadoRojo" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%" >
                                <asp:Label ID="lblTitServidorDominio" runat="server" Text="Nombre del Servidor de Dominio"
                                    ></asp:Label>
                            </td>
                            <td style="width: 75%">
                                <asp:Label ID="lblServidorDominio" runat="server" SkinID="LblResaltadoRojo" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%" >
                                <asp:Label ID="lblTitPuertoServidor" runat="server" Text="Puerto del Servidor" ></asp:Label>
                            </td>
                            <td style="width: 75%">
                                <asp:Label ID="lblPuertoServidor" runat="server" SkinID="LblResaltadoRojo"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%" >
                                <asp:Label ID="lblTitSoftwareServidor" runat="server" Text="Software del Servidor"
                                    ></asp:Label>
                            </td>
                            <td style="width: 75%">
                                <asp:Label ID="lblSoftwareServidor" runat="server" SkinID="LblResaltadoRojo"></asp:Label>
                            </td>
                        </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

