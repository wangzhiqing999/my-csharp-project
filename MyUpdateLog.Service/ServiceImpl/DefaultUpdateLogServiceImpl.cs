using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using Newtonsoft.Json;


using MyUpdateLog.Model;
using MyUpdateLog.DataAccess;

using MyUpdateLog.Service;




namespace MyUpdateLog.ServiceImpl
{


    public class DefaultUpdateLogServiceImpl : IUpdateLogService
    {
        /// <summary>
        /// 成功返回的消息.
        /// </summary>
        private const string SUCCESS_MESSAGE = "success";




        public bool SaveUpdateLog(string categoryCode, object keyData, string updateUser, object beforeData, object afterData, ref string resultMsg)
        {

            // 首先，排除掉 更新前与更新后，  都是 null 的情况.
            if (beforeData == null && afterData == null)
            {
                resultMsg = "更新前的数据与更新后的数据，都是 null.";
                return false;
            }

            // 然后， 排除 keyData 是 null 的情况.
            if (keyData == null)
            {
                resultMsg = "主键数据不能为空！";
                return false;
            }

            try
            {

                List<UpdateItem> updateItemList = this.GetUpdateItemList(beforeData, afterData);
                string jsonString = JsonConvert.SerializeObject(updateItemList);


                using (MyUpdateLogContext context = new MyUpdateLogContext())
                {
                    // 检查分类是否存在.
                    var category = context.UpdateLogCategorys.Find(categoryCode);
                    if (category == null)
                    {
                        resultMsg = String.Format("未知的分类代码: {0}", categoryCode);
                        return false;
                    }

                    UpdateLogDetail detail = new UpdateLogDetail()
                    {
                        // 分类代码.
                        CategoryCode = categoryCode,
                        // 主键数据.
                        KeyData = keyData.ToString(),
                        // 什么时间更新的.
                        WhenUpdate = DateTime.Now,
                        // 谁更新的.
                        WhoUpdate = updateUser,
                        // 更新了什么.
                        WhatUpdate = jsonString,
                    };

                    // 插入.
                    context.UpdateLogDetails.Add(detail);

                    // 保存.
                    context.SaveChanges();

                }


                resultMsg = SUCCESS_MESSAGE;
                return true;
            }
            catch (Exception ex)
            {
                resultMsg = ex.Message;
                return false;
            }



            throw new NotImplementedException();
        }






        /// <summary>
        /// 获取更新日志.
        /// </summary>
        /// <param name="beforeData"></param>
        /// <param name="afterData"></param>
        /// <returns></returns>
        private List<UpdateItem> GetUpdateItemList(object beforeData, object afterData)
        {
            if (beforeData != null)
            {
                // 更新前 != null
                if (afterData != null)
                {
                    // 更新前 != null， 更新后 != null.
                    // 理解为 更新操作.
                    return this.GetUpdateInfo(beforeData, afterData);
                }
                else
                {
                    // 更新前 != null， 更新后 == null.
                    // 理解为 删除操作.
                    return this.GetDeleteInfo(beforeData);
                }
            }
            else
            {
                // 更新前 == null
                if (afterData != null)
                {
                    // 更新前 == null， 更新后 != null.
                    // 理解为 新增操作.
                    return this.GetInsertInfo(afterData);
                }
                else
                {
                    // 更新前后均为 null.
                    // 这个情况，在外部已经屏蔽掉了.
                    return null;
                }
            }
        }





        /// <summary>
        /// 获取插入操作的信息.
        /// </summary>
        /// <param name="afterData"></param>
        /// <returns></returns>
        private List<UpdateItem> GetInsertInfo(object afterData)
        {
            // 最终结果.
            List<UpdateItem> resultList = new List<UpdateItem>();


            // 更新后对象类型.
            Type afterDataType = afterData.GetType();
            // 更新后对象的所有属性.
            PropertyInfo[] afterDataPropArray = afterDataType.GetProperties();



             // 遍历更新前对象所有的属性.
            foreach (PropertyInfo afterProp in afterDataPropArray)
            {
                if (!afterProp.CanRead || !afterProp.CanWrite)
                {
                    // 忽略掉 只读 / 只写 的属性.
                    continue;
                }


                if (afterProp.CustomAttributes.Count(p => p.AttributeType.Name == "ColumnAttribute") == 0)
                {
                    // 仅仅处理有  [Column("列名")]  这样的标记的.
                    // 其他的忽略.
                    continue;
                }


                // 从 更新后 对象 获取属性值.
                Object afterVal = afterProp.GetValue(afterData, null);



                if (afterVal != null)
                {
                    // 更新后非空.
                    UpdateItem oneResult = new UpdateItem()
                    {
                        ItemName = afterProp.Name,
                        BeforeValue = null,
                        AftertValue = afterVal.ToString(),
                    };
                    resultList.Add(oneResult);
                }
            }


            // 返回.
            return resultList;
        }



        /// <summary>
        /// 获取更新操作的信息.
        /// </summary>
        /// <param name="beforeData"></param>
        /// <param name="afterData"></param>
        /// <returns></returns>
        private List<UpdateItem> GetUpdateInfo(object beforeData, object afterData)
        {

            // 最终结果.
            List<UpdateItem> resultList = new List<UpdateItem>();


            // 更新前对象类型.
            Type beforeDataType = beforeData.GetType();
            // 更新前对象的所有属性.
            PropertyInfo[] beforeDataPropArray = beforeDataType.GetProperties();

            // 更新后对象类型.
            Type afterDataType = afterData.GetType();
            // 更新后对象的所有属性.
            PropertyInfo[] afterDataPropArray = afterDataType.GetProperties();



            // 遍历更新前对象所有的属性.
            foreach (PropertyInfo beforeProp in beforeDataPropArray)
            {
                if (!beforeProp.CanRead || !beforeProp.CanWrite)
                {
                    // 忽略掉 只读 / 只写 的属性.
                    continue;
                }


                if (beforeProp.CustomAttributes.Count(p => p.AttributeType.Name == "ColumnAttribute") == 0)
                {
                    // 仅仅处理有  [Column("列名")]  这样的标记的.
                    // 其他的忽略.
                    continue;
                }



                // 去更新后对象查找， 是否存在有 同名 / 同数据类型 的属性.
                PropertyInfo afterProp = afterDataPropArray.FirstOrDefault(
                    p => p.Name == beforeProp.Name
                        && p.PropertyType.FullName == beforeProp.PropertyType.FullName);

                if (afterProp == null)
                {
                    // 更新前对象有属性. 更新后对象没有.
                    // 忽略.
                    continue;
                }

                if (!afterProp.CanRead || !afterProp.CanWrite)
                {
                    // 忽略掉 只读 / 只写 的属性.
                    continue;
                }


                // 分别取得 更新前 / 更新后  的数值.

                // 从 更新前/更新后 对象 获取属性值.
                Object beforeVal = beforeProp.GetValue(beforeData, null);
                Object afterVal = afterProp.GetValue(afterData, null);


                if (beforeVal != null)
                {
                    if (afterVal != null)
                    {
                        // 更新前后，都非空.  
                        // 判断是否一致.                        
                        if (beforeVal.ToString() == afterVal.ToString())
                        {
                            // 一致的情况下， 忽略.
                            continue;
                        }



                        UpdateItem oneResult = new UpdateItem()
                        {
                            ItemName = beforeProp.Name,
                            BeforeValue = beforeVal.ToString(),
                            AftertValue = afterVal.ToString(),
                        };
                        resultList.Add(oneResult);
                    }
                    else
                    {
                        // 更新前非空. 更新后为空.
                        UpdateItem oneResult = new UpdateItem()
                        {
                            ItemName = beforeProp.Name,
                            BeforeValue = beforeVal.ToString(),
                            AftertValue = null,
                        };
                        resultList.Add(oneResult);
                    }
                }
                else
                {
                    if (afterVal != null)
                    {
                        // 更新前为空. 更新后非空.
                        UpdateItem oneResult = new UpdateItem()
                        {
                            ItemName = beforeProp.Name,
                            BeforeValue = null,
                            AftertValue = afterVal.ToString(),
                        };
                        resultList.Add(oneResult);
                    }
                    else
                    {
                        // 更新前后均为空， 可以理解为 未发生更新.
                        continue;
                    }
                }
            }

            // 返回.
            return resultList;

        }




        /// <summary>
        /// 获取删除操作的信息.
        /// </summary>
        /// <param name="beforeData"></param>
        /// <returns></returns>
        private List<UpdateItem> GetDeleteInfo(object beforeData)
        {
            // 最终结果.
            List<UpdateItem> resultList = new List<UpdateItem>();


            // 更新前对象类型.
            Type beforeDataType = beforeData.GetType();
            // 更新前对象的所有属性.
            PropertyInfo[] beforeDataPropArray = beforeDataType.GetProperties();



            
            // 遍历更新前对象所有的属性.
            foreach (PropertyInfo beforeProp in beforeDataPropArray)
            {
                if (!beforeProp.CanRead || !beforeProp.CanWrite)
                {
                    // 忽略掉 只读 / 只写 的属性.
                    continue;
                }

                if (beforeProp.CustomAttributes.Count(p => p.AttributeType.Name == "ColumnAttribute") == 0)
                {
                    // 仅仅处理有  [Column("列名")]  这样的标记的.
                    // 其他的忽略.
                    continue;
                }


                // 从 更新前/更新后 对象 获取属性值.
                Object beforeVal = beforeProp.GetValue(beforeData, null);

                if (beforeVal != null)
                {
                    // 更新前非空.
                    UpdateItem oneResult = new UpdateItem()
                    {
                        ItemName = beforeProp.Name,
                        BeforeValue = beforeVal.ToString(),
                        AftertValue = null,
                    };
                    resultList.Add(oneResult);
                }

            }


            // 返回.
            return resultList;
        }


    }
}
