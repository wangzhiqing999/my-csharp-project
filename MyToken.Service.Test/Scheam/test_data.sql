INSERT INTO [dbo].[mt_token_type](
	[token_type_code],[token_type_name],[token_type_desc],
	[default_timeout_seconds],[access_able_times_limit],[is_require_access_log]
)
SELECT 'TEST_CASE_1', '���԰���1','10����Ч��������ʹ�ã�����־',		10,0,0		UNION ALL
SELECT 'TEST_CASE_2', '���԰���2','10����Ч������ʹ��1�Σ�����־',	10,1,0		UNION ALL
SELECT 'TEST_CASE_3', '���԰���3','10����Ч������ʹ��2�Σ�����־',	10,2,0		UNION ALL
SELECT 'TEST_CASE_4', '���԰���4','10����Ч��������ʹ�ã�����־',		10,0,1		UNION ALL
SELECT 'TEST_CASE_5', '���԰���5','10����Ч������ʹ��1�Σ�����־',	10,1,1		UNION ALL
SELECT 'TEST_LOGIN',  '����ɨ���¼','60����Ч������ʹ��2�Σ�����־',	60,2,1
;