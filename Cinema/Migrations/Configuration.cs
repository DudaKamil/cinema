using System.Collections.Generic;
using System.Data.Entity.Migrations;
using Cinema.DAL;
using Cinema.Models;
using Cinema.Services;

namespace Cinema.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<CinemaContext>
    {
        private UserRepository repository = new UserRepository();

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CinemaContext context)
        {
            var users = new List<User>
            {
                new User {Login = "user", Password = repository.EncodePassword("user"), Name = "User_name", Email = "user@exmaple.com"},
                new User {Login = "admin", Password = repository.EncodePassword("admin"), Name = "Admin_name", Email = "admin@exmaple.com"}
            };

            users.ForEach(user => context.Users.AddOrUpdate(p => p.Email, user));
            context.SaveChanges();
        }
    }
}