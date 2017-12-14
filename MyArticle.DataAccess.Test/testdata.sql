INSERT INTO my_article_category (
	article_category_code,	article_category_name,	
	status,create_user,create_time,last_update_user,last_update_time
)
SELECT 'TEST1', '测试分类1', 	'ACTIVE','tester',NOW(),'tester',NOW()	UNION ALL
SELECT 'TEST2', '测试分类2', 	'ACTIVE','tester',NOW(),'tester',NOW()	UNION ALL
SELECT 'TEST3', '测试分类3', 	'ACTIVE','tester',NOW(),'tester',NOW()
;


INSERT INTO my_article (
	article_id,				article_category_code,	article_title,
	article_sub_title,		article_keyword,		article_date,
	article_content_short,	article_content,		article_title_image,
	article_download_filename,
	status,create_user,create_time,last_update_user,last_update_time
)
SELECT 1,'TEST1','测试文章1',	'子标题1',	'关键字1','2017-12-01',		'文章简介1','文章全文1','Logo图片1',	'下载文件1', 	'ACTIVE','tester',NOW(),'tester',NOW()	UNION ALL
SELECT 2,'TEST1','测试文章2',	'子标题2',	'关键字2','2017-12-02',		'文章简介2','文章全文2','Logo图片2',	'下载文件2', 	'ACTIVE','tester',NOW(),'tester',NOW()	UNION ALL
SELECT 3,'TEST1','测试文章3',	'子标题3',	'关键字3','2017-12-03',		'文章简介3','文章全文3','Logo图片3',	'下载文件3', 	'ACTIVE','tester',NOW(),'tester',NOW()	UNION ALL
SELECT 4,'TEST1','测试文章4',	'子标题4',	'关键字4','2017-12-04',		'文章简介4','文章全文4','Logo图片4',	'下载文件4', 	'ACTIVE','tester',NOW(),'tester',NOW()	UNION ALL
SELECT 5,'TEST1','测试文章5',	'子标题5',	'关键字5','2017-12-05',		'文章简介5','文章全文5','Logo图片5',	'下载文件5', 	'ACTIVE','tester',NOW(),'tester',NOW()	UNION ALL
SELECT 6,'TEST1','测试文章6',	'子标题6',	'关键字6','2017-12-06',		'文章简介6','文章全文6','Logo图片6',	'下载文件6', 	'ACTIVE','tester',NOW(),'tester',NOW()	UNION ALL
SELECT 7,'TEST1','测试文章7',	'子标题7',	'关键字7','2017-12-07',		'文章简介7','文章全文7','Logo图片7',	'下载文件7', 	'ACTIVE','tester',NOW(),'tester',NOW()	UNION ALL
SELECT 8,'TEST1','测试文章8',	'子标题8',	'关键字8','2017-12-08',		'文章简介8','文章全文8','Logo图片8',	'下载文件8', 	'ACTIVE','tester',NOW(),'tester',NOW()	UNION ALL
SELECT 9,'TEST1','测试文章9',	'子标题9',	'关键字9','2017-12-09',		'文章简介9','文章全文9','Logo图片9',	'下载文件9', 	'ACTIVE','tester',NOW(),'tester',NOW()	UNION ALL
SELECT 10,'TEST1','测试文章10',	'子标题10',	'关键字10','2017-12-10',	'文章简介10','文章全文10','Logo图片10',	'下载文件10', 	'ACTIVE','tester',NOW(),'tester',NOW()	UNION ALL
SELECT 11,'TEST2','测试文章11',	'子标题11',	'关键字11','2017-12-01',	'文章简介1','文章全文1','Logo图片1',	'下载文件1', 	'ACTIVE','tester',NOW(),'tester',NOW()	UNION ALL
SELECT 12,'TEST2','测试文章12',	'子标题12',	'关键字12','2017-12-02',	'文章简介2','文章全文2','Logo图片2',	'下载文件2', 	'ACTIVE','tester',NOW(),'tester',NOW()	UNION ALL
SELECT 13,'TEST2','测试文章13',	'子标题13',	'关键字13','2017-12-03',	'文章简介3','文章全文3','Logo图片3',	'下载文件3', 	'ACTIVE','tester',NOW(),'tester',NOW()	UNION ALL
SELECT 14,'TEST2','测试文章14',	'子标题14',	'关键字14','2017-12-04',	'文章简介4','文章全文4','Logo图片4',	'下载文件4', 	'ACTIVE','tester',NOW(),'tester',NOW()	UNION ALL
SELECT 15,'TEST2','测试文章15',	'子标题15',	'关键字15','2017-12-05',	'文章简介5','文章全文5','Logo图片5',	'下载文件5', 	'ACTIVE','tester',NOW(),'tester',NOW()	UNION ALL
SELECT 16,'TEST2','测试文章16',	'子标题16',	'关键字16','2017-12-06',	'文章简介6','文章全文6','Logo图片6',	'下载文件6', 	'ACTIVE','tester',NOW(),'tester',NOW()	UNION ALL
SELECT 17,'TEST2','测试文章17',	'子标题17',	'关键字17','2017-12-07',	'文章简介7','文章全文7','Logo图片7',	'下载文件7', 	'ACTIVE','tester',NOW(),'tester',NOW()	UNION ALL
SELECT 18,'TEST2','测试文章18',	'子标题18',	'关键字18','2017-12-08',	'文章简介8','文章全文8','Logo图片8',	'下载文件8', 	'ACTIVE','tester',NOW(),'tester',NOW()	UNION ALL
SELECT 19,'TEST2','测试文章19',	'子标题19',	'关键字19','2017-12-09',	'文章简介9','文章全文9','Logo图片9',	'下载文件9', 	'ACTIVE','tester',NOW(),'tester',NOW()	UNION ALL
SELECT 20,'TEST2','测试文章20',	'子标题20',	'关键字20','2017-12-10',	'文章简介10','文章全文10','Logo图片10',	'下载文件10', 	'ACTIVE','tester',NOW(),'tester',NOW()	UNION ALL
SELECT 21,'TEST3','测试文章21',	'子标题21',	'关键字21','2017-12-01',	'文章简介1','文章全文1','Logo图片1',  	'下载文件1', 	'ACTIVE','tester',NOW(),'tester',NOW()	UNION ALL
SELECT 22,'TEST3','测试文章22',	'子标题22',	'关键字22','2017-12-02',	'文章简介2','文章全文2','Logo图片2',  	'下载文件2', 	'ACTIVE','tester',NOW(),'tester',NOW()	UNION ALL
SELECT 23,'TEST3','测试文章23',	'子标题23',	'关键字23','2017-12-03',	'文章简介3','文章全文3','Logo图片3',  	'下载文件3', 	'ACTIVE','tester',NOW(),'tester',NOW()	UNION ALL
SELECT 24,'TEST3','测试文章24',	'子标题24',	'关键字24','2017-12-04',	'文章简介4','文章全文4','Logo图片4',  	'下载文件4', 	'ACTIVE','tester',NOW(),'tester',NOW()	UNION ALL
SELECT 25,'TEST3','测试文章25',	'子标题25',	'关键字25','2017-12-05',	'文章简介5','文章全文5','Logo图片5',  	'下载文件5', 	'ACTIVE','tester',NOW(),'tester',NOW()	UNION ALL
SELECT 26,'TEST3','测试文章26',	'子标题26',	'关键字26','2017-12-06',	'文章简介6','文章全文6','Logo图片6',  	'下载文件6', 	'ACTIVE','tester',NOW(),'tester',NOW()	UNION ALL
SELECT 27,'TEST3','测试文章27',	'子标题27',	'关键字27','2017-12-07',	'文章简介7','文章全文7','Logo图片7',  	'下载文件7', 	'ACTIVE','tester',NOW(),'tester',NOW()	UNION ALL
SELECT 28,'TEST3','测试文章28',	'子标题28',	'关键字28','2017-12-08',	'文章简介8','文章全文8','Logo图片8',  	'下载文件8', 	'ACTIVE','tester',NOW(),'tester',NOW()	UNION ALL
SELECT 29,'TEST3','测试文章29',	'子标题29',	'关键字29','2017-12-09',	'文章简介9','文章全文9','Logo图片9',  	'下载文件9', 	'ACTIVE','tester',NOW(),'tester',NOW()	UNION ALL
SELECT 30,'TEST3','测试文章30',	'子标题30',	'关键字30','2017-12-10',	'文章简介10','文章全文10','Logo图片10',	'下载文件10', 	'ACTIVE','tester',NOW(),'tester',NOW()
;