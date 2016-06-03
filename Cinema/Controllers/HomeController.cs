using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Cinema.DAL;
using Cinema.Models;
using Cinema.Services;

namespace Cinema.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieRepository _movieRepository = new MovieRepository(new CinemaContext());
        // GET: Home
        public ActionResult Index()
        {
            var amountMovies = _movieRepository.GetMovieList().Count;
            var moviesRepeated = new List<string>();
            var movieList = new List<Movie>();
            int random;
            var r = new Random();
            for (var i = 1; i <= 6; i++)
            {
                random = r.Next(amountMovies);
                if (moviesRepeated.Contains(_movieRepository.GetMovieName(random)))
                {
                    while (moviesRepeated.Contains(_movieRepository.GetMovieName(random)))
                    {
                        random = r.Next(amountMovies);
                    }
                }
                var move = _movieRepository.GetMovie(random);
                if (move != null)
                {
                    moviesRepeated.Add(_movieRepository.GetMovieName(random));
                    movieList.Add(move);
                }
            }
            return View(movieList);
        }
    }
}