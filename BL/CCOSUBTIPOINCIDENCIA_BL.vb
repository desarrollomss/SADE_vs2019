'--Imports IBM.Data.DB2
Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class CCOSUBTIPOINCIDENCIA_BL
		Private oCCOSUBTIPOINCIDENCIA_DL As New DAL.CCOSUBTIPOINCIDENCIA_DL

		Public Sub Insertar(ByVal pCCOSUBTIPOINCIDENCIA_BE As CCOSUBTIPOINCIDENCIA_BE)
			Try
				oCCOSUBTIPOINCIDENCIA_DL.Insertar(pCCOSUBTIPOINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCOSUBTIPOINCIDENCIA_BE As CCOSUBTIPOINCIDENCIA_BE)
			Try
				oCCOSUBTIPOINCIDENCIA_DL.Actualizar(pCCOSUBTIPOINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCOSUBTIPOINCIDENCIA_BE As CCOSUBTIPOINCIDENCIA_BE)
			Try
				oCCOSUBTIPOINCIDENCIA_DL.Eliminar(pCCOSUBTIPOINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

        Public Function Listarkey(ByVal pCCOSUBTIPOINCIDENCIA_BE As CCOSUBTIPOINCIDENCIA_BE) As CCOSUBTIPOINCIDENCIA_BE
            Try
                Return oCCOSUBTIPOINCIDENCIA_DL.ListarKey(pCCOSUBTIPOINCIDENCIA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

        Public Function ListarCombo(ByVal pCCOSUBTIPOINCIDENCIA_BE As CCOSUBTIPOINCIDENCIA_BE) As List(Of CCOSUBTIPOINCIDENCIA_BE)
            Try
                Return oCCOSUBTIPOINCIDENCIA_DL.ListarCombo(pCCOSUBTIPOINCIDENCIA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

        Public Function Listar(ByVal pCCOSUBTIPOINCIDENCIA_BE As CCOSUBTIPOINCIDENCIA_BE) As DataTable
            Try
                Return oCCOSUBTIPOINCIDENCIA_DL.Listar(pCCOSUBTIPOINCIDENCIA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function


	End Class
End Namespace
