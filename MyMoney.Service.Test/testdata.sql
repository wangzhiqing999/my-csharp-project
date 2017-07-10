INSERT INTO dbo.mm_account_operation_type (
	operation_type_code,operation_type_name,change_direction
)
SELECT 'IN',	'入金',		1		UNION ALL
SELECT 'OUT',	'出金',		-1		UNION ALL
SELECT 'BUY',	'买入',		-1		UNION ALL
SELECT 'SELL',	'卖出',		1
;