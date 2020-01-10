using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebCrawler.Service.Test.Model
{
    public class RlData
    {

        /// <summary>
        /// 国家.
        /// </summary>
        public string Country { set; get; }


        /// <summary>
        /// 时间
        /// </summary>
        public string Time { set; get; }


        /// <summary>
        /// 重要度图片.
        /// </summary>
        public string StartImg { set; get; }



        /// <summary>
        /// 名称.
        /// </summary>
        public string Content { set; get; }



        /// <summary>
        /// 前值.
        /// </summary>
        public string Previous { set; get; }



        /// <summary>
        /// 预测值.
        /// </summary>
        public string Predict { set; get; }



        /// <summary>
        /// 公布值.
        /// </summary>
        public string CurrentValue { set; get; }



    }
}
