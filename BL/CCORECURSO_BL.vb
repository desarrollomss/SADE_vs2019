'--Imports IBM.Data.DB2
Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class CCORECURSO_BL
		Private oCCORECURSO_DL As New DAL.CCORECURSO_DL

        Public Function Insertar(ByVal pCCORECURSO_BE As CCORECURSO_BE) As Integer
            Try
                Return oCCORECURSO_DL.Insertar(pCCORECURSO_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

        Public Sub Actualizar(ByVal pCCORECURSO_BE As CCORECURSO_BE)
            Try
                oCCORECURSO_DL.Actualizar(pCCORECURSO_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCORECURSO_BE As CCORECURSO_BE)
            Try
                oCCORECURSO_DL.Eliminar(pCCORECURSO_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCORECURSO_BE As CCORECURSO_BE) As CCORECURSO_BE
            Try
                Return oCCORECURSO_DL.ListarKey(pCCORECURSO_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function
        Public Function Listar(ByVal pCCORECURSO_BE As CCORECURSO_BE) As DataTable
            Try
                Return oCCORECURSO_DL.Listar(pCCORECURSO_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function
        Public Function Listar(ByVal pCCORECURSO_BE As CCORECURSO_BE, ByVal pFecha As Date) As DataTable
            Try
                Return oCCORECURSO_DL.ListarDisponibles(pCCORECURSO_BE, pFecha)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

        Public Function ListarxTipo(ByVal pCCORECURSO_BE As CCORECURSO_BE) As DataTable
            Try
                Return oCCORECURSO_DL.ListarxTipo(pCCORECURSO_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

        Public Function Busqueda(ByVal pCCORECURSO_BE As CCORECURSO_BE) As DataTable
            Try
                Return oCCORECURSO_DL.Busqueda(pCCORECURSO_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

    End Class
End Namespace
