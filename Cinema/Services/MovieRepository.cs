using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using Cinema.DAL;
using Cinema.Models;

namespace Cinema.Services
{
    public class MovieRepository
    {
        private CinemaContext db = new CinemaContext();

        public List<Movie> GetMovieList()
        {
            return db.Movies.ToList();
        }

        public string GetMovieName(int id)
        {
            Movie movie = db.Movies.FirstOrDefault(u => u.MovieID == id);
            if (movie == null)
            {
                return "errorę";
            }
            return movie.Title;
        }

    }
}