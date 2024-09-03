Imports System

Namespace BE

	<Serializable()> _
	Public Class CCORESULTADOINCIDENCIA_BE

		Private intrescodigo As Nullable(Of Integer)
		Private vchresdescripcion As String

		Public Property PropRESCODIGO() As Nullable(Of Integer)
		  Get
			  Return intrescodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intrescodigo = value
		  End Set
		End Property
		Public Property PropRESDESCRIPCION() As String
		  Get
			  Return vchresdescripcion
		  End Get
		  Set(ByVal value As String)
			  vchresdescripcion = value
		  End Set
		End Property

		Public Sub New()
			LimpiaPropiedades()
		End Sub

		Public Sub LimpiaPropiedades()
			PropRESCODIGO = Nothing
			PropRESDESCRIPCION = Nothing
		End Sub

	End Class
End Namespace
