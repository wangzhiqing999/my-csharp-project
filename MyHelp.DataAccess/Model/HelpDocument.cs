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
    /// 帮助文档.
    /// </summary>
    [Serializable]
    [Table("my_help_doc")]
    public class HelpDocument
    {

        /// <summary>
        /// 帮助文档流水.
        /// </summary>
        [Column("document_id")]
        [Display(Name = "帮助文档流水")]
        [Key]
        public long DocumentID { set; get; }




        #region 多对多.


        /// <summary>
        /// 本帮助文档，所涉及的关键字.
        /// </summary>
        [JsonIgnore]
        public List<HelpKeyword> HelpKeywordList { set; get; }


        #endregion





        /// <summary>
        /// 文档标题.
        /// </summary>
        [Column("document_title")]
        [Display(Name = "文档标题")]
        [StringLength(64)]
        [Required]
        public string DocumentTitle { set; get; }




        /// <summary>
        /// 文档内容.
        /// </summary>
        [Column("document_content")]
        [Display(Name = "文档内容")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Html)]
        public string DocumentContent { set; get; }



    }
}
