using System.Linq;
using System.Web.Helpers;
using Cinema.DAL;
using Cinema.Models;

namespace Cinema.Services
{
    public class UserRepository
    {
        private readonly AbstractCinemaContext _cinemaContext;

        public UserRepository(CinemaContext cinemaContext)
        {
            _cinemaContext = cinemaContext;
        }

        public bool IsValidUser(User user)
        {
            var userData = _cinemaContext.Users.FirstOrDefault(u => u.Login == user.Login);
            return userData != null && Crypto.VerifyHashedPassword(userData.Password, user.Password);
        }

        public bool IsLoginFree(string login)
        {
            return _cinemaContext.Users.FirstOrDefault(u => u.Login == login) == null;
        }

        public bool IsEmailFree(string email)
        {
            return _cinemaContext.Users.FirstOrDefault(u => u.Email == email) == null;
        }

        public string EncodePassword(string password)
        {
            return Crypto.HashPassword(password);
        }

        public User GetUser(string login)
        {
            return _cinemaContext.Users.FirstOrDefault(u => u.Login == login);
        }

        public string GetUserName(int id)
        {
            return _cinemaContext.Users.FirstOrDefault(u => u.UserID == id).Name;
        }

        public void Add(User user)
        {
            _cinemaContext.Users.Add(user);
            _cinemaContext.SaveChanges();
        }
    }
}