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
            AutomaticMigrationsEnabled = true;
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
                    Title = "Movie 1 Title",
                    Genre = "Movie 1 Genre",
                    Description = "Movie 1 Description",
                    Length = 120
                },
                new Movie
                {
                    Title = "Movie 2 Title",
                    Genre = "Movie 2 Genre",
                    Description = "Movie 2 Description",
                    Length = 120
                }
            };

            movies.ForEach(movie => context.Movies.AddOrUpdate(movie));
            context.SaveChanges();
        }
    }
}