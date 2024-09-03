Imports System

Namespace BE

	<Serializable()> _
	Public Class CCOCOMISARIA_BE

		Private intcomcodigo As Nullable(Of Integer)
		Private vchcomdescripcion As String
		Private intcomestado As Nullable(Of Integer)

		Public Property PropCOMCODIGO() As Nullable(Of Integer)
		  Get
			  Return intcomcodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intcomcodigo = value
		  End Set
		End Property
		Public Property PropCOMDESCRIPCION() As String
		  Get
			  Return vchcomdescripcion
		  End Get
		  Set(ByVal value As String)
			  vchcomdescripcion = value
		  End Set
		End Property
		Public Property PropCOMESTADO() As Nullable(Of Integer)
		  Get
			  Return intcomestado
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intcomestado = value
		  End Set
		End Property

		Public Sub New()
			LimpiaPropiedades()
		End Sub

		Public Sub LimpiaPropiedades()
			PropCOMCODIGO = Nothing
			PropCOMDESCRIPCION = Nothing
			PropCOMESTADO = Nothing
		End Sub

	End Class
End Namespace
