using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data.Entity.ModelConfiguration;

using MyToken.Model;



namespace MyToken.Config
{

    /// <summary>
    /// 令牌类型  配置信息.
    /// </summary>
    class TokenTypeConfig : EntityTypeConfiguration<TokenType>
    {
        public TokenTypeConfig()
        {
            // 一个 令牌类型  允许 多个 令牌数据.
            this.HasMany(s => s.TokenDataList)
                // 一个 令牌数据 必须属于 一个 令牌类型 .
                .WithRequired(m => m.TokenTypeData)
                // 外键的列是  TokenTypeCode
                .HasForeignKey(m => m.TokenTypeCode)
                // 取消 外键的 ON DELETE CASCADE 
                // (因为删除 令牌类型 的操作比较少. 需要避免误操作)
                .WillCascadeOnDelete(false);
        }
    }
}
