INSERT INTO [dbo].[mul_update_log_category](
	[category_code],[category_name]
) 
SELECT 'TEST_INSERT', '测试插入' 	UNION  ALL
SELECT 'TEST_UPDATE', '测试更新' 	UNION  ALL
SELECT 'TEST_DELETE', '测试删除'
GO

