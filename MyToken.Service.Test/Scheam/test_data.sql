INSERT INTO [dbo].[mt_token_type](
	[token_type_code],[token_type_name],[token_type_desc],
	[default_timeout_seconds],[access_able_times_limit],[is_require_access_log]
)
SELECT 'TEST_CASE_1', '测试案例1','10秒有效，允许多次使用，无日志',		10,0,0		UNION ALL
SELECT 'TEST_CASE_2', '测试案例2','10秒有效，最多次使用1次，无日志',	10,1,0		UNION ALL
SELECT 'TEST_CASE_3', '测试案例3','10秒有效，最多次使用2次，无日志',	10,2,0		UNION ALL
SELECT 'TEST_CASE_4', '测试案例4','10秒有效，允许多次使用，有日志',		10,0,1		UNION ALL
SELECT 'TEST_CASE_5', '测试案例5','10秒有效，最多次使用1次，有日志',	10,1,1		UNION ALL
SELECT 'TEST_LOGIN',  '测试扫码登录','60秒有效，最多次使用2次，有日志',	60,2,1
;