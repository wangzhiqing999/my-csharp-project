using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using MyDatabaseDoc.Model;
using MyDatabaseDoc.Config;

namespace MyDatabaseDoc.DataAccess
{


    // Enable-Migrations -ProjectName MyDatabaseDoc.DataAccess  -EnableAutomaticMigrations
    public class MyDatabaseDocContext : DbContext
    {

        public MyDatabaseDocContext()
            : base("name=MyDatabaseDocContext")
        {
        }


        /// <summary>
        /// 表.
        /// </summary>
        public DbSet<Table> Tables { get; set; }


        /// <summary>
        /// 列.
        /// </summary>
        public DbSet<Column> Columns { get; set; }




        /// <summary>
        /// 指定如何创建 表的处理.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 表.
            modelBuilder.Configurations.Add(new TableConfig());

            // 列.
            modelBuilder.Configurations.Add(new ColumnConfig());
        }

    }
}
