<%@ Page Language="VB" AutoEventWireup="false" CodeFile="confirmaRegistro.aspx.vb"
    Inherits="confirmaRegistro" %>
<!doctype html>

<html lang="en">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width,user-scalable=no"/>
	<link rel="stylesheet" href="http://code.jquery.com/mobile/1.2.0/jquery.mobile-1.2.0.min.css" />
	<script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.min.js"></script>
	<script type="text/javascript" src="http://code.jquery.com/mobile/1.2.0/jquery.mobile-1.2.0.min.js"></script>
</head>


<body>
   <form id="form1" runat="server">
   <div data-role="page" id="inicio">
       <div data-role="header">
           <h3>Municipalidad de Santiago de Surco</h3>
       </div>
       <div data-role="content">
            <p style="font-size:14pt;text-align:center">Activación de Cuenta</p>
            <p style="font-size:16pt;text-align:center">Surco Alerta</p><br />
            <br />
            <p style="text-align:center"><img src="img/SurcoAlerta.png" alt="MSS" width="400" height="200" /></p>
            <br />
            <p style="font-size:12pt;text-align:center"><asp:Label ID="lblResultado" runat="server" Text=""></asp:Label></p>
            <br />
       </div>
       <div data-role="footer">
           <h4>Sistema de Atención de Denuncias y Emergencias</h4>
       </div>
   </div>
   </form>
</body>
</html>
