Imports System
Imports System.Xml.Serialization
Imports System.Xml.XmlAttribute
Imports System.Xml
Imports System.IO
Imports Framework

Namespace SISCAS

    <Serializable()> Partial Public Class SEGUSUARIOEntidad
        Inherits SISCASEntidadBase
        Private mperfilesxusuario As List(Of SEGPERFILEntidad)
        Public Sub New()
            MyBase.New("SISCAS", "SEGUSUARIO")
            mperfilesxusuario = New List(Of SEGPERFILEntidad)
            
        End Sub
        


        Public Property Perfilesxusuario() As List(Of SEGPERFILEntidad)
            Get
                Return Me.mperfilesxusuario
            End Get
            Set(ByVal value As List(Of SEGPERFILEntidad))
                Me.mperfilesxusuario = value
            End Set
        End Property

        Private Usuidentificador_key As String
        Public Property Usuidentificador() As Integer
            Get
                Return Usuidentificador_key
            End Get
            Set(ByVal value As Integer)
                Me.Usuidentificador_key = value
            End Set
        End Property

        Private Usucodigo_key As String

        Public Property Usucodigo() As String
            Get
                Return Usucodigo_key
            End Get
            Set(ByVal value As String)
                Usucodigo_key = value
            End Set
        End Property

        Private Admcodigo_key As String

        Public Property Admcodigo() As Integer
            Get
                Return Admcodigo_key
            End Get
            Set(ByVal value As Integer)
                Admcodigo_key = value
            End Set
        End Property

        Private Usunombre_key As String

        Public Property Usunombre() As String
            Get
                Return Usunombre_key
            End Get
            Set(ByVal value As String)
                Usunombre_key = value
            End Set
        End Property


        Private Usuapepaterno_key As String

        Public Property Usuapepaterno() As String
            Get
                Return Usuapepaterno_key
            End Get
            Set(ByVal value As String)
                Usuapepaterno_key = value
            End Set
        End Property
        Public Usuapematerno_key As String

        Private Property Usuapematerno() As String
            Get
                Return Usuapematerno_key
            End Get
            Set(ByVal value As String)
                Usuapematerno_key = value
            End Set
        End Property

        Private Usupassword_key As String

        Public Property Usupassword() As String
            Get
                Return Usupassword_key
            End Get
            Set(ByVal value As String)
                Usupassword_key = value
            End Set
        End Property


        Private EstablecerUsupassword_key As String

        Public Property EstablecerUsupassword() As String
            Get
                Return EstablecerUsupassword_key
            End Get
            Set(ByVal value As String)
                EstablecerUsupassword_key = value
            End Set
        End Property

        Private Usuestado_key As String

        Public Property Usuestado() As String
            Get
                Return Usuestado_key
            End Get
            Set(ByVal value As String)
                Usuestado_key = value
            End Set
        End Property

        Private EstablecerUsuestado_key As String

        Public Property EstablecerUsuestado() As String
            Get
                Return EstablecerUsuestado_key
            End Get
            Set(ByVal value As String)
                EstablecerUsuestado_key = value
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

        Private EstablecerAudequipocreacion_key As String

        Public Property EstablecerAudequipocreacion() As String
            Get
                Return EstablecerAudequipocreacion_key
            End Get
            Set(ByVal value As String)
                EstablecerAudequipocreacion_key = value
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

        Private Audusucreacion_key As String

        Public Property Audusucreacion() As String
            Get
                Return Audusucreacion_key
            End Get
            Set(ByVal value As String)
                Audusucreacion_key = value
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



        Private EstablecerAudusumodif_key As String

        Public Property EstablecerAudusumodif() As String
            Get
                Return EstablecerAudusumodif_key
            End Get
            Set(ByVal value As String)
                EstablecerAudusumodif_key = value
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
        Private DiasAvisoCambio_key As Date
        Public Property DiasAvisoCambio() As Date
            Get
                Return DiasAvisoCambio_key
            End Get
            Set(ByVal value As Date)
                DiasAvisoCambio_key = value
            End Set
        End Property
    End Class
End Namespace
