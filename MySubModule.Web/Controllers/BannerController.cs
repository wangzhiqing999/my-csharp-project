using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MyBanner.Service;
using MyBanner.Model;

namespace MySubModule.Web.Controllers
{

    /// <summary>
    /// 横幅
    /// </summary>
    public class BannerController : ApiController
    {

        /// <summary>
        /// 横幅服务.
        /// </summary>
        private IBannerService bannerService;


        /// <summary>
        /// 横幅
        /// </summary>
        /// <param name="bannerService"></param>
        public BannerController(IBannerService bannerService)
        {
            this.bannerService = bannerService;
        }




        /// <summary>
        /// 获取横幅列表
        /// </summary>
        /// <param name="code">横幅分类代码</param>
        /// <returns></returns>
        public IHttpActionResult GetBannerList(string code)
        {
            var dataList = this.bannerService.GetBannerList(code);

            var query =
                from data in dataList
                select new
                {
                    BannerID = data.BannerID,
                    BannerText = data.BannerText,
                    BannerImage = data.BannerImage,
                    BannerUrl = data.BannerUrl
                };

            var result = query.ToList();
            return Ok(result);
        }


    }


}
