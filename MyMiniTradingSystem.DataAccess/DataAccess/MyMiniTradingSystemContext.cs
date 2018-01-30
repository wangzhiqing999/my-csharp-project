using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data.Entity;

using MyMiniTradingSystem.Config;
using MyMiniTradingSystem.Model;


namespace MyMiniTradingSystem.DataAccess
{

    // Enable-Migrations -ProjectName MyMiniTradingSystem.DataAccess  -EnableAutomaticMigrations
    public class MyMiniTradingSystemContext : DbContext
    {


        public MyMiniTradingSystemContext()
            : base("name=MyMiniTradingSystemContext")
        {

        }



        /// <summary>
        /// 用户帐户.
        /// </summary>
        public DbSet<UserAccount> UserAccounts { get; set; }

        /// <summary>
        /// 交易商品.
        /// </summary>
        public DbSet<TradableCommodity> TradableCommoditys { get; set; }


        /// <summary>
        /// 商品行情(日).
        /// </summary>
        public DbSet<CommodityPrice> CommodityPrices { get; set; }


        /// <summary>
        /// 仓位.
        /// </summary>
        public DbSet<Position> Positions { get; set; }


        /// <summary>
        /// 每日小结
        /// </summary>
        public DbSet<DailySummary> DailySummarys { get; set; }





        /// <summary>
        /// 指定如何创建 表的处理.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // 用户帐户配置.
            modelBuilder.Configurations.Add(new UserAccountConfig());

            // 商品 配置.
            modelBuilder.Configurations.Add(new TradableCommodityConfig());

            // 日线.
            modelBuilder.Configurations.Add(new CommodityPriceConfig());

            // 每日小结. 
            modelBuilder.Configurations.Add(new DailySummaryConfig());

        }


    }


}
