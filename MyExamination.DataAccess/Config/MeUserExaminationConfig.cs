using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Entity.ModelConfiguration;

using MyExamination.Model;




namespace MyExamination.Config
{

    /// <summary>
    /// 用户考试配置.
    /// </summary>
    class MeUserExaminationConfig : EntityTypeConfiguration<MeUserExamination>
    {

        public MeUserExaminationConfig()
        {

            // 一个 用户考试  允许 有多个 回答.
            this.HasMany(s => s.UserAnswerList)
                // 一个 回答项目  必须属于 一个 用户考试 .
                .WithRequired(m => m.UserExamination)
                // 外键的列是  UserExaminationID
                .HasForeignKey(m => m.UserExaminationID)
                // 取消 外键的 ON DELETE CASCADE 
                .WillCascadeOnDelete(false);

        }

    }
}
