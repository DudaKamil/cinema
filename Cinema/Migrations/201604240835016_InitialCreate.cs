using System.Data.Entity.Migrations;

namespace Cinema.Migrations
{
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
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

            CreateTable(
                "dbo.Movie",
                c => new
                {
                    MovieID = c.Int(false, true),
                    Title = c.String(),
                    Length = c.Int(),
                    Genre = c.String(),
                    Description = c.String(),
                    Poster = c.Byte()
                })
                .PrimaryKey(t => t.MovieID);
        }

        public override void Down()
        {
            DropTable("dbo.User");
            DropTable("dbo.Movie");
        }
    }
}