INSERT INTO [dbo].[ballot_type](
	[ballot_type_code],[ballot_type_name]
) VALUES (
	'STOCK',  '股票行情投票'
)
GO


INSERT INTO [dbo].[ballot_type_detail](
	[ballot_type_detail_code],[ballot_type_code],[ballot_type_detail_title],[default_ballot_value]
)
SELECT 'STOCK_UP', 'STOCK', '看多', 100		UNION  ALL
SELECT 'STOCK_DOWN', 'STOCK', '看空', 100
GO

