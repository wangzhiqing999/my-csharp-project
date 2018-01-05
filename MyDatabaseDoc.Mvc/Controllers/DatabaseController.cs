using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MyDatabaseDoc.Model;
using MyDatabaseDoc.Service;

namespace MyDatabaseDoc.Mvc.Controllers
{
    public class DatabaseController : Controller
    {

        private IDatabaseReader databaseReader;


        public DatabaseController(IDatabaseReader databaseReader)
        {
            this.databaseReader = databaseReader;
        }


        // GET: Database
        public ActionResult Index()
        {
            List<Table> tableList = this.databaseReader.GetTableList();
            return View(model: tableList);
        }


        public ActionResult Details(string id)
        {
            List<Column> columnList = this.databaseReader.GetColumnList(id);
            return View(model: columnList);
        }
    }
}