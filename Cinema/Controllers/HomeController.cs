using Cinema.Services;
using Cinema.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Net;
using Cinema.DAL;

namespace Cinema.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieRepository _movieRepository = new MovieRepository(new CinemaContext());
        // GET: Home
        public ActionResult Index()
        {

            List<int> repeat = new List<int>();
            List<Movie> movieList = new List<Movie>();
            int random;
            Random r = new Random();
            for (int i = 1; i <= 7; i++)
            {
                random = r.Next(19)+1;
                if (repeat.Contains(random))
                {
                    while (!repeat.Contains(random))
                    {
                        random = r.Next(20);
                    }
                }
                Movie move = _movieRepository.GetMovie(random);
                repeat.Add(random);
                movieList.Add(move);
            }
            return View(movieList);
        }
    }
}