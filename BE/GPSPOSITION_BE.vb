Imports System

Namespace BE

	<Serializable()> _
	Public Class GPSPOSITION_BE

		Private intnissi As Nullable(Of Integer)
		Private declatitude As Nullable(Of Decimal)
		Private declongitude As Nullable(Of Decimal)
		Private tmsdatetime As DateTime
		Private tmsdatetime2 As DateTime
		Private smlstatus As Nullable(Of Int16)
		Private vchuser As String
		Private smlunittype As Nullable(Of Int16)
		Private vchdescription As String
		Private intprecision As Nullable(Of Integer)
		Private vchtrigger As String
		Private vchvelocidad_hor As String
		Private vchdireccion As String
		Private smlunitsec As Nullable(Of Int16)

		Public Property PropNISSI() As Nullable(Of Integer)
		  Get
			  Return intnissi
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intnissi = value
		  End Set
		End Property
		Public Property PropLATITUDE() As Nullable(Of Decimal)
		  Get
			  Return declatitude
		  End Get
		  Set(ByVal value As Nullable(Of Decimal))
			  declatitude = value
		  End Set
		End Property
		Public Property PropLONGITUDE() As Nullable(Of Decimal)
		  Get
			  Return declongitude
		  End Get
		  Set(ByVal value As Nullable(Of Decimal))
			  declongitude = value
		  End Set
		End Property
		Public Property PropDATETIME() As DateTime
		  Get
			  Return tmsdatetime
		  End Get
		  Set(ByVal value As DateTime)
			  tmsdatetime = value
		  End Set
		End Property
		Public Property PropDATETIME2() As DateTime
		  Get
			  Return tmsdatetime2
		  End Get
		  Set(ByVal value As DateTime)
			  tmsdatetime2 = value
		  End Set
		End Property
		Public Property PropSTATUS() As Nullable(Of Int16)
		  Get
			  Return smlstatus
		  End Get
		  Set(ByVal value As Nullable(Of Int16))
			  smlstatus = value
		  End Set
		End Property
		Public Property PropUSER() As String
		  Get
			  Return vchuser
		  End Get
		  Set(ByVal value As String)
			  vchuser = value
		  End Set
		End Property
		Public Property PropUNITTYPE() As Nullable(Of Int16)
		  Get
			  Return smlunittype
		  End Get
		  Set(ByVal value As Nullable(Of Int16))
			  smlunittype = value
		  End Set
		End Property
		Public Property PropDESCRIPTION() As String
		  Get
			  Return vchdescription
		  End Get
		  Set(ByVal value As String)
			  vchdescription = value
		  End Set
		End Property
		Public Property PropPRECISION() As Nullable(Of Integer)
		  Get
			  Return intprecision
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intprecision = value
		  End Set
		End Property
		Public Property PropTRIGGER() As String
		  Get
			  Return vchtrigger
		  End Get
		  Set(ByVal value As String)
			  vchtrigger = value
		  End Set
		End Property
		Public Property PropVELOCIDAD_HOR() As String
		  Get
			  Return vchvelocidad_hor
		  End Get
		  Set(ByVal value As String)
			  vchvelocidad_hor = value
		  End Set
		End Property
		Public Property PropDIRECCION() As String
		  Get
			  Return vchdireccion
		  End Get
		  Set(ByVal value As String)
			  vchdireccion = value
		  End Set
		End Property
		Public Property PropUNITSEC() As Nullable(Of Int16)
		  Get
			  Return smlunitsec
		  End Get
		  Set(ByVal value As Nullable(Of Int16))
			  smlunitsec = value
		  End Set
		End Property

		Public Sub New()
			LimpiaPropiedades()
		End Sub

		Public Sub LimpiaPropiedades()
			PropNISSI = Nothing
			PropLATITUDE = Nothing
			PropLONGITUDE = Nothing
			PropDATETIME = Now.Date
			PropDATETIME2 = Now.Date
			PropSTATUS = Nothing
			PropUSER = Nothing
			PropUNITTYPE = Nothing
			PropDESCRIPTION = Nothing
			PropPRECISION = Nothing
			PropTRIGGER = Nothing
			PropVELOCIDAD_HOR = Nothing
			PropDIRECCION = Nothing
			PropUNITSEC = Nothing
		End Sub

	End Class
End Namespace
