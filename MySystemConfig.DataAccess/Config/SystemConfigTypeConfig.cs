using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data.Entity.ModelConfiguration;

using MySystemConfig.Model;




namespace MySystemConfig.Config
{


    /// <summary>
    /// 系统配置类型  配置信息.
    /// </summary>
    class SystemConfigTypeConfig : EntityTypeConfiguration<SystemConfigType>
    {

        public SystemConfigTypeConfig()
        {

            // 一个 系统配置类型  允许 多个 系统配置属性.
            this.HasMany(s => s.SystemConfigPropertyList)
                // 一个 系统配置属性 必须属于 一个 系统配置类型 .
                .WithRequired(m => m.SystemConfigTypeData)
                // 外键的列是  ConfigTypeCode
                .HasForeignKey(m => m.ConfigTypeCode)
                // 取消 外键的 ON DELETE CASCADE 
                // (因为删除 系统配置类型 的操作比较少. 需要避免误操作)
                .WillCascadeOnDelete(false);     


            // 一个 系统配置类型  允许 多个 系统配置值.
            this.HasMany(s => s.SystemConfigValueList)
                // 一个 系统配置值 必须属于 一个 系统配置类型 .
                .WithRequired(m => m.SystemConfigTypeData)
                // 外键的列是  ConfigTypeCode
                .HasForeignKey(m => m.ConfigTypeCode)
                // 取消 外键的 ON DELETE CASCADE 
                // (因为删除 系统配置类型 的操作比较少. 需要避免误操作)
                .WillCascadeOnDelete(false);         
        }


    }

}
