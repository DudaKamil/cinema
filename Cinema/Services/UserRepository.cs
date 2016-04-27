using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using Cinema.DAL;
using Cinema.Models;

namespace Cinema.Services
{
    public class UserRepository
    {
        private CinemaContext db = new CinemaContext();

        public User GetByLoginAndPassword(User user)
        {
            User userData = db.Users.FirstOrDefault(u => u.Login == user.Login);
            if(userData != null && Crypto.VerifyHashedPassword(userData.Password, user.Password))
                    return userData;
            return null;
        }

        public bool IsLoginFree(string login)
        {
            if (db.Users.FirstOrDefault(u => u.Login == login) == null)
                return true;
            return false;
        }

        public bool IsEmailFree(string email)
        {
            if (db.Users.FirstOrDefault(u => u.Email == email) == null)
                return true;
            return false;
        }

        public string EncodePassword(string password)
        {
            return Crypto.HashPassword(password);
        }


    }
}