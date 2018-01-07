using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyDatabaseDoc.Model
{

    /// <summary>
    /// 表
    /// </summary>
    [Table("db_doc_table")]
    public class Table
    {

        /// <summary>
        /// 表名.
        /// </summary>
        [Display(Name = "表名")]
        [Column("table_name")]
        [StringLength(32)]
        [Key]
        public string TableName { set; get; }



        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        [Column("table_comment")]
        public string TableComment { set; get; }



        /// <summary>
        /// 列.
        /// </summary>
        public List<Column> ColumnList { set; get; }

    }
}
