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

        public bool IsValidUser(User user)
        {
            User userData = db.Users.FirstOrDefault(u => u.Login == user.Login);
            return userData != null && Crypto.VerifyHashedPassword(userData.Password, user.Password);
        }

        public bool IsLoginFree(string login)
        {
            return db.Users.FirstOrDefault(u => u.Login == login) == null;
        }

        public bool IsEmailFree(string email)
        {
            return db.Users.FirstOrDefault(u => u.Email == email) == null;
        }

        public string EncodePassword(string password)
        {
            return Crypto.HashPassword(password);
        }
    }
}