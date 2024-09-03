Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

    Public Class GPSTETRA_BL
        Private oGPSTETRA_DL As New DAL.GPSTETRA_DL

        Public Function ListarKey(ByVal pGPSTETRA_BE As GPSTETRA_BE) As GPSTETRA_BE
            Try
                Return oGPSTETRA_DL.ListarKey(pGPSTETRA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

        Public Function Listar(ByVal pGPSTETRA_BE As GPSTETRA_BE) As DataTable
            Try
                Return oGPSTETRA_DL.Listar(pGPSTETRA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

        Public Sub Insertar(ByVal pGPSTETRA_BE As GPSTETRA_BE, ByRef MSG As String)
            Try
                oGPSTETRA_DL.Insertar(pGPSTETRA_BE, MSG)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

        Public Sub Actualizar(ByVal pGPSTETRA_BE As GPSTETRA_BE)
            Try
                oGPSTETRA_DL.Actualizar(pGPSTETRA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

        Public Sub Eliminar(ByVal pGPSTETRA_BE As GPSTETRA_BE)
            Try
                oGPSTETRA_DL.Eliminar(pGPSTETRA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

    End Class

End Namespace