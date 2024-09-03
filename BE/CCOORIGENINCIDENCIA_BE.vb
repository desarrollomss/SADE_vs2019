Imports System

Namespace BE

	<Serializable()> _
	Public Class CCOORIGENINCIDENCIA_BE

		Private intoricodigo As Nullable(Of Integer)
		Private vchoridescripcion As String
		Private intoriestado As Nullable(Of Integer)

		Public Property PropORICODIGO() As Nullable(Of Integer)
		  Get
			  Return intoricodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intoricodigo = value
		  End Set
		End Property
		Public Property PropORIDESCRIPCION() As String
		  Get
			  Return vchoridescripcion
		  End Get
		  Set(ByVal value As String)
			  vchoridescripcion = value
		  End Set
		End Property
		Public Property PropORIESTADO() As Nullable(Of Integer)
		  Get
			  Return intoriestado
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intoriestado = value
		  End Set
		End Property

		Public Sub New()
			LimpiaPropiedades()
		End Sub

		Public Sub LimpiaPropiedades()
			PropORICODIGO = Nothing
			PropORIDESCRIPCION = Nothing
			PropORIESTADO = Nothing
		End Sub

	End Class
End Namespace
