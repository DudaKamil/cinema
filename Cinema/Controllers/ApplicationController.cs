using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.ClientServices.Providers;
using System.Web.Mvc;
using System.Web.Security;
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
        private MovieRepository movieRepo = new MovieRepository();
        private UserRepository userRepo = new UserRepository();
        private OrderRepository orderRepo = new OrderRepository();

        public ActionResult Repertoire()
        {
            return View(db.Movies.ToList());
        }

        public ActionResult PriceList()
        {
            return View();
        }

        public ActionResult MovieDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            MovieDetailsModel movieDetailsModel = new MovieDetailsModel()
            {
                Title = movie.Title,
                Genre = movie.Genre,
                Length = movie.Length,
                ImageURL = movie.ImageURL,
                Description = movie.Description,
                SeancesList = seanceRepo.GetSeancesList(id)               
            };
            return View(movieDetailsModel);
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

        [Authorize]
        public ActionResult BuyTicket(int id)
        {
            TempData["SeanceID"] = id;       
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult BuyTicket(BuyTicketModel buyTicketModel)
        {
            if (ModelState.IsValid)
            {
                Order order = new Order()
                {
                    SeanceID = (int)TempData["SeanceID"],
                    UserID = userRepo.GetUser(HttpContext.User.Identity.Name).UserID,
                    NormalTicket = buyTicketModel.NormalTicket,
                    ReducedTicket = buyTicketModel.ReducedTicket,
                    TicketCode = Membership.GeneratePassword(9,0),
                    OrderDate = DateTime.Now
                };
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("OrderSummary");
            }
            return View(buyTicketModel);
        }

        [Authorize]
        public ActionResult OrderSummary()
        {
            return View(orderRepo.GetUserOrdersList(userRepo.GetUser(HttpContext.User.Identity.Name).UserID));
        }

    }
}