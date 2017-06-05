using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;


using MyWeb.Model;
using MyWeb.Config;


namespace MyWeb.DataAccess
{


    //  Enable-Migrations -ProjectName MyWeb.DataAccess  -EnableAutomaticMigrations
    public class MyWebContext : DbContext
    {
        public MyWebContext()
            : base("name=MyWebContext")
        {
        }





        /// <summary>
        /// 网站.
        /// </summary>
        public DbSet<WebSite> WebSites { get; set; }


        /// <summary>
        /// 网站模块.
        /// </summary>
        public DbSet<Module> Modules { get; set; }


        /// <summary>
        /// 网站页面.
        /// </summary>
        public DbSet<Page> Pages { get; set; }



        /// <summary>
        /// 网站菜单.
        /// </summary>
        public DbSet<Menu> Menus { get; set; }






        /// <summary>
        /// 指定如何创建 表的处理.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 网站 配置信息.
            modelBuilder.Configurations.Add(new WebSiteConfig());

            // 网站模块 配置信息.
            modelBuilder.Configurations.Add(new ModuleConfig());

            // 网站页面 配置信息.
            modelBuilder.Configurations.Add(new PageConfig());

        }


    }
}
