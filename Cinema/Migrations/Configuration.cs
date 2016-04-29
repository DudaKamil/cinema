using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Web.Helpers;
using Cinema.DAL;
using Cinema.Models;

namespace Cinema.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<CinemaContext>
    {
        private CinemaContext cinemaContext = new CinemaContext();

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CinemaContext context)
        {
            var users = new List<User>
            {
                new User
                {
                    Login = "user",
                    Password = Crypto.HashPassword("user"),
                    Name = "User_name",
                    Email = "user@exmaple.com"
                },
                new User
                {
                    Login = "admin",
                    Password = Crypto.HashPassword("admin"),
                    Name = "Admin_name",
                    Email = "admin@exmaple.com"
                }
            };

            users.ForEach(user => context.Users.AddOrUpdate(p => p.Email, user));
            context.SaveChanges();

            var movies = new List<Movie>
            {
                new Movie
                {
                    Title = "Movie Title",
                    Genre = "Movie Genre",
                    Description = "Movie Description",
                    Length = 120
                }
            };

            movies.ForEach(movie => context.Movies.AddOrUpdate(movie));
            context.SaveChanges();
        }
    }
}