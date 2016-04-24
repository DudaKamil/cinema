using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Cinema.DAL;
using Cinema.Models;
using Cinema.Services;

namespace Cinema.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private CinemaContext db = new CinemaContext();
        private UserRepository userRepo = new UserRepository();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                {
                    user.Login = loginModel.Login;
                    user.Password = loginModel.Password;
                }

                User validatedUser = userRepo.GetByLoginAndPassword(user);

                if (validatedUser != null)
                    FormsAuthentication.RedirectFromLoginPage(loginModel.Login, loginModel.RememberMe);

                ModelState.AddModelError("", "Błędne dane logowania.");
            }
            return View(loginModel);
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                if (!userRepo.IsLoginFree(registerModel.Login) || !userRepo.IsEmailFree(registerModel.Email))
                {
                    if (!userRepo.IsLoginFree(registerModel.Login))
                        ModelState.AddModelError("", "Login jest już używany.");
                    if (!userRepo.IsEmailFree(registerModel.Email))
                        ModelState.AddModelError("", "Email jest już używany.");
                    return View(registerModel);
                }

                User user = new User();
                {
                    user.Login = registerModel.Login;
                    user.Password = registerModel.Password;
                    user.Email = registerModel.Email;
                    user.Name = registerModel.Name;
                }

                db.Users.Add(user);
                db.SaveChanges();

                return RedirectToAction("Login", "Account");
            }
            return View(registerModel);
        }
    }
}