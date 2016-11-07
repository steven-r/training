using System.Data.Entity;
using DataAnnotationsExample.Entities;
using DataAnnotationsExample.Migrations;

namespace DataAnnotationsExample
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            //Important performance code
            Configuration.AutoDetectChangesEnabled = false; 
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        static ApplicationDbContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, ApplicationDbInitializer>());
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
