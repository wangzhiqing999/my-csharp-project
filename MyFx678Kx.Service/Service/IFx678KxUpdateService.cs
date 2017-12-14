using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyFx678Kx.Service
{

    /// <summary>
    /// 汇通快讯 更新接口.
    /// </summary>
    public interface IFx678KxUpdateService
    {

        string ResultMessage { set; get; }


        /// <summary>
        /// 更新快讯.
        /// </summary>
        /// <returns></returns>
        bool UpdateFx678Kx();

    }

}
