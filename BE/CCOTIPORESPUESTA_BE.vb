Imports System

Namespace BE

	<Serializable()> _
	Public Class CCOTIPORESPUESTA_BE

		Private smltrecodigo As Nullable(Of Int16)
		Private vchtredescripcion As String
		Private smltreestado As Nullable(Of Int16)

		Public Property PropTRECODIGO() As Nullable(Of Int16)
		  Get
			  Return smltrecodigo
		  End Get
		  Set(ByVal value As Nullable(Of Int16))
			  smltrecodigo = value
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
		Public Property PropTREESTADO() As Nullable(Of Int16)
		  Get
			  Return smltreestado
		  End Get
		  Set(ByVal value As Nullable(Of Int16))
			  smltreestado = value
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
