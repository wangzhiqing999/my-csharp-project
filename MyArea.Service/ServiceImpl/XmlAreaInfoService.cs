using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using System.Xml;
using System.Xml.Linq;

using MyArea.Model;
using MyArea.Service;



namespace MyArea.ServiceImpl
{


    /// <summary>
    /// 默认的区域服务实现.
    /// </summary>
    public class XmlAreaInfoService : IAreaInfoService
    {


        /// <summary>
        /// xml 节点.
        /// </summary>
        private XElement contacts;



        public XmlAreaInfoService(string xmlFile)
        {
            // 读取 xml 文件.
            string xmlString = File.ReadAllText(xmlFile);

            // 加载 XML.
            this.contacts = XElement.Parse(xmlString);
        }



        /// <summary>
        /// 获取顶级区域列表.
        /// </summary>
        /// <returns></returns>
        public List<AreaInfo> GetRootAreaInfoList()
        {
            var query =
                from e in this.contacts.Elements("AreaInfo")
                where
                    e.Element("ParentAreaCode") == null
                select new AreaInfo()
                {
                    AreaCode = e.Element("AreaCode").Value,
                    ParentAreaCode = null,
                    AreaName = e.Element("AreaName").Value,
                };

            var resultList = query.ToList();
            return resultList;
            
        }




        /// <summary>
        /// 获取子区域列表.
        /// </summary>
        /// <param name="areaCode"></param>
        /// <returns></returns>
        public List<AreaInfo> GetSubAreaInfoList(string areaCode)
        {
            var query =
                from e in this.contacts.Elements("AreaInfo")
                where
                    e.Element("ParentAreaCode") != null
                    && e.Element("ParentAreaCode").Value == areaCode
                select new AreaInfo()
                {
                    AreaCode = e.Element("AreaCode").Value,
                    ParentAreaCode = e.Element("ParentAreaCode").Value,
                    AreaName = e.Element("AreaName").Value,
                };

            var resultList = query.ToList();
            return resultList;
        }








        /// <summary>
        /// 获取全部的区域列表.
        /// </summary>
        /// <returns></returns>
        public List<AreaInfo> GetAllAreaInfoList()
        {
            var query =
                from e in this.contacts.Elements("AreaInfo")
                select new AreaInfo()
                {
                    AreaCode = e.Element("AreaCode").Value,
                    ParentAreaCode = e.Element("ParentAreaCode") == null ? null : e.Element("ParentAreaCode").Value,
                    AreaName = e.Element("AreaName").Value,
                };

            var resultList = query.ToList();
            return resultList;
        }



    }


}
