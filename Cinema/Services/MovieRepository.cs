using System.Collections.Generic;
using System.Linq;
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
                return "błąd";
            }
            return movie.Title;
        }

        public Movie GetMovie(int id)
        {
            return db.Movies.FirstOrDefault(u => u.MovieID == id);
        }

    }
}