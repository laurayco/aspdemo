CREATE VIEW [dbo].[SalesData]
	AS
		Select
			POS_Data.StoreNbr as StoreNumber,
			POS_Data.WhseNbr as WarehouseNumber,
			((POS_Data.[201247]+POS_Data.[201248]+POS_Data.[201249]+POS_Data.[201250])/4) As WeeklySales,
			(
				Select SUM(dat.[201251])
				from POS_Data as dat
				WHERE (dat.[Data Type]='Curr Str On Hand Qty' OR dat.[Data Type] = 'Curr Str In Transit Qty')
				AND dat.[StoreNbr]=POS_Data.StoreNbr
			) as OnHand,
			(
				Select SUM(dat.[201251])
				from POS_Data as dat
				WHERE (dat.[Data Type]='Curr Str In Whse Qty' OR dat.[Data Type] = 'Curr Str On Order Qty')
				AND dat.[StoreNbr]=POS_Data.StoreNbr
			) as OnOrder
		From POS_Data
		WHERE POS_Data.[Data Type] = 'POS Qty'