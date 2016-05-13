using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Cinema.DAL;
using Cinema.Models;

namespace Cinema.Controllers
{
    public class ApplicationController : Controller
    {

        private CinemaContext db = new CinemaContext();

        [Authorize]
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

        [Authorize]
        public ActionResult BuyTicket(int? movieId)
        {
            if (movieId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(movieId);
            if (movie == null)
            {
                return HttpNotFound();
            }
            BuyTicketModel buyTicketModel = new BuyTicketModel();
            {
                buyTicketModel.Movie = movie;
                //tutaj czary
            }
            return View(buyTicketModel);
        }
        
    }
}