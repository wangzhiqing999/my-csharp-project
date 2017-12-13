using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using MyFramework.Util;

using MyArticle.Model;
using MyArticle.DataAccess;

using MyArticle.Service;



namespace MyArticle.ServiceImpl
{


    /// <summary>
    /// 文章管理服务.
    /// </summary>
    public class DefaultArticleService : IArticleService
    {

        /// <summary>
        /// 查询 有效的 分类列表.
        /// </summary>
        /// <returns></returns>
        public List<ArticleCategory> GetActiveArticleCategoryList()
        {
            using (MyArticleContext context = new MyArticleContext())
            {
                var query =
                    from data in context.ArticleCategorys
                    where
                        // 数据有效.
                        data.Status == ArticleCategory.STATUS_IS_ACTIVE
                    select data;

                return query.ToList();
            }
        }



        /// <summary>
        /// 取得分类信息.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public ArticleCategory GetActiveArticleCategory(string code)
        {
            using (MyArticleContext context = new MyArticleContext())
            {
                var query =
                    from data in context.ArticleCategorys
                    where
                        // 指定分类.
                        data.ArticleCategoryCode == code
                        // 数据有效.
                        && data.Status == ArticleCategory.STATUS_IS_ACTIVE
                    select data;

                return query.FirstOrDefault();
            }
        }




        /// <summary>
        /// 查询文章.
        /// </summary>
        /// <param name="categoryCode"></param>
        /// <param name="pageNo"></param>
        /// <param name="pageSize"></param>
        /// <param name="pgInfo"></param>
        /// <returns></returns>
        public List<Article> GetArticleList(
            string categoryCode, string subTitle, ref PageInfo pgInfo, int pageNo = 1, int pageSize = 30)
        {
            // 预期结果.
            List<Article> resultList = new List<Article>();


            using (MyArticleContext context = new MyArticleContext())
            {
                var query =
                    from data in context.Articles.Include("ArticleCategory")
                    where
                        // 指定分类.
                        data.ArticleCategoryCode == categoryCode
                        // 数据有效.
                        && data.Status == Article.STATUS_IS_ACTIVE
                        // 今天不应显示  文章日期是明天或者更后的文章.
                        && data.ArticleDate <= DateTime.Now
                    select data;

                // 初始化翻页.
                pgInfo = new PageInfo(
                    pageSize: pageSize,
                    pageNo: pageNo,
                    rowCount: query.Count());

                query = query.OrderByDescending(p => p.ArticleDate)
                    .Skip(pgInfo.SkipValue)
                    .Take(pgInfo.PageSize);


                resultList = query.ToList();
            }


            return resultList;
        }




        /// <summary>
        /// 查询文章.
        /// </summary>
        /// <param name="articleID"></param>
        /// <returns></returns>
        public Article GetArticleByID(long articleID)
        {
            using (MyArticleContext context = new MyArticleContext())
            {
                Article result = context.Articles.Include("ArticleCategory").FirstOrDefault(p => p.ArticleID == articleID);
                return result;
            }
        }





    }


}
