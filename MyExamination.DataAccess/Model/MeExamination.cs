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
    /// 考试主表.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Table("me_examination")]
    public class MeExamination 
    {


        /// <summary>
        /// 考试代码.
        /// </summary>
        [DataMember]
        [Column("examination_id")]
        [Display(Name = "考试代码")]
        [Key]
        public long ExaminationID { set; get; }



        /// <summary>
        /// 考试名称
        /// </summary>
        [DataMember]
        [Column("examination_name")]
        [Display(Name = "考试名称")]
        [StringLength(64)]
        public string ExaminationName { set; get; }




        /// <summary>
        /// 考试描述
        /// </summary>
        [DataMember]
        [Column("examination_desc")]
        [Display(Name = "考试描述")]
        [StringLength(512)]
        public string ExaminationDesc { set; get; }





        /// <summary>
        /// 问题列表.
        /// </summary>
        [JsonIgnore]
        public virtual List<MeQuestion> QuestionList { set; get; }





        /// <summary>
        /// 用户考试项目.
        /// </summary>
        [JsonIgnore]
        public virtual List<MeUserExamination> UserExaminationList { set; get; }




    }

}
