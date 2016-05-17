using System.Collections.Generic;
using System.Data.Entity;
using Cinema.DAL;
using Cinema.Models;

namespace Cinema.Services
{
    public class MovieRepository
    {
        private readonly AbstractCinemaContext _cinemaContext;

        public MovieRepository(AbstractCinemaContext cinemaContext)
        {
            _cinemaContext = cinemaContext;
        }

        public List<Movie> GetMovieList()
        {
            return _cinemaContext.GetMovies();
        }

        public string GetMovieName(int id)
        {
            var movie = _cinemaContext.GetMovieById(id);
            if (movie == null)
            {
                return "błąd";
            }
            return movie.Title;
        }

        public Movie GetMovie(int id)
        {
            return _cinemaContext.GetMovieById(id);
        }

        public void Add(Movie movie)
        {
            _cinemaContext.Movies.Add(movie);
            _cinemaContext.SaveChanges();
        }

        public void EditMovie(Movie movie)
        {
            _cinemaContext.Entry(movie).State = EntityState.Modified;
            _cinemaContext.SaveChanges();
        }

        public void DeleteMovieById(int id)
        {
            var movie = _cinemaContext.Movies.Find(id);
            _cinemaContext.Movies.Remove(movie);
            _cinemaContext.SaveChanges();
        }
    }
}