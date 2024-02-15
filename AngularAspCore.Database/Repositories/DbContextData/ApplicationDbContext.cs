using Microsoft.EntityFrameworkCore;
using AngularAspCore.Database.Data.Models;

namespace AngularAspCore.Database.Repositories.DbContextData
{
    /// <summary>
    /// Database Context
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Database Context Constructor
        /// </summary>
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        /// <summary>
        /// Book Data Model DbSet
        /// </summary>
        public DbSet<BookDataModel> BookData { get; set; }

        /// <summary>
        /// Reading Log Data Model DbSet
        /// </summary>
        public DbSet<ReadingLogDataModel> ReadingLog { get; set; }

        /// <summary>
        /// Reader Data Model DbSet
        /// </summary>
        public DbSet<ReaderDataModel> Reader { get; set; }
    }
}
