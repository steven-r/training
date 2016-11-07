using System.Data.Entity.Migrations;

namespace DataAnnotationsExample.Migrations
{
    public class ApplicationDbInitializer : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public ApplicationDbInitializer()
        {
            AutomaticMigrationsEnabled = true;
            // not allowed migration, if data loss is possible
            AutomaticMigrationDataLossAllowed = false;
        }

        // ReSharper disable once RedundantOverriddenMember
        protected override void Seed(ApplicationDbContext context)
        {
            base.Seed(context);
        }
    }
}
