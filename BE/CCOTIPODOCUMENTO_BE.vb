Imports System

Namespace BE

	<Serializable()> _
	Public Class CCOTIPODOCUMENTO_BE

		Private inttdocodigo As Nullable(Of Integer)
		Private vchtdodescripcion As String
		Private vchtdoabrevia As String
		Private inttdoestado As Nullable(Of Integer)

		Public Property PropTDOCODIGO() As Nullable(Of Integer)
		  Get
			  Return inttdocodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  inttdocodigo = value
		  End Set
		End Property
		Public Property PropTDODESCRIPCION() As String
		  Get
			  Return vchtdodescripcion
		  End Get
		  Set(ByVal value As String)
			  vchtdodescripcion = value
		  End Set
		End Property
		Public Property PropTDOABREVIA() As String
		  Get
			  Return vchtdoabrevia
		  End Get
		  Set(ByVal value As String)
			  vchtdoabrevia = value
		  End Set
		End Property
		Public Property PropTDOESTADO() As Nullable(Of Integer)
		  Get
			  Return inttdoestado
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  inttdoestado = value
		  End Set
		End Property

		Public Sub New()
			LimpiaPropiedades()
		End Sub

		Public Sub LimpiaPropiedades()
			PropTDOCODIGO = Nothing
			PropTDODESCRIPCION = Nothing
			PropTDOABREVIA = Nothing
			PropTDOESTADO = Nothing
		End Sub

	End Class
End Namespace
