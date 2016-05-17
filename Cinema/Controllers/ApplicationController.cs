﻿using System;
using System.Net;
using System.Web.Mvc;
using Cinema.DAL;
using Cinema.Models;
using Cinema.Services;

namespace Cinema.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly MovieRepository _movieRepository;
        private readonly OrderRepository _orderRepository;
        private readonly SeanceRepository _seanceRepository;
        private readonly UserRepository _userRepository;

        public ApplicationController()
        {
            _movieRepository = new MovieRepository(new CinemaContext());
            _orderRepository = new OrderRepository(new CinemaContext());
            _seanceRepository = new SeanceRepository(new CinemaContext());
            _userRepository = new UserRepository(new CinemaContext());
        }

        public ActionResult Repertoire()
        {
            return View(_movieRepository.GetMovieList());
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

            var notNullableId = id.Value;
            var movie = _movieRepository.GetMovie(notNullableId);
            if (movie == null)
            {
                return HttpNotFound();
            }

            var movieDetailsModel = new MovieDetailsModel
            {
                Title = movie.Title,
                Genre = movie.Genre,
                Length = movie.Length,
                ImageURL = movie.ImageURL,
                Description = movie.Description,
                SeancesList = _seanceRepository.GetSeancesList(id)
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
            return View(_seanceRepository.GetSeancesList(id));
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
                if (buyTicketModel.ReducedTicket >= 0 && buyTicketModel.NormalTicket >= 0 &&
                    buyTicketModel.ReducedTicket + buyTicketModel.NormalTicket > 0)
                {
                    var order = new Order
                    {
                        SeanceID = (int) TempData["SeanceID"],
                        UserID = _userRepository.GetUser(HttpContext.User.Identity.Name).UserID,
                        NormalTicket = buyTicketModel.NormalTicket,
                        ReducedTicket = buyTicketModel.ReducedTicket,
                        TicketCode = Guid.NewGuid().ToString(),
                        OrderDate = DateTime.Now
                    };
                    _orderRepository.Add(order);
                    return RedirectToAction("OrderSummary");
                }
                ModelState.AddModelError("", "Musisz kupić przynajmniej jeden bilet.");
            }
            return View(buyTicketModel);
        }

        [Authorize]
        public ActionResult OrderSummary()
        {
            return
                View(_orderRepository.GetUserOrdersList(_userRepository.GetUser(HttpContext.User.Identity.Name).UserID));
        }


        [Authorize]
        public ActionResult OrderDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var order = _orderRepository.GetOrder(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            var seance = _seanceRepository.GetSeance(order.SeanceID);
            var movie = _movieRepository.GetMovie(seance.MovieID);
            var buyTicket = new BuyTicketModel();
            var orderDetailsModel = new OrderDetailsModel
            {
                OrderID = id,
                Title = movie.Title,
                Genre = movie.Genre,
                Length = movie.Length,
                ImageURL = movie.ImageURL,
                Description = movie.Description,
                ShowDate = seance.ShowDate,
                Type = seance.Type,
                OrderDate = order.OrderDate,
                NormalTicket = order.NormalTicket,
                ReducedTicket = order.ReducedTicket,
                Cost = buyTicket.GetTicketsCost(order.NormalTicket, order.ReducedTicket, seance.Type),
                TicketCode = order.TicketCode
            };
            return View(orderDetailsModel);
        }

        public ActionResult OrderDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var order = _orderRepository.GetOrder(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        [HttpPost, ActionName("OrderDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult OrderDeleteConfirmed(int id)
        {
            _orderRepository.Remove(id);
            return RedirectToAction("OrderSummary");
        }
    }
}