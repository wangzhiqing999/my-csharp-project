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
    /// 用户投票.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Table("user_ballot")]
    public class UserBallot
    {


        /// <summary>
        /// 用户投票ID
        /// </summary>
        [DataMember]
        [Column("user_ballot_id")]
        [Display(Name = "用户投票 ID")]
        [Key]
        public long UserBallotID { set; get; }





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




        /// <summary>
        /// 投票明细ID
        /// </summary>
        [DataMember]
        [Column("ballot_detail_id")]
        [Display(Name = "投票明细 ID")]
        public long BallotDetailID { set; get; }

        /// <summary>
        /// 投票明细数据.
        /// </summary>
        public virtual BallotDetail BallotDetailData { set; get; }


        #endregion  一对多.






        /// <summary>
        /// 投票时间.
        /// </summary>
        [DataMember]
        [Column("ballot_time")]
        [Display(Name = "投票时间")]
        public DateTime BallotTime { set; get; }




        /// <summary>
        /// 投票用户 ip 地址.
        /// </summary>
        [DataMember]
        [Column("ballot_user_ip")]
        [Display(Name = "投票用户 ip 地址")]
        [StringLength(64)]
        public string UserIp { set; get; }



        /// <summary>
        /// 投票用户 cookie.
        /// </summary>
        [DataMember]
        [Column("ballot_user_cookie")]
        [Display(Name = "投票用户 Cookie")]
        [StringLength(64)]
        public string UserCookie { set; get; }


        /// <summary>
        /// 投票用户代码
        /// </summary>
        [DataMember]
        [Column("ballot_user_code")]
        [Display(Name = "投票用户代码（如果有的话）")]
        [StringLength(64)]
        public string UserCode { set; get; }

    }


}
