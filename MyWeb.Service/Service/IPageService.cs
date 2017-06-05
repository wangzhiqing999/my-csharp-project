using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyWeb.Model;

namespace MyWeb.Service
{
    public interface IPageService
    {

        /// <summary>
        /// 取得子页面.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        List<Page> GetSubPageList(string code);

    }

}
