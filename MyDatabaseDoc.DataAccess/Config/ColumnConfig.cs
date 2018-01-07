using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity.ModelConfiguration;

using MyDatabaseDoc.Model;


namespace MyDatabaseDoc.Config
{
    class ColumnConfig : EntityTypeConfiguration<Column>
    {

        public ColumnConfig()
        {
            // 复合主键.
            this.HasKey(p => new { p.TableName, p.ColumnName });
        }

    }
}
