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
    /// 商品主表.
    /// </summary>
    [Serializable]
    [Table("my_commodity_master")]
    public class CommodityMaster
    {
        
        /// <summary>
        /// 商品主表代码
        /// </summary>
        [Column("commodity_master_code")]
        [Display(Name = "商品主表代码")]
        [StringLength(16)]
        [Key]
        public string CommodityMasterCode { set; get; }



        /// <summary>
        /// 商品主表名称
        /// </summary>
        [Column("commodity_master_name")]
        [Display(Name = "商品主表名称")]
        [StringLength(64)]
        public string CommodityMasterName { set; get; }



        /// <summary>
        /// 商品主表描述
        /// </summary>
        [Column("commodity_master_desc")]
        [Display(Name = "商品主表描述")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Html)]
        public string CommodityMasterDesc { set; get; }








        #region 一对多.



        /// <summary>
        /// 商品明细模板列表.
        /// </summary>
        public List<CommodityDetailTemplate> CommodityDetailTemplateList { set; get; }



        /// <summary>
        /// 商品明细列表.
        /// </summary>
        public List<CommodityDetail> CommodityDetailList { set; get; }



        #endregion



    }

}
