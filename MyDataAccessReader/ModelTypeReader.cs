using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

public static class ModelTypeReader
{

    /// <summary>
    /// 获取主键.
    /// </summary>
    /// <param name="modelType"></param>
    /// <returns></returns>
    public static Dictionary<string, string> GetKeyInfo(this Type modelType)
    {
        Dictionary<string, string> result = new Dictionary<string, string>();
        // 取得对象的所有属性.
        PropertyInfo[] propArray = modelType.GetProperties();
        // 遍历属性.
        foreach (PropertyInfo prop in propArray)
        {
            // 遍历属性上面的标签.
            foreach (var attr in prop.GetCustomAttributes(true))
            {
                // 如果是 Key 标签.
                if (attr is System.ComponentModel.DataAnnotations.KeyAttribute)
                {
                    // 加入结果.
                    result.Add("KeyName", prop.Name);
                    result.Add("KeyType", prop.PropertyType.Name);
                }
            }
        }
        return result;
    }

}
