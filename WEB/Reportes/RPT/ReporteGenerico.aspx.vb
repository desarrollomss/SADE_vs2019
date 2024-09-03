Imports System
Imports System.IO
Imports System.Data
Imports CrystalDecisions.Shared
Imports SISSADE.BE
Imports SISSADE.BL

Partial Class Reportes_rpt_ReporteGenerico
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim vReporte As String = Request.QueryString("pReporte")
            Me.Page.Title = "Reporte"
            Select Case vReporte
                Case "ReporteFormatoSADE"
                    ReporteFormatoSADE()
            End Select
        Else
            Response.Write("<B> no pasa nada</B>")
        End If
    End Sub


    Public Sub ReporteFormatoSADE()
        Dim IncCodigo As Integer = Request.QueryString("pINCCODIGO")
        Dim rpt As New BE.SYS_Reporte_BE
        Dim oCCOINCIDENCIA_BE As New CCOINCIDENCIA_BE
        Dim oCCOINCIDENCIA_BL As New CCOINCIDENCIA_BL
        Dim oCCOINCIDENCIARECURSO_BL As New CCOINCIDENCIARECURSO_BL
        Dim oCCOINCIDENCIAHISTORIAL_BL As New CCOINCIDENCIAHISTORIAL_BL
        Dim oCCOINCIDENCIAHISTORIAL_BE As New CCOINCIDENCIAHISTORIAL_BE
        Dim oCCOINCIDENCIAINTERACCION_BL As New CCOINCIDENCIAINTERACCION_BL



        oCCOINCIDENCIA_BE.PropINCCODIGO = IncCodigo
        oCCOINCIDENCIAHISTORIAL_BE.PropINCCODIGO = IncCodigo

        Dim Odt As New DataTable
        Odt = oCCOINCIDENCIA_BL.ReporteFormatoSADE(oCCOINCIDENCIA_BE)
        Dim OdtREC As New DataTable
        OdtREC = oCCOINCIDENCIARECURSO_BL.Listar(oCCOINCIDENCIA_BE.PropINCCODIGO)

        Dim OdtINT As New DataTable
        OdtINT = oCCOINCIDENCIAINTERACCION_BL.Listar(oCCOINCIDENCIA_BE.PropINCCODIGO)

        Dim OdtHIS As New DataTable
        OdtHIS = oCCOINCIDENCIAHISTORIAL_BL.Listar(oCCOINCIDENCIAHISTORIAL_BE)

        rpt.ResourceName = "rptFormatoSADE.rpt"
        rpt.SetDataSource(Odt)
        rpt.Subreports.Item("rptFormatoSADEREC.rpt").SetDataSource(OdtREC)
        rpt.Subreports.Item("rptFormatoSADEINT.rpt").SetDataSource(OdtINT)
        rpt.Subreports.Item("rptFormatoSADEHIS.rpt").SetDataSource(OdtHIS)
        ' Exportando a PDF
        'Dim oStream As MemoryStream
        'oStream = DirectCast(rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat), MemoryStream)
        'Response.Clear()
        'Response.Buffer = True
        'Response.ContentType = "application/pdf"
        'Response.BinaryWrite(oStream.ToArray())
        'Response.End()


        Dim strExportFile As String = "ReporteSADE.pdf"
        Dim s As System.IO.Stream = rpt.ExportToStream(ExportFormatType.PortableDocFormat)
        Dim b(s.Length) As Byte
        s.Read(b, 0, CInt(s.Length))

        With HttpContext.Current.Response
            .ClearContent()
            .ClearHeaders()
            .ContentType = "application/pdf"
            .AddHeader("Content-Disposition", "inline; filename=" & strExportFile)
            .BinaryWrite(b)
            .Flush()
            .SuppressContent = True
            HttpContext.Current.ApplicationInstance.CompleteRequest()
        End With


        rpt.Dispose()
        rpt.Close()
    End Sub



End Class
