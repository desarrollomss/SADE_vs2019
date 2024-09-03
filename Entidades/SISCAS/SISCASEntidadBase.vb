
Imports System
Imports System.Xml.Serialization
Imports System.Xml.XmlAttribute
Imports System.Xml
Imports System.IO
Imports Framework.Entidades
Namespace SISCAS
    <Serializable()> _
    Public MustInherit Class SISCASEntidadBase
        Inherits EntidadBase
        Public Sub New(ByVal NombreDeEsquema As String, ByVal NombreDeTabla As String)
            MyBase.new(NombreDeEsquema, NombreDeTabla)
        End Sub
    End Class
End Namespace
