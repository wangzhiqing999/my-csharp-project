using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MyFramework.Util;

using MyFx678Kx.Model;
using MyFx678Kx.Service;



namespace MySubModule.Web.Controllers
{

    /// <summary>
    /// 快讯
    /// </summary>
    public class Fx678KxController : ApiController
    {

        /// <summary>
        /// 快讯服务.
        /// </summary>
        private IFx678KxService fx678KxService;


        /// <summary>
        /// 快讯
        /// </summary>
        /// <param name="fx678KxService"></param>
        public Fx678KxController(IFx678KxService fx678KxService)
        {
            this.fx678KxService = fx678KxService;
        }



        /// <summary>
        /// 获取快讯列表.
        /// </summary>
        /// <param name="pageNo">第几页（默认1）</param>
        /// <param name="pageSize">每页几行（默认20）</param>
        /// <returns></returns>
        public IHttpActionResult GetKxList(int pageNo = 1, int pageSize = 20)
        {
            PageInfo pgInfo = new PageInfo();
            var dataList = this.fx678KxService.GetFx678KxList(ref pgInfo, pageNo, pageSize);

            var result = new 
            {
                PageIndex = pgInfo.PageIndex,
                PageSize = pgInfo.PageSize,
                RowCount = pgInfo.RowCount,
                KxList = dataList
            };

            return Ok(result);
        }



    }
}
