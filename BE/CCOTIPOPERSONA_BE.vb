Imports System

Namespace BE

	<Serializable()> _
	Public Class CCOTIPOPERSONA_BE

		Private inttpecodigo As Nullable(Of Integer)
		Private vchtpedescripcion As String
		Private vchtpeabrevia As String
		Private inttpeestado As Nullable(Of Integer)

		Public Property PropTPECODIGO() As Nullable(Of Integer)
		  Get
			  Return inttpecodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  inttpecodigo = value
		  End Set
		End Property
		Public Property PropTPEDESCRIPCION() As String
		  Get
			  Return vchtpedescripcion
		  End Get
		  Set(ByVal value As String)
			  vchtpedescripcion = value
		  End Set
		End Property
		Public Property PropTPEABREVIA() As String
		  Get
			  Return vchtpeabrevia
		  End Get
		  Set(ByVal value As String)
			  vchtpeabrevia = value
		  End Set
		End Property
		Public Property PropTPEESTADO() As Nullable(Of Integer)
		  Get
			  Return inttpeestado
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  inttpeestado = value
		  End Set
		End Property

		Public Sub New()
			LimpiaPropiedades()
		End Sub

		Public Sub LimpiaPropiedades()
			PropTPECODIGO = Nothing
			PropTPEDESCRIPCION = Nothing
			PropTPEABREVIA = Nothing
			PropTPEESTADO = Nothing
		End Sub

	End Class
End Namespace
