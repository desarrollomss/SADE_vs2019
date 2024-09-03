<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PagError.aspx.vb" Inherits="PagError" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pagina de Error</title>
   <style type="text/css">
        #pnlContenedor
        {
            width: 100%;
            padding:0.25em;
            text-align:center;
        }
        h4
        {
        	margin-top:2em;
        	margin-bottom:1em;
        	font-size : 18pt;
        	color:#A9D600;
        	font-family: "Trebuchet MS", "Arial", "Helvetica", "Verdana", "sans-serif";
        	font-weight :400;
        }
        h3
        {
        	margin-top:1em;
        	margin-bottom:2em;
        	font-size : 16pt;
        	color:#035989;
        	font-family: "Trebuchet MS", "Arial", "Helvetica", "Verdana", "sans-serif";
        	font-weight :400;
        }
        #btnCargar
        {
	         border:0px;	
             border-right :1px;
             border-color:#A9D600;
             background-color: #035989;
             border-style:solid;
             color: #fff;
             text-shadow:#000 0.1em 0.1em 0.2em;
             font-size:14pt;
            font-family: "Trebuchet MS", "Arial", "Helvetica", "Verdana", "sans-serif";
             text-decoration:none;
             width:50%;
             padding: 0.7em;
              border-radius:3px; 
             -moz-border-radius:3px; /* Firefox */ 
             -webkit-border-radius:3px; /* Safari y Chrome */     
             display:block;
             margin-left:25%;
        }
         #btnCargar:hover
            {
            background: #0486C0;
            border-color:#0486C0;
            color: #fff;
	        cursor: pointer;    
            } 
        
        img
        {
          	margin-top:1em;
        	margin-bottom:2em;
        	display:inline-block;
        	text-align :center ;
       	}
       
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="pnlContenedor" >
    <h4>¡Vaya! tenemos un problema</h4>
             <img src="img/error.jpg" />
<h3>El proceso de la pagina web puede haber finalizado. Para continuar, vuelve a cargar el sistema.</h3>
         <asp:Button ID="btnCargar" runat="server" Text="Dar click para volver a cargar el sistema" />
    </div>

    </form>
</body>
</html>
