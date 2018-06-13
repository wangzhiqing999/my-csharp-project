SET IDENTITY_INSERT [me_user] ON
go

INSERT INTO [me_user](
	user_id,[user_name]
) VALUES (
	1,'测试用户'
)
GO

SET IDENTITY_INSERT [me_user] OFF
go





SET IDENTITY_INSERT [me_examination] ON
go

INSERT INTO [me_examination](
	[examination_id], [examination_name],[examination_desc]
) VALUES (
	101, 'Oracle测试',  '测试用'
)
GO

SET IDENTITY_INSERT [me_examination] OFF
go







SET IDENTITY_INSERT [me_question] ON
go

INSERT INTO [me_question](
	question_id,
	[examination_id],[question_type],[question_text],
	[question_point],[display_order]
)
SELECT 1011, 		101, 1,'ORACLE中，游标可以分为三类，下面不是Oracle游标的是',											10,1			UNION  ALL
SELECT 1012, 		101, 1,'PL/SQL块中定义了一个带参数的游标：CURSOR emp_cursor(dnum NUMBER) IS
 SELECT sal,comm FROM emp WHERE deptno=dnum;
那么正确打开此游标的语句是',																								10,2			UNION  ALL
SELECT 1013, 		101, 1,'有关ORACLE索引说法正确的是',																	10,3			UNION  ALL
SELECT 1014, 		101, 1,'下列有关包的使用说法错误的是',																	10,4			UNION  ALL
SELECT 1015, 		101, 1,'以下定义的哪个变量是非法的？',																	10,5			UNION  ALL
SELECT 1016, 		101, 1,'PL/SQL块中不能直接使用的SQL命令是',																10,6			UNION  ALL
SELECT 1017, 		101, 2,'下列有关函数的特点说法错误的是',																10,7			UNION  ALL
SELECT 1018, 		101, 1,'与where salary between 2000 and 3000等价的语句是',												10,8			UNION  ALL
SELECT 1019, 		101, 1,'对于oracle数据库，设计用户表时，家庭住址字段最好采用下面的哪个数据类型进行存储',				10,9			UNION  ALL
SELECT 1020, 		101, 1,'如果希望执行某操作时，该操作不执行，而是执行另一个操作，那么可是使用什么方式来完成',			10,10
GO

SET IDENTITY_INSERT [me_question] OFF
go




SET IDENTITY_INSERT [me_question_option] ON
go

INSERT INTO [me_question_option](
	question_option_id,
	[question_id],[question_option_text],[is_right_option],
	[option_point]
)
-- ORACLE中，游标可以分为三类，下面不是Oracle游标的是.
SELECT 10111,		1011,'系统游标',1,						0	UNION  ALL
SELECT 10112,		1011,'显式游标',0,						0	UNION  ALL
SELECT 10113,		1011,'隐式游标',0,						0	UNION  ALL
SELECT 10114,		1011,'REF游标',0,						0	UNION  ALL
-- 那么正确打开此游标的语句是.
SELECT 10121,		1012,'OPEN emp_cursor(20); ',1,									0	UNION  ALL
SELECT 10122,		1012,'OPEN emp_cursor FOR 20;',0,								0	UNION  ALL
SELECT 10123,		1012,'OPEN emp_cursor USING 20;',0,								0	UNION  ALL
SELECT 10124,		1012,'FOR rmp_rec IN emp_cursor[20] LOOP ... END LOOP; ',0,		0	UNION  ALL
-- 有关ORACLE索引说法正确的是.
SELECT 10131,		1013,'索引的数据和表的数据分开存储，但索引组织表除外',1,		0	UNION  ALL
SELECT 10132,		1013,'所有索引中的数据是顺序排序',0,							0	UNION  ALL
SELECT 10133,		1013,'分区表的索引必须统一存储',0,								0	UNION  ALL
SELECT 10134,		1013,'只能对分区表的索引进行分区',0,							0	UNION  ALL
-- 下列有关包的使用说法错误的是
SELECT 10141,		1014,'必须先创建包头，然后创建包体',1,							0	UNION  ALL
SELECT 10142,		1014,'在不同的包内模块可以重名',0,								0	UNION  ALL
SELECT 10143,		1014,'包的私有过程不能被外部程序调用',0,						0	UNION  ALL
SELECT 10144,		1014,'包体中的全局过程和函数必须在包',0,						0	UNION  ALL
-- 以下定义的哪个变量是非法的？
SELECT 10151,		1015,'var_ab number default:=1;   var_ab number default 1;',1,	0	UNION  ALL
SELECT 10152,		1015,'var_ab number not null :=0;',0,							0	UNION  ALL
SELECT 10153,		1015,'var_ab number;',0,										0	UNION  ALL
SELECT 10154,		1015,'var_ab number:=3;',0,										0	UNION  ALL
-- PL/SQL块中不能直接使用的SQL命令是
SELECT 10161,		1016,'drop',1,													0	UNION  ALL
SELECT 10162,		1016,'insert',0,												0	UNION  ALL
SELECT 10163,		1016,'update',0,												0	UNION  ALL
SELECT 10164,		1016,'select',0,												0	UNION  ALL
-- 下列有关函数的特点说法错误的是
SELECT 10171,		1017,'函数的调用应使用EXECUTE命令',1,							0	UNION  ALL
SELECT 10172,		1017,'函数可以不定义返回类型',1,								0	UNION  ALL
SELECT 10173,		1017,'函数参数的类型可以是OUT',0,								0	UNION  ALL
SELECT 10174,		1017,'在函数体内可以多次使用RETURN语句',0,						0	UNION  ALL
-- 与where salary between 2000 and 3000等价的语句是
SELECT 10181,		1018,'salary >= 2000 and salary <= 3000',1,						0	UNION  ALL
SELECT 10182,		1018,'salary > 2000 and salary < 3000',0,						0	UNION  ALL
SELECT 10183,		1018,'salary >= 2000 or salary <= 3000',0,						0	UNION  ALL
SELECT 10184,		1018,'salary > 2000 or salary < 3000',0,						0	UNION  ALL
-- 对于oracle数据库，设计用户表时，家庭住址字段最好采用下面的哪个数据类型进行存储
SELECT 10191,		1019,'VARCHAR2',1,												0	UNION  ALL
SELECT 10192,		1019,'CHAR',0,													0	UNION  ALL
SELECT 10193,		1019,'VARCHAR',0,												0	UNION  ALL
SELECT 10194,		1019,'LONG',0,													0	UNION  ALL
-- 如果希望执行某操作时，该操作不执行，而是执行另一个操作，那么可是使用什么方式来完成
SELECT 10201,		1020,'instead of 触发器',1,										0	UNION  ALL
SELECT 10202,		1020,'before 触发器',0,											0	UNION  ALL
SELECT 10203,		1020,'after 触发器',0,											0	UNION  ALL
SELECT 10204,		1020,'undo 触发器',0,											0
GO

SET IDENTITY_INSERT [me_question_option] OFF
go

