using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyFramework.Model
{

    /// <summary>
    /// 选择对话框的查询结果.
    /// </summary>
    [Serializable]
    public class SelectDialogQueryResult
    {

        /// <summary>
        /// 页索引.
        /// </summary>
        public int PageIndex { set; get; }

        /// <summary>
        /// 页数.
        /// </summary>
        public int PageCount { set; get; }


        /// <summary>
        /// 具体查询数据.
        /// </summary>
        public Object ResultList { set; get; }


    }


}
