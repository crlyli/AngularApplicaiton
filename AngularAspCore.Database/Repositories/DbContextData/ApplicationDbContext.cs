using Microsoft.EntityFrameworkCore;
using AngularAspCore.Database.Data.Models;

namespace AngularAspCore.Database.Repositories.DbContextData
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<BookDataModel> BookData { get; set; }
    }
}
