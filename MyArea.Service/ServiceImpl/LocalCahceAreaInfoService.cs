using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using Newtonsoft.Json;

using MyArea.Model;
using MyArea.Service;



namespace MyArea.ServiceImpl
{

    /// <summary>
    /// 本地缓存服务.
    /// </summary>
    public class LocalCahceAreaInfoService : IAreaInfoService
    {

        /// <summary>
        /// 真实的区域信息服务.
        /// </summary>
        private IAreaInfoService realAreaInfoService;


        /// <summary>
        /// 本地缓存路径.
        /// </summary>
        private string localCachePath;


        /// <summary>
        /// 本地缓存可用小时数.
        /// </summary>
        private int localCacheUseAbleHours;






        public LocalCahceAreaInfoService(IAreaInfoService realAreaInfoService, string localCachePath, int localCacheUseAbleHours)
        {
            this.realAreaInfoService = realAreaInfoService;
            this.localCachePath = localCachePath;
            this.localCacheUseAbleHours = localCacheUseAbleHours;
        }




        /// <summary>
        /// 尝试加载缓存.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private string TryLoadCache(string fileName)
        {
            // 缓存文件名.
            string cacheFileName = String.Format(@"{0}\{1}", localCachePath, fileName);

            // 预期结果.
            string resultString = null;


            if (File.Exists(cacheFileName))
            {
                // 缓存文件存在.
                FileInfo fi = new FileInfo(cacheFileName);
                if ((DateTime.Now - fi.CreationTime).Hours < 24)
                {
                    // 24小时以内， 使用缓存.
                    resultString = File.ReadAllText(cacheFileName, Encoding.UTF8);
                }
            }

            return resultString;
        }



        /// <summary>
        /// 尝试存储缓存信息.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="resultData"></param>
        private void TrySaveCache(string fileName, string resultData)
        {
            // 缓存文件名.
            string cacheFileName = String.Format(@"{0}\{1}", localCachePath, fileName);

            if (!String.IsNullOrEmpty(resultData))
            {
                // 结果非空的情况下， 写入缓存文件.
                File.WriteAllText(cacheFileName, resultData, Encoding.UTF8);
            }
        }








        public List<AreaInfo> GetRootAreaInfoList()
        {
            // 缓存文件名.
            string cacheFileName = "root.json";

            // 尝试加载缓存.
            string resultString = this.TryLoadCache(cacheFileName);


            if (!String.IsNullOrEmpty(resultString))
            {
                // 读取到缓存数据.
                var cacheResult = JsonConvert.DeserializeObject<List<AreaInfo>>(resultString);
                // 返回.
                return cacheResult;
            }
            

            // 未读取到缓存数据.
            var result = this.realAreaInfoService.GetRootAreaInfoList();

            // 进行缓存.
            resultString = JsonConvert.SerializeObject(result);
            this.TrySaveCache(cacheFileName, resultString);


            return result;
        }





        public List<AreaInfo> GetSubAreaInfoList(string areaCode)
        {
            // 缓存文件名.
            string cacheFileName = String.Format("{0}_sub.json", areaCode);

            // 尝试加载缓存.
            string resultString = this.TryLoadCache(cacheFileName);


            if (!String.IsNullOrEmpty(resultString))
            {
                // 读取到缓存数据.
                var cacheResult = JsonConvert.DeserializeObject<List<AreaInfo>>(resultString);
                // 返回.
                return cacheResult;
            }


            // 未读取到缓存数据.
            var result = this.realAreaInfoService.GetSubAreaInfoList(areaCode);

            // 进行缓存.
            resultString = JsonConvert.SerializeObject(result);
            this.TrySaveCache(cacheFileName, resultString);


            return result;
        }



        public List<AreaInfo> GetAllAreaInfoList()
        {
            throw new NotImplementedException();
        }
    }



}
