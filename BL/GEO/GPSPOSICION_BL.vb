Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

    Public Class GPSPOSICION_BL
        Private oGPSPOSICION_DL As New DAL.GPSPOSICION_DL

        Public Function Insertar(ByVal pGPSPOSICION_BE As GPSPOSICION_BE) As Integer
            Try
                Return oGPSPOSICION_DL.Insertar(pGPSPOSICION_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

    End Class
End Namespace
