INSERT INTO mm_menu(
	menu_code,parent_menu_code,display_index,
	menu_text,menu_desc,menu_expand
)
SELECT 'HOME', NULL, 1,						'��ҳ','','javascript:alert("��ҳ");'				UNION  ALL
SELECT 'ABOUT', NULL, 2,					'��������','','#'									UNION  ALL
SELECT 'ABOUT_CENTER', 'ABOUT', 1,			'���ļ��','','javascript:alert("���ļ��");'		UNION  ALL
SELECT 'ABOUT_ORG',    'ABOUT', 2,			'��֯�ṹ','','javascript:alert("��֯�ṹ");'		UNION  ALL
SELECT 'ABOUT_RECRUIT','ABOUT', 3,			'�˲���Ƹ','','javascript:alert("�˲���Ƹ");'		UNION  ALL
SELECT 'ABOUT_CONTACT','ABOUT', 4,			'��ϵ����','','javascript:alert("��ϵ����");'		UNION  ALL
SELECT 'NEWS', NULL, 3,						'���Ŷ�̬','','#'									UNION  ALL
SELECT 'NEWS_CENTER', 'NEWS', 1,			'��������','','javascript:alert("��������");'		UNION  ALL
SELECT 'NEWS_NOTICE', 'NEWS', 2,			'����','','javascript:alert("����");'				UNION  ALL
SELECT 'NEWS_FLASH',  'NEWS', 3,			'��Ѷ','','javascript:alert("��Ѷ");'				UNION  ALL
SELECT 'DOWNLOAD', NULL, 4,					'��������','','javascript:alert("��������");'
;