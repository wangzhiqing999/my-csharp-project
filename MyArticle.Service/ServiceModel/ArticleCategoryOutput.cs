using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArticle.ServiceModel
{


    /// <summary>
    /// 文章分类.
    /// </summary>
    public class ArticleCategoryOutput
    {

        /// <summary>
        /// 文章分类代码.
        /// </summary>
        public string ArticleCategoryCode { set; get; }


        /// <summary>
        /// 文章分类名称.
        /// </summary>
        public string ArticleCategoryName { set; get; }

    }

}
