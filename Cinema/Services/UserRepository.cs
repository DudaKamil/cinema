using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cinema.DAL;
using Cinema.Models;

namespace Cinema.Services
{
    public class UserRepository
    {
        private CinemaContext db = new CinemaContext();

        public User GetByLoginAndPassword(User user)
        {
            return db.Users.FirstOrDefault(u => u.Login == user.Login && u.Password == user.Password);
        }

        public bool IsLoginFree(string login)
        {
            if (db.Users.FirstOrDefault(u => u.Login == login) == null)
                return true;
            return false;
        }
    }
}