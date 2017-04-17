using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using MySystemConfig.Model;
using MySystemConfig.DataAccess;
using MySystemConfig.Service;
using MySystemConfig.ServiceImpl;

namespace MySystemConfig.Mvc.Controllers
{


    public class SystemConfigValueController : Controller
    {

        /// <summary>
        /// 系统配置服务.
        /// </summary>
        private ISystemConfigService systemConfigService = new DefaultSystemConfigService();



        // GET: SystemConfigValue
        public ActionResult Index(string queryConfigTypeCode)
        {

            List<SystemConfigValue> dataList = null;

            using (MySystemConfigContext context = new MySystemConfigContext())
            {
                var query =
                    from data in context.SystemConfigValues
                    select data;


                if (!String.IsNullOrEmpty(queryConfigTypeCode))
                {
                    query = query.Where(p => p.ConfigCode == queryConfigTypeCode);
                }


                // 查询数据.
                dataList = query.ToList();
            }


            return View(model:dataList);
        }




        // GET: SystemConfig/Details/5
        public ActionResult Details(string configTypeCode, string configCode)
        {
            // 配置类型.
            SystemConfigType sct = this.systemConfigService.GetSystemConfigType(configTypeCode);
            ViewBag.SystemConfigType = sct;

            // 配置属性
            List<SystemConfigProperty> scp = this.systemConfigService.GetSystemConfigPropertyByType(configTypeCode);
            ViewBag.SystemConfigPropertys = scp;

            // 数据.
            SystemConfigValue data = this.systemConfigService.GetSystemConfigValue(configTypeCode, configCode);
                        
            if (data == null)
            {
                return HttpNotFound();
            }

            return View(model: data);
        }



        /// <summary>
        /// 基本数据类型转换.
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private object BasicDataConvert(string dataType, string value)
        {
            switch (dataType)
            {
                case "System.Int32":
                    return Convert.ToInt32(value);

                case "System.Int64":
                    return Convert.ToInt64(value);

                case "System.Boolean":
                    return !String.IsNullOrEmpty(value);

                default:
                    return value;

            }
        }






        // GET: SystemConfig/Edit/5
        public ActionResult Edit(string configTypeCode, string configCode)
        {

            // 配置类型.
            SystemConfigType sct = this.systemConfigService.GetSystemConfigType(configTypeCode);
            ViewBag.SystemConfigType = sct;

            // 配置属性
            List<SystemConfigProperty> scp = this.systemConfigService.GetSystemConfigPropertyByType(configTypeCode);
            ViewBag.SystemConfigPropertys = scp;

            // 数据.
            SystemConfigValue data = this.systemConfigService.GetSystemConfigValue(configTypeCode, configCode);
                       
            if (data == null)
            {
                return HttpNotFound();
            }


            return View(model: data);
        }



        // POST: SystemConfig/Edit/5
        [HttpPost]
        public ActionResult Edit(string configTypeCode, string configCode, FormCollection collection)
        {
            SystemConfigValue data = null;

            try
            {
                // 配置类型.
                SystemConfigType sct = this.systemConfigService.GetSystemConfigType(configTypeCode);
                ViewBag.SystemConfigType = sct;

                // 配置属性
                List<SystemConfigProperty> scp = this.systemConfigService.GetSystemConfigPropertyByType(configTypeCode);
                ViewBag.SystemConfigPropertys = scp;


                // 数据.
                data = this.systemConfigService.GetSystemConfigValue(configTypeCode, configCode);



                if (data == null)
                {
                    return HttpNotFound();
                }


                if (data.SystemConfigTypeData.ConfigClassName == SystemConfigType.SimpleDictionary)
                {
                    Dictionary<string, Object> configObj = new Dictionary<string, object>();
                    foreach (var prop in scp)
                    {
                        String value = collection[prop.PropertyName];
                        configObj.Add(prop.PropertyName, BasicDataConvert(prop.PropertyDataType, value));
                    }

                    data.ConfigValueObject = configObj;
                }
                else
                {
                    data.ConfigValueObject = BasicDataConvert(sct.ConfigClassName, collection["ConfigValue"]);
                }



                string resultMsg = null;
                bool result = this.systemConfigService.UpdateSystemConfigValue(data, ref resultMsg);

                if (!result)
                {
                    return View(model: data);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model: data);
            }
        }







        /// <summary>
        /// 测试获取某一个类型的所有配置.
        /// </summary>
        /// <param name="configTypeCode"></param>
        /// <returns></returns>
        public JsonResult GetConfigList(string configTypeCode)
        {
            List<SystemConfigValue> dataList = this.systemConfigService.GetSystemConfigValueByType(configTypeCode);

            var query =
                from data in dataList
                select new
                {
                    Code = data.ConfigCode,
                    Name = data.ConfigName,
                    Config = data.ConfigValueObject
                };

            var result = query.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 测试获取某个具体的配置.
        /// </summary>
        /// <param name="configTypeCode"></param>
        /// <param name="configCode"></param>
        /// <returns></returns>
        public JsonResult GetConfig(string configTypeCode, string configCode)
        {
            SystemConfigValue data = this.systemConfigService.GetSystemConfigValue(configTypeCode, configCode);

            if (data == null)
            {
                var errResult =
                    new
                    {
                        Code = data.ConfigCode,
                        Name = "DATA NOT FOUND!"                    
                    };

                return Json(errResult, JsonRequestBehavior.AllowGet);
            }

            var result =
                new
                {
                    Code = data.ConfigCode,
                    Name = data.ConfigName,
                    Config = data.ConfigValueObject
                };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
