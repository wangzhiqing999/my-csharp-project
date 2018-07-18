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
    /// 商品明细模板.
    /// 创建商品明细时，如果每次创建的商品明细，都有着特定的附加数据，那么通过模板来创建，更为合适。
    /// 
    /// 例如：
    /// 一辆班车，20个座位，每次出行，生成商品明细时， 都会创建20行商品明细数据。
    /// 在不特别标注座位的情况下，简单创建 20 个明细既可。
    /// 
    /// 但是，如果每个商品明细上面，附加数据中，包含座位编号的情况下，使用模板来创建，就一次操作完毕。
    /// 而不是简单创建 20 个明细之后， 再逐行编辑每个明细的座位号码.
    /// </summary>
    [Serializable]
    [Table("my_commodity_detail_template")]
    public class CommodityDetailTemplate
    {


        /// <summary>
        /// 模板流水
        /// </summary>
        [Column("template_id")]
        [Display(Name = "模板流水")]
        [Key]
        public long TemplateID { set; get; }





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
        /// 商品明细附加数据
        /// </summary>
        [Column("commodity_detail_exp_data")]
        [Display(Name = "商品明细附加数据")]
        public string CommodityDetailExpData { set; get; }



    }
}
