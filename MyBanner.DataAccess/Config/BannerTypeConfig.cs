using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity.ModelConfiguration;

using MyBanner.Model;



namespace MyBanner.Config
{

    /// <summary>
    /// 网站横幅类型 配置信息.
    /// </summary>
    class BannerTypeConfig : EntityTypeConfiguration<BannerType>
    {

        public BannerTypeConfig()
        {
            // 一个 网站横幅类型  允许 多个 网站横幅.
            this.HasMany(s => s.BannerList)
                // 一个 网站横幅 必须属于 一个 网站横幅类型 .
                .WithRequired(m => m.BannerTypeData)
                // 外键的列是  BannerTypeCode
                .HasForeignKey(m => m.BannerTypeCode)
                // 取消 外键的 ON DELETE CASCADE 
                // (因为删除 网站横幅类型 的操作比较少. 需要避免误操作)
                .WillCascadeOnDelete(false);
        }


    }
}
