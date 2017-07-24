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
    /// 投票明细.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Table("ballot_detail")]
    public class BallotDetail
    {


        /// <summary>
        /// 投票明细ID
        /// </summary>
        [DataMember]
        [Column("ballot_detail_id")]
        [Display(Name = "投票明细 ID")]
        [Key]
        public long BallotDetailID { set; get; }





        #region  一对多.


        /// <summary>
        /// 投票主表ID
        /// </summary>
        [DataMember]
        [Column("ballot_master_id")]
        [Display(Name = "投票主表 ID")]
        public long BallotMasterID { set; get; }


        /// <summary>
        /// 投票主表数据.
        /// </summary>
        public virtual BallotMaster BallotMasterData { set; get; }


        #endregion



        #region 一对多.



        /// <summary>
        /// 投票类型明细代码
        /// </summary>
        [DataMember]
        [Column("ballot_type_detail_code")]
        [Display(Name = "投票类型明细代码")]
        [StringLength(32)]
        public string BallotTypeDetailCode { set; get; }



        /// <summary>
        /// 投票类型明细
        /// </summary>
        public virtual BallotTypeDetail BallotTypeDetailData { set; get; }



        #endregion





        /// <summary>
        /// 投票数.
        /// </summary>
        [DataMember]
        [Column("ballot_count")]
        [Display(Name = "投票数")]
        public int BallotCount { set; get; }




        /// <summary>
        /// 投票百分比.
        /// 查询后，动态计算，不存储在表里面。
        /// </summary>
        [DataMember]
        [Display(Name = "投票百分比")]
        [NotMapped]
        public decimal BallotPercent { set; get; }





        #region  一对多.

        /// <summary>
        /// 用户投票.
        /// </summary>
        public virtual List<UserBallot> UserBallotList { set; get; }



        #endregion



    }


}
