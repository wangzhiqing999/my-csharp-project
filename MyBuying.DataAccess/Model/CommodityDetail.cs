using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MyBuying.Model
{

    /// <summary>
    /// 商品明细
    /// </summary>
    [Serializable]
    [Table("my_commodity_detail")]
    public class CommodityDetail
    {

        /// <summary>
        /// 商品明细流水
        /// </summary>
        [Column("commodity_detail_id")]
        [Display(Name = "商品明细流水")]
        [Key]
        public long CommodityDetailID { set; get; }




        #region 一对多.

        /// <summary>
        /// 商品主表代码
        /// </summary>
        [Column("commodity_master_code")]
        [Display(Name = "商品主表代码")]
        [StringLength(16)]
        public string CommodityMasterCode { set; get; }



        /// <summary>
        /// 商品主表数据.
        /// </summary>
        public CommodityMaster CommodityMasterData { set; get; }


        #endregion 一对多.



        /// <summary>
        /// 批次代码
        /// </summary>
        [Column("commodity_batch_code")]
        [Display(Name = "商品批次代码")]
        [StringLength(8)]
        public string BatchCode { set; get; }




        /// <summary>
        /// 商品明细代码
        /// (同一个商品主表代码 + 批次代码下， 该代码唯一)
        /// </summary>
        [Column("commodity_detail_code")]
        [Display(Name = "商品明细代码")]
        [StringLength(16)]
        public string CommodityDetailCode { set; get; }





        /// <summary>
        /// 商品状态
        /// </summary>
        [Column("commodity_status")]
        [Display(Name = "商品状态")]
        [StringLength(16)]
        public string CommodityStatus { set; get; }



        #region 内建的商品状态.


        /// <summary>
        /// 商品明细刚创建，处于“可用”状态.
        /// </summary>
        public const string COMMODITY_STATUS_IS_CREATED = "CREATED";


        /// <summary>
        /// 商品明细被特定客户 “抢购” 放入购物车， 等待创建订单，处于“锁定”状态.
        /// 此状态下， 超时未创建订单的，将回到 “可用”状态.
        /// </summary>
        public const string COMMODITY_STATUS_IS_LOCKED = "LOCKED";


        /// <summary>
        /// 商品明细被创建订单，等待付款， 处于“支付中”状态.
        /// 此状态下， 超时未付款的，将回到 “可用”状态.
        /// </summary>
        public const string COMMODITY_STATUS_IS_PAYING = "PAYING";


        /// <summary>
        /// 该商品明细，已经完成付款，处理“已支付”状态
        /// </summary>
        public const string COMMODITY_STATUS_IS_PAYED = "PAYED";


        /// <summary>
        /// 该商品明细，已经完成使用，处理“已使用”状态
        /// </summary>
        public const string COMMODITY_STATUS_IS_USED = "USED";



        #endregion





        /// <summary>
        /// 商品明细附加数据
        /// </summary>
        [Column("commodity_detail_exp_data")]
        [Display(Name = "商品明细附加数据")]
        public string CommodityDetailExpData { set; get; }







        // ------------------------------------
        // 上面的属性， 是本模块使用的属性.
        // ------------------------------------
        // 下面的属性， 是与其他模块相关联使用的属性.
        // ------------------------------------



        /// <summary>
        /// 购买者代码
        /// </summary>
        [Column("buyer_code")]
        [Display(Name = "购买者代码")]
        [StringLength(32)]
        public string BuyerCode { set; get; }




    }
}
