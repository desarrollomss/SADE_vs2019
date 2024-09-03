'--Imports IBM.Data.DB2
Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class CCOMENSAJE_BL
		Private oCCOMENSAJE_DL As New DAL.CCOMENSAJE_DL

		Public Sub Insertar(ByVal pCCOMENSAJE_BE As CCOMENSAJE_BE)
			Try
				oCCOMENSAJE_DL.Insertar(pCCOMENSAJE_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCOMENSAJE_BE As CCOMENSAJE_BE)
			Try
				oCCOMENSAJE_DL.Actualizar(pCCOMENSAJE_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCOMENSAJE_BE As CCOMENSAJE_BE)
			Try
				oCCOMENSAJE_DL.Eliminar(pCCOMENSAJE_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pCCOMENSAJE_BE As CCOMENSAJE_BE) As CCOMENSAJE_BE
			Try
				Return oCCOMENSAJE_DL.ListarKey(pCCOMENSAJE_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function


	End Class
End Namespace
