using System.Data.Entity.Migrations;

namespace Cinema.Migrations
{
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movie",
                c => new
                {
                    MovieID = c.Int(false, true),
                    Title = c.String(),
                    Length = c.Int(false),
                    Genre = c.String(),
                    Description = c.String()
                })
                .PrimaryKey(t => t.MovieID);

            CreateTable(
                "dbo.User",
                c => new
                {
                    UserID = c.Int(false, true),
                    Login = c.String(),
                    Password = c.String(),
                    Email = c.String(),
                    Name = c.String()
                })
                .PrimaryKey(t => t.UserID);
        }

        public override void Down()
        {
            DropTable("dbo.User");
            DropTable("dbo.Movie");
        }
    }
}