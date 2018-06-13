using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Entity.ModelConfiguration;

using MyExamination.Model;



namespace MyExamination.Config
{


    /// <summary>
    /// 问题主表设置.
    /// </summary>
    class MeQuestionConfig : EntityTypeConfiguration<MeQuestion>
    {

        public MeQuestionConfig()
        {
            // 一个 问题主表  允许 多个 选择项目.
            this.HasMany(s => s.QuestionOptionList)
                // 一个 选择项目  必须属于 一个 问题主表 .
                .WithRequired(m => m.Question)
                // 外键的列是  QuestionID
                .HasForeignKey(m => m.QuestionID)
                // 取消 外键的 ON DELETE CASCADE 
                .WillCascadeOnDelete(false);



            // 一个 问题主表  允许 多个 用户回答 .
            this.HasMany(s => s.UserAnswerList)
                // 一个 用户回答  必须属于 一个 问题主表 .
                .WithRequired(m => m.Question)
                // 外键的列是  QuestionID
                .HasForeignKey(m => m.QuestionID)
                // 取消 外键的 ON DELETE CASCADE 
                .WillCascadeOnDelete(false);

        }

    }


}
