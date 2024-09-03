'--Imports IBM.Data.DB2
Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class CCOINCIDENCIAREPLICA_BL
		Private oCCOINCIDENCIAREPLICA_DL As New DAL.CCOINCIDENCIAREPLICA_DL

		Public Sub Insertar(ByVal pCCOINCIDENCIAREPLICA_BE As CCOINCIDENCIAREPLICA_BE)
			Try
				oCCOINCIDENCIAREPLICA_DL.Insertar(pCCOINCIDENCIAREPLICA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCOINCIDENCIAREPLICA_BE As CCOINCIDENCIAREPLICA_BE)
			Try
				oCCOINCIDENCIAREPLICA_DL.Actualizar(pCCOINCIDENCIAREPLICA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCOINCIDENCIAREPLICA_BE As CCOINCIDENCIAREPLICA_BE)
			Try
				oCCOINCIDENCIAREPLICA_DL.Eliminar(pCCOINCIDENCIAREPLICA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pCCOINCIDENCIAREPLICA_BE As CCOINCIDENCIAREPLICA_BE) As CCOINCIDENCIAREPLICA_BE
			Try
				Return oCCOINCIDENCIAREPLICA_DL.ListarKey(pCCOINCIDENCIAREPLICA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function


	End Class
End Namespace
