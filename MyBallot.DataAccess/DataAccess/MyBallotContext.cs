using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



using System.Data.Entity;

using MyBallot.Config;
using MyBallot.Model;



namespace MyBallot.DataAccess
{

    // Enable-Migrations -ProjectName MyBallot.DataAccess  -EnableAutomaticMigrations
    public class MyBallotContext: DbContext
    {


        public MyBallotContext()
            : base("name=MyBallotContext")
        {
        }



        /// <summary>
        /// 投票类型.
        /// </summary>
        public DbSet<BallotType> BallotTypes { get; set; }

        /// <summary>
        /// 投票类型.
        /// </summary>
        public DbSet<BallotTypeDetail> BallotTypeDetails { get; set; }





        /// <summary>
        /// 投票主表.
        /// </summary>
        public DbSet<BallotMaster> BallotMasters { get; set; }

        /// <summary>
        /// 投票明细.
        /// </summary>
        public DbSet<BallotDetail> BallotDetails { get; set; }





        /// <summary>
        /// 用户投票.
        /// </summary>
        public DbSet<UserBallot> UserBallots { get; set; }







        
        /// <summary>
        /// 指定如何创建 表的处理.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // 投票分类 配置信息.
            modelBuilder.Configurations.Add(new BallotTypeConfig());

            // 投票分类明细  配置信息 
            modelBuilder.Configurations.Add(new BallotTypeDetailConfig());



            // 投票主表 配置信息.
            modelBuilder.Configurations.Add(new BallotMasterConfig());

            // 投票明细 配置
            modelBuilder.Configurations.Add(new BallotDetailConfig());
        }



    }


}
