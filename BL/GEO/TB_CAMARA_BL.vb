
Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

    Public Class TB_CAMARA_BL

        Private oTB_CAMARA_DL As New DAL.TB_CAMARA_DL

        Public Function Insertar(ByVal pTB_CAMARA_BE As TB_CAMARA_BE) As Integer
            Try
                Return oTB_CAMARA_DL.Insertar(pTB_CAMARA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

        Public Sub Actualizar(ByVal pTB_CAMARA_BE As TB_CAMARA_BE)
            Try
                oTB_CAMARA_DL.Actualizar(pTB_CAMARA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

        Public Sub Eliminar(ByVal pTB_CAMARA_BE As TB_CAMARA_BE)
            Try
                oTB_CAMARA_DL.Eliminar(pTB_CAMARA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub
        Public Function Busqueda(ByVal pTB_CAMARA_BE As TB_CAMARA_BE) As DataTable
            Try
                Return oTB_CAMARA_DL.Busqueda(pTB_CAMARA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

        Public Function ListarComboMarca() As DataTable
            Try
                Return oTB_CAMARA_DL.ListarComboMarca()
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function
        Public Function ListarComboEstado() As DataTable
            Try
                Return oTB_CAMARA_DL.ListarComboEstado()
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function


        Public Function ListarComboCOVV() As DataTable
            Try
                Return oTB_CAMARA_DL.ListarComboCOVV()
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

    End Class
End Namespace
