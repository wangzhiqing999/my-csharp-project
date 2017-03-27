using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyFramework.Model
{
    /// <summary>
    /// 数字下拉列表控件的 Model
    /// </summary>
    [Serializable]
    public class NumberDropDownListModel : DropDownListModel
    {

        /// <summary>
        /// 最小值
        /// </summary>
        public int MinValue { set; get; }


        /// <summary>
        /// 最大值
        /// </summary>
        public int MaxValue { set; get; }


        /// <summary>
        /// 步长.
        /// </summary>
        private int m_Step = 1;


        /// <summary>
        /// 步长.
        /// </summary>
        public int Step
        {
            set
            {
                m_Step = value;
            }
            get
            {
                return m_Step;
            }
        }
    }

}
