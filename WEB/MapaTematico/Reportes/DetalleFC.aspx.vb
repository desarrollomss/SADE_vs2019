Imports System.IO
Imports System.Data


Partial Class REPORTES_DetalleFC
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Dim vFICHA As Integer = CType(Request.QueryString("pFICHA"), Integer)
            Dim vCODCAT As String = Request.QueryString("pCODCAT")
            Dim vTIPFIC As String = Request.QueryString("pTIPFIC")
            'lblCODCAT.Text = vCODCAT
            lblTipoFicha.Text = vTIPFIC
            lblDpto.Text = "15"
            lblProv.Text = "01"
            lblDist.Text = vCODCAT.Substring(0, 2)
            lblSecc.Text = vCODCAT.Substring(2, 2)
            lblManz.Text = vCODCAT.Substring(4, 2)
            lblLote.Text = vCODCAT.Substring(6, 2)
            lblEdif.Text = vCODCAT.Substring(8, 2)
            lblEntr.Text = vCODCAT.Substring(10, 2)
            lblPiso.Text = vCODCAT.Substring(12, 2)
            lblUnid.Text = vCODCAT.Substring(14, 3)
            lblDigC.Text = vCODCAT.Substring(17, 1)

            Select Case vTIPFIC
                Case "IN"
                    mvwFichas.ActiveViewIndex = 0
                    ReporteFichaIN(vFICHA)
                Case "AE"
                    mvwFichas.ActiveViewIndex = 1
                    ReporteFichaAE(vFICHA)
                Case "CO"
                    mvwFichas.ActiveViewIndex = 2
                    ReporteFichaCO(vFICHA)
                Case "BC"
                    mvwFichas.ActiveViewIndex = 3
                    ReporteFichaBC(vFICHA)
            End Select


        End If
    End Sub


    Public Sub ReporteFichaIN(ByVal pFICHA As String)

        Dim oCATINDIVIDUAL_BL = New SIRUC.BL.CATINDIVIDUAL_BL
        Dim oCATINDIVUBIPRE_BL As New SIRUC.BL.CATINDIVUBIPRE_BL
        Dim oCATINDIVLIMITES_BL As New SIRUC.BL.CATINDIVLIMITES_BL
        Dim oCATFRENTELOTE_BL As New SIRUC.BL.CATFRENTELOTE_BL
        Dim oCATINDIVCONSTRUC_BL As New SIRUC.BL.CATINDIVCONSTRUC_BL
        Dim oCATINDIVOTINSTAL_BL As New SIRUC.BL.CATINDIVOTINSTAL_BL
        Dim oCATLOTEUC_BL = New SIRUC.BL.CATLOTEUC_BL
        Dim oCATINDIVDOCPRES_BL As New SIRUC.BL.CATINDIVDOCPRES_BL
        Dim oCATINDIVLITIGANTE_BL As New SIRUC.BL.CATINDIVLITIGANTE_BL
        Dim codigoIN As String = ""

        codigoIN = " IN (" & pFICHA & ")"

        Dim oDt As DataTable = oCATINDIVIDUAL_BL.ReporteFicha(codigoIN)


        lblCodAdm.Text = oDt.Rows(0)("INTCODIGOTIT")
        If oDt.Rows(0)("INTPRECODIGO") Is DBNull.Value Then
        Else

            lblCodPre.Text = oDt.Rows(0)("INTPRECODIGO")
        End If
        lblUniAcm.Text = oDt.Rows(0)("VCHACUMULADO")


        rptIN_FICHA.DataSource = oDt
        rptIN_FICHA.DataBind()

        rptIN_UBI.DataSource = oCATINDIVUBIPRE_BL.ListarXFichas(codigoIN)
        rptIN_UBI.DataBind()


        rptIN_CON.DataSource = oCATINDIVCONSTRUC_BL.ListarXFichas(codigoIN)
        rptIN_CON.DataBind()


        'objRptFicIndividual.Subreports("subrptCATINDIVUBIPRE.rpt").SetDataSource(oCATINDIVUBIPRE_BL.ListarXFichas(codigoIN))
        'objRptFicIndividual.Subreports("subrptCATINDIVLIMITES.rpt").SetDataSource(oCATINDIVLIMITES_BL.ListarXFichas(codigoIN))
        'objRptFicIndividual.Subreports("subrptCATFRENTELOTE.rpt").SetDataSource(oCATFRENTELOTE_BL.ListarXFichas(codigoIN))
        'objRptFicIndividual.Subreports("subrptCATLOTEUCZOES.rpt").SetDataSource(oCATLOTEUC_BL.ListarXFichas(codigoIN))
        'objRptFicIndividual.Subreports("subrptCATINDIVCONSTRUC.rpt").SetDataSource(oCATINDIVCONSTRUC_BL.ListarXFichas(codigoIN))
        'objRptFicIndividual.Subreports("subrptCATINDIVOTINSTAL.rpt").SetDataSource(oCATINDIVOTINSTAL_BL.ListarXFichas(codigoIN))
        'objRptFicIndividual.Subreports("subrptCATINDIVDOCPRES.rpt").SetDataSource(oCATINDIVDOCPRES_BL.ListarXFichas(codigoIN))
        'objRptFicIndividual.Subreports("subrptCATINDIVLITIGANTE.rpt").SetDataSource(oCATINDIVLITIGANTE_BL.ListarXFichas(codigoIN))

    End Sub

    Public Sub ReporteFichaAE(ByVal pFICHA As String)

        Dim oCATACTIVIDADECON_BL = New SIRUC.BL.CATACTIVIDADECON_BL
        Dim oCATAECOACTIVIDAD_BL As New SIRUC.BL.CATAECOACTIVIDAD_BL
        Dim oCATAEANUNCIO_BL As New SIRUC.BL.CATAEANUNCIO_BL
        Dim codigoAE As String = ""

        codigoAE = " IN (" & pFICHA & ")"

        Dim oDt As DataTable = oCATACTIVIDADECON_BL.ReporteFicha(codigoAE)

        rptAE_Ficha.DataSource = oDt
        rptAE_Ficha.DataBind()

        rptAE_LIC.DataSource = oCATAECOACTIVIDAD_BL.ListarXFichas(codigoAE)
        rptAE_LIC.DataBind()

        rptAE_LANU.DataSource = oCATAEANUNCIO_BL.ListarXFichas(codigoAE)
        rptAE_LANU.DataBind()

        'objRptFicEconomica.Subreports("subrptCATAECOACTIVIDAD.rpt").SetDataSource()
        'objRptFicEconomica.Subreports("subrptCATAEANUNCIO.rpt").SetDataSource(oCATAEANUNCIO_BL.ListarXFichas(codigoAE))


    End Sub

    Public Sub ReporteFichaBC(ByVal pFICHA As String)

        Dim oCATBIENCOMUN_BL = New SIRUC.BL.CATBIENCOMUN_BL
        Dim oCATBIENUBIPRE_BL As New SIRUC.BL.CATBIENUBIPRE_BL
        Dim oCATBIENLIMITES_BL As New SIRUC.BL.CATBIENLIMITES_BL
        Dim oCATBIENCONSPRE_BL As New SIRUC.BL.CATBIENCONSPRE_BL
        Dim oCATBIENOTINPRE_BL As New SIRUC.BL.CATBIENOTINPRE_BL
        Dim oCATBIENRECEDIF_BL As New SIRUC.BL.CATBIENRECEDIF_BL
        Dim oCATBIENRBPRI_BL As New SIRUC.BL.CATBIENRBPRI_BL
        Dim oCATLOTEUC_BL = New SIRUC.BL.CATLOTEUC_BL
        Dim codigoBC As String = ""
        codigoBC = " IN (" & pFICHA & ")"

        Dim oDt As DataTable = oCATBIENCOMUN_BL.ReporteFicha(codigoBC)
        Dim oRt As DataTable = oCATBIENRBPRI_BL.ListarXFichas(codigoBC)

        rptBC_FIC.DataSource = oDt
        rptBC_FIC.DataBind()

        rptBC_UBI.DataSource = oCATBIENUBIPRE_BL.ListarXFichas(codigoBC)
        rptBC_UBI.DataBind()

        Dim sumPORC As Decimal = 0
        Dim sumRATCC As Decimal = 0
        Dim sumRACC As Decimal = 0
        Dim sumRAOIC As Decimal = 0
        For Each r As DataRow In oRt.Rows
            If r("porce") Is DBNull.Value Then
            Else
                sumPORC = sumPORC + r("porce")
            End If

            If r("ratc") Is DBNull.Value Then
            Else
                sumRATCC = sumRATCC + r("ratc")
            End If
            If r("racc") Is DBNull.Value Then
            Else
                sumRACC = sumRACC + r("racc")
            End If
            If r("raoic") Is DBNull.Value Then
            Else
                sumRAOIC = sumRAOIC + r("raoic")
            End If

        Next
        lblPORC.Text = sumPORC
        lblATC.Text = sumRATCC
        lblACC.Text = sumRACC
        lblAOIC.Text = sumRAOIC






        rptBC_RECAP.DataSource = oRt
        rptBC_RECAP.DataBind()


        'objRptFicBienComun.SetDataSource(oDt)
        'objRptFicBienComun.Subreports("subrptCATBIENUBIPRE.rpt").SetDataSource()
        'objRptFicBienComun.Subreports("subrptCATBIENLIMITES.rpt").SetDataSource(oCATBIENLIMITES_BL.ListarXFichas(codigoBC))
        'objRptFicBienComun.Subreports("subrptCATBIENCONSPRE.rpt").SetDataSource(oCATBIENCONSPRE_BL.ListarXFichas(codigoBC))
        'objRptFicBienComun.Subreports("subrptCATBIENOTINPRE.rpt").SetDataSource(oCATBIENOTINPRE_BL.ListarXFichas(codigoBC))
        'objRptFicBienComun.Subreports("subrptCATBIENRECEDIF.rpt").SetDataSource(oCATBIENRECEDIF_BL.ListarXFichas(codigoBC))
        'objRptFicBienComun.Subreports("subrptCATBIENRBPRI.rpt").SetDataSource(oCATBIENRBPRI_BL.ListarXFichas(codigoBC))
        'objRptFicBienComun.Subreports("subrptCATLOTEUCZOES.rpt").SetDataSource(oCATLOTEUC_BL.ListarXFichas(codigoBC))







    End Sub

    Public Sub ReporteFichaCO(ByVal pFICHA As String)

        Dim oCATCONDOMINO_BL As New SIRUC.BL.CATCONDOMINO_BL
        Dim oCATADMINISTRADO_BL As New SIRUC.BL.CATADMINISTRADO_BL

        Dim codigoCO As String = ""


        codigoCO = " IN (" & pFICHA & ")"

        'codigoCO = " IN (" & codigoCO.Substring(0, codigoCO.Length - 1) & ")"

        Dim oDt As DataTable = oCATADMINISTRADO_BL.ListarXFichas(codigoCO)
        
        rptCO_ADMIN.DataSource = oDt
        rptCO_ADMIN.DataBind()

        rptCO_FIC.DataSource = oCATCONDOMINO_BL.ReporteFicha(codigoCO)
        rptCO_FIC.DataBind()

    End Sub

 
End Class
