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
    /// 文档类型.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Table("md_document_type")]
    public class DocumentType : AbstractCommonData
    {


        /// <summary>
        /// 文档类型代码.
        /// </summary>
        [DataMember]
        [Column("document_type_code")]
        [Display(Name = "文档类型代码")]
        [StringLength(32)]
        [Key]
        public string DocumentTypeCode { set; get; }



        /// <summary>
        /// 文档类型名称.
        /// </summary>
        [DataMember]
        [Column("document_type_name")]
        [Display(Name = "文档类型名称")]
        [StringLength(64)]
        public string DocumentTypeName { set; get; }





        /// <summary>
        /// 文档类型Logo图片.
        /// </summary>
        [DataMember]
        [Column("document_type_logo")]
        [Display(Name = "文档类型Logo图片")]
        [StringLength(64)]
        public string DocumentTypeLogo { set; get; }






        /// <summary>
        /// 文档类型描述
        /// </summary>
        [DataMember]
        [Column("document_type_desc")]
        [Display(Name = "文档类型描述")]
        [StringLength(2048)]
        public string DocumentTypeDesc { set; get; }




        /// <summary>
        /// 文档类型文本
        /// </summary>
        [DataMember]
        [Column("document_type_text")]
        [Display(Name = "文档类型文本")]
        public string DocumentTypeText { set; get; }




        /// <summary>
        /// 显示顺序.
        /// </summary>
        [DataMember]
        [Column("display_index")]
        [Display(Name = "显示顺序")]
        public int DisplayIndex { set; get; }






        /// <summary>
        /// 扩展数据.
        /// </summary>
        [DataMember]
        [Column("exp_value")]
        [Display(Name = "扩展数据")]
        public string ExpValue { set; get; }




        #region 一对多.


        /// <summary>
        /// 文档列表.
        /// </summary>
        public virtual List<Document> DocumentList { set; get; }


        #endregion


    }
}
