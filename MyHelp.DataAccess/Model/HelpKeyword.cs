using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


using Newtonsoft.Json;

namespace MyHelp.Model
{

    /// <summary>
    /// 帮助关键字.
    /// </summary>
    [Serializable]
    [Table("my_help_keyword")]
    public class HelpKeyword
    {

        /// <summary>
        /// 关键字流水.
        /// </summary>
        [Column("keyword_id")]
        [Display(Name = "关键字流水")]
        [Key]
        public long KeywordID { set; get; }


        /// <summary>
        /// 关键字文本
        /// </summary>
        [Column("keyword_text")]
        [Display(Name = "关键字文本")]
        [StringLength(64)]
        [Required]
        public string KeywordText { set; get; }




        #region 多对多.


        /// <summary>
        /// 关键字对应的帮助文档.
        /// </summary>
        [JsonIgnore]
        public List<HelpDocument> HelpDocumentList { set; get; }

        #endregion


    }

}
