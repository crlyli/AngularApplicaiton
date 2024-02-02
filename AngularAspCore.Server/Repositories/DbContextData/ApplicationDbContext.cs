using Microsoft.EntityFrameworkCore;
using AngularAspCore.Server.Data.Models.Domain;

namespace AngularAspCore.Server.Repositories.DbContextData
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<BookData> BookData { get; set; }
    }
}
