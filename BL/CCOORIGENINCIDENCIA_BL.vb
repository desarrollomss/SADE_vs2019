'--Imports IBM.Data.DB2
Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class CCOORIGENINCIDENCIA_BL
		Private oCCOORIGENINCIDENCIA_DL As New DAL.CCOORIGENINCIDENCIA_DL

		Public Sub Insertar(ByVal pCCOORIGENINCIDENCIA_BE As CCOORIGENINCIDENCIA_BE)
			Try
				oCCOORIGENINCIDENCIA_DL.Insertar(pCCOORIGENINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCOORIGENINCIDENCIA_BE As CCOORIGENINCIDENCIA_BE)
			Try
				oCCOORIGENINCIDENCIA_DL.Actualizar(pCCOORIGENINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCOORIGENINCIDENCIA_BE As CCOORIGENINCIDENCIA_BE)
			Try
				oCCOORIGENINCIDENCIA_DL.Eliminar(pCCOORIGENINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pCCOORIGENINCIDENCIA_BE As CCOORIGENINCIDENCIA_BE) As CCOORIGENINCIDENCIA_BE
			Try
				Return oCCOORIGENINCIDENCIA_DL.ListarKey(pCCOORIGENINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function


        Public Function ListarCombo() As List(Of CCOORIGENINCIDENCIA_BE)
            Try
                Return oCCOORIGENINCIDENCIA_DL.ListarCombo()
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

	End Class
End Namespace
