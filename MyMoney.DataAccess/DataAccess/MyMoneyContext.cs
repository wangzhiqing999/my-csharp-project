using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;


using MyMoney.Config;
using MyMoney.Model;




namespace MyMoney.DataAccess
{



    // Enable-Migrations -ProjectName MyMoney.DataAccess  -EnableAutomaticMigrations
    public class MyMoneyContext : DbContext
    {


        public MyMoneyContext()
            : base("name=MyMoneyContext")
        {
        }




        /// <summary>
        /// 账户.
        /// </summary>
        public DbSet<Account> Accounts { get; set; }

        /// <summary>
        /// 账户操作类型.
        /// </summary>
        public DbSet<AccountOperationType> AccountOperationTypes { get; set; }

        /// <summary>
        /// 账户操作日志.
        /// </summary>
        public DbSet<AccountOperationLog> AccountOperationLogs { get; set; }

        /// <summary>
        /// 日结报表.
        /// </summary>
        public DbSet<AccountDailyReport> AccountDailyReports { get; set; }






        /// <summary>
        /// 指定如何创建 表的处理.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // 账户操作类型 配置.
            modelBuilder.Configurations.Add(new AccountOperationTypeConfig());

            // 账户 配置.
            modelBuilder.Configurations.Add(new AccountConfig());


        }

    }
}
