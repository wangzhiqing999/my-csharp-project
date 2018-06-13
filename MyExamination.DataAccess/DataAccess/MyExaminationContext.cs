using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data.Entity;

using MyExamination.Config;
using MyExamination.Model;



namespace MyExamination.DataAccess
{

    //  Enable-Migrations -ProjectName MyExamination.DataAccess  -EnableAutomaticMigrations
    public class MyExaminationContext : DbContext
    {
        public MyExaminationContext()
            : base("name=MyExaminationContext")
        {
        }




        /// <summary>
        /// 考试.
        /// </summary>
        public DbSet<MeExamination> Examinations { get; set; }


        /// <summary>
        /// 问题.
        /// </summary>
        public DbSet<MeQuestion> Questions { get; set; }

        /// <summary>
        /// 问题选项.
        /// </summary>
        public DbSet<MeQuestionOption> QuestionOptions { get; set; }




        /// <summary>
        /// 用户.
        /// </summary>
        public DbSet<MeUser> Users { get; set; }

        /// <summary>
        /// 用户考试.
        /// </summary>
        public DbSet<MeUserExamination> UserExaminations { get; set; }

        /// <summary>
        /// 用户回答.
        /// </summary>
        public DbSet<MeUserAnswer> UserAnswers { get; set; }


        /// <summary>
        /// 指定如何创建 表的处理.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 考试 配置信息.
            modelBuilder.Configurations.Add(new MeExaminationConfig());

            // 问题 配置信息.
            modelBuilder.Configurations.Add(new MeQuestionConfig());



            // 用户 配置信息.
            modelBuilder.Configurations.Add(new MeUserConfig());


            // 用户考试 配置信息.
            modelBuilder.Configurations.Add(new MeUserExaminationConfig());

        }

    }


}
