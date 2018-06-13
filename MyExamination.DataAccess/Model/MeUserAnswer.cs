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
    /// 用户回答.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Table("me_user_answer")]
    public class MeUserAnswer 
    {

        /// <summary>
        /// 用户回答流水号.
        /// </summary>
        [DataMember]
        [Column("user_answer_id")]
        [Display(Name = "用户回答流水号")]
        [Key]
        public long UserAnswerID { set; get; }



        /// <summary>
        /// 用户考试流水号.
        /// </summary>
        [DataMember]
        [Column("user_examination_id")]
        [Display(Name = "用户考试流水号")]
        public long UserExaminationID { set; get; }


        /// <summary>
        /// 用户考试.
        /// </summary>
        [JsonIgnore]
        public MeUserExamination UserExamination { set; get; }







        /// <summary>
        /// 用户流水号.
        /// </summary>
        [DataMember]
        [Column("user_id")]
        [Display(Name = "用户流水号")]
        public long UserID { set; get; }


        /// <summary>
        /// 用户.
        /// </summary>
        public MeUser User { set; get; }




        /// <summary>
        /// 问题流水号.
        /// </summary>
        [DataMember]
        [Column("question_id")]
        [Display(Name = "问题流水号")]
        public long QuestionID { set; get; }


        /// <summary>
        /// 问题.
        /// </summary>
        [JsonIgnore]
        public MeQuestion Question { set; get; }






        /// <summary>
        /// 用户回答.
        /// </summary>
        [DataMember]
        [Column("user_answer")]
        [Display(Name = "用户回答")]
        [StringLength(128)]
        public string UserAnswer { set; get; }


    }

}
