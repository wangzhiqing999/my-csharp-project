using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Entity.ModelConfiguration;

using MyMiniTradingSystem.Model;


namespace MyMiniTradingSystem.Config
{

    /// <summary>
    /// 用户帐户 配置.
    /// </summary>
    class UserAccountConfig : EntityTypeConfiguration<UserAccount>
    {
        public UserAccountConfig()
        {

            // 一个 用户帐户  允许有多个 仓位.   ( 做多 / 做空 原因. )
            this.HasMany(s => s.Positions)
                // 一个 仓位  必须 有一个 用户帐户.
                .WithRequired(m => m.UserAccountData)
                // 外键的列是  UserCode
                .HasForeignKey(m => m.UserCode)
                // 取消 外键的 ON DELETE CASCADE 
                // (因为删除 用户帐户 的操作极少. 需要避免误操作)
                .WillCascadeOnDelete(false);




            // 一个 用户帐户  允许有多个 每日总结.    
            this.HasMany(s => s.DailySummarys)
                // 一个 每日总结  必须 有一个 用户帐户.
                .WithRequired(m => m.UserAccountData)
                // 外键的列是  UserCode
                .HasForeignKey(m => m.UserCode)
                // 取消 外键的 ON DELETE CASCADE 
                // (因为删除 用户帐户 的操作极少. 需要避免误操作)
                .WillCascadeOnDelete(false);






        }

    }


}
