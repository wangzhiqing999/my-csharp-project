using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data.Entity.ModelConfiguration;

using MySystemConfig.Model;


namespace MySystemConfig.Config
{
    class SystemConfigPropertyConfig : EntityTypeConfiguration<SystemConfigProperty>
    {

        public SystemConfigPropertyConfig()
        {
            // 复合主键 :  类型代码 + 属性名.
            this.HasKey(p => new { p.ConfigTypeCode, p.PropertyName });
        }

    }

}
