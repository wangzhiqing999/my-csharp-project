using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



using MyFramework.Model;



namespace MyDocument.Model
{

    /// <summary>
    /// 文档.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Table("md_document")]
    public class Document : AbstractCommonData
    {


        /// <summary>
        /// 文档代码.
        /// </summary>
        [DataMember]
        [Column("document_id")]
        [Display(Name = "文档代码")]
        [Key]
        public long DocumentID { set; get; }



        #region 一对多.

        /// <summary>
        /// 文档类型代码.
        /// </summary>
        [DataMember]
        [Column("document_type_code")]
        [Display(Name = "文档类型代码")]
        [StringLength(32)]
        public string DocumentTypeCode { set; get; }


        /// <summary>
        /// 文档类型.
        /// </summary>
        public virtual DocumentType DocumentType { set; get; }


        #endregion 一对多.




        /// <summary>
        /// 文档标题.
        /// </summary>
        [DataMember]
        [Column("document_title")]
        [Display(Name = "文档标题")]
        [StringLength(64)]
        [Required]
        public string DocumentTitle { set; get; }



        /// <summary>
        /// 文档关键字.
        /// </summary>
        [DataMember]
        [Column("document_keywords")]
        [Display(Name = "文档关键字")]
        [StringLength(128)]
        public string DocumentKeywords { set; get; }



        /// <summary>
        /// 文档简要描述.
        /// </summary>
        [DataMember]
        [Column("document_description")]
        [Display(Name = "文档简要描述")]
        [StringLength(256)]
        public string DocumentDescription { set; get; }



        /// <summary>
        /// 文章内容.
        /// </summary>
        [DataMember]
        [Column("document_content")]
        [Display(Name = "文章内容")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Html)]
        public string DocumentContent { set; get; }





        /// <summary>
        /// 文档Logo图片.
        /// </summary>
        [DataMember]
        [Column("document_logo")]
        [Display(Name = "文档Logo图片")]
        [StringLength(64)]
        public string DocumentLogo { set; get; }



        /// <summary>
        /// 文档文件名.
        /// </summary>
        [DataMember]
        [Column("document_filename")]
        [Display(Name = "文档文件名")]
        [StringLength(64)]
        public string DocumentFileName { set; get; }




        /// <summary>
        /// 文档文件名.(swf)
        /// </summary>
        [DataMember]
        [Column("document_swf_filename")]
        [Display(Name = "文档文件名")]
        [StringLength(64)]
        public string DocumentSwfFileName { set; get; }

    }

}
