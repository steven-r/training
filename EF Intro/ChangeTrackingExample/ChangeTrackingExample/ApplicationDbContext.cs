using System.Data.Entity;
using ChangeTrackingExample.Entities;
using ChangeTrackingExample.Migrations;

namespace ChangeTrackingExample
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            Configuration.LazyLoadingEnabled = false;
        }

        static ApplicationDbContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, ApplicationDbInitializer>());
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
