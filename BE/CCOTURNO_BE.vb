Imports System

Namespace BE

	<Serializable()> _
	Public Class CCOTURNO_BE

		Private vchturdescripcion As String
		Private vchturhorario As String
		Private intturcodigo As Nullable(Of Integer)
		Private vchturabrevia As String
		Private intttucodigo As Nullable(Of Integer)

		Public Property PropTURDESCRIPCION() As String
		  Get
			  Return vchturdescripcion
		  End Get
		  Set(ByVal value As String)
			  vchturdescripcion = value
		  End Set
		End Property
		Public Property PropTURHORARIO() As String
		  Get
			  Return vchturhorario
		  End Get
		  Set(ByVal value As String)
			  vchturhorario = value
		  End Set
		End Property
		Public Property PropTURCODIGO() As Nullable(Of Integer)
		  Get
			  Return intturcodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intturcodigo = value
		  End Set
		End Property
		Public Property PropTURABREVIA() As String
		  Get
			  Return vchturabrevia
		  End Get
		  Set(ByVal value As String)
			  vchturabrevia = value
		  End Set
		End Property
		Public Property PropTTUCODIGO() As Nullable(Of Integer)
		  Get
			  Return intttucodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intttucodigo = value
		  End Set
		End Property

		Public Sub New()
			LimpiaPropiedades()
		End Sub

		Public Sub LimpiaPropiedades()
			PropTURDESCRIPCION = Nothing
			PropTURHORARIO = Nothing
			PropTURCODIGO = Nothing
			PropTURABREVIA = Nothing
			PropTTUCODIGO = Nothing
		End Sub

	End Class
End Namespace
