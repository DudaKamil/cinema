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

        public ActionResult AdminPanel()
        {
            return View();
        }


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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserEdit([Bind(Include = "UserID,Login,Password,Email,Name")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.Entry(user).Property(e => e.Password).IsModified = false;
                db.SaveChanges();
                return RedirectToAction("UserOverview");
            }
            return View(user);
        }

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

        // GET: Users/Create
        public ActionResult MovieAdd()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MovieAdd(MovieModel movieModel)
        {
            if (ModelState.IsValid)
            {
                Movie movie = new Movie();
                {
                    movie.Title = movieModel.Title;
                    movie.Length = movieModel.Length;
                    movie.Genre = movieModel.Genre;
                    movie.ImageURL = movieModel.ImageURL;
                    movie.Description = movieModel.Description;
                }

                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("MovieOverview");
            }

            return View(movieModel);
        }

        public ActionResult MovieEdit(int? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MovieEdit([Bind(Include = "MovieID,Title,Length,Genre,ImageURL,Description")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MovieOverview");
            }
            return View(movie);
        }

        public ActionResult MovieDelete(int? id)
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

        [HttpPost, ActionName("MovieDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult MovieDeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("MovieOverview");
        }

        public ActionResult SeanceOverview()
        {
            return View(db.Seances.ToList());
        }

        public ActionResult SeanceDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seance seance = db.Seances.Find(id);
            if (seance == null)
            {
                return HttpNotFound();
            }
            return View(seance);
        }

        public ActionResult SeanceAdd()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SeanceAdd(SeanceModel seanceModel)
        {
            if (ModelState.IsValid)
            {
                Seance seance = new Seance();
                {
                    seance.MovieID = seanceModel.MovieID;
                    seance.ShowDate = seanceModel.ShowDate;
                    seance.Type = seanceModel.Type;
                }

                db.Seances.Add(seance);
                db.SaveChanges();
                return RedirectToAction("MovieOverview");
            }

            return View(seanceModel);
        }

        public ActionResult SeanceEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seance seance = db.Seances.Find(id);
            if (seance == null)
            {
                return HttpNotFound();
            }
            return View(seance);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SeanceEdit([Bind(Include = "SeanceID,MovieID,ShowDate,Type")] Seance seance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("SeanceOverview");
            }
            return View(seance);
        }

        public ActionResult SeanceDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seance seance = db.Seances.Find(id);
            if (seance == null)
            {
                return HttpNotFound();
            }
            return View(seance);
        }

        [HttpPost, ActionName("SeanceDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult SeanceDeleteConfirmed(int id)
        {
            Seance seance = db.Seances.Find(id);
            db.Seances.Remove(seance);
            db.SaveChanges();
            return RedirectToAction("SeanceOverview");
        }

        public ActionResult OrderOverview()
        {
            return View(db.Orders.ToList());
        }

    }
}
