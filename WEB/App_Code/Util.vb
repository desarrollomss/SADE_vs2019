Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Text
Imports System.Collections.Specialized



Public Class Util
    Public Enum Cabecera
        Seleccione = 0
        Todos = 1
        Ninguno = 2
    End Enum
    Public Shared Sub MSG_ALERTA(ByVal P_strMensaje As String, ByVal page As Page)
        Dim sb As New StringBuilder
        sb.Append("<script>")
        sb.Append("alert('" + P_strMensaje + "');")
        sb.Append("</script>")
        ScriptManager.RegisterStartupScript(page, page.GetType, "PopupAlert", sb.ToString, False)
    End Sub

    Public Shared Function StringAByteArray(ByVal str As String) As Byte()
        Dim encoding As New System.Text.UTF8Encoding()
        Return encoding.GetBytes(str)
    End Function

    Public Shared Function ByteArrayAString(ByVal byteArray As Byte()) As String
        Dim enc As New System.Text.UTF8Encoding()
        Return enc.GetString(byteArray)
    End Function

    Public Shared Sub LlenarComboBox(ByRef ddl As DropDownList, ByVal dt As DataTable, ByVal Valor As String, ByVal Texto As String)
        ddl.DataSource = dt
        ddl.DataValueField = Valor
        ddl.DataTextField = Texto
        ddl.DataBind()
    End Sub

    Public Shared Sub LlenarComboBox(ByRef ddl As DropDownList, ByVal dt As DataTable, ByVal Valor As String, ByVal Texto As String, ByVal Titulo As Cabecera)
        ddl.DataSource = dt
        ddl.DataValueField = Valor
        ddl.DataTextField = Texto
        ddl.DataBind()
        If Titulo = Cabecera.Seleccione Then
            ddl.Items.Insert(0, New ListItem("-- Seleccione --"))
            ddl.Items(0).Value = "0"
        ElseIf Titulo = Cabecera.Todos Then
            ddl.Items.Insert(0, New ListItem("-- Todos --"))
            ddl.Items(0).Value = "0"
        ElseIf Titulo = Cabecera.Ninguno Then
            ddl.Items.Insert(0, New ListItem("-- Ninguno --"))
            ddl.Items(0).Value = "0"
        End If
    End Sub
    Public Function cNulo(ByVal objeto As Object) As String
        Dim mValor As String = ""
        If Not IsDBNull(objeto) Then
            mValor = objeto
        End If
        Return mValor
    End Function
    Public Function nNulo(ByVal objeto As Object) As Integer
        Dim mValor As Integer = 0
        If (Not IsDBNull(objeto) And objeto.ToString.Length > 0) Then
            mValor = objeto
        End If
        Return mValor
    End Function
    Public Function dNulo(ByVal objeto As Object) As Decimal
        Dim mValor As Decimal = 0.0
        If (Not IsDBNull(objeto) And objeto.ToString.Length > 0) Then
            mValor = objeto
        End If
        Return mValor
    End Function
    Public Function Nulo(ByVal objeto As Object) As String 

        If (Not IsDBNull(objeto) And objeto.ToString.Length > 0) Then
            Return objeto
        Else
            Return Nothing
        End If

    End Function
    Public Sub BajarArchivo(ByVal tipoArchivo As String, ByVal archivoCliente As String, ByVal archivoServidor As String)
        With HttpContext.Current.Response
            .ContentType = "Application/" & tipoArchivo & "; charset=utf-8;"
            .AppendHeader("content-disposition", "attachment; filename=" & archivoCliente)
            .TransmitFile(archivoServidor)
            .Flush()
            .Close()
        End With
    End Sub

    Public Sub LimpiarCache()
        With HttpContext.Current.Response.Cache
            .SetCacheability(HttpCacheability.NoCache)
            .SetNoStore()
            .SetExpires(DateTime.Now().Subtract(New TimeSpan(1, 0, 0)))
            .SetLastModified(DateTime.Now)
            .SetAllowResponseInBrowserHistory(False)
        End With
    End Sub

End Class

