using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MyUpdateLog.Service
{

    public interface IUpdateLogService
    {
        bool SaveUpdateLog(string categoryCode, object keyData, string updateUser, object beforeData, object afterData, ref string resultMsg);

    }

}
