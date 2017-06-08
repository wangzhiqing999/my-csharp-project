using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyFramework.Util;

using MyDocument.Model;
using MyDocument.DataAccess;

using MyDocument.Service;


namespace MyDocument.ServiceImpl
{

    public class DefaultDocumentService : IDocumentService
    {

        /// <summary>
        /// 取得文档列表.
        /// </summary>
        /// <param name="typeCode"></param>
        /// <param name="pgInfo"></param>
        /// <returns></returns>
        public List<Document> GetDocumentList(string typeCode, ref PageInfo pgInfo)
        {
            using (MyDocumentContext context = new MyDocumentContext())
            {
                var query =
                    from data in context.Documents
                    where
                        data.DocumentTypeCode == typeCode
                    select
                        data;


                pgInfo = new PageInfo(
                    pageSize: pgInfo.PageSize,
                    pageNo: pgInfo.PageIndex,
                    rowCount: query.Count());

                query = query.OrderByDescending(p => p.CreateTime)
                    .Skip(pgInfo.SkipValue)
                    .Take(pgInfo.PageSize);

                List<Document> resultList = query.ToList();

                return resultList;
            }
        }

    }
}
