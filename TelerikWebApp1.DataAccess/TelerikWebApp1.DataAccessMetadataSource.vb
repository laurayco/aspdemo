Imports Telerik.OpenAccess.Metadata
Imports Telerik.OpenAccess.Metadata.Fluent

Public Class TelerikWebApp1DataAccessMetadataSource
    Inherits FluentMetadataSource

    Protected Overrides Function PrepareMapping() As System.Collections.Generic.IList(Of Telerik.OpenAccess.Metadata.Fluent.MappingConfiguration)

        ' Getting Started with the Fluent Mapping API
        ' http://documentation.telerik.com/openaccess-orm/developers-guide/code-only-mapping/fluent-mapping-overview

        Dim configurations As List(Of MappingConfiguration) = New List(Of MappingConfiguration)()

        Dim productConfiguration As MappingConfiguration(Of Product) = New MappingConfiguration(Of Product)()

        productConfiguration.MapType(Function(x) New With {.ID = x.ID, .Name = x.ProductName, .Price = x.Price}).ToTable("Products")
        productConfiguration.HasProperty(Function(x) x.ID).IsIdentity(KeyGenerator.Autoinc)
        productConfiguration.FieldNamingRules.AddPrefix = "_"

        configurations.Add(productConfiguration)
        Return configurations
    End Function



End Class
