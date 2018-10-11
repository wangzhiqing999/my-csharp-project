namespace MyJob.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using MyJob.Model;


    public sealed class Configuration : DbMigrationsConfiguration<MyJob.DataAccess.MyJobContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MyJob.DataAccess.MyJobContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.


            context.JobTypes.AddOrUpdate(
                p => p.JobTypeCode,
                new JobType { JobTypeCode = "SQL_QUERY", JobTypeName = "数据库查询", JobTypeProcesser = "MyJob.ServiceImpl.SqlQueryJobProcessServiceImpl" },
                new JobType { JobTypeCode = "SQL_UPDATE", JobTypeName = "数据库更新", JobTypeProcesser = "MyJob.ServiceImpl.SqlUpdateJobProcessServiceImpl" },

                new JobType { JobTypeCode = "WINDOWS_CMD", JobTypeName = "Windows 命令行操作", JobTypeProcesser = "MyJob.ServiceImpl.WindowsCmdJobProcessServiceImpl" }
                );
        }
    }
}
