using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data.Entity.ModelConfiguration;

using MyArticle.Model;




namespace MyArticle.Config
{


    /// <summary>
    /// 文章类型配置.
    /// </summary>
    public class ArticleCategoryConfig : EntityTypeConfiguration<ArticleCategory>
    {

        public ArticleCategoryConfig()
        {

            // 一个 文章类型  允许有多个 文章.
            this.HasMany(s => s.Articles)
                // 一个文章必须要有一个文章类型.
                .WithRequired(m => m.ArticleCategory)
                // 外键的列是  ArticleCategoryCode
                .HasForeignKey(m => m.ArticleCategoryCode)
                // 取消 外键的 ON DELETE CASCADE 
                // (因为删除 文章类型 的操作极少. 需要避免误操作)
                .WillCascadeOnDelete(false);

        }
    }



}
