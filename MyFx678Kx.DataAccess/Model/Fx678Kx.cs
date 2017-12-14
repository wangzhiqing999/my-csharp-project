using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Runtime.Serialization;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using MyFramework.Model;



namespace MyFx678Kx.Model
{

    /// <summary>
    /// 快讯.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Table("my_fx678_kx")]
    public class Fx678Kx : AbstractCommonData
    {

        /// <summary>
        /// 新闻ID.
        /// </summary>
        [DataMember]
        [Column("news_id")]
        [Display(Name = "新闻ID.")]
        [StringLength(32)]
        [Key]
        public string NewsId { set; get; }




        /// <summary>
        /// 新闻标题.
        /// </summary>
        [DataMember]
        [Column("news_title")]
        [Display(Name = "新闻标题")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Html)]
        [Required]
        public string Title { set; get; }




        [Display(Name = "显示的新闻标题")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Html)]
        [NotMapped]
        public string DisplayTitle
        {
            get
            {
                if (String.IsNullOrEmpty(Title))
                {
                    return Title;
                }


                if (this.Title.Contains("src=\"images/star"))
                {
                    return Title.Replace("src=\"images/star", "src=\"/images/star");
                }


                return Title;
            }
        }





        /// <summary>
        /// 重要程度
        /// </summary>
        [DataMember]
        [Column("news_level")]
        [Display(Name = "重要程度")]
        public int Level { set; get; }



        /// <summary>
        /// 快讯是否有明细
        /// </summary>
        [DataMember]
        [Column("news_has_more")]
        [Display(Name = "快讯是否有明细")]
        public bool HasMore { set; get; }



        /// <summary>
        /// 快讯的明细地址.
        /// </summary>
        [DataMember]
        [Column("news_more_url")]
        [Display(Name = "快讯的明细地址")]
        [StringLength(128)]
        public string MoreUrl { set; get; }



        /// <summary>
        /// 新闻内容.
        /// </summary>
        [DataMember]
        [Column("news_content")]
        [Display(Name = "新闻内容")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Html)]
        public string Content { set; get; }







        /// <summary>
        /// 新闻发布日期.
        /// </summary>
        [DataMember]
        [Column("pub_date")]
        [Display(Name = "新闻发布日期")]
        public DateTime PubDate { set; get; }







        public override string ToString()
        {
            StringBuilder buff = new StringBuilder();

            buff.AppendFormat("NewsId = {0};", this.NewsId);
            buff.AppendFormat("Level = {0};", this.Level);
            buff.AppendFormat("PubDate = {0};", this.PubDate);
            buff.AppendFormat("HasMore = {0};", this.HasMore);
            buff.AppendFormat("MoreUrl = {0};", this.MoreUrl);
            buff.AppendLine();

            buff.AppendFormat("Title = {0}", this.Title);
            buff.AppendLine();

            buff.AppendFormat("Content = {0}", this.Content);
            buff.AppendLine();


            return buff.ToString();
        }


    }
}
