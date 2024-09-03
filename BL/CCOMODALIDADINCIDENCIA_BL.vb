'--Imports IBM.Data.DB2
Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

    Public Class CCOMODALIDADINCIDENCIA_BL
        Private oCCOMODALIDADINCIDENCIA_DL As New DAL.CCOMODALIDADINCIDENCIA_DL


        Public Function ListaCombo() As DataTable
            Try
                Return oCCOMODALIDADINCIDENCIA_DL.ListarCombo()
            Catch ex As Exception
                Throw ex
            End Try
        End Function


    End Class
End Namespace
