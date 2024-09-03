Imports System

Namespace BE

	<Serializable()> _
	Public Class CCODETALLESECUENCIASERVICIO_BE

		Private smldsscodigo As Nullable(Of Int16)
		Private smlssecodigo As Nullable(Of Int16)
		Private smldsssecuencia As Nullable(Of Int16)
		Private smldssdisponible As Nullable(Of Int16)
		Private smlmaucodigo As Nullable(Of Int16)
		Private smlturcodigo As Nullable(Of Int16)

		Public Property PropDSSCODIGO() As Nullable(Of Int16)
		  Get
			  Return smldsscodigo
		  End Get
		  Set(ByVal value As Nullable(Of Int16))
			  smldsscodigo = value
		  End Set
		End Property
		Public Property PropSSECODIGO() As Nullable(Of Int16)
		  Get
			  Return smlssecodigo
		  End Get
		  Set(ByVal value As Nullable(Of Int16))
			  smlssecodigo = value
		  End Set
		End Property
		Public Property PropDSSSECUENCIA() As Nullable(Of Int16)
		  Get
			  Return smldsssecuencia
		  End Get
		  Set(ByVal value As Nullable(Of Int16))
			  smldsssecuencia = value
		  End Set
		End Property
		Public Property PropDSSDISPONIBLE() As Nullable(Of Int16)
		  Get
			  Return smldssdisponible
		  End Get
		  Set(ByVal value As Nullable(Of Int16))
			  smldssdisponible = value
		  End Set
		End Property
		Public Property PropMAUCODIGO() As Nullable(Of Int16)
		  Get
			  Return smlmaucodigo
		  End Get
		  Set(ByVal value As Nullable(Of Int16))
			  smlmaucodigo = value
		  End Set
		End Property
		Public Property PropTURCODIGO() As Nullable(Of Int16)
		  Get
			  Return smlturcodigo
		  End Get
		  Set(ByVal value As Nullable(Of Int16))
			  smlturcodigo = value
		  End Set
		End Property

		Public Sub New()
			LimpiaPropiedades()
		End Sub

		Public Sub LimpiaPropiedades()
			PropDSSCODIGO = Nothing
			PropSSECODIGO = Nothing
			PropDSSSECUENCIA = Nothing
			PropDSSDISPONIBLE = Nothing
			PropMAUCODIGO = Nothing
			PropTURCODIGO = Nothing
		End Sub

	End Class
End Namespace
