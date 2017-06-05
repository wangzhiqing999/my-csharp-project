-- ������վ����.
INSERT INTO mw_web_site(
	web_site_code,web_site_name,web_site_host,web_site_port,web_site_use_https
)
SELECT 'main',  		'����վ',	'localhost',	8080, 0		UNION  ALL
SELECT 'document', 		'�ĵ���վ',	'localhost',	8081, 0		UNION  ALL
SELECT 'news',			'������վ',	'localhost',	8082, 0		UNION  ALL
SELECT 'market',		'������վ',	'localhost',	8083, 0		UNION  ALL
SELECT 'bbs',			'��̳��վ',	'localhost',	8084, 0
;



-- ����ģ��.
INSERT INTO dbo.mw_module(
	module_code,web_site_code,module_name
)
SELECT 'about', 	'main', '��������'			UNION  ALL
SELECT 'download', 	'main', '����'				UNION  ALL
SELECT 'banner',	'main', '���'				UNION  ALL
SELECT 'other',		'main', '����'
;


INSERT INTO dbo.mw_module(
	module_code,web_site_code,module_name
)
SELECT 'news',		'news', 	'����'			UNION  ALL
SELECT 'doc',		'document', '�ĵ�����'		UNION  ALL
SELECT 'market', 	'market', 	'����'			UNION  ALL
SELECT 'bbs', 		'bbs', 		'��̳'
;








-- ����ҳ��.
INSERT INTO dbo.mw_page(
	page_code,module_code,parent_page_code,
	page_name,page_path,is_partial,
	display_index
)
SELECT 'home','other',null,						'��ҳ','/',0,						0		UNION  ALL
SELECT 'news','news',null,						'���ŷ���','/news/index',0,			0		UNION  ALL
SELECT 'newslist','news',null,					'�����б�','/news/list',0,			0		UNION  ALL
SELECT 'doc','doc',null,						'�ĵ�����','/doc/index',0,			0		UNION  ALL
SELECT 'doclist','doc',null,					'�ĵ��б�','/doc/list',0,			0		UNION  ALL
SELECT 'bbs','bbs',null,						'��̳����','/bbs/index',0,			0		UNION  ALL
SELECT 'bbslist','bbs',null,					'��̳�б�','/bbs/list',0,			0		UNION  ALL
SELECT 'market','market',null,					'�������','/market/index',0,		0		UNION  ALL
SELECT 'marketlist','market',null,				'�����б�','/market/list',0,		0		UNION  ALL
SELECT 'download','download',null,				'����ҳ','/download/index',0,		0		UNION  ALL
SELECT 'about','about',null,					'��������ҳ','/about/index',0,		0
;


-- ����ҳ��(�Ƕ���).
INSERT INTO dbo.mw_page(
	page_code,module_code,parent_page_code,
	page_name,page_path,is_partial,
	display_index
)
SELECT 'banner','banner','home',				'��ҳ���','/banner/index',1,			1		UNION  ALL
SELECT 'top5news','news','home',				'��ҳ����','/news/top5news',1,			2		UNION  ALL
SELECT 'top5doc','doc','home',					'��ҳ�ĵ�','/doc/top5doc',1,			3		UNION  ALL
SELECT 'top5bbs','bbs','home',					'��ҳ��̳','/bbs/top5bbs',1,			4
;


-- ���Բ˵�.
INSERT INTO dbo.mw_menu(
	menu_code,web_site_code,parent_menu_code,
	display_index,menu_text,menu_desc,
	menu_target,is_outer_href,menu_href,
	page_code,menu_expand
)
SELECT 'home',		'main', NULL,						1,'��ҳ','',		'_self',0,'',			'home',''				UNION  ALL
SELECT 'news',		'main', NULL,						2,'����','',		'_self',0,'',			'news',''				UNION  ALL
SELECT 'doc', 		'main', NULL,						3,'�ĵ�','',		'_self',0,'',			'doc',''				UNION  ALL
SELECT 'market',	'main', NULL,						4,'����','',		'_self',0,'',			'market',''				UNION  ALL
SELECT 'bbs',		'main', NULL,						5,'��̳','',		'_self',0,'',			'bbs',''
;
