using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyDatabaseDoc.Model
{

    /// <summary>
    /// 表
    /// </summary>
    public class Table
    {

        /// <summary>
        /// 表名.
        /// </summary>
        [Display(Name = "表名")]
        public string TableName { set; get; }



        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        public string TableComment { set; get; }



        /// <summary>
        /// 列.
        /// </summary>
        public List<Column> ColumnList { set; get; }

    }
}
