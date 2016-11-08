using System.Data.Entity.Migrations;
using System.Linq;
using ChangeTrackingExample.Entities;

namespace ChangeTrackingExample.Migrations
{
    public class ApplicationDbInitializer : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public ApplicationDbInitializer()
        {
            AutomaticMigrationsEnabled = true;
            // not allowed migration, if data loss is possible
            AutomaticMigrationDataLossAllowed = true;
        }

        // ReSharper disable once RedundantOverriddenMember
        protected override void Seed(ApplicationDbContext context)
        {
            context.Authors.AddOrUpdate(x => x.LastName,
                new Author {LastName = "Glut", FirstName = "Donald F."},
                new Author {LastName = "Foster", FirstName = "Alan Dean"},
                new Author {LastName = "Lucas", FirstName = "George"},
                new Author {LastName = "Kahn", FirstName = "James"}
            );
            context.SaveChanges();
            // ReSharper disable once InconsistentNaming
            var epIV = new Book
            {
                Name = "Episode IV – A New Hope",
                PublishedYear = 1976
            };
            epIV.Authors.Add(context.Authors.Single(x => x.LastName == "Foster"));
            var epV = new Book
            {
                Name = "Episode V – The Empire Strikes Back",
                PublishedYear = 1976
            };
            epV.Authors.Add(context.Authors.Single(x => x.LastName == "Glut"));
            // ReSharper disable once InconsistentNaming
            var epVI = new Book
            {
                Name = "Episode VI – Return of the Jedi",
                PublishedYear = 1983
            };
            epVI.Authors.Add(context.Authors.Single(x => x.LastName == "Kahn"));
            context.Books.AddOrUpdate(x => x.Name,
                epIV,
                epV,
                epVI
                );
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
