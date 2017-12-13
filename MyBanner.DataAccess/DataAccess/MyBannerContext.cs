using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using MyBanner.Model;
using MyBanner.Config;


namespace MyBanner.DataAccess
{
    public class MyBannerContext : DbContext
    {

        public MyBannerContext()
            : base("name=MyBannerContext")
        {
        }


        /// <summary>
        /// 网站横幅类型.
        /// </summary>
        public DbSet<BannerType> BannerTypes { get; set; }

        /// <summary>
        /// 网站横幅.
        /// </summary>
        public DbSet<Banner> Banners { get; set; }



        
        /// <summary>
        /// 指定如何创建 表的处理.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // 网站横幅类型 配置信息.
            modelBuilder.Configurations.Add(new BannerTypeConfig());
        }



    }
}
