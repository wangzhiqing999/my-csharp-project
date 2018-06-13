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
    /// 问题类型.
    /// </summary>
    public enum MeQuestionType
    {
        /// <summary>
        /// 单选.
        /// </summary>
        OneOption = 1,

        /// <summary>
        /// 多选.
        /// </summary>
        MulOption = 2,


        /// <summary>
        /// 文本信息.
        /// </summary>
        Text = 4,

    }





    /// <summary>
    /// 问题主表.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Table("me_question")]
    [JsonObject(MemberSerialization.OptIn)]
    public class MeQuestion 
    {

        /// <summary>
        /// 问题流水号.
        /// </summary>
        [DataMember]
        [Column("question_id")]
        [Display(Name = "问题流水号")]
        [Key]
        [JsonProperty]
        public long QuestionID { set; get; }



        /// <summary>
        /// 考试代码.
        /// </summary>
        [DataMember]
        [Column("examination_id")]
        [Display(Name = "考试代码")]
        public long ExaminationID { set; get; }


        /// <summary>
        /// 问题所属的考试.
        /// </summary>
        [JsonIgnore]
        public MeExamination Examination { set; get; }




        /// <summary>
        /// 问题类型.
        /// </summary>
        [DataMember]
        [Column("question_type")]
        [Display(Name = "问题类型")]
        [Required]
        [JsonProperty]
        public MeQuestionType QuestionType { set; get; }

        

        /// <summary>
        /// 问题描述
        /// </summary>
        [DataMember]
        [Column("question_text")]
        [Display(Name = "问题描述")]
        [StringLength(1024)]
        [JsonProperty]
        public string QuestionText { set; get; }






        /// <summary>
        /// 问题的分值.
        /// </summary>
        [DataMember]
        [Column("question_point")]
        [Display(Name = "问题的分值")]
        public int QuestionPoint { set; get; }



        /// <summary>
        /// 题目的显示顺序（排序）
        /// </summary>
        [DataMember]
        [Column("display_order")]
        [Display(Name = "题目的显示顺序（排序）")]
        public int DisplayOrder { set; get; }






        /// <summary>
        /// 问题的选项.
        /// </summary>
        [JsonProperty]
        public List<MeQuestionOption> QuestionOptionList { set; get; }



        /// <summary>
        /// 用户的回答.
        /// </summary>
        [JsonIgnore]
        public List<MeUserAnswer> UserAnswerList { set; get; }







    }

}
