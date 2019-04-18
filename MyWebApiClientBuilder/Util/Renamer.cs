using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApiClientBuilder.Util
{
    public sealed class Renamer
    {


        /// <summary>
        /// 取得 js 的方法名.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string RenameJavaScriptFunctionName(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                // 为空的情况下，返回空白.
                return string.Empty;
            }

            return name.Substring(0, 1).ToLower() + name.Substring(1);
        }


    }
}
