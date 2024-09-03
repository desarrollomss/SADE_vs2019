Imports System

Namespace BE

	<Serializable()> _
	Public Class CCOCLASEINCIDENCIA_BE

		Private intcincodigo As Nullable(Of Integer)
		Private vchcindescripcion As String
		Private vchcinabrevia As String
		Private intcinestado As Nullable(Of Integer)

		Public Property PropCINCODIGO() As Nullable(Of Integer)
		  Get
			  Return intcincodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intcincodigo = value
		  End Set
		End Property
		Public Property PropCINDESCRIPCION() As String
		  Get
			  Return vchcindescripcion
		  End Get
		  Set(ByVal value As String)
			  vchcindescripcion = value
		  End Set
		End Property
		Public Property PropCINABREVIA() As String
		  Get
			  Return vchcinabrevia
		  End Get
		  Set(ByVal value As String)
			  vchcinabrevia = value
		  End Set
		End Property
		Public Property PropCINESTADO() As Nullable(Of Integer)
		  Get
			  Return intcinestado
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intcinestado = value
		  End Set
		End Property

		Public Sub New()
			LimpiaPropiedades()
		End Sub

		Public Sub LimpiaPropiedades()
			PropCINCODIGO = Nothing
			PropCINDESCRIPCION = Nothing
			PropCINABREVIA = Nothing
			PropCINESTADO = Nothing
		End Sub

	End Class
End Namespace
