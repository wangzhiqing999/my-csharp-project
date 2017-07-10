using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using System.Data.Entity.ModelConfiguration;

using MyMoney.Model;



namespace MyMoney.Config
{

    /// <summary>
    /// 账户操作类型 配置.
    /// </summary>
    public class AccountOperationTypeConfig : EntityTypeConfiguration<AccountOperationType>
    {
        public AccountOperationTypeConfig()
        {
            // 一个 账户操作类型  允许有多个 账户操作日志.
            this.HasMany(s => s.OperationLogList)
                // 一个 账户操作日志  必须 有一个 账户操作类型.
                .WithRequired(m => m.OperationType)
                // 外键的列是  OperationTypeCode
                .HasForeignKey(m => m.OperationTypeCode)
                // 取消 外键的 ON DELETE CASCADE 
                // (因为删除 账户操作类型 的操作极少. 需要避免误操作)
                .WillCascadeOnDelete(false);
        }
    }

}
