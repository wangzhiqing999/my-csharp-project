using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using System.Data.Entity.ModelConfiguration;

using MyAccessStatistics.Model;


namespace MyAccessStatistics.Config
{

    /// <summary>
    /// 访问类型.
    /// </summary>
    class AccessTypeConfig : EntityTypeConfiguration<AccessType>
    {

        public AccessTypeConfig()
        {

            // 一个 访问类型  允许 多个 访问类型汇总.
            this.HasMany(s => s.AccessSummaryList)
                // 一个 访问类型汇总 必须属于 一个 访问类型  .
                .WithRequired(m => m.AccessTypeData)
                // 外键的列是  AccessTypeCode
                .HasForeignKey(m => m.AccessTypeCode)
                // 取消 外键的 ON DELETE CASCADE 
                .WillCascadeOnDelete(false);




            // 一个 访问类型  允许 多个 访问明细.
            this.HasMany(s => s.AccessDetailList)
                // 一个 访问明细 必须属于 一个 访问类型  .
                .WithRequired(m => m.AccessTypeData)
                // 外键的列是  AccessTypeCode
                .HasForeignKey(m => m.AccessTypeCode)
                // 取消 外键的 ON DELETE CASCADE 
                .WillCascadeOnDelete(false);




            // 一个 访问类型  允许 多个 访问明细汇总.
            this.HasMany(s => s.AccessDetailSummaryList)
                // 一个 访问明细 必须属于 一个 访问类型  .
                .WithRequired(m => m.AccessTypeData)
                // 外键的列是  AccessTypeCode
                .HasForeignKey(m => m.AccessTypeCode)
                // 取消 外键的 ON DELETE CASCADE 
                .WillCascadeOnDelete(false);




            // 一个 访问类型  允许 多个 访问明细日志.
            this.HasMany(s => s.AccessDetailLogList)
                // 一个 访问明细 必须属于 一个 访问类型  .
                .WithRequired(m => m.AccessTypeData)
                // 外键的列是  AccessTypeCode
                .HasForeignKey(m => m.AccessTypeCode)
                // 取消 外键的 ON DELETE CASCADE 
                .WillCascadeOnDelete(false);


        }






    }
}
