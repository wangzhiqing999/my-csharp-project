INSERT INTO dbo.ma_area_info (
	area_code,	parent_area_code,	area_name
)
SELECT '9110',	NULL,	'北京市'		UNION  ALL
SELECT '9120',	NULL,	'天津市'		UNION  ALL
SELECT '9130',	NULL,	'河北省'
;


INSERT INTO dbo.ma_area_info (
	area_code,	parent_area_code,	area_name
)
SELECT '1392',	'9130',	'康保县'		UNION  ALL
SELECT '1393',	'9130',	'沽源县'		UNION  ALL
SELECT '1394',	'9130',	'尚义县'		UNION  ALL
SELECT '1395',	'9130',	'蔚县'			UNION  ALL
SELECT '1396',	'9130',	'阳原县'
;