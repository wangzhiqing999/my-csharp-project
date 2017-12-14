using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyFramework.ServiceModel;

namespace MyArticle.ServiceModel
{

    /// <summary>
    /// 文章列表输出.
    /// </summary>
    public class ArticleListOutput : PageAbleOutput
    {

        /// <summary>
        /// 文章列表.
        /// </summary>
        public List<ArticleOutput> ArticleList { set; get; }

    }
}
