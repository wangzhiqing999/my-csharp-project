using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Text;
using System.Text.RegularExpressions;

using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using log4net;

using MyFramework.Util;

using MyDocument.Model;
using MyDocument.DataAccess;

using MyDocument.Mvc.Common;


namespace MyDocument.Mvc.Controllers
{
    public class DocumentTypeController : Controller
    {

        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        //
        // GET: /DocumentType/

        public ActionResult Index(
            string searchDocumentTypeCode,
            string searchDocumentTypeName,
			int? pageNo,
            int? pageSize)
        {
			List<DocumentType>  dataList = null;

			using (MyDocumentContext context = new MyDocumentContext())
            {
                var query =
                    from data in context.DocumentTypes
                    select data;


                if (!String.IsNullOrEmpty(searchDocumentTypeCode))
                {
                    query = query.Where(p => p.DocumentTypeCode.Contains(searchDocumentTypeCode));
                }

                if (!String.IsNullOrEmpty(searchDocumentTypeName))
                {
                    query = query.Where(p => p.DocumentTypeName.Contains(searchDocumentTypeName));
                }


                // 初始化翻页.
                PageInfo pgInfo = new PageInfo(
                    pageSize: pageSize, 
                    pageNo: pageNo, 
                    rowCount: query.Count());

                ViewBag.PageInfo = pgInfo;


				query = query.OrderBy(p => p.DocumentTypeCode)
                    .Skip(pgInfo.SkipValue)
                    .Take(pgInfo.PageSize);     

				// 查询数据.
                dataList = query.ToList();
			}

			// 显示画面.
            return View(dataList);
        }



        //
        // GET: /DocumentType/Details/5

        public ActionResult Details(string id, string returnQueryString)
        {
            DocumentType data = null;
            using (MyDocumentContext context = new MyDocumentContext())
            {
                data = context.DocumentTypes.Find(id);
            }
			if (data == null)
            {
                return HttpNotFound();
            }

			// 设置返回的 RouteValueDictionary
            ViewBag.ReturnQueryRouteValue = ReturnQueryRouteValueBuilder.GetReturnQueryRouteValue(returnQueryString);

            return View(data);
        }




        //
        // GET: /DocumentType/Create

        public ActionResult Create(string returnQueryString)
        {
            // 设置返回的 RouteValueDictionary
            ViewBag.ReturnQueryRouteValue = ReturnQueryRouteValueBuilder.GetReturnQueryRouteValue(returnQueryString);

            return View();
        }

        //
        // POST: /DocumentType/Create

        [HttpPost]
        public ActionResult Create(DocumentType data, string returnQueryString, HttpPostedFileBase logoFile)
        {

            if (logoFile != null && !String.IsNullOrEmpty(logoFile.FileName))
            {
                // 上传了文件.
                // 取得上传的文件名.
                string uploadFileName = System.IO.Path.GetFileName(logoFile.FileName);
                if (!UploadFileChecker.CheckImageFileExt(uploadFileName))
                {
                    ViewBag.Message = String.Format("文件仅仅允许上传 {0} 扩展名的文件！", UploadFileChecker.DisplayAccessAbleImageExt);
                    return View(data);
                }

                data.DocumentTypeLogo = SaveLogoFile(logoFile);
            }
            


            try
            {
                if (ModelState.IsValid)
                {
                    // 假如数据检查无误.
                    // 将数据加入结果列表.
                    using (MyDocumentContext context = new MyDocumentContext())
                    {
                        DocumentType oldDocumentType =
                            context.DocumentTypes.Find(data.DocumentTypeCode);
                        if (oldDocumentType != null)
                        {
                            ViewBag.Message = "代码已存在！";
                            return View();
                        }


                        DataRecorder.BeforeInsertOperation(Session, data);
                        context.DocumentTypes.Add(data);
                        context.SaveChanges();
                    }

                    return RedirectToAction(
                        "Index", 
                        ReturnQueryRouteValueBuilder.GetReturnQueryRouteValue(returnQueryString));
				}
                else
                {
                    // 假如数据检查有误， 那么返回原有的画面，让用户继续修改.
                    return View(data);
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbErr)
            {
                foreach (var errItem in dbErr.EntityValidationErrors)
                {
                    foreach (var err in errItem.ValidationErrors)
                    {
                        logger.InfoFormat("{0} : {1}", err.PropertyName, err.ErrorMessage);
                    }
                }

                logger.Error(dbErr.Message, dbErr);
                ViewBag.Message = dbErr.Message;
                return View(data);
            }
            catch(Exception ex)
            {
                logger.Error(ex.Message, ex);
				ViewBag.Message = "服务器忙.请稍候在尝试执行本操作。";
                return View(data);
            }
        }




        //
        // GET: /DocumentType/Edit/5

        public ActionResult Edit(string id, string returnQueryString)
        {
            DocumentType data = null;

            using (MyDocumentContext context = new MyDocumentContext())
            {
                data = context.DocumentTypes.Find(id);
            }
            if (data == null)
            {
                return HttpNotFound();
            }

			// 设置返回的 RouteValueDictionary
            ViewBag.ReturnQueryRouteValue = ReturnQueryRouteValueBuilder.GetReturnQueryRouteValue(returnQueryString);

            return View(data);
        }

        //
        // POST: /DocumentType/Edit/5

        [HttpPost]
        public ActionResult Edit(DocumentType data, string returnQueryString, HttpPostedFileBase logoFile)
        {

            if (logoFile != null && !String.IsNullOrEmpty(logoFile.FileName))
            {
                // 上传了文件.
                // 取得上传的文件名.
                string uploadFileName = System.IO.Path.GetFileName(logoFile.FileName);
                if (!UploadFileChecker.CheckImageFileExt(uploadFileName))
                {
                    ViewBag.Message = String.Format("文件仅仅允许上传 {0} 扩展名的文件！", UploadFileChecker.DisplayAccessAbleImageExt);
                    return View(data);
                }

                data.DocumentTypeLogo = SaveLogoFile(logoFile);
            }


            try
            {
				if (ModelState.IsValid)
                {
                    // 假如数据检查无误.
                    // 更新数据.

                    using (MyDocumentContext context = new MyDocumentContext())
                    {
                        DocumentType oldDocumentType =
                            context.DocumentTypes.Find(data.DocumentTypeCode);
                        if (oldDocumentType == null)
                        {
                            ViewBag.Message = "数据不存在！";
                            return View(data);
                        }

                        DataRecorder.BeforeUpdateOperation(Session, data);


                        // 先从上下文中的旧实体获取跟踪
                        DbEntityEntry entry = context.Entry(oldDocumentType);

                        // 把新值设置到旧实体上
                        entry.CurrentValues.SetValues(data);  
                        
                        // 物理保存.
                        context.SaveChanges();
                    }

                    return RedirectToAction(
                        "Index",
                        ReturnQueryRouteValueBuilder.GetReturnQueryRouteValue(returnQueryString));
                }
                else
                {
                    // 假如数据检查有误， 那么返回原有的画面，让用户继续修改.
                    return View(data);
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbErr)
            {
                foreach (var errItem in dbErr.EntityValidationErrors)
                {
                    foreach (var err in errItem.ValidationErrors)
                    {
                        logger.InfoFormat("{0} : {1}", err.PropertyName, err.ErrorMessage);
                    }
                }

                logger.Error(dbErr.Message, dbErr);
                ViewBag.Message = dbErr.Message;
                return View(data);
            }
            catch(Exception ex)
            {
                logger.Error(ex.Message, ex);
				ViewBag.Message = "服务器忙.请稍候在尝试执行本操作。";
                return View(data);
            }
        }


        //
        // GET: /DocumentType/Delete/5

        public ActionResult Delete(string id, string returnQueryString)
        {
            DocumentType data = null;

            using (MyDocumentContext context = new MyDocumentContext())
            {
                data = context.DocumentTypes.Find(id);
            }

            if (data == null)
            {
                return HttpNotFound();
            }

			// 设置返回的 RouteValueDictionary
            ViewBag.ReturnQueryRouteValue = ReturnQueryRouteValueBuilder.GetReturnQueryRouteValue(returnQueryString);

            return View(data);
        }



        //
        // POST: /DocumentType/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id, string returnQueryString)
        {
			DocumentType data = null;

			try
            {
                using (MyDocumentContext context = new MyDocumentContext())
                {
                    data = context.DocumentTypes.Find(id);

                    if (data == null)
                    {
                        return HttpNotFound();
                    }

                    context.DocumentTypes.Remove(data);

                    context.SaveChanges();
                }


                return RedirectToAction(
                        "Index",
                        ReturnQueryRouteValueBuilder.GetReturnQueryRouteValue(returnQueryString));
            }
            catch(Exception ex)
            {
                logger.Error(ex.Message, ex);
                ViewBag.Message = "服务器忙.请稍候在尝试执行本操作。";
                return View(data);
            }
        }






        private string SaveLogoFile(HttpPostedFileBase logoFile)
        {

            // 取得上传的文件名.
            string uploadFileName = System.IO.Path.GetFileName(logoFile.FileName);

            var uploadDay = DateTime.Today;

            string webPath = String.Format("~/upload/Logo/{0:yyyyMMdd}", uploadDay);
            string path = Server.MapPath(webPath);
            if (!System.IO.Directory.Exists(path))
            {
                // 目录不存在，则创建.
                System.IO.Directory.CreateDirectory(path);
            }

            string fileName = uploadFileName;
            string filePhysicalPath = String.Format(@"{0}\{1}", path, fileName);

            if (System.IO.File.Exists(filePhysicalPath) || Regex.IsMatch(fileName, @"[\u4e00-\u9fa5]"))
            {
                // 如果文件名已存在，或者包含中文汉字，那么随机处理.
                // 取得 扩展名...
                string ext = uploadFileName.Substring(uploadFileName.LastIndexOf("."));
                fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ext;
                filePhysicalPath = String.Format(@"{0}\{1}", path, fileName);
            }
            logoFile.SaveAs(filePhysicalPath);

            return String.Format("{0:yyyyMMdd}/{1}", uploadDay, fileName);
        }


    }
}
