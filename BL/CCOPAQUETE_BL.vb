Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class CCOPAQUETE_BL
        Private oCCOPAQUETE_DL As New CCOPAQUETE_DL

        Public Function Insertar(ByVal pCCOPAQUETE_BE As CCOPAQUETE_BE) As Integer
            Try
                Return oCCOPAQUETE_DL.Insertar(pCCOPAQUETE_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

        Public Sub Actualizar(ByVal pCCOPAQUETE_BE As CCOPAQUETE_BE)
            Try
                oCCOPAQUETE_DL.Actualizar(pCCOPAQUETE_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOPAQUETE_BE As CCOPAQUETE_BE)
            Try
                oCCOPAQUETE_DL.Eliminar(pCCOPAQUETE_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub
        Public Sub EliminarTodo(ByVal pCCOPAQUETE_BE As CCOPAQUETE_BE)
            Try
                oCCOPAQUETE_DL.EliminarTodo(pCCOPAQUETE_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub
        Public Function ListarKey(ByVal pCCOPAQUETE_BE As CCOPAQUETE_BE) As CCOPAQUETE_BE
            Try
                Return oCCOPAQUETE_DL.ListarKey(pCCOPAQUETE_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function
        Public Function Listar(ByVal pCCOPAQUETE_BE As CCOPAQUETE_BE) As DataTable
            Try
                Return oCCOPAQUETE_DL.Listar(pCCOPAQUETE_BE)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function ListarTurnoSector() As DataSet
            Try
                Return oCCOPAQUETE_DL.ListarTurnoSector()
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function ListarRecursosDisponibles(ByVal pCCOPAQUETE_BE As CCOPAQUETE_BE) As DataTable
            Try
                Return oCCOPAQUETE_DL.ListarRecursosDisponibles(pCCOPAQUETE_BE)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function ListaCombo(ByVal pCCOPAQUETE_BE As CCOPAQUETE_BE) As DataSet
            Try
                Return oCCOPAQUETE_DL.ListaCombo(pCCOPAQUETE_BE)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function ListarPlantilla(ByVal pCCOPAQUETE_BE As CCOPAQUETE_BE) As DataTable
            Try
                Return oCCOPAQUETE_DL.ListarPlantilla(pCCOPAQUETE_BE)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function ListaTablaTemporal(ByVal pCCOPAQUETE_BE As CCOPAQUETE_BE) As DataSet
            Try
                Return oCCOPAQUETE_DL.ListaTablaTemporal(pCCOPAQUETE_BE)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        Public Function VerificaIncidencia(ByVal pPAQCODIGO As Integer) As Int16
            Try
                Return oCCOPAQUETE_DL.VerificaIncidencia(pPAQCODIGO)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class
End Namespace
