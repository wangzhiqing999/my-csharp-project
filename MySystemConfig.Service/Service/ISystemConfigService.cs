using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MySystemConfig.Model;


namespace MySystemConfig.Service
{

    /// <summary>
    /// 系统配置服务.
    /// </summary>
    public interface ISystemConfigService
    {

        /// <summary>
        /// 取得全部的 系统配置类型.
        /// </summary>
        /// <returns></returns>
        List<SystemConfigType> GetAllSystemConfigType();

        /// <summary>
        /// 取得指定类型的 系统配置属性.
        /// </summary>
        /// <param name="configTypeCode"></param>
        /// <returns></returns>
        List<SystemConfigProperty> GetSystemConfigPropertyByType(string configTypeCode);

        /// <summary>
        /// 取得指定类型的 系统配置数值.
        /// </summary>
        /// <param name="configTypeCode"></param>
        /// <returns></returns>
        List<SystemConfigValue> GetSystemConfigValueByType(string configTypeCode);




        /// <summary>
        /// 更新配置信息
        /// </summary>
        /// <param name="configValue"></param>
        /// <param name="resultMessage"></param>
        /// <returns></returns>
        bool UpdateSystemConfigValue(SystemConfigValue configValue, ref string resultMessage);

    }


}
