Imports System.Collections
Imports System.Collections.Specialized
'Imports System.Collections.ICollection.SyncRoot
Namespace Entidades
    <Serializable()> _
    Public MustInherit Class EntidadBase

        Public Sub New(ByVal NombreDeEsquema As String, ByVal NombreDeTabla As String)
            Me.NombreDeEsquema = NombreDeEsquema
            Me.NombreDeTabla = NombreDeTabla
            ' Me.Propiedades = New OrderedDictionary
        End Sub




#Region "Variables Internas"




        Protected NombreDeEsquema As String

        ''' <summary>
        ''' Nombre de la tabla relacionada con la entidad
        ''' </summary>
        ''' <remarks></remarks>
        Protected NombreDeTabla As String

        ''' <summary>
        ''' Coleccion de valores y nombres de las propiedades
        ''' </summary>
        ''' <remarks></remarks>
        Protected Propiedades As IDictionary

#End Region

#Region "Propiedades y sus valores por defecto"

        ''' <summary>
        ''' Obtiene el IDictionari interno de la entidad con la informacion de los nombre y valores de cada propiedad
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        'Public Function ObtenerEnIDictionary() As IDictionary
        '    Return Propiedades
        'End Function

        ''' <summary>
        ''' Obtiene una coleccion con los nombres de las propiedades de la entidad
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        'Public ReadOnly Property NombresDeColumnas() As System.Collections.Generic.IList(

        '    Get
        '        Return Me.Propiedades.Keys
        '    End Get
        'End Property

        ''' <summary>
        ''' Establece el valor de determinada propiedad si el nombre de la propiedad no existe libera una excepcion
        ''' </summary>
        ''' <param name="NombreDeColumna"></param>
        ''' <param name="Valor"></param>
        ''' <remarks></remarks>
        'Public Sub EstablecerPropiedad(ByVal nombreDeColumna As String, ByVal Valor As Object)
        '    Propiedades.Item(nombreDeColumna) = Valor
        'End Sub

        'Public Function ObtenerPropiedad(ByVal nombreDeColumna As String) As Object
        '    If PropiedadEsDBNull(nombreDeColumna) Then
        '        Return Nothing
        '    Else
        '        Return Propiedades.Item(nombreDeColumna)
        '    End If
        'End Function

        'Public Function PropiedadEsDBNull(ByVal nombreDeColumna As String) As Boolean
        '    Return Propiedades.Item(nombreDeColumna) Is DBNull.Value
        'End Function

        'Public Sub EstablecerPropiedadADBNull(ByVal nombreDeColumna As String)
        '    Propiedades.Item(nombreDeColumna) = DBNull.Value
        'End Sub

        'Public Sub RegistrarPropiedad(ByVal nombreDeColumna As String)
        '    EstablecerPropiedad(nombreDeColumna, Nothing)
        'End Sub

        'Public Sub EstablecerTodasLasPropiedadADBNull()
        '    For Each key As String In NombresDeColumnas
        '        EstablecerPropiedadADBNull(key)
        '    Next
        'End Sub

#End Region

    End Class
End Namespace
