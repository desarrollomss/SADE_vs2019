Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Data
Imports Framework.Entidades
Imports Framework.Util
Imports System.Configuration
Imports IBM.Data.DB2
' TipoEntidadColeccion
Namespace Datos
    'Implements ICollection.IsSynchronized
    <Serializable()> _
    Public MustInherit Class DAOBase(Of TipoEntidad As EntidadBase)
        Implements IDisposable
        Private _Conexion As DbConnection
        Protected ReadOnly Property Conexion() As DbConnection
            Get
                Return _Conexion
            End Get
        End Property

#Region "Nombre de Conexion, Nombre de Tabla y Nombre de Esquema"
        Private _NombreDeEsquema As String

        ''' <summary>
        ''' Propiedad solo de lectura que permite acceder al nombre del esquema
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected ReadOnly Property NombreDeEsquema() As String
            Get
                Return _NombreDeEsquema
            End Get
        End Property

        ''' <summary>
        ''' Nombre de la tabla relacionada con el dao
        ''' </summary>
        ''' <remarks></remarks>
        Private _NombreDeTabla As String

        ''' <summary>
        ''' Propiedad solo de lectura que permite acceder al nombre de la tabla
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected ReadOnly Property NombreDeTabla() As String
            Get
                Return _NombreDeTabla
            End Get
        End Property

        ''' <summary>
        ''' Nombre de la conexion por defecto que empleara el dao
        ''' </summary>
        ''' <remarks></remarks>
        Private _NombreDeConexion As String

        ''' <summary>
        ''' Propiedad solo de lectura que permite acceder al nombre de la conexion por defecto para el dao
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected ReadOnly Property NombreDeConexion() As String
            Get
                Return _NombreDeConexion
            End Get
        End Property
#End Region

        Sub New(ByVal nombreDeConexion As String, ByVal nombreDeEsquema As String, ByVal nombreDeTabla As String)
            Me._NombreDeConexion = nombreDeConexion
            Me._NombreDeEsquema = nombreDeEsquema
            Me._NombreDeTabla = nombreDeTabla
            Dim cadenaDeConexion As String = ConfigurationManager.ConnectionStrings(nombreDeConexion).ConnectionString
               _Conexion = New DB2Connection()
               _Conexion.ConnectionString = cadenaDeConexion
        End Sub

#Region "Transacciones"
        Public Function IniciarTransaccion() As DbTransaction
            Conexion.Close()
            Conexion.Open()
            Return Conexion.BeginTransaction
        End Function

        Public Sub AcometerCambios(ByVal transaccion As DbTransaction)
            Try
                transaccion.Commit()
                Conexion.Close()
            Catch ex As DbException
                DeshacerCambios(transaccion)
            End Try
        End Sub

        Public Sub DeshacerCambios(ByVal transaccion As DbTransaction)
            transaccion.Rollback()
            Conexion.Close()
        End Sub
#End Region

        Protected Function Ejecutar(ByVal comando As DbCommand) As Integer
            comando.Connection = Conexion
            comando.Connection.Open()
            Ejecutar = comando.ExecuteNonQuery()
            comando.Connection.Close()
        End Function

        Protected Sub Ejecutar(ByVal comando As DbCommand, ByVal transaccion As DbTransaction)
            comando.Transaction = transaccion
            comando.Connection = transaccion.Connection
            comando.ExecuteNonQuery()
        End Sub

        Protected Function EjecutarEscalar(ByVal comando As DbCommand) As Object
            comando.Connection = Conexion
            comando.Connection.Open()
            EjecutarEscalar = comando.ExecuteScalar()
            comando.Connection.Close()
        End Function

        Protected Function EjecutarEscalar(ByVal comando As DbCommand, ByVal transaccion As DbTransaction) As Object
            comando.Transaction = transaccion
            comando.Connection = transaccion.Connection
            Return comando.ExecuteScalar
        End Function

        Protected Function EjecutarReader(ByVal comando As DbCommand) As DbDataReader
            comando.Connection = Conexion
            comando.Connection.Open()
            Dim dataReader As IDataReader = comando.ExecuteReader
            Return dataReader
        End Function

        Protected Function EjecutarReader(ByVal comando As DbCommand, ByVal transaccion As DbTransaction) As DbDataReader
            comando.Transaction = transaccion
            comando.Connection = transaccion.Connection
            Dim dataReader As IDataReader = comando.ExecuteReader
            Return dataReader
        End Function

        Protected Function EjecutarDataTable(ByVal comando As DbCommand) As DataTable
            comando.Connection = Conexion
            Dim dataTable As New DataTable
            Dim dataAdapter As DbDataAdapter = New DB2DataAdapter
            dataAdapter.SelectCommand = comando
            dataAdapter.Fill(dataTable)
            Return dataTable
        End Function

        Protected Function EjecutarDataSet(ByVal comando As DbCommand) As DataSet
            comando.Connection = Conexion
            Dim dataSet As New DataSet
            Dim dataAdapter As DbDataAdapter = New DB2DataAdapter
            dataAdapter.SelectCommand = comando
            dataAdapter.Fill(dataSet)
            Return dataSet
        End Function

        Protected Function CrearComando(ByVal nombreDeProcedimiento As String, ByVal ParamArray parametrosEnOrden() As Object) As DbCommand
            Dim comando As DbCommand = New DB2Command
            comando.CommandText = nombreDeProcedimiento
            comando.CommandType = CommandType.StoredProcedure
            For Each valor As Object In parametrosEnOrden
                Dim dbParameter As DbParameter = New DB2Parameter
                dbParameter.Value = valor
                comando.Parameters.Add(dbParameter)
            Next
            Return comando
        End Function

        Protected Function CrearComando(ByVal nombreDeProcedimiento As String, ByVal entidad As TipoEntidad, ByVal lstp As DB2Parameter()) As DbCommand
            Dim comando As DbCommand = New DB2Command
            comando.CommandText = nombreDeProcedimiento
            comando.CommandType = CommandType.StoredProcedure
            For Each dbParameter As DbParameter In lstp
                'Dim dbParameter As DbParameter = New DB2Parameter
                'dbParameter.Value = propiedad.Value
                comando.Parameters.Add(dbParameter)
            Next
            Return comando
        End Function

        Protected Sub cerrarConexion()
            Conexion.Close()
        End Sub

#Region " IDisposable Support "
        Private disposedValue As Boolean = False        ' Para detectar llamadas redundantes
        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: Liberar recursos no administrados cuando se llamen explícitamente
                    If Not Conexion.State = ConnectionState.Closed Then
                        Conexion.Close()
                    End If
                End If

                ' TODO: Liberar recursos no administrados compartidos
            End If
            Me.disposedValue = True
        End Sub

        ' Visual Basic agregó este código para implementar correctamente el modelo descartable.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' No cambie este código. Coloque el código de limpieza en Dispose (ByVal que se dispone como Boolean).
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class
End Namespace