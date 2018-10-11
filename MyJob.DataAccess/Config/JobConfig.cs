using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity.ModelConfiguration;

using MyJob.Model;


namespace MyJob.Config
{

    /// <summary>
    /// 作业类型配置.
    /// </summary>
    class JobConfig : EntityTypeConfiguration<Job>
    {


        public JobConfig()
        {

            // 一个 作业  允许 多个 作业时间.
            this.HasMany(s => s.JobTimeList)
                // 一个 作业时间 必须属于 一个 作业 .
                .WithRequired(m => m.JobData)
                // 外键的列是  JobID
                .HasForeignKey(m => m.JobID)
                // 打开 外键的 ON DELETE CASCADE 
                // 当删除作业时， 自动删除作业时间.
                .WillCascadeOnDelete(true);    



            // 一个 作业  允许 多个 作业日志.
            this.HasMany(s => s.JobLogList)
                // 一个 作业日志 必须属于 一个 作业 .
                .WithRequired(m => m.JobData)
                // 外键的列是  JobID
                .HasForeignKey(m => m.JobID)
                // 打开 外键的 ON DELETE CASCADE 
                // 当删除作业时， 自动删除作业日志.
                .WillCascadeOnDelete(true);     
        }

    }

}
