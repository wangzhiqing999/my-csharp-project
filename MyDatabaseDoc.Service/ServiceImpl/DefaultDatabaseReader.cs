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
    public class DefaultDatabaseReader : IDatabaseReader
    {

        public List<Table> GetTableList()
        {
            using (MyDatabaseDocContext context = new MyDatabaseDocContext())
            {
                var query =
                    from data in context.Tables
                    select data;

                var resultList = query.ToList();

                return resultList;
            }
        }



        public List<Column> GetColumnList(string tableName)
        {
            using (MyDatabaseDocContext context = new MyDatabaseDocContext())
            {
                var query =
                    from data in context.Columns
                    where
                        data.TableName == tableName
                    orderby
                        data.ColumnIndex
                    select data;

                var resultList = query.ToList();

                return resultList;
            }
        }




        public Table GetTable(string tableName)
        {
            using (MyDatabaseDocContext context = new MyDatabaseDocContext())
            {
                var query =
                    from data in context.Tables.Include("ColumnList")
                    where
                        data.TableName == tableName
                    select data;

                var result = query.FirstOrDefault();

                return result;
            }
        }


    }
}
