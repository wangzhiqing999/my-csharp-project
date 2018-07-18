using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MyBuying.Service;
using MyBuying.Model;
using MyFramework.ServiceModel;



namespace MyBuying.Mvc.Controllers
{
    public class BuyingController : Controller
    {

        /// <summary>
        /// 购买服务.
        /// </summary>
        private IBuyingService _BuyingService;



        public BuyingController(IBuyingService buyingService)
        {
            this._BuyingService = buyingService;
        }


        // GET: Buying
        public ActionResult Index()
        {
            return View();
        }




        /// <summary>
        /// 获取可购买的数据.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="batch"></param>
        /// <returns></returns>
        public JsonResult GetBuyableDetail(string id, string batch, string userID)
        {
            CommonServiceResult<long> result = this._BuyingService.GetFirstBuyableCommodityDetail(id, batch, userID);
            return Json(result);
        }


        /// <summary>
        /// 创建订单 (购买操作)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public JsonResult CreateOrder(long id, string userID)
        {
            CommonServiceResult result = this._BuyingService.CreateOrder(id, userID);
            return Json(result);
        }


        /// <summary>
        /// 完成支付.
        /// (这里只是用于测试的， 实际操作中， 是后台收到支付回调的时候，进行处理， 而不是简单前端调用)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult OrderPayed(long id)
        {
            CommonServiceResult<CommodityDetail> result = this._BuyingService.OrderPayed(id);
            return Json(result);
        }


        /// <summary>
        /// 代码使用
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult CodeUsed(string id, string batch, string userCode)
        {
            CommonServiceResult result = this._BuyingService.CommodityDetailUsedByCode(id, batch, userCode);
            return Json(result);
        }


    }
}