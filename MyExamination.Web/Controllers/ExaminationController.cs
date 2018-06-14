using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using MyExamination.Model;
using MyExamination.Service;
using MyExamination.ServiceImpl;
using MyExamination.ServiceModel;

namespace MyExamination.Web.Controllers
{
    public class ExaminationController : ApiController
    {

        /// <summary>
        /// 考试服务.
        /// </summary>
        private IExaminationService _ExaminationService = new DefaultExaminationService();




        /// <summary>
        /// 取得考试列表.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Examination/GetMeExaminationList")]
        public List<MeExamination> GetMeExaminationList()
        {
            return this._ExaminationService.GetMeExaminationList();
        }


        /// <summary>
        /// 取得考试.
        /// </summary>
        /// <param name="examinationID"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Examination/GetExamination")]
        public MeExamination GetExamination(long examinationID)
        {
            return this._ExaminationService.GetExamination(examinationID);
        }



        /// <summary>
        /// 取得考试列表
        /// </summary>
        /// <param name="examinationID"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Examination/GetQuestionList")]
        public List<MeQuestion> GetQuestionList(long examinationID)
        {
            List<MeQuestion> resultList = this._ExaminationService.GetQuestionList(examinationID);
            return resultList;
        }




        /// <summary>
        /// 取得用户的试题回答信息.
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="examinationID"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Examination/GetQuestionAnswerReportList")]
        public List<MeQuestionAnswerReport> GetQuestionAnswerReportList(long userID, long examinationID)
        {
            List<MeQuestionAnswerReport> resultList = this._ExaminationService.GetQuestionAnswerReportList(userID, examinationID);
            return resultList;
        }






        /// <summary>
        /// 开始考试.
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="examinationID"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Examination/StartExamination")]
        public long StartExamination(long userID, long examinationID)
        {
            return this._ExaminationService.StartExamination(userID, examinationID);
        }



        /// <summary>
        /// 用户回答
        /// </summary>
        /// <param name="userExaminationID"></param>
        /// <param name="userID"></param>
        /// <param name="questionID"></param>
        /// <param name="userAnswer"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Examination/DoUserAnswer")]
        public bool DoUserAnswer(long userExaminationID, long userID, long questionID, string userAnswer)
        {
            return this._ExaminationService.DoUserAnswer( userExaminationID,  userID,  questionID,  userAnswer);
        }




        /// <summary>
        /// 批量提交考试回答
        /// </summary>
        /// <param name="userExaminationID"></param>
        /// <param name="userID"></param>
        /// <param name="questionAnswers"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Examination/BatchSubmitUserAnswer")]
        public bool BatchSubmitUserAnswer([FromBody]BatchSubmitUserAnswerInput data)
        {
            return this._ExaminationService.BatchSubmitUserAnswer(data);
        }





        /// <summary>
        /// 结束考试.
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="examinationID"></param>
        /// <param name="userExaminationID"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Examination/FinishExamination")]
        public bool FinishExamination(long userID, long examinationID, long userExaminationID)
        {
            return this._ExaminationService.FinishExamination(userID, examinationID, userExaminationID);
        }



    }
}
