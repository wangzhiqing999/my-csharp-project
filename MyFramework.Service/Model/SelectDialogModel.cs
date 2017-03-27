using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyFramework.Model
{


    /// <summary>
    /// 对话框选择控件的 Model
    /// </summary>
    [Serializable]
    public class SelectDialogModel
    {
        /// <summary>
        /// 文本的控件名称.
        /// </summary>
        public string TextControlName { set; get; }


        /// <summary>
        /// 数值的控件名称.
        /// </summary>
        public string ValueControlName { set; get; }




        /// <summary>
        /// 文本的控件数值.
        /// </summary>
        public string TextControlValue { set; get; }


        /// <summary>
        /// 数值的控件数值.
        /// </summary>
        public string ValueControlValue { set; get; }


    }
}
