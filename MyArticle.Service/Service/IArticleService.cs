using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyFramework.Util;

using MyArticle.ServiceModel;


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
        List<ArticleCategoryOutput> GetActiveArticleCategoryList();




        /// <summary>
        /// 取得分类信息.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        ArticleCategoryOutput GetActiveArticleCategory(string code);




        /// <summary>
        /// 查询文章.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        ArticleListOutput GetArticleList(GetArticleListInput input);




        /// <summary>
        /// 查询文章.
        /// </summary>
        /// <param name="articleID"></param>
        /// <returns></returns>
        ArticleDetailOutput GetArticleByID(long articleID);
        

    }

}
