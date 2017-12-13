using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


using System.Runtime.Serialization;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



using MyFramework.Model;




namespace MyBanner.Model
{

    /// <summary>
    /// 网站横幅.
    /// </summary>
    [Serializable]
    [Table("my_banner")]
    public class Banner : AbstractCommonData
    {
        /// <summary>
        /// 网站横幅代码.
        /// </summary>
        [Column("banner_id")]
        [Display(Name = "网站横幅代码")]
        [Key]
        public long BannerID { set; get; }





        #region 一对多.

        /// <summary>
        /// 网站横幅类型代码.
        /// </summary>
        [Column("banner_type_code")]
        [Display(Name = "网站横幅类型代码")]
        [StringLength(32)]
        [Required]
        public string BannerTypeCode { set; get; }


        /// <summary>
        /// 网站横幅类型.
        /// </summary>
        public virtual BannerType BannerTypeData { set; get; }


        #endregion 一对多.






        /// <summary>
        /// 显示顺序.
        /// </summary>
        [Column("display_order")]
        [Display(Name = "显示顺序")]
        public int DisplayOrder { set; get; }



        /// <summary>
        /// 网站横幅文本
        /// </summary>
        [Column("banner_text")]
        [Display(Name = "网站横幅文本")]
        [StringLength(64)]
        public string BannerText { set; get; }



        /// <summary>
        /// 网站横幅图片
        /// </summary>
        [Column("banner_image")]
        [Display(Name = "网站横幅图片")]
        [StringLength(64)]
        public string BannerImage { set; get; }





        /// <summary>
        /// 网站横幅 跳转地址
        /// </summary>
        [Column("banner_url")]
        [Display(Name = "网站横幅跳转地址")]
        [StringLength(128)]
        public string BannerUrl { set; get; }





        private static readonly string httpPortPat = @"[:][0-9]+/";


        [NotMapped]
        public string HttpsBannerUrl
        {
            get
            {

                if (String.IsNullOrEmpty(this.BannerUrl))
                {
                    // 为空， 简单返回.
                    return this.BannerUrl;
                }


                if (this.BannerUrl.StartsWith("http://", StringComparison.CurrentCultureIgnoreCase))
                {
                    string httpsUrl = this.BannerUrl.Replace("http://", "https://");

                    // 移除 端口号.
                    httpsUrl = Regex.Replace(httpsUrl, httpPortPat, "/", RegexOptions.IgnoreCase);

                    return httpsUrl;
                }
                return this.BannerUrl;
            }
        }




        /// <summary>
        /// 开始日期.
        /// </summary>
        [Column("start_date")]
        [Display(Name = "开始日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime StartDate { set; get; }



        /// <summary>
        /// 结束日期.
        /// </summary>
        [Column("finish_date")]
        [Display(Name = "结束日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime FinishDate { set; get; } 


    }


}
