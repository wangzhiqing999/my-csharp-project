using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyBallot.Model;


namespace MyBallot.Service
{

    /// <summary>
    /// 投票主表接口.
    /// </summary>
    public interface IBallotMasterService
    {

        /// <summary>
        /// 获取有效的 投票主表 数据.
        /// </summary>
        /// <param name="typeCode"></param>
        /// <returns></returns>
        BallotMaster GetActiveBallotMaster(string typeCode);

    }

}
