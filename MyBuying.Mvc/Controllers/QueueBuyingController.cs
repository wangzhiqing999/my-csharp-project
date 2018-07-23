using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using log4net;

using MyFramework.ServiceModel;

using MyBuying.Service;
using MyBuying.ServiceModel;
using MyBuying.Model;
using MyBuying.Util;



namespace MyBuying.Mvc.Controllers
{

    /// <summary>
    /// 队列方式购买.
    /// </summary>
    public class QueueBuyingController : Controller
    {

        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 管理队列.
        /// </summary>
        private static BuyerQueueManager buyerQueueManager = BuyerQueueManager.GetInstance();



        public QueueBuyingController()
        {
        }



        // GET: QueueBuying
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
                logger.DebugFormat("GetBuyableDetail ( {0}, {1}, {2}  ) Start", id, batch, userID);
            }

            BuyingData buyingData = new BuyingData()
            {
                CommodityMasterCode = id,
                Batch = batch,
                BuyerCode = userID
            };


            // 这里是 入队列后， 立即返回。
            // 后续客户端通过调用 IsInQueue， 来判断请求是否还在队列里面。
            // 当队列中没有请求的时候， 说明请求已经被处理，通过调用 GetServiceResult 获取执行的结果。

            // 这种处理方式
            // 优点是 客户端不卡， 可以做到 先到先得。
            // 缺点是 客户端/服务端代码量，稍微增加一些。
            CommonServiceResult<int> result = buyerQueueManager.Enqueue(buyingData);

            if (logger.IsDebugEnabled)
            {
                logger.DebugFormat("GetBuyableDetail ( {0}, {1}, {2}  ) Result: {3}", id, batch, userID, result);
            }

            return Json(result);
        }


        /// <summary>
        /// 是否在队列.
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public JsonResult IsInQueue(string userID)
        {
            if (logger.IsDebugEnabled)
            {
                logger.DebugFormat("IsInQueue ( {0}  ) Start", userID);
            }

            CommonServiceResult result = buyerQueueManager.IsInQueue(userID);


            if (logger.IsDebugEnabled)
            {
                logger.DebugFormat("IsInQueue ( {0}  ) Result: {1}", userID, result);
            }

            return Json(result);
        }


        /// <summary>
        /// 获取处理结果.
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public JsonResult GetServiceResult(string userID)
        {
            if (logger.IsDebugEnabled)
            {
                logger.DebugFormat("GetServiceResult ( {0}  ) Start", userID);
            }

            CommonServiceResult<long> result = buyerQueueManager.GetServiceResult(userID);


            if (logger.IsDebugEnabled)
            {
                logger.DebugFormat("GetServiceResult ( {0}  ) Result: {1}", userID, result);
            }

            return Json(result);
        }



    }
}