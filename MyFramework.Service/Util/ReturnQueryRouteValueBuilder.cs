using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web.Routing;


namespace MyFramework.Util
{
    public class ReturnQueryRouteValueBuilder
    {


        /// <summary>
        /// 根据 QueryString ，  获取画面返回时的  RouteValueDictionary
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        public static RouteValueDictionary GetReturnQueryRouteValue(string queryString)
        {

            RouteValueDictionary result = new RouteValueDictionary();

            if (!String.IsNullOrEmpty(queryString))
            {
                string[] keyvalueArray = queryString.Split('&');

                foreach (string keyvalString in keyvalueArray)
                {
                    string[] keyval = keyvalString.Split('=');
                    if (keyval.Length == 2)
                    {
                        result[keyval[0]] = FormatUnicodeString(keyval[1]);
                    }
                }
            }

            return result;
        }






        /// <summary>
        /// 将  %uXXXX  这样的unicode字符， 转换为 正常的字符串
        /// </summary>
        /// <param name="unicodeString"></param>
        /// <returns></returns>
        private static string FormatUnicodeString(string unicodeString)
        {

            if (String.IsNullOrEmpty(unicodeString))
            {
                return unicodeString;
            }

            if (unicodeString.IndexOf("%u") < 0)
            {
                return FormatOthetString(unicodeString);
            }


            StringBuilder result = new StringBuilder();

            string[] arr = unicodeString.Split(new string[] { "%u" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in arr)
            {
                if (s.Length < 4)
                {                    
                    result.Append(FormatOthetString(s));
                }
                else 
                {
                    // 单个汉字.
                    result.Append((char)Convert.ToInt32(s.Substring(0, 4), 16) + FormatOthetString(s.Substring(4)));
                }

            }

            return result.ToString();
        }




        private static string FormatOthetString(string otherString)
        {
            if (String.IsNullOrEmpty(otherString))
            {
                return otherString;
            }

            if (otherString.IndexOf("%") < 0)
            {
                return otherString.Replace('+', ' ');
            }

            StringBuilder result = new StringBuilder();

            // 存在有 %2b 这种短数据.
            string[] arr2 = otherString.Split('%');
            foreach (string s2 in arr2)
            {
                if (s2.Length < 2)
                {
                    if (s2 == "+")
                    {
                        // 空格会变 +
                        result.Append(" ");
                    }
                    else
                    {
                        result.Append(s2);
                    }
                }
                else
                {
                    result.Append((char)Convert.ToInt32(s2.Substring(0, 2), 16) + FormatOthetString(s2.Substring(2)));
                }
            }


            return result.ToString();
        }





    }
}
