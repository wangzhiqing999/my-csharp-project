using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity.ModelConfiguration;

using MyWeb.Model;

namespace MyWeb.Config
{
    class ModuleConfig : EntityTypeConfiguration<Module>
    {
        public ModuleConfig()
        {
            // 一个 模块  允许 多个 页面.
            this.HasMany(s => s.ModulePages)
                // 一个 页面 必须属于 一个 模块 .
                .WithRequired(m => m.PageModule)
                // 外键的列是  ModuleCode
                .HasForeignKey(m => m.ModuleCode)
                // 取消 外键的 ON DELETE CASCADE 
                // (因为删除 模块 的操作比较少. 需要避免误操作)
                .WillCascadeOnDelete(false);     
        }
    }
}
