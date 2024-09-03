'--Imports IBM.Data.DB2
Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class CCOCLASEINCIDENCIA_BL
		Private oCCOCLASEINCIDENCIA_DL As New DAL.CCOCLASEINCIDENCIA_DL

		Public Sub Insertar(ByVal pCCOCLASEINCIDENCIA_BE As CCOCLASEINCIDENCIA_BE)
			Try
				oCCOCLASEINCIDENCIA_DL.Insertar(pCCOCLASEINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCOCLASEINCIDENCIA_BE As CCOCLASEINCIDENCIA_BE)
			Try
				oCCOCLASEINCIDENCIA_DL.Actualizar(pCCOCLASEINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCOCLASEINCIDENCIA_BE As CCOCLASEINCIDENCIA_BE)
			Try
				oCCOCLASEINCIDENCIA_DL.Eliminar(pCCOCLASEINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pCCOCLASEINCIDENCIA_BE As CCOCLASEINCIDENCIA_BE) As CCOCLASEINCIDENCIA_BE
			Try
				Return oCCOCLASEINCIDENCIA_DL.ListarKey(pCCOCLASEINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function

        Public Function ListarCombo() As DataTable
            Try
                Return oCCOCLASEINCIDENCIA_DL.ListarCombo()
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

	End Class
End Namespace
