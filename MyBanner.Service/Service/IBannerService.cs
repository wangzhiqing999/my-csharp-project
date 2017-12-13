using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using MyBanner.Model;



namespace MyBanner.Service
{

    /// <summary>
    /// 网站横幅服务.
    /// </summary>
    public interface IBannerService
    {


        /// <summary>
        /// 获取网站横幅列表.
        /// </summary>
        /// <param name="bannerTypeCode"></param>
        /// <returns></returns>
        List<Banner> GetBannerList(string bannerTypeCode);


    }

}
