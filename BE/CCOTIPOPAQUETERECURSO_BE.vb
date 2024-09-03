Imports System

Namespace BE

	<Serializable()> _
	Public Class CCOTIPOPAQUETERECURSO_BE

		Private intpaqcodigo As Nullable(Of Integer)
		Private inttrecodigo As Nullable(Of Integer)
		Private inttprobligatorio As Nullable(Of Integer)

		Public Property PropPAQCODIGO() As Nullable(Of Integer)
		  Get
			  Return intpaqcodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intpaqcodigo = value
		  End Set
		End Property
		Public Property PropTRECODIGO() As Nullable(Of Integer)
		  Get
			  Return inttrecodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  inttrecodigo = value
		  End Set
		End Property
		Public Property PropTPROBLIGATORIO() As Nullable(Of Integer)
		  Get
			  Return inttprobligatorio
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  inttprobligatorio = value
		  End Set
		End Property

		Public Sub New()
			LimpiaPropiedades()
		End Sub

		Public Sub LimpiaPropiedades()
			PropPAQCODIGO = Nothing
			PropTRECODIGO = Nothing
			PropTPROBLIGATORIO = Nothing
		End Sub

	End Class
End Namespace
