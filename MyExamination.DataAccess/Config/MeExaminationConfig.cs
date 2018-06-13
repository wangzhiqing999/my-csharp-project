using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Entity.ModelConfiguration;

using MyExamination.Model;




namespace MyExamination.Config
{

    /// <summary>
    /// 考试主表设置.
    /// </summary>
    public class MeExaminationConfig: EntityTypeConfiguration<MeExamination>
    {

        public MeExaminationConfig()
        {
            // 一个 考试主表  允许 多个 问题主表.
            this.HasMany(s => s.QuestionList)
                // 一个 问题主表  必须属于 一个 考试主表 .
                .WithRequired(m => m.Examination)
                // 外键的列是  ExaminationID
                .HasForeignKey(m => m.ExaminationID)
                // 取消 外键的 ON DELETE CASCADE 
                // (因为删除 考试主表 的操作比较少. 需要避免误操作)
                .WillCascadeOnDelete(false);



            // 一个 考试主表  允许 参加多个 用户参与考试.
            this.HasMany(s => s.UserExaminationList)
                // 一个 用户考试项目  必须属于 一个 考试主表 .
                .WithRequired(m => m.Examination)
                // 外键的列是  ExaminationID
                .HasForeignKey(m => m.ExaminationID)
                // 取消 外键的 ON DELETE CASCADE 
                // (因为删除 考试主表 的操作比较少. 需要避免误操作)
                .WillCascadeOnDelete(false);

        }

    }


}
