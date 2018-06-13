using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


using Newtonsoft.Json;


namespace MyExamination.Model
{

    /// <summary>
    /// 问题选项.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Table("me_question_option")]
    public class MeQuestionOption 
    {


        /// <summary>
        /// 问题选项流水号.
        /// </summary>
        [DataMember]
        [Column("question_option_id")]
        [Display(Name = "问题选项流水号")]
        [Key]
        public long QuestionOptionID { set; get; }





        /// <summary>
        /// 问题流水号.
        /// </summary>
        [DataMember]
        [Column("question_id")]
        [Display(Name = "问题流水号")]
        [JsonIgnore]
        public long QuestionID { set; get; }


        /// <summary>
        /// 问题.
        /// </summary>
        [JsonIgnore]
        public MeQuestion Question { set; get; }




        
        /// <summary>
        /// 问题选项描述
        /// </summary>
        [DataMember]
        [Column("question_option_text")]
        [Display(Name = "问题选项描述")]
        [StringLength(1024)]
        public string QuestionOptionText { set; get; }




        /// <summary>
        /// 是否是正确的选项.
        /// </summary>
        [DataMember]
        [Column("is_right_option")]
        [Display(Name = "问题选项描述")]
        [JsonIgnore]
        public bool IsRightOption { set; get; }


        /// <summary>
        /// 选项的分值.
        /// </summary>
        [DataMember]
        [Column("option_point")]
        [Display(Name = "选项的分值")]
        [JsonIgnore]
        public int OptionPoint { set; get; }



    }


}
