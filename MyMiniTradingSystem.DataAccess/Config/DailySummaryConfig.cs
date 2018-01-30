using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data.Entity.ModelConfiguration;

using MyMiniTradingSystem.Model;


namespace MyMiniTradingSystem.Config
{


    public class DailySummaryConfig : EntityTypeConfiguration<DailySummary>
    {


        public DailySummaryConfig()
        {
            // 收盘
            this.Property(p => p.ClosePrice).HasPrecision(10, 3);

            // 持仓市值
            this.Property(p => p.PositionValue).HasPrecision(10, 3);
        }


    }

}
