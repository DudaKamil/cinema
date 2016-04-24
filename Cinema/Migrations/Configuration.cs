using System.Collections.Generic;
using System.Data.Entity.Migrations;
using Cinema.DAL;
using Cinema.Models;

namespace Cinema.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<CinemaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CinemaContext context)
        {
            var users = new List<User>
            {
                new User {Login = "user", Password = "user", Name = "User_name", Email = "user@exmaple.com"},
                new User {Login = "admin", Password = "admin", Name = "Admin_name", Email = "admin@exmaple.com"}
            };

            users.ForEach(user => context.Users.AddOrUpdate(p => p.Email, user));
            context.SaveChanges();
        }
    }
}