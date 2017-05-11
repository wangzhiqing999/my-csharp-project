INSERT INTO mm_menu(
	menu_code,parent_menu_code,display_index,
	menu_text,menu_desc,menu_expand
)
SELECT 'HOME', NULL, 1,						'首页','','javascript:alert("首页");'				UNION  ALL
SELECT 'ABOUT', NULL, 2,					'关于我们','','#'									UNION  ALL
SELECT 'ABOUT_CENTER', 'ABOUT', 1,			'中心简介','','javascript:alert("中心简介");'		UNION  ALL
SELECT 'ABOUT_ORG',    'ABOUT', 2,			'组织结构','','javascript:alert("组织结构");'		UNION  ALL
SELECT 'ABOUT_RECRUIT','ABOUT', 3,			'人才招聘','','javascript:alert("人才招聘");'		UNION  ALL
SELECT 'ABOUT_CONTACT','ABOUT', 4,			'联系我们','','javascript:alert("联系我们");'		UNION  ALL
SELECT 'NEWS', NULL, 3,						'新闻动态','','#'									UNION  ALL
SELECT 'NEWS_CENTER', 'NEWS', 1,			'中心新闻','','javascript:alert("中心新闻");'		UNION  ALL
SELECT 'NEWS_NOTICE', 'NEWS', 2,			'公告','','javascript:alert("公告");'				UNION  ALL
SELECT 'NEWS_FLASH',  'NEWS', 3,			'快讯','','javascript:alert("快讯");'				UNION  ALL
SELECT 'DOWNLOAD', NULL, 4,					'下载中心','','javascript:alert("下载中心");'
;