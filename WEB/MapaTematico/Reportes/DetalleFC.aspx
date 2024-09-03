<%@ Page Language="VB" AutoEventWireup="false" CodeFile="DetalleFC.aspx.vb" Inherits="REPORTES_DetalleFC" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
 	<style type="text/css">
        html {
            height: 100%;
            background-color: #fff;
        }

        body {
            height: 100%;
            margin: 0px;
            padding: 0px;
        }

        #title {
            width: 100%;
            height: 120px;
            background-color: #131F2A;
            margin: 0px 0px 0px 0px;
            padding: 1px 0px 0px 1px;
        }

        .table
        {
            border:1;
            font-family: Arial, Verdana, Sans-Serif;
            font-size: 10px; 
        }

 	    .tableCT 
 	    {
 	        border:1;
            font-family: Arial, Verdana, Sans-Serif;
            font-size: 12px;
            text-align:center;
            padding-left:2px;
            padding-right:2px; 
            padding-top:2px; 
            padding-bottom:2px;
 	    }

 	    .tableCTB 
 	    {
 	        border:1;
            font-family: Arial, Verdana, Sans-Serif;
            font-weight: bold;
            font-size: 12px;
            text-align:left;
            padding-left:2px;
            padding-right:2px; 
            padding-top:2px; 
            padding-bottom:2px;
 	    }

 	    .tableC 
 	    {
 	        border:1;
            font-family: Arial, Verdana, Sans-Serif;
            font-size: 12px;
            text-align:left;
            padding-left:2px;
            padding-right:2px; 
            padding-top:2px; 
            padding-bottom:2px;
 	    }

 	    .tableBGT
 	    {
 	        border:1;
            font-family: Arial, Verdana, Sans-Serif;
            font-size: 10px; 
            text-align:center;
            background-color: Black; 
            color: White
 	    }


 	    .tableBG 
 	    {
 	        border:1;
            font-family: Arial, Verdana, Sans-Serif;
            font-size: 10px; 
            text-align:left;
            background-color: Black; 
            color: White
 	    }

        
     </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <center>
        <table id="Table5" cellspacing="0" border="0" class="table" width="850px">
        <colgroup>
        <col width="100px" />
        <col width="650px" />
        <col width="100px" />
        </colgroup>
        <tr align="center">
        <td></td>
        <td>
       <table id="tbCAB" cellspacing="0" rules="all" border="1" class="table" width="450px">
            <colgroup>
                <col width="09%" />
                <col width="09%" />
                <col width="09%" />
                <col width="09%" />
                <col width="09%" />
                <col width="10%" />
                <col width="09%" />
                <col width="09%" />
                <col width="09%" />
                <col width="09%" />
                <col width="09%" />
            </colgroup>
            <tr class="tableBGT">
                <td colspan="6">Código Unico Catastral - CUC</td>
                <td colspan="5">Código Hoja Catastral</td>
            </tr>
            <tr class="tableCT">
                <td colspan="6">-</td>
                <td colspan="5">-</td>
            </tr>

            <tr class="tableCT"><td colspan="11">CODIGO DE REFERENCIA CATASTRAL</td>
            </tr>
            <tr class="tableBGT">
                <td>Dpto</td>
                <td>Prov</td>
                <td>Dist</td>
                <td>Sección</td>
                <td>Manz</td>
                <td>Lote</td>
                <td>Edifica</td>
                <td>Entrada</td>
                <td>Piso</td>
                <td>Unidad</td>
                <td>DC</td>
            </tr>
            <tr class="tableCT">
                <td><asp:Label ID="lblDpto" runat="server"/></td>
                <td><asp:Label ID="lblProv" runat="server"/></td>
                <td><asp:Label ID="lblDist" runat="server"/></td>
                <td><asp:Label ID="lblSecc" runat="server"/></td>
                <td><asp:Label ID="lblManz" runat="server"/></td>
                <td><asp:Label ID="lblLote" runat="server"/></td>
                <td><asp:Label ID="lblEdif" runat="server"/></td>
                <td><asp:Label ID="lblEntr" runat="server"/></td>
                <td><asp:Label ID="lblPiso" runat="server"/></td>
                <td><asp:Label ID="lblUnid" runat="server"/></td>
                <td><asp:Label ID="lblDigC" runat="server"/></td>
            </tr>
        </table>
        </td>
        <td align="center" style="font-family: Arial, Verdana, Sans-Serif; font-size: 40px; font-weight: bold; background-color: Black; color: White;"><asp:Label ID="lblTipoFicha" runat="server" /></td>        
        </tr>
        </table>

       <asp:MultiView ID="mvwFichas" runat="server" ActiveViewIndex="0">
       <asp:View ID="ViewIN_1" runat="server">
           <table id="Table7" cellspacing="0" rules="all" border="1" class="table" width="450px">
            <colgroup>
                <col width="09%" />
                <col width="36%" />
                <col width="28%" />
                <col width="09%" />
                <col width="09%" />
                <col width="09%" />
            </colgroup>
            <tr class="tableBGT">
                <td>Codigo de Contribuyente</td>
                <td>Codigo de Predio</td>
                <td>Unidad Acumulada</td>
            </tr>
            <tr class="tableCT">
                <td><asp:Label ID="lblCodAdm" runat="server" Text="" /></td>
                <td><asp:Label ID="lblCodPre" runat="server" Text="" /></td>
                <td><asp:Label ID="lblUniAcm" runat="server" Text="" /></td>
            </tr>
            </table>
            <br />
           <asp:Repeater ID="rptIN_UBI" runat="server">
                    <HeaderTemplate>
                    <table id="Table5" cellspacing="0" rules="all" border="1" class="table" width="850px">
                        <colgroup>
                            <col width="10%" />
                            <col width="10%" />
                            <col width="20%" />
                            <col width="10%" />
                            <col width="10%" />
                            <col width="10%" />
                            <col width="20%" />
                            <col width="10%" />
                        </colgroup>
                        <tr>
                        <td colspan="8" class="tableCTB">UBICACION DEL PREDIO CATASTRAL</td>
                        </tr>
                        <tr class="tableBGT">
                        <td>Cod.Via</td>
                        <td>Tipo Via</td>
                        <td>Nombre Via</td>
                        <td>Tipo Puerta</td>
                        <td>Verif.Campo</td>
                        <td>Cert.Num.</td>
                        <td>Condicion</td>
                        <td>Nº Certif</td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr >
                        <td><asp:Label ID="Label41" runat="server" Text='<%# Eval("CodVia") %>' /></td>
                        <td><asp:Label ID="Label33" runat="server" Text='<%# Eval("TipoVia") %>' /></td>
                        <td><asp:Label ID="Label34" runat="server" Text='<%# Eval("NomVia") %>' /></td>
                        <td><asp:Label ID="Label35" runat="server" Text='<%# Eval("NomTPuerta") %>' /></td>
                        <td><asp:Label ID="Label36" runat="server" Text='<%# Eval("VerfCampo") %>' /></td>
                        <td><asp:Label ID="Label37" runat="server" Text='<%# Eval("VerfCerNum") %>' /></td>
                        <td><asp:Label ID="Label38" runat="server" Text='<%# Eval("CodConNum") %>' /> <asp:Label ID="Label40" runat="server" Text='<%# Eval("NomConNum") %>' /></td>
                        <td><asp:Label ID="Label39" runat="server" Text='<%# Eval("NroCerNR") %>' /></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                    </table>
                    </FooterTemplate>
           </asp:Repeater>

           <asp:Repeater ID="rptIN_FICHA" runat="server">
           <HeaderTemplate>
           </HeaderTemplate>
           <ItemTemplate>
                <center>
                <table id="Table02" cellspacing="0" rules="all" border="1" class="table" width="850px">
                    <colgroup>
                        <col width="13%" />
                        <col width="20%" />
                        <col width="01%" />
                        <col width="13%" />
                        <col width="20%" />
                        <col width="13%" />
                        <col width="20%" />
                    </colgroup>

                        <tr">
                        <td class="tableBG">Nombre de Edificación</td>
                        <td colspan="3"><asp:Label ID="Label42" runat="server" Text='<%# Eval("VCHINDNOMEDIF") %>' /></td>
                        <td class="tableBG">Tipo de Edificacion</td>
                        <td colspan="2"><asp:Label ID="Label43" runat="server" Text='<%# Eval("CHRTBLOCODIGO") %>' /> <asp:Label ID="Label44" runat="server" Text='<%# Eval("VCHTBLODESCRIPCION") %>' /></td>
                        </tr>

                        <tr">
                        <td class="tableBG">Tipo Interior</td>
                        <td colspan="2"><asp:Label ID="Label45" runat="server" Text='<%# Eval("CHRTINTCODIGO") %>' /> <asp:Label ID="Label47" runat="server" Text='<%# Eval("VCHTINTDESCRIPCION") %>' /></td>
                        <td class="tableBG">Nro. Interior</td>
                        <td><asp:Label ID="Label46" runat="server" Text='<%# Eval("VCHINDNUMINTE") %>' /></td>
                        <td class="tableBG">Condicion Interior</td>
                        <td><asp:Label ID="Label48" runat="server" Text='<%# Eval("CHRINDCONDINTE") %>' /> <asp:Label ID="Label49" runat="server" Text='<%# Eval("VCHCINTDESCRIPCION") %>' /></td>
                        </tr>

                        <tr class="tableBGT">
                        <td>Codigo HU</td>
                        <td colspan="2">Tipo HU</td>
                        <td>Nombre HU</td>
                        <td>Manzana</td>
                        <td>Lote</td>
                        <td>Sublote</td>
                        </tr>

                        <tr>
                        <td><asp:Label ID="Label50" runat="server" Text='<%# Eval("CHRCURCODIGO") %>' /></td>
                        <td colspan="2"><asp:Label ID="Label51" runat="server" Text='<%# Eval("INTTCUCODIGO") %>' /> <asp:Label ID="Label56" runat="server" Text='<%# Eval("TIPOHU") %>' /></td>
                        <td><asp:Label ID="Label52" runat="server" Text='<%# Eval("VCHCURDESCRIPCION") %>' /></td>
                        <td><asp:Label ID="Label53" runat="server" Text='<%# Eval("VCHMAUDESCRIPCION") %>' /></td>
                        <td><asp:Label ID="Label54" runat="server" Text='<%# Eval("VCHLOUDESCRIPCION") %>' /></td>
                        <td><asp:Label ID="Label55" runat="server" Text='<%# Eval("VCHSLODESCRIPCION") %>' /></td>
                        </tr>
                        <tr>
                        <td colspan="7" class="tableCTB"><br />IDENTIFICACION DEL TITULAR CATASTRAL</td>
                        </tr>
                        <tr>
                        <td class="tableBG">Tipo de Titular</td>
                        <td><asp:Label ID="Label1" runat="server" Text='<%# Eval("TIVCHTIPCODIGO") %>' /> <asp:Label ID="Label7" runat="server" Text='<%# Eval("VCHGRPDESCRI") %>' /></td>
                        <td></td>
                        <td class="tableBG">Tipo</td>
                        <td><asp:Label ID="Label2" runat="server" Text='<%# Eval("TIVCHTIDCODIGO") %>' /> <asp:Label ID="Label8" runat="server" Text='<%# Eval("VCHTIDDESCRI") %>' /></td>
                        <td class="tableBG">Nº Documento</td>
                        <td><asp:Label ID="Label3" runat="server" Text='<%# Eval("TIVCHADMNUMDOCUMENTO") %>' /></td>
                        </tr>
                        <tr>
                        <td class="tableBG">Nombres</td>
                        <td><asp:Label ID="Label4" runat="server" Text='<%# Eval("TIVCHADMNOMBRES") %>' /></td>
                        <td></td>
                        <td class="tableBG">Apellido Paterno</td>
                        <td><asp:Label ID="Label5" runat="server" Text='<%# Eval("TIVCHADMAPEPATERNO") %>' /></td>
                        <td class="tableBG">Apellido Materno</td>
                        <td><asp:Label ID="Label6" runat="server" Text='<%# Eval("TIVCHADMAPEMATERNO") %>' /></td>
                        </tr>
                    </table>
                <br />
                <table id="Table1" cellspacing="0" rules="all" border="1" class="table" width="850px">
                    <colgroup>
                        <col width="25%" />
                        <col width="25%" />
                        <col width="50%" />
                    </colgroup>
                    <tr>
                    <td class="tableBG">Tipo Doc.Identidad</td>
                    <td class="tableBG">Nº Documento</td>
                    <td class="tableBG">Apellidos y Nombres</td>
                    </tr>
                    <tr>
                    <td><asp:Label ID="Label14" runat="server" Text='<%# Eval("COVCHTIDCODIGO") %>' /> <asp:Label ID="Label9" runat="server" Text='<%# Eval("VCHCOTIDDESCRI") %>' /></td>
                    <td><asp:Label ID="Label15" runat="server" Text='<%# Eval("COVCHADMNUMDOCUMENTO") %>' /></td>
                    <td><asp:Label ID="Label16" runat="server" Text='<%# Eval("COVCHADMNOMBRES") %>' /></td>
                    </tr>
                </table>
                <br />
                <table id="Table3" cellspacing="0" rules="all" border="1" class="table" width="850px">
                    <colgroup>
                        <col width="10%" />
                        <col width="15%" />
                        <col width="10%" />
                        <col width="15%" />
                        <col width="10%" />
                        <col width="15%" />
                        <col width="10%" />
                        <col width="15%" />
                    </colgroup>
                    <tr>
                    <td class="tableBG">Nº de RUC</td>
                    <td><asp:Label ID="Label25" runat="server" Text='<%# Eval("VCHADMNUMRUC") %>' /></td>
                    <td class="tableBG">Razon Social</td>
                    <td colspan="5"><asp:Label ID="Label28" runat="server" Text='<%# Eval("VCHADMRAZSOCIAL") %>' /></td>
                    </tr>
                    <tr>
                    <td class="tableBG">Persona Juridica</td>
                    <td><asp:Label ID="Label20" runat="server" Text='<%# Eval("CHRPCONTPERJ") %>' /> <asp:Label ID="Label23" runat="server" Text='<%# Eval("VCHTPERJURIDICA") %>' /></td>
                    <td colspan="2"><asp:Label ID="Label21" runat="server" Text='<%# Eval("VCHTPERJCOTROS") %>' /></td>
                    <td class="tableBG">Condicion Esp. Titular</td>
                    <td colspan="3"><asp:Label ID="Label22" runat="server" Text='<%# Eval("CHRCETICODIGO") %>' /> <asp:Label ID="Label24" runat="server" Text='<%# Eval("VCHCETIDESCRIPCION") %>' /></td>
                    </tr>
                    <tr>
                    <td class="tableBG">Resolucion Exoneracion</td>
                    <td><asp:Label ID="Label10" runat="server" Text='<%# Eval("VCHCETINUMRESEXO") %>' /></td>
                    <td class="tableBG">Nº Boleta</td>
                    <td><asp:Label ID="Label17" runat="server" Text='<%# Eval("VCHCETINUMBOLPEN") %>' /></td>
                    <td class="tableBG">Inicio Exoneracion</td>
                    <td><asp:Label ID="Label18" runat="server" Text='<%# Eval("DATCETIFECINIEXO") %>' /></td>
                    <td class="tableBG">Vence Exoneracion</td>
                    <td><asp:Label ID="Label19" runat="server" Text='<%# Eval("DATCETIFECFINEXO") %>' /></td>
                    </tr>
                </table>
                <br />
                <table id="Table4" cellspacing="0" rules="all" border="1" class="table" width="850px">
                    <colgroup>
                        <col width="10%" />
                        <col width="15%" />
                        <col width="10%" />
                        <col width="15%" />
                        <col width="10%" />
                        <col width="15%" />
                        <col width="10%" />
                        <col width="15%" />
                    </colgroup>
                    <tr>
                    <td colspan="8" class="tableCTB">DESCRIPCION DEL PREDIO</td>
                    </tr>
                    <tr>
                    <td class="tableBG">Clasificación</td>
                    <td><asp:Label ID="Label11" runat="server" Text='<%# Eval("VCHCLPREDESCRIPCION") %>' /></td>
                    <td></td>
                    <td><asp:Label ID="Label12" runat="server" Text='<%# Eval("VCHCLPREOTROS") %>' /></td>
                    <td class="tableBG">Predio Catastral</td>
                    <td colspan="2"><asp:Label ID="Label13" runat="server" Text='<%# Eval("CHRTPREDCODIGO") %>' /> <asp:Label ID="Label32" runat="server" Text='<%# Eval("VCHTPREDDESCRIPCION") %>' /></td>
                    <td><asp:Label ID="Label26" runat="server" Text='<%# Eval("VCHINDTPOTROS") %>' /></td>
                    </tr>
                    <tr>
                    <td class="tableBG">Código Uso</td>
                    <td><asp:Label ID="Label27" runat="server" Text='<%# Eval("CHRUSOCODIGO") %>' /></td>
                    <td class="tableBG">Uso Predio</td>
                    <td><asp:Label ID="Label29" runat="server" Text='<%# Eval("VCHINDIVUSODESC") %>' /></td>
                    <td class="tableBG">Estructuración</td>
                    <td></td>
                    <td class="tableBG">Zonificación</td>
                    <td></td>
                    </tr>


                </table>
                <br />
                <table id="Table6" cellspacing="0" rules="all" border="1" class="table" width="850px">
                    <colgroup>
                        <col width="23%" />
                        <col width="10%" />
                        <col width="23%" />
                        <col width="10%" />
                        <col width="24%" />
                        <col width="10%" />
                    </colgroup>
                    <tr>
                    <td class="tableBG">Area de Terreno Titulo m2</td>
                    <td align="right"><asp:Label ID="Label71" runat="server" Text='<%# Eval("DECINDARETIT","{0:N2}") %>' /></td>
                    <td class="tableBG">Area de Terreno Declarada m2</td>
                    <td align="right"><asp:Label ID="Label72" runat="server" Text='<%# Eval("DECINDAREDEC","{0:N2}") %>' /></td>
                    <td class="tableBG">Area de Terreno Verificada m2</td>
                    <td align="right"><asp:Label ID="Label73" runat="server" Text='<%# Eval("DECINDAREVER","{0:N2}") %>' /></td>
                    </tr>
                    <tr class="tableCTB">
                    <td colspan="6"><br />OBSERVACIONES</td>
                    </tr>

                    <tr>
                    <td colspan ="8"><asp:Label ID="Label77" runat="server" Text='<%# Eval("VCHUCAOBS") %>' /></td>
                    </tr>

                </table>

           </ItemTemplate>
            <FooterTemplate>
            </FooterTemplate>
            </asp:Repeater>
           <br /> 
           <asp:Repeater ID="rptIN_CON" runat="server">
           <HeaderTemplate>
                <table id="Table5" cellspacing="0" rules="all" border="1" class="table" width="850px">
                <colgroup>
                <col width="5%" />
                <col width="5%" />
                <col width="5%" />
                <col width="5%" />
                <col width="5%" />
                <col width="5%" />
                <col width="5%" />
                <col width="5%" />
                <col width="5%" />
                <col width="5%" />
                <col width="5%" />
                <col width="5%" />
                <col width="5%" />
                <col width="5%" />
                <col width="10%" />
                <col width="10%" />
                <col width="10%" />
                </colgroup>
                <tr>
                <td colspan="20" class="tableCTB">CONSTRUCCIONES</td>
                </tr>
                <tr class="tableBGT">
                <td>Piso</td>
                <td>Mes</td>
                <td>Año</td>
                <td>Cla</td>
                <td>MEP</td>
                <td>ECS</td>
                <td>ECC</td>
                <td>Mur-Col</td>
                <td>Techo</td>
                <td>Piso</td>
                <td>Puer-Ven</td>
                <td>Reves</td>
                <td>Baño</td>
                <td>Elec. y San.</td>
                <td>Declarada</td>
                <td>Verificada</td>
                <td>UCA</td>
                </tr>
           </HeaderTemplate>
           <ItemTemplate>
                <tr align="center">
                <td><asp:Label ID="Label42" runat="server" Text='<%# Eval("Nro") %>' /></td>
                <td><asp:Label ID="Label30" runat="server" Text='<%# Eval("Mes") %>' /></td>
                <td><asp:Label ID="Label31" runat="server" Text='<%# Eval("Anio") %>' /></td>
                <td><asp:Label ID="Label57" runat="server" Text='<%# Eval("Clasif") %>' /></td>
                <td><asp:Label ID="Label58" runat="server" Text='<%# Eval("codmep") %>' /></td>
                <td><asp:Label ID="Label59" runat="server" Text='<%# Eval("codecs") %>' /></td>
                <td><asp:Label ID="Label60" runat="server" Text='<%# Eval("codecc") %>' /></td>
                <td><asp:Label ID="Label61" runat="server" Text='<%# Eval("muros") %>' /></td>
                <td><asp:Label ID="Label62" runat="server" Text='<%# Eval("techos") %>' /></td>
                <td><asp:Label ID="Label63" runat="server" Text='<%# Eval("pisos") %>' /></td>
                <td><asp:Label ID="Label64" runat="server" Text='<%# Eval("puerta") %>' /></td>
                <td><asp:Label ID="Label65" runat="server" Text='<%# Eval("reves") %>' /></td>
                <td><asp:Label ID="Label66" runat="server" Text='<%# Eval("banio") %>' /></td>
                <td><asp:Label ID="Label67" runat="server" Text='<%# Eval("insta") %>' /></td>
                <td align="right"><asp:Label ID="Label68" runat="server" Text='<%# Eval("decla","{0:N2}") %>' /></td>
                <td align="right"><asp:Label ID="Label69" runat="server" Text='<%# Eval("verif","{0:N2}") %>' /></td>
                <td><asp:Label ID="Label70" runat="server" Text='<%# Eval("coduca") %>' /></td>
                </tr>
           </ItemTemplate>
           <FooterTemplate>
                </table>
           </FooterTemplate>
           </asp:Repeater> 

       </asp:View>
       <asp:View ID="ViewAE_2" runat="server">
           <br />
           <asp:Repeater ID="rptAE_Ficha" runat="server">
                    <HeaderTemplate>
                    <table id="Table5" cellspacing="0" rules="all" border="1" class="table" width="850px">
                        <colgroup>
                            <col width="20%" />
                            <col width="10%" />
                            <col width="10%" />
                            <col width="10%" />
                            <col width="20%" />
                            <col width="10%" />
                            <col width="10%" />
                            <col width="10%" />
                        </colgroup>
                        <tr>
                        <td colspan="8" class="tableCTB">IDENTIFICACION DEL CONDUCTOR</td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                        <td class="tableBG">Tipo de Conductor</td>
                        <td colspan="3"><asp:Label ID="Label41" runat="server" Text='<%# Eval("TIVCHTIPCODIGO") %>' /> <asp:Label ID="Label74" runat="server" Text='<%# Eval("VCHGRPDESCRI") %>' /></td>
                        <td class="tableBG">Nombre Comercial</td>
                        <td colspan="3"><asp:Label ID="Label75" runat="server" Text='<%# Eval("VCHAECONOMCOMER") %>' /></td>
                        </tr>
                        <tr>
                        <td class="tableBG">Tipo Doc.Identidad</td>
                        <td colspan="3"><asp:Label ID="Label76" runat="server" Text='<%# Eval("TIVCHTIDCODIGO") %>' /> <asp:Label ID="Label78" runat="server" Text='<%# Eval("VCHTIDDESCRI") %>' /></td>
                        <td class="tableBG">Número de Documento</td>
                        <td colspan="3"><asp:Label ID="Label79" runat="server" Text='<%# Eval("TIVCHADMNUMDOCUMENTO") %>' /></td>
                        </tr>
                        <tr>
                        <td class="tableBG">Número de RUC</td>
                        <td colspan="3"><asp:Label ID="Label80" runat="server" Text='<%# Eval("VCHNUMRUC") %>' /></td>
                        <td class="tableBG">Razón Social Conductor</td>
                        <td colspan="3"><asp:Label ID="Label82" runat="server" Text='<%# Eval("VCHADMCOMPLETO") %>' /></td>
                        </tr>
                        <tr>
                        <td class="tableBG">Condición del Conductor</td>
                        <td colspan="3"><asp:Label ID="Label83" runat="server" Text='<%# Eval("CHRAECOCONCOND") %>' /> <asp:Label ID="Label84" runat="server" Text='<%# Eval("VCHCCONDDESCRIPCION") %>' /></td>
                        <td></td>
                        <td colspan="3"><asp:Label ID="Label85" runat="server" Text='<%# Eval("CHRAECOCONCONDOTROS") %>' /></td>
                        </tr>
                        <tr>
                        <td colspan="8">_</td>
                        </tr>
                        </tr>
                        <tr class="tableCTB">
                        <td colspan="8">OBSERVACIONES</td>
                        </tr>
                        <tr>
                        <td colspan="8"><asp:Label ID="Label91" runat="server" Text='<%# Eval("VCHUCAOBS") %>' /></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                    </table>
                    </FooterTemplate>
           </asp:Repeater>
           <br />

           <asp:Repeater ID="rptAE_LIC" runat="server">
                    <HeaderTemplate>
                    <table id="Table5" cellspacing="0" rules="all" border="1" class="table" width="850px">
                        <colgroup>
                            <col width="15%" />
                            <col width="85%" />
                            <col width="10%" />
                        </colgroup>
                        <tr>
                        <td colspan="3" class="tableCTB">AUTORIZACION MUNICIPAL DE FUNCIONAMIENTO</td>
                        </tr>
                        <tr class="tableBGT">
                        <td>Código Actividad</td>
                        <td>Descripción de la Actividad</td>
                        <td>Act. Principal</td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                        <td><asp:Label ID="Label78" runat="server" Text='<%# Eval("CodAct") %>' /></td>
                        <td><asp:Label ID="Label76" runat="server" Text='<%# Eval("DesAct") %>' /></td>
                        <td><asp:Label ID="Label79" runat="server" Text='<%# Eval("FlgPrinc") %>' /></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                    </table>
                    </FooterTemplate>
           </asp:Repeater>
           <br />

           <asp:Repeater ID="rptAE_LANU" runat="server">
                <HeaderTemplate>
                <table id="Table5" cellspacing="0" rules="all" border="1" class="table" width="850px">
                    <colgroup>
                        <col width="10%" />
                        <col width="25%" />
                        <col width="05%" />
                        <col width="10%" />
                        <col width="10%" />
                        <col width="10%" />
                        <col width="10%" />
                        <col width="10%" />
                        <col width="10%" />
                    </colgroup>
                    <tr>
                    <td colspan="9" class="tableCTB">AUTORIZACION DE ANUNCIO</td>
                    </tr>
                    <tr class="tableBGT">
                    <td>Código de Tipo</td>
                    <td>Descripción del Tipo Anuncio</td>
                    <td>Nº Lados</td>
                    <td>Area Autorizada del Anuncio</td>
                    <td>Area Verificada del Anuncio</td>
                    <td>Nº Expediente</td>
                    <td>Nº Licencia</td>
                    <td>Fecha Expedición</td>
                    <td>Fecha Vencimiento</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                        <tr>
                        <td><asp:Label ID="Label78" runat="server" Text='<%# Eval("CodAnu") %>' /></td>
                        <td><asp:Label ID="Label76" runat="server" Text='<%# Eval("DesAnu") %>' /></td>
                        <td><asp:Label ID="Label79" runat="server" Text='<%# Eval("NumLad") %>' /></td>
                        <td><asp:Label ID="Label81" runat="server" Text='<%# Eval("AreAut") %>' /></td>
                        <td><asp:Label ID="Label86" runat="server" Text='<%# Eval("AreVer") %>' /></td>
                        <td><asp:Label ID="Label87" runat="server" Text='<%# Eval("NumExp") %>' /></td>
                        <td><asp:Label ID="Label88" runat="server" Text='<%# Eval("NumLic") %>' /></td>
                        <td><asp:Label ID="Label89" runat="server" Text='<%# Eval("FecEmi") %>' /></td>
                        <td><asp:Label ID="Label90" runat="server" Text='<%# Eval("FecVen") %>' /></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                    </table>
                    </FooterTemplate>
           </asp:Repeater>
           
       </asp:View>
       <asp:View ID="ViewCO_3" runat="server">
           <br /> 
           <asp:Repeater ID="rptCO_ADMIN" runat="server">
                    <HeaderTemplate>
                    <table id="Table5" cellspacing="0" rules="all" border="1" class="table" width="850px">
                        <colgroup>
                            <col width="10%" />
                            <col width="10%" />
                            <col width="10%" />
                            <col width="10%" />
                            <col width="10%" />
                            <col width="10%" />
                            <col width="10%" />
                            <col width="10%" />
                            <col width="10%" />
                            <col width="10%" />
                        </colgroup>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                        <td colspan="10" class="tableCTB">DATOS DEL COTITULAR CATASTRAL</td>
                        </tr>
                        <tr>
                        <td class="tableBG">Nro. Cotitular</td>
                        <td><asp:Label ID="Label41" runat="server" Text='<%# Eval("NROCOTI") %>' /></td>
                        <td class="tableBG">Total de Cotitulares</td>
                        <td><asp:Label ID="Label92" runat="server" Text='<%# Eval("TOTALCOTI") %>' /></td>
                        <td class="tableBG">Tipo Cotitular</td>
                        <td><asp:Label ID="Label93" runat="server" Text='<%# Eval("VCHTIPCODIGO") %>' /> <asp:Label ID="Label94" runat="server" Text='<%# Eval("VCHGRPDESCRI") %>' /></td>
                        <td class="tableBG">% Cotitularidad</td>
                        <td><asp:Label ID="Label95" runat="server" Text='<%# Eval("DECCCOTPORCENT") %>' /></td>
                        <td class="tableBG">Codigo Contribuyente</td>
                        <td><asp:Label ID="Label96" runat="server" Text='<%# Eval("INTADMCODIGO") %>' /></td>
                        </tr>

                        <tr>
                        <td class="tableBG">Tipo Documento</td>
                        <td><asp:Label ID="Label97" runat="server" Text='<%# Eval("VCHTIDCODIGO") %>' /> <asp:Label ID="Label102" runat="server" Text='<%# Eval("VCHTIDDESCRI") %>' /></td>
                        <td class="tableBG">Nro.Documento</td>
                        <td><asp:Label ID="Label98" runat="server" Text='<%# Eval("VCHADMNUMDOCUMENTO") %>' /></td>
                        <td class="tableBG">Nombres y Apellidos</td>
                        <td colspan="5"><asp:Label ID="Label99" runat="server" Text='<%# Eval("VCHADMNOMBRES") %>' /> <asp:Label ID="Label100" runat="server" Text='<%# Eval("VCHADMAPEPATERNO") %>' /> <asp:Label ID="Label101" runat="server" Text='<%# Eval("VCHADMAPEMATERNO") %>' /></td>
                        </tr>

                        <tr>
                        <td class="tableBG">Nro. RUC</td>
                        <td><asp:Label ID="Label103" runat="server" Text='<%# Eval("VCHADMNUMRUC") %>' /></td>
                        <td class="tableBG">Razon Social</td>
                        <td colspan="5"><asp:Label ID="Label104" runat="server" Text='<%# Eval("VCHADMRAZSOCIAL") %>' /></td>
                        <td colspan="2"></td>
                        </tr>

                        <tr>
                        <td class="tableBG" colspan="2">Forma Adquisición</td>
                        <td><asp:Label ID="Label109" runat="server" Text='<%# Eval("VCHCCOTFORADQUI") %>' /> <asp:Label ID="Label105" runat="server" Text='<%# Eval("VCHFADQUDESCRIPCION") %>' /></td>
                        <td class="tableBG" colspan="2">Fecha Adquisición</td>
                        <td><asp:Label ID="Label106" runat="server" Text='<%# Eval("DATCCOTFECADQ") %>' /></td>
                        <td class="tableBG" colspan="2">Condición Especial Titular</td>
                        <td colspan="2"><asp:Label ID="Label108" runat="server" Text='<%# Eval("VCHCCOTCONESPTITU") %>' /> <asp:Label ID="Label107" runat="server" Text='<%# Eval("VCHCETIDESCRIPCION") %>' /></td>
                        </tr>

                        <tr>
                        <td class="tableBG" colspan="2">Resolucion Exoneración</td>
                        <td><asp:Label ID="Label110" runat="server" Text='<%# Eval("VCHCCOTNUMRESEXO") %>' /></td>
                        <td class="tableBG" colspan="2">Fecha Inicio</td>
                        <td><asp:Label ID="Label112" runat="server" Text='<%# Eval("DATCCOTFECINIC") %>' /></td>
                        <td class="tableBG" colspan="2">Fecha Vencimiento</td>
                        <td colspan="2"><asp:Label ID="Label113" runat="server" Text='<%# Eval("DATCCOTFECVENC") %>' /></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                    </table>
                    </FooterTemplate>
           </asp:Repeater>
           <br />
           <asp:Repeater ID="rptCO_FIC" runat="server">
                    <HeaderTemplate>
                    <table id="Table5" cellspacing="0" rules="all" border="1" class="table" width="850px">
                        <colgroup>
                            <col width="10%" />
                            <col width="10%" />
                            <col width="10%" />
                            <col width="10%" />
                            <col width="10%" />
                            <col width="10%" />
                            <col width="10%" />
                            <col width="10%" />
                            <col width="10%" />
                            <col width="10%" />
                        </colgroup>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                        <td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td>
                        </tr>
                        <tr>
                        <td colspan="10" class="tableCTB">INFORMACION COMPLEMENTARIA</td>
                        </tr>
                        <tr>
                        <td colspan="2" class="tableBG">Condición Declarante</td>
                        <td colspan="3"><asp:Label ID="Label109" runat="server" Text='<%# Eval("CHRCDECLCODIGO") %>' /> <asp:Label ID="Label105" runat="server" Text='<%# Eval("VCHCDECLDESCRIPCION") %>' /></td>
                        <td colspan="2" class="tableBG">Estado Llenado Ficha</td>
                        <td colspan="3"><asp:Label ID="Label106" runat="server" Text='<%# Eval("CHRFICESTLLEN") %>' /> <asp:Label ID="Label111" runat="server" Text='<%# Eval("VCHESTDESCRIPCION") %>' /></td>
                        </tr>
                        <tr>
                        <td colspan="10">_</td>
                        </tr>
                        <tr>
                        <td colspan="10" class="tableCTB">OBSERVACIONES</td>
                        </tr>
                        <tr>
                        <td colspan="10"><asp:Label ID="Label110" runat="server" Text='<%# Eval("VCHUCAOBS") %>' /></td>
                        </tr>

                    </ItemTemplate>
                    <FooterTemplate>
                    </table>
                    </FooterTemplate>
           </asp:Repeater>

       </asp:View>
       <asp:View ID="ViewBC_4" runat="server">
            <br />
           <asp:Repeater ID="rptBC_UBI" runat="server">
                    <HeaderTemplate>
                    <table id="Table5" cellspacing="0" rules="all" border="1" class="table" width="850px">
                        <colgroup>
                            <col width="10%" />
                            <col width="10%" />
                            <col width="20%" />
                            <col width="10%" />
                            <col width="10%" />
                            <col width="10%" />
                            <col width="20%" />
                            <col width="10%" />
                        </colgroup>
                        <tr>
                        <td colspan="8" class="tableCTB">UBICACION DEL BIEN COMUN</td>
                        </tr>
                        <tr class="tableBGT">
                        <td>Cod.Via</td>
                        <td>Tipo Via</td>
                        <td>Nombre Via</td>
                        <td>Tipo Puerta</td>
                        <td>Verif.Campo</td>
                        <td>Cert.Num.</td>
                        <td>Condicion</td>
                        <td>Nº Certif</td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr >
                        <td><asp:Label ID="Label41" runat="server" Text='<%# Eval("CodVia") %>' /></td>
                        <td><asp:Label ID="Label33" runat="server" Text='<%# Eval("TipoVia") %>' /></td>
                        <td><asp:Label ID="Label34" runat="server" Text='<%# Eval("NomVia") %>' /></td>
                        <td><asp:Label ID="Label35" runat="server" Text='<%# Eval("NomTPuerta") %>' /></td>
                        <td><asp:Label ID="Label36" runat="server" Text='<%# Eval("VerfCampo") %>' /></td>
                        <td><asp:Label ID="Label37" runat="server" Text='<%# Eval("VerfCerNum") %>' /></td>
                        <td><asp:Label ID="Label38" runat="server" Text='<%# Eval("CodConNum") %>' /> <asp:Label ID="Label40" runat="server" Text='<%# Eval("NomConNum") %>' /></td>
                        <td><asp:Label ID="Label39" runat="server" Text='<%# Eval("NroCerNR") %>' /></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                    </table>
                    </FooterTemplate>
           </asp:Repeater>

           <br />
           <asp:Repeater ID="rptBC_FIC" runat="server">
           <HeaderTemplate>
           </HeaderTemplate>
           <ItemTemplate>
                <center>
                <table id="Table02" cellspacing="0" rules="all" border="1" class="table" width="850px">
                    <colgroup>
                        <col width="15%" />
                        <col width="20%" />
                        <col width="15%" />
                        <col width="15%" />
                        <col width="20%" />
                        <col width="15%" />
                    </colgroup>
                        <tr>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        </tr>

                        <tr>
                        <td class="tableBG">Nombre de Edificación</td>
                        <td colspan="2"><asp:Label ID="Label42" runat="server" Text='<%# Eval("VCHBICNOMEDIF") %>' /></td>
                        <td class="tableBG">Tipo de Edificacion</td>
                        <td colspan="2"><asp:Label ID="Label43" runat="server" Text='<%# Eval("CHRTBLOCODIGO") %>' /> <asp:Label ID="Label44" runat="server" Text='<%# Eval("VCHTBLODESCRIPCION") %>' /></td>
                        </tr>

                        <tr class="tableBGT">
                        <td>Codigo HU</td>
                        <td>Nombre HU</td>
                        <td>Zona Sector Etapa</td>
                        <td>Manzana</td>
                        <td>Lote</td>
                        <td>Sublote</td>
                        </tr>

                        <tr>
                        <td><asp:Label ID="Label50" runat="server" Text='<%# Eval("CHRCURCODIGO") %>' /></td>
                        <td><asp:Label ID="Label52" runat="server" Text='<%# Eval("VCHCURDESCRIPCION") %>' /></td>
                        <td><asp:Label ID="Label114" runat="server" Text='<%# Eval("VCHBICETAPA") %>' /></td>
                        <td><asp:Label ID="Label53" runat="server" Text='<%# Eval("VCHMAUDESCRIPCION") %>' /></td>
                        <td><asp:Label ID="Label54" runat="server" Text='<%# Eval("VCHLOUDESCRIPCION") %>' /></td>
                        <td><asp:Label ID="Label55" runat="server" Text='<%# Eval("VCHSLODESCRIPCION") %>' /></td>
                        </tr>
                        <tr>
                        <td colspan="6" class="tableCTB"><br />DESCRIPCION DEL BIEN COMUN</td>
                        </tr>

                        <tr>
                        <td class="tableBG">Clasificación Predio</td>
                        <td><asp:Label ID="Label116" runat="server" Text='<%# Eval("VCHCLPREDESCRIPCION") %>' /></td>
                        <td><asp:Label ID="Label117" runat="server" Text='<%# Eval("VCHCLPREOTROS") %>' /></td>
                        <td class="tableBG">Predio Catastral en</td>
                        <td><asp:Label ID="Label118" runat="server" Text='<%# Eval("CHRTPREDCODIGO") %>' /> <asp:Label ID="Label119" runat="server" Text='<%# Eval("VCHTPREDDESCRIPCION") %>' /></td>
                        <td><asp:Label ID="Label120" runat="server" Text='<%# Eval("VCHBICTPREOTROS") %>' /></td>
                        </tr>

                        <tr>
                        <td class="tableBG">Codigo Uso</td>
                        <td><asp:Label ID="Label115" runat="server" Text='<%# Eval("CHRUSOCODIGO") %>' /></td>
                        <td class="tableBG">Uso del Predio Catastral</td>
                        <td colspan="3"><asp:Label ID="Label124" runat="server" Text='<%# Eval("VCHBICUSODESC") %>' /></td>
                        </tr>

                        <tr>
                        <td colspan="2" class="tableBG">Area de Terreno Titulo m2</td>
                        <td align="right"><asp:Label ID="Label125" runat="server" Text='<%# Eval("DECINDARETIT","{0:N2}") %>' /></td>
                        <td colspan="2" class="tableBG">Area de Terreno Verificada</td>
                        <td align="right"><asp:Label ID="Label129" runat="server" Text='<%# Eval("DECBICAREVER","{0:N2}") %>' /></td>
                        </tr>


                    </table>

           </ItemTemplate>
            <FooterTemplate>
            </FooterTemplate>
            </asp:Repeater>

           <br />
           <asp:Repeater ID="rptBC_RECAP" runat="server">
           <HeaderTemplate>
                <center>
                <table id="Table02" cellspacing="0" rules="all" border="1" class="table" width="850px">
                    <colgroup>
                        <col width="08%" />
                        <col width="08%" />
                        <col width="08%" />
                        <col width="08%" />
                        <col width="08%" />
                        <col width="15%" />
                        <col width="15%" />
                        <col width="15%" />
                        <col width="15%" />
                    </colgroup>
                        <tr class="tableBGT">
                        <td>Nro</td>
                        <td>Edifica</td>
                        <td>Entrada</td>
                        <td>Piso</td>
                        <td>Unidad</td>
                        <td>Porcentaje (%)</td>
                        <td>A.T.C.(m2)</td>
                        <td>A.C.C.(m2)</td>
                        <td>A.O.I.C.(m2)</td>
                        </tr>
           </HeaderTemplate>
           <ItemTemplate>

                        <tr>
                        <td align="center"><asp:Label ID="Label50" runat="server" Text='<%# Eval("num") %>' /></td>
                        <td align="center"><asp:Label ID="Label52" runat="server" Text='<%# Eval("edifica") %>' /></td>
                        <td align="center"><asp:Label ID="Label121" runat="server" Text='<%# Eval("ent") %>' /></td>
                        <td align="center"><asp:Label ID="Label114" runat="server" Text='<%# Eval("piso") %>' /></td>
                        <td align="center"><asp:Label ID="Label53" runat="server" Text='<%# Eval("und") %>' /></td>
                        <td align="right"><asp:Label ID="Label54" runat="server" Text='<%# Eval("porce","{0:N3}") %>' /></td>
                        <td align="right"><asp:Label ID="Label55" runat="server" Text='<%# Eval("ratc","{0:N3}") %>' /></td>
                        <td align="right"><asp:Label ID="Label115" runat="server" Text='<%# Eval("racc","{0:N3}") %>' /></td>
                        <td align="right"><asp:Label ID="Label122" runat="server" Text='<%# Eval("raoic","{0:N3}") %>' /></td>
                        </tr>
           </ItemTemplate>
           <FooterTemplate>
           </table>
           </FooterTemplate>
           </asp:Repeater>
        <table id="Table02" cellspacing="0" rules="all" border="1" class="table" width="850px">
            <colgroup>
                <col width="08%" />
                <col width="08%" />
                <col width="08%" />
                <col width="08%" />
                <col width="08%" />
                <col width="15%" />
                <col width="15%" />
                <col width="15%" />
                <col width="15%" />
            </colgroup>
            <tr>
            <td align="center" colspan="5">T O T A L</td>
            <td align="right"><asp:Label ID="lblPORC" runat="server" /></td>
            <td align="right"><asp:Label ID="lblATC" runat="server" /></td>
            <td align="right"><asp:Label ID="lblACC" runat="server" /></td>
            <td align="right"><asp:Label ID="lblAOIC" runat="server" /></td>
            </tr>

            </table>

       </asp:View>
       </asp:MultiView>
       </center >



       <br />
       <br />
    </div>

    </form>
</body>
</html>
