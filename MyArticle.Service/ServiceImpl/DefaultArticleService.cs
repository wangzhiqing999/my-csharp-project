using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using MyFramework.Util;

using MyArticle.Model;
using MyArticle.DataAccess;

using MyArticle.Service;
using MyArticle.ServiceModel;


namespace MyArticle.ServiceImpl
{


    /// <summary>
    /// 文章管理服务.
    /// </summary>
    public class DefaultArticleService : IArticleService
    {


        static DefaultArticleService()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Article, ArticleDetailOutput>();
            });
        }



        /// <summary>
        /// 查询 有效的 分类列表.
        /// </summary>
        /// <returns></returns>
        public List<ArticleCategoryOutput> GetActiveArticleCategoryList()
        {
            using (MyArticleContext context = new MyArticleContext())
            {
                var query =
                    from data in context.ArticleCategorys
                    where
                        // 数据有效.
                        data.Status == ArticleCategory.STATUS_IS_ACTIVE
                    select new ArticleCategoryOutput() {
                        ArticleCategoryCode = data.ArticleCategoryCode,
                        ArticleCategoryName = data.ArticleCategoryName
                    };

                List<ArticleCategoryOutput> resultList = query.ToList();
                return resultList;
            }
        }



        /// <summary>
        /// 取得分类信息.
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public ArticleCategoryOutput GetActiveArticleCategory(string code)
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
                    select new ArticleCategoryOutput()
                    {
                        ArticleCategoryCode = data.ArticleCategoryCode,
                        ArticleCategoryName = data.ArticleCategoryName
                    };

                return query.FirstOrDefault();
            }
        }




        /// <summary>
        /// 查询文章.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public ArticleListOutput GetArticleList(GetArticleListInput input)
        {
            using (MyArticleContext context = new MyArticleContext())
            {
                var query =
                    from data in context.Articles.Include("ArticleCategory")
                    where
                        // 指定分类.
                        data.ArticleCategoryCode == input.CategoryCode
                        // 数据有效.
                        && data.Status == Article.STATUS_IS_ACTIVE
                        // 今天不应显示  文章日期是明天或者更后的文章.
                        && data.ArticleDate <= DateTime.Now
                    select new ArticleOutput()
                    {
                        ArticleID = data.ArticleID,
                        ArticleTitle = data.ArticleTitle,
                        ArticleDate = data.ArticleDate,
                        ShortArticleContent = data.ShortArticleContent
                    };

                if (!String.IsNullOrEmpty(input.Title))
                {
                    // 指定了标题.
                    query = query.Where(p => p.ArticleTitle.Contains(input.Title));
                }

                // 初始化翻页.
                PageInfo pgInfo = new PageInfo(
                    pageSize: input.PageSize,
                    pageNo: input.PageNo,
                    rowCount: query.Count());

                query = query.OrderByDescending(p => p.ArticleDate)
                    .Skip(pgInfo.SkipValue)
                    .Take(pgInfo.PageSize);


                ArticleListOutput result = new ArticleListOutput()
                {
                    PageIndex = pgInfo.PageIndex,
                    PageSize = pgInfo.PageSize,
                    RowCount = pgInfo.RowCount,
                    ArticleList = query.ToList()
                };

                return result;
            }            
        }




        /// <summary>
        /// 查询文章.
        /// </summary>
        /// <param name="articleID"></param>
        /// <returns></returns>
        public ArticleDetailOutput GetArticleByID(long articleID)
        {
            using (MyArticleContext context = new MyArticleContext())
            {
                Article data = context.Articles.Include("ArticleCategory").FirstOrDefault(p => p.ArticleID == articleID);
                if (data == null)
                {
                    return null;
                }

                ArticleDetailOutput result = Mapper.Map<Article, ArticleDetailOutput>(source: data);
                return result;
            }
        }





    }


}
