<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="frmRegistraPersonal.aspx.vb" Inherits="frmRegistraPersonal" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
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
            left: 20%;
            width: 60%;
            padding: 0px;
            border: 0px solid #a6c25c;
            background-color: white;
            z-index: 1002;
            overflow: auto;
        }
        #pnlContenedor
        {
            width: 100%;
            padding:0.25em;
        }
       .panel
        {
        	width:80%;
        	padding-bottom:0.50em;
        	margin-left :10%;
        }
        .panel table
        {
        	width:100%;
        	background-color:#CACACA; 
        	color:#807F7F;
        	font-size:10pt; 
        	padding: 0.25em 1em 0.25em 1em;
        }

        table td
        {
        	padding: 0.25em 1em 0.25em 1em;
        }
        h4
        {
        	margin-top:1em;
        	margin-bottom:0.50em;
        	font-size : 10pt;
        	color:#696969;
        	font-weight :300;
        	margin-left :10%;
        }
        div#div_file{
	        width:200px;
            height:40px;
	        position:relative;
	        background-image :url(img/btn-foto.png);
	        display: inline-block;
	        vertical-align: top;	
 	        }
        .NoExaminar{
	         position:absolute; 
	         left:0px;
	         right:0px;
	         top:0px;
	         bottom:0px;
	         width:100%;
	         height:100%;
	         opacity:0;
	        }        
    </style>

    <script type="text/javascript">
        function subir_archivos(e) {
	                var archivos = e.target.files;
	                var archivo = document.getElementById("fulFoto").files[0];
	                var url = "RecibeUploapPersonal.aspx";
	                var solicitud = new XMLHttpRequest();
	                var subida = solicitud.upload;

	                solicitud.open("POST", url, true);
	                solicitud.setRequestHeader('Access-Control-Allow-Headers', '*');
	                solicitud.setRequestHeader('Access-Control-Allow-Origin', '*');
	                var datos = new FormData();
	                datos.append("archivo", archivo);
	                datos.append("codigo", "PER_" + document.getElementById('<%= txtCodigo.ClientID %>').value);
	                //datos.append("codigo", "PER_001");
	                solicitud.send(datos);
	                console.log(datos);
	            }

        function desBloquearDIV(){
            $("#pnlDatosFamiliares").unblock();
            $("#div_file").unblock();
        }

        function validaGrabar() {

            if (document.getElementById('<%= txtNombres.ClientID %>').value == '') {
                alert('DEBE INGRESAR EL NOMBRE DE LA PERSONA');
                return false;
            }

            if (document.getElementById('<%= ddlDistrito.ClientID %>').value == 0) {
                alert('DEBE SELECCIONAR EL DISTRITO');
                return false;
            }
            if (document.getElementById('<%= ddlEstadoCivil.ClientID %>').value == 0) {
                alert('DEBE SELECCIONAR EL ESTADO CIVIL');
                return false;
            }
            if (document.getElementById('<%= ddlGradoInstruccion.ClientID %>').value == 0) {
                alert('DEBE SELECCIONAR EL GRADO DE INSTRUCCION');
                return false;
            }
            if (document.getElementById('<%= ddlAfp.ClientID %>').value == 0) {
                alert('DEBE SELECCIONAR LA AFP');
                return false;
            }

            if (document.getElementById('<%= ddlEstado.ClientID %>').value == 0) {
                alert('DEBE SELECCIONAR EL ESTADO DE LA PERSONA');
                return false;
            }
            if (document.getElementById('<%= ddlSubgerencia.ClientID %>').value == 0) {
                alert('DEBE SELECCIONAR LA SUBGERENCIA');
                return false;
            }
            if (document.getElementById('<%= ddlModalidadContrato.ClientID %>').value == 0) {
                alert('DEBE SELECCIONAR LA MODALIDA DE CONTRATO');
                return false;
            }
            if (document.getElementById('<%= ddlSector.ClientID %>').value == 0) {
                alert('DEBE SELECCIONAR EL SECTOR');
                return false;
            }
            if (document.getElementById('<%= ddlCargo.ClientID %>').value == 0) {
                alert('DEBE SELECCIONAR EL CARGO');
                return false;
            }
            if (document.getElementById('<%= ddlSecuenciaServicio.ClientID %>').value == 0) {
                alert('DEBE SELECCIONAR LA SECUENCIA DEL SERVICIO');
                return false;
            }            
            
            return true;
        }
        function sololetras(e) {

            var key;

            if (window.event) // IE
            {
                key = e.keyCode;
            }
            else if (e.which) // Netscape/Firefox/Opera
            {
                key = e.which;
            }

            if (key < 48 || key > 57) {
                return true;
            }

            return false;
        }

        function validarEmail(valor) {
            if (valor.indexOf('@', 0) == -1 ||
       valor.indexOf('@', 0) == 0 ||
       valor.indexOf('.', 0) == -1) {
                return (false)
            } else {
                return (true)
            };
        }

        function solonumeros(e) {

            var key;

            if (window.event) // IE
            {
                key = e.keyCode;
            }
            else if (e.which) // Netscape/Firefox/Opera
            {
                key = e.which;
            }

            if (key < 48 || key > 57) {
                return false;
            }
            return true;
        }
        function solomontos(e) {

            var key;
            if (window.event) // IE
            {
                key = e.keyCode;
            }
            else if (e.which) // Netscape/Firefox/Opera
            {
                key = e.which;
            }

            if (key < 46 || key > 57) {
                return false;
            }
            else if (key == 47)
            { return false; }
            return true;
        } 
   </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization = 'True'  EnableScriptLocalization = 'True'    >
                </asp:ScriptManager>
<div id="pnlContenedor">
  <h4>DATOS GENERALES</h4>
  <div id="pnlDatosGenerales" class="panel">
        <table id="tbDatosGenerales">
        <colgroup>
            <col style="width : 5%;"  />
            <col style="width : 10%;"   />
            <col style="width : 10%;"   />
            <col style="width : 15%;"   />
            <col style="width : 10%;"   />
            <col style="width : 15%;"   />
            <col style="width : 5%;"   />
            <col style="width : 10%;"   />
            <col style="width : 5%; text-align:right;"    />
            <col style="width : 15%;"   />
        </colgroup> 
        <tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr> 
        <tr><td></td><td></td><td></td><td></td><td></td><td>
            &nbsp;</td><td colspan="4" style="text-align :right;" >
            <asp:Button ID="btnGrabar" runat="server" Text="Guardar cambios" 
                CssClass="boton_dialogo"  
                OnClientClick ="{cambiarvalor();desBloquearDIV();}" />
            &nbsp;<asp:Button ID="btnCancelar" runat="server" Text="Volver atrás"  
                    CssClass="boton_regresar"  OnClientClick ="{cambiarvalor();}"/>
            </td>
            </tr>
        <tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr> 
        <tr><td>
            <asp:Label ID="Label1" runat="server" Text="Código"></asp:Label>
            </td><td>
                <asp:TextBox ID="txtCodigo" Width="95%" CssClass ="CajaTexto"  runat="server" 
                    Enabled="False"></asp:TextBox>
            </td><td>
                <asp:Label ID="Apellido_paterno" runat="server" Text="Apellido paterno"></asp:Label>
            </td><td>
                <asp:TextBox ID="txtAPellidoPaterno" Width="95%"  CssClass ="CajaTexto"  runat="server"></asp:TextBox>
            </td><td>
                <asp:Label ID="Apellido_materno" runat="server" Text="Apellido materno"></asp:Label>
            </td><td>
                <asp:TextBox ID="txtApellidoMaterno" Width="95%"  CssClass ="CajaTexto"  runat="server"></asp:TextBox>
            </td><td>
                <asp:Label ID="Nombres" runat="server" Text="Nombres"></asp:Label>
            </td><td colspan="2">
                <asp:TextBox ID="txtNombres" Width="95%"  CssClass ="CajaTextoObligatorio" 
                    runat="server"></asp:TextBox>
            </td><td></td></tr>
            <tr>
                <td colspan="2"  style="text-align: center;" valign="top">
<%--                    <asp:Image ID="imgFoto" runat="server" 
                        ImageUrl="~/img/No_imagen_disponible.gif"  BorderStyle="Inset" 
                        BorderWidth="2px" Height="128px" Width="128px"/>--%>
                        <div id="holder" style="background-image:url(img/No_imagen_disponible.gif); border-style :inset; border-width:2px; height:128px; width:128px; vertical-align: top; position:relative; display:inline-block; background-size: cover; "></div>
                </td>
                <td colspan= "8" style ="vertical-align:top!important; padding-left:0px!important; " >
                    <table cellspacing ="0" style = "width :100%; top : 0; left:0;">
                        <tbody>
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="Label5" runat="server" Text="Documento Identidad"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDNI" Width="95%" CssClass="CajaTexto" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="RUC"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRuc" Width="100px" CssClass="CajaTexto" MaxLength ="12" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text="Fecha Nacimiento"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="CajaTexto"  
                                        Width="70px"></asp:TextBox>
                                    <asp:Image ID="imgFechaBusca" runat="server" ImageAlign="Middle" 
                                        ImageUrl="~/img/calendario2.png" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtFechaNacimiento"
                                        ErrorMessage="Fecha inválida" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"
                                        Visible="False"></asp:RegularExpressionValidator>   
                                    <cc1:maskededitextender ID="MaskedEditExtender6" runat="server" Mask="99/99/9999"
                                        MaskType="Date" TargetControlID="txtFechaNacimiento" >
                                    </cc1:maskededitextender>
                                    <cc1:calendarextender ID="CalendarExtender5" runat="server" 
                                        CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="imgFechaBusca"
                                        TargetControlID="txtFechaNacimiento">
                                    </cc1:calendarextender>    



                                </td>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Text="Lugar Nac."></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLugarNacimiento" Width="95%" CssClass="CajaTexto" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label9" runat="server" Text="Dirección"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtDireccion" Width="95%" CssClass="CajaTexto" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label11" runat="server" Text="Urbanización"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtUrbanizacion" Width="95%" CssClass="CajaTexto" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label12" runat="server" Text="Distrito"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:DropDownList ID="ddlDistrito" Width="95%" CssClass="CajaComboObligatorio" 
                                    runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label10" runat="server" Text="Correo Electrónico"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtCorreoElectronico" CssClass="CajaTexto" runat="server" Width="95%"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="Label13" runat="server" Text="EstadoCivil"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlEstadoCivil" Width="95%" 
                                    CssClass="CajaComboObligatorio" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label14" runat="server" Text="Teléfono casa"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTelefonoCasa" Width="95%" CssClass="CajaTexto" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label15" runat="server" Text="Teléfono móvil"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTelefonoMovil" Width="95%" CssClass="CajaTexto" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label16" runat="server" Text="Teléfono emergencia"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTelefonoEmergencia" Width="95%" CssClass="CajaTexto" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                    </tbody> 
                    </table>
                
                </td>
            </tr>

            <tr>
                <td colspan="2">
                    <div id="div_file">
                    <%--<asp:FileUpload ID="fulFoto" CssClass="NoExaminar"  runat="server" />--%>
                    <input type="file" name="fulFoto" id="fulFoto" class="NoExaminar" >
                        
                    </div> 
                    <div id="status">
                    </div>
                    <script type="text/javascript">
                        var upload = document.getElementById('fulFoto'),
                            holder = document.getElementById('holder'),
                            state = document.getElementById('status');

                        if (typeof window.FileReader === 'undefined') {
                            state.className = 'fail';
                        } else {
                            state.className = 'success';
                            state.innerHTML = '';
                        }
                        upload.onchange = function (e) {
                            e.preventDefault();
                            var file = upload.files[0],
                            reader = new FileReader();
                            reader.onload = function (event) {
                                var img = new Image();
                                img.src = event.target.result;
                                var view = new Int8Array(img);
                                img.width = 128;
                                img.height = 128;
                                holder.innerHTML = '';
                                holder.appendChild(img);
                                console.log(img);
                                subir_archivos(event);
                            };
                            reader.readAsDataURL(file);
                            
                            return false;
                        };
                    </script>  
                </td>
                <td colspan="8"></td>
                
            </tr>
        <tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr>
        </table>
    </div>
  <h4>DATOS PERSONALES</h4>
  <div id="pnlDatosPersonales" class="panel">
        <table id="Table1">
            <colgroup>
                <col style="width: 10%;" />
                <col style="width: 10%;" />
                <col style="width: 10%;" />
                <col style="width: 15%;" />
                <col style="width: 10%;" />
                <col style="width: 15%;" />
                <col style="width: 5%;" />
                <col style="width: 10%;" />
                <col style="width: 5%; text-align: right;" />
                <col style="width: 10%;" />
            </colgroup>
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
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Cta. banco"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCuentaBancaria" Width="95%" CssClass="CajaTexto" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Grado de instrucción"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlGradoInstruccion" Width="95%" 
                        CssClass="CajaComboObligatorio" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Profesión"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtProfesion" Width="95%" CssClass="CajaTexto" runat="server"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:CheckBox ID="chkLicenciado" runat="server" Text="Licenciado" />
                    &nbsp;
                </td>
                <td>
                    <asp:Label ID="Label19" runat="server" Text="Fuerza Armada"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFuerzaArmada" Width="95%" CssClass="CajaTexto" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label21" runat="server" Text="Libreta militar"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtLibretaMilitar" Width="100px" CssClass="CajaTexto" MaxLength="12"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label28" runat="server" Text="AFP"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlAfp" Width="95%" CssClass="CajaComboObligatorio" 
                        runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label27" runat="server" Text="Código de AFP"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCodAfp" CssClass="CajaTexto" runat="server" Width="95%"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label24" runat="server" Text="Cod. Essalud"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCodEssalud" Width="95%" CssClass="CajaTexto" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label23" runat="server" Text="Sunat 4ta Cat."></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSunatCuarta" Width="95%" CssClass="CajaTexto" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label25" runat="server" Text="Grupo sanguíneo"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtGrupoSanguineo" Width="95%" CssClass="CajaTexto" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label30" runat="server" Text="Talla"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTalla" Width="95%" CssClass="CajaTexto" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label26" runat="server" Text="Peso"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPeso" Width="95%" CssClass="CajaTexto" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label20" runat="server" Text="Cursos realizados"></asp:Label>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="10">
                    <asp:TextBox ID="txtCursosRealizados" Width="95%" CssClass="CajaTexto" 
                        runat="server" Height="100px"
                        TextMode="MultiLine"></asp:TextBox>
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
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </div>
  <h4>MUNICIPALIDAD</h4>
  <div id="pnlMunicipalidad" class="panel">

        <table id="Table2">
            <colgroup>
                <col style="width: 15%;" />
                <col style="width: 10%;" />
                <col style="width: 10%;" />
                <col style="width: 10%;" />
                <col style="width: 20%;" />
                <col style="width: 15%;" />
                <col style="width: 15%;" />
                <col style="width: 5%;" />
                <col style="width: 0%; text-align: right;" />
                <col style="width: 0%;" />
            </colgroup>
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
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label22" runat="server" Text="Fec.Ingreso Municipalidad"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtFecIngresoMunicipalidad" runat="server" CssClass="CajaTexto" Width="70px"></asp:TextBox>
                    <asp:Image ID="Image1" runat="server" ImageAlign="Middle" ImageUrl="~/img/calendario2.png" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtFecIngresoMunicipalidad"
                        ErrorMessage="Fecha inválida" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"
                        Visible="False"></asp:RegularExpressionValidator>
                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999"
                        MaskType="Date" TargetControlID="txtFecIngresoMunicipalidad">
                    </cc1:MaskedEditExtender>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="calendario"
                        Format="dd/MM/yyyy" PopupButtonID="Image1" TargetControlID="txtFecIngresoMunicipalidad">
                    </cc1:CalendarExtender>
                </td>
                <td>
                    <asp:Label ID="Label43" runat="server" Text="Estado persona"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlEstado" Width="95%" CssClass="CajaComboObligatorio" 
                        runat="server">
                    </asp:DropDownList>
                </td>
                <td style="text-align :right;">
                    <asp:Label ID="Label44" runat="server" Text="Fec.ultimo estado"></asp:Label>
                </td>
                <td>
                                  <asp:TextBox ID="txtFecUltimoEstado" runat="server" CssClass="CajaTexto" 
                                      Width="70px"></asp:TextBox>
                    <asp:Image ID="Image6" runat="server" ImageAlign="Middle" ImageUrl="~/img/calendario2.png" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtFecUltimoEstado"
                        ErrorMessage="Fecha inválida" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"
                        Visible="False"></asp:RegularExpressionValidator>
                    <cc1:MaskedEditExtender ID="MaskedEditExtender7" runat="server" Mask="99/99/9999"
                        MaskType="Date" TargetControlID="txtFecUltimoEstado">
                    </cc1:MaskedEditExtender>
                    <cc1:CalendarExtender ID="CalendarExtender7" runat="server" CssClass="calendario"
                        Format="dd/MM/yyyy" PopupButtonID="Image6" TargetControlID="txtFecUltimoEstado">
                    </cc1:CalendarExtender>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label33" runat="server" Text="Subgerencia"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:DropDownList ID="ddlSubgerencia" Width="95%" 
                        CssClass="CajaComboObligatorio" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label31" runat="server" Text="Fec.ing.Area"></asp:Label>
                </td>
                <td>
                                <asp:TextBox ID="txtFecIngArea" runat="server" CssClass="CajaTexto" Width="70px"></asp:TextBox>
                    <asp:Image ID="Image2" runat="server" ImageAlign="Middle" ImageUrl="~/img/calendario2.png" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtFecIngArea"
                        ErrorMessage="Fecha inválida" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"
                        Visible="False"></asp:RegularExpressionValidator>
                    <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" Mask="99/99/9999"
                        MaskType="Date" TargetControlID="txtFecIngArea">
                    </cc1:MaskedEditExtender>
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="calendario"
                        Format="dd/MM/yyyy" PopupButtonID="Image2" TargetControlID="txtFecIngArea">
                    </cc1:CalendarExtender>
               </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label39" runat="server" Text="Modalidad contrato"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:DropDownList ID="ddlModalidadContrato" Width="95%" 
                        CssClass="CajaComboObligatorio" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label35" runat="server" Text="Fec.Ing.Modalidad"></asp:Label>
                </td>
                <td>
                                 <asp:TextBox ID="txtFecIngModalidad" runat="server" CssClass="CajaTexto" Width="70px"></asp:TextBox>
                    <asp:Image ID="Image3" runat="server" ImageAlign="Middle" ImageUrl="~/img/calendario2.png" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtFecIngModalidad"
                        ErrorMessage="Fecha inválida" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"
                        Visible="False"></asp:RegularExpressionValidator>
                    <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" Mask="99/99/9999"
                        MaskType="Date" TargetControlID="txtFecIngModalidad">
                    </cc1:MaskedEditExtender>
                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" CssClass="calendario"
                        Format="dd/MM/yyyy" PopupButtonID="Image3" TargetControlID="txtFecIngModalidad">
                    </cc1:CalendarExtender>
                    </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label42" runat="server" Text="Sector"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:DropDownList ID="ddlSector" Width="95%" CssClass="CajaComboObligatorio" 
                        runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label36" runat="server" Text="Fec.ing.Sector"></asp:Label>
                </td>
                <td>
                                     <asp:TextBox ID="txtFecIngSector" runat="server" CssClass="CajaTexto" Width="70px"></asp:TextBox>
                    <asp:Image ID="Image4" runat="server" ImageAlign="Middle" ImageUrl="~/img/calendario2.png" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtFecIngSector"
                        ErrorMessage="Fecha inválida" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"
                        Visible="False"></asp:RegularExpressionValidator>
                    <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" Mask="99/99/9999"
                        MaskType="Date" TargetControlID="txtFecIngSector">
                    </cc1:MaskedEditExtender>
                    <cc1:CalendarExtender ID="CalendarExtender4" runat="server" CssClass="calendario"
                        Format="dd/MM/yyyy" PopupButtonID="Image4" TargetControlID="txtFecIngSector">
                    </cc1:CalendarExtender></td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label34" runat="server" Text="Cargo"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:DropDownList ID="ddlCargo" Width="95%" CssClass="CajaComboObligatorio" 
                        runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label32" runat="server" Text="Fec.Ing.Cargo"></asp:Label>
                </td>
                <td>
                                     <asp:TextBox ID="txtFecIngCargo" runat="server" CssClass="CajaTexto" Width="70px"></asp:TextBox>
                    <asp:Image ID="Image5" runat="server" ImageAlign="Middle" ImageUrl="~/img/calendario2.png" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtFecIngCargo"
                        ErrorMessage="Fecha inválida" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"
                        Visible="False"></asp:RegularExpressionValidator>
                    <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" Mask="99/99/9999"
                        MaskType="Date" TargetControlID="txtFecIngCargo">
                    </cc1:MaskedEditExtender>
                    <cc1:CalendarExtender ID="CalendarExtender6" runat="server" CssClass="calendario"
                        Format="dd/MM/yyyy" PopupButtonID="Image5" TargetControlID="txtFecIngCargo">
                    </cc1:CalendarExtender></td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label29" runat="server" Text="Secuencia de servicio"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:DropDownList ID="ddlSecuenciaServicio" Width="95%" CssClass="CajaComboObligatorio" 
                        runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label37" runat="server" Text="Rango"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlRango" Width="95%" CssClass="CajaCombo" 
                        runat="server">
                    </asp:DropDownList>
                </td>
                <td style="text-align :right;">
                    <asp:Label ID="Label41" runat="server" Text="Sueldo"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSueldo" Width="95%" CssClass="CajaTexto" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
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
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </div>
  <h4>DATOS DEL VEHICULO</h4>
  <div id="pnlDatosVehiculo" class="panel">
        <table id="Table3">
            <colgroup>
                <col style="width: 15%;" />
                <col style="width: 10%;" />
                <col style="width: 10%;" />
                <col style="width: 10%;" />
                <col style="width: 20%;" />
                <col style="width: 15%;" />
                <col style="width: 15%;" />
                <col style="width: 5%;" />
                <col style="width: 0%; text-align: right;" />
                <col style="width: 0%;" />
            </colgroup>
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
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label51" runat="server" Text="Brevete vehicular"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtBreveteVehiculo" Width="95%" CssClass="CajaTexto" 
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label47" runat="server" Text="Categoria"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:DropDownList ID="ddlCategoriaVehiculo" Width="95%" CssClass="CajaCombo" 
                        runat="server">
                    </asp:DropDownList>
                </td>
                <td style="text-align :right;">
                    <asp:Label ID="Label48" runat="server" Text="Fecha de revalidación"></asp:Label>
                </td>
                <td>
                                <asp:TextBox ID="txtFecRevalidaVehiculo" runat="server" CssClass="CajaTexto" Width="70px"></asp:TextBox>
                    <asp:Image ID="Image9" runat="server" ImageAlign="Middle" ImageUrl="~/img/calendario2.png" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="txtFecRevalidaVehiculo"
                        ErrorMessage="Fecha inválida" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"
                        Visible="False"></asp:RegularExpressionValidator>
                    <cc1:MaskedEditExtender ID="MaskedEditExtender10" runat="server" Mask="99/99/9999"
                        MaskType="Date" TargetControlID="txtFecRevalidaVehiculo">
                    </cc1:MaskedEditExtender>
                    <cc1:CalendarExtender ID="CalendarExtender10" runat="server" CssClass="calendario"
                        Format="dd/MM/yyyy" PopupButtonID="Image9" TargetControlID="txtFecRevalidaVehiculo">
                    </cc1:CalendarExtender>
               </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>

            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label53" runat="server" Text="Restricciones"></asp:Label>
                </td>
                <td colspan="7">
                    <asp:TextBox ID="txtRestriccionVehiculo" Width="95%" CssClass="CajaTexto" 
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                            <td>
                                &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                                 &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                            <td>
                    <asp:Label ID="Label52" runat="server" Text="Brevete Moto"></asp:Label>
                            </td>
                <td>
                    <asp:TextBox ID="txtBreveteMoto" Width="95%" CssClass="CajaTexto" 
                        runat="server"></asp:TextBox>
                            </td>
                <td>
                    <asp:Label ID="Label49" runat="server" Text="Categoria"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:DropDownList ID="ddlCategoriaMoto" Width="95%" CssClass="CajaCombo" 
                        runat="server">
                    </asp:DropDownList>
                </td>
                <td style="text-align :right;">
                    <asp:Label ID="Label50" runat="server" Text="Fecha de revalidación"></asp:Label>
                </td>
                <td>
                                 <asp:TextBox ID="txtFecRevalidaMoto" runat="server" CssClass="CajaTexto" Width="70px"></asp:TextBox>
                    <asp:Image ID="Image10" runat="server" ImageAlign="Middle" ImageUrl="~/img/calendario2.png" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ControlToValidate="txtFecRevalidaMoto"
                        ErrorMessage="Fecha inválida" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"
                        Visible="False"></asp:RegularExpressionValidator>
                    <cc1:MaskedEditExtender ID="MaskedEditExtender11" runat="server" Mask="99/99/9999"
                        MaskType="Date" TargetControlID="txtFecRevalidaMoto">
                    </cc1:MaskedEditExtender>
                    <cc1:CalendarExtender ID="CalendarExtender11" runat="server" CssClass="calendario"
                        Format="dd/MM/yyyy" PopupButtonID="Image10" TargetControlID="txtFecRevalidaMoto">
                    </cc1:CalendarExtender>
                    </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label54" runat="server" Text="Restricciones"></asp:Label>
                </td>
                <td colspan="7">
                    <asp:TextBox ID="txtRestriccionMoto" Width="95%" CssClass="CajaTexto" 
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
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
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </div>
  <h4>DATOS FAMILIARES</h4>
  <div id="pnlDatosFamiliares" class="panel">
        <table id="tbDatosFamiliares">
        <colgroup>
            <col style="width : 5%;"  />
            <col style="width : 10%;"   />
            <col style="width : 10%;"   />
            <col style="width : 15%;"   />
            <col style="width : 10%;"   />
            <col style="width : 15%;"   />
            <col style="width : 5%;"   />
            <col style="width : 10%;"   />
            <col style="width : 5%; text-align:right;"    />
            <col style="width : 15%;"   />
        </colgroup> 
        <tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr> 
        <tr><td>
            <asp:Label ID="Label17" runat="server" Text="Parentesco"></asp:Label>
            </td><td colspan="2">
                <asp:DropDownList ID="ddlParentesco"  Width="95%" CssClass="CajaCombo" runat="server">
                </asp:DropDownList>
            </td><td>
                <asp:Label ID="Label18" runat="server" Text="Nombre y apellidos"></asp:Label>
            </td><td colspan="2">
                <asp:TextBox ID="txtNombreFamiliar" runat="server"  Width="95%" CssClass="CajaTexto"></asp:TextBox>
            </td><td colspan="2">
            <asp:Button ID="btnAgregaFamiliar" runat="server" Text="Agrega familiar"  OnClientClick ="{cambiarvalor();desBloquearDIV();}" 
                CssClass="boton_dialogo"  />
            </td><td>&nbsp;</td><td>&nbsp;</td></tr> 
        <tr><td colspan="10">
            <asp:GridView ID="gvFamiliar" runat="server" AlternatingRowStyle-CssClass="GridAlternateRow"
                AutoGenerateColumns="False" CssClass="Grid" HeaderStyle-CssClass="GridHeader"
                PagerStyle-CssClass="GridFooter" RowStyle-CssClass="GridRow" Width="100%">
                <Columns>
                    <asp:TemplateField InsertVisible="False" ShowHeader="False">
                        <HeaderStyle />
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEliminaFamiliar" CssClass="boton_eliminar" OnClientClick="{cambiarvalor();desBloquearDIV();javascript:return confirm('Estas seguro(a) de eliminar?','SADE');}"
                                runat="server" CommandName="Select">Eliminar</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="10%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="INTPFACODIGO" HeaderText="ID">
                        <ItemStyle Width="5%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PARENTESCO" HeaderText="Parentesco">
                        <ItemStyle Width="20%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="VCHPFANOMBRE" HeaderText="Nombres y Apellidos">
                        <ItemStyle Width="65%" />
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
            </td></tr> 
        <tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr>
        </table>
    </div>
<div id="mensaje" class="white_content">
    <table width="100%" class="Tabla">
        <colgroup valign="top">
            <col width="4%" />
            <col width="18%" />
            <col width="20%" />
            <col width="20%" />
            <col width="15%"/>
            <col width="21%" />
            <col width="2%" />
        </colgroup>
<tr>
<td style=" background-color:#f0f0f0"></td>
<td style=" background-color:#f0f0f0; vertical-align:middle; text-align:center;" colspan="5">
<asp:Label ID="Label40" runat="server" Font-Size="Small"
        Font-Bold="True">Mensaje del sistema</asp:Label>
</td>
<td style=" background-color:#f0f0f0; vertical-align:middle;"><a href = "javascript:void(0)" onclick = "document.getElementById('mensaje').style.display='none';document.getElementById('fade').style.display='none'"><img src="img/Close.gif" style="border :0px" align="right" /></a>
</td>
</tr>        
<tr><td colspan="7" style="height:20px;"></td></tr>
        <tr class="titulo" >
            <td colspan="7" style="text-align :center">
                <asp:Label ID="lblMensajeSistema" runat="server" Text=""></asp:Label></td>
        </tr>
<tr><td colspan="7" style="height:20px;"></td></tr>
<tr><td colspan="7" style="height:20px; vertical-align:middle; text-align :center;"><asp:Button ID="btnRedirecciona" runat="server" CssClass="boton_busca" 
        Text="    Aceptar    " OnClientClick ="cambiarvalor();" /></td></tr>
<tr><td colspan="7" style="height:10px;"></td></tr>
</table>
</div>
<div id="fade" class="black_overlay">
</div>
</div>
<script type="text/javascript">
    $("#pnlDatosFamiliares").block({ message: null });
    $("#div_file").block({ message: null });

    if (document.getElementById('<%= txtCodigo.ClientID %>').value != 0) {
        document.getElementById("holder").style.backgroundImage = "url(fotos/PER_" + document.getElementById('<%= txtCodigo.ClientID %>').value + ".jpg)";
    }

</script>
</asp:Content>

