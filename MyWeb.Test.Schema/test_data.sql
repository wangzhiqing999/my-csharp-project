-- 测试网站数据.
INSERT INTO mw_web_site(
	web_site_code,web_site_name,web_site_host,web_site_port,web_site_use_https
)
SELECT 'main',  		'主网站',	'localhost',	8080, 0		UNION  ALL
SELECT 'document', 		'文档网站',	'localhost',	8081, 0		UNION  ALL
SELECT 'news',			'新闻网站',	'localhost',	8082, 0		UNION  ALL
SELECT 'market',		'行情网站',	'localhost',	8083, 0		UNION  ALL
SELECT 'bbs',			'论坛网站',	'localhost',	8084, 0
;



-- 测试模块.
INSERT INTO dbo.mw_module(
	module_code,web_site_code,module_name
)
SELECT 'about', 	'main', '关于我们'			UNION  ALL
SELECT 'download', 	'main', '下载'				UNION  ALL
SELECT 'banner',	'main', '横幅'				UNION  ALL
SELECT 'other',		'main', '其它'
;


INSERT INTO dbo.mw_module(
	module_code,web_site_code,module_name
)
SELECT 'news',		'news', 	'新闻'			UNION  ALL
SELECT 'doc',		'document', '文档资料'		UNION  ALL
SELECT 'market', 	'market', 	'行情'			UNION  ALL
SELECT 'bbs', 		'bbs', 		'论坛'
;








-- 测试页面.
INSERT INTO dbo.mw_page(
	page_code,module_code,parent_page_code,
	page_name,page_path,is_partial,
	display_index
)
SELECT 'home','other',null,						'首页','/',0,						0		UNION  ALL
SELECT 'news','news',null,						'新闻分组','/news/index',0,			0		UNION  ALL
SELECT 'newslist','news',null,					'新闻列表','/news/list',0,			0		UNION  ALL
SELECT 'doc','doc',null,						'文档分组','/doc/index',0,			0		UNION  ALL
SELECT 'doclist','doc',null,					'文档列表','/doc/list',0,			0		UNION  ALL
SELECT 'bbs','bbs',null,						'论坛分组','/bbs/index',0,			0		UNION  ALL
SELECT 'bbslist','bbs',null,					'论坛列表','/bbs/list',0,			0		UNION  ALL
SELECT 'market','market',null,					'行情分组','/market/index',0,		0		UNION  ALL
SELECT 'marketlist','market',null,				'行情列表','/market/list',0,		0		UNION  ALL
SELECT 'download','download',null,				'下载页','/download/index',0,		0		UNION  ALL
SELECT 'about','about',null,					'关于我们页','/about/index',0,		0
;


-- 测试页面(非独立).
INSERT INTO dbo.mw_page(
	page_code,module_code,parent_page_code,
	page_name,page_path,is_partial,
	display_index
)
SELECT 'banner','banner','home',				'首页横幅','/banner/index',1,			1		UNION  ALL
SELECT 'top5news','news','home',				'首页新闻','/news/top5news',1,			2		UNION  ALL
SELECT 'top5doc','doc','home',					'首页文档','/doc/top5doc',1,			3		UNION  ALL
SELECT 'top5bbs','bbs','home',					'首页论坛','/bbs/top5bbs',1,			4
;


-- 测试菜单.
INSERT INTO dbo.mw_menu(
	menu_code,web_site_code,parent_menu_code,
	display_index,menu_text,menu_desc,
	menu_target,is_outer_href,menu_href,
	page_code,menu_expand
)
SELECT 'home',		'main', NULL,						1,'首页','',		'_self',0,'',			'home',''				UNION  ALL
SELECT 'news',		'main', NULL,						2,'新闻','',		'_self',0,'',			'news',''				UNION  ALL
SELECT 'doc', 		'main', NULL,						3,'文档','',		'_self',0,'',			'doc',''				UNION  ALL
SELECT 'market',	'main', NULL,						4,'行情','',		'_self',0,'',			'market',''				UNION  ALL
SELECT 'bbs',		'main', NULL,						5,'论坛','',		'_self',0,'',			'bbs',''
;
