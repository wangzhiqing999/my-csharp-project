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
    /// 文章
    /// </summary>
    public class ArticleController : ApiController
    {

        /// <summary>
        /// 文章服务.
        /// </summary>
        private IArticleService articleService;


        /// <summary>
        /// 文章
        /// </summary>
        /// <param name="articleService"></param>
        public ArticleController(IArticleService articleService)
        {
            this.articleService = articleService;
        }



        /// <summary>
        /// 获取文章列表.
        /// </summary>
        /// <param name="categoryCode">分类代码</param>
        /// <param name="title">文章标题</param>
        /// <param name="pageNo">第几页（默认1）</param>
        /// <param name="pageSize">每页几行（默认20）</param>
        /// <returns></returns>
        public IHttpActionResult GetArticleList(string categoryCode, string title = null, int pageNo = 1, int pageSize = 20)
        {
            GetArticleListInput input = new GetArticleListInput()
            {
                CategoryCode = categoryCode,
                Title = title,
                PageNo = pageNo,
                PageSize = pageSize
            };

            var result = this.articleService.GetArticleList(input);
            return Ok(result);
        }



        /// <summary>
        /// 获取文章明细
        /// </summary>
        /// <param name="id">文章ID</param>
        /// <returns></returns>
        public IHttpActionResult GetArticle(long id)
        {
            var data = this.articleService.GetArticleByID(id);

            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }


    }
}
