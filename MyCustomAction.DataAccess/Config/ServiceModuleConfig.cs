using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity.ModelConfiguration;


using MyCustomAction.Model;


namespace MyCustomAction.Config
{

    /// <summary>
    /// 服务模块配置.
    /// </summary>
    class ServiceModuleConfig : EntityTypeConfiguration<ServiceModule>  
    {

        public ServiceModuleConfig()
        {
            // 一个 服务模块 允许有 多个 访问本模块的客户行为.
            this.HasMany(s => s.CustomActionList)
                // 一个 客户行为 必须要有一个所属的 服务模块.
                .WithRequired(m => m.AccessServiceModule)
                // 外键的列是 ModuleCode
                .HasForeignKey(m => m.ModuleCode)
                // 取消 外键的 ON DELETE CASCADE 
                // (因为删除 服务模块 的操作极少. 需要避免误操作)
                .WillCascadeOnDelete(false);
        }
    }
}
