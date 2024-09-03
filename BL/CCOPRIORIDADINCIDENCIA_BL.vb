'--Imports IBM.Data.DB2
Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class CCOPRIORIDADINCIDENCIA_BL
		Private oCCOPRIORIDADINCIDENCIA_DL As New DAL.CCOPRIORIDADINCIDENCIA_DL

		Public Sub Insertar(ByVal pCCOPRIORIDADINCIDENCIA_BE As CCOPRIORIDADINCIDENCIA_BE)
			Try
				oCCOPRIORIDADINCIDENCIA_DL.Insertar(pCCOPRIORIDADINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCOPRIORIDADINCIDENCIA_BE As CCOPRIORIDADINCIDENCIA_BE)
			Try
				oCCOPRIORIDADINCIDENCIA_DL.Actualizar(pCCOPRIORIDADINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCOPRIORIDADINCIDENCIA_BE As CCOPRIORIDADINCIDENCIA_BE)
			Try
				oCCOPRIORIDADINCIDENCIA_DL.Eliminar(pCCOPRIORIDADINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pCCOPRIORIDADINCIDENCIA_BE As CCOPRIORIDADINCIDENCIA_BE) As CCOPRIORIDADINCIDENCIA_BE
			Try
				Return oCCOPRIORIDADINCIDENCIA_DL.ListarKey(pCCOPRIORIDADINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function


        Public Function ListarCombo() As List(Of CCOPRIORIDADINCIDENCIA_BE)
            Try
                Return oCCOPRIORIDADINCIDENCIA_DL.ListarCombo()
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

	End Class
End Namespace
