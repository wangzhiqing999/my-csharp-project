using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDocument.Mvc.Common
{

    /// <summary>
    /// 上传文件检查.
    /// </summary>
    public class UploadFileChecker
    {


        #region 图片扩展名检查.

        /// <summary>
        /// 可接受的 图片扩展名.
        /// </summary>
        public static readonly string[] AccessAbleImageExt = { 
                                                  ".jpg",
                                                  ".gif",
                                                  ".png"
                                              };

        /// <summary>
        /// 用于显示的 可接受的 图片扩展名.
        /// </summary>
        public static readonly string DisplayAccessAbleImageExt = string.Join(",", AccessAbleImageExt);



        /// <summary>
        /// 图片文件扩展名检查
        /// </summary>
        /// <param name="fileExt"></param>
        /// <returns></returns>
        public static bool CheckImageFileExt(string fileName)
        {
            int lastIndex = fileName.LastIndexOf(".");

            if (lastIndex <= 0)
            {
                return false;
            }


            // 取得扩展名
            string ext = fileName.Substring(lastIndex);

            if (String.IsNullOrEmpty(ext))
            {
                return false;
            }

            // 小写.
            ext = ext.ToLower();


            // 返回.
            return AccessAbleImageExt.Contains(ext);

        }


        #endregion 图片扩展名检查.







        #region  Pdf 扩展名检查.

        /// <summary>
        /// 可接受的 Pdf 扩展名.
        /// </summary>
        public static readonly string[] AccessAblePdfExt = { 
                                                  ".pdf"
                                              };

        /// <summary>
        /// 用于显示的 可接受的 Pdf 扩展名.
        /// </summary>
        public static readonly string DisplayAccessAblePdfExt = string.Join(",", AccessAblePdfExt);



        /// <summary>
        /// Pdf 文件扩展名检查
        /// </summary>
        /// <param name="fileExt"></param>
        /// <returns></returns>
        public static bool CheckPdfFileExt(string fileName)
        {
            int lastIndex = fileName.LastIndexOf(".");

            if (lastIndex <= 0)
            {
                return false;
            }


            // 取得扩展名
            string ext = fileName.Substring(lastIndex);

            if (String.IsNullOrEmpty(ext))
            {
                return false;
            }

            // 小写.
            ext = ext.ToLower();


            // 返回.
            return AccessAblePdfExt.Contains(ext);

        }




        #endregion




    }


}