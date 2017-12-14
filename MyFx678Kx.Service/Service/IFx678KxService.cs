using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using MyFramework.Util;

using MyFx678Kx.Model;


namespace MyFx678Kx.Service
{



    /// <summary>
    /// 快讯 基本服务接口.
    /// </summary>
    public interface IFx678KxService
    {


        /// <summary>
        /// 获取快讯.
        /// </summary>
        /// <param name="pgInfo"></param>
        /// <param name="pageNo"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        List<Fx678Kx> GetFx678KxList(ref PageInfo pgInfo, int pageNo = 1, int pageSize = 30);

    }


}
