'--Imports IBM.Data.DB2
Imports System.Text
Imports System.Data
Imports System.Collections.Generic
Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

    Public Class SYSDNI_BL


        Public Function dniBusqueda(ByVal P_NUMERO As String) As List(Of SYSDNI_BE)
            Dim obj As New SYSDNI_DL
            Return obj.dniBusqueda(P_NUMERO)
        End Function


    End Class
End Namespace
