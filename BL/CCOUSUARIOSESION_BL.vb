Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class CCOUSUARIOSESION_BL
		Private oCCOUSUARIOSESION_DL As New DAL.CCOUSUARIOSESION_DL

		Public Sub Insertar(ByVal pCCOUSUARIOSESION_BE As CCOUSUARIOSESION_BE)
			Try
				oCCOUSUARIOSESION_DL.Insertar(pCCOUSUARIOSESION_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCOUSUARIOSESION_BE As CCOUSUARIOSESION_BE)
			Try
				oCCOUSUARIOSESION_DL.Actualizar(pCCOUSUARIOSESION_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCOUSUARIOSESION_BE As CCOUSUARIOSESION_BE)
			Try
				oCCOUSUARIOSESION_DL.Eliminar(pCCOUSUARIOSESION_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pCCOUSUARIOSESION_BE As CCOUSUARIOSESION_BE) As CCOUSUARIOSESION_BE
			Try
				Return oCCOUSUARIOSESION_DL.ListarKey(pCCOUSUARIOSESION_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function

        Public Sub EliminarUsuario(ByVal pVCHUSUARIO As String)
            Try
                oCCOUSUARIOSESION_DL.EliminarUsuario(pVCHUSUARIO)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public Sub AgregarUsuario(ByVal pVCHUSUARIO As String)
            Try
                oCCOUSUARIOSESION_DL.AgregarUsuario(pVCHUSUARIO)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public Sub AsignaRol(ByVal pINTROLCODIGO As Int16, ByVal pVCHUSUARIO As String)
            Try
                oCCOUSUARIOSESION_DL.AsignaRol(pINTROLCODIGO, pVCHUSUARIO)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Function Busqueda(ByVal pUsuario As String, ByVal pRolUsuario As Integer, ByVal pUsuarioEst As Integer) As DataTable
            Try
                Return oCCOUSUARIOSESION_DL.Busqueda(pUsuario, pRolUsuario, pUsuarioEst)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Sub InsertarUsuario(ByVal pCCOUSUARIOSESION_BE As CCOUSUARIOSESION_BE)
            Try
                oCCOUSUARIOSESION_DL.InsertarUsuario(pCCOUSUARIOSESION_BE)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub AsignaRol(ByVal pCCOUSUARIOSESION_BE As CCOUSUARIOSESION_BE)
            Try
                oCCOUSUARIOSESION_DL.AsignaRol(pCCOUSUARIOSESION_BE)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub


	End Class
End Namespace
