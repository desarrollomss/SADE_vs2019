Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class GPSREGISTRO_BL
		Private oGPSREGISTRO_DL As New DAL.GPSREGISTRO_DL

        'Public Sub Insertar(ByVal pGPSREGISTRO_BE As GPSREGISTRO_BE)
        '	Try
        '		oGPSREGISTRO_DL.Insertar(pGPSREGISTRO_BE)
        '	Catch ex As Exception
        '		Throw ex
        '	Finally
        '	End Try
        'End Sub

		Public Sub Actualizar(ByVal pGPSREGISTRO_BE As GPSREGISTRO_BE)
			Try
				oGPSREGISTRO_DL.Actualizar(pGPSREGISTRO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pGPSREGISTRO_BE As GPSREGISTRO_BE)
			Try
				oGPSREGISTRO_DL.Eliminar(pGPSREGISTRO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pGPSREGISTRO_BE As GPSREGISTRO_BE) As GPSREGISTRO_BE
			Try
				Return oGPSREGISTRO_DL.ListarKey(pGPSREGISTRO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function


        Public Function Insertar(ByVal pGPSREGISTRO_BE As GPSREGISTRO_BE) As List(Of GPSREGISTRO_BE)
            Try
                Return oGPSREGISTRO_DL.Insertar(pGPSREGISTRO_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

        Public Function Listar(ByVal pNUMERO As String) As List(Of GPSREGISTRO_BE)
            Try
                Return oGPSREGISTRO_DL.Listar(pNUMERO)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

        Public Function ListarUsuarioApp(ByVal pNUMERO As String, ByVal pVERSION As String) As List(Of GPSREGISTRO_BE)
            Try
                Return oGPSREGISTRO_DL.ListarUsuarioApp(pNUMERO, pVERSION)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function


        Public Function Validar(ByVal pNUMERO As String) As String
            Try
                Return oGPSREGISTRO_DL.Validar(pNUMERO)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function
        Public Function Listar(ByVal pGPSREGISTRO_BE As GPSREGISTRO_BE) As DataTable
            Try
                Return oGPSREGISTRO_DL.Listar(pGPSREGISTRO_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function
        Public Function ListarDetalle(ByVal pGPSREGISTRO_BE As GPSREGISTRO_BE) As DataTable
            Try
                Return oGPSREGISTRO_DL.ListarDetalle(pGPSREGISTRO_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function
        Public Function ListarResumen(ByVal pGPSREGISTRO_BE As GPSREGISTRO_BE) As DataTable
            Try
                Return oGPSREGISTRO_DL.ListarResumen(pGPSREGISTRO_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

        Public Function InsertarV3(ByVal pGPSREGISTRO_BE As GPSREGISTRO_BE) As List(Of GPSREGISTRO_BE)
            Try
                Return oGPSREGISTRO_DL.InsertarV3(pGPSREGISTRO_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

        Public Function Registrar(ByVal pGPSREGISTRO_BE As GPSREGISTRO_BE) As List(Of GPSREGISTRO_BE)
            Try
                Return oGPSREGISTRO_DL.Registrar(pGPSREGISTRO_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

    End Class
End Namespace
