using System.Net;
using System.Web.Mvc;
using Cinema.DAL;
using Cinema.Models;
using Cinema.Services;

namespace Cinema.Controllers
{
    [Authorize(Users = "admin")]
    public class AdminController : Controller
    {
        private readonly MovieRepository _movieRepository;
        private readonly OrderRepository _orderRepository;
        private readonly SeanceRepository _seanceRepository;
        private readonly UserRepository _userRepository;
        private readonly TicketPriceRepository _ticketPriceRepository;

        public AdminController()
        {
            _userRepository = new UserRepository(new CinemaContext());
            _movieRepository = new MovieRepository(new CinemaContext());
            _seanceRepository = new SeanceRepository(new CinemaContext());
            _orderRepository = new OrderRepository(new CinemaContext());
            _ticketPriceRepository = new TicketPriceRepository(new CinemaContext());
        }

        public ActionResult AdminPanel()
        {
            return View();
        }


        // GET: Users
        public ActionResult UserOverview()
        {
            return View(_userRepository.GetAllUsers());
        }

        // GET: Users/Details/5
        public ActionResult UserDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = _userRepository.GetUserById(id.Value);

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
                var user = new User();
                {
                    user.Login = registerModel.Login;
                    user.Password = registerModel.Password;
                    user.Email = registerModel.Email;
                    user.Name = registerModel.Name;
                }

                _userRepository.Add(user);
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

            var user = _userRepository.GetUserById(id.Value);
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
                _userRepository.EditUser(user);
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

            var user = _userRepository.GetUserById(id.Value);
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
            _userRepository.DeleteById(id);
            return RedirectToAction("UserOverview");
        }

        public ActionResult MovieOverview()
        {
            return View(_movieRepository.GetMovieList());
        }

        public ActionResult MovieDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var movie = _movieRepository.GetMovie(id.Value);
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
                var movie = new Movie();
                {
                    movie.Title = movieModel.Title;
                    movie.Length = movieModel.Length;
                    movie.Genre = movieModel.Genre;
                    movie.ImageURL = movieModel.ImageURL;
                    movie.Description = movieModel.Description;
                }

                _movieRepository.Add(movie);
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
            var movie = _movieRepository.GetMovie(id.Value);
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
                _movieRepository.EditMovie(movie);
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

            var movie = _movieRepository.GetMovie(id.Value);
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
            _movieRepository.DeleteMovieById(id);
            return RedirectToAction("MovieOverview");
        }

        public ActionResult SeanceOverview()
        {
            return View(_seanceRepository.GetAllSeances());
        }

        public ActionResult SeanceDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var seance = _seanceRepository.GetSeance(id.Value);
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
                var seance = new Seance();
                {
                    seance.MovieID = seanceModel.MovieID;
                    seance.ShowDate = seanceModel.ShowDate;
                    seance.Type = seanceModel.Type;
                }

                _seanceRepository.Add(seance);
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

            var seance = _seanceRepository.GetSeance(id.Value);
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
                _seanceRepository.EditSeance(seance);
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

            var seance = _seanceRepository.GetSeance(id.Value);
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
            _seanceRepository.DeleteById(id);
            return RedirectToAction("SeanceOverview");
        }

        public ActionResult OrderOverview()
        {
            return View(_orderRepository.GetAllOrders());
        }

        public ActionResult PricesEdit(int? id)
        {

            var ticketPrices = _ticketPriceRepository.GetPrices(1);
            if (ticketPrices == null)
            {
                return HttpNotFound();
            }
            return View(ticketPrices);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PricesEdit([Bind(Include = "Id,reduced2D,reduced3D,normal2D,normal3D")] TicketPrice ticketPrice)
        {
            if (ModelState.IsValid)
            {
                _ticketPriceRepository.EditPrice(ticketPrice);
                return RedirectToAction("PricesEdit");
            }
            return View(ticketPrice);
        }
    }
}