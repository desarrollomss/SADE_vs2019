Imports System
Imports System.IO
Imports System.Data
Imports CrystalDecisions.Shared

Imports SISSADE.BE
Imports SISSADE.BL


Partial Class frmEstadistica
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        If Session("DatosUsuarioActivo") Is Nothing Then
            Session.Clear()
            Session.Abandon()
            Response.Redirect(Request.ApplicationPath & "/frmLogin.aspx")
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim mp As MasterPage = Me.Master
            Dim tit As Label = CType(mp.FindControl("lblTitulo"), Label)
            tit.Text = ":: ESTADISTICAS ALERTA SURCO"
            txtDesde.Text = "01" & "/" + Date.Now.Month.ToString("00") & "/" & Date.Now.Year.ToString
            txtHasta.Text = Date.Now.ToString
            gvEstadistica.DataSource = Nothing
            gvEstadistica.DataBind()
        End If
    End Sub

    Protected Sub btnExportar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExportar.Click

        Dim dt As DataTable = New DataTable

        Try
            If rblTipoInformacion.SelectedValue = "AS" Then
                Dim oCCOINCIDENCIA_BE As CCOINCIDENCIA_BE = New CCOINCIDENCIA_BE
                Dim oCCOINCIDENCIA_BL As CCOINCIDENCIA_BL = New CCOINCIDENCIA_BL

                With oCCOINCIDENCIA_BE
                    .PropAUDFECCREACION = txtDesde.Text
                    .PropAUDFECMODIF = txtHasta.Text
                End With
                dt = oCCOINCIDENCIA_BL.Exportar(oCCOINCIDENCIA_BE)

                ExportarXLS(dt)

            Else
                Dim obe As GPSREGISTRO_BE = New GPSREGISTRO_BE
                Dim obl As GPSREGISTRO_BL = New GPSREGISTRO_BL

                With obe
                    .PropREGNUMERO = txtDesde.Text
                    .PropREGNOMBRE = txtHasta.Text
                End With
                If rblTipoReporte.SelectedValue = "D" Then
                    dt = obl.ListarDetalle(obe)
                Else
                    dt = obl.ListarResumen(obe)
                End If

                gvEstadistica.DataSource = dt
                gvEstadistica.DataBind()
                'If rblTipoReporte.SelectedValue = "D" Then
                '    GridViewExportUtil.ExportaUsuario("ReporteDetallado.xls", gvEstadistica)
                'Else
                GridViewExportUtil.Export("Estadistica.xls", gvEstadistica)
                'End If
            End If
        Catch ex As Exception
            lblMensaje.Text = "Desde:" & txtDesde.Text & "  Hasta:" & txtHasta.Text & " - " & ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try


    End Sub

    Protected Sub rblTipoInformacion_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles rblTipoInformacion.SelectedIndexChanged
        rblTipoReporte.SelectedIndex = 0
        rblTipoReporte.Enabled = (rblTipoInformacion.SelectedValue = "UR")
    End Sub

    Public Sub ExportarXLS(ByVal pDT As DataTable)

        Dim rpt As New BE.SYS_Reporte_BE

        rpt.ResourceName = "Reportes\RPT\rptExportSADE.rpt"
        rpt.SetDataSource(pDT)
        ' Exportando a PDF
        Dim s As System.IO.Stream = rpt.ExportToStream(ExportFormatType.ExcelRecord)
        Dim b(s.Length) As Byte
        s.Read(b, 0, CInt(s.Length))

        Response.Clear()
        Response.Buffer = True
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("Content-Disposition", "attachment;filename=ExportSADE.xls")
        Response.BinaryWrite(b)
        Response.End()

        rpt.Dispose()
        rpt.Close()



    End Sub



End Class
