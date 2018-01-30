using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Entity.ModelConfiguration;

using MyMiniTradingSystem.Model;

namespace MyMiniTradingSystem.Config
{


    class CommodityPriceConfig : EntityTypeConfiguration<CommodityPrice>
    {


        public CommodityPriceConfig()
        {
            // 复合主键.
            this.HasKey(p => new { p.CommodityCode, p.TradingStartDate });


            // 开盘.
            this.Property(p => p.OpenPrice).HasPrecision(10, 3);
            // 收盘
            this.Property(p => p.ClosePrice).HasPrecision(10, 3);

            // 最高.
            this.Property(p => p.HighestPrice).HasPrecision(10, 3);
            // 最低.
            this.Property(p => p.LowestPrice).HasPrecision(10, 3);


            this.Property(p => p.Tr).HasPrecision(10, 3);
            this.Property(p => p.Atr).HasPrecision(10, 3);

        }

    }
}
