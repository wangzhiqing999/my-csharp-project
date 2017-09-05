using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using log4net;


using MyChatRoom.Model;
using MyChatRoom.Service;



namespace MyChatRoom.Mvc.Controllers
{
    public class HouseController : Controller
    {


        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        /// <summary>
        /// 房间服务.
        /// </summary>
        private IChatRoomHouseService chatRoomHouseService;



        public HouseController(IChatRoomHouseService chatRoomHouseService)
        {
            this.chatRoomHouseService = chatRoomHouseService;
        }





        // GET: House
        public ActionResult Index(string id)
        {
            // 获取房间信息.
            ChatRoomHouse house = this.chatRoomHouseService.GetChatRoomHouse(id);

            if (house == null)
            {

                if (logger.IsDebugEnabled)
                {
                    logger.DebugFormat("尝试访问不存在的 直播室房间 {0}", id);
                }

                // 房间不存在.
                return HttpNotFound();
            }




            // TODO : 根据房间的登录类型， 判断 是否要登录， 以及如何跳转登录页 （）。
            switch (house.LoginMode)
            {
                case HouseLoginMode.Unkonw:
                case HouseLoginMode.None:
                    // 未设定， 或者不用登录的情况下， 忽略.
                    break;

                case HouseLoginMode.HousePassword:
                    // 房间登录
                    break;

                case HouseLoginMode.LocalUserPassword:
                    // 本地用户登录.
                    break;

                case HouseLoginMode.RemoteUserToken:
                    // 外部用户 Token 登录.
                    break;
            }






            // 直播室页面.
            var housePage = house.HousePageData;

            if (housePage == null ||  String.IsNullOrEmpty(housePage.HousePagePath))
            {
                // 未指定页面， 使用默认视图.
                return View(model: house);
            }



            // 如果手机访问， 并且指定的手机页面非空， 则跳转到  手机页面.
            if (Request.Browser != null && Request.Browser.IsMobileDevice && !String.IsNullOrEmpty(housePage.HousePagePathPhone))
            {
                return View(viewName: housePage.HousePagePathPhone, model: house);
            }



            // 其它情况下， 返回 PC 页面.
            return View(viewName: housePage.HousePagePath, model: house);
        }



    }
}