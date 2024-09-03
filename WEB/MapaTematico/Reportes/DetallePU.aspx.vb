Imports System.IO
Imports System.Data


Partial Class REPORTES_DetallePU
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Dim vANOPRO As Integer = CType(Request.QueryString("pANOPRO"), Integer)
            Dim vNUMDDJJ As Integer = CType(Request.QueryString("pNUMDDJJ"), Integer)
            Dim vCODPRE As Integer = CType(Request.QueryString("pCODPRE"), Integer)
            Dim vCODCAT As String = Request.QueryString("pCODCAT")
            lblCODCAT.Text = vCODCAT
            cargaGrillas(vANOPRO, vNUMDDJJ, vCODPRE)

        End If
    End Sub

    Public Sub cargaGrillas(ByVal pANOPRO As Integer, ByVal pNUMDDJJ As Integer, ByVal pCODPRE As Integer)


        Dim oSATTI_BL = New SISSADE.BL.SATTI_BL
        Dim oDt As New DataTable

        oDt = oSATTI_BL.ListaDetPredioPU(pANOPRO, pNUMDDJJ, pCODPRE)
        rptCAB.DataSource = oDt
        rptCAB.DataBind()

        rptCABTOT.DataSource = oDt
        rptCABTOT.DataBind()


        oDt = oSATTI_BL.ListaDetPredioCONS(pANOPRO, pNUMDDJJ, pCODPRE)

        rptDETPU.DataSource = oDt
        rptDETPU.DataBind()
    End Sub

End Class
