using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

using MyArea.Model;


namespace MyArea.DataAccess
{


    //  Enable-Migrations -ProjectName MyArea.DataAccess  -EnableAutomaticMigrations
    public class MyAreaContext : DbContext
    {

        public MyAreaContext()
            : base("name=MyAreaContext")
        {
        }



        /// <summary>
        /// 区域.
        /// </summary>
        public DbSet<AreaInfo> AreaInfos { get; set; }




        /// <summary>
        /// 指定如何创建 表的处理.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }



    }

}
