using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyFramework.Util
{


    [Serializable]
    public class SelectOption
    {
        /// <summary>
        /// Option 显示的文字.
        /// </summary>
        public string Text { set; get; }


        /// <summary>
        /// Option 内部的数值.
        /// </summary>
        public string Value { set; get; }



        /// <summary>
        /// 附加的数据，仅仅某些情况下使用.
        /// </summary>
        public string ExpandValue { set; get; }
    }
}
