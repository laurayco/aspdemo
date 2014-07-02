Use MookstrDB;
With data as (Select
	SalesData.StoreNumber as StoreNumber,
	SalesData.WarehouseNumber as WareHouseNumber,
	SalesData.WeeklySales,
	Case When SalesData.OnHand>0 Then 0 Else 1 END As Minimum,
	Case When SalesData.WeeklySales>(SalesData.OnHand+SalesData.OnOrder) Then 1 Else 0 END As SalesCatchUp,
	Case When SalesData.WeeklySales>0.5 Then 1 Else 0 End As SalesAmplify
From SalesData) Select
	StoreNumber,
	WareHouseNumber,
	WeeklySales,
	Minimum,
	SalesCatchUp,
	SalesAmplify,
	(Minimum+SalesCatchup+SalesAmplify) As AmountToOrder