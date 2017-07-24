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
    /// 投票类型.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Table("ballot_type")]
    public class BallotType
    {


        /// <summary>
        /// 投票类型代码
        /// </summary>
        [DataMember]
        [Column("ballot_type_code")]
        [Display(Name = "投票类型代码")]
        [StringLength(32)]
        [Key]
        public string BallotTypeCode { set; get; }



        /// <summary>
        /// 投票类型名称
        /// </summary>
        [DataMember]
        [Column("ballot_type_name")]
        [Display(Name = "投票类型名称")]
        [StringLength(64)]
        public string BallotTypeName { set; get; }





        #region  一对多.




        /// <summary>
        /// 投票类型明细.
        /// </summary>
        public virtual List<BallotTypeDetail> BallotTypeDetailList { set; get; }





        /// <summary>
        /// 投票主表.
        /// </summary>
        public virtual List<BallotMaster> BallotMasterList { set; get; }



        #endregion



    }


}
