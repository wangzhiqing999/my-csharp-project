using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyChatRoom.Mvc.Common
{
    public class IpGetter
    {



        // X-Real-IP=211.138.243.111;
        // X-Forwarded-For=10.110.84.70, 211.138.243.111;


        /// <summary>
        /// 取得 ip 地址.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string GetIpAddress(HttpRequest request)
        {
            if (request.Headers.AllKeys.Contains("X-Real-IP"))
            {
                return request.Headers.Get("X-Real-IP");
            }

            // CDN设置了X-Forwarded-For，我们这里又设置了一次，且值为$proxy_add_x_forwarded_for的话，那么X-Forwarded-For的内容变成 ”客户端IP,Nginx负载均衡服务器IP“如果是这种情况的话，那后端的程序通过X-Forwarded-For获得客户端IP，则取逗号分隔的第一项即可。
            if (request.Headers.AllKeys.Contains("X-Forwarded-For"))
            {
                string forwarded = request.Headers.Get("X-Forwarded-For");
                string[] addrs = forwarded.Split(',');
                if (addrs != null && addrs.Length > 0)
                {
                    return addrs[addrs.Length - 1];
                }
            }
            return request.UserHostAddress;
        }



        /// <summary>
        /// 取得 ip 地址.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string GetIpAddress(HttpRequestBase request)
        {
            if (request.Headers.AllKeys.Contains("X-Real-IP"))
            {
                return request.Headers.Get("X-Real-IP");
            }

            // CDN设置了X-Forwarded-For，我们这里又设置了一次，且值为$proxy_add_x_forwarded_for的话，那么X-Forwarded-For的内容变成 ”客户端IP,Nginx负载均衡服务器IP“如果是这种情况的话，那后端的程序通过X-Forwarded-For获得客户端IP，则取逗号分隔的第一项即可。
            if (request.Headers.AllKeys.Contains("X-Forwarded-For"))
            {
                string forwarded = request.Headers.Get("X-Forwarded-For");
                string[] addrs = forwarded.Split(',');
                if (addrs != null && addrs.Length > 0)
                {
                    return addrs[addrs.Length - 1];
                }
            }
            return request.UserHostAddress;
        }





    }
}