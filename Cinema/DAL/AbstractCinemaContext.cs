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
        public DbSet<Seats> Seats { get; set; }

        public virtual Movie GetMovieById(int id)
        {
            return Movies.FirstOrDefault(u => u.MovieID == id);
        }

        public virtual List<Movie> GetMovies()
        {
            return Movies.ToList();
        }

        public virtual List<Order> GetOrdersByUserId(int id)
        {
            return Orders.Where(order => order.UserID == id).ToList();
        }

        public virtual List<Order> GetAllOrders()
        {
           return Orders.ToList();
        }

        public virtual Order GetOrderById(int id)
        {
            return Orders.FirstOrDefault(order => order.OrderID == id);
        }
    }
}