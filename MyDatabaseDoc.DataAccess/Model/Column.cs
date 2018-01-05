using System.ComponentModel.DataAnnotations;


namespace MyDatabaseDoc.Model
{

    /// <summary>
    /// 列
    /// </summary>
    public class Column
    {

        /// <summary>
        /// 列名.
        /// </summary>
        [Display(Name = "列名")]
        public string ColumnName { set; get; }


        /// <summary>
        /// 数据类型.
        /// </summary>
        [Display(Name = "数据类型")]
        public string DataType { set; get; }



        /// <summary>
        /// 允许为空.
        /// </summary>
        [Display(Name = "允许为空")]
        public string IsNullable { set; get; }






        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        public string ColumnComment { set; get; }


    }

}
