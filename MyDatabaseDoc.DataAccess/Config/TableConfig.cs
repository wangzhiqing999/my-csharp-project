using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity.ModelConfiguration;

using MyDatabaseDoc.Model;

namespace MyDatabaseDoc.Config
{
    class TableConfig : EntityTypeConfiguration<Table>
    {

        public TableConfig()
        {
            // 一个 表  允许有多个 列.
            this.HasMany(s => s.ColumnList)
                // 一个 列 必须 归属于一个 表.
                .WithRequired(m => m.TableData)
                // 外键的列是  TableName
                .HasForeignKey(m => m.TableName)
                // 删除 表 的同时， 删除 列。
                .WillCascadeOnDelete(true);
        }

    }
}
