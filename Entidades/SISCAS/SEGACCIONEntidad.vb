
Imports Entidades.SISCAS
Namespace SISCAS
    <Serializable()> _
    Partial Public Class SEGACCIONEntidad
        Inherits SISCASEntidadBase

        Public Sub New()
            MyBase.New("SISCAS", "SEGACCION")
        End Sub


        Private Acccodigo_key As Integer

        Public Property Acccodigo() As Integer
            Get
                Return Acccodigo_key
            End Get
            Set(ByVal value As Integer)
                Acccodigo_key = value
            End Set
        End Property


        Private Objcodigo_key As Integer

        Public Property Objcodigo() As Integer
            Get
                Return Objcodigo_key
            End Get
            Set(ByVal value As Integer)
                Objcodigo_key = value
            End Set
        End Property

        Private Siscodigo_key As Integer

        Public Property Siscodigo() As Integer
            Get
                Return Siscodigo_key
            End Get
            Set(ByVal value As Integer)
                Siscodigo_key = value
            End Set
        End Property


        Private Accdescripcion_key As String

        Public Property Accdescripcion() As String
            Get
                Return Accdescripcion_key
            End Get
            Set(ByVal value As String)
                Accdescripcion_key = value
            End Set
        End Property


        Private Accestado_key As String

        Public Property Accestado() As String
            Get
                Return Accestado_key
            End Get
            Set(ByVal value As String)
                Accestado_key = value
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


        Private Acccodigopadre_key As String

        Public Property Acccodigopadre() As Integer
            Get
                Return Acccodigopadre_key
            End Get
            Set(ByVal value As Integer)
                Acccodigopadre_key = value
            End Set
        End Property

        Private Accnroorden_key As String

        Public Property Accnroorden() As String
            Get
                Return Accnroorden_key
            End Get
            Set(ByVal value As String)
                Accnroorden_key = value
            End Set
        End Property


        Private Accnombrectrol_key As String

        Public Property Accnombrectrol() As String
            Get
                Return Accnombrectrol_key
            End Get
            Set(ByVal value As String)
                Accnombrectrol_key = value
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
        Private Audfeccreacion_key As String

        Public Property Audfeccreacion() As String
            Get
                Return Audfeccreacion_key
            End Get
            Set(ByVal value As String)
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
