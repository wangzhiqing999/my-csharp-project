using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArticle.ServiceModel
{

    /// <summary>
    /// 文章简略信息 （用于文章列表中）
    /// </summary>
    public class ArticleOutput
    {

        /// <summary>
        /// 文章ID.
        /// </summary>
        public long ArticleID { set; get; }



        /// <summary>
        /// 文章标题.
        /// </summary>
        public string ArticleTitle { set; get; }



        /// <summary>
        /// 文章日期
        /// </summary>
        public DateTime ArticleDate { set; get; }



        /// <summary>
        /// 文章内容简介. 不超过512个中文字符
        /// </summary>
        public string ShortArticleContent { set; get; }


    }
}
