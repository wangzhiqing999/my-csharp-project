using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;

using MySystemConfig.Model;
using MySystemConfig.DataAccess;

using MySystemConfig.Service;




namespace MySystemConfig.ServiceImpl
{


    public class DefaultSystemConfigService : ISystemConfigService
    {


        /// <summary>
        /// 取得全部的 系统配置类型.
        /// </summary>
        /// <returns></returns>
        public List<SystemConfigType> GetAllSystemConfigType()
        {
            using (MySystemConfigContext context = new MySystemConfigContext())
            {
                var query =
                    from data in context.SystemConfigTypes
                    select
                        data;

                return query.ToList();
            }
        }



        /// <summary>
        /// 取得指定类型的 系统配置属性.
        /// </summary>
        /// <param name="configTypeCode"></param>
        /// <returns></returns>
        public List<SystemConfigProperty> GetSystemConfigPropertyByType(string configTypeCode)
        {
            using (MySystemConfigContext context = new MySystemConfigContext())
            {
                var query =
                    from data in context.SystemConfigPropertys
                    where
                        data.ConfigTypeCode == configTypeCode
                    select
                        data;

                return query.ToList();
            }
        }



        /// <summary>
        /// 取得指定类型的 系统配置数值.
        /// </summary>
        /// <param name="configTypeCode"></param>
        /// <returns></returns>
        public List<SystemConfigValue> GetSystemConfigValueByType(string configTypeCode)
        {
            using (MySystemConfigContext context = new MySystemConfigContext())
            {
                // 首先，取得类型.
                SystemConfigType systemConfigType = context.SystemConfigTypes.Find(configTypeCode);

                if (systemConfigType == null)
                {
                    // 类型为空， 返回空白列表.
                    return new List<SystemConfigValue>();
                }

                // 然后， 查询明细.
                var query =
                    from data in context.SystemConfigValues
                    where
                        data.ConfigTypeCode == configTypeCode
                    orderby
                        data.ConfigCode
                    select
                        data;

                // 取得结果.
                List<SystemConfigValue> resultList = query.ToList();


                // 配置的数据类型.
                Type configType = null;
                try
                {
                    configType = Type.GetType(systemConfigType.ConfigClassName);
                }
                catch (Exception)
                {
                    configType = null;
                }


                foreach (var item in resultList)
                {
                    // Json 反序列化.
                    if (configType != null)
                    {
                        // 指定了数据类型.
                        item.ConfigValueObject = JsonConvert.DeserializeObject(item.ConfigValue, configType);
                    }
                    else
                    {
                        // 未指定数据类型.
                        item.ConfigValueObject = JsonConvert.DeserializeObject(item.ConfigValue);
                    }
                }

                return resultList;
            }
        }





        /// <summary>
        /// 更新配置信息
        /// </summary>
        /// <param name="configValue"></param>
        /// <param name="resultMessage"></param>
        /// <returns></returns>
        public bool UpdateSystemConfigValue(SystemConfigValue configValue, ref string resultMessage)
        {
            using (MySystemConfigContext context = new MySystemConfigContext())
            {
                // 首先， 检查 ConfigTypeCode, ConfigCode 是否非空.
                if (String.IsNullOrEmpty(configValue.ConfigTypeCode))
                {
                    resultMessage = "配置类型代码不能为空.";
                    return false;
                }
                if (String.IsNullOrEmpty(configValue.ConfigCode))
                {
                    resultMessage = "配置代码不能为空.";
                    return false;
                }

                // 其次， 检查 ConfigTypeCode 是否存在.
                var configType = context.SystemConfigTypes.Find(configValue.ConfigTypeCode);
                if (configType == null)
                {
                    resultMessage = String.Format("配置类型代码 {0} 不存在.", configValue.ConfigTypeCode);
                    return false;
                }


                // 用户数据, 以Json格式存储.
                if (configValue.ConfigValueObject != null)
                {
                    configValue.ConfigValue = JsonConvert.SerializeObject(configValue.ConfigValueObject);
                }


                // 最后， 尝试查询数据， 判断是 插入， 还是更新.
                var dbConfigValue = context.SystemConfigValues.Find(configValue.ConfigTypeCode, configValue.ConfigCode);
                if (dbConfigValue == null)
                {
                    // 插入处理.
                    context.SystemConfigValues.Add(configValue);
                }
                else
                {
                    // 更新数据.
                    dbConfigValue.ConfigValue = configValue.ConfigValue;
                }
                context.SaveChanges();
                return true;
            }
        }



    }

}
