Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL


    Public Class LUGAR_BL

        Private oLugar_DL As New DAL.LUGAR_DL


        Public Function proj_LonLat2XY(ByVal pLon As String, ByVal pLat As String) As LUGAR_BE
            Return oLugar_DL.proj_LonLat2XY(pLon, pLat)
        End Function

        Public Function proj_XY2LonLat(ByVal pX As String, ByVal pY As String) As LUGAR_BE
            Return oLugar_DL.proj_XY2LonLat(pX, pY)
        End Function

    End Class

End Namespace
