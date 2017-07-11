using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MyMoney.Model
{



    /// <summary>
    /// 账户.
    /// </summary>
    [Serializable]
    [Table("mm_account")]
    public class Account
    {

        /// <summary>
        /// 账户ID.
        /// </summary>
        [Column("account_id")]
        [Display(Name = "账户ID")]
        [Key]
        public long AccountID { set; get; }



        /// <summary>
        /// 用户名.
        /// </summary>
        [Column("user_name")]
        [Display(Name = "账户余额")]
        public string UserName { set; get; }




        /// <summary>
        /// 账户余额
        /// </summary>
        [Column("account_balance")]
        [Display(Name = "账户余额")]
        public decimal AccountBalance { set; get; }





        /// <summary>
        /// 时间戳.
        /// </summary>
        [Timestamp]
        [Column("row_version")]
        public byte[] RowVersion { get; set; }






        #region 一对多 (操作日志)


        /// <summary>
        /// 账户操作日志.
        /// </summary>
        public virtual List<AccountOperationLog> OperationLogList { set; get; }


        #endregion 一对多 (操作日志)






        #region 一对多 (日结报表)


        /// <summary>
        /// 账户操作日志.
        /// </summary>
        public virtual List<AccountDailyReport> DailyReportList { set; get; }


        #endregion 一对多 (日结报表)



    }


}
