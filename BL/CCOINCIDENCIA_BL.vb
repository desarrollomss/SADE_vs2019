Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class CCOINCIDENCIA_BL
		Private oCCOINCIDENCIA_DL As New DAL.CCOINCIDENCIA_DL

		Public Sub Insertar(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE)
			Try
				oCCOINCIDENCIA_DL.Insertar(pCCOINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE)
			Try
				oCCOINCIDENCIA_DL.Actualizar(pCCOINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE)
			Try
				oCCOINCIDENCIA_DL.Eliminar(pCCOINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE) As CCOINCIDENCIA_BE
			Try
				Return oCCOINCIDENCIA_DL.ListarKey(pCCOINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function

        Public Function Listar(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE, ByVal pBuscaTodo As Integer) As DataTable
            Try
                Return oCCOINCIDENCIA_DL.Listar(pCCOINCIDENCIA_BE, pBuscaTodo)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function


        Public Sub InsertFromSIP(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE)
            Try
                oCCOINCIDENCIA_DL.InsertFromSIP(pCCOINCIDENCIA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

        Public Function InsertarMan(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE) As Integer
            Try
                Return oCCOINCIDENCIA_DL.InsertarMan(pCCOINCIDENCIA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function


        Public Sub DerivarIncidencia(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE)
            Try
                oCCOINCIDENCIA_DL.DerivarIncidencia(pCCOINCIDENCIA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

        Public Sub CancelarDerivarIncidencia(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE)
            Try
                oCCOINCIDENCIA_DL.CancelarDerivarIncidencia(pCCOINCIDENCIA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

        Public Function InsertFromAlertaSurco(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE) As Integer
            Try
                Return oCCOINCIDENCIA_DL.InsertFromALertaSurco(pCCOINCIDENCIA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

        Public Sub AtenderIncidencia(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE)
            Try
                oCCOINCIDENCIA_DL.AtenderIncidencia(pCCOINCIDENCIA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

        Public Sub DevolerAbiertaIncidencia(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE)
            Try
                oCCOINCIDENCIA_DL.DevolerAbiertaIncidencia(pCCOINCIDENCIA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

        Public Function ListarDatos(ByVal pINCCODIGO As Integer) As DataTable
            Try
                Return oCCOINCIDENCIA_DL.ListarDatos(pINCCODIGO)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function


        Public Sub CerrarIncidencia(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE)
            Try
                oCCOINCIDENCIA_DL.CerrarIncidencia(pCCOINCIDENCIA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

        Public Sub DerivarSIAVE(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE)
            Try
                oCCOINCIDENCIA_DL.DerivarSIAVE(pCCOINCIDENCIA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

        Public Sub CerrarSIAVE(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE)
            Try
                oCCOINCIDENCIA_DL.CerrarSIAVE(pCCOINCIDENCIA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

        Public Function ListarBandejaAlerta(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE) As DataTable
            Try
                Return oCCOINCIDENCIA_DL.ListarBandejaAlerta(pCCOINCIDENCIA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

        Public Function ListarTematico(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE) As DataTable
            Try
                Return oCCOINCIDENCIA_DL.ListarTematico(pCCOINCIDENCIA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

        Public Function ListarMarcadores(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE) As DataTable
            Try
                Return oCCOINCIDENCIA_DL.ListarMarcadores(pCCOINCIDENCIA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

        Public Sub ActualizarAlertaSurcoV2(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE)
            Try
                oCCOINCIDENCIA_DL.ActualizarAlertaSurcoV2(pCCOINCIDENCIA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

        Public Sub Insertar_SQL_DB2(ByVal plstCCOINCIDENCIA_BE As List(Of CCOINCIDENCIA_BE))
            Try
                oCCOINCIDENCIA_DL.Insertar_SQL_DB2(plstCCOINCIDENCIA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

        Public Function ListarF911(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE, ByVal pDesde As String, ByVal pHasta As String, ByVal pBuscaTodo As Integer) As DataTable
            Try
                Return oCCOINCIDENCIA_DL.ListarF911(pCCOINCIDENCIA_BE, pDesde, pHasta, pBuscaTodo)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function


        Public Sub Actualizar_SQL_DB2(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE)
            Try
                oCCOINCIDENCIA_DL.Actualizar_SQL_DB2(pCCOINCIDENCIA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

        Public Sub DescartarSIAVE(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE)
            Try
                oCCOINCIDENCIA_DL.DescartarSIAVE(pCCOINCIDENCIA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub
        Public Function ListarDetalle(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE) As DataTable
            Try
                Return oCCOINCIDENCIA_DL.ListarDetalle(pCCOINCIDENCIA_BE)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Sub Actualizar_GEO_SIAVE(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE)
            Try
                oCCOINCIDENCIA_DL.Actualizar_GEO_SIAVE(pCCOINCIDENCIA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

        Public Function InsertarAlertaSurcoV3(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE, ByVal pCCOINCIDENCIADEVICE_BE As CCOINCIDENCIADEVICE_BE) As Integer
            Try
                Return oCCOINCIDENCIA_DL.InsertarAlertaSurcoV3(pCCOINCIDENCIA_BE, pCCOINCIDENCIADEVICE_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

        Public Function InsertarOperador(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE) As Integer
            Try
                Return oCCOINCIDENCIA_DL.InsertarOperador(pCCOINCIDENCIA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

        Public Function ActualizarOperador(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE) As Integer
            Try
                Return oCCOINCIDENCIA_DL.ActualizarOperador(pCCOINCIDENCIA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

        Public Sub Finalizar_Atencion(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE)
            Try
                oCCOINCIDENCIA_DL.Finalizar_Atencion(pCCOINCIDENCIA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub


        Public Sub Finalizar_Atencion_Nuevo(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE)
            Try
                oCCOINCIDENCIA_DL.Finalizar_Atencion_Nuevo(pCCOINCIDENCIA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

        Public Function Busqueda(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE, ByVal pBuscaTodo As Integer) As DataTable
            Try
                Return oCCOINCIDENCIA_DL.Busqueda(pCCOINCIDENCIA_BE, pBuscaTodo)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function


        Public Function ReporteFormatoSADE(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE) As DataTable
            Try
                Return oCCOINCIDENCIA_DL.ReporteFormatoSADE(pCCOINCIDENCIA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

        Public Function Exportar(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE) As DataTable
            Try
                Return oCCOINCIDENCIA_DL.Exportar(pCCOINCIDENCIA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

        Public Function getFechaHoraServer() As DateTime
            Try
                Return oCCOINCIDENCIA_DL.getFechaHoraServer()
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

        Public Sub DerivarSIAVE2(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE)
            Try
                oCCOINCIDENCIA_DL.DerivarSIAVE2(pCCOINCIDENCIA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

        Public Sub ActualizarFile(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE)
            Try
                oCCOINCIDENCIA_DL.ActualizarFile(pCCOINCIDENCIA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

        Public Sub ActualizarFileNew(ByVal pNAMEFILE As String)
            Try
                oCCOINCIDENCIA_DL.ActualizarFileNew(pNAMEFILE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

        Public Function BusquedaGeneral(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE, ByVal pBuscaTodo As Integer) As DataTable
            Try
                Return oCCOINCIDENCIA_DL.BusquedaGeneral(pCCOINCIDENCIA_BE, pBuscaTodo)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

        Public Function RegistrarAlertaSurcoV2(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE, ByVal pGPSREGISTRO_BE As GPSREGISTRO_BE) As Integer
            Try
                Return oCCOINCIDENCIA_DL.RegistrarAlertaSurcoV2(pCCOINCIDENCIA_BE, pGPSREGISTRO_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

        Public Function RegistrarLlamada(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE) As Integer
            Try
                Return oCCOINCIDENCIA_DL.RegistrarLlamada(pCCOINCIDENCIA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

        Public Function RegistrarAlertaSurcoV3(ByVal pCCOINCIDENCIA_BE As CCOINCIDENCIA_BE, ByVal pGPSREGISTRO_BE As GPSREGISTRO_BE) As Integer
            Try
                Return oCCOINCIDENCIA_DL.RegistrarAlertaSurcoV3(pCCOINCIDENCIA_BE, pGPSREGISTRO_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

    End Class
End Namespace
