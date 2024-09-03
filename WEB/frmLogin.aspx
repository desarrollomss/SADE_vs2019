<%@ Page Language="VB" EnableEventValidation="false" AutoEventWireup="false" CodeFile="frmLogin.aspx.vb" Inherits="frmLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    <link href="//netdna.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css"/>
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="//code.jquery.com/jquery-1.11.1.min.js" type="text/javascript"></script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <style type="text/css">

    body, html {
        height: 100%;
        background-repeat: no-repeat;
        /*background-image: linear-gradient(rgb(89, 89, 89), rgb(102, 102, 102));*/
    }
        .panel-heading
        {
            padding: 10px 20px;
            text-align: center;
        }
        .panel-footer
        {
            padding: 1px 15px;
            color: #A0A0A0;
            text-align: center;
            font-size: small ;
        
        }
        .profile-img
        {
            width: 260px;
            height: 260px;
            margin: 0 auto 10px;
            display: block;
            -moz-border-radius: 50%;
            -webkit-border-radius: 50%;
            border-radius: 50%;
        }
    </style>

    <title></title>

</head>



<body>
    <form id="form1" runat="server">
    <div class="container" style="margin-top: 120px">
        <div class="row">
            <div class="col-sm-6 col-md-4 col-md-offset-4">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <strong>S A D E </strong>
                    </div>
                    <div class="panel-body">
                        <form role="form" action="#" method="POST">
                        <fieldset>
                            <div class="row">
                                <div class="center-block">
                                    <img class="profile-img" src="img/img_sugerencias.png" alt="" />
                                    
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12 col-md-10  col-md-offset-1 ">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                            <asp:TextBox ID="txtUser" runat="server" class="form-control" placeholder="Usuario"
                                                type="text" autofocus></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                            <asp:TextBox ID="txtPassword" runat="server" class="form-control" placeholder="Password"
                                                type="password" value=""></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="glyphicon glyphicon-earphone"></i></span>
                                            <asp:DropDownList ID="ddlAnexo" runat="server" class="form-control" placeholder="Anexo">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" class="btn btn-lg btn-primary btn-block" />
                                    </div>

                                    <div class="form-group">
                                        <%--<asp:LinkButton ID="likCambiarPwd" runat="server" Font-Bold="False" Font-Size="10pt"
                                            ForeColor="#98AF16" CausesValidation="False" Font-Overline="False" Font-Names="Arial" Font-Underline="True">Cambiar  Contraseña</asp:LinkButton>--%>
                                    </div>
                                </div>
                                <h4><asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="#CC0000"></asp:Label></h4>
                            </div>
                        </fieldset>
                        </form>
                    </div>
                    <div class="panel-footer ">
                        Municipalidad de Santiago de Surco
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
