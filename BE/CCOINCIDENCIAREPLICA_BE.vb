Imports System

Namespace BE

	<Serializable()> _
	Public Class CCOINCIDENCIAREPLICA_BE

		Private intinrcodigo As Nullable(Of Integer)

		Public Property PropINRCODIGO() As Nullable(Of Integer)
		  Get
			  Return intinrcodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intinrcodigo = value
		  End Set
		End Property

		Public Sub New()
			LimpiaPropiedades()
		End Sub

		Public Sub LimpiaPropiedades()
			PropINRCODIGO = Nothing
		End Sub

	End Class
End Namespace
