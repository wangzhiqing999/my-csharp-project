using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyFramework.Util;

using MyFx678Kx.Model;
using MyFx678Kx.DataAccess;
using MyFx678Kx.Service;
 

namespace MyFx678Kx.ServiceImpl
{

    public class DefaultFx678KxService : IFx678KxService
    {


        /// <summary>
        /// 获取快讯
        /// </summary>
        /// <param name="pgInfo"></param>
        /// <param name="pageNo"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<Fx678Kx> GetFx678KxList(ref PageInfo pgInfo, int pageNo = 1, int pageSize = 30)
        {
            List<Fx678Kx> resultList = new List<Fx678Kx>();


            using (MyFx678KxContext context = new MyFx678KxContext())
            {

                var query =
                    from data in context.Fx678Kxs
                    where
                        !data.Title.Contains("images")
                    select data;


                // 初始化翻页.
                pgInfo = new PageInfo(
                    pageSize: pageSize,
                    pageNo: pageNo,
                    rowCount: query.Count());


                query = query.OrderByDescending(p=>p.PubDate)
                    .Skip(pgInfo.SkipValue)
                    .Take(pgInfo.PageSize);


                resultList = query.ToList();
            }

            return resultList;
        }



    }


}
