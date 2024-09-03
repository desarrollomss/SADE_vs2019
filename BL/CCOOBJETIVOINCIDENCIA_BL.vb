'--Imports IBM.Data.DB2
Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class CCOOBJETIVOINCIDENCIA_BL
		Private oCCOOBJETIVOINCIDENCIA_DL As New DAL.CCOOBJETIVOINCIDENCIA_DL

		Public Sub Insertar(ByVal pCCOOBJETIVOINCIDENCIA_BE As CCOOBJETIVOINCIDENCIA_BE)
			Try
				oCCOOBJETIVOINCIDENCIA_DL.Insertar(pCCOOBJETIVOINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCOOBJETIVOINCIDENCIA_BE As CCOOBJETIVOINCIDENCIA_BE)
			Try
				oCCOOBJETIVOINCIDENCIA_DL.Actualizar(pCCOOBJETIVOINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCOOBJETIVOINCIDENCIA_BE As CCOOBJETIVOINCIDENCIA_BE)
			Try
				oCCOOBJETIVOINCIDENCIA_DL.Eliminar(pCCOOBJETIVOINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pCCOOBJETIVOINCIDENCIA_BE As CCOOBJETIVOINCIDENCIA_BE) As CCOOBJETIVOINCIDENCIA_BE
			Try
				Return oCCOOBJETIVOINCIDENCIA_DL.ListarKey(pCCOOBJETIVOINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function

        Public Function ListaCombo() As DataTable
            Try
                Return oCCOOBJETIVOINCIDENCIA_DL.ListarCombo()
            Catch ex As Exception
                Throw ex
            End Try
        End Function


	End Class
End Namespace
