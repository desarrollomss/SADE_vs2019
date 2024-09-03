Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class CCOTABLA_BL
		Private oCCOTABLA_DL As New DAL.CCOTABLA_DL

		Public Sub Insertar(ByVal pCCOTABLA_BE As CCOTABLA_BE)
			Try
				oCCOTABLA_DL.Insertar(pCCOTABLA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCOTABLA_BE As CCOTABLA_BE)
			Try
				oCCOTABLA_DL.Actualizar(pCCOTABLA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCOTABLA_BE As CCOTABLA_BE)
			Try
				oCCOTABLA_DL.Eliminar(pCCOTABLA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pCCOTABLA_BE As CCOTABLA_BE) As CCOTABLA_BE
			Try
				Return oCCOTABLA_DL.ListarKey(pCCOTABLA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function

        Public Function Listar(ByVal pCCOTABLA_BE As CCOTABLA_BE) As DataTable
            Try
                Return oCCOTABLA_DL.Listar(pCCOTABLA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try

        End Function
    End Class
End Namespace
