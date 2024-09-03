'--Imports IBM.Data.DB2
Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class CCOTIPOINCIDENCIA_BL
		Private oCCOTIPOINCIDENCIA_DL As New DAL.CCOTIPOINCIDENCIA_DL

		Public Sub Insertar(ByVal pCCOTIPOINCIDENCIA_BE As CCOTIPOINCIDENCIA_BE)
			Try
				oCCOTIPOINCIDENCIA_DL.Insertar(pCCOTIPOINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCOTIPOINCIDENCIA_BE As CCOTIPOINCIDENCIA_BE)
			Try
				oCCOTIPOINCIDENCIA_DL.Actualizar(pCCOTIPOINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCOTIPOINCIDENCIA_BE As CCOTIPOINCIDENCIA_BE)
			Try
				oCCOTIPOINCIDENCIA_DL.Eliminar(pCCOTIPOINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pCCOTIPOINCIDENCIA_BE As CCOTIPOINCIDENCIA_BE) As CCOTIPOINCIDENCIA_BE
			Try
				Return oCCOTIPOINCIDENCIA_DL.ListarKey(pCCOTIPOINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function

        Public Function ListarCombo() As List(Of CCOTIPOINCIDENCIA_BE)
            Try
                Return oCCOTIPOINCIDENCIA_DL.ListarCombo()
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

        Public Function Busqueda(ByVal pCCOTIPOINCIDENCIA_BE As CCOTIPOINCIDENCIA_BE) As DataTable
            Try
                Return oCCOTIPOINCIDENCIA_DL.Busqueda(pCCOTIPOINCIDENCIA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function


	End Class
End Namespace
