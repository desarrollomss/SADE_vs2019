'--Imports IBM.Data.DB2
Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class CCOINCIDENCIAPAQUETE_BL
		Private oCCOINCIDENCIAPAQUETE_DL As New DAL.CCOINCIDENCIAPAQUETE_DL

		Public Sub Insertar(ByVal pCCOINCIDENCIAPAQUETE_BE As CCOINCIDENCIAPAQUETE_BE)
			Try
				oCCOINCIDENCIAPAQUETE_DL.Insertar(pCCOINCIDENCIAPAQUETE_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCOINCIDENCIAPAQUETE_BE As CCOINCIDENCIAPAQUETE_BE)
			Try
				oCCOINCIDENCIAPAQUETE_DL.Actualizar(pCCOINCIDENCIAPAQUETE_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCOINCIDENCIAPAQUETE_BE As CCOINCIDENCIAPAQUETE_BE)
			Try
				oCCOINCIDENCIAPAQUETE_DL.Eliminar(pCCOINCIDENCIAPAQUETE_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pCCOINCIDENCIAPAQUETE_BE As CCOINCIDENCIAPAQUETE_BE) As CCOINCIDENCIAPAQUETE_BE
			Try
				Return oCCOINCIDENCIAPAQUETE_DL.ListarKey(pCCOINCIDENCIAPAQUETE_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function

        Public Sub ActualizarAtencion(ByVal pCCOINCIDENCIAPAQUETE_BE As CCOINCIDENCIAPAQUETE_BE)
            Try
                oCCOINCIDENCIAPAQUETE_DL.ActualizarAtencion(pCCOINCIDENCIAPAQUETE_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

        Public Function Listar(ByVal pINTINCCODIGO As Integer) As DataTable
            Try
                Return oCCOINCIDENCIAPAQUETE_DL.Listar(pINTINCCODIGO)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

	End Class
End Namespace
