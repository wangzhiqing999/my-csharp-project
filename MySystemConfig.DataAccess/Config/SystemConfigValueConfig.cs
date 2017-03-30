using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Entity.ModelConfiguration;

using MySystemConfig.Model;



namespace MySystemConfig.Config
{

    /// <summary>
    /// 系统配置数值  配置信息.
    /// </summary>
    class SystemConfigValueConfig : EntityTypeConfiguration<SystemConfigValue>
    {
        public SystemConfigValueConfig()
        {
            // 复合主键 :  类型代码 + 代码.
            this.HasKey(p => new { p.ConfigTypeCode, p.ConfigCode });
        }

    }

}
