using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Cinema.Models;

namespace Cinema.DAL
{
    public abstract class AbstractCinemaContext : DbContext
    {
        public AbstractCinemaContext() : base("CinemaContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Seance> Seances { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<TicketPrice> TicketPrices { get; set; }

        public virtual Movie GetMovieById(int id)
        {
            return Movies.FirstOrDefault(u => u.MovieID == id);
        }

        public virtual List<Movie> GetMovies()
        {
            return Movies.ToList();
        }
    }
}