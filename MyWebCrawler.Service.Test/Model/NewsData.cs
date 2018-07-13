using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebCrawler.Service.Test.Model
{
    class NewsData
    {

        /// <summary>
        /// 链接.
        /// </summary>
        public string Url { set; get; }


        /// <summary>
        /// 标题.
        /// </summary>
        public string Title { set; get; }


        /// <summary>
        /// 日期.
        /// </summary>
        public string Date { set; get; }


        /// <summary>
        /// 新闻内容.
        /// </summary>
        public string Html { set; get; }

    }
}
