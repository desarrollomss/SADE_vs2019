<%@ Page Language="VB" AutoEventWireup="false" CodeFile="_frmLogin0.aspx.vb" Inherits="_frmLogin0" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SADE :: Sistema de Atención de Denuncias y Emergencia</title>
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="IE8" />
    <link href="css/demo.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="css/common.css" />
    <link rel="stylesheet" type="text/css" href="css/style5.css" />
    <link rel="stylesheet" type="text/css" href="css/login_sade.css" />
    <link href="css/boton.css" rel="stylesheet" type="text/css" />
    <link href="css/controles.css" rel="stylesheet" type="text/css" />
    <script src="js/toastr/jquery-1.9.1.min.js" type="text/javascript"></script>
    <%--<script src="http://code.jquery.com/jquery-1.9.1.min.js"></script>--%>
    <link href="js/toastr/content/toastr.css" rel="stylesheet" type="text/css" />
    <script src="js/toastr/scripts/toastr.js" type="text/javascript"></script>
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
            top: 15%;
            left: 30%;
            width: 40%;
            padding: 0px;
            border: 0px solid #a6c25c;
            background-color: white;
            z-index: 1002;
            overflow: auto;
        }
    </style>
</head>
<body>
    <form id="form8" runat="server">
    <div class="container">
        <!-- Codrops top bar -->
        <div class="codrops-top">
            <img src="img/img_municipalidad.png" style="margin-left: 30px; margin-right: 50px;
                margin-top: 30px">
            <img src="img/sistema.png" style="margin-top: 0px">
            <span class="right" style="margin-right: 20px;">
                <img src="img/logo_sade2.png">
            </span>
            <div class="clr">
            </div>
        </div>
        <!--/ Codrops top bar -->
        <section class="main">
			
				<ul class="ch-grid">
                 <!--  BOTÖN 1 -->
					<li>
						<div class="ch-item ch-img-1" style="z-index:3;cursor:hand;">
						</div>

                        <div style="z-index:10; position:relative;">
                        	<img src="img/img_sombra.png">
                        </div>
					</li>
                    
					<li>
						<div class="ch-item ch-img-2" style="z-index:3;">
                           <div style=" padding-left:30em">
                             <div id="wrapper">
                               
                               <div  id="form1" class="login-form">
                                    <div class="header">
                                    <h1>Acceso</h1>
                                    <span>Solo para usuarios registrados</span>
                                    <h1><asp:Label ID="lblMensaje" runat="server" ForeColor="#CC0000" Font-Bold="True" 
                                            Font-Size="Small"></asp:Label></h1>
                                    </div>
                                    <div class="content">
                                        <%--<input name="username" type="text" class="input username" placeholder="Usuario" />--%>
                                    <asp:textbox id="txtUser"  runat="server" Width="170px" CssClass="input username"></asp:textbox>
                                    <div class="user-icon"></div>
                                        <%--<input name="password" type="password" class="input password" placeholder="Contraseña" />--%>
                                    <asp:textbox id="txtPassword" runat="server" Width="170px" TextMode="Password" CssClass="input password"></asp:textbox>
                                    <div class="pass-icon"></div>		
                                    </div>
                            
                                    <div class="footer">
                                    <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="button" 
                                            CausesValidation="False"/>
                                    <asp:LinkButton ID="likCambiarPwd" runat="server" Font-Bold="False" Font-Size="10pt"
                                        ForeColor="#98AF16" CausesValidation="False" Font-Overline="False" Font-Names="Arial" Font-Underline="True">Cambiar  Contraseña</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            
                          </div>  
                       </div>
					   
					</li>
                    
				</ul>
                

				
			</section>
        <div style="background-color: #E9EAEC; height: 0px; z-index: 0; margin-top: -80px;">
            <footer>
            </footer>
        </div>
        <br />
        <br />
        <br />
        <br />
        <br />
    </div>
    <div id="cambioclave" class="white_content">
        <table width="100%" class="Tabla">
            <colgroup valign="top">
                <col width="4%" />
                <col width="1%" />
                <col width="40%" />
                <col width="30%" />
                <col width="15%" />
                <col width="8%" />
                <col width="2%" />
            </colgroup>
            <tr>
                <td style="background-color: #f0f0f0; height: 20px;">
                </td>
                <td style="background-color: #f0f0f0; vertical-align: middle; text-align: center;
                    height: 50px;" colspan="5">
                    <asp:Label ID="Label5" runat="server" Font-Size="Small" Font-Bold="True">Cambio de contraseña</asp:Label>
                </td>
                <td style="background-color: #f0f0f0; vertical-align: middle; height: 50px;">
                    <a href="javascript:void(0)" onclick="document.getElementById('cambioclave').style.display='none';document.getElementById('fade').style.display='none'">
                        <img src="img/Close.gif" style="border: 0px" align="right" /></a>
                </td>
            </tr>
            <tr>
                <td colspan="7" style="height: 50px;">
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
                <td>
                </td>
                <td>
                </td>
                <td align="right">
                    <asp:Label ID="Label1" runat="server" Font-Size="10pt" Text="Usuario"></asp:Label>
                </td>
                <td>
                    &nbsp;<asp:TextBox ID="txtUser2" runat="server" Width="96%" MaxLength="15" CssClass="CajaTexto"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtUser2"
                        ErrorMessage="Ingrese usuario">*</asp:RequiredFieldValidator>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
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
                <td>
                </td>
                <td>
                </td>
                <td align="right">
                    <asp:Label ID="Label2" runat="server" Font-Size="10pt" Text="Contraseña actual"></asp:Label>
                </td>
                <td>
                    &nbsp;<asp:TextBox ID="txtPass2" runat="server" Width="96%" MaxLength="15" TextMode="Password"
                        CssClass="CajaTexto"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPass2"
                        ErrorMessage="Ingrese usuario">*</asp:RequiredFieldValidator>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
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
                <td>
                </td>
                <td>
                </td>
                <td align="right">
                    <asp:Label ID="Label4" runat="server" Font-Size="10pt" Text="Nueva contraseña"></asp:Label>
                </td>
                <td>
                    &nbsp;<asp:TextBox ID="txtNPass2" runat="server" Width="96%" MaxLength="15" TextMode="Password"
                        CssClass="CajaTexto"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNPass2"
                        ErrorMessage="Ingrese usuario">*</asp:RequiredFieldValidator>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
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
                <td>
                </td>
                <td>
                </td>
                <td align="right">
                    <asp:Label ID="Label3" runat="server" Font-Size="10pt" Text="Confirma contraseña"></asp:Label>
                </td>
                <td>
                    &nbsp;<asp:TextBox ID="txtCNPass2" runat="server" Width="96%" MaxLength="15" TextMode="Password"
                        CssClass="CajaTexto"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCNPass2"
                        ErrorMessage="Ingrese usuario">*</asp:RequiredFieldValidator>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
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
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="las nuevas contraseñas no son iguales"
                        ControlToCompare="txtNPass2" ControlToValidate="txtCNPass2">*</asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td colspan="7" style="height: 30px; vertical-align: middle; text-align: center;">
                    <asp:Button ID="btnCambiarContraseña" runat="server" Text="    Aceptar    " 
                        CssClass="boton_registrar" />
                </td>
            </tr>
            <tr>
                <td colspan="7" style="height: 100px;">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div id="fade" class="black_overlay">
    </div>
    </form>
</body>
</html>
