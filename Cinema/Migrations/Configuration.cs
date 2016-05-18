using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Helpers;
using Cinema.DAL;
using Cinema.Models;
using System.Collections;

namespace Cinema.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<CinemaContext>
    {
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
                    Type = "2D",
                    ShowDate = DateTime.Today.AddDays(14).AddHours(1)
                },
                new Seance
                {
                    MovieID = movies.Single(m => m.Title == "Movie 1 Title").MovieID,
                    Type = "3D",
                    ShowDate = DateTime.Today.AddDays(14).AddHours(2)
                },
                new Seance
                {
                    MovieID = movies.Single(m => m.Title == "Movie 1 Title").MovieID,
                    Type = "2D",
                    ShowDate = DateTime.Today.AddDays(14).AddHours(3)
                }
            };

            seances.ForEach(seance => context.Seances.AddOrUpdate(seance));
            context.SaveChanges();

            var orderes = new List<Order>
            {
                new Order
                {
                    SeanceID = 1,
                    UserID = 1,
                    ReducedTicket = 2,
                    NormalTicket = 2,
                    TicketCode = "1234567",
                    OrderDate = DateTime.Today.AddDays(-3).AddHours(-4)
                },
                new Order
                {
                    SeanceID = 1,
                    UserID = 1,
                    ReducedTicket = 4,
                    NormalTicket = 4,
                    TicketCode = "123456",
                    OrderDate = DateTime.Today.AddDays(-3).AddHours(-4)
                }
            };
            orderes.ForEach(order => context.Orders.AddOrUpdate(order));
            context.SaveChanges();

            var ticketPrices = new List<TicketPrice>
            {
                new TicketPrice
                {
                    Id = 1,
                    reduced2D = 10,
                    reduced3D = 16,
                    normal2D = 15,
                    normal3D = 20
                }
            };

            ticketPrices.ForEach(ticketPrice => context.TicketPrices.AddOrUpdate(ticketPrice));
            context.SaveChanges();
        }
    }
}