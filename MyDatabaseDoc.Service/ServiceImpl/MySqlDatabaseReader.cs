using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyDatabaseDoc.DataAccess;
using MyDatabaseDoc.Model;
using MyDatabaseDoc.Service;

namespace MyDatabaseDoc.ServiceImpl
{
    public class MySqlDatabaseReader : IDatabaseReader
    {

        private const string getTableSql = @"SELECT 
  table_name  AS  `TableName`, 
  table_comment  AS  `TableComment`
FROM 
  information_schema.tables
WHERE 
  table_schema = database()";

        public List<Table> GetTableList()
        {
            using (MyDatabaseDocContext context = new MyDatabaseDocContext())
            {
                var query = context.Database.SqlQuery<Table>(getTableSql);
                return query.ToList();
            }
        }




        private const string getColumnSql = @"SELECT 
  column_name AS `ColumnName`, 
  data_type   AS `DataType`, 
  is_nullable AS `IsNullable`, 
  column_comment  AS  `ColumnComment`
FROM
  Information_schema.columns
WHERE
  table_schema = database()
  AND table_Name='{0}';

";

        public List<Column> GetColumnList(string tableName)
        {
            string sql = String.Format(getColumnSql, tableName);

            using (MyDatabaseDocContext context = new MyDatabaseDocContext())
            {
                var query = context.Database.SqlQuery<Column>(sql);
                return query.ToList();
            }
        }
    }
}
