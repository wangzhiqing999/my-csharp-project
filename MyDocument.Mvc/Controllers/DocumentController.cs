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
using MyDocument.Util;

namespace MyDocument.Mvc.Controllers
{


    public class DocumentController : Controller
    {

        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        //
        // GET: /Document/

        public ActionResult Index(
			int? pageNo,
            int? pageSize)
        {
			List<Document>  dataList = null;

			using (MyDocumentContext context = new MyDocumentContext())
            {
                var query =
                    from data in context.Documents
                    select data;



                // 初始化翻页.
                PageInfo pgInfo = new PageInfo(
                    pageSize: pageSize, 
                    pageNo: pageNo, 
                    rowCount: query.Count());

                ViewBag.PageInfo = pgInfo;


				query = query.OrderBy(p => p.DocumentID)
                    .Skip(pgInfo.SkipValue)
                    .Take(pgInfo.PageSize);     

				// 查询数据.
                dataList = query.ToList();
			}

			// 显示画面.
            return View(dataList);
        }



        //
        // GET: /Document/Details/5

        public ActionResult Details(long id, string returnQueryString)
        {
            Document data = null;
            using (MyDocumentContext context = new MyDocumentContext())
            {
                data = context.Documents.Find(id);
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
        // GET: /Document/Create

        public ActionResult Create(string returnQueryString)
        {
            // 设置返回的 RouteValueDictionary
            ViewBag.ReturnQueryRouteValue = ReturnQueryRouteValueBuilder.GetReturnQueryRouteValue(returnQueryString);

            return View();
        }

        //
        // POST: /Document/Create

        [HttpPost]
        public ActionResult Create(Document data, string returnQueryString, HttpPostedFileBase pdfFile, HttpPostedFileBase logoFile)
        {



            if (pdfFile != null && !String.IsNullOrEmpty(pdfFile.FileName))
            {
                // 上传了文件.
                // 取得上传的文件名.
                string uploadFileName = System.IO.Path.GetFileName(pdfFile.FileName);
                if (!UploadFileChecker.CheckPdfFileExt(uploadFileName))
                {
                    ViewBag.Message = "文件仅仅允许上传 PDF 扩展名的文件！";
                    return View(data);
                }

                data.DocumentFileName = SavePdfFile(pdfFile);

                data.DocumentSwfFileName = SaveSwfFile(data.DocumentFileName);
            }

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

                data.DocumentLogo = SaveLogoFile(logoFile);
            }

            try
            {
                if (ModelState.IsValid)
                {
                    // 假如数据检查无误.
                    // 将数据加入结果列表.
                    using (MyDocumentContext context = new MyDocumentContext())
                    {
                        Document oldDocument =
                            context.Documents.Find(data.DocumentID);
                        if (oldDocument != null)
                        {
                            ViewBag.Message = "代码已存在！";
                            return View();
                        }


                        DataRecorder.BeforeInsertOperation(Session, data);
                        context.Documents.Add(data);
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
            catch(Exception ex)
            {
                logger.Error(ex.Message, ex);
				ViewBag.Message = "服务器忙.请稍候在尝试执行本操作。";
                return View(data);
            }
        }




        //
        // GET: /Document/Edit/5

        public ActionResult Edit(long id, string returnQueryString)
        {
            Document data = null;

            using (MyDocumentContext context = new MyDocumentContext())
            {
                data = context.Documents.Find(id);
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
        // POST: /Document/Edit/5

        [HttpPost]
        public ActionResult Edit(Document data, string returnQueryString, HttpPostedFileBase pdfFile, HttpPostedFileBase logoFile)
        {


            if (pdfFile != null && !String.IsNullOrEmpty(pdfFile.FileName))
            {
                // 上传了文件.
                // 取得上传的文件名.
                string uploadFileName = System.IO.Path.GetFileName(pdfFile.FileName);
                if (!UploadFileChecker.CheckPdfFileExt(uploadFileName))
                {
                    ViewBag.Message = "文件仅仅允许上传 PDF 扩展名的文件！";
                    return View(data);
                }

                data.DocumentFileName = SavePdfFile(pdfFile);
                data.DocumentSwfFileName = SaveSwfFile(data.DocumentFileName);
            }

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

                data.DocumentLogo = SaveLogoFile(logoFile);
            }

            try
            {
				if (ModelState.IsValid)
                {
                    // 假如数据检查无误.
                    // 更新数据.

                    using (MyDocumentContext context = new MyDocumentContext())
                    {
                        Document oldDocument =
                            context.Documents.Find(data.DocumentID);
                        if (oldDocument == null)
                        {
                            ViewBag.Message = "数据不存在！";
                            return View(data);
                        }

                        DataRecorder.BeforeUpdateOperation(Session, data);


                        // 先从上下文中的旧实体获取跟踪
                        DbEntityEntry entry = context.Entry(oldDocument);

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
            catch(Exception ex)
            {
                logger.Error(ex.Message, ex);
				ViewBag.Message = "服务器忙.请稍候在尝试执行本操作。";
                return View(data);
            }
        }


        //
        // GET: /Document/Delete/5

        public ActionResult Delete(long id, string returnQueryString)
        {
            Document data = null;

            using (MyDocumentContext context = new MyDocumentContext())
            {
                data = context.Documents.Find(id);
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
        // POST: /Document/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id, string returnQueryString)
        {
			Document data = null;

			try
            {
                using (MyDocumentContext context = new MyDocumentContext())
                {
                    data = context.Documents.Find(id);

                    if (data == null)
                    {
                        return HttpNotFound();
                    }

                    context.Documents.Remove(data);

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





        private string SavePdfFile(HttpPostedFileBase pdfFile)
        {
            // 取得上传的文件名.
            string uploadFileName = System.IO.Path.GetFileName(pdfFile.FileName);

            var uploadDay = DateTime.Today;

            string webPath = String.Format("~/upload/Pdf/{0:yyyyMMdd}", uploadDay);
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
            pdfFile.SaveAs(filePhysicalPath);

            return String.Format("{0:yyyyMMdd}/{1}", uploadDay, fileName);
        }



        private string SaveSwfFile(string pdfFileName)
        {
            var uploadDateTime = DateTime.Now;

            string webPath = String.Format("~/upload/Swf/{0:yyyyMMdd}", uploadDateTime);
            string path = Server.MapPath(webPath);
            if (!System.IO.Directory.Exists(path))
            {
                // 目录不存在，则创建.
                System.IO.Directory.CreateDirectory(path);
            }

            string swfFileName = String.Format("{0:yyyyMMdd}/{0:yyyyMMddHHmmss}.swf", uploadDateTime);


            string pdfFilePhysicalPath = Server.MapPath("~/Upload/Pdf/" + pdfFileName);
            string swfFilePhysicalPath = Server.MapPath("~/Upload/Swf/" + swfFileName);


            // Pdf2Swf
            Pdf2SwfConverter converter = new Pdf2SwfConverter();

            bool result = converter.Pdf2Swf(pdfFilePhysicalPath, swfFilePhysicalPath);


            return swfFileName;
        }


    }
}
