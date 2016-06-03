using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Helpers;
using Cinema.DAL;
using Cinema.Models;
using System.Collections;

namespace Cinema.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<CinemaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CinemaContext context)
        {
            var users = new List<User>
            {
                new User
                {
                    Login = "user",
                    Password = Crypto.HashPassword("user"),
                    Name = "User_name",
                    Email = "user@exmaple.com"
                },
                new User
                {
                    Login = "admin",
                    Password = Crypto.HashPassword("admin"),
                    Name = "Admin_name",
                    Email = "admin@exmaple.com"
                }
            };

            users.ForEach(user => context.Users.AddOrUpdate(p => p.Email, user));
            context.SaveChanges();

            var movies = new List<Movie>
            {
                new Movie
                {
                    Title = "Plan Maggie",
                    Genre = "Komedia",
                    Description = "Plany Maggie o samotnym macierzy�stwie spe�zaj� na niczym, kiedy zakochuje si� w Johnie, niszcz�c jego ma��e�stwo. ",
                    ImageURL = "http://media1.woopic.com/93/f/200x250/q/85/fd/p/cinemovies%7C1d6%7C305%7C3e69a4522b6c2d5674df4e9fdd/maggie-a-un-plan%7Cmovies-226326-1.jpg",
                    Length = 120
                },
                new Movie
                {
                    Title = "Ben-Hur",
                    Genre = "Historyczny",
                    Description = "Mylnie oskar�ony ksi��� do�wiadcza lat niewoli, by zem�ci� si� na swoim najlepszym przyjacielu, kt�ry go zdradzi�.",
                    ImageURL = "http://www.fullmoviestoday.com/wp-content/uploads/2016/01/Ben-Hur-2016-Full-Movie-Watch-Online.jpg",
                    Length = 120
                },
                new Movie
                {
                    Title = "Agent i P�",
                    Genre = "Komedia",
                    Description = "Po odnowieniu kontaktu ze starym znajomym przez Facebooka ksi�gowy zostaje zwerbowany do mi�dzynarodowego wywiadu.",
                    ImageURL = "http://www.fullmoviestoday.com/wp-content/uploads/2016/02/Central-Intelligence-2016-Movie-Watch-Online.jpg",
                    Length = 120
                },
                new Movie
                {
                    Title = "Tarzan: Legenda",
                    Genre = "Przygodowy",
                    Description = "Tarzan powraca do Kongo, aby stawi� czo�o kapitanowi Romowi.",
                    ImageURL = "http://www.fullmoviestoday.com/wp-content/uploads/2016/01/The-Legend-of-Tarzan-2016-Full-Movie-Online.jpg",
                    Length = 120
                },
                new Movie
                {
                    Title = "Bardzo fajny gigant",
                    Genre = "Familijny",
                    Description = "Porywaj�ca opowie�� o ma�ej dziewczynce i tajemniczym Olbrzymie, kt�ry odkrywa przed ni� cuda i sekrety magicznej krainy.",
                    ImageURL = "http://photos.elcinema.com/123910498/3e2747fc649a0f515cde701d39db413f_123910498_152.jpg?AWSAccessKeyId=AKIAIE6P6O6F64KPS3OQ&Expires=1973203200&Signature=%2FSxxM42u3kcOl%2B%2FKQ1vT%2BW7OEWU%3D",
                    Length = 120
                },
                new Movie
                {
                    Title = "Zak�adnik z Wall Street",
                    Genre = "Dramat",
                    Description = "Money Monster to popularny program telewizyjny, kt�rego gwiazda, Lee Gates (George Clooney), zwany guru Wall Street, doradza widzom, jak i w co inwestowa� pieni�dze. Kiedy s�uchaj�cy jego finansowych wskaz�wek Kyle Budwell (Jack O'Connell) traci wszystkie oszcz�dno�ci, terroryzuje ekip� show i na planie, podczas programu na �ywo, grozi Lee �mierci�, je�li ten nie sprawi, �e akcje, w kt�re zainwestowa�, nie p�jd� do g�ry w ci�gu doby. Publiczno�� telewizyjna zamiera w przera�eniu, ogl�dalno�� show ro�nie w rekordowym tempie. Ile warte jest �ycie cz�owieka? ",
                    ImageURL = "http://erenguldas.com/portfolyo/izmovie/assets/img/coming-soon-1.jpg",
                    Length = 120
                },
                new Movie
                {
                    Title = "S�siedzi 2",
                    Genre = "Komedia",
                    Description = "Kiedy do domu obok wprowadza si� stowarzyszenie studentek, jeszcze gorsze od poprzedniego bractwa, Mac i Kelly prosz� o pomoc by�ego s�siada - Teddy'ego.",
                    ImageURL = "http://photos.elcinema.com/123928009/8ee7cb3de8ecd67b3129a3fda3d151a7_123928009_152.jpg?AWSAccessKeyId=AKIAIE6P6O6F64KPS3OQ&Expires=1973203200&Signature=KKWkeO%2BAYNuCEo%2FkzWYaDl7dJnY%3D",
                    Length = 120
                },
                new Movie
                {
                    Title = "M�ody Mesjasz",
                    Genre = "Biblijny",
                    Description = "Opowie�� o niezwyk�ych wydarzeniach w �yciu siedmioletniego Jezusa, kt�re ka�� Mu zada� sobie pytanie: kim jestem?",
                    ImageURL = "http://photos.elcinema.com/123886549/8738b72223b55107abfef1d892e5c699_123886549_152.jpg?AWSAccessKeyId=AKIAIE6P6O6F64KPS3OQ&Expires=1973203200&Signature=O8UtJOkb2knhv46Vw0DYqdsBg40%3D",
                    Length = 120
                },
                new Movie
                {
                    Title = "Ksi�ga D�ungli",
                    Genre = "Przygodowy",
                    Description = "Wilcza rodzina przygarnia ch�opca, kt�remu nadaj� imi� Mowgli. Gdy ten podrasta, zaprzyja�nia si� z czarn� panter� Bagheer� i nied�wiedziem Baloo. ",
                    ImageURL = "http://media.santabanta.com/gallery/Hollywood%20Movies/The%20Jungle%20Book/The-Jungle-Book-1-a_th.jpg",
                    Length = 120
                },
                new Movie
                {
                    Title = "Pi�ta fala",
                    Genre = "Thriller",
                    Description = "Po inwazji kosmit�w nastolatka poszukuje zaginionego brata, kt�ry prawdopodobnie zosta� porwany przez obcych. ",
                    ImageURL = "http://media.santabanta.com/gallery/Hollywood%20Movies/The%205th%20Wave/The-5th-Wave-1-a_th.jpg",
                    Length = 120
                },
                new Movie
                {
                    Title = "R�wni go�cie",
                    Genre = "Komedia",
                    Description = "Prywatny detektyw Holland March (Ryan Gosling) i grubosk�rny mi�niak do wynaj�cia Jackson Healy (Russell Crowe) nie pa�aj� do siebie sympati�. Zostaj� jednak wynaj�ci do rozwik�ania tej samej sprawy zaginionej dziewczyny.",
                    ImageURL = "http://media3.woopic.com/93/f/200x250/q/85/fd/p/cinemovies%7Cca6%7C39b%7C0d18383aaa40a4b1dfb1622873/the-nice-guys%7Cmovies-229665-1.jpg",
                    Length = 120
                },
                new Movie
                {
                    Title = "Kapitan Ameryka: Wojna bohater�w",
                    Genre = "Sci-Fi",
                    Description = "Ustawa zmuszaj�ca superbohater�w do rejestracji i ujawnienia ich to�samo�ci doprowadza do konfliktu pomi�dzy zwolennikami a przeciwnikami nowego prawa.  ",
                    ImageURL = "http://movierulez.me/wp-content/uploads/2016/05/Captain-America-Civil-War-2016-Full-Movie-Watch-Online.jpg",
                    Length = 120
                }


            };

            movies.ForEach(movie => context.Movies.AddOrUpdate(movie));
            context.SaveChanges();

            var seances = new List<Seance>
            {
                     new Seance
                {
                    MovieID = movies.Single(m => m.Title == "Plan Maggie").MovieID,
                    Type = "2D",
                    ShowDate = DateTime.Today.AddDays(0).AddHours(2)
                },

                           new Seance
                {
                    MovieID = movies.Single(m => m.Title == "Plan Maggie").MovieID,
                    Type = "3D",
                    ShowDate = DateTime.Today.AddDays(0).AddHours(6)
                },


                new Seance
                {
                    MovieID = movies.Single(m => m.Title == "Plan Maggie").MovieID,
                    Type = "2D",
                    ShowDate = DateTime.Today.AddDays(2).AddHours(1)
                },

                 new Seance
                {
                    MovieID = movies.Single(m => m.Title == "Plan Maggie").MovieID,
                    Type = "3D",
                    ShowDate = DateTime.Today.AddDays(2).AddHours(3)
                },

                      new Seance
                {
                    MovieID = movies.Single(m => m.Title == "Plan Maggie").MovieID,
                    Type = "3D",
                    ShowDate = DateTime.Today.AddDays(3).AddHours(6)
                },

         
                new Seance
                {
                    MovieID = movies.Single(m => m.Title == "Pi�ta fala").MovieID,
                    Type = "3D",
                    ShowDate = DateTime.Today.AddDays(4).AddHours(2)
                },

                new Seance
                {
                    MovieID = movies.Single(m => m.Title == "Pi�ta fala").MovieID,
                    Type = "2D",
                    ShowDate = DateTime.Today.AddDays(4).AddHours(4)
                },

                new Seance
                {
                    MovieID = movies.Single(m => m.Title == "Ksi�ga D�ungli").MovieID,
                    Type = "2D",
                    ShowDate = DateTime.Today.AddDays(2).AddHours(3)
                },

                 new Seance
                {
                    MovieID = movies.Single(m => m.Title == "Ksi�ga D�ungli").MovieID,
                    Type = "2D",
                    ShowDate = DateTime.Today.AddDays(2).AddHours(6)
                },

                 new Seance
                {
                    MovieID = movies.Single(m => m.Title == "M�ody Mesjasz").MovieID,
                    Type = "2D",
                    ShowDate = DateTime.Today.AddDays(3).AddHours(3)
                },

                 new Seance
                {
                    MovieID = movies.Single(m => m.Title == "M�ody Mesjasz").MovieID,
                    Type = "2D",
                    ShowDate = DateTime.Today.AddDays(3).AddHours(5)
                },

                  new Seance
                {
                    MovieID = movies.Single(m => m.Title == "S�siedzi 2").MovieID,
                    Type = "2D",
                    ShowDate = DateTime.Today.AddDays(1).AddHours(2)
                },

                   new Seance
                {
                    MovieID = movies.Single(m => m.Title == "S�siedzi 2").MovieID,
                    Type = "2D",
                    ShowDate = DateTime.Today.AddDays(2).AddHours(0.5)
                },

                   new Seance
                {
                    MovieID = movies.Single(m => m.Title == "Zak�adnik z Wall Street").MovieID,
                    Type = "2D",
                    ShowDate = DateTime.Today.AddDays(3).AddHours(2)
                },

                   new Seance
                {
                    MovieID = movies.Single(m => m.Title == "Zak�adnik z Wall Street").MovieID,
                    Type = "2D",
                    ShowDate = DateTime.Today.AddDays(0).AddHours(1)
                },

                    new Seance
                {
                    MovieID = movies.Single(m => m.Title == "Bardzo fajny gigant").MovieID,
                    Type = "2D",
                    ShowDate = DateTime.Today.AddDays(1).AddHours(3)
                },

                     new Seance
                {
                    MovieID = movies.Single(m => m.Title == "Bardzo fajny gigant").MovieID,
                    Type = "2D",
                    ShowDate = DateTime.Today.AddDays(4).AddHours(2)
                },

                     new Seance
                {
                    MovieID = movies.Single(m => m.Title == "Tarzan: Legenda").MovieID,
                    Type = "2D",
                    ShowDate = DateTime.Today.AddDays(5).AddHours(2)
                },

                     new Seance
                {
                    MovieID = movies.Single(m => m.Title == "Tarzan: Legenda").MovieID,
                    Type = "2D",
                    ShowDate = DateTime.Today.AddDays(0).AddHours(3)
                },

                      new Seance
                {
                    MovieID = movies.Single(m => m.Title == "Ben-Hur").MovieID,
                    Type = "2D",
                    ShowDate = DateTime.Today.AddDays(1).AddHours(1)
                },

                      new Seance
                {
                    MovieID = movies.Single(m => m.Title == "Ben-Hur").MovieID,
                    Type = "2D",
                    ShowDate = DateTime.Today.AddDays(2).AddHours(5)
                },

                       new Seance
                {
                    MovieID = movies.Single(m => m.Title == "Agent i P�").MovieID,
                    Type = "2D",
                    ShowDate = DateTime.Today.AddDays(4).AddHours(0)
                },

                       new Seance
                {
                    MovieID = movies.Single(m => m.Title == "Agent i P�").MovieID,
                    Type = "3D",
                    ShowDate = DateTime.Today.AddDays(2).AddHours(3)
                },
                         new Seance
                {
                    MovieID = movies.Single(m => m.Title == "R�wni go�cie").MovieID,
                    Type = "2D",
                    ShowDate = DateTime.Today.AddDays(1).AddHours(2)
                },
                           new Seance
                {
                    MovieID = movies.Single(m => m.Title == "Kapitan Ameryka: Wojna bohater�w").MovieID,
                    Type = "2D",
                    ShowDate = DateTime.Today.AddDays(0).AddHours(2)
                },
                             new Seance
                {
                    MovieID = movies.Single(m => m.Title == "Kapitan Ameryka: Wojna bohater�w").MovieID,
                    Type = "3D",
                    ShowDate = DateTime.Today.AddDays(3).AddHours(2)
                }

            };

            seances.ForEach(seance => context.Seances.AddOrUpdate(seance));
            context.SaveChanges();

            var orderes = new List<Order>
            {
                new Order
                {
                    SeanceID = 1,
                    UserID = 1,
                    ReducedTicket = 2,
                    NormalTicket = 2,
                    TicketCode = Guid.NewGuid().ToString(),
                    OrderDate = DateTime.Today.AddDays(-3).AddHours(-4),
                },
                new Order
                {
                    SeanceID = 1,
                    UserID = 1,
                    ReducedTicket = 4,
                    NormalTicket = 4,
                    TicketCode = Guid.NewGuid().ToString(),
                    OrderDate = DateTime.Today.AddDays(-3).AddHours(-4),
                }
            };
            orderes.ForEach(order => context.Orders.AddOrUpdate(order));
            context.SaveChanges();

            var ticketPrices = new List<TicketPrice>
            {
                new TicketPrice
                {
                    Id = 1,
                    reduced2D = 10,
                    reduced3D = 16,
                    normal2D = 15,
                    normal3D = 20
                }
            };

            ticketPrices.ForEach(ticketPrice => context.TicketPrices.AddOrUpdate(ticketPrice));
            context.SaveChanges();
        }
    }
}