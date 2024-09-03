'--Imports IBM.Data.DB2
Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class CCOMENSAJEROLUSUARIO_BL
		Private oCCOMENSAJEROLUSUARIO_DL As New DAL.CCOMENSAJEROLUSUARIO_DL

		Public Sub Insertar(ByVal pCCOMENSAJEROLUSUARIO_BE As CCOMENSAJEROLUSUARIO_BE)
			Try
				oCCOMENSAJEROLUSUARIO_DL.Insertar(pCCOMENSAJEROLUSUARIO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCOMENSAJEROLUSUARIO_BE As CCOMENSAJEROLUSUARIO_BE)
			Try
				oCCOMENSAJEROLUSUARIO_DL.Actualizar(pCCOMENSAJEROLUSUARIO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCOMENSAJEROLUSUARIO_BE As CCOMENSAJEROLUSUARIO_BE)
			Try
				oCCOMENSAJEROLUSUARIO_DL.Eliminar(pCCOMENSAJEROLUSUARIO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pCCOMENSAJEROLUSUARIO_BE As CCOMENSAJEROLUSUARIO_BE) As CCOMENSAJEROLUSUARIO_BE
			Try
				Return oCCOMENSAJEROLUSUARIO_DL.ListarKey(pCCOMENSAJEROLUSUARIO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function


	End Class
End Namespace
