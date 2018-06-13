using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Entity.ModelConfiguration;

using MyExamination.Model;



namespace MyExamination.Config
{


    /// <summary>
    /// 用户表设置.
    /// </summary>
    class MeUserConfig : EntityTypeConfiguration<MeUser>
    {

        public MeUserConfig()
        {
            // 一个 用户  允许 参加多个 考试项目.
            this.HasMany(s => s.UserExaminationList)
                // 一个 用户考试项目  必须属于 一个 用户 .
                .WithRequired(m => m.User)
                // 外键的列是  UserID
                .HasForeignKey(m => m.UserID)
                // 取消 外键的 ON DELETE CASCADE 
                .WillCascadeOnDelete(false);



            // 一个 用户  允许 有多个 回答.
            this.HasMany(s => s.UserAnswerList)
                // 一个 回答项目  必须属于 一个 用户 .
                .WithRequired(m => m.User)
                // 外键的列是  UserID
                .HasForeignKey(m => m.UserID)
                // 取消 外键的 ON DELETE CASCADE 
                .WillCascadeOnDelete(false);

        }

    }

}
