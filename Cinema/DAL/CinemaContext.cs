using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Cinema.Models;

namespace Cinema.DAL
{
    public class CinemaContext : DbContext
    {
        public CinemaContext() : base("CinemaContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}