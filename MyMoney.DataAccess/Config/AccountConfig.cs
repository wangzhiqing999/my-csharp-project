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
    /// 账户 配置.
    /// </summary>
    class AccountConfig : EntityTypeConfiguration<Account>
    {
        public AccountConfig()
        {
            // 一个 账户  允许有多个 账户操作日志.
            this.HasMany(s => s.OperationLogList)
                // 一个 账户操作日志  必须 有一个 账户 .
                .WithRequired(m => m.AccountData)
                // 外键的列是  AccountID
                .HasForeignKey(m => m.AccountID)
                // 取消 外键的 ON DELETE CASCADE 
                // (因为删除 账户 的操作, 应该是不允许的)
                .WillCascadeOnDelete(false);


            // 一个 账户  允许有多个 日结报表.
            this.HasMany(s => s.DailyReportList)
                // 一个 日结报表  必须 有一个 账户 .
                .WithRequired(m => m.AccountData)
                // 外键的列是  AccountID
                .HasForeignKey(m => m.AccountID)
                // 取消 外键的 ON DELETE CASCADE 
                // (因为删除 账户 的操作, 应该是不允许的)
                .WillCascadeOnDelete(false);



            // 时间戳
            this.Property(s => s.RowVersion).IsRowVersion();

        }
    }
}
