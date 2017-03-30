INSERT INTO [dbo].[sc_system_config_type]
           ([config_type_code]
           ,[config_type_name]
           ,[config_type_class_name])
SELECT 'TEST_STRING',  	'简单测试String',  		'System.String'																UNION ALL
SELECT 'TEST_INT32',  	'简单测试Int32',  		'System.Int32'																UNION ALL
SELECT 'TEST_OBJ',  	'简单测试自定义对象',  	'MySystemConfig.Service.Test.MyTestUser,MySystemConfig.Service.Test'
GO

