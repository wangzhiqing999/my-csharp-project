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
    /// 文章.
    /// </summary>
    [Serializable]
    [Table("my_article")]
    public class Article : AbstractCommonData
    {

        /// <summary>
        /// 文章ID.
        /// </summary>
        [Column("article_id")]
        [Display(Name = "文章ID")]
        [Key]
        public long ArticleID { set; get; }




        #region 一对多的部分.  (与文章分类)


        /// <summary>
        /// 文章分类代码
        /// </summary>
        [Column("article_category_code")]
        [Display(Name = "文章分类代码")]
        [ForeignKey("ArticleCategory")]
        [StringLength(16)]
        [Required]
        public string ArticleCategoryCode { set; get; }



        /// <summary>
        /// 文章分类.
        /// </summary>
        public virtual ArticleCategory ArticleCategory { set; get; }



        [Display(Name = "文章分类名")]
        [NotMapped]
        public string DisplayArticleCategoryName
        {
            get
            {
                return ArticleCategory.ArticleCategoryName;
            }
        }



        #endregion 一对多的部分.




        /// <summary>
        /// 文章标题.
        /// </summary>
        [Column("article_title")]
        [Display(Name = "文章标题")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Html)]
        [Required]
        [StringLength(128)]
        public string ArticleTitle { set; get; }



        /// <summary>
        /// 文章子标题
        /// </summary>
        [Column("article_sub_title")]
        [Display(Name = "文章子标题")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Html)]
        [StringLength(32)]
        public string ArticleSubTitle { set; get; }


        /// <summary>
        /// 文章关键字.
        /// </summary>
        [Column("article_keyword")]
        [Display(Name = "文章关键字")]
        [StringLength(128)]
        public string ArticleKeyword { set; get; }



        



        /// <summary>
        /// 文章日期
        /// </summary>
        [Column("article_date")]
        [Display(Name = "文章日期")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ArticleDate { set; get; }



        /// <summary>
        /// 用于显示的文章日期.
        /// </summary>
        [NotMapped]
        public string DisplayArticleDate
        {
            get
            {
                return this.ArticleDate.ToString("yyyy年MM月dd日");
            }
        }






        /// <summary>
        /// 文章内容简介. 不超过512个中文字符
        /// </summary>
        [Column("article_content_short")]
        [Display(Name = "文章内容简介")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Html)]
        [StringLength(512)]
        public string ShortArticleContent { set; get; }


        /// <summary>
        /// 文章内容.
        /// </summary>
        [Column("article_content")]
        [Display(Name = "文章内容")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Html)]
        public string ArticleContent { set; get; }




        /// <summary>
        /// 文章标题图片.
        /// </summary>
        [Column("article_title_image")]
        [Display(Name = "文章标题图片")]
        [StringLength(128)]
        public string ArticleTitleImage { set; get; }



        /// <summary>
        /// 下载的文件.
        /// </summary>
        [Column("article_download_filename")]
        [Display(Name = "下载的文件名")]
        [StringLength(128)]
        public string ArticleDownloadFileName { set; get; }


    }
}
