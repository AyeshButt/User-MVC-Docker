using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace User_MVC_Docker.Models.Context
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {

            try
            {
                var databaseCreater = Database.GetService<IDatabaseCreator>()
                    as RelationalDatabaseCreator;
                if (databaseCreater != null)
                {
                    if (!databaseCreater.CanConnect())
                    {
                        databaseCreater.Create();
                    }
                    if (!databaseCreater.HasTables())
                    {
                        databaseCreater.CreateTables();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
