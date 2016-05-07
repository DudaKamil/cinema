using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cinema.DAL;
using Cinema.Models;
using Cinema.Services;

namespace Cinema.Controllers
{
    [Authorize(Users = "admin")]
    public class AdminController : Controller
    {
        private CinemaContext db = new CinemaContext();

        // GET: Users
        public ActionResult UserOverview()
        {
            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult UserDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult UserAdd()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserAdd(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {

                User user = new User();
                {
                    user.Login = registerModel.Login;
                    user.Password = registerModel.Password;
                    user.Email = registerModel.Email;
                    user.Name = registerModel.Name;

                }

                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("UserOverview");
            }

            return View(registerModel);
        }

        // GET: Users/Edit/5
        public ActionResult UserEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserEdit([Bind(Include = "UserID,Login,Password,Email,Name")] User user)
        {
            if (ModelState.IsValid)
            {
                //db.Users.Attach(user);
                db.Entry(user).State = EntityState.Modified;
                db.Entry(user).Property(e => e.Password).IsModified = false;
                db.SaveChanges();
                return RedirectToAction("UserOverview");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult UserDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("UserDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult UserDeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("UserOverview");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        public ActionResult MovieOverview()
        {
            return View(db.Movies.ToList());
        }

        public ActionResult MovieDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }
    }
}
