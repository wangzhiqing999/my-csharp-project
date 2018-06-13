using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyExamination.ServiceModel
{

    /// <summary>
    /// 批量提交考试回答输入.
    /// </summary>
    public class BatchSubmitUserAnswerInput
    {

        /// <summary>
        /// 用户考试流水
        /// </summary>
        public long UserExaminationID {set;get;}


        /// <summary>
        /// 用户ID.
        /// </summary>
        public long UserID {set;get;}


        /// <summary>
        /// 题目答案.
        /// </summary>
        public List<QuestionAnswer> QuestionAnswers { set; get; } 

    }
}
