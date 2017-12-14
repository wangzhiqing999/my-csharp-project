using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArticle.ServiceModel
{

    /// <summary>
    /// 文章详细信息. （用于文章明细）
    /// </summary>
    public class ArticleDetailOutput
    {


        /// <summary>
        /// 文章ID.
        /// </summary>
        public long ArticleID { set; get; }



        /// <summary>
        /// 分类名称.
        /// </summary>
        public string DisplayArticleCategoryName { set; get; }



        /// <summary>
        /// 文章标题.
        /// </summary>
        public string ArticleTitle { set; get; }



        /// <summary>
        /// 文章子标题
        /// </summary>
        public string ArticleSubTitle { set; get; }



        /// <summary>
        /// 文章关键字.
        /// </summary>
        public string ArticleKeyword { set; get; }



        /// <summary>
        /// 文章日期
        /// </summary>
        public DateTime ArticleDate { set; get; }



        /// <summary>
        /// 文章内容简介. 不超过512个中文字符
        /// </summary>
        public string ShortArticleContent { set; get; }



        /// <summary>
        /// 文章内容.
        /// </summary>
        public string ArticleContent { set; get; }



        /// <summary>
        /// 文章标题图片.
        /// </summary>
        public string ArticleTitleImage { set; get; }



        /// <summary>
        /// 下载的文件.
        /// </summary>
        public string ArticleDownloadFileName { set; get; }


    }
}
