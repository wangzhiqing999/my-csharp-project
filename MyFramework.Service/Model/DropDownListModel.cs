using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyFramework.Model
{

    /// <summary>
    /// 下拉列表控件的 Model
    /// </summary>
    [Serializable]
    public class DropDownListModel
    {

        /// <summary>
        /// 控件名称.
        /// </summary>
        public string DropDownListName { set; get; }


        /// <summary>
        /// 默认值.
        /// </summary>
        public string DefaultValue { set; get; }

    }


}
