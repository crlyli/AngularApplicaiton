using AngularAspCore.Database.Repositories.DbContextData;
using Microsoft.EntityFrameworkCore;

namespace AngularAspCore.UnitTest.Helpers
{
    internal static class ApplicationDbContextHelper
    {
        public static ApplicationDbContext CreateDbContext()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;

            var dbContext = new ApplicationDbContext(contextOptions);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            return dbContext;
        }
    }
}
