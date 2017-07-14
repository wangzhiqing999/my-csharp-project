using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data.Entity;


using MyUpdateLog.Config;
using MyUpdateLog.Model;


namespace MyUpdateLog.DataAccess
{


    // Enable-Migrations -ProjectName MyUpdateLog.DataAccess  -EnableAutomaticMigrations
    public class MyUpdateLogContext : DbContext
    {
        public MyUpdateLogContext()
            : base("name=MyUpdateLogContext")
        {
        }



        /// <summary>
        /// 更新日志分类.
        /// </summary>
        public DbSet<UpdateLogCategory> UpdateLogCategorys { get; set; }



        /// <summary>
        /// 更新日志.
        /// </summary>
        public DbSet<UpdateLogDetail> UpdateLogDetails { get; set; }






        /// <summary>
        /// 指定如何创建 表的处理.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // 更新日志分类表 配置.
            modelBuilder.Configurations.Add(new UpdateLogCategoryConfig());




        }
    }


}
