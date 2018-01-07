replace into db_doc_table (
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



replace into db_doc_column (
	column_index,	table_name,	column_name,	
	data_type,	is_nullable,	column_comment
)
SELECT 
  CASE 
    WHEN @cn != table_name THEN @rownum:= 1 
    ELSE @rownum:= @rownum + 1  
  END AS column_index,
  @cn := table_name AS table_name,
  column_name,    
  data_type, 
  is_nullable, 
  column_comment
FROM
  (SELECT @rownum:=0) r,
  (SELECT @cn:='') p,
  Information_schema.columns
WHERE
  table_schema = database()
;

