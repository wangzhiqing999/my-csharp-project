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
    /// 投票主表.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "")]
    [Table("ballot_master")]
    public class BallotMaster
    {

        /// <summary>
        /// 投票主表ID
        /// </summary>
        [DataMember]
        [Column("ballot_master_id")]
        [Display(Name = "投票主表 ID")]
        [Key]
        public long BallotMasterID { set; get; }




        #region  一对多.

        /// <summary>
        /// 投票类型代码
        /// </summary>
        [DataMember]
        [Column("ballot_type_code")]
        [Display(Name = "投票类型代码")]
        [StringLength(32)]
        public string BallotTypeCode { set; get; }


        /// <summary>
        /// 投票类型
        /// </summary>
        public virtual BallotType BallotTypeData { set; get; }


        #endregion  一对多.



        /// <summary>
        /// 投票日期.
        /// </summary>
        [DataMember]
        [Column("ballot_date")]
        [Display(Name = "投票日期")]        
        public DateTime BallotDate { set; get; }






        #region  一对多.


        /// <summary>
        /// 投票明细.
        /// </summary>
        public virtual List<BallotDetail> BallotDetailList { set; get; }




        /// <summary>
        /// 用户投票.
        /// </summary>
        public virtual List<UserBallot> UserBallotList { set; get; }



        #endregion





        #region 计算方法.


        /// <summary>
        /// 计算投票百分比.
        /// </summary>
        public void CalculateBallotPercent()
        {
            // 总计的投票数.
            int totlaCount = 0;

            // 计算投票总计.
            foreach (var detail in this.BallotDetailList)
            {
                totlaCount += detail.BallotCount;
            }

            if (totlaCount > 0)
            {

                // 累计的百分比.
                decimal totalBallotPercent = 0;

                // 仅仅当 至少存在有1个投票的时候， 才计算百分比. (否则会发生除零错误)
                // 填写投票百分比.
                for (int i = 0; i < this.BallotDetailList.Count -1; i ++)
                {
                    this.BallotDetailList[i].BallotPercent = Math.Round(100.0M * this.BallotDetailList[i].BallotCount / totlaCount, 2);

                    // 累计百分比.
                    totalBallotPercent += this.BallotDetailList[i].BallotPercent;
                }

                // 最后一个 = 100 - 累计.
                this.BallotDetailList[this.BallotDetailList.Count - 1].BallotPercent = 100M - totalBallotPercent;
            }
        }


        #endregion


    }

}
