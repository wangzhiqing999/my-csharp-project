using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;

using log4net;

using MyFramework.ServiceModel;

using MyBuying.Service;
using MyBuying.Model;





namespace MyBuying.Mvc.Controllers
{

    /// <summary>
    /// 锁定方式的购买.
    /// </summary>
    public class LockBuyingController : Controller
    {

        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        /// <summary>
        /// 购买服务.
        /// </summary>
        private IBuyingService _BuyingService;



        public LockBuyingController(IBuyingService buyingService)
        {
            this._BuyingService = buyingService;
        }



        /// <summary>
        /// 用于锁定的对象.
        /// </summary>
        static object _Locker = new object();





        // GET: LockBuying
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

            if (logger.IsDebugEnabled)
            {
                logger.DebugFormat("GetBuyableDetail ( {0}, {1}, {2}  ) Start",  id, batch, userID);
            }


            // 注意： 
            // 这种操作方式， 是通过 锁定一个对象，来避免 一个商品， 被多个人抢购到。

            // 存在的问题：
            // 1. 用户多的情况下，会卡得一塌糊涂。 (当然和这里 lock 里面休眠 5秒有关系)
            // 2. 无法确保先到先得。

            lock (_Locker)
            {

                // 为了测试多人同时抢购的操作.
                // 这里休眠5秒.
                Thread.Sleep(5000);

                CommonServiceResult<long> result = this._BuyingService.GetFirstBuyableCommodityDetail(id, batch, userID);


                logger.DebugFormat("GetBuyableDetail ( {0}, {1}, {2}  ) Finish, Result = {3}", id, batch, userID, result);

                return Json(result);

            }
        }





    }
}