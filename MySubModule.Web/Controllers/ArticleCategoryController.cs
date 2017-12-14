using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MyArticle.Service;
using MyArticle.ServiceModel;

namespace MySubModule.Web.Controllers
{

    /// <summary>
    /// 文章分类.
    /// </summary>
    public class ArticleCategoryController : ApiController
    {

        /// <summary>
        /// 文章服务.
        /// </summary>
        private IArticleService articleService;


        /// <summary>
        /// 文章分类
        /// </summary>
        /// <param name="articleService"></param>
        public ArticleCategoryController(IArticleService articleService)
        {
            this.articleService = articleService;
        }



        /// <summary>
        /// 获取全部的文章分类.
        /// </summary>
        /// <returns></returns>
        public List<ArticleCategoryOutput> GetActiveArticleCategoryList()
        {
            return this.articleService.GetActiveArticleCategoryList();
        }



        /// <summary>
        /// 获取指定的文章分类.
        /// </summary>
        /// <param name="id">分类代码</param>
        /// <returns></returns>
        public IHttpActionResult  GetActiveArticleCategory(string id)
        {
            var data = this.articleService.GetActiveArticleCategory(id);

            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
 
        }

    }
}
