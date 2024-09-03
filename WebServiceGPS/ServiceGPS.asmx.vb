Imports SISSADE.BL
Imports SISSADE.BE
Imports System.Collections.Generic
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://localhost/WebService", Name:="ServicioGPS", Description:="ServicioGPS")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
 Public Class ServiceGPS
    Inherits System.Web.Services.WebService
    Dim oGPSPOSITION_BL As New GPSPOSITION_BL
    <WebMethod()> _
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function


    <WebMethod()> _
    Public Function GetPosition() As List(Of GPSPOSITION_BE)
        Return oGPSPOSITION_BL.ListarGPS
    End Function

End Class