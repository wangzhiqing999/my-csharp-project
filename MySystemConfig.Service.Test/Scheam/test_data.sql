INSERT INTO [dbo].[sc_system_config_type]
           ([config_type_code]
           ,[config_type_name]
           ,[config_type_class_name])
SELECT 'TEST_STRING',  	'�򵥲���String',  		'System.String'																UNION ALL
SELECT 'TEST_INT32',  	'�򵥲���Int32',  		'System.Int32'																UNION ALL
SELECT 'TEST_OBJ',  	'�򵥲����Զ������',  	'MySystemConfig.Service.Test.MyTestUser,MySystemConfig.Service.Test'
GO

