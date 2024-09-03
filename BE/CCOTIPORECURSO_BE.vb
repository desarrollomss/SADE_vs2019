Imports System

Namespace BE

	<Serializable()> _
	Public Class CCOTIPORECURSO_BE

		Private inttrecodigo As Nullable(Of Integer)
		Private vchtredescripcion As String
		Private inttreestado As Nullable(Of Integer)

		Public Property PropTRECODIGO() As Nullable(Of Integer)
		  Get
			  Return inttrecodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  inttrecodigo = value
		  End Set
		End Property
		Public Property PropTREDESCRIPCION() As String
		  Get
			  Return vchtredescripcion
		  End Get
		  Set(ByVal value As String)
			  vchtredescripcion = value
		  End Set
		End Property
		Public Property PropTREESTADO() As Nullable(Of Integer)
		  Get
			  Return inttreestado
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  inttreestado = value
		  End Set
		End Property

		Public Sub New()
			LimpiaPropiedades()
		End Sub

		Public Sub LimpiaPropiedades()
			PropTRECODIGO = Nothing
			PropTREDESCRIPCION = Nothing
			PropTREESTADO = Nothing
		End Sub

	End Class
End Namespace
