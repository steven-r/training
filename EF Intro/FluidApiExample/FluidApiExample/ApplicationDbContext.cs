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


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasKey(x => x.Key);
            modelBuilder.Entity<Author>()
                .Property(x => x.FirstName).HasMaxLength(128).IsRequired();
            modelBuilder.Entity<Author>()
                .Property(x => x.LastName).HasMaxLength(128).IsRequired();

            modelBuilder.Entity<Book>()
                .HasKey(x => x.Key);
            modelBuilder.Entity<Book>()
                .Property(x => x.Name).HasMaxLength(128).IsRequired();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
