Imports System

Namespace BE

	<Serializable()> _
	Public Class CCOPRIORIDADINCIDENCIA_BE

		Private intpricodigo As Nullable(Of Integer)
		Private vchpridescripcion As String
		Private intpritiempoderi As Nullable(Of Integer)
		Private intpritiempoasig As Nullable(Of Integer)
		Private intpritiempoaten As Nullable(Of Integer)
		Private intpriestado As Nullable(Of Integer)

		Public Property PropPRICODIGO() As Nullable(Of Integer)
		  Get
			  Return intpricodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intpricodigo = value
		  End Set
		End Property
		Public Property PropPRIDESCRIPCION() As String
		  Get
			  Return vchpridescripcion
		  End Get
		  Set(ByVal value As String)
			  vchpridescripcion = value
		  End Set
		End Property
		Public Property PropPRITIEMPODERI() As Nullable(Of Integer)
		  Get
			  Return intpritiempoderi
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intpritiempoderi = value
		  End Set
		End Property
		Public Property PropPRITIEMPOASIG() As Nullable(Of Integer)
		  Get
			  Return intpritiempoasig
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intpritiempoasig = value
		  End Set
		End Property
		Public Property PropPRITIEMPOATEN() As Nullable(Of Integer)
		  Get
			  Return intpritiempoaten
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intpritiempoaten = value
		  End Set
		End Property
		Public Property PropPRIESTADO() As Nullable(Of Integer)
		  Get
			  Return intpriestado
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intpriestado = value
		  End Set
		End Property

		Public Sub New()
			LimpiaPropiedades()
		End Sub

		Public Sub LimpiaPropiedades()
			PropPRICODIGO = Nothing
			PropPRIDESCRIPCION = Nothing
			PropPRITIEMPODERI = Nothing
			PropPRITIEMPOASIG = Nothing
			PropPRITIEMPOATEN = Nothing
			PropPRIESTADO = Nothing
		End Sub

	End Class
End Namespace
