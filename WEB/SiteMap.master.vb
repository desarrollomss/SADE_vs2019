
Partial Class SiteMap
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            ' CargarMenu()
        End If
    End Sub
    Public Sub CargarMenu()

        Dim sb As New StringBuilder
        sb.AppendLine("<h3>Incidencia</h3>")
        sb.AppendLine("	<div>")
        sb.AppendLine("		<p>")
        sb.AppendLine("         <ul class =""ul"">                        ")
        sb.AppendLine("                <li><a href=""#"">Registro de incidencia</a></li>")
        sb.AppendLine("                <li><a href=""#"">Asignación de recursos</a></li>")
        sb.AppendLine("          </ul>		")
        sb.AppendLine("		</p>")
        sb.AppendLine("	</div>")
        sb.AppendLine("	<h3>Recursos</h3>")
        sb.AppendLine("	<div>")
        sb.AppendLine("		<p>")
        sb.AppendLine("              <ul class =""ul"">                        		")
        sb.AppendLine("                <li><a href=""frmBuscaPaqueteRecurso.aspx"">Distribución de paquete de recursos</a></li>")
        sb.AppendLine("              </ul>                ")
        sb.AppendLine("		</p>")
        sb.AppendLine("	</div>")
        'ltrMenu.Text = sb.ToString
    End Sub

End Class

