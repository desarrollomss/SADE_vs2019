Imports IBM.Data.DB2
Imports Framework.Entidades
Imports System.Data.Common
Namespace Util
    <Serializable()> _
    Public Class ConvertidorUtil

        Public Shared Function DeReaderAEntidad(Of TipoEntidad)(ByVal dataReader As DbDataReader) As TipoEntidad
            Dim entidad As Object = RefleccionUtil.CrearObjeto(Of TipoEntidad)()
            Dim cantidadDeColumnas As Integer = dataReader.FieldCount - 1
            For ordinal As Integer = 0 To cantidadDeColumnas
                RefleccionUtil.EjecutarSub(entidad, "EstablecerPropiedad", dataReader.GetName(ordinal), dataReader.GetValue(ordinal))
            Next
            Return entidad
        End Function

        Public Shared Function DeReaderAColeccion(Of TipoEntidad, TipoColeccion)(ByVal dataReader As DbDataReader) As TipoColeccion
            Dim coleccion As Object = RefleccionUtil.CrearObjeto(Of TipoColeccion)()
            While dataReader.Read
                coleccion.Add(DeReaderAEntidad(Of TipoEntidad)(dataReader))
            End While
            Return coleccion
        End Function

        Public Shared Function DeReaderADataTable(ByVal dataReader As DbDataReader) As DataTable
            Dim dataTable As New DataTable

            Dim cantidadDeColumnas As Integer = dataReader.FieldCount - 1

            For ordinal As Integer = 0 To cantidadDeColumnas
                Dim columna As New DataColumn
                columna.AllowDBNull = True
                columna.ColumnName = dataReader.GetName(ordinal)
                dataTable.Columns.Add(columna)
            Next

            While dataReader.Read
                Dim newRow As DataRow = dataTable.NewRow
                For ordinal As Integer = 0 To cantidadDeColumnas
                    newRow.Item(dataReader.GetName(ordinal)) = dataReader.GetValue(ordinal)
                Next
                dataTable.Rows.Add(newRow)
            End While
            dataTable.AcceptChanges()
            Return dataTable
        End Function

    End Class
End Namespace
