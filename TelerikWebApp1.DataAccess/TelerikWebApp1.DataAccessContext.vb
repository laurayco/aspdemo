Imports Telerik.OpenAccess
Imports Telerik.OpenAccess.Metadata

Partial Public Class TelerikWebApp1DataAccessContext
    Inherits OpenAccessContext

    Shared metadataContainer As MetadataContainer = (New TelerikWebApp1DataAccessMetadataSource()).GetModel()
    Shared backendConfiguration As BackendConfiguration = New BackendConfiguration() With
        {
            .Backend = "mssql"
        }

    Public Const DbConnection As String = "connectionId"

    Public Sub New()
        MyBase.New(DbConnection, backendConfiguration, metadataContainer)
    End Sub

    Public ReadOnly Property Products() As IQueryable(Of Product)
        Get
            Return Me.GetAll(Of Product)()
        End Get
    End Property

    Public Sub UpdateSchema()
        Dim handler = Me.GetSchemaHandler()
        Dim script As String = Nothing
        Try
            script = handler.CreateUpdateDDLScript(Nothing)
        Catch
            Dim throwException As Boolean = False
            Try
                handler.CreateDatabase()
                script = handler.CreateDDLScript()
            Catch
                throwException = True
            End Try
            If throwException Then
                Throw
            End If
        End Try

        If String.IsNullOrEmpty(script) = False Then
            handler.ExecuteDDLScript(script)
        End If
    End Sub
End Class
