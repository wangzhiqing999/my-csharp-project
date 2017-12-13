using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyBanner.Model;
using MyBanner.DataAccess;
using MyBanner.Service;


namespace MyBanner.ServiceImpl
{

    /// <summary>
    /// 网站横幅服务 默认实现.
    /// </summary>
    public class DefaultBannerService : IBannerService
    {

        /// <summary>
        /// 获取网站横幅列表.
        /// </summary>
        /// <param name="bannerTypeCode"></param>
        /// <returns></returns>
        public List<Banner> GetBannerList(string bannerTypeCode)
        {
            using (MyBannerContext context = new MyBannerContext())
            {
                var query =
                    from data in context.Banners
                    where
                        // 指定分类.
                        data.BannerTypeCode == bannerTypeCode
                        // 数据必须是有效的.
                        && data.Status == Banner.STATUS_IS_ACTIVE
                        // 已经开始.
                        && data.StartDate <= DateTime.Today
                        // 尚未结束.
                        && data.FinishDate >= DateTime.Today
                    orderby
                        data.DisplayOrder
                    select
                        data;


                List<Banner> resultList = query.ToList();

                return resultList;
            }
        }

    }

}
