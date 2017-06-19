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
    /// 访问明细汇总
    /// </summary>
    class AccessDetailSummaryConfig : EntityTypeConfiguration<AccessDetailSummary>
    {

        public AccessDetailSummaryConfig()
        {
            // 复合主键.
            this.HasKey(p => new { p.AccessTypeCode, p.DetailCode, p.AccessDate });
        }

    }


}
