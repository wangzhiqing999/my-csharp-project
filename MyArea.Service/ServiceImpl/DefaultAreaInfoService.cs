using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using MyArea.Model;
using MyArea.DataAccess;
using MyArea.Service;



namespace MyArea.ServiceImpl
{


    /// <summary>
    /// 默认的区域服务实现.
    /// </summary>
    public class DefaultAreaInfoService : IAreaInfoService
    {



        /// <summary>
        /// 获取顶级区域列表.
        /// </summary>
        /// <returns></returns>
        public List<AreaInfo> GetRootAreaInfoList()
        {
            using (MyAreaContext context = new MyAreaContext())
            {
                var query =
                    from data in context.AreaInfos
                    where
                        data.ParentAreaCode == null
                    select data;

                var resultList = query.ToList();
                return resultList;
            }
        }




        /// <summary>
        /// 获取子区域列表.
        /// </summary>
        /// <param name="areaCode"></param>
        /// <returns></returns>
        public List<AreaInfo> GetSubAreaInfoList(string areaCode)
        {
            using (MyAreaContext context = new MyAreaContext())
            {
                var query =
                    from data in context.AreaInfos
                    where
                        data.ParentAreaCode == areaCode
                    select data;

                var resultList = query.ToList();
                return resultList;
            }
        }



        /// <summary>
        /// 获取全部的区域列表.
        /// </summary>
        /// <returns></returns>
        public List<AreaInfo> GetAllAreaInfoList()
        {
            using (MyAreaContext context = new MyAreaContext())
            {
                var query =
                    from data in context.AreaInfos
                    select data;

                var resultList = query.ToList();
                return resultList;
            }
        }
    }


}
