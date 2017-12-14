using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArticle.ServiceModel
{

    /// <summary>
    /// 获取文章列表的输入条件.
    /// </summary>
    public class GetArticleListInput
    {
        
        /// <summary>
        /// 文章分类代码.
        /// </summary>
        public string CategoryCode {set;get;}


        /// <summary>
        /// 文章标题.
        /// </summary>
        public string Title{set;get;}
        

        /// <summary>
        /// 第几页.
        /// </summary>
        public int PageNo {set;get;}


        /// <summary>
        /// 页面大小.
        /// </summary>
        public int PageSize { set; get; }
    }
}
