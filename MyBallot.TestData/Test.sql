INSERT INTO [dbo].[ballot_type](
	[ballot_type_code],[ballot_type_name]
) VALUES (
	'STOCK',  '��Ʊ����ͶƱ'
)
GO


INSERT INTO [dbo].[ballot_type_detail](
	[ballot_type_detail_code],[ballot_type_code],[ballot_type_detail_title],[default_ballot_value]
)
SELECT 'STOCK_UP', 'STOCK', '����', 100		UNION  ALL
SELECT 'STOCK_DOWN', 'STOCK', '����', 100
GO

