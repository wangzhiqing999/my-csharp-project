

INSERT INTO mca_service_module(
	module_code,	module_name
)
SELECT 'TestModule1', '测试模块1'	UNION ALL
SELECT 'TestModule2', '测试模块2'	UNION ALL
SELECT 'TestModule3', '测试模块3'
;
