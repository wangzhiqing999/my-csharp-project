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
    class JobTypeConfig : EntityTypeConfiguration<JobType>
    {


        public JobTypeConfig()
        {
            // 一个 作业类型  允许 多个 作业.
            this.HasMany(s => s.JobList)
                // 一个 作业 必须属于 一个 作业类型 .
                .WithRequired(m => m.JobTypeData)
                // 外键的列是  JobTypeCode
                .HasForeignKey(m => m.JobTypeCode)
                // 取消 外键的 ON DELETE CASCADE 
                // (因为删除 作业类型 的操作比较少. 需要避免误操作)
                .WillCascadeOnDelete(false);     
        }

    }

}
