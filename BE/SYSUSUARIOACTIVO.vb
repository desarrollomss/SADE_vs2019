Namespace BE
    <Serializable()> _
    Public Class SYSUSUARIOACTIVO
        Dim p_mintusuidentificador As Integer
        Dim p_mvchusucodigo As String
        Dim p_mvchusunombre As String
        Dim p_pmprogramaauditoria As String
        Dim p_pmequipoauditoria As String
        Dim p_saintccostocodigo As Integer
        Dim p_sasmlccostogrupo As Integer
        Dim p_savchccostodescripcion As String
        Dim p_sasmlanoejecano As Integer
        Dim p_sasmlperiperiodo As Integer
        Dim p_saintpiacodigo As Integer
        Dim p_sasmlanoejeccodigo As Integer

        Public Property p_smlanoejeccodigo() As String
            Get
                Return Me.p_sasmlanoejeccodigo
            End Get
            Set(ByVal value As String)
                Me.p_sasmlanoejeccodigo = value
            End Set
        End Property



        Public Property p_intpiacodigo() As String
            Get
                Return Me.p_saintpiacodigo
            End Get
            Set(ByVal value As String)
                Me.p_saintpiacodigo = value
            End Set
        End Property

        Public Property p_smlperiperiodo() As String
            Get
                Return Me.p_sasmlperiperiodo
            End Get
            Set(ByVal value As String)
                Me.p_sasmlperiperiodo = value
            End Set
        End Property

        Public Property p_smlanoejecano() As String
            Get
                Return Me.p_sasmlanoejecano
            End Get
            Set(ByVal value As String)
                Me.p_sasmlanoejecano = value
            End Set
        End Property

        Public Property p_vchccostodescripcion() As String
            Get
                Return Me.p_savchccostodescripcion
            End Get
            Set(ByVal value As String)
                Me.p_savchccostodescripcion = value
            End Set
        End Property

        Public Property p_smlccostogrupo() As String
            Get
                Return Me.p_sasmlccostogrupo
            End Get
            Set(ByVal value As String)
                Me.p_sasmlccostogrupo = value
            End Set
        End Property

        Public Property p_intccostocodigo() As String
            Get
                Return Me.p_saintccostocodigo
            End Get
            Set(ByVal value As String)
                Me.p_saintccostocodigo = value
            End Set
        End Property

        Public Property p_vchusunombre() As String
            Get
                Return Me.p_mvchusunombre
            End Get
            Set(ByVal value As String)
                Me.p_mvchusunombre = value
            End Set
        End Property
        Public Property p_vchusucodigo() As String
            Get
                Return Me.p_mvchusucodigo
            End Get
            Set(ByVal value As String)
                Me.p_mvchusucodigo = value
            End Set
        End Property
        Public Property p_intusuidentificador() As Integer
            Get
                Return Me.p_mintusuidentificador
            End Get
            Set(ByVal value As Integer)
                Me.p_mintusuidentificador = value
            End Set
        End Property
        Public Property p_programaauditoria() As String
            Get
                Return Me.p_pmprogramaauditoria
            End Get
            Set(ByVal value As String)
                Me.p_pmprogramaauditoria = value
            End Set
        End Property
        Public Property p_equipoauditoria() As String
            Get
                Return Me.p_pmequipoauditoria
            End Get
            Set(ByVal value As String)
                Me.p_pmequipoauditoria = value
            End Set
        End Property

        Public Sub New()
        End Sub
    End Class
End Namespace

