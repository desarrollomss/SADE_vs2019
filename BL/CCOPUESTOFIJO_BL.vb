'--Imports IBM.Data.DB2
Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class CCOPUESTOFIJO_BL
		Private oCCOPUESTOFIJO_DL As New DAL.CCOPUESTOFIJO_DL

		Public Sub Insertar(ByVal pCCOPUESTOFIJO_BE As CCOPUESTOFIJO_BE)
			Try
				oCCOPUESTOFIJO_DL.Insertar(pCCOPUESTOFIJO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCOPUESTOFIJO_BE As CCOPUESTOFIJO_BE)
			Try
				oCCOPUESTOFIJO_DL.Actualizar(pCCOPUESTOFIJO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCOPUESTOFIJO_BE As CCOPUESTOFIJO_BE)
			Try
				oCCOPUESTOFIJO_DL.Eliminar(pCCOPUESTOFIJO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pCCOPUESTOFIJO_BE As CCOPUESTOFIJO_BE) As CCOPUESTOFIJO_BE
			Try
				Return oCCOPUESTOFIJO_DL.ListarKey(pCCOPUESTOFIJO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function


	End Class
End Namespace
