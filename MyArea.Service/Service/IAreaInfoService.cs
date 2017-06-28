using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyArea.Model;


namespace MyArea.Service
{


    /// <summary>
    /// 区域服务.
    /// </summary>
    public interface IAreaInfoService
    {


        /// <summary>
        /// 获取顶级区域列表.
        /// </summary>
        /// <returns></returns>
        List<AreaInfo> GetRootAreaInfoList();



        /// <summary>
        /// 获取子区域列表.
        /// </summary>
        /// <param name="areaCode"></param>
        /// <returns></returns>
        List<AreaInfo> GetSubAreaInfoList(string areaCode);

    }


}
