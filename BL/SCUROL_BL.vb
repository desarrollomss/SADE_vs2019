Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class SCUROL_BL
		Private oSCUROL_DL As New DAL.SCUROL_DL

		Public Sub Insertar(ByVal pSCUROL_BE As SCUROL_BE)
			Try
				oSCUROL_DL.Insertar(pSCUROL_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Actualizar(ByVal pSCUROL_BE As SCUROL_BE)
			Try
				oSCUROL_DL.Actualizar(pSCUROL_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pSCUROL_BE As SCUROL_BE)
			Try
				oSCUROL_DL.Eliminar(pSCUROL_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pSCUROL_BE As SCUROL_BE) As SCUROL_BE
			Try
				Return oSCUROL_DL.ListarKey(pSCUROL_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function

        Public Function ListarCombo() As DataTable
            Try
                Return oSCUROL_DL.ListarCombo()
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

        Public Function ListarComboDeriva(ByVal pTIPO As Integer) As DataTable
            Try
                Return oSCUROL_DL.ListarComboDeriva(pTIPO)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

	End Class
End Namespace
