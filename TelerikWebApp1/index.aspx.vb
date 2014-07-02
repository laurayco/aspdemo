Imports Telerik.Web.UI
Imports System.Data

Partial Class Index
    Inherits System.Web.UI.Page

    Protected Sub OnCalculateClick(ByVal sender As Object, ByVal e As EventArgs)
        RunCalculations()
    End Sub

    Protected Sub RunCalculations()
        Dim query = String.Format("With data as (Select " &
                        "SalesData.StoreNumber as StoreNumber," &
                        "SalesData.WarehouseNumber as WareHouseNumber," &
                        "SalesData.WeeklySales, " &
                        "Case When SalesData.OnHand>0 Then 0 Else {0} END As Minimum," &
                        "Case When SalesData.WeeklySales>(SalesData.OnHand+SalesData.OnOrder) Then {1} Else 0 END As SalesCatchUp," &
                        "Case When SalesData.WeeklySales>{2} Then {3} Else 0 End As SalesAmplify " &
                    "From SalesData) Select " &
                        "StoreNumber, " &
                        "WareHouseNumber, " &
                        "WeeklySales, " &
                        "Minimum, " &
                        "SalesCatchUp, " &
                        "SalesAmplify, " &
                    "(Minimum+SalesCatchup+SalesAmplify) As AmountToOrder " &
                    "From data", Latency.Value, Redirects.Value, HiSales.Value, Bandwidth.Value)
        DataSource.SelectCommand = query
    End Sub

    Protected Overrides Sub OnLoad(ByVal e As EventArgs)
        MyBase.OnLoad(e)
        RunCalculations()
    End Sub

End Class
