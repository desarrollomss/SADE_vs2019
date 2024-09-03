Imports Microsoft.VisualBasic
Imports System.Net.Mail
Imports System.Net
Imports System.Collections
Imports System.Net.Mime
Imports System.Net.Sockets
Imports System.Text


Public Class Correo

    Public Function enviarcorreo(ByVal dirdestino As String, ByVal asunto As String, ByVal pmsg As String, _
     ByVal msgerror As String, ByVal ArchivoImg As String, ByVal correoSaliente As String, ByVal mensajeSaliente As String, _
     ByVal contrasenaSaliente As String, ByVal host As String, ByVal puerto As String) As Boolean
        Dim exito As Boolean = False
        Try

            Dim correo As New System.Net.Mail.MailMessage
            correo.From = New System.Net.Mail.MailAddress(correoSaliente, mensajeSaliente)
            correo.To.Add(dirdestino)
            correo.To.Add(correoSaliente)
            correo.Subject = asunto.Trim
            correo.Body = pmsg
            correo.IsBodyHtml = True
            correo.Priority = System.Net.Mail.MailPriority.High

            Dim smtp As New System.Net.Mail.SmtpClient
            smtp.UseDefaultCredentials = True
            'smtp.Credentials = New NetworkCredential(correoSaliente.Trim, contrasenaSaliente.Trim)
            smtp.Host = host.Trim
            smtp.Port = puerto.Trim
            'smtp.EnableSsl = True
            smtp.Send(correo)
            exito = True

        Catch ex As SmtpException
            'msgerror = ex.Message.ToString()
            'exito = False
            Throw ex
            'Catch ex As Exception
            '    'msgerror = ex.Message.ToString()
            '    'exito = False
            '    Throw ex
        End Try
        Return exito
    End Function

    Public Function PuertoAbierto(ByVal Host As String, ByVal Port As Integer) As Boolean
        Dim m_sck As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        Try
            m_sck.Connect(Host, Port)
            Return True
        Catch ex As SocketException
            'Código para manejar error del socket (cerrado, conexión rechazada)
            'Catch ex As Exception
            '    'Código para manejar otra excepción
        End Try
        Return False
    End Function
    Public Function cNulo(ByVal objeto As Object) As String
        Dim mValor As String = ""
        If Not IsDBNull(objeto) Then
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
    Public Function nNulo(ByVal objeto As Object) As Integer
        Dim mValor As Integer = 0
        If (Not IsDBNull(objeto) And objeto.ToString.Length > 0) Then
            mValor = objeto
        End If
        Return mValor
    End Function
End Class
