Imports System.Data
Imports IBM.Data.DB2
Imports System.Configuration

Namespace AccesoDatos
    <Serializable()> _
    Public Class DB2_Conexion

        Public Shared Function f_ConeccionDB2() As String
            'Return System.Configuration.ConfigurationManager.AppSettings("ConnectionString")
            Return System.Configuration.ConfigurationManager.ConnectionStrings("cadSADE").ConnectionString
        End Function

        Public Shared Function GetConnection() As DB2Connection
            ' Get the connection string from the configuration file
            Dim connectionString As String = f_ConeccionDB2()

            ' Create a new connection object
            Dim connection As New DB2Connection(connectionString)

            ' Open the connection, and return it
            connection.Open()
            Return connection

        End Function

        '--- Sobrecarga de conexion server DB2 con parametro
        Public Shared Function f_ConeccionDB2(ByVal srvDB2 As String) As String
            Return ConfigurationManager.ConnectionStrings(srvDB2).ConnectionString
        End Function

        Public Shared Function GetConnection(ByVal srvDB2 As String) As DB2Connection
            ' Get the connection string from the configuration file
            Dim connectionString As String = f_ConeccionDB2(srvDB2)

            ' Create a new connection object
            Dim connection As New DB2Connection(connectionString)

            ' Open the connection, and return it
            connection.Open()
            Return connection

        End Function

    End Class
End Namespace
