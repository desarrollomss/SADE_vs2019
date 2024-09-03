Imports System

Namespace BE

	<Serializable()> _
	Public Class CCOMODALIDADFUGAINCIDENCIA_BE

		Private intmodcodigo As Nullable(Of Integer)
		Private vchmoddescripcion As String

		Public Property PropMODCODIGO() As Nullable(Of Integer)
		  Get
			  Return intmodcodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intmodcodigo = value
		  End Set
		End Property
		Public Property PropMODDESCRIPCION() As String
		  Get
			  Return vchmoddescripcion
		  End Get
		  Set(ByVal value As String)
			  vchmoddescripcion = value
		  End Set
		End Property

		Public Sub New()
			LimpiaPropiedades()
		End Sub

		Public Sub LimpiaPropiedades()
			PropMODCODIGO = Nothing
			PropMODDESCRIPCION = Nothing
		End Sub

	End Class
End Namespace
