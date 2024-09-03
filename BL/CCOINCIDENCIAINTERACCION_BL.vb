Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

    Public Class CCOINCIDENCIAINTERACCION_BL
        Private oCCOINCIDENCIAINTERACCION_DL As New DAL.CCOINCIDENCIAINTERACCION_DL

        Public Sub Insertar(ByVal pCCOINCIDENCIAINTERACCION_BE As CCOINCIDENCIAINTERACCION_BE)
            Try
                oCCOINCIDENCIAINTERACCION_DL.Insertar(pCCOINCIDENCIAINTERACCION_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

        Public Function Listar(ByVal pINTINCCODIGO As Integer) As DataTable
            Try
                Return oCCOINCIDENCIAINTERACCION_DL.Listar(pINTINCCODIGO)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

    End Class
End Namespace
