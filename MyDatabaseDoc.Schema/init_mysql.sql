/*  注意： 下面的 SQL 语句， 只需要执行一次， 不要重复执行。  */

insert into db_doc_table (
	table_name,	table_comment
)
SELECT
  table_name,
  table_comment
FROM
  information_schema.tables
WHERE
  table_schema = database()
;



insert into db_doc_column (
	table_name,		column_name,				column_index,
	data_type,		character_maximum_length,	numeric_precision,
	numeric_scale,	is_nullable,				column_comment
)
SELECT
  table_name,  		column_name,    			ordinal_position,
  data_type, 		character_maximum_length,	numeric_precision,
  numeric_scale,	is_nullable,				column_comment
FROM
  Information_schema.columns
WHERE
  table_schema = database()
;






UPDATE db_doc_table SET table_comment = '数据库表文档'			WHERE table_name = 'db_doc_table';
UPDATE db_doc_table SET table_comment = '数据库列文档'			WHERE table_name = 'db_doc_column';



UPDATE `db_doc_column` SET `column_comment` = '表名'		WHERE `table_name` = 'db_doc_table' AND `column_name` = 'table_name';
UPDATE `db_doc_column` SET `column_comment` = '备注'		WHERE `table_name` = 'db_doc_table' AND `column_name` = 'table_comment';

UPDATE `db_doc_column` SET `column_comment` = '表名'		WHERE `table_name` = 'db_doc_column' AND `column_name` = 'table_name';
UPDATE `db_doc_column` SET `column_comment` = '列名'		WHERE `table_name` = 'db_doc_column' AND `column_name` = 'column_name';
UPDATE `db_doc_column` SET `column_comment` = '列顺序'		WHERE `table_name` = 'db_doc_column' AND `column_name` = 'column_index';
UPDATE `db_doc_column` SET `column_comment` = '数据类型'	WHERE `table_name` = 'db_doc_column' AND `column_name` = 'data_type';
UPDATE `db_doc_column` SET `column_comment` = '字符串长度'	WHERE `table_name` = 'db_doc_column' AND `column_name` = 'character_maximum_length';
UPDATE `db_doc_column` SET `column_comment` = '数字长度'	WHERE `table_name` = 'db_doc_column' AND `column_name` = 'numeric_precision';
UPDATE `db_doc_column` SET `column_comment` = '小数位数'	WHERE `table_name` = 'db_doc_column' AND `column_name` = 'numeric_scale';
UPDATE `db_doc_column` SET `column_comment` = '允许为空'	WHERE `table_name` = 'db_doc_column' AND `column_name` = 'is_nullable';
UPDATE `db_doc_column` SET `column_comment` = '备注'		WHERE `table_name` = 'db_doc_column' AND `column_name` = 'column_comment';


/*
注意：

后期数据发生变更，需要更新操作时.

如果使用下面的  REPLACE  INTO   db_doc_table  ... 操作，  可能会导致  db_doc_column  表的数据被清空.


REPLACE  INTO db_doc_table (
	table_name,	table_comment
)
SELECT
  table_name,
  table_comment
FROM
  information_schema.tables
WHERE
  table_schema = database()
;



*/


