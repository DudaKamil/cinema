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
        private readonly UserRepository _userRepo;

        public AccountController()
        {
            _userRepo = new UserRepository(new CinemaContext());
        }

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
                var user = new User();
                {
                    user.Login = loginModel.Login;
                    user.Password = loginModel.Password;
                }

                if (_userRepo.IsValidUser(user))
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
                if (!_userRepo.IsLoginFree(registerModel.Login) || !_userRepo.IsEmailFree(registerModel.Email))
                {
                    if (!_userRepo.IsLoginFree(registerModel.Login))
                        ModelState.AddModelError("", "Login jest już używany.");
                    if (!_userRepo.IsEmailFree(registerModel.Email))
                        ModelState.AddModelError("", "Email jest już używany.");
                    return View(registerModel);
                }

                var user = new User();
                {
                    user.Login = registerModel.Login;
                    user.Password = _userRepo.EncodePassword(registerModel.Password);
                    user.Email = registerModel.Email;
                    user.Name = registerModel.Name;
                }

                _userRepo.Add(user);

                return RedirectToAction("Login", "Account");
            }
            return View(registerModel);
        }
    }
}