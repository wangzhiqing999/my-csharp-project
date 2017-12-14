INSERT INTO `mysubmodule`.`my_banner_type`(
	`banner_type_code`,	`banner_type_name`,
	`status`,`create_user`,`create_time`,`last_update_user`,`last_update_time`
)
SELECT 'TOP','顶部横幅', 	'ACTIVE','tester',NOW(),'tester',NOW()	UNION ALL
SELECT 'FOOT','底部横幅', 	'ACTIVE','tester',NOW(),'tester',NOW()	UNION ALL
SELECT 'APP','APP横幅', 	'ACTIVE','tester',NOW(),'tester',NOW()
;


INSERT INTO `mysubmodule`.`my_banner`(
	`banner_id`,`banner_type_code`,`display_order`,
	`banner_text`,`banner_image`,`banner_url`,
	`start_date`,`finish_date`,
	`status`,`create_user`,`create_time`,`last_update_user`,`last_update_time`
)
SELECT 1,'TOP',1,	'通知1','通知图片1','通知明细地址',		'2017-12-01','2099-12-31',	'ACTIVE','tester',NOW(),'tester',NOW()	UNION ALL
SELECT 2,'TOP',2,	'通知2','通知图片2','通知明细地址',		'2017-12-01','2099-12-31',	'ACTIVE','tester',NOW(),'tester',NOW()	UNION ALL
SELECT 3,'TOP',3,	'通知3','通知图片3','通知明细地址',		'2017-12-01','2099-12-31',	'ACTIVE','tester',NOW(),'tester',NOW()	UNION ALL
SELECT 4,'FOOT',1,	'广告1','广告图片1','广告明细地址',		'2017-12-01','2099-12-31',	'ACTIVE','tester',NOW(),'tester',NOW()	UNION ALL
SELECT 5,'FOOT',2,	'广告2','广告图片2','广告明细地址',		'2017-12-01','2099-12-31',	'ACTIVE','tester',NOW(),'tester',NOW()	UNION ALL
SELECT 6,'FOOT',3,	'广告3','广告图片3','广告明细地址',		'2017-12-01','2099-12-31',	'ACTIVE','tester',NOW(),'tester',NOW()	UNION ALL
SELECT 7,'APP',1,	'APP1','APP图片1','APP明细地址',		'2017-12-01','2099-12-31',	'ACTIVE','tester',NOW(),'tester',NOW()	UNION ALL
SELECT 8,'APP',2,	'APP2','APP图片2','APP明细地址',		'2017-12-01','2099-12-31',	'ACTIVE','tester',NOW(),'tester',NOW()	UNION ALL
SELECT 9,'APP',3,	'APP3','APP图片3','APP明细地址',		'2017-12-01','2099-12-31',	'ACTIVE','tester',NOW(),'tester',NOW()
;