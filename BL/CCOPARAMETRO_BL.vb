Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class CCOPARAMETRO_BL
		Private oCCOPARAMETRO_DL As New DAL.CCOPARAMETRO_DL

		Public Sub Insertar(ByVal pCCOPARAMETRO_BE As CCOPARAMETRO_BE)
			Try
				oCCOPARAMETRO_DL.Insertar(pCCOPARAMETRO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCOPARAMETRO_BE As CCOPARAMETRO_BE)
			Try
				oCCOPARAMETRO_DL.Actualizar(pCCOPARAMETRO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCOPARAMETRO_BE As CCOPARAMETRO_BE)
			Try
				oCCOPARAMETRO_DL.Eliminar(pCCOPARAMETRO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pCCOPARAMETRO_BE As CCOPARAMETRO_BE) As CCOPARAMETRO_BE
			Try
				Return oCCOPARAMETRO_DL.ListarKey(pCCOPARAMETRO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function


	End Class
End Namespace
