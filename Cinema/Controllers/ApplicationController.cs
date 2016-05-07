using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Cinema.Controllers
{
    [Authorize]
    public class ApplicationController : Controller
    {
        public ActionResult MainMenu()
        {
            return View();
        }

        public ActionResult Repertoire()
        {
            return View();
        }

        public ActionResult PriceList()
        {
            return View();
        }
    }
}