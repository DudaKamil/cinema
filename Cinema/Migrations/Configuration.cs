using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
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
                    ImageURL = "https://placehold.it/350x150",
                    Length = 120
                },
                new Movie
                {
                    Title = "Movie 2 Title",
                    Genre = "Movie 2 Genre",
                    Description = "Movie 2 Description",
                    ImageURL = "https://placehold.it/350x150",
                    Length = 120
                }
            };

            movies.ForEach(movie => context.Movies.AddOrUpdate(movie));
            context.SaveChanges();

            var seances = new List<Seance>
            {
                new Seance
                {
                    MovieID = movies.Single(m => m.Title == "Movie 1 Title").MovieID,
                    Type = "standard",
                    ShowDate = DateTime.Today.AddDays(14).AddHours(1)
                },
                new Seance
                {
                    MovieID = movies.Single(m => m.Title == "Movie 1 Title").MovieID,
                    Type = "standard",
                    ShowDate = DateTime.Today.AddDays(14).AddHours(2)
                },
                new Seance
                {
                    MovieID = movies.Single(m => m.Title == "Movie 1 Title").MovieID,
                    Type = "standard",
                    ShowDate = DateTime.Today.AddDays(14).AddHours(3)
                }
            };

            seances.ForEach(seance => context.Seances.AddOrUpdate(seance));
            context.SaveChanges();
        }
    }
}