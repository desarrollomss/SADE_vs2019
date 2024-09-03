Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class SYSESTACION_BL
		Private oSYSESTACION_DL As New DAL.SYSESTACION_DL

		Public Sub Insertar(ByVal pSYSESTACION_BE As SYSESTACION_BE)
			Try
				oSYSESTACION_DL.Insertar(pSYSESTACION_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Actualizar(ByVal pSYSESTACION_BE As SYSESTACION_BE)
			Try
				oSYSESTACION_DL.Actualizar(pSYSESTACION_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pSYSESTACION_BE As SYSESTACION_BE)
			Try
				oSYSESTACION_DL.Eliminar(pSYSESTACION_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pSYSESTACION_BE As SYSESTACION_BE) As SYSESTACION_BE
			Try
				Return oSYSESTACION_DL.ListarKey(pSYSESTACION_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function

        Public Sub Atencion_SIP(ByVal pSYSESTACION_BE As SYSESTACION_BE, ByVal pUsuario As String, ByVal pRolUsuario As Integer)
            Try
                oSYSESTACION_DL.Atencion_SIP(pSYSESTACION_BE, pUsuario, pRolUsuario)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub
        Public Function ListarAlerta(ByVal pVCHUSUARIO As String) As DataSet
            Try
                Return oSYSESTACION_DL.ListarAlerta(pVCHUSUARIO)
            Catch ex As Exception
                Throw ex
            End Try

        End Function

        Public Sub GestionarAlerta()
            Try
                oSYSESTACION_DL.GestionarAlerta()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub EliminarAlerta(ByVal pINTINCCODIGO As Int32)
            Try
                oSYSESTACION_DL.EliminarAlerta(pINTINCCODIGO)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public Sub EnAtencionAlerta(ByVal pINTINCCODIGO As Int32, ByVal pVCHUSUARIO As String, ByVal pSMLATENCION As Int16)
            Try
                oSYSESTACION_DL.EnAtencionAlerta(pINTINCCODIGO, pVCHUSUARIO, pSMLATENCION)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public Sub LiberarAlerta(ByVal pINTINCCODIGO As Int32, ByVal pVCHUSUARIO As String)
            Try
                oSYSESTACION_DL.LiberarAlerta(pINTINCCODIGO, pVCHUSUARIO)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Public Sub ActivaSesion(ByVal pVCHUSUARIO As String, ByVal pSMLESTADOSESION As Int16)
            Try
                oSYSESTACION_DL.ActivaSesion(pSMLESTADOSESION, pVCHUSUARIO)
            Catch ex As Exception
                Throw ex
            End Try

        End Sub
        Public Function ListarUsuario(ByVal pVCHUSUARIO As String) As DataTable
            Try
                Return oSYSESTACION_DL.ListarUsuario(pVCHUSUARIO)
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        'Public Sub ElimnarUsuario(ByVal pVCHUSUARIO As String)
        '    Try
        '        oSYSESTACION_DL.ElimnarUsuario(pVCHUSUARIO)
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Sub
        'Public Sub AgregarUsuario(ByVal pVCHUSUARIO As String)
        '    Try
        '        oSYSESTACION_DL.AgregarUsuario(pVCHUSUARIO)
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Sub
        'Public Sub AsignaRol(ByVal pINTROLCODIGO As Int16, ByVal pVCHUSUARIO As String)
        '    Try
        '        oSYSESTACION_DL.AsignaRol(pINTROLCODIGO, pVCHUSUARIO)
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Sub

        'Public Function Busqueda(ByVal pUsuario As String, ByVal pRolUsuario As Integer, ByVal pUsuarioEst As Integer) As DataTable
        '    Try
        '        Return oSYSESTACION_DL.Busqueda(pUsuario, pRolUsuario, pUsuarioEst)
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function

        Public Function Listar() As DataTable
            Try
                Return oSYSESTACION_DL.Listar()
            Catch ex As Exception
                Throw ex
            End Try
        End Function

    End Class
End Namespace
