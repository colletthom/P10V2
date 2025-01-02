using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Front.VModel;

namespace Front.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {/*
            try
            {
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;                
                if (databaseCreator != null)
                {
                    databaseCreator.CreateTables();       
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            */
        }
    }
}
