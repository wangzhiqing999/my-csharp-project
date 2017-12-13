using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using MyFramework.Model;


namespace MyArticle.Model
{

    /// <summary>
    /// 文章分类.
    /// </summary>
    [Serializable]
    [Table("my_article_category")]
    public class ArticleCategory : AbstractCommonData
    {

        /// <summary>
        /// 文章分类ID.
        /// </summary>
        [Column("article_category_code")]
        [Display(Name = "文章分类代码")]
        [StringLength(16)]
        [Key]
        public string ArticleCategoryCode { set; get; }



        /// <summary>
        /// 文章分类名称.
        /// </summary>
        [Column("article_category_name")]
        [Display(Name = "文章分类名称")]
        [Required]
        [StringLength(128)]
        public string ArticleCategoryName { set; get; }







        #region 一对多的部分.  (与文章)

        /// <summary>
        /// 文章 
        /// </summary>
        public virtual List<Article> Articles { set; get; }



        #endregion 一对多的部分.




    }

}
