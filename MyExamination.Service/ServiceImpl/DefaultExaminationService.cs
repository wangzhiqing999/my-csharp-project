using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

using MyExamination.Model;
using MyExamination.DataAccess;

using MyExamination.Service;
using MyExamination.ServiceModel;

namespace MyExamination.ServiceImpl
{



    public class DefaultExaminationService : IExaminationService
    {
        
        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        /// <summary>
        /// 取得试题列表
        /// </summary>
        /// <returns></returns>
        public List<MeExamination> GetMeExaminationList()
        {
            using (MyExaminationContext context = new MyExaminationContext())
            {
                var query =
                    from data in context.Examinations
                    select data;

                List<MeExamination> resultList = query.ToList();

                return resultList;
            }
        }



        /// <summary>
        /// 取得试题.
        /// </summary>
        /// <param name="examinationID"></param>
        /// <returns></returns>
        public MeExamination GetExamination(long examinationID)
        {
            using (MyExaminationContext context = new MyExaminationContext())
            {
                MeExamination result = context.Examinations.Find(examinationID);

                return result;
            }
        }



        /// <summary>
        /// 取得试题列表
        /// </summary>
        /// <param name="examinationID"></param>
        /// <returns></returns>
        public List<MeQuestion> GetQuestionList(long examinationID)
        {
            List<MeQuestion> resultList;

            using (MyExaminationContext context = new MyExaminationContext())
            {
                var query =
                    from data in context.Questions.Include("QuestionOptionList")
                    where
                        data.ExaminationID == examinationID
                    select
                        data;

                resultList = query.ToList();
            }

            // 随机排序.
            resultList = resultList.OrderBy(p => Guid.NewGuid()).ToList();


            return resultList;
        }







        public List<MeQuestionAnswerReport> GetQuestionAnswerReportList(long userID, long examinationID)
        {
            List<MeQuestionAnswerReport> resultList = new List<MeQuestionAnswerReport>();

            using (MyExaminationContext context = new MyExaminationContext())
            {

                // 查询问题.
                var questionQuery =
                    from data in context.Questions.Include("QuestionOptionList")
                    where
                        data.ExaminationID == examinationID
                    select
                        data;

                List<MeQuestion> questionList = questionQuery.ToList();
                

                // 查询回答.
                var answerQuery =
                    from data in context.UserExaminations
                    from answerData in data.UserAnswerList
                    where
                        data.ExaminationID == examinationID
                        && data.UserID == userID
                    select
                        answerData;

                List<MeUserAnswer> userAnswerList = answerQuery.ToList();


                foreach (var question in questionList)
                {
                    // 每一题.
                    foreach (var questionOption in question.QuestionOptionList)
                    {
                        // 每一个选项.
                        MeQuestionAnswerReport oneResult = new MeQuestionAnswerReport()
                        {
                            QuestionID = question.QuestionID,
                            QuestionType = question.QuestionType,
                            QuestionText = question.QuestionText,
                            DisplayOrder = question.DisplayOrder,
                            QuestionOptionID = questionOption.QuestionOptionID,
                            QuestionOptionText = questionOption.QuestionOptionText,
                        };

                        switch (oneResult.QuestionType)
                        {
                            case MeQuestionType.OneOption:
                                // 单选.
                                int count = userAnswerList.Count(p => p.QuestionID == oneResult.QuestionID && p.UserAnswer == oneResult.QuestionOptionID.ToString());
                                oneResult.UserAnswerCount = count;
                                break;

                            case MeQuestionType.MulOption:
                                // 多选.
                                int count2 = userAnswerList.Count(p => p.QuestionID == oneResult.QuestionID && p.UserAnswer.Split(',').Contains(oneResult.QuestionOptionID.ToString()));
                                oneResult.UserAnswerCount = count2;
                                break;

                            default:
                                break;
                        }

                        // 加入结果列表.
                        resultList.Add(oneResult);
                    }
                }                
            }

            return resultList;

        }





        /// <summary>
        /// 开始考试.
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="examinationID"></param>
        /// <returns></returns>
        public long StartExamination(long userID, long examinationID)
        {
            try
            {
                using (MyExaminationContext context = new MyExaminationContext())
                {
                    // 用户检查.
                    MeUser user = context.Users.Find(userID);
                    if (user == null)
                    {
                        // 用户不存在.
                        return -1;
                    }

                    // 考试主表检查.
                    MeExamination examination = context.Examinations.Find(examinationID);
                    if (examination == null)
                    {
                        // 考试主表不存在.
                        return -1;
                    }


                    MeUserExamination userExamination = new MeUserExamination()
                    {
                        // 用户
                        UserID = userID,
                        // 考试.
                        ExaminationID = examinationID,

                        // 开始时间.
                        ExaminationStartTime = DateTime.Now,                        
                    };

                    context.UserExaminations.Add(userExamination);
                    context.SaveChanges();

                    return userExamination.UserExaminationID;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                return -1;
            }
        }



        /// <summary>
        /// 用户回答
        /// </summary>
        /// <param name="userExaminationID"></param>
        /// <param name="userID"></param>
        /// <param name="questionID"></param>
        /// <param name="userAnswer"></param>
        /// <returns></returns>
        public bool DoUserAnswer(long userExaminationID, long userID, long questionID, string userAnswer)
        {
            try
            {
                using (MyExaminationContext context = new MyExaminationContext())
                {
                    // 用户检查.
                    MeUser user = context.Users.Find(userID);
                    if (user == null)
                    {
                        // 用户不存在.
                        return false;
                    }

                    // 用户考试数据检查.
                    MeUserExamination userExamination = context.UserExaminations.Find(userExaminationID);
                    if (userExamination == null)
                    {
                        // 用户考试数据不存在.
                        return false;
                    }
                    if (userExamination.UserID != userID)
                    {
                        // 参数不正确， 当前用户对别人的考试进行回答.
                        return false;
                    }                   
                    if (userExamination.ExaminationFinishTime != null)
                    {
                        // 考试已经结束.
                        return false;
                    }


                    // 获取具体的问题.
                    MeQuestion question = context.Questions.Find(questionID);
                    if (question == null)
                    {
                        // 问题不存在.
                        return false;
                    }


                    // 单选或者多选的情况下，检查 提交的答案， 是否是 可选答案.
                    if (question.QuestionType == MeQuestionType.OneOption)
                    {
                        long questionOptionID = 0;
                        if (!Int64.TryParse(userAnswer, out questionOptionID))
                        {
                            // 对于 单选/多选， 提交的数据， 无法解析为 long 值.
                            return false;
                        }

                        MeQuestionOption questionOption = context.QuestionOptions.Find(questionOptionID);
                        if (questionOption == null)
                        {
                            // 不存在的 答案选项.
                            return false;
                        }
                        if (questionOption.QuestionID != questionID)
                        {
                            // 答案选项， 与 问题不匹配.
                            return false;
                        }
                    }
                    if (question.QuestionType == MeQuestionType.MulOption)
                    {
                        string[] mulUserAnswer = userAnswer.Split(',');
                        foreach (string answerString in mulUserAnswer)
                        {
                            long questionOptionID = 0;
                            if (!Int64.TryParse(answerString, out questionOptionID))
                            {
                                // 对于 单选/多选， 提交的数据， 无法解析为 long 值.
                                return false;
                            }
                            MeQuestionOption questionOption = context.QuestionOptions.Find(questionOptionID);
                            if (questionOption == null)
                            {
                                // 不存在的 答案选项.
                                return false;
                            }
                            if (questionOption.QuestionID != questionID)
                            {
                                // 答案选项， 与 问题不匹配.
                                return false;
                            }
                        }
                    }


                    var answerQuery =
                        from data in context.UserAnswers
                        where
                            data.UserExaminationID == userExaminationID
                            && data.UserID == userID
                            && data.QuestionID == questionID
                        select
                            data;

                    MeUserAnswer userAnswerData = answerQuery.SingleOrDefault();

                    if (userAnswerData == null)
                    {
                        // 是首次回答.
                        userAnswerData = new MeUserAnswer()
                        {
                            // 用户考试ID.
                            UserExaminationID = userExaminationID,
                            // 用户ID.
                            UserID = userID,
                            // 问题ID.
                            QuestionID = questionID,
                            // 回答.
                            UserAnswer = userAnswer,                            
                        };
                        context.UserAnswers.Add(userAnswerData);
                    }
                    else
                    {
                        // 是修改之前的回答.
                        userAnswerData.UserAnswer = userAnswer;
                    }

                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                return false;
            }
        }






        public bool BatchSubmitUserAnswer(BatchSubmitUserAnswerInput data)
        {
            try
            {
                using (MyExaminationContext context = new MyExaminationContext())
                {
                    // 用户检查.
                    MeUser user = context.Users.Find(data.UserID);
                    if (user == null)
                    {
                        // 用户不存在.
                        return false;
                    }

                    // 用户考试数据检查.
                    MeUserExamination userExamination = context.UserExaminations.Find(data.UserExaminationID);
                    if (userExamination == null)
                    {
                        // 用户考试数据不存在.
                        return false;
                    }
                    if (userExamination.UserID != data.UserID)
                    {
                        // 参数不正确， 当前用户对别人的考试进行回答.
                        return false;
                    }
                    if (userExamination.ExaminationFinishTime != null)
                    {
                        // 考试已经结束.
                        return false;
                    }



                    foreach (QuestionAnswer item in data.QuestionAnswers)
                    {
                        // 获取具体的问题.
                        MeQuestion question = context.Questions.Find(item.QuestionID);
                        if (question == null)
                        {
                            // 问题不存在.
                            return false;
                        }
  

                        // 单选的情况下，检查 提交的答案， 是否是 可选答案.
                        if (question.QuestionType == MeQuestionType.OneOption)
                        {
                            long questionOptionID = 0;
                            if (!Int64.TryParse(item.OneOptionAnswer, out questionOptionID))
                            {
                                // 对于 单选/多选， 提交的数据， 无法解析为 long 值.
                                return false;
                            }

                            MeQuestionOption questionOption = context.QuestionOptions.Find(questionOptionID);
                            if (questionOption == null)
                            {
                                // 不存在的 答案选项.
                                return false;
                            }
                            if (questionOption.QuestionID != item.QuestionID)
                            {
                                // 答案选项， 与 问题不匹配.
                                return false;
                            }
                        }
                        // 多选的情况下，检查 提交的答案， 是否是 可选答案.
                        if (question.QuestionType == MeQuestionType.MulOption)
                        {
                            foreach (string answerString in item.MulOptionAnswer)
                            {
                                long questionOptionID = 0;
                                if (!Int64.TryParse(answerString, out questionOptionID))
                                {
                                    // 对于 单选/多选， 提交的数据， 无法解析为 long 值.
                                    return false;
                                }
                                MeQuestionOption questionOption = context.QuestionOptions.Find(questionOptionID);
                                if (questionOption == null)
                                {
                                    // 不存在的 答案选项.
                                    return false;
                                }
                                if (questionOption.QuestionID != item.QuestionID)
                                {
                                    // 答案选项， 与 问题不匹配.
                                    return false;
                                }
                            }                            
                        }

                        var answerQuery =
                            from answerData in context.UserAnswers
                            where
                                answerData.UserExaminationID == data.UserExaminationID
                                && answerData.UserID == data.UserID
                                && answerData.QuestionID == item.QuestionID
                            select
                                answerData;

                        MeUserAnswer userAnswerData = answerQuery.SingleOrDefault();

                        if (userAnswerData == null)
                        {
                            // 是首次回答.
                            userAnswerData = new MeUserAnswer()
                            {
                                // 用户考试ID.
                                UserExaminationID = data.UserExaminationID,
                                // 用户ID.
                                UserID = data.UserID,
                                // 问题ID.
                                QuestionID = item.QuestionID,
                                // 回答.
                                UserAnswer = item.ResultAnswer,
                            };
                            context.UserAnswers.Add(userAnswerData);
                        }
                        else
                        {
                            // 是修改之前的回答.
                            userAnswerData.UserAnswer = item.ResultAnswer;
                        }
                    }



                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                return false;
            }
        }




        /// <summary>
        /// 结束考试.
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="examinationID"></param>
        /// <returns></returns>
        public bool FinishExamination(long userID, long examinationID, long userExaminationID)
        {
            try
            {
                using (MyExaminationContext context = new MyExaminationContext())
                {
                    // 用户检查.
                    MeUser user = context.Users.Find(userID);
                    if (user == null)
                    {
                        // 用户不存在.
                        return false;
                    }

                    // 考试主表检查.
                    MeExamination examination = context.Examinations.Find(examinationID);
                    if (examination == null)
                    {
                        // 考试主表不存在.
                        return false;
                    }

                    // 用户考试数据检查.
                    MeUserExamination userExamination = context.UserExaminations.Find(userExaminationID);
                    if (userExamination == null)
                    {
                        // 用户考试数据不存在.
                        return false;
                    }
                    if (userExamination.UserID != userID)
                    {
                        // 参数不正确， 当前用户尝试结束别人的考试.
                        return false;
                    }
                    if (userExamination.ExaminationID != examinationID)
                    {
                        // 参数不正确， 当前用户尝试结束另外一个考试代码不匹配的考试.
                        return false;
                    }

                    if (userExamination.ExaminationFinishTime != null)
                    {
                        // 考试已经结束.
                        return false;
                    }





                    // #####  计算成绩. #####

                    // 先获取用户回答数据.
                    var userAnswerQuery =
                        from data in context.UserAnswers
                        where
                            data.UserExaminationID == userExaminationID
                        select
                            data;
                    List<MeUserAnswer> userAnswerList = userAnswerQuery.ToList();


                    // 获取试题与选项.
                    var query =
                        from data in context.Questions.Include("QuestionOptionList")
                    where
                        data.ExaminationID == examinationID
                    select
                       data;
                    List<MeQuestion> questionList = query.ToList();


                    // 总成绩.
                    int totalPoint = 0;


                    // 遍历每一题.
                    foreach (var questionData in questionList)
                    {
                        // 正确答案.
                        List<string> rightAnswerList = new List<string>();

                        switch (questionData.QuestionType)
                        {
                            case MeQuestionType.OneOption:
                                // 单选.
                                var rigthData = questionData.QuestionOptionList.SingleOrDefault(p => p.IsRightOption);
                                if (rigthData == null)
                                {
                                    logger.WarnFormat("题目答案出现异常， 第 {0} 题， 不存在正确的选择项目", questionData.QuestionID);
                                } else {
                                    rightAnswerList.Add(rigthData.QuestionOptionID.ToString());
                                }
                                break;

                            case MeQuestionType.MulOption:
                                // 多选.
                                List<string> answerList = questionData.QuestionOptionList.Where(p => p.IsRightOption).Select(p => p.QuestionOptionID.ToString()).ToList();
                                rightAnswerList.AddRange(answerList);
                                break;
                            default:
                                // 未知.
                                break;
                        }

                        
                        // 获取用户输入.
                        MeUserAnswer userAnswer = userAnswerList.SingleOrDefault(p=>p.UserExaminationID == userExaminationID && p.QuestionID == questionData.QuestionID);

                        if (userAnswer == null)
                        {
                            logger.WarnFormat("回答出现一些问题， 第 {0} 题， 用户 {1} 没有做回答。", questionData.QuestionID, userID);
                            // 用户未回答当前题目.
                            continue;
                        }

                        if (CompareUserAnswer(rightAnswerList, userAnswer.UserAnswer))
                        {
                            // 回答正确时， 获得分数.
                            userAnswer.AnswerPoint = questionData.QuestionPoint;

                            // 累加总成绩.
                            totalPoint += questionData.QuestionPoint;
                        }

                    }

                    // 设置结束时间.
                    userExamination.ExaminationFinishTime = DateTime.Now;

                    // 设置总成绩.
                    userExamination.ExaminationPoint = totalPoint;

                    context.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
                return false;
            }
        }



        private bool CompareUserAnswer(List<string> rightAnswerList, string userAnswer)
        {
            // 用户答案按 , 拆分.
            string [] dataArray = userAnswer.Split(',');


            if (dataArray.Length != rightAnswerList.Count)
            {
                // 用户答案 与 正确答案 数量不匹配.
                return false;
            }

            foreach (var rightAnswer in rightAnswerList)
            {
                if (!dataArray.Contains(rightAnswer))
                {
                    // 存在有 正确的答案， 在用户的答案中， 未选择的情况.
                    return false;
                }
            }

            // 如果能执行到这里， 认为是正确选择的.
            return true;
        }





    }



}
