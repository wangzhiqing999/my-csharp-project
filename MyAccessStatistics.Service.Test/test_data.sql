INSERT INTO [mas_access_type](
	[access_type_code],	[access_type_name]
) VALUES (
	'TEST', '用于测试的文档类型'
);


INSERT INTO [mas_access_detail](
	[access_type_code],[detail_code],[detail_name]
) VALUES (
	'TEST', '1', '测试文档'
);





INSERT INTO [mas_access_type](
	[access_type_code],	[access_type_name]
) 
SELECT  'TEST_MODULES', '用于测试的模块'
;

INSERT INTO [mas_access_detail](
	[access_type_code],[detail_code],[detail_name]
)
SELECT 'TEST_MODULES', 'HOME', 		'首页模块'	UNION ALL
SELECT 'TEST_MODULES', 'NEWS', 		'新闻模块'	UNION ALL
SELECT 'TEST_MODULES', 'DOCS', 		'文档模块'	UNION ALL
SELECT 'TEST_MODULES', 'SYSTEM',	'系统模块'	UNION ALL
SELECT 'TEST_MODULES', 'BUSINESS', 	'业务模块'
;

