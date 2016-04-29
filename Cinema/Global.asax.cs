using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Cinema.DAL;
using Cinema.Migrations;

namespace Cinema
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CinemaContext, Configuration>());
        }
    }
}