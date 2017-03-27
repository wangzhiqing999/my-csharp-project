using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Entity;

using MyToken.Model;
using MyToken.Config;


namespace MyToken.DataAccess
{

    // Enable-Migrations -ProjectName MyToken.DataAccess   -EnableAutomaticMigrations
    public class MyTokenContext : DbContext
    {



        public MyTokenContext()
            : base("name=MyTokenContext")
        {
        }




        /// <summary>
        /// 令牌类型.
        /// </summary>
        public DbSet<TokenType> TokenTypes { get; set; }




        /// <summary>
        /// 令牌数据.
        /// </summary>
        public DbSet<TokenData> TokenDatas { get; set; }




        /// <summary>
        /// 令牌访问日志.
        /// </summary>
        public DbSet<TokenAccessLog> TokenAccessLogs { get; set; }





        /// <summary>
        /// 指定如何创建 表的处理.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // 令牌类型.
            modelBuilder.Configurations.Add(new TokenTypeConfig());

            // 令牌数据.
            modelBuilder.Configurations.Add(new TokenDataConfig());

        }




    }
}
