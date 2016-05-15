using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
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

        public void wtf()
        {
            
        }

    }
}