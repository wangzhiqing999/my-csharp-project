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
    /// 用户.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Table("me_user")]
    public class MeUser 
    {

        /// <summary>
        /// 用户流水号.
        /// </summary>
        [DataMember]
        [Column("user_id")]
        [Display(Name = "用户流水号")]
        [Key]
        public long UserID { set; get; }



        /// <summary>
        /// 考试用户姓名
        /// </summary>
        [DataMember]
        [Column("user_name")]
        [Display(Name = "考试用户姓名")]
        public string UserName { set; get; }





        /// <summary>
        /// 用户考试项目.
        /// </summary>
        [JsonIgnore]
        public virtual List<MeUserExamination> UserExaminationList {set;get;}



        /// <summary>
        /// 用户回答.
        /// </summary>
        [JsonIgnore]
        public virtual List<MeUserAnswer> UserAnswerList { set; get; }


    }

}
