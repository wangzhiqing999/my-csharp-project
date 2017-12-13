using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using MyArticle.Model;
using MyArticle.Config;


namespace MyArticle.DataAccess
{
    public class MyArticleContext : DbContext
    {

        public MyArticleContext()
            : base("name=MyArticleContext")
        {
        }


        /// <summary>
        /// 文章分类.
        /// </summary>
        public DbSet<ArticleCategory> ArticleCategorys { get; set; }

        /// <summary>
        /// 文章.
        /// </summary>
        public DbSet<Article> Articles { get; set; }



        /// <summary>
        /// 指定如何创建 表的处理.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // 文章类型 配置信息.
            modelBuilder.Configurations.Add(new ArticleCategoryConfig());
        }

    }
}
