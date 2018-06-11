-- 关键字.
SET IDENTITY_INSERT [my_help_keyword] ON
GO

INSERT INTO [my_help_keyword](
	[keyword_id],  [keyword_text]
)
SELECT 1, '存储过程'	UNION ALL
SELECT 2, '函数'		UNION ALL
SELECT 3, '触发器'		UNION ALL
SELECT 4, '外键'		UNION ALL
SELECT 5, '游标'		UNION ALL
SELECT 6, '异常'
GO

SET IDENTITY_INSERT [my_help_keyword] OFF
GO



-- 文档.
SET IDENTITY_INSERT [my_help_doc] ON
GO

INSERT INTO [my_help_doc](
	[document_id],[document_title],[document_content]
)
SELECT 11, '存储过程的创建', '使用 CREATE PROCEDURE ...... 进行存储过程的创建 ......'		UNION ALL
SELECT 12, '存储过程的修改', '使用 ALTER  PROCEDURE ...... 进行存储过程的修改 ......'		UNION ALL
SELECT 13, '存储过程的异常', '使用 BEGIN TRY ...... END TRY ...... BEGIN CATCH ...... END CATCH 进行处理 ......'		UNION ALL
SELECT 21, '函数的创建', '使用 CREATE FUNCTION  ...... 进行函数的创建 ......'		UNION ALL
SELECT 22, '函数的修改', '使用 ALTER  FUNCTION  ...... 进行函数的修改 ......'		UNION ALL
SELECT 23, '函数的异常', '使用 BEGIN TRY ...... END TRY ...... BEGIN CATCH ...... END CATCH 进行处理 ......'		UNION ALL
SELECT 31, '触发器的创建', '使用 CREATE TRIGGER   ...... 进行触发器的创建 ......'		UNION ALL
SELECT 32, '触发器的修改', '使用 ALTER  TRIGGER  ...... 进行触发器的修改 ......'		UNION ALL
SELECT 33, '触发器的异常', '使用 BEGIN TRY ...... END TRY ...... BEGIN CATCH ...... END CATCH 进行处理 ......'		UNION ALL
SELECT 41, '外键的创建', 'ALTER TABLE ... ADD CONSTRAINT ...  FOREIGN KEY (...)  REFERENCES  ...; 进行外键的创建 ......'		UNION ALL
SELECT 51, '游标的定义', '使用 DECLARE ... CURSOR FAST_FORWARD FOR ... 定义游标 ......'		UNION ALL
SELECT 52, '游标的打开', '使用 OPEN ... 打开游标 ......'		UNION ALL
SELECT 53, '游标的关闭', '使用 CLOSE ... 关闭游标 ......'		UNION ALL
SELECT 54, '游标的遍历', '使用 FETCH NEXT FROM ... INTO  ... 遍历游标 ......'		UNION ALL
SELECT 55, '游标的释放', '使用 DEALLOCATE  ... 释放游标 ......'		UNION ALL
SELECT 61, '基本异常处理', '使用 BEGIN TRY ...... END TRY ...... BEGIN CATCH ...... END CATCH 进行处理 ......'		UNION ALL
SELECT 62, '获取异常错误码', '使用 ERROR_NUMBER() 进行处理 ......'		UNION ALL
SELECT 63, '获取异常错误信息', '使用 ERROR_MESSAGE() 进行处理 ......'
GO

SET IDENTITY_INSERT [my_help_doc] OFF
GO





-- 多对多关联.
INSERT INTO [my_help_doc_keyword](
	[document_id],[keyword_id]
)
SELECT 11,1	UNION ALL
SELECT 12,1	UNION ALL
SELECT 13,1	UNION ALL
SELECT 13,6	UNION ALL
SELECT 21,2	UNION ALL
SELECT 22,2	UNION ALL
SELECT 23,2	UNION ALL
SELECT 23,6	UNION ALL
SELECT 31,3	UNION ALL
SELECT 32,3	UNION ALL
SELECT 33,3	UNION ALL
SELECT 33,6	UNION ALL
SELECT 41,4	UNION ALL
SELECT 51,5	UNION ALL
SELECT 52,5	UNION ALL
SELECT 53,5	UNION ALL
SELECT 54,5	UNION ALL
SELECT 55,5	UNION ALL
SELECT 61,6	UNION ALL
SELECT 62,6	UNION ALL
SELECT 63,6
GO
