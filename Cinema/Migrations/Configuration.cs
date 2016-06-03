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
                    Description = "Plany Maggie o samotnym macierzyñstwie spe³zaj¹ na niczym, kiedy zakochuje siê w Johnie, niszcz¹c jego ma³¿eñstwo. ",
                    ImageURL = "http://media1.woopic.com/93/f/200x250/q/85/fd/p/cinemovies%7C1d6%7C305%7C3e69a4522b6c2d5674df4e9fdd/maggie-a-un-plan%7Cmovies-226326-1.jpg",
                    Length = 120
                },
                new Movie
                {
                    Title = "Ben-Hur",
                    Genre = "Historyczny",
                    Description = "Mylnie oskar¿ony ksi¹¿ê doœwiadcza lat niewoli, by zemœciæ siê na swoim najlepszym przyjacielu, który go zdradzi³.",
                    ImageURL = "http://www.fullmoviestoday.com/wp-content/uploads/2016/01/Ben-Hur-2016-Full-Movie-Watch-Online.jpg",
                    Length = 120
                },
                new Movie
                {
                    Title = "Agent i Pó³",
                    Genre = "Komedia",
                    Description = "Po odnowieniu kontaktu ze starym znajomym przez Facebooka ksiêgowy zostaje zwerbowany do miêdzynarodowego wywiadu.",
                    ImageURL = "http://www.fullmoviestoday.com/wp-content/uploads/2016/02/Central-Intelligence-2016-Movie-Watch-Online.jpg",
                    Length = 120
                },
                new Movie
                {
                    Title = "Tarzan: Legenda",
                    Genre = "Przygodowy",
                    Description = "Tarzan powraca do Kongo, aby stawiæ czo³o kapitanowi Romowi.",
                    ImageURL = "http://www.fullmoviestoday.com/wp-content/uploads/2016/01/The-Legend-of-Tarzan-2016-Full-Movie-Online.jpg",
                    Length = 120
                },
                new Movie
                {
                    Title = "Bardzo fajny gigant",
                    Genre = "Familijny",
                    Description = "Porywaj¹ca opowieœæ o ma³ej dziewczynce i tajemniczym Olbrzymie, który odkrywa przed ni¹ cuda i sekrety magicznej krainy.",
                    ImageURL = "http://photos.elcinema.com/123910498/3e2747fc649a0f515cde701d39db413f_123910498_152.jpg?AWSAccessKeyId=AKIAIE6P6O6F64KPS3OQ&Expires=1973203200&Signature=%2FSxxM42u3kcOl%2B%2FKQ1vT%2BW7OEWU%3D",
                    Length = 120
                },
                new Movie
                {
                    Title = "Zak³adnik z Wall Street",
                    Genre = "Dramat",
                    Description = "Money Monster to popularny program telewizyjny, którego gwiazda, Lee Gates (George Clooney), zwany guru Wall Street, doradza widzom, jak i w co inwestowaæ pieni¹dze. Kiedy s³uchaj¹cy jego finansowych wskazówek Kyle Budwell (Jack O'Connell) traci wszystkie oszczêdnoœci, terroryzuje ekipê show i na planie, podczas programu na ¿ywo, grozi Lee œmierci¹, jeœli ten nie sprawi, ¿e akcje, w które zainwestowa³, nie pójd¹ do góry w ci¹gu doby. Publicznoœæ telewizyjna zamiera w przera¿eniu, ogl¹dalnoœæ show roœnie w rekordowym tempie. Ile warte jest ¿ycie cz³owieka? ",
                    ImageURL = "http://erenguldas.com/portfolyo/izmovie/assets/img/coming-soon-1.jpg",
                    Length = 120
                },
                new Movie
                {
                    Title = "S¹siedzi 2",
                    Genre = "Komedia",
                    Description = "Kiedy do domu obok wprowadza siê stowarzyszenie studentek, jeszcze gorsze od poprzedniego bractwa, Mac i Kelly prosz¹ o pomoc by³ego s¹siada - Teddy'ego.",
                    ImageURL = "http://photos.elcinema.com/123928009/8ee7cb3de8ecd67b3129a3fda3d151a7_123928009_152.jpg?AWSAccessKeyId=AKIAIE6P6O6F64KPS3OQ&Expires=1973203200&Signature=KKWkeO%2BAYNuCEo%2FkzWYaDl7dJnY%3D",
                    Length = 120
                },
                new Movie
                {
                    Title = "M³ody Mesjasz",
                    Genre = "Biblijny",
                    Description = "Opowieœæ o niezwyk³ych wydarzeniach w ¿yciu siedmioletniego Jezusa, które ka¿¹ Mu zadaæ sobie pytanie: kim jestem?",
                    ImageURL = "http://photos.elcinema.com/123886549/8738b72223b55107abfef1d892e5c699_123886549_152.jpg?AWSAccessKeyId=AKIAIE6P6O6F64KPS3OQ&Expires=1973203200&Signature=O8UtJOkb2knhv46Vw0DYqdsBg40%3D",
                    Length = 120
                },
                new Movie
                {
                    Title = "Ksiêga D¿ungli",
                    Genre = "Przygodowy",
                    Description = "Wilcza rodzina przygarnia ch³opca, któremu nadaj¹ imiê Mowgli. Gdy ten podrasta, zaprzyjaŸnia siê z czarn¹ panter¹ Bagheer¹ i niedŸwiedziem Baloo. ",
                    ImageURL = "http://media.santabanta.com/gallery/Hollywood%20Movies/The%20Jungle%20Book/The-Jungle-Book-1-a_th.jpg",
                    Length = 120
                },
                new Movie
                {
                    Title = "Pi¹ta fala",
                    Genre = "Thriller",
                    Description = "Po inwazji kosmitów nastolatka poszukuje zaginionego brata, który prawdopodobnie zosta³ porwany przez obcych. ",
                    ImageURL = "http://media.santabanta.com/gallery/Hollywood%20Movies/The%205th%20Wave/The-5th-Wave-1-a_th.jpg",
                    Length = 120
                },
                new Movie
                {
                    Title = "Równi goœcie",
                    Genre = "Komedia",
                    Description = "Prywatny detektyw Holland March (Ryan Gosling) i gruboskórny miêœniak do wynajêcia Jackson Healy (Russell Crowe) nie pa³aj¹ do siebie sympati¹. Zostaj¹ jednak wynajêci do rozwik³ania tej samej sprawy zaginionej dziewczyny.",
                    ImageURL = "http://media3.woopic.com/93/f/200x250/q/85/fd/p/cinemovies%7Cca6%7C39b%7C0d18383aaa40a4b1dfb1622873/the-nice-guys%7Cmovies-229665-1.jpg",
                    Length = 120
                },
                new Movie
                {
                    Title = "Kapitan Ameryka: Wojna bohaterów",
                    Genre = "Sci-Fi",
                    Description = "Ustawa zmuszaj¹ca superbohaterów do rejestracji i ujawnienia ich to¿samoœci doprowadza do konfliktu pomiêdzy zwolennikami a przeciwnikami nowego prawa.  ",
                    ImageURL = "http://movierulez.me/wp-content/uploads/2016/05/Captain-America-Civil-War-2016-Full-Movie-Watch-Online.jpg",
                    Length = 120
                },


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
                    MovieID = movies.Single(m => m.Title == "Pi¹ta fala").MovieID,
                    Type = "3D",
                    ShowDate = DateTime.Today.AddDays(4).AddHours(2)
                },

                new Seance
                {
                    MovieID = movies.Single(m => m.Title == "Pi¹ta fala").MovieID,
                    Type = "2D",
                    ShowDate = DateTime.Today.AddDays(4).AddHours(4)
                },

                new Seance
                {
                    MovieID = movies.Single(m => m.Title == "Ksiêga D¿ungli").MovieID,
                    Type = "2D",
                    ShowDate = DateTime.Today.AddDays(2).AddHours(3)
                },

                 new Seance
                {
                    MovieID = movies.Single(m => m.Title == "Ksiêga D¿ungli").MovieID,
                    Type = "2D",
                    ShowDate = DateTime.Today.AddDays(2).AddHours(6)
                },

                 new Seance
                {
                    MovieID = movies.Single(m => m.Title == "M³ody Mesjasz").MovieID,
                    Type = "2D",
                    ShowDate = DateTime.Today.AddDays(3).AddHours(3)
                },

                 new Seance
                {
                    MovieID = movies.Single(m => m.Title == "M³ody Mesjasz").MovieID,
                    Type = "2D",
                    ShowDate = DateTime.Today.AddDays(3).AddHours(5)
                },

                  new Seance
                {
                    MovieID = movies.Single(m => m.Title == "S¹siedzi 2").MovieID,
                    Type = "2D",
                    ShowDate = DateTime.Today.AddDays(1).AddHours(2)
                },

                   new Seance
                {
                    MovieID = movies.Single(m => m.Title == "S¹siedzi 2").MovieID,
                    Type = "2D",
                    ShowDate = DateTime.Today.AddDays(2).AddHours(0.5)
                },

                   new Seance
                {
                    MovieID = movies.Single(m => m.Title == "Zak³adnik z Wall Street").MovieID,
                    Type = "2D",
                    ShowDate = DateTime.Today.AddDays(3).AddHours(2)
                },

                   new Seance
                {
                    MovieID = movies.Single(m => m.Title == "Zak³adnik z Wall Street").MovieID,
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
                    MovieID = movies.Single(m => m.Title == "Agent i Pó³").MovieID,
                    Type = "2D",
                    ShowDate = DateTime.Today.AddDays(4).AddHours(0)
                },

                       new Seance
                {
                    MovieID = movies.Single(m => m.Title == "Agent i Pó³").MovieID,
                    Type = "3D",
                    ShowDate = DateTime.Today.AddDays(2).AddHours(3)
                }
                         new Seance
                {
                    MovieID = movies.Single(m => m.Title == "Równi goœcie").MovieID,
                    Type = "2D",
                    ShowDate = DateTime.Today.AddDays(1).AddHours(2)
                },
                           new Seance
                {
                    MovieID = movies.Single(m => m.Title == "Kapitan Ameryka: Wojna bohaterów").MovieID,
                    Type = "2D",
                    ShowDate = DateTime.Today.AddDays(0).AddHours(2)
                },
                             new Seance
                {
                    MovieID = movies.Single(m => m.Title == "Kapitan Ameryka: Wojna bohaterów").MovieID,
                    Type = "3D",
                    ShowDate = DateTime.Today.AddDays(3).AddHours(2)
                },

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