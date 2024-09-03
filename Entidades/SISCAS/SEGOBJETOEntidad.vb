Imports System
Imports System.Xml.Serialization
Imports System.Xml.XmlAttribute
Imports System.Xml
Imports System.IO
Imports Framework
Imports Entidades.SISCAS
Namespace SISCAS
    <Serializable()> _
    Partial Public Class SEGOBJETOEntidad
        Inherits SISCASEntidadBase
        Public Sub New()
            MyBase.New("SISCAS", "SEGOBJETO")
            mlistadoaciones = New List(Of SEGACCIONEntidad)
        End Sub

        Private mlistadoaciones As List(Of SEGACCIONEntidad)

        Public Property ListadoAciones() As List(Of SEGACCIONEntidad)
            Get
                Return Me.mlistadoaciones
            End Get
            Set(ByVal value As List(Of SEGACCIONEntidad))
                Me.mlistadoaciones = value
            End Set
        End Property

        Private Objcodigo_key As String

        Public Property Objcodigo() As Integer
            Get
                Return Objcodigo_key
            End Get
            Set(ByVal value As Integer)
                Objcodigo_key = value
            End Set
        End Property

        Private Siscodigo_key As String

        Public Property Siscodigo() As String
            Get
                Return Siscodigo_key
            End Get
            Set(ByVal value As String)
                Siscodigo_key = value
            End Set
        End Property


        Private Objdescripcion_key As String

        Public Property Objdescripcion() As String
            Get
                Return Objdescripcion_key
            End Get
            Set(ByVal value As String)
                Objdescripcion_key = value
            End Set
        End Property


        Private Objpadrecodigo_key As String

        Public Property Objpadrecodigo() As Integer
            Get
                Return Objpadrecodigo_key
            End Get
            Set(ByVal value As Integer)
                Objpadrecodigo_key = value
            End Set
        End Property


        Private Objestado_key As String

        Public Property Objestado() As String
            Get
                Return Objestado_key
            End Get
            Set(ByVal value As String)
                Objestado_key = value
            End Set
        End Property

        Private Objnumorden_key As String

        Public Property Objnumorden() As Integer
            Get
                Return Objnumorden_key
            End Get
            Set(ByVal value As Integer)
                Objnumorden_key = value
            End Set
        End Property

        Private Objsustento_key As String

        Public Property Objsustento() As String
            Get
                Return Objsustento_key
            End Get
            Set(ByVal value As String)
                Objsustento_key = value
            End Set
        End Property


        Private Objurl_key As String

        Public Property Objurl() As String
            Get
                Return Objurl_key
            End Get
            Set(ByVal value As String)
                Objurl_key = value
            End Set
        End Property


        Private Objhijo_key As String

        Public Property Objhijo() As String
            Get
                Return Objhijo_key
            End Get
            Set(ByVal value As String)
                Objhijo_key = value
            End Set
        End Property

        Private Audprogramacreacion_key As String

        Public Property Audprogramacreacion() As String
            Get
                Return Audprogramacreacion_key
            End Get
            Set(ByVal value As String)
                Audprogramacreacion_key = value
            End Set
        End Property



        Private Audequipocreacion_key As String

        Public Property Audequipocreacion() As String
            Get
                Return Audequipocreacion_key
            End Get
            Set(ByVal value As String)
                Audequipocreacion_key = value
            End Set
        End Property

        Private Audfeccreacion_key As Date

        Public Property Audfeccreacion() As Date
            Get
                Return Audfeccreacion_key
            End Get
            Set(ByVal value As Date)
                Audfeccreacion_key = value
            End Set
        End Property



        Private Audprogramamodif_key As String

        Public Property Audprogramamodif() As String
            Get
                Return Audprogramamodif_key
            End Get
            Set(ByVal value As String)
                Audprogramamodif_key = value
            End Set
        End Property


        Private Audequipomodif_key As String

        Public Property Audequipomodif() As String
            Get
                Return Audequipomodif_key
            End Get
            Set(ByVal value As String)
                Audequipomodif_key = value
            End Set
        End Property


        Private Audusumodif_key As String

        Public Property Audusumodif() As String
            Get
                Return Audusumodif_key
            End Get
            Set(ByVal value As String)
                Audusumodif_key = value
            End Set
        End Property


        Private Audfecmodif_key As Date

        Public Property Audfecmodif() As Date
            Get
                Return Audfecmodif_key
            End Get
            Set(ByVal value As Date)
                Audfecmodif_key = value
            End Set
        End Property

    End Class
End Namespace
