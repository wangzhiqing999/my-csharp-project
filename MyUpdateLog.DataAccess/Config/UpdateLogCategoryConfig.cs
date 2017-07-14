using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data.Entity.ModelConfiguration;

using MyUpdateLog.Model;



namespace MyUpdateLog.Config
{


    /// <summary>
    /// 更新日志分类表 配置.
    /// </summary>
    class UpdateLogCategoryConfig : EntityTypeConfiguration<UpdateLogCategory>
    {

        public UpdateLogCategoryConfig()
        {

            // 一个 更新日志分类表  允许有多个 更新日志.
            this.HasMany(s => s.UpdateLogDetails)
                // 一个 更新日志  必须 有一个 更新日志分类表 .
                .WithRequired(m => m.UpdateLogCategoryData)
                // 外键的列是  CategoryCode
                .HasForeignKey(m => m.CategoryCode)
                // 取消 外键的 ON DELETE CASCADE 
                .WillCascadeOnDelete(false);

        }

    }


}
