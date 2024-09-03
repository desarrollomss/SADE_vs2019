<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="frmRecursosGPS.aspx.vb" Inherits="frmRecursosGPS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<script type="text/javascript">

    function popupMostrarGPS(pURL) {
        var setting = "directories=no,height=900,left=10,location=no,menubar=no,resizable=yes,scrollbars=yes,status=no,toolbar=no,top=10,width=1000";
        window.open(pURL, "Monitorero Recursos GPS", setting);
        
//        window.resizeTo(screen.availWidth,screen.availHeight);
     window.moveTo(0, 0);

    }


</script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
</asp:Content>

