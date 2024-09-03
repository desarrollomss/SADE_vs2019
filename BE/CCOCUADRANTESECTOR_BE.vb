Imports System

Namespace BE

	<Serializable()> _
	Public Class CCOCUADRANTESECTOR_BE

		Private vchcuacodigo As Nullable(Of Integer)
		Private intseccodigo As Nullable(Of Integer)
		Private vchcuadescripcion As String
		Private intcomcodigo As Nullable(Of Integer)
		Private intcuaestado As Nullable(Of Integer)

		Public Property PropCUACODIGO() As Nullable(Of Integer)
		  Get
			  Return vchcuacodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  vchcuacodigo = value
		  End Set
		End Property
		Public Property PropSECCODIGO() As Nullable(Of Integer)
		  Get
			  Return intseccodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intseccodigo = value
		  End Set
		End Property
		Public Property PropCUADESCRIPCION() As String
		  Get
			  Return vchcuadescripcion
		  End Get
		  Set(ByVal value As String)
			  vchcuadescripcion = value
		  End Set
		End Property
		Public Property PropCOMCODIGO() As Nullable(Of Integer)
		  Get
			  Return intcomcodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intcomcodigo = value
		  End Set
		End Property
		Public Property PropCUAESTADO() As Nullable(Of Integer)
		  Get
			  Return intcuaestado
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intcuaestado = value
		  End Set
		End Property

		Public Sub New()
			LimpiaPropiedades()
		End Sub

		Public Sub LimpiaPropiedades()
			PropCUACODIGO = Nothing
			PropSECCODIGO = Nothing
			PropCUADESCRIPCION = Nothing
			PropCOMCODIGO = Nothing
			PropCUAESTADO = Nothing
		End Sub

	End Class
End Namespace
