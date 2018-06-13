using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyExamination.ServiceModel
{

    /// <summary>
    /// 问题的回答.
    /// </summary>
    public class QuestionAnswer
    {

        /// <summary>
        /// 问题流水号.
        /// </summary>
        public long QuestionID { set; get; }


        /// <summary>
        /// 单选回答.
        /// </summary>
        public string OneOptionAnswer { set; get; }


        /// <summary>
        /// 多选回答.
        /// </summary>
        public string[] MulOptionAnswer { set; get; }



        /// <summary>
        /// 结果回答.
        /// </summary>
        public string ResultAnswer
        {
            get
            {
                if (!String.IsNullOrEmpty(this.OneOptionAnswer))
                {
                    // 单选有回答.
                    return this.OneOptionAnswer;
                }
                if (this.MulOptionAnswer != null && this.MulOptionAnswer.Length > 0)
                {
                    // 多选有回答.
                    return String.Join(",", this.MulOptionAnswer);
                }

                // 没有回答.
                return String.Empty;
            }
        }


    }
}
