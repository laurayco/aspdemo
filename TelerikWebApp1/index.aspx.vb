Imports Telerik.Web.UI
Imports System.Data

Partial Class Index
    Inherits System.Web.UI.Page

    Dim HighSalesThreshold As Double = 0.5
    Dim HighSalesBoost As Integer = 1
    Dim TransitBoost As Integer = 1
    Dim MinimumStock As Integer = 1
    Dim ConnectionString As String = "Server=.\SQLEXPRESS;Database=MookstrDB;Provider=SQLOLEDB;Trusted_Connection=Yes;"

    Protected Function GetConnection()
        Dim r = New OleDb.OleDbConnection(ConnectionString)
        r.Open()
        Return r
    End Function

    Protected Function ReadQuery(ByRef conn, ByVal query)
        Dim cmd = New OleDb.OleDbCommand(query, conn)
        Return cmd.ExecuteReader()
    End Function

    Protected Sub RunCalculations()
        Dim dbconn = GetConnection()
        Dim query = "With data as (Select" &
                        "SalesData.StoreNumber as StoreNumber," &
                        "SalesData.WarehouseNumber as WareHouseNumber," &
                        "SalesData.WeeklySales, " &
                        "Case When SalesData.OnHand>0 Then 0 Else 1 END As Minimum," &
                        "Case When SalesData.WeeklySales>(SalesData.OnHand+SalesData.OnOrder) Then 1 Else 0 END As SalesCatchUp," &
                        "Case When SalesData.WeeklySales>0.5 Then 1 Else 0 End As SalesAmplify " &
                    "From SalesData) Select" &
                        "StoreNumber, " &
                        "WareHouseNumber, " &
                        "WeeklySales, " &
                        "Minimum, " &
                        "SalesCatchUp, " &
                        "SalesAmplify, " &
                    "(Minimum+SalesCatchup+SalesAmplify) As AmountToOrder"
        Dim dbread = ReadQuery(dbconn, query)
        store_info.DataSource = dbread
        store_info.DataBind()
        dbread.Close()
    End Sub

    Protected Overrides Sub OnLoad(ByVal e As EventArgs)
        MyBase.OnLoad(e)
        RunCalculations()
    End Sub

End Class
