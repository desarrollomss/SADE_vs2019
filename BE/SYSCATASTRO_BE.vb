Imports System

Namespace BE

    <Serializable()> _
    Public Class SYSCATASTRO_BE
        Private p_saCHRTIPO As String
        Private p_saVCHDESCRIPCION As String
        Private p_sastrdesvaloropc1 As String
        Private p_sastrdesvaloropc2 As String

        Public Property p_CHRTIPO As String
            Get
                Return p_saCHRTIPO
            End Get
            Set(ByVal value As String)
                p_saCHRTIPO = value
            End Set
        End Property
        Public Property p_VCHDESCRIPCION As String
            Get
                Return p_saVCHDESCRIPCION
            End Get
            Set(ByVal value As String)
                p_saVCHDESCRIPCION = value
            End Set
        End Property
        Public Property p_strdesvaloropc1 As String
            Get
                Return p_sastrdesvaloropc1
            End Get
            Set(ByVal value As String)
                p_sastrdesvaloropc1 = value
            End Set
        End Property
        Public Property p_strdesvaloropc2 As String
            Get
                Return p_sastrdesvaloropc2
            End Get
            Set(ByVal value As String)
                p_sastrdesvaloropc2 = value
            End Set
        End Property

        Public Sub New()
            LimpiaPropiedades()
        End Sub

        Public Sub LimpiaPropiedades()
            p_CHRTIPO = Nothing
            p_VCHDESCRIPCION = Nothing
            p_strdesvaloropc1 = Nothing
            p_strdesvaloropc2 = Nothing
        End Sub

    End Class
End Namespace
