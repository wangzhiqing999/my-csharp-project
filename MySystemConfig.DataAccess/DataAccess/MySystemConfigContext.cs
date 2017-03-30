using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data.Entity;

using MySystemConfig.Config;
using MySystemConfig.Model;




namespace MySystemConfig.DataAccess
{

    // Enable-Migrations -ProjectName MySystemConfig.DataAccess   -EnableAutomaticMigrations
    /// <summary>
    /// 系统配置 Context.
    /// </summary>
    public class MySystemConfigContext : DbContext
    {

        public MySystemConfigContext()
            : base("name=MySystemConfigContext")
        {

        }



        /// <summary>
        /// 系统配置类型.
        /// </summary>
        public DbSet<SystemConfigType> SystemConfigTypes { get; set; }


        /// <summary>
        /// 系统配置属性.
        /// </summary>
        public DbSet<SystemConfigProperty> SystemConfigPropertys { get; set; }


        /// <summary>
        /// 系统配置.
        /// </summary>
        public DbSet<SystemConfigValue> SystemConfigValues { get; set; }




        /// <summary>
        /// 指定如何创建 表的处理.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 系统配置类型 配置信息.
            modelBuilder.Configurations.Add(new SystemConfigTypeConfig());

            // 系统配置属性 配置信息.
            modelBuilder.Configurations.Add(new SystemConfigPropertyConfig());

            // 系统配置数值 配置信息.
            modelBuilder.Configurations.Add(new SystemConfigValueConfig());
        }


    }


}
