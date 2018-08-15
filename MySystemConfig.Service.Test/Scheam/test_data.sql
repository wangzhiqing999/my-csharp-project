INSERT INTO [dbo].[sc_system_config_type]
           ([config_type_code]
           ,[config_type_name]
           ,[config_type_class_name])
SELECT 'TEST_STRING',  	'�򵥲���String',  		'System.String'																UNION ALL
SELECT 'TEST_INT32',  	'�򵥲���Int32',  		'System.Int32'																UNION ALL
SELECT 'TEST_OBJ',  	'�򵥲����Զ������',  	'MySystemConfig.Service.Test.MyTestUser,MySystemConfig.Service.Test'
GO






INSERT INTO [dbo].[sc_system_config_type]
           ([config_type_code]
           ,[config_type_name]
           ,[config_type_class_name])
SELECT 'TEST_DICTIONARY_1',  	'�򵥲���Dictionary',  	'System.Collections.Generic.Dictionary`2[System.String,System.Object]'
GO





INSERT INTO [dbo].[sc_system_config_property]
           ([config_type_code]
           ,[property_name]
           ,[property_datatype]
           ,[property_desc]
           ,[display_order]
		   ,[is_search_able])
SELECT 'TEST_DICTIONARY_1',  'Name',		'System.String',  		'����',1,1		UNION  ALL
SELECT 'TEST_DICTIONARY_1',  'Age',			'System.Int32',  		'����',2,1		UNION  ALL
SELECT 'TEST_DICTIONARY_1',  'Address',		'System.String',		'��ַ',3,1		UNION  ALL
SELECT 'TEST_DICTIONARY_1',  'IsEmployee',	'System.Boolean',		'�Ƿ��Ա',4,1
GO

