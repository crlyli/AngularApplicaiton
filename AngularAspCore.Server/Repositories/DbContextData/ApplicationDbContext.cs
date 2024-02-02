using Microsoft.EntityFrameworkCore;
using AngularAspCore.Server.Data.Models;

namespace AngularAspCore.Server.Repositories.DbContextData
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<BookDataModel> BookData { get; set; }
    }
}
