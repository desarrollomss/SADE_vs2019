<%@ Page Language="VB" AutoEventWireup="false" CodeFile="DetallePU.aspx.vb" Inherits="REPORTES_DetallePU" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

 	<style type="text/css">
th.rotate {
  /* Something you can count on */
  height: 140px;
  white-space: nowrap;
}

th.rotate > div {
  transform: 
    /* Magic Numbers */
    translate(25px, 51px)
    /* 45 is really 360 - 45 */
    rotate(90deg);
  width: 30px;
}
th.rotate > div > span {
  border-bottom: 1px solid #ccc;
  padding: 5px 10px;
}

     </style>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <table id="table00" cellspacing="0" rules="all" border="0" style="font-family: Arial, Verdana, Sans-Serif;
                font-size: 10px; width: 850px;">
                <colgroup>
                <col width="85%" />
                <col width="15%" />
                </colgroup>
                <tr align="center" style="font-family: Arial, Verdana, Sans-Serif; font-size: 30px; font-weight: bold; background-color: Black; color: White;">
                    <td></td>
                    <td>PU</td>
                </tr>
                <tr align="center" style="font-family: Arial, Verdana, Sans-Serif; font-size: 12px; background-color: Black; color: White;">
                    <td>CODIGO CATASTRAL : <asp:Label ID="lblCODCAT" runat="server"/></td>
                    <td>PREDIO URBANO</td>
                </tr>
            </table>

        <asp:Repeater ID="rptCAB" runat="server">
            <ItemTemplate>
                <br />
                <table id="table01" cellspacing="0" rules="all" border="1" style="font-family: Arial, Verdana, Sans-Serif;
                    font-size: 10px; width: 850px;">
                    <tr align="center" style="font-family: Arial, Verdana, Sans-Serif; font-size: 12px; font-weight: bold;">
                        <td colspan="2">
                            DATOS DEL CONTRIBUYENTE
                        </td>
                    </tr>
                    <tr align="center" style="background-color: Black; color: White">
                        <td>
                            CODIGO CONT.
                        </td>
                        <td>
                            APELLIDOS Y NOMBRES o RAZON SOCIAL
                        </td>
                    </tr>
                    <tr align="center">
                        <td>
                            <asp:Label ID="Label21" runat="server" Text='<%# Eval("INTADMCODIGO") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Label22" runat="server" Text='<%# Eval("VCHADMCOMPLETO") %>' />
                        </td>
                    </tr>
                </table>
                <br />
                <table id="table2" cellspacing="0" rules="all" border="1" style="font-family: Arial, Verdana, Sans-Serif;
                    font-size: 10px; width: 850px;">
                    <tr align="center" style="font-family: Arial, Verdana, Sans-Serif; font-size: 12px; font-weight: bold;">
                        <td colspan="9">
                            DATOS DEL PREDIO
                        </td>
                    </tr>
                    <tr align="center" style="background-color: Black; color: White">
                        <td>
                            CODIGO PREDIO
                        </td>
                        <td>
                            SECTOR
                        </td>
                        <td>
                            CONJUNTO URBANO
                        </td>
                        <td>
                            VIA
                        </td>
                        <td>
                            NUMEROS
                        </td>
                        <td>
                            EDIF./BLOCK
                        </td>
                        <td>
                            INT.
                        </td>
                        <td>
                            MZ.
                        </td>
                        <td>
                            LT./SLT.
                        </td>
                    </tr>
                    <tr align="center">
                        <td>
                            <asp:Label ID="Label23" runat="server" Text='<%# Eval("INTPRECODIGO") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Label24" runat="server" Text='<%# Eval("VCHSETCODIGO") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Label25" runat="server" Text='<%# Eval("VCHHABNOMBRE") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Label26" runat="server" Text='<%# Eval("VCHVIANOMBRE") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Label27" runat="server" Text='<%# Eval("VCHUURNUMERO") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Label28" runat="server" Text='<%# Eval("VCHUUREDIFIC") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Label29" runat="server" Text='<%# Eval("INTERIOR") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Label30" runat="server" Text='<%# Eval("VCHUURMANADMINI") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Label31" runat="server" Text='<%# Eval("VCHUURLOTADMINI") %>' />
                        </td>
                    </tr>
                </table>
                <table id="table3" cellspacing="0" rules="all" border="1" style="font-family: Arial, Verdana, Sans-Serif;
                    font-size: 10px; width: 850px;">
                    <tr align="center" style="background-color: Black; color: White">
                        <td>
                            ESTADO
                        </td>
                        <td>
                            TIPO
                        </td>
                        <td>
                            USO
                        </td>
                        <td>
                            CONDICION DE PROPIEDAD
                        </td>
                        <td>
                            % CONDOMINIO
                        </td>
                        <td>
                            Nº CONDOMINOS
                        </td>
                    </tr>
                    <tr align="center">
                        <td>
                            <asp:Label ID="Label32" runat="server" Text='<%# Eval("VCHESCDESCRI") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Label33" runat="server" Text='<%# Eval("VCHTIPDESCRI") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Label34" runat="server" Text='<%# Eval("VCHUSODESCRI") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Label35" runat="server" Text='<%# Eval("VCHCOPDESCRI") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Label36" runat="server" Text='<%# Eval("DECPREPORCOPROTOT") %>' />
                        </td>
                        <td>
                            <asp:Label ID="Label37" runat="server" Text='' />
                        </td>
                    </tr>
                </table>
                <table id="table4" cellspacing="0" rules="all" border="1" style="font-family: Arial, Verdana, Sans-Serif;
                    font-size: 10px; width: 850px;">
                    <colgroup>
                        <col width="15%" />
                        <col width="10%" />
                        <col width="15%" />
                        <col width="10%" />
                        <col width="15%" />
                        <col width="10%" />
                        <col width="15%" />
                        <col width="10%" />
                    </colgroup>
                    <tr align="center" style="font-family: Arial, Verdana, Sans-Serif; font-size: 12px; font-weight: bold;">
                        <td colspan="4">INAFECTACION/EXONERACION</td>
                        <td colspan="4">BENEFICIO TRIBUTARIO DE PENSIONISTA</td>
                    </tr>

                    <tr>
                        <td align="center" style="background-color: Black; color: White">
                            REGIMEN
                        </td>
                        <td align="center">
                            <asp:Label ID="Label43" runat="server" Text='<%# Eval("REGIMEN") %>' />
                        </td>
                        <td align="center" style="background-color: Black; color: White">
                            % EXONERACION
                        </td>
                        <td align="center">
                            <asp:Label ID="Label44" runat="server" Text='<%# Eval("DECPRIPOREXONERA") %>' />
                        </td>
                        <td align="center" style="background-color: Black; color: White">
                            FEC. INICIO
                        </td>
                        <td align="center">
                            <asp:Label ID="Label45" runat="server" Text='<%# Eval("INICIOPENSION") %>' />
                        </td>
                        <td align="center" style="background-color: Black; color: White">
                            RENOVAR B.T.P.
                        </td>
                        <td align="center">
                            <asp:Label ID="Label46" runat="server" Text='<%# Eval("RENOVARBTP") %>' />
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:Repeater>
        <br />
        <asp:Repeater ID="rptDETPU" runat="server">
            <HeaderTemplate>
                <table id="Table1" cellspacing="0" rules="all" border="1" style="font-family: Arial, Verdana, Sans-Serif;
                    font-size: 10px; width: 850px;">
                    <tr align="center" style="font-family: Arial, Verdana, Sans-Serif; font-size: 12px; font-weight: bold;">
                        <td colspan="21">
                            DETERMINACION DEL VALUO
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <img src="IMG/CCNIVEL.png" />
                        </td>
                        <td>
                            <img src="IMG/CCANTIGUEDAD.png" />
                        </td>
                        <td>
                            <img src="IMG/CCCLASIFICACION.png" />
                        </td>
                        <td>
                            <img src="IMG/CCMATERIAL.png" />
                        </td>
                        <td>
                            <img src="IMG/CCCONSERVACION.png" />
                        </td>
                        <td>
                            <img src="IMG/CCMUROS.png" />
                        </td>
                        <td>
                            <img src="IMG/CCTECHOS.png" />
                        </td>
                        <td>
                            <img src="IMG/CCPISOS.png" />
                        </td>
                        <td>
                            <img src="IMG/CCPUERTAS.png" />
                        </td>
                        <td>
                            <img src="IMG/CCREVESTIMIENTO.png" />
                        </td>
                        <td>
                            <img src="IMG/CCBANOS.png" />
                        </td>
                        <td>
                            <img src="IMG/CCINSELEC.png" />
                        </td>
                        <td>
                            <img src="IMG/CCVALUNI.png" />
                        </td>
                        <td>
                            <img src="IMG/CCINCRE5.png" />
                        </td>
                        <td>
                            <img src="IMG/CCPORCDEPRE.png" />
                        </td>
                        <td>
                            <img src="IMG/CCVALUNIDEP.png" />
                        </td>
                        <td>
                            <img src="IMG/CCARCONM2.png" />
                        </td>
                        <td>
                            <img src="IMG/CCARCONVAL.png" />
                        </td>
                        <td>
                            <img src="IMG/CCARCOMM2.png" />
                        </td>
                        <td>
                            <img src="IMG/CCARCOMVAL.png" />
                        </td>
                        <td>
                            <img src="IMG/CCVALCONS.png" />
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                    <tr align="center">
                    <td>
                        <asp:Label ID="Label21" runat="server" Text='<%# Eval("VCHCONNUMPISO") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label20" runat="server" Text='<%# Eval("ANTIGUEDAD") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label01" runat="server" Text='<%# Eval("VCHCLPCODIGO") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label02" runat="server" Text='<%# Eval("VCHMAPCODIGO") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label03" runat="server" Text='<%# Eval("VCHESCCODIGO") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label04" runat="server" Text='<%# Eval("CHRCONCATMUROS") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label05" runat="server" Text='<%# Eval("CHRCONCATTECHOS") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label06" runat="server" Text='<%# Eval("CHRCONCATPISOS") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label07" runat="server" Text='<%# Eval("CHRCONCATPUERTA") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label08" runat="server" Text='<%# Eval("CHRCONCATREVES") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label09" runat="server" Text='<%# Eval("CHRCONCATBANOS") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label10" runat="server" Text='<%# Eval("CHRCONCATINSTAL") %>' />
                    </td>
                    <td align="right">
                        <asp:Label ID="Label11" runat="server" Text='<%# Eval("DECCONVALUNITA","{0:N2}") %>' />
                    </td>
                    <td align="right">
                        <asp:Label ID="Label12" runat="server" Text='<%# Eval("DECCONINCRE5","{0:N2}") %>' />
                    </td>
                    <td align="right">
                        <asp:Label ID="Label13" runat="server" Text='<%# Eval("DECCONPORDEPREC","{0:N2}") %>' />
                    </td>
                    <td align="right">
                        <asp:Label ID="Label14" runat="server" Text='<%# Eval("DECCONVALUNIDEP","{0:N2}") %>' />
                    </td>
                    <td align="right">
                        <asp:Label ID="Label15" runat="server" Text='<%# Eval("AREA_CONSTRUIDA","{0:N2}") %>' />
                    </td>
                    <td align="right">
                        <asp:Label ID="Label16" runat="server" Text='<%# Eval("VALOR_AREA_CONSTRUIDA","{0:N2}") %>' />
                    </td>
                    <td align="right">
                        <asp:Label ID="Label17" runat="server" Text='<%# Eval("DECCONPORCOMUN","{0:N2}") %>' />
                    </td>
                    <td align="right">
                        <asp:Label ID="Label18" runat="server" Text='<%# Eval("VALOR_AREA_COMUN","{0:N2}") %>' />
                    </td>
                    <td align="right">
                        <asp:Label ID="Label19" runat="server" Text='<%# Eval("DECCONVALCONSTR","{0:N2}") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <br />
        <asp:Repeater ID="rptCABTOT" runat="server">
            <ItemTemplate>
                <table id="table5" cellspacing="0" rules="all" border="1" style="font-family: Arial, Verdana, Sans-Serif;
                    font-size: 10px; width: 850px;">
                    <colgroup>
                        <col width="15%" />
                        <col width="15%" />
                        <col width="15%" />
                        <col width="15%" />
                        <col width="25%" />
                        <col width="15%" />
                    </colgroup>
                    <tr align="center">
                        <td colspan="3" style="font-family: Arial, Verdana, Sans-Serif; font-size: 12px; font-weight: bold;" >DATOS DEL TERRENO</td>
                        <td style="background-color: Black; color: White">FECHA DE EMISION</td>
                        <td align="left">
                            VALOR TOTAL CONSTRUCCION
                        </td>
                        <td align="right">
                            <asp:Label ID="Label41" runat="server" Text='<%# Eval("DECPREVALCONST","{0:N2}") %>' />
                        </td>
                    </tr>
                    <tr align="center">
                        <td style="background-color: Black; color: White">AREA (m2)</td>
                        <td style="background-color: Black; color: White">AREA COMUN (m2)</td>
                        <td style="background-color: Black; color: White">VALOR ARANCELARIO</td>
                        <td><asp:Label ID="Label49" runat="server" Text='<%# Eval("FECHA_EMISION") %>' /></td>
                        <td align="left">
                            VALOR OTRAS INSTALACIONES
                        </td>
                        <td align="right">
                            <asp:Label ID="Label38" runat="server" Text='<%# Eval("DECPREVALOBRCOMP","{0:N2}") %>' />
                        </td>
                    </tr>
                    <tr align="center">
                        <td><asp:Label ID="Label42" runat="server" Text='<%# Eval("DECPRETERPREDIAL","{0:N2}") %>' />
                        </td>
                        <td><asp:Label ID="Label47" runat="server" Text='<%# Eval("DECPREARECOMUN","{0:N2}") %>' />
                        </td>
                        <td><asp:Label ID="Label48" runat="server" Text='<%# Eval("DECPREARANCEL","{0:N2}") %>' />
                        </td>
                        <td style="background-color: Black; color: White">FECHA DE ADQUISICION</td>
                        <td align="left">
                            VALOR DEL TERRENO
                        </td>
                        <td align="right">
                            <asp:Label ID="Label39" runat="server" Text='<%# Eval("DECPREVALTERRENO","{0:N2}") %>' />
                        </td>
                    </tr>
                    <tr align="center">
                        <td colspan="3"></td>
                        <td><asp:Label ID="Label50" runat="server" Text='<%# Eval("DATPREFECADQUISI") %>' /></td>
                        <td align="left">
                            VALOR DEL AUTOAVALUO
                        </td>
                        <td align="right">
                            <asp:Label ID="Label40" runat="server" Text='<%# Eval("DECPREIMPPREDIAL","{0:N2}") %>' />
                        </td>
                    </tr>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>
