using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Entity.ModelConfiguration;

using MyMiniTradingSystem.Model;


namespace MyMiniTradingSystem.Config
{


    /// <summary>
    /// 商品 配置.
    /// </summary>
    public class TradableCommodityConfig : EntityTypeConfiguration<TradableCommodity>
    {

        public TradableCommodityConfig()
        {

            // 一个 商品  允许有多个 日线数据.
            this.HasMany(s => s.CommodityPrices)
                // 一个 日线数据  必须 有一个 商品.
                .WithRequired(m => m.TradableCommodityData)
                // 外键的列是  CommodityCode
                .HasForeignKey(m => m.CommodityCode)
                // 取消 外键的 ON DELETE CASCADE 
                // (因为删除 商品 的操作极少. 需要避免误操作)
                .WillCascadeOnDelete(false);


            // 一个 商品  允许有多个 每日总结.
            this.HasMany(s => s.DailySummarys)
                // 一个 每日总结  必须 有一个 商品.
                .WithRequired(m => m.PositionTradableCommodity)
                // 外键的列是  PositionCommodityCode
                .HasForeignKey(m => m.PositionCommodityCode)
                // 取消 外键的 ON DELETE CASCADE 
                // (因为删除 商品 的操作极少. 需要避免误操作)
                .WillCascadeOnDelete(false);


            // 一个 商品  允许有多个 仓位.   ( 做多 / 做空 原因. )
            this.HasMany(s => s.Positions)
                // 一个 仓位  必须 有一个 商品.
                .WithRequired(m => m.TradableCommodityData)
                // 外键的列是  CommodityCode
                .HasForeignKey(m => m.CommodityCode)
                // 取消 外键的 ON DELETE CASCADE 
                // (因为删除 商品 的操作极少. 需要避免误操作)
                .WillCascadeOnDelete(false);







        }

    }

}
