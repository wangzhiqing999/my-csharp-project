using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Runtime.Serialization;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace MyWord.Model
{


    [Serializable]
    [DataContract(Namespace = "")]
    [Table("mw_word")]    
    public class Word
    {

        /// <summary>
        /// 词代码
        /// </summary>
        [DataMember]
        [Column("word_id")]
        [Display(Name = "词代码")]
        [Key]
        public int WordID { set; get; }


        /// <summary>
        /// 词数值
        /// </summary>
        [DataMember]
        [Column("word_value")]
        [Display(Name = "词数值")]
        [StringLength(32)]
        public string WordValue { set; get; }



    }

}
