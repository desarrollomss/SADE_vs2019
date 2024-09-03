'--Imports IBM.Data.DB2
Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

    Public Class CCOCARGOPERSONAL_BL
        Private oCCOCARGO_DL As New DAL.CCOCARGOPERSONAL_DL

        Public Sub Insertar(ByVal pCCOCARGO_BE As CCOCARGOPERSONAL_BE)
            Try
                oCCOCARGO_DL.Insertar(pCCOCARGO_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

        Public Sub Actualizar(ByVal pCCOCARGO_BE As CCOCARGOPERSONAL_BE)
            Try
                oCCOCARGO_DL.Actualizar(pCCOCARGO_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOCARGO_BE As CCOCARGOPERSONAL_BE)
            Try
                oCCOCARGO_DL.Eliminar(pCCOCARGO_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOCARGO_BE As CCOCARGOPERSONAL_BE) As CCOCARGOPERSONAL_BE
            Try
                Return oCCOCARGO_DL.ListarKey(pCCOCARGO_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function
        Public Function Listar(ByVal pCCOCARGOPERSONAL_BE As CCOCARGOPERSONAL_BE) As DataTable
            Try
                Return oCCOCARGO_DL.Listar(pCCOCARGOPERSONAL_BE)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

    End Class
End Namespace
