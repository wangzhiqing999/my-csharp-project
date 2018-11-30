using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity.Infrastructure.Interception;
using System.Diagnostics;



using System.Data.Entity;

using MyCustomAction.Model;
using MyCustomAction.Config;


namespace MyCustomAction.DataAccess
{


    // Enable-Migrations -ProjectName MyCustomAction.DataAccess  -EnableAutomaticMigrations
    public class MyCustomActionContext : DbContext
    {

        public MyCustomActionContext()
            : base("name=MyCustomActionContext")
        {
        }



        /// <summary>
        /// 服务模块.
        /// </summary>
        public DbSet<ServiceModule> ServiceModules { get; set; }


        /// <summary>
        /// 客户行为.
        /// </summary>
        public DbSet<CustomAction> CustomActions { get; set; }




        /// <summary>
        /// 指定如何创建 表的处理.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 服务模块 配置信息.
            modelBuilder.Configurations.Add(new ServiceModuleConfig());

        }


    }
}
