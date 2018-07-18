using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity.ModelConfiguration;

using MyBuying.Model;


namespace MyBuying.Config
{

    /// <summary>
    /// 商品主表
    /// </summary>
    class CommodityMasterConfig : EntityTypeConfiguration<CommodityMaster>
    {
        public CommodityMasterConfig()
        {
            // 一个 商品主表  允许 多个 商品明细模板.
            this.HasMany(s => s.CommodityDetailTemplateList)
                // 一个 商品明细模板 必须属于 一个 商品主表 .
                .WithRequired(m => m.CommodityMasterData)
                // 外键的列是  CommodityMasterCode
                .HasForeignKey(m => m.CommodityMasterCode)
                // 取消 外键的 ON DELETE CASCADE 
                .WillCascadeOnDelete(false);


            // 一个 商品主表  允许 多个 商品明细.
            this.HasMany(s => s.CommodityDetailList)
                // 一个 商品明细 必须属于 一个 商品主表 .
                .WithRequired(m => m.CommodityMasterData)
                // 外键的列是  CommodityMasterCode
                .HasForeignKey(m => m.CommodityMasterCode)
                // 取消 外键的 ON DELETE CASCADE 
                .WillCascadeOnDelete(false);
        }
    }

}
