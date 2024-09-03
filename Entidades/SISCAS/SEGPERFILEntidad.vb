Imports Entidades.SISCAS
Namespace SISCAS
    <Serializable()> _
    Partial Public Class SEGPERFILEntidad
        Inherits SISCASEntidadBase

        Public Sub New()
            MyBase.New("SISCAS", "SEGPERFIL")
            mlistadoobjetos = New List(Of SEGOBJETOEntidad)
        End Sub

        Private mlistadoobjetos As List(Of SEGOBJETOEntidad)

        Public Property ListadoObjetos() As List(Of SEGOBJETOEntidad)
            Get
                Return Me.mlistadoobjetos
            End Get
            Set(ByVal value As List(Of SEGOBJETOEntidad))
                Me.mlistadoobjetos = value
            End Set
        End Property

        Private Percodigo_key As String

        Public Property Percodigo() As Integer
            Get
                Return Percodigo_key
            End Get
            Set(ByVal value As Integer)
                Percodigo_key = value
            End Set
        End Property


        Private Perdescripcion_key As String

        Public Property Perdescripcion() As String
            Get
                Return Perdescripcion_key
            End Get
            Set(ByVal value As String)
                Perdescripcion_key = value
            End Set
        End Property


        Private Siscodigo_key As String

        Public Property Siscodigo() As Integer
            Get
                Return Siscodigo_key
            End Get
            Set(ByVal value As Integer)
                Siscodigo_key = value
            End Set
        End Property


        Private Perestado_key As String

        Public Property Perestado() As String
            Get
                Return Perestado_key
            End Get
            Set(ByVal value As String)
                Perestado_key = value
            End Set
        End Property

        Private Objvalor_key As String

        Public Property Objvalor() As String
            Get
                Return Objvalor_key
            End Get
            Set(ByVal value As String)
                Objvalor_key = value
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
