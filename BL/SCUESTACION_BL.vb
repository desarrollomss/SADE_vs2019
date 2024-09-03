Imports SISSADE.DAL
Imports SISSADE.BE


Namespace BL

    Public Class SCUESTACION_BL
        Private oSCUESTACION_DL As New DAL.SCUESTACION_DL

        Public Sub Insertar(ByVal pSCUESTACION_BE As SCUESTACION_BE)
            Try
                oSCUESTACION_DL.Insertar(pSCUESTACION_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

        Public Sub Actualizar(ByVal pSCUESTACION_BE As SCUESTACION_BE)
            Try
                oSCUESTACION_DL.Actualizar(pSCUESTACION_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

        Public Sub Eliminar(ByVal pSCUESTACION_BE As SCUESTACION_BE)
            Try
                oSCUESTACION_DL.Eliminar(pSCUESTACION_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

        Public Function ListarKey(ByVal pSCUESTACION_BE As SCUESTACION_BE) As SCUESTACION_BE
            Try
                Return oSCUESTACION_DL.ListarKey(pSCUESTACION_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

        Public Function ValidarLogon(ByVal pSCUESTACION_BE As SCUESTACION_BE) As SCUESTACION_BE
            Try
                Return oSCUESTACION_DL.ValidarLogon(pSCUESTACION_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

        Public Function Busqueda(ByVal pSCUESTACION_BE As SCUESTACION_BE) As DataTable
            Try
                Return oSCUESTACION_DL.Busqueda(pSCUESTACION_BE)
            Catch ex As Exception
                Throw ex
            End Try
        End Function



    End Class
End Namespace
