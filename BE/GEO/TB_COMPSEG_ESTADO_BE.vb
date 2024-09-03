Imports System

Namespace BE

	<Serializable()> _
	Public Class TB_COMPSEG_ESTADO_BE

		Private idcse As Nullable(Of Integer)
		Private nom As String

        Public Property PropIDCSE() As Nullable(Of Integer)
            Get
                Return idcse
            End Get
            Set(ByVal value As Nullable(Of Integer))
                idcse = value
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

		Public Sub New()
			LimpiaPropiedades()
		End Sub

		Public Sub LimpiaPropiedades()
            PropIDCSE = Nothing
            PropNOM = Nothing
		End Sub

	End Class
End Namespace
