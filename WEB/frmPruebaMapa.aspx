<%@ Page Title="" Language="VB" MasterPageFile="~/SiteMap.master" AutoEventWireup="false" CodeFile="frmPruebaMapa.aspx.vb" Inherits="frmPruebaMapa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link type="text/css"
href="css/smoothness/jquery-ui-1.10.2.custom.css" rel="Stylesheet" />
    <script type="text/javascript"
src="JavaScript/jquery-1.7.2.js">
    </script>
    <script type="text/javascript"
src="JavaScript/jquery-ui-1.8.21.custom.min.js">
    </script>  
  
  
  <link href="css/themes/smoothness/jquery-ui-1.10.2.custom.css" rel="stylesheet" type="text/css" />
  <script src="js/jquery-1.9.1.js"></script>
  <script src="js/ui/minified/jquery-ui.custom.min.js" type="text/javascript"></script>
  <script>
      $(document).ready(function () {
          $('#cmdjQueryButton').button();
      });

  </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
 <asp:Button ID="btnEnviar"  runat="server" Text="Enviar" />
    <input id="Button1" type="button"  value="Enviar2" />
    <asp:Button id="cmdjQueryButton" runat="server" Text="jQuery Button" /> 
</asp:Content>

