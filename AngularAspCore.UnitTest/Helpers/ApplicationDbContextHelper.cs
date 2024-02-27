using AngularAspCore.Database.Repositories.DbContextData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
