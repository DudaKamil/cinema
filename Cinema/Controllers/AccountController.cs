using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cinema.Models;

namespace Cinema.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
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
                //sprawdź w bazie czy login i hasło jest poprawne
                return RedirectToAction("Index", "Home"); //domyślnie strona główna aplikacji - do zmiany
            }
            ModelState.AddModelError("", "Błędne dane logowania.");
            return View(loginModel);
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
                //zapisz w bazie dane nowego użytkownika
                return RedirectToAction("Login", "Account");
            }
            return View(registerModel);
        }

    }
}