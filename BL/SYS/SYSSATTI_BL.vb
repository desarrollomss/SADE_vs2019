Imports System.Text
Imports System.Data
Imports System.Collections.Generic
Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

    Public Class SATTI_BL

        Public Function ListaDetPredioCONS(ByVal pANOPRO As Integer, ByVal pNUMDDJJ As Integer, ByVal pCODPRE As Integer) As DataTable
            Dim obj As New SATTI_DL
            Return obj.ListaDetPredioCONS(pANOPRO, pNUMDDJJ, pCODPRE)
        End Function

        Public Function ListaDetPredioPU(ByVal pANOPRO As Integer, ByVal pNUMDDJJ As Integer, ByVal pCODPRE As Integer) As DataTable
            Dim obj As New SATTI_DL
            Return obj.ListaDetPredioPU(pANOPRO, pNUMDDJJ, pCODPRE)
        End Function

    End Class

End Namespace
