using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

using MyAccessStatistics.Model;
using MyAccessStatistics.Config;


namespace MyAccessStatistics.DataAccess
{


    // Enable-Migrations -ProjectName MyAccessStatistics.DataAccess  -EnableAutomaticMigrations
    public class MyAccessStatisticsContext : DbContext
    {

        public MyAccessStatisticsContext()
            : base("name=MyAccessStatisticsContext")
        {
        }



        /// <summary>
        /// 访问类型
        /// </summary>
        public DbSet<AccessType> AccessTypes { get; set; }


        /// <summary>
        /// 访问类型汇总
        /// </summary>
        public DbSet<AccessTypeSummary> AccessTypeSummarys { get; set; }


        /// <summary>
        /// 访问明细
        /// </summary>
        public DbSet<AccessDetail> AccessDetails { get; set; }



        /// <summary>
        /// 访问明细汇总
        /// </summary>
        public DbSet<AccessDetailSummary> AccessDetailSummarys { get; set; }



        /// <summary>
        /// 访问明细日志.
        /// </summary>
        public DbSet<AccessDetailLog> AccessDetailLogs { get; set; }






        /// <summary>
        /// 指定如何创建 表的处理.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            // 访问类型表 配置信息.
            modelBuilder.Configurations.Add(new AccessTypeConfig());

            
            // 访问类型汇总 配置信息.
            modelBuilder.Configurations.Add(new AccessTypeSummaryConfig());

            
            // 访问明细 配置信息.
            modelBuilder.Configurations.Add(new AccessDetailConfig());

            
            // 访问明细汇总 配置信息.
            modelBuilder.Configurations.Add(new AccessDetailSummaryConfig());

        }



    }
}
