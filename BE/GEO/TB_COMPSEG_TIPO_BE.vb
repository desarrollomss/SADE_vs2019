Imports System

Namespace BE

	<Serializable()> _
	Public Class TB_COMPSEG_TIPO_BE

		Private idcst As Nullable(Of Integer)
		Private cod As String
		Private nom As String
		Private icono As String

        Public Property PropIDCST() As Nullable(Of Integer)
            Get
                Return idcst
            End Get
            Set(ByVal value As Nullable(Of Integer))
                idcst = value
            End Set
        End Property
        Public Property PropCOD() As String
            Get
                Return cod
            End Get
            Set(ByVal value As String)
                cod = value
            End Set
        End Property
        Public Property PropNOM() As String
            Get
                Return nom
            End Get
            Set(ByVal value As String)
                nom = value
            End Set
        End Property
        Public Property PropICONO() As String
            Get
                Return icono
            End Get
            Set(ByVal value As String)
                icono = value
            End Set
        End Property

		Public Sub New()
			LimpiaPropiedades()
		End Sub

		Public Sub LimpiaPropiedades()
            PropIDCST = Nothing
            PropCOD = Nothing
            PropNOM = Nothing
            PropICONO = Nothing
		End Sub

	End Class
End Namespace
