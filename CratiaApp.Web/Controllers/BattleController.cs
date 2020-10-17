using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CratiaApp.Web.Controllers
{
    public class BattleController : Controller
    {
        // GET: Battle

        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        public ActionResult AddBattle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditBattle()
        {
            return View();
        }
    }
}