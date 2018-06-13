using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using MyExamination.Model;
using MyExamination.ServiceModel;

namespace MyExamination.Service
{


    /// <summary>
    /// 考试测评服务.
    /// </summary>
    public interface IExaminationService
    {

        /// <summary>
        /// 取得考试列表.
        /// </summary>
        /// <returns></returns>
        List<MeExamination> GetMeExaminationList();


        /// <summary>
        /// 取得考试.
        /// </summary>
        /// <param name="examinationID"></param>
        /// <returns></returns>
        MeExamination GetExamination(long examinationID);


        /// <summary>
        /// 取得试题列表
        /// </summary>
        /// <param name="examinationID"></param>
        /// <returns></returns>
        List<MeQuestion> GetQuestionList(long examinationID);



        /// <summary>
        /// 取得用户的试题回答信息.
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="examinationID"></param>
        /// <returns></returns>
        List<MeQuestionAnswerReport> GetQuestionAnswerReportList(long userID, long examinationID);










        /// <summary>
        /// 开始考试.
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="examinationID"></param>
        /// <returns></returns>
        long StartExamination(long userID, long examinationID);



        /// <summary>
        /// 用户回答
        /// </summary>
        /// <param name="userExaminationID"></param>
        /// <param name="userID"></param>
        /// <param name="questionID"></param>
        /// <param name="userAnswer"></param>
        /// <returns></returns>
        bool DoUserAnswer(long userExaminationID, long userID, long questionID, string userAnswer);



        /// <summary>
        /// 批量提交考试回答
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool BatchSubmitUserAnswer(BatchSubmitUserAnswerInput data);



        /// <summary>
        /// 结束考试.
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="examinationID"></param>
        /// <param name="userExaminationID"></param>
        /// <returns></returns>
        bool FinishExamination(long userID, long examinationID, long userExaminationID);













    }




}
