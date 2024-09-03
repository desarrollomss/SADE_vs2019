Imports Framework.Datos
Imports Framework.Entidades
Imports System.Data
Imports System.Collections

Namespace SISCAS
    <Serializable()> _
    Public MustInherit Class SISCASDAOBase(Of TipoEntidad As EntidadBase)
        Inherits DAOBase(Of TipoEntidad)
        ', EntidadColeccion
        Sub New(ByVal nombreDeConexion As String, ByVal nombreDeEsquema As String, ByVal nombreDeTabla As String)
            MyBase.New(nombreDeConexion, nombreDeEsquema, nombreDeTabla)
        End Sub

    End Class
End Namespace