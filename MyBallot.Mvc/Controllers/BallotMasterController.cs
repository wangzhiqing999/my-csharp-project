using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using MyBallot.Model;
using MyBallot.ServiceImpl;



namespace MyBallot.Mvc.Controllers
{
    public class BallotMasterController : Controller
    {



        //
        // GET: /BallotMaster/

        public ActionResult Index()
        {
            return View();
        }







        private DefaultBallotMasterService ballotMasterService = new DefaultBallotMasterService();



        public ActionResult Detail(string id)
        {
            BallotMaster data = ballotMasterService.GetActiveBallotMaster(id);

            return PartialView(model: data);
        }



    }
}
