Imports SISSADE.BE
Imports SISSADE.BL
Imports System.Data

Partial Class frmPopBuscaPersonal
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        If Session("DatosUsuarioActivo") Is Nothing Then
            Session.Clear()
            Session.Abandon()
            Response.Redirect(Request.ApplicationPath & "/frmLogin.aspx")
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim sec As String = Request.QueryString("sec")
            'ViewState("smlseccodigo") = Int16.Parse(sec)
            ViewState("smlseccodigo") = sec
            cargacombo()
            cargagrilla()
        End If

    End Sub
#Region "FDU"
    Private Sub cargacombo()

        Dim oBE As CCOCARGOPERSONAL_BE = New CCOCARGOPERSONAL_BE
        Dim oBL As CCOCARGOPERSONAL_BL = New CCOCARGOPERSONAL_BL
        oBE.PropCRGCODIGO = 0
        oBE.PropCRGDESCRIPCION = String.Empty
        ddlCargoBusca.DataSource = oBL.Listar(oBE)
        ddlCargoBusca.DataTextField = "VCHCRGDESCRIPCION"
        ddlCargoBusca.DataValueField = "SMLCRGCODIGO"
        ddlCargoBusca.DataBind()
        ddlCargoBusca.Items.Insert(0, " (Todos) ")
        ddlCargoBusca.Items(0).Value = 0

        Dim oCCOPAQUETE_BL As CCOPAQUETE_BL = New CCOPAQUETE_BL
        Dim ds As DataSet = New DataSet
        ds = oCCOPAQUETE_BL.ListarTurnoSector()
        ddlSectorBusca.DataSource = ds.Tables(1)
        ddlSectorBusca.DataTextField = "DESCRIPCION"
        ddlSectorBusca.DataValueField = "CODIGO"
        ddlSectorBusca.DataBind()
        ddlSectorBusca.SelectedValue = ViewState("smlseccodigo")

    End Sub
    Private Sub cargagrilla()
        Dim oBE As CCOPERSONAL_BE = New CCOPERSONAL_BE
        Dim oBL As CCOPERSONAL_BL = New CCOPERSONAL_BL
        Dim _cod As Integer = 0
        If txtCodigoBusca.Text.Length > 0 Then
            If IsNumeric(txtCodigoBusca.Text) Then
                _cod = Integer.Parse(txtCodigoBusca.Text)
            End If
        End If
        With oBE
            .PropPERCODIGO = _cod
            .PropPERAPELLIDOPATERNO = txtPaternoBusca.Text.ToUpper
            .PropPERAPELLIDOMATERNO = txtMaternoBusca.Text.ToUpper
            .PropPERNOMBRE = txtNombreBusca.Text.ToUpper
            .PropCRGCODIGO = ddlCargoBusca.SelectedValue
            .PropPERESTADO = 1
            .Propturcodigo = 0
            .PropSECCODIGO = ddlSectorBusca.SelectedValue
        End With
        Dim dt As DataTable = New DataTable
        dt = oBL.Listar(oBE)
        gvPersonalBusca.DataSource = dt
        gvPersonalBusca.DataBind()

    End Sub
#End Region
    Protected Sub gvPersonalBusca_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvPersonalBusca.SelectedIndexChanged
        Dim _codigo As String = ""
        Dim _nombre As String = ""
        Dim _cargo As String = ""
        Dim _modalidad As String = ""

        Dim sb As New StringBuilder
        _codigo = Server.HtmlDecode(gvPersonalBusca.SelectedRow.Cells(1).Text.Trim)
        _nombre = Server.HtmlDecode(gvPersonalBusca.SelectedRow.Cells(2).Text.Trim)
        _cargo = Server.HtmlDecode(gvPersonalBusca.SelectedRow.Cells(3).Text.Trim)
        _modalidad = Server.HtmlDecode(gvPersonalBusca.SelectedRow.Cells(4).Text.Trim)
        sb.Append("<script>")
        sb.Append("window.opener.CargarDatosPopup('" + _codigo + "','" + _nombre + "','" + _cargo + "','" + _modalidad + "');")
        sb.Append("self.close();")
        sb.Append("</script>")
        ScriptManager.RegisterStartupScript(Me, Me.GetType, "CargarTrabajador", sb.ToString, False)
    End Sub

    Protected Sub btnRecursoBuscar_Click(sender As Object, e As System.EventArgs) Handles btnRecursoBuscar.Click
        cargagrilla()
    End Sub

End Class
