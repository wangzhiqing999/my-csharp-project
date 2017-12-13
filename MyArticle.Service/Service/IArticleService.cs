using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyFramework.Util;

using MyArticle.Model;


namespace MyArticle.Service
{

    /// <summary>
    /// 文章接口.
    /// </summary>
    public interface IArticleService
    {

        /// <summary>
        /// 查询 有效的 分类列表.
        /// </summary>
        /// <returns></returns>
        List<ArticleCategory> GetActiveArticleCategoryList();




        /// <summary>
        /// 取得分类信息.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        ArticleCategory GetActiveArticleCategory(string code);




        /// <summary>
        /// 查询文章.
        /// </summary>
        /// <param name="categoryCode"></param>
        /// <param name="pageNo"></param>
        /// <param name="pageSize"></param>
        /// <param name="pgInfo"></param>
        /// <returns></returns>
        List<Article> GetArticleList(string categoryCode, string subTitle, ref PageInfo pgInfo, int pageNo = 1, int pageSize = 30);




        /// <summary>
        /// 查询文章.
        /// </summary>
        /// <param name="articleID"></param>
        /// <returns></returns>
        Article GetArticleByID(long articleID);
        

    }

}
