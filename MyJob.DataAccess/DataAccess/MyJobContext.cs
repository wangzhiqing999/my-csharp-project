using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;


using MyJob.Model;
using MyJob.Config;


namespace MyJob.DataAccess
{
    //  Enable-Migrations -ProjectName MyJob.DataAccess  -EnableAutomaticMigrations
    public class MyJobContext : DbContext
    {
        public MyJobContext()
            : base("name=MyJobContext")
        {
        }



        /// <summary>
        /// 作业类型.
        /// </summary>
        public DbSet<JobType> JobTypes { get; set; }


        /// <summary>
        /// 作业.
        /// </summary>
        public DbSet<Job> Jobs { get; set; }


        /// <summary>
        /// 作业时间.
        /// </summary>
        public DbSet<JobTime> JobTimes { get; set; }
        

        /// <summary>
        /// 作业日志.
        /// </summary>
        public DbSet<JobLog> JobLogs { get; set; }








        /// <summary>
        /// 指定如何创建 表的处理.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 作业类型 配置信息.
            modelBuilder.Configurations.Add(new JobTypeConfig());

            // 作业 配置信息.
            modelBuilder.Configurations.Add(new JobConfig());

        }


    }
}
