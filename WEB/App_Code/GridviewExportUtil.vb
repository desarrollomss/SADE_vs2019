Imports System
Imports System.Data
Imports System.Configuration
Imports System.IO
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Text

Public Class GridViewExportUtil

    Public Shared Sub Export(ByVal fileName As String, ByVal gv As GridView)
        Try
            HttpContext.Current.Response.Clear()
            HttpContext.Current.Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", fileName))
            HttpContext.Current.Response.ContentType = "application/ms-excel"
            Dim sw As StringWriter = New StringWriter
            Dim htw As HtmlTextWriter = New HtmlTextWriter(sw)
            Dim strStyle As String = "<style> .text { mso-number-format:\@; } </style> "
            '  Create a form to contain the grid
            Dim table As Table = New Table
            table.Font.Size = 8
            table.BorderWidth = 1
            table.GridLines = gv.GridLines
            '  add the header row to the table
            If (Not (gv.HeaderRow) Is Nothing) Then
                GridViewExportUtil.PrepareControlForExport(gv.HeaderRow)
                For i As Integer = 0 To gv.HeaderRow.Cells.Count - 1
                    gv.HeaderRow.Cells(i).Style.Add("background-color", "#1E436E")
                    gv.HeaderRow.Cells(i).Style.Add("color", "#ffffff")
                    gv.HeaderRow.Cells(i).Style.Add("Height", "20px")
                    gv.HeaderRow.Cells(i).BorderColor = Color.FromName("#ffffff")
                Next
                table.Rows.Add(gv.HeaderRow)
            End If
            '  add each of the data rows to the table
            For Each row As GridViewRow In gv.Rows
                GridViewExportUtil.PrepareControlForExport(row)
                For i As Integer = 0 To gv.HeaderRow.Cells.Count - 1
                    row.Cells(i).Style.Add("background-color", "#EBEBEB")
                    row.Cells(i).Style.Add("color", "#000000")
                    row.Cells(i).Style.Add("Height", "20px")
                    row.Cells(i).BorderColor = Color.FromName("#000000")
                Next
                table.Rows.Add(row)
            Next
            '  add the footer row to the table
            If (Not (gv.FooterRow) Is Nothing) Then
                GridViewExportUtil.PrepareControlForExport(gv.FooterRow)
                table.Rows.Add(gv.FooterRow)
            End If
            '  render the table into the htmlwriter
            table.RenderControl(htw)
            'Dim pag As New Page

            '  render the htmlwriter into the response
            HttpContext.Current.Response.Write(strStyle)
            HttpContext.Current.Response.Write(sw.ToString())
            HttpContext.Current.Response.End()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Public Shared Sub ExportaUsuario(ByVal fileName As String, ByVal gv As GridView)
        Try
            HttpContext.Current.Response.Clear()
            HttpContext.Current.Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", fileName))
            HttpContext.Current.Response.ContentType = "application/ms-excel"
            Dim sw As StringWriter = New StringWriter
            Dim htw As HtmlTextWriter = New HtmlTextWriter(sw)
            Dim strStyle As String = "<style> .text { mso-number-format:\@; } </style> "

            '  Create a form to contain the grid
            Dim table As Table = New Table
            table.Font.Size = 10
            table.BorderWidth = 1
            table.GridLines = gv.GridLines
            '  add the header row to the table
            If (Not (gv.HeaderRow) Is Nothing) Then
                GridViewExportUtil.PrepareControlForExport(gv.HeaderRow)
                For i As Integer = 0 To gv.HeaderRow.Cells.Count - 1
                    gv.HeaderRow.Cells(i).Style.Add("background-color", "#1E436E")
                    gv.HeaderRow.Cells(i).Style.Add("color", "#ffffff")
                    gv.HeaderRow.Cells(i).Style.Add("Height", "50px")
                    gv.HeaderRow.Cells(i).BorderColor = Color.FromName("#ffffff")
                Next
                table.Rows.Add(gv.HeaderRow)
            End If
            '  add each of the data rows to the table
            For Each row As GridViewRow In gv.Rows
                GridViewExportUtil.PrepareControlForExport(row)
                For i As Integer = 0 To gv.HeaderRow.Cells.Count - 1
                    row.Cells(i).Style.Add("background-color", "#EBEBEB")
                    row.Cells(i).Style.Add("color", "#000000")
                    row.Cells(i).Style.Add("Height", "30px")
                    row.Cells(i).BorderColor = Color.FromName("#000000")
                    'If Object.ReferenceEquals(row.Cells(i).Text.GetType(), Type.GetType("System.String")) Then
                    '    row.Cells(i).Attributes.Add("class", "text")
                    'End If
                    If (i > 0 And i < 3) Then
                        row.Cells(i).Attributes.Add("class", "text")
                    End If

                Next
                table.Rows.Add(row)
            Next
            '  add the footer row to the table
            If (Not (gv.FooterRow) Is Nothing) Then
                GridViewExportUtil.PrepareControlForExport(gv.FooterRow)
                table.Rows.Add(gv.FooterRow)
            End If
            '  render the table into the htmlwriter
            table.RenderControl(htw)
            'Dim pag As New Page

            '  render the htmlwriter into the response
            HttpContext.Current.Response.Write(strStyle)
            HttpContext.Current.Response.Write(sw.ToString())
            HttpContext.Current.Response.End()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    ' Replace any of the contained controls with literals
    Private Shared Sub PrepareControlForExport(ByVal control As Control)
        Dim i As Integer = 0
        Do While (i < control.Controls.Count)
            Dim current As Control = control.Controls(i)
            If (TypeOf current Is LinkButton) Then
                control.Controls.Remove(current)
                control.Controls.AddAt(i, New LiteralControl(CType(current, LinkButton).Text))
            ElseIf (TypeOf current Is ImageButton) Then
                control.Controls.Remove(current)
                control.Controls.AddAt(i, New LiteralControl(CType(current, ImageButton).AlternateText))
            ElseIf (TypeOf current Is HyperLink) Then
                control.Controls.Remove(current)
                control.Controls.AddAt(i, New LiteralControl(CType(current, HyperLink).Text))
            ElseIf (TypeOf current Is TextBox) Then
                control.Controls.Remove(current)
                control.Controls.AddAt(i, New LiteralControl(CType(current, TextBox).Text))
            ElseIf (TypeOf current Is Label) Then
                control.Controls.Remove(current)
                control.Controls.AddAt(i, New LiteralControl(CType(current, Label).Text))
            ElseIf (TypeOf current Is DropDownList) Then
                control.Controls.Remove(current)
                control.Controls.AddAt(i, New LiteralControl(CType(current, DropDownList).SelectedItem.Text))
            ElseIf (TypeOf current Is CheckBox) Then
                control.Controls.Remove(current)
                control.Controls.AddAt(i, New LiteralControl(CType(current, CheckBox).Checked))
                'TODO: Warning!!!, inline IF is not supported ?
            End If
            If current.HasControls Then
                GridViewExportUtil.PrepareControlForExport(current)
            End If
            i = (i + 1)
        Loop
    End Sub
    Public Shared Sub Exportar(ByVal fileName As String, ByVal gv As GridView)
        Try
            Dim sb As StringBuilder = New StringBuilder()
            Dim sw As StringWriter = New StringWriter(sb)
            Dim htw As HtmlTextWriter = New HtmlTextWriter(sw)
            Dim pagina As Page = New Page
            Dim form = New HtmlForm
            gv.EnableViewState = False
            form.Controls.Add(gv)
            pagina.EnableEventValidation = False
            pagina.DesignerInitialize()
            pagina.Controls.Add(form)
            pagina.RenderControl(htw)
            HttpContext.Current.Response.Clear()
            HttpContext.Current.Response.Buffer = True
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel"
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" & fileName)
            HttpContext.Current.Response.Charset = "UTF-8"
            HttpContext.Current.Response.ContentEncoding = Encoding.Default
            HttpContext.Current.Response.Write(sb.ToString())
            HttpContext.Current.Response.End()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
End Class

