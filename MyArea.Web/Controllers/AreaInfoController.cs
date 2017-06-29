using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MyArea.Service;
using MyArea.Model;


namespace MyArea.Web.Controllers
{
    public class AreaInfoController : Controller
    {
        // GET: AreaInfo
        public ActionResult Index()
        {
            return View();
        }




        /// <summary>
        /// 区域信息服务.
        /// </summary>
        private IAreaInfoService areaInfoService;




        public AreaInfoController(IAreaInfoService areaInfoService)
        {
            this.areaInfoService = areaInfoService;
        }




        /// <summary>
        /// 顶级区域.
        /// </summary>
        /// <returns></returns>
        [OutputCache(Duration = 30)]
        public JsonResult RootArea()
        {
            var dataList = this.areaInfoService.GetRootAreaInfoList();
            return FormatJsonResult(dataList);
        }


        /// <summary>
        /// 子区域.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OutputCache(Duration = 30, VaryByParam = "id")]
        public JsonResult SubArea(string id)
        {
            var dataList = this.areaInfoService.GetSubAreaInfoList(id);
            return FormatJsonResult(dataList);
        }



        /// <summary>
        /// 格式化 json 输出.
        /// </summary>
        /// <param name="dataList"></param>
        /// <returns></returns>
        private JsonResult FormatJsonResult(List<AreaInfo> dataList)
        {
            var query =
                from data in dataList
                select new
                {
                    areaCode = data.AreaCode,
                    areaName = data.AreaName
                };

            var result = query.ToList();
            return Json(data: result, behavior: JsonRequestBehavior.AllowGet);
        }

    }
}