using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Entity.ModelConfiguration;

using MyToken.Model;



namespace MyToken.Config
{

    /// <summary>
    /// 令牌数据.
    /// </summary>
    class TokenDataConfig : EntityTypeConfiguration<TokenData>
    {


        public TokenDataConfig()
        {
            // 一个 令牌数据  允许 多个 令牌访问日志.
            this.HasMany(s => s.TokenAccessLogList)
                // 一个 令牌访问日志 必须属于 一个 令牌数据 .
                .WithRequired(m => m.TokenData)
                // 外键的列是  TokenID
                .HasForeignKey(m => m.TokenID)
                // 打开 外键的 ON DELETE CASCADE 
                // 删除令牌的同时， 删除日志.
                .WillCascadeOnDelete(true);
        }
    }

}
