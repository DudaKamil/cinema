using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Cinema.DAL;
using Cinema.Models;
using Cinema.Services;

namespace Cinema.Controllers
{
    public class ApplicationController : Controller
    {

        private CinemaContext db = new CinemaContext();
        private SeanceRepository seanceRepo = new SeanceRepository();

        public ActionResult Repertoire()
        {
            return View(db.Movies.ToList());
        }

        public ActionResult PriceList()
        {
            return View();
        }

        [Authorize]
        public ActionResult SelectSeance(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(seanceRepo.GetSeancesList(id));
        }
        
    }
}