'--Imports IBM.Data.DB2
Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class CCOPERSONAL_BL
		Private oCCOPERSONAL_DL As New DAL.CCOPERSONAL_DL

        Public Function Insertar(ByVal pCCOPERSONAL_BE As CCOPERSONAL_BE) As Integer
            Try
                Return oCCOPERSONAL_DL.Insertar(pCCOPERSONAL_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

        Public Sub Actualizar(ByVal pCCOPERSONAL_BE As CCOPERSONAL_BE)
            Try
                oCCOPERSONAL_DL.Actualizar(pCCOPERSONAL_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOPERSONAL_BE As CCOPERSONAL_BE)
            Try
                oCCOPERSONAL_DL.Eliminar(pCCOPERSONAL_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOPERSONAL_BE As CCOPERSONAL_BE) As CCOPERSONAL_BE
            Try
                Return oCCOPERSONAL_DL.ListarKey(pCCOPERSONAL_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function
        Public Function Listar(ByVal pCCOPERSONAL_BE As CCOPERSONAL_BE) As DataTable
            Try
                Return oCCOPERSONAL_DL.Listar(pCCOPERSONAL_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function
        Public Function RolListar(ByVal pCCOPERSONAL_BE As CCOPERSONAL_BE) As DataTable
            Try
                Return oCCOPERSONAL_DL.RolListar(pCCOPERSONAL_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function
        Public Function ListarNombres(ByVal pCCOPERSONAL_BE As CCOPERSONAL_BE) As DataTable
            Try
                Return oCCOPERSONAL_DL.ListarNombres(pCCOPERSONAL_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function
        Public Function ListarBusqueda(ByVal pCCOPERSONAL_BE As CCOPERSONAL_BE) As DataTable
            Try
                Return oCCOPERSONAL_DL.ListarBusqueda(pCCOPERSONAL_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function
        Public Function ListarCombo() As DataSet
            Try
                Return oCCOPERSONAL_DL.ListarCombo()
            Catch ex As Exception
                Throw ex
            End Try
        End Function

    End Class
End Namespace
