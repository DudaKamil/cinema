using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Cinema.DAL
{
    public class CinemaContext : AbstractCinemaContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}