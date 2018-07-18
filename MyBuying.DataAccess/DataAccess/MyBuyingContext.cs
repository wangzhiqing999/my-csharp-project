using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using MyBuying.Model;
using MyBuying.Config;


namespace MyBuying.DataAccess
{

    // Enable-Migrations  -ProjectName MyBuying.DataAccess -EnableAutomaticMigrations
    public class MyBuyingContext : DbContext
    {
        public MyBuyingContext()
            : base("name=MyBuyingContext")
        {
        }


        /// <summary>
        /// 商品主表.
        /// </summary>
        public DbSet<CommodityMaster> CommodityMasters { get; set; }


        /// <summary>
        /// 商品明细模板.
        /// </summary>
        public DbSet<CommodityDetailTemplate> CommodityDetailTemplates { get; set; }

        /// <summary>
        /// 商品明细.
        /// </summary>
        public DbSet<CommodityDetail> CommodityDetails { get; set; }



        /// <summary>
        /// 指定如何创建 表的处理.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 商品主表 配置信息.
            modelBuilder.Configurations.Add(new CommodityMasterConfig());
        }



    }
}
