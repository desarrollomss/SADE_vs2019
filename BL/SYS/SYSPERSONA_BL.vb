'--Imports IBM.Data.DB2
Imports System.Text
Imports System.Data
Imports System.Collections.Generic
Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

    Public Class SYSPERSONA_BL


        Public Function consultAutoNombre(ByVal P_NOMBRE As String) As List(Of SYSPERSONA_BE)
            Dim obj As New SYSPERSONA_DL
            Return obj.consultAutoNombre(P_NOMBRE)
        End Function


        Public Function consultAutoCodigo(ByVal P_CODIGO As Integer) As List(Of SYSPERSONA_BE)
            Dim obj As New SYSPERSONA_DL
            Return obj.consultAutoCodigo(P_CODIGO)
        End Function

    End Class
End Namespace
