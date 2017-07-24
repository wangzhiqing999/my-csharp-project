using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyBallot.Model;


namespace MyBallot.Service
{

    /// <summary>
    /// 用户投票接口.
    /// </summary>
    public interface IUserBallotService
    {

        /// <summary>
        /// 结果消息.
        /// </summary>
        string ResultMessage { set; get; }



        /// <summary>
        /// 用户投票.
        /// </summary>
        /// <param name="userBallot"></param>
        /// <returns></returns>
        bool TakeUserBallot(UserBallot userBallot);



    }


}
