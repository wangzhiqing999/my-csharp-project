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
    /// 用户考试记录.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Table("me_user_examination")]
    public class MeUserExamination 
    {

        /// <summary>
        /// 用户考试流水号.
        /// </summary>
        [DataMember]
        [Column("user_examination_id")]
        [Display(Name = "用户考试流水号")]
        [Key]
        public long UserExaminationID { set; get; }





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
        [JsonIgnore]
        public MeUser User { set; get; }







        /// <summary>
        /// 考试代码.
        /// </summary>
        [DataMember]
        [Column("examination_id")]
        [Display(Name = "考试代码")]
        public long ExaminationID { set; get; }


        /// <summary>
        /// 考试
        /// </summary>
        [JsonIgnore]
        public MeExamination Examination { set; get; }





        /// <summary>
        /// 考试开始时间.
        /// </summary>
        [DataMember]
        [Column("examination_start_time")]
        [Display(Name = "考试开始时间")]
        public DateTime ExaminationStartTime
        {
            set;
            get;
        }

        /// <summary>
        /// 考试结束时间.
        /// </summary>
        [DataMember]
        [Column("examination_finish_time")]
        [Display(Name = "考试结束时间")]
        public DateTime? ExaminationFinishTime
        {
            set;
            get;
        }



        /// <summary>
        /// 用户回答.
        /// </summary>
        [JsonIgnore]
        public virtual List<MeUserAnswer> UserAnswerList { set; get; }




        /// <summary>
        /// 考试的分数.
        /// </summary>
        [DataMember]
        [Column("examination_point")]
        [Display(Name = "考试的分数")]
        public int ExaminationPoint { set; get; }

    }



}
