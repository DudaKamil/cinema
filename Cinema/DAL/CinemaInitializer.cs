using System.Collections.Generic;
using System.Data.Entity;
using Cinema.Models;

namespace Cinema.DAL
{
    public class CinemaInitializer : DropCreateDatabaseIfModelChanges<CinemaContext>
    {
        protected override void Seed(CinemaContext context)
        {
//            var users = new List<User>
//            {
//                new User {Login = "user", Password = "user", Name = "User_name", Email = "user@exmaple.com"}
//            };
//
//            users.ForEach(user => context.Users.Add(user));
//            context.SaveChanges();
        }
    }
}