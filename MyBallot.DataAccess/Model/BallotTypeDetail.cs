using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Runtime.Serialization;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MyBallot.Model
{

    /// <summary>
    /// 投票类型明细.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Table("ballot_type_detail")]
    public class BallotTypeDetail
    {



        /// <summary>
        /// 投票类型明细代码
        /// </summary>
        [DataMember]
        [Column("ballot_type_detail_code")]
        [Display(Name = "投票类型明细代码")]
        [StringLength(32)]
        [Key]
        public string BallotTypeDetailCode { set; get; }





        #region 一对多.



        /// <summary>
        /// 投票类型代码
        /// </summary>
        [DataMember]
        [Column("ballot_type_code")]
        [Display(Name = "投票类型代码")]
        [StringLength(32)]
        [Required]
        public string BallotTypeCode { set; get; }




        /// <summary>
        /// 投票类型
        /// </summary>
        public virtual BallotType BallotTypeData { set; get; }



        #endregion 一对多.








        /// <summary>
        /// 投票类型明细标题
        /// </summary>
        [DataMember]
        [Column("ballot_type_detail_title")]
        [Display(Name = "投票类型明细标题")]
        [StringLength(64)]
        public string BallotTypeDetailTitle { set; get; }





        /// <summary>
        /// 默认投票值
        /// </summary>
        [DataMember]
        [Column("default_ballot_value")]
        [Display(Name = "投票类型明细代码")]
        public int DefaultBallotValue { set; get; }










        #region 一对多.



        /// <summary>
        /// 投票明细.
        /// </summary>
        public virtual List<BallotDetail> BallotDetailList { set; get; }


        #endregion 一对多.



    }

}
