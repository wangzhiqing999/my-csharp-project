using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyDatabaseDoc.Model
{

    /// <summary>
    /// 列
    /// </summary>
    [Table("db_doc_column")]
    public class Column
    {


        #region 一对多.

        /// <summary>
        /// 表名
        /// </summary>
        [Display(Name = "表名")]
        [Column("table_name")]
        [StringLength(64)]
        public string TableName { set; get; }


        /// <summary>
        /// 表.
        /// </summary>
        public Table TableData { set; get; }


        #endregion 一对多.





        /// <summary>
        /// 列名.
        /// </summary>
        [Display(Name = "列名")]
        [Column("column_name")]
        [StringLength(64)]
        public string ColumnName { set; get; }


        /// <summary>
        /// 列顺序
        /// </summary>
        [Display(Name = "列顺序")]
        [Column("column_index")]
        public int ColumnIndex { set; get; }



        /// <summary>
        /// 数据类型.
        /// </summary>
        [Display(Name = "数据类型")]
        [Column("data_type")]
        [StringLength(32)]
        public string DataType { set; get; }



        /// <summary>
        /// 字符串长度
        /// </summary>
        [Display(Name = "字符串长度")]
        [Column("character_maximum_length")]
        public long? CharacterMaximumLength { set; get; }


        
        /// <summary>
        /// 数字长度
        /// </summary>
        [Display(Name = "数字长度")]
        [Column("numeric_precision")]
        public long? NumericPrecision { set; get; }


        /// <summary>
        /// 小数位数
        /// </summary>
        [Display(Name = "小数位数")]
        [Column("numeric_scale")]
        public long? NumericScale { set; get; }




        /// <summary>
        /// 允许为空.
        /// </summary>
        [Display(Name = "允许为空")]
        [Column("is_nullable")]
        [StringLength(8)]
        public string IsNullable { set; get; }



        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        [Column("column_comment")]
        public string ColumnComment { set; get; }


    }

}
