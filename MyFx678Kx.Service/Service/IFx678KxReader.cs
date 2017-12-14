using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyFx678Kx.Model;

namespace MyFx678Kx.Service
{


    /// <summary>
    /// 快讯 读取接口.
    /// </summary>
    public interface IFx678KxReader
    {


        /// <summary>
        /// 读取快讯数据列表.
        /// </summary>
        /// <returns></returns>
        List<Fx678Kx> ReadFx678KxList();




        /// <summary>
        /// 读取页面明细信息.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        string ReadMore(string url);


    }



}
