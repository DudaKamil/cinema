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
            int amountMovies = _movieRepository.GetMovieList().Count;
            List<string> moviesRepeated = new List<string>();
            List<Movie> movieList = new List<Movie>();
            int random;
            Random r = new Random();
            for (int i = 1; i <= 6; i++)
            {
                random = r.Next(amountMovies);
                if (moviesRepeated.Contains(_movieRepository.GetMovieName(random)))
                {
                    while (moviesRepeated.Contains(_movieRepository.GetMovieName(random)))
                    {
                        random = r.Next(amountMovies);
                    }
                }
                Movie move = _movieRepository.GetMovie(random);
                moviesRepeated.Add(_movieRepository.GetMovieName(random));
                movieList.Add(move);
            }
            return View(movieList);
        }
    }
}