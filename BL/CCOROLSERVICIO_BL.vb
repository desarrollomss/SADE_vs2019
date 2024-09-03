Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

    Public Class CCOROLSERVICIO_BL
        Private oCCOROLSERVICIO_DL As New DAL.CCOROLSERVICIO_DL

        Public Sub Insertar(ByVal pCCOROLSERVICIO_BE As CCOROLSERVICIO_BE)
            Try
                oCCOROLSERVICIO_DL.Insertar(pCCOROLSERVICIO_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

        Public Sub Actualizar(ByVal pCCOROLSERVICIO_BE As CCOROLSERVICIO_BE)
            Try
                oCCOROLSERVICIO_DL.Actualizar(pCCOROLSERVICIO_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOROLSERVICIO_BE As CCOROLSERVICIO_BE)
            Try
                oCCOROLSERVICIO_DL.Eliminar(pCCOROLSERVICIO_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOROLSERVICIO_BE As CCOROLSERVICIO_BE) As CCOROLSERVICIO_BE
            Try
                Return oCCOROLSERVICIO_DL.ListarKey(pCCOROLSERVICIO_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

        Public Function Listar(ByVal pCCOROLSERVICIO_BE As CCOROLSERVICIO_BE) As DataTable
            Try
                Return oCCOROLSERVICIO_DL.Listar(pCCOROLSERVICIO_BE)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function ListarProgramacion(ByVal pCCOROLSERVICIO_BE As CCOROLSERVICIO_BE) As DataTable
            Try
                Return oCCOROLSERVICIO_DL.ListarProgramacion(pCCOROLSERVICIO_BE)
            Catch ex As Exception
                Throw ex
            End Try

        End Function

        Public Sub InsertarProgramacion(ByVal pCCOROLSERVICIO_BE As CCOROLSERVICIO_BE)
            Try
                oCCOROLSERVICIO_DL.InsertarProgramacion(pCCOROLSERVICIO_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub
    End Class
End Namespace
